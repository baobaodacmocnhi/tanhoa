using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using System.Data;

namespace ThuTien.DAL.QuanTri
{
    class CPhanQuyenNguoiDung:CDAL
    {
        public bool Them(TT_PhanQuyenNguoiDung phanquyennguoidung)
        {
            try
            {
                phanquyennguoidung.CreateDate = DateTime.Now;
                phanquyennguoidung.CreateBy = CNguoiDung.MaND;
                _db.TT_PhanQuyenNguoiDungs.InsertOnSubmit(phanquyennguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TT_PhanQuyenNguoiDung phanquyennguoidung)
        {
            try
            {
                phanquyennguoidung.ModifyDate = DateTime.Now;
                phanquyennguoidung.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TT_PhanQuyenNguoiDung phanquyennguoidung)
        {
            try
            {
                _db.TT_PhanQuyenNguoiDungs.DeleteOnSubmit(phanquyennguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(List<TT_PhanQuyenNguoiDung> lstphanquyennguoidung)
        {
            try
            {
                _db.TT_PhanQuyenNguoiDungs.DeleteAllOnSubmit(lstphanquyennguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public TT_PhanQuyenNguoiDung GetByMaMenuMaND(int MaMenu, int MaND)
        {
            return _db.TT_PhanQuyenNguoiDungs.SingleOrDefault(item => item.MaMenu == MaMenu && item.MaND == MaND);
        }

        public bool CheckByMaMenuMaND(int MaMenu, int MaND)
        {
            return _db.TT_PhanQuyenNguoiDungs.Any(item => item.MaMenu == MaMenu && item.MaND == MaND);
        }

        public DataTable GetDSByMaND(int MaND)
        {
            return LINQToDataTable(_db.TT_PhanQuyenNguoiDungs.Where(item => item.MaND == MaND).Select(item =>
                new { item.TT_Menu.TextMenuCha, item.TT_Menu.STT, item.MaMenu, item.TT_Menu.TenMenu, item.TT_Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa }).ToList());
        }
    }
}
