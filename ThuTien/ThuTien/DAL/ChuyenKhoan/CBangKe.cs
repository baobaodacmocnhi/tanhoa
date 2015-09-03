using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CBangKe:CDAL
    {
        public bool Them(TT_BangKe bangke)
        {
            try
            {
                bangke.CreateDate = DateTime.Now;
                bangke.CreateBy = CNguoiDung.MaND;
                _db.TT_BangKes.InsertOnSubmit(bangke);
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

        public bool Sua(TT_BangKe bangke)
        {
            try
            {
                bangke.ModifyDate = DateTime.Now;
                bangke.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TT_BangKe bangke)
        {
            try
            {
                _db.TT_BangKes.DeleteOnSubmit(bangke);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string DanhBo,int MaNH)
        {
            return _db.TT_BangKes.Any(item => item.DanhBo == DanhBo && item.MaNH == MaNH);
        }
    }
}
