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
        public bool Them(ThuTraLoi_GhiChu ghichu)
        {
            try
            {
                if (db.ThuTraLoi_GhiChus.Count() > 0)
                {
                    ghichu.ID = db.ThuTraLoi_GhiChus.Max(item => item.ID) + 1;
                }
                else
                    ghichu.ID = 1;
                ghichu.CreateDate = DateTime.Now;
                ghichu.CreateBy = CTaiKhoan.MaUser;
                db.ThuTraLoi_GhiChus.InsertOnSubmit(ghichu);
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

        public bool Sua(ThuTraLoi_GhiChu ghichu)
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

        public bool Xoa(ThuTraLoi_GhiChu ghichu)
        {
            try
            {
                db.ThuTraLoi_GhiChus.DeleteOnSubmit(ghichu);
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

        public ThuTraLoi_GhiChu Get(int ID)
        {
            return db.ThuTraLoi_GhiChus.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS(decimal MaCTTTTL)
        {
            return LINQToDataTable(db.ThuTraLoi_GhiChus.Where(item => item.MaCTTTTL == MaCTTTTL).OrderByDescending(item => item.CreateDate).ToList());
        }
    }
}
