USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetChanDCHD]    Script Date: 28/10/2020 9:37:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[fnGetChanDCHD]
(
	-- Add the parameters for the function here
	@MaHD int
)
RETURNS varchar(5)
AS
BEGIN
		if exists(select ID_HOADON from HOADON where ID_HOADON=@MaHD  and (NAM<2020 or (NAM=2020 and KY<=6)))
		return 'true'
	else
		if not exists(select FK_HOADON from DIEUCHINH_HD where FK_HOADON=@MaHD )
			return 'true'
		else
			if exists(select FK_HOADON from DIEUCHINH_HD where FK_HOADON=@MaHD  and UpdatedHDDT=1)
				return 'true'
			else
				return 'false'
	return 'false'
END
