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

        public void SubmitChanges()
        {
            db.SubmitChanges();
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

        public HOADON Get(string DanhBo, int Ky, int Nam)
        {
            HOADON a = new HOADON();
            if (db.HOADONs.Any(item => item.DANHBA == DanhBo && item.KY == Ky && item.NAM == Nam))
                return db.HOADONs.SingleOrDefault(item => item.DANHBA == DanhBo && item.KY == Ky && item.NAM == Nam);
            else
                if (db.TT_HoaDonCus.Any(item => item.DANHBA == DanhBo && item.KY == Ky && item.NAM == Nam))
                    return Copy(a, db.TT_HoaDonCus.FirstOrDefault(item => item.DANHBA == DanhBo && item.KY == Ky && item.NAM == Nam));
                else
                    return null;
        }

        public HOADON get(int MaHD)
        {
            HOADON a = new HOADON();
            if (db.HOADONs.Any(item => item.ID_HOADON == MaHD))
                return db.HOADONs.SingleOrDefault(item => item.ID_HOADON == MaHD);
            else
                if (db.TT_HoaDonCus.Any(item => item.ID_HOADON == MaHD))
                    return Copy(a, db.TT_HoaDonCus.FirstOrDefault(item => item.ID_HOADON == MaHD));
                else
                    return null;
        }

        public HOADON get(string SoHoaDon)
        {
            HOADON a = new HOADON();
            if (db.HOADONs.Any(item => item.SOHOADON == SoHoaDon))
                return db.HOADONs.SingleOrDefault(item => item.SOHOADON == SoHoaDon);
            else
                if (db.TT_HoaDonCus.Any(item => item.SOHOADON == SoHoaDon))
                    return Copy(a, db.TT_HoaDonCus.FirstOrDefault(item => item.SOHOADON == SoHoaDon));
                else
                    return null;
        }

        public DataTable getDS(string DanhBo, int TuKy, int TuNam, int DenKy, int DenNam)
        {
            string sql = "select Nam,Ky,GiaBieu=GB,DinhMuc=DM,DinhMucHN,TieuThu,TongCong from HOADON where DanhBa='" + DanhBo + "' and (NAM>" + TuNam + " or (NAM=" + TuNam + " and KY>=" + TuKy + ")) and (NAM<" + DenNam + " or (NAM=" + DenNam + " and KY<=" + DenKy + "))"
                        + " union"
                        + " select Nam,Ky,GiaBieu=GB,DinhMuc=DM,DinhMucHN,TieuThu,TongCong from TT_HoaDonCu where DanhBa='" + DanhBo + "' and (NAM>" + TuNam + " or (NAM=" + TuNam + " and KY>=" + TuKy + ")) and (NAM<" + DenNam + " or (NAM=" + DenNam + " and KY<=" + DenKy + "))"
                        + " order by Nam,Ky";
            return ExecuteQuery_DataTable(sql);
        }

        public decimal GetTieuThuMoiNhat(string DanhBo)
        {
            if (db.HOADONs.Any(item => item.DANHBA == DanhBo))
                return db.HOADONs.Where(item => item.DANHBA == DanhBo).OrderByDescending(item => item.ID_HOADON).First().TIEUTHU.Value;
            else
                return 0;
        }

        public DataTable GetDSTimKiem(string DanhBo, string MLT)
        {
            string sql = "select * from fnTimKiem('" + DanhBo + "','" + MLT + "') order by MaHD desc";

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
            a.DinhMucHN = b.DinhMucHN;
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

        public bool Them(DIEUCHINH_HD dchd)
        {
            try
            {
                //if (_db.DIEUCHINH_HDs.Count() > 0)
                //    hoadon.ID_DIEUCHINH_HD = _db.DIEUCHINH_HDs.Max(item => item.ID_DIEUCHINH_HD) + 1;
                //else
                //    hoadon.ID_DIEUCHINH_HD = 1;
                dchd.CreateDate = DateTime.Now;
                db.DIEUCHINH_HDs.InsertOnSubmit(dchd);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public DIEUCHINH_HD get_DCHD(int MaHD)
        {
            return db.DIEUCHINH_HDs.SingleOrDefault(item => item.FK_HOADON == MaHD);
        }

        public DIEUCHINH_HD get_DCHD(string SoHoaDon)
        {
            return db.DIEUCHINH_HDs.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public void LuuLichSuDC(DIEUCHINH_HD dchd)
        {
            TT_LichSuDieuChinhHD lsdc = new TT_LichSuDieuChinhHD();

            lsdc.FK_HOADON = dchd.FK_HOADON;
            lsdc.SoHoaDon = dchd.SoHoaDon;
            lsdc.GiaBieu = dchd.GiaBieu;
            lsdc.DinhMuc = dchd.DinhMuc;
            lsdc.TIEUTHU_BD = dchd.TIEUTHU_BD;
            lsdc.GIABAN_BD = dchd.GIABAN_BD;
            lsdc.PHI_BD = dchd.PHI_BD;
            lsdc.THUE_BD = dchd.THUE_BD;
            lsdc.TONGCONG_BD = dchd.TONGCONG_BD;

            lsdc.PHIEU_DC = dchd.PHIEU_DC;
            lsdc.NGAY_VB = dchd.NGAY_VB;
            lsdc.NGAY_DC = dchd.NGAY_DC;
            lsdc.SoPhieu = dchd.SoPhieu;
            lsdc.TangGiam = dchd.TangGiam;

            lsdc.GIABAN_DC = dchd.GIABAN_DC;
            lsdc.GIABAN_END = dchd.GIABAN_END;

            lsdc.THUE_DC = dchd.THUE_DC;
            lsdc.THUE_END = dchd.THUE_END;

            lsdc.PHI_DC = dchd.PHI_DC;
            lsdc.PHI_END = dchd.PHI_END;

            lsdc.TONGCONG_DC = dchd.TONGCONG_DC;
            lsdc.TONGCONG_END = dchd.TONGCONG_END;

            lsdc.GB_DC = dchd.GB_DC;
            lsdc.DM_DC = dchd.DM_DC;
            lsdc.TIEUTHU_DC = dchd.TIEUTHU_DC;

            if (db.TT_LichSuDieuChinhHDs.Count() > 0)
                lsdc.ID = db.TT_LichSuDieuChinhHDs.Max(item => item.ID) + 1;
            else
                lsdc.ID = 1;
            lsdc.CreateDate = DateTime.Now;
            db.TT_LichSuDieuChinhHDs.InsertOnSubmit(lsdc);
            db.SubmitChanges();
        }

        public bool checkDangNgan(int MaHD)
        {
            return db.HOADONs.Any(item => item.ID_HOADON == MaHD && item.NGAYGIAITRACH != null);
        }

        public DataTable GetNam()
        {
            return ExecuteQuery_DataTable("select * from ViewGetNamHD order by ID desc");
        }
    }
}
