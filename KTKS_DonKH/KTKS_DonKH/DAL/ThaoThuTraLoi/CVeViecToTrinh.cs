using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.ThaoThuTraLoi
{
    class CVeViecToTrinh : CDAL
    {
        public bool Them(VeViecToTrinh vv)
        {
            try
            {
                if (db.VeViecToTrinhs.Count() > 0)
                    vv.MaVV = db.VeViecToTrinhs.Max(item => item.MaVV) + 1;
                else
                    vv.MaVV = 1;
                vv.CreateDate = DateTime.Now;
                vv.CreateBy = CTaiKhoan.MaUser;
                db.VeViecToTrinhs.InsertOnSubmit(vv);
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

        public bool Sua(VeViecToTrinh vv)
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

        public bool Xoa(VeViecToTrinh vv)
        {
            try
            {
                db.VeViecToTrinhs.DeleteOnSubmit(vv);
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

        public List<VeViecToTrinh> GetDS()
        {
            return db.VeViecToTrinhs.OrderBy(item => item.STT).ToList();
        }

        public VeViecToTrinh Get(int MaVV)
        {
            return db.VeViecToTrinhs.Single(item => item.MaVV == MaVV);
        }

        public int GetMaxSTT()
        {
            if (db.VeViecToTrinhs.Count() == 0)
                return 0;
            else
                return db.VeViecToTrinhs.Max(item => item.STT).Value;
        }
    }
}
