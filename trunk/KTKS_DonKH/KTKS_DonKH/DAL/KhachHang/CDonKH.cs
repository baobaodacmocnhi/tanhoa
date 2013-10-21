using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.DAL.KhachHang
{
    class CDonKH
    {
        DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

        /// <summary>
        /// Lấy Mã Đơn kế tiếp
        /// </summary>
        /// <returns></returns>
        public int getMaxNextID()
        {
            if (db.DonKHs.Count() > 0)
                return db.DonKHs.Max(itemDonKH => itemDonKH.MaDon) + 1;
            else
                return 1;
        }

        public void ThemDonKH(DonKH donkh)
        {
            try
            {
                if (CTaiKhoan.RoleNhanDonKH)
                {
                    donkh.CreateDate = DateTime.Now;
                    donkh.CreateBy = CTaiKhoan.TaiKhoan;
                    db.DonKHs.InsertOnSubmit(donkh);
                    db.SubmitChanges();
                }
                else
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
