using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.ThuMoi
{
    class CInBienBan:CDAL
    {
        public bool them(InBienBan entity)
        {
            try
            {
                if (db.InBienBans.Count() > 0)
                {
                    entity.ID = db.InBienBans.Max(item => item.ID) + 1;
                }
                else
                {
                    entity.ID = 1;
                }
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.InBienBans.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool xoa(InBienBan entity)
        {
            try
            {
                db.InBienBans.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public InBienBan get(int ID)
        {
            return db.InBienBans.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS(int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(db.InBienBans.Where(item => item.CreateBy == CreateBy && item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date).ToList());
        }
    }
}
