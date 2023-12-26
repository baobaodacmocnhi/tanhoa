select * from DanhBo_MuaHe where DanhBo not in (
select b.DANHBO,b.HOTEN,ĐiaChi=b.SONHA+' '+b.TENDUONG,TieuThu=(select sum(TieuThuMoi)/3 from DocSoTH.dbo.DocSo c where c.DanhBa=a.DanhBo and c.Nam=2023 and c.Ky in(10,11,12)) from DanhBo_MuaHe a, CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b
where a.DanhBo=b.DANHBO)