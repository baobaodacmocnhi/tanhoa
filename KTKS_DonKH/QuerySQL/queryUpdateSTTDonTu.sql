select * from DonTu where MaDon=20070131
select * from DonTu_ChiTiet where MaDon=20070131

declare @ID int
declare @STT int
declare @getCursor cursor

set @getCursor=cursor for select ID from DonTu_ChiTiet where MaDon=20070131
set @STT=1
open @getCursor
fetch next
from @getCursor into @ID
while @@FETCH_STATUS=0
begin
	update DonTu_ChiTiet set STT=@STT where ID=@ID
	fetch next
	from @getCursor into @ID
	set @STT+=1
end

close @getCursor
deallocate @getCursor
