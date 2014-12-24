using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;

namespace ThuTien.DAL.QuanTri
{
    class CMenu : CDAL
    {

        public bool Them(MenuForm menu)
        {
            try
            {
                if (_db.MenuForms.Count() > 0)
                    menu.MaMenu = _db.MenuForms.Max(item => item.MaMenu) + 1;
                else
                    menu.MaMenu = 1;
                menu.CreateDate = DateTime.Now;
                menu.CreateBy = CNguoiDung.MaND;
                _db.MenuForms.InsertOnSubmit(menu);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(MenuForm menu)
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(MenuForm menu)
        {
            try
            {
                _db.MenuForms.DeleteOnSubmit(menu);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExistByTenMenu(string TenMenu)
        {
            try
            {
                return _db.MenuForms.Any(item => item.TenMenu == TenMenu);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<MenuForm> GetDSMenu()
        {
            return _db.MenuForms.ToList();
        }

        public MenuForm GetMenuByMaMenu(int MaMenu)
        {
            return _db.MenuForms.SingleOrDefault(item => item.MaMenu == MaMenu);
        }

        public MenuForm GetMenuByTenMenu(string TenMenu)
        {
            return _db.MenuForms.SingleOrDefault(item => item.TenMenu == TenMenu);
        }
    }
}
