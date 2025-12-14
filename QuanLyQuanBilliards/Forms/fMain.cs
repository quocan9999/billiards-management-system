using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyQuanBilliards.Helpers;

namespace QuanLyQuanBilliards.Forms
{
    public partial class fMain : Form
    {
        // Khai báo Context - sử dụng quyền theo vai trò người dùng hiện tại
        private QuanLyQuanBilliardsEntities db;

        // Biến lưu trạng thái hiện tại
        private int _selectedTableId = -1; // ID bàn đang được chọn
        private Timer _timerUpdateUI;      // Timer để cập nhật giờ trên nút bàn
        private bool _daTinhTienBan = false; // Biến kiểm tra đã tính tiền bàn chưa

        public fMain()
        {
            InitializeComponent();

            // Khởi tạo DbContext với quyền theo vai trò người dùng
            db = DatabaseHelper.CreateDbContext();

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
            LoadTables();      // Load danh sách bàn
        }

        /// <summary>
        /// Làm mới DbContext (vẫn giữ quyền theo vai trò)
        /// </summary>
        private void RefreshDbContext()
        {
            db.Dispose();
            db = DatabaseHelper.CreateDbContext();
        }

        private void InitializeForm()
        {
            UpdateDateTime();
            dgvHoaDon.Rows.Clear();
            btnThanhToan.Enabled = false; // Vô hiệu hóa nút Thanh toán ban đầu

            // Hiển thị tên nhân viên đang đăng nhập
            if (SessionManager.DaDangNhap)
            {
                // Hiển thị đầy đủ tên nhân viên với định dạng "Nhân viên: [Họ tên]"
                lblTenNhanVien.Text = $"Nhân viên: {SessionManager.HoTen}";
                
                // Tăng kích thước label để tránh bị cắt chuỗi
                lblTenNhanVien.Size = new System.Drawing.Size(250, 30); // Tăng từ 150 lên 250
                lblTenNhanVien.AutoSize = false; // Tắt AutoSize để dùng Size cố định
            }
            else
            {
                lblTenNhanVien.Text = "Nhân viên: Chưa đăng nhập";
                lblTenNhanVien.Size = new System.Drawing.Size(250, 30);
            }
        }

        private void SetupEventHandlers()
        {
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnHuyHoaDon.Click += btnHuyHoaDon_Click;
            btnThanhToan.Click += btnThanhToan_Click;
            btnBatDauTinhGio.Click += btnBatDauTinhGio_Click;
            btnTinhTienBan.Click += BtnTinhTienBan_Click;
            btnChuyenBan.Click += BtnChuyenBan_Click;

            cboLocKhuVuc.SelectedIndexChanged += Filter_Changed;
            cboLocTrangThai.SelectedIndexChanged += Filter_Changed;
            cboLocLoaiBan.SelectedIndexChanged += Filter_Changed;

            // Sự kiện khi click vào grid để đổ dữ liệu lên numeric
            dgvHoaDon.CellClick += DgvHoaDon_CellClick;
        }

        #region 1. QUẢN LÝ BÀN & HIỂN THỊ (Load Tables)

        private void LoadFilters()
        {
            // 1. Khu vực
            var listKhuVuc = db.KhuVucs.Select(k => k.TenKhuVuc).ToList();
            listKhuVuc.Insert(0, "Tất cả");
            cboLocKhuVuc.DataSource = listKhuVuc;

            // 2. Loại bàn
            var listLoaiBan = db.LoaiBans.Select(l => l.TenLoai).ToList();
            listLoaiBan.Insert(0, "Tất cả");
            cboLocLoaiBan.DataSource = listLoaiBan;

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

            // Lấy tên Loại Bàn
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
            _daTinhTienBan = false; // Reset trạng thái khi chọn bàn mới
            btnThanhToan.Enabled = false; // Vô hiệu hóa nút Thanh toán

            // Cập nhật tiêu đề
            lblInvoiceTitle.Text = "Hóa đơn bàn " + ban.TenBan;
            lblMaHoaDon.Text = "🎱 Bàn: " + ban.TenBan;

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
            lblTienDichVu.Text = "🍽️ Dịch vụ: ---";
            lblTienBan.Text = "🎱 Tiền bàn: ---";
            lblTongTien.Text = "💰 TỔNG: ---";

            // Tìm hóa đơn đang mở
            var hd = db.HoaDons.FirstOrDefault(h => h.BanID == banID && h.TrangThai == 0);

            if (hd != null)
            {
                lblMaHoaDon.Text = "📄 HÐ: #" + hd.HoaDonID;
                lblThoiGianBatDau.Text = "🟢 BẮT ĐẦU\n\nNgày: " + hd.ThoiDiemBatDau.ToString("dd/MM/yyyy") + "\nGiờ: " + hd.ThoiDiemBatDau.ToString("HH:mm:ss");

                // Gọi Stored Procedure sp_LayChiTietHoaDon
                var listCT = db.Database.SqlQuery<ChiTietHoaDonResult>(
                    "EXEC banhang.sp_LayChiTietHoaDon @BanID",
                    new System.Data.SqlClient.SqlParameter("@BanID", banID)
                ).ToList();

                foreach (var item in listCT)
                {
                    // Thêm dòng vào Grid
                    int index = dgvHoaDon.Rows.Add();
                    dgvHoaDon.Rows[index].Tag = item.SanPhamID; // Tag lưu ID để Sửa/Xóa
                    dgvHoaDon.Rows[index].Cells[0].Value = item.TenSP;
                    dgvHoaDon.Rows[index].Cells[1].Value = item.DonGia.ToString("N0");
                    dgvHoaDon.Rows[index].Cells[2].Value = item.SoLuong;
                    dgvHoaDon.Rows[index].Cells[3].Value = item.ThanhTien.ToString("N0");
                }
            }
            else
            {
                // Không có hóa đơn
                lblMaHoaDon.Text = "📄 HÐ: --";
                lblThoiGianBatDau.Text = "🟢 BẮT ĐẦU\n\nNgày: --/--/----\nGiờ: --:--:--";
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
            lblTienDichVu.Text = "🍽️ Dịch vụ: 0đ";
            lblTienBan.Text = "🎱 Tiền bàn: 0đ";
            lblTongTien.Text = "💰 TỔNG: 0đ";
            lblThoiGianKetThuc.Text = "🔴 KẾT THÚC\n\nNgày: --/--/----\nGiờ: --:--:--";
            _daTinhTienBan = false;
            btnThanhToan.Enabled = false;
        }

        private void BtnTinhTienBan_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1) { MessageBox.Show("Vui lòng chọn bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                // 1. Gọi Stored Procedure để lấy số liệu chính xác
                var result = db.Database.SqlQuery<BillResult>("EXEC banhang.sp_TinhTienBan @BanID", new System.Data.SqlClient.SqlParameter("@BanID", _selectedTableId)).FirstOrDefault();

                if (result != null)
                {
                    // 2. TÍNH TOÁN TIỀN BÀN (Dựa trên giây)
                    decimal gioChoi = (decimal)result.SoGiayChoi / 3600.0m;
                    decimal tienBan = gioChoi * result.GiaTheoGio;

                    // 3. TÍNH TỔNG
                    decimal tongTien = result.TienDichVu + tienBan;

                    // 4. HIỂN THỊ RA LABEL
                    lblTienDichVu.Text = string.Format("🍽️ Dịch vụ: {0:N0}đ", result.TienDichVu);

                    TimeSpan t = TimeSpan.FromSeconds(result.SoGiayChoi);
                    string thoiGianChoi = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);

                    lblTienBan.Text = string.Format("🎱 Bàn: {0:N0}đ ({1})", tienBan, thoiGianChoi);
                    lblTongTien.Text = string.Format("💰 TỔNG: {0:N0}đ", tongTien);
                    lblThoiGianKetThuc.Text = "🔴 KẾT THÚC\n\nNgày: " + DateTime.Now.ToString("dd/MM/yyyy") + "\nGiờ: " + DateTime.Now.ToString("HH:mm:ss");

                    // 5. Cho phép thanh toán sau khi đã tính tiền
                    _daTinhTienBan = true;
                    btnThanhToan.Enabled = true;

                    // 6. Cập nhật giao diện
                    LoadTables();
                    
                    MessageBox.Show("Tính tiền bàn thành công!\nNhấn thanh toán để thanh toán hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không tìm thấy hóa đơn để tính tiền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 3. QUẢN LÝ DỊCH VỤ (Edit/Delete Service)

        // Khi click vào Grid thì fill số lượng vào NumericUpDown
        private void DgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];

                // Lấy số lượng và hiển thị lên NumericUpDown
                if (row.Cells[2].Value != null)
                {
                    decimal sl = decimal.Parse(row.Cells[2].Value.ToString());
                    nudQuantity.Value = sl;
                }
            }
        }

        // Sửa số lượng món được chọn trong DataGridView
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1 || dgvHoaDon.CurrentRow == null) 
            {
                MessageBox.Show("Vui lòng chọn bàn và chọn món cần sửa trong danh sách!", "Thông báo");
                return; 
            }

            // Lấy ID SP từ tag của dòng đang chọn trong DataGridView
            if (dgvHoaDon.CurrentRow.Tag == null) 
            {
                MessageBox.Show("Vui lòng chọn món cần sửa trong danh sách!", "Thông báo");
                return;
            }
            
            int spID = (int)dgvHoaDon.CurrentRow.Tag;

            var hd = db.HoaDons.FirstOrDefault(h => h.BanID == _selectedTableId && h.TrangThai == 0);
            if (hd == null) return;

            var chiTiet = db.HoaDonChiTiets.FirstOrDefault(c => c.HoaDonID == hd.HoaDonID && c.SanPhamID == spID);

            if (chiTiet != null)
            {
                chiTiet.SoLuong = nudQuantity.Value; // Cập nhật số lượng mới
                db.SaveChanges();
                
                // Reset trạng thái tính tiền vì đã thay đổi hóa đơn
                _daTinhTienBan = false;
                btnThanhToan.Enabled = false;
                ResetTongTienUI();
                
                LoadInvoiceData(_selectedTableId);
                MessageBox.Show("Đã cập nhật số lượng thành công!\nVui lòng tính tiền lại trước khi thanh toán.", "Thông báo");
            }
        }

        // Xóa món được chọn trong DataGridView
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1 || dgvHoaDon.CurrentRow == null) 
            {
                MessageBox.Show("Vui lòng chọn bàn và chọn món cần xóa trong danh sách!", "Thông báo");
                return;
            }

            if (dgvHoaDon.CurrentRow.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa trong danh sách!", "Thông báo");
                return;
            }

            string tenMon = dgvHoaDon.CurrentRow.Cells[0].Value?.ToString() ?? "";

            if (MessageBox.Show($"Xóa món '{tenMon}' khỏi hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int spID = (int)dgvHoaDon.CurrentRow.Tag;
                var hd = db.HoaDons.FirstOrDefault(h => h.BanID == _selectedTableId && h.TrangThai == 0);
                var chiTiet = db.HoaDonChiTiets.FirstOrDefault(c => c.HoaDonID == hd.HoaDonID && c.SanPhamID == spID);

                if (chiTiet != null)
                {
                    db.HoaDonChiTiets.Remove(chiTiet);
                    db.SaveChanges();
                    
                    // Reset trạng thái tính tiền vì đã thay đổi hóa đơn
                    _daTinhTienBan = false;
                    btnThanhToan.Enabled = false;
                    ResetTongTienUI();
                    
                    LoadInvoiceData(_selectedTableId);
                    MessageBox.Show("Đã xóa món thành công!\nVui lòng tính tiền lại trước khi thanh toán.", "Thông báo");
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

            // Hỏi xác nhận
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn HỦY hóa đơn bàn {ban.TenBan}?",
                "Xác nhận hủy",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Gọi Stored Procedure với Transaction và xử lý kết quả trả về
                    var spResult = db.Database.SqlQuery<SPResult>(
                        "EXEC banhang.sp_HuyHoaDon @BanID",
                        new System.Data.SqlClient.SqlParameter("@BanID", _selectedTableId)
                    ).FirstOrDefault();

                    if (spResult != null && spResult.Success == 1)
                    {
                        ResetTongTienUI();
                        LoadTables();
                        LoadInvoiceData(_selectedTableId);
                        MessageBox.Show(spResult.Message ?? "Đã hủy hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(spResult?.Message ?? "Lỗi khi hủy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1) 
            { 
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return; 
            }

            // Kiểm tra đã tính tiền chưa
            if (!_daTinhTienBan)
            {
                MessageBox.Show("Vui lòng tính tiền bàn trước khi thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ban = db.Bans.AsNoTracking().FirstOrDefault(b => b.BanID == _selectedTableId);
            if (ban.TrangThai == "Trống") 
            { 
                MessageBox.Show("Bàn đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return; 
            }

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

            var banCheck = db.Bans.AsNoTracking().FirstOrDefault(b => b.BanID == _selectedTableId);
            if (banCheck == null) return;

            if (banCheck.TrangThai == "Có khách" || banCheck.TrangThai == "Chờ thanh toán")
            {
                LoadInvoiceData(_selectedTableId);
                return;
            }

            try
            {
                db.Database.ExecuteSqlCommand(
                    @"INSERT INTO banhang.HoaDon (BanID, TrangThai, ThoiDiemBatDau, TongThanhToan, LoaiGiamGia, GiaTriGiam, TongTienTruocGiam)
                      VALUES (@p0, 0, @p1, 0, 0, 0, 0)",
                    _selectedTableId,
                    DateTime.Now
                );

                LoadTables();
                LoadInvoiceData(_selectedTableId);
            }
            catch (Exception ex)
            {
                string errorMsg = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show("Lỗi khi mở bàn: " + errorMsg);
            }
        }

        private void btnOrderMon_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần Order!");
                return;
            }

            var ban = db.Bans.AsNoTracking().FirstOrDefault(b => b.BanID == _selectedTableId);

            if (ban.TrangThai == "Trống" || ban.TrangThai == "Chờ thanh toán")
            {
                MessageBox.Show("Chỉ được Order cho bàn đang có khách (Đang tính giờ)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            fOrder frm = new fOrder(_selectedTableId);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Reset trạng thái tính tiền vì đã thêm món mới
                _daTinhTienBan = false;
                btnThanhToan.Enabled = false;
                ResetTongTienUI();
                
                LoadInvoiceData(_selectedTableId);
            }
        }

        private void BtnChuyenBan_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần chuyển!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ban = db.Bans.AsNoTracking().FirstOrDefault(b => b.BanID == _selectedTableId);
            if (ban == null) return;

            if (ban.TrangThai == "Trống")
            {
                MessageBox.Show("Bàn đang trống, không thể chuyển!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ban.TrangThai == "Chờ thanh toán")
            {
                MessageBox.Show("Bàn đang chờ thanh toán, không thể chuyển!\nVui lòng thanh toán hoặc hủy trước.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            fChuyenBan frm = new fChuyenBan(_selectedTableId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _selectedTableId = -1;
                lblInvoiceTitle.Text = "Hóa đơn bàn --";
                lblMaHoaDon.Text = "📄 HÐ: --";
                dgvHoaDon.Rows.Clear();
                ResetTongTienUI();

                LoadTables();
            }
        }
    }
    public class BillResult
    {
        public decimal TienDichVu { get; set; }
        public int SoGiayChoi { get; set; }
        public decimal GiaTheoGio { get; set; }
    }

    /// <summary>
    /// Class để nhận kết quả trả về từ các Stored Procedure có Transaction
    /// </summary>
    public class SPResult
    {
        public int Success { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// Class để nhận kết quả trả về từ Stored Procedure sp_LayChiTietHoaDon
    /// </summary>
    public class ChiTietHoaDonResult
    {
        public int SanPhamID { get; set; }
        public string TenSP { get; set; }
        public decimal DonGia { get; set; }
        public decimal SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
    }
}