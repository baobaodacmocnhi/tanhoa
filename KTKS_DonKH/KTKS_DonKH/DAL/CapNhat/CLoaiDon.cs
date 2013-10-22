using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CLoaiDon
    {
        DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

        /// <summary>
        /// Lấy danh sách loại đơn
        /// </summary>
        /// <returns></returns>
        public BindingSource LoadDSLoaiDon()
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    var query = from itemLD in db.LoaiDons
                                select new { itemLD.MaLD, itemLD.KyHieuLD, itemLD.TenLD };
                    BindingSource source = new BindingSource();
                    source.DataSource = query.ToList();
                    return source;
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
        /// Lấy danh sách loại đơn, hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="inheritance">true</param>
        /// <returns></returns>
        public BindingSource LoadDSLoaiDon(bool inheritance)
        {
            try
            {
                if (inheritance)
                {
                    BindingSource source = new BindingSource();
                    var table = from itemLD in db.LoaiDons
                                select new { itemLD.MaLD, itemLD.KyHieuLD, itemLD.TenLD };
                    source.DataSource = table.ToList();
                    return source;
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

        public LoaiDon getLoaiDonbyID(int MaLD)
        {
            try
            {
                return db.LoaiDons.Single(itemLD => itemLD.MaLD == MaLD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemLoaiDon(LoaiDon loaidon)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    if (db.LoaiDons.Count() > 0)
                        loaidon.MaLD = db.LoaiDons.Max(itemLD => itemLD.MaLD) + 1;
                    else
                        loaidon.MaLD = 1;
                    loaidon.CreateDate = DateTime.Now;
                    loaidon.CreateBy = CTaiKhoan.TaiKhoan;
                    db.LoaiDons.InsertOnSubmit(loaidon);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool SuaLoaiDon(LoaiDon loaidon)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    loaidon.ModifyDate = DateTime.Now;
                    loaidon.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
