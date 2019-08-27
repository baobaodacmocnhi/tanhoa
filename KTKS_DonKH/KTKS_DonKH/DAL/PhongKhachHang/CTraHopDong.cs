using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.PhongKhachHang
{
    class CTraHopDong:CDAL
    {
        public bool them(KH_HopDong en)
        {
            try
            {
                if (db.KH_HopDongs.Count() > 0)
                    en.ID = db.KH_HopDongs.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.KH_HopDongs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool sua(KH_HopDong en)
        {
            try
            {
                en.ModifyBy = CTaiKhoan.MaUser;
                en.ModifyDate = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool xoa(KH_HopDong en)
        {
            try
            {
                db.KH_HopDongs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public KH_HopDong get(int ID)
        {
            return db.KH_HopDongs.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS()
        {
           return LINQToDataTable(db.KH_HopDongs.OrderByDescending(item=>item.CreateDate).ToList());
        }

        public DataTable getDS(string DanhBo)
        {
            return LINQToDataTable(db.KH_HopDongs.Where(item => item.DanhBo == DanhBo).OrderByDescending(item => item.CreateDate).ToList());
        }

    }
}
