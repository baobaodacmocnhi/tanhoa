declare @SoHoaDon nvarchar(20)
set @SoHoaDon='CT/16P0939673'
update TT_DichVuThu set SoHoaDon=(select top(1)SOHOADON from HOADON where DANHBA=(select DanhBo from TT_DichVuThu where SoHoaDon=@SoHoaDon) order by ID_HOADON desc) where SoHoaDon=@SoHoaDon

select * from TT_DichVuThu where SoHoaDon='CT/16P0839673'
select * from HOADON where SOHOADON='CT/16P0839673' order by ID_HOADON desc