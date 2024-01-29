select nd.HoTen,t1.SL from TT_NguoiDung nd,
(select MaNV_HanhThu,SL=count(ID_HOADON) from HOADON hd where nam=2024 and ky=1 and TIEUTHU=0 and Quan in(22,23) group by MaNV_HanhThu)t1
where nd.MaND=t1.MaNV_HanhThu order by MaTo asc,STT asc