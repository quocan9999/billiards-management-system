using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanBilliards.Helpers;

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
            HienThiThongTinNguoiDung();
        }

        /// <summary>
        /// Hiển thị thông tin người dùng đang đăng nhập
        /// </summary>
        private void HienThiThongTinNguoiDung()
        {
            if (SessionManager.DaDangNhap)
            {
                this.Text = $"Chọn chức năng - {SessionManager.HoTen} ({SessionManager.VaiTro})";
            }
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
                // Nhân viên chỉ có thể sử dụng chức năng quản lý billiards (bán hàng)
                // Nhân viên KHÔNG được truy cập:
                // - Schema phanquyen (quản lý tài khoản)
                // - Schema baocao (xem báo cáo)
                // - Thay đổi dữ liệu schema danhmuc (giá bàn, sản phẩm...)
                btnQuanLyBilliards.Enabled = true;
                btnQuanTriHeThong.Enabled = true;

                // Thay đổi màu sắc để hiển thị button bị vô hiệu hóa
                //btnQuanTriHeThong.ForeColor = Color.Gray;
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
            // Kiểm tra quyền bằng SessionManager
            if (!SessionManager.LaAdmin)
            {
                MessageBox.Show(
                    "Bạn không có quyền sử dụng chức năng này!\n\n" +
                    "Chức năng Quản trị hệ thống chỉ dành cho Admin.\n", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở form Admin
            this.Hide();
            fAdmin formAdmin = new fAdmin();
            formAdmin.ShowDialog();
            this.Show();
        }

        private void BtnQuanLyBilliards_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền - cả Admin và Nhân viên đều được sử dụng
            if (SessionManager.LaAdmin || SessionManager.LaNhanVien)
            {
                // Mở form quản lý billiards (fMain)
                // Nhân viên sẽ được cấp quyền dbrole_NhanVien trong SQL Server
                // Chỉ được thao tác trên schema banhang
                this.Hide();
                fMain formMain = new fMain();
                formMain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này!",
                    "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Chỉ xử lý khi người dùng bấm nút X
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có muốn đăng xuất và quay lại màn hình đăng nhập không?",
                    "Xác nhận đăng xuất",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Không đóng form
                }
                // Nếu Yes thì cho phép đóng form (SessionManager.DangXuat() sẽ được gọi ở fLogin)
            }
        }
    }
}
