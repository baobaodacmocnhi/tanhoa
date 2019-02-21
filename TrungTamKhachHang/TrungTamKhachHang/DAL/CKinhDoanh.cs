using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TrungTamKhachHang.DAL
{
    class CKinhDoanh
    {
        CConnection _cDAL = new CConnection(CConnection.connectionString_KinhDoanh);

        //public DataTable GetDSTimKiem(string DanhBo)
        //{
        //    string sql = "select * from fnTimKiem('" + DanhBo + "') order by MaHD desc";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDanhBo(string HoTen,string SoNha,string TenDuong)
        //{
        //    return _cDAL.ExecuteQuery_DataTable("select * from fnTimKiemTTKH('" + HoTen + "','" + SoNha + "','" + TenDuong + "')");
        //}

        public DataSet getTimKiem(string DanhBo)
        {
            DataSet ds = new DataSet();
            ds = _cDAL.ExecuteQuery_DataSet("exec spTimKiemByBanhBo_DonTuChiTiet '" + DanhBo + "'");

            DataTable dt = new DataTable();
            dt = _cDAL.ExecuteQuery_DataTable("exec spTimKiemByBanhBo_DonTu '" + DanhBo + "'");
            DataTable dtDon = new DataTable();
            dtDon.Columns.Add("MaDon", typeof(string));
            dtDon.Columns.Add("TenLD", typeof(string));
            dtDon.Columns.Add("CreateDate", typeof(DateTime));
            dtDon.Columns.Add("DanhBo", typeof(string));
            dtDon.Columns.Add("HoTen", typeof(string));
            dtDon.Columns.Add("DiaChi", typeof(string));
            dtDon.Columns.Add("GiaBieu", typeof(string));
            dtDon.Columns.Add("DinhMuc", typeof(string));
            dtDon.Columns.Add("NoiDung", typeof(string));
            dtDon.TableName = "DonTu";

            foreach (DataRow itemRow in dt.Rows)
            {
                if (dtDon.Select("MaDon = '" + itemRow["MaDon"] + "'").Count() <= 0)
                    dtDon.ImportRow(itemRow);
            }

            dtDon.DefaultView.Sort = "CreateDate ASC";
            ds.Tables.Add(dtDon.DefaultView.ToTable());

            for (int i = 0; i < ds.Tables.Count; i++)
                if (ds.Tables[i].Rows.Count > 0)
                {
                    switch (ds.Tables[i].Rows[0][0].ToString())
                    {
                        case "KTXM":
                            ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "BamChi":
                            ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "DongNuoc":
                            ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "DCBD":
                            ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "CHDB":
                            ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "PhieuCHDB":
                            ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TTTL":
                            ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "GianLan":
                            ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TruyThu":
                            ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ToTrinh":
                            ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ThuMoi":
                            ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TienTrinh":
                            ds.Relations.Add("Chi Tiết Tiến Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                    }
                }

            return ds;
        }
    }
}
