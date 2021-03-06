USE [HOADON_TA]
GO
/****** Object:  StoredProcedure [dbo].[spTemp_Insert_HoaDon]    Script Date: 07/01/2021 1:50:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spTemp_Insert_HoaDon]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Nam int,@Ky int,@Dot int
	declare @getCursorA cursor
	set @getCursorA=cursor for select Nam,Ky,Dot from Temp_Insert_HoaDon
	open @getCursorA
	fetch next
	from @getCursorA into @Nam,@Ky,@Dot 
	while @@FETCH_STATUS=0
	begin

		exec spUpdateChiTietTienNuoc @Nam,@Ky,@Dot
		exec spUpdateHieuCoSoThan @Nam,@Ky,@Dot
		exec spUpdateCuaHangThuHo @Nam,@Ky,@Dot
		
		if((select COUNT(ID_HOADON) from HOADON where ChiTietTienNuoc is null and NAM=@Nam and KY=@Ky and DOT=@Dot)=0 and (select COUNT(ID_HOADON) from HOADON where MaNV_HanhThu is null and NAM=@Nam and KY=@Ky and DOT=@Dot)=0)
			delete Temp_Insert_HoaDon where Nam=@Nam and Ky=@Ky and Dot=@Dot

		fetch next
		from @getCursorA into @Nam,@Ky,@Dot 
	end
	close @getCursorA
	deallocate @getCursorA



END
