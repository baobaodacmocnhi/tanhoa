select NAM,COUNT(*) from HOADON
group by NAM

select * from HOADON where NAM=2018 and NGAYGIAITRACH is not null and KY=1

--insert into TT_HoaDonCu select * from HOADON where NAM=2018 and NGAYGIAITRACH is not null and KY=1
--delete HOADON where NAM=2018 and NGAYGIAITRACH is not null and KY=1