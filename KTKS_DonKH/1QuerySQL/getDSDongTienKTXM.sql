--select MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=ktxm.MaDonMoi)=1) then CONVERT(varchar(10),ktxm.MaDonMoi) else CONVERT(varchar(10),ktxm.MaDonMoi)+'.'+CONVERT(varchar(10),ctktxm.STT) end
--,ctktxm.DanhBo,NoiDungXuLy,GhiChuNoiDungXuLy from KTXM ktxm,KTXM_ChiTiet ctktxm,DonTu dt,DonTu_ChiTiet dtct where ktxm.MaKTXM=ctktxm.MaKTXM and dt.MaDon=ktxm.MaDonMoi and dtct.STT=ctktxm.STT and dt.MaDon=dtct.MaDon and LapBangGia=1
--and CAST(NgayLapBangGia as date)>='20190121' and CAST(NgayLapBangGia as date)<='20190220'

--select MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=ktxm.MaDonMoi)=1) then CONVERT(varchar(10),ktxm.MaDonMoi) else CONVERT(varchar(10),ktxm.MaDonMoi)+'.'+CONVERT(varchar(10),ctktxm.STT) end
--,ctktxm.DanhBo,NoiDungXuLy,GhiChuNoiDungXuLy from KTXM ktxm,KTXM_ChiTiet ctktxm,DonTu dt,DonTu_ChiTiet dtct where ktxm.MaKTXM=ctktxm.MaKTXM and dt.MaDon=ktxm.MaDonMoi and dtct.STT=ctktxm.STT and dt.MaDon=dtct.MaDon and DongTien=1
--and CAST(NgayDongTien as date)>='20190121' and CAST(NgayDongTien as date)<='20190220' 
                    
select MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=ktxm.MaDonMoi)=1) then CONVERT(varchar(10),ktxm.MaDonMoi) else CONVERT(varchar(10),ktxm.MaDonMoi)+'.'+CONVERT(varchar(10),ctktxm.STT) end
,ctktxm.DanhBo,NoiDungXuLy,GhiChuNoiDungXuLy from KTXM ktxm,KTXM_ChiTiet ctktxm,DonTu dt,DonTu_ChiTiet dtct where ktxm.MaKTXM=ctktxm.MaKTXM and dt.MaDon=ktxm.MaDonMoi and dtct.STT=ctktxm.STT and dt.MaDon=dtct.MaDon and ChuyenLapTBCat=1
and CAST(NgayChuyenLapTBCat as date)>='20190121' and CAST(NgayChuyenLapTBCat as date)<='20190220' 