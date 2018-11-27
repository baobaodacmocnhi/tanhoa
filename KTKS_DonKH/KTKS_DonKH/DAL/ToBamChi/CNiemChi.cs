using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.ToBamChi
{
    class CNiemChi:CDAL
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

        public bool checkExist(int ID)
        {
            return db.NiemChis.Any(item => item.ID == ID);
        }

        public bool checkSuDung(DateTime CreateDate)
        {
            return db.NiemChis.Any(item => item.CreateDate.Value.Date == CreateDate.Date && item.SuDung == true);
        }

        public bool checkSuDung(int ID)
        {
            return db.NiemChis.Any(item => item.ID == ID && item.SuDung == true);
        }

        public bool checkSuDung(int FromID, int ToID)
        {
            return db.NiemChis.Any(item => item.ID >= FromID && item.ID <= ToID && item.SuDung == true);
        }

        public bool checkGiao(int FromID, int ToID)
        {
            return db.NiemChis.Any(item => item.ID >= FromID && item.ID <= ToID && item.MaNV != null);
        }

        public bool checkGiao_MaNV(int ID,int MaNV)
        {
            return db.NiemChis.Any(item => item.ID == ID && item.MaNV == MaNV);
        }

        public bool checkGiao(DateTime CreateDate)
        {
            return db.NiemChis.Any(item => item.CreateDate.Value.Date == CreateDate.Date && item.MaNV != null);
        }

        public bool suDung(int ID)
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

        public bool traSuDung(int ID)
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

        public NiemChi get(int ID)
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
                            TuSo = itemGroup.Min(groupItem => groupItem.ID),
                            DenSo = itemGroup.Max(groupItem => groupItem.ID),
                            SLNhap = itemGroup.Count(),
                            SLSuDung = itemGroup.Count(groupItem => groupItem.SuDung == true),
                            SLHuHong = itemGroup.Count(groupItem => groupItem.HuHong == true),
                            SLTon = itemGroup.Count() - itemGroup.Count(groupItem => groupItem.SuDung == true) - itemGroup.Count(groupItem => groupItem.HuHong == true),
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSGiao_Group(DateTime CreateDate)
        {
            var query = from item in db.NiemChis
                        where item.CreateDate.Value.Date == CreateDate.Date
                        group item by new { item.CreateDate.Value.Date, item.MaNV,item.DotChia } into itemGroup
                        select new
                        {
                            itemGroup.Key.MaNV,
                            itemGroup.Key.DotChia,
                            HoTen = db.Users.SingleOrDefault(itemT => itemT.MaU == itemGroup.Key.MaNV).HoTen,
                            CreateDate = itemGroup.Key,
                            TuSo = itemGroup.Min(groupItem => groupItem.ID),
                            DenSo = itemGroup.Max(groupItem => groupItem.ID),
                            SLNhap = itemGroup.Count(),
                            SLSuDung = itemGroup.Count(groupItem => groupItem.SuDung == true),
                            SLHuHong = itemGroup.Count(groupItem => groupItem.HuHong == true),
                            SLTon = itemGroup.Count() - itemGroup.Count(groupItem => groupItem.SuDung == true) - itemGroup.Count(groupItem => groupItem.HuHong == true),
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

        public string getDSNiemChiTon(int MaNV)
        {
            DataTable dt = LINQToDataTable(db.NiemChis.Where(item => item.MaNV == MaNV && item.SuDung == false&&item.HuHong==false).ToList());
            string str = "";
            foreach (DataRow item in dt.Rows)
            {
                    str+=item["ID"].ToString()+"\r\n";
            }
            return str;
        }
    }
}
