select count(*),sum(DM) from (select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b where a.IDZalo=b.IDZalo and a.Follow=1)t2,HOADON_TA.dbo.HOADON hd
where DanhBo not in (select t1.DanhBo from (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0) t1,HOADON_TA.dbo.HOADON hd
where hd.NAM=2023 and hd.ky=10 and t1.DanhBo=hd.DANHBA and hd.DM>=20 and hd.DM<=36)
and hd.NAM=2023 and hd.ky=10 and t2.DanhBo=hd.DANHBA and hd.DM>=20 and hd.DM<=36

select count(*),sum(DM) from (select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b where a.IDZalo=b.IDZalo and a.Follow=1)t2,HOADON_TA.dbo.HOADON hd
where DanhBo not in (select t1.DanhBo from (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0) t1,HOADON_TA.dbo.HOADON hd where hd.NAM=2023 and hd.ky=10 and t1.DanhBo=hd.DANHBA and hd.DM>=40)
and hd.NAM=2023 and hd.ky=10 and t2.DanhBo=hd.DANHBA and hd.DM>=40

--không quan tâm zalo
select * from HOADON_TA.dbo.HOADON hd
where DanhBa not in (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0)
and hd.NAM=2023 and hd.ky=10 and hd.DM>=20 and hd.DM<=36 and DANHBA  in (select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b where a.IDZalo=b.IDZalo and a.Follow=1)

--đã nhận đơn
select count(*),sum(ct.DinhMuc)-sum(dt.soNK*4) from
(select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_Send where Loai like '%cccd%' and DanhBo in (select distinct ct.danhbo from KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet ct
where dt.MaDon=ct.MaDon  and CAST(ct.CreateDate as date)>='20231012' and Name_NhomDon like N'%Cấp định mức%'))t1,KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet ct
where dt.MaDon=ct.MaDon and t1.DanhBo=ct.DanhBo and CAST(ct.CreateDate as date)>='20231012' and Name_NhomDon like N'%Cấp định mức%' and ct.DinhMuc<dt.soNK*4

---thống kê đã gửi zalo
select distinct DanhBo,Quan=(select TENQUAN from CAPNUOCTANHOA.dbo.QUAN where MAQUAN=(select Quan from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG.DanhBo=TRUNGTAMKHACHHANG.dbo.Zalo_Send.DanhBo)) from TRUNGTAMKHACHHANG.dbo.Zalo_Send where Loai like '%cccd%' and DanhBo not in (select ct.danhbo from KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet ct
where dt.MaDon=ct.MaDon  and CAST(ct.CreateDate as date)>='20231012' and Name_NhomDon like N'%Cấp định mức%')

select count(*),SUM(DM) from HOADON_TA.dbo.HOADON hd,(select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_Send where Loai like '%cccd%' )t1 where nam=2023 and ky=9  and t1.DanhBo=hd.DANHBA 

select count(*),SUM(DM) from HOADON_TA.dbo.HOADON hd,(select distinct DanhBo from TRUNGTAMKHACHHANG.dbo.Zalo_Send where Loai like '%cccd%' and DanhBo not in (select distinct ct.danhbo from KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet ct
where dt.MaDon=ct.MaDon  and CAST(ct.CreateDate as date)>='20231012' and Name_NhomDon like N'%Cấp định mức%'))t1 where nam=2023 and ky=9 and DM>0 and t1.DanhBo=hd.DANHBA 
---

select count(*),SUM(DM) from HOADON_TA.dbo.HOADON where nam=2023 and ky=10 and danhba in
(select danhba from HOADON_TA.dbo.HOADON where NAM=2023 and ky in (8,9,10) and TIEUTHU=4 and DM>0
group by danhba having count(*)=3)

select count(*),SUM(DM) from HOADON_TA.dbo.HOADON where nam=2023 and ky=10 and danhba in
(select danhba from HOADON_TA.dbo.HOADON where NAM=2023 and ky in (9,10) and TIEUTHU=4 and DM>0
group by danhba having count(*)=2)

select count(*),SUM(DM) from HOADON_TA.dbo.HOADON where nam=2023 and ky=10 and danhba in
(select danhba from HOADON_TA.dbo.HOADON where NAM=2023 and ky in (10) and TIEUTHU=4 and DM>0
group by danhba having count(*)=1)

select danhba,DM=SUM(DM) from HOADON_TA.dbo.HOADON where NAM=2023 and ky in (8,9,10) and TIEUTHU=0 and DM>0
group by danhba having count(*)=3 order by DANHBA
