select distinct dn.MaDN,dn.CreateBy,dn.* from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd
where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0 and hd.MaNV_DangNgan is null
and dn.CreateBy in (2,39,23,15,13,43,44,34,45) and hd.DOT<=8

select * from HOADON where DANHBA='13132116200' and (ky=3 or ky=4) and nam=2022

update TT_DongNuoc set CreateBy_Old=CreateBy,CreateDate_Old=GETDATE(),CreateBy=(select MaNV_HanhThu from HOADON where DANHBA=TT_DongNuoc.DanhBo and NAM=2022 and KY=4)
where MaDN in (select distinct dn.MaDN from TT_DongNuoc dn,TT_CTDongNuoc ctdn,HOADON hd
where dn.MaDN=ctdn.MaDN and ctdn.MaHD=hd.ID_HOADON and dn.Huy=0 and hd.MaNV_DangNgan is null
 and hd.DOT>=9 and hd.DOT<=10
)