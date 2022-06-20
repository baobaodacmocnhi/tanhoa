select t1.DanhBa,DS=TieuThuMoi,TT=t2.tieuthu from
(select * from DocSo where nam=2022 and KY=06)t1,
(select * from (select DanhBo=b.danhBa from server9.HOADON_TA.dbo.TT_QuetTam a,server9.HOADON_TA.dbo.HOADon b where a.createby=0 and a.MaHD=b.ID_HOADON) db,
(select * from server9.HOADON_TA.dbo.HOADon where Nam=2022 and ky=06) hd where db.DanhBo=hd.danhba)t2
where t1.DanhBa=t2.DanhBo and TieuThuMoi=0