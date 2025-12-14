using System;

namespace QuanLyQuanBilliards.Helpers
{
    /// <summary>
    /// Lớp quản lý phiên đăng nhập của người dùng
    /// Lưu trữ thông tin người dùng hiện tại để sử dụng trong toàn ứng dụng
    /// </summary>
    public static class SessionManager
    {
        // Thông tin người dùng hiện tại
        public static int NguoiDungID { get; private set; }
        public static string TenDangNhap { get; private set; }
        public static string VaiTro { get; private set; }
        public static string HoTen { get; private set; }

        // Kiểm tra đã đăng nhập chưa
        public static bool DaDangNhap => NguoiDungID > 0;

        // Kiểm tra có phải Admin không
        public static bool LaAdmin => VaiTro == "Admin";

        // Kiểm tra có phải Nhân viên không
        public static bool LaNhanVien => VaiTro == "Nhân viên";

        /// <summary>
        /// Thiết lập thông tin đăng nhập khi người dùng đăng nhập thành công
        /// </summary>
        /// <param name="nguoiDungID">ID người dùng</param>
        /// <param name="tenDangNhap">Tên đăng nhập</param>
        /// <param name="vaiTro">Vai trò (Admin / Nhân viên)</param>
        /// <param name="hoTen">Họ tên nhân viên</param>
        public static void DangNhap(int nguoiDungID, string tenDangNhap, string vaiTro, string hoTen)
        {
            NguoiDungID = nguoiDungID;
            TenDangNhap = tenDangNhap;
            VaiTro = vaiTro;
            HoTen = hoTen;
        }

        /// <summary>
        /// Xóa thông tin đăng nhập khi người dùng đăng xuất
        /// </summary>
        public static void DangXuat()
        {
            NguoiDungID = 0;
            TenDangNhap = null;
            VaiTro = null;
            HoTen = null;
        }
    }
}
