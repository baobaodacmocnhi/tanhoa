USE [HOADON_TA]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateTT_DichVuThu_CuaHang_DanhBo_NamKy]    Script Date: 28/10/2020 9:34:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spUpdateTT_DichVuThu_CuaHang_DanhBo_NamKy]
	-- Add the parameters for the stored procedure here
	@Nam int,@Ky int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
declare @DanhBo char(11)
declare @getCursorDHN cursor, @getCursorCH cursor
set @getCursorDHN=cursor for select DANHBA from HOADON where NAM=@Nam and KY=@Ky

open @getCursorDHN
fetch next
from @getCursorDHN into @DanhBo
while @@FETCH_STATUS=0
begin
	declare @LocationDHNS varchar(100)=(select a=case when DangNgan_DienThoai_Location is not null and DangNgan_DienThoai_Location!='' then DangNgan_DienThoai_Location
										when InPhieuBao_Location is not null and InPhieuBao_Location!='' then InPhieuBao_Location
										when InPhieuBao2_Location is not null and InPhieuBao2_Location!='' then InPhieuBao2_Location
										end from HOADON where NAM=@Nam and KY=@Ky-1 and DANHBA=@DanhBo and ((DangNgan_DienThoai_Location is not null and DangNgan_DienThoai_Location!='')or(InPhieuBao_Location is not null and InPhieuBao_Location!='')or(InPhieuBao2_Location is not null and InPhieuBao2_Location!='')))
	declare @NameCH1 nvarchar(100)=N'', @NameCH2 nvarchar(100)=N'', @NameCH nvarchar(100)=N'', @LocationCHS varchar(100)=N''
	declare @Distance1 float=0, @Distance2 float=0
	if(@LocationDHNS is not null)
	begin
		declare @Lat float=convert(float,SUBSTRING(@LocationDHNS, 1, CHARINDEX(',', @LocationDHNS)-1))
		,@Lot float=convert(float,SUBSTRING(@LocationDHNS, CHARINDEX(',', @LocationDHNS)+1, Len(@LocationDHNS)-CHARINDEX(',', @LocationDHNS)));
		declare @LocationDHN geography= geography::Point(@Lat,@Lot, 4326);
		set @getCursorCH=cursor for select NameCH=[Name]+':'+DiaChi,LocationCH=(select a=case when DangNgan_DienThoai_Location is not null and DangNgan_DienThoai_Location!='' then DangNgan_DienThoai_Location
																				when InPhieuBao_Location is not null and InPhieuBao_Location!='' then InPhieuBao_Location
																				when InPhieuBao2_Location is not null and InPhieuBao2_Location!='' then InPhieuBao2_Location
																				end from HOADON where NAM=@Nam and KY=@Ky-1 and DANHBA=DanhBo and ((DangNgan_DienThoai_Location is not null and DangNgan_DienThoai_Location!='')or(InPhieuBao_Location is not null and InPhieuBao_Location!='')or(InPhieuBao2_Location is not null and InPhieuBao2_Location!=''))) from TT_DichVuThu_CuaHang where DanhBo is not null and DanhBo!=''
			open @getCursorCH
			fetch next
			from @getCursorCH into @NameCH,@LocationCHS
			while @@FETCH_STATUS=0
			begin
				if(@LocationCHS is not null)
				begin
					set @Lat=convert(float,SUBSTRING(@LocationCHS, 1, CHARINDEX(',', @LocationCHS)-1))
					set @Lot=convert(float,SUBSTRING(@LocationCHS, CHARINDEX(',', @LocationCHS)+1, Len(@LocationCHS)-CHARINDEX(',', @LocationCHS)));
					declare @LocationCH geography= geography::Point(@Lat,@Lot, 4326);
					declare @Distance float=@LocationDHN.STDistance(@LocationCH)
					if(@Distance<=2000)
						begin
							if(@Distance1=0)
								begin
									set @NameCH1=@NameCH
									set @Distance1=@Distance
								end
							else
								if(@Distance1>@Distance)
									begin
										set @NameCH2=@NameCH1
										set @Distance2=@Distance1
										set @NameCH1=@NameCH
										set @Distance1=@Distance
									end
								else
									if(@Distance2=0)
										begin
											set @NameCH2=@NameCH
											set @Distance2=@Distance
										end
									else
										if(@Distance2>@Distance)
											begin
												set @NameCH2=@NameCH
												set @Distance2=@Distance
											end
						end
					end
				fetch next
				from @getCursorCH into @NameCH,@LocationCHS
			end
			close @getCursorCH
			deallocate @getCursorCH
		
		if(@NameCH1!='' and @NameCH2!='')
			update TT_DichVuThu_CuaHang_DanhBo set CuaHangThuHo=N'Dịch Vụ Thu Hộ:'+CHAR(13)+@NameCH1+CHAR(13)+@NameCH2 where DanhBo=@DanhBo
		else
			if(@NameCH1!='')
				update TT_DichVuThu_CuaHang_DanhBo set CuaHangThuHo=N'Dịch Vụ Thu Hộ:'+CHAR(13)+@NameCH1 where DanhBo=@DanhBo
			else
				update TT_DichVuThu_CuaHang_DanhBo set CuaHangThuHo=NULL where DanhBo=@DanhBo
	end
	fetch next
	from @getCursorDHN into @DanhBo
end
close @getCursorDHN
deallocate @getCursorDHN

END
