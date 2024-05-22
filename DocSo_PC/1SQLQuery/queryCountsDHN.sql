select HIEUDH,SL=count(*) from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where HIEUDH in
(select HIEU_DHTM from sDHN.dbo.DHTM_THONGTIN) and DANHBO in (select DanhBo from sDHN.dbo.sDHN_TCT)
and SUBSTRING(LOTRINH,0,3)>15
group by HIEUDH