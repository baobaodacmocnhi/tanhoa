using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.DongNuoc
{
    class CPhoiHop : CDAL
    {
        #region Loại Phối Hợp

        public DataTable getDS_LoaiPhoiHop()
        {
            return LINQToDataTable(_db.TT_DongNuoc_LoaiPhoiHops.ToList());
        }

        #endregion

        public bool Them(TT_DongNuoc_PhoiHop en)
        {
            try
            {
                if (_db.TT_DongNuoc_PhoiHops.Count() > 0)
                    en.ID = _db.TT_DongNuoc_PhoiHops.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.TT_DongNuoc_PhoiHops.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Them(TT_DongNuoc_PhoiHop en,int CreateBy)
        {
            try
            {
                if (_db.TT_DongNuoc_PhoiHops.Count() > 0)
                    en.ID = _db.TT_DongNuoc_PhoiHops.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CreateBy;
                en.CreateDate = DateTime.Now;
                _db.TT_DongNuoc_PhoiHops.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_DongNuoc_PhoiHop en)
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

        public bool Xoa(TT_DongNuoc_PhoiHop en)
        {
            try
            {
                _db.TT_DongNuoc_PhoiHops.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public TT_DongNuoc_PhoiHop get(int ID)
        {
            return _db.TT_DongNuoc_PhoiHops.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.TT_DongNuoc_PhoiHops.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date).ToList());
        }

        public DataTable getDS_To(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.TT_DongNuoc_PhoiHops.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == item.CreateBy).MaTo == MaTo).ToList());
        }

        public DataTable getDS_NV(int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.TT_DongNuoc_PhoiHops.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.CreateBy == CreateBy).ToList());
        }
    }
}
