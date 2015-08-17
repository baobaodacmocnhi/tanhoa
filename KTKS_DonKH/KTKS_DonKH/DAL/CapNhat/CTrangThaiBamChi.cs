using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CTrangThaiBamChi : CDAL
    {
        public List<TrangThaiBamChi> LoadDSTrangThaiBamChi()
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_Xem || CTaiKhoan.RoleCapNhat_CapNhat)
                    return db.TrangThaiBamChis.OrderBy(item => item.STT).ToList();
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

        public List<TrangThaiBamChi> LoadDSTrangThaiBamChi(bool inheritance)
        {
            try
            {
                if (inheritance)
                {
                    return db.TrangThaiBamChis.OrderBy(item => item.STT).ToList();
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

        public TrangThaiBamChi getTrangThaiBamChibyID(int MaTTBC)
        {
            try
            {
                return db.TrangThaiBamChis.Single(itemTTBC => itemTTBC.MaTTBC == MaTTBC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemTrangThaiBamChi(TrangThaiBamChi trangthaibamchi)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    if (db.TrangThaiBamChis.Count() > 0)
                        trangthaibamchi.MaTTBC = db.TrangThaiBamChis.Max(itemTTBC => itemTTBC.MaTTBC) + 1;
                    else
                        trangthaibamchi.MaTTBC = 1;
                    trangthaibamchi.CreateDate = DateTime.Now;
                    trangthaibamchi.CreateBy = CTaiKhoan.MaUser;
                    db.TrangThaiBamChis.InsertOnSubmit(trangthaibamchi);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TrangThaiBamChis);
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

        public bool SuaTrangThaiBamChi(TrangThaiBamChi trangthaibamchi)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    trangthaibamchi.ModifyDate = DateTime.Now;
                    trangthaibamchi.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TrangThaiBamChis);
                    return false;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaTrangThaiBamChi(List<TrangThaiBamChi> lsttrangthaibamchi)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    //trangthaibamchi.ModifyDate = DateTime.Now;
                    //trangthaibamchi.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TrangThaiBamChis);
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

        public bool XoaTrangThaiBamChi(TrangThaiBamChi trangthaibamchi)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    db.TrangThaiBamChis.DeleteOnSubmit(trangthaibamchi);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TrangThaiBamChis);
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

        public bool UpdateSQL(string sql)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    db.ExecuteCommand(sql);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TrangThaiBamChis);
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
