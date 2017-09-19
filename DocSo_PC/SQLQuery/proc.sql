

CREATE PROC [dbo].[UpdateBienDong]
	@KY varchar(10),
	@NAM INT,
	@DOT varchar(10)
 AS 
  UPDATE  BienDong 
	SET  TenKH=t2.HOTEN, So=t2.SONHA ,Duong=t2.TENDUONG,Hieu=LEFT(t2.HIEUDH,3)
 FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as t2  
 WHERE t2.DANHBO= BienDong.DanhBa  and BienDong.Nam=@NAM  and BienDong.Ky=@KY and BienDong.Dot=@DOT
 
 
 
ALTER PROC [dbo].[GetSoDocSo]
	@NAM INT,
	@KY varchar(10),	
	@DOT varchar(10),
	@TUMAY INT,
	@DENMAY INT
AS
BEGIN TRY
	IF (select COUNT(*) from DocSo where Nam=@NAM AND Ky=@KY AND Dot=@DOT )>0 
		BEGIN
			select May,COUNT(*) AS SOLUONG , 'True' as DaTao ,NVTaoDS,NgayTaoDS from DocSo WHERE (May BETWEEN @TUMAY AND @DENMAY )AND Nam=@NAM AND Ky=@KY AND Dot=@DOT group by May,NVTaoDS,NgayTaoDS ORDER BY May ASC
		END
	ELSE
		BEGIN
			select May,COUNT(*) AS SOLUONG , 'False' as DaTao ,'' AS NVTaoDS, '' AS NgayTaoDS from BienDong WHERE (May BETWEEN @TUMAY AND @DENMAY )AND Nam=@NAM AND Ky=@KY AND Dot=@DOT group by May ORDER BY May ASC			 
		END
	 
END TRY
BEGIN CATCH   
    SELECT 'Lỗi Hệ Thống'   
END CATCH;

GO

select May,COUNT(*) AS SOLUONG , 'False' as DaTao ,'' AS NVTaoDS, '' AS NgayTaoDS from BienDong WHERE (May BETWEEN 0 AND 100 )AND Nam=2017 AND Ky='10' AND Dot='01' group by May ORDER BY May ASC