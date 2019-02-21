--select * from CTKTXM where DongTienBoiThuong=1 and LapBangGia=0

declare @ID numeric(18, 0)
declare @DanhBo char(11)
declare @Quan char(2)
declare @Phuong char(2)
declare @getCursor cursor

set @getCursor=cursor for select [IDCT],DanhBo from ThuMoi_ChiTiet where quan is null

open @getCursor
fetch next
from @getCursor into @ID,@DanhBo
while @@FETCH_STATUS=0
begin
	update ThuMoi_ChiTiet set Quan=(select QUAN from SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=@DanhBo)
	,Phuong=(select PHUONG from SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=@DanhBo) where [IDCT]=@ID
	--update ThuMoi_ChiTiet set Quan=(select QUAN from SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=@DanhBo)
	--,Phuong=(select PHUONG from SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG_HUYDB where DanhBo=@DanhBo) where [IDCT]=@ID
	fetch next
	from @getCursor into @ID,@DanhBo
end

close @getCursor
deallocate @getCursor
