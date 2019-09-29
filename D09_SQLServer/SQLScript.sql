--29/09/2019
--Tạo view lấy thông tin hàng hóa
CREATE VIEW vHangHoa AS
SELECT MaHH, TenHH, lo.MaLoai, TenLoai, 
	ncc.MaNCC, TenCongTy as TenNhaCC,
	DonGia, MoTaDonVi
FROM HangHoa hh JOIN Loai lo ON lo.MaLoai = hh.MaLoai
	JOIN NhaCungCap ncc ON ncc.MaNCC = hh.MaNCC

SELECT * FROM vHangHoa
WHERE DonGia BETWEEN 50 AND 1000

---PROCEDURE
--CREATE: tạo, ALTER: sửa, DROP: xóa (cấu trúc)
--Viết store proce lấy hàng hóa theo loại & nhà cung cấp
CREATE PROC spLayHangHoa
	@MaLoai int,
	@MaNcc nvarchar(50)
AS BEGIN
	SELECT * FROM vHangHoa
	WHERE MaLoai = @MaLoai AND MaNCC = @MaNcc
END

EXEC spLayHangHoa 1001, 'NK'

--Thêm loại
CREATE PROC spThemLoai
	@MaLoai int OUTPUT,
	@TenLoai nvarchar(50),
	@MoTa nvarchar(MAX),
	@Hinh nvarchar(50)
AS BEGIN
	--Thêm
	INSERT INTO Loai(TenLoai, MoTa, Hinh)
	VALUES(@TenLoai, @MoTa, @Hinh)
	--Lấy giá trị mã loại vừa tăng
	SELECT @MaLoai = @@IDENTITY
END

--Sửa loại
CREATE PROC spSuaLoai
	@MaLoai int,
	@TenLoai nvarchar(50),
	@MoTa nvarchar(MAX),
	@Hinh nvarchar(50)
AS BEGIN
	UPDATE Loai SET TenLoai = @TenLoai, MoTa = @MoTa,
	Hinh = @Hinh WHERE MaLoai = @MaLoai
END

--Xóa loại
CREATE PROC spXoaLoai
	@MaLoai int
AS BEGIN
	DELETE FROM Loai WHERE MaLoai = @MaLoai
END

--Lấy loại
CREATE PROC spLayLoai
	@MaLoai int
AS BEGIN
	IF (@MaLoai IS NULL)
		SELECT * FROM Loai
	ELSE
		SELECT * FROM Loai WHERE MaLoai = @MaLoai
END

EXEC spLayLoai null

--Viết hàm tính doanh số theo khách hàng
ALTER FUNCTION DoanhSoTheoKhachHang
(
	@MaKH nvarchar(20),
	@TuNgay datetime, @DenNgay datetime
)
RETURNS float
AS BEGIN
	DECLARE @DoanhSo float

	SELECT @DoanhSo = SUM(SoLuong * DonGia * (1 - GiamGia))
	FROM ChiTietHD cthd JOIN HoaDon hd ON hd.MaHD = cthd.MaHD
	WHERE MaKH = @MaKH AND NgayDat BETWEEN @TuNgay AND @DenNgay

	RETURN @DoanhSo
END

SELECT dbo.DoanhSoTheoKhachHang('ANTON', '2006-1-1', GETDATE())
SELECT MaKH, HoTen,
dbo.DoanhSoTheoKhachHang(MaKH, '2006-1-1', GETDATE()) DoanhSo
FROM KhachHang 
WHERE dbo.DoanhSoTheoKhachHang(MaKH, '2006-1-1', GETDATE()) IS NOT NULL


--VD function trả về table 1
CREATE FUNCTION LayDoanhThu
( 	@TuNgay datetime, @DenNgay datetime )
RETURNS TABLE
AS RETURN
	SELECT kh.MaKH, kh.HoTen,
		SUM(SoLuong * DonGia * (1 - GiamGia)) as DoanhSo
	FROM ChiTietHD cthd JOIN HoaDon hd ON hd.MaHD = cthd.MaHD
		JOIN KhachHang kh ON kh.MaKH = hd.MaKH
	WHERE NgayDat BETWEEN @TuNgay AND @DenNgay
	GROUP BY kh.MaKH, kh.HoTen

SELECT * FROM dbo.LayDoanhThu('2006-1-1', GETDATE())

--VD function trả về table 2
CREATE FUNCTION DoanhThuTheoNam
( @Nam int)
RETURNS @MyTable TABLE(
		MaHH int, TenHH nvarchar(50), DoanhSo float)
AS BEGIN
	--Xử lý...

	--Chèn dữ liệu vào @MyTable
	INSERT INTO @MyTable
	SELECT hh.MaHH, hh.TenHH,
		SUM(SoLuong * cthd.DonGia * (1 - cthd.GiamGia)) as DoanhSo
	FROM ChiTietHD cthd JOIN HoaDon hd ON hd.MaHD = cthd.MaHD
		JOIN HangHoa hh ON hh.MaHH = cthd.MaHH
	WHERE YEAR(NgayDat) = @Nam
	GROUP BY hh.MaHH, hh.TenHH

	RETURN
END