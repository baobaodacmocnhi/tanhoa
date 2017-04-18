using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.CallCenter
{
    class CGanMoi
    {
        public static DataTable getDataTable(string sql)
        {
            DataTable table = new DataTable();
            dbGanMoiDataContext db = new dbGanMoiDataContext();
            try
            {
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                db.Connection.Close();
            }
            return table;
        }

        public static DataTable getDataTable(string sql, int FirstRow, int pageSize)
        {
            dbGanMoiDataContext db = new dbGanMoiDataContext();
            try
            {
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
                db.Connection.Close();
                return dataset.Tables[0];
            }
            catch (Exception ex)
            {
            }
            finally
            {
                db.Connection.Close();
            }
            return null;
        }

        public static DON_KHACHHANG searchTimKiemDon(string sohoso)
        {
            try
            {
                dbGanMoiDataContext db = new dbGanMoiDataContext();
                var data = from don in db.DON_KHACHHANGs where don.SHS == sohoso select don;
                DON_KHACHHANG donkh = data.SingleOrDefault();
                //if (donkh.HOSOCHA != null)
                //{
                //    var hosocha = from don in db.DON_KHACHHANGs where don.SHS == donkh.HOSOCHA select don;
                //    return hosocha.SingleOrDefault();
                //}
                return donkh;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public static BIENNHANDON searchBienNhan(string sohoso)
        {
            try
            {
                dbGanMoiDataContext db = new dbGanMoiDataContext();
                var data = from don in db.BIENNHANDONs where don.SHS == sohoso select don;
                BIENNHANDON donkh = data.SingleOrDefault();
                //if (donkh.HOSOCHA != null)
                //{
                //    var hosocha = from don in db.DON_KHACHHANGs where don.SHS == donkh.HOSOCHA select don;
                //    return hosocha.SingleOrDefault();
                //}
                return donkh;
            }
            catch (Exception ex)
            {
            }
            return null;
        }


        public static DataTable TimBienNhan(string shs, string hoten, string diachi, int FirstRow, int pageSize, string dienthoai)
        {
            string sql = "SELECT  biennhan.SHS, biennhan.HOTEN,( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN) as 'DIACHI', DIENTHOAI ,CONVERT(VARCHAR(20),biennhan.NGAYNHAN,103) AS 'NGAYNHAN',lhs.TENLOAI as 'LOAIHS' ";
            sql += " FROM QUAN q,PHUONG p,BIENNHANDON biennhan, LOAI_HOSO lhs ";
            sql += " WHERE biennhan.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN  AND biennhan.PHUONG=p.MAPHUONG AND lhs.MALOAI=biennhan.LOAIDON";
            if (!"".Equals(shs))
            {
                sql += " AND biennhan.SHS = '" + shs + "'";
            }
            if (!"".Equals(hoten))
            {
                sql += " AND HOTEN LIKE N'%" + hoten + "%'";
            }
            if (!"".Equals(dienthoai))
            {
                sql += " AND DIENTHOAI LIKE N'%" + dienthoai + "%'";
            }
            if (!"".Equals(diachi))
            {
                sql += " AND  replace(( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN),' ','')  LIKE N'%" + diachi.Replace(" ", "") + "%'";
            }
            dbGanMoiDataContext db = new dbGanMoiDataContext();
            db.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }

        public static int TotalRecord(string shs, string hoten, string diachi, string dienthoai)
        {
            string sql = "SELECT COUNT(*) ";
            sql += " FROM QUAN q,PHUONG p,BIENNHANDON biennhan, LOAI_HOSO lhs ";
            sql += " WHERE biennhan.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN  AND biennhan.PHUONG=p.MAPHUONG AND lhs.MALOAI=biennhan.LOAIDON";
            if (!"".Equals(shs))
            {
                sql += " AND biennhan.SHS = '" + shs + "'";
            }
            if (!"".Equals(hoten))
            {
                sql += " AND HOTEN LIKE N'%" + hoten + "%'";
            }
            if (!"".Equals(dienthoai))
            {
                sql += " AND DIENTHOAI LIKE N'%" + dienthoai + "%'";
            }
            if (!"".Equals(diachi))
            {
                sql += " AND  replace(( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN),' ','')  LIKE N'%" + diachi.Replace(" ", "") + "%'";
            }
            dbGanMoiDataContext db = new dbGanMoiDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }


        public static DataTable TimDonKH(string shs, string hoten, string diachi, int FirstRow, int pageSize, string dienthoai)
        {
            string sql = "SELECT  biennhan.SHS, biennhan.HOTEN,( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN) as 'DIACHI',DIENTHOAI ,CONVERT(VARCHAR(20),biennhan.NGAYNHAN,103) AS 'NGAYNHAN',lhs.TENLOAI as 'LOAIHS' ";
            sql += " FROM QUAN q,PHUONG p,DON_KHACHHANG biennhan, LOAI_HOSO lhs ";
            sql += " WHERE LEN(biennhan.SHS)<=10 AND  biennhan.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN  AND biennhan.PHUONG=p.MAPHUONG AND lhs.MALOAI=biennhan.LOAIHOSO";
            if (!"".Equals(shs))
            {
                //  sql += " AND biennhan.SHS = '" + shs + "'";
                sql += " AND (biennhan.SHS = '" + shs + "' OR biennhan.HOSOCHA = '" + shs + "' )";
            }
            if (!"".Equals(hoten))
            {
                sql += " AND HOTEN LIKE N'%" + hoten + "%'";
            }
            if (!"".Equals(dienthoai))
            {
                sql += " AND DIENTHOAI LIKE N'%" + dienthoai + "%'";
            }
            if (!"".Equals(diachi))
            {
                sql += " AND  replace(( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN),' ','')  LIKE N'%" + diachi.Replace(" ", "") + "%'";
            }
            return getDataTable(sql);
        }

        public static DataTable TimDonKH_DOTTHICONG(string shs)
        {
            string sql = "SELECT  biennhan.SHS, biennhan.HOTEN,( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN) as 'DIACHI',DIENTHOAI ,CONVERT(VARCHAR(20),biennhan.NGAYNHAN,103) AS 'NGAYNHAN',lhs.TENLOAI as 'LOAIHS' ";
            sql += " FROM QUAN q,PHUONG p,DON_KHACHHANG biennhan, LOAI_HOSO lhs , KH_HOSOKHACHHANG hskh ";
            sql += " WHERE biennhan.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN  AND biennhan.PHUONG=p.MAPHUONG AND lhs.MALOAI=biennhan.LOAIHOSO AND hskh.SHS=biennhan.SHS ";
            sql += " AND hskh.MADOTTC=N'" + shs + "' ";
            return getDataTable(sql);
        }

        public static int TotalTimDonKH(string shs, string hoten, string diachi, string dienthoai)
        {
            string sql = "SELECT COUNT(*) ";
            sql += " FROM QUAN q,PHUONG p,DON_KHACHHANG biennhan, LOAI_HOSO lhs ";
            sql += " WHERE biennhan.QUAN = q.MAQUAN AND q.MAQUAN=p.MAQUAN  AND biennhan.PHUONG=p.MAPHUONG AND lhs.MALOAI=biennhan.LOAIHOSO";
            if (!"".Equals(shs))
            {
                sql += " AND biennhan.SHS = '" + shs + "'";
            }
            if (!"".Equals(hoten))
            {
                sql += " AND HOTEN LIKE N'%" + hoten + "%'";
            }
            if (!"".Equals(dienthoai))
            {
                sql += " AND DIENTHOAI LIKE N'%" + dienthoai + "%'";
            }
            if (!"".Equals(diachi))
            {
                sql += " AND  replace(( SONHA +'  '+DUONG+',  P.'+ p.TENPHUONG+',  Q.'+q.TENQUAN),' ','')  LIKE N'%" + diachi.Replace(" ", "") + "%'";
            }
            dbGanMoiDataContext db = new dbGanMoiDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }

        static dbGanMoiDataContext db = new dbGanMoiDataContext();
        public static TOTHIETKE findBySHS(string shs)
        {
            var ttk = from query in db.TOTHIETKEs where query.SHS == shs select query;
            return ttk.SingleOrDefault();
        }
        public static USER findByUserName(string username)
        {
           
            var data = from user in db.USERs where user.USERNAME == username select user;
            USER us = data.SingleOrDefault();
            return us;
        }
        public static BG_KHOILUONGXDCB findBySHSXDCB(string shs)
        {
            try
            {
                var query = from kt in db.BG_KHOILUONGXDCBs where kt.SHS == shs select kt;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public static KH_HOSOKHACHHANG findBySHSKH(string shs)
        {

            var obj = from dd in db.KH_HOSOKHACHHANGs where dd.SHS == shs select dd;
            return obj.SingleOrDefault();
        }
        public static KH_XINPHEPDAODUONG finbyMaDot(string madot)
        {
            var obj = from dd in db.KH_XINPHEPDAODUONGs where dd.MADOT == madot select dd;
            return obj.SingleOrDefault();
        }
        public static KH_DOTTHICONG findByMadot(string madot)
        {
            try
            {
                var query = from dottc in db.KH_DOTTHICONGs where dottc.MADOTTC == madot select dottc;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public static KH_DONVITHICONG findDVTCbyID(int id)
        {
            var list = from query in db.KH_DONVITHICONGs where query.ID == id select query;
            return list.SingleOrDefault();
        }

        public static string rTX = "";
        public static bool dontaixet(string sohoso)
        {
            var data = from don in db.TMP_TAIXETs where don.MAHOSO == sohoso select don;
            if (data.SingleOrDefault() != null)
            {
                rTX = data.SingleOrDefault().GHICHUTR;
                return true;

            }
            return false;

        }

    }
}