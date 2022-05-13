select * from dontu_lichsu where noidung=N'CNÐD' and madon in
(select (select top 1 madon from DonTu_ChiTiet where DanhBo=DCBD_DKDM_DanhBo.danhbo and nam=2022 and ky=5 order by createdate desc) from DCBD_DKDM_DanhBo where CreateBy is not null and MaDon like '')
order by madon