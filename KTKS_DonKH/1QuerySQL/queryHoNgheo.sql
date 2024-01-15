--select * from
--(select DanhBo=DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,GiaBieu=GB,DinhMuc=DM,TieuThu,GiaBan,Thue,Phi,TongCong from hoadon where gb=10 and nam=2020 and ky=3) t3
--left join (select DanhBo=DANHBA,TieuThu,GiaBan,Thue,Phi,TongCong,DangNgan=case when NGAYGIAITRACH is not null then 'X' else '' end from hoadon where gb=10 and nam=2020 and ky=4) t4 on t3.DanhBo=t4.DanhBo
--left join (select DanhBo=DANHBA,TieuThu,GiaBan,Thue,Phi,TongCong,DangNgan=case when NGAYGIAITRACH is not null then 'X' else '' end from hoadon where gb=10 and nam=2020 and ky=5) t5 on t3.DanhBo=t5.DanhBo
--left join (select DanhBo=DANHBA,TieuThu,GiaBan,Thue,Phi,TongCong,DangNgan=case when NGAYGIAITRACH is not null then 'X' else '' end from hoadon where gb=10 and nam=2020 and ky=6) t6 on t3.DanhBo=t6.DanhBo

select DanhBo=DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,TieuThu,GiaBan,Thue,Phi,TongCong,GiaBieu=GB,DinhMuc=DM,DinhMucHN,SOHOADON,Ky=CONVERT(varchar(10),KY)+'/'+CONVERT(varchar(10),Nam)
,Phuong=(select top 1 [Name] from KTKS_DonKH.dbo.Phuong where IDQuan=Quan and IDPhuong=Phuong),Quan=(select top 1 [Name] from KTKS_DonKH.dbo.Quan where ID=Quan)
from hoadon where gb=10 and nam=2023 AND KY in (10,11,12) and (NGAYGIAITRACH is not null and MaNV_DangNgan is not null) order by DANHBA asc, ID_HOADON asc
union
select DanhBo=DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,TieuThu,GiaBan,Thue,Phi,TongCong,GiaBieu=GB,DinhMuc=DM,DinhMucHN,SOHOADON from hoadon where (gb!=10 and DinhMucHN is not null) and nam=2020 and ky=4 and (NGAYGIAITRACH is not null or CAST(NGAYGIAITRACH as date)<='20201106')
