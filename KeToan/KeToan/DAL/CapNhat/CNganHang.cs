using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeToan.LinQ;
using KeToan.DAL.QuanTri;

namespace KeToan.DAL.CapNhat
{
    class CNganHang : CDAL
    {
        public bool Them(NganHang entity)
        {
            try
            {
                if (_db.NganHangs.Count() > 0)
                    entity.ID = _db.NganHangs.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateBy = CUser.MaUser;
                entity.CreateDate = DateTime.Now;
                _db.NganHangs.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(NganHang entity)
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

        public bool Xoa(NganHang entity)
        {
            try
            {
                _db.NganHangs.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NganHang Get(int ID)
        {
            return _db.NganHangs.SingleOrDefault(item => item.ID == ID);
        }

        public int Get(string KyHieu)
        {
            return _db.NganHangs.SingleOrDefault(item => item.KyHieu == KyHieu).ID;
        }

        public List<NganHang> GetDS()
        {
            return _db.NganHangs.ToList();
        }
    }
}
