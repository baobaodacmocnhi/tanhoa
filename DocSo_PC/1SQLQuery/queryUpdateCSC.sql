select ds.DanhBa,bd.ChiSo,ds.CSCu,Quan from BienDong bd,DocSo ds where ds.DanhBa=bd.DanhBa and ds.Nam=2024 and ds.ky=1 and ds.nam=bd.Nam and ds.ky=bd.ky
and ds.CSCu!=bd.ChiSo and CSCu=0

select * from BienDong where DanhBa='13152252439' order by BienDongID desc
select * from DocSo where DanhBa='13152252439' order by DocSoID desc

--update DocSo set CSCu=(select bd.ChiSo from BienDong bd where bd.Nam=2024 and bd.Ky=1 and bd.DanhBa=DocSo.DanhBa) where nam=2024 and ky=1 and DanhBa in (select ds.DanhBa from BienDong bd,DocSo ds where ds.DanhBa=bd.DanhBa and ds.Nam=2024 and ds.Ky=1 and ds.nam=bd.Nam and ds.ky=bd.Ky
--and ds.CSCu!=bd.ChiSo and CSCu=0)