USE [HOADON_TA]
GO
/****** Object:  Trigger [dbo].[trigger_Update_HOADON]    Script Date: 19/01/2021 2:07:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[trigger_Update_HOADON]
   ON  [dbo].[HOADON] 
   AFTER update
AS 
if UPDATE(NGAYGIAITRACH)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON
	
	declare @MaHD int,@SoHoaDon varchar(50),@Nam int,@Ky int,@NgayGiaiTrach datetime,@MaNV_HanhThu int,@MaNV_DangNgan int,
	@DangNgan_ChuyenKhoan bit,@DangNgan_Quay bit,@Name_PC varchar(50),@IP_PC varchar(50),@CreateBy int,@CreateDate datetime,@DCHD bit
	
	select @MaHD=ID_HOADON,@SoHoaDon=SOHOADON,@Nam=NAM,@Ky=KY,@NgayGiaiTrach=NGAYGIAITRACH,@MaNV_HanhThu=MaNV_HanhThu,@MaNV_DangNgan=MaNV_DangNgan,
	@DangNgan_ChuyenKhoan=@DangNgan_ChuyenKhoan,@DangNgan_Quay=DangNgan_Quay,@Name_PC=Name_PC,@IP_PC=IP_PC,@CreateBy=ModifyBy,@CreateDate=ModifyDate,@DCHD=DCHD from inserted
	
	--trigger 1 insert TT_LichSuDangNgan
	if(@NgayGiaiTrach is not null)
		begin
			insert into TT_LichSuDangNgan(MaHD,GhiChu,Name_PC,IP_PC,CreateBy,CreateDate)values(@MaHD,N'Thêm',@Name_PC,@IP_PC,@CreateBy,@CreateDate)
			if(@MaNV_DangNgan is not null and (@Nam>2020 or (@Nam=2020 and @Ky>=7)) and @DCHD=0)
				--insert into Temp_SyncHoaDon(ID,[Action],Name,Value,MaHD)values((select ID=case when not exists (select ID from Temp_SyncHoaDon) then 1 else MAX(ID)+1 end from Temp_SyncHoaDon),'ThanhToan','GiaiTrach','true',@MaHD)
				insert into Temp_SyncHoaDon([Action],[Name],[Value],MaHD)values('ThanhToan','GiaiTrach','true',@MaHD)
			if(@MaNV_HanhThu!=@MaNV_DangNgan)
			begin
				--insert into Temp_SyncHoaDon(ID,[Action],Name,Value,MaHD)values((select ID=case when not exists (select ID from Temp_SyncHoaDon) then 1 else MAX(ID)+1 end from Temp_SyncHoaDon),'DienThoai','GiaiTrach','true',@MaHD)
				insert into Temp_SyncHoaDon([Action],[Name],[Value],MaHD)values('DienThoai','GiaiTrach','true',@MaHD)
				--exec spSendNotificationToClient 'GiaiTrach','true',@MaHD
				--exec spSyncThanhToan @MaHD,'true'
			end
		end
	else
		begin
			insert into TT_LichSuDangNgan(MaHD,GhiChu,Name_PC,IP_PC,CreateBy,CreateDate)values(@MaHD,N'Xóa',@Name_PC,@IP_PC,@CreateBy,@CreateDate)
			if((select MaNV_DangNgan from deleted) is not null and (@Nam>2020 or (@Nam=2020 and @Ky>=7)) and @DCHD=0)
				--insert into Temp_SyncHoaDon(ID,[Action],Name,Value,MaHD)values((select ID=case when not exists (select ID from Temp_SyncHoaDon) then 1 else MAX(ID)+1 end from Temp_SyncHoaDon),'ThanhToan','GiaiTrach','false',@MaHD)
				insert into Temp_SyncHoaDon([Action],[Name],[Value],MaHD)values('ThanhToan','GiaiTrach','false',@MaHD)
			if( @MaNV_HanhThu!=(select MaNV_DangNgan from deleted))
			begin
				--insert into Temp_SyncHoaDon(ID,[Action],Name,Value,MaHD)values((select ID=case when not exists (select ID from Temp_SyncHoaDon) then 1 else MAX(ID)+1 end from Temp_SyncHoaDon),'DienThoai','GiaiTrach','false',@MaHD)
				insert into Temp_SyncHoaDon([Action],[Name],[Value],MaHD)values('DienThoai','GiaiTrach','false',@MaHD)
				--exec spSendNotificationToClient 'GiaiTrach','false',@MaHD
				--exec spSyncThanhToan @MaHD,'false'
			end
		end
		
	--trigger 2 SendNotificationToClient
	--if(@DangNgan_ChuyenKhoan=1 or @DangNgan_Quay=1)
	--begin
	--	declare @MaNV int;
	--	declare @Content nvarchar(100);

	--	set @MaNV=0;

	--	select @MaNV=MaNV from TT_GiaoHDDienThoai where MaHD=@MaHD --and NgayDi=cast(GETDATE() as date)

	--	set @Content=N'Hóa Đơn '+@SoHoaDon;

	--	if(@MaNV>0)
	--	begin
	--		if(@NgayGiaiTrach is not null)
	--			exec spSendNotificationToClient N'Thông Báo',@Content,@MaNV,'NgayGiaiTrach','true',@MaHD
	--		else
	--			exec spSendNotificationToClient N'Thông Báo',@Content,@MaNV,'NgayGiaiTrach','false',@MaHD
	--	end
	--end

END
