
select 'PYC: '+cast(ID as varchar(10))+', '+CONVERT(varchar(10),CreateDate,103)+' - HL: '+HieuLucKy+N' - ĐC Địa Chỉ từ '+DiaChi+' -> '+DiaChi_BD from DocSoTH.dbo.MaHoa_DCBD dcbd where dcbd.ThongTin=N'Địa chỉ'

and DanhBo='13051375210'

select 'PYC: '+cast(ID as varchar(10))+' ,'+CONVERT(varchar(10),CreateDate,103)+' - HL : '+HieuLucKy+N' - ĐC Địa Chỉ: '+DiaChi_BD from DocSoTH.dbo.MaHoa_DCBD dcbd where dcbd.ThongTin=N'Địa chỉ'

and DanhBo='13051375210'

select * from CAPNUOCTANHOA.dbo.TB_GHICHU where DanhBo='13051375210'