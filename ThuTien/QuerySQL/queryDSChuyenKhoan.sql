select t1.DANHBA,MALOTRINH,(select TenTo from TT_To where MaTo=(select MaTo from TT_NguoiDung where MaND=MaNV_HanhThu)),(select HoTen from TT_NguoiDung where MaND=MaNV_HanhThu) from
(select DANHBA from HOADON where DangNgan_ChuyenKhoan=1 and NAM=2017 and (KY=7 or KY=8 or KY=9) and DANHBA not in (select DanhBo from TT_DuLieuKhachHang_DanhBo)
group by DANHBA
having COUNT(*)=3) t1 
LEFT JOIN 
        (
        SELECT  DANHBA,MALOTRINH,MaNV_HanhThu, ROW_NUMBER()
                OVER (PARTITION BY danhba ORDER BY (ID_HOADON) desc) AS RowNum
        FROM    HOADON

        ) t2 ON t1.DANHBA  = t2.DANHBA And RowNum = 1