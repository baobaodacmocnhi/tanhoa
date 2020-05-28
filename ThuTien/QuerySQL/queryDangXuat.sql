--select * from CTKTXM where DongTienBoiThuong=1 and LapBangGia=0

declare @MaNV int
declare @getCursor cursor

set @getCursor=cursor for select MaNV from TT_DeviceSigned group by manv

open @getCursor
fetch next
from @getCursor into @MaNV
while @@FETCH_STATUS=0
begin
	exec spSendNotificationToClient 'DangXuat','false',@MaNV
	fetch next
	from @getCursor into @MaNV
end
close @getCursor
deallocate @getCursor
