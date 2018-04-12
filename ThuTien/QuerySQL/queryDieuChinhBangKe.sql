select * from TT_BangKe where DanhBo='13111751160'
select * from TT_TienDu where DanhBo='13111751160'
select * from TT_TienDuLichSu where DanhBo='13111751160'
--update TT_BangKe set SoTien=SoTien-118450 where MaBK=25740
--update TT_TienDu set SoTien=SoTien+91770 where DanhBo='13111751160'
--update TT_TienDuLichSu set SoTien=SoTien-118450 where ID=65231
--delete TT_TienDuLichSu where ID=99486

select *,DATEADD( day, DATEDIFF( day, CreateDate, '20180411' ), CreateDate ) from TT_BangKe where CAST(CreateDate as date)='2018-04-12'
--update TT_BangKe set CreateDate=DATEADD( day, DATEDIFF( day, CreateDate, '20180411' ), CreateDate ) where CAST(CreateDate as date)='2018-04-12'
select * from TT_TienDuLichSu where CAST(CreateDate as date)='2018-04-12' and Loai=N'B?ng Kê'
--update  TT_TienDuLichSu set CreateDate=DATEADD( day, DATEDIFF( day, CreateDate, '20180411' ), CreateDate ) where CAST(CreateDate as date)='2018-04-12' and Loai=N'B?ng Kê'