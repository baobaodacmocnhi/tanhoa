using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_ChungCu.LinQ;
using System.Windows.Forms;
using System.IO;

namespace KTKS_ChungCu.DAL
{
    class CTTKH : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng TTKhachHang & TTKhachHangDate
        
        #region TTKhachHang

        public TTKhachHang getTTKHbyID(string DanhBo)
        {
            try
            {
                return db.TTKhachHangs.SingleOrDefault(itemTTKH => itemTTKH.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool CheckTTKHbyID(string DanhBo)
        {
            try
            {
                return db.TTKhachHangs.Any(itemTTKH => itemTTKH.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

    }
}