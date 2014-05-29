using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.DAL.DongNuoc
{
    class CDongNuoc : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng DongNuoc & CTDongNuoc

        #region DongNuoc

        /// <summary>
        /// Kiểm tra Đơn Khách Hàng có được DongNuoc xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckDongNuocbyMaDon(decimal MaDon)
        {
            try
            {
                if (db.DongNuocs.Any(itemDongNuoc => itemDongNuoc.MaDon == MaDon))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn Tổ Xử Lý có được DongNuoc xử lý hay chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns>true/có</returns>
        public bool CheckDongNuocbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                if (db.DongNuocs.Any(itemDongNuoc => itemDongNuoc.MaDonTXL == MaDonTXL))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ThemDongNuoc(LinQ.DongNuoc dongnuoc)
        {
            try
            {
                if (CTaiKhoan.RoleDongNuoc_CapNhat)
                {
                    if (db.DongNuocs.Count() > 0)
                    {
                        decimal MaDN = db.DongNuocs.Max(itemDongNuoc => itemDongNuoc.MaDN);
                        dongnuoc.MaDN = getMaxNextIDTable(MaDN);
                    }
                    else
                        dongnuoc.MaDN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    dongnuoc.CreateDate = DateTime.Now;
                    dongnuoc.CreateBy = CTaiKhoan.TaiKhoan;
                    db.DongNuocs.InsertOnSubmit(dongnuoc);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm DongNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DongNuocs);
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

        public bool SuaDongNuoc(LinQ.DongNuoc dongnuoc)
        {
            try
            {
                if (CTaiKhoan.RoleDongNuoc_CapNhat)
                {

                    dongnuoc.ModifyDate = DateTime.Now;
                    dongnuoc.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DongNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DongNuocs);
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

        #endregion

        #region CTDongNuoc

        /// <summary>
        /// Kiểm tra CTDongNuoc đã được tạo cho Mã Đơn Khách Hàng và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTDongNuocbyMaDonDanhBo(decimal MaDon, string DanhBo)
        {
            try
            {
                return db.CTDongNuocs.Any(itemCTDongNuoc => itemCTDongNuoc.DongNuoc.MaDon == MaDon && itemCTDongNuoc.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTDongNuoc đã được tạo cho Mã Đơn Tổ Xử Lý và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTDongNuocbyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo)
        {
            try
            {
                return db.CTDongNuocs.Any(itemCTDongNuoc => itemCTDongNuoc.DongNuoc.MaDonTXL == MaDonTXL && itemCTDongNuoc.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ThemCTDongNuoc(CTDongNuoc ctdongnuoc)
        {
            try
            {
                if (CTaiKhoan.RoleDongNuoc_CapNhat)
                {
                    if (db.CTDongNuocs.Count() > 0)
                    {
                        decimal MaCTDN = db.CTDongNuocs.Max(itemCTDongNuoc => itemCTDongNuoc.MaCTDN);
                        ctdongnuoc.MaCTDN = getMaxNextIDTable(MaCTDN);
                    }
                    else
                        ctdongnuoc.MaCTDN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ctdongnuoc.CreateDate = DateTime.Now;
                    ctdongnuoc.CreateBy = CTaiKhoan.MaUser;
                    db.CTDongNuocs.InsertOnSubmit(ctdongnuoc);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm CTDongNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTDongNuocs);
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

        public bool SuaCTDongNuoc(CTDongNuoc ctdongnuoc)
        {
            try
            {
                if (CTaiKhoan.RoleDongNuoc_CapNhat)
                {
                    ctdongnuoc.ModifyDate = DateTime.Now;
                    ctdongnuoc.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CTDongNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTDongNuocs);
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

        #endregion
    }
}
