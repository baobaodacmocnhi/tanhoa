select b.DanhBo,c.MaDonMoi,b.CreateDate from Zalo_EContract_ChiTiet a,KTKS_DonKH.dbo.DCBD_ChiTietBienDong b,KTKS_DonKH.dbo.DCBD c
where a.MaDon=c.MaDonMoi and b.MaDCBD=c.MaDCBD order by c.MaDonMoi