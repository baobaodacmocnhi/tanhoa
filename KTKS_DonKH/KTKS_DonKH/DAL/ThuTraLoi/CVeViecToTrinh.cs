using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.ThuTraLoi
{
    class CVeViecToTrinh : CDAL
    {
        public bool Them(ToTrinhVeViec vv)
        {
            try
            {
                if (db.ToTrinhVeViecs.Count() > 0)
                    vv.MaVV = db.ToTrinhVeViecs.Max(item => item.MaVV) + 1;
                else
                    vv.MaVV = 1;
                vv.CreateDate = DateTime.Now;
                vv.CreateBy = CTaiKhoan.MaUser;
                db.ToTrinhVeViecs.InsertOnSubmit(vv);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Sua(ToTrinhVeViec vv)
        {
            try
            {
                vv.ModifyDate = DateTime.Now;
                vv.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Xoa(ToTrinhVeViec vv)
        {
            try
            {
                db.ToTrinhVeViecs.DeleteOnSubmit(vv);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public List<ToTrinhVeViec> GetDS()
        {
            return db.ToTrinhVeViecs.OrderBy(item => item.STT).ToList();
        }

        public ToTrinhVeViec Get(int MaVV)
        {
            return db.ToTrinhVeViecs.Single(item => item.MaVV == MaVV);
        }

        public int GetMaxSTT()
        {
            if (db.ToTrinhVeViecs.Count() == 0)
                return 0;
            else
                return db.ToTrinhVeViecs.Max(item => item.STT).Value;
        }
    }
}
