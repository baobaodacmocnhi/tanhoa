using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Doi
{
    class CNiemChi:CDAL
    {
        public bool Them(TT_NiemChi en)
        {
            try
            {
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaND;
                _db.TT_NiemChis.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TT_NiemChi en)
        {
            try
            {
                _db.TT_NiemChis.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(List<TT_NiemChi> lsten)
        {
            try
            {
                _db.TT_NiemChis.DeleteAllOnSubmit(lsten);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_NiemChi en)
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

        public bool checkExist(int ID)
        {
            return _db.TT_NiemChis.Any(item => item.ID == ID);
        }

        public bool checkSuDung(DateTime CreateDate)
        {
            return _db.TT_NiemChis.Any(item => item.CreateDate.Value.Date == CreateDate.Date && item.SuDung == true);
        }

        public bool checkSuDung(int ID)
        {
            return _db.TT_NiemChis.Any(item => item.ID == ID && item.SuDung == true);
        }

        public bool checkSuDung(int FromID, int ToID)
        {
            return _db.TT_NiemChis.Any(item => item.ID >= FromID && item.ID <= ToID && item.SuDung == true);
        }

        public bool checkGiao(int FromID, int ToID)
        {
            return _db.TT_NiemChis.Any(item => item.ID>=FromID && item.ID<=ToID && item.MaTo!=null);
        }

        public bool checkGiao(DateTime CreateDate)
        {
            return _db.TT_NiemChis.Any(item => item.CreateDate.Value.Date == CreateDate.Date && item.MaTo != null);
        }

        public bool suDung(int ID)
        {
            try
            {
                TT_NiemChi en = _db.TT_NiemChis.SingleOrDefault(item => item.ID == ID);
                en.SuDung = true;
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

        public List<TT_NiemChi> getDS(DateTime CreateDate)
        {
            return _db.TT_NiemChis.Where(item => item.CreateDate.Value.Date == CreateDate.Date).ToList();
        }

        public DataTable getDSNhap_Group()
        {
            var query = from item in _db.TT_NiemChis
                        group item by item.CreateDate.Value.Date into itemGroup
                        select new
                        {
                            CreateDate=itemGroup.Key,
                            TuSo = itemGroup.Min(groupItem => groupItem.ID),
                            DenSo = itemGroup.Max(groupItem => groupItem.ID),
                            SLNhap = itemGroup.Count(),
                            SLSuDung = itemGroup.Count(groupItem => groupItem.SuDung==true),
                            SLTon = itemGroup.Count() - itemGroup.Count(groupItem => groupItem.SuDung == true),
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSGiao_Group(DateTime CreateDate)
        {
            var query = from item in _db.TT_NiemChis
                        where item.CreateDate.Value.Date == CreateDate.Date
                        group item by new { item.CreateDate.Value.Date ,item.MaTo} into itemGroup
                        select new
                        {
                            itemGroup.Key.MaTo,
                            TenTo=_db.TT_Tos.SingleOrDefault(itemT=>itemT.MaTo==itemGroup.Key.MaTo).TenTo,
                            CreateDate = itemGroup.Key,
                            TuSo = itemGroup.Min(groupItem => groupItem.ID),
                            DenSo = itemGroup.Max(groupItem => groupItem.ID),
                            SLNhap = itemGroup.Count(),
                            SLSuDung = itemGroup.Count(groupItem => groupItem.SuDung == true),
                            SLTon = itemGroup.Count() - itemGroup.Count(groupItem => groupItem.SuDung == true),
                        };
            return LINQToDataTable(query);
        }

    }
}
