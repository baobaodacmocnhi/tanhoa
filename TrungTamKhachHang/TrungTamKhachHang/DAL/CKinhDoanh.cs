using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TrungTamKhachHang.DAL
{
    class CKinhDoanh
    {
        CConnection _cDAL = new CConnection(CConnection.connectionString_KinhDoanh);

        public DataTable GetDSTimKiem(string DanhBo)
        {
            string sql = "select * from fnTimKiem('" + DanhBo + "') order by MaHD desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDanhBo(string HoTen,string SoNha,string TenDuong)
        {
            return _cDAL.ExecuteQuery_DataTable("select * from fnTimKiemTTKH('" + HoTen + "','" + SoNha + "','" + TenDuong + "')");
        }
    }
}
