using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

namespace QuaySoMayMan_Web
{
    public class CDAL
    {
        string strConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + AppDomain.CurrentDomain.BaseDirectory + "\\quaysomayman.accdb;Persist Security Info=True";
        OleDbConnection oleConnection;
        CConnection _cDAL = new CConnection("Data Source=server9;Initial Catalog=DH_CODONG;Persist Security Info=True;User ID=sa;Password=db9@tanhoa");

        public CDAL()
        {
            oleConnection = new OleDbConnection(strConnection);
        }

        //public bool ExecuteNonQuery(string sql)
        //{
        //    oleConnection.Open();
        //    OleDbCommand oldCommand = new OleDbCommand(sql, oleConnection);
        //    int rowsAffected = oldCommand.ExecuteNonQuery();
        //    oleConnection.Close();
        //    if (rowsAffected >= 1)
        //        return true;
        //    else
        //        return false;
        //}

        //public bool update_Quay(string STT)
        //{
        //    return ExecuteNonQuery("update KhachMoi set Quay=1 where STT='" + STT + "'");
        //}

        //public bool update_Quay()
        //{
        //    return ExecuteNonQuery("update KhachMoi set Quay=0");
        //}

        //public DataTable get_KhachMoi(string STT)
        //{
        //    OleDbDataAdapter oldAdapter = new OleDbDataAdapter("select * from KhachMoi where STT='" + STT + "'", oleConnection);
        //    oleConnection.Open();
        //    DataTable dt = new DataTable();
        //    oldAdapter.Fill(dt);
        //    oleConnection.Close();
        //    return dt;
        //}

        //public DataTable getDS_KhachMoi()
        //{
        //    OleDbDataAdapter oldAdapter = new OleDbDataAdapter("select * from KhachMoi", oleConnection);
        //    oleConnection.Open();
        //    DataTable dt = new DataTable();
        //    oldAdapter.Fill(dt);
        //    oleConnection.Close();
        //    return dt;
        //}

        //public DataTable getDS_KhachMoi_ChuaQuay()
        //{
        //    OleDbDataAdapter oldAdapter = new OleDbDataAdapter("select * from KhachMoi where Quay=0", oleConnection);
        //    oleConnection.Open();
        //    DataTable dt = new DataTable();
        //    oldAdapter.Fill(dt);
        //    oleConnection.Close();
        //    return dt;
        //}

        //public bool checkExist(string STT)
        //{
        //    OleDbCommand oldCommand = new OleDbCommand("select count(*) from KhachMoi where STT='" + STT + "'", oleConnection);
        //    oleConnection.Open();
        //    object result = oldCommand.ExecuteScalar();
        //    oleConnection.Close();
        //    if ((int)result >= 1)
        //        return true;
        //    else
        //        return false;
        //}

        //public bool checkExist_Quay(string STT)
        //{
        //    OleDbCommand oldCommand = new OleDbCommand("select count(*) from KhachMoi where STT='" + STT + "' and Quay=1", oleConnection);
        //    oleConnection.Open();
        //    object result = oldCommand.ExecuteScalar();
        //    oleConnection.Close();
        //    if ((int)result >= 1)
        //        return true;
        //    else
        //        return false;
        //}

        public DataTable get_KhachMoi(string STT)
        {
            return _cDAL.ExecuteQuery_DataTable("select * from QuaySo where STT='" + STT + "'");
        }

        public bool update_Quay(string STT)
        {
            return _cDAL.ExecuteNonQuery("update QuaySo set Quay=1 where STT='" + STT + "'");
        }
    }
}