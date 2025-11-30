using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBilliards.Forms
{
    public partial class fOption : Form
    {
        private string vaiTro;

        public fOption()
        {
            InitializeComponent();
        }

        public fOption(string vaiTroNguoiDung)
        {
            InitializeComponent();
            this.vaiTro = vaiTroNguoiDung;
            KiemTraQuyen();
        }

        private void KiemTraQuyen()
        {
            // Thiết lập quyền truy cập dựa trên vai trò
            if (vaiTro == "Admin")
            {
                // Admin có thể sử dụng tất cả chức năng
                btnQuanLyBilliards.Enabled = true;
                btnQuanTriHeThong.Enabled = true;
            }
            else if (vaiTro == "Nhân viên")
            {
                // Nhân viên chỉ có thể sử dụng chức năng quản lý billiards
                btnQuanLyBilliards.Enabled = true;
                btnQuanTriHeThong.Enabled = false;

                // Thay đổi màu sắc để hiển thị button bị vô hiệu hóa
                btnQuanTriHeThong.ForeColor = Color.Gray;
            }
            else
            {
                // Các vai trò khác không có quyền gì
                btnQuanLyBilliards.Enabled = false;
                btnQuanTriHeThong.Enabled = false;
                btnQuanLyBilliards.ForeColor = Color.Gray;
                btnQuanTriHeThong.ForeColor = Color.Gray;
            }
        }

        private void BtnQuanTriHeThong_Click(object sender, EventArgs e)
        {
            if (vaiTro != "Admin")
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này!",
             "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (vaiTro == "Admin")
            {
                this.Hide();
                fAdmin formAdmin = new fAdmin();
                formAdmin.ShowDialog();
                this.Show();
            }
        }

        private void BtnQuanLyBilliards_Click(object sender, EventArgs e)
        {
            if (vaiTro == "Admin" || vaiTro == "Nhân viên")
            {
                // TODO: Mở form quản lý billiards (fMain)
                this.Hide();
                fMain formMain = new fMain();
                formMain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này!",
       "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Chỉ xử lý khi người dùng bấm nút X (UserClosing)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có muốn đăng xuất và quay lại màn hình đăng nhập không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    fLogin login = new fLogin();
                    login.Show();

                    this.Hide();

                    e.Cancel = true;
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
