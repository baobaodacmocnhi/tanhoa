USE [KTKS_DonKH]
GO
/****** Object:  StoredProcedure [dbo].[spDieuChinh]    Script Date: 08/08/2019 08:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[spDieuChinh]
@DanhBo VARCHAR(50)
as
select Loai=N'Kiểm Tra',DanhBo,NgayXuLy=CONVERT(VARCHAR(20), NgayKTXM,103),HienTrangKiemTra as noidung,NoiDungKiemTra as ketqua,CreateDate from KTXM_ChiTiet where DanhBo=@DanhBo
union
select Loai=N'Bấm Chì',DanhBo,NgayXuLy=CONVERT(VARCHAR(20), NgayBC,103),TrangThaiBC as noidung,TheoYeuCau as ketqua,CreateDate  from BamChi_ChiTiet where DanhBo=@DanhBo
union
select Loai=N'ĐC Biến Động',DanhBo,NgayXuLy=CONVERT(VARCHAR(20), CreateDate,103),'' as noidung,ThongTin as ketqua,CreateDate from DCBD_ChiTietBienDong where DanhBo=@DanhBo
union
select Loai=N'ĐC Hóa Đơn',DanhBo,NgayXuLy=CONVERT(VARCHAR(20), CreateDate,103),TangGiam as noidung,'' as ketqua,CreateDate from DCBD_ChiTietHoaDon where DanhBo=@DanhBo
union
select Loai=N'Cắt Tạm',DanhBo,NgayXuLy=CONVERT(VARCHAR(20), CreateDate,103),LyDo as noidung,NoiDungXuLy as ketqua,CreateDate from CHDB_ChiTietCatTam where DanhBo=@DanhBo
union
select Loai=N'Cắt Hủy',DanhBo,NgayXuLy=CONVERT(VARCHAR(20), CreateDate,103),LyDo as noidung,NoiDungXuLy as ketqua,CreateDate from CHDB_ChiTietCatHuy where DanhBo=@DanhBo
union
select Loai=N'Phiếu Hủy',DanhBo,NgayXuLy=CONVERT(VARCHAR(20), CreateDate,103),LyDo as noidung,GhiChuLyDo as ketqua,CreateDate from CHDB_Phieu where DanhBo=@DanhBo
union
select Loai=N'Thư Trả Lời',DanhBo,NgayXuLy=CONVERT(VARCHAR(20), CreateDate,103),VeViec as noidung,'' as ketqua,CreateDate from ThuTraLoi_ChiTiet where DanhBo=@DanhBo
union
select Loai=N'Truy Thu',DanhBo,NgayXuLy=CONVERT(VARCHAR(20), CreateDate,103),NoiDung as noidung,TinhTrang as ketqua,CreateDate from TruyThuTienNuoc_ChiTiet where DanhBo=@DanhBo
union
select Loai=N'Gian Lận',DanhBo,NgayXuLy=CONVERT(VARCHAR(20), CreateDate,103),NoiDungViPham as noidung,TinhTrang as ketqua,CreateDate from GianLan_ChiTiet where DanhBo=@DanhBo
order by CreateDate desc