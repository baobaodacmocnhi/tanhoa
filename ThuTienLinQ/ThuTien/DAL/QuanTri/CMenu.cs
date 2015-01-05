using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;

namespace ThuTien.DAL.QuanTri
{
    class CMenu : CDAL
    {

        public bool Them(TT_Menu menu)
        {
            try
            {
                if (_db.TT_Menus.Count() > 0)
                    menu.MaMenu = _db.TT_Menus.Max(item => item.MaMenu) + 1;
                else
                    menu.MaMenu = 1;
                menu.CreateDate = DateTime.Now;
                menu.CreateBy = CNguoiDung.MaND;
                _db.TT_Menus.InsertOnSubmit(menu);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TT_Menu menu)
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

        public bool Xoa(TT_Menu menu)
        {
            try
            {
                _db.TT_Menus.DeleteOnSubmit(menu);
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
                return _db.TT_Menus.Any(item => item.TenMenu == TenMenu);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TT_Menu> GetDS()
        {
            return _db.TT_Menus.ToList();
        }

        public TT_Menu GetByMaMenu(int MaMenu)
        {
            return _db.TT_Menus.SingleOrDefault(item => item.MaMenu == MaMenu);
        }

        public TT_Menu GetByTenMenu(string TenMenu)
        {
            return _db.TT_Menus.SingleOrDefault(item => item.TenMenu == TenMenu);
        }
    }
}
