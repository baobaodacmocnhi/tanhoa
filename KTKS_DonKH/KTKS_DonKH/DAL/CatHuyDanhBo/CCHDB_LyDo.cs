using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.CatHuyDanhBo
{
    class CCHDB_LyDo : CDAL
    {
        public bool Them(CHDB_LyDo vv)
        {
            try
            {
                if (db.CHDB_LyDos.Count() > 0)
                    vv.ID = db.CHDB_LyDos.Max(item => item.ID) + 1;
                else
                    vv.ID = 1;
                vv.CreateDate = DateTime.Now;
                vv.CreateBy = CTaiKhoan.MaUser;
                db.CHDB_LyDos.InsertOnSubmit(vv);
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

        public bool Sua(CHDB_LyDo vv)
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

        public bool Xoa(CHDB_LyDo vv)
        {
            try
            {
                db.CHDB_LyDos.DeleteOnSubmit(vv);
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

        public List<CHDB_LyDo> GetDS()
        {
            return db.CHDB_LyDos.OrderBy(item => item.STT).ToList();
        }

        public CHDB_LyDo Get(int ID)
        {
            return db.CHDB_LyDos.SingleOrDefault(item => item.ID == ID);
        }

        public int GetMaxSTT()
        {
            if (db.CHDB_LyDos.Count() == 0)
                return 0;
            else
                return db.CHDB_LyDos.Max(item => item.STT).Value;
        }
    }
}
