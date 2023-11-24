


select * from DonTu where CAST(CreateDate as date)>='20230101' and CAST(CreateDate as date)<='20231123'
and ( Name_NhomDon_PKH like N'%Chỉ số nước%'
or Name_NhomDon_PKH like N'%ĐHN (đứt chì, chạy nhanh,...)%'
or Name_NhomDon_PKH like N'%Tiền nước, giá nước%'
or Name_NhomDon_PKH like N'%Gian lận%'
or Name_NhomDon_PKH like N'%Thời gian giải quyết hồ sơ%'
or Name_NhomDon_PKH like N'%Thái độ phục vụ khách hàng%'
)

and Name_NhomDon_PKH not like ''