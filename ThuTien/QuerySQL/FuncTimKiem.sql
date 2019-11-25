--USE [HOADON_TA]
--GO
--/****** Object:  UserDefinedFunction [dbo].[TimKiem]    Script Date: 11/28/2017 09:15:15 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--ALTER function [dbo].[TimKiem]
--(
-- @DanhBo varchar(11),
-- @MLT varchar(11)
--) returns table
--AS return
--select ID_HOADON as MaHD,DANHBA as DanhBo,MALOTRINH as MLT,TENKH as HoTen,(SO+' '+DUONG) as DiaChi,GB as GiaBieu,DM as DinhMuc,a.SoHoaDon,
--                (convert(varchar(2),a.KY)+'/'+convert(varchar(4),a.NAM)) as Ky,TieuThu,GiaBan,Thue as ThueGTGT,Phi as PhiBVMT,TongCong,NgayGiaiTrach,b.HoTen as DangNgan,c.HoTen as HanhThu,MaDN,NgayDN,NgayMN
--                ,DENNGAY as NgayDoc,CODE,CSMOI as ChiSo
--                 from HOADON a left join TT_NguoiDung b on a.MaNV_DangNgan=b.MaND
--                 left join TT_NguoiDung c on a.MaNV_HanhThu=c.MaND
--                 left join
--                 (select b.MaHD,a.MaDN,NgayDN,NgayMN from TT_DongNuoc a
--                 left join TT_CTDongNuoc b on a.MaDN=b.MaDN
--                 left join TT_KQDongNuoc c on a.MaDN=c.MaDN where Huy=0) as dn on  a.ID_HOADON=dn.MaHD
--                 where a.DANHBA like '%'+@DanhBo+'%' and MALOTRINH like '%'+@MLT+'%'
USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[TimKiem]    Script Date: 12/04/2017 14:27:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER function [dbo].[TimKiem]
(
 @DanhBo varchar(11),
 @MLT varchar(11)
) returns table
AS return
select MaHD=ID_HOADON,DanhBo=DANHBA,MLT=MALOTRINH,HoTen=TENKH,DiaChi=(SO+' '+DUONG),GiaBieu=GB,DinhMucHN,DinhMuc=DM,hd.SoHoaDon,
Ky=(convert(varchar(2),hd.KY)+'/'+convert(varchar(4),hd.NAM)),TieuThu,GiaBan,ThueGTGT=Thue,PhiBVMT=Phi,TongCong,NgayGiaiTrach,
DangNgan=case when exists(select * from TT_CTChuyenNoKhoDoi ctcnkd where ctcnkd.MaHD=hd.ID_HOADON) then 'CNKĐ' else dangngan.HoTen end,
HanhThu=hanhthu.HoTen,MaDN,NgayDN,NgayMN,NgayDoc=DENNGAY,CODE,ChiSo=CSMOI,DCHD,
DongNuoc2=case when DongNuoc2 is null then 'false' else DongNuoc2 end,
LenhHuy=case when lenhhuy.MaHD is null then 'false' else 'true' end,
ToTrinh=case when exists(select MaHD from TT_ToTrinhCatHuy a,TT_CTToTrinhCatHuy b where a.MaTT=b.MaTT and a.DaKy=0 and b.MaHD like '%'+CAST(hd.ID_HOADON as varchar(10))+'%') then 'true' else 'false' end,
NhanVien=hanhthu.HoTen+' : '+hanhthu.DienThoai
from HOADON hd left join TT_NguoiDung dangngan on hd.MaNV_DangNgan=dangngan.MaND
left join TT_NguoiDung hanhthu on hd.MaNV_HanhThu=hanhthu.MaND
left join
(select ctdongnuoc.MaHD,dongnuoc.MaDN,NgayDN,NgayMN,DongNuoc2 from TT_DongNuoc dongnuoc
	left join TT_CTDongNuoc ctdongnuoc on dongnuoc.MaDN=ctdongnuoc.MaDN
	left join TT_KQDongNuoc kqdongnuoc on dongnuoc.MaDN=kqdongnuoc.MaDN where Huy=0) dongnuoc on hd.ID_HOADON=dongnuoc.MaHD
left join
(select MaHD from TT_LenhHuy) lenhhuy on hd.ID_HOADON=lenhhuy.MaHD
where hd.DANHBA like '%'+@DanhBo+'%' and MALOTRINH like '%'+@MLT+'%'