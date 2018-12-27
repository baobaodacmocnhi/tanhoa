using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrungTamKhachHang.LinQ;
using System.Data;

namespace TrungTamKhachHang.DAL.QuanTri
{
    class CPhanQuyenNhom:CTrungTamKhachHang
    {
        public bool Them(PhanQuyenNhom entity)
        {
            try
            {
                entity.CreateBy = CUser.MaUser;
                entity.CreateDate = DateTime.Now;
                _db.PhanQuyenNhoms.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
               Refresh();
               throw ex;
            }
        }

        public bool Sua(PhanQuyenNhom entity)
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

        public bool Xoa(PhanQuyenNhom entity)
        {
            try
            {
                _db.PhanQuyenNhoms.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(List<PhanQuyenNhom> entity)
        {
            try
            {
                _db.PhanQuyenNhoms.DeleteAllOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool CheckExist(int MaMenu, int MaNhom)
        {
            return _db.PhanQuyenNhoms.Any(item => item.MaMenu == MaMenu && item.MaNhom == MaNhom);
        }

        public PhanQuyenNhom Get(int MaMenu,int MaNhom)
        {
            return _db.PhanQuyenNhoms.SingleOrDefault(item => item.MaMenu == MaMenu && item.MaNhom == MaNhom);
        }

        public DataTable GetDS(int MaNhom)
        {
            return LINQToDataTable(_db.PhanQuyenNhoms.Where(item => item.MaNhom == MaNhom).Select(item =>
                new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
        }

        
    }
}
