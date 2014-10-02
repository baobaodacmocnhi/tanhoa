using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CLoaiDonTXL : CDAL
    {
        /// <summary>
        /// Lấy danh sách Loại Đơn
        /// </summary>
        /// <returns></returns>
        public List<LoaiDonTXL> LoadDSLoaiDonTXL()
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_Xem || CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    return db.LoaiDonTXLs.ToList();
                }
                else
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách Loại Đơn, hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="inheritance">true</param>
        /// <returns></returns>
        public List<LoaiDonTXL> LoadDSLoaiDonTXL(bool inheritance)
        {
            try
            {
                if (inheritance)
                {
                    return db.LoaiDonTXLs.ToList();
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

        public LoaiDonTXL getLoaiDonTXLbyID(int MaLD)
        {
            try
            {
                return db.LoaiDonTXLs.SingleOrDefault(itemLDTXL => itemLDTXL.MaLD == MaLD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Tên Loại Đơn từ Mã Loại Đơn
        /// </summary>
        /// <param name="MaLD"></param>
        /// <returns></returns>
        public string getTenLDbyID(int MaLD)
        {
            try
            {
                return db.LoaiDonTXLs.SingleOrDefault(itemLDXL => itemLDXL.MaLD == MaLD).TenLD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Ký Hiệu loại đơn từ Mã Loại Đơn
        /// </summary>
        /// <param name="MaLD"></param>
        /// <returns></returns>
        public string getKyHieuLDTXLubyID(int MaLD)
        {
            try
            {
                return db.LoaiDonTXLs.SingleOrDefault(itemLDTXL => itemLDTXL.MaLD == MaLD).KyHieuLD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemLoaiDonTXL(LoaiDonTXL loaidontxl)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    if (db.LoaiDonTXLs.Count() > 0)
                        loaidontxl.MaLD = db.LoaiDonTXLs.Max(itemLD => itemLD.MaLD) + 1;
                    else
                        loaidontxl.MaLD = 1;
                    loaidontxl.CreateDate = DateTime.Now;
                    loaidontxl.CreateBy = CTaiKhoan.MaUser;
                    db.LoaiDonTXLs.InsertOnSubmit(loaidontxl);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm LoaiDonTXL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.LoaiDons);
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

        public bool SuaLoaiDonTXL(LoaiDonTXL loaidontxl)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    loaidontxl.ModifyDate = DateTime.Now;
                    loaidontxl.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa LoaiDonTXL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.LoaiDons);
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

        public bool XoaLoaiDonTXL(LoaiDonTXL loaidontxl)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    db.LoaiDonTXLs.DeleteOnSubmit(loaidontxl);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa LoaiDonTXL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.LoaiDons);
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
