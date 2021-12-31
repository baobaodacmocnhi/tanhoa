

declare @MaCTKTXM numeric(18, 0)
declare @NgayDongTien datetime
declare @getCursor cursor

set @getCursor=cursor for select MaHD from Temp_SyncHoaDon where [Action]='NopTien' and Result like 'ERR:6%'

open @getCursor
fetch next
from @getCursor into @MaCTKTXM
while @@FETCH_STATUS=0
begin
	EXEC	 [dbo].[spSyncThanhToan]
		@MaHD = @MaCTKTXM,
		@GiaiTrach = N'true',
		@IDTemp_SyncHoaDon = 0,
		@LoaiThanhToan = N'GiaiTrach'
	fetch next
	from @getCursor into @MaCTKTXM
end

close @getCursor
deallocate @getCursor
