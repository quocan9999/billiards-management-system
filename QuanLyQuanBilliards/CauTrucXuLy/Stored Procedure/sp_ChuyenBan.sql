/* ================================================================
   SP: Chuyển bàn - Di chuyển hóa đơn đang mở từ bàn cũ sang bàn mới
   Lưu vào: CauTrucXuLy/StoredProcedures/sp_ChuyenBan.sql
   ================================================================ */
USE QuanLyQuanBilliards;
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