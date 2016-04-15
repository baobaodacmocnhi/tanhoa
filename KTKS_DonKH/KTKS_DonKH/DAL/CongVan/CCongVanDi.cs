using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Data;

namespace KTKS_DonKH.DAL.CongVan
{
    class CCongVanDi : CDAL
    {
        public bool Them(CongVanDi item)
        {
            try
            {
                if (db.CongVanDis.Count() > 0)
                    item.ID = db.CongVanDis.Max(item2 => item2.ID) + 1;
                else
                    item.ID = 1;
                item.CreateDate = DateTime.Now;
                item.CreateBy = CTaiKhoan.MaUser;
                db.CongVanDis.InsertOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Sua(CongVanDi item)
        {
            try
            {
                item.ModifyDate = DateTime.Now;
                item.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Xoa(CongVanDi item)
        {
            try
            {
                db.CongVanDis.DeleteOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public CongVanDi Get(int ID)
        {
            return db.CongVanDis.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(db.CongVanDis.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date).ToList());
        }
    }
}
