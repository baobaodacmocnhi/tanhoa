USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[fnThuHoChuaDangNgan]    Script Date: 28/10/2020 9:36:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER function [dbo].[fnThuHoChuaDangNgan]
(
 @DanhBo varchar(11)
) returns table
AS return
select dvtt.Kys,dvtt.TongCong,dvtt.TenDichVu,dvtt.CreateDate from TT_DichVuThuTong dvtt,TT_DichVuThu dvt,HOADON hd
where dvtt.DanhBo=@DanhBo and dvtt.ID=dvt.IDDichVu and dvt.MaHD=hd.ID_HOADON and hd.NGAYGIAITRACH is null