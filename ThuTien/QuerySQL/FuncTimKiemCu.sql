USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[TimKiemCu]    Script Date: 11/28/2017 09:16:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER function [dbo].[TimKiemCu]
(
 @DanhBo varchar(11),
 @MLT varchar(11)
) returns table
AS return
select ID_HOADON as MaHD,DANHBA as DanhBo,MALOTRINH as MLT,TENKH as HoTen,(SO+' '+DUONG) as DiaChi,GB as GiaBieu,DM as DinhMuc,a.SoHoaDon,
                (convert(varchar(2),a.KY)+'/'+convert(varchar(4),a.NAM)) as Ky,TieuThu,GiaBan,Thue as ThueGTGT,Phi as PhiBVMT,TongCong,NgayGiaiTrach,b.HoTen as DangNgan,c.HoTen as HanhThu,MaDN,NgayDN,NgayMN
                ,DENNGAY as NgayDoc,CODE,CSMOI as ChiSo
                 from TT_HoaDonCu a left join TT_NguoiDung b on a.MaNV_DangNgan=b.MaND
                 left join TT_NguoiDung c on a.MaNV_HanhThu=c.MaND
                 left join
                 (select b.MaHD,a.MaDN,NgayDN,NgayMN from TT_DongNuoc a
                 left join TT_CTDongNuoc b on a.MaDN=b.MaDN
                 left join TT_KQDongNuoc c on a.MaDN=c.MaDN where Huy=0) as dn on  a.ID_HOADON=dn.MaHD
                 where a.DANHBA like '%'+@DanhBo+'%' and MALOTRINH like '%'+@MLT+'%'