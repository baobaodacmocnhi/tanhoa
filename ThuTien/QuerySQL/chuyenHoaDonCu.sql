select NAM,COUNT(*) from HOADON
group by NAM

select * from HOADON where NAM=2017 and NGAYGIAITRACH is not null

--insert into TT_HoaDonCu select * from HOADON where NAM=2017 and NGAYGIAITRACH is not null
--delete HOADON where NAM=2017 and NGAYGIAITRACH is not null