--select * from CTKTXM where DongTienBoiThuong=1 and LapBangGia=0

declare @MaCTKTXM numeric(18, 0)
declare @NgayDongTien datetime
declare @getCursor cursor

set @getCursor=cursor for select MaCTKTXM,NgayDongTien from CTKTXM where DongTienBoiThuong=1 and LapBangGia=0

open @getCursor
fetch next
from @getCursor into @MaCTKTXM,@NgayDongTien
while @@FETCH_STATUS=0
begin
	update CTKTXM set LapBangGia=1,NgayLapBangGia=@NgayDongTien where MaCTKTXM=@MaCTKTXM
	fetch next
	from @getCursor into @MaCTKTXM,@NgayDongTien
end

close @getCursor
deallocate @getCursor
