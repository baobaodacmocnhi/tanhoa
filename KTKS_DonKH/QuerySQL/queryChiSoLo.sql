declare @dot int
set @dot=4
select Dot=@dot,
SLDHNLap=(select COUNT(*) from ChiSoLo_DanhBo where nam=2021 and ky=11 and dot=@dot)
,SLTVLap=(select COUNT(*) from ChiSoLo_DanhBo where nam=2021 and ky=11 and dot=@dot and MaDon is not null)
,SLHDDC=(select COUNT(*) from ChiSoLo_DanhBo a,ChiSoLo_HoaDon b where a.nam=2021 and a.ky=11 and a.dot=@dot and b.TieuThuDC is not null and a.ID=b.ID)
,SLChiSoHet=(select COUNT(*) from ChiSoLo_DanhBo where nam=2021 and ky=11 and dot=@dot and MaDon is not null and TieuThuLoConLai=0)
,SLChiSoTon=(select COUNT(*) from ChiSoLo_DanhBo where nam=2021 and ky=11 and dot=@dot and MaDon is not null and TieuThuLoConLai<0)
,SLTieuThuDieuChinh=(select SUM(TieuThuLo)*-1 from ChiSoLo_DanhBo where nam=2021 and ky=11 and dot=@dot and MaDon is not null)-(select SUM(TieuThuLoConLai)*-1 from ChiSoLo_DanhBo where nam=2021 and ky=11 and dot=@dot and MaDon is not null)


--select a.* from ChiSoLo_DanhBo a,ChiSoLo_HoaDon b where a.nam=2021 and a.ky=11 and a.dot=3 and b.TieuThuDC is not null and a.ID=b.ID

--select * from ChiSoLo_HoaDon where ID=2661
--update ChiSoLo_HoaDon set TieuThuDC=NULL where ID=2661