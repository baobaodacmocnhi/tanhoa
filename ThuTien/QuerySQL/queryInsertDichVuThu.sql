declare @DanhBo varchar(11);
declare @Nam int;
declare @Ky int;
set @DanhBo='13132163807'
set @Nam=2016
set @Ky=6
insert into TT_DichVuThu select ID_HOADON,SOHOADON,DANHBA,NAM,KY,TONGCONG,0,'BIDV','BIDV',GETDATE() from HOADON where DANHBA=@DanhBo and NAM=@Nam and KY=@Ky
