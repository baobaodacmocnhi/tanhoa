using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTCN_CongVan.LinQ;
using System.Data;

namespace KTCN_CongVan.DAL.QuanTri
{
    class CPhanQuyenUser : CDAL
    {
        public bool Them(PhanQuyenUser phanquyennguoidung)
        {
            try
            {
                phanquyennguoidung.CreateDate = DateTime.Now;
                phanquyennguoidung.CreateBy = CUser.ID;
                _db.PhanQuyenUsers.InsertOnSubmit(phanquyennguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(PhanQuyenUser phanquyennguoidung)
        {
            try
            {
                phanquyennguoidung.ModifyDate = DateTime.Now;
                phanquyennguoidung.ModifyBy = CUser.ID;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Xoa(PhanQuyenUser phanquyennguoidung)
        {
            try
            {
                _db.PhanQuyenUsers.DeleteOnSubmit(phanquyennguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(List<PhanQuyenUser> lstphanquyennguoidung)
        {
            try
            {
                _db.PhanQuyenUsers.DeleteAllOnSubmit(lstphanquyennguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public PhanQuyenUser get(int IDMenu, int IDUser)
        {
            return _db.PhanQuyenUsers.SingleOrDefault(item => item.IDMenu == IDMenu && item.IDUser == IDUser);
        }

        public bool checkExist(int IDMenu, int IDUser)
        {
            return _db.PhanQuyenUsers.Any(item => item.IDMenu == IDMenu && item.IDUser == IDUser);
        }

        public bool checkExist_TenMenuChaMaND(string TenMenuCha, int IDUser)
        {
            return _db.PhanQuyenUsers.Any(item => item.Menu.TenMenuCha == TenMenuCha && item.IDUser == IDUser && item.Xem == true);
        }

        public DataTable GetDSByMaND(bool Admin, int IDUser)
        {
            if (Admin)
                return LINQToDataTable(_db.PhanQuyenUsers.Where(item => item.IDUser == IDUser).Select(item =>
                new { item.Menu.TextMenuCha, item.Menu.STT, item.IDMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
            else
                return LINQToDataTable(_db.PhanQuyenUsers.Where(item => item.IDUser == IDUser && item.Menu.TenMenuCha != "mnuPhoGiamDoc").Select(item =>
                    new { item.Menu.TextMenuCha, item.Menu.STT, item.IDMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
        }

    }
}
