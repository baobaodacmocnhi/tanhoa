USE [DocSoTH]
GO

/****** Object:  StoredProcedure [dbo].[calTieuTHu]    Script Date: 11/17/2017 13:10:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[calTieuTHu]
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


