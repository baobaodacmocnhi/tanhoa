--select * from
--(select DanhBo=DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,GiaBieu=GB,DinhMuc=DM,TieuThu,GiaBan,Thue,Phi,TongCong from hoadon where gb=10 and nam=2020 and ky=3) t3
--left join (select DanhBo=DANHBA,TieuThu,GiaBan,Thue,Phi,TongCong,DangNgan=case when NGAYGIAITRACH is not null then 'X' else '' end from hoadon where gb=10 and nam=2020 and ky=4) t4 on t3.DanhBo=t4.DanhBo
--left join (select DanhBo=DANHBA,TieuThu,GiaBan,Thue,Phi,TongCong,DangNgan=case when NGAYGIAITRACH is not null then 'X' else '' end from hoadon where gb=10 and nam=2020 and ky=5) t5 on t3.DanhBo=t5.DanhBo
--left join (select DanhBo=DANHBA,TieuThu,GiaBan,Thue,Phi,TongCong,DangNgan=case when NGAYGIAITRACH is not null then 'X' else '' end from hoadon where gb=10 and nam=2020 and ky=6) t6 on t3.DanhBo=t6.DanhBo

select DanhBo=DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,TieuThu,GiaBan,Thue,Phi,TongCong,GiaBieu=GB,DinhMuc=DM,DinhMucHN,SOHOADON from hoadon where gb=10 and nam=2020 and ky=4 and (NGAYGIAITRACH is not null or CAST(NGAYGIAITRACH as date)<='20201106')
union
select DanhBo=DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,TieuThu,GiaBan,Thue,Phi,TongCong,GiaBieu=GB,DinhMuc=DM,DinhMucHN,SOHOADON from hoadon where (gb!=10 and DinhMucHN is not null) and nam=2020 and ky=4 and (NGAYGIAITRACH is not null or CAST(NGAYGIAITRACH as date)<='20201106')

--giam 10%
select DanhBo=DANHBA,HoTen=TENKH,DiaChi=SO+' '+DUONG,Ky,TieuThu ,GiaBan,Thue,Phi,TongCong,SoTienGiam from hoadon where nam=2021 and ky=9 and SoTienGiam is not null