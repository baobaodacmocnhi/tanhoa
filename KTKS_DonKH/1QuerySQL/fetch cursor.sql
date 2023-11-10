--select * from CTKTXM where DongTienBoiThuong=1 and LapBangGia=0

declare @noidungCu nvarchar(1000)
declare @noidungMoi nvarchar(1000)
declare @getCursor cursor

set @getCursor=cursor for select NoiDungMoi='PYC: '+cast(ID as varchar(10))+', '+CONVERT(varchar(10),CreateDate,103)+' - HL: '+HieuLucKy+N' - ĐC Địa Chỉ từ '+DiaChi+' -> '+DiaChi_BD,NoiDungCu='PYC: '+cast(ID as varchar(10))+' ,'+CONVERT(varchar(10),CreateDate,103)+' - HL : '+HieuLucKy+N' - ĐC Địa Chỉ: '+DiaChi_BD from DocSoTH.dbo.MaHoa_DCBD dcbd where dcbd.ThongTin=N'Địa chỉ' order by CreateDate desc

open @getCursor
fetch next
from @getCursor into @noidungMoi,@noidungCu
while @@FETCH_STATUS=0
begin
	update CAPNUOCTANHOA.dbo.TB_GHICHU set NOIDUNG=@noidungMoi where NOIDUNG like N''+@noidungCu+'%'
	fetch next
	from @getCursor into @noidungMoi,@noidungCu
end

close @getCursor
deallocate @getCursor

select * from CAPNUOCTANHOA.dbo.TB_GHICHU where DanhBo='13051375210'
where noidung like N'PYC: 2333400 ,14/08/2023 - HL : 09/2023 - ĐC Địa Chỉ: 1306/52/5/7 CACH MANG THANG TAM%'