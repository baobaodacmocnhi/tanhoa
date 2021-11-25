declare @nam int;
declare @ky int;
set @nam=2015;
set @ky=7;
select tong.MaND,tong.HoTen,TongHD,TongGiaBan,TongCong,TongHDThu,TongGiaBanThu,TongCongThu,TongHDTon,TongGiaBanTon,TongCongTon
from 
(select nd.MaND,nd.HoTen,count(DANHBA) as TongHD,sum(GIABAN) as TongGiaBan,sum(hd.TONGCONG) as TongCong
from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND
where NAM=@nam and KY=@ky
group by nd.MaND,nd.HoTen,KY,NAM) tong
left join
(select nd.MaND,nd.HoTen,count(DANHBA) as TongHDTon,sum(GIABAN) as TongGiaBanTon,sum(hd.TONGCONG) as TongCongTon
from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND
where NAM=@nam and KY=@ky and NGAYGIAITRACH is null
group by nd.MaND,nd.HoTen,KY,NAM) ton on tong.MaND=ton.MaND
left join
(select nd.MaND,nd.HoTen,count(DANHBA) as TongHDThu,sum(GIABAN) as TongGiaBanThu,sum(hd.TONGCONG) as TongCongThu
from HOADON hd left join TT_NguoiDung nd on hd.MaNV_HanhThu = nd.MaND
where NAM=@nam and KY=@ky and NGAYGIAITRACH is not null
group by nd.MaND,nd.HoTen,KY,NAM) thu on tong.MaND=thu.MaND
order by tong.MaND asc