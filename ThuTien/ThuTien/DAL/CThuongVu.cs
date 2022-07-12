using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;

namespace ThuTien.DAL
{
    class CThuongVu
    {
        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn
        //protected SqlTransaction transaction;       // Đối tượng transaction
        dbKTKS_DonKHDataContext _dbKinhDoanh = new dbKTKS_DonKHDataContext();
        private const int _GiamTienNuoc = 10;

        public CThuongVu()
        {
            try
            {
                //_connectionString = "Data Source=192.168.90.8\\KD;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=sa;Password=123@tanhoa";
                _connectionString = ThuTien.Properties.Settings.Default.KTKS_DonKHConnectionString;
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

        public DataTable ExecuteQuery_DataTable(string sql)
        {
            this.Connect();
            DataTable dt = new DataTable();
            command = new SqlCommand();
            command.Connection = this.connection;
            adapter = new SqlDataAdapter(sql, connection);
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

        public bool LinQ_ExecuteNonQuery(string sql)
        {
            if (_dbKinhDoanh.ExecuteCommand(sql) == 0)
            {
                _dbKinhDoanh = new dbKTKS_DonKHDataContext();
                return false;
            }
            else
            {
                _dbKinhDoanh = new dbKTKS_DonKHDataContext();
                return true;
            }
        }

        public DataTable GetDSP_KinhDoanh(string DanhBo)
        {
            string sqlKTXM = "select db='Kinh Doanh',Loai=N'Kiểm Tra Xác Minh',NoiDung=NoiDungKiemTra,CreateDate=NgayKTXM,'Table'='KTXM_ChiTiet','Column'='MaCTKTXM',Ma=MaCTKTXM,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from KTXM_ChiTiet where DanhBo='" + DanhBo + "'";
            string sqlBamChi = "select db='Kinh Doanh',Loai=N'Bấm Chì',NoiDung=TrangThaiBC,CreateDate=NgayBC,'Table'='BamChi_ChiTiet','Column'='MaCTBC',Ma=MaCTBC,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from BamChi_ChiTiet where DanhBo='" + DanhBo + "'";
            string sqlDCBD = "select db='Kinh Doanh',Loai=N'Điều Chỉnh Biến Động',NoiDung=ThongTin+' '+HieuLucKy,CreateDate,'Table'='DCBD_ChiTietBienDong','Column'='MaCTDCBD',Ma=MaCTDCBD,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from DCBD_ChiTietBienDong where DanhBo='" + DanhBo + "'";
            string sqlDCHD = "select db='Kinh Doanh',Loai=N'Điều Chỉnh Hóa Đơn',NoiDung=KyHD+' '+TangGiam,CreateDate,'Table'='DCBD_ChiTietHoaDon','Column'='MaCTDCHD',Ma=MaCTDCHD,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from DCBD_ChiTietHoaDon where DanhBo='" + DanhBo + "'";
            string sqlCTDB = "select db='Kinh Doanh',Loai=N'TB Cắt Tạm Danh Bộ',NoiDung=LyDo+'. '+GhiChuLyDo,CreateDate,'Table'='CHDB_ChiTietCatTam','Column'='MaCTCTDB',Ma=MaCTCTDB,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from CHDB_ChiTietCatTam where DanhBo='" + DanhBo + "'";
            string sqlCHDB = "select db='Kinh Doanh',Loai=N'TB Cắt Hủy Danh Bộ',NoiDung=LyDo+'. '+GhiChuLyDo,CreateDate,'Table'='CHDB_ChiTietCatHuy','Column'='MaCTCHDB',Ma=MaCTCHDB,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from CHDB_ChiTietCatHuy where DanhBo='" + DanhBo + "'";
            string sqlPhieuCHDB = "select db='Kinh Doanh',Loai=N'Phiếu Hủy',NoiDung=LyDo+'. '+GhiChuLyDo,CreateDate,'Table'='CHDB_Phieu','Column'='MaYCCHDB',Ma=MaYCCHDB,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from CHDB_Phieu where DanhBo='" + DanhBo + "'";
            string sqlTTTL = "select db='Kinh Doanh',Loai=N'Thư Trả Lời',NoiDung,CreateDate,'Table'='ThuTraLoi_ChiTiet','Column'='MaCTTTTL',Ma=MaCTTTTL,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu from ThuTraLoi_ChiTiet where DanhBo='" + DanhBo + "'";

            DataTable dt = ExecuteQuery_DataTable(sqlKTXM);
            dt.Merge(ExecuteQuery_DataTable(sqlDCBD));
            dt.Merge(ExecuteQuery_DataTable(sqlDCHD));
            dt.Merge(ExecuteQuery_DataTable(sqlCTDB));
            dt.Merge(ExecuteQuery_DataTable(sqlCHDB));
            dt.Merge(ExecuteQuery_DataTable(sqlPhieuCHDB));
            dt.Merge(ExecuteQuery_DataTable(sqlTTTL));
            dt.DefaultView.Sort = "CreateDate desc";
            return dt.DefaultView.ToTable();
        }

        public DataTable GetDSP_KinhDoanh(string Loai, DateTime FromThuTien_NgayNhan, DateTime ToThuTien_NgayNhan)
        {
            DataTable dt = new DataTable();
            switch (Loai)
            {
                case "Kiểm Tra Xác Minh":
                    string sqlKTXM = "select Loai=N'Kiểm Tra Xác Minh',DanhBo,DiaChi,NoiDung=NoiDungKiemTra,CreateDate,'Table'='KTXM_ChiTiet','Column'='MaCTKTXM',Ma=MaCTKTXM,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from KTXM_ChiTiet"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    dt = ExecuteQuery_DataTable(sqlKTXM);
                    break;
                case "Điều Chỉnh Biến Động":
                    string sqlDCBD = "select Loai=N'Điều Chỉnh Biến Động',DanhBo,DiaChi,NoiDung=ThongTin,CreateDate,'Table'='DCBD_ChiTietBienDong','Column'='MaCTDCBD',Ma=MaCTDCBD,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from DCBD_ChiTietBienDong"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    dt = ExecuteQuery_DataTable(sqlDCBD);
                    break;
                case "Điều Chỉnh Hóa Đơn":
                    string sqlDCHD = "select Loai=N'Điều Chỉnh Hóa Đơn',DanhBo,DiaChi,NoiDung=TangGiam,CreateDate,'Table'='DCBD_ChiTietHoaDon','Column'='MaCTDCHD',Ma=MaCTDCHD,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from DCBD_ChiTietHoaDon"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    dt = ExecuteQuery_DataTable(sqlDCHD);
                    break;
                case "TB Cắt Tạm Danh Bộ":
                    string sqlCTDB = "select Loai=N'TB Cắt Tạm Danh Bộ',DanhBo,DiaChi,NoiDung=LyDo+'. '+GhiChuLyDo,CreateDate,'Table'='CHDB_ChiTietCatTam','Column'='MaCTCTDB',Ma=MaCTCTDB,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from CHDB_ChiTietCatTam"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    dt = ExecuteQuery_DataTable(sqlCTDB);
                    break;
                case "TB Cắt Hủy Danh Bộ":
                    string sqlCHDB = "select Loai=N'TB Cắt Hủy Danh Bộ',DanhBo,DiaChi,NoiDung=LyDo+'. '+GhiChuLyDo,CreateDate,'Table'='CHDB_ChiTietCatHuy','Column'='MaCTCHDB',Ma=MaCTCHDB,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from CHDB_ChiTietCatHuy"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    dt = ExecuteQuery_DataTable(sqlCHDB);
                    break;
                case "Phiếu Yêu Cầu Cắt Hủy Danh Bộ":
                    string sqlPhieuCHDB = "select Loai=N'Phiếu Yêu Cầu Cắt Hủy Danh Bộ',DanhBo,DiaChi,NoiDung=LyDo+'. '+GhiChuLyDo,CreateDate,'Table'='CHDB_Phieu','Column'='MaYCCHDB',Ma=MaYCCHDB,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from CHDB_Phieu"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    dt = ExecuteQuery_DataTable(sqlPhieuCHDB);
                    break;
                case "Thư Trả Lời":
                    string sqlTTTL = "select Loai=N'Thư Trả Lời',DanhBo,DiaChi,NoiDung,CreateDate,'Table'='ThuTraLoi_ChiTiet','Column'='MaCTTTTL',Ma=MaCTTTTL,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from ThuTraLoi_ChiTiet"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    dt = ExecuteQuery_DataTable(sqlTTTL);
                    break;
                default:
                    sqlKTXM = "select Loai=N'Kiểm Tra Xác Minh',DanhBo,DiaChi,NoiDung=NoiDungKiemTra,CreateDate,'Table'='KTXM_ChiTiet','Column'='MaCTKTXM',Ma=MaCTKTXM,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from KTXM_ChiTiet"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    sqlDCBD = "select Loai=N'Điều Chỉnh Biến Động',DanhBo,DiaChi,NoiDung=ThongTin,CreateDate,'Table'='DCBD_ChiTietBienDong','Column'='MaCTDCBD',Ma=MaCTDCBD,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from DCBD_ChiTietBienDong"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    sqlDCHD = "select Loai=N'Điều Chỉnh Hóa Đơn',DanhBo,DiaChi,NoiDung=TangGiam,CreateDate,'Table'='DCBD_ChiTietHoaDon','Column'='MaCTDCHD',Ma=MaCTDCHD,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from DCBD_ChiTietHoaDon"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    sqlCTDB = "select Loai=N'TB Cắt Tạm Danh Bộ',DanhBo,DiaChi,NoiDung=LyDo+'. '+GhiChuLyDo,CreateDate,'Table'='CHDB_ChiTietCatTam','Column'='MaCTCTDB',Ma=MaCTCTDB,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from CHDB_ChiTietCatTam"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    sqlCHDB = "select Loai=N'TB Cắt Hủy Danh Bộ',DanhBo,DiaChi,NoiDung=LyDo+'. '+GhiChuLyDo,CreateDate,'Table'='CHDB_ChiTietCatHuy','Column'='MaCTCHDB',Ma=MaCTCHDB,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from CHDB_ChiTietCatHuy"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    sqlPhieuCHDB = "select Loai=N'Phiếu Yêu Cầu Cắt Hủy Danh Bộ',DanhBo,DiaChi,NoiDung=LyDo+'. '+GhiChuLyDo,CreateDate,'Table'='CHDB_Phieu','Column'='MaYCCHDB',Ma=MaYCCHDB,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from CHDB_Phieu"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    sqlTTTL = "select Loai=N'Thư Trả Lời',DanhBo,DiaChi,NoiDung,CreateDate,'Table'='ThuTraLoi_ChiTiet','Column'='MaCTTTTL',Ma=MaCTTTTL,ThuTien_Nhan,ThuTien_NgayNhan,ThuTien_GhiChu,ThuTien_ButPhe,ThuTien_NgayButPhe from ThuTraLoi_ChiTiet"
                        + " where ThuTien_NgayNhan>='" + FromThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "' and ThuTien_NgayNhan<='" + ToThuTien_NgayNhan.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                    dt = ExecuteQuery_DataTable(sqlKTXM);
                    dt.Merge(ExecuteQuery_DataTable(sqlDCBD));
                    dt.Merge(ExecuteQuery_DataTable(sqlDCHD));
                    dt.Merge(ExecuteQuery_DataTable(sqlCTDB));
                    dt.Merge(ExecuteQuery_DataTable(sqlCHDB));
                    dt.Merge(ExecuteQuery_DataTable(sqlPhieuCHDB));
                    dt.Merge(ExecuteQuery_DataTable(sqlTTTL));
                    break;
            }

            dt.DefaultView.Sort = "ThuTien_NgayNhan asc";
            return dt.DefaultView.ToTable();
        }

        //public TTKhachHang GetTTKH(string DanhBo)
        //{
        //    try
        //    {
        //        return _dbKTKS_DonKH.TTKhachHangs.SingleOrDefault(itemTTKH => itemTTKH.DanhBo == DanhBo);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        CHoaDon _cHoaDon = new CHoaDon();

        ///// <summary>
        ///// Công thức tính tiền nước theo giá biểu
        ///// </summary>
        ///// <param name="DieuChinhGia">true là điều chỉnh giá/ false là không</param>
        ///// <param name="GiaDieuChinh"></param>
        ///// <param name="DanhBo">Danh Bộ được dùng để lấy SH,SX,DV,HCSN</param>
        ///// <param name="GiaBieu"></param>
        ///// <param name="DinhMuc"></param>
        ///// <param name="TieuThu"></param>
        ///// <param name="ChiTiet"></param>
        ///// <returns></returns>
        //public int TinhTienNuoc(bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int GiaBieu, int DinhMuc, int TieuThu, out string ChiTiet)
        //{
        //    try
        //    {
        //        string _chiTiet = "";
        //        HOADON hoadon = _cHoaDon.GetMoiNhat(DanhBo);
        //        List<GiaNuoc> lstGiaNuoc = _dbKinhDoanh.GiaNuocs.ToList();
        //        ///Table GiaNuoc được thiết lập theo bảng giá nước
        //        ///1. Đến 4m3/người/tháng
        //        ///2. Trên 4m3 đến 6m3/người/tháng
        //        ///3. Trên 6m3/người/tháng
        //        ///4. Đơn vị sản xuất
        //        ///5. Cơ quan, đoàn thể HCSN
        //        ///6. Đơn vị kinh doanh, dịch vụ
        //        ///List bắt đầu từ phần tử thứ 0
        //        int TongTien = 0;
        //        switch (GiaBieu)
        //        {
        //            ///TƯ GIA
        //            case 11:
        //            case 21:///SH thuần túy
        //                if (TieuThu <= DinhMuc)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                }
        //                else
        //                    if (!DieuChinhGia)
        //                        if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                        {
        //                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
        //                                        + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                        }
        //                    else
        //                    {
        //                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                    }
        //                break;
        //            case 12:
        //            case 22:
        //            case 32:
        //            case 42:///SX thuần túy
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                }
        //                break;
        //            case 13:
        //            case 23:
        //            case 33:
        //            case 43:///DV thuần túy
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                }
        //                break;
        //            case 14:
        //            case 24:///SH + SX
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if (hoadon.TILESH == null && hoadon.TILESX == null)
        //                    {
        //                        if (TieuThu <= DinhMuc)
        //                        {
        //                            TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                        }
        //                        else
        //                            if (!DieuChinhGia)
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[3].DonGia.Value);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                           + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                           + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            }
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ SH + SX
        //                        if (hoadon.TILESH != null && hoadon.TILESX != null)
        //                        {
        //                            int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                            int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                            if (_SH <= DinhMuc)
        //                            {
        //                                TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
        //                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                            }
        //                            else
        //                                if (!DieuChinhGia)
        //                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                    {
        //                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
        //                                    }
        //                                    else
        //                                    {
        //                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
        //                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
        //                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                                    }
        //                                else
        //                                {
        //                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                                }
        //                            TongTien += _SX * lstGiaNuoc[3].DonGia.Value;
        //                            _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
        //                        }
        //                break;
        //            case 15:
        //            case 25:///SH + DV
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if (hoadon.TILESH == null && hoadon.TILEDV == null)
        //                    {
        //                        if (TieuThu <= DinhMuc)
        //                        {
        //                            TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                        }
        //                        else
        //                            if (!DieuChinhGia)
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[5].DonGia.Value);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            }
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ SH + DV
        //                        if (hoadon.TILESH != null && hoadon.TILEDV != null)
        //                        {
        //                            int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                            int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                            if (_SH <= DinhMuc)
        //                            {
        //                                TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
        //                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                            }
        //                            else
        //                                if (!DieuChinhGia)
        //                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                    {
        //                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
        //                                    }
        //                                    else
        //                                    {
        //                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
        //                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
        //                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                                    }
        //                                else
        //                                {
        //                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                                }
        //                            TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
        //                            _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                        }
        //                break;
        //            case 16:
        //            case 26:///SH + SX + DV
        //                if (hoadon != null)
        //                    ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
        //                    if (hoadon.TILESX != null && hoadon.TILEDV != null && hoadon.TILESH == null)
        //                    {
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        TongTien = (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                        _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                    }
        //                    else
        //                        ///Nếu có đủ 3 tỉ lệ SH + SX + DV
        //                        if (hoadon.TILESX != null && hoadon.TILEDV != null && hoadon.TILESH != null)
        //                        {
        //                            int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                            int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                            int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                            if (_SH <= DinhMuc)
        //                            {
        //                                TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
        //                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                            }
        //                            else
        //                                if (!DieuChinhGia)
        //                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                    {
        //                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
        //                                    }
        //                                    else
        //                                    {
        //                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
        //                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
        //                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                                    }
        //                                else
        //                                {
        //                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                                }
        //                            TongTien += (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                            _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
        //                                         + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                        }
        //                break;
        //            case 17:
        //            case 27:///SH ĐB
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                }
        //                break;
        //            case 18:
        //            case 28:
        //            case 38:///SH + HCSN
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if (hoadon.TILESH == null && hoadon.TILEHCSN == null)
        //                    {
        //                        if (TieuThu <= DinhMuc)
        //                        {
        //                            TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                        }
        //                        else
        //                            if (!DieuChinhGia)
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[4].DonGia.Value);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            }
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ SH + HCSN
        //                        if (hoadon.TILESH != null && hoadon.TILEHCSN != null)
        //                        {
        //                            int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                            int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                            if (_SH <= DinhMuc)
        //                            {
        //                                TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
        //                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                            }
        //                            else
        //                                if (!DieuChinhGia)
        //                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                    {
        //                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
        //                                    }
        //                                    else
        //                                    {
        //                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
        //                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
        //                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                                    }
        //                                else
        //                                {
        //                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                                }
        //                            TongTien += _HCSN * lstGiaNuoc[4].DonGia.Value;
        //                            _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
        //                        }
        //                break;
        //            case 19:
        //            case 29:
        //            case 39:///SH + HCSN + SX + DV
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        if (_SH <= DinhMuc)
        //                        {
        //                            TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
        //                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                        }
        //                        else
        //                            if (!DieuChinhGia)
        //                                if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                {
        //                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
        //                                }
        //                                else
        //                                {
        //                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
        //                                                + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                                }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            }
        //                        TongTien += (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                        _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
        //                                    + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                    }
        //                break;
        //            ///TẬP THỂ
        //            //case 21:///SH thuần túy
        //            //    if (TieuThu <= DinhMuc)
        //            //        TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //            //    else
        //            //        if (TieuThu - DinhMuc <= DinhMuc / 2)
        //            //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //            //        else
        //            //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + (DinhMuc / 2 * lstGiaNuoc[1].DonGia.Value) + ((TieuThu - DinhMuc - DinhMuc / 2) * lstGiaNuoc[2].DonGia.Value);
        //            //    break;
        //            //case 22:///SX thuần túy
        //            //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
        //            //    break;
        //            //case 23:///DV thuần túy
        //            //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
        //            //    break;
        //            //case 24:///SH + SX
        //            //    hoadon = _cTTKH._cHoaDon.GetMoiNhat(DanhBo);
        //            //    if (hoadon != null)
        //            //        ///Nếu không có tỉ lệ
        //            //        if (hoadon.TILESH==null && hoadon.TILESX==null)
        //            //        {

        //            //        }
        //            //    break;
        //            //case 25:///SH + DV

        //            //    break;
        //            //case 26:///SH + SX + DV

        //            //    break;
        //            //case 27:///SH ĐB
        //            //    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //            //    break;
        //            //case 28:///SH + HCSN

        //            //    break;
        //            //case 29:///SH + HCSN + SX + DV

        //            //    break;
        //            ///CƠ QUAN
        //            case 31:///SHVM thuần túy
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[4].DonGia.Value;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                }
        //                break;
        //            //case 32:///SX
        //            //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
        //            //    break;
        //            //case 33:///DV
        //            //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
        //            //    break;
        //            case 34:///HCSN + SX
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if (hoadon.TILEHCSN == null && hoadon.TILESX == null)
        //                    {
        //                        TongTien = (TieuThu * lstGiaNuoc[3].DonGia.Value);
        //                        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ
        //                        if (hoadon.TILEHCSN != null && hoadon.TILESX != null)
        //                        {
        //                            int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                            int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                            TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
        //                            _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
        //                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
        //                        }
        //                break;
        //            case 35:///HCSN + DV
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if (hoadon.TILEHCSN == null && hoadon.TILESX == null)
        //                    {
        //                        TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
        //                        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ
        //                        if (hoadon.TILEHCSN != null && hoadon.TILEDV != null)
        //                        {
        //                            int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                            int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                            TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                            _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
        //                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                        }
        //                break;
        //            case 36:///HCSN + SX + DV
        //                if (hoadon != null)
        //                    if (hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                        _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
        //                                    + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                    }
        //                break;
        //            //case 38:///SH + HCSN

        //            //    break;
        //            //case 39:///SH + HCSN + SX + DV

        //            //    break;
        //            ///NƯỚC NGOÀI
        //            case 41:///SHVM thuần túy
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[2].DonGia.Value;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                }
        //                break;
        //            //case 42:///SX
        //            //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
        //            //    break;
        //            //case 43:///DV
        //            //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
        //            //    break;
        //            case 44:///SH + SX
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILESX != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
        //                                    + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
        //                    }
        //                break;
        //            case 45:///SH + DV
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                    }
        //                break;
        //            case 46:///SH + SX + DV
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
        //                                    + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                    }
        //                break;
        //            ///BÁN SỈ
        //            case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
        //                //if (TieuThu <= DinhMuc)
        //                //    TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100));
        //                //else
        //                //    if (TieuThu - DinhMuc <= DinhMuc / 2)
        //                //        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100))) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - (lstGiaNuoc[1].DonGia.Value * 10 / 100)));
        //                //    else
        //                //        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100))) + (DinhMuc / 2 * (lstGiaNuoc[1].DonGia.Value - (lstGiaNuoc[1].DonGia.Value * 10 / 100))) + ((TieuThu - DinhMuc - DinhMuc / 2) * (lstGiaNuoc[2].DonGia.Value - (lstGiaNuoc[2].DonGia.Value * 10 / 100)));
        //                if (TieuThu <= DinhMuc)
        //                {
        //                    TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
        //                }
        //                else
        //                    if (!DieuChinhGia)
        //                        if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                        {
        //                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
        //                        }
        //                    else
        //                    {
        //                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                    }
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 52:///sỉ khu công nghiệp
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100));
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                }
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 53:///sỉ KD - TM
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                }
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 54:///sỉ HCSN
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100));
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                }
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 59:///sỉ phức tạp
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        if (_SH <= DinhMuc)
        //                        {
        //                            TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
        //                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
        //                        }
        //                        else
        //                            if (!DieuChinhGia)
        //                                if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                {
        //                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
        //                                }
        //                                else
        //                                {
        //                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
        //                                }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                            }
        //                        TongTien += (_HCSN * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + +(_DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
        //                        _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
        //                        //TongTien -= TongTien * 10 / 100;
        //                    }
        //                break;
        //            case 68:///SH giá sỉ - KD giá lẻ
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        if (_SH <= DinhMuc)
        //                        {
        //                            TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
        //                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
        //                        }
        //                        else
        //                            if (!DieuChinhGia)
        //                                if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                {
        //                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                         + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
        //                                }
        //                                else
        //                                {
        //                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
        //                                    _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100))) + "\r\n"
        //                                         + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                         + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
        //                                }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                            }
        //                        TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
        //                        _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                        //TongTien -= TongTien * 10 / 100;
        //                    }
        //                break;
        //            default:
        //                _chiTiet = "";
        //                TongTien = 0;
        //                break;
        //        }
        //        ChiTiet = _chiTiet;
        //        return TongTien;
        //    }
        //    catch (Exception)
        //    {
        //        ChiTiet = "";
        //        return 0;
        //    }
        //}

        //public int TinhTienNuoc(bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int GiaBieu, int DinhMuc, int TieuThu, int SH, int SX, int DV, int HCSN, out string ChiTiet)
        //{
        //    try
        //    {
        //        string _chiTiet = "";
        //        HOADON hoadon = _cHoaDon.GetMoiNhat(DanhBo);
        //        List<GiaNuoc> lstGiaNuoc = _dbKinhDoanh.GiaNuocs.ToList();
        //        ///Table GiaNuoc được thiết lập theo bảng giá nước
        //        ///1. Đến 4m3/người/tháng
        //        ///2. Trên 4m3 đến 6m3/người/tháng
        //        ///3. Trên 6m3/người/tháng
        //        ///4. Đơn vị sản xuất
        //        ///5. Cơ quan, đoàn thể HCSN
        //        ///6. Đơn vị kinh doanh, dịch vụ
        //        ///List bắt đầu từ phần tử thứ 0
        //        int TongTien = 0;
        //        switch (GiaBieu)
        //        {
        //            ///TƯ GIA
        //            case 11:
        //            case 21:///SH thuần túy
        //                if (TieuThu <= DinhMuc)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                }
        //                else
        //                    if (!DieuChinhGia)
        //                        if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                        {
        //                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
        //                                        + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                        }
        //                    else
        //                    {
        //                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                    }
        //                break;
        //            case 12:
        //            case 22:
        //            case 32:
        //            case 42:///SX thuần túy
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                }
        //                break;
        //            case 13:
        //            case 23:
        //            case 33:
        //            case 43:///DV thuần túy
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                }
        //                break;
        //            case 14:
        //            case 24:///SH + SX
        //                if (hoadon != null)
        //                ///Nếu không có tỉ lệ
        //                //if (hoadon.TILESH==null && hoadon.TILESX==null)
        //                //{
        //                //    if (TieuThu <= DinhMuc)
        //                //    {
        //                //        TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //                //        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                //    }
        //                //    else
        //                //        if (!DieuChinhGia)
        //                //        {
        //                //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[3].DonGia.Value);
        //                //            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                //                       + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
        //                //        }
        //                //        else
        //                //        {
        //                //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                //            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                //                       + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //        }
        //                //}
        //                //else
        //                ///Nếu có tỉ lệ SH + SX
        //                //if (SH != 0 && SX != 0)
        //                {
        //                    int _SH = (int)Math.Round((double)TieuThu * SH / 100);
        //                    int _SX = TieuThu - _SH;

        //                    if (_SH <= DinhMuc)
        //                    {
        //                        TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
        //                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                            }
        //                        else
        //                        {
        //                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        }
        //                    ///tránh trường hợp chia dự 0.5 cả 2 cái sẽ bị đôn lên 1
        //                    TongTien += _SX * lstGiaNuoc[3].DonGia.Value;
        //                    _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
        //                }
        //                break;
        //            case 15:
        //            case 25:///SH + DV
        //                if (hoadon != null)
        //                ///Nếu không có tỉ lệ
        //                //if (hoadon.TILESH==null && hoadon.TILEDV==null)
        //                //{
        //                //    if (TieuThu <= DinhMuc)
        //                //    {
        //                //        TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //                //        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                //    }
        //                //    else
        //                //        if (!DieuChinhGia)
        //                //        {
        //                //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[5].DonGia.Value);
        //                //            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                //                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                //        }
        //                //        else
        //                //        {
        //                //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                //            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                //                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //        }
        //                //}
        //                //else
        //                ///Nếu có tỉ lệ SH + DV
        //                //if (SH != 0 && DV != 0)
        //                {
        //                    int _SH = (int)Math.Round((double)TieuThu * SH / 100);
        //                    int _DV = TieuThu - _SH;

        //                    if (_SH <= DinhMuc)
        //                    {
        //                        TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
        //                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                            }
        //                        else
        //                        {
        //                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        }
        //                    TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
        //                    _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                }
        //                break;
        //            case 16:
        //            case 26:///SH + SX + DV
        //                if (hoadon != null)
        //                    ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
        //                    if (SX != 0 && DV != 0 && SH == 0)
        //                    {
        //                        int _SX = (int)Math.Round((double)TieuThu * SX / 100);
        //                        int _DV = TieuThu - _SX;

        //                        TongTien = (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                        _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                    }
        //                    else
        //                    ///Nếu có đủ 3 tỉ lệ SH + SX + DV
        //                    //if (SX != 0 && DV != 0 && SH != 0)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * SH / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * SX / 100);
        //                        int _DV = TieuThu - _SH - _SX;

        //                        if (_SH <= DinhMuc)
        //                        {
        //                            TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
        //                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                        }
        //                        else
        //                            if (!DieuChinhGia)
        //                                if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                {
        //                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
        //                                }
        //                                else
        //                                {
        //                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
        //                                                + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                                }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            }
        //                        TongTien += (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                        _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
        //                                     + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                    }
        //                break;
        //            case 17:
        //            case 27:///SH ĐB
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                }
        //                break;
        //            case 18:
        //            case 28:
        //            case 38:///SH + HCSN
        //                if (hoadon != null)
        //                ///Nếu không có tỉ lệ
        //                //if (hoadon.TILESH==null && hoadon.TILEHCSN==null)
        //                //{
        //                //    if (TieuThu <= DinhMuc)
        //                //    {
        //                //        TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //                //        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                //    }
        //                //    else
        //                //        if (!DieuChinhGia)
        //                //        {
        //                //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[4].DonGia.Value);
        //                //            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                //                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
        //                //        }
        //                //        else
        //                //        {
        //                //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                //            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                //                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //        }
        //                //}
        //                //else
        //                ///Nếu có tỉ lệ SH + HCSN
        //                //if (SH != 0 && HCSN != 0)
        //                {
        //                    int _SH = (int)Math.Round((double)TieuThu * SH / 100);
        //                    int _HCSN = TieuThu - _SH;

        //                    if (_SH <= DinhMuc)
        //                    {
        //                        TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
        //                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                            }
        //                        else
        //                        {
        //                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        }
        //                    TongTien += _HCSN * lstGiaNuoc[4].DonGia.Value;
        //                    _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
        //                }
        //                break;
        //            case 19:
        //            case 29:
        //            case 39:///SH + HCSN + SX + DV
        //                if (hoadon != null)
        //                //if (SH != 0 && HCSN != 0 && SX != 0 && DV != 0)
        //                {
        //                    int _SH = (int)Math.Round((double)TieuThu * SH / 100);
        //                    int _HCSN = (int)Math.Round((double)TieuThu * HCSN / 100);
        //                    int _SX = (int)Math.Round((double)TieuThu * SX / 100);
        //                    int _DV = TieuThu - _SH - _HCSN - _SX;

        //                    if (_SH <= DinhMuc)
        //                    {
        //                        TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
        //                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                            }
        //                        else
        //                        {
        //                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
        //                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        }
        //                    TongTien += (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_DV * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                    _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
        //                                + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
        //                                + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                }
        //                break;
        //            ///TẬP THỂ
        //            //case 21:///SH thuần túy
        //            //    if (TieuThu <= DinhMuc)
        //            //        TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //            //    else
        //            //        if (TieuThu - DinhMuc <= DinhMuc / 2)
        //            //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
        //            //        else
        //            //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + (DinhMuc / 2 * lstGiaNuoc[1].DonGia.Value) + ((TieuThu - DinhMuc - DinhMuc / 2) * lstGiaNuoc[2].DonGia.Value);
        //            //    break;
        //            //case 22:///SX thuần túy
        //            //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
        //            //    break;
        //            //case 23:///DV thuần túy
        //            //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
        //            //    break;
        //            //case 24:///SH + SX
        //            //    hoadon = _cThuTien.GetMoiNhat(DanhBo);
        //            //    if (hoadon != null)
        //            //        ///Nếu không có tỉ lệ
        //            //        if (hoadon.TILESH==null && hoadon.TILESX==null)
        //            //        {

        //            //        }
        //            //    break;
        //            //case 25:///SH + DV

        //            //    break;
        //            //case 26:///SH + SX + DV

        //            //    break;
        //            //case 27:///SH ĐB
        //            //    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
        //            //    break;
        //            //case 28:///SH + HCSN

        //            //    break;
        //            //case 29:///SH + HCSN + SX + DV

        //            //    break;
        //            ///CƠ QUAN
        //            case 31:///SHVM thuần túy
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[4].DonGia.Value;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                }
        //                break;
        //            //case 32:///SX
        //            //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
        //            //    break;
        //            //case 33:///DV
        //            //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
        //            //    break;
        //            case 34:///HCSN + SX
        //                if (hoadon != null)
        //                ///Nếu không có tỉ lệ
        //                //if (hoadon.TILEHCSN==null && hoadon.TILESX==null)
        //                //{
        //                //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
        //                //}
        //                //else
        //                ///Nếu có tỉ lệ
        //                //if (HCSN != 0 && SX != 0)
        //                {
        //                    int _HCSN = (int)Math.Round((double)TieuThu * HCSN / 100);
        //                    int _SX = TieuThu - _HCSN;

        //                    TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
        //                    _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
        //                                + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
        //                }
        //                break;
        //            case 35:///HCSN + DV
        //                if (hoadon != null)
        //                ///Nếu không có tỉ lệ
        //                //if (hoadon.TILEHCSN==null && hoadon.TILESX==null)
        //                //{
        //                //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                //}
        //                //else
        //                ///Nếu có tỉ lệ
        //                //if (HCSN != 0 && DV != 0)
        //                {
        //                    int _HCSN = (int)Math.Round((double)TieuThu * HCSN / 100);
        //                    int _DV = TieuThu - _HCSN;

        //                    TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                    _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
        //                                + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                }
        //                break;
        //            case 36:///HCSN + SX + DV
        //                if (hoadon != null)
        //                //if (HCSN != 0 && SX != 0 && DV != 0)
        //                {
        //                    int _HCSN = (int)Math.Round((double)TieuThu * HCSN / 100);
        //                    int _SX = (int)Math.Round((double)TieuThu * SX / 100);
        //                    int _DV = TieuThu - _HCSN - _SX;

        //                    TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                    _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
        //                                + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
        //                                + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                }
        //                break;
        //            //case 38:///SH + HCSN

        //            //    break;
        //            //case 39:///SH + HCSN + SX + DV

        //            //    break;
        //            ///NƯỚC NGOÀI
        //            case 41:///SHVM thuần túy
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[2].DonGia.Value;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                }
        //                break;
        //            //case 42:///SX
        //            //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
        //            //    break;
        //            //case 43:///DV
        //            //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
        //            //    break;
        //            case 44:///SH + SX
        //                if (hoadon != null)
        //                //if (SH != 0 && SX !=0)
        //                {
        //                    int _SH = (int)Math.Round((double)TieuThu * SH / 100);
        //                    int _SX = TieuThu - _SH;

        //                    TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
        //                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
        //                                + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
        //                }
        //                break;
        //            case 45:///SH + DV

        //                if (hoadon != null)
        //                //if (SH != 0 && DV != 0)
        //                {
        //                    int _SH = (int)Math.Round((double)TieuThu * SH / 100);
        //                    int _DV = TieuThu - _SH;

        //                    TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
        //                                + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                }
        //                break;
        //            case 46:///SH + SX + DV
        //                if (hoadon != null)
        //                //if (SH!= 0 && SX != 0 && DV != 0)
        //                {
        //                    int _SH = (int)Math.Round((double)TieuThu * SH / 100);
        //                    int _SX = (int)Math.Round((double)TieuThu * SX / 100);
        //                    int _DV = TieuThu - _SH - _SX;

        //                    TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
        //                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
        //                                + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
        //                                + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                }
        //                break;
        //            ///BÁN SỈ
        //            case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
        //                //if (TieuThu <= DinhMuc)
        //                //    TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100));
        //                //else
        //                //    if (TieuThu - DinhMuc <= DinhMuc / 2)
        //                //        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100))) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - (lstGiaNuoc[1].DonGia.Value * 10 / 100)));
        //                //    else
        //                //        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100))) + (DinhMuc / 2 * (lstGiaNuoc[1].DonGia.Value - (lstGiaNuoc[1].DonGia.Value * 10 / 100))) + ((TieuThu - DinhMuc - DinhMuc / 2) * (lstGiaNuoc[2].DonGia.Value - (lstGiaNuoc[2].DonGia.Value * 10 / 100)));
        //                if (TieuThu <= DinhMuc)
        //                {
        //                    TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
        //                }
        //                else
        //                    if (!DieuChinhGia)
        //                        if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                        {
        //                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
        //                        }
        //                    else
        //                    {
        //                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                    }
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 52:///sỉ khu công nghiệp
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100));
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                }
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 53:///sỉ KD - TM
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                }
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 54:///sỉ HCSN
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100));
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                }
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 59:///sỉ phức tạp
        //                if (hoadon != null)
        //                //if (SH != 0 && HCSN !=0 && SX != 0 && DV != 0)
        //                {
        //                    int _SH = (int)Math.Round((double)TieuThu * SH / 100);
        //                    int _HCSN = (int)Math.Round((double)TieuThu * HCSN / 100);
        //                    int _SX = (int)Math.Round((double)TieuThu * SX / 100);
        //                    int _DV = TieuThu - _SH - _HCSN - _SX;

        //                    if (_SH <= DinhMuc)
        //                    {
        //                        TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                            {
        //                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
        //                            }
        //                        else
        //                        {
        //                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        }
        //                    TongTien += (_HCSN * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + +(_DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
        //                    _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                 + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                 + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
        //                    //TongTien -= TongTien * 10 / 100;
        //                }
        //                break;
        //            case 68:///SH giá sỉ - KD giá lẻ
        //                if (hoadon != null)
        //                //if (SH != 0 && DV != 0)
        //                {
        //                    int _SH = (int)Math.Round((double)TieuThu * SH / 100);
        //                    int _DV = TieuThu - _SH;

        //                    if (_SH <= DinhMuc)
        //                    {
        //                        TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                            {
        //                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
        //                                _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100))) + "\r\n"
        //                                     + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
        //                            }
        //                        else
        //                        {
        //                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
        //                                 + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        }
        //                    TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
        //                    _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
        //                    //TongTien -= TongTien * 10 / 100;
        //                }
        //                break;
        //            default:
        //                _chiTiet = "";
        //                TongTien = 0;
        //                break;
        //        }
        //        ChiTiet = _chiTiet;
        //        return TongTien;
        //    }
        //    catch (Exception)
        //    {
        //        ChiTiet = "";
        //        return 0;
        //    }
        //}

        //public int TinhTienNuoc(bool DieuChinhGia, int GiaDieuChinh, List<int> lstGiaNuoc, int GiaBieu, int TyLeSH, int TyLeSX, int TyLeDV, int TyLeHCSN, int TongDinhMuc, int DinhMucHN, int TieuThu, out string ChiTiet, out int TieuThu_DieuChinhGia)
        //{
        //    try
        //    {
        //        string _chiTiet = "";
        //        int DinhMuc = TongDinhMuc - DinhMucHN, _SH = 0, _SX = 0, _DV = 0, _HCSN = 0;
        //        TieuThu_DieuChinhGia = 0;
        //        //HOADON hoadon = _cThuTien.Get(DanhBo, Ky, Nam);
        //        //List<GiaNuoc> lstGiaNuoc = db.GiaNuocs.ToList();
        //        ///Table GiaNuoc được thiết lập theo bảng giá nước
        //        ///1. Đến 4m3/người/tháng
        //        ///2. Trên 4m3 đến 6m3/người/tháng
        //        ///3. Trên 6m3/người/tháng
        //        ///4. Đơn vị sản xuất
        //        ///5. Cơ quan, đoàn thể HCSN
        //        ///6. Đơn vị kinh doanh, dịch vụ
        //        ///7. Hộ nghèo, cận nghèo
        //        ///List bắt đầu từ phần tử thứ 0
        //        int TongTien = 0;
        //        switch (GiaBieu)
        //        {
        //            ///TƯ GIA
        //            case 10:
        //                DinhMucHN = TongDinhMuc;
        //                if (TieuThu <= DinhMucHN)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[6];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                }
        //                else
        //                    if (!DieuChinhGia)
        //                        if (TieuThu - DinhMucHN <= Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero))
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                        + ((TieuThu - DinhMucHN) * lstGiaNuoc[1]);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                        + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1])
        //                                        + ((TieuThu - DinhMucHN - (int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + (int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - (int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                        }
        //                    else
        //                    {
        //                        TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                    + ((TieuThu - DinhMucHN) * GiaDieuChinh);
        //                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        if (lstGiaNuoc[6] == GiaDieuChinh)
        //                            TieuThu_DieuChinhGia = TieuThu;
        //                        else
        //                            TieuThu_DieuChinhGia = TieuThu - DinhMucHN;
        //                    }
        //                break;
        //            case 11:
        //            case 21:///SH thuần túy
        //                //if (TieuThu <= DinhMucHN)
        //                //{
        //                //    TongTien = TieuThu * lstGiaNuoc[6];
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                //}
        //                //else
        //                //    if (TieuThu - DinhMucHN <= DinhMuc)
        //                //    {
        //                //        TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                //                    + ((TieuThu - DinhMucHN) * lstGiaNuoc[0]);
        //                //        _chiTiet = (DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                //    }
        //                if (TieuThu <= DinhMucHN + DinhMuc)
        //                {
        //                    double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
        //                    int TieuThuHN = 0, TieuThuDC = 0;
        //                    TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
        //                    TieuThuDC = TieuThu - TieuThuHN;
        //                    TongTien = (TieuThuHN * lstGiaNuoc[6])
        //                                + (TieuThuDC * lstGiaNuoc[0]);
        //                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                + TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                }
        //                else
        //                    if (!DieuChinhGia)
        //                        if (TieuThu - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                        + (DinhMuc * lstGiaNuoc[0])
        //                                        + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                        + (DinhMuc * lstGiaNuoc[0])
        //                                        + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
        //                                        + ((TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                        }
        //                    else
        //                    {
        //                        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0])
        //                                    + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                    + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        if (lstGiaNuoc[0] == GiaDieuChinh)
        //                            TieuThu_DieuChinhGia = TieuThu;
        //                        else
        //                            TieuThu_DieuChinhGia = TieuThu - DinhMucHN - DinhMuc;
        //                    }
        //                break;
        //            case 12:
        //            case 22:
        //            case 32:
        //            case 42:///SX thuần túy
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[3];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                    TieuThu_DieuChinhGia = TieuThu;
        //                }
        //                break;
        //            case 13:
        //            case 23:
        //            case 33:
        //            case 43:///DV thuần túy
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[5];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                    TieuThu_DieuChinhGia = TieuThu;
        //                }
        //                break;
        //            case 14:
        //            case 24:///SH + SX
        //                ///Nếu không có tỉ lệ
        //                if (TyLeSH == 0 && TyLeSX == 0)
        //                {
        //                    //if (TieuThu <= DinhMucHN)
        //                    //{
        //                    //    TongTien = TieuThu * lstGiaNuoc[6];
        //                    //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                    //}
        //                    //else
        //                    //    if (TieuThu - DinhMucHN <= DinhMuc)
        //                    //    {
        //                    //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + ((TieuThu - DinhMucHN) * lstGiaNuoc[0]);
        //                    //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                    //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    //    }
        //                    if (TieuThu <= DinhMucHN + DinhMuc)
        //                    {
        //                        double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
        //                        int TieuThuHN = 0, TieuThuDC = 0;
        //                        TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
        //                        TieuThuDC = TieuThu - TieuThuHN;
        //                        TongTien = (TieuThuHN * lstGiaNuoc[6])
        //                                    + (TieuThuDC * lstGiaNuoc[0]);
        //                        _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[3]);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            if (lstGiaNuoc[0] == GiaDieuChinh)
        //                                TieuThu_DieuChinhGia = TieuThu;
        //                            else
        //                                TieuThu_DieuChinhGia = TieuThu - DinhMucHN - DinhMuc;
        //                        }
        //                }
        //                else
        //                ///Nếu có tỉ lệ SH + SX
        //                {
        //                    //int _SH = 0, _SX = 0;
        //                    if (TyLeSH != 0)
        //                        _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
        //                    _SX = TieuThu - _SH;

        //                    //if (_SH <= DinhMucHN)
        //                    //{
        //                    //    TongTien = _SH * lstGiaNuoc[6];
        //                    //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                    //}
        //                    //else
        //                    //    if (_SH - DinhMucHN <= DinhMuc)
        //                    //    {
        //                    //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (_SH - DinhMucHN * lstGiaNuoc[0]);
        //                    //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                    //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    //    }
        //                    if (_SH <= DinhMucHN + DinhMuc)
        //                    {
        //                        double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
        //                        int TieuThuHN = 0, TieuThuDC = 0;
        //                        TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
        //                        TieuThuDC = _SH - TieuThuHN;
        //                        TongTien = (TieuThuHN * lstGiaNuoc[6])
        //                                    + (TieuThuDC * lstGiaNuoc[0]);
        //                        _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                            if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
        //                            {
        //                                TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                            + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1]) + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                            + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                            + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                            }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            if (lstGiaNuoc[0] == GiaDieuChinh)
        //                                TieuThu_DieuChinhGia = _SH;
        //                            else
        //                                TieuThu_DieuChinhGia = _SH - DinhMucHN - DinhMuc;
        //                        }
        //                    TongTien += _SX * lstGiaNuoc[3];
        //                    _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                }
        //                break;
        //            case 15:
        //            case 25:///SH + DV
        //                ///Nếu không có tỉ lệ
        //                if (TyLeSH == 0 && TyLeDV == 0)
        //                {
        //                    //if (TieuThu <= DinhMucHN)
        //                    //{
        //                    //    TongTien = TieuThu * lstGiaNuoc[6];
        //                    //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                    //}
        //                    //else
        //                    //    if (TieuThu - DinhMucHN <= DinhMuc)
        //                    //    {
        //                    //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (TieuThu * lstGiaNuoc[0]);
        //                    //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                    //                    + TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    //    }
        //                    if (TieuThu <= DinhMucHN + DinhMuc)
        //                    {
        //                        double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
        //                        int TieuThuHN = 0, TieuThuDC = 0;
        //                        TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
        //                        TieuThuDC = TieuThu - TieuThuHN;
        //                        TongTien = (TieuThuHN * lstGiaNuoc[6])
        //                                    + (TieuThuDC * lstGiaNuoc[0]);
        //                        _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[5]);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMucHN - DinhMuc) * GiaDieuChinh);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            if (lstGiaNuoc[0] == GiaDieuChinh)
        //                                TieuThu_DieuChinhGia = TieuThu;
        //                            else
        //                                TieuThu_DieuChinhGia = TieuThu - DinhMucHN - DinhMuc;
        //                        }
        //                }
        //                else
        //                ///Nếu có tỉ lệ SH + DV
        //                {
        //                    //int _SH = 0, _DV = 0;
        //                    if (TyLeSH != 0)
        //                        _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
        //                    _DV = TieuThu - _SH;

        //                    //if (_SH <= DinhMucHN)
        //                    //{
        //                    //    TongTien = _SH * lstGiaNuoc[6];
        //                    //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                    //}
        //                    //else
        //                    //    if (_SH - DinhMucHN <= DinhMuc)
        //                    //    {
        //                    //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (_SH - DinhMucHN * lstGiaNuoc[0]);
        //                    //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6])
        //                    //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    //    }
        //                    if (_SH <= DinhMucHN + DinhMuc)
        //                    {
        //                        double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
        //                        int TieuThuHN = 0, TieuThuDC = 0;
        //                        TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
        //                        TieuThuDC = _SH - TieuThuHN;
        //                        TongTien = (TieuThuHN * lstGiaNuoc[6])
        //                                    + (TieuThuDC * lstGiaNuoc[0]);
        //                        _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                            if (_SH - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
        //                            {
        //                                TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                            + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1]) + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                            + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                            + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                            }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            if (lstGiaNuoc[0] == GiaDieuChinh)
        //                                TieuThu_DieuChinhGia = _SH;
        //                            else
        //                                TieuThu_DieuChinhGia = _SH - DinhMucHN - DinhMuc;
        //                        }
        //                    TongTien += _DV * lstGiaNuoc[5];
        //                    _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                }
        //                break;
        //            case 16:
        //            case 26:///SH + SX + DV
        //                ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
        //                if (TyLeSX != 0 && TyLeDV != 0 && TyLeSH == 0)
        //                {
        //                    if (TyLeSX != 0)
        //                        _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
        //                    _DV = TieuThu - _SX;
        //                    TongTien = (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                    _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                }
        //                else
        //                ///Nếu có đủ 3 tỉ lệ SH + SX + DV
        //                {
        //                    //int _SH = 0, _SX = 0, _DV = 0;
        //                    if (TyLeSH != 0)
        //                        _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
        //                    if (TyLeSX != 0)
        //                        _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
        //                    _DV = TieuThu - _SH - _SX;

        //                    //if (_SH <= DinhMucHN)
        //                    //{
        //                    //    TongTien = _SH * lstGiaNuoc[6];
        //                    //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                    //}
        //                    //else
        //                    //    if (_SH - DinhMucHN <= DinhMuc)
        //                    //    {
        //                    //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (_SH * lstGiaNuoc[0]);
        //                    //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6])
        //                    //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    //    }
        //                    if (_SH <= DinhMucHN + DinhMuc)
        //                    {
        //                        double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
        //                        int TieuThuHN = 0, TieuThuDC = 0;
        //                        TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
        //                        TieuThuDC = _SH - TieuThuHN;
        //                        TongTien = (TieuThuHN * lstGiaNuoc[6])
        //                                    + (TieuThuDC * lstGiaNuoc[0]);
        //                        _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                            if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
        //                            {
        //                                TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * lstGiaNuoc[1]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                            + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1]) + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                            + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                            + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                            }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            if (lstGiaNuoc[0] == GiaDieuChinh)
        //                                TieuThu_DieuChinhGia = _SH;
        //                            else
        //                                TieuThu_DieuChinhGia = _SH - DinhMucHN - DinhMuc;
        //                        }
        //                    TongTien += (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                    _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                 + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                }
        //                break;
        //            case 17:
        //            case 27:///SH ĐB
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[0];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                    TieuThu_DieuChinhGia = TieuThu;
        //                }
        //                break;
        //            case 18:
        //            case 28:
        //            case 38:///SH + HCSN
        //                ///Nếu không có tỉ lệ
        //                if (TyLeSH == 0 && TyLeHCSN == 0)
        //                {
        //                    //if (TieuThu <= DinhMucHN)
        //                    //{
        //                    //    TongTien = TieuThu * lstGiaNuoc[6];
        //                    //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                    //}
        //                    //else
        //                    //    if (TieuThu - DinhMucHN <= DinhMuc)
        //                    //    {
        //                    //        TongTien = (DinhMucHN * lstGiaNuoc[0]) + ((TieuThu - DinhMucHN) * lstGiaNuoc[0]);
        //                    //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6])
        //                    //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    //    }
        //                    if (TieuThu <= DinhMucHN + DinhMuc)
        //                    {
        //                        double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
        //                        int TieuThuHN = 0, TieuThuDC = 0;
        //                        TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
        //                        TieuThuDC = TieuThu - TieuThuHN;
        //                        TongTien = (TieuThuHN * lstGiaNuoc[6])
        //                                    + (TieuThuDC * lstGiaNuoc[0]);
        //                        _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[4]);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMucHN - DinhMuc) * GiaDieuChinh);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            if (lstGiaNuoc[0] == GiaDieuChinh)
        //                                TieuThu_DieuChinhGia = TieuThu;
        //                            else
        //                                TieuThu_DieuChinhGia = TieuThu - DinhMucHN - DinhMuc;
        //                        }
        //                }
        //                else
        //                ///Nếu có tỉ lệ SH + HCSN
        //                {
        //                    //int _SH = 0, _HCSN = 0;
        //                    if (TyLeSH != 0)
        //                        _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
        //                    _HCSN = TieuThu - _SH;

        //                    //if (_SH <= DinhMucHN)
        //                    //{
        //                    //    TongTien = _SH * lstGiaNuoc[6];
        //                    //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                    //}
        //                    //else
        //                    //    if (_SH - DinhMucHN <= DinhMuc)
        //                    //    {
        //                    //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + ((_SH - DinhMucHN) * lstGiaNuoc[0]);
        //                    //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6])
        //                    //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    //    }
        //                    if (_SH <= DinhMucHN + DinhMuc)
        //                    {
        //                        double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
        //                        int TieuThuHN = 0, TieuThuDC = 0;
        //                        TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
        //                        TieuThuDC = _SH - TieuThuHN;
        //                        TongTien = (TieuThuHN * lstGiaNuoc[6])
        //                                    + (TieuThuDC * lstGiaNuoc[0]);
        //                        _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    }
        //                    else
        //                        if (!DieuChinhGia)
        //                            if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
        //                            {
        //                                TongTien = (DinhMucHN * lstGiaNuoc[0]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                            + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                            }
        //                            else
        //                            {
        //                                TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1]) + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                            + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                            + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                            }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            if (lstGiaNuoc[0] == GiaDieuChinh)
        //                                TieuThu_DieuChinhGia = _SH;
        //                            else
        //                                TieuThu_DieuChinhGia = _SH - DinhMucHN - DinhMuc;
        //                        }
        //                    TongTien += _HCSN * lstGiaNuoc[4];
        //                    _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
        //                }
        //                break;
        //            case 19:
        //            case 29:
        //            case 39:///SH + HCSN + SX + DV
        //                //int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
        //                if (TyLeSH != 0)
        //                    _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
        //                if (TyLeHCSN != 0)
        //                    _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
        //                if (TyLeSX != 0)
        //                    _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
        //                _DV = TieuThu - _SH - _HCSN - _SX;

        //                //if (_SH <= DinhMucHN)
        //                //{
        //                //    TongTien = _SH * lstGiaNuoc[6];
        //                //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                //}
        //                //else
        //                //    if (_SH - DinhMucHN <= DinhMuc)
        //                //    {
        //                //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + ((_SH - DinhMucHN) * lstGiaNuoc[0]);
        //                //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                //    }
        //                if (_SH <= DinhMucHN + DinhMuc)
        //                {
        //                    double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
        //                    int TieuThuHN = 0, TieuThuDC = 0;
        //                    TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
        //                    TieuThuDC = _SH - TieuThuHN;
        //                    TongTien = (TieuThuHN * lstGiaNuoc[6])
        //                                + (TieuThuDC * lstGiaNuoc[0]);
        //                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                + TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                }
        //                else
        //                    if (!DieuChinhGia)
        //                        if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1]) + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                        + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                        }
        //                    else
        //                    {
        //                        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh);
        //                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                    + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        if (lstGiaNuoc[0] == GiaDieuChinh)
        //                            TieuThu_DieuChinhGia = _SH;
        //                        else
        //                            TieuThu_DieuChinhGia = _SH - DinhMucHN - DinhMuc;
        //                    }
        //                TongTien += (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
        //                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                break;
        //            ///TẬP THỂ
        //            //case 21:///SH thuần túy
        //            //    if (TieuThu <= DinhMuc)
        //            //        TongTien = TieuThu * lstGiaNuoc[0];
        //            //    else
        //            //        if (TieuThu - DinhMuc <= DinhMuc / 2)
        //            //            TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[1]);
        //            //        else
        //            //            TongTien = (DinhMuc * lstGiaNuoc[0]) + (DinhMuc / 2 * lstGiaNuoc[1]) + ((TieuThu - DinhMuc - DinhMuc / 2) * lstGiaNuoc[2]);
        //            //    break;
        //            //case 22:///SX thuần túy
        //            //    TongTien = TieuThu * lstGiaNuoc[3];
        //            //    break;
        //            //case 23:///DV thuần túy
        //            //    TongTien = TieuThu * lstGiaNuoc[5];
        //            //    break;
        //            //case 24:///SH + SX
        //            //    hoadon = _cThuTien.GetMoiNhat(DanhBo);
        //            //    if (hoadon != null)
        //            //        ///Nếu không có tỉ lệ
        //            //        if (hoadon.TILESH==null && hoadon.TILESX==null)
        //            //        {

        //            //        }
        //            //    break;
        //            //case 25:///SH + DV

        //            //    break;
        //            //case 26:///SH + SX + DV

        //            //    break;
        //            //case 27:///SH ĐB
        //            //    TongTien = TieuThu * lstGiaNuoc[0];
        //            //    break;
        //            //case 28:///SH + HCSN

        //            //    break;
        //            //case 29:///SH + HCSN + SX + DV

        //            //    break;
        //            ///CƠ QUAN
        //            case 31:///SHVM thuần túy
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[4];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                    TieuThu_DieuChinhGia = TieuThu;
        //                }
        //                break;
        //            //case 32:///SX
        //            //    TongTien = TieuThu * lstGiaNuoc[3];
        //            //    break;
        //            //case 33:///DV
        //            //    TongTien = TieuThu * lstGiaNuoc[5];
        //            //    break;
        //            case 34:///HCSN + SX
        //                ///Nếu không có tỉ lệ
        //                if (TyLeHCSN == 0 && TyLeSX == 0)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[3];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                }
        //                else
        //                ///Nếu có tỉ lệ
        //                {
        //                    //int _HCSN = 0, _SX = 0;
        //                    if (TyLeHCSN != 0)
        //                        _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
        //                    _SX = TieuThu - _HCSN;

        //                    TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]);
        //                    _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
        //                                + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                }
        //                break;
        //            case 35:///HCSN + DV
        //                ///Nếu không có tỉ lệ
        //                if (TyLeHCSN == 0 && TyLeDV == 0)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[5];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                }
        //                else
        //                ///Nếu có tỉ lệ
        //                {
        //                    //int _HCSN = 0, _DV = 0;
        //                    if (TyLeHCSN != 0)
        //                        _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
        //                    _DV = TieuThu - _HCSN;

        //                    TongTien = (_HCSN * lstGiaNuoc[4]) + (_DV * lstGiaNuoc[5]);
        //                    _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
        //                                + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                }
        //                break;
        //            case 36:///HCSN + SX + DV
        //                {
        //                    //int _HCSN = 0, _SX = 0, _DV = 0;
        //                    if (TyLeHCSN != 0)
        //                        _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
        //                    if (TyLeSX != 0)
        //                        _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
        //                    _DV = TieuThu - _HCSN - _SX;

        //                    TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                    _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
        //                                + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                }
        //                break;
        //            //case 38:///SH + HCSN

        //            //    break;
        //            //case 39:///SH + HCSN + SX + DV

        //            //    break;
        //            ///NƯỚC NGOÀI
        //            case 41:///SHVM thuần túy
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * lstGiaNuoc[2];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * GiaDieuChinh;
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                    TieuThu_DieuChinhGia = TieuThu;
        //                }
        //                break;
        //            //case 42:///SX
        //            //    TongTien = TieuThu * lstGiaNuoc[3];
        //            //    break;
        //            //case 43:///DV
        //            //    TongTien = TieuThu * lstGiaNuoc[5];
        //            //    break;
        //            case 44:///SH + SX
        //                {
        //                    //int _SH = 0, _SX = 0;
        //                    if (TyLeSH != 0)
        //                        _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
        //                    _SX = TieuThu - _SH;

        //                    TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]);
        //                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]) + "\r\n"
        //                                + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                }
        //                break;
        //            case 45:///SH + DV
        //                //int _SH = 0, _DV = 0;
        //                if (TyLeSH != 0)
        //                    _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
        //                _DV = TieuThu - _SH;

        //                TongTien = (_SH * lstGiaNuoc[2]) + (_DV * lstGiaNuoc[5]);
        //                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]) + "\r\n"
        //                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                break;
        //            case 46:///SH + SX + DV
        //                {
        //                    //int _SH = 0, _SX = 0, _DV = 0;
        //                    if (TyLeSH != 0)
        //                        _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
        //                    if (TyLeSX != 0)
        //                        _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
        //                    _DV = TieuThu - _SH - _SX;

        //                    TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]) + "\r\n"
        //                                + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                }
        //                break;
        //            ///BÁN SỈ
        //            case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
        //                //if (TieuThu <= DinhMuc)
        //                //    TongTien = TieuThu * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100));
        //                //else
        //                //    if (TieuThu - DinhMuc <= DinhMuc / 2)
        //                //        TongTien = (DinhMuc * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100))) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1] - (lstGiaNuoc[1] * 10 / 100)));
        //                //    else
        //                //        TongTien = (DinhMuc * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100))) + (DinhMuc / 2 * (lstGiaNuoc[1] - (lstGiaNuoc[1] * 10 / 100))) + ((TieuThu - DinhMuc - DinhMuc / 2) * (lstGiaNuoc[2] - (lstGiaNuoc[2] * 10 / 100)));
        //                //if (TieuThu <= DinhMucHN)
        //                //{
        //                //    TongTien = TieuThu * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100);
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
        //                //}
        //                //else
        //                //    if (TieuThu - DinhMucHN <= DinhMuc)
        //                //    {
        //                //        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (TieuThu - DinhMucHN * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
        //                //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                //    }
        //                if (TieuThu <= DinhMucHN + DinhMuc)
        //                {
        //                    double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
        //                    int TieuThuHN = 0, TieuThuDC = 0;
        //                    TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
        //                    TieuThuDC = TieuThu - TieuThuHN;
        //                    TongTien = (TieuThuHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
        //                                + (TieuThuDC * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                + TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                }
        //                else
        //                    if (!DieuChinhGia)
        //                        if (TieuThu - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
        //                        {
        //                            TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + ((TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                        }
        //                    else
        //                    {
        //                        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((TieuThu - DinhMucHN - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        _chiTiet = +DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                    + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        if (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100 == GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
        //                            TieuThu_DieuChinhGia = TieuThu;
        //                        else
        //                            TieuThu_DieuChinhGia = TieuThu - DinhMucHN - DinhMuc;
        //                    }
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 52:///sỉ khu công nghiệp
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100));
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                    TieuThu_DieuChinhGia = TieuThu;
        //                }
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 53:///sỉ KD - TM
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                    TieuThu_DieuChinhGia = TieuThu;
        //                }
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 54:///sỉ HCSN
        //                if (!DieuChinhGia)
        //                {
        //                    TongTien = TieuThu * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100));
        //                }
        //                else
        //                {
        //                    TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                    TieuThu_DieuChinhGia = TieuThu;
        //                }
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 58:
        //                //int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
        //                if (TyLeSH != 0)
        //                    _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
        //                if (TyLeHCSN != 0)
        //                    _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
        //                if (TyLeSX != 0)
        //                    _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
        //                _DV = TieuThu - _SH - _HCSN - _SX;

        //                TongTien += (_SH * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
        //                            + (_HCSN * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100))
        //                            + (_SX * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100))
        //                            + (_DV * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                _chiTiet += _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                             + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)) + "\r\n"
        //                             + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)) + "\r\n"
        //                             + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                break;
        //            case 59:///sỉ phức tạp
        //                //int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
        //                if (TyLeSH != 0)
        //                    _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
        //                if (TyLeHCSN != 0)
        //                    _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
        //                if (TyLeSX != 0)
        //                    _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
        //                _DV = TieuThu - _SH - _HCSN - _SX;

        //                //if (_SH <= DinhMucHN)
        //                //{
        //                //    TongTien = _SH * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100);
        //                //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
        //                //}
        //                //else
        //                //    if (_SH - DinhMucHN <= DinhMuc)
        //                //    {
        //                //        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (_SH - DinhMucHN * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                //    }
        //                if (_SH <= DinhMucHN + DinhMuc)
        //                {
        //                    double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
        //                    int TieuThuHN = 0, TieuThuDC = 0;
        //                    TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
        //                    TieuThuDC = _SH - TieuThuHN;
        //                    TongTien = (TieuThuHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
        //                                + (TieuThuDC * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                + TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                }
        //                else
        //                    if (!DieuChinhGia)
        //                        if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
        //                        {
        //                            TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((_SH - DinhMucHN - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                        }
        //                    else
        //                    {
        //                        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((_SH - DinhMucHN - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                    + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        if (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100 == GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
        //                            TieuThu_DieuChinhGia = _SH;
        //                        else
        //                            TieuThu_DieuChinhGia = _SH - DinhMucHN - DinhMuc;
        //                    }
        //                TongTien += (_HCSN * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)) + (_DV * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)) + "\r\n"
        //                             + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)) + "\r\n"
        //                             + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            case 68:///SH giá sỉ - KD giá lẻ
        //                //int _SH = 0, _DV = 0;
        //                if (TyLeSH != 0)
        //                    _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
        //                _DV = TieuThu - _SH;

        //                //if (_SH <= DinhMucHN)
        //                //{
        //                //    TongTien = _SH * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100);
        //                //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
        //                //}
        //                //else
        //                //    if (_SH - DinhMucHN <= DinhMuc)
        //                //    {
        //                //        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + ((_SH - DinhMucHN) * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
        //                //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                //    }
        //                if (_SH <= DinhMucHN + DinhMuc)
        //                {
        //                    double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
        //                    int TieuThuHN = 0, TieuThuDC = 0;
        //                    TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
        //                    TieuThuDC = _SH - TieuThuHN;
        //                    TongTien = (TieuThuHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
        //                                + (TieuThuDC * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                + TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                }
        //                else
        //                    if (!DieuChinhGia)
        //                        if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
        //                        {
        //                            TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((_SH - DinhMucHN - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                        }
        //                        else
        //                        {
        //                            TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                        }
        //                    else
        //                    {
        //                        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((_SH - DinhMucHN - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                    + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        if (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100 == GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
        //                            TieuThu_DieuChinhGia = _SH;
        //                        else
        //                            TieuThu_DieuChinhGia = _SH - DinhMuc;
        //                    }
        //                TongTien += _DV * lstGiaNuoc[5];
        //                _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                //TongTien -= TongTien * 10 / 100;
        //                break;
        //            default:
        //                _chiTiet = "";
        //                TongTien = 0;
        //                break;
        //        }
        //        ChiTiet = _chiTiet;
        //        return TongTien;
        //    }
        //    catch (Exception)
        //    {
        //        ChiTiet = "";
        //        TieuThu_DieuChinhGia = 0;
        //        return 0;
        //    }
        //}

        //public void TinhTienNuoc(bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int Ky, int Nam, DateTime TuNgay, DateTime DenNgay, int GiaBieu, int TyLeSH, int TyLeSX, int TyLeDV, int TyLeHCSN, int TongDinhMuc, int DinhMucHN, int TieuThu, out int TienNuocCu, out string ChiTietCu, out int TienNuocMoi, out string ChiTietMoi, out int TieuThu_DieuChinhGia)
        //{
        //    List<GiaNuoc2> lst = _dbKinhDoanh.GiaNuoc2s.ToList();
        //    int index = -1;
        //    TienNuocCu = TienNuocMoi = 0;
        //    ChiTietCu = ChiTietMoi = "";
        //    TieuThu_DieuChinhGia = 0;
        //    for (int i = 0; i < lst.Count; i++)
        //        if (TuNgay.Date < lst[i].NgayTangGia.Value.Date && lst[i].NgayTangGia.Value.Date < DenNgay.Date)
        //        {
        //            index = i;
        //        }
        //        else
        //            if (TuNgay.Date >= lst[i].NgayTangGia.Value.Date)
        //            {
        //                index = i;
        //            }
        //    if (index != -1)
        //    {
        //        if (DenNgay.Date < new DateTime(2019, 11, 15))
        //        {
        //            //int TieuThu_DieuChinhGia;
        //            List<int> lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
        //            TienNuocCu = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuoc, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, 0, TieuThu, out ChiTietCu, out TieuThu_DieuChinhGia);
        //        }
        //        else
        //            if (TuNgay.Date < lst[index].NgayTangGia.Value.Date && lst[index].NgayTangGia.Value.Date < DenNgay.Date)
        //            {
        //                //int TieuThu_DieuChinhGia;
        //                int TongSoNgay = (int)((DenNgay.Date - TuNgay.Date).TotalDays);

        //                int SoNgayCu = (int)((lst[index].NgayTangGia.Value.Date - TuNgay.Date).TotalDays);
        //                int TieuThuCu = (int)Math.Round((double)TieuThu * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
        //                int TieuThuMoi = TieuThu - TieuThuCu;
        //                int TongDinhMucCu = (int)Math.Round((double)TongDinhMuc * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
        //                int TongDinhMucMoi = TongDinhMuc - TongDinhMucCu;
        //                int DinhMucHN_Cu = 0, DinhMucHN_Moi = 0;
        //                if (TuNgay.Date > new DateTime(2019, 11, 15))
        //                    if (TongDinhMucCu != 0 && DinhMucHN != 0 && TongDinhMuc != 0)
        //                        DinhMucHN_Cu = (int)Math.Round((double)TongDinhMucCu * DinhMucHN / TongDinhMuc, 0, MidpointRounding.AwayFromZero);
        //                if (TongDinhMucMoi != 0 && DinhMucHN != 0 && TongDinhMuc != 0)
        //                    DinhMucHN_Moi = (int)Math.Round((double)TongDinhMucMoi * DinhMucHN / TongDinhMuc, 0, MidpointRounding.AwayFromZero);
        //                List<int> lstGiaNuocCu = new List<int> { lst[index - 1].SHTM.Value, lst[index - 1].SHVM1.Value, lst[index - 1].SHVM2.Value, lst[index - 1].SX.Value, lst[index - 1].HCSN.Value, lst[index - 1].KDDV.Value, lst[index - 1].SHN.Value };
        //                List<int> lstGiaNuocMoi = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
        //                //lần đầu áp dụng giá biểu 10, tổng áp giá mới luôn
        //                if (TuNgay.Date < new DateTime(2019, 11, 15) && new DateTime(2019, 11, 15) < DenNgay.Date && GiaBieu == 10)
        //                    TienNuocCu = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuocMoi, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucCu, DinhMucHN_Cu, TieuThuCu, out ChiTietCu, out TieuThu_DieuChinhGia);
        //                else
        //                    TienNuocCu = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuocCu, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucCu, DinhMucHN_Cu, TieuThuCu, out ChiTietCu, out TieuThu_DieuChinhGia);
        //                TienNuocMoi = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuocMoi, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucMoi, DinhMucHN_Moi, TieuThuMoi, out ChiTietMoi, out TieuThu_DieuChinhGia);
        //            }
        //            else
        //            {
        //                //int TieuThu_DieuChinhGia;
        //                List<int> lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
        //                TienNuocCu = TinhTienNuoc(DieuChinhGia, 0, lstGiaNuoc, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, DinhMucHN, TieuThu, out ChiTietCu, out TieuThu_DieuChinhGia);
        //            }
        //    }
        //    else
        //    {

        //    }
        //}

        public DonKH GetDonKHbyID(decimal MaDon)
        {
            return _dbKinhDoanh.DonKHs.SingleOrDefault(itemDonKH => itemDonKH.MaDon == MaDon);
        }

        public DonTXL GetDonTXLbyID(decimal MaDon)
        {
            return _dbKinhDoanh.DonTXLs.SingleOrDefault(itemDonTXL => itemDonTXL.MaDon == MaDon);
        }

        public DCBD_ChiTietHoaDon get_HoaDon(decimal SoPhieu)
        {
            return _dbKinhDoanh.DCBD_ChiTietHoaDons.SingleOrDefault(item => item.MaCTDCHD == SoPhieu);
        }

        public DataTable getTong_HoaDon(string DanhBo, int Nam, int Ky)
        {
            string sql = "select TieuThu=sum(TieuThu_BD)-sum(TieuThu),GiaBan=sum(TienNuoc_BD),ThueGTGT=sum(ThueGTGT_BD),PhiBVMT=sum(PhiBVMT_BD),PhiBVMT_Thue=sum(PhiBVMT_Thue_BD)"
                + " from DCBD_ChiTietHoaDon where DanhBo = '" + DanhBo + "' and Nam = " + Nam + " and Ky = " + Ky + " and PhieuDuocKy=1"
                + " group by DanhBo,Nam,Ky";
                return ExecuteQuery_DataTable(sql);
            //var query = from item in _dbKinhDoanh.DCBD_ChiTietHoaDons
            //            where item.DanhBo == DanhBo && item.Nam == Nam && item.Ky == Ky
            //            group item by new { item.DanhBo, item.Nam, item.Ky } into itemGroup
            //            select new
            //            {
            //                TieuThu = itemGroup.Sum(groupItem => groupItem.TieuThu) - itemGroup.Sum(groupItem => groupItem.TieuThu_BD),
            //                GiaBan = itemGroup.Sum(groupItem => groupItem.TienNuoc_BD),
            //                ThueGTGT = itemGroup.Sum(groupItem => groupItem.ThueGTGT_BD),
            //                PhiBVMT = itemGroup.Sum(groupItem => groupItem.PhiBVMT_BD),
            //            };
            //return LINQToDataTable(query.ToList());
        }

        public DCBD_ChiTietBienDong get_BienDong(string DanhBo)
        {
            if (_dbKinhDoanh.DCBD_ChiTietBienDongs.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date >= DateTime.Now.AddDays(-31).Date))
                return _dbKinhDoanh.DCBD_ChiTietBienDongs.Where(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date >= DateTime.Now.AddDays(-31).Date).OrderByDescending(item => item.CreateDate).First();
            else
                return null;
        }

        public decimal getLastMaCatHuy(string DanhBo)
        {
            try
            {
                string sql = "select top 1 MaCTCHDB from CHDB_ChiTietCatHuy where DanhBo='" + DanhBo + "' order by CreateDate desc";
                return (decimal)ExecuteQuery_ReturnOneValue(sql);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string getDanhBo_CatTam(int ID)
        {
            return (string)ExecuteQuery_ReturnOneValue("select DanhBo from CHDB_ChiTietCatTam where MaCTCTDB=" + ID);
        }

        public string getDanhBo_CatHuy(int ID)
        {
            return (string)ExecuteQuery_ReturnOneValue("select DanhBo from CHDB_ChiTietCatHuy where MaCTCHDB=" + ID);
        }

        public bool checkExists_KhauTru(string DanhBo)
        {
            return _dbKinhDoanh.DCBD_KhauTrus.Any(item => item.DanhBo == DanhBo && item.TatToan == false);
            //int i = (int)ExecuteQuery_ReturnOneValue("select count (*) from DCBD_KhauTru where DanhBo='" + DanhBo + "' and TatToan=0");
            //if (i == 0)
            //    return false;
            //else
            //    return true;
        }

        public string getPhuong(int MaQuan, int MaPhuong)
        {
            return (string)ExecuteQuery_ReturnOneValue("select Name2 from Phuong where IDQuan=" + MaQuan + " and IDPhuong=" + MaPhuong);
        }

        public string getQuan(int MaQuan)
        {
            return (string)ExecuteQuery_ReturnOneValue("select Name2 from Quan where ID=" + MaQuan);
        }

    }
}
