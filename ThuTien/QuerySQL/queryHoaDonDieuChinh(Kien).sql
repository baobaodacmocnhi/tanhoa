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
--update HOADON set SyncNopTien=1 where ID_HOADON=22022393