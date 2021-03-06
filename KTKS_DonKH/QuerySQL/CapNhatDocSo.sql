--select DanhBo,GiaBieu,DinhMuc into #tempDocSo from TB_DULIEUKHACHHANG
--drop table #tempDocSo
declare @FromMa numeric(18, 0);
declare @ToMa numeric(18, 0);
declare @DanhBo varchar(11);
declare @Value varchar(11);
declare @getCursor cursor

set @FromMa=390016;
set @ToMa=468916;

--set @getCursor=cursor for
select t1.DanhBo,GIABIEU,GiaBieu_BD,DinhMuc,DinhMuc_BD from
(select DanhBo,GiaBieu_BD,DinhMuc_BD,ROW_NUMBER() OVER (PARTITION BY DanhBo ORDER BY CreateDate DESC) AS rn from SERVER9.KTKS_DonKH.DBO.CTDCBD
where SUBSTRING(CONVERT(varchar(10),MaCTDCBD),LEN(CONVERT(varchar(10),MaCTDCBD))-1,2)=SUBSTRING(CONVERT(varchar(10),@FromMa),LEN(CONVERT(varchar(10),@FromMa))-1,2)
and MaCTDCBD>=@FromMa and MaCTDCBD<=@ToMa and ChuyenDocSo=1 and (GiaBieu_BD is not null or DinhMuc_BD is not null)) t1,
(select DanhBo,GiaBieu,DinhMuc from TB_DULIEUKHACHHANG) t2
where t1.DanhBo=t2.DanhBo and rn=1 and ((GiaBieu_BD is not null and t1.GiaBieu_BD!=t2.GiaBieu)or(DinhMuc_BD is not null and t1.DinhMuc_BD!=t2.DinhMuc))

--open @getCursor
--fetch next
--from @getCursor into @DanhBo,@Value
--while @@FETCH_STATUS=0
--begin
--	update TB_DULIEUKHACHHANG set GiaBieu=@Value where DanhBo=@DanhBo
--	fetch next
--	from @getCursor into @DanhBo,@Value
--end
--close @getCursor
--deallocate @getCursor

--exec KTKSCapNhatDocSo @FromMa=116,@ToMa=389916