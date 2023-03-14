using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.DAL.VanThu
{
    class CCongVanDen : CDAL
    {
        public bool Them(CongVanDen en)
        {
            try
            {
                if (_db.CongVanDens.Count() > 0)
                    en.ID = _db.CongVanDens.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.CongVanDens.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(CongVanDen en)
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

        public bool Xoa(CongVanDen en)
        {
            try
            {
                _db.CongVanDens.DeleteOnSubmit(en);
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
            return _db.CongVanDens.Any(item => item.TableName == TableName && item.IDCT == IDCT);
        }

        public bool checkExists(string DanhBo, string NoiDung)
        {
            return _db.CongVanDens.Any(item => item.DanhBo == DanhBo && item.NoiDung == NoiDung);
        }

        public CongVanDen get(int ID)
        {
            return _db.CongVanDens.SingleOrDefault(item => item.ID == ID);
        }

        public CongVanDen get(string TableName, int IDCT)
        {
            return _db.CongVanDens.SingleOrDefault(item => item.TableName == TableName && item.IDCT == IDCT);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return _cDAL.ExecuteQuery_DataTable("select *,'To'=(select TenTo from [To] where TuMay<=SUBSTRING(MLT,3,2) and DenMay>=SUBSTRING(MLT,3,2)) from CongVanDen where cast(createdate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and cast(createdate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' order by createdate desc");
        }

        public DataTable getDS(string DanhBo)
        {
            return _cDAL.ExecuteQuery_DataTable("select *,'To'=(select TenTo from [To] where TuMay<=SUBSTRING(MLT,3,2) and DenMay>=SUBSTRING(MLT,3,2)) from CongVanDen where DanhBo='" + DanhBo + "' order by createdate desc");
        }

        public DataTable getGroup_NoiDung()
        {
            return _cDAL.ExecuteQuery_DataTable("select LoaiVB from CongVanDen group by LoaiVB order by LoaiVB asc");
        }

        public DataTable getDS_ChuaDuyet(string LoaiVB)
        {
            if (LoaiVB == "Tất Cả")
                LoaiVB = "";
            else
                LoaiVB = "and LoaiVB=N'" + LoaiVB + "'";
            return _cDAL.ExecuteQuery_DataTable("select *,'To'=(select TenTo from [To] where TuMay<=SUBSTRING(MLT,3,2) and DenMay>=SUBSTRING(MLT,3,2))"
                + " from CongVanDen where Duyet_Ngay is null " + LoaiVB + " order by createdate desc");
        }

        public DataTable getDS_DaDuyet(string LoaiVB, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            if (LoaiVB == "Tất Cả")
                LoaiVB = "";
            else
                LoaiVB = "and LoaiVB=N'" + LoaiVB + "'";
            return _cDAL.ExecuteQuery_DataTable("select *,'To'=(select TenTo from [To] where TuMay<=SUBSTRING(MLT,3,2) and DenMay>=SUBSTRING(MLT,3,2))"
                + " from CongVanDen where cast(Duyet_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and cast(Duyet_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' " + LoaiVB + " order by createdate desc");
        }

        public DataTable getDS_DanhBo_XuLySoLieu(string DanhBo)
        {
            return _cDAL.ExecuteQuery_DataTable("select * from CongVanDen where DanhBo='" + DanhBo + "' and CAST(DATEADD(DAY,90,CreateDate) as date)>=CAST(GETDATE() as date) order by CreateDate desc");
        }

        public DataTable getDS_ButPhe_XuLySoLieu(string ButPhe)
        {
            return _cDAL.ExecuteQuery_DataTable("select * from CongVanDen where " + ButPhe + "=1 order by MLT asc");
        }

        public DataTable count_ButPhe_XuLySoLieu(string MaTo, string Nam, string Ky, string Dot)
        {
            if (MaTo == "0")
                MaTo = "";
            else
                MaTo = "and SUBSTRING(MLT1,3,2)>=(select TuMay from [To] where MaTo=" + MaTo + ") and SUBSTRING(MLT1,3,2)<=(select DenMay from [To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable("declare @Nam int=" + Nam + ",@Ky char(2)='" + Ky + "',@Dot char(2)='" + Dot + "'"
                    + " select ButPhe=N'Xem',Loai='Xem',SoLuong=count(*) from CongVanDen where Xem=1 and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0"
                    + " union all"
                    + " select ButPhe=N'Cập Nhật',Loai='CapNhat',SoLuong=count(*) from CongVanDen where CapNhat=1 and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0"
                    + " union all"
                    + " select ButPhe=N'Tính Tiêu Thụ',Loai='TinhTieuThu',SoLuong=count(*) from CongVanDen where TinhTieuThu=1 and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0"
                    + " union all"
                    + " select ButPhe=N'Theo Dõi',Loai='TheoDoi',SoLuong=count(*) from CongVanDen where TheoDoi=1 and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0"
                    + " union all"
                    + " select ButPhe=N'Kiểm Tra Lại Hiện Trường',Loai='KiemTraLaiHienTruong',SoLuong=count(*) from CongVanDen where KiemTraLaiHienTruong=1 and DanhBo in (select DanhBa from DocSo where Nam=@Nam and Ky=@Ky and Dot=@Dot " + MaTo + ") having COUNT(*)>0");
        }

    }
}
