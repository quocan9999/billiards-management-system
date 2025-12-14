//namespace QuanLyQuanBilliards.Forms
//{
//    partial class fThanhToan
//    {
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null)) components.Dispose();
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer

//        private void InitializeComponent()
//        {
//            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
//            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
//            this.gbChiTiet = new System.Windows.Forms.GroupBox();
//            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
//            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.pnlInfo = new System.Windows.Forms.Panel();
//            this.gbThongTin = new System.Windows.Forms.GroupBox();
//            this.lblFinalTotal = new System.Windows.Forms.Label();
//            this.label8 = new System.Windows.Forms.Label();
//            this.panelLine = new System.Windows.Forms.Panel();
//            this.lblTienGiam = new System.Windows.Forms.Label();
//            this.label7 = new System.Windows.Forms.Label();
//            this.txtGiamGia = new System.Windows.Forms.TextBox();
//            this.cboLoaiGiamGia = new System.Windows.Forms.ComboBox();
//            this.label6 = new System.Windows.Forms.Label();
//            this.lblTienBan = new System.Windows.Forms.Label();
//            this.label5 = new System.Windows.Forms.Label();
//            this.lblTienDichVu = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.lblThoiGian = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.lblTenBan = new System.Windows.Forms.Label();
//            this.btnHuy = new System.Windows.Forms.Button();
//            this.btnXacNhan = new System.Windows.Forms.Button();
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.tlpMain.SuspendLayout();
//            this.gbChiTiet.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
//            this.pnlInfo.SuspendLayout();
//            this.gbThongTin.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // tlpMain
//            // 
//            this.tlpMain.ColumnCount = 2;
//            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
//            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
//            this.tlpMain.Controls.Add(this.gbChiTiet, 0, 1);
//            this.tlpMain.Controls.Add(this.pnlInfo, 1, 1);
//            this.tlpMain.Controls.Add(this.lblTitle, 0, 0);
//            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.tlpMain.Location = new System.Drawing.Point(0, 0);
//            this.tlpMain.Name = "tlpMain";
//            this.tlpMain.RowCount = 2;
//            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
//            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
//            this.tlpMain.Size = new System.Drawing.Size(982, 553);
//            this.tlpMain.TabIndex = 0;
//            // 
//            // gbChiTiet
//            // 
//            this.gbChiTiet.Controls.Add(this.dgvChiTiet);
//            this.gbChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.gbChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
//            this.gbChiTiet.Location = new System.Drawing.Point(10, 60);
//            this.gbChiTiet.Margin = new System.Windows.Forms.Padding(10);
//            this.gbChiTiet.Name = "gbChiTiet";
//            this.gbChiTiet.Size = new System.Drawing.Size(569, 483);
//            this.gbChiTiet.TabIndex = 0;
//            this.gbChiTiet.TabStop = false;
//            this.gbChiTiet.Text = "Chi tiết dịch vụ";
//            // 
//            // dgvChiTiet
//            // 
//            this.dgvChiTiet.AllowUserToAddRows = false;
//            this.dgvChiTiet.AllowUserToDeleteRows = false;
//            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
//            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
//            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
//            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
//            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
//            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
//            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
//            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
//            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
//            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.colTenSP,
//            this.colDonGia,
//            this.colSoLuong,
//            this.colThanhTien});
//            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.dgvChiTiet.Location = new System.Drawing.Point(3, 22);
//            this.dgvChiTiet.Name = "dgvChiTiet";
//            this.dgvChiTiet.ReadOnly = true;
//            this.dgvChiTiet.RowHeadersVisible = false;
//            this.dgvChiTiet.RowHeadersWidth = 51;
//            this.dgvChiTiet.RowTemplate.Height = 24;
//            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvChiTiet.Size = new System.Drawing.Size(563, 458);
//            this.dgvChiTiet.TabIndex = 0;
//            // 
//            // colTenSP
//            // 
//            this.colTenSP.FillWeight = 150F;
//            this.colTenSP.HeaderText = "Tên món";
//            this.colTenSP.MinimumWidth = 6;
//            this.colTenSP.Name = "colTenSP";
//            this.colTenSP.ReadOnly = true;
//            // 
//            // colDonGia
//            // 
//            this.colDonGia.HeaderText = "Đơn giá";
//            this.colDonGia.MinimumWidth = 6;
//            this.colDonGia.Name = "colDonGia";
//            this.colDonGia.ReadOnly = true;
//            // 
//            // colSoLuong
//            // 
//            this.colSoLuong.HeaderText = "SL";
//            this.colSoLuong.MinimumWidth = 6;
//            this.colSoLuong.Name = "colSoLuong";
//            this.colSoLuong.ReadOnly = true;
//            // 
//            // colThanhTien
//            // 
//            this.colThanhTien.HeaderText = "Thành tiền";
//            this.colThanhTien.MinimumWidth = 6;
//            this.colThanhTien.Name = "colThanhTien";
//            this.colThanhTien.ReadOnly = true;
//            // 
//            // pnlInfo
//            // 
//            this.pnlInfo.BackColor = System.Drawing.Color.WhiteSmoke;
//            this.pnlInfo.Controls.Add(this.gbThongTin);
//            this.pnlInfo.Controls.Add(this.btnHuy);
//            this.pnlInfo.Controls.Add(this.btnXacNhan);
//            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.pnlInfo.Location = new System.Drawing.Point(592, 53);
//            this.pnlInfo.Name = "pnlInfo";
//            this.pnlInfo.Padding = new System.Windows.Forms.Padding(10);
//            this.pnlInfo.Size = new System.Drawing.Size(387, 497);
//            this.pnlInfo.TabIndex = 1;
//            // 
//            // gbThongTin
//            // 
//            this.gbThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.gbThongTin.BackColor = System.Drawing.Color.White;
//            this.gbThongTin.Controls.Add(this.lblFinalTotal);
//            this.gbThongTin.Controls.Add(this.label8);
//            this.gbThongTin.Controls.Add(this.panelLine);
//            this.gbThongTin.Controls.Add(this.lblTienGiam);
//            this.gbThongTin.Controls.Add(this.label7);
//            this.gbThongTin.Controls.Add(this.txtGiamGia);
//            this.gbThongTin.Controls.Add(this.cboLoaiGiamGia);
//            this.gbThongTin.Controls.Add(this.label6);
//            this.gbThongTin.Controls.Add(this.lblTienBan);
//            this.gbThongTin.Controls.Add(this.label5);
//            this.gbThongTin.Controls.Add(this.lblTienDichVu);
//            this.gbThongTin.Controls.Add(this.label4);
//            this.gbThongTin.Controls.Add(this.lblThoiGian);
//            this.gbThongTin.Controls.Add(this.label3);
//            this.gbThongTin.Controls.Add(this.lblTenBan);
//            this.gbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
//            this.gbThongTin.Location = new System.Drawing.Point(10, 10);
//            this.gbThongTin.Name = "gbThongTin";
//            this.gbThongTin.Size = new System.Drawing.Size(367, 390);
//            this.gbThongTin.TabIndex = 2;
//            this.gbThongTin.TabStop = false;
//            this.gbThongTin.Text = "Thông tin thanh toán";
//            // 
//            // lblFinalTotal
//            // 
//            this.lblFinalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.lblFinalTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
//            this.lblFinalTotal.ForeColor = System.Drawing.Color.Red;
//            this.lblFinalTotal.Location = new System.Drawing.Point(130, 330);
//            this.lblFinalTotal.Name = "lblFinalTotal";
//            this.lblFinalTotal.Size = new System.Drawing.Size(231, 35);
//            this.lblFinalTotal.TabIndex = 14;
//            this.lblFinalTotal.Text = "0đ";
//            this.lblFinalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // label8
//            // 
//            this.label8.AutoSize = true;
//            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
//            this.label8.Location = new System.Drawing.Point(6, 335);
//            this.label8.Name = "label8";
//            this.label8.Size = new System.Drawing.Size(124, 29);
//            this.label8.TabIndex = 13;
//            this.label8.Text = "TỔNG TT";
//            // 
//            // panelLine
//            // 
//            this.panelLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.panelLine.BackColor = System.Drawing.Color.Black;
//            this.panelLine.Location = new System.Drawing.Point(10, 310);
//            this.panelLine.Name = "panelLine";
//            this.panelLine.Size = new System.Drawing.Size(347, 2);
//            this.panelLine.TabIndex = 12;
//            // 
//            // lblTienGiam
//            // 
//            this.lblTienGiam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.lblTienGiam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic);
//            this.lblTienGiam.ForeColor = System.Drawing.Color.Green;
//            this.lblTienGiam.Location = new System.Drawing.Point(167, 275);
//            this.lblTienGiam.Name = "lblTienGiam";
//            this.lblTienGiam.Size = new System.Drawing.Size(194, 25);
//            this.lblTienGiam.TabIndex = 11;
//            this.lblTienGiam.Text = "-0đ";
//            this.lblTienGiam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // label7
//            // 
//            this.label7.AutoSize = true;
//            this.label7.Location = new System.Drawing.Point(6, 275);
//            this.label7.Name = "label7";
//            this.label7.Size = new System.Drawing.Size(89, 24);
//            this.label7.TabIndex = 10;
//            this.label7.Text = "Đã giảm:";
//            // 
//            // txtGiamGia
//            // 
//            this.txtGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.txtGiamGia.Location = new System.Drawing.Point(217, 230);
//            this.txtGiamGia.Name = "txtGiamGia";
//            this.txtGiamGia.Size = new System.Drawing.Size(144, 28);
//            this.txtGiamGia.TabIndex = 9;
//            this.txtGiamGia.Text = "0";
//            this.txtGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
//            // 
//            // cboLoaiGiamGia
//            // 
//            this.cboLoaiGiamGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cboLoaiGiamGia.FormattingEnabled = true;
//            this.cboLoaiGiamGia.Items.AddRange(new object[] {
//            "Không giảm",
//            "Theo %",
//            "Theo tiền"});
//            this.cboLoaiGiamGia.Location = new System.Drawing.Point(100, 230);
//            this.cboLoaiGiamGia.Name = "cboLoaiGiamGia";
//            this.cboLoaiGiamGia.Size = new System.Drawing.Size(111, 30);
//            this.cboLoaiGiamGia.TabIndex = 8;
//            // 
//            // label6
//            // 
//            this.label6.AutoSize = true;
//            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
//            this.label6.Location = new System.Drawing.Point(6, 233);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(98, 24);
//            this.label6.TabIndex = 7;
//            this.label6.Text = "Giảm giá:";
//            // 
//            // lblTienBan
//            // 
//            this.lblTienBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.lblTienBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
//            this.lblTienBan.Location = new System.Drawing.Point(151, 185);
//            this.lblTienBan.Name = "lblTienBan";
//            this.lblTienBan.Size = new System.Drawing.Size(210, 25);
//            this.lblTienBan.TabIndex = 6;
//            this.lblTienBan.Text = "0đ";
//            this.lblTienBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Location = new System.Drawing.Point(6, 185);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(91, 24);
//            this.label5.TabIndex = 5;
//            this.label5.Text = "Tiền bàn:";
//            // 
//            // lblTienDichVu
//            // 
//            this.lblTienDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.lblTienDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
//            this.lblTienDichVu.Location = new System.Drawing.Point(151, 145);
//            this.lblTienDichVu.Name = "lblTienDichVu";
//            this.lblTienDichVu.Size = new System.Drawing.Size(210, 25);
//            this.lblTienDichVu.TabIndex = 4;
//            this.lblTienDichVu.Text = "0đ";
//            this.lblTienDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Location = new System.Drawing.Point(6, 145);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(120, 24);
//            this.label4.TabIndex = 3;
//            this.label4.Text = "Tiền dịch vụ:";
//            // 
//            // lblThoiGian
//            // 
//            this.lblThoiGian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.lblThoiGian.Location = new System.Drawing.Point(110, 100);
//            this.lblThoiGian.Name = "lblThoiGian";
//            this.lblThoiGian.Size = new System.Drawing.Size(251, 25);
//            this.lblThoiGian.TabIndex = 2;
//            this.lblThoiGian.Text = "00:00:00 (0 phút)";
//            this.lblThoiGian.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(6, 100);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(96, 24);
//            this.label3.TabIndex = 1;
//            this.label3.Text = "Thời gian:";
//            // 
//            // lblTenBan
//            // 
//            this.lblTenBan.Dock = System.Windows.Forms.DockStyle.Top;
//            this.lblTenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
//            this.lblTenBan.ForeColor = System.Drawing.Color.DarkBlue;
//            this.lblTenBan.Location = new System.Drawing.Point(3, 24);
//            this.lblTenBan.Name = "lblTenBan";
//            this.lblTenBan.Size = new System.Drawing.Size(361, 53);
//            this.lblTenBan.TabIndex = 0;
//            this.lblTenBan.Text = "BÀN 01";
//            this.lblTenBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // btnHuy
//            // 
//            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
//            this.btnHuy.BackColor = System.Drawing.Color.IndianRed;
//            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
//            this.btnHuy.ForeColor = System.Drawing.Color.White;
//            this.btnHuy.Location = new System.Drawing.Point(10, 427);
//            this.btnHuy.Name = "btnHuy";
//            this.btnHuy.Size = new System.Drawing.Size(120, 60);
//            this.btnHuy.TabIndex = 1;
//            this.btnHuy.Text = "Hủy bỏ";
//            this.btnHuy.UseVisualStyleBackColor = false;
//            // 
//            // btnXacNhan
//            // 
//            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.btnXacNhan.BackColor = System.Drawing.Color.DodgerBlue;
//            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
//            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
//            this.btnXacNhan.Location = new System.Drawing.Point(140, 427);
//            this.btnXacNhan.Name = "btnXacNhan";
//            this.btnXacNhan.Size = new System.Drawing.Size(237, 60);
//            this.btnXacNhan.TabIndex = 0;
//            this.btnXacNhan.Text = "THANH TOÁN";
//            this.btnXacNhan.UseVisualStyleBackColor = false;
//            // 
//            // lblTitle
//            // 
//            this.tlpMain.SetColumnSpan(this.lblTitle, 2);
//            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
//            this.lblTitle.Location = new System.Drawing.Point(3, 0);
//            this.lblTitle.Name = "lblTitle";
//            this.lblTitle.Size = new System.Drawing.Size(976, 50);
//            this.lblTitle.TabIndex = 2;
//            this.lblTitle.Text = "XÁC NHẬN THANH TOÁN";
//            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // fThanhToan
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(982, 553);
//            this.Controls.Add(this.tlpMain);
//            this.MinimumSize = new System.Drawing.Size(900, 600);
//            this.Name = "fThanhToan";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "Thanh toán hóa đơn";
//            this.tlpMain.ResumeLayout(false);
//            this.gbChiTiet.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
//            this.pnlInfo.ResumeLayout(false);
//            this.gbThongTin.ResumeLayout(false);
//            this.gbThongTin.PerformLayout();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.TableLayoutPanel tlpMain;
//        private System.Windows.Forms.GroupBox gbChiTiet;
//        private System.Windows.Forms.DataGridView dgvChiTiet;
//        private System.Windows.Forms.Panel pnlInfo;
//        private System.Windows.Forms.Button btnXacNhan;
//        private System.Windows.Forms.Button btnHuy;
//        private System.Windows.Forms.GroupBox gbThongTin;
//        private System.Windows.Forms.Label lblTenBan;
//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Label lblThoiGian;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Label lblTienBan;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Label lblTienDichVu;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Panel panelLine;
//        private System.Windows.Forms.Label lblTienGiam;
//        private System.Windows.Forms.Label label7;
//        private System.Windows.Forms.TextBox txtGiamGia;
//        private System.Windows.Forms.ComboBox cboLoaiGiamGia;
//        private System.Windows.Forms.Label label6;
//        private System.Windows.Forms.Label lblFinalTotal;
//        private System.Windows.Forms.Label label8;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
//    }
//}


namespace QuanLyQuanBilliards.Forms
{
    partial class fThanhToan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbChiTiet = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.lblFinalTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelLine = new System.Windows.Forms.Panel();
            this.lblTienGiam = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.cboLoaiGiamGia = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTienBan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTienDichVu = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTenBan = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.gbChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.Controls.Add(this.gbChiTiet, 0, 1);
            this.tlpMain.Controls.Add(this.pnlInfo, 1, 1);
            this.tlpMain.Controls.Add(this.lblTitle, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1280, 695);
            this.tlpMain.TabIndex = 0;
            // 
            // gbChiTiet
            // 
            this.gbChiTiet.Controls.Add(this.dgvChiTiet);
            this.gbChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbChiTiet.Location = new System.Drawing.Point(10, 70);
            this.gbChiTiet.Margin = new System.Windows.Forms.Padding(10);
            this.gbChiTiet.Name = "gbChiTiet";
            this.gbChiTiet.Size = new System.Drawing.Size(748, 615);
            this.gbChiTiet.TabIndex = 0;
            this.gbChiTiet.TabStop = false;
            this.gbChiTiet.Text = "Chi tiết dịch vụ";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenSP,
            this.colDonGia,
            this.colSoLuong,
            this.colThanhTien});
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(3, 22);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 30;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(742, 590);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // colTenSP
            // 
            this.colTenSP.FillWeight = 150F;
            this.colTenSP.HeaderText = "Tên món";
            this.colTenSP.MinimumWidth = 6;
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.ReadOnly = true;
            // 
            // colDonGia
            // 
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.MinimumWidth = 6;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.MinimumWidth = 6;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.MinimumWidth = 6;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInfo.Controls.Add(this.gbThongTin);
            this.pnlInfo.Controls.Add(this.btnHuy);
            this.pnlInfo.Controls.Add(this.btnXacNhan);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(771, 63);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(10);
            this.pnlInfo.Size = new System.Drawing.Size(506, 629);
            this.pnlInfo.TabIndex = 1;
            // 
            // gbThongTin
            // 
            this.gbThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbThongTin.BackColor = System.Drawing.Color.White;
            this.gbThongTin.Controls.Add(this.lblFinalTotal);
            this.gbThongTin.Controls.Add(this.label8);
            this.gbThongTin.Controls.Add(this.panelLine);
            this.gbThongTin.Controls.Add(this.lblTienGiam);
            this.gbThongTin.Controls.Add(this.label7);
            this.gbThongTin.Controls.Add(this.txtGiamGia);
            this.gbThongTin.Controls.Add(this.cboLoaiGiamGia);
            this.gbThongTin.Controls.Add(this.label6);
            this.gbThongTin.Controls.Add(this.lblTienBan);
            this.gbThongTin.Controls.Add(this.label5);
            this.gbThongTin.Controls.Add(this.lblTienDichVu);
            this.gbThongTin.Controls.Add(this.label4);
            this.gbThongTin.Controls.Add(this.lblThoiGian);
            this.gbThongTin.Controls.Add(this.label3);
            this.gbThongTin.Controls.Add(this.lblTenBan);
            this.gbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.gbThongTin.Location = new System.Drawing.Point(10, 10);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(486, 420);
            this.gbThongTin.TabIndex = 2;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin thanh toán";
            // 
            // lblFinalTotal
            // 
            this.lblFinalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFinalTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblFinalTotal.ForeColor = System.Drawing.Color.Red;
            this.lblFinalTotal.Location = new System.Drawing.Point(176, 350);
            this.lblFinalTotal.Name = "lblFinalTotal";
            this.lblFinalTotal.Size = new System.Drawing.Size(300, 40);
            this.lblFinalTotal.TabIndex = 14;
            this.lblFinalTotal.Text = "0đ";
            this.lblFinalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(15, 358);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 36);
            this.label8.TabIndex = 13;
            this.label8.Text = "TỔNG TIỀN";
            // 
            // panelLine
            // 
            this.panelLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLine.BackColor = System.Drawing.Color.Black;
            this.panelLine.Location = new System.Drawing.Point(15, 330);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(460, 2);
            this.panelLine.TabIndex = 12;
            // 
            // lblTienGiam
            // 
            this.lblTienGiam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTienGiam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic);
            this.lblTienGiam.ForeColor = System.Drawing.Color.Green;
            this.lblTienGiam.Location = new System.Drawing.Point(240, 285);
            this.lblTienGiam.Name = "lblTienGiam";
            this.lblTienGiam.Size = new System.Drawing.Size(236, 25);
            this.lblTienGiam.TabIndex = 11;
            this.lblTienGiam.Text = "-0đ";
            this.lblTienGiam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 24);
            this.label7.TabIndex = 10;
            this.label7.Text = "Đã giảm:";
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGiamGia.Location = new System.Drawing.Point(300, 230);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(176, 28);
            this.txtGiamGia.TabIndex = 9;
            this.txtGiamGia.Text = "0";
            this.txtGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboLoaiGiamGia
            // 
            this.cboLoaiGiamGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiGiamGia.FormattingEnabled = true;
            this.cboLoaiGiamGia.Items.AddRange(new object[] {
            "Không giảm",
            "Theo %",
            "Theo tiền"});
            this.cboLoaiGiamGia.Location = new System.Drawing.Point(150, 230);
            this.cboLoaiGiamGia.Name = "cboLoaiGiamGia";
            this.cboLoaiGiamGia.Size = new System.Drawing.Size(140, 30);
            this.cboLoaiGiamGia.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(15, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 24);
            this.label6.TabIndex = 7;
            this.label6.Text = "Giảm giá:";
            // 
            // lblTienBan
            // 
            this.lblTienBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTienBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTienBan.Location = new System.Drawing.Point(220, 185);
            this.lblTienBan.Name = "lblTienBan";
            this.lblTienBan.Size = new System.Drawing.Size(256, 25);
            this.lblTienBan.TabIndex = 6;
            this.lblTienBan.Text = "0đ";
            this.lblTienBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tiền bàn:";
            // 
            // lblTienDichVu
            // 
            this.lblTienDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTienDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTienDichVu.Location = new System.Drawing.Point(220, 145);
            this.lblTienDichVu.Name = "lblTienDichVu";
            this.lblTienDichVu.Size = new System.Drawing.Size(256, 25);
            this.lblTienDichVu.TabIndex = 4;
            this.lblTienDichVu.Text = "0đ";
            this.lblTienDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tiền dịch vụ:";
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThoiGian.Location = new System.Drawing.Point(180, 100);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(296, 25);
            this.lblThoiGian.TabIndex = 2;
            this.lblThoiGian.Text = "00:00:00 (0 phút)";
            this.lblThoiGian.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Thời gian:";
            // 
            // lblTenBan
            // 
            this.lblTenBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTenBan.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTenBan.Location = new System.Drawing.Point(3, 24);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(480, 53);
            this.lblTenBan.TabIndex = 0;
            this.lblTenBan.Text = "BÀN 01";
            this.lblTenBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHuy.BackColor = System.Drawing.Color.IndianRed;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(10, 549);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(140, 70);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Quay lại";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhan.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(160, 549);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(336, 70);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "XÁC NHẬN THANH TOÁN";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.tlpMain.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1274, 60);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "XÁC NHẬN THANH TOÁN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 695);
            this.Controls.Add(this.tlpMain);
            this.MinimumSize = new System.Drawing.Size(1280, 695);
            this.Name = "fThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán hóa đơn";
            this.tlpMain.ResumeLayout(false);
            this.gbChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblTenBan;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTienBan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTienDichVu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelLine;
        private System.Windows.Forms.Label lblTienGiam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.ComboBox cboLoaiGiamGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFinalTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
    }
}