declare @i int
set @i=0
while(@i<=24)
begin
	insert into DetailRoles(MaU,MaR,QuyenCapNhat,QuyenXem)values(@i,12,0,0)
	set @i+=1
end