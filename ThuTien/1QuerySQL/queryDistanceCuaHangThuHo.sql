declare @MaHD int
declare @LocationDHNS varchar(100)
declare @getCursorDHN cursor, @getCursorCH cursor
set @getCursorDHN=cursor for select ID_HOADON,DangNgan_DienThoai_Location from HOADON where nam=2020 and ky=9 and DangNgan_DienThoai_Location is not null

open @getCursorDHN
fetch next
from @getCursorDHN into @MaHD,@LocationDHNS
while @@FETCH_STATUS=0
begin
	declare @NameCH1 nvarchar(100), @NameCH2 nvarchar(100), @NameCH nvarchar(100), @LocationCHS varchar(100)
	declare @Distance1 float=0, @Distance2 float=0
	declare @Lat float=convert(float,SUBSTRING(@LocationDHNS, 1, CHARINDEX(',', @LocationDHNS)-1))
	,@Lot float=convert(float,SUBSTRING(@LocationDHNS, CHARINDEX(',', @LocationDHNS)+1, Len(@LocationDHNS)-CHARINDEX(',', @LocationDHNS)));
	declare @LocationDHN geography= geography::Point(@Lat,@Lot, 4326);
	set @getCursorCH=cursor for select NameCH=[Name]+':'+DiaChi,LocationCH=(select DangNgan_DienThoai_Location from HOADON where nam=2020 and ky=9 and DangNgan_DienThoai_Location is not null and DANHBA=DanhBo) from TT_DichVuThu_CuaHang where DanhBo is not null and DanhBo!=''
		open @getCursorCH
		fetch next
		from @getCursorCH into @NameCH,@LocationCHS
		while @@FETCH_STATUS=0
		begin
			if(@LocationCHS is not null)
			begin
				set @Lat=convert(float,SUBSTRING(@LocationCHS, 1, CHARINDEX(',', @LocationCHS)-1))
				set @Lot=convert(float,SUBSTRING(@LocationCHS, CHARINDEX(',', @LocationCHS)+1, Len(@LocationCHS)-CHARINDEX(',', @LocationCHS)));
				declare @LocationCH geography= geography::Point(@Lat,@Lot, 4326);
				declare @Distance float=@LocationDHN.STDistance(@LocationCH)
				if(@Distance<=1000)
					begin
						if(@Distance1=0)
							begin
								set @NameCH1=@NameCH
								set @Distance1=@Distance
							end
						else
							if(@Distance1>@Distance)
								begin
									set @NameCH2=@NameCH1
									set @Distance2=@Distance1
									set @NameCH1=@NameCH
									set @Distance1=@Distance
								end
							else
								if(@Distance2=0)
									begin
										set @NameCH2=@NameCH
										set @Distance2=@Distance
									end
								else
									if(@Distance2>@Distance)
										begin
											set @NameCH2=@NameCH
											set @Distance2=@Distance
										end
					end
				end
			fetch next
			from @getCursorCH into @NameCH,@LocationCHS
		end
		close @getCursorCH
		deallocate @getCursorCH

		update HOADON set CuaHangThuHo=N'Dịch Vụ Thu Hộ:'+CHAR(13)+@NameCH1+CHAR(13)+@NameCH2 where ID_HOADON=@MaHD

	fetch next
	from @getCursorDHN into @MaHD,@LocationDHNS
end
close @getCursorDHN
deallocate @getCursorDHN
