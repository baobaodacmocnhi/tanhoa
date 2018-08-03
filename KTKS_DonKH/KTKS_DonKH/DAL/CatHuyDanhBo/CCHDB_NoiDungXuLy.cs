using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.CatHuyDanhBo
{
    class CCHDB_NoiDungXuLy : CDAL
    {
        public bool Them(CHDB_NoiDungXuLy vv)
        {
            try
            {
                if (db.CHDB_NoiDungXuLies.Count() > 0)
                    vv.ID = db.CHDB_NoiDungXuLies.Max(item => item.ID) + 1;
                else
                    vv.ID = 1;
                vv.CreateDate = DateTime.Now;
                vv.CreateBy = CTaiKhoan.MaUser;
                db.CHDB_NoiDungXuLies.InsertOnSubmit(vv);
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

        public bool Sua(CHDB_NoiDungXuLy vv)
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

        public bool Xoa(CHDB_NoiDungXuLy vv)
        {
            try
            {
                db.CHDB_NoiDungXuLies.DeleteOnSubmit(vv);
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

        public List<CHDB_NoiDungXuLy> GetDS()
        {
            return db.CHDB_NoiDungXuLies.OrderBy(item=>item.STT).ToList();
        }

        public CHDB_NoiDungXuLy Get(int ID)
        {
            return db.CHDB_NoiDungXuLies.SingleOrDefault(item => item.ID == ID);
        }

        public int GetMaxSTT()
        {
            if (db.CHDB_NoiDungXuLies.Count() == 0)
                return 0;
            else
                return db.CHDB_NoiDungXuLies.Max(item => item.STT).Value;
        }

    }
}
