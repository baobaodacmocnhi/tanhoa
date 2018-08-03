using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using System.Data;

namespace KTKS_DonKH.DAL.ThuTraLoi
{
    class CTTTL_GhiChu : CDAL
    {
        public bool Them(TTTL_GhiChu ghichu)
        {
            try
            {
                if (db.TTTL_GhiChus.Count() > 0)
                {
                    ghichu.ID = db.TTTL_GhiChus.Max(item => item.ID) + 1;
                }
                else
                    ghichu.ID = 1;
                ghichu.CreateDate = DateTime.Now;
                ghichu.CreateBy = CTaiKhoan.MaUser;
                db.TTTL_GhiChus.InsertOnSubmit(ghichu);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TTTL_GhiChu ghichu)
        {
            try
            {
                ghichu.ModifyDate = DateTime.Now;
                ghichu.ModifyBy = CTaiKhoan.MaUser;
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

        public bool Xoa(TTTL_GhiChu ghichu)
        {
            try
            {
                db.TTTL_GhiChus.DeleteOnSubmit(ghichu);
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

        public TTTL_GhiChu Get(int ID)
        {
            return db.TTTL_GhiChus.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS(decimal MaCTTTTL)
        {
            return LINQToDataTable(db.TTTL_GhiChus.Where(item => item.MaCTTTTL == MaCTTTTL).OrderByDescending(item => item.CreateDate).ToList());
        }
    }
}
