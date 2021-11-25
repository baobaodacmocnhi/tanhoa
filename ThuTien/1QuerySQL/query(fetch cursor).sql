--select * from CTKTXM where DongTienBoiThuong=1 and LapBangGia=0

declare @ID int
declare @STT int
declare @getCursor cursor
set @STT=1
set @getCursor=cursor for select ID from GianLan where YEAR(CreateDate)=2014 order by CreateDate
open @getCursor
fetch next
from @getCursor into @ID
while @@FETCH_STATUS=0
begin
	update GianLan set ID=cast(CAST(STT as char(5))+'14' as int) where ID=@ID 
	fetch next
	from @getCursor into @ID
	set @STT+=1
end
close @getCursor
deallocate @getCursor
