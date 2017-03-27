using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCTB_Web.Database;
using System.Data;

namespace TCTB_Web.DAL.QuanTri
{
    public class CThiCong:CDAL
    {
        public bool Them(KT_NhanVienSuaBe entity)
        {
            try
            {
                if (_db.KT_NhanVienSuaBes.Count() > 0)
                    entity.ID = _db.KT_NhanVienSuaBes.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateDate = DateTime.Now;
                _db.KT_NhanVienSuaBes.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sua(KT_NhanVienSuaBe entity)
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

        public bool Xoa(KT_NhanVienSuaBe entity)
        {
            try
            {
                _db.KT_NhanVienSuaBes.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public KT_NhanVienSuaBe Get(int ID)
        {
            return _db.KT_NhanVienSuaBes.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(_db.KT_NhanVienSuaBes.Where(item => item.An == false));
        }
    }
}