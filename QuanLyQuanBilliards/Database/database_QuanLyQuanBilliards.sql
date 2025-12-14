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
    TenBan     NVARCHAR(60) NOT NULL,
    KhuVucID   INT NOT NULL,
    LoaiBanID  INT NOT NULL,
    TrangThai  NVARCHAR(20) NOT NULL CONSTRAINT DF_Ban_TrangThai DEFAULT N'Trống', -- Trống | Có khách | Chờ thanh toán
    GhiChu     NVARCHAR(200) NULL,
    CONSTRAINT CK_Ban_TrangThai CHECK (TrangThai IN(N'Trống', N'Có khách', N'Chờ thanh toán')),
    CONSTRAINT PK_Ban PRIMARY KEY (BanID),
    CONSTRAINT FK_Ban_KhuVuc FOREIGN KEY (KhuVucID)  REFERENCES danhmuc.KhuVuc(KhuVucID),
    CONSTRAINT FK_Ban_LoaiBan FOREIGN KEY (LoaiBanID) REFERENCES danhmuc.LoaiBan(LoaiBanID),
    -- Ràng buộc UNIQUE: Tên bàn chỉ cần duy nhất trong cùng khu vực
    CONSTRAINT UQ_Ban_TenBan_KhuVuc UNIQUE (TenBan, KhuVucID)
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
			STORE PROCEDURE + TRANSACTION
===================================*/
-- PROCEDURE + TRANSACTION
-- Tác dụng:
--   - Đảm bảo việc xóa hóa đơn và cập nhật trạng thái bàn phải đồng bộ
--   - Nếu xóa hóa đơn thành công nhưng cập nhật bàn thất bại, tự động rollback
--   - Tránh tình trạng hóa đơn đã xóa nhưng bàn vẫn ở trạng thái "Có khách"
--   - Đảm bảo tính toàn vẹn dữ liệu khi hủy hóa đơn
CREATE OR ALTER PROCEDURE [banhang].[sp_HuyHoaDon]
    @BanID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- TRANSACTION 3: Đảm bảo tính nguyên tử khi hủy hóa đơn
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- 1. Tìm hóa đơn đang hoạt động (Mở hoặc Chờ thanh toán)
        DECLARE @HoaDonID INT;
        SELECT TOP 1 @HoaDonID = HoaDonID 
        FROM banhang.HoaDon 
        WHERE BanID = @BanID AND TrangThai IN (0, 1);

        IF @HoaDonID IS NULL
        BEGIN
            RAISERROR(N'Không tìm thấy hóa đơn đang hoạt động cho bàn này!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- 2. Xóa vĩnh viễn hóa đơn
        DELETE FROM banhang.HoaDon
        WHERE HoaDonID = @HoaDonID;

        -- 3. Trả trạng thái Bàn về 'Trống'
        UPDATE danhmuc.Ban
        SET TrangThai = N'Trống'
        WHERE BanID = @BanID;
        
        -- Commit nếu thành công
        COMMIT TRANSACTION;
        
        SELECT 1 AS Success, N'Hủy hóa đơn thành công!' AS Message;
    END TRY
    BEGIN CATCH
        -- Rollback nếu có lỗi
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        SELECT 0 AS Success, ERROR_MESSAGE() AS Message;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE [banhang].[sp_LayChiTietHoaDon]
    @BanID INT
AS
BEGIN
    -- Tìm hóa đơn đang mở (TrangThai = 0) của bàn này
    DECLARE @HoaDonID INT;
    SELECT TOP 1 @HoaDonID = HoaDonID 
    FROM banhang.HoaDon 
    WHERE BanID = @BanID AND TrangThai = 0;

    -- Nếu không có hóa đơn nào mở, trả về rỗng
    IF @HoaDonID IS NULL
    BEGIN
        SELECT NULL WHERE 1 = 0; -- Trả về bảng rỗng
        RETURN;
    END

    -- Trả về danh sách món ăn
    SELECT 
        ct.SanPhamID,
        sp.TenSP,
        ct.DonGia,
        ct.SoLuong,
        (ct.DonGia * ct.SoLuong) AS ThanhTien
    FROM banhang.HoaDonChiTiet ct
    JOIN danhmuc.SanPham sp ON ct.SanPhamID = sp.SanPhamID
    WHERE ct.HoaDonID = @HoaDonID;
END;
GO

CREATE OR ALTER PROCEDURE [banhang].[sp_TinhTienBan]
    @BanID INT
AS
BEGIN
    -- 1. Tìm hóa đơn
    DECLARE @HoaDonID INT;
    SELECT TOP 1 @HoaDonID = HoaDonID 
    FROM banhang.HoaDon 
    WHERE BanID = @BanID 
      AND (TrangThai = 0 OR (TrangThai = 1 AND ThoiDiemThanhToan IS NOT NULL))
    ORDER BY HoaDonID DESC;

    IF @HoaDonID IS NULL RETURN; 

    -- 2. Chốt giờ
    DECLARE @GioKetThuc DATETIME2(0) = SYSDATETIME();
    DECLARE @GioDaChot DATETIME2(0);
    SELECT @GioDaChot = ThoiDiemThanhToan FROM banhang.HoaDon WHERE HoaDonID = @HoaDonID;

    IF @GioDaChot IS NULL
    BEGIN
        UPDATE banhang.HoaDon
        SET ThoiDiemThanhToan = @GioKetThuc, TrangThai = 1
        WHERE HoaDonID = @HoaDonID;
        
        UPDATE danhmuc.Ban SET TrangThai = N'Chờ thanh toán' WHERE BanID = @BanID;
    END
    ELSE
    BEGIN
        SET @GioKetThuc = @GioDaChot;
    END

    -- 3. Tính toán
    SELECT 
        ISNULL((SELECT SUM(SoLuong * DonGia) 
                FROM banhang.HoaDonChiTiet 
                WHERE HoaDonID = @HoaDonID), 0) AS TienDichVu, -- <--- TÊN CỘT PHẢI CHUẨN

        DATEDIFF(SECOND, ThoiDiemBatDau, @GioKetThuc) AS SoGiayChoi,

        (SELECT TOP 1 lb.GiaTheoGio 
         FROM danhmuc.Ban b JOIN danhmuc.LoaiBan lb ON b.LoaiBanID = lb.LoaiBanID 
         WHERE b.BanID = @BanID) AS GiaTheoGio
    FROM banhang.HoaDon
    WHERE HoaDonID = @HoaDonID;
END;
GO

-- PROCEDURE + TRANSACTION
-- Tác dụng:
--   - Đảm bảo việc cập nhật hóa đơn và cập nhật trạng thái bàn phải đồng bộ
--   - Kiểm tra tính hợp lệ của số tiền thanh toán trước khi cập nhật
--   - Nếu có lỗi, tự động rollback để tránh mất dữ liệu
--   - Đảm bảo hóa đơn và bàn luôn ở trạng thái nhất quán sau khi thanh toán
CREATE OR ALTER PROCEDURE [banhang].[sp_ThanhToanDayDu]
    @BanID INT,
    @TongTienCuoiCung DECIMAL(18,2), -- Số tiền khách trả thực tế
    @TongTienTruocGiam DECIMAL(18,2) -- Số tiền gốc chưa giảm
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        DECLARE @HoaDonID INT;
        SELECT TOP 1 @HoaDonID = HoaDonID 
        FROM banhang.HoaDon 
        WHERE BanID = @BanID AND TrangThai IN (0, 1)
        ORDER BY HoaDonID DESC;

        IF @HoaDonID IS NULL
        BEGIN
            RAISERROR(N'Không tìm thấy hóa đơn đang mở cho bàn này!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- Kiểm tra số tiền hợp lệ
        IF @TongTienCuoiCung < 0
        BEGIN
            RAISERROR(N'Số tiền thanh toán không hợp lệ!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Cập nhật hóa đơn
        UPDATE banhang.HoaDon
        SET TongThanhToan = @TongTienCuoiCung,
            TongTienTruocGiam = @TongTienTruocGiam,
            TrangThai = 1, 
            ThoiDiemThanhToan = ISNULL(ThoiDiemThanhToan, SYSDATETIME()) 
        WHERE HoaDonID = @HoaDonID;

        -- Cập nhật trạng thái bàn
        UPDATE danhmuc.Ban
        SET TrangThai = N'Trống'
        WHERE BanID = @BanID;
        
        -- Commit nếu thành công
        COMMIT TRANSACTION;
        
        SELECT 1 AS Success, N'Thanh toán thành công!' AS Message;
    END TRY
    BEGIN CATCH
        -- Rollback nếu có lỗi
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        SELECT 0 AS Success, ERROR_MESSAGE() AS Message;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE [baocao].[sp_BaoCaoDoanhThu]
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SELECT 
        hd.HoaDonID AS [Mã HĐ],
        b.TenBan AS [Tên Bàn],
        hd.TongThanhToan AS [Tổng Tiền],
        hd.ThoiDiemThanhToan AS [Ngày Thanh Toán],
        hd.GiaTriGiam AS [Giảm Giá],
        CASE 
            WHEN hd.LoaiGiamGia = 1 THEN N'Theo %'
            WHEN hd.LoaiGiamGia = 2 THEN N'Theo tiền'
            ELSE N'Không'
        END AS [Loại Giảm]
    FROM banhang.HoaDon hd
    JOIN danhmuc.Ban b ON hd.BanID = b.BanID
    WHERE hd.TrangThai = 1
      AND CAST(hd.ThoiDiemThanhToan AS DATE) >= @TuNgay
      AND CAST(hd.ThoiDiemThanhToan AS DATE) <= @DenNgay
    ORDER BY hd.HoaDonID ASC; -- Sửa thành ASC (Tăng dần)
END;
GO

CREATE OR ALTER PROCEDURE [banhang].[sp_ChuyenBan]
    @BanCu INT,
    @BanMoi INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Khai báo biến
    DECLARE @HoaDonID INT;
    DECLARE @TrangThaiBanMoi NVARCHAR(20);
    
    -- Bắt đầu TRANSACTION
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- 1. Kiểm tra bàn mới có đang trống không
        SELECT @TrangThaiBanMoi = TrangThai 
        FROM danhmuc.Ban 
        WHERE BanID = @BanMoi;
        
        IF @TrangThaiBanMoi IS NULL
        BEGIN
            RAISERROR(N'Bàn đích không tồn tại!', 16, 1);
            RETURN;
        END
        
        IF @TrangThaiBanMoi <> N'Trống'
        BEGIN
            RAISERROR(N'Bàn đích đang được sử dụng, không thể chuyển!', 16, 1);
            RETURN;
        END
        
        -- 2. Tìm hóa đơn đang mở (TrangThai = 0) của bàn cũ
        SELECT TOP 1 @HoaDonID = HoaDonID 
        FROM banhang.HoaDon 
        WHERE BanID = @BanCu AND TrangThai = 0;
        
        IF @HoaDonID IS NULL
        BEGIN
            RAISERROR(N'Không tìm thấy hóa đơn đang mở tại bàn cũ!', 16, 1);
            RETURN;
        END
        
        -- 3. Cập nhật BanID của hóa đơn sang bàn mới
        UPDATE banhang.HoaDon
        SET BanID = @BanMoi
        WHERE HoaDonID = @HoaDonID;
        
        -- 4. Cập nhật trạng thái bàn cũ -> Trống
        UPDATE danhmuc.Ban
        SET TrangThai = N'Trống'
        WHERE BanID = @BanCu;
        
        -- 5. Cập nhật trạng thái bàn mới -> Có khách
        UPDATE danhmuc.Ban
        SET TrangThai = N'Có khách'
        WHERE BanID = @BanMoi;
        
        -- Commit nếu thành công
        COMMIT TRANSACTION;
        
        -- Trả về kết quả thành công
        SELECT 1 AS Success, N'Chuyển bàn thành công!' AS Message;
        
    END TRY
    BEGIN CATCH
        -- Rollback nếu có lỗi
        ROLLBACK TRANSACTION;
        
        -- Trả về lỗi
        SELECT 0 AS Success, ERROR_MESSAGE() AS Message;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE [baocao].[sp_XemBaoCaoTheoNgay]
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Tạo bảng tạm để chứa tất cả các ngày trong khoảng
    DECLARE @DanhSachNgay TABLE (Ngay DATE);
    DECLARE @NgayHienTai DATE = @TuNgay;
    
    WHILE @NgayHienTai <= @DenNgay
    BEGIN
        INSERT INTO @DanhSachNgay (Ngay) VALUES (@NgayHienTai);
        SET @NgayHienTai = DATEADD(DAY, 1, @NgayHienTai);
    END
    
    -- Kết hợp với dữ liệu doanh thu thực tế
    SELECT 
        ds.Ngay,
        DATENAME(WEEKDAY, ds.Ngay) AS ThuTrongTuan,
        ISNULL(bc.TongDoanhThu, 0) AS DoanhThu,
        baocao.fn_DemHoaDonNgay(ds.Ngay) AS SoHoaDon,
        baocao.fn_DoanhThuTrungBinhNgay(ds.Ngay) AS TrungBinhMoiHoaDon
    FROM @DanhSachNgay ds
    LEFT JOIN baocao.BaoCao_DoanhThu bc 
        ON ds.Ngay = bc.TuNgay AND ds.Ngay = bc.DenNgay
    ORDER BY ds.Ngay;
END;
GO

CREATE OR ALTER PROCEDURE [baocao].[sp_DongBoBaoCao]
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @GhiDe BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Thiết lập giá trị mặc định
    IF @DenNgay IS NULL
        SET @DenNgay = CAST(GETDATE() AS DATE);
    
    IF @TuNgay IS NULL
        SET @TuNgay = DATEADD(MONTH, -1, @DenNgay); -- Mặc định 1 tháng trước
    
    -- Kiểm tra tham số
    IF @TuNgay > @DenNgay
    BEGIN
        RAISERROR(N'Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!', 16, 1);
        RETURN;
    END
    
    -- Khai báo biến cho CURSOR
    DECLARE @NgayHienTai DATE;
    DECLARE @DoanhThuNgay DECIMAL(18, 2);
    DECLARE @SoBaoCaoDaXuLy INT = 0;
    DECLARE @SoBaoCaoCapNhat INT = 0;
    DECLARE @SoBaoCaoThemMoi INT = 0;
    
    -- Tạo bảng tạm lưu danh sách ngày cần xử lý
    DECLARE @DanhSachNgay TABLE (Ngay DATE);
    
    -- Đổ danh sách ngày vào bảng tạm
    SET @NgayHienTai = @TuNgay;
    WHILE @NgayHienTai <= @DenNgay
    BEGIN
        INSERT INTO @DanhSachNgay (Ngay) VALUES (@NgayHienTai);
        SET @NgayHienTai = DATEADD(DAY, 1, @NgayHienTai);
    END
    
 -- ================================================================
 -- CURSOR: Duyệt từng ngày và tính doanh thu
 -- ================================================================
    DECLARE cur_Ngay CURSOR LOCAL FAST_FORWARD FOR
        SELECT Ngay FROM @DanhSachNgay ORDER BY Ngay;
    
    OPEN cur_Ngay;
    FETCH NEXT FROM cur_Ngay INTO @NgayHienTai;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Tính doanh thu ngày hiện tại bằng Function đã tạo
        SET @DoanhThuNgay = baocao.fn_TinhTongTienNgay(@NgayHienTai);
        
        -- Kiểm tra báo cáo ngày này đã tồn tại chưa
        IF EXISTS (
            SELECT 1 FROM baocao.BaoCao_DoanhThu 
            WHERE TuNgay = @NgayHienTai AND DenNgay = @NgayHienTai
        )
        BEGIN
            -- Nếu cho phép ghi đè thì UPDATE
            IF @GhiDe = 1
            BEGIN
                UPDATE baocao.BaoCao_DoanhThu
                SET TongDoanhThu = @DoanhThuNgay,
                    NgayLap = SYSDATETIME()
                WHERE TuNgay = @NgayHienTai AND DenNgay = @NgayHienTai;
                
                SET @SoBaoCaoCapNhat = @SoBaoCaoCapNhat + 1;
            END
        END
        ELSE
        BEGIN
            -- Chưa có thì INSERT mới
            INSERT INTO baocao.BaoCao_DoanhThu (TuNgay, DenNgay, TongDoanhThu)
            VALUES (@NgayHienTai, @NgayHienTai, @DoanhThuNgay);
            
            SET @SoBaoCaoThemMoi = @SoBaoCaoThemMoi + 1;
        END
        
        SET @SoBaoCaoDaXuLy = @SoBaoCaoDaXuLy + 1;
        
        FETCH NEXT FROM cur_Ngay INTO @NgayHienTai;
    END
    
    CLOSE cur_Ngay;
    DEALLOCATE cur_Ngay;
    
    -- Trả về kết quả thống kê
    SELECT 
        @SoBaoCaoDaXuLy AS TongSoNgayXuLy,
        @SoBaoCaoThemMoi AS SoBaoCaoThemMoi,
        @SoBaoCaoCapNhat AS SoBaoCaoCapNhat,
        @TuNgay AS TuNgay,
        @DenNgay AS DenNgay,
        N'Đồng bộ báo cáo thành công!' AS ThongBao;
END;
GO

/*=================================== 
			  TRIGGER	
===================================*/
-- Trigger 1: Tự động tạo hồ sơ NhanVien khi thêm NguoiDung mới
CREATE OR ALTER TRIGGER [phanquyen].[trg_AutoCreateNhanVien]
ON [phanquyen].[NguoiDung]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Khai báo biến
    DECLARE @NguoiDungID INT;
    DECLARE @TenDangNhap VARCHAR(50);
    DECLARE @VaiTro NVARCHAR(20);
    DECLARE @HoTenMacDinh NVARCHAR(100);
    
    DECLARE cur_NewUsers CURSOR FOR
        SELECT NguoiDungID, TenDangNhap, VaiTro
        FROM inserted;
    
    OPEN cur_NewUsers;
    FETCH NEXT FROM cur_NewUsers INTO @NguoiDungID, @TenDangNhap, @VaiTro;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Kiểm tra xem NhanVien đã tồn tại chưa (tránh trùng lặp)
        IF NOT EXISTS (SELECT 1 FROM phanquyen.NhanVien WHERE NguoiDungID = @NguoiDungID)
        BEGIN
            -- Tạo họ tên mặc định dựa trên vai trò
            SET @HoTenMacDinh = CASE 
                WHEN @VaiTro = N'Admin' THEN N'Quản trị viên - ' + @TenDangNhap
                ELSE N'Nhân viên - ' + @TenDangNhap
            END;
            
            -- Insert bản ghi NhanVien mới
            INSERT INTO phanquyen.NhanVien (NguoiDungID, HoTen, SoDienThoai, Email, LuongCoBan)
            VALUES (
                @NguoiDungID,
                @HoTenMacDinh,
                NULL,                           -- SoDienThoai mặc định NULL
                NULL,                           -- Email mặc định NULL
                CASE 
                    WHEN @VaiTro = N'Admin' THEN 15000000  -- Lương Admin mặc định
                    ELSE 8000000                          -- Lương NV mặc định
                END
            );
        END
        
        FETCH NEXT FROM cur_NewUsers INTO @NguoiDungID, @TenDangNhap, @VaiTro;
    END
    
    CLOSE cur_NewUsers;
    DEALLOCATE cur_NewUsers;
END;
GO

-- Trigger 2: Tự động cập nhật trạng thái bàn khi hóa đơn thay đổi
-- Mục đích: Đảm bảo trạng thái bàn luôn đồng bộ với trạng thái hóa đơn
-- Tác dụng:
--   - Khi tạo hóa đơn mới (INSERT), tự động cập nhật bàn thành "Có khách"
--   - Khi thanh toán hóa đơn (UPDATE TrangThai = 1), tự động cập nhật bàn thành "Trống" nếu không còn hóa đơn nào đang mở
--   - Khi xóa hóa đơn (DELETE), kiểm tra và cập nhật trạng thái bàn nếu cần
--   - Xử lý cả INSERT, UPDATE và DELETE để đảm bảo tính nhất quán dữ liệu
CREATE OR ALTER TRIGGER [banhang].[trg_AutoUpdateTrangThaiBan]
ON [banhang].[HoaDon]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Xử lý INSERT và UPDATE
        IF EXISTS (SELECT 1 FROM inserted)
        BEGIN
            DECLARE @BanID INT;
            DECLARE @TrangThai TINYINT; -- TrangThai của HoaDon là TINYINT (0, 1, 2)
            
            -- Duyệt qua các hóa đơn được INSERT hoặc UPDATE
            DECLARE cur_HoaDon CURSOR FOR
                SELECT i.BanID, i.TrangThai
                FROM inserted i;
            
            OPEN cur_HoaDon;
            FETCH NEXT FROM cur_HoaDon INTO @BanID, @TrangThai;
            
            WHILE @@FETCH_STATUS = 0
            BEGIN
                -- Cập nhật trạng thái bàn dựa trên trạng thái hóa đơn
                IF @TrangThai = 0 -- Hóa đơn đang mở
                BEGIN
                    UPDATE danhmuc.Ban
                    SET TrangThai = N'Có khách'
                    WHERE BanID = @BanID;
                END
                ELSE IF @TrangThai = 1 -- Hóa đơn đã thanh toán
                BEGIN
                    -- Kiểm tra xem bàn còn hóa đơn nào đang mở không
                    IF NOT EXISTS (
                        SELECT 1 FROM banhang.HoaDon 
                        WHERE BanID = @BanID AND TrangThai = 0
                    )
                    BEGIN
                        UPDATE danhmuc.Ban
                        SET TrangThai = N'Trống'
                        WHERE BanID = @BanID;
                    END
                END
                
                FETCH NEXT FROM cur_HoaDon INTO @BanID, @TrangThai;
            END
            
            CLOSE cur_HoaDon;
            DEALLOCATE cur_HoaDon;
        END
        
        -- Xử lý DELETE
        IF EXISTS (SELECT 1 FROM deleted) AND NOT EXISTS (SELECT 1 FROM inserted)
        BEGIN
            DECLARE @BanIDXoa INT;
            
            DECLARE cur_Deleted CURSOR FOR
                SELECT DISTINCT BanID FROM deleted;
            
            OPEN cur_Deleted;
            FETCH NEXT FROM cur_Deleted INTO @BanIDXoa;
            
            WHILE @@FETCH_STATUS = 0
            BEGIN
                -- Kiểm tra xem bàn còn hóa đơn nào không
                IF NOT EXISTS (
                    SELECT 1 FROM banhang.HoaDon 
                    WHERE BanID = @BanIDXoa AND TrangThai IN (0, 1)
                )
                BEGIN
                    UPDATE danhmuc.Ban
                    SET TrangThai = N'Trống'
                    WHERE BanID = @BanIDXoa;
                END
                
                FETCH NEXT FROM cur_Deleted INTO @BanIDXoa;
            END
            
            CLOSE cur_Deleted;
            DEALLOCATE cur_Deleted;
        END
    END TRY
    BEGIN CATCH
        -- Nếu có lỗi, rollback transaction (nếu đang trong transaction)
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        -- Ném lỗi để người dùng biết
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Trigger 3: Kiểm tra và ngăn chặn xóa khu vực đang có bàn
-- Mục đích: Bảo vệ tính toàn vẹn dữ liệu, ngăn chặn xóa khu vực đang được sử dụng
-- Tác dụng:
--   - Sử dụng INSTEAD OF DELETE để chặn lệnh DELETE trực tiếp
--   - Kiểm tra số lượng bàn trong khu vực trước khi cho phép xóa
--   - Chỉ cho phép xóa khu vực khi không còn bàn nào
--   - Hiển thị thông báo lỗi rõ ràng nếu cố gắng xóa khu vực có bàn
--   - Sử dụng CURSOR để xử lý trường hợp xóa nhiều khu vực cùng lúc
CREATE OR ALTER TRIGGER [danhmuc].[trg_ValidateXoaKhuVuc]
ON [danhmuc].[KhuVuc]
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Kiểm tra các khu vực đang được xóa có bàn nào đang sử dụng không
        DECLARE @KhuVucID INT;
        DECLARE @TenKhuVuc NVARCHAR(100);
        DECLARE @SoBan INT;
        
        DECLARE cur_KhuVuc CURSOR FOR
            SELECT d.KhuVucID, d.TenKhuVuc,
                   (SELECT COUNT(*) FROM danhmuc.Ban WHERE KhuVucID = d.KhuVucID) AS SoBan
            FROM deleted d;
        
        OPEN cur_KhuVuc;
        FETCH NEXT FROM cur_KhuVuc INTO @KhuVucID, @TenKhuVuc, @SoBan;
        
        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Nếu khu vực có bàn thì không cho xóa
            IF @SoBan > 0
            BEGIN
                RAISERROR(N'Không thể xóa khu vực "%s" vì đang có %d bàn!', 16, 1, @TenKhuVuc, @SoBan);
                ROLLBACK TRANSACTION;
                RETURN;
            END
            
            FETCH NEXT FROM cur_KhuVuc INTO @KhuVucID, @TenKhuVuc, @SoBan;
        END
        
        CLOSE cur_KhuVuc;
        DEALLOCATE cur_KhuVuc;
        
        -- Nếu không có bàn nào thì cho phép xóa
        DELETE FROM danhmuc.KhuVuc
        WHERE KhuVucID IN (SELECT KhuVucID FROM deleted);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

/*=================================== 
			  FUNCTION	
===================================*/
-- Tính tổng doanh thu trong một ngày cụ thể
CREATE OR ALTER FUNCTION [baocao].[fn_TinhTongTienNgay]
(
    @Ngay DATE
)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TongDoanhThu DECIMAL(18, 2);
    
    -- Tính tổng tiền từ các hóa đơn đã thanh toán (TrangThai = 1)
    -- trong ngày được chỉ định
    SELECT @TongDoanhThu = ISNULL(SUM(TongThanhToan), 0)
    FROM banhang.HoaDon
    WHERE TrangThai = 1  -- Đã thanh toán
      AND CAST(ThoiDiemThanhToan AS DATE) = @Ngay;
    
    RETURN @TongDoanhThu;
END;
GO

-- Tính doanh thu theo khoảng thời gian
CREATE OR ALTER FUNCTION [baocao].[fn_TinhDoanhThuKhoangThoiGian]
(
    @TuNgay DATE,
    @DenNgay DATE
)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TongDoanhThu DECIMAL(18, 2);
    
    SELECT @TongDoanhThu = ISNULL(SUM(TongThanhToan), 0)
    FROM banhang.HoaDon
    WHERE TrangThai = 1
      AND CAST(ThoiDiemThanhToan AS DATE) BETWEEN @TuNgay AND @DenNgay;
    
    RETURN @TongDoanhThu;
END;
GO

-- Đếm số hóa đơn trong ngày
CREATE OR ALTER FUNCTION [baocao].[fn_DemHoaDonNgay]
(
    @Ngay DATE
)
RETURNS INT
AS
BEGIN
    DECLARE @SoLuong INT;
    
    SELECT @SoLuong = COUNT(*)
    FROM banhang.HoaDon
    WHERE TrangThai = 1
      AND CAST(ThoiDiemThanhToan AS DATE) = @Ngay;
    
    RETURN @SoLuong;
END;
GO

-- Tính doanh thu trung bình mỗi hóa đơn trong ngày
CREATE OR ALTER FUNCTION [baocao].[fn_DoanhThuTrungBinhNgay]
(
    @Ngay DATE
)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TrungBinh DECIMAL(18, 2);
    
    SELECT @TrungBinh = ISNULL(AVG(TongThanhToan), 0)
    FROM banhang.HoaDon
    WHERE TrangThai = 1
      AND CAST(ThoiDiemThanhToan AS DATE) = @Ngay;
    
    RETURN @TrungBinh;
END;
GO

/*===================================
            DỮ LIỆU MẪU
===================================*/

-- 1) Tài khoản người dùng (5 tài khoản)
INSERT INTO phanquyen.NguoiDung (TenDangNhap, MatKhau, VaiTro)
VALUES 
    ('admin', '1', N'Admin'),
    ('nhanvien', '1', N'Nhân viên'),
    ('nhanvien2', '1', N'Nhân viên'),
    ('nhanvien3', '1', N'Nhân viên'),
    ('quanly', '1', N'Admin');
GO

-- Cập nhật thông tin nhân viên (Trigger đã tự động tạo)
UPDATE phanquyen.NhanVien SET HoTen = N'Nguyễn Văn An', SoDienThoai = '0901234567', Email = 'admin@billiards.vn' WHERE NguoiDungID = 1;
UPDATE phanquyen.NhanVien SET HoTen = N'Trần Thị Bình', SoDienThoai = '0912345678', Email = 'binh.tran@billiards.vn' WHERE NguoiDungID = 2;
UPDATE phanquyen.NhanVien SET HoTen = N'Lê Văn Cường', SoDienThoai = '0923456789', Email = 'cuong.le@billiards.vn' WHERE NguoiDungID = 3;
UPDATE phanquyen.NhanVien SET HoTen = N'Phạm Thị Dung', SoDienThoai = '0934567890', Email = 'dung.pham@billiards.vn' WHERE NguoiDungID = 4;
UPDATE phanquyen.NhanVien SET HoTen = N'Hoàng Văn Em', SoDienThoai = '0945678901', Email = 'em.hoang@billiards.vn' WHERE NguoiDungID = 5;
GO

-- 2) Khu vực bàn (5 khu vực)
INSERT INTO danhmuc.KhuVuc (TenKhuVuc, TangSo)
VALUES
    (N'Tầng trệt', 0),
    (N'Lầu 1',     1),
    (N'Khu VIP',   1),
    (N'Lầu 2',     2),
    (N'Khu sân thượng', 3);
GO

-- 3) Loại bàn (4 loại)
INSERT INTO danhmuc.LoaiBan (TenLoai, GiaTheoGio)
VALUES
    (N'Bàn thường',   50000),
    (N'Bàn VIP',      80000),
    (N'Bàn Snooker',  100000),
    (N'Bàn Pool 9 bi', 70000);
GO

-- 4) Bàn (15 bàn phân bố trong các khu vực)
INSERT INTO danhmuc.Ban (TenBan, KhuVucID, LoaiBanID, TrangThai, GhiChu)
VALUES
    -- Tầng trệt (5 bàn)
    (N'Bàn 01', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Tầng trệt'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn thường'), N'Trống', N'Bàn cạnh cửa ra vào'),
    (N'Bàn 02', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Tầng trệt'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn thường'), N'Trống', NULL),
    (N'Bàn 03', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Tầng trệt'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn thường'), N'Trống', NULL),
    (N'Bàn 04', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Tầng trệt'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn Pool 9 bi'), N'Trống', N'Bàn mới'),
    (N'Bàn 05', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Tầng trệt'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn Pool 9 bi'), N'Trống', NULL),
    
    -- Lầu 1 (4 bàn)
    (N'Bàn 06', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Lầu 1'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn thường'), N'Trống', NULL),
    (N'Bàn 07', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Lầu 1'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn VIP'), N'Trống', N'Có điều hòa riêng'),
    (N'Bàn 08', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Lầu 1'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn VIP'), N'Trống', NULL),
    (N'Bàn 09', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Lầu 1'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn Snooker'), N'Trống', N'Bàn lớn 12 feet'),
    
    -- Khu VIP (3 bàn)
    (N'Bàn VIP 01', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Khu VIP'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn Snooker'), N'Trống', N'Phòng riêng có karaoke'),
    (N'Bàn VIP 02', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Khu VIP'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn Snooker'), N'Trống', N'Phòng riêng'),
    (N'Bàn VIP 03', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Khu VIP'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn VIP'), N'Trống', N'View đẹp'),
    
    -- Lầu 2 (2 bàn)
    (N'Bàn 10', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Lầu 2'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn thường'), N'Trống', NULL),
    (N'Bàn 11', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Lầu 2'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn Pool 9 bi'), N'Trống', N'Bàn góc yên tĩnh'),
    
    -- Khu sân thượng (1 bàn)
    (N'Bàn Rooftop', (SELECT KhuVucID FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Khu sân thượng'),
     (SELECT LoaiBanID FROM danhmuc.LoaiBan WHERE TenLoai = N'Bàn VIP'), N'Trống', N'Ngoài trời, chỉ phục vụ buổi tối');
GO

-- 5) Danh mục sản phẩm (5 danh mục)
INSERT INTO danhmuc.DanhMuc (TenDanhMuc)
VALUES
    (N'Thức uống'),
    (N'Đồ ăn nhanh'),
    (N'Snack'),
    (N'Bia - Nước ngọt'),
    (N'Phụ kiện');
GO

-- 6) Sản phẩm (25+ sản phẩm đa dạng)
INSERT INTO danhmuc.SanPham (TenSP, DanhMucID, DonGia, TrangThai)
VALUES
    -- THỨC UỐNG (8 món)
    (N'Cà phê sữa đá', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Thức uống'), 25000, N'Còn'),
    (N'Cà phê đen đá', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Thức uống'), 20000, N'Còn'),
    (N'Trà tắc', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Thức uống'), 20000, N'Còn'),
    (N'Trà đào', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Thức uống'), 30000, N'Còn'),
    (N'Trà sữa trân châu', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Thức uống'), 35000, N'Còn'),
    (N'Sinh tố bơ', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Thức uống'), 35000, N'Còn'),
    (N'Sinh tố xoài', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Thức uống'), 30000, N'Còn'),
    (N'Nước chanh muối', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Thức uống'), 18000, N'Còn'),
    
    -- ĐỒ ĂN NHANH (6 món)
    (N'Mì xào bò', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Đồ ăn nhanh'), 40000, N'Còn'),
    (N'Mì xào hải sản', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Đồ ăn nhanh'), 50000, N'Còn'),
    (N'Cơm chiên dương châu', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Đồ ăn nhanh'), 35000, N'Còn'),
    (N'Bánh mì thịt', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Đồ ăn nhanh'), 25000, N'Còn'),
    (N'Xúc xích nướng', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Đồ ăn nhanh'), 20000, N'Còn'),
    (N'Khoai tây chiên', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Đồ ăn nhanh'), 30000, N'Còn'),
    
    -- SNACK (5 món)
    (N'Bim bim Oishi', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Snack'), 10000, N'Còn'),
    (N'Bắp rang bơ', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Snack'), 15000, N'Còn'),
    (N'Đậu phộng rang', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Snack'), 12000, N'Còn'),
    (N'Khô bò', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Snack'), 25000, N'Còn'),
    (N'Me ngào đường', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Snack'), 15000, N'Còn'),
    
    -- BIA - NƯỚC NGỌT (5 món)
    (N'Bia Tiger', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Bia - Nước ngọt'), 20000, N'Còn'),
    (N'Bia Heineken', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Bia - Nước ngọt'), 25000, N'Còn'),
    (N'Bia Sài Gòn', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Bia - Nước ngọt'), 18000, N'Còn'),
    (N'Coca Cola', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Bia - Nước ngọt'), 15000, N'Còn'),
    (N'Pepsi', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Bia - Nước ngọt'), 15000, N'Còn'),
    (N'7Up', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Bia - Nước ngọt'), 15000, N'Còn'),
    (N'Nước suối', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Bia - Nước ngọt'), 10000, N'Còn'),
    (N'Red Bull', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Bia - Nước ngọt'), 20000, N'Còn'),
    
    -- PHỤ KIỆN (3 món - cho thuê)
    (N'Thuê găng tay', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Phụ kiện'), 10000, N'Còn'),
    (N'Thuê cơ riêng', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Phụ kiện'), 20000, N'Còn'),
    (N'Phấn bida', (SELECT DanhMucID FROM danhmuc.DanhMuc WHERE TenDanhMuc = N'Phụ kiện'), 5000, N'Còn');
GO

-- 7) HÓA ĐƠN LỊCH SỬ (20 hóa đơn trong 30 ngày qua)
DISABLE TRIGGER [banhang].[trg_AutoUpdateTrangThaiBan] ON [banhang].[HoaDon];
GO

-- Insert các hóa đơn đã thanh toán
DECLARE @i INT = 1;
DECLARE @BanID INT;
DECLARE @GioBatDau DATETIME2(0);
DECLARE @GioKetThuc DATETIME2(0);
DECLARE @TongTien DECIMAL(18,2);
DECLARE @NguoiLapID INT;

-- Hóa đơn 1: 7 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (1, 1, 185000, 185000, DATEADD(DAY, -7, DATEADD(HOUR, 14, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -7, DATEADD(HOUR, 16, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 2);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (1, 1, 2, 25000), -- 2 Cà phê sữa đá
    (1, 21, 3, 20000), -- 3 Bia Tiger
    (1, 15, 1, 10000); -- 1 Bim bim

-- Hóa đơn 2: 7 ngày trước (khác bàn, khác ca)
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (3, 1, 420000, 420000, DATEADD(DAY, -7, DATEADD(HOUR, 18, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -7, DATEADD(HOUR, 21, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 3);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (2, 9, 2, 40000), -- 2 Mì xào bò
    (2, 22, 6, 25000), -- 6 Bia Heineken
    (2, 16, 2, 15000), -- 2 Bắp rang
    (2, 18, 1, 25000); -- 1 Khô bò

-- Hóa đơn 3: 6 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (5, 1, 290000, 290000, DATEADD(DAY, -6, DATEADD(HOUR, 15, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -6, DATEADD(HOUR, 18, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 2);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (3, 4, 3, 30000), -- 3 Trà đào
    (3, 14, 2, 30000), -- 2 Khoai tây chiên
    (3, 23, 4, 18000), -- 4 Bia Sài Gòn
    (3, 29, 2, 20000); -- 2 Thuê cơ riêng

-- Hóa đơn 4: 6 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (7, 1, 550000, 550000, DATEADD(DAY, -6, DATEADD(HOUR, 19, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -6, DATEADD(HOUR, 23, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 4);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (4, 10, 3, 50000), -- 3 Mì xào hải sản
    (4, 22, 8, 25000), -- 8 Bia Heineken
    (4, 6, 2, 35000), -- 2 Sinh tố bơ
    (4, 17, 2, 12000); -- 2 Đậu phộng rang

-- Hóa đơn 5: 5 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (2, 1, 160000, 160000, DATEADD(DAY, -5, DATEADD(HOUR, 10, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -5, DATEADD(HOUR, 12, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 2);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (5, 1, 4, 25000), -- 4 Cà phê sữa đá
    (5, 2, 2, 20000), -- 2 Cà phê đen
    (5, 15, 2, 10000); -- 2 Bim bim

-- Hóa đơn 6: 5 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (10, 1, 315000, 350000, DATEADD(DAY, -5, DATEADD(HOUR, 14, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -5, DATEADD(HOUR, 17, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 3);

-- Có giảm giá 10%
UPDATE banhang.HoaDon SET LoaiGiamGia = 1, GiaTriGiam = 10 WHERE HoaDonID = 6;

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (6, 5, 4, 35000), -- 4 Trà sữa
    (6, 11, 2, 35000), -- 2 Cơm chiên
    (6, 24, 4, 15000), -- 4 Coca
    (6, 28, 2, 20000); -- 2 Red Bull

-- Hóa đơn 7: 4 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (8, 1, 450000, 450000, DATEADD(DAY, -4, DATEADD(HOUR, 16, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -4, DATEADD(HOUR, 20, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 2);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (7, 21, 10, 20000), -- 10 Bia Tiger
    (7, 9, 2, 40000), -- 2 Mì xào bò
    (7, 13, 3, 20000), -- 3 Xúc xích
    (7, 18, 2, 25000), -- 2 Khô bò  
    (7, 30, 3, 5000); -- 3 Phấn bida

-- Hóa đơn 8: 4 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (4, 1, 280000, 280000, DATEADD(DAY, -4, DATEADD(HOUR, 20, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -4, DATEADD(HOUR, 23, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 4);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (8, 3, 4, 20000), -- 4 Trà tắc
    (8, 23, 6, 18000), -- 6 Bia Sài Gòn
    (8, 16, 2, 15000), -- 2 Bắp rang
    (8, 12, 2, 25000); -- 2 Bánh mì

-- Hóa đơn 9: 3 ngày trước (cuối tuần - đông khách)
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (9, 1, 680000, 680000, DATEADD(DAY, -3, DATEADD(HOUR, 14, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -3, DATEADD(HOUR, 19, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 2);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (9, 22, 12, 25000), -- 12 Bia Heineken
    (9, 10, 4, 50000), -- 4 Mì xào hải sản
    (9, 14, 3, 30000), -- 3 Khoai tây chiên
    (9, 28, 4, 20000); -- 4 Red Bull

-- Hóa đơn 10: 3 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (11, 1, 350000, 350000, DATEADD(DAY, -3, DATEADD(HOUR, 15, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -3, DATEADD(HOUR, 18, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 3);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (10, 6, 4, 35000), -- 4 Sinh tố bơ
    (10, 9, 3, 40000), -- 3 Mì xào bò
    (10, 17, 3, 12000), -- 3 Đậu phộng
    (10, 29, 3, 20000); -- 3 Thuê cơ riêng

-- Hóa đơn 11: 3 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (6, 1, 210000, 210000, DATEADD(DAY, -3, DATEADD(HOUR, 19, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -3, DATEADD(HOUR, 22, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 4);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (11, 1, 3, 25000), -- 3 Cà phê sữa đá
    (11, 21, 5, 20000), -- 5 Bia Tiger
    (11, 15, 2, 10000), -- 2 Bim bim
    (11, 19, 2, 15000); -- 2 Me ngào đường

-- Hóa đơn 12: 2 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (1, 1, 175000, 175000, DATEADD(DAY, -2, DATEADD(HOUR, 9, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -2, DATEADD(HOUR, 11, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 2);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (12, 2, 5, 20000), -- 5 Cà phê đen
    (12, 8, 3, 18000), -- 3 Nước chanh muối
    (12, 27, 2, 10000); -- 2 Nước suối

-- Hóa đơn 13: 2 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (12, 1, 520000, 520000, DATEADD(DAY, -2, DATEADD(HOUR, 18, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -2, DATEADD(HOUR, 22, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 3);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (13, 22, 10, 25000), -- 10 Bia Heineken
    (13, 9, 2, 40000), -- 2 Mì xào bò
    (13, 10, 2, 50000), -- 2 Mì xào hải sản
    (13, 18, 2, 25000), -- 2 Khô bò
    (13, 30, 4, 5000); -- 4 Phấn bida

-- Hóa đơn 14: 2 ngày trước (có giảm giá theo tiền)
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, LoaiGiamGia, GiaTriGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (3, 1, 380000, 400000, 2, 20000, DATEADD(DAY, -2, DATEADD(HOUR, 20, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -2, DATEADD(HOUR, 23, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 2);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (14, 21, 8, 20000), -- 8 Bia Tiger
    (14, 11, 3, 35000), -- 3 Cơm chiên
    (14, 14, 2, 30000), -- 2 Khoai tây
    (14, 16, 3, 15000); -- 3 Bắp rang

-- Hóa đơn 15: 1 ngày trước (hôm qua)  
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (5, 1, 230000, 230000, DATEADD(DAY, -1, DATEADD(HOUR, 10, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -1, DATEADD(HOUR, 13, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 2);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (15, 4, 4, 30000), -- 4 Trà đào
    (15, 12, 3, 25000), -- 3 Bánh mì
    (15, 24, 3, 15000); -- 3 Coca

-- Hóa đơn 16: 1 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (7, 1, 480000, 480000, DATEADD(DAY, -1, DATEADD(HOUR, 14, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -1, DATEADD(HOUR, 18, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 3);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (16, 22, 8, 25000), -- 8 Bia Heineken
    (16, 10, 3, 50000), -- 3 Mì xào hải sản
    (16, 6, 2, 35000); -- 2 Sinh tố bơ

-- Hóa đơn 17: 1 ngày trước
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (8, 1, 340000, 340000, DATEADD(DAY, -1, DATEADD(HOUR, 19, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -1, DATEADD(HOUR, 22, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 4);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (17, 23, 8, 18000), -- 8 Bia Sài Gòn
    (17, 9, 2, 40000), -- 2 Mì xào bò
    (17, 13, 4, 20000), -- 4 Xúc xích
    (17, 17, 2, 12000); -- 2 Đậu phộng

-- Hóa đơn 18: 1 ngày trước (VIP)
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (10, 1, 720000, 800000, DATEADD(DAY, -1, DATEADD(HOUR, 17, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 
        DATEADD(DAY, -1, DATEADD(HOUR, 23, CAST(CAST(GETDATE() AS DATE) AS DATETIME2))), 2);

-- Giảm 10%
UPDATE banhang.HoaDon SET LoaiGiamGia = 1, GiaTriGiam = 10 WHERE HoaDonID = 18;

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (18, 22, 15, 25000), -- 15 Bia Heineken
    (18, 10, 4, 50000), -- 4 Mì xào hải sản
    (18, 14, 3, 30000), -- 3 Khoai tây
    (18, 28, 5, 20000); -- 5 Red Bull

-- Hóa đơn 19: Hôm nay (đã thanh toán sáng nay)
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (2, 1, 195000, 195000, DATEADD(HOUR, 8, CAST(CAST(GETDATE() AS DATE) AS DATETIME2)), 
        DATEADD(HOUR, 10, CAST(CAST(GETDATE() AS DATE) AS DATETIME2)), 2);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (19, 1, 3, 25000), -- 3 Cà phê sữa đá
    (19, 2, 2, 20000), -- 2 Cà phê đen
    (19, 3, 2, 20000), -- 2 Trà tắc
    (19, 15, 3, 10000), -- 3 Bim bim
    (19, 27, 2, 10000); -- 2 Nước suối

-- Hóa đơn 20: Hôm nay (đã thanh toán trưa)
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, TongTienTruocGiam, ThoiDiemBatDau, ThoiDiemThanhToan, NguoiLapID)
VALUES (4, 1, 275000, 275000, DATEADD(HOUR, 11, CAST(CAST(GETDATE() AS DATE) AS DATETIME2)), 
        DATEADD(HOUR, 13, CAST(CAST(GETDATE() AS DATE) AS DATETIME2)), 3);

INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
VALUES 
    (20, 11, 3, 35000), -- 3 Cơm chiên
    (20, 4, 3, 30000), -- 3 Trà đào
    (20, 25, 4, 15000); -- 4 Pepsi
GO

ENABLE TRIGGER [banhang].[trg_AutoUpdateTrangThaiBan] ON [banhang].[HoaDon];
GO

-- 8) Đồng bộ báo cáo doanh thu cho 7 ngày qua
EXEC baocao.sp_DongBoBaoCao @TuNgay = NULL, @DenNgay = NULL, @GhiDe = 1;
GO


/* =============================================================
   FILE 1 - TẠO LOGIN, USER VÀ ROLE CHO HỆ THỐNG QUÁN BILLIARDS
   CSDL: QuanLyQuanBilliards
   Lưu ý: Mật khẩu chỉ là ví dụ demo, khi triển khai thực tế
          cần thay bằng mật khẩu mạnh.
   ============================================================= */

-- 1. Tạo LOGIN ở mức SQL Server
USE master;
GO

-- Login dành cho tài khoản ADMIN của ứng dụng
CREATE LOGIN App_Billiards_Admin
WITH PASSWORD = 'Admin@123',
     DEFAULT_DATABASE = QuanLyQuanBilliards,
     CHECK_POLICY = ON;
GO

-- Login dành cho tài khoản NHÂN VIÊN của ứng dụng
CREATE LOGIN App_Billiards_Staff
WITH PASSWORD = 'Staff@123',
     DEFAULT_DATABASE = QuanLyQuanBilliards,
     CHECK_POLICY = ON;
GO


-- 2. Tạo user
USE QuanLyQuanBilliards;
GO
-- User tương ứng với Login admin
CREATE USER App_Billiards_Admin
FOR LOGIN App_Billiards_Admin;
GO
-- User tương ứng với Login nhân viên
CREATE USER App_Billiards_Staff
FOR LOGIN App_Billiards_Staff;
GO


-- 3. Tạo các ROLE trong database để gom nhóm quyền
CREATE ROLE dbrole_QuanTri;   -- Role dành cho người quản trị
GO

CREATE ROLE dbrole_NhanVien;  -- Role dành cho nhân viên bán hàng
GO


-- 4. Thêm User vào từng Role tương ứng
EXEC sp_addrolemember 'dbrole_QuanTri',  'App_Billiards_Admin';
EXEC sp_addrolemember 'dbrole_NhanVien', 'App_Billiards_Staff';
GO

/* =============================================================
                        PHÂN QUYỀN
   ============================================================= */

USE QuanLyQuanBilliards;
GO

/* -------------------------------------------------------------
   1. CẤP QUYỀN CHO ROLE QUẢN TRỊ (dbrole_QuanTri)
   ------------------------------------------------------------- */
EXEC sp_addrolemember 'db_owner', 'dbrole_QuanTri';
GO



/* -------------------------------------------------------------
   2. CẤP QUYỀN CHO ROLE NHÂN VIÊN (dbrole_NhanVien)
   - Nhân viên CHỈ được thao tác trên schema banhang
   - Chỉ được SELECT tối thiểu từ danhmuc để load dữ liệu hiển thị
   - KHÔNG được truy cập schema phanquyen và baocao
   ------------------------------------------------------------- */

-- Cho phép SELECT tối thiểu từ danh mục để hiển thị dữ liệu bàn, sản phẩm
-- (chỉ đọc, không được thay đổi danh mục)
GRANT SELECT ON danhmuc.Ban TO dbrole_NhanVien;
GRANT SELECT ON danhmuc.LoaiBan TO dbrole_NhanVien;
GRANT SELECT ON danhmuc.KhuVuc TO dbrole_NhanVien;
GRANT SELECT ON danhmuc.SanPham TO dbrole_NhanVien;
GRANT SELECT ON danhmuc.DanhMuc TO dbrole_NhanVien;
GO

-- Cho phép đầy đủ quyền trên schema banhang (nghiệp vụ chính)
-- Nhân viên được: chọn bàn, order món, tính tiền, thanh toán, hủy hóa đơn
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::banhang TO dbrole_NhanVien;
GO

-- Cho phép gọi các stored procedure trong schema banhang
GRANT EXECUTE ON SCHEMA::banhang TO dbrole_NhanVien;
GO

-- CHẶN hoàn toàn truy cập schema phanquyen (bảo mật tài khoản)
DENY SELECT, INSERT, UPDATE, DELETE, ALTER, REFERENCES
ON SCHEMA::phanquyen TO dbrole_NhanVien;
GO

-- CHẶN hoàn toàn truy cập schema baocao (không được xem báo cáo)
DENY SELECT, INSERT, UPDATE, DELETE, ALTER, REFERENCES
ON SCHEMA::baocao TO dbrole_NhanVien;
GO

-- CHẶN thay đổi cấu trúc danhmuc (chỉ được đọc)
DENY INSERT, UPDATE, DELETE, ALTER, REFERENCES
ON SCHEMA::danhmuc TO dbrole_NhanVien;
GO


/* -------------------------------------------------------------
   3. VÍ DỤ THU HỒI QUYỀN (REVOKE / DENY)
   - Chỉ là ví dụ minh họa, có thể dùng khi cần siết chặt bảo mật.
   ------------------------------------------------------------- */

-- Thu hồi quyền EXECUTE trên schema banhang đối với role nhân viên
-- (khi muốn tạm thời chặn chức năng bán hàng)
/*
REVOKE EXECUTE ON SCHEMA::banhang FROM dbrole_NhanVien;
GO

-- Chặn hẳn thực thi (ưu tiên cao hơn GRANT)
DENY EXECUTE ON SCHEMA::banhang TO dbrole_NhanVien;
GO
*/

-- Thu hồi quyền truy cập tạm thời khi bảo trì
/*
REVOKE SELECT, INSERT, UPDATE, DELETE ON SCHEMA::banhang FROM dbrole_NhanVien;
GO
*/
--REVOKE EXECUTE ON SCHEMA::banhang FROM dbrole_NhanVien;
--GO



/* ===================================================================
   SAO LƯU DỮ LIỆU (BACKUP) - MÔ HÌNH FULL RECOVERY
   Lịch sao lưu:
     - Full Backup       : 23:00 hàng ngày
     - Differential Backup: 15:00 hàng ngày
     - Transaction Log   : Mỗi 30 phút
   =================================================================== */

-- 1) Thiết lập Recovery Model = FULL
USE master;
GO
ALTER DATABASE QuanLyQuanBilliards SET RECOVERY FULL;
GO

-- 2) FULL BACKUP (Chạy lúc 23:00 hàng ngày)
BACKUP DATABASE [QuanLyQuanBilliards]
TO DISK = N'C:\SQLBackup\QuanLyQuanBilliards_FULL.bak'
WITH FORMAT, INIT, NAME = N'Full Backup', COMPRESSION;
GO

-- 3) DIFFERENTIAL BACKUP (Chạy lúc 15:00 hàng ngày)
BACKUP DATABASE [QuanLyQuanBilliards]
TO DISK = N'C:\SQLBackup\QuanLyQuanBilliards_DIFF.bak'
WITH DIFFERENTIAL, INIT, NAME = N'Differential Backup', COMPRESSION;
GO

-- 4) TRANSACTION LOG BACKUP (Chạy mỗi 30 phút)
BACKUP LOG [QuanLyQuanBilliards]
TO DISK = N'C:\SQLBackup\QuanLyQuanBilliards_LOG.trn'
WITH INIT, NAME = N'Transaction Log Backup', COMPRESSION;
GO