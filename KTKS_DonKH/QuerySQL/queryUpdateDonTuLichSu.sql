update DonTu_LichSu set ID_NoiChuyen=9,NoiChuyen=N'Thư Trả Lời'
,TableName='ThuTraLoi_ChiTiet',IDCT=(select MaCTTTTL from ThuTraLoi a,ThuTraLoi_ChiTiet b where a.MaTTTL=b.MaTTTL and a.MaDonMoi=DonTu_LichSu.MaDon and b.STT=DonTu_LichSu.STT and CAST(b.CreateDate as date)=CAST(DonTu_LichSu.CreateDate as date))
,NoiDung=N'Đã Lập Thư Trả Lời, '+(select VeViec from ThuTraLoi a,ThuTraLoi_ChiTiet b where a.MaTTTL=b.MaTTTL and a.MaDonMoi=DonTu_LichSu.MaDon and b.STT=DonTu_LichSu.STT and CAST(b.CreateDate as date)=CAST(DonTu_LichSu.CreateDate as date))
where ID_NoiChuyen is NULL and CreateBy=9