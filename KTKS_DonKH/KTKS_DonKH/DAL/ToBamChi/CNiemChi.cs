using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.ToBamChi
{
    class CNiemChi : CDAL
    {
        public bool Them(NiemChi en)
        {
            try
            {
                en.CreateDate = DateTime.Now;
                en.CreateBy = CTaiKhoan.MaUser;
                db.NiemChis.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(NiemChi en)
        {
            try
            {
                db.NiemChis.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(List<NiemChi> lsten)
        {
            try
            {
                db.NiemChis.DeleteAllOnSubmit(lsten);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(NiemChi en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(string ID)
        {
            return db.NiemChis.Any(item => item.ID == ID);
        }

        public bool checkSuDung(DateTime CreateDate)
        {
            return db.NiemChis.Any(item => item.CreateDate.Value.Date == CreateDate.Date && item.SuDung == true);
        }

        public bool checkSuDung(string ID)
        {
            return db.NiemChis.Any(item => item.ID == ID && item.SuDung == true);
        }

        public bool checkSuDung(string KyHieu, int FromID, int ToID)
        {
            return db.NiemChis.Any(item => item.KyHieu == KyHieu && Convert.ToInt32(item.STT) >= FromID && Convert.ToInt32(item.STT) <= ToID && item.SuDung == true);
        }

        public bool checkGiao(string KyHieu, int FromID, int ToID)
        {
            return db.NiemChis.Any(item => item.KyHieu == KyHieu && Convert.ToInt32(item.STT) >= FromID && Convert.ToInt32(item.STT) <= ToID && item.MaNV != null);
        }

        public bool checkGiao_MaNV(string ID, int MaNV)
        {
            return db.NiemChis.Any(item => item.ID == ID && item.MaNV == MaNV);
        }

        public bool checkGiao(DateTime CreateDate)
        {
            return db.NiemChis.Any(item => item.CreateDate.Value.Date == CreateDate.Date && item.MaNV != null);
        }

        public bool suDung(string ID)
        {
            try
            {
                NiemChi en = db.NiemChis.SingleOrDefault(item => item.ID == ID);
                en.SuDung = true;
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool traSuDung(string ID)
        {
            try
            {
                NiemChi en = db.NiemChis.SingleOrDefault(item => item.ID == ID);
                en.SuDung = false;
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public NiemChi get(string ID)
        {
            return db.NiemChis.SingleOrDefault(item => item.ID == ID);
        }

        public List<NiemChi> getDS(DateTime CreateDate)
        {
            return db.NiemChis.Where(item => item.CreateDate.Value.Date == CreateDate.Date).ToList();
        }

        public DataTable getDSNhap_Group()
        {
            var query = from item in db.NiemChis
                        group item by item.CreateDate.Value.Date into itemGroup
                        select new
                        {
                            CreateDate = itemGroup.Key,
                            KyHieu = itemGroup.FirstOrDefault().KyHieu,
                            TuSo = itemGroup.Min(groupItem => groupItem.STT),
                            DenSo = itemGroup.Max(groupItem => groupItem.STT),
                            SLNhap = itemGroup.Count(),
                            SLSuDung = itemGroup.Count(groupItem => groupItem.SuDung == true),
                            SLHuHong = itemGroup.Count(groupItem => groupItem.HuHong == true),
                            SLTon = itemGroup.Count() - itemGroup.Count(groupItem => groupItem.SuDung == true) - itemGroup.Count(groupItem => groupItem.HuHong == true),
                            MauSac = itemGroup.FirstOrDefault().MauSac,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSGiao_Group(DateTime CreateDate)
        {
            var query = from item in db.NiemChis
                        where item.CreateDate.Value.Date == CreateDate.Date
                        group item by new { item.CreateDate.Value.Date, item.MaNV, item.DotChia } into itemGroup
                        select new
                        {
                            itemGroup.Key.MaNV,
                            itemGroup.Key.DotChia,
                            HoTen = db.Users.SingleOrDefault(itemT => itemT.MaU == itemGroup.Key.MaNV).HoTen,
                            CreateDate = itemGroup.Key,
                            KyHieu = itemGroup.FirstOrDefault().KyHieu,
                            TuSo = itemGroup.Min(groupItem => groupItem.STT),
                            DenSo = itemGroup.Max(groupItem => groupItem.STT),
                            SLNhap = itemGroup.Count(),
                            SLSuDung = itemGroup.Count(groupItem => groupItem.SuDung == true),
                            SLHuHong = itemGroup.Count(groupItem => groupItem.HuHong == true),
                            SLTon = itemGroup.Count() - itemGroup.Count(groupItem => groupItem.SuDung == true) - itemGroup.Count(groupItem => groupItem.HuHong == true),
                            MauSac = itemGroup.FirstOrDefault().MauSac,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSGiao_GroupTong(DateTime CreateDate)
        {
            var query = from item in db.NiemChis
                        where item.CreateDate.Value.Date == CreateDate.Date
                        group item by new { item.CreateDate.Value.Date, item.MaNV } into itemGroup
                        select new
                        {
                            itemGroup.Key.MaNV,
                            HoTen = db.Users.SingleOrDefault(itemT => itemT.MaU == itemGroup.Key.MaNV).HoTen,
                            SLNhap = itemGroup.Count(),
                            SLSuDung = itemGroup.Count(groupItem => groupItem.SuDung == true),
                            SLHuHong = itemGroup.Count(groupItem => groupItem.HuHong == true),
                            SLTon = itemGroup.Count() - itemGroup.Count(groupItem => groupItem.SuDung == true) - itemGroup.Count(groupItem => groupItem.HuHong == true),
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSHuHong()
        {
            var query = from item in db.NiemChis
                        where item.HuHong == true
                        select new
                        {
                            item.MaNV,
                            HoTen = db.Users.SingleOrDefault(itemT => itemT.MaU == item.MaNV).HoTen,
                            item.DotChia,
                            item.ID,
                        };
            return LINQToDataTable(query);
        }

        public string getDSNiemChiTon(int MaNV)
        {
            DataTable dt = LINQToDataTable(db.NiemChis.Where(item => item.MaNV == MaNV && item.SuDung == false && item.HuHong == false).ToList());
            string str = "";
            foreach (DataRow item in dt.Rows)
            {
                str += item["ID"].ToString() + "\r\n";
            }
            return str;
        }
    }
}
