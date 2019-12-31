using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.DonTu
{
    class CNhomDon : CDAL
    {
        public bool Them(NhomDon entity)
        {
            try
            {
                if (db.NhomDons.Count() > 0)
                {
                    entity.ID = db.NhomDons.Max(item => item.ID) + 1;
                    if (entity.DieuChinh == true)
                        entity.STT = db.NhomDons.Where(item => item.DieuChinh == true).Max(item => item.STT) + 1;
                    else
                        if (entity.KhieuNai == true)
                            entity.STT = db.NhomDons.Where(item => item.KhieuNai == true).Max(item => item.STT) + 1;
                        else
                            if (entity.SuCo == true)
                                entity.STT = db.NhomDons.Where(item => item.SuCo == true).Max(item => item.STT) + 1;
                }
                else
                {
                    entity.ID = 1;
                    entity.STT = 1;
                }
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.NhomDons.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public bool Sua(NhomDon entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public bool Xoa(NhomDon entity)
        {
            try
            {
                db.NhomDons.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public DataTable getDSGroup(string Loai)
        {
            switch (Loai)
            {
                case "DieuChinh":
                    return LINQToDataTable(db.NhomDons.Where(item => item.DieuChinh == true).GroupBy(item => new { item.STTGroup, item.NameGroup }).Select(item => new { ID = item.Key.STTGroup, Name = item.Key.NameGroup }).OrderBy(item => item.ID).ToList());
                case "KhieuNai":
                    return LINQToDataTable(db.NhomDons.Where(item => item.KhieuNai == true).GroupBy(item => new { item.STTGroup, item.NameGroup }).Select(item => new { ID = item.Key.STTGroup, Name = item.Key.NameGroup }).OrderBy(item => item.ID).ToList());
                case "SuCo":
                    return LINQToDataTable(db.NhomDons.Where(item => item.SuCo == true).GroupBy(item => new { item.STTGroup, item.NameGroup }).Select(item => new { ID = item.Key.STTGroup, Name = item.Key.NameGroup }).OrderBy(item => item.ID).ToList());
                case "QuanLy":
                    return LINQToDataTable(db.NhomDons.Where(item => item.QuanLy == true).GroupBy(item => new { item.STTGroup, item.NameGroup }).Select(item => new { ID = item.Key.STTGroup, Name = item.Key.NameGroup }).OrderBy(item => item.ID).ToList());
                default:
                    return null;
            }
        }

        public List<NhomDon> getDS_List(string Loai)
        {
            switch (Loai)
            {
                case "DieuChinh":
                    return db.NhomDons.Where(item => item.DieuChinh == true).OrderBy(item => item.STT).ToList();
                case "KhieuNai":
                    return db.NhomDons.Where(item => item.KhieuNai == true).OrderBy(item => item.STT).ToList();
                case "SuCo":
                    return db.NhomDons.Where(item => item.SuCo == true).OrderBy(item => item.STT).ToList();
                case "QuanLy":
                    return db.NhomDons.Where(item => item.QuanLy == true).OrderBy(item => item.STT).ToList();
                default:
                    return null;
            }
        }

        public DataTable getDS(string Loai)
        {
            switch (Loai)
            {
                case "DieuChinh":
                    return LINQToDataTable(db.NhomDons.Where(item => item.DieuChinh == true).OrderBy(item => item.STT).ToList());
                case "KhieuNai":
                    return LINQToDataTable(db.NhomDons.Where(item => item.KhieuNai == true).OrderBy(item => item.STT).ToList());
                case "SuCo":
                    return LINQToDataTable(db.NhomDons.Where(item => item.SuCo == true).OrderBy(item => item.STT).ToList());
                case "QuanLy":
                    return LINQToDataTable(db.NhomDons.Where(item => item.QuanLy == true).OrderBy(item => item.STT).ToList());
                default:
                    return null;
            }
        }

        public DataTable getDS_ChiTiet()
        {
            return LINQToDataTable(db.NhomDon_ChiTiets.ToList());
        }
    }
}
