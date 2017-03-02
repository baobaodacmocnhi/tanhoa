using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.ToKhachHang
{
    class CLoaiDon : CDAL
    {
        public bool Them(LoaiDon loaidon)
        {
            try
            {
                if (db.LoaiDons.Count() > 0)
                    loaidon.MaLD = db.LoaiDons.Max(itemLD => itemLD.MaLD) + 1;
                else
                    loaidon.MaLD = 1;
                loaidon.CreateDate = DateTime.Now;
                loaidon.CreateBy = CTaiKhoan.MaUser;
                db.LoaiDons.InsertOnSubmit(loaidon);
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

        public bool Sua(LoaiDon loaidon)
        {
            try
            {
                loaidon.ModifyDate = DateTime.Now;
                loaidon.ModifyBy = CTaiKhoan.MaUser;
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

        public bool Xoa(LoaiDon loaidon)
        {
            try
            {
                db.LoaiDons.DeleteOnSubmit(loaidon);
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

        public List<LoaiDon> LoadDSLoaiDon_All()
        {
            try
            {
                return db.LoaiDons.OrderBy(item => item.STT).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<LoaiDon> LoadDSLoaiDon()
        {
            try
            {
                return db.LoaiDons.Where(item => item.An == false).OrderBy(item => item.STT).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public LoaiDon getLoaiDonbyID(int MaLD)
        {
            try
            {
                return db.LoaiDons.SingleOrDefault(itemLD => itemLD.MaLD == MaLD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public string getTenLDbyID(int MaLD)
        {
            try
            {
                return db.LoaiDons.SingleOrDefault(itemLD => itemLD.MaLD == MaLD).TenLD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public string getKyHieuLDubyID(int MaLD)
        {
            try
            {
                return db.LoaiDons.SingleOrDefault(itemLD => itemLD.MaLD == MaLD).KyHieuLD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int GetSoLuongLoaiDon()
        {
            try
            {
                return db.LoaiDons.Count();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int GetMaxSTT()
        {
            if (db.LoaiDons.Count() == 0)
                return 0;
            else
                return db.LoaiDons.Max(item => item.STT).Value;
        }
    }
}
