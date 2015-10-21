using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ThuTien.LinQ;

namespace ThuTien.DAL
{
    class CKTKS_DonKH
    {
        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn
        //protected SqlTransaction transaction;       // Đối tượng transaction
        dbKTKS_DonKHDataContext _dbKTKS_DonKH = new dbKTKS_DonKHDataContext();

        public CKTKS_DonKH()
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

        /// <summary>
        /// Thực thi câu truy vấn SQL trả về một đối tượng DataSet chứa kết quả trả về
        /// </summary>
        /// <param name="strSelect">Câu truy vấn cần thực thi lấy dữ liệu</param>
        /// <returns>Đối tượng dataset chứa dữ liệu kết quả câu truy vấn</returns>
        public DataSet ExecuteQuery_SqlDataAdapter_DataSet(string sql)
        {
            try
            {
                Connect();
                DataSet dataset = new DataSet();
                command = new SqlCommand();
                command.Connection = this.connection;
                adapter = new SqlDataAdapter(sql, connection);
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Thực thi câu truy vấn SQL trả về một đối tượng DataTable chứa kết quả trả về
        /// </summary>
        /// <param name="strSelect">Câu truy vấn cần thực thi lấy dữ liệu</param>
        /// <returns>Đối tượng datatable chứa dữ liệu kết quả câu truy vấn</returns>
        public DataTable ExecuteQuery_SqlDataAdapter_DataTable(string sql)
        {

            try
            {
                return ExecuteQuery_SqlDataAdapter_DataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                Disconnect();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSP_KinhDoanh(string DanhBo)
        {
            string sqlKTXM = "select Loai=N'Kiểm Tra Xác Minh',NoiDungKiemTra as NoiDung,CreateDate,'Table'='CTKTXM','Column'='MaCTKTXM',MaCTKTXM as Ma,ThuTien_Nhan,ThuTien_NgayNhan from CTKTXM where DanhBo='" + DanhBo + "'";
            string sqlDCBD = "select Loai=N'Điều Chỉnh Biến Động',ThongTin as NoiDung,CreateDate,'Table'='CTDCBD','Column'='MaCTDCBD',MaCTDCBD as Ma,ThuTien_Nhan,ThuTien_NgayNhan from CTDCBD where DanhBo='" + DanhBo + "'";
            string sqlDCHD = "select Loai=N'Điểu Chỉnh Hóa Đơn',TangGiam as NoiDung,CreateDate,'Table'='CTDCHD','Column'='MaCTDCHD',MaCTDCHD as Ma,ThuTien_Nhan,ThuTien_NgayNhan from CTDCHD where DanhBo='" + DanhBo + "'";
            string sqlCTDB = "select Loai=N'TB Cắt Tạm Danh Bộ',LyDo+'. '+GhiChuLyDo as NoiDung,CreateDate,'Table'='CTCTDB','Column'='MaCTCTDB',MaCTCTDB as Ma,ThuTien_Nhan,ThuTien_NgayNhan from CTCTDB where DanhBo='" + DanhBo + "'";
            string sqlCHDB = "select Loai=N'TB Cắt Hủy Danh Bộ',LyDo+'. '+GhiChuLyDo as NoiDung,CreateDate,'Table'='CTCHDB','Column'='MaCTCHDB',MaCTCHDB as Ma,ThuTien_Nhan,ThuTien_NgayNhan from CTCHDB where DanhBo='" + DanhBo + "'";
            string sqlYCCHDB = "select Loai=N'Phiếu Yêu Cầu Cắt Hủy Danh Bộ',LyDo+'. '+GhiChuLyDo as NoiDung,CreateDate,'Table'='YeuCauCHDB','Column'='MaYCCHDB',MaYCCHDB as Ma,ThuTien_Nhan,ThuTien_NgayNhan from YeuCauCHDB where DanhBo='" + DanhBo + "'";
            string sqlTTTL = "select Loai=N'Thư Trả Lời',NoiDung,CreateDate,'Table'='CTTTTL','Column'='MaCTTTTL',MaCTTTTL as Ma,ThuTien_Nhan,ThuTien_NgayNhan from CTTTTL where DanhBo='" + DanhBo + "'";

            DataTable dt = ExecuteQuery_SqlDataAdapter_DataTable(sqlKTXM);
            dt.Merge(ExecuteQuery_SqlDataAdapter_DataTable(sqlDCBD));
            dt.Merge(ExecuteQuery_SqlDataAdapter_DataTable(sqlDCHD));
            dt.Merge(ExecuteQuery_SqlDataAdapter_DataTable(sqlCTDB));
            dt.Merge(ExecuteQuery_SqlDataAdapter_DataTable(sqlCHDB));
            dt.Merge(ExecuteQuery_SqlDataAdapter_DataTable(sqlYCCHDB));
            dt.Merge(ExecuteQuery_SqlDataAdapter_DataTable(sqlTTTL));
            dt.DefaultView.Sort = "CreateDate desc";
            return dt.DefaultView.ToTable();
        }

        public TTKhachHang getTTKHbyID(string DanhBo)
        {
            try
            {
                return _dbKTKS_DonKH.TTKhachHangs.SingleOrDefault(itemTTKH => itemTTKH.DanhBo == DanhBo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Công thức tính tiền nước theo giá biểu
        /// </summary>
        /// <param name="DieuChinhGia">true là điều chỉnh giá/ false là không</param>
        /// <param name="GiaDieuChinh"></param>
        /// <param name="DanhBo">Danh Bộ được dùng để lấy LNSH,LNSX,LNDV,LNHCSN</param>
        /// <param name="GiaBieu"></param>
        /// <param name="DinhMuc"></param>
        /// <param name="TieuThu"></param>
        /// <param name="ChiTiet"></param>
        /// <returns></returns>
        public int TinhTienNuoc(bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int GiaBieu, int DinhMuc, int TieuThu, out string ChiTiet)
        {
            try
            {
                int GiamTienNuoc = 10;
                string _chiTiet = "";
                TTKhachHang ttkhachhang = null;
                List<GiaNuoc> lstGiaNuoc = _dbKTKS_DonKH.GiaNuocs.ToList();
                ///Table GiaNuoc được thiết lập theo bảng giá nước
                ///1. Đến 4m3/người/tháng
                ///2. Trên 4m3 đến 6m3/người/tháng
                ///3. Trên 6m3/người/tháng
                ///4. Đơn vị sản xuất
                ///5. Cơ quan, đoàn thể LNHCSN
                ///6. Đơn vị kinh doanh, dịch vụ
                ///List bắt đầu từ phần tử thứ 0
                int TongTien = 0;
                switch (GiaBieu)
                {
                    ///TƯ GIA
                    case 11:
                    case 21:///LNSH thuần túy
                        if (TieuThu <= DinhMuc)
                        {
                            TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                }
                                else
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                }
                            else
                            {
                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            }
                        break;
                    case 12:
                    case 22:
                    case 32:
                    case 42:///LNSX thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        }
                        break;
                    case 13:
                    case 23:
                    case 33:
                    case 43:///LNDV thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        }
                        break;
                    case 14:
                    case 24:///LNSH + LNSX
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.LNSH.Trim() == "" && ttkhachhang.LNSX.Trim() == "")
                            {
                                if (TieuThu <= DinhMuc)
                                {
                                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[3].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                   + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                   + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                    }
                            }
                            else
                                ///Nếu có tỉ lệ LNSH + LNSX
                                if (ttkhachhang.LNSH.Trim() != "" && ttkhachhang.LNSX.Trim() != "")
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSH.Trim()) / 100);
                                    int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSX.Trim()) / 100);
                                    if (_SH <= DinhMuc)
                                    {
                                        TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                    }
                                    else
                                        if (!DieuChinhGia)
                                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                            }
                                            else
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                            }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        }
                                    TongTien += _SX * lstGiaNuoc[3].DonGia.Value;
                                    _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                                }
                        break;
                    case 15:
                    case 25:///LNSH + LNDV
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.LNSH.Trim() == "" && ttkhachhang.LNDV.Trim() == "")
                            {
                                if (TieuThu <= DinhMuc)
                                {
                                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[5].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                    }
                            }
                            else
                                ///Nếu có tỉ lệ LNSH + LNDV
                                if (ttkhachhang.LNSH.Trim() != "" && ttkhachhang.LNDV.Trim() != "")
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSH.Trim()) / 100);
                                    int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNDV.Trim()) / 100);
                                    if (_SH <= DinhMuc)
                                    {
                                        TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                    }
                                    else
                                        if (!DieuChinhGia)
                                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                            }
                                            else
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                            }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        }
                                    TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
                                    _chiTiet += _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                                }
                        break;
                    case 16:
                    case 26:///LNSH + LNSX + LNDV
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu chỉ có tỉ lệ LNSX + LNDV mà không có tỉ lệ LNSH, không xét Định Mức
                            if (ttkhachhang.LNSX.Trim() != "" && ttkhachhang.LNDV.Trim() != "" && ttkhachhang.LNSH.Trim() == "")
                            {
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNDV.Trim()) / 100);
                                TongTien = (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                            else
                                ///Nếu có đủ 3 tỉ lệ LNSH + LNSX + LNDV
                                if (ttkhachhang.LNSX.Trim() != "" && ttkhachhang.LNDV.Trim() != "" && ttkhachhang.LNSH.Trim() != "")
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSH.Trim()) / 100);
                                    int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSX.Trim()) / 100);
                                    int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNDV.Trim()) / 100);
                                    if (_SH <= DinhMuc)
                                    {
                                        TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                    }
                                    else
                                        if (!DieuChinhGia)
                                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                            }
                                            else
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                            }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        }
                                    TongTien += (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                    _chiTiet += _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                                 + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                                }
                        break;
                    case 17:
                    case 27:///LNSH ĐB
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        }
                        break;
                    case 18:
                    case 28:
                    case 38:///LNSH + LNHCSN
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.LNSH.Trim() == "" && ttkhachhang.LNHCSN.Trim() == "")
                            {
                                if (TieuThu <= DinhMuc)
                                {
                                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[4].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                    }
                            }
                            else
                                ///Nếu có tỉ lệ LNSH + LNHCSN
                                if (ttkhachhang.LNSH.Trim() != "" && ttkhachhang.LNHCSN.Trim() != "")
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSH.Trim()) / 100);
                                    int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNHCSN.Trim()) / 100);
                                    if (_SH <= DinhMuc)
                                    {
                                        TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                    }
                                    else
                                        if (!DieuChinhGia)
                                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                            }
                                            else
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                            }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        }
                                    TongTien += _HCSN * lstGiaNuoc[4].DonGia.Value;
                                    _chiTiet += _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
                                }
                        break;
                    case 19:
                    case 29:
                    case 39:///LNSH + LNHCSN + LNSX + LNDV
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.LNSH.Trim() != "" && ttkhachhang.LNHCSN.Trim() != "" && ttkhachhang.LNSX.Trim() != "" && ttkhachhang.LNDV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSH.Trim()) / 100);
                                int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNHCSN.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNDV.Trim()) / 100);
                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                    }
                                TongTien += (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet += _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    ///TẬP THỂ
                    //case 21:///LNSH thuần túy
                    //    if (TieuThu <= DinhMuc)
                    //        TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                    //    else
                    //        if (TieuThu - DinhMuc <= DinhMuc / 2)
                    //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                    //        else
                    //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + (DinhMuc / 2 * lstGiaNuoc[1].DonGia.Value) + ((TieuThu - DinhMuc - DinhMuc / 2) * lstGiaNuoc[2].DonGia.Value);
                    //    break;
                    //case 22:///LNSX thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                    //    break;
                    //case 23:///LNDV thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                    //    break;
                    //case 24:///LNSH + LNSX
                    //    ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                    //    if (ttkhachhang != null)
                    //        ///Nếu không có tỉ lệ
                    //        if (ttkhachhang.LNSH.Trim() == "" && ttkhachhang.LNSX.Trim() == "")
                    //        {

                    //        }
                    //    break;
                    //case 25:///LNSH + LNDV

                    //    break;
                    //case 26:///LNSH + LNSX + LNDV

                    //    break;
                    //case 27:///LNSH ĐB
                    //    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                    //    break;
                    //case 28:///LNSH + LNHCSN

                    //    break;
                    //case 29:///LNSH + LNHCSN + LNSX + LNDV

                    //    break;
                    ///CƠ QUAN
                    case 31:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[4].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        }
                        break;
                    //case 32:///LNSX
                    //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                    //    break;
                    //case 33:///LNDV
                    //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                    //    break;
                    case 34:///LNHCSN + LNSX
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.LNHCSN.Trim() != "" && ttkhachhang.LNSX.Trim() != "")
                            {
                                int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNHCSN.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSX.Trim()) / 100);
                                TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                            }
                        break;
                    case 35:///LNHCSN + LNDV
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.LNHCSN.Trim() != "" && ttkhachhang.LNDV.Trim() != "")
                            {
                                int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNHCSN.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNDV.Trim()) / 100);
                                TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    case 36:///LNHCSN + LNSX + LNDV
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.LNHCSN.Trim() != "" && ttkhachhang.LNSX.Trim() != "" && ttkhachhang.LNDV.Trim() != "")
                            {
                                int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNHCSN.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNDV.Trim()) / 100);
                                TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    //case 38:///LNSH + LNHCSN

                    //    break;
                    //case 39:///LNSH + LNHCSN + LNSX + LNDV

                    //    break;
                    ///NƯỚC NGOÀI
                    case 41:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[2].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        }
                        break;
                    //case 42:///LNSX
                    //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                    //    break;
                    //case 43:///LNDV
                    //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                    //    break;
                    case 44:///LNSH + LNSX
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.LNSH.Trim() != "" && ttkhachhang.LNSX.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSH.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSX.Trim()) / 100);
                                TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                            }
                        break;
                    case 45:///LNSH + LNDV
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.LNSH.Trim() != "" && ttkhachhang.LNDV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSH.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNDV.Trim()) / 100);
                                TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    case 46:///LNSH + LNSX + LNDV
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.LNSH.Trim() != "" && ttkhachhang.LNSX.Trim() != "" && ttkhachhang.LNDV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSH.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNDV.Trim()) / 100);
                                TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    ///BÁN SỈ
                    case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
                        //if (TieuThu <= DinhMuc)
                        //    TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100));
                        //else
                        //    if (TieuThu - DinhMuc <= DinhMuc / 2)
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100))) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - (lstGiaNuoc[1].DonGia.Value * 10 / 100)));
                        //    else
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100))) + (DinhMuc / 2 * (lstGiaNuoc[1].DonGia.Value - (lstGiaNuoc[1].DonGia.Value * 10 / 100))) + ((TieuThu - DinhMuc - DinhMuc / 2) * (lstGiaNuoc[2].DonGia.Value - (lstGiaNuoc[2].DonGia.Value * 10 / 100)));
                        if (TieuThu <= DinhMuc)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * GiamTienNuoc / 100));
                                }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * GiamTienNuoc / 100)) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * GiamTienNuoc / 100));
                                }
                            else
                            {
                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * GiamTienNuoc / 100));
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * GiamTienNuoc / 100));
                            }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 52:///sỉ khu công nghiệp
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 53:///sỉ KD - TM
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 54:///sỉ LNHCSN
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 59:///sỉ phức tạp
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.LNSH.Trim() != "" && ttkhachhang.LNHCSN.Trim() != "" && ttkhachhang.LNSX.Trim() != "" && ttkhachhang.LNDV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSH.Trim()) / 100);
                                int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNHCSN.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNDV.Trim()) / 100);
                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100);
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100));
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * GiamTienNuoc / 100));
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * GiamTienNuoc / 100));
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * GiamTienNuoc / 100));
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                                        + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * GiamTienNuoc / 100));
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * GiamTienNuoc / 100));
                                    }
                                TongTien += (_HCSN * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * GiamTienNuoc / 100)) + +(_DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * GiamTienNuoc / 100));
                                _chiTiet += _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                             + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                             + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * GiamTienNuoc / 100));
                                //TongTien -= TongTien * 10 / 100;
                            }
                        break;
                    case 68:///LNSH giá sỉ - KD giá lẻ
                        ttkhachhang = getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.LNSH.Trim() != "" && ttkhachhang.LNDV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNSH.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.LNDV.Trim()) / 100);
                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100);
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100));
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * GiamTienNuoc / 100));
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                                 + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * GiamTienNuoc / 100));
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * GiamTienNuoc / 100));
                                            _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100))) + "\r\n"
                                                 + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                                 + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * GiamTienNuoc / 100));
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * GiamTienNuoc / 100)) + "\r\n"
                                             + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * GiamTienNuoc / 100));
                                    }
                                TongTien += _DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * GiamTienNuoc / 100);
                                _chiTiet += _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * GiamTienNuoc / 100));
                                //TongTien -= TongTien * 10 / 100;
                            }
                        break;
                    default:
                        _chiTiet = "";
                        TongTien = 0;
                        break;
                }
                ChiTiet = _chiTiet;
                return TongTien;
            }
            catch (Exception)
            {
                ChiTiet = "";
                return 0;
            }
        }

        public bool LinQ_ExecuteNonQuery(string sql)
        {
            if (_dbKTKS_DonKH.ExecuteCommand(sql) == 0)
            {
                _dbKTKS_DonKH = new dbKTKS_DonKHDataContext();
                return false;
            }
            else
            {
                _dbKTKS_DonKH = new dbKTKS_DonKHDataContext();
                return true;
            }
        }
    }
}
