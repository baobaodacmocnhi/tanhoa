USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetHoaDonTon]    Script Date: 03/12/2020 9:05:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER FUNCTION [dbo].[fnGetHoaDonTon]
(	
	-- Add the parameters for the function here
	@DanhBo varchar(11)
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select MaHD=ID_HOADON,SOHOADON,DanhBo=DANHBA,HoTen=TENKH,DiaChi=case when SO is null then DUONG else case when DUONG is null then SO else SO+' '+DUONG end end,NAM,KY,KyHD=(convert(varchar(2),KY)+'/'+convert(varchar(4),NAM))
	,GiaBieu=GB,DinhMuc=DM,TIEUTHU,GIABAN,ThueGTGT=THUE,PhiBVMT=PHI,TONGCONG,ChiTietTienNuoc
	,PhiMoNuoc=(select dbo.fnGetPhiMoNuoc(@DanhBo)),TienDu=(select dbo.fnGetTienDu(@DanhBo))
	,UpdatedHDDT=(select UpdatedHDDT from DIEUCHINH_HD where FK_HOADON=HOADON.ID_HOADON)
	from HOADON where NGAYGIAITRACH is null and DANHBA=@DanhBo and ID_HOADON not in (select MaHD from TT_DichVuThu)
	and ID_HOADON not in (select FK_HOADON from DIEUCHINH_HD,HOADON where CodeF2=1 and NGAYGIAITRACH is null and ID_HOADON=FK_HOADON)
)
