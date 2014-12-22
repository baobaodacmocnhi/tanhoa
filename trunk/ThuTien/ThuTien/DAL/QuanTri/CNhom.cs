using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;

namespace ThuTien.DAL.QuanTri
{
    class CNhom:CDAL
    {
        public bool Them(TT_Nhom nhom)
        {
            try
            {
                if (_db.TT_Nhoms.Count() > 0)
                    nhom.MaNhom = _db.TT_Nhoms.Max(item => item.MaNhom) + 1;
                else
                    nhom.MaNhom = 1;
                nhom.CreateDate = DateTime.Now;
                nhom.CreateBy = CNguoiDung.MaND;
                _db.TT_Nhoms.InsertOnSubmit(nhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return false;
            }
        }

        public bool Sua(TT_Nhom nhom)
        {
            try
            {
                nhom.ModifyDate = DateTime.Now;
                nhom.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return false;
            }
        }

        public bool Xoa(TT_Nhom nhom)
        {
            try
            {
                _db.TT_Nhoms.DeleteOnSubmit(nhom);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return false;
            }
        }

        public List<TT_Nhom> GetDSNhom()
        {
            return _db.TT_Nhoms.ToList();
        }

        public TT_Nhom GetNhomByMaNhom(int MaNhom)
        {
            return _db.TT_Nhoms.SingleOrDefault(item => item.MaNhom == MaNhom);
        }

        public string GetTenNhomByMaNhom(int MaNhom)
        {
            return _db.TT_Nhoms.SingleOrDefault(item => item.MaNhom == MaNhom).TenNhom;
        }
    }
}
