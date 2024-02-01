using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data.SqlClient;
using System.Data;

namespace KTKS_DonKH.DAL
{
    class CDocSo
    {
        private dbDocSoDataContext db = new dbDocSoDataContext();
        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn

        public CDocSo()
        {
            try
            {
                _connectionString = KTKS_DonKH.Properties.Settings.Default.DocSoTHConnectionString;
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

        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                Connect();
                command = new SqlCommand(sql, connection);
                command.CommandTimeout = 600;
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected >= 1)
                    return true;
                else
                    return false;
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
            command = new SqlCommand(sql, connection);
            command.CommandTimeout = 600;
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

        public DocSo get(string DanhBo, int Ky, int Nam)
        {
            if (db.DocSos.Any(item => item.DanhBa == DanhBo && Convert.ToInt32(item.Ky) == Ky && item.Nam == Nam))
                return db.DocSos.SingleOrDefault(item => item.DanhBa == DanhBo && Convert.ToInt32(item.Ky) == Ky && item.Nam == Nam);
            else
            {
                DocSoLuuTru enLuuTru = db.DocSoLuuTrus.SingleOrDefault(item => item.DanhBa == DanhBo && Convert.ToInt32(item.Ky) == Ky && item.Nam == Nam);
                DocSo en = new DocSo();
                en.DocSoID = enLuuTru.DocSoID;
                en.DanhBa = enLuuTru.DanhBa;
                en.MLT1 = enLuuTru.MLT1;
                en.MLT2 = enLuuTru.MLT2;
                en.SoNhaCu = enLuuTru.SoNhaCu;
                en.SoNhaMoi = enLuuTru.SoNhaMoi;
                en.Duong = enLuuTru.Duong;
                en.SDT = enLuuTru.SDT;
                en.GB = enLuuTru.GB;
                en.DM = enLuuTru.DM;
                en.Nam = enLuuTru.Nam;
                en.Ky = enLuuTru.Ky;
                en.Dot = enLuuTru.Dot;
                en.May = enLuuTru.May;
                en.TBTT = enLuuTru.TBTT;
                en.TamTinh = enLuuTru.TamTinh;
                en.CSCu = enLuuTru.CSCu;
                en.CSMoi = enLuuTru.CSMoi;
                en.CodeCu = enLuuTru.CodeCu;
                en.CodeMoi = enLuuTru.CodeMoi;
                en.TTDHNCu = enLuuTru.TTDHNCu;
                en.TTDHNMoi = enLuuTru.TTDHNMoi;
                en.TieuThuCu = enLuuTru.TieuThuCu;
                en.TieuThuMoi = enLuuTru.TieuThuMoi;
                en.TuNgay = enLuuTru.TuNgay;
                en.DenNgay = enLuuTru.DenNgay;
                en.TienNuoc = enLuuTru.TienNuoc;
                en.BVMT = enLuuTru.BVMT;
                en.Thue = enLuuTru.Thue;
                en.TongTien = enLuuTru.TongTien;
                en.SoThanCu = enLuuTru.SoThanCu;
                en.SoThanMoi = enLuuTru.SoThanMoi;
                en.HieuCu = enLuuTru.HieuCu;
                en.HieuMoi = enLuuTru.HieuMoi;
                en.CoCu = enLuuTru.CoCu;
                en.CoMoi = enLuuTru.CoMoi;
                en.GiengCu = enLuuTru.GiengCu;
                en.GiengMoi = enLuuTru.GiengMoi;
                en.Van1Cu = enLuuTru.Van1Cu;
                en.Van1Moi = enLuuTru.Van1Moi;
                en.MVCu = enLuuTru.MVCu;
                en.MVMoi = enLuuTru.MVMoi;
                en.ChiCoCu = enLuuTru.ChiCoCu;
                en.ChiCoMoi = enLuuTru.ChiCoMoi;
                en.ChiThanCu = enLuuTru.ChiThanCu;
                en.ChiThanMoi = enLuuTru.ChiThanMoi;
                en.ViTriCu = enLuuTru.ViTriCu;
                en.ViTriMoi = enLuuTru.ViTriMoi;
                en.CapDoCu = enLuuTru.CapDoCu;
                en.CapDoMoi = enLuuTru.CapDoMoi;
                en.CongDungCu = enLuuTru.CongDungCu;
                en.CongDungMoi = enLuuTru.CongDungMoi;
                en.DMACu = enLuuTru.DMACu;
                en.DMAMoi = enLuuTru.DMAMoi;
                en.GhiChuKH = enLuuTru.GhiChuKH;
                en.GhiChuDS = enLuuTru.GhiChuDS;
                en.GhiChuTV = enLuuTru.GhiChuTV;
                en.NVGHI = enLuuTru.NVGHI;
                en.GIOGHI = enLuuTru.GIOGHI;
                en.BARCODE = enLuuTru.BARCODE;
                en.SOLANGHI = enLuuTru.SOLANGHI;
                en.GPSDATA = enLuuTru.GPSDATA;
                en.StaCapNhat = enLuuTru.StaCapNhat;
                en.NgayCapNhat = enLuuTru.NgayCapNhat;
                en.NVCapNhat = enLuuTru.NVCapNhat;
                en.TODS = enLuuTru.TODS;
                en.NgayTaoDot = enLuuTru.NgayTaoDot;
                en.ChiTiet = enLuuTru.ChiTiet;
                en.Latitude = enLuuTru.Latitude;
                en.Longitude = enLuuTru.Longitude;
                en.BVMT_Thue = enLuuTru.BVMT_Thue;
                en.NgayChuyenListing = enLuuTru.NgayChuyenListing;
                en.NgayTaoDS1 = enLuuTru.NgayTaoDS1;
                en.DutChiThan = enLuuTru.DutChiThan;
                en.DutChiGoc = enLuuTru.DutChiGoc;
                en.DHNSaiTT = enLuuTru.DHNSaiTT;
                en.BaoKinhDoanh = enLuuTru.BaoKinhDoanh;
                en.DMHN = enLuuTru.DMHN;
                en.PhanMay = enLuuTru.PhanMay;
                en.ChuBao = enLuuTru.ChuBao;
                return en;
            }
        }

        public DataSet getDS_DocLoChiSoNuoc(int Nam, int Ky, int Dot)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "select Chon=CAST(0 as bit),DocSoID,DanhBo=DanhBa,MLT=MLT1,HoTen=(select TenKH from KhachHang where DanhBa=DocSo.DanhBa),DiaChi=SoNhaCu+' '+Duong,Nam,Ky,Dot,CodeCu,CodeMoi,CSC=CSCu,CSM=CSMoi,TieuThu=TieuThuMoi,TieuThuLo=0,TieuThuLoConLai=0,TinhTrang=''"
                            + " ,ID='',MaDon='',STT='' from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and CodeMoi='N' order by MLT asc";
                DataTable dtParent = ExecuteQuery_DataTable(sql);
                dtParent.TableName = "Parent";
                ds.Tables.Add(dtParent);
                sql = "(select t2.* from"
                        + "(select DocSoID,DanhBo=DanhBa,MLT=MLT1,HoTen=TenKH,DiaChi=SoNhaCu+' '+Duong,Nam,Ky,Dot,CodeCu,CodeMoi,CSC=CSCu,CSM=CSMoi,TieuThu=TieuThuMoi"
                        + " from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and CodeMoi='N')t1,"
                        + "	(select DocSoID,DanhBo=ds.DanhBa,MLT=MLT1,HoTen=ds.TenKH,DiaChi=SoNhaCu+' '+ds.Duong,ds.Nam,ds.Ky,ds.Dot,CodeCu,CodeMoi,CSC=ds.CSCu,CSM=ds.CSMoi,TieuThu=hd.TIEUTHU,TieuThuDC='',TinhTrang=case when MaNV_DangNgan is not null then N'Đã Đăng Ngân' else '' end,MaHD=ID_HOADON"
                        + " from DocSo ds,HOADON_TA.dbo.HOADON hd where ds.Nam=" + Nam + " and ds.Ky>=1 and ds.Ky<" + Ky + " and ds.Dot=" + Dot + ""
                        + "	and ds.Nam=hd.NAM and ds.Ky=hd.KY and ds.DanhBa=hd.DANHBA)t2"
                        + "	where t1.DanhBo=t2.DanhBo)"
                        + "	order by DanhBo,DocSoID desc";
                DataTable dtChild = ExecuteQuery_DataTable(sql);
                dtChild.TableName = "Child";
                ds.Tables.Add(dtChild);
                if (dtParent.Rows.Count > 0 && dtChild.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết", ds.Tables["Parent"].Columns["DanhBo"], ds.Tables["Child"].Columns["DanhBo"]);
                return ds;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public bool checkKhongTinhPBVMT(string DanhBo)
        {
            return db.DanhBoKPBVMTs.Any(item => item.DanhBo == DanhBo);
        }

        public string getHieuLucKyToi(bool CCDM, int Dot)
        {
            int FromDot = 0, ToDot = 0;
            if (Dot <= 15)
            {
                FromDot = 1;
                ToDot = 15;
            }
            else
                if (Dot >= 16)
                {
                    FromDot = 16;
                    ToDot = 30;
                }
            DataTable dt = ExecuteQuery_DataTable("select top 1 ds.Ky,ds.Nam,Dot=dsct.IDDot from Lich_DocSo ds,Lich_DocSo_ChiTiet dsct where NgayDoc=CAST(getdate() as date) and ds.ID=dsct.IDDocSo and IDDot>=" + FromDot + " and IDDot<=" + ToDot + " order by dsct.NgayDoc asc");
            if (dt != null && dt.Rows.Count == 0)
                dt = ExecuteQuery_DataTable("select top 1 ds.Ky,ds.Nam,Dot=dsct.IDDot from Lich_DocSo ds,Lich_DocSo_ChiTiet dsct where NgayDoc>CAST(getdate() as date) and ds.ID=dsct.IDDocSo and IDDot>=" + FromDot + " and IDDot<=" + ToDot + " order by dsct.NgayDoc asc");
            if (dt != null && dt.Rows.Count > 0)
            {
                //lấy mặc định 2 kỳ
                //if (dt.Rows[0]["Ky"].ToString() == "11")
                //    return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                //else
                //    if (dt.Rows[0]["Ky"].ToString() == "12")
                //        return "02/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                //    else
                //        return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 2).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                //chưa tới đợt đọc số
                if (Dot >= int.Parse(dt.Rows[0]["Dot"].ToString()))
                    if ((int.Parse(dt.Rows[0]["Dot"].ToString()) >= 1 && int.Parse(dt.Rows[0]["Dot"].ToString()) <= 6)
                        || (int.Parse(dt.Rows[0]["Dot"].ToString()) >= 16 && int.Parse(dt.Rows[0]["Dot"].ToString()) <= 21))
                    {
                        if (CCDM)
                            if (dt.Rows[0]["Ky"].ToString() == "11")
                                return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                            else
                                if (dt.Rows[0]["Ky"].ToString() == "12")
                                    return "02/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                                else
                                    return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 2).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                        else
                            if (dt.Rows[0]["Ky"].ToString() == "12")
                                return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                            else
                                return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 1).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                    }
                    else
                        if ((int.Parse(dt.Rows[0]["Dot"].ToString()) >= 7 && int.Parse(dt.Rows[0]["Dot"].ToString()) <= 15)
                            || (int.Parse(dt.Rows[0]["Dot"].ToString()) >= 17 && int.Parse(dt.Rows[0]["Dot"].ToString()) <= 30))
                            if (dt.Rows[0]["Ky"].ToString() == "11")
                                return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                            else
                                if (dt.Rows[0]["Ky"].ToString() == "12")
                                    return "02/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                                else
                                    return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 2).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                        else
                            return "";
                else//đã qua đợt đọc số
                    if ((int.Parse(dt.Rows[0]["Dot"].ToString()) >= 1 && int.Parse(dt.Rows[0]["Dot"].ToString()) <= 6)
                        || (int.Parse(dt.Rows[0]["Dot"].ToString()) >= 16 && int.Parse(dt.Rows[0]["Dot"].ToString()) <= 21))
                    {
                        if (dt.Rows[0]["Ky"].ToString() == "11")
                            return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                        else
                            if (dt.Rows[0]["Ky"].ToString() == "12")
                                return "02/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                            else
                                return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 2).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                    }
                    else
                        if ((int.Parse(dt.Rows[0]["Dot"].ToString()) >= 7 && int.Parse(dt.Rows[0]["Dot"].ToString()) <= 15)
                            || (int.Parse(dt.Rows[0]["Dot"].ToString()) >= 17 && int.Parse(dt.Rows[0]["Dot"].ToString()) <= 30))
                            if (CCDM)
                                if (dt.Rows[0]["Ky"].ToString() == "11")
                                    return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                                else
                                    if (dt.Rows[0]["Ky"].ToString() == "12")
                                        return "02/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                                    else
                                        return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 2).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                            else
                                if (dt.Rows[0]["Ky"].ToString() == "12")
                                    return "01/" + (int.Parse(dt.Rows[0]["Nam"].ToString()) + 1).ToString();
                                else
                                    return (int.Parse(dt.Rows[0]["Ky"].ToString()) + 1).ToString("00") + "/" + dt.Rows[0]["Nam"].ToString();
                        else
                            return "";
            }
            else
                return "";
        }

        public DataTable getPhieuChuyen(string SoPhieu)
        {
            return ExecuteQuery_DataTable("select ID,DanhBo from MaHoa_PhieuChuyen_LichSu where SoPhieu=" + SoPhieu);
        }

    }
}
