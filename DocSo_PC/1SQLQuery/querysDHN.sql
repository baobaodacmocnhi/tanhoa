
  
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