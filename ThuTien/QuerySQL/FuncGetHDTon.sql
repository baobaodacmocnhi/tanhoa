USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetHoaDonTon]    Script Date: 05/03/2019 08:30:43 ******/
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
	from HOADON where NGAYGIAITRACH is null and DANHBA=@DanhBo and SOHOADON not in (select SoHoaDon from TT_DichVuThu)
)
