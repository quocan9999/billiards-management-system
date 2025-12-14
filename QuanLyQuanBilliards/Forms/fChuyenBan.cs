using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using QuanLyQuanBilliards.Helpers;

namespace QuanLyQuanBilliards.Forms
{
    public partial class fChuyenBan : Form
    {
        // Sử dụng quyền theo vai trò người dùng hiện tại
        private QuanLyQuanBilliardsEntities db;
        private int _banHienTaiID;
        private string _tenBanHienTai;

        /// <summary>
        /// Constructor nhận ID bàn hiện tại cần chuyển
        /// </summary>
        /// <param name="banHienTaiID">ID của bàn đang có khách muốn chuyển</param>
        public fChuyenBan(int banHienTaiID)
        {
            InitializeComponent();
            _banHienTaiID = banHienTaiID;

            // Khởi tạo DbContext với quyền theo vai trò
            db = DatabaseHelper.CreateDbContext();

            // Load thông tin bàn hiện tại
            LoadBanHienTai();

            // Load danh sách bàn trống
            LoadDanhSachBanTrong();

            // Gán sự kiện
            btnXacNhan.Click += BtnXacNhan_Click;
            btnHuy.Click += BtnHuy_Click;
        }

        /// <summary>
        /// Hiển thị tên bàn hiện tại
        /// </summary>
        private void LoadBanHienTai()
        {
            var ban = db.Bans.Find(_banHienTaiID);
            if (ban != null)
            {
                _tenBanHienTai = ban.TenBan;
                lblBanHienTai.Text = $"Bàn hiện tại: {ban.TenBan} ({ban.KhuVuc?.TenKhuVuc})";
            }
            else
            {
                lblBanHienTai.Text = "Bàn hiện tại: Không tìm thấy!";
            }
        }

        /// <summary>
        /// Load danh sách các bàn đang TRỐNG vào ComboBox
        /// </summary>
        private void LoadDanhSachBanTrong()
        {
            // Lấy danh sách bàn trống (loại trừ bàn hiện tại)
            var listBanTrong = db.Bans
                .Where(b => b.TrangThai == "Trống" && b.BanID != _banHienTaiID)
                .OrderBy(b => b.BanID)
                .Select(b => new
                {
                    b.BanID,
                    HienThi = b.TenBan + " - " + b.KhuVuc.TenKhuVuc + " (" + b.LoaiBan.TenLoai + ")"
                })
                .ToList();

            if (listBanTrong.Count == 0)
            {
                cboBanMoi.DataSource = null;
                cboBanMoi.Items.Add("-- Không có bàn trống --");
                cboBanMoi.SelectedIndex = 0;
                cboBanMoi.Enabled = false;
                btnXacNhan.Enabled = false;
            }
            else
            {
                cboBanMoi.DataSource = listBanTrong;
                cboBanMoi.DisplayMember = "HienThi";
                cboBanMoi.ValueMember = "BanID";
                cboBanMoi.Enabled = true;
                btnXacNhan.Enabled = true;
            }
        }

        /// <summary>
        /// Xử lý khi bấm nút Xác nhận
        /// </summary>
        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (cboBanMoi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bàn muốn chuyển tới!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int banMoiID = (int)cboBanMoi.SelectedValue;
            string tenBanMoi = cboBanMoi.Text;

            // Xác nhận lần nữa
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn chuyển từ [{_tenBanHienTai}] sang [{tenBanMoi}]?",
                "Xác nhận chuyển bàn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                // Gọi Stored Procedure sp_ChuyenBan
                var paramBanCu = new SqlParameter("@BanCu", _banHienTaiID);
                var paramBanMoi = new SqlParameter("@BanMoi", banMoiID);

                // Sử dụng SqlQuery để nhận kết quả từ SP
                var result = db.Database.SqlQuery<SPResult>(
                    "EXEC banhang.sp_ChuyenBan @BanCu, @BanMoi",
                    paramBanCu, paramBanMoi).FirstOrDefault();

                if (result != null && result.Success == 1)
                {
                    MessageBox.Show(result.Message, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string errorMsg = result != null ? result.Message : "Lỗi không xác định!";
                    MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển bàn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý khi bấm nút Hủy
        /// </summary>
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Class để map kết quả từ Stored Procedure
        /// </summary>
        private class SPResult
        {
            public int Success { get; set; }
            public string Message { get; set; }
        }
    }
}