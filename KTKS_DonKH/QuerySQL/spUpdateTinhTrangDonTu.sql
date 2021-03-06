USE [KTKS_DonKH]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateTinhTrang]    Script Date: 02/22/2021 15:53:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spUpdateTinhTrang]
	-- Add the parameters for the stored procedure here
	@MaDon int,@STT int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    --7 - cắt hủy
    --8 - truy thu
    
    declare @TinhTrang nvarchar(100),@i int,@j int,@ID int,@NgayChuyen datetime
    ,@ID_NoiChuyen int,@ID_NoiNhan int,@TableName varchar(50),@IDCT int,@getCursor cursor;
	
	--set @TinhTrang=N'Tồn'
    set @getCursor=cursor for select ID,ID_NoiNhan,NgayChuyen from DonTu_LichSu where MaDon=@MaDon and STT=@STT and Huy=0 order by NgayChuyen,ID
    --chạy vòng lặp 1
    open @getCursor
    fetch next from @getCursor into @ID,@ID_NoiNhan,@NgayChuyen
    while @@FETCH_STATUS=0
    begin
		declare @KiemTra bit
		set @KiemTra=(select KiemTra from NoiChuyen where ID=@ID_NoiNhan)
		if(@ID_NoiNhan is not null and @KiemTra=1)
		begin
			set @TinhTrang=N'Tồn ('+(select [Name] from NoiChuyen where ID=@ID_NoiNhan)+')'
			declare @getCursor2 cursor
			set @getCursor2=cursor for select ID_NoiChuyen,TableName,IDCT from DonTu_LichSu where MaDon=@MaDon and STT=@STT and NgayChuyen>@NgayChuyen order by NgayChuyen,ID
				--chạy vòng lặp 2
				open @getCursor2
				fetch next from @getCursor2 into @ID_NoiChuyen,@TableName,@IDCT
				while @@FETCH_STATUS=0
				begin
					declare @result nvarchar(50)
					set @result=''
					if(@ID_NoiChuyen in (2,3,4) and @ID_NoiChuyen=@ID_NoiNhan)
						begin
							set @TinhTrang=N'Hoàn Thành'
						end
					else
						if(@ID_NoiChuyen=7 and @ID_NoiChuyen=@ID_NoiNhan and @TableName is not null)
							begin
								set @result=(select dbo.fnCheckTinhTrangCatHuy_Ton(@TableName,@IDCT))
								if(@result='')
									set @TinhTrang=N'Hoàn Thành'
								else
									set @TinhTrang=N'Hoàn Thành (KH)'
							end
						else
							begin
								if(@ID_NoiChuyen=8 and @ID_NoiChuyen=@ID_NoiNhan and @TableName is not null)
									begin
										set @result=(select dbo.fnCheckTinhTrangTruyThu_Ton_IDCT(@IDCT))
										if(@result='')
											set @TinhTrang=N'Hoàn Thành'
										else
											set @TinhTrang=N'Hoàn Thành (KH)'
									end
								else
									begin
										if(@ID_NoiChuyen=@ID_NoiNhan and @TableName is not null)
											set @TinhTrang=N'Hoàn Thành'
									end
							end
					fetch next from @getCursor2 into @ID_NoiChuyen,@TableName,@IDCT
				end
				close @getCursor2
				deallocate @getCursor2
				--xóa vòng lặp 2
		end
		fetch next from @getCursor into @ID,@ID_NoiNhan,@NgayChuyen
    end
    close @getCursor
    deallocate @getCursor
    --update TinhTrang DonTu_ChiTiet 
    if((select HoanThanh from DonTu_ChiTiet where MaDon=@MaDon and STT=@STT)=1)--nếu check Hoành Thành
		update DonTu_ChiTiet set TinhTrang=N'Hoàn Thành',HoanThanh_Ngay=GETDATE() where MaDon=@MaDon and STT=@STT
    else--nếu không check Hoành Thành
		if @TinhTrang like N'Hoàn Thành'
			update DonTu_ChiTiet set TinhTrang=@TinhTrang,HoanThanh_Ngay=GETDATE() where MaDon=@MaDon and STT=@STT
		else
			update DonTu_ChiTiet set TinhTrang=@TinhTrang where MaDon=@MaDon and STT=@STT
    --update TinhTrang DonTu
    declare @soluongNhan int ,@soluongHoanThanh int;
    set @soluongNhan=(select COUNT(MaDon) from DonTu_ChiTiet where MaDon=@MaDon)
    set @soluongHoanThanh=(select COUNT(MaDon) from DonTu_ChiTiet where MaDon=@MaDon and TinhTrang like N'%Hoàn Thành%')
    if(@soluongNhan=@soluongHoanThanh)
		update DonTu set TinhTrang=N'Hoàn Thành' where MaDon=@MaDon
	else
		update DonTu set TinhTrang=N'Tồn' where MaDon=@MaDon
END
