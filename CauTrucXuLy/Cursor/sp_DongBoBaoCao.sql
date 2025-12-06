/* ================================================================
   STORED PROCEDURE với CURSOR: Đồng bộ báo cáo doanh thu
   Lưu vào: CauTrucXuLy/Cursor/sp_DongBoBaoCao.sql
   
   Mục đích: Duyệt từng ngày trong khoảng thời gian chỉ định,
   tính lại doanh thu và cập nhật/insert vào bảng BaoCao_DoanhThu.
   Dùng để fix lỗi dữ liệu báo cáo hoặc tạo báo cáo hàng loạt.
   
   Tham số:
   - @TuNgay DATE: Ngày bắt đầu
   - @DenNgay DATE: Ngày kết thúc (mặc định là hôm nay)
   - @GhiDe BIT: 1 = Ghi đè báo cáo cũ, 0 = Chỉ thêm mới
   ================================================================ */
USE QuanLyQuanBilliards;
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

-- ================================================================
-- STORED PROCEDURE BỔ SUNG: Xem báo cáo doanh thu theo ngày
-- ================================================================
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

-- ================================================================
-- TEST CURSOR PROCEDURE
-- ================================================================
/*
-- Test 1: Đồng bộ báo cáo 7 ngày gần nhất
EXEC baocao.sp_DongBoBaoCao 
    @TuNgay = NULL, 
    @DenNgay = NULL, 
    @GhiDe = 1;

-- Test 2: Đồng bộ báo cáo tháng trước
DECLARE @DauThangTruoc DATE = DATEADD(MONTH, -1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1));
DECLARE @CuoiThangTruoc DATE = DATEADD(DAY, -1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1));
EXEC baocao.sp_DongBoBaoCao @DauThangTruoc, @CuoiThangTruoc, 1;

-- Test 3: Xem báo cáo theo ngày
EXEC baocao.sp_XemBaoCaoTheoNgay '2024-01-01', '2024-01-31';

-- Kiểm tra kết quả
SELECT * FROM baocao.BaoCao_DoanhThu ORDER BY TuNgay DESC;
*/
GO