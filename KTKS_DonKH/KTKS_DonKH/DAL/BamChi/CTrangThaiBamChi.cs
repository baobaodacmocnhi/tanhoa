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
        public bool Them(BamChi_TrangThai entity)
        {
            try
            {
                if (db.BamChi_TrangThais.Count() > 0)
                    entity.MaTTBC = db.BamChi_TrangThais.Max(itemTTBC => itemTTBC.MaTTBC) + 1;
                else
                    entity.MaTTBC = 1;
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.BamChi_TrangThais.InsertOnSubmit(entity);
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

        public bool Sua(BamChi_TrangThai entity)
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

        public bool Xoa(BamChi_TrangThai entity)
        {
            try
            {
                db.BamChi_TrangThais.DeleteOnSubmit(entity);
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

        public BamChi_TrangThai Get(int MaTTBC)
        {
            return db.BamChi_TrangThais.SingleOrDefault(item => item.MaTTBC == MaTTBC);
        }

        public List<BamChi_TrangThai> GetDS()
        {
                    return db.BamChi_TrangThais.OrderBy(item => item.STT).ToList();
        }

        public int GetMaxSTT()
        {
            if (db.BamChi_TrangThais.Count() == 0)
                return 0;
            else
                return db.BamChi_TrangThais.Max(item => item.STT).Value;
        }
    }
}
