USE [HOADON_TA]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateCuaHangThuHo]    Script Date: 07/01/2021 4:29:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spUpdateCuaHangThuHo]
	-- Add the parameters for the stored procedure here
	@Nam int,@Ky int,@Dot int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	update HOADON set CuaHangThuHo1=(select top 1 [Name]+': '+DiaChi from TT_DichVuThu_CuaHang where DOT=(select top 1 Dot from HOADON where DANHBA=DanhBo order by CreateDate desc) and MaNV_HanhThu=(select top 1 MaNV_HanhThu from HOADON where DANHBA=DanhBo order by CreateDate desc))
	,CuaHangThuHo2=(select top 1 [Name]+': '+DiaChi from TT_DichVuThu_CuaHang where DOT=(select top 1 Dot from HOADON where DANHBA=DanhBo order by CreateDate desc) and MaNV_HanhThu=(select top 1 MaNV_HanhThu from HOADON where DANHBA=DanhBo order by CreateDate desc) and ID not in((select top 1 ID from TT_DichVuThu_CuaHang where DOT=(select top 1 Dot from HOADON where DANHBA=DanhBo order by CreateDate desc) and MaNV_HanhThu=(select top 1 MaNV_HanhThu from HOADON where DANHBA=DanhBo order by CreateDate desc))))
	where NAM=@Nam and KY=@Ky and DOT=@Dot and MaNV_HanhThu is not null and CuaHangThuHo1 is null

END
