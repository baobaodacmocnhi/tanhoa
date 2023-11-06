--select * from ChungTu where MaLCT=15
select Quan=(select TENQUAN from CAPNUOCTANHOA.dbo.QUAN where MAQUAN=t1.Quan)
,Phuong=(select TENPHUONG from CAPNUOCTANHOA.dbo.PHUONG where MAQUAN=t1.Quan and MAPHUONG=t1.PHUONG)
,t1.SoLuong
from 
(select Quan,Phuong,SoLuong=COUNT(*) from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DANHBO in
(select distinct DanhBo from ChungTu_ChiTiet where MaLCT=15 and Cat=0) group by Quan,Phuong
) t1 order by Quan,Phuong


select count (*)*4 from DCBD_DKDM_CCCD where IDDanhBo in
(select ID from
(select *,num=ROW_NUMBER() OVER(PARTITION BY DanhBo ORDER BY CreateDate DESC) 
								 from DCBD_DKDM_DanhBo where CAST(CreateDate as date)>='20220401' and CAST(CreateDate as date)<='20231106'
and thung is not null and DaXuLy=1)t1
where num=1)

--select * from DCBD_DKDM_CCCD where IDDanhBo=24698
select * from ChungTu_ChiTiet where DanhBo='13152175589'

select count(*),sum(dtct.DinhMuc),sum(SoNK)*4 from DonTu dt,DonTu_ChiTiet dtct
where dt.MaDon=dtct.MaDon and dt.Name_NhomDon_PKH like N'định mức' and ((SoCongVan_PhongBanDoi=N'P. Khách Hàng' and VanPhong=1)or(VanPhong=0))
and CAST(dt.CreateDate as date)>='20220401' and CAST(dt.CreateDate as date)<='20231106'