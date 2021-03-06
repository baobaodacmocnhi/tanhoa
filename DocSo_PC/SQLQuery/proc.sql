 --=============================================
CREATE PROCEDURE [dbo].[calTieuTHu]
	 @DANHBO VARCHAR(11),
	 @KY	 INT,
	 @NAM	 INT,
	 @CODE	 NVARCHAR(20),
	 @CSMOI	 INT,
	 @TIEUTHU INT OUTPUT
AS
BEGIN
	 BEGIN TRY
	    
	    -- TH1: TÍNH TIÊU THỤ =0 GỒM CODE [ 'K','N1','N2','N3','68','Q' ]
	    IF @CODE IN ('K','N1','N2','N3','68','Q')
			SET @TIEUTHU=0
	    -- TH2:  TÍNH THEO TRUNG BÌNH ĐỌC SỐ 3 KỲ GỒM CODE ['60','61','62','63','64','66','80','F1','F2','F3','F4']
	    ELSE IF @CODE IN (N'60','61','62','63','64','66','80','F1','F2','F3','F4')
	       BEGIN
				--SELECT @CODE+'deDDD'
				SELECT @TIEUTHU= TBTT FROM DocSoTH.dbo.DocSo WHERE Nam=@NAM AND Ky=@KY AND DanhBa=@DANHBO
				--SELECT @TIEUTHU ,@NAM,@KY,@DANHBO
			END
		-- TH3:	TÍNH THEO A2-A1 GỒM CODE '40','41','42','54','55','56','58','5F','5M','5Q','5K','5N','5','M0','M1','M2','M3'
	    ELSE IF @CODE IN ('40','41','42','54','55','56','58','5F','5M','5Q','5K','5N','5','M0','M1','M2','M3') 
			SELECT @TIEUTHU= @CSMOI-CSCu FROM DocSo WHERE Nam=@NAM AND Ky=@KY AND DanhBa=@DANHBO
		ELSE IF @CODE IN ('81')
			BEGIN	
				DECLARE @CODEkytRUOC VARCHAR(20)
				SELECT @CODEkytRUOC= CodeCu FROM DocSoTH.dbo.DocSo WHERE Nam=@NAM AND Ky=@KY AND DanhBa=@DANHBO
				SELECT @CODEkytRUOC
				IF @CODEkytRUOC IN ('61')
					BEGIN				
						DECLARE @T_CSGO INT
						DECLARE @T_CSGAN INT				
						SELECT @T_CSGO = TMP.HCT_CHISOGO, @T_CSGAN= TMP.HCT_CHISOGAN   FROM (SELECT TOP(1) * FROM CAPNUOCTANHOA.dbo.TB_THAYDHN WHERE DHN_DANHBO=@DANHBO AND ISNULL(HCT_TRONGAI,0) <> 1 ORDER BY DHN_NGAYGAN DESC) AS TMP
						SELECT @TIEUTHU =(@CSMOI-@T_CSGAN)+ (@T_CSGO-CSCu) FROM DocSo WHERE Nam=@NAM AND Ky=@KY AND DanhBa=@DANHBO
					--	SELECT @T_CSGO as csgo,@T_CSGAN as csgan, @CSMOI as csmoi,@TIEUTHU	
					END
				ELSE 
					BEGIN
						DECLARE @Tck INT
						DECLARE @Tnt INT
						DECLARE @T_CSGAN81 INT
						
						SELECT @Tck = DATEDIFF(DD,HCT_NGAYGAN,GETDATE()),@T_CSGAN81=HCT_CHISOGAN   FROM (SELECT TOP(1) * FROM CAPNUOCTANHOA.dbo.TB_THAYDHN WHERE DHN_DANHBO=@DANHBO AND ISNULL(HCT_TRONGAI,0) <> 1 ORDER BY DHN_NGAYGAN DESC) AS TMP
						SELECT @Tnt = DATEDIFF(DD,TuNgay,DenNgay) FROM DocSo WHERE Nam=@NAM AND Ky=@KY AND DanhBa=@DANHBO			
						
						SELECT @TIEUTHU= (@CSMOI-@T_CSGAN81)*ROUND((@Tck/@Tnt), 0) FROM DocSo WHERE Nam=@NAM AND Ky=@KY AND DanhBa=@DANHBO				
						
						--SELECT @Tck,@Tnt,@T_CSGAN81,@TIEUTHU
					END
			END
		ELSE IF @CODE IN (N'82',N'83') 
			BEGIN				
				DECLARE @T_CSGO2 INT
				DECLARE @T_CSGAN2 INT				
				SELECT @T_CSGO2 = TMP.HCT_CHISOGO, @T_CSGAN2= TMP.HCT_CHISOGAN   FROM (SELECT TOP(1) * FROM CAPNUOCTANHOA.dbo.TB_THAYDHN WHERE DHN_DANHBO=@DANHBO AND ISNULL(HCT_TRONGAI,0) <> 1 ORDER BY DHN_NGAYGAN DESC) AS TMP
				--SELECT @T_CSGO2,@T_CSGAN2			 
				SELECT @TIEUTHU =(@CSMOI-@T_CSGAN2)+ (@T_CSGO2-CSCu) FROM DocSo WHERE Nam=@NAM AND Ky=@KY AND DanhBa=@DANHBO
				 				
			END
		ELSE IF @CODE IN (N'X41') 
			BEGIN				
				SELECT @TIEUTHU =(10000+@CSMOI) -CSCu  FROM DocSo WHERE Nam=@NAM AND Ky=@KY AND DanhBa=@DANHBO
				 				
			END
		ELSE IF @CODE IN (N'X51') 
			BEGIN				
				SELECT @TIEUTHU =(100000+@CSMOI) -CSCu  FROM DocSo WHERE Nam=@NAM AND Ky=@KY AND DanhBa=@DANHBO
				 				
			END
	 END TRY
	 BEGIN CATCH
		SELECT   ERROR_NUMBER() AS ErrorNumber ,ERROR_MESSAGE() AS ErrorMessage;  
	 END CATCH
END

GO


ALTER PROC [dbo].[UpdateBienDong]
	@KY varchar(10),
	@NAM INT,
	@DOT varchar(10)
 AS 
  UPDATE  BienDong 
	SET  Hieu=LEFT(t2.HIEUDH,3),SoThan=t2.SOTHANDH,NgayGan=t2.NGAYTHAY, HopDong=t2.DIENTHOAI 
 FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as t2  
 WHERE t2.DANHBO= BienDong.DanhBa  and BienDong.Nam=@NAM  and BienDong.Ky=@KY and BienDong.Dot=@DOT
 GO
 --TenKH=t2.HOTEN, So=t2.SONHA ,Duong=t2.TENDUONG,
 
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


 ALTER PROC [dbo].[UpdateDocSo]
	@KY varchar(10),
	@NAM INT,
	@DOT varchar(10)
 AS 
 
  UPDATE  DocSo 
	SET  SDT= t2.DIENTHOAI,ViTriCu=LEFT(REPLACE(t2.VITRIDHN,' ',''),2)
 FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as t2  
 WHERE t2.DANHBO= DocSo.DanhBa  and DocSo.Nam=@NAM  and DocSo.Ky=@KY and DocSo.Dot=@DOT
 GO
 
 
CREATE PROC [dbo].[UpdateTBTT3KY]
	@DANHBA varchar(12),
	@KY varchar(10),
	@NAM INT,
	@DOT varchar(10)
 AS 

UPDATE DocSo SET TBTT=TB
FROM (select AVG(TieuThu) AS TB from (   SELECT  TOP(3) TieuThu FROM HoaDon WHERE DanhBa=@DANHBA  ORDER   BY  NAM DESC,KY DESC ) as t1 ) AS tb
 WHERE  DocSo.DanhBa =@DANHBA  and DocSo.Nam=@NAM  and DocSo.Ky=@KY and DocSo.Dot=@DOT
                
 --  UPDATE  DocSo 
	--SET  SDT= t2.DIENTHOAI,ViTriCu=LEFT(REPLACE(t2.VITRIDHN,' ',''),2)
 --FROM DocSoTH.dbo.TTDHN as t2  
 --WHERE t2.DANHBO= DocSo.DanhBa  and DocSo.Nam=@NAM  and DocSo.Ky=@KY and DocSo.Dot=@DOT
 
 