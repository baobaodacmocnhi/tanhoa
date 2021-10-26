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
            return db.DocSos.SingleOrDefault(item => item.DanhBa == DanhBo && Convert.ToInt32(item.Ky) == Ky && item.Nam == Nam);
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
                        + " from DocSo ds,server9.HOADON_TA.dbo.HOADON hd where ds.Nam=" + Nam + " and ds.Ky>=1 and ds.Ky<" + Ky + " and ds.Dot=" + Dot + ""
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
    }
}
