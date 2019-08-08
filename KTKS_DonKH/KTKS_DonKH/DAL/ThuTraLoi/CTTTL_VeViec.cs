using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.ThuTraLoi
{
    class CTTTL_VeViec : CDAL
    {
        public bool Them(ThuTraLoi_VeViec vv)
        {
            try
            {
                if (db.ThuTraLoi_VeViecs.Count() > 0)
                    vv.MaVV = db.ThuTraLoi_VeViecs.Max(item => item.MaVV) + 1;
                else
                    vv.MaVV = 1;
                vv.CreateDate = DateTime.Now;
                vv.CreateBy = CTaiKhoan.MaUser;
                db.ThuTraLoi_VeViecs.InsertOnSubmit(vv);
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

        public bool Sua(ThuTraLoi_VeViec vv)
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

        public bool Xoa(ThuTraLoi_VeViec vv)
        {
            try
            {
                db.ThuTraLoi_VeViecs.DeleteOnSubmit(vv);
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

        public List<ThuTraLoi_VeViec> GetDS()
        {
            return db.ThuTraLoi_VeViecs.OrderBy(item => item.STT).ToList();
        }

        public ThuTraLoi_VeViec Get(int MaVV)
        {
            return db.ThuTraLoi_VeViecs.Single(item => item.MaVV == MaVV);
        }

        public int GetMaxSTT()
        {
            if (db.ThuTraLoi_VeViecs.Count() == 0)
                return 0;
            else
                return db.ThuTraLoi_VeViecs.Max(item => item.STT).Value;
        }
    }
}
