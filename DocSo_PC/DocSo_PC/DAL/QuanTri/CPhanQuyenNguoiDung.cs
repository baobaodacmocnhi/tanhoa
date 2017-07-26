using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;

namespace DocSo_PC.DAL.QuanTri
{
    class CPhanQuyenNguoiDung : CDAL
    {
        public bool Them(PhanQuyenNguoiDung phanquyennguoidung)
        {
            try
            {
                phanquyennguoidung.CreateDate = DateTime.Now;
                phanquyennguoidung.CreateBy = CNguoiDung.MaND;
                _db.PhanQuyenNguoiDungs.InsertOnSubmit(phanquyennguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(PhanQuyenNguoiDung phanquyennguoidung)
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

        public bool Xoa(PhanQuyenNguoiDung phanquyennguoidung)
        {
            try
            {
                _db.PhanQuyenNguoiDungs.DeleteOnSubmit(phanquyennguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(List<PhanQuyenNguoiDung> lstphanquyennguoidung)
        {
            try
            {
                _db.PhanQuyenNguoiDungs.DeleteAllOnSubmit(lstphanquyennguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public PhanQuyenNguoiDung GetByMaMenuMaND(int MaMenu, int MaND)
        {
            return _db.PhanQuyenNguoiDungs.SingleOrDefault(item => item.MaMenu == MaMenu && item.MaND == MaND);
        }

        public bool CheckByMaMenuMaND(int MaMenu, int MaND)
        {
            return _db.PhanQuyenNguoiDungs.Any(item => item.MaMenu == MaMenu && item.MaND == MaND);
        }

        public DataTable GetDSByMaND(bool Admin, int MaND)
        {
            if (Admin)
                return LINQToDataTable(_db.PhanQuyenNguoiDungs.Where(item => item.MaND == MaND).Select(item =>
                new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
            else
                return LINQToDataTable(_db.PhanQuyenNguoiDungs.Where(item => item.MaND == MaND && item.Menu.TenMenuCha != "mnuPhoGiamDoc").Select(item =>
                    new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
        }

    }
}
