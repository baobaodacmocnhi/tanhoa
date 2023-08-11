--select ID_HOADON,* from hoadon where cast(NGAYGIAITRACH as date)='20210329' and SyncNopTien=0 and MaNV_DangNgan is not null
--update HOADON set SOHOADON='CT/20E4999724' where SOHOADON='CT/20E04999724'
declare @ID int
declare @IDTemp int
declare @getCursor cursor
set @getCursor=cursor for SELECT [MaHD],IDTemp=ID
  FROM [HOADON_TA].[dbo].[Temp_SyncHoaDon]
  where Action='thanhtoan' and name='giaitrach' and Value='true'
open @getCursor
fetch next
from @getCursor into @ID,@IDTemp
while @@FETCH_STATUS=0
begin
	--exec dbo.spSyncNopTien @ID
	exec dbo.spSyncThanhToan @ID,'true',@IDTemp,'GiaiTrach'
	fetch next
	from @getCursor into @ID,@IDTemp
end
close @getCursor
deallocate @getCursor