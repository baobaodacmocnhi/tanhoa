using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;

namespace ThuTien.DAL.QuanTri
{
    class CNguoiDung : CDAL
    {
        static int _MaND;

        public static int MaND
        {
            get { return _MaND; }
            set { _MaND = value; }
        }


        public bool Them(TT_NguoiDung nguoidung)
        {
            try
            {
                if (_db.TT_NguoiDungs.Count() > 0)
                    nguoidung.MaND = _db.TT_NguoiDungs.Max(item => item.MaND) + 1;
                else
                    nguoidung.MaND = 1;
                nguoidung.CreateDate = DateTime.Now;
                nguoidung.CreateBy = CNguoiDung.MaND;
                _db.TT_NguoiDungs.InsertOnSubmit(nguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sua(TT_NguoiDung nguoidung)
        {
            try
            {
                nguoidung.ModifyDate = DateTime.Now;
                nguoidung.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Xoa(TT_NguoiDung nguoidung)
        {
            try
            {
                _db.TT_NguoiDungs.DeleteOnSubmit(nguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TT_NguoiDung> GetDSNguoiDung()
        {
            return _db.TT_NguoiDungs.ToList();
        }

        public TT_NguoiDung getNguoiDungbyMaND(int MaND)
        {
            return _db.TT_NguoiDungs.SingleOrDefault(item => item.MaND == MaND);
        }
    }
}
