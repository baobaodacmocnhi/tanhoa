using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.CatHuyDanhBo
{
    class CNoiDungXuLyCHDB:CDAL
    {
        public bool Them(NoiDungXuLyCHDB vv)
        {
            try
            {
                if (db.NoiDungXuLyCHDBs.Count() > 0)
                    vv.ID = db.NoiDungXuLyCHDBs.Max(item => item.ID) + 1;
                else
                    vv.ID = 1;
                vv.CreateDate = DateTime.Now;
                vv.CreateBy = CTaiKhoan.MaUser;
                db.NoiDungXuLyCHDBs.InsertOnSubmit(vv);
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

        public bool Sua(NoiDungXuLyCHDB vv)
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

        public bool Xoa(NoiDungXuLyCHDB vv)
        {
            try
            {
                db.NoiDungXuLyCHDBs.DeleteOnSubmit(vv);
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

        public List<NoiDungXuLyCHDB> GetDS()
        {
            return db.NoiDungXuLyCHDBs.OrderBy(item=>item.STT).ToList();
        }

        public NoiDungXuLyCHDB GetByID(int ID)
        {
            return db.NoiDungXuLyCHDBs.SingleOrDefault(item => item.ID == ID);
        }

        public int GetMaxSTT()
        {
            if (db.NoiDungXuLyCHDBs.Count() == 0)
                return 0;
            else
                return db.NoiDungXuLyCHDBs.Max(item => item.STT).Value;
        }

    }
}
