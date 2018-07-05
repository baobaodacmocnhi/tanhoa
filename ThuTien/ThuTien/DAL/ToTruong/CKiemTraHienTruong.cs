using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.ToTruong
{
    class CKiemTraHienTruong : CDAL
    {
        public bool Them(TT_KiemTraHienTruong entity)
        {
            try
            {
                if (_db.TT_KiemTraHienTruongs.Count() > 0)
                    entity.ID = _db.TT_KiemTraHienTruongs.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateBy = CNguoiDung.MaND;
                entity.CreateDate = DateTime.Now;
                _db.TT_KiemTraHienTruongs.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TT_KiemTraHienTruong entity)
        {
            try
            {
                _db.TT_KiemTraHienTruongs.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua()
        {
            try
            {
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool CheckExist(string DanhBo, DateTime CreateDate)
        {
            return _db.TT_KiemTraHienTruongs.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public TT_KiemTraHienTruong get(int ID)
        {
            return _db.TT_KiemTraHienTruongs.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.TT_KiemTraHienTruongs.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date).ToList());
        }

        public DataTable getDS(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.TT_KiemTraHienTruongs.Where(item => _db.TT_NguoiDungs.SingleOrDefault(itemND => itemND.MaND == item.CreateBy).MaTo == MaTo && item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date).ToList());
        }

    }
}
