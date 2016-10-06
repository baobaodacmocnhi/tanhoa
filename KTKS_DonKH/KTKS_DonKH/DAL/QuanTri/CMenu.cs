using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.QuanTri
{
    class CMenu:CDAL
    {
        public bool Them(Menu menu)
        {
            try
            {
                if (db.Menus.Count() > 0)
                    menu.MaMenu = db.Menus.Max(item => item.MaMenu) + 1;
                else
                    menu.MaMenu = 1;
                menu.CreateDate = DateTime.Now;
                menu.CreateBy = CTaiKhoan.MaUser;
                db.Menus.InsertOnSubmit(menu);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new DB_KTKS_DonKHDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(Menu menu)
        {
            try
            {
                menu.ModifyDate = DateTime.Now;
                menu.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(Menu menu)
        {
            try
            {
                db.Menus.DeleteOnSubmit(menu);
                db.SubmitChanges();
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
                return db.Menus.Any(item => item.TenMenu == TenMenu);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Menu> GetDS()
        {
            return db.Menus.ToList();
        }

        public Menu GetByMaMenu(int MaMenu)
        {
            return db.Menus.SingleOrDefault(item => item.MaMenu == MaMenu);
        }

        public Menu GetByTenMenu(string TenMenu)
        {
            return db.Menus.SingleOrDefault(item => item.TenMenu == TenMenu);
        }
    }
}
