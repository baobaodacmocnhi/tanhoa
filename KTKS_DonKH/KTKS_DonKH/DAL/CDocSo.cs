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
                //                string sql = "(select DocSoID,DanhBo=DanhBa,MLT=MLT1,HoTen=TenKH,DiaChi=SoNhaCu+' '+Duong,Nam,Ky,Dot,CodeCu,CodeMoi,CSC=CSCu,CSM=CSMoi,TieuThu=TieuThuMoi"
                //+ "                             from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and CodeMoi='N')"
                //+ "union"
                //+ "(select t2.* from"
                //+ "(select DocSoID,DanhBo=DanhBa,MLT=MLT1,HoTen=TenKH,DiaChi=SoNhaCu+' '+Duong,Nam,Ky,Dot,CodeCu,CodeMoi,CSC=CSCu,CSM=CSMoi,TieuThu=TieuThuMoi"
                //+ "                             from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and CodeMoi='N')t1,"
                //+ "							 (select DocSoID,DanhBo=ds.DanhBa,MLT=MLT1,HoTen=ds.TenKH,DiaChi=SoNhaCu+' '+ds.Duong,ds.Nam,ds.Ky,ds.Dot,CodeCu,CodeMoi,CSC=ds.CSCu,CSM=ds.CSMoi,TieuThu=TieuThuMoi"
                //+ "                             from DocSo ds,server9.HOADON_TA.dbo.HOADON hd where ds.Nam=" + Nam + " and ds.Ky>=6 and ds.Ky<" + Ky + " and ds.Dot=" + Dot + ""
                //+ "							 and ds.Nam=hd.NAM and ds.Ky=hd.KY and ds.DanhBa=hd.DANHBA and hd.MaNV_DangNgan is null)t2"
                //+ "							 where t1.DanhBo=t2.DanhBo)"
                //+ "							 order by DanhBo,DocSoID desc";
                string sql = "(select DocSoID,DanhBo=DanhBa,MLT=MLT1,HoTen=(select TenKH from KhachHang where DanhBa=DocSo.DanhBa),DiaChi=SoNhaCu+' '+Duong,Nam,Ky,Dot,CodeCu,CodeMoi,CSC=CSCu,CSM=CSMoi,TieuThu=TieuThuMoi,TieuThuLo=0,TieuThuLoConLai=0,TinhTrang=''"
+ "                             from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and CodeMoi='N')order by DanhBo asc";
                DataTable dtParent = ExecuteQuery_DataTable(sql);
                dtParent.TableName = "Parent";
                ds.Tables.Add(dtParent);

                sql = "(select t2.* from"
+ "(select DocSoID,DanhBo=DanhBa,MLT=MLT1,HoTen=TenKH,DiaChi=SoNhaCu+' '+Duong,Nam,Ky,Dot,CodeCu,CodeMoi,CSC=CSCu,CSM=CSMoi,TieuThu=TieuThuMoi"
+ "                             from DocSo where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + " and CodeMoi='N')t1,"
+ "							 (select DocSoID,DanhBo=ds.DanhBa,MLT=MLT1,HoTen=ds.TenKH,DiaChi=SoNhaCu+' '+ds.Duong,ds.Nam,ds.Ky,ds.Dot,CodeCu,CodeMoi,CSC=ds.CSCu,CSM=ds.CSMoi,TieuThu=TieuThuMoi,TieuThuDC='',NgayGiaiTrach=case when MaNV_DangNgan is not null then NgayGiaiTrach else null end"
+ "                             from DocSo ds,server9.HOADON_TA.dbo.HOADON hd where ds.Nam=" + Nam + " and ds.Ky>=5 and ds.Ky<" + Ky + " and ds.Dot=" + Dot + ""
+ "							 and ds.Nam=hd.NAM and ds.Ky=hd.KY and ds.DanhBa=hd.DANHBA)t2"
+ "							 where t1.DanhBo=t2.DanhBo)"
+ "							 order by DanhBo,DocSoID desc";
                DataTable dtChild = ExecuteQuery_DataTable(sql);
                dtChild.TableName = "Child";
                ds.Tables.Add(dtChild);
                //DataTable dtChild = new DataTable();
                //foreach (DataRow item in dtParent.Rows)
                //{
                //    sql = "select DanhBo=DanhBa,Nam,Ky,CodeCu,CSC=CSCu,CSM=CSMoi,CodeMoi,TieuThu=TieuThuMoi"
                //            + " from DocSo where DanhBa='" + item["DanhBo"].ToString() + "' and Nam=" + Nam + " and Ky>=6 and Ky<" + Ky + " and Dot=" + Dot+" order by DocSoID desc";
                //    DataTable dtTemp = ExecuteQuery_DataTable(sql);
                //    for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
                //        if (dtTemp.Rows[i]["CodeMoi"].ToString().Contains("4") == true || dtTemp.Rows[i]["CodeMoi"].ToString().Contains("5") == true)
                //        {
                //            dtTemp.Rows.RemoveAt(i);
                //        }
                //    dtChild.Merge(dtTemp);
                //}


                if (dtParent.Rows.Count > 0 && dtChild.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết", ds.Tables["Parent"].Columns["DanhBo"], ds.Tables["Child"].Columns["DanhBo"]);
                return ds;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
