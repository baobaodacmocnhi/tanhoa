select * from TT_BangKe where DanhBo='13222892120' order by CreateDate desc
select * from TT_TienDu where DanhBo='13222892120'
select * from TT_TienDuLichSu where DanhBo='13222892120' and CAST(CreateDate as date)='2018-05-28'
--update TT_BangKe set SoTien=SoTien-118450 where MaBK=25740
--update TT_TienDu set SoTien=0 where DanhBo='13222892120'
--update TT_TienDuLichSu set SoTien=SoTien-118450 where ID=65231

--delete TT_BangKe where MaBK=2497273
--delete TT_TienDuLichSu where ID=5707711
--delete TT_TienDuLichSu where DanhBo='13263414890' and CAST(CreateDate as date)='2018-05-28'

--update HOADON set TONGCONG=GIABAN+PHI+THUE where SOHOADON='CT/18P1138436'
select * from HOADON where SOHOADON='CT/18P1138436'

--select *,DATEADD( day, DATEDIFF( day, CreateDate, '20180411' ), CreateDate ) from TT_BangKe where CAST(CreateDate as date)='2018-04-12'
--update TT_BangKe set CreateDate=DATEADD( day, DATEDIFF( day, CreateDate, '20180411' ), CreateDate ) where CAST(CreateDate as date)='2018-04-12'
--select * from TT_TienDuLichSu where CAST(CreateDate as date)='2018-04-12' and Loai=N'B?ng Kê'
--update  TT_TienDuLichSu set CreateDate=DATEADD( day, DATEDIFF( day, CreateDate, '20180411' ), CreateDate ) where CAST(CreateDate as date)='2018-04-12' and Loai=N'B?ng Kê'