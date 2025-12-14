using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace QuanLyQuanBilliards.Helpers
{
    /// <summary>
    /// Lớp hỗ trợ tạo connection string động dựa trên vai trò người dùng
    /// Sử dụng các SQL Login đã được phân quyền:
    /// - App_Billiards_Admin: Toàn quyền (dbrole_QuanTri)
    /// - App_Billiards_Staff: Chỉ được thao tác bán hàng (dbrole_NhanVien)
    /// </summary>
    public static class DatabaseHelper
    {
        private const string SERVER_NAME = ".";
        private const string DATABASE_NAME = "QuanLyQuanBilliards";

        // Thông tin đăng nhập SQL Server theo vai trò
        private const string ADMIN_LOGIN = "App_Billiards_Admin";
        private const string ADMIN_PASSWORD = "Admin@123";
        private const string STAFF_LOGIN = "App_Billiards_Staff";
        private const string STAFF_PASSWORD = "Staff@123";

        /// <summary>
        /// Tạo connection string cho Entity Framework dựa trên vai trò người dùng
        /// </summary>
        /// <param name="vaiTro">Vai trò người dùng (Admin / Nhân viên)</param>
        /// <returns>Connection string cho Entity Framework</returns>
        public static string GetConnectionString(string vaiTro)
        {
            string login, password;

            // Chọn thông tin đăng nhập SQL dựa trên vai trò
            if (vaiTro == "Admin")
            {
                login = ADMIN_LOGIN;
                password = ADMIN_PASSWORD;
            }
            else
            {
                // Mặc định sử dụng quyền nhân viên (quyền thấp nhất)
                login = STAFF_LOGIN;
                password = STAFF_PASSWORD;
            }

            // Tạo SQL connection string với SQL Authentication
            var sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = SERVER_NAME,
                InitialCatalog = DATABASE_NAME,
                UserID = login,
                Password = password,
                IntegratedSecurity = false,
                Encrypt = false,
                TrustServerCertificate = true,
                MultipleActiveResultSets = true,
                ApplicationName = "EntityFramework"
            };

            // Tạo Entity Framework connection string
            var entityBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sqlBuilder.ConnectionString,
                Metadata = "res://*/QuanLyQuanBilliards.csdl|res://*/QuanLyQuanBilliards.ssdl|res://*/QuanLyQuanBilliards.msl"
            };

            return entityBuilder.ConnectionString;
        }

        /// <summary>
        /// Tạo connection string cho vai trò hiện tại (từ SessionManager)
        /// </summary>
        /// <returns>Connection string cho Entity Framework</returns>
        public static string GetCurrentConnectionString()
        {
            return GetConnectionString(SessionManager.VaiTro);
        }

        /// <summary>
        /// Tạo DbContext mới với quyền theo vai trò hiện tại
        /// </summary>
        /// <returns>DbContext với quyền phù hợp</returns>
        public static QuanLyQuanBilliardsEntities CreateDbContext()
        {
            if (!SessionManager.DaDangNhap)
            {
                // Nếu chưa đăng nhập, sử dụng connection mặc định (Windows Auth)
                return new QuanLyQuanBilliardsEntities();
            }

            // Tạo DbContext với connection string theo vai trò
            return new QuanLyQuanBilliardsEntities(GetCurrentConnectionString());
        }

        /// <summary>
        /// Tạo DbContext mới với quyền Admin (dùng cho việc xác thực đăng nhập)
        /// </summary>
        /// <returns>DbContext với quyền Admin</returns>
        public static QuanLyQuanBilliardsEntities CreateAdminDbContext()
        {
            return new QuanLyQuanBilliardsEntities(GetConnectionString("Admin"));
        }
    }
}
