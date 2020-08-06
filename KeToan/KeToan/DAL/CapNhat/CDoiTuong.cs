using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeToan.LinQ;
using KeToan.DAL.QuanTri;

namespace KeToan.DAL.CapNhat
{
    class CDoiTuong : CDAL
    {
        public bool Them(DoiTuong entity)
        {
            try
            {
                //if (_db.DoiTuongs.Count() > 0)
                //    entity.ID = _db.DoiTuongs.Max(item => item.ID) + 1;
                //else
                //    entity.ID = 1;
                entity.CreateBy = CUser.MaUser;
                entity.CreateDate = DateTime.Now;
                _db.DoiTuongs.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(DoiTuong entity)
        {
            try
            {
                entity.ModifyBy = CUser.MaUser;
                entity.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Xoa(DoiTuong entity)
        {
            try
            {
                _db.DoiTuongs.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public List<DoiTuong> GetDS()
        {
            return _db.DoiTuongs.ToList();
        }

        public DoiTuong Get(int ID)
        {
            return _db.DoiTuongs.SingleOrDefault(item => item.ID == ID);
        }
    }
}
