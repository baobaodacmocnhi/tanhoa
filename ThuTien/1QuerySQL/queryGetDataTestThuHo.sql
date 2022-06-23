select DANHBA from HOADON where NGAYGIAITRACH is null and MaNV_DangNgan is null and ID_HOADON not in (select MaHD from TT_DichVuThu) and TONGCONG<=10000 and DANHBA in (select DanhBo from TT_KQDongNuoc where DanhBo=DANHBA and MoNuoc=0 and TroNgaiMN=0)
group by DANHBA
having count(*)>1