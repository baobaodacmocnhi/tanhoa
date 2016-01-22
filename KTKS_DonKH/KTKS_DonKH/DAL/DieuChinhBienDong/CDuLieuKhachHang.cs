using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;
using System.Data.SqlClient;
using System.Data;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CDuLieuKhachHang
    {
        private DB_CAPNUOCTANHOADataContext db = new DB_CAPNUOCTANHOADataContext();

        public TB_DULIEUKHACHHANG getDLKH(string DanhBo)
        {
            try
            {
                return db.TB_DULIEUKHACHHANGs.SingleOrDefault(itemDLKH => itemDLKH.DANHBO == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool CheckExist(string DanhBo)
        {
            try
            {
                return db.TB_DULIEUKHACHHANGs.Any(itemDLKH => itemDLKH.DANHBO == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaDLKH(TB_DULIEUKHACHHANG dulieukhachhang)
        {
            try
            {
                dulieukhachhang.MODIFYDATE = DateTime.Now;
                dulieukhachhang.MODIFYBY = CTaiKhoan.HoTen;
                db.SubmitChanges();
                db = new DB_CAPNUOCTANHOADataContext();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ThemGhiChu(TB_GHICHU ghichu)
        {
            try
            {
                ghichu.CREATEDATE = DateTime.Now;
                ghichu.CREATEBY = CTaiKhoan.HoTen;
                db.TB_GHICHUs.InsertOnSubmit(ghichu);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void beginTransaction()
        {
            if (db.Connection.State == System.Data.ConnectionState.Closed)
                db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
        }

        public void commitTransaction()
        {
            db.Transaction.Commit();
        }

        public void rollback()
        {
            db.Transaction.Rollback();
        }

        public bool Sua(string sql)
        {
            if (db.ExecuteCommand(sql) > 0)
            {
                //db.SubmitChanges();
                return true;
            }
            else
                return false;
        }

        protected static string _connectionString;
        protected SqlConnection connection;
        protected SqlCommand command;
        protected SqlTransaction transaction;

        public CDuLieuKhachHang()
        {
            try
            {
                _connectionString = "Data Source=192.168.90.8\\KD;Initial Catalog=CAPNUOCTANHOA;Persist Security Info=True;User ID=sa;Password=123@tanhoa";
                connection = new SqlConnection(_connectionString);
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void SqlBeginTransaction()
        {
            try
            {
                Connect();
                transaction = connection.BeginTransaction();
            }
            catch (Exception) { }
        }

        public void SqlCommitTransaction()
        {
            try
            {
                transaction.Commit();
                transaction.Dispose();
                Disconnect();
            }
            catch (Exception) { }
        }

        public void SqlRollbackTransaction()
        {
            transaction.Rollback();
            transaction.Dispose();
            try
            {
                Disconnect();
            }
            catch (Exception) { }
        }

        public bool ExecuteNonQuery_Transaction(string sql)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command = new SqlCommand(sql, connection);
                //command.Transaction = transaction;
                if (command.ExecuteNonQuery() == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
