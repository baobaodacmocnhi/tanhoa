using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeToan.LinQ;
using KeToan.DAL.QuanTri;
using System.Data;

namespace KeToan.DAL.NhapLieu
{
    class CPhieuChi : CDAL
    {
        public bool Them(PhieuChi entity)
        {
            try
            {
                if (_db.PhieuChis.Count() > 0)
                    entity.ID = _db.PhieuChis.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;

                if (_db.PhieuChis.Any(item => item.ID_NganHang == entity.ID_NganHang && item.Thang == DateTime.Now.Month && item.Nam == DateTime.Now.Year) == true)
                {
                    entity.STT = _db.PhieuChis.Where(item => item.ID_NganHang == entity.ID_NganHang && item.Thang == DateTime.Now.Month && item.Nam == DateTime.Now.Year).Max(item => item.STT) + 1;
                }
                else
                {
                    entity.STT = 1;
                }
                entity.Thang = DateTime.Now.Month;
                entity.Nam = DateTime.Now.Year;

                entity.SoCT = entity.STT.ToString("00000") + "/" + entity.KyHieu + entity.Thang.ToString("00") + "-" + entity.Nam % 100;

                entity.CreateBy = CUser.MaUser;
                entity.CreateDate = DateTime.Now;
                _db.PhieuChis.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(PhieuChi entity)
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
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(PhieuChi entity)
        {
            try
            {
                _db.PhieuChis.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        bool CheckExist(int ID_NganHang, int Thang, int Nam)
        {
            try
            {
                return _db.PhieuChis.Any(item => item.ID_NganHang == ID_NganHang && item.Thang == Thang && item.Nam == Nam);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PhieuChi Get(int ID)
        {
            return _db.PhieuChis.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.PhieuChis.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date).OrderBy(item => item.ID).ToList());
        }
    }
}
