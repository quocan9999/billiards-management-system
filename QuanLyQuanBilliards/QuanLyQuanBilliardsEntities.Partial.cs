using System.Data.Entity;

namespace QuanLyQuanBilliards
{
    /// <summary>
    /// Partial class mở rộng QuanLyQuanBilliardsEntities
    /// Thêm constructor hỗ trợ connection string động theo vai trò người dùng
    /// </summary>
    public partial class QuanLyQuanBilliardsEntities
    {
        /// <summary>
        /// Constructor với connection string tùy chỉnh
        /// Sử dụng khi cần kết nối với quyền phân biệt theo vai trò (Admin/Nhân viên)
        /// </summary>
        /// <param name="connectionString">Connection string của Entity Framework</param>
        public QuanLyQuanBilliardsEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
}
