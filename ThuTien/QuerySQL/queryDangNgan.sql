select * from HOADON where CAST(NGAYGIAITRACH as date)='20200701'
and MaNV_DangNgan=(select MaND from TT_NguoiDung where HoTen=N'Bảo Bảo')

--update HOADON set MaNV_DangNgan=52 where CAST(NGAYGIAITRACH as date)='20200701'
--and MaNV_DangNgan=(select MaND from TT_NguoiDung where HoTen=N'Bảo Bảo')

select * from HOADON where DANHBA='13182551953' order by ID_HOADON desc

--lịch sử đăng ngân
select * from TT_LichSuDangNgan 
where MaHD=(select ID_HOADON from HOADON where DANHBA='13152202126' and NAM=2020 and KY=4)

select * from TT_LichSuDangNgan 
where MaHD=(select ID_HOADON from HOADON where SOHOADON='ct/20e4272484')