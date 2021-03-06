USE [KTKS_DonKH]
GO
/****** Object:  UserDefinedFunction [dbo].[fnCheckTinhTrangTruyThu_Ton_IDCT]    Script Date: 11/19/2019 11:13:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[fnCheckTinhTrangTruyThu_Ton_IDCT]
(
	-- Add the parameters for the function here
	@IDCT int
)
RETURNS nvarchar(200)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @TinhTrang nvarchar(200)
	DECLARE @MaDon nvarchar(100)
	-- Add the T-SQL statements to compute the return value here
	SELECT @MaDon=case when a.MaDonMoi is not null then case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=a.MaDonMoi)=1) then CONVERT(varchar(10),a.MaDonMoi) else CONVERT(varchar(10),a.MaDonMoi)+'.'+CONVERT(varchar(10),b.STT) end else
			case when a.MaDon is not null then 'TKH'+CONVERT(varchar(10),a.MaDon) else 
			case when a.MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),a.MaDonTXL) else 
			case when a.MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),a.MaDonTBC) end end end end,
			@TinhTrang=TinhTrang from TruyThuTienNuoc a,TruyThuTienNuoc_ChiTiet b	
	where IDCT=@IDCT and a.ID=b.ID
			and TinhTrang!=N'Đã thanh toán'
			and TinhTrang!=N'Điều chỉnh không phát sinh truy thu'
			and TinhTrang!=N'Miễn truy thu'
			and TinhTrang!=N'Giữ nguyên'

	-- Return the result of the function
	if @TinhTrang is not null
		RETURN N'có Truy Thu: '+@TinhTrang+' ('+@MaDon+')'
	else
		RETURN @TinhTrang
	return null
END
