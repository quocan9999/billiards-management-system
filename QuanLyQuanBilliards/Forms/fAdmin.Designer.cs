namespace QuanLyQuanBilliards.Forms
{
    partial class fAdmin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tcAdmin = new System.Windows.Forms.TabControl();
            this.tpDanhMuc = new System.Windows.Forms.TabPage();
            this.dgvDanhMuc = new System.Windows.Forms.DataGridView();
            this.pnlCatInput = new System.Windows.Forms.Panel();
            this.txtIDCat = new System.Windows.Forms.TextBox();
            this.labelCat1 = new System.Windows.Forms.Label();
            this.txtTenCat = new System.Windows.Forms.TextBox();
            this.labelCat2 = new System.Windows.Forms.Label();
            this.btnThemCat = new System.Windows.Forms.Button();
            this.btnSuaCat = new System.Windows.Forms.Button();
            this.btnXoaCat = new System.Windows.Forms.Button();
            this.tpSanPham = new System.Windows.Forms.TabPage();
            this.panelSP = new System.Windows.Forms.Panel();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.pnlSPFilter = new System.Windows.Forms.Panel();
            this.lblSPFilterDanhMuc = new System.Windows.Forms.Label();
            this.cboSPFilterDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblSPFilterTen = new System.Windows.Forms.Label();
            this.txtSPFilterTen = new System.Windows.Forms.TextBox();
            this.btnSPFilterLoc = new System.Windows.Forms.Button();
            this.btnSPFilterXoa = new System.Windows.Forms.Button();
            this.pnlSPInput = new System.Windows.Forms.Panel();
            this.txtIDSP = new System.Windows.Forms.TextBox();
            this.labelSP1 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.labelSP2 = new System.Windows.Forms.Label();
            this.cboDanhMucSP = new System.Windows.Forms.ComboBox();
            this.labelSP3 = new System.Windows.Forms.Label();
            this.numGiaSP = new System.Windows.Forms.NumericUpDown();
            this.labelSP4 = new System.Windows.Forms.Label();
            this.cboTrangThaiSP = new System.Windows.Forms.ComboBox();
            this.labelSP5 = new System.Windows.Forms.Label();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.btnSuaSP = new System.Windows.Forms.Button();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.tpKhuVuc = new System.Windows.Forms.TabPage();
            this.dgvKhuVuc = new System.Windows.Forms.DataGridView();
            this.pnlKVInput = new System.Windows.Forms.Panel();
            this.txtIDKV = new System.Windows.Forms.TextBox();
            this.labelKV1 = new System.Windows.Forms.Label();
            this.txtTenKV = new System.Windows.Forms.TextBox();
            this.labelKV2 = new System.Windows.Forms.Label();
            this.btnThemKV = new System.Windows.Forms.Button();
            this.btnSuaKV = new System.Windows.Forms.Button();
            this.btnXoaKV = new System.Windows.Forms.Button();
            this.tpLoaiBan = new System.Windows.Forms.TabPage();
            this.dgvLoaiBan = new System.Windows.Forms.DataGridView();
            this.pnlLBInput = new System.Windows.Forms.Panel();
            this.txtIDLB = new System.Windows.Forms.TextBox();
            this.labelLB1 = new System.Windows.Forms.Label();
            this.txtTenLB = new System.Windows.Forms.TextBox();
            this.labelLB2 = new System.Windows.Forms.Label();
            this.numGiaLB = new System.Windows.Forms.NumericUpDown();
            this.labelLB3 = new System.Windows.Forms.Label();
            this.btnThemLB = new System.Windows.Forms.Button();
            this.btnSuaLB = new System.Windows.Forms.Button();
            this.btnXoaLB = new System.Windows.Forms.Button();
            this.tpBan = new System.Windows.Forms.TabPage();
            this.panelBan = new System.Windows.Forms.Panel();
            this.dgvBan = new System.Windows.Forms.DataGridView();
            this.pnlBanFilter = new System.Windows.Forms.Panel();
            this.lblBanFilterKhuVuc = new System.Windows.Forms.Label();
            this.cboBanFilterKhuVuc = new System.Windows.Forms.ComboBox();
            this.lblBanFilterLoaiBan = new System.Windows.Forms.Label();
            this.cboBanFilterLoaiBan = new System.Windows.Forms.ComboBox();
            this.lblBanFilterTen = new System.Windows.Forms.Label();
            this.txtBanFilterTen = new System.Windows.Forms.TextBox();
            this.btnBanFilterLoc = new System.Windows.Forms.Button();
            this.btnBanFilterXoa = new System.Windows.Forms.Button();
            this.pnlBanInput = new System.Windows.Forms.Panel();
            this.txtIDBan = new System.Windows.Forms.TextBox();
            this.labelBan1 = new System.Windows.Forms.Label();
            this.txtTenBan = new System.Windows.Forms.TextBox();
            this.labelBan2 = new System.Windows.Forms.Label();
            this.cboKhuVuc = new System.Windows.Forms.ComboBox();
            this.labelBan3 = new System.Windows.Forms.Label();
            this.cboLoaiBan = new System.Windows.Forms.ComboBox();
            this.labelBan4 = new System.Windows.Forms.Label();
            this.btnThemBan = new System.Windows.Forms.Button();
            this.btnSuaBan = new System.Windows.Forms.Button();
            this.btnXoaBan = new System.Windows.Forms.Button();
            this.tpDoanhThu = new System.Windows.Forms.TabPage();
            this.tlpDoanhThu = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dtpkToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpkFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.tpBaoCaoNangCao = new System.Windows.Forms.TabPage();
            this.dgvBCNC_BaoCao = new System.Windows.Forms.DataGridView();
            this.pnlBCNC_DongBo = new System.Windows.Forms.Panel();
            this.dtpBCNC_TuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpBCNC_DenNgay = new System.Windows.Forms.DateTimePicker();
            this.chkBCNC_GhiDe = new System.Windows.Forms.CheckBox();
            this.btnBCNC_DongBo = new System.Windows.Forms.Button();
            this.btnBCNC_XemBaoCao = new System.Windows.Forms.Button();
            this.btnBCNC_LamMoi = new System.Windows.Forms.Button();
            this.pnlBCNC_ThongKe = new System.Windows.Forms.Panel();
            this.lblBCNC_DoanhThuHomNay = new System.Windows.Forms.Label();
            this.lblBCNC_GiaTriDoanhThuHomNay = new System.Windows.Forms.Label();
            this.lblBCNC_SoHoaDon = new System.Windows.Forms.Label();
            this.lblBCNC_GiaTriSoHoaDon = new System.Windows.Forms.Label();
            this.lblBCNC_TrungBinh = new System.Windows.Forms.Label();
            this.lblBCNC_GiaTriTrungBinh = new System.Windows.Forms.Label();
            this.lblBCNC_DoanhThuThang = new System.Windows.Forms.Label();
            this.lblBCNC_GiaTriDoanhThuThang = new System.Windows.Forms.Label();
            this.tpTaiKhoan = new System.Windows.Forms.TabPage();
            this.panelTK = new System.Windows.Forms.Panel();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.pnlTKInput = new System.Windows.Forms.Panel();
            this.txtIDTK = new System.Windows.Forms.TextBox();
            this.labelTK1 = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.labelTK2 = new System.Windows.Forms.Label();
            this.txtMatKhauTK = new System.Windows.Forms.TextBox();
            this.labelTK3 = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.labelTK4 = new System.Windows.Forms.Label();
            this.cboTrangThaiTK = new System.Windows.Forms.ComboBox();
            this.labelTK5 = new System.Windows.Forms.Label();
            this.grpNhanVien = new System.Windows.Forms.GroupBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.labelNV1 = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.labelNV2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.labelNV3 = new System.Windows.Forms.Label();
            this.numLuong = new System.Windows.Forms.NumericUpDown();
            this.labelNV4 = new System.Windows.Forms.Label();
            this.btnThemTK = new System.Windows.Forms.Button();
            this.btnSuaTK = new System.Windows.Forms.Button();
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.tcAdmin.SuspendLayout();
            this.tpDanhMuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            this.pnlCatInput.SuspendLayout();
            this.tpSanPham.SuspendLayout();
            this.panelSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.pnlSPFilter.SuspendLayout();
            this.pnlSPInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaSP)).BeginInit();
            this.tpKhuVuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuVuc)).BeginInit();
            this.pnlKVInput.SuspendLayout();
            this.tpLoaiBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiBan)).BeginInit();
            this.pnlLBInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaLB)).BeginInit();
            this.tpBan.SuspendLayout();
            this.panelBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).BeginInit();
            this.pnlBanFilter.SuspendLayout();
            this.pnlBanInput.SuspendLayout();
            this.tpDoanhThu.SuspendLayout();
            this.tlpDoanhThu.SuspendLayout();
            this.pnlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.tpBaoCaoNangCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCNC_BaoCao)).BeginInit();
            this.pnlBCNC_DongBo.SuspendLayout();
            this.pnlBCNC_ThongKe.SuspendLayout();
            this.tpTaiKhoan.SuspendLayout();
            this.panelTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.pnlTKInput.SuspendLayout();
            this.grpNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAdmin
            // 
            this.tcAdmin.Controls.Add(this.tpDanhMuc);
            this.tcAdmin.Controls.Add(this.tpSanPham);
            this.tcAdmin.Controls.Add(this.tpKhuVuc);
            this.tcAdmin.Controls.Add(this.tpLoaiBan);
            this.tcAdmin.Controls.Add(this.tpBan);
            this.tcAdmin.Controls.Add(this.tpDoanhThu);
            this.tcAdmin.Controls.Add(this.tpBaoCaoNangCao);
            this.tcAdmin.Controls.Add(this.tpTaiKhoan);
            this.tcAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.tcAdmin.ItemSize = new System.Drawing.Size(120, 40);
            this.tcAdmin.Location = new System.Drawing.Point(0, 0);
            this.tcAdmin.Name = "tcAdmin";
            this.tcAdmin.SelectedIndex = 0;
            this.tcAdmin.Size = new System.Drawing.Size(1280, 720);
            this.tcAdmin.TabIndex = 0;
            // 
            // tpDanhMuc
            // 
            this.tpDanhMuc.Controls.Add(this.dgvDanhMuc);
            this.tpDanhMuc.Controls.Add(this.pnlCatInput);
            this.tpDanhMuc.Location = new System.Drawing.Point(4, 44);
            this.tpDanhMuc.Name = "tpDanhMuc";
            this.tpDanhMuc.Size = new System.Drawing.Size(1272, 672);
            this.tpDanhMuc.TabIndex = 0;
            this.tpDanhMuc.Text = "Danh mục";
            // 
            // dgvDanhMuc
            // 
            this.dgvDanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhMuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhMuc.ColumnHeadersHeight = 50;
            this.dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.RowHeadersWidth = 51;
            this.dgvDanhMuc.RowTemplate.Height = 40;
            this.dgvDanhMuc.Size = new System.Drawing.Size(822, 672);
            this.dgvDanhMuc.TabIndex = 0;
            // 
            // pnlCatInput
            // 
            this.pnlCatInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCatInput.Controls.Add(this.txtIDCat);
            this.pnlCatInput.Controls.Add(this.labelCat1);
            this.pnlCatInput.Controls.Add(this.txtTenCat);
            this.pnlCatInput.Controls.Add(this.labelCat2);
            this.pnlCatInput.Controls.Add(this.btnThemCat);
            this.pnlCatInput.Controls.Add(this.btnSuaCat);
            this.pnlCatInput.Controls.Add(this.btnXoaCat);
            this.pnlCatInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCatInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlCatInput.Location = new System.Drawing.Point(822, 0);
            this.pnlCatInput.Name = "pnlCatInput";
            this.pnlCatInput.Size = new System.Drawing.Size(450, 672);
            this.pnlCatInput.TabIndex = 1;
            // 
            // txtIDCat
            // 
            this.txtIDCat.Location = new System.Drawing.Point(140, 37);
            this.txtIDCat.Name = "txtIDCat";
            this.txtIDCat.ReadOnly = true;
            this.txtIDCat.Size = new System.Drawing.Size(280, 30);
            this.txtIDCat.TabIndex = 0;
            // 
            // labelCat1
            // 
            this.labelCat1.Location = new System.Drawing.Point(20, 40);
            this.labelCat1.Name = "labelCat1";
            this.labelCat1.Size = new System.Drawing.Size(100, 23);
            this.labelCat1.TabIndex = 1;
            this.labelCat1.Text = "ID:";
            // 
            // txtTenCat
            // 
            this.txtTenCat.Location = new System.Drawing.Point(140, 107);
            this.txtTenCat.Name = "txtTenCat";
            this.txtTenCat.Size = new System.Drawing.Size(280, 30);
            this.txtTenCat.TabIndex = 2;
            // 
            // labelCat2
            // 
            this.labelCat2.Location = new System.Drawing.Point(20, 110);
            this.labelCat2.Name = "labelCat2";
            this.labelCat2.Size = new System.Drawing.Size(100, 23);
            this.labelCat2.TabIndex = 3;
            this.labelCat2.Text = "Tên DM:";
            // 
            // btnThemCat
            // 
            this.btnThemCat.BackColor = System.Drawing.Color.ForestGreen;
            this.btnThemCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCat.ForeColor = System.Drawing.Color.White;
            this.btnThemCat.Location = new System.Drawing.Point(30, 200);
            this.btnThemCat.Name = "btnThemCat";
            this.btnThemCat.Size = new System.Drawing.Size(120, 60);
            this.btnThemCat.TabIndex = 4;
            this.btnThemCat.Text = "Thêm";
            this.btnThemCat.UseVisualStyleBackColor = false;
            // 
            // btnSuaCat
            // 
            this.btnSuaCat.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSuaCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaCat.ForeColor = System.Drawing.Color.White;
            this.btnSuaCat.Location = new System.Drawing.Point(165, 200);
            this.btnSuaCat.Name = "btnSuaCat";
            this.btnSuaCat.Size = new System.Drawing.Size(120, 60);
            this.btnSuaCat.TabIndex = 5;
            this.btnSuaCat.Text = "Sửa";
            this.btnSuaCat.UseVisualStyleBackColor = false;
            // 
            // btnXoaCat
            // 
            this.btnXoaCat.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoaCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCat.ForeColor = System.Drawing.Color.White;
            this.btnXoaCat.Location = new System.Drawing.Point(300, 200);
            this.btnXoaCat.Name = "btnXoaCat";
            this.btnXoaCat.Size = new System.Drawing.Size(120, 60);
            this.btnXoaCat.TabIndex = 6;
            this.btnXoaCat.Text = "Xóa";
            this.btnXoaCat.UseVisualStyleBackColor = false;
            // 
            // tpSanPham
            // 
            this.tpSanPham.Controls.Add(this.panelSP);
            this.tpSanPham.Controls.Add(this.pnlSPFilter);
            this.tpSanPham.Controls.Add(this.pnlSPInput);
            this.tpSanPham.Location = new System.Drawing.Point(4, 44);
            this.tpSanPham.Name = "tpSanPham";
            this.tpSanPham.Padding = new System.Windows.Forms.Padding(3);
            this.tpSanPham.Size = new System.Drawing.Size(1272, 672);
            this.tpSanPham.TabIndex = 1;
            this.tpSanPham.Text = "Sản phẩm";
            this.tpSanPham.UseVisualStyleBackColor = true;
            // 
            // panelSP
            // 
            this.panelSP.Controls.Add(this.dgvSanPham);
            this.panelSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSP.Location = new System.Drawing.Point(3, 63);
            this.panelSP.Name = "panelSP";
            this.panelSP.Padding = new System.Windows.Forms.Padding(20);
            this.panelSP.Size = new System.Drawing.Size(816, 606);
            this.panelSP.TabIndex = 0;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSanPham.ColumnHeadersHeight = 50;
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSanPham.Location = new System.Drawing.Point(20, 20);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 40;
            this.dgvSanPham.Size = new System.Drawing.Size(776, 566);
            this.dgvSanPham.TabIndex = 0;
            // 
            // pnlSPFilter
            // 
            this.pnlSPFilter.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlSPFilter.Controls.Add(this.lblSPFilterDanhMuc);
            this.pnlSPFilter.Controls.Add(this.cboSPFilterDanhMuc);
            this.pnlSPFilter.Controls.Add(this.lblSPFilterTen);
            this.pnlSPFilter.Controls.Add(this.txtSPFilterTen);
            this.pnlSPFilter.Controls.Add(this.btnSPFilterLoc);
            this.pnlSPFilter.Controls.Add(this.btnSPFilterXoa);
            this.pnlSPFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSPFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.pnlSPFilter.Location = new System.Drawing.Point(3, 3);
            this.pnlSPFilter.Name = "pnlSPFilter";
            this.pnlSPFilter.Size = new System.Drawing.Size(816, 60);
            this.pnlSPFilter.TabIndex = 1;
            // 
            // lblSPFilterDanhMuc
            // 
            this.lblSPFilterDanhMuc.AutoSize = true;
            this.lblSPFilterDanhMuc.Location = new System.Drawing.Point(20, 18);
            this.lblSPFilterDanhMuc.Name = "lblSPFilterDanhMuc";
            this.lblSPFilterDanhMuc.Size = new System.Drawing.Size(102, 24);
            this.lblSPFilterDanhMuc.TabIndex = 0;
            this.lblSPFilterDanhMuc.Text = "Danh mục:";
            // 
            // cboSPFilterDanhMuc
            // 
            this.cboSPFilterDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSPFilterDanhMuc.Location = new System.Drawing.Point(132, 15);
            this.cboSPFilterDanhMuc.Name = "cboSPFilterDanhMuc";
            this.cboSPFilterDanhMuc.Size = new System.Drawing.Size(180, 30);
            this.cboSPFilterDanhMuc.TabIndex = 1;
            // 
            // lblSPFilterTen
            // 
            this.lblSPFilterTen.AutoSize = true;
            this.lblSPFilterTen.Location = new System.Drawing.Point(325, 18);
            this.lblSPFilterTen.Name = "lblSPFilterTen";
            this.lblSPFilterTen.Size = new System.Drawing.Size(78, 24);
            this.lblSPFilterTen.TabIndex = 2;
            this.lblSPFilterTen.Text = "Tìm tên:";
            // 
            // txtSPFilterTen
            // 
            this.txtSPFilterTen.Location = new System.Drawing.Point(410, 15);
            this.txtSPFilterTen.Name = "txtSPFilterTen";
            this.txtSPFilterTen.Size = new System.Drawing.Size(180, 28);
            this.txtSPFilterTen.TabIndex = 3;
            // 
            // btnSPFilterLoc
            // 
            this.btnSPFilterLoc.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSPFilterLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSPFilterLoc.ForeColor = System.Drawing.Color.White;
            this.btnSPFilterLoc.Location = new System.Drawing.Point(610, 10);
            this.btnSPFilterLoc.Name = "btnSPFilterLoc";
            this.btnSPFilterLoc.Size = new System.Drawing.Size(80, 40);
            this.btnSPFilterLoc.TabIndex = 4;
            this.btnSPFilterLoc.Text = "Lọc";
            this.btnSPFilterLoc.UseVisualStyleBackColor = false;
            // 
            // btnSPFilterXoa
            // 
            this.btnSPFilterXoa.BackColor = System.Drawing.Color.Gray;
            this.btnSPFilterXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSPFilterXoa.ForeColor = System.Drawing.Color.White;
            this.btnSPFilterXoa.Location = new System.Drawing.Point(700, 10);
            this.btnSPFilterXoa.Name = "btnSPFilterXoa";
            this.btnSPFilterXoa.Size = new System.Drawing.Size(90, 40);
            this.btnSPFilterXoa.TabIndex = 5;
            this.btnSPFilterXoa.Text = "Xóa lọc";
            this.btnSPFilterXoa.UseVisualStyleBackColor = false;
            // 
            // pnlSPInput
            // 
            this.pnlSPInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSPInput.Controls.Add(this.txtIDSP);
            this.pnlSPInput.Controls.Add(this.labelSP1);
            this.pnlSPInput.Controls.Add(this.txtTenSP);
            this.pnlSPInput.Controls.Add(this.labelSP2);
            this.pnlSPInput.Controls.Add(this.cboDanhMucSP);
            this.pnlSPInput.Controls.Add(this.labelSP3);
            this.pnlSPInput.Controls.Add(this.numGiaSP);
            this.pnlSPInput.Controls.Add(this.labelSP4);
            this.pnlSPInput.Controls.Add(this.cboTrangThaiSP);
            this.pnlSPInput.Controls.Add(this.labelSP5);
            this.pnlSPInput.Controls.Add(this.btnThemSP);
            this.pnlSPInput.Controls.Add(this.btnSuaSP);
            this.pnlSPInput.Controls.Add(this.btnXoaSP);
            this.pnlSPInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSPInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlSPInput.Location = new System.Drawing.Point(819, 3);
            this.pnlSPInput.Name = "pnlSPInput";
            this.pnlSPInput.Size = new System.Drawing.Size(450, 666);
            this.pnlSPInput.TabIndex = 2;
            // 
            // txtIDSP
            // 
            this.txtIDSP.Location = new System.Drawing.Point(140, 37);
            this.txtIDSP.Name = "txtIDSP";
            this.txtIDSP.ReadOnly = true;
            this.txtIDSP.Size = new System.Drawing.Size(280, 30);
            this.txtIDSP.TabIndex = 0;
            // 
            // labelSP1
            // 
            this.labelSP1.Location = new System.Drawing.Point(20, 40);
            this.labelSP1.Name = "labelSP1";
            this.labelSP1.Size = new System.Drawing.Size(100, 23);
            this.labelSP1.TabIndex = 1;
            this.labelSP1.Text = "ID:";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(140, 107);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(280, 30);
            this.txtTenSP.TabIndex = 2;
            // 
            // labelSP2
            // 
            this.labelSP2.Location = new System.Drawing.Point(20, 110);
            this.labelSP2.Name = "labelSP2";
            this.labelSP2.Size = new System.Drawing.Size(100, 23);
            this.labelSP2.TabIndex = 3;
            this.labelSP2.Text = "Tên món:";
            // 
            // cboDanhMucSP
            // 
            this.cboDanhMucSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMucSP.Location = new System.Drawing.Point(140, 177);
            this.cboDanhMucSP.Name = "cboDanhMucSP";
            this.cboDanhMucSP.Size = new System.Drawing.Size(280, 33);
            this.cboDanhMucSP.TabIndex = 4;
            // 
            // labelSP3
            // 
            this.labelSP3.Location = new System.Drawing.Point(20, 180);
            this.labelSP3.Name = "labelSP3";
            this.labelSP3.Size = new System.Drawing.Size(100, 23);
            this.labelSP3.TabIndex = 5;
            this.labelSP3.Text = "Danh mục:";
            // 
            // numGiaSP
            // 
            this.numGiaSP.Location = new System.Drawing.Point(140, 247);
            this.numGiaSP.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numGiaSP.Name = "numGiaSP";
            this.numGiaSP.Size = new System.Drawing.Size(280, 30);
            this.numGiaSP.TabIndex = 6;
            // 
            // labelSP4
            // 
            this.labelSP4.AutoSize = true;
            this.labelSP4.Location = new System.Drawing.Point(20, 250);
            this.labelSP4.Name = "labelSP4";
            this.labelSP4.Size = new System.Drawing.Size(85, 25);
            this.labelSP4.TabIndex = 7;
            this.labelSP4.Text = "Đơn giá:";
            // 
            // cboTrangThaiSP
            // 
            this.cboTrangThaiSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiSP.Items.AddRange(new object[] {
            "Còn",
            "Hết"});
            this.cboTrangThaiSP.Location = new System.Drawing.Point(140, 317);
            this.cboTrangThaiSP.Name = "cboTrangThaiSP";
            this.cboTrangThaiSP.Size = new System.Drawing.Size(280, 33);
            this.cboTrangThaiSP.TabIndex = 8;
            // 
            // labelSP5
            // 
            this.labelSP5.AutoSize = true;
            this.labelSP5.Location = new System.Drawing.Point(20, 320);
            this.labelSP5.Name = "labelSP5";
            this.labelSP5.Size = new System.Drawing.Size(106, 25);
            this.labelSP5.TabIndex = 9;
            this.labelSP5.Text = "Trạng thái:";
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.ForestGreen;
            this.btnThemSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSP.ForeColor = System.Drawing.Color.White;
            this.btnThemSP.Location = new System.Drawing.Point(30, 400);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(120, 60);
            this.btnThemSP.TabIndex = 10;
            this.btnThemSP.Text = "Thêm";
            this.btnThemSP.UseVisualStyleBackColor = false;
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSuaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaSP.ForeColor = System.Drawing.Color.White;
            this.btnSuaSP.Location = new System.Drawing.Point(165, 400);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(120, 60);
            this.btnSuaSP.TabIndex = 11;
            this.btnSuaSP.Text = "Sửa";
            this.btnSuaSP.UseVisualStyleBackColor = false;
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSP.ForeColor = System.Drawing.Color.White;
            this.btnXoaSP.Location = new System.Drawing.Point(300, 400);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(120, 60);
            this.btnXoaSP.TabIndex = 12;
            this.btnXoaSP.Text = "Xóa";
            this.btnXoaSP.UseVisualStyleBackColor = false;
            // 
            // tpKhuVuc
            // 
            this.tpKhuVuc.Controls.Add(this.dgvKhuVuc);
            this.tpKhuVuc.Controls.Add(this.pnlKVInput);
            this.tpKhuVuc.Location = new System.Drawing.Point(4, 44);
            this.tpKhuVuc.Name = "tpKhuVuc";
            this.tpKhuVuc.Size = new System.Drawing.Size(1272, 672);
            this.tpKhuVuc.TabIndex = 2;
            this.tpKhuVuc.Text = "Khu vực";
            // 
            // dgvKhuVuc
            // 
            this.dgvKhuVuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhuVuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhuVuc.ColumnHeadersHeight = 50;
            this.dgvKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.dgvKhuVuc.Name = "dgvKhuVuc";
            this.dgvKhuVuc.RowHeadersWidth = 51;
            this.dgvKhuVuc.RowTemplate.Height = 40;
            this.dgvKhuVuc.Size = new System.Drawing.Size(822, 672);
            this.dgvKhuVuc.TabIndex = 0;
            // 
            // pnlKVInput
            // 
            this.pnlKVInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlKVInput.Controls.Add(this.txtIDKV);
            this.pnlKVInput.Controls.Add(this.labelKV1);
            this.pnlKVInput.Controls.Add(this.txtTenKV);
            this.pnlKVInput.Controls.Add(this.labelKV2);
            this.pnlKVInput.Controls.Add(this.btnThemKV);
            this.pnlKVInput.Controls.Add(this.btnSuaKV);
            this.pnlKVInput.Controls.Add(this.btnXoaKV);
            this.pnlKVInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlKVInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlKVInput.Location = new System.Drawing.Point(822, 0);
            this.pnlKVInput.Name = "pnlKVInput";
            this.pnlKVInput.Size = new System.Drawing.Size(450, 672);
            this.pnlKVInput.TabIndex = 1;
            // 
            // txtIDKV
            // 
            this.txtIDKV.Location = new System.Drawing.Point(140, 37);
            this.txtIDKV.Name = "txtIDKV";
            this.txtIDKV.ReadOnly = true;
            this.txtIDKV.Size = new System.Drawing.Size(280, 30);
            this.txtIDKV.TabIndex = 0;
            // 
            // labelKV1
            // 
            this.labelKV1.Location = new System.Drawing.Point(20, 40);
            this.labelKV1.Name = "labelKV1";
            this.labelKV1.Size = new System.Drawing.Size(100, 23);
            this.labelKV1.TabIndex = 1;
            this.labelKV1.Text = "ID:";
            // 
            // txtTenKV
            // 
            this.txtTenKV.Location = new System.Drawing.Point(140, 107);
            this.txtTenKV.Name = "txtTenKV";
            this.txtTenKV.Size = new System.Drawing.Size(280, 30);
            this.txtTenKV.TabIndex = 2;
            // 
            // labelKV2
            // 
            this.labelKV2.Location = new System.Drawing.Point(20, 110);
            this.labelKV2.Name = "labelKV2";
            this.labelKV2.Size = new System.Drawing.Size(100, 23);
            this.labelKV2.TabIndex = 3;
            this.labelKV2.Text = "Tên KV:";
            // 
            // btnThemKV
            // 
            this.btnThemKV.BackColor = System.Drawing.Color.ForestGreen;
            this.btnThemKV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemKV.ForeColor = System.Drawing.Color.White;
            this.btnThemKV.Location = new System.Drawing.Point(30, 200);
            this.btnThemKV.Name = "btnThemKV";
            this.btnThemKV.Size = new System.Drawing.Size(120, 60);
            this.btnThemKV.TabIndex = 4;
            this.btnThemKV.Text = "Thêm";
            this.btnThemKV.UseVisualStyleBackColor = false;
            // 
            // btnSuaKV
            // 
            this.btnSuaKV.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSuaKV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaKV.ForeColor = System.Drawing.Color.White;
            this.btnSuaKV.Location = new System.Drawing.Point(165, 200);
            this.btnSuaKV.Name = "btnSuaKV";
            this.btnSuaKV.Size = new System.Drawing.Size(120, 60);
            this.btnSuaKV.TabIndex = 5;
            this.btnSuaKV.Text = "Sửa";
            this.btnSuaKV.UseVisualStyleBackColor = false;
            // 
            // btnXoaKV
            // 
            this.btnXoaKV.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoaKV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaKV.ForeColor = System.Drawing.Color.White;
            this.btnXoaKV.Location = new System.Drawing.Point(300, 200);
            this.btnXoaKV.Name = "btnXoaKV";
            this.btnXoaKV.Size = new System.Drawing.Size(120, 60);
            this.btnXoaKV.TabIndex = 6;
            this.btnXoaKV.Text = "Xóa";
            this.btnXoaKV.UseVisualStyleBackColor = false;
            // 
            // tpLoaiBan
            // 
            this.tpLoaiBan.Controls.Add(this.dgvLoaiBan);
            this.tpLoaiBan.Controls.Add(this.pnlLBInput);
            this.tpLoaiBan.Location = new System.Drawing.Point(4, 44);
            this.tpLoaiBan.Name = "tpLoaiBan";
            this.tpLoaiBan.Size = new System.Drawing.Size(1272, 672);
            this.tpLoaiBan.TabIndex = 3;
            this.tpLoaiBan.Text = "Loại bàn";
            // 
            // dgvLoaiBan
            // 
            this.dgvLoaiBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiBan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLoaiBan.ColumnHeadersHeight = 50;
            this.dgvLoaiBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoaiBan.Location = new System.Drawing.Point(0, 0);
            this.dgvLoaiBan.Name = "dgvLoaiBan";
            this.dgvLoaiBan.RowHeadersWidth = 51;
            this.dgvLoaiBan.RowTemplate.Height = 40;
            this.dgvLoaiBan.Size = new System.Drawing.Size(822, 672);
            this.dgvLoaiBan.TabIndex = 0;
            // 
            // pnlLBInput
            // 
            this.pnlLBInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLBInput.Controls.Add(this.txtIDLB);
            this.pnlLBInput.Controls.Add(this.labelLB1);
            this.pnlLBInput.Controls.Add(this.txtTenLB);
            this.pnlLBInput.Controls.Add(this.labelLB2);
            this.pnlLBInput.Controls.Add(this.numGiaLB);
            this.pnlLBInput.Controls.Add(this.labelLB3);
            this.pnlLBInput.Controls.Add(this.btnThemLB);
            this.pnlLBInput.Controls.Add(this.btnSuaLB);
            this.pnlLBInput.Controls.Add(this.btnXoaLB);
            this.pnlLBInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLBInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlLBInput.Location = new System.Drawing.Point(822, 0);
            this.pnlLBInput.Name = "pnlLBInput";
            this.pnlLBInput.Size = new System.Drawing.Size(450, 672);
            this.pnlLBInput.TabIndex = 1;
            // 
            // txtIDLB
            // 
            this.txtIDLB.Location = new System.Drawing.Point(140, 37);
            this.txtIDLB.Name = "txtIDLB";
            this.txtIDLB.ReadOnly = true;
            this.txtIDLB.Size = new System.Drawing.Size(280, 30);
            this.txtIDLB.TabIndex = 0;
            // 
            // labelLB1
            // 
            this.labelLB1.Location = new System.Drawing.Point(20, 40);
            this.labelLB1.Name = "labelLB1";
            this.labelLB1.Size = new System.Drawing.Size(100, 23);
            this.labelLB1.TabIndex = 1;
            this.labelLB1.Text = "ID:";
            // 
            // txtTenLB
            // 
            this.txtTenLB.Location = new System.Drawing.Point(140, 107);
            this.txtTenLB.Name = "txtTenLB";
            this.txtTenLB.Size = new System.Drawing.Size(280, 30);
            this.txtTenLB.TabIndex = 2;
            // 
            // labelLB2
            // 
            this.labelLB2.Location = new System.Drawing.Point(20, 110);
            this.labelLB2.Name = "labelLB2";
            this.labelLB2.Size = new System.Drawing.Size(100, 23);
            this.labelLB2.TabIndex = 3;
            this.labelLB2.Text = "Tên Loại:";
            // 
            // numGiaLB
            // 
            this.numGiaLB.Location = new System.Drawing.Point(140, 177);
            this.numGiaLB.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numGiaLB.Name = "numGiaLB";
            this.numGiaLB.Size = new System.Drawing.Size(280, 30);
            this.numGiaLB.TabIndex = 4;
            // 
            // labelLB3
            // 
            this.labelLB3.AutoSize = true;
            this.labelLB3.Location = new System.Drawing.Point(20, 180);
            this.labelLB3.Name = "labelLB3";
            this.labelLB3.Size = new System.Drawing.Size(84, 25);
            this.labelLB3.TabIndex = 5;
            this.labelLB3.Text = "Giá/Giờ:";
            // 
            // btnThemLB
            // 
            this.btnThemLB.BackColor = System.Drawing.Color.ForestGreen;
            this.btnThemLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemLB.ForeColor = System.Drawing.Color.White;
            this.btnThemLB.Location = new System.Drawing.Point(30, 270);
            this.btnThemLB.Name = "btnThemLB";
            this.btnThemLB.Size = new System.Drawing.Size(120, 60);
            this.btnThemLB.TabIndex = 6;
            this.btnThemLB.Text = "Thêm";
            this.btnThemLB.UseVisualStyleBackColor = false;
            // 
            // btnSuaLB
            // 
            this.btnSuaLB.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSuaLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaLB.ForeColor = System.Drawing.Color.White;
            this.btnSuaLB.Location = new System.Drawing.Point(165, 270);
            this.btnSuaLB.Name = "btnSuaLB";
            this.btnSuaLB.Size = new System.Drawing.Size(120, 60);
            this.btnSuaLB.TabIndex = 7;
            this.btnSuaLB.Text = "Sửa";
            this.btnSuaLB.UseVisualStyleBackColor = false;
            // 
            // btnXoaLB
            // 
            this.btnXoaLB.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoaLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaLB.ForeColor = System.Drawing.Color.White;
            this.btnXoaLB.Location = new System.Drawing.Point(300, 270);
            this.btnXoaLB.Name = "btnXoaLB";
            this.btnXoaLB.Size = new System.Drawing.Size(120, 60);
            this.btnXoaLB.TabIndex = 8;
            this.btnXoaLB.Text = "Xóa";
            this.btnXoaLB.UseVisualStyleBackColor = false;
            // 
            // tpBan
            // 
            this.tpBan.Controls.Add(this.panelBan);
            this.tpBan.Controls.Add(this.pnlBanFilter);
            this.tpBan.Controls.Add(this.pnlBanInput);
            this.tpBan.Location = new System.Drawing.Point(4, 44);
            this.tpBan.Name = "tpBan";
            this.tpBan.Size = new System.Drawing.Size(1272, 672);
            this.tpBan.TabIndex = 4;
            this.tpBan.Text = "Bàn chơi";
            // 
            // panelBan
            // 
            this.panelBan.Controls.Add(this.dgvBan);
            this.panelBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBan.Location = new System.Drawing.Point(0, 60);
            this.panelBan.Name = "panelBan";
            this.panelBan.Padding = new System.Windows.Forms.Padding(20);
            this.panelBan.Size = new System.Drawing.Size(822, 612);
            this.panelBan.TabIndex = 0;
            // 
            // dgvBan
            // 
            this.dgvBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBan.ColumnHeadersHeight = 50;
            this.dgvBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBan.Location = new System.Drawing.Point(20, 20);
            this.dgvBan.Name = "dgvBan";
            this.dgvBan.RowHeadersWidth = 51;
            this.dgvBan.RowTemplate.Height = 40;
            this.dgvBan.Size = new System.Drawing.Size(782, 572);
            this.dgvBan.TabIndex = 0;
            // 
            // pnlBanFilter
            // 
            this.pnlBanFilter.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlBanFilter.Controls.Add(this.lblBanFilterKhuVuc);
            this.pnlBanFilter.Controls.Add(this.cboBanFilterKhuVuc);
            this.pnlBanFilter.Controls.Add(this.lblBanFilterLoaiBan);
            this.pnlBanFilter.Controls.Add(this.cboBanFilterLoaiBan);
            this.pnlBanFilter.Controls.Add(this.lblBanFilterTen);
            this.pnlBanFilter.Controls.Add(this.txtBanFilterTen);
            this.pnlBanFilter.Controls.Add(this.btnBanFilterLoc);
            this.pnlBanFilter.Controls.Add(this.btnBanFilterXoa);
            this.pnlBanFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.pnlBanFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlBanFilter.Name = "pnlBanFilter";
            this.pnlBanFilter.Size = new System.Drawing.Size(822, 60);
            this.pnlBanFilter.TabIndex = 1;
            // 
            // lblBanFilterKhuVuc
            // 
            this.lblBanFilterKhuVuc.AutoSize = true;
            this.lblBanFilterKhuVuc.Location = new System.Drawing.Point(20, 18);
            this.lblBanFilterKhuVuc.Name = "lblBanFilterKhuVuc";
            this.lblBanFilterKhuVuc.Size = new System.Drawing.Size(84, 24);
            this.lblBanFilterKhuVuc.TabIndex = 0;
            this.lblBanFilterKhuVuc.Text = "Khu vực:";
            // 
            // cboBanFilterKhuVuc
            // 
            this.cboBanFilterKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanFilterKhuVuc.Location = new System.Drawing.Point(109, 15);
            this.cboBanFilterKhuVuc.Name = "cboBanFilterKhuVuc";
            this.cboBanFilterKhuVuc.Size = new System.Drawing.Size(140, 30);
            this.cboBanFilterKhuVuc.TabIndex = 1;
            // 
            // lblBanFilterLoaiBan
            // 
            this.lblBanFilterLoaiBan.AutoSize = true;
            this.lblBanFilterLoaiBan.Location = new System.Drawing.Point(256, 18);
            this.lblBanFilterLoaiBan.Name = "lblBanFilterLoaiBan";
            this.lblBanFilterLoaiBan.Size = new System.Drawing.Size(87, 24);
            this.lblBanFilterLoaiBan.TabIndex = 2;
            this.lblBanFilterLoaiBan.Text = "Loại bàn:";
            // 
            // cboBanFilterLoaiBan
            // 
            this.cboBanFilterLoaiBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanFilterLoaiBan.Location = new System.Drawing.Point(349, 15);
            this.cboBanFilterLoaiBan.Name = "cboBanFilterLoaiBan";
            this.cboBanFilterLoaiBan.Size = new System.Drawing.Size(140, 30);
            this.cboBanFilterLoaiBan.TabIndex = 3;
            // 
            // lblBanFilterTen
            // 
            this.lblBanFilterTen.AutoSize = true;
            this.lblBanFilterTen.Location = new System.Drawing.Point(495, 18);
            this.lblBanFilterTen.Name = "lblBanFilterTen";
            this.lblBanFilterTen.Size = new System.Drawing.Size(78, 24);
            this.lblBanFilterTen.TabIndex = 4;
            this.lblBanFilterTen.Text = "Tìm tên:";
            // 
            // txtBanFilterTen
            // 
            this.txtBanFilterTen.Location = new System.Drawing.Point(578, 16);
            this.txtBanFilterTen.Name = "txtBanFilterTen";
            this.txtBanFilterTen.Size = new System.Drawing.Size(160, 28);
            this.txtBanFilterTen.TabIndex = 5;
            // 
            // btnBanFilterLoc
            // 
            this.btnBanFilterLoc.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBanFilterLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanFilterLoc.ForeColor = System.Drawing.Color.White;
            this.btnBanFilterLoc.Location = new System.Drawing.Point(750, 10);
            this.btnBanFilterLoc.Name = "btnBanFilterLoc";
            this.btnBanFilterLoc.Size = new System.Drawing.Size(80, 40);
            this.btnBanFilterLoc.TabIndex = 6;
            this.btnBanFilterLoc.Text = "Lọc";
            this.btnBanFilterLoc.UseVisualStyleBackColor = false;
            // 
            // btnBanFilterXoa
            // 
            this.btnBanFilterXoa.BackColor = System.Drawing.Color.Gray;
            this.btnBanFilterXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanFilterXoa.ForeColor = System.Drawing.Color.White;
            this.btnBanFilterXoa.Location = new System.Drawing.Point(840, 10);
            this.btnBanFilterXoa.Name = "btnBanFilterXoa";
            this.btnBanFilterXoa.Size = new System.Drawing.Size(90, 40);
            this.btnBanFilterXoa.TabIndex = 7;
            this.btnBanFilterXoa.Text = "Xóa lọc";
            this.btnBanFilterXoa.UseVisualStyleBackColor = false;
            // 
            // pnlBanInput
            // 
            this.pnlBanInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBanInput.Controls.Add(this.txtIDBan);
            this.pnlBanInput.Controls.Add(this.labelBan1);
            this.pnlBanInput.Controls.Add(this.txtTenBan);
            this.pnlBanInput.Controls.Add(this.labelBan2);
            this.pnlBanInput.Controls.Add(this.cboKhuVuc);
            this.pnlBanInput.Controls.Add(this.labelBan3);
            this.pnlBanInput.Controls.Add(this.cboLoaiBan);
            this.pnlBanInput.Controls.Add(this.labelBan4);
            this.pnlBanInput.Controls.Add(this.btnThemBan);
            this.pnlBanInput.Controls.Add(this.btnSuaBan);
            this.pnlBanInput.Controls.Add(this.btnXoaBan);
            this.pnlBanInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBanInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlBanInput.Location = new System.Drawing.Point(822, 0);
            this.pnlBanInput.Name = "pnlBanInput";
            this.pnlBanInput.Size = new System.Drawing.Size(450, 672);
            this.pnlBanInput.TabIndex = 2;
            // 
            // txtIDBan
            // 
            this.txtIDBan.Location = new System.Drawing.Point(140, 37);
            this.txtIDBan.Name = "txtIDBan";
            this.txtIDBan.ReadOnly = true;
            this.txtIDBan.Size = new System.Drawing.Size(280, 30);
            this.txtIDBan.TabIndex = 0;
            // 
            // labelBan1
            // 
            this.labelBan1.Location = new System.Drawing.Point(20, 40);
            this.labelBan1.Name = "labelBan1";
            this.labelBan1.Size = new System.Drawing.Size(100, 23);
            this.labelBan1.TabIndex = 1;
            this.labelBan1.Text = "ID:";
            // 
            // txtTenBan
            // 
            this.txtTenBan.Location = new System.Drawing.Point(140, 107);
            this.txtTenBan.Name = "txtTenBan";
            this.txtTenBan.Size = new System.Drawing.Size(280, 30);
            this.txtTenBan.TabIndex = 2;
            // 
            // labelBan2
            // 
            this.labelBan2.Location = new System.Drawing.Point(20, 110);
            this.labelBan2.Name = "labelBan2";
            this.labelBan2.Size = new System.Drawing.Size(100, 23);
            this.labelBan2.TabIndex = 3;
            this.labelBan2.Text = "Tên bàn:";
            // 
            // cboKhuVuc
            // 
            this.cboKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhuVuc.Location = new System.Drawing.Point(140, 177);
            this.cboKhuVuc.Name = "cboKhuVuc";
            this.cboKhuVuc.Size = new System.Drawing.Size(280, 33);
            this.cboKhuVuc.TabIndex = 4;
            // 
            // labelBan3
            // 
            this.labelBan3.Location = new System.Drawing.Point(20, 180);
            this.labelBan3.Name = "labelBan3";
            this.labelBan3.Size = new System.Drawing.Size(100, 23);
            this.labelBan3.TabIndex = 5;
            this.labelBan3.Text = "Khu vực:";
            // 
            // cboLoaiBan
            // 
            this.cboLoaiBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBan.Location = new System.Drawing.Point(140, 247);
            this.cboLoaiBan.Name = "cboLoaiBan";
            this.cboLoaiBan.Size = new System.Drawing.Size(280, 33);
            this.cboLoaiBan.TabIndex = 6;
            // 
            // labelBan4
            // 
            this.labelBan4.AutoSize = true;
            this.labelBan4.Location = new System.Drawing.Point(20, 250);
            this.labelBan4.Name = "labelBan4";
            this.labelBan4.Size = new System.Drawing.Size(93, 25);
            this.labelBan4.TabIndex = 7;
            this.labelBan4.Text = "Loại bàn:";
            // 
            // btnThemBan
            // 
            this.btnThemBan.BackColor = System.Drawing.Color.ForestGreen;
            this.btnThemBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemBan.ForeColor = System.Drawing.Color.White;
            this.btnThemBan.Location = new System.Drawing.Point(30, 340);
            this.btnThemBan.Name = "btnThemBan";
            this.btnThemBan.Size = new System.Drawing.Size(120, 60);
            this.btnThemBan.TabIndex = 8;
            this.btnThemBan.Text = "Thêm";
            this.btnThemBan.UseVisualStyleBackColor = false;
            // 
            // btnSuaBan
            // 
            this.btnSuaBan.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSuaBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaBan.ForeColor = System.Drawing.Color.White;
            this.btnSuaBan.Location = new System.Drawing.Point(165, 340);
            this.btnSuaBan.Name = "btnSuaBan";
            this.btnSuaBan.Size = new System.Drawing.Size(120, 60);
            this.btnSuaBan.TabIndex = 9;
            this.btnSuaBan.Text = "Sửa";
            this.btnSuaBan.UseVisualStyleBackColor = false;
            // 
            // btnXoaBan
            // 
            this.btnXoaBan.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoaBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaBan.ForeColor = System.Drawing.Color.White;
            this.btnXoaBan.Location = new System.Drawing.Point(300, 340);
            this.btnXoaBan.Name = "btnXoaBan";
            this.btnXoaBan.Size = new System.Drawing.Size(120, 60);
            this.btnXoaBan.TabIndex = 10;
            this.btnXoaBan.Text = "Xóa";
            this.btnXoaBan.UseVisualStyleBackColor = false;
            // 
            // tpDoanhThu
            // 
            this.tpDoanhThu.Controls.Add(this.tlpDoanhThu);
            this.tpDoanhThu.Location = new System.Drawing.Point(4, 44);
            this.tpDoanhThu.Name = "tpDoanhThu";
            this.tpDoanhThu.Padding = new System.Windows.Forms.Padding(3);
            this.tpDoanhThu.Size = new System.Drawing.Size(1272, 672);
            this.tpDoanhThu.TabIndex = 5;
            this.tpDoanhThu.Text = "Báo cáo Doanh thu";
            this.tpDoanhThu.UseVisualStyleBackColor = true;
            // 
            // tlpDoanhThu
            // 
            this.tlpDoanhThu.ColumnCount = 1;
            this.tlpDoanhThu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDoanhThu.Controls.Add(this.pnlDate, 0, 0);
            this.tlpDoanhThu.Controls.Add(this.chartDoanhThu, 0, 1);
            this.tlpDoanhThu.Controls.Add(this.dgvDoanhThu, 0, 2);
            this.tlpDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDoanhThu.Location = new System.Drawing.Point(3, 3);
            this.tlpDoanhThu.Name = "tlpDoanhThu";
            this.tlpDoanhThu.RowCount = 3;
            this.tlpDoanhThu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpDoanhThu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpDoanhThu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpDoanhThu.Size = new System.Drawing.Size(1266, 666);
            this.tlpDoanhThu.TabIndex = 0;
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.btnThongKe);
            this.pnlDate.Controls.Add(this.dtpkToDate);
            this.pnlDate.Controls.Add(this.dtpkFromDate);
            this.pnlDate.Controls.Add(this.label1);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnlDate.Location = new System.Drawing.Point(3, 3);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(1260, 64);
            this.pnlDate.TabIndex = 0;
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(580, 10);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(160, 45);
            this.btnThongKe.TabIndex = 0;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            // 
            // dtpkToDate
            // 
            this.dtpkToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpkToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkToDate.Location = new System.Drawing.Point(350, 17);
            this.dtpkToDate.Name = "dtpkToDate";
            this.dtpkToDate.Size = new System.Drawing.Size(200, 30);
            this.dtpkToDate.TabIndex = 1;
            // 
            // dtpkFromDate
            // 
            this.dtpkFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpkFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkFromDate.Location = new System.Drawing.Point(20, 17);
            this.dtpkFromDate.Name = "dtpkFromDate";
            this.dtpkFromDate.Size = new System.Drawing.Size(200, 30);
            this.dtpkFromDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Đến ngày:";
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(3, 73);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "DoanhThu";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(1260, 351);
            this.chartDoanhThu.TabIndex = 1;
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDoanhThu.ColumnHeadersHeight = 50;
            this.dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThu.Location = new System.Drawing.Point(3, 430);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.RowHeadersWidth = 51;
            this.dgvDoanhThu.RowTemplate.Height = 40;
            this.dgvDoanhThu.Size = new System.Drawing.Size(1260, 233);
            this.dgvDoanhThu.TabIndex = 2;
            // 
            // tpBaoCaoNangCao
            // 
            this.tpBaoCaoNangCao.Controls.Add(this.dgvBCNC_BaoCao);
            this.tpBaoCaoNangCao.Controls.Add(this.pnlBCNC_DongBo);
            this.tpBaoCaoNangCao.Controls.Add(this.pnlBCNC_ThongKe);
            this.tpBaoCaoNangCao.Location = new System.Drawing.Point(4, 44);
            this.tpBaoCaoNangCao.Name = "tpBaoCaoNangCao";
            this.tpBaoCaoNangCao.Size = new System.Drawing.Size(1272, 672);
            this.tpBaoCaoNangCao.TabIndex = 6;
            this.tpBaoCaoNangCao.Text = "Báo cáo nâng cao";
            // 
            // dgvBCNC_BaoCao
            // 
            this.dgvBCNC_BaoCao.AllowUserToAddRows = false;
            this.dgvBCNC_BaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBCNC_BaoCao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBCNC_BaoCao.ColumnHeadersHeight = 50;
            this.dgvBCNC_BaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBCNC_BaoCao.Location = new System.Drawing.Point(0, 170);
            this.dgvBCNC_BaoCao.Name = "dgvBCNC_BaoCao";
            this.dgvBCNC_BaoCao.ReadOnly = true;
            this.dgvBCNC_BaoCao.RowHeadersWidth = 51;
            this.dgvBCNC_BaoCao.RowTemplate.Height = 40;
            this.dgvBCNC_BaoCao.Size = new System.Drawing.Size(1272, 502);
            this.dgvBCNC_BaoCao.TabIndex = 0;
            // 
            // pnlBCNC_DongBo
            // 
            this.pnlBCNC_DongBo.Controls.Add(this.dtpBCNC_TuNgay);
            this.pnlBCNC_DongBo.Controls.Add(this.dtpBCNC_DenNgay);
            this.pnlBCNC_DongBo.Controls.Add(this.chkBCNC_GhiDe);
            this.pnlBCNC_DongBo.Controls.Add(this.btnBCNC_DongBo);
            this.pnlBCNC_DongBo.Controls.Add(this.btnBCNC_XemBaoCao);
            this.pnlBCNC_DongBo.Controls.Add(this.btnBCNC_LamMoi);
            this.pnlBCNC_DongBo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBCNC_DongBo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.pnlBCNC_DongBo.Location = new System.Drawing.Point(0, 100);
            this.pnlBCNC_DongBo.Name = "pnlBCNC_DongBo";
            this.pnlBCNC_DongBo.Size = new System.Drawing.Size(1272, 70);
            this.pnlBCNC_DongBo.TabIndex = 1;
            // 
            // dtpBCNC_TuNgay
            // 
            this.dtpBCNC_TuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpBCNC_TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBCNC_TuNgay.Location = new System.Drawing.Point(20, 20);
            this.dtpBCNC_TuNgay.Name = "dtpBCNC_TuNgay";
            this.dtpBCNC_TuNgay.Size = new System.Drawing.Size(150, 28);
            this.dtpBCNC_TuNgay.TabIndex = 0;
            // 
            // dtpBCNC_DenNgay
            // 
            this.dtpBCNC_DenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpBCNC_DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBCNC_DenNgay.Location = new System.Drawing.Point(190, 20);
            this.dtpBCNC_DenNgay.Name = "dtpBCNC_DenNgay";
            this.dtpBCNC_DenNgay.Size = new System.Drawing.Size(150, 28);
            this.dtpBCNC_DenNgay.TabIndex = 1;
            // 
            // chkBCNC_GhiDe
            // 
            this.chkBCNC_GhiDe.AutoSize = true;
            this.chkBCNC_GhiDe.Checked = true;
            this.chkBCNC_GhiDe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBCNC_GhiDe.Location = new System.Drawing.Point(360, 22);
            this.chkBCNC_GhiDe.Name = "chkBCNC_GhiDe";
            this.chkBCNC_GhiDe.Size = new System.Drawing.Size(89, 28);
            this.chkBCNC_GhiDe.TabIndex = 2;
            this.chkBCNC_GhiDe.Text = "Ghi đè";
            // 
            // btnBCNC_DongBo
            // 
            this.btnBCNC_DongBo.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBCNC_DongBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBCNC_DongBo.ForeColor = System.Drawing.Color.White;
            this.btnBCNC_DongBo.Location = new System.Drawing.Point(470, 15);
            this.btnBCNC_DongBo.Name = "btnBCNC_DongBo";
            this.btnBCNC_DongBo.Size = new System.Drawing.Size(160, 40);
            this.btnBCNC_DongBo.TabIndex = 3;
            this.btnBCNC_DongBo.Text = "Đồng bộ (Cursor)";
            this.btnBCNC_DongBo.UseVisualStyleBackColor = false;
            // 
            // btnBCNC_XemBaoCao
            // 
            this.btnBCNC_XemBaoCao.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnBCNC_XemBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBCNC_XemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBCNC_XemBaoCao.Location = new System.Drawing.Point(650, 15);
            this.btnBCNC_XemBaoCao.Name = "btnBCNC_XemBaoCao";
            this.btnBCNC_XemBaoCao.Size = new System.Drawing.Size(140, 40);
            this.btnBCNC_XemBaoCao.TabIndex = 4;
            this.btnBCNC_XemBaoCao.Text = "Xem báo cáo";
            this.btnBCNC_XemBaoCao.UseVisualStyleBackColor = false;
            // 
            // btnBCNC_LamMoi
            // 
            this.btnBCNC_LamMoi.BackColor = System.Drawing.Color.Gray;
            this.btnBCNC_LamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBCNC_LamMoi.ForeColor = System.Drawing.Color.White;
            this.btnBCNC_LamMoi.Location = new System.Drawing.Point(810, 15);
            this.btnBCNC_LamMoi.Name = "btnBCNC_LamMoi";
            this.btnBCNC_LamMoi.Size = new System.Drawing.Size(120, 40);
            this.btnBCNC_LamMoi.TabIndex = 5;
            this.btnBCNC_LamMoi.Text = "Làm mới";
            this.btnBCNC_LamMoi.UseVisualStyleBackColor = false;
            // 
            // pnlBCNC_ThongKe
            // 
            this.pnlBCNC_ThongKe.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlBCNC_ThongKe.Controls.Add(this.lblBCNC_DoanhThuHomNay);
            this.pnlBCNC_ThongKe.Controls.Add(this.lblBCNC_GiaTriDoanhThuHomNay);
            this.pnlBCNC_ThongKe.Controls.Add(this.lblBCNC_SoHoaDon);
            this.pnlBCNC_ThongKe.Controls.Add(this.lblBCNC_GiaTriSoHoaDon);
            this.pnlBCNC_ThongKe.Controls.Add(this.lblBCNC_TrungBinh);
            this.pnlBCNC_ThongKe.Controls.Add(this.lblBCNC_GiaTriTrungBinh);
            this.pnlBCNC_ThongKe.Controls.Add(this.lblBCNC_DoanhThuThang);
            this.pnlBCNC_ThongKe.Controls.Add(this.lblBCNC_GiaTriDoanhThuThang);
            this.pnlBCNC_ThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBCNC_ThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.pnlBCNC_ThongKe.Location = new System.Drawing.Point(0, 0);
            this.pnlBCNC_ThongKe.Name = "pnlBCNC_ThongKe";
            this.pnlBCNC_ThongKe.Size = new System.Drawing.Size(1272, 100);
            this.pnlBCNC_ThongKe.TabIndex = 2;
            // 
            // lblBCNC_DoanhThuHomNay
            // 
            this.lblBCNC_DoanhThuHomNay.AutoSize = true;
            this.lblBCNC_DoanhThuHomNay.Location = new System.Drawing.Point(20, 15);
            this.lblBCNC_DoanhThuHomNay.Name = "lblBCNC_DoanhThuHomNay";
            this.lblBCNC_DoanhThuHomNay.Size = new System.Drawing.Size(180, 24);
            this.lblBCNC_DoanhThuHomNay.TabIndex = 0;
            this.lblBCNC_DoanhThuHomNay.Text = "Doanh thu hôm nay:";
            // 
            // lblBCNC_GiaTriDoanhThuHomNay
            // 
            this.lblBCNC_GiaTriDoanhThuHomNay.AutoSize = true;
            this.lblBCNC_GiaTriDoanhThuHomNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblBCNC_GiaTriDoanhThuHomNay.ForeColor = System.Drawing.Color.Green;
            this.lblBCNC_GiaTriDoanhThuHomNay.Location = new System.Drawing.Point(20, 45);
            this.lblBCNC_GiaTriDoanhThuHomNay.Name = "lblBCNC_GiaTriDoanhThuHomNay";
            this.lblBCNC_GiaTriDoanhThuHomNay.Size = new System.Drawing.Size(49, 29);
            this.lblBCNC_GiaTriDoanhThuHomNay.TabIndex = 1;
            this.lblBCNC_GiaTriDoanhThuHomNay.Text = "0 đ";
            // 
            // lblBCNC_SoHoaDon
            // 
            this.lblBCNC_SoHoaDon.AutoSize = true;
            this.lblBCNC_SoHoaDon.Location = new System.Drawing.Point(250, 15);
            this.lblBCNC_SoHoaDon.Name = "lblBCNC_SoHoaDon";
            this.lblBCNC_SoHoaDon.Size = new System.Drawing.Size(192, 24);
            this.lblBCNC_SoHoaDon.TabIndex = 2;
            this.lblBCNC_SoHoaDon.Text = "Số hóa đơn hôm nay:";
            // 
            // lblBCNC_GiaTriSoHoaDon
            // 
            this.lblBCNC_GiaTriSoHoaDon.AutoSize = true;
            this.lblBCNC_GiaTriSoHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblBCNC_GiaTriSoHoaDon.ForeColor = System.Drawing.Color.Blue;
            this.lblBCNC_GiaTriSoHoaDon.Location = new System.Drawing.Point(250, 45);
            this.lblBCNC_GiaTriSoHoaDon.Name = "lblBCNC_GiaTriSoHoaDon";
            this.lblBCNC_GiaTriSoHoaDon.Size = new System.Drawing.Size(27, 29);
            this.lblBCNC_GiaTriSoHoaDon.TabIndex = 3;
            this.lblBCNC_GiaTriSoHoaDon.Text = "0";
            // 
            // lblBCNC_TrungBinh
            // 
            this.lblBCNC_TrungBinh.AutoSize = true;
            this.lblBCNC_TrungBinh.Location = new System.Drawing.Point(480, 15);
            this.lblBCNC_TrungBinh.Name = "lblBCNC_TrungBinh";
            this.lblBCNC_TrungBinh.Size = new System.Drawing.Size(184, 24);
            this.lblBCNC_TrungBinh.TabIndex = 4;
            this.lblBCNC_TrungBinh.Text = "Trung bình/hóa đơn:";
            // 
            // lblBCNC_GiaTriTrungBinh
            // 
            this.lblBCNC_GiaTriTrungBinh.AutoSize = true;
            this.lblBCNC_GiaTriTrungBinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblBCNC_GiaTriTrungBinh.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblBCNC_GiaTriTrungBinh.Location = new System.Drawing.Point(480, 45);
            this.lblBCNC_GiaTriTrungBinh.Name = "lblBCNC_GiaTriTrungBinh";
            this.lblBCNC_GiaTriTrungBinh.Size = new System.Drawing.Size(49, 29);
            this.lblBCNC_GiaTriTrungBinh.TabIndex = 5;
            this.lblBCNC_GiaTriTrungBinh.Text = "0 đ";
            // 
            // lblBCNC_DoanhThuThang
            // 
            this.lblBCNC_DoanhThuThang.AutoSize = true;
            this.lblBCNC_DoanhThuThang.Location = new System.Drawing.Point(710, 15);
            this.lblBCNC_DoanhThuThang.Name = "lblBCNC_DoanhThuThang";
            this.lblBCNC_DoanhThuThang.Size = new System.Drawing.Size(189, 24);
            this.lblBCNC_DoanhThuThang.TabIndex = 6;
            this.lblBCNC_DoanhThuThang.Text = "Doanh thu tháng này:";
            // 
            // lblBCNC_GiaTriDoanhThuThang
            // 
            this.lblBCNC_GiaTriDoanhThuThang.AutoSize = true;
            this.lblBCNC_GiaTriDoanhThuThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblBCNC_GiaTriDoanhThuThang.ForeColor = System.Drawing.Color.Purple;
            this.lblBCNC_GiaTriDoanhThuThang.Location = new System.Drawing.Point(710, 45);
            this.lblBCNC_GiaTriDoanhThuThang.Name = "lblBCNC_GiaTriDoanhThuThang";
            this.lblBCNC_GiaTriDoanhThuThang.Size = new System.Drawing.Size(49, 29);
            this.lblBCNC_GiaTriDoanhThuThang.TabIndex = 7;
            this.lblBCNC_GiaTriDoanhThuThang.Text = "0 đ";
            // 
            // tpTaiKhoan
            // 
            this.tpTaiKhoan.Controls.Add(this.panelTK);
            this.tpTaiKhoan.Controls.Add(this.pnlTKInput);
            this.tpTaiKhoan.Location = new System.Drawing.Point(4, 44);
            this.tpTaiKhoan.Name = "tpTaiKhoan";
            this.tpTaiKhoan.Size = new System.Drawing.Size(1272, 672);
            this.tpTaiKhoan.TabIndex = 7;
            this.tpTaiKhoan.Text = "Tài khoản";
            // 
            // panelTK
            // 
            this.panelTK.Controls.Add(this.dgvTaiKhoan);
            this.panelTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTK.Location = new System.Drawing.Point(0, 0);
            this.panelTK.Name = "panelTK";
            this.panelTK.Padding = new System.Windows.Forms.Padding(20);
            this.panelTK.Size = new System.Drawing.Size(792, 672);
            this.panelTK.TabIndex = 0;
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTaiKhoan.ColumnHeadersHeight = 50;
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(20, 20);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.RowHeadersWidth = 51;
            this.dgvTaiKhoan.RowTemplate.Height = 40;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(752, 632);
            this.dgvTaiKhoan.TabIndex = 0;
            // 
            // pnlTKInput
            // 
            this.pnlTKInput.AutoScroll = true;
            this.pnlTKInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTKInput.Controls.Add(this.txtIDTK);
            this.pnlTKInput.Controls.Add(this.labelTK1);
            this.pnlTKInput.Controls.Add(this.txtTenDangNhap);
            this.pnlTKInput.Controls.Add(this.labelTK2);
            this.pnlTKInput.Controls.Add(this.txtMatKhauTK);
            this.pnlTKInput.Controls.Add(this.labelTK3);
            this.pnlTKInput.Controls.Add(this.cboVaiTro);
            this.pnlTKInput.Controls.Add(this.labelTK4);
            this.pnlTKInput.Controls.Add(this.cboTrangThaiTK);
            this.pnlTKInput.Controls.Add(this.labelTK5);
            this.pnlTKInput.Controls.Add(this.grpNhanVien);
            this.pnlTKInput.Controls.Add(this.btnThemTK);
            this.pnlTKInput.Controls.Add(this.btnSuaTK);
            this.pnlTKInput.Controls.Add(this.btnXoaTK);
            this.pnlTKInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTKInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.pnlTKInput.Location = new System.Drawing.Point(792, 0);
            this.pnlTKInput.Name = "pnlTKInput";
            this.pnlTKInput.Size = new System.Drawing.Size(480, 672);
            this.pnlTKInput.TabIndex = 1;
            // 
            // txtIDTK
            // 
            this.txtIDTK.Location = new System.Drawing.Point(160, 17);
            this.txtIDTK.Name = "txtIDTK";
            this.txtIDTK.ReadOnly = true;
            this.txtIDTK.Size = new System.Drawing.Size(280, 28);
            this.txtIDTK.TabIndex = 0;
            // 
            // labelTK1
            // 
            this.labelTK1.AutoSize = true;
            this.labelTK1.Location = new System.Drawing.Point(20, 20);
            this.labelTK1.Name = "labelTK1";
            this.labelTK1.Size = new System.Drawing.Size(32, 24);
            this.labelTK1.TabIndex = 1;
            this.labelTK1.Text = "ID:";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(160, 52);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(280, 28);
            this.txtTenDangNhap.TabIndex = 2;
            // 
            // labelTK2
            // 
            this.labelTK2.AutoSize = true;
            this.labelTK2.Location = new System.Drawing.Point(20, 55);
            this.labelTK2.Name = "labelTK2";
            this.labelTK2.Size = new System.Drawing.Size(146, 24);
            this.labelTK2.TabIndex = 3;
            this.labelTK2.Text = "Tên đăng nhập:";
            // 
            // txtMatKhauTK
            // 
            this.txtMatKhauTK.Location = new System.Drawing.Point(160, 87);
            this.txtMatKhauTK.Name = "txtMatKhauTK";
            this.txtMatKhauTK.Size = new System.Drawing.Size(280, 28);
            this.txtMatKhauTK.TabIndex = 4;
            // 
            // labelTK3
            // 
            this.labelTK3.AutoSize = true;
            this.labelTK3.Location = new System.Drawing.Point(20, 90);
            this.labelTK3.Name = "labelTK3";
            this.labelTK3.Size = new System.Drawing.Size(91, 24);
            this.labelTK3.TabIndex = 5;
            this.labelTK3.Text = "Mật khẩu:";
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.Items.AddRange(new object[] {
            "Admin",
            "Nhân viên"});
            this.cboVaiTro.Location = new System.Drawing.Point(160, 122);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(280, 30);
            this.cboVaiTro.TabIndex = 6;
            // 
            // labelTK4
            // 
            this.labelTK4.AutoSize = true;
            this.labelTK4.Location = new System.Drawing.Point(20, 125);
            this.labelTK4.Name = "labelTK4";
            this.labelTK4.Size = new System.Drawing.Size(68, 24);
            this.labelTK4.TabIndex = 7;
            this.labelTK4.Text = "Vai trò:";
            // 
            // cboTrangThaiTK
            // 
            this.cboTrangThaiTK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiTK.Items.AddRange(new object[] {
            "Hoạt động",
            "Khóa"});
            this.cboTrangThaiTK.Location = new System.Drawing.Point(160, 157);
            this.cboTrangThaiTK.Name = "cboTrangThaiTK";
            this.cboTrangThaiTK.Size = new System.Drawing.Size(280, 30);
            this.cboTrangThaiTK.TabIndex = 8;
            // 
            // labelTK5
            // 
            this.labelTK5.AutoSize = true;
            this.labelTK5.Location = new System.Drawing.Point(20, 160);
            this.labelTK5.Name = "labelTK5";
            this.labelTK5.Size = new System.Drawing.Size(99, 24);
            this.labelTK5.TabIndex = 9;
            this.labelTK5.Text = "Trạng thái:";
            // 
            // grpNhanVien
            // 
            this.grpNhanVien.Controls.Add(this.txtHoTen);
            this.grpNhanVien.Controls.Add(this.labelNV1);
            this.grpNhanVien.Controls.Add(this.txtSoDienThoai);
            this.grpNhanVien.Controls.Add(this.labelNV2);
            this.grpNhanVien.Controls.Add(this.txtEmail);
            this.grpNhanVien.Controls.Add(this.labelNV3);
            this.grpNhanVien.Controls.Add(this.numLuong);
            this.grpNhanVien.Controls.Add(this.labelNV4);
            this.grpNhanVien.Location = new System.Drawing.Point(20, 195);
            this.grpNhanVien.Name = "grpNhanVien";
            this.grpNhanVien.Size = new System.Drawing.Size(420, 180);
            this.grpNhanVien.TabIndex = 10;
            this.grpNhanVien.TabStop = false;
            this.grpNhanVien.Text = "Thông tin Nhân viên (Trigger tự tạo)";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(110, 27);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(290, 28);
            this.txtHoTen.TabIndex = 0;
            // 
            // labelNV1
            // 
            this.labelNV1.AutoSize = true;
            this.labelNV1.Location = new System.Drawing.Point(10, 30);
            this.labelNV1.Name = "labelNV1";
            this.labelNV1.Size = new System.Drawing.Size(71, 24);
            this.labelNV1.TabIndex = 1;
            this.labelNV1.Text = "Họ tên:";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(110, 62);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(290, 28);
            this.txtSoDienThoai.TabIndex = 2;
            // 
            // labelNV2
            // 
            this.labelNV2.AutoSize = true;
            this.labelNV2.Location = new System.Drawing.Point(10, 65);
            this.labelNV2.Name = "labelNV2";
            this.labelNV2.Size = new System.Drawing.Size(52, 24);
            this.labelNV2.TabIndex = 3;
            this.labelNV2.Text = "SĐT:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(110, 97);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(290, 28);
            this.txtEmail.TabIndex = 4;
            // 
            // labelNV3
            // 
            this.labelNV3.AutoSize = true;
            this.labelNV3.Location = new System.Drawing.Point(10, 100);
            this.labelNV3.Name = "labelNV3";
            this.labelNV3.Size = new System.Drawing.Size(62, 24);
            this.labelNV3.TabIndex = 5;
            this.labelNV3.Text = "Email:";
            // 
            // numLuong
            // 
            this.numLuong.Location = new System.Drawing.Point(110, 132);
            this.numLuong.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numLuong.Name = "numLuong";
            this.numLuong.Size = new System.Drawing.Size(290, 28);
            this.numLuong.TabIndex = 6;
            // 
            // labelNV4
            // 
            this.labelNV4.AutoSize = true;
            this.labelNV4.Location = new System.Drawing.Point(10, 135);
            this.labelNV4.Name = "labelNV4";
            this.labelNV4.Size = new System.Drawing.Size(69, 24);
            this.labelNV4.TabIndex = 7;
            this.labelNV4.Text = "Lương:";
            // 
            // btnThemTK
            // 
            this.btnThemTK.BackColor = System.Drawing.Color.ForestGreen;
            this.btnThemTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTK.ForeColor = System.Drawing.Color.White;
            this.btnThemTK.Location = new System.Drawing.Point(30, 390);
            this.btnThemTK.Name = "btnThemTK";
            this.btnThemTK.Size = new System.Drawing.Size(120, 50);
            this.btnThemTK.TabIndex = 11;
            this.btnThemTK.Text = "Thêm";
            this.btnThemTK.UseVisualStyleBackColor = false;
            // 
            // btnSuaTK
            // 
            this.btnSuaTK.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSuaTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaTK.ForeColor = System.Drawing.Color.White;
            this.btnSuaTK.Location = new System.Drawing.Point(165, 390);
            this.btnSuaTK.Name = "btnSuaTK";
            this.btnSuaTK.Size = new System.Drawing.Size(120, 50);
            this.btnSuaTK.TabIndex = 12;
            this.btnSuaTK.Text = "Sửa";
            this.btnSuaTK.UseVisualStyleBackColor = false;
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoaTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTK.ForeColor = System.Drawing.Color.White;
            this.btnXoaTK.Location = new System.Drawing.Point(300, 390);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(120, 50);
            this.btnXoaTK.TabIndex = 13;
            this.btnXoaTK.Text = "Xóa";
            this.btnXoaTK.UseVisualStyleBackColor = false;
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tcAdmin);
            this.Name = "fAdmin";
            this.Text = "Quản trị hệ thống";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tcAdmin.ResumeLayout(false);
            this.tpDanhMuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            this.pnlCatInput.ResumeLayout(false);
            this.pnlCatInput.PerformLayout();
            this.tpSanPham.ResumeLayout(false);
            this.panelSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.pnlSPFilter.ResumeLayout(false);
            this.pnlSPFilter.PerformLayout();
            this.pnlSPInput.ResumeLayout(false);
            this.pnlSPInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaSP)).EndInit();
            this.tpKhuVuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuVuc)).EndInit();
            this.pnlKVInput.ResumeLayout(false);
            this.pnlKVInput.PerformLayout();
            this.tpLoaiBan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiBan)).EndInit();
            this.pnlLBInput.ResumeLayout(false);
            this.pnlLBInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaLB)).EndInit();
            this.tpBan.ResumeLayout(false);
            this.panelBan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).EndInit();
            this.pnlBanFilter.ResumeLayout(false);
            this.pnlBanFilter.PerformLayout();
            this.pnlBanInput.ResumeLayout(false);
            this.pnlBanInput.PerformLayout();
            this.tpDoanhThu.ResumeLayout(false);
            this.tlpDoanhThu.ResumeLayout(false);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.tpBaoCaoNangCao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCNC_BaoCao)).EndInit();
            this.pnlBCNC_DongBo.ResumeLayout(false);
            this.pnlBCNC_DongBo.PerformLayout();
            this.pnlBCNC_ThongKe.ResumeLayout(false);
            this.pnlBCNC_ThongKe.PerformLayout();
            this.tpTaiKhoan.ResumeLayout(false);
            this.panelTK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.pnlTKInput.ResumeLayout(false);
            this.pnlTKInput.PerformLayout();
            this.grpNhanVien.ResumeLayout(false);
            this.grpNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAdmin;
        // Doanh Thu
        private System.Windows.Forms.TabPage tpDoanhThu;
        private System.Windows.Forms.TableLayoutPanel tlpDoanhThu;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.DateTimePicker dtpkFromDate, dtpkToDate;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        // San Pham
        private System.Windows.Forms.TabPage tpSanPham;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Panel pnlSPInput, panelSP;
        private System.Windows.Forms.Button btnThemSP, btnSuaSP, btnXoaSP;
        private System.Windows.Forms.TextBox txtTenSP, txtIDSP;
        private System.Windows.Forms.ComboBox cboDanhMucSP;
        private System.Windows.Forms.ComboBox cboTrangThaiSP;
        private System.Windows.Forms.NumericUpDown numGiaSP;
        private System.Windows.Forms.Label labelSP1, labelSP2, labelSP3, labelSP4, labelSP5;
        // Ban
        private System.Windows.Forms.TabPage tpBan;
        private System.Windows.Forms.DataGridView dgvBan;
        private System.Windows.Forms.Panel pnlBanInput, panelBan;
        private System.Windows.Forms.Button btnThemBan, btnSuaBan, btnXoaBan;
        private System.Windows.Forms.TextBox txtTenBan, txtIDBan;
        private System.Windows.Forms.ComboBox cboKhuVuc, cboLoaiBan;
        private System.Windows.Forms.Label labelBan1, labelBan2, labelBan3, labelBan4;
        // Danh Muc
        private System.Windows.Forms.TabPage tpDanhMuc;
        private System.Windows.Forms.DataGridView dgvDanhMuc;
        private System.Windows.Forms.Panel pnlCatInput;
        private System.Windows.Forms.Button btnThemCat, btnSuaCat, btnXoaCat;
        private System.Windows.Forms.TextBox txtTenCat, txtIDCat;
        private System.Windows.Forms.Label labelCat1, labelCat2;
        // Khu Vuc
        private System.Windows.Forms.TabPage tpKhuVuc;
        private System.Windows.Forms.DataGridView dgvKhuVuc;
        private System.Windows.Forms.Panel pnlKVInput;
        private System.Windows.Forms.Button btnThemKV, btnSuaKV, btnXoaKV;
        private System.Windows.Forms.TextBox txtTenKV, txtIDKV;
        private System.Windows.Forms.Label labelKV1, labelKV2;
        // Loai Ban
        private System.Windows.Forms.TabPage tpLoaiBan;
        private System.Windows.Forms.DataGridView dgvLoaiBan;
        private System.Windows.Forms.Panel pnlLBInput;
        private System.Windows.Forms.Button btnThemLB, btnSuaLB, btnXoaLB;
        private System.Windows.Forms.TextBox txtTenLB, txtIDLB;
        private System.Windows.Forms.NumericUpDown numGiaLB;
        private System.Windows.Forms.Label labelLB1, labelLB2, labelLB3;
        // Tai Khoan
        private System.Windows.Forms.TabPage tpTaiKhoan;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.Panel pnlTKInput, panelTK;
        private System.Windows.Forms.Button btnThemTK, btnSuaTK, btnXoaTK;
        private System.Windows.Forms.TextBox txtIDTK, txtTenDangNhap, txtMatKhauTK;
        private System.Windows.Forms.ComboBox cboVaiTro, cboTrangThaiTK;
        private System.Windows.Forms.Label labelTK1, labelTK2, labelTK3, labelTK4, labelTK5;
        private System.Windows.Forms.GroupBox grpNhanVien;
        private System.Windows.Forms.TextBox txtHoTen, txtSoDienThoai, txtEmail;
        private System.Windows.Forms.NumericUpDown numLuong;
        private System.Windows.Forms.Label labelNV1, labelNV2, labelNV3, labelNV4;
        // Bao Cao Nang Cao
        private System.Windows.Forms.TabPage tpBaoCaoNangCao;
        private System.Windows.Forms.Panel pnlBCNC_ThongKe, pnlBCNC_DongBo;
        private System.Windows.Forms.Label lblBCNC_DoanhThuHomNay, lblBCNC_GiaTriDoanhThuHomNay;
        private System.Windows.Forms.Label lblBCNC_SoHoaDon, lblBCNC_GiaTriSoHoaDon;
        private System.Windows.Forms.Label lblBCNC_TrungBinh, lblBCNC_GiaTriTrungBinh;
        private System.Windows.Forms.Label lblBCNC_DoanhThuThang, lblBCNC_GiaTriDoanhThuThang;
        private System.Windows.Forms.DateTimePicker dtpBCNC_TuNgay, dtpBCNC_DenNgay;
        private System.Windows.Forms.CheckBox chkBCNC_GhiDe;
        private System.Windows.Forms.Button btnBCNC_DongBo, btnBCNC_XemBaoCao, btnBCNC_LamMoi;
        private System.Windows.Forms.DataGridView dgvBCNC_BaoCao;

        // Bộ lọc Sản phẩm
        private System.Windows.Forms.Panel pnlSPFilter;
        private System.Windows.Forms.Label lblSPFilterDanhMuc, lblSPFilterTen;
        private System.Windows.Forms.ComboBox cboSPFilterDanhMuc;
        private System.Windows.Forms.TextBox txtSPFilterTen;
        private System.Windows.Forms.Button btnSPFilterLoc, btnSPFilterXoa;

        // Bộ lọc Bàn
        private System.Windows.Forms.Panel pnlBanFilter;
        private System.Windows.Forms.Label lblBanFilterKhuVuc, lblBanFilterLoaiBan, lblBanFilterTen;
        private System.Windows.Forms.ComboBox cboBanFilterKhuVuc, cboBanFilterLoaiBan;
        private System.Windows.Forms.TextBox txtBanFilterTen;
        private System.Windows.Forms.Button btnBanFilterLoc, btnBanFilterXoa;
    }
}