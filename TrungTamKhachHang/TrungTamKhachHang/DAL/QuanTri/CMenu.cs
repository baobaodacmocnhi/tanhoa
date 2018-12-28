using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrungTamKhachHang.LinQ;

namespace TrungTamKhachHang.DAL.QuanTri
{
    class CMenu : CTrungTamKhachHang
    {
        public bool Them(Menu entity)
        {
            try
            {
                if (_db.Menus.Count() > 0)
                    entity.ID = _db.Menus.Max(item => item.ID) + 1;
                else
                    entity.ID = 1;
                entity.CreateBy = CUser.MaUser;
                entity.CreateDate = DateTime.Now;
                _db.Menus.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(Menu entity)
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

        public bool Xoa(Menu entity)
        {
            try
            {
                _db.Menus.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool CheckExist(string TenMenu)
        {
            return _db.Menus.Any(item => item.TenMenu == TenMenu);
        }

        public List<Menu> GetDS()
        {
            return _db.Menus.ToList();
        }

        public Menu Get(int ID)
        {
            return _db.Menus.SingleOrDefault(item => item.ID == ID);
        }

        public Menu Get(string TenMenu)
        {
            return _db.Menus.SingleOrDefault(item => item.TenMenu == TenMenu);
        }
    }
}
