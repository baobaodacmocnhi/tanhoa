--select * from ChungTu where MaLCT=15
select Quan=(select TENQUAN from CAPNUOCTANHOA.dbo.QUAN where MAQUAN=t1.Quan)
,Phuong=(select TENPHUONG from CAPNUOCTANHOA.dbo.PHUONG where MAQUAN=t1.Quan and MAPHUONG=t1.PHUONG)
,t1.SoLuong
from 
(select Quan,Phuong,SoLuong=COUNT(*) from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DANHBO in
(select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and Cat=0) group by Quan,Phuong
) t1 order by Quan,Phuong


select count (*)*4 from KTKS_DonKH.dbo.DCBD_DKDM_CCCD where IDDanhBo in
(select ID from
(select *,num=ROW_NUMBER() OVER(PARTITION BY DanhBo ORDER BY CreateDate DESC) 
								 from KTKS_DonKH.dbo.DCBD_DKDM_DanhBo where CAST(CreateDate as date)>='20220401' and CAST(CreateDate as date)<='20231106'
and thung is not null and DaXuLy=1)t1
where num=1)

select * from KTKS_DonKH.dbo.ChungTu_ChiTiet where DanhBo='13152175589'

select count(*),sum(dtct.DinhMuc),sum(SoNK)*4 from KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet dtct
where dt.MaDon=dtct.MaDon and dt.Name_NhomDon_PKH like N'định mức' and ((SoCongVan_PhongBanDoi=N'P. Khách Hàng' and VanPhong=1)or(VanPhong=0))
and CAST(dt.CreateDate as date)>='20220401' and CAST(dt.CreateDate as date)<='20231106'

select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0 and CAST(CreateDate as date)<='20231106'


---------------------------------------
--zalo
select count(*),sum(DM) from (select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b where a.IDZalo=b.IDZalo and a.Follow=1)t2,HOADON_TA.dbo.HOADON hd
where DanhBo not in (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0)
and hd.NAM=2023 and hd.ky=10 and t2.DanhBo=hd.DANHBA and hd.DM>=20 and hd.DM<=36

select count(*),sum(DM) from (select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b where a.IDZalo=b.IDZalo and a.Follow=1)t2,HOADON_TA.dbo.HOADON hd
where DanhBo not in (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT = 15 and cat = 0)
and hd.NAM=2023 and hd.ky=10 and t2.DanhBo=hd.DANHBA and hd.DM>=40

--không quan tâm zalo
select Quan=(select TENQUAN from CAPNUOCTANHOA.dbo.QUAN where MAQUAN=Quan)
,Phuong=(select TENPHUONG from CAPNUOCTANHOA.dbo.PHUONG where MAQUAN=Quan and MAPHUONG=PHUONG),* from HOADON_TA.dbo.HOADON hd
where DanhBa not in (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0)
and hd.NAM=2024 and hd.ky=3 and hd.DM>=32 and hd.DM<=36 and DANHBA not  in (select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b where a.IDZalo=b.IDZalo and a.Follow=1)

select hd.DM,Tong=count(hd.DANHBA)
from HOADON_TA.dbo.HOADON hd
where DanhBa not in (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0)
and hd.NAM=2024 and hd.ky=2 and hd.DM>=4 and hd.DM<=36 and DANHBA not  in (select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b where a.IDZalo=b.IDZalo and a.Follow=1)
group by hd.dm
order by hd.dm

--gửi zalo
select b.DanhBo,b.IDZalo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b,HOADON_TA.dbo.HOADON hd where a.IDZalo=b.IDZalo and a.Follow=1
                                 and hd.NAM = 2023 and hd.ky = 11 and b.DanhBo = hd.DANHBA and hd.DM >= 40
								 and DanhBo not in (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT = 15 and cat = 0)
								 and DanhBo not in (select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_Send where Loai like '%cccd%' and DanhBo in (select distinct ct.danhbo from KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet ct
where dt.MaDon=ct.MaDon  and CAST(ct.CreateDate as date)>='20231012' and Name_NhomDon_PKH like N'%định mức%'))

select hd.DANHBA from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b,HOADON_TA.dbo.HOADON hd where a.IDZalo=b.IDZalo and a.Follow=1
								and hd.NAM = 2023 and hd.ky = 11 and b.DanhBo = hd.DANHBA and hd.DM >= 40
                                 and b.DanhBo not in (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT = 15 and cat = 0)
								 and b.DanhBo  in (select distinct ct.DanhBo from KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet ct
where dt.MaDon=ct.MaDon  and CAST(ct.CreateDate as date)>='20231012' and dt.Name_NhomDon_PKH like N'%định mức%')


--danh sách đã gửi
select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_Send where Loai like '%cccd%' and CAST(CreateDate as date)='20231108'

--đã nhận đơn
select count(*),sum(ct.DinhMuc)-sum(dt.soNK*4) from
(select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_Send where Loai like '%cccd%' and DanhBo in (select distinct ct.danhbo from KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet ct
where dt.MaDon=ct.MaDon  and CAST(ct.CreateDate as date)>='20231012' and Name_NhomDon_PKH like N'%định mức%'))t1,KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet ct
where dt.MaDon=ct.MaDon and t1.DanhBo=ct.DanhBo and CAST(ct.CreateDate as date)>='20231012' and Name_NhomDon_PKH like N'%định mức%' and ct.DinhMuc<dt.soNK*4

---thống kê đã gửi zalo
select distinct DanhBo,Quan=(select TENQUAN from CAPNUOCTANHOA.dbo.QUAN where MAQUAN=(select Quan from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG.DanhBo=TRUNGTAMKHACHHANG.dbo.Zalo_Send.DanhBo)) from TRUNGTAMKHACHHANG.dbo.Zalo_Send where Loai like '%cccd%' and DanhBo not in (select ct.danhbo from KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet ct
where dt.MaDon=ct.MaDon  and CAST(ct.CreateDate as date)>='20231012' and Name_NhomDon_PKH like N'%định mức%')

select count(*),SUM(DM) from HOADON_TA.dbo.HOADON hd,(select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_Send where Loai like '%cccd%' )t1 where nam=2023 and ky=9  and t1.DanhBo=hd.DANHBA 

select count(*),SUM(DM) from HOADON_TA.dbo.HOADON hd,(select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_Send where Loai like '%cccd%' and DanhBo not in (select distinct ct.danhbo from KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet ct
where dt.MaDon=ct.MaDon  and CAST(ct.CreateDate as date)>='20231012' and Name_NhomDon_PKH like N'%định mức%'))t1 where nam=2023 and ky=11 and DM>0 and t1.DanhBo=hd.DANHBA 
---

select count(*),SUM(DM) from HOADON_TA.dbo.HOADON where nam=2023 and ky=10 and danhba in
(select danhba from HOADON_TA.dbo.HOADON where NAM=2023 and ky in (8,9,10) and TIEUTHU=4 and DM>0
group by danhba having count(*)=3)

select count(*),SUM(DM) from HOADON_TA.dbo.HOADON where nam=2023 and ky=10 and danhba in
(select danhba from HOADON_TA.dbo.HOADON where NAM=2023 and ky in (9,10) and TIEUTHU=4 and DM>0
group by danhba having count(*)=2)

select count(*),SUM(DM) from HOADON_TA.dbo.HOADON where nam=2023 and ky=10 and danhba in
(select danhba from HOADON_TA.dbo.HOADON where NAM=2023 and ky in (10) and TIEUTHU=1 and DM>0
group by danhba having count(*)=1)

select danhba,DM=SUM(DM) from HOADON_TA.dbo.HOADON where NAM=2023 and ky in (8,9,10) and TIEUTHU=0 and DM>0
group by danhba having count(*)=3 order by DANHBA

--danh sách tiêu thụ 0-4m3
select t1.* from
(select DOT,DANHBA,TENKH,SO,DUONG,GB,DM,DinhMucHN,TIEUTHU,Quan=(select TENQUAN from CAPNUOCTANHOA.dbo.QUAN where MAQUAN=Quan)
,Phuong=(select TENPHUONG from CAPNUOCTANHOA.dbo.PHUONG where MAQUAN=Quan and MAPHUONG=PHUONG)
from HOADON_TA.dbo.HOADON where GB!=10 and DM>4 and TIEUTHU>=1 and TIEUTHU<=4 and NAM=2023 and ky=10 and DOT>=14 and DOT<=20
and DANHBA not in (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT = 15 and cat = 0))t1

order by DOT

select distinct ct.danhbo from KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet ct
where dt.MaDon=ct.MaDon  and CAST(ct.CreateDate as date)>='20231012' and Name_NhomDon_PKH like N'%định mức%'

--check chứng từ
select * from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT = 15 and cat = 0 and DanhBo='13101690659'
-----------------------------------------------
--count giá biểu
select count(*),SUM(DM) from HOADON_TA.dbo.HOADON where nam=2023 and ky=10 and gb=15 and DM>0
and DANHBA not in (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0)

select count(MaCT) from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0 and DanhBo in
(select sum(DM) from HOADON_TA.dbo.HOADON where nam=2023 and ky=10 and gb in (59,21,51,68) and DM>0)

--TieuThu<DM
select * from
(select DANHBA,DM=case when exists(select dc.DinhMuc from HOADON hd,DIEUCHINH_HD dc
where hd.ID_HOADON=dc.FK_HOADON and hd.ID_HOADON=hd2.ID_HOADON) then (select dc.DinhMuc from HOADON hd,DIEUCHINH_HD dc
where hd.ID_HOADON=dc.FK_HOADON and hd.ID_HOADON=hd2.ID_HOADON) else hd2.DM end,TIEUTHU from HOADON hd2 where nam=2023 and ky=11 and DM>=40
and DANHBA not in (select DanhBo from KTKS_DonKH.dbo.DCBD_ChiTietBienDong where HieuLucKy like '%12/2023%' and ThongTin like N'%Định Mức%'))t1
where t1.DM>t1.TIEUTHU and DM-TIEUTHU>=4
order by t1.DANHBA

insert into KTKS_DonKH.dbo.DieuChinhHangLoat(DanhBo,Nam,Ky,Dot,DinhMuc,TieuThu,DCBD)
select DanhBo=DanhBa,Nam,Ky,Dot,DinhMuc=DM,TieuThu=TieuThuMoi,DCBD=cast(1 as bit) from DocSoTH.dbo.DocSo
where Nam=2023 and Ky=12 and Dot=19 and TieuThuMoi>=0 and DM-TieuThuMoi>=4 and GB not in (21,51,59,68)
and DanhBa not in (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where Cat=0 and MaLCT=15)
and DanhBa not in (select b.DanhBo from KTKS_DonKH.dbo.DonTu a,KTKS_DonKH.dbo.DonTu_ChiTiet b 
where a.MaDon=b.MaDon and (a.Name_NhomDon_PKH like N'%định mức%' or a.Name_NhomDon like N'%định mức%'
or a.Name_NhomDon like N'%thông tin khách hàng%' ) and CAST(a.CreateDate as date)>='20231101')

select DanhBo,DinhMuc,DinhMuc_BD,GiaBieu,Code=(select CodeMoi from DocSoTH.dbo.DocSo where DanhBa=DanhBo and nam=2023 and ky=12)
from KTKS_DonKH.dbo.DCBD_ChiTietBienDong where CreateBy=74  and CAST(CreateDate as date)>='20231220' and dot=13

--thông tin send zalo
select *
,Avatar=(select Avatar from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam where IDZalo=s.IDZalo)
,Name=(select Name from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam where IDZalo=s.IDZalo)
,CreateDate=(select CreateDate from TRUNGTAMKHACHHANG.dbo.Zalo_DangKy where IDZalo=s.IDZalo and DanhBo=s.DanhBo)
from TRUNGTAMKHACHHANG.dbo.Zalo_Send s
where DanhBo='13141983452' and Loai='thongbaocccd' 

--danh sách gửi tin nhắn nhưng chưa liên hệ 4/2024
            select * from
(select * from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG)t1,
(select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_Send where Loai='thongbaocccd' and CAST(CreateDate as date)>='20240403')t2
where t1.DANHBO=t2.DanhBo and SUBSTRING(t1.LOTRINH,1,2)<=5 and t1.DINHMUC>0
and t1.DANHBO not in (select dtct.DanhBo from KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet dtct where dt.MaDon=dtct.MaDon
and ((CAST(dtct.CreateDate as date)>='20240404')or(dt.ID_NhomDon like '%23%' and CAST(dtct.CreateDate as date)>='20230101')or(dt.ID_NhomDon_PKH like '%7%' and CAST(dtct.CreateDate as date)>='20231201')))
and t1.DANHBO not in (select DanhBo from KTKS_DonKH.dbo.DCBD_DKDM_DanhBo where CAST(CreateDate as date)>='20240404')
and t1.DanhBo not in (select distinct DanhBo from KTKS_DonKH.dbo.DCBD_ChiTietBienDong where HieuLucKy in ('12/2023','01/2024','02/2024','03/2024','04/2024','05/2024','06/2024','07/2024','08/2024'))
and t1.DanhBo not in (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT = 15 and cat = 0)