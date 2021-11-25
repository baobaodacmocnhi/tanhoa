declare @getCursor cursor,@ID int,@Action varchar(10),@Name varchar(10),@Value varchar(10),@MaHD int
	set @getCursor=cursor for select ID_HOADON from HOADON where nam=2020 and ky=6 and cast(ngaygiaitrach as date)='20200608' and MaNV_DangNgan is not null and SyncThanhToan=0
	
	open @getCursor
	fetch next
	from @getCursor into @MaHD
	while @@FETCH_STATUS=0
	begin
		exec spSyncThanhToan @MaHD,'true',0
		fetch next
		from @getCursor into @MaHD
	end

	close @getCursor
	deallocate @getCursor