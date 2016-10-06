using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.QuanTri
{
    class CPhanQuyenNguoiDung:CDAL
    {
        public bool Them(PhanQuyenNguoiDung phanquyennguoidung)
        {
            try
            {
                phanquyennguoidung.CreateDate = DateTime.Now;
                phanquyennguoidung.CreateBy = CTaiKhoan.MaUser;
                db.PhanQuyenNguoiDungs.InsertOnSubmit(phanquyennguoidung);
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

        public bool Sua(PhanQuyenNguoiDung phanquyennguoidung)
        {
            try
            {
                phanquyennguoidung.ModifyDate = DateTime.Now;
                phanquyennguoidung.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
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
                db.PhanQuyenNguoiDungs.DeleteOnSubmit(phanquyennguoidung);
                db.SubmitChanges();
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
                db.PhanQuyenNguoiDungs.DeleteAllOnSubmit(lstphanquyennguoidung);
                db.SubmitChanges();
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
            return db.PhanQuyenNguoiDungs.SingleOrDefault(item => item.MaMenu == MaMenu && item.MaND == MaND);
        }

        public bool CheckByMaMenuMaND(int MaMenu, int MaND)
        {
            return db.PhanQuyenNguoiDungs.Any(item => item.MaMenu == MaMenu && item.MaND == MaND);
        }

        public DataTable GetDSByMaND(bool Admin, int MaND)
        {
            if (Admin)
                return LINQToDataTable(db.PhanQuyenNguoiDungs.Where(item => item.MaND == MaND).Select(item =>
                new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
            else
                return LINQToDataTable(db.PhanQuyenNguoiDungs.Where(item => item.MaND == MaND && item.Menu.TenMenuCha != "mnuPhoGiamDoc").Select(item =>
                    new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
        }
    }
}
