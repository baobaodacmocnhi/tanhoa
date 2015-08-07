declare @MaNV int;
set @MaNV=5;
select tong.MaNV,Tong,TongDN from
(select CreateBy as MaNV, count(distinct(MaDN)) as Tong
from TT_DongNuoc
where Huy=0 and CreateBy=@MaNV
group by CreateBy) tong
left join
(select dn.CreateBy as MaNV,count(distinct(dn.MaDN)) as TongDN
from TT_DongNuoc dn,TT_KQDongNuoc kqdn
where Huy=0 and dn.MaDN=kqdn.MaDN and dn.CreateBy=@MaNV
group by dn.CreateBy) tongdn on  tong.MaNV=tongdn.MaNV

select dn.CreateBy as MaNV, count(distinct(dn.MaDN)) as Tong,count(case when NGAYGIAITRACH is not null then 1 else 0 end) as TongThu
from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd
where Huy=0 and dn.CreateBy=@MaNV and ctdn.SoHoaDon=hd.SOHOADON and dn.MaDN=ctdn.MaDN
group by dn.CreateBy