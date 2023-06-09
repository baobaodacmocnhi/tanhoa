declare @ngaygiaitrach date
declare @nam int
declare @ky int
set @ngaygiaitrach='2023-01-01'
set @nam=2021
set @ky=12
--select * from TT_HoaDonCu where NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and not exists (select * from TT_CTChuyenNoKhoDoi where MaHD=ID_HOADON and CAST(CreateDate as date)>=@ngaygiaitrach)
--select NAM,COUNT(*) from HOADON group by NAM

--select * from HOADON where NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and not exists (select * from TT_CTChuyenNoKhoDoi where MaHD=ID_HOADON and CAST(CreateDate as date)>=@ngaygiaitrach)

insert into TT_HoaDonCu select * from HOADON where NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@ngaygiaitrach and MaNV_DangNgan is not null and not exists (select * from TT_CTChuyenNoKhoDoi where MaHD=ID_HOADON and CAST(CreateDate as date)>=@ngaygiaitrach)
delete HOADON where NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@ngaygiaitrach and MaNV_DangNgan is not null and not exists (select * from TT_CTChuyenNoKhoDoi where MaHD=ID_HOADON and CAST(CreateDate as date)>=@ngaygiaitrach)

