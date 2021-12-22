using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;

namespace DocSo_PC.DAL.Doi
{
    class CChuyenBilling : CDAL
    {
        public SqlConnection conn = new SqlConnection();
        public OdbcConnection connTongCT = new OdbcConnection();

        public void OpenConnectionTCT()
        {
            try
            {
                connTongCT = new OdbcConnection(@"Dsn=oracle7;uid=TH_HANDHELD;pwd=TH_HANDHELD;server=center");
                if (connTongCT.State != ConnectionState.Open)
                {
                    connTongCT.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConnectionTCT()
        {
            try
            {
                if (connTongCT.State != ConnectionState.Closed)
                {
                    connTongCT.Close();
                }
                connTongCT.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CapNhatDuLieuBilling(string Nam, string Ky, string Dot)
        {
            bool flag = false;
            string sql = "SELECT DanhBa,CSCu,CASE WHEN LEFT(CodeMoi, 1) = 'F' OR LEFT(CodeMoi, 1) = '6' THEN TieuThuMoi ELSE CSMOI END AS CSMoi,TieuThuMoi,CASE WHEN LEFT(CodeMoi,1) = '4' THEN '4' ELSE CodeMoi END AS CodeMoi,MLT2,TTDHNMoi"
                        + ",DenNgay=CONVERT(varchar(10),DenNgay,103) FROM DocSo WHERE Nam=" + Nam + " and Ky='" + Ky + "' AND Dot='" + Dot + "'";
            DataTable dataTable = _cDAL.ExecuteQuery_DataTable(sql);
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            num3 = dataTable.Rows.Count;
            bool result;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string DanhBo = dataTable.Rows[i]["DanhBa"].ToString().Trim();
                string CodeMoi = dataTable.Rows[i]["CodeMoi"].ToString().Trim();
                string CSC = dataTable.Rows[i]["CSCu"].ToString().Trim();
                string CSM = dataTable.Rows[i]["CSMoi"].ToString().Trim();
                string TieuThuMoi = dataTable.Rows[i]["TieuThuMoi"].ToString().Trim();
                double ID = Convert.ToDouble(this.getID());
                string MLT = dataTable.Rows[i]["MLT2"].ToString().Trim();
                string May = MLT.Substring(2, 2);
                string STT = MLT.Substring(4, 3);
                string NgayDoc = dataTable.Rows[i]["DenNgay"].ToString().Trim();
                string rST_ID = this.getRST_ID(CodeMoi);
                if (!(rST_ID.Trim() == ""))
                {
                    goto IL_1C0;
                }
            IL_1C0:
                if (CodeMoi.Length == 0)
                {
                    //MessageBox.Show("Kiểm tra lại code mới của danh bạ " + text);
                    result = false;
                    return result;
                }
                string cmdText = "INSERT INTO ADMIN.\"TMP$MR\" (ID, BRANCH_CODE, \"YEAR\", PERIOD, BC_CODE, CUSTOMER_NO, MR_STATUS, THIS_READING, CONSUMPTION, DATE_READING, CREATED_ON, CREATED_BY, BOOK_NO, OIB, EMP_ID, RST_ID) VALUES ("
                            + ID + ",'TH'," + Nam + "," + Ky + ",'" + Dot + "','" + DanhBo + "','" + CodeMoi + "'," + CSM + "," + TieuThuMoi + ",'" + NgayDoc + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','TH_HANDHELD','" + May + "','" + STT + "','100000002','" + rST_ID + "')";
                if (CodeMoi.Length > 0 && (CodeMoi.Substring(0, 1) == "5" || CodeMoi.Substring(0, 1) == "8" || CodeMoi.Substring(0, 1) == "M"))
                {
                    cmdText = "INSERT INTO ADMIN.\"TMP$MR\" (ID, BRANCH_CODE, \"YEAR\", PERIOD, BC_CODE, CUSTOMER_NO, MR_STATUS, LAST_READING, THIS_READING, CONSUMPTION, DATE_READING, CREATED_ON, CREATED_BY, BOOK_NO, OIB, EMP_ID,RST_ID) VALUES ("
                            + ID + ",'TH'," + Nam + "," + Ky + ",'" + Dot + "','" + DanhBo + "','" + CodeMoi + "'," + CSC + "," + CSM + "," + TieuThuMoi + ",'" + NgayDoc + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','TH_HANDHELD','" + May + "','" + STT + "','100000002','" + rST_ID + "')";
                }
                try
                {
                    if (MLT.Length > 6)
                    {
                        try
                        {
                            this.OpenConnectionTCT();
                            OdbcCommand odbcCommand = new OdbcCommand(cmdText, this.connTongCT);
                            int num5 = odbcCommand.ExecuteNonQuery();
                            if (num5 > 0)
                            {
                                num++;
                            }
                        }
                        catch
                        {
                        }
                        this.CloseConnectionTCT();
                    }
                }
                catch (Exception ex)
                {
                    num2++;
                    this.CloseConnectionTCT();
                }
            }
            this.CloseConnectionTCT();
            if (num2 > 0)
            {
                flag = true;
        //        MessageBox.Show(string.Concat(new string[]
        //{
        //    "Chuyển billing thành công ",
        //    num.ToString(),
        //    " danh bạ, lỗi ",
        //    num2.ToString(),
        //    " danh bạ"
        //}));
            }
            if (num2 == 0 && num == num3)
            {
                //MessageBox.Show("Chuyển billing thành công " + num.ToString() + " danh bạ");
            }
            result = flag;
            return result;
        }

        protected string getID()
        {
            string result = "0";
            try
            {
                OpenConnectionTCT();
                OdbcCommand odbcCommand = new OdbcCommand("SELECT ADMIN.\"TMP$MR_SEQ\".NEXTVAL AS ID FROM SYS.DUAL", this.connTongCT);
                OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
                if (odbcDataReader.Read())
                {
                    result = odbcDataReader["ID"].ToString();
                }
                odbcDataReader.Close();
                this.CloseConnectionTCT();
            }
            catch
            {
            }
            return result;
        }

        protected string getRST_ID(string code)
        {
            string result = "";
            try
            {
                OpenConnectionTCT();
                OdbcCommand odbcCommand = new OdbcCommand("SELECT ID FROM READING_STATUS WHERE STATUS_CODE='" + code + "'", this.connTongCT);
                OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
                if (odbcDataReader.Read())
                {
                    result = odbcDataReader["ID"].ToString().Trim();
                }
                odbcDataReader.Close();
                this.CloseConnectionTCT();
            }
            catch
            {
            }
            return result;
        }

    }
}
