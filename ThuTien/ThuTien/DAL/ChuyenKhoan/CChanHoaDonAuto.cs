using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using System.Data;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CChanHoaDonAuto : CDAL
    {
        public bool Them(TT_ChanHoaDon_DanhBo en)
        {
            try
            {
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.TT_ChanHoaDon_DanhBos.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TT_ChanHoaDon_DanhBo en)
        {
            try
            {
                _db.TT_ChanHoaDon_DanhBos.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExists_ChanHoaDon(string DanhBo, int Nam, int Ky)
        {
            return _db.TT_ChanHoaDon_DanhBos.Any(item => item.DanhBo == DanhBo && item.Nam == Nam && Ky >= item.TuKy && Ky <= item.DenKy);
        }

        public TT_ChanHoaDon_DanhBo get(string DanhBo, int Nam, int TuKy, int DenKy)
        {
            return _db.TT_ChanHoaDon_DanhBos.SingleOrDefault(item => item.DanhBo == DanhBo && item.Nam == Nam && item.TuKy == TuKy && item.DenKy == DenKy);
        }

        public DataTable getDS()
        {
            return LINQToDataTable(_db.TT_ChanHoaDon_DanhBos.ToList());
        }

    }
}
