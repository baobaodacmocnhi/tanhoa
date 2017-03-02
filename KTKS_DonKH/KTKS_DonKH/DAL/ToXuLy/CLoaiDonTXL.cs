using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.ToXuLy
{
    class CLoaiDonTXL : CDAL
    {
        public bool Them(LoaiDonTXL entity)
        {
            try
            {
                if (db.LoaiDonTXLs.Count() > 0)
                {
                    entity.MaLD = db.LoaiDonTXLs.Max(item => item.MaLD) + 1;
                    entity.STT = db.LoaiDonTXLs.Max(item => item.STT) + 1;
                }
                else
                {
                    entity.MaLD = 1;
                    entity.STT = 1;
                }
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.LoaiDonTXLs.InsertOnSubmit(entity);
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

        public bool Sua(LoaiDonTXL entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                Refresh();
                return false;
            }
        }

        public bool Xoa(LoaiDonTXL entity)
        {
            try
            {
                db.LoaiDonTXLs.DeleteOnSubmit(entity);
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

        public List<LoaiDonTXL> GetDS_All()
        {
            return db.LoaiDonTXLs.OrderBy(item => item.An).ThenBy(item => item.STT).ToList();
        }

        public List<LoaiDonTXL> GetDS()
        {
            return db.LoaiDonTXLs.Where(item => item.An == false).OrderBy(item => item.STT).ToList();
        }

        public LoaiDonTXL Get(int MaLD)
        {
            return db.LoaiDonTXLs.SingleOrDefault(item => item.MaLD == MaLD);
        }

        public string GetTenLD(int MaLD)
        {
            return db.LoaiDonTXLs.SingleOrDefault(item => item.MaLD == MaLD).TenLD;
        }

        public string GetKyHieuLD(int MaLD)
        {
            return db.LoaiDonTXLs.SingleOrDefault(item => item.MaLD == MaLD).KyHieuLD;
        }

        public int GetMaxSTT()
        {
            if (db.LoaiDonTXLs.Count() == 0)
                return 0;
            else
                return db.LoaiDonTXLs.Max(item => item.STT).Value;
        }
    }
}
