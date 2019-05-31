using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CXacNhanThanhToan : CDAL
    {
        public bool Them(TT_XacNhanThanhToan en)
        {
            try
            {
                if (_db.TT_XacNhanThanhToans.Count() > 0)
                    en.ID = _db.TT_XacNhanThanhToans.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.TT_XacNhanThanhToans.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                throw ex;
            }
        }

        public bool Sua(TT_XacNhanThanhToan en)
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
                _db = new dbThuTienDataContext();
                throw ex;
            }
        }

        public bool Xoa(TT_XacNhanThanhToan en)
        {
            try
            {
                _db.TT_XacNhanThanhToan_ChiTiets.DeleteAllOnSubmit(en.TT_XacNhanThanhToan_ChiTiets.ToList());
                _db.TT_XacNhanThanhToans.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                throw ex;
            }
        }

        public bool checkExist(string DanhBo,DateTime CreateDate)
        {
            return _db.TT_XacNhanThanhToans.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public bool Them_ChiTiet(TT_XacNhanThanhToan_ChiTiet en)
        {
            try
            {
                if (_db.TT_XacNhanThanhToan_ChiTiets.Count() > 0)
                    en.IDCT = _db.TT_XacNhanThanhToan_ChiTiets.Max(item => item.IDCT) + 1;
                else
                    en.IDCT = 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.TT_XacNhanThanhToan_ChiTiets.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                throw ex;
            }
        }

        public bool Xoa_ChiTiet(TT_XacNhanThanhToan_ChiTiet en)
        {
            try
            {
                _db.TT_XacNhanThanhToan_ChiTiets.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                throw ex;
            }
        }

        public bool Xoa_ChiTiet(List<TT_XacNhanThanhToan_ChiTiet> lst)
        {
            try
            {
                _db.TT_XacNhanThanhToan_ChiTiets.DeleteAllOnSubmit(lst);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                throw ex;
            }
        }

        public int getMaxID_ChiTiet()
        {
            if (_db.TT_XacNhanThanhToan_ChiTiets.Count() > 0)
                return  _db.TT_XacNhanThanhToan_ChiTiets.Max(item => item.IDCT) + 1;
            else
                return  1;
        }

        public TT_XacNhanThanhToan get(int ID)
        {
            return _db.TT_XacNhanThanhToans.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.TT_XacNhanThanhToans.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date).ToList());
        }
    }
}
