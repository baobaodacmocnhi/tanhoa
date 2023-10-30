select b.danhbo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b,HOADON_TA.dbo.HOADON hd where a.IDZalo=b.IDZalo and a.Follow=1
and DanhBo not in (select t1.DanhBo from (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0) t1,HOADON_TA.dbo.HOADON hd
where hd.NAM=2023 and hd.ky=9 and t1.DanhBo=hd.DANHBA and hd.DM>=4 and hd.DM<=16)
and hd.NAM=2023 and hd.ky=9 and b.DanhBo=hd.DANHBA and hd.DM>=4 and hd.DM<=16

select b.danhbo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b,HOADON_TA.dbo.HOADON hd where a.IDZalo=b.IDZalo and a.Follow=1
and DanhBo not in (select t1.DanhBo from (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0) t1,HOADON_TA.dbo.HOADON hd
where hd.NAM=2023 and hd.ky=9 and t1.DanhBo=hd.DANHBA and hd.DM>=40)
and hd.NAM=2023 and hd.ky=9 and b.DanhBo=hd.DANHBA and hd.DM>=40

--đã nhận đơn
select count(*),sum(ct.DinhMuc)-sum(dt.soNK*4) from
(select b.danhbo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b,HOADON_TA.dbo.HOADON hd where a.
=b.IDZalo and a.Follow=1
and DanhBo not in (select t1.DanhBo from (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0 and CAST(CreateDate as date)<='20231012') t1,HOADON_TA.dbo.HOADON hd
where hd.NAM=2023 and hd.ky=9 and t1.DanhBo=hd.DANHBA and hd.DM>=40)
and hd.NAM=2023 and hd.ky=9 and b.DanhBo=hd.DANHBA and hd.DM>=40)t1, KTKS_DonKH.dbo.DonTu dt,KTKS_DonKH.dbo.DonTu_ChiTiet ct
where dt.MaDon=ct.MaDon and t1.DanhBo=ct.DanhBo and CAST(ct.CreateDate as date)>='20231012' and Name_NhomDon like N'%Cấp định mức%' and ct.DinhMuc<dt.soNK*4

select sum(DM) from
(select danhba,DM=SUM(DM) from HOADON_TA.dbo.HOADON where NAM=2023 and ky in (8,9,10) and TIEUTHU=0 and DM>0
group by danhba having count(*)=3)t1