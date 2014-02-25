using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CNhanVien : CDAL
    {
        public List<NhanVien> LoadDSNhanVien()
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    return db.NhanViens.Where(itemNV => itemNV.MaNV != 0).ToList();
                }
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

        /// <summary>
        /// Lấy danh sách NhanVien, hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="inheritance">true</param>
        /// <returns></returns>
        public List<NhanVien> LoadDSNhanVien(bool inhertance)
        {
            try
            {
                if (inhertance)
                {
                    return db.NhanViens.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public NhanVien getNhanVienbyID(int MaNV)
        {
            try
            {
                return db.NhanViens.SingleOrDefault(itemNV => itemNV.MaNV == MaNV);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemNhanVien(NhanVien nhanvien)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    if (db.NhanViens.Count() > 0)
                        nhanvien.MaNV = db.NhanViens.Max(itemNV => itemNV.MaNV) + 1;
                    else
                        nhanvien.MaNV = 1;
                    nhanvien.CreateDate = DateTime.Now;
                    nhanvien.CreateBy = CTaiKhoan.MaUser;
                    db.NhanViens.InsertOnSubmit(nhanvien);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm NhanVien", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public bool SuaNhanVien(NhanVien nhanvien)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    nhanvien.ModifyDate = DateTime.Now;
                    nhanvien.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa BanGiamDoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
