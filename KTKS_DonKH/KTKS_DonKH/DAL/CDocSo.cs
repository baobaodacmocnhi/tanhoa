using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL
{
    class CDocSo
    {
        private dbDocSoDataContext db = new dbDocSoDataContext();

        public TB_DULIEUKHACHHANG getDLKH(string DanhBo)
        {
            try
            {
                return db.TB_DULIEUKHACHHANGs.SingleOrDefault(itemDLKH => itemDLKH.DANHBO == DanhBo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CheckExist(string DanhBo)
        {
            try
            {
                return db.TB_DULIEUKHACHHANGs.Any(itemDLKH => itemDLKH.DANHBO == DanhBo);
            }
            catch (Exception)
            {
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
                //db = new DB_CAPNUOCTANHOADataContext();
                return true;
            }
            catch (Exception)
            {
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

        public string GetDinhMuc(string DanhBo)
        {
            return db.TB_DULIEUKHACHHANGs.SingleOrDefault(item => item.DANHBO == DanhBo).DINHMUC;
        }

        public void Refresh()
        {
            db = new dbDocSoDataContext();
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

        //protected static string _connectionString;
        //protected SqlConnection connection;
        //protected SqlCommand command;
        //protected SqlTransaction transaction;

        //public CDuLieuKhachHang()
        //{
        //    try
        //    {
        //        _connectionString = "Data Source=192.168.90.8\\KD;Initial Catalog=CAPNUOCTANHOA;Persist Security Info=True;User ID=sa;Password=123@tanhoa";
        //        connection = new SqlConnection(_connectionString);
        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        //public void Connect()
        //{
        //    if (connection.State == ConnectionState.Closed)
        //        connection.Open();
        //}

        //public void Disconnect()
        //{
        //    if (connection.State == ConnectionState.Open)
        //        connection.Close();
        //}

        //public void SqlBeginTransaction()
        //{
        //    try
        //    {
        //        Connect();
        //        transaction = connection.BeginTransaction();
        //    }
        //    catch (Exception) { }
        //}

        //public void SqlCommitTransaction()
        //{
        //    try
        //    {
        //        transaction.Commit();
        //        transaction.Dispose();
        //        Disconnect();
        //    }
        //    catch (Exception) { }
        //}

        //public void SqlRollbackTransaction()
        //{
        //    transaction.Rollback();
        //    transaction.Dispose();
        //    try
        //    {
        //        Disconnect();
        //    }
        //    catch (Exception) { }
        //}

        //public bool ExecuteNonQuery_Transaction(string sql)
        //{
        //    try
        //    {
        //        if (connection.State == ConnectionState.Closed)
        //            connection.Open();
        //        command = new SqlCommand(sql, connection);
        //        //command.Transaction = transaction;
        //        if (command.ExecuteNonQuery() == 0)
        //            return false;
        //        else
        //            return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        public bool LinQ_ExecuteNonQuery(string sql)
        {
            if (db.ExecuteCommand(sql) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Lấy Tên Phường & Quận của Danh Bộ
        /// </summary>
        /// <param name="MaQuan"></param>
        /// <param name="MaPhuong"></param>
        /// <returns></returns>
        public string getPhuongQuanByID(string MaQuan, string MaPhuong)
        {
            try
            {
                string Phuong = ", P." + db.PHUONGs.Single(itemPhuong => itemPhuong.MAQUAN == int.Parse(MaQuan) && itemPhuong.MAPHUONG == MaPhuong).TENPHUONG;
                string Quan = ", Q." + db.QUANs.Single(itemQuan => itemQuan.MAQUAN == int.Parse(MaQuan)).TENQUAN;
                return Phuong + Quan;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void getTTDHNbyID(string DanhBo, out string Hieu, out string Co, out string SoThan)
        {
            try
            {
                TB_DULIEUKHACHHANG ttkhachhang = db.TB_DULIEUKHACHHANGs.SingleOrDefault(itemttkhachhang => itemttkhachhang.DANHBO == DanhBo);
                Hieu = ttkhachhang.HIEUDH;
                Co = ttkhachhang.CODH;
                SoThan = ttkhachhang.SOTHANDH;
            }
            catch (Exception)
            {
                Hieu = "";
                Co = "";
                SoThan = "";
            }

        }

        public List<QUAN> LoadDSQuan()
        {
            return db.QUANs.ToList();
        }

        public List<PHUONG> LoadDSPhuongbyQuan(int MaQuan)
        {
            return db.PHUONGs.Where(item => item.MAQUAN == MaQuan).ToList();
        }

        public string getTenQuanByMaQuan(int MaQuan)
        {
            return db.QUANs.SingleOrDefault(item => item.MAQUAN == MaQuan).TENQUAN;
        }

        public string getTenPhuongByMaQuanPhuong(int MaQuan, string MaPhuong)
        {
            return db.PHUONGs.SingleOrDefault(item => item.MAQUAN == MaQuan && item.MAPHUONG == MaPhuong).TENPHUONG;
        }

        public string getDot(string DanhBo)
        {
            return db.TB_DULIEUKHACHHANGs.SingleOrDefault(item => item.DANHBO == DanhBo).LOTRINH.Substring(0, 2);
        }


    }
}
