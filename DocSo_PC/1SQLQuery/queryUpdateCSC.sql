select ds.DanhBa,bd.ChiSo,ds.CSCu,Quan from BienDong bd,DocSo ds
where ds.DocSoID=bd.BienDongID
and ds.Nam=2024 and ds.ky=1 and ds.dot=3
and ds.CSCu!=bd.ChiSo and CSCu=0

select top 1 * from BienDong where DanhBa='13152252439' order by BienDongID desc
select top 1 * from DocSo where DanhBa='13152252439' order by DocSoID desc

--update DocSo set CSCu=(select bd.ChiSo from BienDong bd where bd.BienDongID=DocSo.DocSoID) where nam=2024 and ky=1
--and DocSoID in (select ds.DocSoID from BienDong bd,DocSo ds where ds.DocSoID=bd.BienDongID and ds.Nam=2024 and ds.ky=1 and ds.dot=19
--and ds.CSCu!=bd.ChiSo and CSCu=0)

select * from DocSo where nam=2024 and ky=1 and dot=19