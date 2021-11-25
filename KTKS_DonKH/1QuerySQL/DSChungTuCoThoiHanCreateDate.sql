with k as(select *,ROW_NUMBER() OVER (PARTITION BY danhbo ORDER BY createdate DESC) AS rn from CTDCBD)
select ROW_NUMBER() over (order by (select 1)) as STT,t1.DanhBo,MaCT,SoNKDangKy,DinhMuc_BD from
(select DanhBo,b.MaCT,SoNKDangKy,GhiChu from ChungTu a,CTChungTu b where CAST(b.CreateDate as date)>='2016-08-15' and CAST(b.CreateDate as date)<='2016-09-15'
and Cat=0 and NgayHetHan is not null and CreateDateGoc is null and GiaHan=0 and a.MaCT=b.MaCT and MaLCT=7) t1,

(select DanhBo,DinhMuc_BD from k where rn=1) t2
where t1.DanhBo=t2.DanhBo
