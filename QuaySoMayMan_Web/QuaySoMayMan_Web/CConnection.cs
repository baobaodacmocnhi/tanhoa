using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace QuaySoMayMan_Web
{
    public class CConnection
    {
        private string connectionString;          // Chuỗi kết nối
        private SqlConnection connection;         // Đối tượng kết nối
        private SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        private SqlCommand command;               // Đối tượng command thực thi truy vấn
        private SqlTransaction transaction;       // Đối tượng transaction

        public CConnection(String connectionString)
        {
            try
            {
                this.connectionString = connectionString;
                connection = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
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

        public void BeginTransaction()
        {
            try
            {
                Connect();
                transaction = connection.BeginTransaction(IsolationLevel.Snapshot);
            }
            catch (Exception ex) { throw ex; }
        }

        public void CommitTransaction()
        {
            try
            {
                if (transaction != null)
                {
                    transaction.Commit();
                    transaction.Dispose();
                    Disconnect();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void RollbackTransaction()
        {
            try
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    transaction.Dispose();

                    Disconnect();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                Connect();
                command = new SqlCommand(sql, connection);
                int rowsAffected = command.ExecuteNonQuery();
                Disconnect();
                if (rowsAffected >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        public bool ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                Connect();
                command.Connection = connection;
                int rowsAffected = command.ExecuteNonQuery();
                Disconnect();
                if (rowsAffected >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
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

        public DataSet ExecuteQuery_DataSet(string sql)
        {
            try
            {
                Connect();
                DataSet dataset = new DataSet();
                command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                try
                {
                    adapter.Fill(dataset);
                }
                catch (SqlException e)
                {
                    throw e;
                }
                Disconnect();
                return dataset;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        public DataTable ExecuteQuery_DataTable(string sql)
        {
            try
            {
                Connect();
                DataTable dt = new DataTable();
                command = new SqlCommand(sql, connection);
                command.CommandTimeout = 60 * 5;
                adapter = new SqlDataAdapter(command);
                try
                {
                    adapter.Fill(dt);
                }
                catch (SqlException e)
                {
                    throw e;
                }
                Disconnect();
                return dt;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        public bool ExecuteNonQuery_Transaction(string sql)
        {
            try
            {
                command = new SqlCommand(sql, connection, transaction);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object ExecuteQuery_ReturnOneValue_Transaction(string sql)
        {
            try
            {
                command = new SqlCommand(sql, connection, transaction);
                object result = command.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExecuteQuery_DataTable_Transaction(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                command = new SqlCommand(sql, connection, transaction);
                adapter = new SqlDataAdapter(command);
                try
                {
                    adapter.Fill(dt);
                }
                catch (SqlException e)
                {
                    throw e;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}