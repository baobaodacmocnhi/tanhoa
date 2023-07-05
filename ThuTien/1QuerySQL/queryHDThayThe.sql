select DANHBA,SOHOADON,GIABAN,THUE,PHI,ThueGTGT_TDVTN,TONGCONG from HOADON where MaNV_DangNgan is not null and year(NGAYGIAITRACh)=2023 and month(NGAYGIAITRACh)=6
and ID_HOADON in (select FK_HOADON from DIEUCHINH_HD) and (NAM<2022 or (nam=2022 and ky<=4))
order by SOHOADON