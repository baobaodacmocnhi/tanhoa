USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetHoaDonTon]    Script Date: 10/03/2021 8:10:41 AM ******/
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
	select MaHD=ID_HOADON,SOHOADON,DanhBo=DANHBA,HoTen=TENKH,DiaChi=case when SO is null then DUONG else case when DUONG is null then SO else SO+' '+DUONG end end,NAM,KY
	,KyHD=(right('0' + ltrim(rtrim(convert(varchar(2),KY))), 2)+'/'+convert(varchar(4),NAM))
	,GiaBieu=GB,DinhMuc=DM,TIEUTHU,GIABAN,ThueGTGT=THUE,PhiBVMT=PHI,TONGCONG,ChiTietTienNuoc
	,PhiMoNuoc=(select dbo.fnGetPhiMoNuoc(@DanhBo)),TienDu=(select dbo.fnGetTienDu(@DanhBo))
	,UpdatedHDDT=(select UpdatedHDDT from DIEUCHINH_HD where FK_HOADON=HOADON.ID_HOADON)
	from HOADON where NGAYGIAITRACH is null and DANHBA=@DanhBo and ID_HOADON not in (select MaHD from TT_DichVuThu)
	--and ((NAM>2020 or (NAM=2020 and Ky>=7)) or (GB!=10 and DinhMucHN is null) or (Nam=2020 and DANHBA in (select DanhBo from TT_ThoatNgheo)))
	and ((NAM>2020 or (NAM=2020 and Ky>=7)) or (GB!=10 and DinhMucHN is null))
	and SOHOADON not in (select SoHoaDon from TT_HoaDon_KhongTHu)
	and ID_HOADON not in (select FK_HOADON from DIEUCHINH_HD,HOADON where CodeF2=1 and NGAYGIAITRACH is null and ID_HOADON=FK_HOADON)
)
