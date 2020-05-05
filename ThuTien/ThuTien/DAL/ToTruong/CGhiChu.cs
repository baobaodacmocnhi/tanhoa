using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.ToTruong
{
    class CGhiChu : CDAL
    {
        public bool Them(TT_GhiChu en)
        {
            try
            {
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.TT_GhiChus.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_GhiChu en)
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
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(string DanhBo)
        {
            return _db.TT_GhiChus.Any(item => item.DanhBo == DanhBo);
        }

        public TT_GhiChu get(string DanhBo)
        {
            return _db.TT_GhiChus.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public DataTable getDS(string Loai, int MaTo, DateTime TuNgay, DateTime DenNgay)
        {
            switch (Loai)
            {
                case "GiaBieu":
                    var query = from item in _db.TT_GhiChus
                                where item.GiaBieu_Ngay.Value.Date >= TuNgay.Date && item.GiaBieu_Ngay.Value.Date <= DenNgay.Date
                                && _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == item.GiaBieu_CreateBy).MaTo == MaTo
                                select new
                                {
                                    item.DanhBo,
                                    NoiDung = item.GiaBieu,
                                    NgayLap = item.GiaBieu_Ngay,
                                };
                    return LINQToDataTable(query);
                case "NiemChi":
                    var query2 = from item in _db.TT_GhiChus
                                 where item.NiemChi_Ngay.Value.Date >= TuNgay.Date && item.NiemChi_Ngay.Value.Date <= DenNgay.Date
                                 && _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == item.NiemChi_CreateBy).MaTo == MaTo
                                 select new
                                 {
                                     item.DanhBo,
                                     NoiDung = item.NiemChi,
                                     NgayLap = item.NiemChi_Ngay,
                                 };
                    return LINQToDataTable(query2);
                case "DiemBe":
                    var query3 = from item in _db.TT_GhiChus
                                 where item.DiemBe_Ngay.Value.Date >= TuNgay.Date && item.DiemBe_Ngay.Value.Date <= DenNgay.Date
                                 && _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == item.DiemBe_CreateBy).MaTo == MaTo
                                 select new
                                 {
                                     item.DanhBo,
                                     NoiDung = item.DiemBe,
                                     NgayLap = item.DiemBe_Ngay,
                                 };
                    return LINQToDataTable(query3);
            }
            return null;
        }
    }
}
