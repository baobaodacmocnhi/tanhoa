create view vDonTuLichSu as
WITH dtls_temp AS
(
SELECT dtls.*,ROW_NUMBER() OVER (PARTITION BY dtls.MaDon,dtls.STT ORDER BY dtls.NgayChuyen asc,dtls.ID asc) AS rn
FROM DonTu_ChiTiet dtct, DonTu_LichSu dtls
where dtct.MaDon=dtls.MaDon and dtct.STT=dtls.STT
)
select * from dtls_temp where rn=1