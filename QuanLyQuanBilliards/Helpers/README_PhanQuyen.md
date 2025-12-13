# H??ng D?n C?u Hình Phân Quy?n SQL Server

## 1. T?ng Quan H? Th?ng Phân Quy?n

H? th?ng s? d?ng 2 c?p ?? phân quy?n:
- **Phân quy?n trong ?ng d?ng**: Ki?m tra vai trò t? b?ng `phanquyen.NguoiDung`
- **Phân quy?n trong SQL Server**: S? d?ng Login/User/Role ?? gi?i h?n quy?n truy c?p database

## 2. C?u Trúc Phân Quy?n SQL Server

### 2.1 SQL Logins
| Login | M?t kh?u | Mô t? |
|-------|----------|-------|
| `App_Billiards_Admin` | `Admin@123` | Dành cho tài kho?n Admin |
| `App_Billiards_Staff` | `Staff@123` | Dành cho tài kho?n Nhân viên |

### 2.2 Database Users
| User | Login t??ng ?ng | Role |
|------|-----------------|------|
| `App_Billiards_Admin_User` | `App_Billiards_Admin` | `dbrole_QuanTri` |
| `App_Billiards_Staff_User` | `App_Billiards_Staff` | `dbrole_NhanVien` |

### 2.3 Database Roles và Quy?n

#### Role `dbrole_QuanTri` (Admin)
- Thu?c nhóm `db_owner` ? Toàn quy?n trên database
- Có th? truy c?p t?t c? 4 schema: `phanquyen`, `danhmuc`, `banhang`, `baocao`

#### Role `dbrole_NhanVien` (Nhân viên)

**???c phép:**
- `SELECT` trên `danhmuc.Ban`, `danhmuc.LoaiBan`, `danhmuc.KhuVuc`, `danhmuc.SanPham`, `danhmuc.DanhMuc`
- `SELECT`, `INSERT`, `UPDATE`, `DELETE` trên schema `banhang`
- `EXECUTE` các stored procedure trong schema `banhang`

**B? c?m (DENY):**
- Toàn b? schema `phanquyen` (không xem ???c thông tin tài kho?n)
- Toàn b? schema `baocao` (không xem ???c báo cáo)
- `INSERT`, `UPDATE`, `DELETE` trên schema `danhmuc` (không thay ??i giá, s?n ph?m...)

## 3. C?u Hình Trong ?ng D?ng

### 3.1 File `Helpers/DatabaseHelper.cs`
Thay ??i thông tin k?t n?i SQL Server:

```csharp
// C?P NH?T THEO MÁY CH? C?A B?N
private const string SERVER_NAME = "TEN_MAY_CHU_SQL";
private const string DATABASE_NAME = "QuanLyQuanBilliards";

// Thông tin ??ng nh?p (ph?i kh?p v?i SQL Script)
private const string ADMIN_LOGIN = "App_Billiards_Admin";
private const string ADMIN_PASSWORD = "Admin@123";
private const string STAFF_LOGIN = "App_Billiards_Staff";
private const string STAFF_PASSWORD = "Staff@123";
```

### 3.2 File `Helpers/SessionManager.cs`
L?u tr? thông tin ng??i dùng ?ang ??ng nh?p:
- `NguoiDungID`: ID ng??i dùng
- `TenDangNhap`: Tên ??ng nh?p
- `VaiTro`: Vai trò (Admin / Nhân viên)
- `HoTen`: H? tên nhân viên

### 3.3 Cách S? D?ng Trong Code

```csharp
// T?o DbContext v?i quy?n theo vai trò ng??i dùng hi?n t?i
var db = DatabaseHelper.CreateDbContext();

// Ki?m tra quy?n
if (SessionManager.LaAdmin)
{
    // Code dành cho Admin
}
else if (SessionManager.LaNhanVien)
{
    // Code dành cho Nhân viên
}
```

## 4. Ch?y SQL Script

**B??c 1:** Ch?y file `database_QuanLyQuanBilliards.sql` ??:
- T?o database và các b?ng
- T?o stored procedures, triggers, functions
- T?o Login, User, Role
- C?p quy?n (GRANT/DENY)

**B??c 2:** Ki?m tra Login ?ã ???c t?o:
```sql
SELECT name, type_desc FROM sys.server_principals 
WHERE name LIKE 'App_Billiards%';
```

**B??c 3:** Ki?m tra quy?n c?a Role:
```sql
USE QuanLyQuanBilliards;
SELECT * FROM sys.database_permissions 
WHERE grantee_principal_id = DATABASE_PRINCIPAL_ID('dbrole_NhanVien');
```

## 5. L?u Ý B?o M?t

?? **Quan tr?ng:**
- M?t kh?u trong code ch? là ví d? demo
- Khi tri?n khai th?c t?, c?n:
  - ??i m?t kh?u m?nh h?n
  - Mã hóa ho?c l?u m?t kh?u an toàn (không hardcode)
  - S? d?ng Azure Key Vault ho?c Windows Credential Manager

## 6. X? Lý L?i Th??ng G?p

### L?i "Login failed for user 'App_Billiards_Staff'"
- Ki?m tra SQL Login ?ã ???c t?o ch?a
- Ki?m tra m?t kh?u có ?úng không
- Ki?m tra SQL Server có cho phép SQL Authentication không

### L?i "The SELECT permission was denied on object..."
- Nhân viên ?ang c? truy c?p schema không ???c phép
- Ki?m tra l?i quy?n DENY có ?úng không

### L?i k?t n?i
- Ki?m tra `SERVER_NAME` trong `DatabaseHelper.cs`
- Ki?m tra SQL Server ?ang ch?y
- Ki?m tra Firewall cho phép k?t n?i
