/* ================================================================
   SP: Chuy?n bàn - Chuy?n hóa ??n ?ang m? t? bàn c? sang bàn m?i
   L?u vào: CauTrucXuLy/StoredProcedure/sp_ChuyenBan.sql
   ================================================================ */
USE QuanLyQuanBilliards;
GO

CREATE OR ALTER PROCEDURE [banhang].[sp_ChuyenBan]
    @BanCu INT,
    @BanMoi INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Khai báo bi?n
    DECLARE @HoaDonID INT;
    DECLARE @TrangThaiBanMoi NVARCHAR(20);
    
    -- B?t ??u TRANSACTION
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- 1. Ki?m tra bàn m?i có ?ang tr?ng không
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
        
        -- 2. Tìm hóa ??n ?ang m? (TrangThai = 0) c?a bàn c?
        SELECT TOP 1 @HoaDonID = HoaDonID 
        FROM banhang.HoaDon 
        WHERE BanID = @BanCu AND TrangThai = 0;
        
        IF @HoaDonID IS NULL
        BEGIN
            RAISERROR(N'Bàn ngu?n không có hóa ??n ?ang m?!', 16, 1);
            RETURN;
        END
        
        -- 3. C?p nh?t BanID c?a hóa ??n sang bàn m?i
        UPDATE banhang.HoaDon
        SET BanID = @BanMoi
        WHERE HoaDonID = @HoaDonID;
        
        -- 4. C?p nh?t tr?ng thái bàn c? thành 'Tr?ng'
        UPDATE danhmuc.Ban
        SET TrangThai = N'Tr?ng'
        WHERE BanID = @BanCu;
        
        -- 5. C?p nh?t tr?ng thái bàn m?i thành 'Có khách'
        UPDATE danhmuc.Ban
        SET TrangThai = N'Có khách'
        WHERE BanID = @BanMoi;
        
        -- Commit n?u t?t c? thành công
        COMMIT TRANSACTION;
        
        -- Tr? v? k?t qu? thành công
        SELECT 1 AS Success, N'Chuy?n bàn thành công!' AS Message;
        
    END TRY
    BEGIN CATCH
        -- Rollback n?u có l?i
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        -- Tr? v? l?i
        SELECT 0 AS Success, ERROR_MESSAGE() AS Message;
    END CATCH
END;
GO