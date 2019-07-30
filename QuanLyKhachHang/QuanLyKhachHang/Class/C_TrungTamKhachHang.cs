using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyKhachHang.DataBase;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKhachHang.Class
{
    public class C_TrungTamKhachHang
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("File");
        static KinhDoanhDataContext db = new KinhDoanhDataContext();

      

        public static int ExecuteCommand_(string sql)
        {
            KinhDoanhDataContext db = new KinhDoanhDataContext();
            int result = 0;
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception )
            {


            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public static DataTable getDataTable(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            return table;
        }


        public static TTKH_TiepNhan finBySoHoSo(string id)
        {
            try
            {
                var query = from q in db.TTKH_TiepNhans where q.SoHoSo == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static void Insert(TTKH_TiepNhan tb)
        {
            try
            {
                db.TTKH_TiepNhans.InsertOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static void Delete(TTKH_TiepNhan tb)
        {
            try
            {
                db.TTKH_TiepNhans.DeleteOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }


        public static bool Update()
        {
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }
        public static void ExecuteCommand(string sql)
        {
            int result = 0;
            KinhDoanhDataContext db = new KinhDoanhDataContext();
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
        }

        static string getMoth()
        {
            string s;
            if (DateTime.Now.Month < 10)
                s = "0" + DateTime.Now.Month;
            else
                s = DateTime.Now.Month + "";
            return s;

        }

        public static string IdentityBienNhan()
        {
            string loaihs = "CT";
            string year = DateTime.Now.Year.ToString().Substring(2) + getMoth();
            string kytumacdinh = year + loaihs;


            string id = kytumacdinh + "0001";
            try
            {

                String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();
                KinhDoanhDataContext db = new KinhDoanhDataContext();
                db.Connection.Open();
                string sql = " SELECT MAX(SoHoSo) as 'SoHoSo' FROM TTKH_TiepNhan    ORDER BY SoHoSo DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    if (table.Rows[0][0].ToString().Trim().Substring(0, 2).Equals(year.Substring(0, 2)))
                    {
                        int number = 1;

                        id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000", number) + "";
                    }
                    else
                    {
                        id = obj.ID(year + loaihs, year + loaihs + "0000", "0000") + "";
                    }
                }
                else
                {
                    id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000") + "";
                }

                db.Connection.Close();

            }
            catch (Exception)
            {

            }

            return id;

        }


        public static DataTable getKiemTraXM(string danhbo)
        {
            DataTable dt = new DataTable();
            KinhDoanhDataContext db = new KinhDoanhDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            try
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("spDieuChinh", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter _ky = cmd.Parameters.Add("@DanhBo", SqlDbType.VarChar);
                _ky.Direction = ParameterDirection.Input;
                _ky.Value = danhbo; 
                
                dt.Load(cmd.ExecuteReader());
               dt.DefaultView.Sort = "NgayXuLy DESC";
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

    }
}