using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.QuanTri
{
    class CTo:CDAL
    {
        public bool Them(To to)
        {
            try
            {
                if (db.Tos.Count() > 0)
                    to.MaTo = db.Tos.Max(item => item.MaTo) + 1;
                else
                    to.MaTo = 1;
                to.CreateDate = DateTime.Now;
                to.CreateBy = CTaiKhoan.MaUser;
                db.Tos.InsertOnSubmit(to);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(To to)
        {
            try
            {
                to.ModifyDate = DateTime.Now;
                to.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(To to)
        {
            try
            {
                db.Tos.DeleteOnSubmit(to);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public List<To> GetDS_Admin()
        {
            return db.Tos.ToList();
        }

        public List<To> GetDS()
        {
            return db.Tos.Where(item=>item.An==false).ToList();
        }

        public To GetByMaTo(int MaTo)
        {
            return db.Tos.SingleOrDefault(item => item.MaTo == MaTo);
        }

        public string GetTenToByMaTo(int MaTo)
        {
            return db.Tos.SingleOrDefault(item => item.MaTo == MaTo).TenTo;
        }

    }
}
