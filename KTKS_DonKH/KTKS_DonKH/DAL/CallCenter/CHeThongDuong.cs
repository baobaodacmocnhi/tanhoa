using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace KTKS_DonKH.DAL.CallCenter
{
    class CHeThongDuong
    {
        public static List<TENDUONG> getList()
        {

            dbGanMoiDataContext db = new dbGanMoiDataContext();
            var query = from duong in db.TENDUONGs select duong;
            return query.ToList();
        }
        public static DataTable getQuanPhuong(string tenduong)
        {

            dbGanMoiDataContext db = new dbGanMoiDataContext();
            db.Connection.Open();
            string sql = " SELECT DISTINCT p.TENPHUONG, q.TENQUAN ";
            sql += "  FROM TENDUONG d, PHUONG p, QUAN q ";
            sql += " WHERE d.MAPHUONG = p.MAPHUONG AND d.MAQUAN=q.MAQUAN AND q.MAQUAN =p.MAQUAN";
            sql += " AND replace(d.DUONG,' ','')=N'" + tenduong.Replace(" ", "") + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];
        }
        public static ArrayList getPhuong()
        {
            dbDHNDataContext db = new dbDHNDataContext();
            var data = from phuong in db.PHUONGs select phuong;
            ArrayList list = new ArrayList();
            list.Add(new AddValueCombox("  Chọn Phường  ", ""));
            foreach (var a in data)
            {
                list.Add(new AddValueCombox(a.TENPHUONG, a.MAPHUONG));
            }
            return list;
        }
        public static ArrayList getQuan()
        {
            dbDHNDataContext db = new dbDHNDataContext();
            var data = from quan in db.QUANs select quan;
            ArrayList list = new ArrayList();
            list.Add(new AddValueCombox("  Chọn Quận  ", ""));
            foreach (var a in data)
            {
                list.Add(new AddValueCombox(a.TENQUAN, a.MAQUAN + ""));
            }
            return list;
        }
        public static DataTable getListDuong(string tenduong, string maphuong, string maquan, int FirstRow, int pageSize)
        {
            dbGanMoiDataContext db = new dbGanMoiDataContext();
            db.Connection.Open();
            string sql = "  SELECT STT, DUONG, TENPHUONG, TENQUAN ";
            sql += " FROM QUAN q, PHUONG p, TENDUONG d ";
            sql += " WHERE d.MAPHUONG=p.MAPHUONG AND p.MAQUAN=q.MAQUAN  AND d.MAQUAN=q.MAQUAN";
            if ("".Equals(tenduong) == false)
            {
                sql += " AND DUONG LIKE N'%" + tenduong + "%'";
            }
            if ("".Equals(maphuong) == false)
            {
                sql += " AND p.TENPHUONG LIKE N'%" + maphuong + "%'";

            }
            if ("".Equals(maquan) == false)
            {
                sql += " AND q.MAQUAN = '" + maquan.Trim() + "'";
            }
            sql += " ORDER BY TENPHUONG ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, FirstRow, pageSize, "TABLE");
            db.Connection.Close();
            return dataset.Tables[0];

        }

        public static int TotalListDuong(string tenduong, string maphuong, string maquan)
        {
            dbGanMoiDataContext db = new dbGanMoiDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            conn.Open();
            string sql = "  SELECT COUNT(*) ";
            sql += " FROM QUAN q, PHUONG p, TENDUONG d ";
            sql += " WHERE d.MAPHUONG=p.MAPHUONG AND p.MAQUAN=q.MAQUAN  AND d.MAQUAN=q.MAQUAN";
            if ("".Equals(tenduong) == false)
            {
                sql += " AND DUONG LIKE N'%" + tenduong + "%'";
            }
            if ("".Equals(maphuong) == false)
            {
                sql += " AND p.TENPHUONG LIKE N'%" + maphuong + "%'";
            }
            if ("".Equals(maquan) == false)
            {
                sql += " AND q.MAQUAN ='" + maquan.Trim() + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
        public static TENDUONG findbyDuong(string tenduong, string maphuong, int maquan)
        {
            dbGanMoiDataContext db = new dbGanMoiDataContext();
            var query = from duong in db.TENDUONGs where duong.DUONG == tenduong && duong.MAPHUONG == maphuong && duong.MAQUAN == maquan select duong;
            return query.SingleOrDefault();
        }
        public static bool InsertDuong(TENDUONG duong)
        {
            try
            {
                dbGanMoiDataContext db = new dbGanMoiDataContext();
                db.TENDUONGs.InsertOnSubmit(duong);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        public static bool UpdateDuong(int id, string tenduong, string maphuong, int maquan)
        {
            dbGanMoiDataContext db = new dbGanMoiDataContext();
            var query = from duong in db.TENDUONGs where duong.STT == id select duong;
            TENDUONG tDuong = query.SingleOrDefault();
            if (tDuong != null)
            {
                try
                {
                    tDuong.DUONG = tenduong;
                    tDuong.MAPHUONG = maphuong;
                    tDuong.MAQUAN = maquan;
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                }
            }
            return false;
        }
        public static bool Delete(int id)
        {
            dbGanMoiDataContext db = new dbGanMoiDataContext();
            var query = from duong in db.TENDUONGs where duong.STT == id select duong;
            TENDUONG tDuong = query.SingleOrDefault();
            if (tDuong != null)
            {
                try
                {
                    db.TENDUONGs.DeleteOnSubmit(tDuong);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                }
            }
            return false;
        }
        public static List<PHUONG> getListByQuan(int maquan)
        {
            dbDHNDataContext data = new dbDHNDataContext();
            var lisPhuong = from phuong in data.PHUONGs where phuong.MAQUAN == maquan select phuong;
            return lisPhuong.ToList();
        }
        public static List<PHUONG> getListPhuongAdmin()
        {
            dbDHNDataContext data = new dbDHNDataContext();
            var lisPhuong = from phuong in data.PHUONGs select phuong;
            return lisPhuong.ToList();
        }
        public static PHUONG finbyPhuong(int maquan, string maphuong)
        {
            dbDHNDataContext data = new dbDHNDataContext();
            var phuong = from p in data.PHUONGs where p.MAQUAN == maquan && p.MAPHUONG == maphuong select p;
            return phuong.SingleOrDefault();
        }
        public static PHUONG finbyTenPhuong(int maquan, string tenPhuong)
        {
            dbDHNDataContext data = new dbDHNDataContext();
            var phuong = from p in data.PHUONGs where p.MAQUAN == maquan && p.TENPHUONG == tenPhuong select p;
            return phuong.SingleOrDefault();
        }

        public static ArrayList getListPhuong()
        {
            ArrayList list = new ArrayList();
            dbDHNDataContext data = new dbDHNDataContext();
            var lisPhuong = from phuong in data.PHUONGs select phuong;
            foreach (var a in lisPhuong)
            {
                list.Add(new AddValueCombox(a.TENPHUONG, a.MAPHUONG));
            }
            return list;
        }

        public static ArrayList getListPhuong(int quan)
        {
            ArrayList list = new ArrayList();
            dbDHNDataContext data = new dbDHNDataContext();
            var lisPhuong = from phuong in data.PHUONGs where phuong.MAQUAN == quan select phuong;
            foreach (var a in lisPhuong)
            {
                list.Add(new AddValueCombox(a.TENPHUONG, a.MAPHUONG));
            }
            return list;
        }

        public static ArrayList getListQUAN()
        {
            ArrayList list = new ArrayList();
            dbDHNDataContext data = new dbDHNDataContext();
            var lisPhuong = from phuong in data.QUANs select phuong;
            foreach (var a in lisPhuong)
            {
                list.Add(new AddValueCombox(a.TENQUAN, a.MAQUAN + ""));
            }
            return list;
        }

        public static List<PHUONG> ListPhuongByTenPhuong(string tenPhuong)
        {
            dbDHNDataContext data = new dbDHNDataContext();
            var lisPhuong = from phuong in data.PHUONGs where phuong.TENPHUONG == tenPhuong select phuong;
            return lisPhuong.ToList();
        }
        public static List<QUAN> getListQuan()
        {
            dbDHNDataContext data = new dbDHNDataContext();
            var quan = from p in data.QUANs select p;
            return quan.ToList();
        }
        public static QUAN finByMaQuan(int maquan)
        {
            dbDHNDataContext data = new dbDHNDataContext();
            var quan = from q in data.QUANs where q.MAQUAN == maquan select q;
            return quan.SingleOrDefault();
        }
        public static QUAN finbyTenQuan(string tenquan)
        {
            dbDHNDataContext data = new dbDHNDataContext();
            var quan = from q in data.QUANs where q.TENQUAN == tenquan select q;
            return quan.SingleOrDefault();
        }

        public static List<QUAN> ListQuan()
        {
            dbDHNDataContext db = new dbDHNDataContext();
            var data = from phuong in db.QUANs select phuong;

            return data.ToList(); ;
        }
        public static List<PHUONG> ListPhuong(int quan)
        {
            dbDHNDataContext db = new dbDHNDataContext();
            var data = from phuong in db.PHUONGs where phuong.MAQUAN == quan select phuong;

            return data.ToList(); ;
        }
    }
}