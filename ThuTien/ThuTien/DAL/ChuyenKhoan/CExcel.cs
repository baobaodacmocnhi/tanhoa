using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CExcel
    {
        static OleDbConnection _con;
        //OleDbCommand _cmd;
        OleDbDataAdapter _da;
        DataTable _table;
        String _cn;
        String pathFile;

        public CExcel(String pathFile)
        {
            this.pathFile = pathFile;
        }

        #region Hàm connect file Excel 2010 trở về trước

        public OleDbConnection Connect()
        {
            if (pathFile.Contains("xlsx")) _cn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathFile + ";" + "Extended Properties=Excel 12.0;";
            else
                _cn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + pathFile + ";" + "Extended Properties=Excel 8.0;";
            _con = new OleDbConnection(_cn);
            _con.Open();
            return _con;
        }

        #endregion

        #region hàm thực thi 1 câu lệnh truy vấn như sql

        public DataTable GetDataTable(String sql)
        {
            _table = new DataTable();
            try
            {
                _con = Connect();
                _da = new OleDbDataAdapter(sql, _con);
                _da.Fill(_table);
                _con.Close();
                return _table;
            }
            catch (OleDbException ex)
            {
                _con.Close();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return _table;
            }

        }

        #endregion
    }
}
