using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CVeViecCHDB:CDAL
    {
        public bool Them(VeViecCHDB vv)
        {
            try
            {
                    if (db.VeViecCHDBs.Count() > 0)
                        vv.MaVV = db.VeViecCHDBs.Max(item => item.MaVV) + 1;
                    else
                        vv.MaVV = 1;
                    vv.CreateDate = DateTime.Now;
                    vv.CreateBy = CTaiKhoan.MaUser;
                    db.VeViecCHDBs.InsertOnSubmit(vv);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool Sua(VeViecCHDB vv)
        {
            try
            {
                    vv.ModifyDate = DateTime.Now;
                    vv.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool Xoa(VeViecCHDB vv)
        {
            try
            {
                    db.VeViecCHDBs.DeleteOnSubmit(vv);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public List<VeViecCHDB> LoadDS()
        {
            try
            {
                    return db.VeViecCHDBs.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<VeViecCHDB> LoadDS(bool inheritance)
        {
            try
            {
                if (inheritance)
                {
                    return db.VeViecCHDBs.ToList();
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

        public VeViecCHDB getVeViecCHDBbyID(int MaVV)
        {
            try
            {
                return db.VeViecCHDBs.Single(item => item.MaVV == MaVV);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
