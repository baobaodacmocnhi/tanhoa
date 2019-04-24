using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.QuanTri
{
    class CTo : CDAL
    {
        public bool Them(To to)
        {
            try
            {
                if (db.Tos.Count() > 0)
                    to.MaTo = db.Tos.Max(item => item.MaTo) + 1;
                else
                    to.MaTo = 1;
                to.CreateDate = DateTime.Now;
                to.CreateBy = CTaiKhoan.MaUser;
                db.Tos.InsertOnSubmit(to);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(To to)
        {
            try
            {
                to.ModifyDate = DateTime.Now;
                to.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(To to)
        {
            try
            {
                db.Tos.DeleteOnSubmit(to);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public List<To> getDS_Admin()
        {
            return db.Tos.ToList();
        }

        public List<To> getDS()
        {
            return db.Tos.Where(item => item.An == false).ToList();
        }

        public List<To> getDS_KTXM()
        {
            return db.Tos.Where(item => item.KTXM == true && item.An == false).ToList();
        }

        public To get(int MaTo)
        {
            return db.Tos.SingleOrDefault(item => item.MaTo == MaTo);
        }

        public string getTenTo(int MaTo)
        {
            return db.Tos.SingleOrDefault(item => item.MaTo == MaTo).TenTo;
        }

    }
}
