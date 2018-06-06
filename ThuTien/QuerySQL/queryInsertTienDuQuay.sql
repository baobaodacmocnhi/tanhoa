declare @DanhBo varchar(11)
declare @Nam int
declare @Ky int
set @DanhBo='13192591500';
set @Ky=7;
set @Nam=2017;
if exists(select 1 from TT_TienDuQuay where DanhBo=@DanhBo)
	begin
		update TT_TienDuQuay set SoTien=SoTien+(select TONGCONG from HOADON where DANHBA=@DanhBo and Nam=@Nam and KY=@Ky) where DanhBo=@DanhBo
		insert into TT_TienDuLichSuQuay(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSuQuay),@DanhBo,(select TONGCONG from HOADON where DANHBA=@DanhBo and Nam=@Nam and KY=@Ky),N'Bảng Kê',N'Thêm '+(select Ky=(convert(varchar(2),KY)+'/'+convert(varchar(4),NAM)) from HOADON where DANHBA=@DanhBo and Nam=@Nam and KY=@Ky),0,GETDATE())
		return;
	end
else
	begin
		insert into TT_TienDuQuay(DanhBo,SoTien,CreateBy,CreateDate)values(@DanhBo,(select TONGCONG from HOADON where DANHBA=@DanhBo and Nam=@Nam and KY=@Ky),0,GETDATE())
		insert into TT_TienDuLichSuQuay(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSuQuay),@DanhBo,(select TONGCONG from HOADON where DANHBA=@DanhBo and Nam=@Nam and KY=@Ky),N'Bảng Kê',N'Thêm '+(select Ky=(convert(varchar(2),KY)+'/'+convert(varchar(4),NAM)) from HOADON where DANHBA=@DanhBo and Nam=@Nam and KY=@Ky),0,GETDATE())
		return;
	end
	