using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CChiNhanh : CDAL
    {
        public List<ChiNhanh> LoadDSChiNhanh()
        {
            try
            {
                    return db.ChiNhanhs.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách Chi Nhánh, hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="inheritance">true</param>
        /// <returns></returns>
        public List<ChiNhanh> LoadDSChiNhanh(bool inhertance)
        {
            try
            {
                if (inhertance)
                {
                    return db.ChiNhanhs.ToList();
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

        /// <summary>
        /// Lấy danh sách Chi Nhánh(ngoài trừ Chi Nhánh nào đó), hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="inhertance"></param>
        /// <param name="except">Tên Chi Nhánh ngoại trừ</param>
        /// <returns></returns>
        public List<ChiNhanh> LoadDSChiNhanh(bool inhertance,string except)
        {
            try
            {
                if (inhertance)
                {
                    var query = from itemCN in db.ChiNhanhs
                                where !itemCN.TenCN.ToUpper().Contains(except.ToUpper())
                                select itemCN;
                    return query.ToList();
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

        public ChiNhanh getChiNhanhbyID(int MaCN)
        {
            try
            {
                return db.ChiNhanhs.SingleOrDefault(itemCN => itemCN.MaCN == MaCN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Tên Chi Nhánh từ Mã Chi Nhánh truyền vào
        /// </summary>
        /// <param name="MaCN"></param>
        /// <returns></returns>
        public string getTenChiNhanhbyID(int MaCN)
        {
            try
            {
                return db.ChiNhanhs.Single(itemCN => itemCN.MaCN == MaCN).TenCN;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemChiNhanh(ChiNhanh chinhanh)
        {
            try
            {
                    if (db.ChiNhanhs.Count() > 0)
                        chinhanh.MaCN = db.ChiNhanhs.Max(itemCN => itemCN.MaCN) + 1;
                    else
                        chinhanh.MaCN = 1;
                    chinhanh.CreateDate = DateTime.Now;
                    chinhanh.CreateBy = CTaiKhoan.MaUser;
                    db.ChiNhanhs.InsertOnSubmit(chinhanh);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm ChiNhanh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaChiNhanh(ChiNhanh chinhanh)
        {
            try
            {
                    chinhanh.ModifyDate = DateTime.Now;
                    chinhanh.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa ChiNhanh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
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
