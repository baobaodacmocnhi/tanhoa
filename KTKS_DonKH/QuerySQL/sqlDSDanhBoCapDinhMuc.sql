select t1.*,t2.TIEUTHU from
(select ct.DanhBo,ttkh.HoTen,ttkh.DiaChi,Phuong,Quan,case when DinhMuc_BD is null then DinhMuc else DinhMuc_BD end as DinhMuc from
(select DanhBo from ChungTu ct,CTChungTu ctct,LoaiChungTu lct where ct.MaCT=ctct.MaCT and lct.MaLCT=ct.MaLCT and NgayHetHan is not null and Cat=0
and (lct.MaLCT=2 or lct.MaLCT=5 or lct.MaLCT=6 or lct.MaLCT=7 or lct.MaLCT=8)
group by DanhBo) ct
left join
(select DanhBo,HoTen,DC1+' '+DC2 as DiaChi,Phuong,Quan from TTKhachHang) ttkh on ct.DanhBo=ttkh.DanhBo
left join
(select DanhBo,DinhMuc,DinhMuc_BD,ROW_NUMBER() OVER (PARTITION BY DanhBo ORDER BY CreateDate DESC) AS rn from CTDCBD) dcbd on ct.DanhBo=dcbd.DanhBo
where rn=1) t1
left join
(select DANHBA,TIEUTHU,ROW_NUMBER() OVER (PARTITION BY DanhBa ORDER BY ID_HOADON DESC) AS rn from HOADON_TA.dbo.HOADON) t2 on t1.DanhBo=t2.DANHBA
where rn=1