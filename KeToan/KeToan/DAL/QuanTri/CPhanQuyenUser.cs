using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeToan.LinQ;
using System.Data;

namespace KeToan.DAL.QuanTri
{
    class CPhanQuyenUser : CDAL
    {
        public bool Them(PhanQuyenUser entity)
        {
            try
            {
                entity.CreateBy = CUser.MaUser;
                entity.CreateDate = DateTime.Now;
                _db.PhanQuyenUsers.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(PhanQuyenUser entity)
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

        public bool Xoa(PhanQuyenUser entity)
        {
            try
            {
                _db.PhanQuyenUsers.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public PhanQuyenUser Get(int MaMenu, int MaUser)
        {
            return _db.PhanQuyenUsers.SingleOrDefault(item => item.MaMenu == MaMenu && item.MaUser == MaUser);
        }

        public bool CheckExist(int MaMenu, int MaUser)
        {
            return _db.PhanQuyenUsers.Any(item => item.MaMenu == MaMenu && item.MaUser == MaUser);
        }

        public DataTable GetDS(int MaUser)
        {
            return LINQToDataTable(_db.PhanQuyenUsers.Where(item => item.MaUser == MaUser).Select(item =>
                new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
        }

    }
}
