--select * from CTKTXM where DongTienBoiThuong=1 and LapBangGia=0

declare @danhbo nvarchar(1000)
declare @mact nvarchar(1000)
declare @sophieu int
declare @getCursor cursor

set @getCursor=cursor for select  DanhBo,MaCT,SoPhieu from ChungTu_ChiTiet where SoPhieu is not null and CAST(CreateDate as date)='20240620' and SoPhieu not in (select SoPhieu from ChungTu_LichSu where SoPhieu is not null)

open @getCursor
fetch next
from @getCursor into @danhbo,@mact,@sophieu
while @@FETCH_STATUS=0
begin
	declare @Ma int
	declare @MaNext varchar(10)
                        select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50),MaLSCT),LEN(CONVERT(nvarchar(50),MaLSCT))-1,2)) from ChungTu_LichSu
                        select @Ma=MAX(MaLSCT) from ChungTu_LichSu where SUBSTRING(CONVERT(nvarchar(50),MaLSCT),LEN(CONVERT(nvarchar(50),MaLSCT))-1,2)=@Ma
						select @MaNext=cast(SUBSTRING(cast(@Ma as varchar),0,6)+1 as varchar)+'24'
						INSERT INTO [dbo].[ChungTu_LichSu]
           ([MaLSCT]
           ,[DanhBo]
           ,[Quan]
           ,[Phuong]
           ,[MaCT]
           ,[MaLCT]
           ,[Lo]
           ,[Phong]
           ,[SoNKTong]
           ,[SoNKDangKy]
           ,[SoNKConLai]
           ,[ThoiHan]
           ,[NgayHetHan]
           ,[SoPhieu]
           ,[NhanNK_MaCN]
           ,[NhanNK_DanhBo]
           ,[NhanNK_HoTen]
           ,[NhanNK_DiaChi]
           ,[CatDM]
           ,[NhanDM]
           ,[YeuCauCat]
           ,[SoNK]
           ,[CatNK_MaCN]
           ,[CatNK_DanhBo]
           ,[CatNK_HoTen]
           ,[CatNK_HoTens]
           ,[CatNK_DiaChi]
           ,[NguoiKy]
           ,[ChucVu]
           ,[PhieuDuocKy]
           ,[CreateDate]
           ,[CreateBy])
     VALUES
           (@MaNext
           ,@danhbo
           ,(select quan from ChungTu_ChiTiet where SoPhieu=@sophieu)
           ,(select Phuong from ChungTu_ChiTiet where SoPhieu=@sophieu)
           ,@mact
           ,15
           ,(select lo from ChungTu_ChiTiet where SoPhieu=@sophieu)
           ,(select phong from ChungTu_ChiTiet where SoPhieu=@sophieu)
           ,1
           ,1
           ,1
           ,(select ThoiHan from ChungTu_ChiTiet where SoPhieu=@sophieu)
           ,(select NgayHetHan from ChungTu_ChiTiet where SoPhieu=@sophieu)
           ,@sophieu
           ,1
           ,@danhbo
           ,(select HOTEN from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DANHBO=@danhbo)
           ,(select SONHA+' '+TENDUONG from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DANHBO=@danhbo)
           ,0
           ,0
           ,1
           ,1
           ,(select CatNK_MaCN from ChungTu_ChiTiet where SoPhieu=@sophieu)
           ,(select CatNK_DanhBo from ChungTu_ChiTiet where SoPhieu=@sophieu)
           ,(select CatNK_HoTen from ChungTu_ChiTiet where SoPhieu=@sophieu)
           ,(select CatNK_HoTens from ChungTu_ChiTiet where SoPhieu=@sophieu)
           ,(select CatNK_DiaChi from ChungTu_ChiTiet where SoPhieu=@sophieu)
           ,N'LÊ TRUNG THÀNH'
           ,N'KT.GIÁM ĐỐC PHÓ GIÁM ĐỐC'
           ,1
           ,(select CreateDate from ChungTu_ChiTiet where SoPhieu=@sophieu)
           ,(select CreateBy from ChungTu_ChiTiet where SoPhieu=@sophieu))
	fetch next
	from @getCursor into @danhbo,@mact,@sophieu
end

close @getCursor
deallocate @getCursor

