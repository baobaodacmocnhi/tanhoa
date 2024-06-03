using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;
using System.Data.SqlClient;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL
{
    class CTTKH
    {
        private dbTrungTamKhachHangDataContext db = new dbTrungTamKhachHangDataContext();

        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn

        public CTTKH()
        {
            try
            {
                _connectionString = KTKS_DonKH.Properties.Settings.Default.TRUNGTAMKHACHHANGConnectionString;
                connection = new SqlConnection(_connectionString);
            }
            catch (Exception)
            {
            }

        }

        public void Connect()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        public void Disconnect()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public void Refresh()
        {
            db = new dbTrungTamKhachHangDataContext();
        }

        public object ExecuteQuery_ReturnOneValue(string sql)
        {
            try
            {
                Connect();
                command = new SqlCommand(sql, connection);
                object result = command.ExecuteScalar();
                Disconnect();
                return result;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        public DataTable ExecuteQuery_DataTable(string sql)
        {
            this.Connect();
            DataTable dt = new DataTable();
            command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            try
            {
                adapter.Fill(dt);
            }
            catch (SqlException e)
            {
                throw e;
            }
            this.Disconnect();
            return dt;
        }

        public bool them(SuCoNgungCungCapNuoc en)
        {
            try
            {
                if (db.SuCoNgungCungCapNuocs.Count() > 0)
                    en.ID = db.SuCoNgungCungCapNuocs.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.SuCoNgungCungCapNuocs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool sua(SuCoNgungCungCapNuoc en)
        {
            try
            {
                en.ModifyBy = CTaiKhoan.MaUser;
                en.ModifyDate = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool xoa(SuCoNgungCungCapNuoc en)
        {
            try
            {
                db.SuCoNgungCungCapNuocs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public SuCoNgungCungCapNuoc get(int ID)
        {
            return db.SuCoNgungCungCapNuocs.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS()
        {
            return ExecuteQuery_DataTable("select * from SuCoNgungCungCapNuoc order by CreateDate desc");
        }

        public DataTable getDS_Zalo(string DanhBo)
        {
            return ExecuteQuery_DataTable("select MLT=ttkh.LOTRINH,b.DanhBo,ttkh.HOTEN,DiaChi=ttkh.SONHA+' '+ttkh.TENDUONG,HoTenZalo=a.Name,Avatar=a.Avatar"
+ " from Zalo_QuanTam a,Zalo_DangKy b,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh"
+ " where a.IDZalo=b.IDZalo and a.Follow=1 and b.DanhBo=ttkh.DANHBO and b.DanhBo='" + DanhBo + "'");
        }

        public bool checkExists_HDDT(string DanhBo)
        {
            return bool.Parse(ExecuteQuery_ReturnOneValue("if exists (select * from Zalo_EContract_ChiTiet where DanhBo='" + DanhBo + "') select 'true'"
                + " else if exists (select * from Zalo_EContract_ChiTiet a,[TANHOA_WATER].[dbo].[KH_HOSOKHACHHANG] b where a.SHS=b.SHS and b.DHN_SODANHBO='" + DanhBo + "') select 'true'"
                + " else select 'false'").ToString());
        }

    }
}
