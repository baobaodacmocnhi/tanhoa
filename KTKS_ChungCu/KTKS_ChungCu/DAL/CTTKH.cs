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

        public HOADON GetMoiNhat(string DanhBo)
        {
            if (dbThuTien.HOADONs.Any(item => item.DANHBA == DanhBo))
                return dbThuTien.HOADONs.Where(item => item.DANHBA == DanhBo).OrderByDescending(item => item.ID_HOADON).First();
            else
                return null;
        }

    }
}