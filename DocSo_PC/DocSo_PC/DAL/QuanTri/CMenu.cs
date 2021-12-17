using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;

namespace DocSo_PC.DAL.QuanTri
{
    class CMenu : CDAL
    {
        public bool Them(Menu menu)
        {
            try
            {
                if (_db.Menus.Count() > 0)
                    menu.MaMenu = _db.Menus.Max(item => item.MaMenu) + 1;
                else
                    menu.MaMenu = 1;
                menu.CreateDate = DateTime.Now;
                menu.CreateBy = CNguoiDung.MaND;
                _db.Menus.InsertOnSubmit(menu);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(Menu menu)
        {
            try
            {
                menu.ModifyDate = DateTime.Now;
                menu.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(Menu menu)
        {
            try
            {
                _db.Menus.DeleteOnSubmit(menu);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool CheckExistByTenMenu(string TenMenu)
        {
            try
            {
                return _db.Menus.Any(item => item.TenMenu == TenMenu);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Menu> GetDS()
        {
            return _db.Menus.ToList();
        }

        public Menu GetByMaMenu(int MaMenu)
        {
            return _db.Menus.SingleOrDefault(item => item.MaMenu == MaMenu);
        }

        public Menu GetByTenMenu(string TenMenu)
        {
            return _db.Menus.SingleOrDefault(item => item.TenMenu == TenMenu);
        }
    }
}
