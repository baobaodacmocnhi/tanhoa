select t1.KY,SanLuong=t1.TieuThu+t1.TieuThu_BD-t1.TieuThu_DC,GiaBan=t1.GiaBan-t1.GiaBan_DC from
(select KY,GiaBan=sum(hd.GIABAN),GiaBan_DC=sum(dc.GIABAN_DC),TieuThu=sum(hd.TIEUTHU),TieuThu_BD=sum(dc.TIEUTHU_BD),TieuThu_DC=sum(dc.TIEUTHU_DC) from HOADON hd left join DIEUCHINH_HD dc on dc.FK_HOADON=hd.ID_HOADON
where nam=2023
--and Quan in (22,23)
and Quan in (31)
group by ky)t1