--select * from CTKTXM where DongTienBoiThuong=1 and LapBangGia=0

declare @MaDon int
declare @STT int
declare @getCursor cursor

set @getCursor=cursor for select MaDon,STT from DonTu_ChiTiet where TinhTrang like N'T?n'
and year(createdate)=2020 and month(createdate)=3

open @getCursor
fetch next
from @getCursor into @MaDon,@STT
while @@FETCH_STATUS=0
begin
	exec spUpdateTinhTrang @MaDon,@STT
	fetch next
	from @getCursor into @MaDon,@STT
end

close @getCursor
deallocate @getCursor
