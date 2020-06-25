select * from HOADON where CAST(NGAYGIAITRACH as date)='20200625'
and MaNV_DangNgan=(select MaND from TT_NguoiDung where HoTen=N'Thanh Lâm')