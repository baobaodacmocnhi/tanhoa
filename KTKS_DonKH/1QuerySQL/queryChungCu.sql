select DanhBo=DANHBA,ChungCu=TENKH,DiaChi=SO+' '+DUONG,DM,GB
,Phuong=(select tenphuong from [CAPNUOCTANHOA].[dbo].phuong where maquan=quan and maphuong=phuong)
,Quan=(select tenquan from [CAPNUOCTANHOA].[dbo].[QUAN] where maquan=quan)
from HOADON where nam=2023 and ky=9 and GB in (51,59,68)