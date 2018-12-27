using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrungTamKhachHang.LinQ;

namespace TrungTamKhachHang.DAL.QuanTri
{
    class CNhom:CTrungTamKhachHang
    {
        public bool Them(Nhom nhom)
        {
            try
            {
                if (_db.Nhoms.Count() > 0)
                    nhom.ID = _db.Nhoms.Max(item => item.ID) + 1;
                else
                    nhom.ID = 1;
                nhom.CreateBy = CUser.MaUser;
                nhom.CreateDate = DateTime.Now;
                _db.Nhoms.InsertOnSubmit(nhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(Nhom nhom)
        {
            try
            {
                nhom.ModifyBy = CUser.MaUser;
                nhom.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Xoa(Nhom nhom)
        {
            try
            {
                _db.Nhoms.DeleteOnSubmit(nhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public List<Nhom> GetDS()
        {
            return _db.Nhoms.ToList();
        }

        public Nhom Get(int ID)
        {
            return _db.Nhoms.SingleOrDefault(item => item.ID == ID);
        }

    }
}
