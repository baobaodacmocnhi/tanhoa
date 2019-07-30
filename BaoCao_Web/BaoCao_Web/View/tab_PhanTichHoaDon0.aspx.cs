using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace BaoCao_Web.View
{
    public partial class tab_PhanTichHoaDon0 : System.Web.UI.Page
    {
        log4net.ILog log = log4net.LogManager.GetLogger("File");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            this.tungay.Text = "1/2017";
            this.denngay.Text = (DateTime.Now.Date.Month - 1) + "/" + DateTime.Now.Date.Year;
            //ThongKeHoadon();
        }

        public void PhanTichHoaDon()
        {
            try
            {
                //this.panelAnd.Visible = false;
                //this.panelTu.Visible = false;
                string tuky = getFullKY(this.tungay.Text);
                string denky = getFullKY(this.denngay.Text);
                DataTable tableTre = new DataTable();
                tableTre.Columns.Add(tuky, typeof(String));
                tableTre.Columns.Add(denky, typeof(String));
                tableTre.Columns.Add("TĂNG GIẢM", typeof(String));
                tableTre.Columns.Add("=0 2 KỲ", typeof(String));
                tableTre.Columns.Add("SỬ DỤNG LẠI", typeof(String));
                tableTre.Columns.Add("PHÁT SINH", typeof(String));
                tableTre.Columns.Add("SANLUONG", typeof(String));
                tableTre.Columns.Add("SANLUONGGIAM", typeof(String));
                
                tuky = tuky.Substring(3,4) + tuky.Substring(0,2);
                denky = denky.Substring(3, 4) + denky.Substring(0, 2); ;


                if ("and".Equals(this.sosanh.Text))
                {
                    this.panelAnd.Visible = true;
                    this.panelTu.Visible = false;
                    Session["tuky"] = tuky;
                    Session["denky"] = denky;
                    string sql = "SELECT COUNT(*) FROM DocSoTH.dbo.HoaDon WHERE TieuThu=0 AND HoaDonID LIKE '" + tuky + "%';";
                    // log.Error("LinQConnection ExecuteCommand : " + sql);
                    int Tongtuky = Class.LinQConnection.ReturnResult(sql);


                    sql = "SELECT COUNT(*) FROM DocSoTH.dbo.HoaDon WHERE TieuThu=0 AND HoaDonID LIKE '" + denky + "%';";
                    int Tongdenky = Class.LinQConnection.ReturnResult(sql);

                    int tanggiam = Tongdenky - Tongtuky;

                    sql = "SELECT COUNT(*) FROM (SELECT DanhBa FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + tuky + "%') t1 INNER JOIN (SELECT DanhBa FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + denky + "%') t2 ON t1.DanhBa = t2.DanhBa";
                    int ca2ky = Class.LinQConnection.ReturnResult(sql);

                    sql = "SELECT COUNT(*) FROM (SELECT DanhBa FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + tuky + "%') t1 INNER JOIN (SELECT DanhBa FROM DocSoTH.dbo.HoaDon WHERE TieuThu <> 0 AND HoaDonID like '" + denky + "%') t2 ON t1.DanhBa = t2.DanhBa";
                    int sudunglai = Class.LinQConnection.ReturnResult(sql);

                    sql = "SELECT SUM(t2.TieuThu) FROM (SELECT DanhBa FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + tuky + "%') t1 INNER JOIN (SELECT DanhBa, TieuThu FROM DocSoTH.dbo.HoaDon WHERE TieuThu <> 0 AND HoaDonID like '" + denky + "%') t2 ON t1.DanhBa = t2.DanhBa";
                    int tongsanluong = Class.LinQConnection.ReturnResult(sql);

                    sql = "SELECT SUM(t1.TieuThu) FROM (SELECT DanhBa, TieuThu FROM DocSoTH.dbo.HoaDon WHERE TieuThu <> 0 AND HoaDonID like '" + tuky + "%') t1 INNER JOIN (SELECT DanhBa FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + denky + "%') t2 ON t1.DanhBa = t2.DanhBa";
                    int tongsanluonggiam = Class.LinQConnection.ReturnResult(sql); 
                    int phatsinh = Tongtuky - ca2ky + tanggiam;

                    DataRow row = tableTre.NewRow();
                    row[tuky.Substring(4, 2) + "/" + tuky.Substring(0, 4)] = Tongtuky;
                    row[denky.Substring(4, 2) + "/" + denky.Substring(0, 4)] = Tongdenky;
                    row["TĂNG GIẢM"] = tanggiam;
                    row["=0 2 KỲ"] = ca2ky;
                    row["SỬ DỤNG LẠI"] = sudunglai;
                    row["PHÁT SINH"] = phatsinh;
                    row["SANLUONG"] = tongsanluong;
                    row["SANLUONGGIAM"] = tongsanluonggiam;
                    

                    tableTre.Rows.Add(row);
                    Session["PHANTICH"] = tableTre;


                    Gtuky.DataSource = Class.LinQConnection.getDataTable("SELECT CODE, COUNT(*) AS 'SL' FROM DocSoTH.dbo.HoaDon WHERE TieuThu=0 AND HoaDonID LIKE '" + tuky + "%' GROUP BY CODE ORDER BY CODE ASC");
                    Gtuky.DataBind();

                    Gdenky.DataSource = Class.LinQConnection.getDataTable("SELECT CODE, COUNT(*) AS 'SL' FROM DocSoTH.dbo.HoaDon WHERE TieuThu=0 AND HoaDonID LIKE '" + denky + "%' GROUP BY CODE ORDER BY CODE ASC");
                    Gdenky.DataBind();

                    Ghd02.DataSource = Class.LinQConnection.getDataTable("SELECT t1.CODE, COUNT(*) AS 'SL' FROM (SELECT DanhBa, Code FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + tuky + "%') t1 INNER JOIN (SELECT DanhBa FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + denky + "%') t2 ON t1.DanhBa = t2.DanhBa GROUP BY t1.CODE ORDER BY CODE ASC;");
                    Ghd02.DataBind();

                    Gphatsinh.DataSource = Class.LinQConnection.getDataTable("SELECT  t1.CODE, COUNT(*) AS 'SL' FROM (SELECT DanhBa, Code FROM DocSoTH.dbo.HoaDon WHERE TieuThu <> 0 AND HoaDonID like '" + tuky + "%') t1 INNER JOIN (SELECT DanhBa FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + denky + "%') t2 ON t1.DanhBa = t2.DanhBa GROUP BY t1.CODE ORDER BY CODE ASC;");
                    Gphatsinh.DataBind();

                    GridView1.DataSource = Class.LinQConnection.getDataTable("SELECT t1.CODE, COUNT(*) AS 'SL'FROM (SELECT DanhBa, Code FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + tuky + "%') t1 INNER JOIN (SELECT DanhBa FROM DocSoTH.dbo.HoaDon WHERE TieuThu <> 0 AND HoaDonID like '" + denky + "%') t2 ON t1.DanhBa = t2.DanhBa GROUP BY t1.CODE ORDER BY CODE ASC;");
                    GridView1.DataBind();


                    //////////DOI TUONG/////////

                    Gdoituongtu1.DataSource = Class.LinQConnection.getDataTable("SELECT GB AS GIABIEU, COUNT(*) AS 'SL' FROM DocSoTH.dbo.HoaDon WHERE TieuThu=0 AND HoaDonID LIKE '" + tuky + "%' GROUP BY GB ORDER BY GIABIEU ASC");
                    Gdoituongtu1.DataBind();

                    Gdoituongden.DataSource = Class.LinQConnection.getDataTable("SELECT GB AS GIABIEU, COUNT(*) AS 'SL' FROM DocSoTH.dbo.HoaDon WHERE TieuThu=0 AND HoaDonID LIKE '" + denky + "%' GROUP BY GB ORDER BY GIABIEU ASC");
                    Gdoituongden.DataBind();

                    Gdoituong2ky.DataSource = Class.LinQConnection.getDataTable("SELECT t1.GB AS GIABIEU, COUNT(*) AS 'SL' FROM (SELECT DanhBa, GB FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + tuky + "%') t1 INNER JOIN (SELECT DanhBa FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + denky + "%') t2 ON t1.DanhBa = t2.DanhBa GROUP BY t1.GB ORDER BY GIABIEU ASC");
                    Gdoituong2ky.DataBind();

                    SanLuongDT.DataSource = Class.LinQConnection.getDataTable("SELECT t1.GB AS GIABIEU, SUM(TieuThu) AS 'SL' FROM (SELECT DanhBa, GB FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + tuky + "%') t1 INNER JOIN (SELECT DanhBa, TieuThu FROM DocSoTH.dbo.HoaDon WHERE TieuThu <> 0 AND HoaDonID like '" + denky + "%') t2 ON t1.DanhBa = t2.DanhBa GROUP BY t1.GB ORDER BY GIABIEU ASC");
                    SanLuongDT.DataBind();

                    Gdoituongphatsinh.DataSource = Class.LinQConnection.getDataTable("SELECT t1.GB AS GIABIEU, SUM(TieuThu) AS 'SL' FROM (SELECT DanhBa, GB, TieuThu FROM DocSoTH.dbo.HoaDon WHERE TieuThu <> 0 AND HoaDonID like '" + tuky + "%') t1 INNER JOIN (SELECT DanhBa FROM DocSoTH.dbo.HoaDon WHERE TieuThu = 0 AND HoaDonID like '" + denky + "%') t2 ON t1.DanhBa = t2.DanhBa GROUP BY t1.GB ORDER BY GIABIEU ASC");
                    Gdoituongphatsinh.DataBind();

                    //////////QUAN PHUONG////////////

                    QPTUKY.DataSource = Class.LinQConnection.getDataTable("SELECT (QUAN+'.'+PHUONG) AS QP, COUNT(*) AS 'SL' FROM GET_DLKH_BY_KY_FULL(" + tuky.Substring(0, 4) + "," + tuky.Substring(4, 2) + ") WHERE TIEUTHU=0 AND QUAN IS NOT NULL GROUP BY (QUAN+'.'+PHUONG) ORDER BY (QUAN+'.'+PHUONG) ASC");
                    QPTUKY.DataBind();

                    QPDENKY.DataSource = Class.LinQConnection.getDataTable("SELECT (QUAN+'.'+PHUONG) AS QP, COUNT(*) AS 'SL' FROM GET_DLKH_BY_KY_FULL(" + denky.Substring(0, 4) + "," + denky.Substring(4, 2) + ") WHERE TIEUTHU=0 AND QUAN IS NOT NULL GROUP BY (QUAN+'.'+PHUONG) ORDER BY (QUAN+'.'+PHUONG) ASC");
                    QPDENKY.DataBind();

                    QP02KY.DataSource = Class.LinQConnection.getDataTable("SELECT (K01.QUAN+'.'+K01.PHUONG) AS QP, COUNT(*) AS 'SL' FROM GET_DLKH_BY_KY_FULL(" + tuky.Substring(0, 4) + "," + tuky.Substring(4, 2) + ") K12, GET_DLKH_BY_KY_FULL(" + denky.Substring(0, 4) + "," + denky.Substring(4, 2) + ") K01 WHERE K12.DANHBO= K01.DANHBO AND K12.TIEUTHU =0 AND K01.TIEUTHU = 0 AND K01.QUAN IS NOT NULL GROUP BY (K01.QUAN+'.'+K01.PHUONG) ORDER BY (K01.QUAN+'.'+K01.PHUONG) ASC");
                    QP02KY.DataBind();

                    QPSANLUONG.DataSource = Class.LinQConnection.getDataTable("SELECT (K01.QUAN+'.'+K01.PHUONG) AS QP,  SUM(K01.TieuThu) AS 'SL' FROM GET_DLKH_BY_KY_FULL(" + tuky.Substring(0, 4) + "," + tuky.Substring(4, 2) + ") K12, GET_DLKH_BY_KY_FULL(" + denky.Substring(0, 4) + "," + denky.Substring(4, 2) + ") K01 WHERE K12.DANHBO= K01.DANHBO AND K12.TIEUTHU =0 AND K01.TIEUTHU <> 0 AND K01.QUAN IS NOT NULL GROUP BY (K01.QUAN+'.'+K01.PHUONG) ORDER BY (K01.QUAN+'.'+K01.PHUONG) ASC");
                    QPSANLUONG.DataBind();

                    QPPHATSINH.DataSource = Class.LinQConnection.getDataTable("SELECT ( K01.QUAN+'.'+ K01.PHUONG) AS QP, COUNT(*) AS 'SL' FROM GET_DLKH_BY_KY_FULL(" + tuky.Substring(0, 4) + "," + tuky.Substring(4, 2) + ") K12, GET_DLKH_BY_KY_FULL(" + denky.Substring(0, 4) + "," + denky.Substring(4, 2) + ") K01 WHERE K12.DANHBO= K01.DANHBO AND K12.TIEUTHU <> 0 AND K01.TIEUTHU = 0 AND K01.QUAN IS NOT NULL GROUP BY (K01.QUAN+'.'+K01.PHUONG) ORDER BY (K01.QUAN+'.'+K01.PHUONG) ASC");
                    QPPHATSINH.DataBind();

                    /// PHAN TICH THEO NHAN VIEN DS

                    DataTable t1 = Class.LinQConnection.getDataTable("SELECT  nv.May AS MAYDS, nv.NhanVienID AS FULLNAME, COUNT(*) AS SOLUONG FROM DocSoTH.dbo.MayDS nv, DocSoTH.dbo.DocSo ds WHERE ds.DocSoID LIKE '" + tuky + "%' AND nv.May  = ds.May AND TieuThuMoi=0 GROUP BY nv.May, nv.NhanVienID ORDER BY nv.May ASC");
                    HDONHANVIENTU.DataSource = t1;
                    HDONHANVIENTU.DataBind();

                    DataTable t2 = Class.LinQConnection.getDataTable("SELECT  nv.May AS MAYDS, nv.NhanVienID AS FULLNAME, COUNT(*) AS SOLUONG FROM DocSoTH.dbo.MayDS nv, DocSoTH.dbo.DocSo ds WHERE ds.DocSoID LIKE '" + denky + "%' AND nv.May  = ds.May AND TieuThuMoi=0 GROUP BY nv.May, nv.NhanVienID ORDER BY nv.May ASC");
                    HDONHANVIENDEN.DataSource = t2;
                    HDONHANVIENDEN.DataBind();

                    //----------sai----------------
                    //for (int i = 0; i < t1.Rows.Count; i++) {
                    //    if (!t2.Rows[i]["SOLUONG"].Equals(null))
                    //        t1.Rows[i]["SOLUONG"] = int.Parse(t2.Rows[i]["SOLUONG"].ToString()) - int.Parse(t1.Rows[i]["SOLUONG"].ToString());

                    //}

                    //sosanhnv.DataSource = t1;
                    //sosanhnv.DataBind();
                    

                }
                else if ("To".Equals(this.sosanh.Text))
                {
                    this.panelAnd.Visible = false;
                    this.panelTu.Visible = true;
                    getChart();
                }

            }
            catch (Exception)
            {

            }

        }

        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            PhanTichHoaDon();

        }

        protected void inNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                string tuky = getFullKY(this.tungay.Text);
                string denky = getFullKY(this.denngay.Text);
                Session["TU"] = tuky;
                Session["DEN"] = denky;
                tuky = tuky.Substring(3, 4) + tuky.Substring(0, 2);
                denky = denky.Substring(3, 4) + denky.Substring(0, 2);

                string sql = "  SELECT *,T1.SOLUONG1-T2.SOLUONG2 AS 'TG' FROM ( ";
                sql += " SELECT  nv.May AS MAYDS, nv.NhanVienID AS F1, COUNT(*) AS SOLUONG1 FROM DocSoTH.dbo.MayDS nv, DocSoTH.dbo.DocSo ds WHERE ds.DocSoID LIKE '" + tuky + "%' AND nv.May  = ds.May AND TieuThuMoi=0 GROUP BY nv.May, nv.NhanVienID";
                sql += " ) AS T1 ";
                sql += " JOIN ";
                sql += " (SELECT  nv.May AS M2, nv.NhanVienID AS F2, COUNT(*) AS SOLUONG2 FROM DocSoTH.dbo.MayDS nv, DocSoTH.dbo.DocSo ds WHERE ds.DocSoID LIKE '" + denky + "%' AND nv.May  = ds.May AND TieuThuMoi=0 GROUP BY nv.May, nv.NhanVienID";
                sql += " ) AS T2 ";
                sql += " ON T1.MAYDS=T2.M2 ";
                sql += " ORDER BY T1.MAYDS ASC ";
                Session["SQL"] = sql;
                Session["treport"] = "CÔNG TÁC THEO DÕI HÓA ĐƠN = 0M3 THEO NHÂN VIÊN ĐỌC SỐ";
                Response.Redirect(@"Print.aspx?page=NVDS");

            }
            catch (Exception)
            {

            }
        }
        protected void inQuanPhuong_Click(object sender, EventArgs e)
        {
            string tuky = getFullKY(this.tungay.Text);
            string denky = getFullKY(this.denngay.Text);
            Session["TU"] = tuky;
            Session["DEN"] = denky;
            tuky = tuky.Substring(3, 4) + "," + tuky.Substring(0, 2);
            denky = denky.Substring(3, 4) + "," + denky.Substring(0, 2);

            string sql1 = "SELECT (QUAN+'.'+PHUONG) AS QP, COUNT(*) AS 'SL' FROM GET_DLKH_BY_KY_FULL(" + tuky + ") WHERE TIEUTHU=0 AND QUAN IS NOT NULL GROUP BY (QUAN+'.'+PHUONG) ORDER BY (QUAN+'.'+PHUONG) ASC";

            string sql2 = "SELECT (QUAN+'.'+PHUONG) AS QP, COUNT(*) AS 'SL' FROM GET_DLKH_BY_KY_FULL(" + denky + ") WHERE TIEUTHU=0 AND QUAN IS NOT NULL GROUP BY (QUAN+'.'+PHUONG) ORDER BY (QUAN+'.'+PHUONG) ASC";

            string sql3 = " SELECT *,T1.SL-T2.SL AS 'TG'  ";
            sql3 += " FROM ( SELECT (QUAN+'.'+PHUONG) AS QP, COUNT(*) AS 'SL' FROM GET_DLKH_BY_KY_FULL(" + tuky + ") WHERE TIEUTHU=0 AND QUAN IS NOT NULL GROUP BY (QUAN+'.'+PHUONG) ) AS T1   ";
            sql3 += " JOIN ( SELECT (QUAN+'.'+PHUONG) AS QP, COUNT(*) AS 'SL' FROM GET_DLKH_BY_KY_FULL(" + denky + ") WHERE TIEUTHU=0 AND QUAN IS NOT NULL GROUP BY (QUAN+'.'+PHUONG)) AS T2   ";
            sql3 += " ON T1.QP=T2.QP  ";
            sql3 += " ORDER BY T1.QP ASC ";


            Session["SQL"] = sql1;
            Session["SQL2"] = sql2;
            Session["SQL3"] = sql3;
            Session["treport"] = "PHÂN TÍCH HÓA ĐƠN =0M3 THEO QUẬN PHƯỜNG";
            Response.Redirect(@"Print.aspx?page=PTQP");


        }
        

        string FullKy(int n)
        {
            if (n < 10)
                return "0" + n;
            return n + "";
        }

        string getFullKY(string _ky)
        {
            string k = "";

            try
            {
                string[] words = Regex.Split(_ky, @"/");
                if (words.Length == 2)
                {
                    return FullKy(int.Parse(words[0].Trim())) + "/" + words[1];
                }
            }
            catch (Exception)
            {

            }
            return k;
        }

        public DataTable getChart()
        {
            DataTable tableTre = new DataTable();

           

            string _tungay = "01/"+getFullKY(this.tungay.Text);
            int _tuky = int.Parse(_tungay.Substring(3, 2));
            int _tunam = int.Parse(_tungay.Substring(6, 4));

            string _denngay = "01/" + getFullKY(this.denngay.Text);
            int _denky = int.Parse(_denngay.Substring(3, 2));
            int _dennam = int.Parse(_denngay.Substring(6, 4));

            DateTime tNgay = DateTime.ParseExact(_tungay, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dNgay = DateTime.ParseExact(_denngay, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            int tongThang = (dNgay.Month - tNgay.Month) + 12 * (dNgay.Year - tNgay.Year) + 1;
            string[] arrTitle = new string[tongThang];

            for (int i = 0; i < tongThang; i++)
            {
                string tableName = FullKy(_tuky) + "_" + _tunam;
                tableTre.Columns.Add(tableName, typeof(String));
                arrTitle[i] = tableName;
                _tuky = _tuky + 1;
                if (_tuky > 12)
                {
                    _tuky = 1;
                    _tunam = _tunam + 1;
                }
            }

            string title = " ['Kỳ', 'Tổng HĐ=0', 'Tăng/Giảm', 'KH Không Sử Dụng', 'KH Sử Dụng Lại', 'KH Phát Sinh']";

            string minKy="";
            string maxky = "";
            if (tableTre != null)
            {
                minKy = arrTitle[0].ToString();
                DataRow row = tableTre.NewRow();
                bool flag = false;
                int Tongtuky = 0;
                string tongdanhsach = "SELECT K01.KHU as LOTRINH,K01.DANHBO,K01.HOPDONG,K01.TENKH as HOTEN,K01.SONHA, K01.DUONG as TENDUONG,K01.HIEUDH as HIEU,K01.CODH  as CO,K01.NAMLD as NAM,K01.CODE,K01.LNCC as 'TIEUTHU',K01.NHANVIEN,K01.QUAN,K01.PHUONG   FROM  HOADONTH" + minKy + " K01 WHERE LNCC=0 ";

                string phantichCode = "SELECT K01.CODE, COUNT(*) AS SL   FROM  HOADONTH" + minKy + " K01 WHERE K01.LNCC=0 ";
                string phantichQP = "SELECT (K01.QUAN+'.'+K01.PHUONG ) AS QP, COUNT(*) AS SL    FROM  HOADONTH" + minKy + " K01 WHERE K01.LNCC=0 ";
                
                foreach (string s in arrTitle)
                {

                    string sql = "SELECT COUNT(*) FROM HOADONTH" + s + " WHERE LNCC=0";
                    // log.Error("LinQConnection ExecuteCommand : " + sql);
                    int soluong = Class.LinQConnection.ReturnResult(sql);
                    row[s] = soluong;
                    if (soluong != 0)
                    {
                        if (flag == false)
                        {
                            title += ",['" + s.Replace("_", "/") + "'," + soluong + ",0,0,0,0]";
                            Tongtuky = soluong;
                            flag = true;
                        }
                        else {
                            maxky = s;
                            tongdanhsach += " AND DANHBO IN (SELECT DANHBO FROM HOADONTH" + s + " WHERE LNCC=0 )";
                            phantichCode += " AND DANHBO IN (SELECT DANHBO FROM HOADONTH" + s + " WHERE LNCC=0 )";
                            phantichQP += " AND DANHBO IN (SELECT DANHBO FROM HOADONTH" + s + " WHERE LNCC=0 )";
                            int tanggiam = soluong - Tongtuky;
                            sql = "SELECT COUNT(*) FROM HOADONTH" + minKy + " K12, HOADONTH" + s + " K01 WHERE K12.DANHBO= K01.DANHBO AND K12.LNCC =0 AND K01.LNCC = 0";
                            int ca2ky = Class.LinQConnection.ReturnResult(sql);

                            sql = "SELECT COUNT(*) FROM HOADONTH" + minKy + " K12, HOADONTH" + s + " K01 WHERE K12.DANHBO= K01.DANHBO AND K12.LNCC =0 AND K01.LNCC <> 0";
                            int sudunglai = Class.LinQConnection.ReturnResult(sql);

                            sql = "SELECT SUM(CONVERT(int,K01.LNCC)) FROM HOADONTH" + minKy + " K12, HOADONTH" + s + " K01 WHERE K12.DANHBO= K01.DANHBO AND K12.LNCC =0 AND K01.LNCC <> 0";
                            int tongsanluong = Class.LinQConnection.ReturnResult(sql);

                            int phatsinh = Tongtuky - ca2ky + tanggiam;

                            title += ",['" + s.Replace("_", "/") + "'," + soluong + "," + tanggiam + "," + ca2ky + "," + sudunglai + "," + phatsinh + "]";
                        }
                    }
                }


                phantichCode += " GROUP BY CODE ORDER BY CODE ASC ";
                phantichQP += " GROUP BY K01.QUAN+'.'+K01.PHUONG ORDER BY K01.QUAN+'.'+K01.PHUONG ASC ";



                tongdanhsach = tongdanhsach.Replace(minKy, "MIN");
                tongdanhsach = tongdanhsach.Replace(maxky, "MAX");

                phantichCode = phantichCode.Replace(minKy, "MIN");
                phantichCode = phantichCode.Replace(maxky, "MAX");

                phantichQP = phantichQP.Replace(minKy, "MIN");
                phantichQP = phantichQP.Replace(maxky, "MAX");


                tongdanhsach = tongdanhsach.Replace("MIN", maxky);
                tongdanhsach = tongdanhsach.Replace("MAX", minKy);

                phantichCode = phantichCode.Replace("MIN", maxky);
                phantichCode = phantichCode.Replace("MAX", minKy);

                phantichQP = phantichQP.Replace("MIN", maxky);
                phantichQP = phantichQP.Replace("MAX", minKy);


                GridViewTuCode.DataSource = Class.LinQConnection.getDataTable(phantichCode); ;
                GridViewTuCode.DataBind();
                GridViewTuQP.DataSource = Class.LinQConnection.getDataTable(phantichQP); ;
                GridViewTuQP.DataBind();

                Session["SQL"] = tongdanhsach;
                tongdanhsach += "ORDER BY K01.KHU  ASC";
                DataTable TongDS = Class.LinQConnection.getDataTable(tongdanhsach);
                Session["TongDS"] = TongDS;
                lbTongCong.Text = "TỔNG SỐ HÓA ĐƠN = 0M3 " + tongThang + " KỲ LIÊN TIẾP  : " + Class.Format.NumberFormat(TongDS.Rows.Count);
                Session["treport"] = "DANH SÁCH HÓA ĐƠN = 0M3 " + tongThang + " KỲ LIÊN TIẾP TỪ KỲ " + getFullKY(this.tungay.Text) + " ĐẾN " + getFullKY(this.denngay.Text);
                ///tableTre.Rows.Add(row);
            }

            title = "[" + title + "]";
            Session["hoadon"] = title;
            return tableTre;
        }
        
        

    }

}