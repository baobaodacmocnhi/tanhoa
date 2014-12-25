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
        public bool Them(PhanQuyenNhom phanquyennhom)
        {
            try
            {
                phanquyennhom.CreateDate = DateTime.Now;
                phanquyennhom.CreateBy = CNguoiDung.MaND;
                _db.PhanQuyenNhoms.InsertOnSubmit(phanquyennhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(PhanQuyenNhom phanquyennhom)
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public PhanQuyenNhom GetPhanQuyenNhomByMaMenuMaNhom(int MaMenu,int MaNhom)
        {
            return _db.PhanQuyenNhoms.SingleOrDefault(item => item.MaMenu == MaMenu && item.MaNhom == MaNhom);
        }

        public bool CheckPhanQuyenNhomByMaMenuMaNhom(int MaMenu,int MaNhom)
        {
            return _db.PhanQuyenNhoms.Any(item => item.MaMenu == MaMenu && item.MaNhom == MaNhom);
        }

        public DataTable GetDSPhanQuyenNhomByMaNhom(int MaNhom)
        {
            return LINQToDataTable(_db.PhanQuyenNhoms.Where(item => item.MaNhom == MaNhom).Select(item =>
                new { item.MenuForm.TextMenuCha, item.MenuForm.STT, item.MaMenu, item.MenuForm.TenMenu, item.MenuForm.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa }).ToList());
        }


    }
}
