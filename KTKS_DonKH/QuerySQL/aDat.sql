select STT,dtct.MaDon,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtct.TinhTrang
from DonTu dt,DonTu_ChiTiet dtct where (select COUNT(ID) from DonTu_ChiTiet where MaDon=dt.MaDon)>1
and dt.MaDon=dtct.MaDon and dt.CreateDate>='20201221 09:00' and dt.CreateDate<='20201221 11:00'
