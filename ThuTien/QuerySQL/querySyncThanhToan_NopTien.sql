select ID_HOADON,* from hoadon where cast(NGAYGIAITRACH as date)='20210322' and SyncNopTien=0

--declare @ID int
--declare @getCursor cursor
--set @getCursor=cursor for select ID_HOADON from hoadon where cast(NGAYGIAITRACH as date)='20210322' and SyncNopTien=0
--open @getCursor
--fetch next
--from @getCursor into @ID
--while @@FETCH_STATUS=0
--begin
--	exec dbo.spSyncNopTien @ID
--	--exec dbo.spSyncThanhToan @ID,'true',NULL,'GiaiTrach'
--	fetch next
--	from @getCursor into @ID
--end
--close @getCursor
--deallocate @getCursor