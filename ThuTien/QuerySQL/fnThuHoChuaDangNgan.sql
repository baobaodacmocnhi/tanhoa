USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[fnThuHoChuaDangNgan]    Script Date: 17/12/2020 10:31:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER function [dbo].[fnThuHoChuaDangNgan]
(
 @DanhBo varchar(11)
) returns table
AS return
select dvtt.Kys,dvtt.TongCong,dvtt.TenDichVu,CreateDate=CONVERT(VARCHAR(10), dvtt.CreateDate, 103) + ' ' + CONVERT(VARCHAR(8), dvtt.CreateDate, 108) from TT_DichVuThuTong dvtt,TT_DichVuThu dvt,HOADON hd
where dvtt.DanhBo=@DanhBo and dvtt.ID=dvt.IDDichVu and dvt.MaHD=hd.ID_HOADON and hd.NGAYGIAITRACH is null