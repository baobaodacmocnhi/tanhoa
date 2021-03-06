USE [HOADON_TA]
GO
/****** Object:  StoredProcedure [dbo].[spTemp_SyncHoaDon]    Script Date: 07/01/2021 1:35:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spTemp_SyncHoaDon] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @getCursor cursor,@ID int,@Action varchar(10),@Name varchar(10),@Value varchar(10),@MaHD int
	set @getCursor=cursor for select ID,[Action],Name,Value,MaHD from Temp_SyncHoaDon order by CreateDate asc
	
	open @getCursor
	fetch next
	from @getCursor into @ID,@Action,@Name,@Value,@MaHD
	while @@FETCH_STATUS=0
	begin
		if(@Action='DienThoai')
		begin
			exec spSendNotificationToClient @Name,@Value,@MaHD
			delete Temp_SyncHoaDon where ID=@ID
		end
		else
		if(@Action='ThanhToan')
		begin
			exec spSyncThanhToan @MaHD,@Value,@ID,@Name
		end
		fetch next
		from @getCursor into @ID,@Action,@Name,@Value,@MaHD
	end

	close @getCursor
	deallocate @getCursor

END
