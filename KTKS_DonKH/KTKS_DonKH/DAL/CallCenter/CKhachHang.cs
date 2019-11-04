using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using KTKS_DonKH.LinQ;
using System.IO;

namespace KTKS_DonKH.DAL.CallCenter
{
    class CKhachHang  
    {
        static dbDHNDataContext db = new dbDHNDataContext();
       
        public static DataTable getDataTable(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(table);
            }
            catch (Exception)
            {
            }
            finally
            {
                db.Connection.Close();
            }
            return table;
        }


        public static DataTable getDataTableHoaDon(string sql)
        {
            DataTable table = new DataTable();
            dbThuTienDataContext db = new dbThuTienDataContext();
            try
            {
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(table);
            }
            catch (Exception)
            {
            }
            finally
            {
                db.Connection.Close();
            }
            return table;
        }


        public static DataTable lisGhiChu(string danhbo)
        {
            string sql = "SELECT ID,NOIDUNG,DONVI,CREATEDATE FROM TB_GHICHU WHERE DANHBO='" + danhbo + "'  ORDER BY CREATEDATE DESC";
            return getDataTable(sql);
        }

        public static DataTable getDongMoiNuoc(string danhbo)
        {
            string sql = " select ROW_NUMBER() OVER (ORDER BY NgayDN DESC) [STT], ";
            sql += " case when  kqdn.DongNuoc=1  then CONVERT(varchar(50),NgayDN,103) end as NGAYDN,LyDo, ";
            sql += " case when kqdn.MoNuoc=1   then CONVERT(varchar(50),NgayMN,103) end as NGAYMN ";
            sql += " from TT_KQDongNuoc kqdn  where DanhBo='" + danhbo + "' ";

            return getDataTableHoaDon(sql);
        }

        public static DataTable getListHoaDonReport(string danhba, int rows)
        {

            dbHandHeldDataContext db = new dbHandHeldDataContext();
            DataSet ds = new DataSet();

            string query = " SELECT top(1)  ( CASE WHEN hd.KY<10 THEN CONVERT(VARCHAR(20),hd.KY) ELSE CONVERT(VARCHAR(20),hd.KY) END+'/' + CONVERT(VARCHAR(20),hd.NAM)) as  NAM , CONVERT(NCHAR(10), hd.DenNgay, 103) AS NGAYDOC, CodeMoi, hd.CSCU, hd.CSMOI, hd.TieuThuMoi as TIEUTHU,  0.0 as ThanhTien ";
            query += "  ,N'Đọc số' AS ThanhToan   ";
            query += " FROM dbo.DocSo  hd ";
            query += " WHERE DANHBA=  '" + danhba + "' ";
            query += "  ORDER BY hd.Nam desc,CAST(hd.KY as int) DESC  ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TIEUTHU");

            query = " SELECT top(" + rows + ")  ( CASE WHEN hd.KY<10 THEN '0'+ CONVERT(VARCHAR(20),hd.KY) ELSE CONVERT(VARCHAR(20),hd.KY) END+'/' + CONVERT(VARCHAR(20),hd.NAM)) as  NAM , CONVERT(NCHAR(10), hd.DenNgay, 103) AS NGAYDOC, CODE as CodeMoi, cast(hd.CSCU as int) as CSCU, cast(hd.CSMOI as int) as CSMOI,cast(hd.TIEUTHU as int) AS TIEUTHU , (hd.PHI + hd.THUE +hd.GIABAN) as ThanhTien ";
            query += " ,CASE WHEN NGAYGIAITRACH IS NULL OR NGAYGIAITRACH ='' THEN '' ELSE 'x'  END AS ThanhToan   ";
            query += " FROM dbo.HOADON  hd ";
            query += " WHERE DANHBA= '" + danhba + "'  ";
            query += " ORDER BY hd.Nam desc,CAST(hd.KY as int) DESC ";


            DataTable TB_HD = getDataTableHoaDon(query);

            ds.Tables["TIEUTHU"].Merge(TB_HD);

            return ds.Tables["TIEUTHU"];
        }

        public static string getNVThuTien(string db)
        {

            try
            {
                string query = " SELECT  TOP(1) nd.HoTen + ' ['+ nd.DienThoai +']' ";
                query += "  FROM  TT_NguoiDung nd,HOADON hd ";
                query += " WHERE hd.MaNV_HanhThu=nd.MaND  and DANHBA='" + db + "' ";
                query += " ORDER BY hd.Nam desc,CAST(hd.KY as int) DESC  ";
                DataTable tb = getDataTableHoaDon(query);
                return tb.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                return "";
            }
         


        }
        public static string getApLuc(string db)
        {

            try
            {
                string query = " SELECT  [ApLuc]   FROM [KYTHUAT].[dbo].[THONGTINDMA] WHERE MaDma='"+db+"'";
                DataTable tb = getDataTable(query);
                return tb.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                return "";
            }



        }
        public static DataTable search(string diachi, string dit)
        {
            DataTable tb = new DataTable();
            string sql = "SELECT DANHBO, (SONHA+' '+ TENDUONG) as DIACHI, (QUAN+PHUONG) AS QUANPHUONG ,LOTRINH, HOTEN,HOPDONG,HIEUDH,CODH,SOTHANDH,(CONVERT(VARCHAR,KY)+'/'+CONVERT(VARCHAR,NAM) ) AS N'HL'  , YEAR(NGAYTHAY) AS N'NĂM GẮN' FROM TB_DULIEUKHACHHANG WHERE (SONHA+' '+ TENDUONG) LIKE '" + diachi.Replace("*", "%") + "' ORDER BY LOTRINH ASC ";
            tb = getDataTable(sql);
            sql = " SELECT DANHBO, (SONHA+' '+ TENDUONG) as DIACHI, (QUAN+PHUONG) AS QUANPUONG ,LOTRINH, HOTEN,HOPDONG,HIEUDH,CODH,SOTHANDH, N'Hủy ' +HIEULUCHUY AS N'HL'   FROM TB_DULIEUKHACHHANG_HUYDB  WHERE (SONHA+' '+ TENDUONG) LIKE '" + diachi.Replace("*", "%") + "' ORDER BY LOTRINH ASC ";
            tb.Merge(getDataTable(sql));
            return tb;
        }

        public static TB_DULIEUKHACHHANG finByDanhBo(string danhbo)
        {
            try
            {
                
                var query = from q in db.TB_DULIEUKHACHHANGs where q.DANHBO == danhbo select q;
                return query.SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public static TB_DULIEUKHACHHANG_HUYDB finByDanhBoHuy(string danhbo)
        {
            try
            {
                var query = (from q in db.TB_DULIEUKHACHHANG_HUYDBs where q.DANHBO == danhbo orderby q.CREATEDATE descending select q).Take(1);
                return query.SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }
        public static bool checkHoSogoc(string danhbo)
        {
            if (DAL.CallCenter.CKhachHang.getDataTable("SELECT DBDongHoNuoc FROM HOSOGOC WHERE DBDongHoNuoc='" + danhbo + "'").Rows.Count > 0)
                return true;
            return false;
        }

        public static HOSOGOC findByHoSoGoc(string danhbo)
        {
            try
            {
                var query = from q in db.HOSOGOCs where q.DBDongHoNuoc == danhbo orderby q.NgayCapNhat descending select q;
                return query.First();
            }
            catch (Exception)
            {

            }
            return null;
        }

        public static string getNVDS(string may)
        {
            try
            {
                dbHandHeldDataContext db = new dbHandHeldDataContext();                 
                DataSet ds = new DataSet();

                string query = " SELECT NhanVienID + ' ['  + DienThoai + ']' ";
                query += "  FROM MayDS   ";
                query += " WHERE May=  '" + may + "' ";

                SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
                adapter.Fill(ds, "MayDS");
                return ds.Tables["MayDS"].Rows[0][0].ToString();
            }
            catch (Exception)
            {

            }
            return "";
        }

        public static DataTable getListTiepNhan(string danhbo)
        {

            CDAL t = new CDAL();
            string sql = " SELECT tn.SoHoSo,DienThoai,DanhBo,lt.TenLoai,NgayNhan, GhiChu,CreateBy,ChuyenHS,DonViChuyen,NgayChuyen,NgayXuLy,KetQuaXuLy,NhanVienXuLy,TenKH,(SoNha + ' ' + TenDuong ) as DiaChi ";
            sql += "   FROM TTKH_TiepNhan tn, TTKH_LoaiTiepNhan lt ";
            sql += "   WHERE tn.LoaiHs=lt.ID  ";
            sql += " AND DanhBo='" + danhbo + "' ORDER BY  NgayNhan DESC ";

            return t.ExecuteQuery_DataTable(sql);
        
        }

        public static byte[] GetHoSoGoc(string DanhBo)
        {
            if (db.Connection.State == ConnectionState.Open)
            {
                db.Connection.Close();
            }
            db.Connection.Open();

            SqlConnection sqlCon;
            sqlCon = new SqlConnection(db.Connection.ConnectionString);
            sqlCon.Open();
            using (var sqlQuery = new SqlCommand(@"SELECT DataBlob FROM HOSOGOC WHERE DBDongHoNuoc='" + DanhBo + "' ", sqlCon))
            {

                using (var sqlQueryResult = sqlQuery.ExecuteReader())
                    if (sqlQueryResult != null)
                    {
                        sqlQueryResult.Read();
                        var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                        sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                        sqlCon.Close();
                        return blob;
                    }
            }
            return null;

        }
    }
}