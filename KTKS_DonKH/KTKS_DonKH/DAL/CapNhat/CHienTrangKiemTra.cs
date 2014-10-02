using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CHienTrangKiemTra : CDAL
    {
        public List<HienTrangKiemTra> LoadDSHienTrangKiemTra()
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_Xem || CTaiKhoan.RoleCapNhat_CapNhat)
                    return db.HienTrangKiemTras.ToList();
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<HienTrangKiemTra> LoadDSHienTrangKiemTra(bool inheritance)
        {
            try
            {
                if (inheritance)
                {
                    return db.HienTrangKiemTras.ToList();
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public HienTrangKiemTra getHienTrangKiemTrabyID(int MaHTKT)
        {
            try
            {
                return db.HienTrangKiemTras.Single(itemHTKT => itemHTKT.MaHTKT == MaHTKT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemHienTrangKiemTra(HienTrangKiemTra hientrangkiemtra)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    if (db.HienTrangKiemTras.Count() > 0)
                        hientrangkiemtra.MaHTKT = db.HienTrangKiemTras.Max(itemHTKT => itemHTKT.MaHTKT) + 1;
                    else
                        hientrangkiemtra.MaHTKT = 1;
                    hientrangkiemtra.CreateDate = DateTime.Now;
                    hientrangkiemtra.CreateBy = CTaiKhoan.MaUser;
                    db.HienTrangKiemTras.InsertOnSubmit(hientrangkiemtra);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm HienTrangKiemTra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.HienTrangKiemTras);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaHienTrangKiemTra(HienTrangKiemTra hientrangkiemtra)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    hientrangkiemtra.ModifyDate = DateTime.Now;
                    hientrangkiemtra.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.HienTrangKiemTras);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaHienTrangKiemTra(HienTrangKiemTra hientrangkiemtra)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    db.HienTrangKiemTras.DeleteOnSubmit(hientrangkiemtra);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.HienTrangKiemTras);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }
    }
}
