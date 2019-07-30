using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using QuanLyKhachHang.DataBase;
using System.Data.SqlClient;
using log4net;

namespace QuanLyKhachHang.Class
{
    public static class C_DuLieuKhachHang
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DuLieuKhachHang).Name);

        static TanHoaDataContext db = new TanHoaDataContext();


        public static TB_DULIEUKHACHHANG finByDanhBo(string danhbo)
        {
            try
            {
                db = new TanHoaDataContext();
                var query = from q in db.TB_DULIEUKHACHHANGs where q.DANHBO == danhbo select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static TB_DULIEUKHACHHANG finByLoTrinh(string lotrinh)
        {
            try
            {
                var query = from q in db.TB_DULIEUKHACHHANGs where q.LOTRINH == lotrinh select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static void Insert(TB_DULIEUKHACHHANG tb)
        {
            try
            {
                db.TB_DULIEUKHACHHANGs.InsertOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public static void InsertImg(TB_DULIEUKHACHHANG_IMG tb)
        {
            try
            {
                db.TB_DULIEUKHACHHANG_IMGs.InsertOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public static List<TB_DULIEUKHACHHANG_IMG> getListImg(string db)
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var quan = (from p in data.TB_DULIEUKHACHHANG_IMGs where p.Loai=="img" && p.DANHBO == db orderby p.NGAYUP descending select p).Take(3);
            return quan.ToList();
        }

        public static List<TB_DULIEUKHACHHANG_IMG> getListVideo(string db)
        {
            TanHoaDataContext data = new TanHoaDataContext();
            var quan = (from p in data.TB_DULIEUKHACHHANG_IMGs where p.Loai == "mp4" && p.DANHBO == db orderby p.NGAYUP descending select p).Take(1);
            return quan.ToList();
        }


        public static List<TB_DULIEUKHACHHANG> getAllKHACHHANG()
        {
            var query = from q in db.TB_DULIEUKHACHHANGs select q;
            return query.ToList();
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

        public static DataTable lisGhiChu(string danhbo)
        {
            string sql = "SELECT ID,NOIDUNG,DONVI,CONVERT(varchar(50),CREATEDATE,103) as 'NGAY' FROM TB_GHICHU WHERE DANHBO='" + danhbo + "'  ORDER BY CREATEDATE DESC";
            return LinQConnection.getDataTable(sql);
        }

        public static DataTable getDongMoiNuoc(string danhbo)
        {
            string sql = " select ROW_NUMBER() OVER (ORDER BY NgayDN DESC) [STT], ";
            sql += " case when  kqdn.DongNuoc=1  then CONVERT(varchar(50),NgayDN,103) end as NGAYDN,LyDo, ";
            sql += " case when kqdn.MoNuoc=1   then CONVERT(varchar(50),NgayMN,103) end as NGAYMN ";
            sql += " from TT_KQDongNuoc kqdn  where DanhBo='" + danhbo + "'  ORDER BY NgayDN DESC";

            return LinQConnection.getDataTableHoaDon(sql);
        }

        public static DataTable getListHoaDonReport(string danhba)
        {


            DocSoDataContext db = new DocSoDataContext();
            DataSet ds = new DataSet();

            string query = " SELECT top(1)  ( CASE WHEN hd.KY<10 THEN CONVERT(VARCHAR(20),hd.KY) ELSE CONVERT(VARCHAR(20),hd.KY) END+'/' + CONVERT(VARCHAR(20),hd.NAM)) as  NAM , CONVERT(NCHAR(10), hd.DenNgay, 103) AS NGAYDOC, CodeMoi, hd.CSCU, hd.CSMOI, hd.TieuThuMoi as TIEUTHU,  0.0 as ThanhTien ";
            query += "  ,N'Đọc số' AS ThanhToan   ";
            query += " FROM dbo.DocSo  hd ";
            query += " WHERE DANHBA=  '" + danhba + "' ";
            query += "  ORDER BY hd.Nam desc,CAST(hd.KY as int) DESC  ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TIEUTHU");

            query = " SELECT top(" + 12 + ")  ( CASE WHEN hd.KY<10 THEN '0'+ CONVERT(VARCHAR(20),hd.KY) ELSE CONVERT(VARCHAR(20),hd.KY) END+'/' + CONVERT(VARCHAR(20),hd.NAM)) as  NAM , CONVERT(NCHAR(10), hd.DenNgay, 103) AS NGAYDOC, CODE as CodeMoi, cast(hd.CSCU as int) as CSCU, cast(hd.CSMOI as int) as CSMOI,cast(hd.TIEUTHU as int) AS TIEUTHU , (hd.PHI + hd.THUE +hd.GIABAN) as ThanhTien ";
            query += " ,CASE WHEN NGAYGIAITRACH IS NULL OR NGAYGIAITRACH ='' THEN '' ELSE 'x'  END AS ThanhToan   ";
            query += " FROM dbo.HOADON  hd ";
            query += " WHERE DANHBA= '" + danhba + "'  ";
            query += " ORDER BY hd.Nam desc,CAST(hd.KY as int) DESC ";


            DataTable TB_HD = LinQConnection.getDataTableHoaDon(query);

            ds.Tables["TIEUTHU"].Merge(TB_HD);

            return ds.Tables["TIEUTHU"];
        }

        public static string getNVDS(string may)
        {
            try
            {
                DocSoDataContext db = new DocSoDataContext();
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
        public static string getNVThuTien(string db)
        {

            try
            {
                string query = " SELECT  TOP(1) nd.HoTen + ' ['+ nd.DienThoai +']' ";
                query += "  FROM  TT_NguoiDung nd,HOADON hd ";
                query += " WHERE hd.MaNV_HanhThu=nd.MaND  and DANHBA='" + db + "' ";
                query += " ORDER BY hd.Nam desc,CAST(hd.KY as int) DESC  ";
                DataTable tb = LinQConnection.getDataTableHoaDon(query);
                return tb.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                return "";
            }



        }
        

        public static DataTable getListHoaDonReport(string danhba, int rows)
        {

            DocSoDataContext db = new DocSoDataContext();
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


            DataTable TB_HD = LinQConnection.getDataTableHoaDon(query);

            ds.Tables["TIEUTHU"].Merge(TB_HD);

            return ds.Tables["TIEUTHU"];
        }

    }
}
