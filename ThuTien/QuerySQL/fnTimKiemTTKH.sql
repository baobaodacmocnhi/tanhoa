USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[fnTimKiemTTKH]    Script Date: 28/10/2020 9:37:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER function [dbo].[fnTimKiemTTKH]
(
 @HoTen varchar(100),
 @SoNha varchar(20),
 @TenDuong varchar(100)
) returns table
AS return
select DanhBo,MLT=LOTRINH,HoTen,DiaChi=(SONHA+' '+TENDUONG),DiaChiHoaDon from DLKH
where HoTen like N'%'+@HoTen+'%' and ((SONHA like N'%'+@SoNha+'%' and TENDUONG like N'%'+@TenDuong+'%') or (DiaChiHoaDon like N'%'+@SoNha+' '+@TenDuong+'%'))
union
select DanhBo,MLT=LOTRINH,HoTen,DiaChi=(SONHA+' '+TENDUONG),DiaChiHoaDon from DLKH_HUY
where HoTen like N'%'+@HoTen+'%' and ((SONHA like N'%'+@SoNha+'%' and TENDUONG like N'%'+@TenDuong+'%') or (DiaChiHoaDon like N'%'+@SoNha+' '+@TenDuong+'%'))