--select * from CTKTXM where DongTienBoiThuong=1 and LapBangGia=0

declare @MaHD int
declare @SoHoaDon nvarchar(20)
declare @getCursor cursor

set @getCursor=cursor for select SoHoaDon from TT_TraGop where MaHD=0
open @getCursor
fetch next
from @getCursor into @SoHoaDon
while @@FETCH_STATUS=0
begin
	update TT_TraGop set MaHD=(select ID_HOADON from HOADON where SoHoaDon=@SoHoaDon) where SoHoaDon=@SoHoaDon 
	fetch next
	from @getCursor into @SoHoaDon
end

close @getCursor
deallocate @getCursor
