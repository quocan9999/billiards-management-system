namespace QuanLyQuanBilliards.Forms
{
    partial class fOrder
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.gbOrderTemp = new System.Windows.Forms.GroupBox();
            this.dgvOrderTemp = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnXacNhanOrder = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.gbOrderTemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderTemp)).BeginInit();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.SuspendLayout();

            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.Controls.Add(this.tabMenu, 0, 0);
            this.tlpMain.Controls.Add(this.gbOrderTemp, 1, 0);
            this.tlpMain.Controls.Add(this.pnlControls, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMain.TabIndex = 0;

            // 
            // tabMenu
            // 
            this.tabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.tabMenu.Location = new System.Drawing.Point(3, 3);
            this.tabMenu.Name = "tabMenu";
            this.tlpMain.SetRowSpan(this.tabMenu, 2);
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(703, 647);
            this.tabMenu.TabIndex = 0;

            // 
            // gbOrderTemp
            // 
            this.gbOrderTemp.Controls.Add(this.dgvOrderTemp);
            this.gbOrderTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOrderTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbOrderTemp.Location = new System.Drawing.Point(712, 3);
            this.gbOrderTemp.Name = "gbOrderTemp";
            this.gbOrderTemp.Size = new System.Drawing.Size(467, 447);
            this.gbOrderTemp.TabIndex = 1;
            this.gbOrderTemp.TabStop = false;
            this.gbOrderTemp.Text = "Danh sách món đã chọn (Tạm tính)";

            // 
            // dgvOrderTemp
            // 
            this.dgvOrderTemp.AllowUserToAddRows = false;
            this.dgvOrderTemp.AllowUserToDeleteRows = false;
            this.dgvOrderTemp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderTemp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colTenSP,
            this.colDonGia,
            this.colSoLuong,
            this.colThanhTien});
            this.dgvOrderTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderTemp.Location = new System.Drawing.Point(3, 22);
            this.dgvOrderTemp.MultiSelect = false;
            this.dgvOrderTemp.Name = "dgvOrderTemp";
            this.dgvOrderTemp.ReadOnly = true;
            this.dgvOrderTemp.RowHeadersVisible = false;
            this.dgvOrderTemp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderTemp.Size = new System.Drawing.Size(461, 422);
            this.dgvOrderTemp.TabIndex = 0;

            // Columns Config
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;

            this.colTenSP.HeaderText = "Tên món";
            this.colTenSP.Name = "colTenSP";

            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";

            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.Name = "colSoLuong";

            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.Name = "colThanhTien";

            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlControls.Controls.Add(this.btnXacNhanOrder);
            this.pnlControls.Controls.Add(this.btnXoa);
            this.pnlControls.Controls.Add(this.btnSua);
            this.pnlControls.Controls.Add(this.nudSoLuong);
            this.pnlControls.Controls.Add(this.label4);
            this.pnlControls.Controls.Add(this.txtTrangThai);
            this.pnlControls.Controls.Add(this.label3);
            this.pnlControls.Controls.Add(this.txtDonGia);
            this.pnlControls.Controls.Add(this.label2);
            this.pnlControls.Controls.Add(this.txtTenSP);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(712, 456);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(467, 194);
            this.pnlControls.TabIndex = 2;

            // 
            // Label & TextBox (Readonly)
            // 
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(10, 15); this.label1.Text = "Tên món:";
            this.txtTenSP.Enabled = false; this.txtTenSP.Location = new System.Drawing.Point(90, 12); this.txtTenSP.Size = new System.Drawing.Size(200, 22);

            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(10, 45); this.label2.Text = "Đơn giá:";
            this.txtDonGia.Enabled = false; this.txtDonGia.Location = new System.Drawing.Point(90, 42); this.txtDonGia.Size = new System.Drawing.Size(200, 22);

            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(10, 75); this.label3.Text = "Trạng thái:";
            this.txtTrangThai.Enabled = false; this.txtTrangThai.Location = new System.Drawing.Point(90, 72); this.txtTrangThai.Size = new System.Drawing.Size(200, 22);

            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(10, 105); this.label4.Text = "Số lượng:";
            this.nudSoLuong.Location = new System.Drawing.Point(90, 102); this.nudSoLuong.Size = new System.Drawing.Size(80, 22); this.nudSoLuong.Minimum = 1; this.nudSoLuong.Maximum = 1000;

            // 
            // Buttons
            // 
            this.btnSua.BackColor = System.Drawing.Color.LightBlue;
            this.btnSua.Location = new System.Drawing.Point(190, 100);
            this.btnSua.Size = new System.Drawing.Size(100, 30);
            this.btnSua.Text = "Sửa SL";
            this.btnSua.UseVisualStyleBackColor = false;

            this.btnXoa.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(300, 100);
            this.btnXoa.Size = new System.Drawing.Size(100, 30);
            this.btnXoa.Text = "Xóa món";
            this.btnXoa.UseVisualStyleBackColor = false;

            this.btnXacNhanOrder.BackColor = System.Drawing.Color.Green;
            this.btnXacNhanOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnXacNhanOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnXacNhanOrder.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanOrder.Location = new System.Drawing.Point(0, 144);
            this.btnXacNhanOrder.Size = new System.Drawing.Size(467, 50);
            this.btnXacNhanOrder.Text = "XÁC NHẬN ORDER";
            this.btnXacNhanOrder.UseVisualStyleBackColor = false;

            // 
            // fOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.tlpMain);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "fOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order món ăn / đồ uống";
            this.tlpMain.ResumeLayout(false);
            this.gbOrderTemp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderTemp)).EndInit();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.GroupBox gbOrderTemp;
        private System.Windows.Forms.DataGridView dgvOrderTemp;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnXacNhanOrder;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
    }
}