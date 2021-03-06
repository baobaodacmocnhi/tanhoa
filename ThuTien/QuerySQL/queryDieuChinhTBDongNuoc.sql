
declare @MaDN int
declare @getCursor cursor
set @getCursor=cursor for select distinct top 20 dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd
where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON
and CAST(hd.NGAYGIAITRACH as date)>='20201201' and YEAR(hd.NGAYGIAITRACH)=2020  and hd.MaNV_DangNgan=14
and not exists(select * from TT_KQDongNuoc where MaDN=dn.MaDN)
and (select COUNT(*) from TT_CTDongNuoc where MaDN=dn.MaDN)=(select COUNT(*) from TT_CTDongNuoc a,HOADON b where a.MaHD=b.ID_HOADON and MaDN=dn.MaDN and NGAYGIAITRACH is not null)
and (select COUNT(*) from TT_CTDongNuoc where MaDN=dn.MaDN)=2
open @getCursor
fetch next
from @getCursor into @MaDN
while @@FETCH_STATUS=0
begin
	delete TT_CTDongNuoc where MaDN=@MaDN
	delete TT_DongNuoc where MaDN=@MaDN
	fetch next
	from @getCursor into @MaDN
end
close @getCursor
deallocate @getCursor

select distinct dn.DanhBo,dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd
where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON
and CAST(NGAYGIAITRACH as date)>='20201201' and CAST(NGAYGIAITRACH as date)<='20201231' and MaNV_DongNuoc=14 and MaNV_DangNgan!=14
and  exists(select * from TT_KQDongNuoc where MaDN=dn.MaDN)
--and (select COUNT(*) from TT_CTDongNuoc where MaDN=dn.MaDN)=(select COUNT(*) from TT_CTDongNuoc a,HOADON b where a.MaHD=b.ID_HOADON and MaDN=dn.MaDN and NGAYGIAITRACH is not null)
--and (select COUNT(*) from TT_CTDongNuoc where MaDN=dn.MaDN)=1