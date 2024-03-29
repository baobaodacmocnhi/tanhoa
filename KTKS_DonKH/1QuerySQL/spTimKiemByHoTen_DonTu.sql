USE [KTKS_DonKH]
GO
/****** Object:  StoredProcedure [dbo].[spTimKiemByHoTen_DonTu]    Script Date: 12/17/2020 15:01:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spTimKiemByHoTen_DonTu]
	-- Add the parameters for the stored procedure here
	@HoTen char(11)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--dontu
select MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDon)=1) then CONVERT(varchar(10),a.MaDon) else CONVERT(varchar(10),a.MaDon)+'.'+CONVERT(varchar(10),a.STT) end
,TenLD=(select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon),CreateDate,DanhBo,HoTen,DiaChi,GiaBieu,DinhMuc,DinhMucHN
,NoiDungPKH=case when (select Name_NhomDon_PKH from DonTu where MaDon=a.MaDon)!='' then (select Name_NhomDon_PKH from DonTu where MaDon=a.MaDon) else (select VanDeKhac from DonTu where MaDon=a.MaDon) end
,NoiDung=(select Name_NhomDon from DonTu where MaDon=a.MaDon),a.DienThoai,a.TinhTrang
from DonTu_ChiTiet a where HoTen like N'%'+@HoTen+'%'
--dontkh
union
select MaDon='TKH'+CONVERT(varchar(10),a.MaDon)
,TenLD=(select TenLD from LoaiDon where MaLD=a.MaLD),a.CreateDate,DanhBo,HoTen,DiaChi,GiaBieu,DinhMuc,DinhMucHN,NoiDungPKH='',NoiDung,DienThoai,TinhTrang=''
from DonKH a where HoTen like N'%'+@HoTen+'%'
--dontxl
union
select MaDon='TXL'+CONVERT(varchar(10),a.MaDon)
,TenLD=(select TenLD from LoaiDonTXL where MaLD=a.MaLD),a.CreateDate,DanhBo,HoTen,DiaChi,GiaBieu,DinhMuc,DinhMucHN,NoiDungPKH='',NoiDung,DienThoai,TinhTrang=''
from DonTXL a where HoTen like N'%'+@HoTen+'%'
--dontbc
union
select MaDon='TBC'+CONVERT(varchar(10),a.MaDon)
,TenLD=(select TenLD from LoaiDonTBC where MaLD=a.MaLD),a.CreateDate,DanhBo,HoTen,DiaChi,GiaBieu,DinhMuc,DinhMucHN,NoiDungPKH='',NoiDung,DienThoai,TinhTrang=''
from DonTBC a where HoTen like N'%'+@HoTen+'%'
--ktxm
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon) else
case when a.MaDon is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDon)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDon is not null then (select CreateDate from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DanhBo from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select HoTen from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DiaChi from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select GiaBieu from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMuc from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMucHN from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDon is not null then (select NoiDung from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DienThoai from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from KTXM a,KTXM_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.MaKTXM=b.MaKTXM
--bamchi
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon) else
case when a.MaDon is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDon)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDon is not null then (select CreateDate from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DanhBo from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select HoTen from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DiaChi from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select GiaBieu from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMuc from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMucHN from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDon is not null then (select NoiDung from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DienThoai from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from BamChi a,BamChi_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.MaBC=b.MaBC
--DongNuoc
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon) else
case when a.MaDon is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDon)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDon is not null then (select CreateDate from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DanhBo from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select HoTen from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DiaChi from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select GiaBieu from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMuc from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMucHN from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDon is not null then (select NoiDung from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DienThoai from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from DongNuoc a,DongNuoc_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.MaDN=b.MaDN
--DCBD
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon) else
case when a.MaDon is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDon)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDon is not null then (select CreateDate from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DanhBo from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select HoTen from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DiaChi from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select GiaBieu from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMuc from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMucHN from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDon is not null then (select NoiDung from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DienThoai from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from DCBD a,DCBD_ChiTietBienDong b where HoTen like N'%'+@HoTen+'%' and a.MaDCBD=b.MaDCBD
--DCHD
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon) else
case when a.MaDon is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDon)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDon is not null then (select CreateDate from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DanhBo from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select HoTen from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DiaChi from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select GiaBieu from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMuc from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMucHN from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDon is not null then (select NoiDung from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DienThoai from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from DCBD a,DCBD_ChiTietHoaDon b where HoTen like N'%'+@HoTen+'%' and a.MaDCBD=b.MaDCBD
--CTDB
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon) else
case when a.MaDon is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDon)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDon is not null then (select CreateDate from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DanhBo from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select HoTen from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DiaChi from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select GiaBieu from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMuc from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMucHN from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDon is not null then (select NoiDung from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DienThoai from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from CHDB a,CHDB_ChiTietCatTam b where HoTen like N'%'+@HoTen+'%' and a.MaCHDB=b.MaCHDB
--CHDB
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon) else
case when a.MaDon is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDon)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDon is not null then (select CreateDate from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DanhBo from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select HoTen from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DiaChi from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select GiaBieu from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMuc from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMucHN from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDon is not null then (select NoiDung from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DienThoai from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from CHDB a,CHDB_ChiTietCatHuy b where HoTen like N'%'+@HoTen+'%' and a.MaCHDB=b.MaCHDB
--PhieuCHDB
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon) else
case when a.MaDon is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDon)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDon is not null then (select CreateDate from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DanhBo from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select HoTen from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DiaChi from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select GiaBieu from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMuc from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMucHN from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDon is not null then (select NoiDung from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DienThoai from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from CHDB a,CHDB_Phieu b where HoTen like N'%'+@HoTen+'%' and a.MaCHDB=b.MaCHDB
--ThuTraLoi
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon) else
case when a.MaDon is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDon)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDon is not null then (select CreateDate from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DanhBo from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select HoTen from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DiaChi from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select GiaBieu from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMuc from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMucHN from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDon is not null then (select NoiDung from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DienThoai from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from ThuTraLoi a,ThuTraLoi_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.MaTTTL=b.MaTTTL
--GianLan
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon) else
case when a.MaDon is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDon)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDon is not null then (select CreateDate from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DanhBo from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select HoTen from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DiaChi from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select GiaBieu from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMuc from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMucHN from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDon is not null then (select NoiDung from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DienThoai from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from GianLan a,GianLan_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.MaGL=b.MaGL
--truythu
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon) else
case when a.MaDon is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDon)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDon is not null then (select CreateDate from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DanhBo from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select HoTen from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DiaChi from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select GiaBieu from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMuc from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMucHN from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDon is not null then (select NoiDung from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DienThoai from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from TruyThuTienNuoc a,TruyThuTienNuoc_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.ID=b.ID
--totrinh
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDon) else
case when a.MaDon is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDon)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDon is not null then (select CreateDate from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DanhBo from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select HoTen from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DiaChi from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select GiaBieu from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMuc from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DinhMucHN from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDon is not null then (select NoiDung from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDon is not null then (select DienThoai from DonKH where MaDon=a.MaDon) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from ToTrinh a,ToTrinh_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.ID=b.ID
--thumoi
union
select MaDon=
case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
case when a.MaDonTKH is not null then 'TKH'+CONVERT(varchar(10),a.MaDonTKH) else 
case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
TenLD=
case when a.MaDonMoi is not null then (select SoCongVan_PhongBanDoi+': '+SoCongVan from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDonTKH is not null then (select TenLD from LoaiDon where MaLD=(select MaLD from DonKH where MaDon=a.MaDonTKH)) else 
case when a.MaDonTXL is not null then (select TenLD from LoaiDonTXL where MaLD=(select MaLD from DonTXL where MaDon=a.MaDonTXL)) else 
case when a.MaDonTBC is not null then (select TenLD from LoaiDonTBC where MaLD=(select MaLD from DonTBC where MaDon=a.MaDonTBC)) end end end end,
CreateDate=
case when a.MaDonMoi is not null then (select CreateDate from DonTu where MaDon=a.MaDonMoi) else
case when a.MaDonTKH is not null then (select CreateDate from DonKH where MaDon=a.MaDonTKH) else 
case when a.MaDonTXL is not null then (select CreateDate from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select CreateDate from DonTBC where MaDon=a.MaDonTBC) end end end end,
DanhBo=
case when a.MaDonMoi is not null then (select DanhBo from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDonTKH is not null then (select DanhBo from DonKH where MaDon=a.MaDonTKH) else 
case when a.MaDonTXL is not null then (select DanhBo from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DanhBo from DonTBC where MaDon=a.MaDonTBC) end end end end,
HoTen=
case when a.MaDonMoi is not null then (select HoTen from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDonTKH is not null then (select HoTen from DonKH where MaDon=a.MaDonTKH) else 
case when a.MaDonTXL is not null then (select HoTen from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select HoTen from DonTBC where MaDon=a.MaDonTBC) end end end end,
DiaChi=
case when a.MaDonMoi is not null then (select DiaChi from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDonTKH is not null then (select DiaChi from DonKH where MaDon=a.MaDonTKH) else 
case when a.MaDonTXL is not null then (select DiaChi from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DiaChi from DonTBC where MaDon=a.MaDonTBC) end end end end,
GiaBieu=
case when a.MaDonMoi is not null then (select GiaBieu from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDonTKH is not null then (select GiaBieu from DonKH where MaDon=a.MaDonTKH) else 
case when a.MaDonTXL is not null then (select GiaBieu from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select GiaBieu from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMuc=
case when a.MaDonMoi is not null then (select DinhMuc from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDonTKH is not null then (select DinhMuc from DonKH where MaDon=a.MaDonTKH) else 
case when a.MaDonTXL is not null then (select DinhMuc from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMuc from DonTBC where MaDon=a.MaDonTBC) end end end end,
DinhMucHN=
case when a.MaDonMoi is not null then (select DinhMucHN from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDonTKH is not null then (select DinhMucHN from DonKH where MaDon=a.MaDonTKH) else 
case when a.MaDonTXL is not null then (select DinhMucHN from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DinhMucHN from DonTBC where MaDon=a.MaDonTBC) end end end end,
NoiDungPKH=(select Name_NhomDon_PKH from DonTu where MaDon=a.MaDonMoi),
NoiDung=
case when a.MaDonMoi is not null then case when (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi)!='' then (select Name_NhomDon from DonTu where MaDon=a.MaDonMoi) else (select VanDeKhac from DonTu where MaDon=a.MaDonMoi) end else
case when a.MaDonTKH is not null then (select NoiDung from DonKH where MaDon=a.MaDonTKH) else 
case when a.MaDonTXL is not null then (select NoiDung from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select NoiDung from DonTBC where MaDon=a.MaDonTBC) end end end end,
DienThoai=
case when a.MaDonMoi is not null then (select DienThoai from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT) else
case when a.MaDonTKH is not null then (select DienThoai from DonKH where MaDon=a.MaDonTKH) else 
case when a.MaDonTXL is not null then (select DienThoai from DonTXL where MaDon=a.MaDonTXL) else 
case when a.MaDonTBC is not null then (select DienThoai from DonTBC where MaDon=a.MaDonTBC) end end end end
,TinhTrang=(select TinhTrang from DonTu_ChiTiet where MaDon=a.MaDonMoi and STT=b.STT)
from ThuMoi a,ThuMoi_ChiTiet b where HoTen like N'%'+@HoTen+'%' and a.ID=b.ID
order by CreateDate desc
END
