using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Windows.Forms;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CTienDu:CDAL
    {
        //Quản lý tiền dư của khách hàng

        public bool Them(TT_TienDu tiendu)
        {
            try
            {
                tiendu.CreateDate = DateTime.Now;
                tiendu.CreateBy = CNguoiDung.MaND;
                tiendu.ModifyDate = DateTime.Now;
                tiendu.ModifyBy = CNguoiDung.MaND;
                _db.TT_TienDus.InsertOnSubmit(tiendu);
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

        public bool Sua(TT_TienDu tiendu)
        {
            try
            {
                tiendu.ModifyDate = DateTime.Now;
                tiendu.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public TT_TienDu Get(string DanhBo)
        {
            return _db.TT_TienDus.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public bool CheckExist(string DanhBo)
        {
            return _db.TT_TienDus.Any(item => item.DanhBo == DanhBo);
        }

        public bool Update(string DanhBo, int SoTien)
        {
            try
            {
                if (!ExecuteNonQuery("update TT_BangKe set SoTien=SoTien+" + SoTien + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo='" + DanhBo + "'", false))
                    ExecuteNonQuery("insert into TT_BangKe(DanhBo,SoTien,CreateBy,CreateDate) values('" + DanhBo + "'," + SoTien + "," + CNguoiDung.MaND + ",GETDATE())", false);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
