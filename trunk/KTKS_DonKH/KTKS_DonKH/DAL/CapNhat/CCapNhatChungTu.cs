using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CCapNhatChungTu
    {
        DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

        public BindingSource LoadDSLoaiDon()
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    BindingSource source = new BindingSource();
                    var table = from itemCT in db.ChungTus
                                select new { itemCT.MaCT, itemCT.KyHieuCT, itemCT.TenCT, itemCT.ThoiHan };
                    source.DataSource = table.ToList();
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

        public void ThemLoaiDon(ChungTu chungtu)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    if (db.LoaiDons.Count() > 0)
                        chungtu.MaCT = db.ChungTus.Max(itemCT => itemCT.MaCT) + 1;
                    else
                        chungtu.MaCT = 1;
                    chungtu.CreateDate = DateTime.Now;
                    chungtu.CreateBy = CTaiKhoan.TaiKhoan;
                    db.ChungTus.InsertOnSubmit(chungtu);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
            }
        }

        public void SuaLoaiDon(ChungTu chungtu)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    chungtu.ModifyDate = DateTime.Now;
                    chungtu.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
            }
        }
    }
}
