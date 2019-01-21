using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrungTamKhachHang.LinQ;
using TrungTamKhachHang.DAL.QuanTri;
using System.Data;

namespace TrungTamKhachHang.DAL.KhachHang
{
    class CKhieuNai:CTrungTamKhachHang
    {
        public bool Them(KhieuNai en)
        {
            try
            {
                if (_db.KhieuNais.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.KhieuNais.Max(item => item.ID) + 1;
                en.CreateBy = CUser.MaUser;
                en.CreateDate = DateTime.Now;
                _db.KhieuNais.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(KhieuNai en)
        {
            try
            {
                _db.KhieuNais.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(KhieuNai en)
        {
            try
            {
                en.ModifyBy = CUser.MaUser;
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

        public KhieuNai get(int ID)
        {
            return _db.KhieuNais.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS_DanhBo(string DanhBo)
        {
            return LINQToDataTable(_db.KhieuNais.Where(item => item.DanhBo==DanhBo).OrderByDescending(item=>item.CreateDate).ToList());
        }

        public DataTable getDS_DienThoai(string DienThoai)
        {
            return LINQToDataTable(_db.KhieuNais.Where(item => item.DienThoai == DienThoai).OrderByDescending(item => item.CreateDate).ToList());
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.KhieuNais.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date).ToList());
        }
    }
}
