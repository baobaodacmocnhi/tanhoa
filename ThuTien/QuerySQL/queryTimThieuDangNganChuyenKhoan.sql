select DANHBA from HOADON where CAST(NGAYGIAITRACH as date)='2016-02-18' and MaNV_DangNgan=52
and DANHBA not in (select DanhBo from TT_TienDuLichSu where CAST(CreateDate as date)='2016-02-18' and Loai=N'Đăng Ngân')

update HOADON set NGAYGIAITRACH=null,MaNV_DangNgan=null,DangNgan_ChuyenKhoan=0 where SOHOADON='CT/15P3469951'
