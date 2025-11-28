using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanBilliards.Forms;

namespace QuanLyQuanBilliards
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            // Thiết lập mật khẩu ẩn
            txtMatKhau.PasswordChar = '*';
        }

        #region Events
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            // Kiểm tra thông tin đầu vào
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            try
            {
                using (var context = new QuanLyQuanBilliardsEntities())
                {
                    // Tìm người dùng trong cơ sở dữ liệu
                    var nguoiDung = context.NguoiDungs.FirstOrDefault(nd =>
                        nd.TenDangNhap == tenDangNhap &&
                        nd.MatKhau == matKhau &&
                        nd.TrangThai == "Hoạt động");

                    if (nguoiDung != null)
                    {
                        // Đăng nhập thành công
                        MessageBox.Show($"Đăng nhập thành công! Chào mừng {nguoiDung.TenDangNhap}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Ẩn form đăng nhập
                        this.Hide();

                        // Mở form fOption với thông tin vai trò
                        fOption formOption = new fOption(nguoiDung.VaiTro);
                        formOption.ShowDialog();

                        // Đóng ứng dụng khi form fOption đóng
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!",
                            "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenDangNhap.Focus();
                        txtTenDangNhap.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
