using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;

namespace DocSo_PC.DAL.ChuyenBillding
{
    class CChuyenDuLieu : CDAL
    {
        public SqlConnection conn = new SqlConnection();
        public OdbcConnection connTongCT = new OdbcConnection();
        public void OpenConnectionTCT(string name, string pass)
        {
            try
            {
                connTongCT = new OdbcConnection(@"Dsn=oracle7;uid=TH_HANDHELD;pwd =TH_HANDHELD");
                if (connTongCT.State != ConnectionState.Open)
                {
                    connTongCT.Open();
                }
            }
            catch (Exception)
            {
                try
                {
                    connTongCT = new OdbcConnection(@"Dsn=oracle7;uid=TH_HANDHELD;pwd =TH_HANDHELD");
                    if (connTongCT.State != ConnectionState.Open)
                    {
                        connTongCT.Open();
                    }
                }
                catch (Exception) { MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu Billing"); }
            }
        }
        public void CloseConnectionTCT()
        {
            if (connTongCT.State != ConnectionState.Closed)
            {
                connTongCT.Close();
            }
            connTongCT.Dispose();
        }
    }
}
