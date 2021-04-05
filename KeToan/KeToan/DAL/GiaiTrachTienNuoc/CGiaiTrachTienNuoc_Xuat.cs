using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeToan.LinQ;
using KeToan.DAL.QuanTri;
using System.Data;

namespace KeToan.DAL.GiaiTrachTienNuoc
{
    class CGiaiTrachTienNuoc_Xuat : CDAL
    {
        public bool Them(GiaiTrachTienNuoc_Xuat en)
        {
            try
            {
                if (_db.GiaiTrachTienNuoc_Xuats.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.GiaiTrachTienNuoc_Xuats.Max(item => item.ID) + 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CUser.MaUser;
                _db.GiaiTrachTienNuoc_Xuats.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(GiaiTrachTienNuoc_Xuat en)
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

        //public bool Xoa(GiaiTrachTienNuoc_Xuat en)
        //{
        //    try
        //    {
        //        _db.GiaiTrachTienNuoc_Xuats.DeleteOnSubmit(en);
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
            return ExecuteNonQuery("delete GiaiTrachTienNuoc_Xuat where ID=" + ID);
        }

        public bool checkExists(string SoPhieuThu, DateTime NgayGiaiTrach, string DanhBo, int Ky)
        {
            return _db.GiaiTrachTienNuoc_Xuats.Any(item => item.SoPhieuThu == SoPhieuThu && item.NgayGiaiTrach.Value.Date == NgayGiaiTrach.Date && item.DanhBo == DanhBo && item.Ky == Ky);
        }

        public DataTable getDS(DateTime FromNgayGiaiTrach, DateTime ToNgayGiaiTrach)
        {
            return LINQToDataTable(_db.GiaiTrachTienNuoc_Xuats.Where(item => item.NgayPhieuThu.Value.Date >= FromNgayGiaiTrach.Date && item.NgayPhieuThu.Value.Date <= ToNgayGiaiTrach.Date));
        }

    }
}
