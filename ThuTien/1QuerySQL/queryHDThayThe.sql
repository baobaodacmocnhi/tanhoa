select DANHBA,hd.SOHOADON
,GiaBan=(select top 1 dchd.TienNuoc_Start from KTKS_DonKH.dbo.DCBD_ChiTietHoaDon dchd where hd.NAM=dchd.Nam and hd.KY=dchd.Ky and hd.DANHBA=dchd.DanhBo)
,ThueGTGT=(select top 1 dchd.ThueGTGT_Start from KTKS_DonKH.dbo.DCBD_ChiTietHoaDon dchd where hd.NAM=dchd.Nam and hd.KY=dchd.Ky and hd.DANHBA=dchd.DanhBo)
,TDVTN=(select top 1 dchd.PhiBVMT_Start from KTKS_DonKH.dbo.DCBD_ChiTietHoaDon dchd where hd.NAM=dchd.Nam and hd.KY=dchd.Ky and hd.DANHBA=dchd.DanhBo)
,TDVTN_Thue=(select top 1 dchd.PhiBVMT_Thue_Start from KTKS_DonKH.dbo.DCBD_ChiTietHoaDon dchd where hd.NAM=dchd.Nam and hd.KY=dchd.Ky and hd.DANHBA=dchd.DanhBo)
,TongCong=(select top 1 dchd.TongCong_Start from KTKS_DonKH.dbo.DCBD_ChiTietHoaDon dchd where hd.NAM=dchd.Nam and hd.KY=dchd.Ky and hd.DANHBA=dchd.DanhBo)

,hd.ky,hd.nam from HOADON hd where MaNV_DangNgan is not null and year(NGAYGIAITRACh)=2023 and month(NGAYGIAITRACh)=9
and ID_HOADON in (select FK_HOADON from DIEUCHINH_HD) and (hd.NAM<2022 or (hd.nam=2022 and hd.ky<=4))  
order by hd.SOHOADON