using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.DAL.MaHoa
{
    class CPhieuChuyenLichSu : CDAL
    {
        public static bool them(string DanhBo, string NoiDung, string GhiChu)
        {
            return _cDAL.ExecuteNonQuery("insert into MaHoa_PhieuChuyen_LichSu(DanhBo,NoiDung,GhiChu,CreateBy,CreateDate)values('" + DanhBo + "',N'" + NoiDung + "',N'" + GhiChu + "'," + CNguoiDung.MaND + ",getdate())");
        }
    }
}
