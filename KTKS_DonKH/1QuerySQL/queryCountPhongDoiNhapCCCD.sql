select HoTen=(select HoTen from Users where MaU=t1.CreateBy),t1.DiaChi,t1.CCCD from
(select CreateBy,DiaChi=count(distinct DanhBo),CCCD=count(MaCT) from ChungTu_ChiTiet where CreateBy in (77,95,96,97,98,99,100,101)
group by CreateBy)t1
union all
select HoTen=N'Phòng Khách Hàng',DiaChi=count(distinct DanhBo),CCCD=count(MaCT) from
(select * from ChungTu_ChiTiet
where (select MaPhong from Users where MaU=ChungTu_ChiTiet.CreateBy)=1 and CAST(CreateDate as date)>='20240417' and SHS is null)t1
order by DiaChi

