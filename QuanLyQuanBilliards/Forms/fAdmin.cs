using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyQuanBilliards.Forms
{
    public partial class fAdmin : Form
    {
        private QuanLyQuanBilliardsEntities db = new QuanLyQuanBilliardsEntities();

        // Binding sources
        BindingSource bsBan = new BindingSource();
        BindingSource bsSanPham = new BindingSource();
        BindingSource bsDanhMuc = new BindingSource();
        BindingSource bsKhuVuc = new BindingSource();
        BindingSource bsLoaiBan = new BindingSource();

        public fAdmin()
        {
            InitializeComponent();

            LoadData();
            AddBindings();
            AddEvents();
        }

        private void LoadData()
        {
            dgvBan.DataSource = bsBan;
            dgvSanPham.DataSource = bsSanPham;
            dgvDanhMuc.DataSource = bsDanhMuc;
            dgvKhuVuc.DataSource = bsKhuVuc;
            dgvLoaiBan.DataSource = bsLoaiBan;

            LoadDateTimePicker();
            LoadAllLists();
            LoadComboBoxes();
        }

        private void LoadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
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

                // Dùng ADO.NET thuần để gọi Procedure và đổ vào DataTable
                // Cách này giúp giữ nguyên tên cột Tiếng Việt từ SQL
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

        #region Load Lists & Renaming
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
                    try { cboDanhMucSP.SelectedValue = dgvSanPham.CurrentRow.Cells["DanhMucID"].Value; } catch { }
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
        }
        #endregion

        #region Logic CRUD
        // --- SẢN PHẨM ---
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                db.SanPhams.Add(new SanPham() { TenSP = txtTenSP.Text, DonGia = numGiaSP.Value, DanhMucID = (int)cboDanhMucSP.SelectedValue, TrangThai = "Còn" });
                db.SaveChanges(); LoadAllLists(); MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDSP.Text)) return;
                int id = int.Parse(txtIDSP.Text); var item = db.SanPhams.Find(id);
                if (item != null) { item.TenSP = txtTenSP.Text; item.DonGia = numGiaSP.Value; item.DanhMucID = (int)cboDanhMucSP.SelectedValue; db.SaveChanges(); LoadAllLists(); MessageBox.Show("Sửa thành công"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDSP.Text)) return;
                int id = int.Parse(txtIDSP.Text); var item = db.SanPhams.Find(id);
                if (item != null) { item.TrangThai = "Hết"; db.SaveChanges(); LoadAllLists(); MessageBox.Show("Đã ẩn sản phẩm"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // --- BÀN ---
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            try
            {
                db.Bans.Add(new Ban() { TenBan = txtTenBan.Text, KhuVucID = (int)cboKhuVuc.SelectedValue, LoaiBanID = (int)cboLoaiBan.SelectedValue, TrangThai = "Trống" });
                db.SaveChanges(); LoadAllLists(); MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDBan.Text)) return;
                int id = int.Parse(txtIDBan.Text); var item = db.Bans.Find(id);
                if (item != null) { item.TenBan = txtTenBan.Text; item.KhuVucID = (int)cboKhuVuc.SelectedValue; item.LoaiBanID = (int)cboLoaiBan.SelectedValue; db.SaveChanges(); LoadAllLists(); MessageBox.Show("Sửa thành công"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDBan.Text)) return;
                int id = int.Parse(txtIDBan.Text); var item = db.Bans.Find(id);
                if (item != null) { db.Bans.Remove(item); db.SaveChanges(); LoadAllLists(); MessageBox.Show("Xóa thành công"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // --- DANH MỤC ---
        private void AddCategory()
        {
            try { db.DanhMucs.Add(new DanhMuc() { TenDanhMuc = txtTenCat.Text }); db.SaveChanges(); LoadAllLists(); LoadComboBoxes(); MessageBox.Show("Thêm thành công"); } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void EditCategory()
        {
            try { if (string.IsNullOrEmpty(txtIDCat.Text)) return; int id = int.Parse(txtIDCat.Text); var item = db.DanhMucs.Find(id); if (item != null) { item.TenDanhMuc = txtTenCat.Text; db.SaveChanges(); LoadAllLists(); LoadComboBoxes(); MessageBox.Show("Sửa thành công"); } } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void DeleteCategory()
        {
            try { if (string.IsNullOrEmpty(txtIDCat.Text)) return; int id = int.Parse(txtIDCat.Text); var item = db.DanhMucs.Find(id); if (item != null) { db.DanhMucs.Remove(item); db.SaveChanges(); LoadAllLists(); LoadComboBoxes(); MessageBox.Show("Xóa thành công"); } } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // --- KHU VỰC ---
        private void AddArea()
        {
            try { db.KhuVucs.Add(new KhuVuc() { TenKhuVuc = txtTenKV.Text, TangSo = 0 }); db.SaveChanges(); LoadAllLists(); LoadComboBoxes(); MessageBox.Show("Thêm thành công"); } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void EditArea()
        {
            try { if (string.IsNullOrEmpty(txtIDKV.Text)) return; int id = int.Parse(txtIDKV.Text); var item = db.KhuVucs.Find(id); if (item != null) { item.TenKhuVuc = txtTenKV.Text; db.SaveChanges(); LoadAllLists(); LoadComboBoxes(); MessageBox.Show("Sửa thành công"); } } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void DeleteArea()
        {
            try { if (string.IsNullOrEmpty(txtIDKV.Text)) return; int id = int.Parse(txtIDKV.Text); var item = db.KhuVucs.Find(id); if (item != null) { db.KhuVucs.Remove(item); db.SaveChanges(); LoadAllLists(); LoadComboBoxes(); MessageBox.Show("Xóa thành công"); } } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // --- LOẠI BÀN ---
        private void AddTableType()
        {
            try { db.LoaiBans.Add(new LoaiBan() { TenLoai = txtTenLB.Text, GiaTheoGio = numGiaLB.Value }); db.SaveChanges(); LoadAllLists(); LoadComboBoxes(); MessageBox.Show("Thêm thành công"); } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void EditTableType()
        {
            try { if (string.IsNullOrEmpty(txtIDLB.Text)) return; int id = int.Parse(txtIDLB.Text); var item = db.LoaiBans.Find(id); if (item != null) { item.TenLoai = txtTenLB.Text; item.GiaTheoGio = numGiaLB.Value; db.SaveChanges(); LoadAllLists(); LoadComboBoxes(); MessageBox.Show("Sửa thành công"); } } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void DeleteTableType()
        {
            try { if (string.IsNullOrEmpty(txtIDLB.Text)) return; int id = int.Parse(txtIDLB.Text); var item = db.LoaiBans.Find(id); if (item != null) { db.LoaiBans.Remove(item); db.SaveChanges(); LoadAllLists(); LoadComboBoxes(); MessageBox.Show("Xóa thành công"); } } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion
    }
}