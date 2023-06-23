select a.DanhBo,a.Nam,a.Ky,COUNT(*) from DCBD_ChiTietHoaDon a,HOADON_TA.dbo.HOADON hd
where a.DanhBo=hd.DANHBA and a.Nam=hd.NAM and a.Ky=hd.KY and hd.MaNV_DangNgan is not null and (a.Nam<2022 or (a.Nam=2022 and a.Ky<5))
and CAST(NGAYGIAITRACH as date)='20230622'
group by a.DanhBo,a.Nam,a.Ky
having COUNT(*)>1