using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.ThaoThuTraLoi
{
    class CVeViecTTTL : CDAL
    {
        public bool Them(TTTLVeViec vv)
        {
            try
            {
                if (db.TTTLVeViecs.Count() > 0)
                    vv.MaVV = db.TTTLVeViecs.Max(item => item.MaVV) + 1;
                else
                    vv.MaVV = 1;
                vv.CreateDate = DateTime.Now;
                vv.CreateBy = CTaiKhoan.MaUser;
                db.TTTLVeViecs.InsertOnSubmit(vv);
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

        public bool Sua(TTTLVeViec vv)
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

        public bool Xoa(TTTLVeViec vv)
        {
            try
            {
                db.TTTLVeViecs.DeleteOnSubmit(vv);
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

        public List<TTTLVeViec> GetDS()
        {
            return db.TTTLVeViecs.OrderBy(item => item.STT).ToList();
        }

        public TTTLVeViec Get(int MaVV)
        {
            return db.TTTLVeViecs.Single(item => item.MaVV == MaVV);
        }

        public int GetMaxSTT()
        {
            if (db.TTTLVeViecs.Count() == 0)
                return 0;
            else
                return db.TTTLVeViecs.Max(item => item.STT).Value;
        }
    }
}
