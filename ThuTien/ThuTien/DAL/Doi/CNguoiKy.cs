using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Doi
{
    class CNguoiKy:CDAL
    {
        public bool Them(TT_NguoiKy en)
        {
            try
            {
                if (_db.TT_NguoiKies.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.TT_NguoiKies.Max(item => item.ID) + 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.TT_NguoiKies.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_NguoiKy en)
        {
            try
            {
                en.ModifyBy = CNguoiDung.MaND;
                en.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TT_NguoiKy en)
        {
            try
            {
                _db.TT_NguoiKies.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public TT_NguoiKy get(int ID)
        {
            return _db.TT_NguoiKies.SingleOrDefault(item => item.ID == ID);
        }

        public static string getChucVu()
        {
            return _db.TT_NguoiKies.SingleOrDefault(item => item.Ky == true).ChucVu;
        }

        public static string getNguoiKy()
        {
            return _db.TT_NguoiKies.SingleOrDefault(item => item.Ky == true).Name;
        }

        public DataTable getDS()
        {
            return LINQToDataTable(_db.TT_NguoiKies.ToList());
        }

    }
}
