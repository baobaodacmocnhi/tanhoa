
select DANHBA from HOADON where CAST(NGAYGIAITRACH as date)='20190731' and DangNgan_ChuyenKhoan=1 order by DANHBA
select * from TT_TienDuLichSu where CAST(CreateDate as date)='20190731' and Loai=N'Đăng Ngân' order by DanhBo
select DanhBo from TT_TienDuLichSu where CAST(CreateDate as date)='20190731' and Loai=N'Đăng Ngân' and DanhBo='13111736000'
select * from HOADON where SOHOADON='CT/19P1736366' 13111736000


--update TT_TienDu set SoTien=SoTien-(select TONGCONG from HOADON where SOHOADON='CT/19P1736366'),ModifyBy=52,ModifyDate='2019-07-31 14:59:30.677' where DanhBo=(select DANHBA from HOADON where SOHOADON='CT/19P1736366')

--insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='CT/19P1736366'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='CT/19P1736366'),N'Đăng Ngân',N'Thêm '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='CT/19P1736366'),'CT/19P1736366',52,'2019-07-31 14:59:30.677')
