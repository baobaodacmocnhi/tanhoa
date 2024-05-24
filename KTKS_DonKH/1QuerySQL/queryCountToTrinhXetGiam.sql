select * from
(select ttct.CreateDate,DanhBo,HoTen,DiaChi,VeViec,NoiDung,MaDonMoi,STT from ToTrinh tt,ToTrinh_ChiTiet ttct where VeViec like N'%xét giảm%' and YEAR(ttct.CreateDate)>=2022 and tt.ID=ttct.ID)t1,
(select MaDonMoi,STT,KyHD,GiaBieu,GiaBieu_BD,DinhMuc,DinhMuc_BD,TieuThu,TieuThu_BD,GiaDieuChinh from DCBD dc,DCBD_ChiTietHoaDon dchd where dc.MaDCBD=dchd.MaDCBD and TieuThu>=200)t2
where t1.MaDonMoi=t2.MaDonMoi and t1.STT=t2.STT order by t1.CreateDate asc