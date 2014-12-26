using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using System.Data;

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
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public TT_PhanQuyenNhom GetByMaMenuMaNhom(int MaMenu,int MaTT_Nhom)
        {
            return _db.TT_PhanQuyenNhoms.SingleOrDefault(item => item.MaMenu == MaMenu && item.MaNhom == MaTT_Nhom);
        }

        public bool CheckByMaMenuMaNhom(int MaMenu,int MaTT_Nhom)
        {
            return _db.TT_PhanQuyenNhoms.Any(item => item.MaMenu == MaMenu && item.MaNhom == MaTT_Nhom);
        }

        public DataTable GetDSByMaNhom(int MaTT_Nhom)
        {
            return LINQToDataTable(_db.TT_PhanQuyenNhoms.Where(item => item.MaNhom == MaTT_Nhom).Select(item =>
                new { item.TT_Menu.TextMenuCha, item.TT_Menu.STT, item.MaMenu, item.TT_Menu.TenMenu, item.TT_Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa }).ToList());
        }


    }
}
