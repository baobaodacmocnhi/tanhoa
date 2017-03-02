using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.ToBamChi
{
    class CLoaiDonTBC : CDAL
    {
        public bool Them(LoaiDonTBC entity)
        {
            try
            {
                if (db.LoaiDonTBCs.Count() > 0)
                    entity.MaLD = db.LoaiDonTBCs.Max(itemLD => itemLD.MaLD) + 1;
                else
                    entity.MaLD = 1;
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.LoaiDonTBCs.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(LoaiDonTBC entity)
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
                return false;
            }
        }

        public bool Xoa(LoaiDonTBC entity)
        {
            try
            {
                db.LoaiDonTBCs.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<LoaiDonTBC> GetDS_All()
        {
            return db.LoaiDonTBCs.OrderBy(item => item.STT).ToList();
        }

        public List<LoaiDonTBC> GetDS()
        {
            return db.LoaiDonTBCs.Where(item => item.An == false).OrderBy(item => item.STT).ToList();
        }

        public LoaiDonTBC Get(int MaLD)
        {
            return db.LoaiDonTBCs.SingleOrDefault(item => item.MaLD == MaLD);
        }

        public string GetTenLD(int MaLD)
        {
            return db.LoaiDonTBCs.SingleOrDefault(item => item.MaLD == MaLD).TenLD;
        }

        public string GetKyHieuLD(int MaLD)
        {
            return db.LoaiDonTBCs.SingleOrDefault(item => item.MaLD == MaLD).KyHieuLD;
        }

        public int GetMaxSTT()
        {
            if (db.LoaiDonTBCs.Count() == 0)
                return 0;
            else
                return db.LoaiDonTBCs.Max(item => item.STT).Value;
        }
    }
}
