/* ================================================================
   FUNCTION: Tính tổng doanh thu trong một ngày cụ thể
   Lưu vào: CauTrucXuLy/Function/fn_TinhTongTienNgay.sql
   
   Mục đích: Trả về tổng doanh thu của tất cả hóa đơn đã thanh toán
   trong một ngày được chỉ định.
   
   Tham số: @Ngay DATE - Ngày cần tính doanh thu
   Trả về: DECIMAL(18,2) - Tổng doanh thu
   ================================================================ */
USE QuanLyQuanBilliards;
GO

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

-- ================================================================
-- CÁC FUNCTION BỔ SUNG HỮU ÍCH
-- ================================================================

-- Function: Tính doanh thu theo khoảng thời gian
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

-- Function: Đếm số hóa đơn trong ngày
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

-- Function: Tính doanh thu trung bình mỗi hóa đơn trong ngày
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

-- ================================================================
-- TEST FUNCTIONS
-- ================================================================
/*
-- Test: Tính doanh thu ngày hôm nay
SELECT baocao.fn_TinhTongTienNgay(CAST(GETDATE() AS DATE)) AS DoanhThuHomNay;

-- Test: Tính doanh thu tháng này
DECLARE @DauThang DATE = DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1);
DECLARE @CuoiThang DATE = EOMONTH(GETDATE());
SELECT baocao.fn_TinhDoanhThuKhoangThoiGian(@DauThang, @CuoiThang) AS DoanhThuThangNay;

-- Test: Đếm hóa đơn hôm nay
SELECT baocao.fn_DemHoaDonNgay(CAST(GETDATE() AS DATE)) AS SoHoaDonHomNay;

-- Test: Doanh thu trung bình hôm nay
SELECT baocao.fn_DoanhThuTrungBinhNgay(CAST(GETDATE() AS DATE)) AS TrungBinhHomNay;
*/
GO