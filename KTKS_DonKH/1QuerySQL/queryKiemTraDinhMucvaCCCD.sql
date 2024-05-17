select * from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh
where DINHMUC!=(select sum(SoNKDangKy)*4 from KTKS_DonKH.dbo.ChungTu_ChiTiet where KTKS_DonKH.dbo.ChungTu_ChiTiet.DanhBo=ttkh.DANHBO and cat=0 and (malct=15 or malct=16))
and exists(select * from KTKS_DonKH.dbo.ChungTu_ChiTiet where KTKS_DonKH.dbo.ChungTu_ChiTiet.DanhBo=ttkh.DANHBO and cat=0 and malct=15)