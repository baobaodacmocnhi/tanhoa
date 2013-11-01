using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CLoaiChungTu : CDAL
    {
        //DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

        public BindingSource LoadDSLoaiChungTu()
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    var query = from itemLCT in db.LoaiChungTus
                                select new { itemLCT.MaLCT, itemLCT.KyHieuLCT, itemLCT.TenLCT, itemLCT.ThoiHan };
                    BindingSource source = new BindingSource();
                    source.DataSource = query.ToList();
                    return source;
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

        public LoaiChungTu getLoaiChungTubyID(int MaLCT)
        {
            try
            {
                return db.LoaiChungTus.Single(itemLCT => itemLCT.MaLCT == MaLCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemLoaiChungTu(LoaiChungTu loaichungtu)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    if (db.LoaiChungTus.Count() > 0)
                        loaichungtu.MaLCT = db.LoaiChungTus.Max(itemLCT => itemLCT.MaLCT) + 1;
                    else
                        loaichungtu.MaLCT = 1;
                    loaichungtu.CreateDate = DateTime.Now;
                    loaichungtu.CreateBy = CTaiKhoan.TaiKhoan;
                    db.LoaiChungTus.InsertOnSubmit(loaichungtu);
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

        public bool SuaLoaiChungTu(LoaiChungTu loaichungtu)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    loaichungtu.ModifyDate = DateTime.Now;
                    loaichungtu.ModifyBy = CTaiKhoan.TaiKhoan;
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
