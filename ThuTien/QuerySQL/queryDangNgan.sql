select * from HOADON where CAST(NGAYGIAITRACH as date)='20200626'
and MaNV_DangNgan=(select MaND from TT_NguoiDung where HoTen=N'Thanh S?')

select * from HOADON where DANHBA='13182551953' order by ID_HOADON desc

--lịch sử đăng ngân
select * from TT_LichSuDangNgan 
where MaHD=(select ID_HOADON from HOADON where DANHBA='13152202126' and NAM=2020 and KY=4)