select MaCTKTXM from DonTXL a,LoaiDonTXL b,KTXM c,CTKTXM d
where a.MaLD=b.MaLD and c.MaDonTXL=a.MaDon and c.MaKTXM=d.MaKTXM
and b.MaLD=25 and YEAR(NgayKTXM)=2015 and MONTH(NgayKTXM)=1