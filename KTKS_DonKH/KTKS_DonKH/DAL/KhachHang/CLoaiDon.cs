using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.KhachHang
{
    class CLoaiDon : CDAL
    {
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

        public bool ThemLoaiDon(LoaiDon loaidon)
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
                //MessageBox.Show("Thành công Thêm LoaiDon", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaLoaiDon(LoaiDon loaidon)
        {
            try
            {
                loaidon.ModifyDate = DateTime.Now;
                loaidon.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa LoaiDon", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaLoaiDon(LoaiDon loaidon)
        {
            try
            {
                db.LoaiDons.DeleteOnSubmit(loaidon);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa LoaiDon", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
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
    }
}
