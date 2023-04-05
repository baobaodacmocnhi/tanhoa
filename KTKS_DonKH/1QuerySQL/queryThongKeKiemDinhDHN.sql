select DanhBo
,Hieu=(select HieuDH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG.DANHBO=ThuTraLoi_ChiTiet.DanhBo)
,Co=(select CoDH from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG.DANHBO=ThuTraLoi_ChiTiet.DanhBo)
,KetQua=case when NoiDung like N'%có sai số%' then N'Không Đạt'
when NoiDung like N'%đạt yêu cầu kỹ thuật%' then N'Đạt'
when NoiDung like N'%đạt yêu cầu%' then N'Đạt'
when NoiDung like N'%chạy nhanh%' then N'Không Đạt' 
when NoiDung like N'%chạy chậm%' then N'Không Đạt' end
from ThuTraLoi_ChiTiet where VeViec like N'%kiểm định%' and YEAR(CreateDate)=2023