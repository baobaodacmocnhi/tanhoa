select SOPHATHANH,hd.SOHOADON,TONGCONG,TONGCONG_Truoc=dc.TONGCONG_BD from HOADON hd
left join DIEUCHINH_HD dc on dc.FK_HOADON=hd.ID_HOADON
where CAST(NGAYGIAITRACH as date)='20220110'  and MaNV_DangNgan is not null

--hd điều chỉnh phí bvmt
select hd.danhba,tv.danhbo,ID_DIEUCHINH_HD,FK_HOADON,tt.PHI_BD,mactdchd,phibvmt_start,phibvmt_start-phi_bd,hd.TIEUTHU from DIEUCHINH_HD tt,HOADON hd,server11.KTKS_DonKH.dbo.DCBD_ChiTietHoaDon tv
where  hd.MaNV_DangNgan is null and PHIEU_DC is not null
and tt.FK_HOADON=hd.ID_HOADON and hd.NAm=tv.Nam and hd.ky=tv.Ky and hd.DANHBA=tv.DanhBo
and tt.phi_bd!=tv.phibvmt_start 