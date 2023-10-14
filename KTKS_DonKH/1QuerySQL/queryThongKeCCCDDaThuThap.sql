select
SLDiaChiDaThuThap=(select count(distinct DanhBo) from ChungTu_ChiTiet where MaLCT=15 and Cat=0)
,SLDiaChi=(select count(*) from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG)
,TyLeDiaChi=cast((select count(distinct DanhBo) from ChungTu_ChiTiet where MaLCT=15 and Cat=0) as decimal)/(select count(*) from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG)*100
,SLCCCDDaThuThap=(select count(MaCT) from ChungTu_ChiTiet where MaLCT=15 and Cat=0)
,SLDMKy92023=(select SUM(DM) from HOADON_TA.dbo.HOADON where nam=2023 and ky=9)
,TyLeDM=cast((select count(MaCT) from ChungTu_ChiTiet where MaLCT=15 and Cat=0) as decimal)*4/(select SUM(DM) from HOADON_TA.dbo.HOADON where nam=2023 and ky=9)*100