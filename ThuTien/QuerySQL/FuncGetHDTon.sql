USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetHoaDonTon]    Script Date: 01/07/2020 08:23:16 ******/
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
	select MaHD=ID_HOADON,SOHOADON,DanhBo=DANHBA,HoTen=TENKH,DiaChi=(SO+' '+DUONG),NAM,KY,KyHD=(convert(varchar(2),KY)+'/'+convert(varchar(4),NAM))
	,GiaBieu=GB,DinhMuc=DM,TIEUTHU,GIABAN,ThueGTGT=THUE,PhiBVMT=PHI,TONGCONG
	,PhiMoNuoc=(select dbo.fnGetPhiMoNuoc(@DanhBo)),TienDu=(select dbo.fnGetTienDu(@DanhBo))
	from HOADON where NGAYGIAITRACH is null and DANHBA=@DanhBo and ID_HOADON not in (select MaHD from TT_DichVuThu)
)
