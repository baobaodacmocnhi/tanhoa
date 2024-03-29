USE [HOADON_TA]
GO
/****** Object:  StoredProcedure [dbo].[spSendNotificationToClient_Stored]    Script Date: 28/10/2020 9:33:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSendNotificationToClient_Stored]
	-- Add the parameters for the stored procedure here
	@Loai varchar(10),
	@ID varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @Title nvarchar(200),
	@Content nvarchar(200),
	@MaNV varchar(5),@UID varchar(200),
	@Action varchar(50),
	@ActionDetail varchar(50),
	--@ID varchar(50),
	@MLT varchar(10),@DanhBo varchar(11),@DiaChi varchar(200),@Ky varchar(11),@TongCong varchar(10)
	
	if(@Loai='DongPhi')
	begin
		set @Action='DongPhi';
		set @Title=N'Thông Báo Đã Đóng Phí Mở Nước'
		set @ActionDetail='DongPhi'
		select @MaNV=MaNV_DongNuoc,@MLT=kqdn.MLT,@DanhBo=dn.DanhBo,@DiaChi=dn.DiaChi from TT_DongNuoc dn,TT_KQDongNuoc kqdn where dn.MaDN=kqdn.MaDN and dn.MaDN=@ID--dùng tạm,lúc trigger sẽ truyền MaDN
		set @Content=@MLT+' - '+@DanhBo;
	end
	else
	begin
		if exists(select 1 from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and dn.MaDN=ctdn.MaDN and ctdn.MaHD=@ID)
			begin
				set @Action='DongNuoc'
				select @MaNV=MaNV_DongNuoc from TT_DongNuoc dn,TT_CTDongNuoc ctdn where dn.Huy=0 and dn.MaDN=ctdn.MaDN and ctdn.MaHD=@ID
				select @MLT=MALOTRINH,@DanhBo=DANHBA,@DiaChi=(SO+' '+DUONG),@Ky=(convert(varchar(2),KY)+'/'+convert(varchar(4),NAM)),@TongCong=TONGCONG from HOADON where ID_HOADON=@ID
			end
		else
			begin
				set @Action='HanhThu'
				select @MaNV=MaNV_HanhThu,@MLT=MALOTRINH,@DanhBo=DANHBA,@DiaChi=(SO+' '+DUONG),@Ky=(convert(varchar(2),KY)+'/'+convert(varchar(4),NAM)),@TongCong=TONGCONG from HOADON where ID_HOADON=@ID
			end
			
		--set @Content=@MLT+' - '+@DanhBo+' - '+@DiaChi+' - '+@Ky+' - '+@TongCong;
		set @Content=@MLT+' - '+@DanhBo+' - '+@Ky+' - '+@TongCong;
		
		if(@Loai='GiaiTrach')
		begin
			set @Title=N'Thông Báo Đã Giải Trách'
			set @ActionDetail='GiaiTrach'
		end
		else
			if(@Loai='TamThu')
			begin
				set @Title=N'Thông Báo Đã Tạm Thu'
				set @ActionDetail='TamThu'
			end
			else
				if(@Loai='ThuHo')
				begin
					set @Title=N'Thông Báo Đã Thu Hộ'
					set @ActionDetail='ThuHo'
				end
				else
					return
	end
	
	--break nếu chưa giao
	if(@MaNV is null)
		return
			
	declare @getCursor cursor
	set @getCursor=cursor for select UID from TT_DeviceSigned where MaNV=@MaNV

	open @getCursor
	fetch next
	from @getCursor into @UID
	while @@FETCH_STATUS=0
	begin
	
		-- Insert statements for procedure here
		declare @Url varchar(1024)
		declare @HttpMethod varchar(10)
		declare @ParamsValues varchar(1024)   -- param1=value&param2=value
		declare @SoapAction varchar(1024) = null

		set @Url = 'http://192.168.90.11:81/service.asmx'
		set @HttpMethod = 'soap'
		set @ParamsValues = 'Title='+@Title+'&Content='+@Content+'&UID='+@UID+'&Action='+@Action+'&ActionDetail='+@ActionDetail+'&ID='+@ID
		set @SoapAction = 'TT_SendNotificationToClient'

		if @HttpMethod in ('get','GET') and len(@ParamsValues) > 0
		begin
			set @Url = @Url + '?' + @ParamsValues
		end

		declare @obj int
			,@response varchar(8000)
			,@responseXml xml
			--,@status varchar(50)
			--,@statusText varchar(1024)
			,@method varchar(10) = (case when @HttpMethod in ('soap','SOAP') then 'POST' else @HttpMethod end)

		exec sp_OACreate 'MSXML2.ServerXMLHttp', @obj out
		exec sp_OAMethod @obj, 'Open', null, @method, @Url, false

		if @HttpMethod in ('get','GET')
		begin
			exec sp_OAMethod @obj, 'send'
		end
		else if @HttpMethod in ('post','POST')
		begin
			exec sp_OAMethod @obj, 'setRequestHeader', null, 'Content-Type', 'text/xml; charset=utf-8'--'application/x-www-form-urlencoded'
			exec sp_OAMethod @obj, 'send', null, @ParamsValues
		end
		else if @HttpMethod in ('soap','SOAP')
		begin
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

			declare @envelope varchar(8000) = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><{action} xmlns="http://tempuri.org/">{params}</{action}></soap:Body></soap:Envelope>'
			declare @params varchar(8000) = '' 

			WHILE LEN(@ParamsValues) > 0
			BEGIN
				declare @param varchar(256),
						@value varchar(256)

				IF charindex('&', @ParamsValues) > 0
				BEGIN

					SET @param = left(@ParamsValues, charindex('&', @ParamsValues) - 1)
					set @value = RIGHT(@param, len(@param) - charindex('=', @param))
					set @param = left(@param, charindex('=', @param) - 1)
					set @params = @params + '<' + @param + '>' + @value + '</'+ @param + '>'
					SET @ParamsValues = right(@ParamsValues, LEN(@ParamsValues) - LEN(@param + '=' + @value + '&'))
				END
				ELSE
				BEGIN
					set @value = RIGHT(@ParamsValues, len(@ParamsValues) - charindex('=', @ParamsValues))
					set @param = left(@ParamsValues, charindex('=', @ParamsValues) - 1)

					set @params = @params + '<' + @param + '>' + @value + '</'+ @param + '>'
					SET @ParamsValues = NULL
				END
			END

			set @envelope = replace(@envelope, '{action}', @SoapAction)
			set @envelope = replace(@envelope, '{params}', @params)

			set @SoapAction = 'http://tempuri.org/' + @SoapAction

			print @host
			print @SoapAction
			print @envelope

			exec sp_OAMethod @obj, 'setRequestHeader', null, 'Content-Type', 'text/xml; charset=utf-8'
			exec sp_OAMethod @obj, 'setRequestHeader', null, 'Host', @host
			exec sp_OAMethod @obj, 'setRequestHeader', null, 'SOAPAction', @SoapAction
			exec sp_OAMethod @obj, 'send', null, @envelope
		end

		exec sp_OAGetProperty @obj, 'responseText', @response out
		exec sp_OADestroy @obj

		--InsertOnSubmit with linq không đc có kết quả trả về
		--execute query thì đc có kết quả trả về
		--select @response as [response]
	
		fetch next
		from @getCursor into @UID
	end

	close @getCursor
	deallocate @getCursor

END
