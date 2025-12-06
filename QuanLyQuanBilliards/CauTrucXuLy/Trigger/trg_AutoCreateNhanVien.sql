/* ================================================================
   TRIGGER: Tự động tạo hồ sơ NhanVien khi thêm NguoiDung mới
   Lưu vào: CauTrucXuLy/Trigger/trg_AutoCreateNhanVien.sql
   
   Mục đích: Giải quyết TODO trong database - Khi Insert NguoiDung,
   tự động Insert một bản ghi NhanVien tương ứng.
   ================================================================ */
USE QuanLyQuanBilliards;
GO

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
    
    -- Sử dụng CURSOR để xử lý trường hợp INSERT nhiều dòng cùng lúc
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

-- ================================================================
-- TEST TRIGGER
-- ================================================================
/*
-- Test: Thêm người dùng mới
INSERT INTO phanquyen.NguoiDung (TenDangNhap, MatKhau, VaiTro)
VALUES ('testuser', '123456', N'Nhân viên');

-- Kiểm tra kết quả
SELECT * FROM phanquyen.NguoiDung WHERE TenDangNhap = 'testuser';
SELECT * FROM phanquyen.NhanVien WHERE HoTen LIKE N'%testuser%';

-- Dọn dẹp test data
DELETE FROM phanquyen.NhanVien WHERE HoTen LIKE N'%testuser%';
DELETE FROM phanquyen.NguoiDung WHERE TenDangNhap = 'testuser';
*/
GO