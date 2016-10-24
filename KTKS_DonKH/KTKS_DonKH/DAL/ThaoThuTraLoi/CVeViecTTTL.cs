using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.ThaoThuTraLoi
{
    class CVeViecTTTL:CDAL
    {
        public bool Them(VeViecTTTL vv)
        {
            try
            {
                    if (db.VeViecTTTLs.Count() > 0)
                        vv.MaVV = db.VeViecTTTLs.Max(item => item.MaVV) + 1;
                    else
                        vv.MaVV = 1;
                    vv.CreateDate = DateTime.Now;
                    vv.CreateBy = CTaiKhoan.MaUser;
                    db.VeViecTTTLs.InsertOnSubmit(vv);
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

        public bool Sua(VeViecTTTL vv)
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

        public bool Xoa(VeViecTTTL vv)
        {
            try
            {
                    db.VeViecTTTLs.DeleteOnSubmit(vv);
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

        public List<VeViecTTTL> GetDS()
        {
            try
            {
                    return db.VeViecTTTLs.OrderBy(item=>item.STT).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public VeViecTTTL GetByID(int MaVV)
        {
            try
            {
                return db.VeViecTTTLs.Single(item => item.MaVV== MaVV);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int GetMaxSTT()
        {
            if (db.VeViecTTTLs.Count() == 0)
                return 0;
            else
                return db.VeViecTTTLs.Max(item => item.STT).Value;
        }
    }
}
