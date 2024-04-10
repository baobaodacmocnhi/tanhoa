select * from DCBD_ChiTietBienDong dc where HieuLucKy in ('02/2024','03/2024') and DinhMuc_BD >0
and (select count(*) from ChungTu_ChiTiet ct where MaLCT=15 and cat=0 and ct.DanhBo=dc.DanhBo)=0