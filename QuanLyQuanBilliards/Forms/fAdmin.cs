using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyQuanBilliards.Helpers;

namespace QuanLyQuanBilliards.Forms
{
    public partial class fAdmin : Form
    {
        // Sử dụng quyền Admin (toàn quyền trên database)
        private QuanLyQuanBilliardsEntities db;

        // Binding sources
        BindingSource bsBan = new BindingSource();
        BindingSource bsSanPham = new BindingSource();
        BindingSource bsDanhMuc = new BindingSource();
        BindingSource bsKhuVuc = new BindingSource();
        BindingSource bsLoaiBan = new BindingSource();
        BindingSource bsTaiKhoan = new BindingSource();

        public fAdmin()
        {
            InitializeComponent();

            // Kiểm tra quyền Admin trước khi mở form
            if (!SessionManager.LaAdmin)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!\nChỉ Admin mới được phép.",
                    "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }

            // Khởi tạo DbContext với quyền Admin
            db = DatabaseHelper.CreateDbContext();

            LoadData();
            AddBindings();
            AddEvents();
        }

        /// <summary>
        /// Làm mới DbContext để tránh lỗi tracking (vẫn giữ quyền Admin)
        /// </summary>
        private void RefreshDbContext()
        {
            db.Dispose();
            db = DatabaseHelper.CreateDbContext();
        }

        private void LoadData()
        {
            dgvBan.DataSource = bsBan;
            dgvSanPham.DataSource = bsSanPham;
            dgvDanhMuc.DataSource = bsDanhMuc;
            dgvKhuVuc.DataSource = bsKhuVuc;
            dgvLoaiBan.DataSource = bsLoaiBan;
            dgvTaiKhoan.DataSource = bsTaiKhoan;

            LoadDateTimePicker();
            LoadAllLists();
            LoadComboBoxes();
            LoadBaoCaoNangCao();
        }

        private void LoadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);

            // Báo cáo nâng cao
            dtpBCNC_TuNgay.Value = new DateTime(today.Year, today.Month, 1);
            dtpBCNC_DenNgay.Value = today;
        }

        private void AddEvents()
        {
            // Báo cáo
            btnThongKe.Click += btnThongKe_Click;

            // Sản phẩm
            btnThemSP.Click += btnThemSP_Click;
            btnSuaSP.Click += btnSuaSP_Click;
            btnXoaSP.Click += btnXoaSP_Click;

            // Bàn
            btnThemBan.Click += btnThemBan_Click;
            btnSuaBan.Click += btnSuaBan_Click;
            btnXoaBan.Click += btnXoaBan_Click;

            // Danh mục
            btnThemCat.Click += (s, e) => AddCategory();
            btnSuaCat.Click += (s, e) => EditCategory();
            btnXoaCat.Click += (s, e) => DeleteCategory();

            // Khu vực
            btnThemKV.Click += (s, e) => AddArea();
            btnSuaKV.Click += (s, e) => EditArea();
            btnXoaKV.Click += (s, e) => DeleteArea();

            // Loại bàn
            btnThemLB.Click += (s, e) => AddTableType();
            btnSuaLB.Click += (s, e) => EditTableType();
            btnXoaLB.Click += (s, e) => DeleteTableType();

            // Tài khoản (sử dụng Trigger)
            btnThemTK.Click += (s, e) => AddAccount();
            btnSuaTK.Click += (s, e) => EditAccount();
            btnXoaTK.Click += (s, e) => DeleteAccount(); // Đổi thành xóa tài khoản

            // Báo cáo nâng cao (sử dụng Function và Cursor SP)
            btnBCNC_DongBo.Click += BtnBCNC_DongBo_Click;
            btnBCNC_XemBaoCao.Click += BtnBCNC_XemBaoCao_Click;
            btnBCNC_LamMoi.Click += (s, e) => LoadBaoCaoNangCao();

            // Bộ lọc Sản phẩm
            btnSPFilterLoc.Click += (s, e) => FilterSanPham();
            btnSPFilterXoa.Click += (s, e) => ClearSanPhamFilter();

            // Bộ lọc Bàn
            btnBanFilterLoc.Click += (s, e) => FilterBan();
            btnBanFilterXoa.Click += (s, e) => ClearBanFilter();
        }

        #region Báo Cáo Doanh Thu (Sử dụng DataTable)

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadRevenueReport(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void LoadRevenueReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                DataTable dt = new DataTable();

                using (var cmd = db.Database.Connection.CreateCommand())
                {
                    if (db.Database.Connection.State != ConnectionState.Open)
                        db.Database.Connection.Open();

                    cmd.CommandText = "EXEC baocao.sp_BaoCaoDoanhThu @TuNgay, @DenNgay";

                    var p1 = cmd.CreateParameter(); p1.ParameterName = "@TuNgay"; p1.Value = fromDate;
                    var p2 = cmd.CreateParameter(); p2.ParameterName = "@DenNgay"; p2.Value = toDate;
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);

                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }

                // 1. Gán dữ liệu vào Grid
                dgvDoanhThu.DataSource = dt;

                // 2. Format hiển thị số tiền
                if (dgvDoanhThu.Columns["Tổng Tiền"] != null)
                    dgvDoanhThu.Columns["Tổng Tiền"].DefaultCellStyle.Format = "N0";

                if (dgvDoanhThu.Columns["Giảm Giá"] != null)
                    dgvDoanhThu.Columns["Giảm Giá"].DefaultCellStyle.Format = "N0";

                if (dgvDoanhThu.Columns["Ngày Thanh Toán"] != null)
                    dgvDoanhThu.Columns["Ngày Thanh Toán"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // 3. Vẽ biểu đồ
                chartDoanhThu.Series["DoanhThu"].Points.Clear();

                // Group dữ liệu theo ngày để vẽ
                var chartData = dt.AsEnumerable()
                    .GroupBy(row => ((DateTime)row["Ngày Thanh Toán"]).Date)
                    .Select(g => new {
                        Date = g.Key,
                        // Lưu ý: SQL trả về Decimal cho cột [Tổng Tiền]
                        Total = g.Sum(row => row.Field<decimal>("Tổng Tiền"))
                    })
                    .OrderBy(x => x.Date)
                    .ToList();

                foreach (var item in chartData)
                {
                    chartDoanhThu.Series["DoanhThu"].Points.AddXY(item.Date.ToString("dd/MM"), item.Total);
                }

                chartDoanhThu.Series["DoanhThu"].IsValueShownAsLabel = true;
                chartDoanhThu.Series["DoanhThu"].LabelFormat = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message);
            }
        }
        #endregion

        #region Tải danh sách và Đổi tên cột
        private void LoadAllLists()
        {
            // Bàn (Sắp xếp theo ID tăng dần)
            bsBan.DataSource = db.Bans.OrderBy(x => x.BanID).Select(b => new {
                b.BanID,
                b.TenBan,
                KhuVuc = b.KhuVuc.TenKhuVuc,
                Loai = b.LoaiBan.TenLoai,
                b.TrangThai,
                KhuVucID = b.KhuVucID,
                LoaiBanID = b.LoaiBanID
            }).ToList();
            RenameColumns(dgvBan, "ID", "Tên Bàn", "Khu Vực", "Loại", "Trạng Thái");

            // Sản phẩm (Sắp xếp theo ID tăng dần)
            bsSanPham.DataSource = db.SanPhams.OrderBy(x => x.SanPhamID).Select(s => new {
                s.SanPhamID,
                s.TenSP,
                s.DonGia,
                DanhMuc = s.DanhMuc.TenDanhMuc,
                s.TrangThai,
                DanhMucID = s.DanhMucID
            }).ToList();
            RenameColumns(dgvSanPham, "ID", "Tên Món", "Đơn Giá", "Danh Mục", "Trạng Thái");

            // Danh mục
            bsDanhMuc.DataSource = db.DanhMucs.OrderBy(x => x.DanhMucID).Select(d => new { d.DanhMucID, d.TenDanhMuc }).ToList();
            RenameColumns(dgvDanhMuc, "ID", "Tên Danh Mục");

            // Khu vực
            bsKhuVuc.DataSource = db.KhuVucs.OrderBy(x => x.KhuVucID).Select(k => new { k.KhuVucID, k.TenKhuVuc }).ToList();
            RenameColumns(dgvKhuVuc, "ID", "Tên Khu Vực");

            // Loại bàn
            bsLoaiBan.DataSource = db.LoaiBans.OrderBy(x => x.LoaiBanID).Select(l => new { l.LoaiBanID, l.TenLoai, l.GiaTheoGio }).ToList();
            RenameColumns(dgvLoaiBan, "ID", "Tên Loại", "Giá/Giờ");

            // Tài khoản (kết hợp NguoiDung và NhanVien)
            LoadTaiKhoanList();
        }

        private void LoadTaiKhoanList()
        {
            // Thêm mật khẩu vào danh sách hiển thị
            var data = (from nd in db.NguoiDungs
                        join nv in db.NhanViens on nd.NguoiDungID equals nv.NguoiDungID into nvGroup
                        from nv in nvGroup.DefaultIfEmpty()
                        orderby nd.NguoiDungID
                        select new
                        {
                            nd.NguoiDungID,
                            nd.TenDangNhap,
                            nd.MatKhau, // Thêm mật khẩu
                            nd.VaiTro,
                            nd.TrangThai,
                            HoTen = nv != null ? nv.HoTen : "",
                            SoDienThoai = nv != null ? nv.SoDienThoai : "",
                            Email = nv != null ? nv.Email : "",
                            LuongCoBan = nv != null ? nv.LuongCoBan : 0
                        }).ToList();

            bsTaiKhoan.DataSource = data;
            RenameColumns(dgvTaiKhoan, "ID", "Tên đăng nhập", "Mật khẩu", "Vai trò", "Trạng thái", "Họ tên", "SĐT", "Email", "Lương");
        }

        private void RenameColumns(DataGridView dgv, params string[] headers)
        {
            for (int i = 0; i < headers.Length && i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].HeaderText = headers[i];
            }
            // Ẩn các cột ID phụ (nằm sau các cột hiển thị)
            if (dgv.Columns.Count > headers.Length)
            {
                for (int i = headers.Length; i < dgv.Columns.Count; i++)
                    dgv.Columns[i].Visible = false;
            }
        }

        private void LoadComboBoxes()
        {
            cboKhuVuc.DataSource = db.KhuVucs.ToList();
            cboKhuVuc.DisplayMember = "TenKhuVuc"; cboKhuVuc.ValueMember = "KhuVucID";

            cboLoaiBan.DataSource = db.LoaiBans.ToList();
            cboLoaiBan.DisplayMember = "TenLoai"; cboLoaiBan.ValueMember = "LoaiBanID";

            cboDanhMucSP.DataSource = db.DanhMucs.ToList();
            cboDanhMucSP.DisplayMember = "TenDanhMuc"; cboDanhMucSP.ValueMember = "DanhMucID";

            // Trạng thái sản phẩm
            cboTrangThaiSP.SelectedIndex = 0; // Còn

            // Tài khoản
            cboVaiTro.SelectedIndex = 1; // Nhân viên
            cboTrangThaiTK.SelectedIndex = 0; // Hoạt động

            // Bộ lọc Sản phẩm
            LoadSPFilterComboBox();

            // Bộ lọc Bàn
            LoadBanFilterComboBoxes();
        }

        /// <summary>
        /// Load dữ liệu cho ComboBox lọc Sản phẩm
        /// </summary>
        private void LoadSPFilterComboBox()
        {
            var danhMucList = new List<DanhMuc> { new DanhMuc { DanhMucID = 0, TenDanhMuc = "-- Tất cả --" } };
            danhMucList.AddRange(db.DanhMucs.ToList());
            cboSPFilterDanhMuc.DataSource = danhMucList;
            cboSPFilterDanhMuc.DisplayMember = "TenDanhMuc";
            cboSPFilterDanhMuc.ValueMember = "DanhMucID";
        }

        /// <summary>
        /// Load dữ liệu cho các ComboBox lọc Bàn
        /// </summary>
        private void LoadBanFilterComboBoxes()
        {
            // Khu vực
            var khuVucList = new List<KhuVuc> { new KhuVuc { KhuVucID = 0, TenKhuVuc = "-- Tất cả --" } };
            khuVucList.AddRange(db.KhuVucs.ToList());
            cboBanFilterKhuVuc.DataSource = khuVucList;
            cboBanFilterKhuVuc.DisplayMember = "TenKhuVuc";
            cboBanFilterKhuVuc.ValueMember = "KhuVucID";

            // Loại bàn
            var loaiBanList = new List<LoaiBan> { new LoaiBan { LoaiBanID = 0, TenLoai = "-- Tất cả --" } };
            loaiBanList.AddRange(db.LoaiBans.ToList());
            cboBanFilterLoaiBan.DataSource = loaiBanList;
            cboBanFilterLoaiBan.DisplayMember = "TenLoai";
            cboBanFilterLoaiBan.ValueMember = "LoaiBanID";
        }
        #endregion

        #region Bindings
        private void AddBindings()
        {
            // Bàn
            txtIDBan.DataBindings.Add("Text", bsBan, "BanID", true, DataSourceUpdateMode.Never);
            txtTenBan.DataBindings.Add("Text", bsBan, "TenBan", true, DataSourceUpdateMode.Never);
            dgvBan.SelectionChanged += (s, e) => {
                if (dgvBan.CurrentRow != null)
                {
                    try
                    {
                        cboKhuVuc.SelectedValue = dgvBan.CurrentRow.Cells["KhuVucID"].Value;
                        cboLoaiBan.SelectedValue = dgvBan.CurrentRow.Cells["LoaiBanID"].Value;
                    }
                    catch { }
                }
            };

            // Sản phẩm
            txtIDSP.DataBindings.Add("Text", bsSanPham, "SanPhamID", true, DataSourceUpdateMode.Never);
            txtTenSP.DataBindings.Add("Text", bsSanPham, "TenSP", true, DataSourceUpdateMode.Never);
            numGiaSP.DataBindings.Add("Value", bsSanPham, "DonGia", true, DataSourceUpdateMode.Never);
            dgvSanPham.SelectionChanged += (s, e) => {
                if (dgvSanPham.CurrentRow != null)
                {
                    try
                    {
                        cboDanhMucSP.SelectedValue = dgvSanPham.CurrentRow.Cells["DanhMucID"].Value;
                        // Sync trạng thái sản phẩm
                        var trangThai = dgvSanPham.CurrentRow.Cells["TrangThai"].Value?.ToString();
                        cboTrangThaiSP.SelectedItem = trangThai;
                    }
                    catch { }
                }
            };

            // Danh mục
            txtIDCat.DataBindings.Add("Text", bsDanhMuc, "DanhMucID", true, DataSourceUpdateMode.Never);
            txtTenCat.DataBindings.Add("Text", bsDanhMuc, "TenDanhMuc", true, DataSourceUpdateMode.Never);

            // Khu vực
            txtIDKV.DataBindings.Add("Text", bsKhuVuc, "KhuVucID", true, DataSourceUpdateMode.Never);
            txtTenKV.DataBindings.Add("Text", bsKhuVuc, "TenKhuVuc", true, DataSourceUpdateMode.Never);

            // Loại bàn
            txtIDLB.DataBindings.Add("Text", bsLoaiBan, "LoaiBanID", true, DataSourceUpdateMode.Never);
            txtTenLB.DataBindings.Add("Text", bsLoaiBan, "TenLoai", true, DataSourceUpdateMode.Never);
            numGiaLB.DataBindings.Add("Value", bsLoaiBan, "GiaTheoGio", true, DataSourceUpdateMode.Never);

            // Tài khoản
            txtIDTK.DataBindings.Add("Text", bsTaiKhoan, "NguoiDungID", true, DataSourceUpdateMode.Never);
            txtTenDangNhap.DataBindings.Add("Text", bsTaiKhoan, "TenDangNhap", true, DataSourceUpdateMode.Never);
            txtHoTen.DataBindings.Add("Text", bsTaiKhoan, "HoTen", true, DataSourceUpdateMode.Never);
            txtSoDienThoai.DataBindings.Add("Text", bsTaiKhoan, "SoDienThoai", true, DataSourceUpdateMode.Never);
            txtEmail.DataBindings.Add("Text", bsTaiKhoan, "Email", true, DataSourceUpdateMode.Never);

            dgvTaiKhoan.SelectionChanged += (s, e) => {
                if (dgvTaiKhoan.CurrentRow != null)
                {
                    try
                    {
                        // Sync mật khẩu từ DataGridView vào TextBox
                        var matKhau = dgvTaiKhoan.CurrentRow.Cells["MatKhau"].Value?.ToString();
                        txtMatKhauTK.Text = matKhau ?? "";

                        var vaiTro = dgvTaiKhoan.CurrentRow.Cells["VaiTro"].Value?.ToString();
                        cboVaiTro.SelectedItem = vaiTro;

                        var trangThai = dgvTaiKhoan.CurrentRow.Cells["TrangThai"].Value?.ToString();
                        cboTrangThaiTK.SelectedItem = trangThai;

                        var luong = dgvTaiKhoan.CurrentRow.Cells["LuongCoBan"].Value;
                        numLuong.Value = luong != null && luong != DBNull.Value ? Convert.ToDecimal(luong) : 0;
                    }
                    catch { }
                }
            };
        }
        #endregion

        #region Quản lý Tài khoản (Trigger tự động tạo NhanVien)

        /// <summary>
        /// Thêm tài khoản mới - Trigger sẽ tự động tạo NhanVien
        /// </summary>
        private void AddAccount()
        {
            try
            {
                RefreshDbContext(); // Làm mới context trước khi thêm
                
                if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhauTK.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra trùng
                if (db.NguoiDungs.Any(nd => nd.TenDangNhap == txtTenDangNhap.Text.Trim()))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 1. Tạo NguoiDung - TRIGGER sẽ tự động tạo NhanVien
                var nguoiDung = new NguoiDung
                {
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhauTK.Text.Trim(),
                    VaiTro = cboVaiTro.SelectedItem?.ToString() ?? "Nhân viên",
                    TrangThai = cboTrangThaiTK.SelectedItem?.ToString() ?? "Hoạt động",
                    NgayTao = DateTime.Now
                };

                db.NguoiDungs.Add(nguoiDung);
                db.SaveChanges(); // Trigger fires here!

                // Refresh context để lấy NhanVien mới được trigger tạo
                RefreshDbContext();

                // 2. Cập nhật thông tin NhanVien đã được Trigger tạo
                var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.NguoiDungID == nguoiDung.NguoiDungID);
                if (nhanVien != null)
                {
                    if (!string.IsNullOrWhiteSpace(txtHoTen.Text))
                        nhanVien.HoTen = txtHoTen.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
                        nhanVien.SoDienThoai = txtSoDienThoai.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                        nhanVien.Email = txtEmail.Text.Trim();
                    if (numLuong.Value > 0)
                        nhanVien.LuongCoBan = numLuong.Value;

                    db.SaveChanges();
                }

                RefreshDbContext();
                LoadTaiKhoanList();
                ClearAccountInputs();
                MessageBox.Show("Thêm tài khoản thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        /// <summary>
        /// Sửa thông tin tài khoản (bao gồm tên đăng nhập)
        /// </summary>
        private void EditAccount()
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDTK.Text)) return;

                RefreshDbContext(); // Làm mới context trước khi sửa
                
                int id = int.Parse(txtIDTK.Text);
                string tenDangNhapMoi = txtTenDangNhap.Text.Trim();

                // Kiểm tra trùng tên đăng nhập (trừ tài khoản hiện tại)
                bool daTonTai = db.NguoiDungs.Any(nd => nd.TenDangNhap == tenDangNhapMoi && nd.NguoiDungID != id);
                if (daTonTai)
                {
                    MessageBox.Show($"Tên đăng nhập '{tenDangNhapMoi}' đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nguoiDung = db.NguoiDungs.Find(id);

                if (nguoiDung != null)
                {
                    // Cập nhật tên đăng nhập
                    nguoiDung.TenDangNhap = tenDangNhapMoi;
                    nguoiDung.VaiTro = cboVaiTro.SelectedItem?.ToString() ?? nguoiDung.VaiTro;
                    nguoiDung.TrangThai = cboTrangThaiTK.SelectedItem?.ToString() ?? nguoiDung.TrangThai;

                    // Cập nhật mật khẩu nếu có nhập
                    if (!string.IsNullOrWhiteSpace(txtMatKhauTK.Text))
                        nguoiDung.MatKhau = txtMatKhauTK.Text.Trim();

                    // Cập nhật NhanVien
                    var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.NguoiDungID == id);
                    if (nhanVien != null)
                    {
                        if (!string.IsNullOrWhiteSpace(txtHoTen.Text))
                            nhanVien.HoTen = txtHoTen.Text.Trim();
                        nhanVien.SoDienThoai = txtSoDienThoai.Text?.Trim();
                        nhanVien.Email = txtEmail.Text?.Trim();
                        nhanVien.LuongCoBan = numLuong.Value;
                    }

                    db.SaveChanges();
                    RefreshDbContext();
                    LoadTaiKhoanList();
                    MessageBox.Show("Cập nhật thành công!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        /// <summary>
        /// Xóa tài khoản (xóa vĩnh viễn)
        /// </summary>
        private void DeleteAccount()
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDTK.Text)) return;

                int id = int.Parse(txtIDTK.Text);
                
                // Xác nhận trước khi xóa
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa tài khoản này?\nLưu ý: Tài khoản và thông tin nhân viên liên quan sẽ bị xóa vĩnh viễn!",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                    
                if (result == DialogResult.Yes)
                {
                    RefreshDbContext();
                    
                    // Kiểm tra xem tài khoản có hóa đơn không
                    bool coHoaDon = db.HoaDons.Any(hd => hd.NguoiLapID == id);
                    if (coHoaDon)
                    {
                        MessageBox.Show("Không thể xóa tài khoản vì đã có hóa đơn liên quan!\nBạn có thể đổi trạng thái thành 'Khóa' để vô hiệu hóa tài khoản.", 
                            "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    // Xóa NhanVien trước (do có FK)
                    db.Database.ExecuteSqlCommand("DELETE FROM phanquyen.NhanVien WHERE NguoiDungID = @p0", id);
                    // Sau đó xóa NguoiDung
                    db.Database.ExecuteSqlCommand("DELETE FROM phanquyen.NguoiDung WHERE NguoiDungID = @p0", id);
                    
                    RefreshDbContext();
                    LoadTaiKhoanList();
                    ClearAccountInputs();
                    MessageBox.Show("Xóa tài khoản thành công!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        private void ClearAccountInputs()
        {
            txtIDTK.Clear();
            txtTenDangNhap.Clear();
            txtMatKhauTK.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            numLuong.Value = 0;
            cboVaiTro.SelectedIndex = 1;
            cboTrangThaiTK.SelectedIndex = 0;
        }

        #endregion

        #region Báo cáo Nâng cao (Function và Cursor SP)

        /// <summary>
        /// Load thống kê nhanh sử dụng SQL Functions
        /// </summary>
        private void LoadBaoCaoNangCao()
        {
            try
            {
                DateTime today = DateTime.Today;
                DateTime dauThang = new DateTime(today.Year, today.Month, 1);
                DateTime cuoiThang = dauThang.AddMonths(1).AddDays(-1);

                // Gọi các SQL Function
                lblBCNC_GiaTriDoanhThuHomNay.Text = GetDoanhThuNgay(today).ToString("#,##0") + " đ";
                lblBCNC_GiaTriSoHoaDon.Text = GetSoHoaDonNgay(today).ToString();
                lblBCNC_GiaTriTrungBinh.Text = GetDoanhThuTrungBinhNgay(today).ToString("#,##0") + " đ";
                lblBCNC_GiaTriDoanhThuThang.Text = GetDoanhThuKhoangThoiGian(dauThang, cuoiThang).ToString("#,##0") + " đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê: " + ex.Message);
            }
        }

        private decimal GetDoanhThuNgay(DateTime ngay)
        {
            var param = new SqlParameter("@Ngay", SqlDbType.Date) { Value = ngay };
            return db.Database.SqlQuery<decimal>("SELECT baocao.fn_TinhTongTienNgay(@Ngay)", param).FirstOrDefault();
        }

        private int GetSoHoaDonNgay(DateTime ngay)
        {
            var param = new SqlParameter("@Ngay", SqlDbType.Date) { Value = ngay };
            return db.Database.SqlQuery<int>("SELECT baocao.fn_DemHoaDonNgay(@Ngay)", param).FirstOrDefault();
        }

        private decimal GetDoanhThuTrungBinhNgay(DateTime ngay)
        {
            var param = new SqlParameter("@Ngay", SqlDbType.Date) { Value = ngay };
            return db.Database.SqlQuery<decimal>("SELECT baocao.fn_DoanhThuTrungBinhNgay(@Ngay)", param).FirstOrDefault();
        }

        private decimal GetDoanhThuKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            return db.Database.SqlQuery<decimal>(
                "SELECT baocao.fn_TinhDoanhThuKhoangThoiGian(@TuNgay, @DenNgay)",
                new SqlParameter("@TuNgay", SqlDbType.Date) { Value = tuNgay },
                new SqlParameter("@DenNgay", SqlDbType.Date) { Value = denNgay }).FirstOrDefault();
        }

        /// <summary>
        /// Đồng bộ báo cáo sử dụng Cursor SP
        /// </summary>
        private void BtnBCNC_DongBo_Click(object sender, EventArgs e)
        {
            if (dtpBCNC_TuNgay.Value > dtpBCNC_DenNgay.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                var result = db.Database.SqlQuery<DongBoResult>(
                    "EXEC baocao.sp_DongBoBaoCao @TuNgay, @DenNgay, @GhiDe",
                    new SqlParameter("@TuNgay", SqlDbType.Date) { Value = dtpBCNC_TuNgay.Value.Date },
                    new SqlParameter("@DenNgay", SqlDbType.Date) { Value = dtpBCNC_DenNgay.Value.Date },
                    new SqlParameter("@GhiDe", SqlDbType.Bit) { Value = chkBCNC_GhiDe.Checked }).FirstOrDefault();

                if (result != null)
                {
                    MessageBox.Show(
                        $"Đồng bộ thành công!\n\n" +
                        $"Tổng số ngày xử lý: {result.TongSoNgayXuLy}\n" +
                        $"Thêm mới: {result.SoBaoCaoThemMoi}\n" +
                        $"Cập nhật: {result.SoBaoCaoCapNhat}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadBaoCaoNangCao();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đồng bộ: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Xem báo cáo theo ngày
        /// </summary>
        private void BtnBCNC_XemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DataTable dt = new DataTable();
                using (var cmd = db.Database.Connection.CreateCommand())
                {
                    if (db.Database.Connection.State != ConnectionState.Open)
                        db.Database.Connection.Open();

                    cmd.CommandText = "EXEC baocao.sp_XemBaoCaoTheoNgay @TuNgay, @DenNgay";
                    var p1 = cmd.CreateParameter(); p1.ParameterName = "@TuNgay"; p1.Value = dtpBCNC_TuNgay.Value.Date;
                    var p2 = cmd.CreateParameter(); p2.ParameterName = "@DenNgay"; p2.Value = dtpBCNC_DenNgay.Value.Date;
                    cmd.Parameters.Add(p1); cmd.Parameters.Add(p2);

                    using (var reader = cmd.ExecuteReader()) { dt.Load(reader); }
                }

                dgvBCNC_BaoCao.DataSource = dt;

                // Đổi tên cột sang tiếng Việt có dấu
                if (dgvBCNC_BaoCao.Columns["Ngay"] != null)
                {
                    dgvBCNC_BaoCao.Columns["Ngay"].HeaderText = "Ngày";
                    dgvBCNC_BaoCao.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (dgvBCNC_BaoCao.Columns["ThuTrongTuan"] != null)
                    dgvBCNC_BaoCao.Columns["ThuTrongTuan"].HeaderText = "Thứ Trong Tuần";
                if (dgvBCNC_BaoCao.Columns["DoanhThu"] != null)
                {
                    dgvBCNC_BaoCao.Columns["DoanhThu"].HeaderText = "Doanh Thu";
                    dgvBCNC_BaoCao.Columns["DoanhThu"].DefaultCellStyle.Format = "#,##0";
                }
                if (dgvBCNC_BaoCao.Columns["SoHoaDon"] != null)
                    dgvBCNC_BaoCao.Columns["SoHoaDon"].HeaderText = "Số Hóa Đơn";
                if (dgvBCNC_BaoCao.Columns["TrungBinhMoiHoaDon"] != null)
                {
                    dgvBCNC_BaoCao.Columns["TrungBinhMoiHoaDon"].HeaderText = "Trung Bình Mỗi Hóa Đơn";
                    dgvBCNC_BaoCao.Columns["TrungBinhMoiHoaDon"].DefaultCellStyle.Format = "#,##0";
                }

                // Chuyển thứ trong tuần sang tiếng Việt
                ConvertDayOfWeekToVietnamese();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            finally { Cursor = Cursors.Default; }
        }

        private class DongBoResult
        {
            public int TongSoNgayXuLy { get; set; }
            public int SoBaoCaoThemMoi { get; set; }
            public int SoBaoCaoCapNhat { get; set; }
            public DateTime TuNgay { get; set; }
            public DateTime DenNgay { get; set; }
            public string ThongBao { get; set; }
        }

        /// <summary>
        /// Chuyển đổi thứ trong tuần sang tiếng Việt
        /// </summary>
        private void ConvertDayOfWeekToVietnamese()
        {
            if (dgvBCNC_BaoCao.Columns["ThuTrongTuan"] == null) return;

            foreach (DataGridViewRow row in dgvBCNC_BaoCao.Rows)
            {
                if (row.Cells["ThuTrongTuan"].Value != null)
                {
                    string dayEnglish = row.Cells["ThuTrongTuan"].Value.ToString();
                    row.Cells["ThuTrongTuan"].Value = ConvertToVietnameseDayName(dayEnglish);
                }
            }
        }

        /// <summary>
        /// Chuyển tên thứ tiếng Anh sang tiếng Việt
        /// </summary>
        private string ConvertToVietnameseDayName(string englishDay)
        {
            switch (englishDay?.ToLower())
            {
                case "monday": return "Thứ Hai";
                case "tuesday": return "Thứ Ba";
                case "wednesday": return "Thứ Tư";
                case "thursday": return "Thứ Năm";
                case "friday": return "Thứ Sáu";
                case "saturday": return "Thứ Bảy";
                case "sunday": return "Chủ Nhật";
                default: return englishDay;
            }
        }

        #endregion

        #region Bộ lọc Sản phẩm và Bàn

        /// <summary>
        /// Lọc sản phẩm theo danh mục và tên
        /// </summary>
        private void FilterSanPham()
        {
            int danhMucID = cboSPFilterDanhMuc.SelectedValue != null ? (int)cboSPFilterDanhMuc.SelectedValue : 0;
            string tenSP = txtSPFilterTen.Text.Trim().ToLower();

            var query = db.SanPhams.OrderBy(x => x.SanPhamID).AsQueryable();

            if (danhMucID > 0)
                query = query.Where(sp => sp.DanhMucID == danhMucID);

            if (!string.IsNullOrEmpty(tenSP))
                query = query.Where(sp => sp.TenSP.ToLower().Contains(tenSP));

            bsSanPham.DataSource = query.Select(s => new {
                s.SanPhamID,
                s.TenSP,
                s.DonGia,
                DanhMuc = s.DanhMuc.TenDanhMuc,
                s.TrangThai,
                DanhMucID = s.DanhMucID
            }).ToList();

            RenameColumns(dgvSanPham, "ID", "Tên Món", "Đơn Giá", "Danh Mục", "Trạng Thái");
        }

        /// <summary>
        /// Xóa bộ lọc sản phẩm
        /// </summary>
        private void ClearSanPhamFilter()
        {
            cboSPFilterDanhMuc.SelectedIndex = 0;
            txtSPFilterTen.Clear();
            LoadAllLists();
        }

        /// <summary>
        /// Lọc bàn theo khu vực, loại bàn và tên
        /// </summary>
        private void FilterBan()
        {
            int khuVucID = cboBanFilterKhuVuc.SelectedValue != null ? (int)cboBanFilterKhuVuc.SelectedValue : 0;
            int loaiBanID = cboBanFilterLoaiBan.SelectedValue != null ? (int)cboBanFilterLoaiBan.SelectedValue : 0;
            string tenBan = txtBanFilterTen.Text.Trim().ToLower();

            var query = db.Bans.OrderBy(x => x.BanID).AsQueryable();

            if (khuVucID > 0)
                query = query.Where(b => b.KhuVucID == khuVucID);

            if (loaiBanID > 0)
                query = query.Where(b => b.LoaiBanID == loaiBanID);

            if (!string.IsNullOrEmpty(tenBan))
                query = query.Where(b => b.TenBan.ToLower().Contains(tenBan));

            bsBan.DataSource = query.Select(b => new {
                b.BanID,
                b.TenBan,
                KhuVuc = b.KhuVuc.TenKhuVuc,
                Loai = b.LoaiBan.TenLoai,
                b.TrangThai,
                KhuVucID = b.KhuVucID,
                LoaiBanID = b.LoaiBanID
            }).ToList();

            RenameColumns(dgvBan, "ID", "Tên Bàn", "Khu Vực", "Loại", "Trạng Thái");
        }

        /// <summary>
        /// Xóa bộ lọc bàn
        /// </summary>
        private void ClearBanFilter()
        {
            cboBanFilterKhuVuc.SelectedIndex = 0;
            cboBanFilterLoaiBan.SelectedIndex = 0;
            txtBanFilterTen.Clear();
            LoadAllLists();
        }

        #endregion

        #region Logic CRUD
        // --- SẢN PHẨM ---
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshDbContext(); // Làm mới context trước khi thêm

                var trangThai = cboTrangThaiSP.SelectedItem?.ToString() ?? "Còn";
                db.SanPhams.Add(new SanPham() {
                    TenSP = txtTenSP.Text,
                    DonGia = numGiaSP.Value,
                    DanhMucID = (int)cboDanhMucSP.SelectedValue,
                    TrangThai = trangThai
                });
                db.SaveChanges();
                RefreshDbContext();
                LoadAllLists();
                LoadComboBoxes();
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDSP.Text)) return;

                RefreshDbContext(); // Làm mới context trước khi sửa

                int id = int.Parse(txtIDSP.Text);
                var item = db.SanPhams.Find(id);
                if (item != null)
                {
                    item.TenSP = txtTenSP.Text;
                    item.DonGia = numGiaSP.Value;
                    item.DanhMucID = (int)cboDanhMucSP.SelectedValue;
                    item.TrangThai = cboTrangThaiSP.SelectedItem?.ToString() ?? item.TrangThai;
                    db.SaveChanges();
                    RefreshDbContext();
                    LoadAllLists();
                    LoadComboBoxes();
                    MessageBox.Show("Sửa thành công");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDSP.Text)) return;

                int id = int.Parse(txtIDSP.Text);

                // Xác nhận trước khi xóa
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa sản phẩm này?\nLưu ý: Sản phẩm sẽ bị xóa vĩnh viễn!",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Kiểm tra sản phẩm có trong hóa đơn chi tiết không
                    bool dangSuDung = db.HoaDonChiTiets.Any(hdct => hdct.SanPhamID == id);
                    if (dangSuDung)
                    {
                        MessageBox.Show("Không thể xóa sản phẩm vì đang được sử dụng trong hóa đơn!",
                            "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xóa sản phẩm bằng raw SQL để tránh lỗi EF tracking
                    db.Database.ExecuteSqlCommand("DELETE FROM danhmuc.SanPham WHERE SanPhamID = @p0", id);
                    RefreshDbContext();
                    LoadAllLists();
                    LoadComboBoxes();
                    MessageBox.Show("Xóa sản phẩm thành công!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        // --- BÀN ---
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshDbContext(); // Làm mới context trước khi thêm

                string tenBan = txtTenBan.Text.Trim();
                int khuVucID = (int)cboKhuVuc.SelectedValue;

                // Kiểm tra trùng tên bàn trong cùng khu vực
                bool daTonTai = db.Bans.Any(b => b.TenBan == tenBan && b.KhuVucID == khuVucID);
                if (daTonTai)
                {
                    MessageBox.Show($"Tên bàn '{tenBan}' đã tồn tại trong khu vực này!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ban = new Ban()
                {
                    TenBan = tenBan,
                    KhuVucID = khuVucID,
                    LoaiBanID = (int)cboLoaiBan.SelectedValue,
                    TrangThai = "Trống"
                };
                db.Bans.Add(ban);
                db.SaveChanges();
                RefreshDbContext();
                LoadAllLists();
                LoadComboBoxes();
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDBan.Text)) return;

                int id = int.Parse(txtIDBan.Text);
                string tenBan = txtTenBan.Text.Trim();
                int khuVucID = (int)cboKhuVuc.SelectedValue;
                int loaiBanID = (int)cboLoaiBan.SelectedValue;

                // Làm mới context trước khi sửa
                RefreshDbContext();

                // Lấy thông tin bàn hiện tại từ database
                var banHienTai = db.Bans.Find(id);
                if (banHienTai == null)
                {
                    MessageBox.Show("Không tìm thấy bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Chỉ kiểm tra trùng tên khi tên bàn HOẶC khu vực thay đổi
                bool tenThayDoi = banHienTai.TenBan != tenBan;
                bool khuVucThayDoi = banHienTai.KhuVucID != khuVucID;

                if (tenThayDoi || khuVucThayDoi)
                {
                    // Kiểm tra trùng tên bàn trong cùng khu vực (trừ bàn hiện tại)
                    bool daTonTai = db.Bans.Any(b => b.TenBan == tenBan && b.KhuVucID == khuVucID && b.BanID != id);
                    if (daTonTai)
                    {
                        MessageBox.Show($"Tên bàn '{tenBan}' đã tồn tại trong khu vực này!", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Cập nhật thông tin bàn
                banHienTai.TenBan = tenBan;
                banHienTai.KhuVucID = khuVucID;
                banHienTai.LoaiBanID = loaiBanID;
                
                db.SaveChanges();
                RefreshDbContext();
                LoadAllLists();
                LoadComboBoxes();
                MessageBox.Show("Sửa thành công");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDBan.Text)) return;
                int id = int.Parse(txtIDBan.Text);

                // Sử dụng raw SQL để xóa, tránh lỗi EF tracking với triggers
                db.Database.ExecuteSqlCommand("DELETE FROM danhmuc.Ban WHERE BanID = @p0", id);
                RefreshDbContext();
                LoadAllLists();
                LoadComboBoxes();
                MessageBox.Show("Xóa thành công");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        // --- DANH MỤC ---
        private void AddCategory()
        {
            try
            {
                RefreshDbContext(); // Làm mới context trước khi thêm

                string tenDanhMuc = txtTenCat.Text.Trim();

                // Kiểm tra trùng tên danh mục
                bool daTonTai = db.DanhMucs.Any(d => d.TenDanhMuc == tenDanhMuc);
                if (daTonTai)
                {
                    MessageBox.Show($"Tên danh mục '{tenDanhMuc}' đã tồn tại!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.DanhMucs.Add(new DanhMuc() { TenDanhMuc = tenDanhMuc });
                db.SaveChanges();
                RefreshDbContext();
                LoadAllLists();
                LoadComboBoxes();
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        private void EditCategory()
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDCat.Text)) return;

                RefreshDbContext(); // Làm mới context trước khi sửa

                int id = int.Parse(txtIDCat.Text);
                string tenDanhMuc = txtTenCat.Text.Trim();

                // Kiểm tra trùng tên danh mục (trừ danh mục hiện tại)
                bool daTonTai = db.DanhMucs.Any(d => d.TenDanhMuc == tenDanhMuc && d.DanhMucID != id);
                if (daTonTai)
                {
                    MessageBox.Show($"Tên danh mục '{tenDanhMuc}' đã tồn tại!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var item = db.DanhMucs.Find(id);
                if (item != null)
                {
                    item.TenDanhMuc = tenDanhMuc;
                    db.SaveChanges();
                    RefreshDbContext();
                    LoadAllLists();
                    LoadComboBoxes();
                    MessageBox.Show("Sửa thành công");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        private void DeleteCategory()
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDCat.Text)) return;
                int id = int.Parse(txtIDCat.Text);

                // Kiểm tra nếu danh mục có sản phẩm
                var productCount = db.SanPhams.Count(sp => sp.DanhMucID == id);
                if (productCount > 0)
                {
                    MessageBox.Show($"Không thể xóa danh mục vì đang có {productCount} sản phẩm!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Database.ExecuteSqlCommand("DELETE FROM danhmuc.DanhMuc WHERE DanhMucID = @p0", id);
                RefreshDbContext();
                LoadAllLists();
                LoadComboBoxes();
                MessageBox.Show("Xóa thành công");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        // --- KHU VỰC ---
        private void AddArea()
        {
            try
            {
                RefreshDbContext(); // Làm mới context trước khi thêm

                string tenKhuVuc = txtTenKV.Text.Trim();

                // Kiểm tra trùng tên khu vực
                bool daTonTai = db.KhuVucs.Any(k => k.TenKhuVuc == tenKhuVuc);
                if (daTonTai)
                {
                    MessageBox.Show($"Tên khu vực '{tenKhuVuc}' đã tồn tại!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.KhuVucs.Add(new KhuVuc() { TenKhuVuc = tenKhuVuc, TangSo = 0 });
                db.SaveChanges();
                RefreshDbContext();
                LoadAllLists();
                LoadComboBoxes();
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        private void EditArea()
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDKV.Text)) return;

                RefreshDbContext(); // Làm mới context trước khi sửa

                int id = int.Parse(txtIDKV.Text);
                string tenKhuVuc = txtTenKV.Text.Trim();

                // Kiểm tra trùng tên khu vực (trừ khu vực hiện tại)
                bool daTonTai = db.KhuVucs.Any(k => k.TenKhuVuc == tenKhuVuc && k.KhuVucID != id);
                if (daTonTai)
                {
                    MessageBox.Show($"Tên khu vực '{tenKhuVuc}' đã tồn tại!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var item = db.KhuVucs.Find(id);
                if (item != null)
                {
                    item.TenKhuVuc = tenKhuVuc;
                    db.SaveChanges();
                    RefreshDbContext();
                    LoadAllLists();
                    LoadComboBoxes();
                    MessageBox.Show("Sửa thành công");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        /// <summary>
        /// Xóa khu vực - Trigger trg_ValidateXoaKhuVuc sẽ ngăn chặn nếu khu vực đang có bàn
        /// </summary>
        private void DeleteArea()
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDKV.Text)) return;

                int id = int.Parse(txtIDKV.Text);

                // Kiểm tra nếu khu vực có bàn trước khi xóa
                var tableCount = db.Bans.Count(b => b.KhuVucID == id);
                if (tableCount > 0)
                {
                    MessageBox.Show($"Không thể xóa khu vực vì đang có {tableCount} bàn!", "Không thể xóa",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận xóa
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa khu vực này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Sử dụng raw SQL để xóa, hoạt động với INSTEAD OF trigger
                    db.Database.ExecuteSqlCommand("DELETE FROM danhmuc.KhuVuc WHERE KhuVucID = @p0", id);
                    RefreshDbContext();
                    LoadAllLists();
                    LoadComboBoxes();
                    MessageBox.Show("Xóa khu vực thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show("Lỗi: " + errorMessage, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshDbContext();
            }
        }

        // --- LOẠI BÀN ---
        private void AddTableType()
        {
            try
            {
                RefreshDbContext(); // Làm mới context trước khi thêm

                string tenLoai = txtTenLB.Text.Trim();

                // Kiểm tra trùng tên loại bàn
                bool daTonTai = db.LoaiBans.Any(l => l.TenLoai == tenLoai);
                if (daTonTai)
                {
                    MessageBox.Show($"Tên loại bàn '{tenLoai}' đã tồn tại!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.LoaiBans.Add(new LoaiBan() { TenLoai = tenLoai, GiaTheoGio = numGiaLB.Value });
                db.SaveChanges();
                RefreshDbContext();
                LoadAllLists();
                LoadComboBoxes();
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        private void EditTableType()
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDLB.Text)) return;

                RefreshDbContext(); // Làm mới context trước khi sửa

                int id = int.Parse(txtIDLB.Text);
                string tenLoai = txtTenLB.Text.Trim();

                // Kiểm tra trùng tên loại bàn (trừ loại bàn hiện tại)
                bool daTonTai = db.LoaiBans.Any(l => l.TenLoai == tenLoai && l.LoaiBanID != id);
                if (daTonTai)
                {
                    MessageBox.Show($"Tên loại bàn '{tenLoai}' đã tồn tại!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var item = db.LoaiBans.Find(id);
                if (item != null)
                {
                    item.TenLoai = tenLoai;
                    item.GiaTheoGio = numGiaLB.Value;
                    db.SaveChanges();
                    RefreshDbContext();
                    LoadAllLists();
                    LoadComboBoxes();
                    MessageBox.Show("Sửa thành công");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }

        private void DeleteTableType()
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDLB.Text)) return;
                int id = int.Parse(txtIDLB.Text);

                // Kiểm tra nếu loại bàn đang được sử dụng
                var tableCount = db.Bans.Count(b => b.LoaiBanID == id);
                if (tableCount > 0)
                {
                    MessageBox.Show($"Không thể xóa loại bàn vì đang có {tableCount} bàn sử dụng!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Database.ExecuteSqlCommand("DELETE FROM danhmuc.LoaiBan WHERE LoaiBanID = @p0", id);
                RefreshDbContext();
                LoadAllLists();
                LoadComboBoxes();
                MessageBox.Show("Xóa thành công");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + (ex.InnerException?.Message ?? ex.Message)); }
        }
        #endregion
    }
}