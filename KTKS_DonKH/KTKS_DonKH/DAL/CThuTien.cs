using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;
using System.Data.SqlClient;

namespace KTKS_DonKH.DAL
{
    class CThuTien
    {
        private dbThuTienDataContext db = new dbThuTienDataContext();

        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn

        public CThuTien()
        {
            try
            {
                _connectionString = KTKS_DonKH.Properties.Settings.Default.HOADON_TAConnectionString;
                connection = new SqlConnection(_connectionString);
            }
            catch (Exception)
            {
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

        public DataTable ExecuteQuery_DataTable(string sql)
        {
            this.Connect();
            DataTable dt = new DataTable();
            command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            try
            {
                adapter.Fill(dt);
            }
            catch (SqlException e)
            {
                throw e;
            }
            this.Disconnect();
            return dt;
        }

        public HOADON GetMoiNhat(string DanhBo)
        {
            HOADON a = new HOADON();
            if (db.HOADONs.Any(item => item.DANHBA == DanhBo))
                return db.HOADONs.Where(item => item.DANHBA == DanhBo).OrderByDescending(item => item.ID_HOADON).First();
            else
                if (db.TT_HoaDonCus.Any(item => item.DANHBA == DanhBo))
                    return Copy(a, db.TT_HoaDonCus.Where(item => item.DANHBA == DanhBo).OrderByDescending(item => item.ID_HOADON).First());
                else
                    return null;
        }

        public HOADON Get(string DanhBo,int Ky,int Nam)
        {
            if (db.HOADONs.Any(item => item.DANHBA == DanhBo && item.KY==Ky && item.NAM==Nam))
                return db.HOADONs.SingleOrDefault(item => item.DANHBA == DanhBo && item.KY == Ky && item.NAM == Nam);
            else
                return null;
        }

        public decimal GetTieuThuMoiNhat(string DanhBo)
        {
            if (db.HOADONs.Any(item => item.DANHBA == DanhBo))
                return db.HOADONs.Where(item => item.DANHBA == DanhBo).OrderByDescending(item => item.ID_HOADON).First().TIEUTHU.Value;
            else
                return 0;
        }

        public DataTable GetDSTimKiem(string DanhBo)
        {
            string sql = "select * from fnTimKiem('" + DanhBo + "') order by MaHD desc";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTimKiemTTKH(string HoTen, string SoNha, string TenDuong)
        {
            string sql = "select * from fnTimKiemTTKH('" + HoTen + "','" + SoNha + "','" + TenDuong + "')";

            return ExecuteQuery_DataTable(sql);
        }

        public HOADON Copy(HOADON a, TT_HoaDonCu b)
        {
            a.ChanTienDu = b.ChanTienDu;
            a.ChuyenNoKhoDoi = b.ChuyenNoKhoDoi;
            a.CODE = b.CODE;
            a.CoDH = b.CoDH;
            a.CreateBy = b.CreateBy;
            a.CreateDate = b.CreateDate;
            a.CSCU = b.CSCU;
            a.CSMOI = b.CSMOI;
            a.DangNgan_ChuyenKhoan = b.DangNgan_ChuyenKhoan;
            a.DangNgan_HanhThu = b.DangNgan_HanhThu;
            a.DangNgan_Quay = b.DangNgan_Quay;
            a.DangNgan_Ton = b.DangNgan_Ton;
            a.DANHBA = b.DANHBA;
            a.DENNGAY = b.DENNGAY;
            a.DM = b.DM;
            a.DOT = b.DOT;
            a.DOTCHIA = b.DOTCHIA;
            a.DUONG = b.DUONG;
            //a.FK_DIEUCHINH = b.FK_DIEUCHINH;
            a.GB = b.GB;
            a.GIABAN = b.GIABAN;
            //a.GIABAN_BU = b.GIABAN_BU;
            //a.GIO_TT = b.GIO_TT;
            a.HIEUDH = b.HIEUDH;
            a.HIEULUC = b.HIEULUC;
            a.HOPDONG = b.HOPDONG;
            a.ID_HOADON = b.ID_HOADON;
            a.KhoaTienDu = b.KhoaTienDu;
            a.KY = b.KY;
            //a.L_THANHTOAN = b.L_THANHTOAN;
            //a.MA_NHANVIEN = b.MA_NHANVIEN;
            //a.MA_NHANVIENGIAI = b.MA_NHANVIENGIAI;
            //a.MA_NHANVIENTON = b.MA_NHANVIENTON;
            a.MaDMA = b.MaDMA;
            a.MALOTRINH = b.MALOTRINH;
            a.MaNV_DangNgan = b.MaNV_DangNgan;
            a.MaNV_GiaoTon = b.MaNV_GiaoTon;
            a.MaNV_HanhThu = b.MaNV_HanhThu;
            a.MaNV_HanhThuTruoc = b.MaNV_HanhThuTruoc;
            a.MAY = b.MAY;
            a.ModifyBy = b.ModifyBy;
            a.ModifyDate = b.ModifyDate;
            a.MST = b.MST;
            a.NAM = b.NAM;
            a.NAMLD = b.NAMLD;
            a.NgayChanTienDu = b.NgayChanTienDu;
            a.NGAYGIAITRACH = b.NGAYGIAITRACH;
            a.NGAYGIAO = b.NGAYGIAO;
            a.NGAYGIAOTON = b.NGAYGIAOTON;
            a.PHI = b.PHI;
            //a.PHI_BU = b.PHI_BU;
            //a.PHI_MONUOC = b.PHI_MONUOC;
            a.Phuong = b.Phuong;
            //a.Pol = b.Pol;
            a.Quan = b.Quan;
            a.SO = b.SO;
            a.SOHOADON = b.SOHOADON;
            a.SoHoaDonCu = b.SoHoaDonCu;
            a.SONGAY = b.SONGAY;
            a.SOPHATHANH = b.SOPHATHANH;
            a.SoThanDHN = b.SoThanDHN;
            a.STT = b.STT;
            a.TENKH = b.TENKH;
            a.Thu2Lan = b.Thu2Lan;
            a.Thu2Lan_ChuyenKhoan = b.Thu2Lan_ChuyenKhoan;
            a.Thu2Lan_GhiChu = b.Thu2Lan_GhiChu;
            a.Thu2Lan_NgayTra = b.Thu2Lan_NgayTra;
            a.Thu2Lan_Tra = b.Thu2Lan_Tra;
            a.THUE = b.THUE;
            //a.THUE_BU = b.THUE_BU;
            a.TienDu = b.TienDu;
            a.TienMat = b.TienMat;
            a.TIEUTHU = b.TIEUTHU;
            //a.TIEUTHUBU = b.TIEUTHUBU;
            a.TIEUTHUDV = b.TIEUTHUDV;
            a.TIEUTHUHCSN = b.TIEUTHUHCSN;
            a.TIEUTHUSH = b.TIEUTHUSH;
            a.TIEUTHUSX = b.TIEUTHUSX;
            a.TILEDV = b.TILEDV;
            a.TILEHCSN = b.TILEHCSN;
            a.TILESH = b.TILESH;
            a.TILESX = b.TILESX;
            //a.TO_THUNGAN = b.TO_THUNGAN;
            a.TONGCONG = b.TONGCONG;
            //a.TONGCONG_BU = b.TONGCONG_BU;
            a.TUNGAY = b.TUNGAY;
            return a;
        }
    }
}
