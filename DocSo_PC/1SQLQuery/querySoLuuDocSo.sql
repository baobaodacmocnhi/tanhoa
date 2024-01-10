declare @Nam int
declare @Ky int
set @Nam=2022
set @Ky=1

--select Nam,COUNT(*) from BienDong_BAK group by Nam
--select Nam,COUNT(*) from BienDong group by Nam
select Nam,COUNT(*) from DocSoLuuTru group by Nam
select Nam,COUNT(*) from DocSo group by Nam

--insert BienDong_BAK select * from BienDong where Nam=@Nam
--delete BienDong where Nam=@Nam

--insert DocSoLuuTru select * from DocSo where Nam=@Nam
--delete DocSo where Nam=@Nam