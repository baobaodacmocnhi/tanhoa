using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CThongTinDanhBo:CDAL
    {
        public bool Them(TT_ThongTinDanhBo danhbo)
        {
            try
            {
                danhbo.CreateDate = DateTime.Now;
                danhbo.CreateBy = CNguoiDung.MaND;
                _db.TT_ThongTinDanhBos.InsertOnSubmit(danhbo);
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

        public bool Sua(TT_ThongTinDanhBo danhbo)
        {
            try
            {
                danhbo.ModifyDate = DateTime.Now;
                danhbo.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TT_ThongTinDanhBo danhbo)
        {
            try
            {
                _db.TT_ThongTinDanhBos.DeleteOnSubmit(danhbo);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public TT_ThongTinDanhBo GetByDanhBo(string DanhBo)
        {
            return _db.TT_ThongTinDanhBos.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public bool CheckExistByDanhBo(string DanhBo)
        {
            return _db.TT_ThongTinDanhBos.Any(item => item.DanhBo == DanhBo);
        }
    }
}
