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
        public List<TrangThaiBamChi> LoadDSTrangThaiBamChi()
        {
            try
            {
                    return db.TrangThaiBamChis.OrderBy(item => item.STT).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public TrangThaiBamChi getTrangThaiBamChibyID(int MaTTBC)
        {
            try
            {
                return db.TrangThaiBamChis.Single(itemTTBC => itemTTBC.MaTTBC == MaTTBC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemTrangThaiBamChi(TrangThaiBamChi trangthaibamchi)
        {
            try
            {
                    if (db.TrangThaiBamChis.Count() > 0)
                        trangthaibamchi.MaTTBC = db.TrangThaiBamChis.Max(itemTTBC => itemTTBC.MaTTBC) + 1;
                    else
                        trangthaibamchi.MaTTBC = 1;
                    trangthaibamchi.CreateDate = DateTime.Now;
                    trangthaibamchi.CreateBy = CTaiKhoan.MaUser;
                    db.TrangThaiBamChis.InsertOnSubmit(trangthaibamchi);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaTrangThaiBamChi(TrangThaiBamChi trangthaibamchi)
        {
            try
            {
                    trangthaibamchi.ModifyDate = DateTime.Now;
                    trangthaibamchi.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaTrangThaiBamChi(List<TrangThaiBamChi> lsttrangthaibamchi)
        {
            try
            {
                    //trangthaibamchi.ModifyDate = DateTime.Now;
                    //trangthaibamchi.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaTrangThaiBamChi(TrangThaiBamChi trangthaibamchi)
        {
            try
            {
                    db.TrangThaiBamChis.DeleteOnSubmit(trangthaibamchi);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TrangThaiBamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool UpdateSQL(string sql)
        {
            try
            {
                    db.ExecuteCommand(sql);
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
