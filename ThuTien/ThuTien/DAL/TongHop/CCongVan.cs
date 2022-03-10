using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.TongHop
{
    class CCongVan : CDAL
    {
        public bool Them(TT_CongVan en)
        {
            try
            {
                if (_db.TT_CongVans.Count() > 0)
                    en.MaCV = _db.TT_CongVans.Max(item => item.MaCV) + 1;
                else
                    en.MaCV = 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaND;
                _db.TT_CongVans.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TT_CongVan en)
        {
            try
            {
                _db.TT_CongVans.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_CongVan en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool CheckExist(string Loai, string DanhBo, DateTime CreateDate)
        {
            return _db.TT_CongVans.Any(item => item.Loai == Loai && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public DataTable GetDS(string DanhBo)
        {
            var query = from item in _db.TT_CongVans
                        where item.DanhBo == DanhBo
                        select new
                        {
                            db = "Thu Tiền",
                            item.Loai,
                            item.NoiDung,
                            item.DanhBo,
                            item.CreateDate,
                            Table = "TT_CongVan",
                            Column = "MaCV",
                            Ma = (decimal)item.MaCV,
                            ThuTien_Nhan = true,
                            ThuTien_NgayNhan = item.CreateDate,
                            ThuTien_GhiChu = item.GhiChu,
                            item.GhiChu,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(string Loai, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in _db.TT_CongVans
                        where item.Loai.Contains(Loai) && item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate
                        select new
                        {
                            db = "Thu Tiền",
                            item.Loai,
                            item.NoiDung,
                            item.DanhBo,
                            item.CreateDate,
                            Table = "TT_CongVan",
                            Column = "MaCV",
                            Ma = (decimal)item.MaCV,
                            ThuTien_Nhan = true,
                            ThuTien_NgayNhan = item.CreateDate,
                            ThuTien_GhiChu = item.GhiChu,
                            ThuTien_ButPhe = item.ButPhe,
                            ThuTien_NgayButPhe = item.NgayButPhe,
                            item.GhiChu,
                        };
            return LINQToDataTable(query);
        }
    }
}
