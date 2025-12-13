# 🎱 Hệ Thống Quản Lý Quán Billiards

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-purple)](https://dotnet.microsoft.com/download/dotnet-framework/net48)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-red)](https://www.microsoft.com/sql-server)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-6.5.1-blue)](https://docs.microsoft.com/ef/ef6/)

Ứng dụng quản lý quán Billiards được phát triển bằng **C# Windows Forms** với **Entity Framework 6** và **SQL Server**.

---

## 📋 Mục Lục

- [Tính Năng](#-tính-năng)
- [Yêu Cầu Hệ Thống](#-yêu-cầu-hệ-thống)
- [Hướng Dẫn Cài Đặt](#-hướng-dẫn-cài-đặt)
- [Tài Khoản Mặc Định](#-tài-khoản-mặc-định)
- [Cấu Trúc Database](#-cấu-trúc-database)
- [Khắc Phục Lỗi Thường Gặp](#-khắc-phục-lỗi-thường-gặp)

---

## ✨ Tính Năng

| Chức năng | Mô tả |
|-----------|-------|
| 🎯 **Quản lý bàn** | Theo dõi trạng thái bàn (Trống/Có khách/Chờ thanh toán) |
| ⏱️ **Tính tiền theo giờ** | Tự động tính tiền dựa trên loại bàn và thời gian chơi |
| 🍔 **Order sản phẩm** | Đặt đồ ăn, thức uống cho từng bàn |
| 💰 **Thanh toán** | Hỗ trợ giảm giá theo % hoặc số tiền cố định |
| 🔄 **Chuyển bàn** | Chuyển khách từ bàn này sang bàn khác |
| 📊 **Báo cáo doanh thu** | Thống kê doanh thu theo ngày/tháng |
| 👥 **Phân quyền** | Phân quyền Admin và Nhân viên |

---

## 💻 Yêu Cầu Hệ Thống

- **Visual Studio 2019/2022** (với workload **.NET desktop development**)
- **SQL Server** (LocalDB/Express/Developer) + **SSMS**
- **.NET Framework 4.8**
- **Git**

---

## 🚀 Hướng Dẫn Cài Đặt

### Bước 1: Clone Dự Án

```bash
https://github.com/quocan9999/billiards-management-system.git
cd billiards-management-system
```

---

### Bước 2: Tạo Database

Mở **SSMS**, kết nối đến SQL Server của bạn, sau đó chạy file:

```
QuanLyQuanBilliards/QuanLyQuanBilliards/Database/database_QuanLyQuanBilliards.sql
```

> Script sẽ tự động tạo database `QuanLyQuanBilliards` với đầy đủ bảng, stored procedures, triggers, functions và dữ liệu mẫu.

---

### Bước 3: Cấu Hình Connection String ⚠️ QUAN TRỌNG

Bạn cần thay đổi **2 file** để khớp với tên SQL Server của máy bạn:

#### 3.1. File `App.config`

Đường dẫn: `QuanLyQuanBilliards/QuanLyQuanBilliards/App.config`

Tìm dòng `data source=...` và thay bằng tên server của bạn:

```xml
<connectionStrings>
  <add name="QuanLyQuanBilliardsEntities" 
       connectionString="...data source=TÊN_SERVER_CỦA_BẠN;initial catalog=QuanLyQuanBilliards;..." />
</connectionStrings>
```

#### 3.2. File `DatabaseHelper.cs`

Đường dẫn: `QuanLyQuanBilliards/QuanLyQuanBilliards/Helpers/DatabaseHelper.cs`

Tìm dòng 17 và thay đổi `SERVER_NAME`:

```csharp
private const string SERVER_NAME = "TÊN_SERVER_CỦA_BẠN";
```

#### Bảng tham khảo tên server:

| Loại SQL Server | Giá trị |
|-----------------|---------|
| SQL Server mặc định | `.` hoặc `localhost` |
| SQL Server Express | `.\SQLEXPRESS` |
| LocalDB | `(localdb)\MSSQLLocalDB` |

---

### Bước 4: Mở Dự Án và Build

1. Mở file `QuanLyQuanBilliards.sln` bằng Visual Studio
2. Build Solution: `Ctrl + Shift + B`

> 💡 **Lưu ý:** Các NuGet packages đã được bao gồm sẵn trong repo, không cần restore thủ công.

---

### Bước 5: Chạy Ứng Dụng

Nhấn `F5` để chạy và đăng nhập với tài khoản mặc định.

---

## 👤 Tài Khoản Mặc Định

| Vai trò | Tên đăng nhập | Mật khẩu | Quyền hạn |
|---------|---------------|----------|-----------|
| **Admin** | `admin` | `1` | Toàn quyền |
| **Nhân viên** | `nhanvien` | `1` | Chỉ bán hàng |

---

## 🗄️ Cấu Trúc Database

### Schemas

| Schema | Mô tả |
|--------|-------|
| `phanquyen` | Quản lý người dùng và nhân viên |
| `danhmuc` | Danh mục bàn, khu vực, sản phẩm |
| `banhang` | Hóa đơn và chi tiết hóa đơn |
| `baocao` | Báo cáo doanh thu |

### Stored Procedures

| Procedure | Chức năng |
|-----------|-----------|
| `banhang.sp_HuyHoaDon` | Hủy hóa đơn và giải phóng bàn |
| `banhang.sp_ThanhToanDayDu` | Xử lý thanh toán |
| `banhang.sp_ChuyenBan` | Chuyển khách sang bàn khác |
| `banhang.sp_TinhTienBan` | Tính tiền bàn theo giờ |
| `baocao.sp_BaoCaoDoanhThu` | Lấy báo cáo doanh thu |
| `baocao.sp_DongBoBaoCao` | Đồng bộ báo cáo từ hóa đơn |

---

## ❌ Khắc Phục Lỗi Thường Gặp

| Lỗi | Giải pháp |
|-----|-----------|
| **Không kết nối được database** | Kiểm tra lại `data source` trong `App.config` và `SERVER_NAME` trong `DatabaseHelper.cs` |
| **Database không tồn tại** | Chạy lại file `database_QuanLyQuanBilliards.sql` |
| **EntityFramework không load** | Clean Solution rồi Rebuild, hoặc xóa thư mục `bin`, `obj` và build lại |
| **Login failed** | Đảm bảo SQL Server có `integrated security=True` hoặc tạo Login theo script |

---

## 📞 Liên Hệ

Nếu có thắc mắc, vui lòng tạo [Issue](https://github.com/quocan9999/billiards-management-system/issues) trên GitHub.

---

<p align="center">
  Made with ❤️ by <a href="https://github.com/quocan9999">quocan9999</a>
</p>
