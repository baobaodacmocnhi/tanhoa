USE [KTKS_DonKH]
GO
/****** Object:  StoredProcedure [dbo].[spTimKiemByHoTen_DonTuChiTiet]    Script Date: 06/12/2019 15:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spTimKiemByHoTen_DonTuChiTiet]
	-- Add the parameters for the stored procedure here
	@HoTen nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--ktxm
select TableName='KTXM',TabSTT='1',TabName=N'Chi Tiết Kiểm Tra Xác Minh',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
MaCTKTXM,NgayKTXM,DanhBo,HoTen,DiaChi,NoiDungKiemTra,NoiDungDongTien,NgayDongTien,SoTienDongTien,CreateBy=(select HoTen from Users where MaU=b.CreateBy)
from KTXM a,KTXM_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.MaKTXM=b.MaKTXM
--bamchi
select TableName='BamChi',TabSTT='2',TabName=N'Chi Tiết Bấm Chì',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
MaCTBC,NgayBC,DanhBo,HoTen,DiaChi,TrangThaiBC,TheoYeuCau,MaSoBC,CreateBy=(select HoTen from Users where MaU=b.CreateBy)
from BamChi a,BamChi_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.MaBC=b.MaBC
--dongnuoc
select TableName='DongNuoc',TabSTT='3',TabName=N'Chi Tiết Đóng Nước',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
MaCTDN,NgayDN,DanhBo,HoTen,DiaChi,MaCTMN,NgayMN,CreateBy=(select HoTen from Users where MaU=b.CreateBy)
from DongNuoc a,DongNuoc_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.MaDN=b.MaDN
--dcbd
select TableName='DCBD',TabSTT='4',TabName=N'Chi Tiết Điều Chỉnh Biến Động',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
MaDC = b.MaCTDCBD,DieuChinh = N'Biến Động',b.CreateDate,DanhBo,HoTen,DiaChi,GiaBieu,DinhMuc,GiaBieu_BD,DinhMuc_BD,HoTen_BD,DiaChi_BD,MSThue,MSThue_BD,ThongTin,'TieuThu'=NULL,'TieuThu_BD'=NULL,'TongCong_Start'=NULL,'TongCong_End'=NULL,'TongCong_BD'=NULL,'TangGiam'=NULL,CreateBy=(select HoTen from Users where MaU=b.CreateBy)from DCBD a,DCBD_ChiTietBienDong b where HoTen like N'%'+@HoTen+'%' and a.MaDCBD=b.MaDCBD
union all
select TableName='DCBD',TabSTT='5',TabName=N'Chi Tiết Điều Chỉnh Hóa Đơn',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
MaDC = b.MaCTDCHD,DieuChinh = N'Hóa Đơn',b.CreateDate,DanhBo,HoTen,DiaChi,GiaBieu,DinhMuc,GiaBieu_BD,DinhMuc_BD,'HoTen_BD'=NULL,'DiaChi_BD'=NULL,'MSThue'=NULL,'MSThue_BD'=NULL,ThongTin,TieuThu,TieuThu_BD,TongCong_Start,TongCong_End,TongCong_BD,TangGiam,CreateBy=(select HoTen from Users where MaU=b.CreateBy)
from DCBD a,DCBD_ChiTietHoaDon b where HoTen like N'%'+@HoTen+'%' and a.MaDCBD=b.MaDCBD
--chdb
select TableName='CHDB',TabSTT='6',TabName=N'Chi Tiết Cắt Tạm/Hủy Danh Bộ',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
MaCH = b.MaCTCTDB,LoaiCat = N'Cắt Tạm',b.CreateDate,DanhBo,HoTen,DiaChi,LyDo,GhiChuLyDo,DaLapPhieu,SoPhieu,NgayLapPhieu,CreateBy=(select HoTen from Users where MaU=b.CreateBy)
from CHDB a,CHDB_ChiTietCatTam b where HoTen like N'%'+@HoTen+'%' and a.MaCHDB=b.MaCHDB
union all
select TableName='CHDB',TabSTT='7',TabName=N'Chi Tiết Cắt Tạm/Hủy Danh Bộ',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
MaCH = b.MaCTCHDB,LoaiCat = N'Cắt Hủy',b.CreateDate,DanhBo,HoTen,DiaChi,LyDo,GhiChuLyDo,DaLapPhieu,SoPhieu,NgayLapPhieu,CreateBy=(select HoTen from Users where MaU=b.CreateBy)
from CHDB a,CHDB_ChiTietCatHuy b where HoTen like N'%'+@HoTen+'%' and a.MaCHDB=b.MaCHDB
--phieuchdb
select TableName='PhieuCHDB',TabSTT='8',TabName=N'Chi Tiết Phiếu Hủy Danh Bộ',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
b.MaYCCHDB,b.CreateDate,DanhBo,HoTen,DiaChi,LyDo,GhiChuLyDo,HieuLucKy,CreateBy=(select HoTen from Users where MaU=b.CreateBy)
from CHDB a,CHDB_Phieu b where HoTen like N'%'+@HoTen+'%' and a.MaCHDB=b.MaCHDB
--tttl
select TableName='TTTL',TabSTT='9',TabName=N'Chi Tiết Thảo Thư Trả Lời',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
b.MaCTTTTL,b.CreateDate,DanhBo,HoTen,DiaChi,VeViec,NoiDung,NoiNhan,CreateBy=(select HoTen from Users where MaU=b.CreateBy)
from TTTL a,TTTL_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.MaTTTL=b.MaTTTL
--gianlan
select TableName='GianLan',TabSTT='10',TabName=N'Chi Tiết Gian Lận',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
ID = b.MaCTGL,b.CreateDate,DanhBo,HoTen,DiaChi,NoiDungViPham,TinhTrang,ThanhToan1,ThanhToan2,ThanhToan3,XepDon,CreateBy=(select HoTen from Users where MaU=b.CreateBy)
from GianLan a,GianLan_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.MaGL=b.MaGL
--truythu
select TableName='TruyThu',TabSTT='11',TabName=N'Chi Tiết Truy Thu',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
b.IDCT,b.CreateDate,DanhBo,HoTen,DiaChi,NoiDung,TongTien,Tongm3BinhQuan,TinhTrang,CreateBy=(select HoTen from Users where MaU=b.CreateBy)
from TruyThuTienNuoc a,TruyThuTienNuoc_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.ID=b.ID
--totrinh
select TableName='ToTrinh',TabSTT='12',TabName=N'Chi Tiết Tờ Trình',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
b.IDCT,b.CreateDate,DanhBo,HoTen,DiaChi,NoiDung,VeViec,CreateBy=(select HoTen from Users where MaU=b.CreateBy)
from ToTrinh a,ToTrinh_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.ID=b.ID
--thumoi
select TableName='ThuMoi',TabSTT='13',TabName=N'Chi Tiết Thư Mời',MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDonTKH is not null then 'TKH'+CONVERT(varchar(10),a.MaDonTKH) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
b.IDCT,b.CreateDate,DanhBo,HoTen,DiaChi,Lan,VeViec,CreateBy=(select HoTen from Users where MaU=b.CreateBy)
from ThuMoi a,ThuMoi_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.ID=b.ID
--tientrinh
select TableName='TienTrinh',TabSTT='14',TabName=N'Chi Tiết Tiến Trình',MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDon)=1) then CONVERT(varchar(10),a.MaDon) else CONVERT(varchar(10),a.MaDon)+'.'+CONVERT(varchar(10),b.STT) end,
NgayChuyen,NoiChuyen,NoiNhan,KTXM,NoiDung
from DonTu_ChiTiet a,DonTu_LichSu b where HoTen like N'%'+@HoTen+'%' and a.MaDon=b.MaDon and a.STT=b.STT
order by NgayChuyen asc,b.ID asc
END
