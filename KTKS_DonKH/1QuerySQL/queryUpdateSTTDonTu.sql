--select b.* from KTXM a, KTXM_ChiTiet b where a.MaKTXM=b.MaKTXM and a.MaDonMoi=20071623
--update KTXM_ChiTiet set STT=2 where MaCTKTXM=1707620

--select * from DonTu_LichSu where MaDon=19121373
--update DonTu_LichSu set STT=2 where MaDon=20071623 and STT=3
select * from DonTu where MaDon=21050030
select * from DonTu_ChiTiet where MaDon=21050030

--declare @ID int
--declare @STT int
--declare @getCursor cursor

--set @getCursor=cursor for select ID from DonTu_ChiTiet where MaDon=21050030
--set @STT=1
--open @getCursor
--fetch next
--from @getCursor into @ID
--while @@FETCH_STATUS=0
--begin
--	update DonTu_ChiTiet set STT=@STT where ID=@ID
--	fetch next
--	from @getCursor into @ID
--	set @STT+=1
--end

--close @getCursor
--deallocate @getCursor


============
select ktxm.MaDonMoi,STT,ktxm.MaKTXM,ktxmct.* from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM
and ktxmct.DanhBo='13182458455' and ktxm.MaDonMoi=19121373

select ktxm.MaDonMoi,STT,ktxm.MaCHDB,ktxmct.* from CHDB ktxm,CHDB_ChiTietCatTam ktxmct where ktxm.MaCHDB=ktxmct.MaCHDB
and ktxmct.DanhBo='13182458455' and ktxm.MaDonMoi=19121373

--update KTXM_ChiTiet set STT=7 where MaKTXM=102320 and STT=9
--update CHDB_ChiTietCatTam set STT=7 where MaCTCTDB=30220
select * from DonTu_LichSu where MaDon=21050030 and STT=9
--delete DonTu_LichSu where MaDon=21050030
--update DonTu_LichSu set STT=7 where MaDon=19121373 and STT=9