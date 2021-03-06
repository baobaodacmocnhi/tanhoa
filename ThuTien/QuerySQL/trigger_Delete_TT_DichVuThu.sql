USE [HOADON_TA]
GO
/****** Object:  Trigger [dbo].[trigger_Delete_TT_DichVuThu]    Script Date: 19/01/2021 2:06:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[trigger_Delete_TT_DichVuThu]
ON [dbo].[TT_DichVuThu]
AFTER delete
AS 
BEGIN
    SET NOCOUNT ON;
    
    declare @MaHD int,@SoHoaDon varchar(50),@Nam int,@Ky int,@DCHD bit,@getCursor cursor;
	
	set @getCursor=cursor for select MaHD from deleted
    
    open @getCursor
	fetch next
	from @getCursor into @MaHD
	while @@FETCH_STATUS=0
	begin
		select @MaHD=ID_HOADON,@SoHoaDon=SOHOADON,@Nam=NAM,@Ky=KY,@DCHD=DCHD from HOADON where ID_HOADON=@MaHD
    
		if((@Nam>2020 or (@Nam=2020 and @Ky>=7)) and @DCHD=0)
			--insert into Temp_SyncHoaDon(ID,[Action],Name,Value,MaHD)values((select ID=case when not exists (select ID from Temp_SyncHoaDon) then 1 else MAX(ID)+1 end from Temp_SyncHoaDon),'ThanhToan','ThuHo','false',@MaHD)
			insert into Temp_SyncHoaDon([Action],[Name],[Value],MaHD)values('ThanhToan','ThuHo','false',@MaHD)

		fetch next
		from @getCursor into @MaHD
	end
	close @getCursor
	deallocate @getCursor
    
    

END
