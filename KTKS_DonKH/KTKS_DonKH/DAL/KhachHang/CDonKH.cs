using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;

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

        public bool ThemDonKH(DonKH donkh)
        {
            try
            {
                if (CTaiKhoan.RoleNhanDonKH)
                {
                    donkh.CreateDate = DateTime.Now;
                    donkh.CreateBy = CTaiKhoan.TaiKhoan;
                    db.DonKHs.InsertOnSubmit(donkh);
                    db.SubmitChanges();
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
                return false;
            }
        }

        public BindingSource LoadDSDonKH()
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH)
                {
                    var query = from itemDonKH in db.DonKHs
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                where itemDonKH.Chuyen == false
                                select new { itemDonKH.MaDon, itemLoaiDon.TenLD, itemDonKH.CreateDate, itemDonKH.DanhBo, itemDonKH.HoTen, itemDonKH.DiaChi, itemDonKH.NoiDung};
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
    }
}
