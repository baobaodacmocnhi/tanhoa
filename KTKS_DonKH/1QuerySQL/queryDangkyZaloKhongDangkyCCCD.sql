select b.danhbo from Zalo_QuanTam a,Zalo_DangKy b,HOADON_TA.dbo.HOADON hd where a.IDZalo=b.IDZalo and a.Follow=1
and DanhBo not in (select t1.DanhBo from (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0) t1,HOADON_TA.dbo.HOADON hd
where hd.NAM=2023 and hd.ky=9 and t1.DanhBo=hd.DANHBA and hd.DM>=4 and hd.DM<=16)
and hd.NAM=2023 and hd.ky=9 and b.DanhBo=hd.DANHBA and hd.DM>=4 and hd.DM<=16

select b.danhbo from Zalo_QuanTam a,Zalo_DangKy b,HOADON_TA.dbo.HOADON hd where a.IDZalo=b.IDZalo and a.Follow=1
and DanhBo not in (select t1.DanhBo from (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0) t1,HOADON_TA.dbo.HOADON hd
where hd.NAM=2023 and hd.ky=9 and t1.DanhBo=hd.DANHBA and hd.DM>=40)
and hd.NAM=2023 and hd.ky=9 and b.DanhBo=hd.DANHBA and hd.DM>=40