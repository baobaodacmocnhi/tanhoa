using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTCN_CongVan.LinQ;

namespace KTCN_CongVan.DAL.QuanTri
{
    class CNhom:CDAL
    {
        public bool Them(Nhom nhom)
        {
            try
            {
                if (_db.Nhoms.Count() > 0)
                    nhom.ID = _db.Nhoms.Max(item => item.ID) + 1;
                else
                    nhom.ID = 1;
                nhom.CreateDate = DateTime.Now;
                nhom.CreateBy = CUser.ID;
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
                nhom.ModifyDate = DateTime.Now;
                nhom.ModifyBy = CUser.ID;
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

        public Nhom get(int ID)
        {
            return _db.Nhoms.SingleOrDefault(item => item.ID == ID);
        }

        public string getName(int ID)
        {
            return _db.Nhoms.SingleOrDefault(item => item.ID == ID).Name;
        }
    }
}
