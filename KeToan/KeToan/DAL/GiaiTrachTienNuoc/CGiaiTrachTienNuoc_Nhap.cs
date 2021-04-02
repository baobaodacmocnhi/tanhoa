using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeToan.LinQ;
using KeToan.DAL.QuanTri;
using System.Data;

namespace KeToan.DAL.GiaiTrachTienNuoc
{
    class CGiaiTrachTienNuoc_Nhap : CDAL
    {
        public bool Them(GiaiTrachTienNuoc_Nhap en)
        {
            try
            {
                if (_db.GiaiTrachTienNuoc_Nhaps.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.GiaiTrachTienNuoc_Nhaps.Max(item => item.ID) + 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CUser.MaUser;
                _db.GiaiTrachTienNuoc_Nhaps.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(GiaiTrachTienNuoc_Nhap en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CUser.MaUser;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        //public bool Xoa(GiaiTrachTienNuoc_Nhap en)
        //{
        //    try
        //    {
        //        _db.GiaiTrachTienNuoc_Nhaps.DeleteOnSubmit(en);
        //        _db.SubmitChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Refresh();
        //        throw ex;
        //    }
        //}

        public bool Xoa(string ID)
        {
            return ExecuteNonQuery("delete GiaiTrachTienNuoc_Nhap where ID=" + ID);
        }

        public bool checkExists(string SoPhieuThu, DateTime NgayPhieuThu, string DanhBo)
        {
            return _db.GiaiTrachTienNuoc_Nhaps.Any(item => item.SoPhieuThu == SoPhieuThu && item.NgayPhieuThu.Value.Date == NgayPhieuThu.Date && item.DanhBo == DanhBo);
        }

        public DataTable getDS(DateTime FromNgayPhieuThu, DateTime ToNgayPhieuThu)
        {
            return LINQToDataTable(_db.GiaiTrachTienNuoc_Nhaps.Where(item => item.NgayPhieuThu.Value.Date >= FromNgayPhieuThu.Date && item.NgayPhieuThu.Value.Date <= ToNgayPhieuThu.Date));
        }

    }
}
