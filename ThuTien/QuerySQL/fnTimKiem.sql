USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[fnTimKiem]    Script Date: 28/10/2020 9:36:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER function [dbo].[fnTimKiem]
(
 @DanhBo varchar(11),
 @MLT varchar(11)
) returns table
AS return
select MaHD=ID_HOADON,DanhBo=DANHBA,MLT=MALOTRINH,HoTen=TENKH,DiaChi=case when SO is null then DUONG else case when DUONG is null then SO else SO+' '+DUONG end end,GiaBieu=GB,DinhMucHN,DinhMuc=DM,hd.SoHoaDon,
Ky=(convert(varchar(2),hd.KY)+'/'+convert(varchar(4),hd.NAM)),TieuThu,GiaBan,ThueGTGT=Thue,PhiBVMT=Phi,TongCong,NgayGiaiTrach,NgayGiaiTrach1=CONVERT(varchar(10),NgayGiaiTrach,103),
DangNgan=case when exists(select * from TT_CTChuyenNoKhoDoi ctcnkd where ctcnkd.MaHD=hd.ID_HOADON) then 'CNKĐ' else dangngan.HoTen end,
HanhThu=hanhthu.HoTen,MaDN,MaNV_DongNuoc,NgayDN,NgayDN1=CONVERT(varchar(10),NgayDN,103),NgayMN,NgayMN1=CONVERT(varchar(10),NgayMN,103),NgayDoc=DENNGAY,Code,ChiSo=CSMOI,DCHD,
--ChanDCHD=(select dbo.fnGetChanDCHD(hd.ID_HOADON)),
ChanDCHD='true',
DongNuoc2=case when DongNuoc2 is null then 'false' else DongNuoc2 end,
LenhHuy=case when lenhhuy.MaHD is null then 'false' else 'true' end,
ToTrinh=case when exists(select MaHD from TT_ToTrinhCatHuy a,TT_CTToTrinhCatHuy b where a.MaTT=b.MaTT and a.DaKy=0 and b.MaHD like '%'+CAST(hd.ID_HOADON as varchar(10))+'%') then 'true' else 'false' end,
NhanVien=hanhthu.HoTen+' : '+hanhthu.DienThoai
from HOADON hd left join TT_NguoiDung dangngan on hd.MaNV_DangNgan=dangngan.MaND
left join TT_NguoiDung hanhthu on hd.MaNV_HanhThu=hanhthu.MaND
left join
(select ctdongnuoc.MaHD,dongnuoc.MaDN,dongnuoc.MaNV_DongNuoc,NgayDN,NgayMN,DongNuoc2 from TT_DongNuoc dongnuoc
	left join TT_CTDongNuoc ctdongnuoc on dongnuoc.MaDN=ctdongnuoc.MaDN
	left join TT_KQDongNuoc kqdongnuoc on dongnuoc.MaDN=kqdongnuoc.MaDN where Huy=0) dongnuoc on hd.ID_HOADON=dongnuoc.MaHD
left join
(select MaHD from TT_LenhHuy) lenhhuy on hd.ID_HOADON=lenhhuy.MaHD
where hd.DANHBA like '%'+@DanhBo+'%' and MALOTRINH like '%'+@MLT+'%'