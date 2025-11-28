using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanBilliards.Forms
{
    public partial class fMain : Form
    {
        // Khai báo Context
        private QuanLyQuanBilliardsEntities db = new QuanLyQuanBilliardsEntities();

        // Biến lưu trạng thái hiện tại
        private int _selectedTableId = -1; // ID bàn đang được chọn
        private Timer _timerUpdateUI;      // Timer để cập nhật giờ trên nút bàn

        public fMain()
        {
            InitializeComponent();

            // Cài đặt Timer cập nhật giao diện (1 giây chạy 1 lần)
            _timerUpdateUI = new Timer();
            _timerUpdateUI.Interval = 1000;
            _timerUpdateUI.Tick += TimerUpdateUI_Tick;
            _timerUpdateUI.Start();

            // Khởi tạo
            InitializeForm();
            SetupEventHandlers();

            // Load dữ liệu
            LoadFilters();
            LoadServiceList(); // Load danh sách món ăn vào ComboBox
            LoadTables();      // Load danh sách bàn
        }

        private void InitializeForm()
        {
            UpdateDateTime();
            dgvHoaDon.Rows.Clear();
        }

        private void SetupEventHandlers()
        {
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnHuyHoaDon.Click += btnHuyHoaDon_Click;
            btnThanhToan.Click += btnThanhToan_Click;
            btnBatDauTinhGio.Click += btnBatDauTinhGio_Click;
            btnTinhTienBan.Click += BtnTinhTienBan_Click;

            cboLocKhuVuc.SelectedIndexChanged += Filter_Changed;
            cboLocTrangThai.SelectedIndexChanged += Filter_Changed;
            cboLocLoaiBan.SelectedIndexChanged += Filter_Changed;

            // Sự kiện khi click vào grid để đổ dữ liệu lên combobox/numeric
            dgvHoaDon.CellClick += DgvHoaDon_CellClick;
        }

        #region 1. QUẢN LÝ BÀN & HIỂN THỊ (Load Tables)

        private void LoadFilters()
        {
            // 1. Khu vực
            var listKhuVuc = db.KhuVucs.Select(k => k.TenKhuVuc).ToList();
            listKhuVuc.Insert(0, "Tất cả");
            cboLocKhuVuc.DataSource = listKhuVuc;

            // 2. Loại bàn (MỚI)
            var listLoaiBan = db.LoaiBans.Select(l => l.TenLoai).ToList();
            listLoaiBan.Insert(0, "Tất cả");
            cboLocLoaiBan.DataSource = listLoaiBan;
            // ------------------------------------

            // 3. Trạng thái
            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.Add("Tất cả");
            cboLocTrangThai.Items.Add("Trống");
            cboLocTrangThai.Items.Add("Có khách");
            cboLocTrangThai.Items.Add("Chờ thanh toán");
            cboLocTrangThai.SelectedIndex = 0;
        }

        private void Filter_Changed(object sender, EventArgs e) => LoadTables();

        private void LoadTables()
        {
            flpBan.SuspendLayout();
            flpBan.Controls.Clear();

            string filterKV = cboLocKhuVuc.SelectedItem?.ToString() ?? "Tất cả";
            string filterLB = cboLocLoaiBan.SelectedItem?.ToString() ?? "Tất cả";
            string filterTT = cboLocTrangThai.SelectedItem?.ToString() ?? "Tất cả";

            var query = db.Bans.AsNoTracking().AsQueryable();

            // Áp dụng bộ lọc
            if (filterKV != "Tất cả") query = query.Where(b => b.KhuVuc.TenKhuVuc == filterKV);
            if (filterLB != "Tất cả") query = query.Where(b => b.LoaiBan.TenLoai == filterLB);
            if (filterTT != "Tất cả") query = query.Where(b => b.TrangThai == filterTT);

            var listBan = query.OrderBy(b => b.BanID).ToList();

            foreach (var ban in listBan)
            {
                Button btn = new Button();
                btn.Name = "btnBan_" + ban.BanID;
                btn.Size = new Size(130, 110);
                btn.Margin = new Padding(5);
                btn.Tag = ban;
                btn.Click += BtnTable_Click;

                UpdateButtonVisual(btn, ban);

                flpBan.Controls.Add(btn);
            }
            flpBan.ResumeLayout();
        }

        // Hàm cập nhật màu sắc và text cho nút bàn
        private void UpdateButtonVisual(Button btn, Ban ban)
        {
            string status = ban.TrangThai;
            decimal gia = ban.LoaiBan != null ? ban.LoaiBan.GiaTheoGio : 0;
            string kv = ban.KhuVuc != null ? ban.KhuVuc.TenKhuVuc : "-";

            // Lấy tên Loại Bàn (MỚI)
            string tenLoai = ban.LoaiBan != null ? ban.LoaiBan.TenLoai : "-";

            string timeString = "00:00:00";

            // Phần xử lý màu sắc bàn
            if (ban.BanID == _selectedTableId)
            {
                btn.BackColor = Color.Yellow;
                btn.ForeColor = Color.Black;
            }
            else if (status == "Có khách")
            {
                btn.BackColor = Color.Green;
                btn.ForeColor = Color.White;
            }
            else if (status == "Chờ thanh toán")
            {
                btn.BackColor = Color.Orange;
                btn.ForeColor = Color.Black;
            }
            else
            {
                btn.BackColor = Color.DarkGray;
                btn.ForeColor = Color.Black;
            }

            // Phần xử lý thời gian
            if (status == "Có khách" || status == "Chờ thanh toán")
            {
                var hd = db.HoaDons.AsNoTracking()
                                   .OrderByDescending(h => h.HoaDonID)
                                   .FirstOrDefault(h => h.BanID == ban.BanID);
                if (hd != null)
                {
                    TimeSpan duration = TimeSpan.Zero;
                    if (status == "Chờ thanh toán" && hd.ThoiDiemThanhToan != null)
                        duration = hd.ThoiDiemThanhToan.Value - hd.ThoiDiemBatDau;
                    else
                        duration = DateTime.Now - hd.ThoiDiemBatDau;

                    timeString = string.Format("{0:D2}:{1:D2}:{2:D2}",
                        (int)duration.TotalHours, duration.Minutes, duration.Seconds);
                }
            }

            // THÔNG TIN CỦA BÀN
            // {0}: Tên bàn
            // {1}: Tên loại (MỚI)
            // {2}: Khu vực
            // {3}: Thời gian
            // {4}: Trạng thái
            // {5}: Giá
            btn.Text = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\nGiá: {5:N0}",
                ban.TenBan,
                tenLoai,
                kv,
                timeString,
                status,
                gia);

            btn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Ban ban = btn.Tag as Ban;
            if (ban == null) return;

            _selectedTableId = ban.BanID;

            // Cập nhật tiêu đề
            lblInvoiceTitle.Text = "Hóa đơn bàn " + ban.TenBan;
            lblMaHoaDon.Text = "Mã bàn: " + ban.BanID;

            // Load lại toàn bộ màu sắc các nút để hiển thị màu Vàng cho nút vừa chọn
            foreach (Control c in flpBan.Controls)
            {
                if (c is Button b && b.Tag is Ban t)
                {
                    UpdateButtonVisual(b, t);
                }
            }

            // Load dữ liệu hóa đơn của bàn này
            LoadInvoiceData(_selectedTableId);
        }

        #endregion

        #region 2. XỬ LÝ HÓA ĐƠN & TÍNH TIỀN (Load Invoice)
        private void LoadInvoiceData(int banID)
        {
            dgvHoaDon.Rows.Clear();

            // Reset Label về trạng thái "chưa tính"
            // Mỗi khi thêm/sửa/xóa món thì tiền cũ không còn đúng nữa -> Reset
            lblTienDichVu.Text = "Tiền dịch vụ: ---";
            lblTienBan.Text = "Tiền bàn: ---";
            lblTongTien.Text = "Tổng tiền: ---";
            // lblThoiGianKetThuc.Text = ... (Giữ nguyên hoặc reset tùy)

            // Tìm hóa đơn đang mở
            var hd = db.HoaDons.FirstOrDefault(h => h.BanID == banID && h.TrangThai == 0);

            if (hd != null)
            {
                lblMaHoaDon.Text = "Mã hóa đơn: " + hd.HoaDonID;
                lblThoiGianBatDau.Text = "Bắt đầu:\n" + hd.ThoiDiemBatDau.ToString("dd/MM/yyyy\nHH:mm:ss");

                var listCT = db.HoaDonChiTiets.Where(ct => ct.HoaDonID == hd.HoaDonID).ToList();

                if (listCT.Count > 0)
                {
                    // Lấy danh sách món duy nhất từ chi tiết hóa đơn
                    var listItemsInBill = listCT.Select(ct => new {
                        SanPhamID = ct.SanPhamID,
                        TenSP = ct.SanPham.TenSP
                    }).Distinct().ToList();

                    cboService.DataSource = listItemsInBill;
                    cboService.DisplayMember = "TenSP";
                    cboService.ValueMember = "SanPhamID";
                }
                else
                {
                    cboService.DataSource = null;
                }

                foreach (var item in listCT)
                {
                    var sp = db.SanPhams.Find(item.SanPhamID);
                    if (sp != null)
                    {
                        decimal thanhTien = item.SoLuong * item.DonGia;

                        // Thêm dòng vào Grid
                        int index = dgvHoaDon.Rows.Add();
                        dgvHoaDon.Rows[index].Tag = item.SanPhamID; // Tag lưu ID để Sửa/Xóa
                        dgvHoaDon.Rows[index].Cells[0].Value = sp.TenSP;
                        dgvHoaDon.Rows[index].Cells[1].Value = item.DonGia.ToString("N0");
                        dgvHoaDon.Rows[index].Cells[2].Value = item.SoLuong;
                        dgvHoaDon.Rows[index].Cells[3].Value = thanhTien.ToString("N0");
                    }
                }
            }
            else
            {
                // Không có hóa đơn
                lblMaHoaDon.Text = "Mã hóa đơn: --";
                lblThoiGianBatDau.Text = "Bắt đầu:\n--/--/--\n--:--:--";
                cboService.DataSource = null;
            }
        }

        private void CalculateTableFee(HoaDon hd)
        {
            if (hd == null) return;

            // Tính thời gian chơi
            TimeSpan duration = DateTime.Now - hd.ThoiDiemBatDau;
            double totalHours = duration.TotalHours;

            // Lấy giá bàn
            var ban = db.Bans.Find(hd.BanID);
            decimal pricePerHour = (ban != null && ban.LoaiBan != null) ? ban.LoaiBan.GiaTheoGio : 0;

            decimal tableFee = (decimal)totalHours * pricePerHour;

            lblTienBan.Text = string.Format("Tiền bàn: {0:N0}đ", tableFee);

            // Lấy tổng tiền dịch vụ hiện tại từ Label (parse ngược lại) hoặc tính lại
            decimal serviceFee = 0;
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Cells[3].Value != null)
                    serviceFee += decimal.Parse(row.Cells[3].Value.ToString().Replace(",", "").Replace(".", ""));
            }

            lblTongTien.Text = string.Format("Tổng tiền: {0:N0}đ", tableFee + serviceFee);
        }

        private void ResetTongTienUI()
        {
            lblTienDichVu.Text = "Tiền dịch vụ: 0đ";
            lblTienBan.Text = "Tiền bàn: 0đ";
            lblTongTien.Text = "Tổng tiền: 0đ";
            lblThoiGianKetThuc.Text = "Kết thúc:\n--/--/--\n--:--:--";
        }

        private void BtnTinhTienBan_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1) { MessageBox.Show("Vui lòng chọn bàn!"); return; }

            try
            {
                // 1. Gọi Stored Procedure để lấy số liệu chính xác
                var result = db.Database.SqlQuery<BillResult>("EXEC banhang.sp_TinhTienBan @BanID", new System.Data.SqlClient.SqlParameter("@BanID", _selectedTableId)).FirstOrDefault();

                if (result != null)
                {
                    // 2. TÍNH TOÁN TIỀN BÀN (Dựa trên giây)
                    // Công thức: (Số giây / 3600) * Giá 1 giờ
                    decimal gioChoi = (decimal)result.SoGiayChoi / 3600.0m;
                    decimal tienBan = gioChoi * result.GiaTheoGio;

                    // 3. TÍNH TỔNG
                    decimal tongTien = result.TienDichVu + tienBan;

                    // 4. HIỂN THỊ RA LABEL
                    // Hiển thị tiền dịch vụ
                    lblTienDichVu.Text = string.Format("Tiền dịch vụ: {0:N0}đ", result.TienDichVu);

                    // Hiển thị tiền bàn kèm chi tiết giờ chơi
                    // Quy đổi giây ra Giờ:Phút:Giây để user dễ nhìn
                    TimeSpan t = TimeSpan.FromSeconds(result.SoGiayChoi);
                    string thoiGianChoi = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);

                    lblTienBan.Text = string.Format("Tiền bàn: {0:N0}đ ({1})", tienBan, thoiGianChoi);

                    // Hiển thị tổng tiền
                    lblTongTien.Text = string.Format("Tổng tiền: {0:N0}đ", tongTien);

                    // Cập nhật ngày kết thúc
                    lblThoiGianKetThuc.Text = "Kết thúc:\n" + DateTime.Now.ToString("dd/MM/yyyy\nHH:mm:ss");

                    // 5. Cập nhật giao diện
                    LoadTables();
                }
                else
                {
                    MessageBox.Show("Lỗi: Không tìm thấy hóa đơn để tính tiền!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        #endregion

        #region 3. QUẢN LÝ DỊCH VỤ (Add/Edit/Delete Service)

        private void LoadServiceList()
        {
            // Load toàn bộ sản phẩm lên ComboBox
            var listSP = db.SanPhams.Where(sp => sp.TrangThai == "Còn").ToList();
            cboService.DataSource = listSP;
            cboService.DisplayMember = "TenSP";
            cboService.ValueMember = "SanPhamID";
        }

        // Khi click vào Grid thì fill data xuống panel Service
        private void DgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];

                // Lấy tên SP gán vào Combo
                string tenSP = row.Cells[0].Value.ToString();
                cboService.Text = tenSP; // Match text

                // Lấy số lượng
                decimal sl = decimal.Parse(row.Cells[2].Value.ToString());
                nudQuantity.Value = sl;
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1) { MessageBox.Show("Chọn bàn trước!"); return; }
            var hd = db.HoaDons.FirstOrDefault(h => h.BanID == _selectedTableId && h.TrangThai == 0);

            if (hd == null) { MessageBox.Show("Bàn chưa mở! Hãy bấm 'Bắt đầu tính giờ'."); return; }
            if (cboService.SelectedValue == null) return;

            int spID = (int)cboService.SelectedValue;
            var sp = db.SanPhams.Find(spID);
            decimal sl = nudQuantity.Value;

            // Kiểm tra xem món này đã có trong HĐ chưa
            var chiTiet = db.HoaDonChiTiets.FirstOrDefault(c => c.HoaDonID == hd.HoaDonID && c.SanPhamID == spID);

            if (chiTiet == null)
            {
                // Chưa có -> Thêm mới
                chiTiet = new HoaDonChiTiet();
                chiTiet.HoaDonID = hd.HoaDonID;
                chiTiet.SanPhamID = spID;
                chiTiet.SoLuong = sl;
                chiTiet.DonGia = sp.DonGia;
                db.HoaDonChiTiets.Add(chiTiet);
            }
            else
            {
                // Có rồi -> Cộng dồn số lượng
                chiTiet.SoLuong += sl;
            }

            db.SaveChanges();
            LoadInvoiceData(_selectedTableId); // Refresh Grid
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1 || dgvHoaDon.CurrentRow == null) return;

            // Lấy ID SP từ tag của dòng đang chọn
            if (dgvHoaDon.CurrentRow.Tag == null) return;
            int spID = (int)dgvHoaDon.CurrentRow.Tag;

            var hd = db.HoaDons.FirstOrDefault(h => h.BanID == _selectedTableId && h.TrangThai == 0);
            var chiTiet = db.HoaDonChiTiets.FirstOrDefault(c => c.HoaDonID == hd.HoaDonID && c.SanPhamID == spID);

            if (chiTiet != null)
            {
                chiTiet.SoLuong = nudQuantity.Value; // Cập nhật số lượng mới
                db.SaveChanges();
                LoadInvoiceData(_selectedTableId);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1 || dgvHoaDon.CurrentRow == null) return;

            if (MessageBox.Show("Xóa món này khỏi hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int spID = (int)dgvHoaDon.CurrentRow.Tag;
                var hd = db.HoaDons.FirstOrDefault(h => h.BanID == _selectedTableId && h.TrangThai == 0);
                var chiTiet = db.HoaDonChiTiets.FirstOrDefault(c => c.HoaDonID == hd.HoaDonID && c.SanPhamID == spID);

                if (chiTiet != null)
                {
                    db.HoaDonChiTiets.Remove(chiTiet);
                    db.SaveChanges();
                    LoadInvoiceData(_selectedTableId);
                }
            }
        }

        #endregion

        #region 4. TIMER & HELPER

        private void TimerUpdateUI_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();

            // Cập nhật text thời gian cho các nút bàn đang hoạt động
            foreach (Control c in flpBan.Controls)
            {
                if (c is Button btn && btn.Tag is Ban ban)
                {
                    if (ban.TrangThai == "Có khách")
                    {
                        UpdateButtonVisual(btn, ban);
                    }
                }
            }
        }

        private void UpdateDateTime()
        {
            lblNgayHienTai.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy | hh:mm:ss tt");
        }

        private void ClockTimer_Tick(object sender, EventArgs e) {}
        #endregion

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra bàn có đang hoạt động không
            var ban = db.Bans.AsNoTracking().FirstOrDefault(b => b.BanID == _selectedTableId);
            if (ban.TrangThai == "Trống")
            {
                MessageBox.Show("Bàn này đang trống, không thể hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hỏi xác nhận (Quan trọng vì hành động này không hoàn tác được)
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn HỦY hóa đơn bàn {ban.TenBan}?",
                "Xác nhận hủy",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Gọi Stored Procedure
                    db.Database.ExecuteSqlCommand(
                        "EXEC banhang.sp_HuyHoaDon @BanID",
                        new System.Data.SqlClient.SqlParameter("@BanID", _selectedTableId)
                    );

                    // Refresh lại giao diện
                    LoadTables();
                    LoadInvoiceData(_selectedTableId);

                    MessageBox.Show("Đã hủy hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1) { MessageBox.Show("Vui lòng chọn bàn cần thanh toán!"); return; }

            var ban = db.Bans.AsNoTracking().FirstOrDefault(b => b.BanID == _selectedTableId);
            if (ban.TrangThai == "Trống") { MessageBox.Show("Bàn đang trống!"); return; }

            // Mở form thanh toán mới
            fThanhToan frm = new fThanhToan(_selectedTableId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ResetTongTienUI();
                LoadTables();
                LoadInvoiceData(_selectedTableId);
            }
        }

        private void btnBatDauTinhGio_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1) { MessageBox.Show("Chưa chọn bàn!"); return; }

            // Kiểm tra trạng thái hiện tại
            var banCheck = db.Bans.AsNoTracking().FirstOrDefault(b => b.BanID == _selectedTableId);
            if (banCheck == null) return;

            if (banCheck.TrangThai == "Có khách" || banCheck.TrangThai == "Chờ thanh toán")
            {
                LoadInvoiceData(_selectedTableId);
                return;
            }

            try
            {
                var banToUpdate = db.Bans.Find(_selectedTableId);

                db.Entry(banToUpdate).Reload();

                banToUpdate.TrangThai = "Có khách";

                HoaDon hd = new HoaDon();
                hd.BanID = _selectedTableId;
                hd.TrangThai = 0;
                hd.ThoiDiemBatDau = DateTime.Now;
                hd.TongThanhToan = 0;
                hd.LoaiGiamGia = 0;
                hd.GiaTriGiam = 0;

                db.HoaDons.Add(hd);
                db.SaveChanges();

                LoadTables();
                LoadInvoiceData(_selectedTableId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở bàn: " + ex.Message);
            }
        }
        private void btnOrderMon_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần Order!");
                return;
            }

            // Kiểm tra trạng thái bàn (phải là "Có khách")
            var ban = db.Bans.AsNoTracking().FirstOrDefault(b => b.BanID == _selectedTableId);

            if (ban.TrangThai == "Trống" || ban.TrangThai == "Chờ thanh toán")
            {
                MessageBox.Show("Chỉ được Order cho bàn đang có khách (Đang tính giờ)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            fOrder frm = new fOrder(_selectedTableId);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadInvoiceData(_selectedTableId);
            }
        }
    }
    public class BillResult
    {
        public decimal TienDichVu { get; set; }
        public int SoGiayChoi { get; set; }
        public decimal GiaTheoGio { get; set; }
    }
}