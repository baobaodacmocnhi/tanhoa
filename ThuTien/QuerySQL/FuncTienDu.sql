USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetTienDu]    Script Date: 11/15/2018 17:02:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[fnGetTienDu] 
(
	-- Add the parameters for the function here
	@DanhBo varchar(11)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @TienDu int
	set @TienDu=0
	declare @DCHD int
	-- Add the T-SQL statements to compute the return value here
	
	select @DCHD=COUNT(ID_HOADON) from HOADON where DCHD=1 and DANHBA=@DanhBo
	if @DCHD>0
	begin
		return 0
	end
	
	SELECT @TienDu=SoTien from TT_TienDu where DanhBo=@DanhBo
	
	IF @@ERROR <> 0
	begin
		return 0
	end

	-- Return the result of the function
	RETURN @TienDu
	
END
