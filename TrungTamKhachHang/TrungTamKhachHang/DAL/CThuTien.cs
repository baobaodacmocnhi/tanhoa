using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TrungTamKhachHang.DAL
{
    class CThuTien
    {
        CConnection _cDAL = new CConnection(CConnection.connectionString_ThuTien);

        public DataTable getTimKiem(string DanhBo)
        {
            string sql = "select * from fnTimKiem('" + DanhBo + "','') order by MaHD desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDanhBo(string HoTen,string SoNha,string TenDuong)
        {
            return _cDAL.ExecuteQuery_DataTable("select * from fnTimKiemTTKH('" + HoTen + "','" + SoNha + "','" + TenDuong + "')");
        }
    }
}
