select b.DanhBo,b.DC1+' '+b.DC2 as DiaChiDB,a.MaCT,c.DiaChi as DiaChiCT,a.SoNKDangKy*4 as DinhMucSo
from CTChungTu a, TTKhachHang b,ChungTu c where a.MaCT=c.MaCT and a.DanhBo=b.DanhBo and b.Quan=31
and b.Phuong=02 and a.MaCT like '%SV%'