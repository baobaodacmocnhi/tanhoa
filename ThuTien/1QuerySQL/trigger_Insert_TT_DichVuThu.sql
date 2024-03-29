USE [HOADON_TA]
GO
/****** Object:  Trigger [dbo].[trigger_Insert_TT_DichVuThu]    Script Date: 19/01/2021 2:10:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[trigger_Insert_TT_DichVuThu]
ON [dbo].[TT_DichVuThu]
AFTER insert
AS 
BEGIN
    SET NOCOUNT ON;
    
    declare @MaHD int,@SoHoaDon varchar(50),@Nam int,@Ky int,@DCHD bit;
	
    select @MaHD=ID_HOADON,@SoHoaDon=SOHOADON,@Nam=NAM,@Ky=KY,@DCHD=DCHD from HOADON where SOHOADON=(select SoHoaDon from inserted)
    
    --trigger 1 update MaHD cho bảng TT_DichVuThu
    update TT_DichVuThu set MaHD=@MaHD where SoHoaDon=@SoHoaDon

	--trigger 2 SendNotificationToClient
	--set @MaNV=0;

	--select @MaNV=MaNV from TT_GiaoHDDienThoai where MaHD=@MaHD --and NgayDi=cast(GETDATE() as date)

	--set @Content=@MLT+' - '+@DanhBo+' - '+@TongCong;

	--if(@MaNV>0)
	--begin
	--	exec spSendNotificationToClient N'Thông Báo Đã Thu Hộ',@Content,@MaNV,'HanhThu','ThuHo',@MaHD
	--end
	
	if((@Nam>2020 or (@Nam=2020 and @Ky>=7)) and @DCHD=0 and (SELECT dbo.fnGetChanDCHD(@MaHD))='true')
		--insert into Temp_SyncHoaDon(ID,[Action],Name,Value,MaHD)values((select ID=case when not exists (select ID from Temp_SyncHoaDon) then 1 else MAX(ID)+1 end from Temp_SyncHoaDon),'ThanhToan','ThuHo','true',@MaHD)
		insert into Temp_SyncHoaDon([Action],[Name],[Value],MaHD)values('ThanhToan','ThuHo','true',@MaHD)

	declare @PhiMoNuoc varchar(6)
	--exec spSendNotificationToClient 'ThuHo','true',@MaHD
	--if not exists(select dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and dn.MaDN=ctdn.MaDN and ctdn.MaHD=@MaHD)
		--insert into Temp_SyncHoaDon(ID,[Action],Name,Value,MaHD)values((select ID=case when not exists (select ID from Temp_SyncHoaDon) then 1 else MAX(ID)+1 end from Temp_SyncHoaDon),'DienThoai','ThuHo','true',@MaHD)
		insert into Temp_SyncHoaDon([Action],[Name],[Value],MaHD)values('DienThoai','ThuHo','true',@MaHD)
	--else
		if((select PhiMoNuoc from TT_DichVuThuTong where MaHDs like '%'+CONVERT(varchar(8),@MaHD)+'%')!=null)
		begin
			set @PhiMoNuoc=(select PhiMoNuoc from TT_DichVuThuTong where MaHDs like '%'+CONVERT(varchar(8),@MaHD)+'%')
			--insert into Temp_SyncHoaDon(ID,[Action],Name,Value,MaHD)values((select ID=case when not exists (select ID from Temp_SyncHoaDon) then 1 else MAX(ID)+1 end from Temp_SyncHoaDon),'DienThoai','PhiMoNuocThuHo',@PhiMoNuoc,@MaHD)
			insert into Temp_SyncHoaDon([Action],[Name],[Value],MaHD)values('DienThoai','PhiMoNuocThuHo',@PhiMoNuoc,@MaHD)
			--exec spSendNotificationToClient 'PhiMoNuocThuHo',@PhiMoNuoc,@MaHD
		end
		
END
