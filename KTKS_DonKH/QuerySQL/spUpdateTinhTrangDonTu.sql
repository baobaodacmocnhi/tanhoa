select MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDon)=1) then CONVERT(varchar(10),a.MaDon) else CONVERT(varchar(10),a.MaDon)+'.'+CONVERT(varchar(10),a.STT) end
,TenLD=(select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon),CreateDate,DanhBo,HoTen,DiaChi,GiaBieu,DinhMuc,DinhMucHN
,NoiDungPKH=case when (select Name_NhomDon_PKH from DonTu where MaDon=a.MaDon)!='' then (select Name_NhomDon_PKH from DonTu where MaDon=a.MaDon) else (select VanDeKhac from DonTu where MaDon=a.MaDon) end
,NoiDung=(select Name_NhomDon from DonTu where MaDon=a.MaDon),DienThoai,TinhTrang=(select TinhTrang from DonTu where MaDon=a.MaDon)
from DonTu_ChiTiet a where DanhBo='13152231379'

select * from DonTu_ChiTiet where MaDon=20092061 and STT=3
