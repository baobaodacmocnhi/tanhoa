USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGet12KyHoaDon]    Script Date: 03/04/2019 14:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER function [dbo].[fnGet12KyHoaDon]
(
 @DanhBo char(11)
) returns table
AS return
select top 12 DanhBo=DANHBA,HoTen=TENKH,DiaChi=(SO+' '+DUONG),GiaBieu=GB,DinhMuc=DM,KY,NAM,
KyHD=(convert(varchar(2),KY)+'/'+convert(varchar(4),NAM)),TieuThu,GIABAN,ThueGTGT=THUE,PhiBVMT=PHI,TongCong,NgayGiaiTrach=CONVERT(varchar(10),NgayGiaiTrach,103)
from HOADON where DANHBA=@DanhBo
order by ID_HOADON desc;