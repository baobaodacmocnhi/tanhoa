select * from
(select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT=15 and cat=0) t1,HOADON_TA.dbo.HOADON hd
where hd.NAM=2023 and hd.ky=9 and t1.DanhBo=hd.DANHBA and hd.DM>=4 and hd.DM<=16 and hd.danhba not in
(select danhbo from Zalo_QuanTam a,Zalo_DangKy b where a.IDZalo=b.IDZalo and a.Follow=1)