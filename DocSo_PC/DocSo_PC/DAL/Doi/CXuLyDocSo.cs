using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.DAL.ToTruong
{
    class CXuLyDocSo : CDAL
    {
        public DataTable getMayDS(int tods)
        {
            string sql = "SELECT  May  FROM   MayDS WHERE NhanVienID is not null  ";
            if (tods != 0)
                sql += " AND ToID=" + tods;
            sql += " order by may";

            return _cDAL.ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }
        public DataTable getGanMoi(string db)
        {
            string sql = "SELECT DanhBa,NgayKiem,NoiDung,Hieu,Co,ChiSo,NgayCapNhat,NVCapNhat   FROM [DocSoTH].[dbo].[ThongBao]";
            sql += " WHERE  DanhBa='" + db + "' order by NgayKiem asc";
            return _cDAL.ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable getDuLieuDocSo(string db, string code, string may, int nam, string ky, string dot)
        {
            string sql = "SELECT DocSoID,MLT1,DanhBa,TTDHNCu,TTDHNMoi,CodeCu,CodeMoi,CSCu,CSMoi,TieuThuMoi,TBTT FROM DocSo ";
            sql += " WHERE Nam=" + nam + " AND Ky='" + ky + "' AND Dot='" + dot + "' ";
            if (!"".Equals(db))
                sql += " AND DanhBa='" + db + "' ";

            if (!"".Equals(code) && !"-1".Equals(code))
                sql += "AND CodeMoi='" + code + "' ";

            if (!"".Equals(may))
                sql += "AND May='" + may + "' ";

            sql += " ORDER BY MLT1 ASC ";
            return _cDAL.ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable SumTongSoDS(string tods, string may, int nam, string ky, string dot)
        {
            string sql = "SELECT COUNT(*) AS TSKH, COUNT(CASE WHEN CodeMoi = '' THEN 1 ELSE NULL END) AS TSCG,  ";
            sql += " SUM(TieuThuMoi) AS SANLUONG, ";
            sql += " COUNT(CASE WHEN CodeMoi LIKE 'F%' THEN 1 ELSE NULL END)AS TSDC,  ";
            sql += " COUNT(CASE WHEN TieuThuMoi=0 AND CodeMoi<>'' THEN 1 ELSE NULL END)AS TSHD0  ";
            sql += " FROM DocSo ";
            sql += " WHERE Nam=" + nam + " AND Ky='" + ky + "' ";

            if (!"".Equals(dot))
                sql += "  AND Dot='" + dot + "' ";

            if (!"".Equals(tods))
            {
                if (int.Parse(tods) != 0)
                    sql += " AND TODS= " + tods + "   ";
            }
            if (!"".Equals(may))
                sql += "AND May='" + may + "' ";

            // sql += " ORDER BY MLT1 ASC ";
            return _cDAL.ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public int TinhTieuThu(string DanhBo, int ky, int nam, string code, int csmoi)
        {
            int tieuthu = 0;
            try
            {

                _cDAL.Connect();
                SqlCommand cmd = new SqlCommand("calTieuTHu");
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter _db = cmd.Parameters.Add("@DANHBO", SqlDbType.VarChar);
                _db.Direction = ParameterDirection.Input;
                _db.Value = DanhBo;

                SqlParameter _ky = cmd.Parameters.Add("@KY", SqlDbType.Int);
                _ky.Direction = ParameterDirection.Input;
                _ky.Value = ky;

                SqlParameter _nam = cmd.Parameters.Add("@NAM", SqlDbType.Int);
                _nam.Direction = ParameterDirection.Input;
                _nam.Value = nam;

                SqlParameter _code = cmd.Parameters.Add("@CODE", SqlDbType.VarChar);
                _code.Direction = ParameterDirection.Input;
                _code.Value = code;

                SqlParameter _csmoi = cmd.Parameters.Add("@CSMOI", SqlDbType.Int);
                _csmoi.Direction = ParameterDirection.Input;
                _csmoi.Value = csmoi;

                SqlParameter _tieuthu = cmd.Parameters.Add("@TIEUTHU", SqlDbType.Int);
                _tieuthu.Direction = ParameterDirection.Output;


                cmd.ExecuteNonQuery();

                tieuthu = int.Parse(cmd.Parameters["@TIEUTHU"].Value + "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _cDAL.Disconnect();
            }
            return tieuthu;
        }

        public bool CapNhatChiSo(string DocSoID, string CodeMoi, string TTDHNMoi, int CSMoi, int TieuThu)
        {
            //int GiaBan, PhiBVMT, ThueGTGT;
            //string ChiTiet;
            //TieuThu = TinhTieuThu(DanhBo, Nam, Ky, CodeMoi, CSMoi);
            //GiaBan = TinhTienNuoc(DanhBo, GiaBieu, DinhMuc, TieuThu, out ChiTiet);
            //if (_DAL.ExecuteQuery_ReturnOneValue("select DanhBo from DanhBoKPBVMT where DanhBo='" + DanhBo + "'") != null)
            //    PhiBVMT = 0;
            //else
            //    PhiBVMT = (int)(GiaBan * 0.1);
            //ThueGTGT = (int)(GiaBan * 0.05);
            //TongCong = GiaBan + PhiBVMT + ThueGTGT;
            //string sql = "update DocSo set NVGHI='nvds',GIOGHI=getdate(),SOLANGHI=1,GPSDATA='0',CSMoi=" + CSMoi + ",CodeMoi='" + CodeMoi + "',TTDHNMoi='" + TTDHNMoi + "',TieuThuMoi=" + TieuThu + ",TienNuoc=" + GiaBan + ",BVMT=" + PhiBVMT + ",Thue=" + ThueGTGT + ",TongTien=" + TongCong + ","
            //    + "ChiTiet='" + ChiTiet + "',Latitude='" + Latitude + "',Longitude='" + Longitude + "',NgayDS=getdate() where DocSoID=" + ID + " and (NgayDS is null or Cast(NgayDS as date)='1900-01-01' or Cast(NgayDS as date)=Cast(getdate() as date))";
            string sql = "UPDATE DocSo SET StaCapNhat=(cast(StaCapNhat as int)+1 ),NgayCapNhat=Getdate(),NVCapNhat=N'" + CNguoiDung.TaiKhoan + "',CSMoi=" + CSMoi + ",CodeMoi='" + CodeMoi + "',TTDHNMoi='" + TTDHNMoi + "',TieuThuMoi=" + TieuThu + " where DocSoID=" + DocSoID + "";
            return _cDAL.ExecuteNonQuery(sql);
            //return _DAL.ExecuteNonQuery(sql);
        }



    }
}
