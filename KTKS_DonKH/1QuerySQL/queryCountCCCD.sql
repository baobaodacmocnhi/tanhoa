--select * from ChungTu where MaLCT=15
select Quan=(select TENQUAN from CAPNUOCTANHOA.dbo.QUAN where MAQUAN=t1.Quan)
,Phuong=(select TENPHUONG from CAPNUOCTANHOA.dbo.PHUONG where MAQUAN=t1.Quan and MAPHUONG=t1.PHUONG)
,t1.SoLuong
from 
(select Quan,Phuong,SoLuong=COUNT(*) from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DANHBO in
(select distinct DanhBo from ChungTu_ChiTiet where MaLCT=15 and Cat=0) group by Quan,Phuong
) t1 order by Quan,Phuong