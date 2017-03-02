using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using System.Data;

namespace KTKS_DonKH.DAL.ThaoThuTraLoi
{
    class CGhiChuCTTTTL : CDAL
    {
        public bool Them(GhiChuCTTTTL ghichu)
        {
            try
            {
                if (db.GhiChuCTTTTLs.Count() > 0)
                {
                    ghichu.ID = db.GhiChuCTTTTLs.Max(item => item.ID) + 1;
                }
                else
                    ghichu.ID = 1;
                ghichu.CreateDate = DateTime.Now;
                ghichu.CreateBy = CTaiKhoan.MaUser;
                db.GhiChuCTTTTLs.InsertOnSubmit(ghichu);
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

        public bool Sua(GhiChuCTTTTL ghichu)
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

        public bool Xoa(GhiChuCTTTTL ghichu)
        {
            try
            {
                db.GhiChuCTTTTLs.DeleteOnSubmit(ghichu);
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

        public GhiChuCTTTTL Get(int ID)
        {
            return db.GhiChuCTTTTLs.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable GetDS(decimal MaCTTTTL)
        {
            return LINQToDataTable(db.GhiChuCTTTTLs.Where(item => item.MaCTTTTL == MaCTTTTL).OrderByDescending(item => item.CreateDate).ToList());
        }
    }
}
