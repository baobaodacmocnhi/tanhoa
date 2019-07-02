using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTCN_CongVan.LinQ;

namespace KTCN_CongVan.DAL.QuanTri
{
    class CMenu : CDAL
    {
        public bool Them(LinQ.Menu menu)
        {
            try
            {
                if (_db.Menus.Count() > 0)
                    menu.ID = _db.Menus.Max(item => item.ID) + 1;
                else
                    menu.ID = 1;
                menu.CreateDate = DateTime.Now;
                menu.CreateBy = CUser.ID;
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

        public bool Sua(LinQ.Menu menu)
        {
            try
            {
                menu.ModifyDate = DateTime.Now;
                menu.ModifyBy = CUser.ID;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Xoa(LinQ.Menu menu)
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

        public bool checkExist(string TenMenu)
        {
            return _db.Menus.Any(item => item.TenMenu == TenMenu);
        }

        public List<LinQ.Menu> GetDS()
        {
            return _db.Menus.ToList();
        }

        public LinQ.Menu get(int ID)
        {
            return _db.Menus.SingleOrDefault(item => item.ID == ID);
        }

        public LinQ.Menu get(string TenMenu)
        {
            return _db.Menus.SingleOrDefault(item => item.TenMenu == TenMenu);
        }
    }
}
