using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTCN_CongVan.LinQ;
using System.Data;

namespace KTCN_CongVan.DAL.QuanTri
{
    class CPhanQuyenNhom:CDAL
    {
        public bool Them(PhanQuyenNhom phanquyennhom)
        {
            try
            {
                phanquyennhom.CreateDate = DateTime.Now;
                phanquyennhom.CreateBy = CUser.ID;
                _db.PhanQuyenNhoms.InsertOnSubmit(phanquyennhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(PhanQuyenNhom phanquyennhom)
        {
            try
            {
                phanquyennhom.ModifyDate = DateTime.Now;
                phanquyennhom.ModifyBy = CUser.ID;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Xoa(PhanQuyenNhom phanquyennhom)
        {
            try
            {
                _db.PhanQuyenNhoms.DeleteOnSubmit(phanquyennhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(List<PhanQuyenNhom> lstphanquyennhom)
        {
            try
            {
                _db.PhanQuyenNhoms.DeleteAllOnSubmit(lstphanquyennhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public PhanQuyenNhom get(int IDMenu,int IDNhom)
        {
            return _db.PhanQuyenNhoms.SingleOrDefault(item => item.IDMenu == IDMenu && item.IDNhom == IDNhom);
        }

        public bool checkExist(int IDMenu, int IDNhom)
        {
            return _db.PhanQuyenNhoms.Any(item => item.IDMenu == IDMenu && item.IDNhom == IDNhom);
        }

        public bool checkExist_TenMenuChaMaNhom(string TenMenuCha, int IDNhom)
        {
            return _db.PhanQuyenNhoms.Any(item => item.Menu.TenMenuCha == TenMenuCha && item.IDNhom == IDNhom && item.Xem == true);
        }

        public DataTable getDS(bool Admin, int IDNhom)
        {
            if(Admin)
                return LINQToDataTable(_db.PhanQuyenNhoms.Where(item => item.IDNhom == IDNhom).Select(item =>
                new { item.Menu.TextMenuCha, item.Menu.STT, item.IDMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
            else
                return LINQToDataTable(_db.PhanQuyenNhoms.Where(item => item.IDNhom == IDNhom && item.Menu.TenMenuCha != "mnuPhoGiamDoc").Select(item =>
                new { item.Menu.TextMenuCha, item.Menu.STT, item.IDMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
        }

        
    }
}
