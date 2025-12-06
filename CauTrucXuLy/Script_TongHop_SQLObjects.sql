/* ================================================================
   SCRIPT T?NG H?P: T?t c? SQL Objects nâng cao
   L?u vào: CauTrucXuLy/Script_TongHop_SQLObjects.sql
   
   Bao g?m:
   1. Stored Procedure: sp_ChuyenBan (Ph?n 1)
   2. Trigger: trg_AutoCreateNhanVien (Ph?n 3)
   3. Functions: fn_TinhTongTienNgay và các function b? sung
   4. Cursor SP: sp_DongBoBaoCao (Ph?n 3)
   
   H??ng d?n: Ch?y toàn b? script này trên SQL Server sau khi
   ?ã t?o database t? file database_QuanLyQuanBilliards.sql
   ================================================================ */

USE QuanLyQuanBilliards;
GO

PRINT N'=== B?T ??U T?O CÁC SQL OBJECTS ===';
PRINT N'';
GO

-- ================================================================
-- 1. STORED PROCEDURE: CHUY?N BÀN
-- ================================================================
PRINT N'[1/4] ?ang t?o SP: banhang.sp_ChuyenBan...';
GO

CREATE OR ALTER PROCEDURE [banhang].[sp_ChuyenBan]
    @BanCu INT,
    @BanMoi INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @HoaDonID INT;
    DECLARE @TrangThaiBanMoi NVARCHAR(20);
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        SELECT @TrangThaiBanMoi = TrangThai 
        FROM danhmuc.Ban 
        WHERE BanID = @BanMoi;
        
        IF @TrangThaiBanMoi IS NULL
        BEGIN
            RAISERROR(N'Bàn ?ích không t?n t?i!', 16, 1);
            RETURN;
        END
        
        IF @TrangThaiBanMoi <> N'Tr?ng'
        BEGIN
            RAISERROR(N'Bàn ?ích không tr?ng, không th? chuy?n!', 16, 1);
            RETURN;
        END
        
        SELECT TOP 1 @HoaDonID = HoaDonID 
        FROM banhang.HoaDon 
        WHERE BanID = @BanCu AND TrangThai = 0;
        
        IF @HoaDonID IS NULL
        BEGIN
            RAISERROR(N'Bàn ngu?n không có hóa ??n ?ang m?!', 16, 1);
            RETURN;
        END
        
        UPDATE banhang.HoaDon SET BanID = @BanMoi WHERE HoaDonID = @HoaDonID;
        UPDATE danhmuc.Ban SET TrangThai = N'Tr?ng' WHERE BanID = @BanCu;
        UPDATE danhmuc.Ban SET TrangThai = N'Có khách' WHERE BanID = @BanMoi;
        
        COMMIT TRANSACTION;
        SELECT 1 AS Success, N'Chuy?n bàn thành công!' AS Message;
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SELECT 0 AS Success, ERROR_MESSAGE() AS Message;
    END CATCH
END;
GO

PRINT N'   ? Hoàn thành SP: banhang.sp_ChuyenBan';
GO

-- ================================================================
-- 2. TRIGGER: T? ??NG T?O NHÂN VIÊN
-- ================================================================
PRINT N'[2/4] ?ang t?o Trigger: phanquyen.trg_AutoCreateNhanVien...';
GO

CREATE OR ALTER TRIGGER [phanquyen].[trg_AutoCreateNhanVien]
ON [phanquyen].[NguoiDung]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @NguoiDungID INT;
    DECLARE @TenDangNhap VARCHAR(50);
    DECLARE @VaiTro NVARCHAR(20);
    DECLARE @HoTenMacDinh NVARCHAR(100);
    
    DECLARE cur_NewUsers CURSOR FOR
        SELECT NguoiDungID, TenDangNhap, VaiTro FROM inserted;
    
    OPEN cur_NewUsers;
    FETCH NEXT FROM cur_NewUsers INTO @NguoiDungID, @TenDangNhap, @VaiTro;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM phanquyen.NhanVien WHERE NguoiDungID = @NguoiDungID)
        BEGIN
            SET @HoTenMacDinh = CASE 
                WHEN @VaiTro = N'Admin' THEN N'Qu?n tr? viên - ' + @TenDangNhap
                ELSE N'Nhân viên - ' + @TenDangNhap
            END;
            
            INSERT INTO phanquyen.NhanVien (NguoiDungID, HoTen, SoDienThoai, Email, LuongCoBan)
            VALUES (
                @NguoiDungID, @HoTenMacDinh, NULL, NULL,
                CASE WHEN @VaiTro = N'Admin' THEN 15000000 ELSE 8000000 END
            );
        END
        
        FETCH NEXT FROM cur_NewUsers INTO @NguoiDungID, @TenDangNhap, @VaiTro;
    END
    
    CLOSE cur_NewUsers;
    DEALLOCATE cur_NewUsers;
END;
GO

PRINT N'   ? Hoàn thành Trigger: phanquyen.trg_AutoCreateNhanVien';
GO

-- ================================================================
-- 3. FUNCTIONS: TÍNH DOANH THU
-- ================================================================
PRINT N'[3/4] ?ang t?o các Functions...';
GO

-- Function: Tính t?ng doanh thu theo ngày
CREATE OR ALTER FUNCTION [baocao].[fn_TinhTongTienNgay](@Ngay DATE)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TongDoanhThu DECIMAL(18, 2);
    SELECT @TongDoanhThu = ISNULL(SUM(TongThanhToan), 0)
    FROM banhang.HoaDon
    WHERE TrangThai = 1 AND CAST(ThoiDiemThanhToan AS DATE) = @Ngay;
    RETURN @TongDoanhThu;
END;
GO

-- Function: Tính doanh thu theo kho?ng th?i gian
CREATE OR ALTER FUNCTION [baocao].[fn_TinhDoanhThuKhoangThoiGian](@TuNgay DATE, @DenNgay DATE)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TongDoanhThu DECIMAL(18, 2);
    SELECT @TongDoanhThu = ISNULL(SUM(TongThanhToan), 0)
    FROM banhang.HoaDon
    WHERE TrangThai = 1 AND CAST(ThoiDiemThanhToan AS DATE) BETWEEN @TuNgay AND @DenNgay;
    RETURN @TongDoanhThu;
END;
GO

-- Function: ??m s? hóa ??n trong ngày
CREATE OR ALTER FUNCTION [baocao].[fn_DemHoaDonNgay](@Ngay DATE)
RETURNS INT
AS
BEGIN
    DECLARE @SoLuong INT;
    SELECT @SoLuong = COUNT(*)
    FROM banhang.HoaDon
    WHERE TrangThai = 1 AND CAST(ThoiDiemThanhToan AS DATE) = @Ngay;
    RETURN @SoLuong;
END;
GO

-- Function: Doanh thu trung bình m?i hóa ??n
CREATE OR ALTER FUNCTION [baocao].[fn_DoanhThuTrungBinhNgay](@Ngay DATE)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TrungBinh DECIMAL(18, 2);
    SELECT @TrungBinh = ISNULL(AVG(TongThanhToan), 0)
    FROM banhang.HoaDon
    WHERE TrangThai = 1 AND CAST(ThoiDiemThanhToan AS DATE) = @Ngay;
    RETURN @TrungBinh;
END;
GO

PRINT N'   ? Hoàn thành 4 Functions báo cáo';
GO

-- ================================================================
-- 4. CURSOR SP: ??NG B? BÁO CÁO DOANH THU
-- ================================================================
PRINT N'[4/4] ?ang t?o SP v?i Cursor: baocao.sp_DongBoBaoCao...';
GO

CREATE OR ALTER PROCEDURE [baocao].[sp_DongBoBaoCao]
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @GhiDe BIT = 1
AS
BEGIN
    SET NOCOUNT ON;
    
    IF @DenNgay IS NULL SET @DenNgay = CAST(GETDATE() AS DATE);
    IF @TuNgay IS NULL SET @TuNgay = DATEADD(MONTH, -1, @DenNgay);
    
    IF @TuNgay > @DenNgay
    BEGIN
        RAISERROR(N'Ngày b?t ??u ph?i nh? h?n ho?c b?ng ngày k?t thúc!', 16, 1);
        RETURN;
    END
    
    DECLARE @NgayHienTai DATE;
    DECLARE @DoanhThuNgay DECIMAL(18, 2);
    DECLARE @SoBaoCaoDaXuLy INT = 0;
    DECLARE @SoBaoCaoCapNhat INT = 0;
    DECLARE @SoBaoCaoThemMoi INT = 0;
    
    DECLARE @DanhSachNgay TABLE (Ngay DATE);
    SET @NgayHienTai = @TuNgay;
    WHILE @NgayHienTai <= @DenNgay
    BEGIN
        INSERT INTO @DanhSachNgay (Ngay) VALUES (@NgayHienTai);
        SET @NgayHienTai = DATEADD(DAY, 1, @NgayHienTai);
    END
    
    -- CURSOR duy?t t?ng ngày
    DECLARE cur_Ngay CURSOR LOCAL FAST_FORWARD FOR
        SELECT Ngay FROM @DanhSachNgay ORDER BY Ngay;
    
    OPEN cur_Ngay;
    FETCH NEXT FROM cur_Ngay INTO @NgayHienTai;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @DoanhThuNgay = baocao.fn_TinhTongTienNgay(@NgayHienTai);
        
        IF EXISTS (SELECT 1 FROM baocao.BaoCao_DoanhThu WHERE TuNgay = @NgayHienTai AND DenNgay = @NgayHienTai)
        BEGIN
            IF @GhiDe = 1
            BEGIN
                UPDATE baocao.BaoCao_DoanhThu
                SET TongDoanhThu = @DoanhThuNgay, NgayLap = SYSDATETIME()
                WHERE TuNgay = @NgayHienTai AND DenNgay = @NgayHienTai;
                SET @SoBaoCaoCapNhat = @SoBaoCaoCapNhat + 1;
            END
        END
        ELSE
        BEGIN
            INSERT INTO baocao.BaoCao_DoanhThu (TuNgay, DenNgay, TongDoanhThu)
            VALUES (@NgayHienTai, @NgayHienTai, @DoanhThuNgay);
            SET @SoBaoCaoThemMoi = @SoBaoCaoThemMoi + 1;
        END
        
        SET @SoBaoCaoDaXuLy = @SoBaoCaoDaXuLy + 1;
        FETCH NEXT FROM cur_Ngay INTO @NgayHienTai;
    END
    
    CLOSE cur_Ngay;
    DEALLOCATE cur_Ngay;
    
    SELECT 
        @SoBaoCaoDaXuLy AS TongSoNgayXuLy,
        @SoBaoCaoThemMoi AS SoBaoCaoThemMoi,
        @SoBaoCaoCapNhat AS SoBaoCaoCapNhat,
        @TuNgay AS TuNgay,
        @DenNgay AS DenNgay,
        N'??ng b? báo cáo thành công!' AS ThongBao;
END;
GO

-- SP b? sung: Xem báo cáo theo ngày
CREATE OR ALTER PROCEDURE [baocao].[sp_XemBaoCaoTheoNgay]
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @DanhSachNgay TABLE (Ngay DATE);
    DECLARE @NgayHienTai DATE = @TuNgay;
    
    WHILE @NgayHienTai <= @DenNgay
    BEGIN
        INSERT INTO @DanhSachNgay (Ngay) VALUES (@NgayHienTai);
        SET @NgayHienTai = DATEADD(DAY, 1, @NgayHienTai);
    END
    
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

PRINT N'   ? Hoàn thành SP v?i Cursor: baocao.sp_DongBoBaoCao';
PRINT N'   ? Hoàn thành SP: baocao.sp_XemBaoCaoTheoNgay';
GO

-- ================================================================
-- HOÀN T?T
-- ================================================================
PRINT N'';
PRINT N'=== HOÀN T?T T?O T?T C? SQL OBJECTS ===';
PRINT N'';
PRINT N'Danh sách ?ã t?o:';
PRINT N'  1. SP: banhang.sp_ChuyenBan';
PRINT N'  2. Trigger: phanquyen.trg_AutoCreateNhanVien';
PRINT N'  3. Function: baocao.fn_TinhTongTienNgay';
PRINT N'  4. Function: baocao.fn_TinhDoanhThuKhoangThoiGian';
PRINT N'  5. Function: baocao.fn_DemHoaDonNgay';
PRINT N'  6. Function: baocao.fn_DoanhThuTrungBinhNgay';
PRINT N'  7. SP (Cursor): baocao.sp_DongBoBaoCao';
PRINT N'  8. SP: baocao.sp_XemBaoCaoTheoNgay';
GO