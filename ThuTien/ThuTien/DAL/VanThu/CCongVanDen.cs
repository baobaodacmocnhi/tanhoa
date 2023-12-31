using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.VanThu
{
    class CCongVanDen : CDAL
    {
        public bool Them(TT_CongVanDen en)
        {
            try
            {
                if (_db.TT_CongVanDens.Count() > 0)
                    en.ID = _db.TT_CongVanDens.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.TT_CongVanDens.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_CongVanDen en)
        {
            try
            {
                en.ModifyBy = CNguoiDung.MaND;
                en.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Xoa(TT_CongVanDen en)
        {
            try
            {
                _db.TT_CongVanDens.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExists(string TableName, int IDCT)
        {
            return _db.TT_CongVanDens.Any(item => item.TableName == TableName && item.IDCT == IDCT);
        }

        public bool checkExists(string DanhBo, string NoiDung)
        {
            return _db.TT_CongVanDens.Any(item => item.DanhBo == DanhBo && item.NoiDung == NoiDung);
        }

        public TT_CongVanDen get(int ID)
        {
            return _db.TT_CongVanDens.SingleOrDefault(item => item.ID == ID);
        }

        public TT_CongVanDen get(string TableName, int IDCT)
        {
            return _db.TT_CongVanDens.SingleOrDefault(item => item.TableName == TableName && item.IDCT == IDCT);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            return ExecuteQuery_DataTable("select *,'To'=(select top 1 TenTo from [TT_To] where TuCuonGCS<=SUBSTRING(MLT,3,2) and DenCuonGCS>=SUBSTRING(MLT,3,2)) from TT_CongVanDen where"
                + FromDot + "<=SUBSTRING(MLT,1,2) and " + ToDot + ">=SUBSTRING(MLT,1,2)"
                + " and cast(createdate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and cast(createdate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' order by createdate desc");
        }

        public DataTable getDS(string DanhBo)
        {
            return ExecuteQuery_DataTable("select *,'To'=(select top 1 TenTo from [TT_To] where TuCuonGCS<=SUBSTRING(MLT,3,2) and DenCuonGCS>=SUBSTRING(MLT,3,2)) from TT_CongVanDen where DanhBo='" + DanhBo + "' order by createdate desc");
        }

        public DataTable getDS_XuLy_To(string DaXuLy, string MaTo)
        {
            if (bool.Parse(DaXuLy))
                DaXuLy = "1";
            else
                DaXuLy = "0";
            return ExecuteQuery_DataTable("select *,'To'=(select top 1 TenTo from [TT_To] where TuCuonGCS<=SUBSTRING(MLT,3,2) and DenCuonGCS>=SUBSTRING(MLT,3,2)) from TT_CongVanDen where DaXuLy=" + DaXuLy
                + " and (select TuCuonGCS from [TT_To] where MaTo=" + MaTo + ")<=SUBSTRING(MLT,3,2) and (select DenCuonGCS from [TT_To] where MaTo=" + MaTo + ")>=SUBSTRING(MLT,3,2) order by createdate desc");
        }

        public DataTable getDS_XuLy_Doi(string DaXuLy)
        {
            if (bool.Parse(DaXuLy))
                DaXuLy = "1";
            else
                DaXuLy = "0";
            return ExecuteQuery_DataTable("select *,'To'=(select top 1 TenTo from [TT_To] where TuCuonGCS<=SUBSTRING(MLT,3,2) and DenCuonGCS>=SUBSTRING(MLT,3,2)) from TT_CongVanDen where DaXuLy=" + DaXuLy
                + " order by createdate desc");
        }

        public DataTable getGroup_NoiDung()
        {
            return ExecuteQuery_DataTable("select LoaiVB from TT_CongVanDen group by LoaiVB order by LoaiVB asc");
        }

        public DataTable getDS_ChuaDuyet(string LoaiVB)
        {
            if (LoaiVB == "Tất Cả")
                LoaiVB = "";
            else
                LoaiVB = "and LoaiVB=N'" + LoaiVB + "'";
            return ExecuteQuery_DataTable("select *,'To'=(select top 1 TenTo from [TT_To] where TuCuonGCS<=SUBSTRING(MLT,3,2) and DenCuonGCS>=SUBSTRING(MLT,3,2))"
                + " ,NgayKiemDinh=(select NgayKiemDinh from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=TT_CongVanDen.DanhBo)"
                + " from TT_CongVanDen where Duyet_Ngay is null " + LoaiVB + " order by createdate desc");
        }

        public DataTable getDS_DaDuyet(string LoaiVB, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            if (LoaiVB == "Tất Cả")
                LoaiVB = "";
            else
                LoaiVB = "and LoaiVB=N'" + LoaiVB + "'";
            return ExecuteQuery_DataTable("select *,'To'=(select top 1 TenTo from [TT_To] where TuCuonGCS<=SUBSTRING(MLT,3,2) and DenCuonGCS>=SUBSTRING(MLT,3,2))"
                + " ,NgayKiemDinh=(select NgayKiemDinh from CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG where DanhBo=TT_CongVanDen.DanhBo)"
                + " from TT_CongVanDen where cast(Duyet_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and cast(Duyet_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' " + LoaiVB + " order by createdate desc");
        }

        public DataTable getDS_DanhBo_XuLySoLieu(string DanhBo)
        {
            return ExecuteQuery_DataTable("select * from TT_CongVanDen where DanhBo='" + DanhBo + "' and CAST(DATEADD(DAY,90,CreateDate) as date)>=CAST(GETDATE() as date) order by CreateDate desc");
        }

        public DataTable getDS_ButPhe_XuLySoLieu(string MaTo, string Nam, string Ky, string Dot, string ButPhe)
        {
            if (MaTo == "0")
                MaTo = "";
            else
                MaTo = "and SUBSTRING(MLT1,3,2)>=(select TuCuonGCS from [TT_To] where MaTo=" + MaTo + ") and SUBSTRING(MLT1,3,2)<=(select DenCuonGCS from [TT_To] where MaTo=" + MaTo + ")";
            return ExecuteQuery_DataTable("select * from TT_CongVanDen where " + ButPhe + "=1 and CAST(DATEADD(DAY,90,CreateDate) as date)>=CAST(GETDATE() as date) and DanhBo in (select DanhBa from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " " + MaTo + ") order by CreateDate desc");
        }

        public DataTable count_ButPhe_XuLySoLieu(string MaTo, string Nam, string Ky, string Dot)
        {
            if (MaTo == "0")
                MaTo = "";
            else
                MaTo = "and SUBSTRING(MLT1,3,2)>=(select TuCuonGCS from [TT_To] where MaTo=" + MaTo + ") and SUBSTRING(MLT1,3,2)<=(select DenCuonGCS from [TT_To] where MaTo=" + MaTo + ")";
            return ExecuteQuery_DataTable("declare @Nam int=" + Nam + ",@Ky char(2)='" + Ky + "',@Dot char(2)='" + Dot + "'"
                    + " select ButPhe=N'Xem',Loai='Xem',SoLuong=count(*) from TT_CongVanDen where Xem=1 and CAST(DATEADD(DAY,90,CreateDate) as date)>=CAST(GETDATE() as date) and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0"
                    + " union all"
                    + " select ButPhe=N'Cập Nhật',Loai='CapNhat',SoLuong=count(*) from TT_CongVanDen where CapNhat=1 and CAST(DATEADD(DAY,90,CreateDate) as date)>=CAST(GETDATE() as date) and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0"
                    + " union all"
                    + " select ButPhe=N'Tính Tiêu Thụ',Loai='TinhTieuThu',SoLuong=count(*) from TT_CongVanDen where TinhTieuThu=1 and CAST(DATEADD(DAY,90,CreateDate) as date)>=CAST(GETDATE() as date) and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0"
                    + " union all"
                    + " select ButPhe=N'Theo Dõi',Loai='TheoDoi',SoLuong=count(*) from TT_CongVanDen where TheoDoi=1 and CAST(DATEADD(DAY,90,CreateDate) as date)>=CAST(GETDATE() as date) and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0"
                    + " union all"
                    + " select ButPhe=N'Báo Thay',Loai='BaoThay',SoLuong=count(*) from TT_CongVanDen where BaoThay=1 and CAST(DATEADD(DAY,90,CreateDate) as date)>=CAST(GETDATE() as date) and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0"
                    + " union all"
                    + " select ButPhe=N'Để Biết',Loai='DeBiet',SoLuong=count(*) from TT_CongVanDen where DeBiet=1 and CAST(DATEADD(DAY,90,CreateDate) as date)>=CAST(GETDATE() as date) and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0"
                    + " union all"
                    + " select ButPhe=N'Kiểm Tra Lại Hiện Trường',Loai='KiemTraLaiHienTruong',SoLuong=count(*) from TT_CongVanDen where KiemTraLaiHienTruong=1 and CAST(DATEADD(DAY,90,CreateDate) as date)>=CAST(GETDATE() as date) and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0"
                    + " union all"
                    + " select ButPhe=N'Khác',Loai='Khac',SoLuong=count(*) from TT_CongVanDen where Khac=1 and CAST(DATEADD(DAY,90,CreateDate) as date)>=CAST(GETDATE() as date) and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0");
        }

        public string thongBaoMaHoa()
        {
            int count = int.Parse(ExecuteQuery_ReturnOneValue("select count(*) from TT_CongVanDen where Duyet_Ngay is not null and ToMaHoa=1 and DaXuLy=0").ToString());
            if (count > 0)
                return "Có " + count + " CVĐ cần xử lý";
            else
                return "";
        }

        public DataTable getDS_ToMaHoa()
        {
            return ExecuteQuery_DataTable("select *,'To'=(select TenTo from [TT_To] where TuCuonGCS<=SUBSTRING(MLT,3,2) and DenCuonGCS>=SUBSTRING(MLT,3,2))"
                + " from TT_CongVanDen where Duyet_Ngay is not null and ToMaHoa=1 and DaXuLy=0 order by createdate desc");
        }

        public DataTable get_ID(string ID)
        {
            return ExecuteQuery_DataTable("select *,'To'=(select TenTo from [TT_To] where TuCuonGCS<=SUBSTRING(MLT,3,2) and DenCuonGCS>=SUBSTRING(MLT,3,2))"
                + " from TT_CongVanDen where ID=" + ID + " order by createdate desc");
        }
    }
}
