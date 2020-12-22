select b.DanhBo,b.HoTen,b.DiaChi,NgayKTXM,NhomDonPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi)
,NhomDonPTV=(select Name_NhomDon from DonTu where MaDon=a.MaDonMoi),VanDeKhac=(select VanDeKhac from DonTu where MaDon=a.MaDonMoi)
,a.MaDonMoi
 from KTXM a,KTXM_ChiTiet b,DonTu_ChiTiet dtct
where a.MaKTXM=b.MaKTXM and CAST(b.NgayKTXM as date)>='20200921' and CAST(b.NgayKTXM as date)<='20201020'
and dtct.MaDon=a.MaDonMoi and dtct.STT=b.STT