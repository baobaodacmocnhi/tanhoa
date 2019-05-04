USE [HOADON_TA]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetPhiMoNuoc]    Script Date: 05/03/2019 08:33:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[fnGetPhiMoNuoc]
(
	-- Add the parameters for the function here
	@DanhBo varchar(11)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @PhiMoNuoc int
	set @PhiMoNuoc=0
	
	-- Add the T-SQL statements to compute the return value here
	SELECT @PhiMoNuoc=PhiMoNuoc from TT_KQDongNuoc a,TT_DongNuoc b where a.DanhBo=@DanhBo and DongNuoc=1 and MoNuoc=0 and TroNgaiMN=0 and b.Huy=0 and a.MaDN=b.MaDN
	--and not exists(select top 1 MaDN from TT_CTDongNuoc c, HOADON hd where c.MaDN=b.MaDN and c.MaHD=hd.ID_HOADON and hd.NGAYGIAITRACH is not null) 
	and not exists(select top 1 c.MaDN from TT_CTDongNuoc c, TT_CTChuyenNoKhoDoi cnkd where c.MaDN=b.MaDN and c.MaHD=cnkd.MaHD)
	
	IF @@ERROR <> 0 
	begin
		return 0
	end
		
	-- Return the result of the function
	RETURN @PhiMoNuoc

END
