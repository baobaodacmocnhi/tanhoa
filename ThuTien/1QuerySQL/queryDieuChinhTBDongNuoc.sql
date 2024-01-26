
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

--update phimonuoc
select * from TT_DongNuoc dn, TT_KQDongNuoc kq
where dn.MaDN=kq.MaDN and dn.Huy=0 and kq.MoNuoc=0 and kq.TroNgaiMN=0 and kq.Co>25

--update TT_KQDongNuoc set PhiMoNuoc=259000 where MaKQDN in (select MaKQDN from TT_DongNuoc dn, TT_KQDongNuoc kq
--where dn.MaDN=kq.MaDN and dn.Huy=0 and kq.MoNuoc=0 and kq.TroNgaiMN=0 and kq.Co<=25)
--------------------------------------------------------------------------------------------
select MaDN from TT_DongNuoc where MaDN in
(select MaDN from
(select dn.MaDN,SL=count(MaHD) from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON
group by dn.MaDN)t1 where t1.SL!=(select count(*) from HOADON hd1,TT_CTDongNuoc ctdn1 where hd1.ID_HOADON=ctdn1.MaHD and MaNV_DangNgan is null and NGAYGIAITRACH is null and ctdn1.MaDN=t1.MaDN))


--update TT_DongNuoc set MLT=(select lotrinh from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG.DANHBO=TT_DongNuoc.DanhBo)
--where MaDN in (select MaDN from TT_DongNuoc where MaDN in
--(select MaDN from
--(select dn.MaDN,SL=count(MaHD) from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON
--group by dn.MaDN)t1 where t1.SL!=(select count(*) from HOADON hd1,TT_CTDongNuoc ctdn1 where hd1.ID_HOADON=ctdn1.MaHD and MaNV_DangNgan is null and NGAYGIAITRACH is null and ctdn1.MaDN=t1.MaDN)))

--update TT_DongNuoc set CreateBy=(select MaND from TT_NguoiDung where May=SUBSTRING(MLT,3,2))
--where MaDN in (select MaDN from TT_DongNuoc where MaDN in
--(select MaDN from
--(select dn.MaDN,SL=count(MaHD) from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON
--group by dn.MaDN)t1 where t1.SL!=(select count(*) from HOADON hd1,TT_CTDongNuoc ctdn1 where hd1.ID_HOADON=ctdn1.MaHD and MaNV_DangNgan is null and NGAYGIAITRACH is null and ctdn1.MaDN=t1.MaDN)))