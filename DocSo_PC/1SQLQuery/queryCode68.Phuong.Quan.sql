select DanhBa,MLT1,SoNhaCu,Duong,GB,DM,Nam,Ky,Dot,CodeMoi
,Phuong=(select TenPhuong from CAPNUOCTANHOA.dbo.PHUONG where MAPHUONG=(select Phuong from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DANHBO=DanhBa) and MAQUAN=(select QUAN from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DANHBO=DanhBa))
,Quan=(select TENQUAN from CAPNUOCTANHOA.dbo.QUAN where MAQUAN=(select QUAN from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DANHBO=DanhBa)) from DocSo where nam=2023 and ky=6 and CodeMoi like '68'