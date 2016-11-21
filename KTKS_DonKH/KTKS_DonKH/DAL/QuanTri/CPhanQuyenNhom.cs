using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.QuanTri
{
    class CPhanQuyenNhom:CDAL
    {
        public bool Them(PhanQuyenNhom phanquyennhom)
        {
            try
            {
                phanquyennhom.CreateDate = DateTime.Now;
                phanquyennhom.CreateBy = CTaiKhoan.MaUser;
                db.PhanQuyenNhoms.InsertOnSubmit(phanquyennhom);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(PhanQuyenNhom phanquyennhom)
        {
            try
            {
                phanquyennhom.ModifyDate = DateTime.Now;
                phanquyennhom.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
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
                db.PhanQuyenNhoms.DeleteOnSubmit(phanquyennhom);
                db.SubmitChanges();
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
                db.PhanQuyenNhoms.DeleteAllOnSubmit(lstphanquyennhom);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public PhanQuyenNhom GetByMaMenuMaNhom(int MaMenu, int MaTT_Nhom)
        {
            return db.PhanQuyenNhoms.SingleOrDefault(item => item.MaMenu == MaMenu && item.MaNhom == MaTT_Nhom);
        }

        public bool CheckByMaMenuMaNhom(int MaMenu, int MaTT_Nhom)
        {
            return db.PhanQuyenNhoms.Any(item => item.MaMenu == MaMenu && item.MaNhom == MaTT_Nhom);
        }

        public DataTable GetDSByMaNhom(bool Admin, int MaTT_Nhom)
        {
            if (Admin)
                return LINQToDataTable(db.PhanQuyenNhoms.Where(item => item.MaNhom == MaTT_Nhom).Select(item =>
                new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
            else
                return LINQToDataTable(db.PhanQuyenNhoms.Where(item => item.MaNhom == MaTT_Nhom && item.Menu.TenMenuCha != "mnuPhoGiamDoc").Select(item =>
                    new { item.Menu.TextMenuCha, item.Menu.STT, item.MaMenu, item.Menu.TenMenu, item.Menu.TextMenu, item.Xem, item.Them, item.Sua, item.Xoa, item.ToanQuyen, item.QuanLy }).ToList());
        }
    }
}
