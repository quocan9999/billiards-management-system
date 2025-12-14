USE QuanLyQuanBilliards;
GO


-- =============================================================
-- 1. TEST LỖI: banhang.sp_TinhTienBan
-- Trường hợp: Truyền BanID không tồn tại trong hệ thống
-- Kết quả mong đợi: Procedure trả về kết quả rỗng (không có dữ liệu)
-- =============================================================

EXEC banhang.sp_TinhTienBan @BanID = 9999;


-- =============================================================
-- 2. TEST LỖI: banhang.sp_HuyHoaDon 
-- Trường hợp: Hủy hóa đơn của bàn không có hóa đơn đang mở
-- Kết quả mong đợi: Trả về lỗi "Không tìm thấy hóa đơn đang hoạt động"
-- =============================================================

-- Đảm bảo bàn 1 đang trống
UPDATE danhmuc.Ban SET TrangThai = N'Trống' WHERE BanID = 1;
DELETE FROM banhang.HoaDon WHERE BanID = 1 AND banhang.HoaDon.TrangThai = 0;

EXEC banhang.sp_HuyHoaDon @BanID = 1;
GO

-- =============================================================
-- 3. TEST LỖI: banhang.sp_LayChiTietHoaDon
-- Trường hợp: Lấy chi tiết hóa đơn của bàn không có hóa đơn mở
-- Kết quả mong đợi: Trả về bảng rỗng
-- =============================================================

-- Đảm bảo bàn 1 không có hóa đơn mở
DELETE FROM banhang.HoaDon WHERE BanID = 1 AND banhang.HoaDon.TrangThai = 0;

EXEC banhang.sp_LayChiTietHoaDon @BanID = 1;


-- =============================================================
-- 4. TEST LỖI: banhang.sp_ThanhToanDayDu
-- Trường hợp: Thanh toán với số tiền âm (không hợp lệ)
-- Kết quả mong đợi: Trả về lỗi "Số tiền thanh toán không hợp lệ"
-- =============================================================

-- Tạo hóa đơn tạm để test
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, ThoiDiemBatDau)
VALUES (2, 0, 0, SYSDATETIME());

EXEC banhang.sp_ThanhToanDayDu 
    @BanID = 2, 
    @TongTienCuoiCung = -50000, 
    @TongTienTruocGiam = 100000;

-- Dọn dẹp
DELETE FROM banhang.HoaDon WHERE BanID = 2 AND TrangThai = 0;
UPDATE danhmuc.Ban SET TrangThai = N'Trống' WHERE BanID = 2;


-- =============================================================
-- 5. TEST LỖI: banhang.sp_ChuyenBan
-- Trường hợp: Chuyển đến bàn đang có khách (không trống)
-- Kết quả mong đợi: Trả về lỗi "Bàn đích đang được sử dụng"
-- =============================================================

-- Thiết lập: Bàn 3 có khách, Bàn 4 cũng có khách
UPDATE danhmuc.Ban SET TrangThai = N'Có khách' WHERE BanID = 3;
UPDATE danhmuc.Ban SET TrangThai = N'Có khách' WHERE BanID = 4;

-- Tạo hóa đơn cho bàn 3
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, ThoiDiemBatDau)
VALUES (3, 0, 0, SYSDATETIME());

EXEC banhang.sp_ChuyenBan @BanCu = 3, @BanMoi = 4;

-- Dọn dẹp
DELETE FROM banhang.HoaDon WHERE BanID = 3 AND TrangThai = 0;
UPDATE danhmuc.Ban SET TrangThai = N'Trống' WHERE BanID IN (3, 4);


-- =============================================================
-- 6. TEST LỖI: baocao.sp_BaoCaoDoanhThu
-- Trường hợp: Khoảng ngày không có dữ liệu doanh thu
-- Kết quả mong đợi: Trả về bảng rỗng (không có hóa đơn trong khoảng thời gian)
-- =============================================================

EXEC baocao.sp_BaoCaoDoanhThu @TuNgay = '2000-01-01', @DenNgay = '2000-12-31';

-- =============================================================
-- 7. TEST LỖI: baocao.sp_XemBaoCaoTheoNgay
-- Trường hợp: Khoảng ngày rất xa trong quá khứ
-- Kết quả mong đợi: Trả về dữ liệu với DoanhThu = 0 cho tất cả các ngày
-- =============================================================

EXEC baocao.sp_XemBaoCaoTheoNgay @TuNgay = '2000-01-01', @DenNgay = '2000-01-05';


-- =============================================================
-- 9. TEST LỖI: phanquyen.trg_AutoCreateNhanVien
-- Trường hợp: Insert NguoiDung với vai trò không hợp lệ
-- Kết quả mong đợi: Trigger vẫn chạy nhưng tạo nhân viên với họ tên mặc định
-- Lưu ý: Trigger không validate vai trò, chỉ tạo nhân viên tự động
-- =============================================================
BEGIN TRY
    -- Thử insert user với TenDangNhap đã tồn tại
    INSERT INTO phanquyen.NguoiDung (TenDangNhap, MatKhau, VaiTro)
    VALUES ('admin', '123', N'Admin');
END TRY
BEGIN CATCH
    PRINT N'Lỗi bắt được: ' + ERROR_MESSAGE();
END CATCH

SELECT * FROM phanquyen.NhanVien

-- =============================================================
-- 10. TEST LỖI: banhang.trg_AutoUpdateTrangThaiBan
-- Trường hợp: Insert hóa đơn cho bàn không tồn tại
-- Kết quả mong đợi: Trigger không thể cập nhật trạng thái bàn
-- =============================================================

BEGIN TRY
    INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, ThoiDiemBatDau)
    VALUES (99999, 0, 0, SYSDATETIME());
END TRY
BEGIN CATCH
    PRINT N'Lỗi bắt được: ' + ERROR_MESSAGE();
END CATCH


-- =============================================================
-- 11. TEST LỖI: danhmuc.trg_ValidateXoaKhuVuc
-- Trường hợp: Xóa khu vực đang có bàn
-- Kết quả mong đợi: Trigger chặn và báo lỗi "Không thể xóa khu vực..."
-- =============================================================
SELECT * FROM danhmuc.Ban WHERE KhuVucID = 1
GO

BEGIN TRY
    DELETE FROM danhmuc.KhuVuc WHERE TenKhuVuc = N'Tầng trệt';
END TRY
BEGIN CATCH
    PRINT N'Lỗi bắt được: ' + ERROR_MESSAGE();
END CATCH


-- =============================================================
-- 12. TEST LỖI: baocao.fn_TinhTongTienNgay
-- Trường hợp: Ngày không có doanh thu nào
-- Kết quả mong đợi: Trả về 0 (không có hóa đơn)
-- =============================================================

SELECT baocao.fn_TinhTongTienNgay('2000-01-01') AS DoanhThuNgay;


-- =============================================================
-- 13. TEST LỖI: baocao.fn_TinhDoanhThuKhoangThoiGian
-- Trường hợp: Khoảng thời gian không có doanh thu
-- Kết quả mong đợi: Trả về 0
-- =============================================================

SELECT baocao.fn_TinhDoanhThuKhoangThoiGian('2000-01-01', '2000-12-31') AS DoanhThuKhoang;


-- =============================================================
-- 14. TEST LỖI: baocao.fn_DemHoaDonNgay
-- Trường hợp: Ngày không có hóa đơn nào
-- Kết quả mong đợi: Trả về 0
-- =============================================================

SELECT baocao.fn_DemHoaDonNgay('2000-01-01') AS SoHoaDon;


-- =============================================================
-- 15. TEST LỖI: baocao.fn_DoanhThuTrungBinhNgay
-- Trường hợp: Ngày không có hóa đơn nào
-- Kết quả mong đợi: Trả về 0 (AVG của tập rỗng)
-- =============================================================

SELECT baocao.fn_DoanhThuTrungBinhNgay('2000-01-01') AS TrungBinhNgay;


-- =============================================================
-- 16. TEST LỖI: Vi phạm ràng buộc CHECK trên bảng HoaDonChiTiet
-- Trường hợp: Insert chi tiết hóa đơn với số lượng <= 0
-- Kết quả mong đợi: SQL Server báo lỗi vi phạm constraint CK_HDCT_SoLuong
-- =============================================================
-- Tạo hóa đơn tạm
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, ThoiDiemBatDau)
VALUES (5, 0, 0, SYSDATETIME());

DECLARE @HoaDonID1 INT = (SELECT TOP 1 HoaDonID FROM banhang.HoaDon WHERE BanID = 5 AND TrangThai = 0);

BEGIN TRY
    INSERT INTO banhang.HoaDonChiTiet (HoaDonID, SanPhamID, SoLuong, DonGia)
    VALUES (@HoaDonID1, 1, 0, 25000);
END TRY
BEGIN CATCH
    PRINT N'Lỗi bắt được: ' + ERROR_MESSAGE();
END CATCH

-- Dọn dẹp
DELETE FROM banhang.HoaDon WHERE BanID = 5 AND TrangThai = 0;
UPDATE danhmuc.Ban SET TrangThai = N'Trống' WHERE BanID = 5;


-- =============================================================
-- 17. TEST LỖI: Vi phạm UNIQUE INDEX (chỉ 1 hóa đơn mở/bàn)
-- Trường hợp: Tạo 2 hóa đơn mở cho cùng 1 bàn
-- Kết quả mong đợi: SQL Server báo lỗi vi phạm IX_HoaDon_Ban_Mo
-- =============================================================

-- Tạo hóa đơn đầu tiên cho bàn 6
INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, ThoiDiemBatDau)
VALUES (6, 0, 0, SYSDATETIME());

BEGIN TRY
    -- Thử tạo hóa đơn thứ 2 cho cùng bàn 6
    INSERT INTO banhang.HoaDon (BanID, TrangThai, TongThanhToan, ThoiDiemBatDau)
    VALUES (6, 0, 0, SYSDATETIME());
END TRY
BEGIN CATCH
    PRINT N'Lỗi bắt được: ' + ERROR_MESSAGE();
END CATCH

-- Dọn dẹp
DELETE FROM banhang.HoaDon WHERE BanID = 6 AND TrangThai = 0;
UPDATE danhmuc.Ban SET TrangThai = N'Trống' WHERE BanID = 6;


-- =============================================================
-- 18. TEST LỖI: Vi phạm CHECK trên bảng Ban (TrangThai không hợp lệ)
-- Trường hợp: Cập nhật trạng thái bàn với giá trị không hợp lệ
-- Kết quả mong đợi: SQL Server báo lỗi vi phạm CK_Ban_TrangThai
-- =============================================================
BEGIN TRY
    UPDATE danhmuc.Ban SET TrangThai = N'Đang sửa chữa' WHERE BanID = 1;
END TRY
BEGIN CATCH
    PRINT N'Lỗi bắt được: ' + ERROR_MESSAGE();
END CATCH
