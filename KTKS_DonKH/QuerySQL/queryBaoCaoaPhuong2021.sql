--select distinct ctktxm.MaCTKTXM from DonTu dt,DonTu_ChiTiet dtct,KTXM ktxm,KTXM_ChiTiet ctktxm
--where dt.MaDon=dtct.MaDon and ktxm.MaKTXM=ctktxm.MaKTXM and dt.MaDon=ktxm.MaDonMoi and ctktxm.STT=dtct.STT
-- and HienTrangKiemTra like N'%đứt chì%'
-- and year(ctktxm.CreateDate)=2021 and MONTH(ctktxm.CreateDate)<=9

--select 
--(select count(distinct ctktxm.MaCTKTXM) from DonKH dt,KTXM ktxm,KTXM_ChiTiet ctktxm
--where ktxm.MaKTXM=ctktxm.MaKTXM and dt.MaDon=ktxm.MaDon
-- and HienTrangKiemTra like N'%ngược%'
-- and year(ctktxm.CreateDate)=2018 )+
 
-- (select count(distinct ctktxm.MaCTKTXM) from DonTXL dt,KTXM ktxm,KTXM_ChiTiet ctktxm
--where ktxm.MaKTXM=ctktxm.MaKTXM and dt.MaDon=ktxm.MaDonTXL
-- and HienTrangKiemTra like N'%ngược%'
-- and year(ctktxm.CreateDate)=2018 )+
 
-- (select count(distinct ctktxm.MaCTKTXM) from DonTBC dt,KTXM ktxm,KTXM_ChiTiet ctktxm
--where ktxm.MaKTXM=ctktxm.MaKTXM and dt.MaDon=ktxm.MaDonTBC
-- and HienTrangKiemTra like N'%ngược%'
-- and year(ctktxm.CreateDate)=2018 )

select count(distinct ttct.IDCT) from DonTu dt,DonTu_ChiTiet dtct,TruyThuTienNuoc tt,TruyThuTienNuoc_ChiTiet ttct
where dt.MaDon=dtct.MaDon and tt.ID=ttct.ID and dt.MaDon=tt.MaDonMoi and ttct.STT=dtct.STT
 and year(ttct.CreateDate)=2019 --and MONTH(ttct.CreateDate)<=9

select 
(select count(distinct ttct.IDCT) from DonKH dt,TruyThuTienNuoc tt,TruyThuTienNuoc_ChiTiet ttct
where tt.ID=ttct.ID and dt.MaDon=tt.MaDon
 and year(ttct.CreateDate)=2017 )+
 
 (select count(distinct ttct.IDCT) from DonTXL dt,TruyThuTienNuoc tt,TruyThuTienNuoc_ChiTiet ttct
where tt.ID=ttct.ID and dt.MaDon=tt.MaDon
 and year(ttct.CreateDate)=2017 )+
 
 (select count(distinct ttct.IDCT) from DonTBC dt,TruyThuTienNuoc tt,TruyThuTienNuoc_ChiTiet ttct
where tt.ID=ttct.ID and dt.MaDon=tt.MaDon
 and year(ttct.CreateDate)=2017 )