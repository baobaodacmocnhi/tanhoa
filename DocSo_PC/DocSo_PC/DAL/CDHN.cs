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
            return _cDAL.ExecuteQuery_SqlDataAdapter_DataTable(sql);

        }
        public DataTable getTTThay(string db)
        {
            string sql = "SELECT DHN_LYDOTHAY AS 'TENBANGKE',DHN_NGAYBAOTHAY,HCT_NGAYGAN,CASE WHEN ISNULL(HCT_TRONGAI,0)=1 THEN N'TN: ' +HCT_LYDOTRONGAI ELSE N'Hoàn tất' end as KETQUA,HCT_CHISOGO,HCT_CHISOGAN,HCT_CREATEDATE, HCT_CREATEBY ";
            sql += " FROM  TB_THAYDHN thay WHERE DHN_DANHBO='" + db + "' ORDER BY DHN_NGAYBAOTHAY DESC ";
            return _cDAL.ExecuteQuery_SqlDataAdapter_DataTable(sql);

        }
        public static TB_DULIEUKHACHHANG finByDanhBo(string danhbo)
        {
            try
            {
                var query = from q in _db.TB_DULIEUKHACHHANGs where q.DANHBO == danhbo select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
               // _db.Error(ex.Message);
            }
            return null;
        }
        public static TB_DULIEUKHACHHANG_HUYDB finByDanhBoHuy(string danhbo)
        {
            try
            {
                var query = (from q in _db.TB_DULIEUKHACHHANG_HUYDBs where q.DANHBO == danhbo orderby q.CREATEDATE descending select q).Take(1);
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }
 
    

    }
}
