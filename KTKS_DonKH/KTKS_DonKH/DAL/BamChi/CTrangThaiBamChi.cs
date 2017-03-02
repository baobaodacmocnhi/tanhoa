using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.BamChi
{
    class CTrangThaiBamChi : CDAL
    {
        public bool Them(TrangThaiBamChi entity)
        {
            try
            {
                if (db.TrangThaiBamChis.Count() > 0)
                    entity.MaTTBC = db.TrangThaiBamChis.Max(itemTTBC => itemTTBC.MaTTBC) + 1;
                else
                    entity.MaTTBC = 1;
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.TrangThaiBamChis.InsertOnSubmit(entity);
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

        public bool Sua(TrangThaiBamChi entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CTaiKhoan.MaUser;
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

        public bool Xoa(TrangThaiBamChi entity)
        {
            try
            {
                db.TrangThaiBamChis.DeleteOnSubmit(entity);
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

        public TrangThaiBamChi Get(int MaTTBC)
        {
            return db.TrangThaiBamChis.SingleOrDefault(item => item.MaTTBC == MaTTBC);
        }

        public List<TrangThaiBamChi> GetDS()
        {
                    return db.TrangThaiBamChis.OrderBy(item => item.STT).ToList();
        }

        public int GetMaxSTT()
        {
            if (db.TrangThaiBamChis.Count() == 0)
                return 0;
            else
                return db.TrangThaiBamChis.Max(item => item.STT).Value;
        }
    }
}
