USE [HOADON_TA]
GO
/****** Object:  StoredProcedure [dbo].[spSyncThanhToan]    Script Date: 28/10/2020 9:33:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSyncThanhToan]
	-- Add the parameters for the stored procedure here
	@MaHD int,
	@GiaiTrach varchar(7),
	@IDTemp_SyncHoaDon int,
	@LoaiThanhToan varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
		declare @Url varchar(1024)
		declare @SoapAction varchar(1024) = null
		declare @ParamsValues nvarchar(1000)

		set @Url = 'http://192.168.90.11:81/wsThuTien.asmx'
		
		set @ParamsValues = '<MaHD>'+CONVERT(varchar(11),@MaHD)+'</MaHD>'
		set @ParamsValues = @ParamsValues+'<GiaiTrach>'+@GiaiTrach+'</GiaiTrach>'
		set @ParamsValues = @ParamsValues+'<IDTemp_SyncHoaDon>'+CONVERT(varchar(11),@IDTemp_SyncHoaDon)+'</IDTemp_SyncHoaDon>'
		
		if(@LoaiThanhToan='GiaiTrach')
			set @SoapAction = 'syncThanhToan'
		else
			if(@LoaiThanhToan='ThuHo')
				set @SoapAction = 'syncThanhToan_ThuHo'

		declare @obj int
			,@response varchar(8000)
			,@responseXml xml
			,@method varchar(10) = 'POST'
			
		exec sp_OACreate 'MSXML2.ServerXMLHttp', @obj out
		exec sp_OAMethod @obj, 'Open', null, @method, @Url, false
		
		if @SoapAction is null
			raiserror('@SoapAction is null', 10, 1)

		declare @host varchar(1024) = @Url
		if @host like 'http://%'
			set @host = right(@host, len(@host) - 7)
		else if @host like 'https://%'
			set @host = right(@host, len(@host) - 8)

		if charindex(':', @host) > 0 and charindex(':', @host) < charindex('/', @host)
			set @host = left(@host, charindex(':', @host) - 1)
		else 
			set @host = left(@host, charindex('/', @host) - 1)

		declare @envelope nvarchar(1000) = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><{action} xmlns="http://tempuri.org/">{params}</{action}></soap:Body></soap:Envelope>'

		set @envelope = replace(@envelope, '{action}', @SoapAction)
		set @envelope = replace(@envelope, '{params}', @ParamsValues)

		set @SoapAction = 'http://tempuri.org/' + @SoapAction

		--print @host
		--print @SoapAction
		--print @envelope

		exec sp_OAMethod @obj, 'setRequestHeader', null, 'Content-Type', 'text/xml; charset=utf-8'
		exec sp_OAMethod @obj, 'setRequestHeader', null, 'Host', @host
		exec sp_OAMethod @obj, 'setRequestHeader', null, 'SOAPAction', @SoapAction
		exec sp_OAMethod @obj, 'send', null, @envelope

		exec sp_OAGetProperty @obj, 'responseText', @response out
		exec sp_OADestroy @obj

		--InsertOnSubmit with linq không đc có kết quả trả về
		--execute query thì đc có kết quả trả về
		set @response=REPLACE(@response, '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><soap:Body><syncThanhToanResponse xmlns="http://tempuri.org/">', '')
		set @response=REPLACE(@response, '</syncThanhToanResponse></soap:Body></soap:Envelope>', '')
		set @response=REPLACE(@response, '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><soap:Body><syncThanhToan_ThuHoResponse xmlns="http://tempuri.org/">', '')
		set @response=REPLACE(@response, '</syncThanhToan_ThuHoResponse></soap:Body></soap:Envelope>', '')
		select [response]=@response
		
END
