namespace QuanLyQuanBilliards.Forms
{
    partial class fOption
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
            this.btnQuanTriHeThong = new System.Windows.Forms.Button();
            this.btnQuanLyBilliards = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQuanTriHeThong
            // 
            this.btnQuanTriHeThong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanTriHeThong.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnQuanTriHeThong.Location = new System.Drawing.Point(92, 34);
            this.btnQuanTriHeThong.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuanTriHeThong.Name = "btnQuanTriHeThong";
            this.btnQuanTriHeThong.Size = new System.Drawing.Size(248, 51);
            this.btnQuanTriHeThong.TabIndex = 0;
            this.btnQuanTriHeThong.Text = "Quản trị hệ thống";
            this.btnQuanTriHeThong.UseVisualStyleBackColor = true;
            this.btnQuanTriHeThong.Click += new System.EventHandler(this.BtnQuanTriHeThong_Click);
            // 
            // btnQuanLyBilliards
            // 
            this.btnQuanLyBilliards.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyBilliards.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnQuanLyBilliards.Location = new System.Drawing.Point(92, 109);
            this.btnQuanLyBilliards.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuanLyBilliards.Name = "btnQuanLyBilliards";
            this.btnQuanLyBilliards.Size = new System.Drawing.Size(248, 80);
            this.btnQuanLyBilliards.TabIndex = 1;
            this.btnQuanLyBilliards.Text = "Quản lý quán billiards";
            this.btnQuanLyBilliards.UseVisualStyleBackColor = true;
            this.btnQuanLyBilliards.Click += new System.EventHandler(this.BtnQuanLyBilliards_Click);
            // 
            // fOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 219);
            this.Controls.Add(this.btnQuanLyBilliards);
            this.Controls.Add(this.btnQuanTriHeThong);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(469, 258);
            this.MinimumSize = new System.Drawing.Size(469, 258);
            this.Name = "fOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fOption";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fOption_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuanTriHeThong;
        private System.Windows.Forms.Button btnQuanLyBilliards;
    }
}