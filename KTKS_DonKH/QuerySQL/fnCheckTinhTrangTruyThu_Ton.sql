USE [KTKS_DonKH]
GO
/****** Object:  UserDefinedFunction [dbo].[fnCheckTinhTrangTruyThu_Ton]    Script Date: 08/08/2019 14:29:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[fnCheckTinhTrangTruyThu_Ton]
(
	-- Add the parameters for the function here
	@DanhBo char(11)
)
RETURNS nvarchar(200)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @TinhTrang nvarchar(200)

	-- Add the T-SQL statements to compute the return value here
	SELECT @TinhTrang=TinhTrang from TruyThuTienNuoc_ChiTiet
	where DanhBo=@DanhBo
			and TinhTrang!=N'Đã thanh toán'
			and TinhTrang!=N'Điều chỉnh không phát sinh truy thu'
			and TinhTrang!=N'Miễn truy thu'
			and TinhTrang!=N'Giữ nguyên'

	-- Return the result of the function
	if @TinhTrang is not null
		RETURN N'Truy Thu: '+@TinhTrang
	else
		RETURN @TinhTrang
	return null
END
