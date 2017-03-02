using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.CatHuyDanhBo
{
    class CLyDoCHDB : CDAL
    {
        public bool Them(LyDoCHDB vv)
        {
            try
            {
                if (db.LyDoCHDBs.Count() > 0)
                    vv.ID = db.LyDoCHDBs.Max(item => item.ID) + 1;
                else
                    vv.ID = 1;
                vv.CreateDate = DateTime.Now;
                vv.CreateBy = CTaiKhoan.MaUser;
                db.LyDoCHDBs.InsertOnSubmit(vv);
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

        public bool Sua(LyDoCHDB vv)
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

        public bool Xoa(LyDoCHDB vv)
        {
            try
            {
                db.LyDoCHDBs.DeleteOnSubmit(vv);
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

        public List<LyDoCHDB> GetDS()
        {
            return db.LyDoCHDBs.OrderBy(item => item.STT).ToList();
        }

        public LyDoCHDB Get(int ID)
        {
            return db.LyDoCHDBs.SingleOrDefault(item => item.ID == ID);
        }

        public int GetMaxSTT()
        {
            if (db.LyDoCHDBs.Count() == 0)
                return 0;
            else
                return db.LyDoCHDBs.Max(item => item.STT).Value;
        }
    }
}
