/****** Script for SelectTopNRows command from SSMS  ******/
SELECT 
lo,stt,MaCT,SoNKDangKy,CreateDate
--sum(sonkdangky)
  FROM [ChungCu].[dbo].[DanhSachChungTu]
  where DanhBo='13162404525'
  order by CreateDate desc
  
