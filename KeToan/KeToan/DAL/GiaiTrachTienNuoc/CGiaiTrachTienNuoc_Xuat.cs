﻿using System;
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

        public bool checkExists(string SoPhieuThu, DateTime NgayPhieuThu, string DanhBo, int Ky, DateTime NgayGiaiTrach)
        {
            return _db.GiaiTrachTienNuoc_Xuats.Any(item => item.SoPhieuThu == SoPhieuThu && item.NgayPhieuThu.Value.Date == NgayPhieuThu.Date && item.DanhBo == DanhBo && item.Ky == Ky && item.NgayGiaiTrach.Value.Date == NgayGiaiTrach.Date);
        }

        public DataTable getDS(DateTime FromNgayGiaiTrach, DateTime ToNgayGiaiTrach)
        {
            return LINQToDataTable(_db.GiaiTrachTienNuoc_Xuats.Where(item => item.NgayGiaiTrach.Value.Date >= FromNgayGiaiTrach.Date && item.NgayGiaiTrach.Value.Date <= ToNgayGiaiTrach.Date));
        }

    }
}
