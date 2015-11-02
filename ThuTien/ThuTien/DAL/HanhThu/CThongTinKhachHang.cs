using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.DAL.HanhThu
{
    class CThongTinKhachHang:CDAL
    {
        public bool Them(TT_ThongTinKhachHang ttkh)
        {
            try
            {
                ttkh.CreateDate = DateTime.Now;
                ttkh.CreateBy = CNguoiDung.MaND;
                _db.TT_ThongTinKhachHangs.InsertOnSubmit(ttkh);
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

        public bool Sua(TT_ThongTinKhachHang ttkh)
        {
            try
            {
                ttkh.ModifyDate = DateTime.Now;
                ttkh.ModifyBy = CNguoiDung.MaND;
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

        public bool CheckExist(string DanhBo)
        {
            return _db.TT_ThongTinKhachHangs.Any(item => item.DanhBo == DanhBo);
        }

        public TT_ThongTinKhachHang Get(string DanhBo)
        {
            return _db.TT_ThongTinKhachHangs.SingleOrDefault(item => item.DanhBo == DanhBo);
        }
    }
}
