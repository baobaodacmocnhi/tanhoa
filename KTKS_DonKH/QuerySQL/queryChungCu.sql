select DanhBo=DANHBA,ChungCu=TENKH,DiaChi=SO+' '+DUONG,Phuong=(select tenphuong from server8.[CAPNUOCTANHOA].[dbo].phuong where maquan=quan and maphuong=phuong),Quan=(select tenquan from server8.[CAPNUOCTANHOA].[dbo].[QUAN] where maquan=quan) from HOADON where nam=2020 and ky=10 and GB in (51,59,68)