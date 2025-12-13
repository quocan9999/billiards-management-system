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
using QuanLyQuanBilliards.Helpers;

namespace QuanLyQuanBilliards
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            // Thiết lập mật khẩu ẩn
            txtMatKhau.PasswordChar = '*';
            // Đăng ký sự kiện FormClosing
            this.FormClosing += fLogin_FormClosing;
        }

        #region Events
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Hiển thị xác nhận thoát
            DialogResult result = MessageBox.Show(
                "Bạn có muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Chỉ xử lý khi người dùng bấm nút X
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có muốn thoát chương trình không?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Hủy đóng form
                }
                // Nếu Yes thì cho phép đóng form và thoát ứng dụng
            }
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
                // Sử dụng quyền Admin để xác thực đăng nhập (vì cần truy cập bảng NguoiDung)
                using (var context = DatabaseHelper.CreateAdminDbContext())
                {
                    // Tìm người dùng trong cơ sở dữ liệu
                    var nguoiDung = context.NguoiDungs.FirstOrDefault(nd =>
                        nd.TenDangNhap == tenDangNhap &&
                        nd.MatKhau == matKhau &&
                        nd.TrangThai == "Hoạt động");

                    if (nguoiDung != null)
                    {
                        // Lấy thông tin nhân viên
                        var nhanVien = context.NhanViens.FirstOrDefault(nv => nv.NguoiDungID == nguoiDung.NguoiDungID);
                        string hoTen = nhanVien?.HoTen ?? nguoiDung.TenDangNhap;

                        // Lưu thông tin đăng nhập vào SessionManager
                        SessionManager.DangNhap(
                            nguoiDung.NguoiDungID,
                            nguoiDung.TenDangNhap,
                            nguoiDung.VaiTro,
                            hoTen
                        );

                        // Đăng nhập thành công
                        MessageBox.Show(
                            $"Đăng nhập thành công!\n" +
                            $"Chào mừng {hoTen}\n" +
                            $"Vai trò: {nguoiDung.VaiTro}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Ẩn form đăng nhập
                        this.Hide();

                        // Mở form fOption với thông tin vai trò
                        fOption formOption = new fOption(nguoiDung.VaiTro);
                        formOption.FormClosed += (s, args) =>
                        {
                            // Khi fOption đóng, đăng xuất và hiển thị lại form đăng nhập
                            SessionManager.DangXuat();
                            this.Show();
                            // Xóa mật khẩu đã nhập
                            txtMatKhau.Clear();
                            txtTenDangNhap.Focus();
                        };
                        formOption.Show();
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
                // Hiển thị lỗi chi tiết để debug
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu:\n{errorMessage}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
