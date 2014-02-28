using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CBanGiamDoc : CDAL
    {
        public List<BanGiamDoc> LoadDSBanGiamDoc()
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_Xem||CTaiKhoan.RoleCapNhat_CapNhat)
                    return db.BanGiamDocs.ToList();
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

        public BanGiamDoc getBanGiamDocbyID(int MaBGD)
        {
            try
            {
                return db.BanGiamDocs.Single(itemBGD => itemBGD.MaBGD == MaBGD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemBanGiamDoc(BanGiamDoc bangiamdoc)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    if (db.BanGiamDocs.Count() > 0)
                        bangiamdoc.MaBGD = db.BanGiamDocs.Max(itemBGD => itemBGD.MaBGD) + 1;
                    else
                        bangiamdoc.MaBGD = 1;
                    bangiamdoc.CreateDate = DateTime.Now;
                    bangiamdoc.CreateBy = CTaiKhoan.MaUser;
                    db.BanGiamDocs.InsertOnSubmit(bangiamdoc);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm BanGiamDoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.BanGiamDocs);
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

        public bool SuaBanGiamDoc(BanGiamDoc bangiamdoc)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat_CapNhat)
                {
                    bangiamdoc.ModifyDate = DateTime.Now;
                    bangiamdoc.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa BanGiamDoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.BanGiamDocs);
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

        public BanGiamDoc getBGDNguoiKy()
        {
            try
            {
                return db.BanGiamDocs.SingleOrDefault(itemBGD => itemBGD.KyTen == true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
