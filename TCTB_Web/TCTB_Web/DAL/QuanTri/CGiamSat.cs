using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCTB_Web.Database;
using System.Data;

namespace TCTB_Web.DAL.QuanTri
{
    public class CGiamSat : CDAL
    {
        public bool Them(KT_NhanVienGiamSat entity)
        {
            try
            {
                if (_db.KT_NhanVienGiamSats.Count() > 0)
                    entity.ID = _db.KT_NhanVienGiamSats.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateDate = DateTime.Now;
                _db.KT_NhanVienGiamSats.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sua(KT_NhanVienGiamSat entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Xoa(KT_NhanVienGiamSat entity)
        {
            try
            {
                _db.KT_NhanVienGiamSats.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public KT_NhanVienGiamSat Get(int ID)
        {
            return _db.KT_NhanVienGiamSats.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS_GNKDT()
        {
            return LINQToDataTable(_db.KT_NhanVienGiamSats.Where(item=>item.GNKDT==true&&item.An==false));
        }

        public DataTable GetDS_KTCN()
        {
            return LINQToDataTable(_db.KT_NhanVienGiamSats.Where(item => item.KTCN == true&&item.An==false));
        }

    }
}