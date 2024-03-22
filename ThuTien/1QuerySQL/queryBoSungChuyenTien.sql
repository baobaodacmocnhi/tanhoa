select * from TT_BangKe where DanhBo='13141940053' and CAST(CreateDate as date)='20240313'
select * from TT_TienDuLichSu where DanhBo='13141940053' and CAST(CreateDate as date)='20240313'
select * from TT_TienDuLichSu where CAST(CreateDate as date)='20240313' and Loai like N'%tiền%'

--update TT_BangKe set DanhBo='24031305000' where MaBK=6271395
--update TT_TienDuLichSu set DanhBo='24031305000' where ID=14661476

--tạo 2 lịch sử tiền dư để chuyển nhận tiền
--insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,DanhBoChuyenNhan,CreateBy,CreateDate)
--values((select max(ID)+1 from TT_TienDuLichSu),'24031305000',-5499912,N'Chuyển Tiền',N'CHUYỂN QUẬN TB','13141940053',1,'2024-03-13 14:56:21.703')
--insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,DanhBoChuyenNhan,CreateBy,CreateDate)
--values((select max(ID)+1 from TT_TienDuLichSu),'13141940053',5499912,N'Nhận Tiền',N'CHUYỂN QUẬN TB','24031305000',1,'2024-03-13 14:56:21.703')