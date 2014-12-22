using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;

namespace ThuTien.DAL.QuanTri
{
    class CTo:CDAL
    {
        public bool Them(TT_To to)
        {
            try
            {
                if (_db.TT_Tos.Count() > 0)
                    to.MaTo = _db.TT_Tos.Max(item => item.MaTo) + 1;
                else
                    to.MaTo = 1;
                to.CreateDate = DateTime.Now;
                to.CreateBy = CNguoiDung.MaND;
                _db.TT_Tos.InsertOnSubmit(to);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sua(TT_To to)
        {
            try
            {
                to.ModifyDate = DateTime.Now;
                to.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Xoa(TT_To to)
        {
            try
            {
                _db.TT_Tos.DeleteOnSubmit(to);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TT_To> GetDSTo()
        {
            return _db.TT_Tos.ToList();
        }

        public TT_To GetToByMaTo(int MaTo)
        {
            return _db.TT_Tos.SingleOrDefault(item => item.MaTo == MaTo);
        }

        public string GetTenToByMaTo(int MaTo)
        {
            return _db.TT_Tos.SingleOrDefault(item => item.MaTo == MaTo).TenTo;
        }
    }
}
