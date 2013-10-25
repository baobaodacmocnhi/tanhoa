using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CChungTu : CDAL
    {
        //DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

        public BindingSource LoadDSChungTu()
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    var query = from itemCT in db.ChungTus
                                select new { itemCT.MaCT, itemCT.KyHieuCT, itemCT.TenCT, itemCT.ThoiHan };
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

        public ChungTu getChungTubyID(int MaCT)
        {
            try
            {
                return db.ChungTus.Single(itemCT => itemCT.MaCT == MaCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemChungTu(ChungTu chungtu)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    if (db.ChungTus.Count() > 0)
                        chungtu.MaCT = db.ChungTus.Max(itemCT => itemCT.MaCT) + 1;
                    else
                        chungtu.MaCT = 1;
                    chungtu.CreateDate = DateTime.Now;
                    chungtu.CreateBy = CTaiKhoan.TaiKhoan;
                    db.ChungTus.InsertOnSubmit(chungtu);
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

        public bool SuaChungTu(ChungTu chungtu)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    chungtu.ModifyDate = DateTime.Now;
                    chungtu.ModifyBy = CTaiKhoan.TaiKhoan;
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
