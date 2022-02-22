 declare @nam int;
                         set @nam=2010;
                         select t1.* from
                         (select distinct db.DanhBo,db.HoTen,db.DiaChi,ky1.Ky1,ky2.Ky2,ky3.Ky3,ky4.Ky4,
                         ky5.Ky5,ky6.Ky6,ky7.Ky7,ky8.Ky8,ky9.Ky9,ky10.Ky10,ky11.Ky11,ky12.Ky12
                         from
                         (select hd.DANHBA as DanhBo,HoTen=hd.TENKH,hd.SO+' '+hd.DUONG as DiaChi
                         from HOADON hd
                         where Nam=@nam and Ky=12
						 union all
						 select hd.DANHBA as DanhBo,HoTen=hd.TENKH,hd.SO+' '+hd.DUONG as DiaChi
                         from TT_HoaDonCu hd
                         where Nam=@nam and Ky=12) db
                         left join
                         (select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from HOADON hd
                         where Nam=@nam and KY=1
						 union all
						 select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from TT_HoaDonCu hd
                         where Nam=@nam and KY=1) ky1 on db.DanhBo=ky1.DanhBo
                         left join
                         (select DanhBo=hd.DANHBA,TIEUTHU as Ky2
                         from HOADON hd
                         where Nam=@nam and KY=2
						 union all
						 select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from TT_HoaDonCu hd
                         where Nam=@nam and KY=2) ky2 on db.DanhBo=ky2.DanhBo
                         left join
                         (select DanhBo=hd.DANHBA,TIEUTHU as Ky3
                         from HOADON hd
                         where Nam=@nam and KY=3
						 union all
						 select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from TT_HoaDonCu hd
                         where Nam=@nam and KY=3) ky3 on db.DanhBo=ky3.DanhBo
                         left join
                         (select DanhBo=hd.DANHBA,TIEUTHU as Ky4
                         from HOADON hd
                         where Nam=@nam and KY=4
						 union all
						 select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from TT_HoaDonCu hd
                         where Nam=@nam and KY=4) ky4 on db.DanhBo=ky4.DanhBo
                         left join
                         (select DanhBo=hd.DANHBA,TIEUTHU as Ky5
                         from HOADON hd
                         where Nam=@nam and KY=5
						 union all
						 select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from TT_HoaDonCu hd
                         where Nam=@nam and KY=5) ky5 on db.DanhBo=ky5.DanhBo
                         left join
                         (select DanhBo=hd.DANHBA,TIEUTHU as Ky6
                         from HOADON hd
                         where Nam=@nam and KY=6
						 union all
						 select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from TT_HoaDonCu hd
                         where Nam=@nam and KY=6) ky6 on db.DanhBo=ky6.DanhBo
                         left join
                         (select DanhBo=hd.DANHBA,TIEUTHU as Ky7
                         from HOADON hd
                         where Nam=@nam and KY=7
						 union all
						 select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from TT_HoaDonCu hd
                         where Nam=@nam and KY=7) ky7 on db.DanhBo=ky7.DanhBo
                         left join
                         (select DanhBo=hd.DANHBA,TIEUTHU as Ky8
                         from HOADON hd
                         where Nam=@nam and KY=8
						 union all
						 select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from TT_HoaDonCu hd
                         where Nam=@nam and KY=8) ky8 on db.DanhBo=ky8.DanhBo
                         left join
                         (select DanhBo=hd.DANHBA,TIEUTHU as Ky9
                         from HOADON hd
                         where Nam=@nam and KY=9
						 union all
						 select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from TT_HoaDonCu hd
                         where Nam=@nam and KY=9) ky9 on db.DanhBo=ky9.DanhBo
                         left join
                         (select DanhBo=hd.DANHBA,TIEUTHU as Ky10
                         from HOADON hd
                         where Nam=@nam and KY=10
						 union all
						 select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from TT_HoaDonCu hd
                         where Nam=@nam and KY=10) ky10 on db.DanhBo=ky10.DanhBo
                         left join
                         (select DanhBo=hd.DANHBA,TIEUTHU as Ky11
                         from HOADON hd
                         where Nam=@nam and KY=11
						 union all
						 select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from TT_HoaDonCu hd
                         where Nam=@nam and KY=11) ky11 on db.DanhBo=ky11.DanhBo
                         left join
                         (select DanhBo=hd.DANHBA,TIEUTHU as Ky12
                         from HOADON hd
                         where Nam=@nam and KY=12
						 union all
						 select DanhBo=hd.DANHBA,TIEUTHU as Ky1
                         from TT_HoaDonCu hd
                         where Nam=@nam and KY=12) ky12 on db.DanhBo=ky12.DanhBo) t1