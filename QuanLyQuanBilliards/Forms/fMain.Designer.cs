namespace QuanLyQuanBilliards.Forms
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblNgayHienTai = new System.Windows.Forms.Label();
            this.lblTenQuan = new System.Windows.Forms.Label();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.flpBan = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.flpFilterContent = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFilterItem1 = new System.Windows.Forms.Panel();
            this.lblLocKhuVuc = new System.Windows.Forms.Label();
            this.cboLocKhuVuc = new System.Windows.Forms.ComboBox();
            this.pnlFilterItem2 = new System.Windows.Forms.Panel();
            this.lblLocLoaiBan = new System.Windows.Forms.Label();
            this.cboLocLoaiBan = new System.Windows.Forms.ComboBox();
            this.pnlFilterItem3 = new System.Windows.Forms.Panel();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInvoiceTitle = new System.Windows.Forms.Label();
            this.btnOrderMon = new System.Windows.Forms.Button();
            this.pnlServiceControls = new System.Windows.Forms.Panel();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.pnlChonDichVu = new System.Windows.Forms.Panel();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.pnlServiceButton = new System.Windows.Forms.Panel();
            this.tlpActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnBatDauTinhGio = new System.Windows.Forms.Button();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.btnTinhTienBan = new System.Windows.Forms.Button();
            this.btnHuyHoaDon = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlThongTinHoaDon = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTienBan = new System.Windows.Forms.Label();
            this.lblTienDichVu = new System.Windows.Forms.Label();
            this.lblThoiGianKetThuc = new System.Windows.Forms.Label();
            this.lblThoiGianBatDau = new System.Windows.Forms.Label();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.flpFilterContent.SuspendLayout();
            this.pnlFilterItem1.SuspendLayout();
            this.pnlFilterItem2.SuspendLayout();
            this.pnlFilterItem3.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.pnlServiceControls.SuspendLayout();
            this.pnlChonDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.pnlServiceButton.SuspendLayout();
            this.tlpActions.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlThongTinHoaDon.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.LightBlue;
            this.pnlHeader.Controls.Add(this.lblNgayHienTai);
            this.pnlHeader.Controls.Add(this.lblTenQuan);
            this.pnlHeader.Controls.Add(this.lblTenNhanVien);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblNgayHienTai
            // 
            this.lblNgayHienTai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNgayHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblNgayHienTai.ForeColor = System.Drawing.Color.Red;
            this.lblNgayHienTai.Location = new System.Drawing.Point(800, 15);
            this.lblNgayHienTai.Name = "lblNgayHienTai";
            this.lblNgayHienTai.Size = new System.Drawing.Size(380, 30);
            this.lblNgayHienTai.TabIndex = 2;
            this.lblNgayHienTai.Text = "Waiting...";
            this.lblNgayHienTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTenQuan
            // 
            this.lblTenQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTenQuan.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTenQuan.Location = new System.Drawing.Point(20, 15);
            this.lblTenQuan.Name = "lblTenQuan";
            this.lblTenQuan.Size = new System.Drawing.Size(400, 30);
            this.lblTenQuan.TabIndex = 0;
            this.lblTenQuan.Text = "Quản lí quán BILLIARD";
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNhanVien.Location = new System.Drawing.Point(420, 15);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(150, 30);
            this.lblTenNhanVien.TabIndex = 1;
            this.lblTenNhanVien.Text = "Nhân viên: ";
            this.lblTenNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 3;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMain.Controls.Add(this.pnlLeft, 0, 0);
            this.tableLayoutMain.Controls.Add(this.pnlCenter, 1, 0);
            this.tableLayoutMain.Controls.Add(this.pnlRight, 2, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 60);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 1;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1200, 640);
            this.tableLayoutMain.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.flpBan);
            this.pnlLeft.Controls.Add(this.pnlFilter);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(354, 634);
            this.pnlLeft.TabIndex = 0;
            // 
            // flpBan
            // 
            this.flpBan.AutoScroll = true;
            this.flpBan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBan.Location = new System.Drawing.Point(0, 120);
            this.flpBan.Name = "flpBan";
            this.flpBan.Padding = new System.Windows.Forms.Padding(10);
            this.flpBan.Size = new System.Drawing.Size(354, 514);
            this.flpBan.TabIndex = 1;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.flpFilterContent);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(354, 120);
            this.pnlFilter.TabIndex = 0;
            // 
            // flpFilterContent
            // 
            this.flpFilterContent.Controls.Add(this.pnlFilterItem1);
            this.flpFilterContent.Controls.Add(this.pnlFilterItem2);
            this.flpFilterContent.Controls.Add(this.pnlFilterItem3);
            this.flpFilterContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFilterContent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpFilterContent.Location = new System.Drawing.Point(0, 0);
            this.flpFilterContent.Name = "flpFilterContent";
            this.flpFilterContent.Padding = new System.Windows.Forms.Padding(5);
            this.flpFilterContent.Size = new System.Drawing.Size(354, 120);
            this.flpFilterContent.TabIndex = 0;
            this.flpFilterContent.WrapContents = false;
            // 
            // pnlFilterItem1
            // 
            this.pnlFilterItem1.Controls.Add(this.lblLocKhuVuc);
            this.pnlFilterItem1.Controls.Add(this.cboLocKhuVuc);
            this.pnlFilterItem1.Location = new System.Drawing.Point(8, 8);
            this.pnlFilterItem1.Name = "pnlFilterItem1";
            this.pnlFilterItem1.Size = new System.Drawing.Size(340, 30);
            this.pnlFilterItem1.TabIndex = 0;
            // 
            // lblLocKhuVuc
            // 
            this.lblLocKhuVuc.AutoSize = true;
            this.lblLocKhuVuc.Location = new System.Drawing.Point(3, 6);
            this.lblLocKhuVuc.Name = "lblLocKhuVuc";
            this.lblLocKhuVuc.Size = new System.Drawing.Size(56, 16);
            this.lblLocKhuVuc.TabIndex = 0;
            this.lblLocKhuVuc.Text = "Khu vực:";
            // 
            // cboLocKhuVuc
            // 
            this.cboLocKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocKhuVuc.FormattingEnabled = true;
            this.cboLocKhuVuc.Location = new System.Drawing.Point(80, 3);
            this.cboLocKhuVuc.Name = "cboLocKhuVuc";
            this.cboLocKhuVuc.Size = new System.Drawing.Size(200, 24);
            this.cboLocKhuVuc.TabIndex = 1;
            // 
            // pnlFilterItem2
            // 
            this.pnlFilterItem2.Controls.Add(this.lblLocLoaiBan);
            this.pnlFilterItem2.Controls.Add(this.cboLocLoaiBan);
            this.pnlFilterItem2.Location = new System.Drawing.Point(8, 44);
            this.pnlFilterItem2.Name = "pnlFilterItem2";
            this.pnlFilterItem2.Size = new System.Drawing.Size(340, 30);
            this.pnlFilterItem2.TabIndex = 1;
            // 
            // lblLocLoaiBan
            // 
            this.lblLocLoaiBan.AutoSize = true;
            this.lblLocLoaiBan.Location = new System.Drawing.Point(3, 6);
            this.lblLocLoaiBan.Name = "lblLocLoaiBan";
            this.lblLocLoaiBan.Size = new System.Drawing.Size(62, 16);
            this.lblLocLoaiBan.TabIndex = 0;
            this.lblLocLoaiBan.Text = "Loại bàn:";
            // 
            // cboLocLoaiBan
            // 
            this.cboLocLoaiBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiBan.FormattingEnabled = true;
            this.cboLocLoaiBan.Location = new System.Drawing.Point(80, 3);
            this.cboLocLoaiBan.Name = "cboLocLoaiBan";
            this.cboLocLoaiBan.Size = new System.Drawing.Size(200, 24);
            this.cboLocLoaiBan.TabIndex = 1;
            // 
            // pnlFilterItem3
            // 
            this.pnlFilterItem3.Controls.Add(this.lblLocTrangThai);
            this.pnlFilterItem3.Controls.Add(this.cboLocTrangThai);
            this.pnlFilterItem3.Location = new System.Drawing.Point(8, 80);
            this.pnlFilterItem3.Name = "pnlFilterItem3";
            this.pnlFilterItem3.Size = new System.Drawing.Size(340, 30);
            this.pnlFilterItem3.TabIndex = 2;
            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Location = new System.Drawing.Point(3, 6);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Size = new System.Drawing.Size(70, 16);
            this.lblLocTrangThai.TabIndex = 0;
            this.lblLocTrangThai.Text = "Trạng thái:";
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Location = new System.Drawing.Point(80, 3);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(200, 24);
            this.cboLocTrangThai.TabIndex = 1;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.dgvHoaDon);
            this.pnlCenter.Controls.Add(this.lblInvoiceTitle);
            this.pnlCenter.Controls.Add(this.btnOrderMon);
            this.pnlCenter.Controls.Add(this.pnlServiceControls);
            this.pnlCenter.Controls.Add(this.pnlChonDichVu);
            this.pnlCenter.Controls.Add(this.pnlServiceButton);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(363, 3);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(594, 634);
            this.pnlCenter.TabIndex = 1;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colPrice,
            this.colQuantity,
            this.colTotal});
            this.dgvHoaDon.Location = new System.Drawing.Point(10, 100);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(574, 350);
            this.dgvHoaDon.TabIndex = 2;
            // 
            // colName
            // 
            this.colName.HeaderText = "Tên";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Đơn giá";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Số lượng";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Tổng tiền";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            // 
            // lblInvoiceTitle
            // 
            this.lblInvoiceTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceTitle.Location = new System.Drawing.Point(9, 59);
            this.lblInvoiceTitle.Name = "lblInvoiceTitle";
            this.lblInvoiceTitle.Size = new System.Drawing.Size(200, 25);
            this.lblInvoiceTitle.TabIndex = 1;
            this.lblInvoiceTitle.Text = "Hóa đơn bàn --";
            // 
            // btnOrderMon
            // 
            this.btnOrderMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrderMon.BackColor = System.Drawing.Color.LightGray;
            this.btnOrderMon.Location = new System.Drawing.Point(450, 58);
            this.btnOrderMon.Name = "btnOrderMon";
            this.btnOrderMon.Size = new System.Drawing.Size(134, 37);
            this.btnOrderMon.TabIndex = 0;
            this.btnOrderMon.Text = "Order món";
            this.btnOrderMon.UseVisualStyleBackColor = false;
            this.btnOrderMon.Click += new System.EventHandler(this.btnOrderMon_Click);
            // 
            // pnlServiceControls
            // 
            this.pnlServiceControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlServiceControls.Controls.Add(this.btnSua);
            this.pnlServiceControls.Controls.Add(this.btnXoa);
            this.pnlServiceControls.Location = new System.Drawing.Point(400, 460);
            this.pnlServiceControls.Name = "pnlServiceControls";
            this.pnlServiceControls.Size = new System.Drawing.Size(184, 40);
            this.pnlServiceControls.TabIndex = 5;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.LightGray;
            this.btnSua.Location = new System.Drawing.Point(0, 0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 40);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa SL";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(94, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 40);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa món";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // pnlChonDichVu
            // 
            this.pnlChonDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChonDichVu.Controls.Add(this.lblQuantity);
            this.pnlChonDichVu.Controls.Add(this.nudQuantity);
            this.pnlChonDichVu.Location = new System.Drawing.Point(10, 510);
            this.pnlChonDichVu.Name = "pnlChonDichVu";
            this.pnlChonDichVu.Size = new System.Drawing.Size(574, 50);
            this.pnlChonDichVu.TabIndex = 3;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(0, 15);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(150, 25);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Số lượng mới:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(160, 15);
            this.nudQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(100, 22);
            this.nudQuantity.TabIndex = 1;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlServiceButton
            // 
            this.pnlServiceButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlServiceButton.Controls.Add(this.tlpActions);
            this.pnlServiceButton.Location = new System.Drawing.Point(10, 570);
            this.pnlServiceButton.Name = "pnlServiceButton";
            this.pnlServiceButton.Size = new System.Drawing.Size(574, 50);
            this.pnlServiceButton.TabIndex = 4;
            // 
            // tlpActions
            // 
            this.tlpActions.ColumnCount = 4;
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActions.Controls.Add(this.btnBatDauTinhGio, 0, 0);
            this.tlpActions.Controls.Add(this.btnChuyenBan, 1, 0);
            this.tlpActions.Controls.Add(this.btnTinhTienBan, 2, 0);
            this.tlpActions.Controls.Add(this.btnHuyHoaDon, 3, 0);
            this.tlpActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpActions.Location = new System.Drawing.Point(0, 0);
            this.tlpActions.Name = "tlpActions";
            this.tlpActions.RowCount = 1;
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpActions.Size = new System.Drawing.Size(574, 50);
            this.tlpActions.TabIndex = 0;
            // 
            // btnBatDauTinhGio
            // 
            this.btnBatDauTinhGio.BackColor = System.Drawing.Color.LightGray;
            this.btnBatDauTinhGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBatDauTinhGio.Location = new System.Drawing.Point(2, 2);
            this.btnBatDauTinhGio.Margin = new System.Windows.Forms.Padding(2);
            this.btnBatDauTinhGio.Name = "btnBatDauTinhGio";
            this.btnBatDauTinhGio.Size = new System.Drawing.Size(139, 46);
            this.btnBatDauTinhGio.TabIndex = 0;
            this.btnBatDauTinhGio.Text = "Bắt đầu tính giờ";
            this.btnBatDauTinhGio.UseVisualStyleBackColor = false;
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.BackColor = System.Drawing.Color.LightGray;
            this.btnChuyenBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChuyenBan.Location = new System.Drawing.Point(145, 2);
            this.btnChuyenBan.Margin = new System.Windows.Forms.Padding(2);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(139, 46);
            this.btnChuyenBan.TabIndex = 1;
            this.btnChuyenBan.Text = "Chuyển bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = false;
            // 
            // btnTinhTienBan
            // 
            this.btnTinhTienBan.BackColor = System.Drawing.Color.LightGray;
            this.btnTinhTienBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTinhTienBan.Location = new System.Drawing.Point(288, 2);
            this.btnTinhTienBan.Margin = new System.Windows.Forms.Padding(2);
            this.btnTinhTienBan.Name = "btnTinhTienBan";
            this.btnTinhTienBan.Size = new System.Drawing.Size(139, 46);
            this.btnTinhTienBan.TabIndex = 2;
            this.btnTinhTienBan.Text = "Tính tiền bàn";
            this.btnTinhTienBan.UseVisualStyleBackColor = false;
            // 
            // btnHuyHoaDon
            // 
            this.btnHuyHoaDon.BackColor = System.Drawing.Color.IndianRed;
            this.btnHuyHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHuyHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHuyHoaDon.Location = new System.Drawing.Point(431, 2);
            this.btnHuyHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuyHoaDon.Name = "btnHuyHoaDon";
            this.btnHuyHoaDon.Size = new System.Drawing.Size(141, 46);
            this.btnHuyHoaDon.TabIndex = 3;
            this.btnHuyHoaDon.Text = "Hủy hóa đơn";
            this.btnHuyHoaDon.UseVisualStyleBackColor = false;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlThongTinHoaDon);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(963, 3);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(234, 634);
            this.pnlRight.TabIndex = 2;
            // 
            // pnlThongTinHoaDon
            // 
            this.pnlThongTinHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlThongTinHoaDon.Controls.Add(this.lblTongTien);
            this.pnlThongTinHoaDon.Controls.Add(this.lblTienBan);
            this.pnlThongTinHoaDon.Controls.Add(this.lblTienDichVu);
            this.pnlThongTinHoaDon.Controls.Add(this.lblThoiGianKetThuc);
            this.pnlThongTinHoaDon.Controls.Add(this.lblThoiGianBatDau);
            this.pnlThongTinHoaDon.Controls.Add(this.lblMaHoaDon);
            this.pnlThongTinHoaDon.Controls.Add(this.btnThanhToan);
            this.pnlThongTinHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThongTinHoaDon.Location = new System.Drawing.Point(0, 0);
            this.pnlThongTinHoaDon.Name = "pnlThongTinHoaDon";
            this.pnlThongTinHoaDon.Padding = new System.Windows.Forms.Padding(10);
            this.pnlThongTinHoaDon.Size = new System.Drawing.Size(234, 634);
            this.pnlThongTinHoaDon.TabIndex = 0;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.AutoSize = false;
            this.lblTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTongTien.Location = new System.Drawing.Point(5, 475);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Padding = new System.Windows.Forms.Padding(5);
            this.lblTongTien.Size = new System.Drawing.Size(224, 57);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "💰 TỔNG: 0đ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTienBan
            // 
            this.lblTienBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTienBan.BackColor = System.Drawing.Color.White;
            this.lblTienBan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTienBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblTienBan.Location = new System.Drawing.Point(10, 425);
            this.lblTienBan.Name = "lblTienBan";
            this.lblTienBan.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.lblTienBan.Size = new System.Drawing.Size(214, 40);
            this.lblTienBan.TabIndex = 1;
            this.lblTienBan.Text = "🎱 Tiền bàn: 0đ";
            this.lblTienBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTienDichVu
            // 
            this.lblTienDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTienDichVu.BackColor = System.Drawing.Color.White;
            this.lblTienDichVu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTienDichVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblTienDichVu.Location = new System.Drawing.Point(10, 380);
            this.lblTienDichVu.Name = "lblTienDichVu";
            this.lblTienDichVu.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.lblTienDichVu.Size = new System.Drawing.Size(214, 40);
            this.lblTienDichVu.TabIndex = 2;
            this.lblTienDichVu.Text = "🍽️ Dịch vụ: 0đ";
            this.lblTienDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThoiGianKetThuc
            // 
            this.lblThoiGianKetThuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.lblThoiGianKetThuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThoiGianKetThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.lblThoiGianKetThuc.Location = new System.Drawing.Point(10, 208);
            this.lblThoiGianKetThuc.Name = "lblThoiGianKetThuc";
            this.lblThoiGianKetThuc.Padding = new System.Windows.Forms.Padding(8);
            this.lblThoiGianKetThuc.Size = new System.Drawing.Size(214, 126);
            this.lblThoiGianKetThuc.TabIndex = 3;
            this.lblThoiGianKetThuc.Text = "🔴 KẾT THÚC\r\n\r\nNgày: --/--/----\r\nGiờ: --:--:--";
            // 
            // lblThoiGianBatDau
            // 
            this.lblThoiGianBatDau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblThoiGianBatDau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThoiGianBatDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblThoiGianBatDau.Location = new System.Drawing.Point(10, 60);
            this.lblThoiGianBatDau.Name = "lblThoiGianBatDau";
            this.lblThoiGianBatDau.Padding = new System.Windows.Forms.Padding(8);
            this.lblThoiGianBatDau.Size = new System.Drawing.Size(214, 121);
            this.lblThoiGianBatDau.TabIndex = 4;
            this.lblThoiGianBatDau.Text = "🟢 BẮT ĐẦU\r\n\r\nNgày: --/--/----\r\nGiờ: --:--:--";
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.lblMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaHoaDon.ForeColor = System.Drawing.Color.White;
            this.lblMaHoaDon.Location = new System.Drawing.Point(10, 10);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(214, 40);
            this.lblMaHoaDon.TabIndex = 5;
            this.lblMaHoaDon.Text = "📄 Mã hóa đơn: --";
            this.lblMaHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(10, 548);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(214, 76);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "✅ THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tableLayoutMain);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán Billiards";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.tableLayoutMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.flpFilterContent.ResumeLayout(false);
            this.pnlFilterItem1.ResumeLayout(false);
            this.pnlFilterItem1.PerformLayout();
            this.pnlFilterItem2.ResumeLayout(false);
            this.pnlFilterItem2.PerformLayout();
            this.pnlFilterItem3.ResumeLayout(false);
            this.pnlFilterItem3.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.pnlServiceControls.ResumeLayout(false);
            this.pnlChonDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.pnlServiceButton.ResumeLayout(false);
            this.tlpActions.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlThongTinHoaDon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNgayHienTai;
        private System.Windows.Forms.Label lblTenQuan;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;

        // --- Phần Trái ---
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.FlowLayoutPanel flpFilterContent;
        // Filter Items
        private System.Windows.Forms.Panel pnlFilterItem1;
        private System.Windows.Forms.ComboBox cboLocKhuVuc;
        private System.Windows.Forms.Label lblLocKhuVuc;
        private System.Windows.Forms.Panel pnlFilterItem2;
        private System.Windows.Forms.ComboBox cboLocLoaiBan;
        private System.Windows.Forms.Label lblLocLoaiBan;
        private System.Windows.Forms.Panel pnlFilterItem3;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Label lblLocTrangThai;

        // --- Phần Giữa ---
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label lblInvoiceTitle;
        private System.Windows.Forms.Button btnOrderMon;
        private System.Windows.Forms.Panel pnlServiceControls;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel pnlChonDichVu;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Panel pnlServiceButton;
        private System.Windows.Forms.TableLayoutPanel tlpActions;
        private System.Windows.Forms.Button btnBatDauTinhGio;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Button btnTinhTienBan;
        private System.Windows.Forms.Button btnHuyHoaDon;

        // --- Phần Phải ---
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlThongTinHoaDon;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTienBan;
        private System.Windows.Forms.Label lblTienDichVu;
        private System.Windows.Forms.Label lblThoiGianKetThuc;
        private System.Windows.Forms.Label lblThoiGianBatDau;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.Button btnThanhToan;
    }
}