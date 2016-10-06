using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.KiemTraXacMinh
{
    class CHienTrangKiemTra : CDAL
    {
        public List<HienTrangKiemTra> LoadDSHienTrangKiemTra()
        {
            try
            {
                return db.HienTrangKiemTras.OrderBy(item => item.STT).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<HienTrangKiemTra> LoadDSHienTrangKiemTra(bool inheritance)
        {
            try
            {
                if (inheritance)
                {
                    return db.HienTrangKiemTras.OrderBy(item => item.STT).ToList();
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public HienTrangKiemTra getHienTrangKiemTrabyID(int MaHTKT)
        {
            try
            {
                return db.HienTrangKiemTras.Single(itemHTKT => itemHTKT.MaHTKT == MaHTKT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemHienTrangKiemTra(HienTrangKiemTra hientrangkiemtra)
        {
            try
            {
                if (db.HienTrangKiemTras.Count() > 0)
                    hientrangkiemtra.MaHTKT = db.HienTrangKiemTras.Max(itemHTKT => itemHTKT.MaHTKT) + 1;
                else
                    hientrangkiemtra.MaHTKT = 1;
                hientrangkiemtra.CreateDate = DateTime.Now;
                hientrangkiemtra.CreateBy = CTaiKhoan.MaUser;
                db.HienTrangKiemTras.InsertOnSubmit(hientrangkiemtra);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Thêm HienTrangKiemTra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaHienTrangKiemTra(HienTrangKiemTra hientrangkiemtra)
        {
            try
            {
                hientrangkiemtra.ModifyDate = DateTime.Now;
                hientrangkiemtra.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaHienTrangKiemTra(List<HienTrangKiemTra> lsthientrangkiemtra)
        {
            try
            {
                //hientrangkiemtra.ModifyDate = DateTime.Now;
                //hientrangkiemtra.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaHienTrangKiemTra(HienTrangKiemTra hientrangkiemtra)
        {
            try
            {
                db.HienTrangKiemTras.DeleteOnSubmit(hientrangkiemtra);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }
    }
}
