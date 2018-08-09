using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.ThuTraLoi
{
    class CToTrinh_VeViec : CDAL
    {
        public bool Them(ToTrinh_VeViec vv)
        {
            try
            {
                if (db.ToTrinh_VeViecs.Count() > 0)
                    vv.ID = db.ToTrinh_VeViecs.Max(item => item.ID) + 1;
                else
                    vv.ID = 1;
                vv.CreateDate = DateTime.Now;
                vv.CreateBy = CTaiKhoan.MaUser;
                db.ToTrinh_VeViecs.InsertOnSubmit(vv);
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

        public bool Sua(ToTrinh_VeViec vv)
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

        public bool Xoa(ToTrinh_VeViec vv)
        {
            try
            {
                db.ToTrinh_VeViecs.DeleteOnSubmit(vv);
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

        public List<ToTrinh_VeViec> GetDS()
        {
            return db.ToTrinh_VeViecs.OrderBy(item => item.STT).ToList();
        }

        public ToTrinh_VeViec Get(int ID)
        {
            return db.ToTrinh_VeViecs.Single(item => item.ID == ID);
        }

        public int GetMaxSTT()
        {
            if (db.ToTrinh_VeViecs.Count() == 0)
                return 0;
            else
                return db.ToTrinh_VeViecs.Max(item => item.STT).Value;
        }
    }
}
