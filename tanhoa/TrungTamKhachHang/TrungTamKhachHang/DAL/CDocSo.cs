using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TrungTamKhachHang.DAL
{
    class CDocSo
    {
        CConnection _cDAL = new CConnection(CConnection.connectionString_DocSo);

        public DataTable getGhiChiSo(string DanhBo)
        {
            string sql = "select top(12) Ky=CONVERT(char(2),Ky)+'/'+CONVERT(char(4),Nam)"
                           + ",NgayDoc=CONVERT(char(10),DenNgay,103)"
                           + ",CodeMoi"
                           + ",ChiSoCu=CSCu"
                           + ",ChiSoMoi=CSMoi"
                           + ",TieuThu=TieuThuMoi"
                           + " from DocSo"
                           + " where DanhBa=" + DanhBo
                           + " order by Nam desc,CAST(Ky as int) desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }
    }
}
