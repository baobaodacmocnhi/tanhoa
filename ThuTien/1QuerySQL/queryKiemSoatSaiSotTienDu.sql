
select DANHBA from HOADON where CAST(NGAYGIAITRACH as date)='20190731' and DangNgan_ChuyenKhoan=1 order by DANHBA
select * from TT_TienDuLichSu where CAST(CreateDate as date)='20190731' and Loai=N'Đăng Ngân' order by DanhBo
select DanhBo from TT_TienDuLichSu where CAST(CreateDate as date)='20190731' and Loai=N'Đăng Ngân' and DanhBo='13111736000'
select * from HOADON where SOHOADON='CT/19P1736366' 13111736000

select * from HOADON where cast(NGAYGIAITRACH as date)='20191121' and DangNgan_ChuyenKhoan=1 and ID_HOADON not in
(select MaHD from TT_TienDuLichSu where cast(CreateDate as date)='20191121' and Loai=N'Đăng Ngân' and MaHD not in(select MaHD from TT_TienDuLichSu where cast(CreateDate as date)='20191121' and Loai=N'Đăng Ngân' and GhiChu like N'%Xóa%'))

--update TT_TienDu set SoTien=SoTien-(select TONGCONG from HOADON where SOHOADON='CT/19P1736366'),ModifyBy=52,ModifyDate='2019-07-31 14:59:30.677' where DanhBo=(select DANHBA from HOADON where SOHOADON='CT/19P1736366')

--insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,SoHoaDon,MaHD,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='CT/19P3921738'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='CT/19P3921738'),N'Đăng Ngân',N'Thêm '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='CT/19P3921738'),'CT/19P3921738',(select ID_HOADON from HOADON where SOHOADON='CT/19P3921738'),52,'2019-11-22 15:00:13.960')


--declare @MaHD int
--declare @DanhBo char(11)
--declare @getCursor cursor
--set @getCursor=cursor for select MaHD from TT_TienDuLichSu where CAST(CreateDate as date)='20200529' and Loai like N'Đăng Ngân'  group by mahd having COUNT(*)=2
--open @getCursor
--fetch next
--from @getCursor into @MaHD
--while @@FETCH_STATUS=0
--begin
--	select @DanhBo=DanhBo from TT_TienDuLichSu where MaHD=@MaHD
--	update TT_TienDu set SoTien=SoTien-(select TongCong from HOADON where ID_HOADON=@MaHD) where DanhBo=@DanhBo
--	delete TT_TienDuLichSu where MaHD=@MaHD and Loai like N'Đăng Ngân' and GhiChu like N'Xóa%'
--	fetch next
--	from @getCursor into @MaHD
--end

--close @getCursor
--deallocate @getCursor


