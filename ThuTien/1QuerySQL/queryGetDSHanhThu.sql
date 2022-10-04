select * from
                             (select ID=ID_HOADON,MaHD=ID_HOADON,MLT=MALOTRINH,hd.SoHoaDon,Ky=CAST(hd.KY as varchar)+'/'+CAST(hd.NAM as varchar),DanhBo=hd.DANHBA,HoTen=hd.TENKH,DiaChi=case when hd.SO is null then hd.DUONG else case when hd.DUONG is null then hd.SO else hd.SO+' '+hd.DUONG end end,CoDH
                             ,GiaBieu=GB,DinhMuc=DM,DinhMucHN,CSC=CSCU,CSM=CSMOI,Code,TieuThu,TuNgay=CONVERT(varchar(10),TUNGAY,103),DenNgay=CONVERT(varchar(10),DenNgay,103),GiaBan,ThueGTGT=Thue,PhiBVMT=Phi,PhiBVMT_Thue=case when ThueGTGT_TDVTN is null then 0 else ThueGTGT_TDVTN end,TongCong
                             ,GiaiTrach=case when hd.NgayGiaiTrach is not null then 'true' else 'false' end
                             ,TamThu=case when exists(select ID_TAMTHU from TAMTHU where FK_HOADON=hd.ID_HOADON) then 'true' else 'false' end
                             ,ThuHo=case when exists(select MaHD from TT_DichVuThu where MaHD=hd.ID_HOADON) then 'true' else 'false' end
                             ,ModifyDate=case when exists(select MaHD from TT_DichVuThu where MaHD=hd.ID_HOADON) then (select CreateDate from TT_DichVuThu where MaHD=hd.ID_HOADON) else NULL end
                             ,DangNgan_DienThoai
                             ,MaNV_DangNgan,NgayGiaiTrach,XoaDangNgan_Ngay_DienThoai,InPhieuBao_Ngay,InPhieuBao2_Ngay,InPhieuBao2_NgayHen,TBDongNuoc_NgayHen,DCHD,TienDuTruoc_DCHD
                             ,TBDongNuoc_Ngay=(select a.CreateDate from TT_DongNuoc a,TT_CTDongNuoc b where a.MaDN=b.MaDN and Huy=0 and b.MaHD=hd.ID_HOADON)
                             ,PhiMoNuoc=(select dbo.fnGetPhiMoNuoc(hd.DANHBA))
                             ,PhiMoNuocThuHo=(select a.PhiMoNuoc from TT_DichVuThuTong a,TT_DichVuThu b where b.MaHD=hd.ID_HOADON and a.ID=b.IDDichVu)
                             ,MaKQDN=(select count( MaKQDN) from TT_DongNuoc a,TT_KQDongNuoc b where a.Huy=0 and b.DanhBo=hd.DANHBA and b.MoNuoc=0 and b.TroNgaiMN=0 and a.MaDN=b.MaDN)
                             --,DongPhi =(select DongPhi from TT_DongNuoc a,TT_KQDongNuoc b where a.Huy=0 and b.DanhBo=hd.DANHBA and b.MoNuoc=0 and b.TroNgaiMN=0 and a.MaDN=b.MaDN)
                             ,LenhHuy=case when exists(select MaHD from TT_LenhHuy where MaHD=hd.ID_HOADON) then 'true' else 'false' end
                             ,LenhHuyCat=case when exists(select MaHD from TT_LenhHuy where MaHD=hd.ID_HOADON and Cat=1) then 'true' else 'false' end
                             ,DiaChiDHN=(select DiaChi from TT_DiaChiDHN where DanhBo=hd.DANHBA)
                             ,DongA=case when exists(select DanhBo from TT_DuLieuKhachHang_DanhBo where DanhBo=hd.DANHBA) then 'true' else 'false' end
                             ,CuaHangThuHo1,CuaHangThuHo2,ChiTietTienNuoc
                             from HOADON hd
                             where (NAM<2022  or (NAM= 2022  and Ky<= 10 )) and DOT>=1  and DOT<= 1  and MaNV_HanhThu=16
                             and (NGAYGIAITRACH is null or CAST(NGAYGIAITRACH as date)=CAST(GETDATE() as date))
                             and hd.ID_HOADON not in (select MaHD from TT_TraGop)
                             and hd.ID_HOADON not in (select FK_HOADON from DIEUCHINH_HD,HOADON where CodeF2=1 and NGAYGIAITRACH is null and ID_HOADON=FK_HOADON)
                             and hd.ID_HOADON not in (select FK_HOADON from DIEUCHINH_HD,HOADON where NGAYGIAITRACH is null and ID_HOADON=FK_HOADON and SoHoaDonMoi is null and SoPhieu is null)
                             )t1
							 where MaKQDN>=2
                             order by MLT asc,MaHD desc