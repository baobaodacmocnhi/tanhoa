using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyKhachHang.DataBase;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKhachHang.Class
{
    public class C_KyThuat
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("File");
        static KyThuatDataContext db = new KyThuatDataContext();

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


        public static KT_DongNuoc finById(int id)
        {
            try
            {
                var query = from q in db.KT_DongNuocs where q.ID == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static DongHo finByToDo(string id)
        {
            try
            {
                var query = from q in db.DongHos where q.DBDONGHONUOC == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static KT_BaoBe finByIdB(int id)
        {
            try
            {
                var query = from q in db.KT_BaoBes where q.ID == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static KT_Van finByIdV(int id)
        {
            try
            {
                var query = from q in db.KT_Vans where q.ID == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static void Insert(KT_DongNuoc tb)
        {
            try
            {
                db.KT_DongNuocs.InsertOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static void Delete(KT_DongNuoc tb)
        {
            try
            {
                db.KT_DongNuocs.DeleteOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public static void Insert(KT_BaoBe tb)
        {
            try
            {
                db.KT_BaoBes.InsertOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static void Insert(KT_Van tb)
        {
            try
            {
                db.KT_Vans.InsertOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static void Delete(KT_Van tb)
        {
            try
            {
                db.KT_Vans.DeleteOnSubmit(tb);
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
            KyThuatDataContext db = new KyThuatDataContext();
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

        public static int ExecuteCommand_(string sql)
        {
            int result = 0;
            KyThuatDataContext db = new KyThuatDataContext();
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
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
            return 0;
        }

        public static DataTable ExecuteStoredProcedure(string storedNam )
        {
            KyThuatDataContext db = new KyThuatDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            DataTable dt = new DataTable();
            try
            {

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(storedNam, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = cmd;

                adapter.Fill(dt);
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