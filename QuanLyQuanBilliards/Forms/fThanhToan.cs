using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyQuanBilliards.Helpers;

namespace QuanLyQuanBilliards.Forms
{
    public partial class fThanhToan : Form
    {
        private int _banID;
        // Sử dụng quyền theo vai trò người dùng hiện tại
        private QuanLyQuanBilliardsEntities db;

        // Biến lưu trữ số liệu thô (chưa giảm giá)
        private decimal _rawTienDichVu = 0;
        private decimal _rawTienBan = 0;
        private decimal _rawTongTien = 0;

        public fThanhToan(int banID)
        {
            InitializeComponent();
            _banID = banID;

            // Khởi tạo DbContext với quyền theo vai trò
            db = DatabaseHelper.CreateDbContext();

            // Cài đặt sự kiện
            this.Load += fThanhToan_Load;
            btnHuy.Click += (s, e) => this.Close();
            btnXacNhan.Click += btnXacNhan_Click;

            // Sự kiện tính toán giảm giá
            cboLoaiGiamGia.SelectedIndexChanged += UpdateTotal_Event;
            txtGiamGia.TextChanged += UpdateTotal_Event;
            txtGiamGia.KeyPress += TxtGiamGia_KeyPress; // Chỉ cho nhập số
        }

        private void fThanhToan_Load(object sender, EventArgs e)
        {
            LoadData();
            cboLoaiGiamGia.SelectedIndex = 0; // Mặc định không giảm
        }

        private void LoadData()
        {
            try
            {
                // 1. Gọi SP để lấy số liệu tính toán chính xác từ SQL
                var result = db.Database.SqlQuery<BillResult>(
                    "EXEC banhang.sp_TinhTienBan @BanID",
                    new System.Data.SqlClient.SqlParameter("@BanID", _banID)
                ).FirstOrDefault();

                if (result != null)
                {
                    // Lưu số liệu thô
                    _rawTienDichVu = result.TienDichVu;

                    // Tính tiền bàn
                    decimal gioChoi = (decimal)result.SoGiayChoi / 3600.0m;
                    _rawTienBan = gioChoi * result.GiaTheoGio;

                    _rawTongTien = _rawTienDichVu + _rawTienBan;

                    // Hiển thị thông tin cơ bản
                    var ban = db.Bans.Find(_banID);
                    lblTenBan.Text = ban.TenBan.ToUpper() + " - " + (ban.LoaiBan?.TenLoai ?? "");

                    TimeSpan t = TimeSpan.FromSeconds(result.SoGiayChoi);
                    lblThoiGian.Text = string.Format("{0:D2}:{1:D2}:{2:D2} ({3} phút)", t.Hours, t.Minutes, t.Seconds, (int)t.TotalMinutes);

                    lblTienDichVu.Text = _rawTienDichVu.ToString("N0") + "đ";
                    lblTienBan.Text = _rawTienBan.ToString("N0") + "đ";

                    // Load Chi tiết món ăn vào GridView
                    LoadGridDetails(ban.BanID);

                    // Tính toán hiển thị tổng lần đầu
                    CalculateFinalTotal();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadGridDetails(int banId)
        {
            dgvChiTiet.Rows.Clear();
            var hd = db.HoaDons.OrderByDescending(h => h.HoaDonID).FirstOrDefault(h => h.BanID == banId);
            if (hd == null) return;

            var listCT = db.HoaDonChiTiets.Where(c => c.HoaDonID == hd.HoaDonID).ToList();
            foreach (var item in listCT)
            {
                var sp = db.SanPhams.Find(item.SanPhamID);
                int idx = dgvChiTiet.Rows.Add();
                dgvChiTiet.Rows[idx].Cells[0].Value = sp.TenSP;
                dgvChiTiet.Rows[idx].Cells[1].Value = item.DonGia.ToString("N0");
                dgvChiTiet.Rows[idx].Cells[2].Value = item.SoLuong;
                dgvChiTiet.Rows[idx].Cells[3].Value = (item.SoLuong * item.DonGia).ToString("N0");
            }
        }

        private void UpdateTotal_Event(object sender, EventArgs e)
        {
            CalculateFinalTotal();
        }

        private void CalculateFinalTotal()
        {
            decimal giamGia = 0;
            decimal finalTotal = _rawTongTien;

            // Xử lý đầu vào textbox
            decimal inputValue = 0;
            decimal.TryParse(txtGiamGia.Text.Replace(",", ""), out inputValue);

            int loaiGiam = cboLoaiGiamGia.SelectedIndex; // 0: Không, 1: %, 2: Tiền

            if (loaiGiam == 1) // Theo %
            {
                if (inputValue > 100) inputValue = 100; // Max 100%
                giamGia = _rawTongTien * (inputValue / 100);
            }
            else if (loaiGiam == 2) // Theo tiền
            {
                if (inputValue > _rawTongTien) inputValue = _rawTongTien; // Không giảm quá tổng tiền
                giamGia = inputValue;
            }

            finalTotal = _rawTongTien - giamGia;

            // Hiển thị
            lblTienGiam.Text = "-" + giamGia.ToString("N0") + "đ";
            lblFinalTotal.Text = finalTotal.ToString("N0") + "đ";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Xác nhận thanh toán hóa đơn với tổng tiền {lblFinalTotal.Text}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // 1. Cập nhật thông tin giảm giá trước khi gọi SP
                    var hd = db.HoaDons.OrderByDescending(h => h.HoaDonID)
                                       .FirstOrDefault(h => h.BanID == _banID && (h.TrangThai == 0 || h.TrangThai == 1));

                    if (hd != null)
                    {
                        hd.LoaiGiamGia = (byte)cboLoaiGiamGia.SelectedIndex;
                        decimal val = 0;
                        decimal.TryParse(txtGiamGia.Text, out val);
                        hd.GiaTriGiam = val;
                        db.SaveChanges();
                    }

                    // 2. Gọi SP Thanh Toán với Transaction và xử lý kết quả trả về
                    // FIX: Tính toán số tiền trực tiếp từ biến thay vì parse từ label (tránh lỗi culture)
                    decimal discountValue = 0;
                    decimal.TryParse(txtGiamGia.Text.Replace(",", ""), out discountValue);
                    
                    decimal discountAmount = 0;
                    int loaiGiam = cboLoaiGiamGia.SelectedIndex;
                    if (loaiGiam == 1) // Theo %
                    {
                        if (discountValue > 100) discountValue = 100;
                        discountAmount = _rawTongTien * (discountValue / 100);
                    }
                    else if (loaiGiam == 2) // Theo tiền
                    {
                        if (discountValue > _rawTongTien) discountValue = _rawTongTien;
                        discountAmount = discountValue;
                    }
                    
                    decimal finalMoney = _rawTongTien - discountAmount;

                    var spResult = db.Database.SqlQuery<SPResult>(
                        "EXEC banhang.sp_ThanhToanDayDu @BanID, @TongTienCuoiCung, @TongTienTruocGiam",
                        new System.Data.SqlClient.SqlParameter("@BanID", _banID),
                        new System.Data.SqlClient.SqlParameter("@TongTienCuoiCung", finalMoney),
                        new System.Data.SqlClient.SqlParameter("@TongTienTruocGiam", _rawTongTien)
                    ).FirstOrDefault();

                    if (spResult != null && spResult.Success == 1)
                    {
                        MessageBox.Show(spResult.Message ?? "Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(spResult?.Message ?? "Lỗi thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}