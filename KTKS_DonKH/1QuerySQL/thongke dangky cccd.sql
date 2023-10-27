--0 - 4 m3
select sum(DM) from HOADON_TA.dbo.HOADON where NAM=2023 and ky=10 and DM>=60 and TIEUTHU<=4  and DANHBA not in (select distinct danhbo from KTKS_DonKH.dbo.ChungTu_ChiTiet where cat=0 and MaLCT=15 and CAST(CreateDate as date)<='20231026')
group by GB
order by GB
--and DANHBA not in (select distinct danhbo from KTKS_DonKH.dbo.ChungTu_ChiTiet where cat=0 and MaLCT=15)

--select * from KTKS_DonKH.dbo.ChungTu_ChiTiet where DanhBo='13132116742'

--zalo
--select b.DanhBo,b.IDZalo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b,HOADON_TA.dbo.HOADON hd where a.IDZalo=b.IDZalo and a.Follow=1 and CAST(b.CreateDate as date)<='20231011'
--                                 and DanhBo not in (select t1.DanhBo from (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT = 15 and cat = 0 and CAST(CreateDate as date)<='20231011') t1,HOADON_TA.dbo.HOADON hd
--                                 where hd.NAM = 2023 and hd.ky = 9 and t1.DanhBo = hd.DANHBA and hd.DM >= 40)
--                                 and hd.NAM = 2023 and hd.ky = 9 and b.DanhBo = hd.DANHBA and hd.DM >= 40

								 select b.DanhBo,b.IDZalo from TRUNGTAMKHACHHANG.dbo.Zalo_QuanTam a,TRUNGTAMKHACHHANG.dbo.Zalo_DangKy b,HOADON_TA.dbo.HOADON hd where a.IDZalo=b.IDZalo and a.Follow=1 
                                 and DanhBo not in (select t1.DanhBo from (select distinct DanhBo from KTKS_DonKH.dbo.ChungTu_ChiTiet where MaLCT = 15 and cat = 0 ) t1,HOADON_TA.dbo.HOADON hd
                                 where hd.NAM = 2023 and hd.ky = 10 and t1.DanhBo = hd.DANHBA and hd.DM >= 60)
                                 and hd.NAM = 2023 and hd.ky = 10 and b.DanhBo = hd.DANHBA and hd.DM >= 60