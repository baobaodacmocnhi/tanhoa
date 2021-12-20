using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DocSo_PC.DAL
{
    class CDHN
    {
        public static dbDHNDataContext _db = new dbDHNDataContext();
        public static CConnection _cDAL = new CConnection(_db.Connection.ConnectionString);

        /// <summary>
        /// Function lấy dữ liệu
        /// </summary> 
        public DataTable getGhiChuKH(string db)
        {
            string sql = "SELECT ID,NOIDUNG,DONVI,CREATEDATE FROM TB_GHICHU WHERE DANHBO='" + db + "'  ORDER BY CREATEDATE DESC";
            return _cDAL.ExecuteQuery_DataTable(sql);

        }
        public DataTable getTTThay(string db)
        {
            string sql = "SELECT DHN_LYDOTHAY AS 'TENBANGKE',DHN_NGAYBAOTHAY,HCT_NGAYGAN,CASE WHEN ISNULL(HCT_TRONGAI,0)=1 THEN N'TN: ' +HCT_LYDOTRONGAI ELSE N'Hoàn tất' end as KETQUA,HCT_CHISOGO,HCT_CHISOGAN,HCT_CREATEDATE, HCT_CREATEBY ";
            sql += " FROM  TB_THAYDHN thay WHERE DHN_DANHBO='" + db + "' ORDER BY DHN_NGAYBAOTHAY DESC ";
            return _cDAL.ExecuteQuery_DataTable(sql);

        }
        public TB_DULIEUKHACHHANG get(string DanhBo)
        {
            return _db.TB_DULIEUKHACHHANGs.SingleOrDefault(item => item.DANHBO == DanhBo);
        }
        public TB_DULIEUKHACHHANG_HUYDB get_Huy(string DanhBo)
        {
            return _db.TB_DULIEUKHACHHANG_HUYDBs.SingleOrDefault(item => item.DANHBO == DanhBo);
        }



    }
}
