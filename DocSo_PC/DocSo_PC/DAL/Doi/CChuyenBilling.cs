﻿using System;
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
        public OdbcConnection connTongCT = new OdbcConnection();

        public CChuyenBilling()
        {
            //try
            //{
            //    connTongCT = new OdbcConnection(@"Dsn=Oracle7;uid=TH_HANDHELD;pwd=TH_HANDHELD;server=center");
            //    connTongCT.Open();
            //    connTongCT.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public void OpenConnectionTCT()
        {
            try
            {
                connTongCT = new OdbcConnection(@"Dsn=Oracle7;uid=TH_HANDHELD;pwd=TH_HANDHELD;server=center");
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

        public bool insertBilling(DataRow row)
        {
            try
            {
                string DanhBo = row["DanhBa"].ToString().Trim();
                string CodeMoi = row["CodeMoi"].ToString().Trim();
                string CSC = row["CSCu"].ToString().Trim();
                string CSM = row["CSMoi"].ToString().Trim();
                string TieuThuMoi = row["TieuThuMoi"].ToString().Trim();
                string MLT = row["MLT2"].ToString().Trim();
                string May = MLT.Substring(2, 2);
                string STT = MLT.Substring(4, 3);
                string NgayDoc = row["DenNgay"].ToString().Trim();
                //double ID = Convert.ToDouble(this.getID());
                //string rST_ID = this.getRST_ID(CodeMoi);

                string cmdText = "INSERT INTO ADMIN.\"TMP$MR\" (ID, BRANCH_CODE, \"YEAR\", PERIOD, BC_CODE, CUSTOMER_NO, MR_STATUS, THIS_READING, CONSUMPTION, DATE_READING, CREATED_ON, CREATED_BY, BOOK_NO, OIB, EMP_ID, RST_ID) VALUES ("
                            + "(SELECT ADMIN.\"TMP$MR_SEQ\".NEXTVAL AS ID FROM SYS.DUAL),'TH'," + row["Nam"].ToString().Trim() + "," + row["Ky"].ToString().Trim() + ",'" + row["Dot"].ToString().Trim() + "','" + DanhBo + "','" + CodeMoi + "'," + CSM + "," + TieuThuMoi + ",'" + NgayDoc + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','TH_HANDHELD','" + May + "','" + STT + "','100000002',(SELECT ID FROM READING_STATUS WHERE STATUS_CODE='" + CodeMoi + "'))";
                if (CodeMoi.Length > 0 && (CodeMoi.Substring(0, 1) == "5" || CodeMoi.Substring(0, 1) == "8" || CodeMoi.Substring(0, 1) == "M"))
                {
                    cmdText = "INSERT INTO ADMIN.\"TMP$MR\" (ID, BRANCH_CODE, \"YEAR\", PERIOD, BC_CODE, CUSTOMER_NO, MR_STATUS, LAST_READING, THIS_READING, CONSUMPTION, DATE_READING, CREATED_ON, CREATED_BY, BOOK_NO, OIB, EMP_ID,RST_ID) VALUES ("
                            + "(SELECT ADMIN.\"TMP$MR_SEQ\".NEXTVAL AS ID FROM SYS.DUAL),'TH'," + row["Nam"].ToString().Trim() + "," + row["Ky"].ToString().Trim() + ",'" + row["Dot"].ToString().Trim() + "','" + DanhBo + "','" + CodeMoi + "'," + CSC + "," + CSM + "," + TieuThuMoi + ",'" + NgayDoc + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','TH_HANDHELD','" + May + "','" + STT + "','100000002',(SELECT ID FROM READING_STATUS WHERE STATUS_CODE='" + CodeMoi + "'))";
                }
                this.OpenConnectionTCT();
                OdbcCommand odbcCommand = new OdbcCommand(cmdText, this.connTongCT);
                int result = odbcCommand.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string test()
        {
            return getID();
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
