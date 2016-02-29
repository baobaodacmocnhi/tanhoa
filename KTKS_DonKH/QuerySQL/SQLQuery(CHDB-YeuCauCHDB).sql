  declare @DanhBo nvarchar(50)
  declare @HopDong nvarchar(50)
  declare @HoTen nvarchar(MAX)
  declare @DiaChi nvarchar(MAX)
  declare @DotLapPhieu nvarchar(50)
  declare @LyDo nvarchar(MAX)
  declare @GhiChuLyDo nvarchar(MAX)
  declare @SoTien int
  declare @HieuLucKy nvarchar(50)
  declare @NguoiKyLapPhieu nvarchar(100)
  declare @ChucVuLapPhieu nvarchar(100)
  declare @NgayLapPhieu datetime
  declare @SoPhieu decimal
  declare @ma decimal
  
  set @ma=7414;
select @DanhBo=DanhBo,@HopDong=HopDong,@HoTen=HoTen,@DiaChi=DiaChi,@LyDo=LyDo,@GhiChuLyDo=GhiChuLyDo,@SoTien=SoTien,
		@DotLapPhieu=DotLapPhieu,@HieuLucKy=HieuLucKy,@NguoiKyLapPhieu=NguoiKyLapPhieu,@ChucVuLapPhieu=ChucVuLapPhieu,
		@NgayLapPhieu=NgayLapPhieu,@SoPhieu=SoPhieu
from CTCHDB where MaCTCHDB=@ma
insert into YeuCauCHDB(MaYCCHDB,DanhBo,HopDong,HoTen,DiaChi,Dot,LyDo,GhiChuLyDo,SoTien,HieuLucKy,PhieuDuocKy,ChucVu,NguoiKy,TBCHDB,MaCTCHDB,CreateDate,Nam,CreateBy)
		values(@SoPhieu,@DanhBo,@HopDong,@HoTen,@DiaChi,@DotLapPhieu,@LyDo,@GhiChuLyDo,@SoTien,@HieuLucKy,1,@ChucVuLapPhieu,@NguoiKyLapPhieu,1,@ma,@NgayLapPhieu,'2014',9)