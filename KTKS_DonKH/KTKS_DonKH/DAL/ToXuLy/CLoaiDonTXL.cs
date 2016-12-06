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
        public List<LoaiDonTXL> LoadDSLoaiDonTXL_All()
        {
            try
            {
                return db.LoaiDonTXLs.OrderBy(item => item.STT).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<LoaiDonTXL> LoadDSLoaiDonTXL()
        {
            try
            {
                return db.LoaiDonTXLs.Where(item=>item.An==false).OrderBy(item => item.STT).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public LoaiDonTXL getLoaiDonTXLbyID(int MaLD)
        {
            try
            {
                return db.LoaiDonTXLs.SingleOrDefault(itemLDTXL => itemLDTXL.MaLD == MaLD);
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
                return db.LoaiDonTXLs.SingleOrDefault(itemLDXL => itemLDXL.MaLD == MaLD).TenLD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public string getKyHieuLDTXLubyID(int MaLD)
        {
            try
            {
                return db.LoaiDonTXLs.SingleOrDefault(itemLDTXL => itemLDTXL.MaLD == MaLD).KyHieuLD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemLoaiDonTXL(LoaiDonTXL loaidontxl)
        {
            try
            {
                if (db.LoaiDonTXLs.Count() > 0)
                    loaidontxl.MaLD = db.LoaiDonTXLs.Max(itemLD => itemLD.MaLD) + 1;
                else
                    loaidontxl.MaLD = 1;
                loaidontxl.CreateDate = DateTime.Now;
                loaidontxl.CreateBy = CTaiKhoan.MaUser;
                db.LoaiDonTXLs.InsertOnSubmit(loaidontxl);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Thêm LoaiDonTXL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaLoaiDonTXL(LoaiDonTXL loaidontxl)
        {
            try
            {
                loaidontxl.ModifyDate = DateTime.Now;
                loaidontxl.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa LoaiDonTXL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaLoaiDonTXL(LoaiDonTXL loaidontxl)
        {
            try
            {
                db.LoaiDonTXLs.DeleteOnSubmit(loaidontxl);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa LoaiDonTXL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

    }
}
