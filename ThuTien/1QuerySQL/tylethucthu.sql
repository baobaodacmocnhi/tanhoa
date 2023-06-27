declare @nam int=2023
declare @ky int=5
select Nam=YEAR(NGAYGIAITRACH),Ky=MONTH(NGAYGIAITRACH),TyLeThucThu=SUM(GIABAN)/(select sum(GIABAN) from HOADON where nam=@nam and ky=@ky)*100
from HOADON where nam=@nam and ky=@ky and MaNV_DangNgan is not null and YEAR(NGAYGIAITRACH)=@nam and MONTH(NGAYGIAITRACH)=@ky
group by YEAR(NGAYGIAITRACH),MONTH(NGAYGIAITRACH)