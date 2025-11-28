/* ================================================================
   QUẢN LÝ QUÁN BIDA
   Tên CSDL: QuanLyQuanBilliards
   Phân hệ & schema: 
     - phanquyen: NguoiDung, NhanVien
     - danhmuc  : KhuVuc, LoaiBan, Ban, DanhMuc, SanPham
     - banhang  : HoaDon, HoaDonChiTiet
     - baocao   : BaoCao_DoanhThu
   ================================================================ */

/* 0) TẠO CSDL */
USE master;
IF DB_ID(N'QuanLyQuanBilliards') IS NOT NULL
BEGIN
    ALTER DATABASE QuanLyQuanBilliards SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyQuanBilliards;
END;
GO
CREATE DATABASE QuanLyQuanBilliards;
GO
USE QuanLyQuanBilliards;
GO

/* 1) SCHEMA */
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name=N'phanquyen') EXEC('CREATE SCHEMA phanquyen');
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name=N'danhmuc')   EXEC('CREATE SCHEMA danhmuc');
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name=N'banhang')   EXEC('CREATE SCHEMA banhang');
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name=N'baocao')    EXEC('CREATE SCHEMA baocao');
GO

/* 2) BẢNG – PHÂN QUYỀN */
CREATE TABLE phanquyen.NguoiDung(
    NguoiDungID  INT IDENTITY,
    TenDangNhap  VARCHAR(50) NOT NULL UNIQUE,
    MatKhau      VARCHAR(1000) NOT NULL, -- mật khẩu đơn giản (demo)
    VaiTro       NVARCHAR(20) NOT NULL, -- Admin, nhân viên
    TrangThai NVARCHAR(20) NOT NULL CONSTRAINT DF_ND_TrangThai DEFAULT N'Hoạt động',
    NgayTao      DATETIME2(0) NOT NULL CONSTRAINT DF_ND_NgayTao DEFAULT(SYSDATETIME()),
    CONSTRAINT PK_NguoiDung PRIMARY KEY (NguoiDungID)
);
GO

CREATE TABLE phanquyen.NhanVien(
    NhanVienID INT IDENTITY,
    MaNV AS ('NV' + RIGHT('000' + CAST(NhanVienID AS VARCHAR(3)), 3)) PERSISTED,
    NguoiDungID INT NOT NULL UNIQUE,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15) NULL,
    Email VARCHAR(100) NULL,
    LuongCoBan DECIMAL(18,2) NULL CONSTRAINT CK_NV_Luong CHECK (LuongCoBan IS NULL OR LuongCoBan>=0),
    CONSTRAINT PK_NhanVien PRIMARY KEY (NhanVienID),
    CONSTRAINT FK_NhanVien_NguoiDung FOREIGN KEY (NguoiDungID) REFERENCES phanquyen.NguoiDung(NguoiDungID)
);
GO

/* Tự tạo hồ sơ NhanVien cho mọi NguoiDung (kể cả Admin) */
-- TODO: kêu chatgpt gen trigger

/* 3) BẢNG – DANH MỤC ĐƠN GIẢN */
CREATE TABLE danhmuc.KhuVuc(
    KhuVucID  INT IDENTITY,
    TenKhuVuc NVARCHAR(100) NOT NULL UNIQUE,
    TangSo    INT NOT NULL CONSTRAINT CK_KV_Tang CHECK (TangSo>=0),
    CONSTRAINT PK_KhuVuc PRIMARY KEY (KhuVucID)
);
GO

CREATE TABLE danhmuc.LoaiBan(
    LoaiBanID     INT IDENTITY,
    TenLoai       NVARCHAR(100) NOT NULL UNIQUE,
    GiaTheoGio    DECIMAL(18,2) NOT NULL CONSTRAINT CK_LB_Gia CHECK (GiaTheoGio>=0),
    CONSTRAINT PK_LoaiBan PRIMARY KEY (LoaiBanID)
);
GO

CREATE TABLE danhmuc.Ban(
    BanID      INT IDENTITY,
    TenBan     NVARCHAR(60) NOT NULL UNIQUE,
    KhuVucID   INT NOT NULL,
    LoaiBanID  INT NOT NULL,
    TrangThai  NVARCHAR(20) NOT NULL CONSTRAINT DF_Ban_TrangThai DEFAULT N'Trống', -- Trống | Có khách | Chờ thanh toán
    GhiChu     NVARCHAR(200) NULL,
    CONSTRAINT CK_Ban_TrangThai CHECK (TrangThai IN(N'Trống', N'Có khách', N'Chờ thanh toán')),
    CONSTRAINT PK_Ban PRIMARY KEY (BanID),
    CONSTRAINT FK_Ban_KhuVuc FOREIGN KEY (KhuVucID)  REFERENCES danhmuc.KhuVuc(KhuVucID),
    CONSTRAINT FK_Ban_LoaiBan FOREIGN KEY (LoaiBanID) REFERENCES danhmuc.LoaiBan(LoaiBanID)
);
GO

CREATE TABLE danhmuc.DanhMuc(
    DanhMucID INT IDENTITY,
    TenDanhMuc NVARCHAR(50) NOT NULL UNIQUE, -- Ví dụ: Thức uống / Đồ ăn
    CONSTRAINT PK_DanhMuc PRIMARY KEY (DanhMucID)
);
GO

CREATE TABLE danhmuc.SanPham(
    SanPhamID   INT IDENTITY,
    TenSP       NVARCHAR(120) NOT NULL UNIQUE,
    DanhMucID   INT NOT NULL,
    DonGia      DECIMAL(18,2) NOT NULL CONSTRAINT CK_SP_DonGia CHECK (DonGia>=0),
    TrangThai NVARCHAR(20) NOT NULL CONSTRAINT DF_SP_TrangThai DEFAULT N'Còn', -- Còn | Hết
    CONSTRAINT PK_SanPham PRIMARY KEY (SanPhamID),
	CONSTRAINT CK_SanPham_TrangThai CHECK (TrangThai IN(N'Còn', N'Hết')),
    CONSTRAINT FK_SanPham_DanhMuc FOREIGN KEY (DanhMucID) REFERENCES danhmuc.DanhMuc(DanhMucID)
);
GO

/* 4) BẢNG – BÁN HÀNG */
CREATE TABLE banhang.HoaDon
(
    HoaDonID INT IDENTITY,
    BanID INT NOT NULL,
    TrangThai TINYINT NOT NULL CONSTRAINT DF_HD_TrangThai DEFAULT (0), -- 0: MO, 1: DA_TT, 2: HUY
    LoaiGiamGia TINYINT NOT NULL CONSTRAINT DF_HD_LoaiGiam DEFAULT (0), -- 0: Không, 1: Trừ tiền, 2: %
    GiaTriGiam DECIMAL(18, 2) NOT NULL CONSTRAINT DF_HD_GiaTriGiam DEFAULT (0),
    TongThanhToan DECIMAL(18, 2) NOT NULL CONSTRAINT DF_HD_Tong DEFAULT (0),
	TongTienTruocGiam DECIMAL(18, 2) CONSTRAINT DF_HD_TruocGiam DEFAULT (0),
    ThoiDiemBatDau DATETIME2(0) NOT NULL CONSTRAINT DF_HD_ThoiDiemBatDau DEFAULT (SYSDATETIME()), -- Thời điểm bắt đầu tính giờ chơi
    ThoiDiemThanhToan DATETIME2(0) NULL, -- Thời điểm thanh toán
    NguoiLapID INT NULL,
    CONSTRAINT CK_HD_TrangThai CHECK (TrangThai IN ( 0, 1, 2 )),
    CONSTRAINT CK_HD_LoaiGiam CHECK (LoaiGiamGia IN ( 0, 1, 2 )),
    CONSTRAINT CK_HD_GiaTriGiam_Positive CHECK (GiaTriGiam >= 0),
    CONSTRAINT PK_HoaDon PRIMARY KEY (HoaDonID),
    CONSTRAINT FK_HoaDon_Ban FOREIGN KEY (BanID) REFERENCES danhmuc.Ban (BanID),
    CONSTRAINT FK_HoaDon_NguoiDung FOREIGN KEY (NguoiLapID) REFERENCES phanquyen.NguoiDung (NguoiDungID)
);
GO

CREATE INDEX IX_HoaDon_Ban ON banhang.HoaDon(BanID, TrangThai);
GO
CREATE UNIQUE INDEX IX_HoaDon_Ban_Mo ON banhang.HoaDon(BanID) WHERE TrangThai = 0;  -- 0 = Mở
GO

CREATE TABLE banhang.HoaDonChiTiet
(
    HoaDonCTID INT IDENTITY,
    HoaDonID INT NOT NULL,
    SanPhamID INT NOT NULL,
    SoLuong DECIMAL(18, 4) NOT NULL CONSTRAINT CK_HDCT_SoLuong CHECK (SoLuong > 0),
    DonGia DECIMAL(18, 2) NOT NULL CONSTRAINT CK_HDCT_DonGia CHECK (DonGia >= 0),
    ThanhTien AS (ROUND(SoLuong * DonGia, 2)) PERSISTED,
    CONSTRAINT PK_HoaDonChiTiet PRIMARY KEY (HoaDonCTID),
    CONSTRAINT FK_HoaDonChiTiet_HoaDon FOREIGN KEY (HoaDonID) REFERENCES banhang.HoaDon (HoaDonID) ON DELETE CASCADE,
    CONSTRAINT FK_HoaDonChiTiet_SanPham FOREIGN KEY (SanPhamID) REFERENCES danhmuc.SanPham (SanPhamID)
);
GO

CREATE INDEX IX_HDCT_HD ON banhang.HoaDonChiTiet(HoaDonID);
GO

/* 5) BẢNG – BÁO CÁO DOANH THU (ĐƠN GIẢN) */
DROP TABLE IF EXISTS baocao.BaoCao_DoanhThu;
GO
CREATE TABLE baocao.BaoCao_DoanhThu(
    BaoCaoID     INT IDENTITY(1,1),
    TuNgay       DATE NOT NULL,
    DenNgay      DATE NOT NULL,
    TongDoanhThu DECIMAL(18,2) NOT NULL,
    NgayLap      DATETIME2(0) NOT NULL CONSTRAINT DF_BC_NgayLap DEFAULT(SYSDATETIME()),
    CONSTRAINT CK_BC_KhoangNgay CHECK (DenNgay >= TuNgay),
    CONSTRAINT PK_BaoCao_DoanhThu PRIMARY KEY (BaoCaoID),
);
GO
/*=================================== 
			DỮ LIỆU MẪU
===================================*/
/*===================================
            DỮ LIỆU MẪU
===================================*/

-- 1) Tài khoản người dùng (2 tài khoản: admin, nhanvien)
INSERT INTO phanquyen.NguoiDung (TenDangNhap, MatKhau, VaiTro)
VALUES 
    ('admin',    '1', N'Admin'),
    ('nhanvien', '1', N'Nhân viên');
GO

-- 2) Hồ sơ nhân viên (1-1 với tài khoản)
INSERT INTO phanquyen.NhanVien (NguoiDungID, HoTen, SoDienThoai, Email, LuongCoBan)
SELECT NguoiDungID, N'Quản trị viên hệ thống', '0900000000', 'admin@bida.local', 15000000
FROM phanquyen.NguoiDung
WHERE TenDangNhap = 'admin';

INSERT INTO phanquyen.NhanVien (NguoiDungID, HoTen, SoDienThoai, Email, LuongCoBan)
SELECT NguoiDungID, N'Nhân viên thu ngân', '0900000001', 'nhanvien@bida.local', 8000000
FROM phanquyen.NguoiDung
WHERE TenDangNhap = 'nhanvien';
GO

-- 3) Khu vực bàn (tối đa 3 dòng)
INSERT INTO danhmuc.KhuVuc (TenKhuVuc, TangSo)
VALUES
    (N'Tầng trệt', 0),
    (N'Lầu 1',     1),
    (N'Khu VIP',   1);
GO

-- 4) Loại bàn (tối đa 3 dòng)
INSERT INTO danhmuc.LoaiBan (TenLoai, GiaTheoGio)
VALUES
    (N'Bàn thường',  50000),
    (N'Bàn VIP',     80000),
    (N'Bàn Snooker', 100000);
GO

-- 5) Bàn (tối đa 3 dòng)
INSERT INTO danhmuc.Ban (TenBan, KhuVucID, LoaiBanID, TrangThai, GhiChu)
VALUES
    (N'Bàn 01',
     (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Tầng trệt'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn thường'),
     N'Trống',
     NULL),
    (N'Bàn 02',
     (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Tầng trệt'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn VIP'),
     N'Trống',
     NULL),
    (N'Bàn 03',
     (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Khu VIP'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn Snooker'),
     N'Trống',
     NULL);
GO

-- 6) Danh mục sản phẩm (tối đa 3 dòng)
INSERT INTO danhmuc.DanhMuc (TenDanhMuc)
VALUES
    (N'Thức uống'),
    (N'Đồ ăn nhanh'),
    (N'Snack');
GO

-- 7) Sản phẩm (tối đa 3 dòng)
INSERT INTO danhmuc.SanPham (TenSP, DanhMucID, DonGia, TrangThai)
VALUES
    (N'Cà phê sữa đá',
     (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Thức uống'),
     25000,
     N'Còn'),
    (N'Trà tắc',
     (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Thức uống'),
     20000,
     N'Còn'),
    (N'Mì xào bò',
     (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Đồ ăn nhanh'),
     40000,
     N'Còn');
GO