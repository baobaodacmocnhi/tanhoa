declare @ngaygiaitrach date
declare @nam int
declare @ky int
set @ngaygiaitrach='2024-01-01'
set @nam=2022
set @ky=8
--select * from TT_HoaDonCu where NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and not exists (select * from TT_CTChuyenNoKhoDoi where MaHD=ID_HOADON and CAST(CreateDate as date)>=@ngaygiaitrach)
----select NAM,COUNT(*) from HOADON group by NAM

----select * from HOADON where NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and not exists (select * from TT_CTChuyenNoKhoDoi where MaHD=ID_HOADON and CAST(CreateDate as date)>=@ngaygiaitrach)

insert into TT_HoaDonCu select * from HOADON where NAM=@nam and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@ngaygiaitrach and not exists (select * from TT_CTChuyenNoKhoDoi where MaHD=ID_HOADON and CAST(CreateDate as date)>=@ngaygiaitrach)
delete HOADON where NAM=@nam and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@ngaygiaitrach and not exists (select * from TT_CTChuyenNoKhoDoi where MaHD=ID_HOADON and CAST(CreateDate as date)>=@ngaygiaitrach)


--insert into TT_HoaDonCu select * from HOADON where NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@ngaygiaitrach and MaNV_DangNgan is not null and not exists (select * from TT_CTChuyenNoKhoDoi where MaHD=ID_HOADON and CAST(CreateDate as date)>=@ngaygiaitrach)
--delete HOADON where NAM=@nam and KY=@ky and NGAYGIAITRACH is not null and CAST(NGAYGIAITRACH as date)<=@ngaygiaitrach and MaNV_DangNgan is not null and not exists (select * from TT_CTChuyenNoKhoDoi where MaHD=ID_HOADON and CAST(CreateDate as date)>=@ngaygiaitrach)

--cập nhật tiền thuế dvtn
--select * from HOADON_TA.dbo.HOADON where TONGCONG!=GIABAN+THUE+PHI and ThueGTGT_TDVTN is null and nam=2023
--update HOADON_TA.dbo.HOADON set ThueGTGT_TDVTN=TONGCONG-(GIABAN+THUE+PHI) where TONGCONG!=GIABAN+THUE+PHI and ThueGTGT_TDVTN is null and nam=2023

--select * from HOADON_TA.dbo.HOADON where DANHBA='13182551911' and nam=2023 and ky=12
--update HOADON_TA.dbo.HOADON set ThueGTGT_TDVTN=TONGCONG-(GIABAN+THUE+PHI) where DANHBA='13182551911' and nam=2023 and ky=12

--select * from HOADON where nam=2014
--select * from TT_CTChuyenNoKhoDoi where MaHD in (9529399
--,9901137)