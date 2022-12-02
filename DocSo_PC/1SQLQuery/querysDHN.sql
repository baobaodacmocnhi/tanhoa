
  
  --update [DHTM_DAGAN] set CSTRUNGMIN=(select TBTT from DocSoTH.dbo.DocSo where DanhBa=DHN_DANHBO and Nam=2022 and Ky=5)
  --,NG1=(select GIOGHI from DocSoTH.dbo.DocSo where DanhBa=DHN_DANHBO and Nam=2022 and Ky=1)
  --,CS1=(select CSMoi from DocSoTH.dbo.DocSo where DanhBa=DHN_DANHBO and Nam=2022 and Ky=1)
  --,NG2=(select GIOGHI from DocSoTH.dbo.DocSo where DanhBa=DHN_DANHBO and Nam=2022 and Ky=2)
  --,CS2=(select CSMoi from DocSoTH.dbo.DocSo where DanhBa=DHN_DANHBO and Nam=2022 and Ky=2)
  --,NG3=(select GIOGHI from DocSoTH.dbo.DocSo where DanhBa=DHN_DANHBO and Nam=2022 and Ky=2)
  --,CS3=(select CSMoi from DocSoTH.dbo.DocSo where DanhBa=DHN_DANHBO and Nam=2022 and Ky=3)
  --,NG4=(select GIOGHI from DocSoTH.dbo.DocSo where DanhBa=DHN_DANHBO and Nam=2022 and Ky=4)
  --,CS4=(select CSMoi from DocSoTH.dbo.DocSo where DanhBa=DHN_DANHBO and Nam=2022 and Ky=4)
  --,NG5=(select GIOGHI from DocSoTH.dbo.DocSo where DanhBa=DHN_DANHBO and Nam=2022 and Ky=5)
  --,CS5=(select CSMoi from DocSoTH.dbo.DocSo where DanhBa=DHN_DANHBO and Nam=2022 and Ky=5)
  
  select * from [DHTM_DAGAN] where NG2 is null
  
  --update [DHTM_DAGAN] set NG5=(select denngay from DocSoTH.dbo.DocSo where DanhBa=DHN_DANHBO and Nam=2022 and Ky=5) where NG5 is null

  insert into sDHN.dbo.sDHN_TCT(DanhBo,serialnumber)

  select serialnumber= CASE WHEN ttkh.HIEUDH='EMS' THEN ISNULL((select Serial_number from [sDHN].[dbo].[DHN_PHAMLAM] where DANHBO=dhn.DanhBo),0) ELSE ttkh.SOTHANDH END ,
IDLogger=ISNULL((select IDLogger from [sDHN].[dbo].[sDHN] where DanhBo=dhn.DanhBo),0),
IDLogger=ISNULL((select IDLogger from [sDHN].[dbo].[sDHN] where DanhBo=dhn.DanhBo),0), 
sim='',
dhn.DanhBo,dot_ds=SUBSTRING(ttkh.LOTRINH,1,2),so_ds=SUBSTRING(ttkh.LOTRINH,3,2),MLT=ttkh.LOTRINH
,ttkh.HOTEN,ttkh.SONHA,ttkh.TENDUONG,phuong=(select tenphuong from CAPNUOCTANHOA.dbo.PHUONG where MAPHUONG=ttkh.PHUONG and MAQUAN=ttkh.QUAN)
,quan=(select tenquan from CAPNUOCTANHOA.dbo.QUAN where MAQUAN=ttkh.QUAN)
,DIENTHOAI=(select top 1 DienThoai from CAPNUOCTANHOA.dbo.SDT_DHN where DanhBo=ttkh.DANHBO order by CreateDate desc)
,ttkh.NGAYTHAY,ttkh.HIEUDH,ttkh.CODH,ttkh.SOTHANDH,vitri=ttkh.VITRIDHN,chisobao='',loaibaothay='',goclapdat=case when ttkh.ViTriDHN_Hop=1 then N'Hộp' else '' end
,tt.tgbh_pin,tt.loai_pin,tt.so_phe_duyet,tt.cty_phe_duyet,tt.chong_nuoc,tt.cong_nghe,tt.ket_noi,hieuluc=1
,tt.chu_ky_phat_song,tt.so_lan_gui_lai,ttkh.MADMA,tt.id_cty,tt.id_donvi,gps_latitude=(select top 1 gps_latitude from CAPNUOCTANHOA.dbo.DanhBoGPS where DanhBo=ttkh.DANHBO),gps_lontitude=(select top 1 gps_lontitude from CAPNUOCTANHOA.dbo.DanhBoGPS where DanhBo=ttkh.DANHBO),gps_lontitude='',hl=1
from (SELECT DanhBo=DHN_DANHBO,DIACHI,REPLACE(DHN_TODS,'DHTM-','TH-') AS MADMA,HCT_HIEUDHNGAN AS HG,HCT_SOTHANGAN AS STGAN, HCT_CHISOGAN AS CSGa, HCT_CODHNGAN AS COGAN, 
CAST(HCT_NGAYGAN as date) AS NGAYGAN  ,CAST(HCT_NGAYKIEMDINH as date) AS KD,  
[DHN_SOTHAN] AS SOTHAN,HCT_SOTHANGO AS THANGO, [DHN_CHISO] AS CSB,HCT_CHISOGO AS CSG, HCT_CHISOGO-DHN_CHISO AS SS,[HCT_CREATEBY], [HCT_MODIFYBY]
FROM CAPNUOCTANHOA.dbo.TB_THAYDHN WHERE DHN_LOAIBANGKE='DHTM' AND HCT_NGAYGAN IS NOT NULL -- and HCT_HIEUDHNGAN='RYNAN'
) dhn,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh,[sDHN].[dbo].[DHTM_THONGTIN] tt
where dhn.DanhBo=ttkh.DANHBO and dhn.HG=tt.HIEU_DHTM
order by dhn.NGAYGAN asc