using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyQuanBilliards.Helpers;

namespace QuanLyQuanBilliards.Forms
{
    public partial class fOrder : Form
    {
        private int _banID;
        // Sử dụng quyền theo vai trò người dùng hiện tại
        private QuanLyQuanBilliardsEntities db;

        // List tạm để lưu món trước khi lưu vào DB
        private List<OrderItemTemp> _tempOrderList = new List<OrderItemTemp>();

        public fOrder(int banID)
        {
            InitializeComponent();
            _banID = banID;

            // Khởi tạo DbContext với quyền theo vai trò
            db = DatabaseHelper.CreateDbContext();

            this.Load += fOrder_Load;
            dgvOrderTemp.CellClick += DgvOrderTemp_CellClick;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnXacNhanOrder.Click += BtnXacNhanOrder_Click;
        }

        private void fOrder_Load(object sender, EventArgs e)
        {
            LoadCategoriesAndProducts();
        }

        private void LoadCategoriesAndProducts()
        {
            tabMenu.TabPages.Clear();

            // Lấy danh mục từ DB
            var listDanhMuc = db.DanhMucs.ToList();

            foreach (var dm in listDanhMuc)
            {
                // Tạo TabPage
                TabPage tab = new TabPage(dm.TenDanhMuc);
                tab.Tag = dm.DanhMucID;

                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Dock = DockStyle.Fill;
                flp.AutoScroll = true;
                flp.BackColor = Color.WhiteSmoke;
                flp.Padding = new Padding(10);

                // Load sản phẩm của danh mục này
                var listSP = db.SanPhams.Where(sp => sp.DanhMucID == dm.DanhMucID && sp.TrangThai == "Còn").ToList();

                foreach (var sp in listSP)
                {
                    Button btn = new Button();
                    btn.Size = new Size(150, 100);
                    btn.Margin = new Padding(10);
                    btn.BackColor = Color.LightCyan;
                    btn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);

                    // Hiển thị tên và giá
                    btn.Text = $"{sp.TenSP}\n{sp.DonGia:N0}đ";
                    btn.Tag = sp;
                    btn.Click += BtnProduct_Click;

                    flp.Controls.Add(btn);
                }

                tab.Controls.Add(flp);
                tabMenu.TabPages.Add(tab);
            }
        }

        // Sự kiện khi bấm vào nút món ăn
        private void BtnProduct_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var sp = btn.Tag as SanPham;
            if (sp == null) return;

            // Nếu món đã có trong list tạm thì cộng dồn, chưa có thì thêm mới
            var existingItem = _tempOrderList.FirstOrDefault(x => x.SanPhamID == sp.SanPhamID);

            if (existingItem != null)
            {
                existingItem.SoLuong++;
            }
            else
            {
                _tempOrderList.Add(new OrderItemTemp
                {
                    SanPhamID = sp.SanPhamID,
                    TenSP = sp.TenSP,
                    DonGia = sp.DonGia,
                    SoLuong = 1,
                    TrangThai = sp.TrangThai
                });
            }

            ReloadGridTemp();
        }

        private void ReloadGridTemp()
        {
            dgvOrderTemp.Rows.Clear();
            foreach (var item in _tempOrderList)
            {
                int idx = dgvOrderTemp.Rows.Add();
                dgvOrderTemp.Rows[idx].Cells[0].Value = item.SanPhamID;
                dgvOrderTemp.Rows[idx].Cells[1].Value = item.TenSP;
                dgvOrderTemp.Rows[idx].Cells[2].Value = item.DonGia.ToString("N0");
                dgvOrderTemp.Rows[idx].Cells[3].Value = item.SoLuong;
                dgvOrderTemp.Rows[idx].Cells[4].Value = (item.SoLuong * item.DonGia).ToString("N0");
                dgvOrderTemp.Rows[idx].Tag = item;
            }
        }

        private void DgvOrderTemp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrderTemp.CurrentRow != null)
            {
                var item = dgvOrderTemp.CurrentRow.Tag as OrderItemTemp;
                if (item != null)
                {
                    txtTenSP.Text = item.TenSP;
                    txtDonGia.Text = item.DonGia.ToString("N0");
                    txtTrangThai.Text = item.TrangThai;
                    nudSoLuong.Value = item.SoLuong;
                }
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvOrderTemp.CurrentRow == null) return;
            var item = dgvOrderTemp.CurrentRow.Tag as OrderItemTemp;
            if (item != null)
            {
                item.SoLuong = (int)nudSoLuong.Value;
                ReloadGridTemp();
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvOrderTemp.CurrentRow == null) return;
            var item = dgvOrderTemp.CurrentRow.Tag as OrderItemTemp;
            if (item != null)
            {
                _tempOrderList.Remove(item);
                ReloadGridTemp();

                // Clear controls
                txtTenSP.Clear(); txtDonGia.Clear(); txtTrangThai.Clear(); nudSoLuong.Value = 1;
            }
        }

        private void BtnXacNhanOrder_Click(object sender, EventArgs e)
        {
            if (_tempOrderList.Count == 0)
            {
                MessageBox.Show("Chưa chọn món nào!");
                return;
            }

            try
            {
                // Tìm hóa đơn đang mở của bàn này
                var hd = db.HoaDons.FirstOrDefault(h => h.BanID == _banID && h.TrangThai == 0);
                if (hd == null)
                {
                    MessageBox.Show("Bàn này chưa được mở! Vui lòng quay lại và Bắt đầu tính giờ.");
                    return;
                }

                foreach (var item in _tempOrderList)
                {
                    // Kiểm tra xem món này đã có trong DB chưa để cộng dồn
                    var chiTietDB = db.HoaDonChiTiets.FirstOrDefault(c => c.HoaDonID == hd.HoaDonID && c.SanPhamID == item.SanPhamID);

                    if (chiTietDB != null)
                    {
                        chiTietDB.SoLuong += item.SoLuong;
                    }
                    else
                    {
                        HoaDonChiTiet newItem = new HoaDonChiTiet
                        {
                            HoaDonID = hd.HoaDonID,
                            SanPhamID = item.SanPhamID,
                            SoLuong = item.SoLuong,
                            DonGia = item.DonGia
                        };
                        db.HoaDonChiTiets.Add(newItem);
                    }
                }

                db.SaveChanges();
                MessageBox.Show("Order thành công!");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi order: " + ex.Message);
            }
        }

        // Class nội bộ dùng cho list tạm
        public class OrderItemTemp
        {
            public int SanPhamID { get; set; }
            public string TenSP { get; set; }
            public decimal DonGia { get; set; }
            public int SoLuong { get; set; }
            public string TrangThai { get; set; }
        }
    }
}