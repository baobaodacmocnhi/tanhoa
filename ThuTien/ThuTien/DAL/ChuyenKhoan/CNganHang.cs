using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CNganHang:CDAL
    {
        public bool Them(NGANHANG nganhang)
        {
            try
            {
                if (_db.NGANHANGs.Count() > 0)
                    nganhang.ID_NGANHANG = _db.NGANHANGs.Max(item => item.ID_NGANHANG) + 1;
                else
                    nganhang.ID_NGANHANG = 1;
                nganhang.CreateDate = DateTime.Now;
                nganhang.CreateBy = CNguoiDung.MaND;
                _db.NGANHANGs.InsertOnSubmit(nganhang);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(NGANHANG nganhang)
        {
            try
            {
                nganhang.ModifyDate = DateTime.Now;
                nganhang.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(NGANHANG nganhang)
        {
            try
            {
                _db.NGANHANGs.DeleteOnSubmit(nganhang);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public NGANHANG GetByMaNH(int MaNH)
        {
            return _db.NGANHANGs.SingleOrDefault(item => item.ID_NGANHANG == MaNH);
        }

        public int GetMaNHByKyHieu(string KyHieu)
        {
            return _db.NGANHANGs.SingleOrDefault(item => item.KyHieu == KyHieu).ID_NGANHANG;
        }

        public System.Data.DataTable GetDS()
        {
            return LINQToDataTable(_db.NGANHANGs.Select(item => new { MaNH = item.ID_NGANHANG,item.KyHieu ,TenNH = item.NGANHANG1,item.SoTK }).ToList());
        }
    }
}
