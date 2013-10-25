using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CTTKHDate : CDAL
    {
        //DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

        public List<TTKhachHangDate> LoadDSTTKhachHangDate()
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    return db.TTKhachHangDates.ToList();
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

        public bool SuaTTKhachHangDate(TTKhachHangDate ttkhdate)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    ttkhdate.ModifyDate = DateTime.Now;
                    ttkhdate.ModifyBy = CTaiKhoan.TaiKhoan;
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

        public TTKhachHangDate getTTKHDatebyID(int id)
        {
            try
            {
                return db.TTKhachHangDates.Single(itemCT => itemCT.Dot == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
