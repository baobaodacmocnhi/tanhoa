select DanhBo=DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,GiaBieu=GB,DinhMuc=DM
,TieuThuKy1=hd.TIEUTHU
,TieuThuKy2=(select TieuThu from HOADON where DANHBA=hd.DANHBA and nam=2022 and ky=2)
,TieuThuKy3=(select TieuThu from HOADON where DANHBA=hd.DANHBA and nam=2022 and ky=3)
from HOADON hd
where gb in(12,14,32,16,36,24) and nam=2022 and ky=1
order by gb,DanhBo