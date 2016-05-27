declare @SoHoaDon nvarchar(20)
set @SoHoaDon='CT/16P0939113'
update TT_DichVuThu set SoHoaDon=(select top(1)SOHOADON from HOADON where DANHBA=(select DanhBo from TT_DichVuThu where SoHoaDon=@SoHoaDon) order by ID_HOADON desc) where SoHoaDon=@SoHoaDon