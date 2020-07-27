--select b.* from KTXM a, KTXM_ChiTiet b where a.MaKTXM=b.MaKTXM and a.MaDonMoi=20071623
--update KTXM_ChiTiet set STT=2 where MaCTKTXM=1707620

--select * from DonTu_LichSu where MaDon=20071623
--update DonTu_LichSu set STT=2 where MaDon=20071623 and STT=3
select * from DonTu where MaDon=20071623
select * from DonTu_ChiTiet where MaDon=20071623

declare @ID int
declare @STT int
declare @getCursor cursor

set @getCursor=cursor for select ID from DonTu_ChiTiet where MaDon=20071623
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
