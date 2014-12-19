using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;

namespace ThuTien.DAL.QuanTri
{
    class CPhanQuyenNhom:CDAL
    {
        public bool Them(TT_PhanQuyenNhom phanquyennhom)
        {
            try
            {
                phanquyennhom.CreateDate = DateTime.Now;
                phanquyennhom.CreateBy = CNguoiDung.MaND;
                _db.TT_PhanQuyenNhoms.InsertOnSubmit(phanquyennhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sua(TT_PhanQuyenNhom phanquyennhom)
        {
            try
            {
                phanquyennhom.ModifyDate = DateTime.Now;
                phanquyennhom.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Xoa(TT_PhanQuyenNhom phanquyennhom)
        {
            try
            {
                _db.TT_PhanQuyenNhoms.DeleteOnSubmit(phanquyennhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Xoa(List<TT_PhanQuyenNhom> lstphanquyennhom)
        {
            try
            {
                _db.TT_PhanQuyenNhoms.DeleteAllOnSubmit(lstphanquyennhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TT_PhanQuyenNhom getPhanQuyenNhombyMaMenuMaNhom(int MaMenu,int MaNhom)
        {
            return _db.TT_PhanQuyenNhoms.SingleOrDefault(item => item.MaMenu == MaMenu && item.MaNhom == MaNhom);
        }

        public bool CheckPhanQuyenNhombyMaMenuMaNhom(int MaMenu,int MaNhom)
        {
            return _db.TT_PhanQuyenNhoms.Any(item => item.MaMenu == MaMenu && item.MaNhom == MaNhom);
        }

        public List<TT_PhanQuyenNhom> getDSPhanQuyenNhombyMaNhom(int MaNhom)
        {
            return _db.TT_PhanQuyenNhoms.Where(item => item.MaNhom == MaNhom).ToList();
        }
    }
}
