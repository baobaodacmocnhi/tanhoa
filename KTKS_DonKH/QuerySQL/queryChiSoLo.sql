select
SLDHNLap=(select COUNT(*) from ChiSoLo_DanhBo where nam=2021 and ky=11 and dot=1)
,SLTVLap=(select COUNT(*) from ChiSoLo_DanhBo where nam=2021 and ky=11 and dot=1 and MaDon is not null)
,SLHDDC=(select COUNT(*) from ChiSoLo_DanhBo a,ChiSoLo_HoaDon b where a.nam=2021 and a.ky=11 and a.dot=1 and b.TieuThuDC is not null and a.ID=b.ID)
,SLChiSoHet=(select COUNT(*) from ChiSoLo_DanhBo where nam=2021 and ky=11 and dot=1 and MaDon is not null and TieuThuLoConLai=0)
,SLChiSoTon=(select COUNT(*) from ChiSoLo_DanhBo where nam=2021 and ky=11 and dot=1 and MaDon is not null and TieuThuLoConLai<0)