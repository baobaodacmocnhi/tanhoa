select DANHBA,hd.DOT,hd.KY,hd.NAM,SoHoaDonCu,GiaBieu,DinhMuc,dc.DinhMucHN,dc.[TieuThu]
		,[TienNuoc_Start]
      ,[ThueGTGT_Start]
      ,[PhiBVMT_Start]
      ,[TongCong_Start]
	  ,hd.SoHoaDon
	  ,GiaBieu_BD,DinhMuc_BD,dc.DinhMucHN_BD,dc.[TieuThu_BD]
	  ,[TienNuoc_End]
      ,[ThueGTGT_End]
      ,[PhiBVMT_End]
      ,[TongCong_End]

	  ,[TienNuoc_BD]
      ,[ThueGTGT_BD]
      ,[PhiBVMT_BD]
      ,[TongCong_BD]
	  ,[TangGiam]
	  from HOADON hd,[SERVER11].[KTKS_DonKH].[dbo].[DCBD_ChiTietHoaDon] dc
where CAST(NGAYGIAITRACH as date)>='20201201' and (hd.NAM>2020 or (hd.NAM=2020 and hd.KY>=7)) and MaNV_DangNgan is not null and SoHoaDonCu is not null
and hd.SoHoaDonCu=dc.SoHoaDon
order by NGAYGIAITRACH

select * from HOADON where ID_HOADON=22666187
select * from TT_DichVuThu where MaHD=22666187

--update HOADON set SyncNopTien=1 where ID_HOADON=22022393

--update TT_DichVuThu set SoHoaDon=(select SoHoaDon from HOADON where ID_HOADON=MaHD) where Nam=2021 and ky=1 and SOHOADON like 'CT/21E%'
update TT_DichVuThu set SoHoaDon=(select SoHoaDon from HOADON where ID_HOADON=MaHD) where MaHD=22666187

--select SOHOADON,SUBSTRING(SOHOADON,1,6),SUBSTRING(SOHOADON,7,7) from hoadon where nam=2021 and SOHOADON like 'CT/21E%'
--update HOADON set SOHOADON='CT/20E'+SUBSTRING(SOHOADON,7,7) where nam=2021 and SOHOADON like 'CT/21E%'

select SOPHATHANH,hd.SOHOADON,TONGCONG,TONGCONG_Truoc=dc.TONGCONG_BD from HOADON hd
left join DIEUCHINH_HD dc on dc.FK_HOADON=hd.ID_HOADON
where CAST(NGAYGIAITRACH as date)='20220110'  and MaNV_DangNgan is not null

--hd điều chỉnh phí bvmt
select hd.danhba,tv.danhbo,ID_DIEUCHINH_HD,FK_HOADON,tt.PHI_BD,mactdchd,phibvmt_start,phibvmt_start-phi_bd,hd.TIEUTHU from DIEUCHINH_HD tt,HOADON hd,server11.KTKS_DonKH.dbo.DCBD_ChiTietHoaDon tv
where  hd.MaNV_DangNgan is null and PHIEU_DC is not null
and tt.FK_HOADON=hd.ID_HOADON and hd.NAm=tv.Nam and hd.ky=tv.Ky and hd.DANHBA=tv.DanhBo
and tt.phi_bd!=tv.phibvmt_start 