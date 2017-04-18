using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.CallCenter
{
    class CTiepNhanDon
    {
        static dbKinhDoanhDataContext db = new dbKinhDoanhDataContext();

        public static List<TTKH_LoaiTiepNhan> getLoaiTiepNhan(string loaikh)
        {
            var data = from tn in db.TTKH_LoaiTiepNhans where tn.LoaiKH == loaikh select tn;            
            return data.ToList();
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
                dbKinhDoanhDataContext db = new dbKinhDoanhDataContext();
                db.Connection.Open();
                string sql = " SELECT MAX(SoHoSo) as 'SoHoSo' FROM TiepNhan    ORDER BY SoHoSo DESC";
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

        public static bool Insert(TTKH_TiepNhan tn)
        {
            try
            {
                db.TTKH_TiepNhans.InsertOnSubmit(tn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static TTKH_TiepNhan finbyMaTN(string mabn)
        {
            var query = from biennhan in db.TTKH_TiepNhans where biennhan.SoHoSo == mabn select biennhan;
            return query.SingleOrDefault();
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
            }
            return false;
        }
    }
}