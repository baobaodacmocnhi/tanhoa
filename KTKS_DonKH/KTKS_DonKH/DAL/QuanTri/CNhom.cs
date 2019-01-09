using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.QuanTri
{
    class CNhom:CDAL
    {
        public bool Them(Nhom nhom)
        {
            try
            {
                if (db.Nhoms.Count() > 0)
                    nhom.MaNhom = db.Nhoms.Max(item => item.MaNhom) + 1;
                else
                    nhom.MaNhom = 1;
                nhom.CreateDate = DateTime.Now;
                nhom.CreateBy = CTaiKhoan.MaUser;
                db.Nhoms.InsertOnSubmit(nhom);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(Nhom nhom)
        {
            try
            {
                nhom.ModifyDate = DateTime.Now;
                nhom.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(Nhom nhom)
        {
            try
            {
                db.Nhoms.DeleteOnSubmit(nhom);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public List<Nhom> GetDS()
        {
            return db.Nhoms.OrderBy(item=>item.TenNhom).ToList();
        }

        public Nhom GetByMaNhom(int MaTT_Nhom)
        {
            return db.Nhoms.SingleOrDefault(item => item.MaNhom == MaTT_Nhom);
        }

        public string GetTenNhomByMaNhom(int MaTT_Nhom)
        {
            return db.Nhoms.SingleOrDefault(item => item.MaNhom == MaTT_Nhom).TenNhom;
        }
    }
}
