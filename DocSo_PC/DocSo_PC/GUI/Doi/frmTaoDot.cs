using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.ChuanBiDocSo;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using System.Data.SqlClient;

namespace DocSo_PC.GUI.Doi
{
    public partial class frmTaoDot : Form
    {
        //  CNguoiDung _cNguoiDung = new CNguoiDung();
        CChuanBiDS _cChuanBi = new CChuanBiDS();
        int tumay = CNguoiDung.TuMayDS;
        int denmay = CNguoiDung.DenMayDS;
        public frmTaoDot()
        {
            InitializeComponent();
        }

        private void dataTaoDS_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataTaoDS.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void frmTaoDocSo_Load(object sender, EventArgs e)
        {
            cmbNam.Items.Add(DateTime.Now.Year - 2);
            cmbNam.Items.Add(DateTime.Now.Year - 1);
            cmbNam.Items.Add(DateTime.Now.Year);
            cmbNam.Items.Add(DateTime.Now.Year + 1);
            cmbNam.SelectedIndex = 2;

            if (DateTime.Now.Day >= 19)
                cmbKy.SelectedIndex = DateTime.Now.Month;
            else
                cmbKy.SelectedIndex = DateTime.Now.Month - 1;

            string sql = "SELECT MaTo,TenTo FROM [To] ";
            if (CNguoiDung.ToTruong)
                sql += " WHERE MaTo=" + CNguoiDung.MaTo;
            cmbToDS.DataSource = _cChuanBi.ExecuteQuery_SqlDataReader_DataTable(sql);
            cmbToDS.DisplayMember = "TenTo";
            cmbToDS.ValueMember = "MaTo";

            dsDenNgay.Value = DateTime.Now.Date.AddDays(1.0);
            //PageLoad();
        }


        private void cmbDot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDot.SelectedIndex != -1)
            {
                SoDocSo();
                dsTuNgay.Value = _cChuanBi.getDocTuNgay(int.Parse(cmbNam.Text),cmbKy.Text,cmbDot.Text);
                
            }
        }
        DataTable tb = null;
        public void SoDocSo()
        {

            try
            {
                CTo _ct = new CTo();
                To _t = _ct.GetByMaTo(int.Parse(cmbToDS.SelectedValue.ToString()));
                tumay = _t.TuMay.Value;
                denmay = _t.DenMay.Value;
                //DataTable t2 = tb.Select(" May > " + tumay + " and May <= " + denmay).CopyToDataTable();
                ////    tb.Select(" (May BETWEEN 0 AND 10 )");
                //dataTaoDS.DataSource = t2;
                string sql = " select May,COUNT(*) AS SOLUONG , 'True' as DaTao ,NVTaoDS,NgayTaoDS from DocSo WHERE (May BETWEEN " + tumay + " AND " + denmay + " )AND Nam=" + int.Parse(cmbNam.Text) + "AND Ky='" + cmbKy.Text + "' AND Dot='" + cmbDot.Text + "' group by May,NVTaoDS,NgayTaoDS ORDER BY May ASC ";
                tb = _cChuanBi.ExecuteQuery_SqlDataReader_DataTable(sql);
                if (tb.Rows.Count > 0)
                    dataTaoDS.DataSource = tb;
                else
                {
                    sql = "select May,COUNT(*) AS SOLUONG , 'False' as DaTao ,'' AS NVTaoDS, '' AS NgayTaoDS from BienDong WHERE (May BETWEEN " + tumay + " AND " + denmay + " )AND Nam=" + int.Parse(cmbNam.Text) + "AND Ky='" + cmbKy.Text + "' AND Dot='" + cmbDot.Text + "' group by May ORDER BY May ASC ";
                    tb = _cChuanBi.ExecuteQuery_SqlDataReader_DataTable(sql);
                    dataTaoDS.DataSource = tb;
                }
            }
            catch (Exception)
            {

            }

        }

        private void cmbToDS_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!"".Equals(cmbDot.Text))
            {
                if (tb != null)
                {
                    SoDocSo();                    
                }
            }
        }


        private void btnTaoDocSo_Click(object sender, EventArgs e)
        {

            SqlConnection thisConnection = new SqlConnection(DocSo_PC.Properties.Settings.Default.DocSoTHTestConnectionString);
            SqlCommand command = null;
            thisConnection.Open();

            if (dataTaoDS.Rows.Count <= 0)
            {
                MessageBox.Show("Chưa cập nhật biến động liệu đọc số  !! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tb != null)
            {
                int nam = int.Parse(cmbNam.Text);
                string ky = cmbKy.Text;
                string dot = cmbDot.Text;
                BillState bilS = _cChuanBi.GetBillState(nam, ky, dot);
                if (bilS != null)
                {
                    if (bilS.izDS == "1")
                    {
                        MessageBox.Show("Dữ liệu đã chuyển Billing không  thể tạo dữ liệu đọc số  !! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }           
                    //if (bilS.izCB == "1")
                }
                try
                {
                    if (!"".Equals(dataTaoDS.Rows[0].Cells["NgayTao"].Value.ToString()))
                    {
                        MessageBox.Show("Đã tạo dữ liệu đọc số rồi không  thể tạo dữ liệu đọc số  !! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        //if (MessageBox.Show("Đã tạo dữ liệu đọc số rồi ! Muốn tạo lại dữ liệu đọc số ? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                        //    return;
                        ////else
                        ////{
                        //}
                    }
                    
                }
                catch (Exception)
                {
                }
                _cChuanBi.ExecuteNonQuery("INSERT INTO BillState VALUES (" + "" + nam + ky + dot + ",1,0,0,0,0)");

              //int total = Convert.ToInt32(tb.Compute("SUM(SOLUONG)", string.Empty));
                int total = dataTaoDS.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells["slDoc"].Value));
                progressBar.Minimum = 0;
                progressBar.Maximum = total;
                int fl = 0;
                string insert = "";
                string value = "";

                try
                {
                    List<BienDong> list = _cChuanBi.getListBienFong(nam, ky, dot, tumay, denmay);
                    foreach (var i in list)
                    {
                        progressBar.Value = fl++;
                        DocSo d = new DocSo();

                        d.DocSoID = i.BienDongID; d.DanhBa = i.DanhBa; d.MLT1 = i.MLT1; d.MLT2 = i.MLT1; d.SoNhaCu = i.So; d.SoNhaMoi = ""; d.Duong = i.Duong; d.SDT = i.HopDong; d.GB = i.GB.ToString(); d.DM = i.DM.ToString(); d.Nam = i.Nam; d.Ky = i.Ky; d.Dot = i.Dot; d.May = i.May;
                        // d.TBTT = _cChuanBi.getTTTB3ky(d.DanhBa);
                        d.TamTinh = 0;
                        insert = " INSERT INTO  DocSo(DocSoID,DanhBa,MLT1,MLT2,SoNhaCu,SoNhaMoi,Duong,SDT,GB,DM,Nam,Ky,Dot,May,TBTT,TamTinh,";
                        value = " VALUES('" + d.DocSoID + "','" + d.DanhBa + "','" + d.MLT1 + "','" + d.MLT2 + "','" + d.SoNhaCu + "','" + d.SoNhaMoi + "','" + d.Duong + "','" + d.SDT + "','" + d.GB + "','" + d.DM + "','" + d.Nam + "','" + d.Ky + "','" + d.Dot + "','" + d.May + "','" + d.TBTT + "','" + d.TamTinh + "',";

                        d.CSCu = i.ChiSo; d.CSMoi = 0; d.CodeCu = i.Code; d.CodeMoi = ""; d.TTDHNCu = i.Code; d.TTDHNMoi = ""; d.TieuThuCu = i.TieuThu; d.TieuThuMoi = 0; d.TuNgay = dsTuNgay.Value; d.DenNgay = dsDenNgay.Value; d.TienNuoc = 0;
                        insert += "CSCu,CSMoi,CodeCu,CodeMoi,TTDHNCu,TTDHNMoi,TieuThuCu,TieuThuMoi,TuNgay,DenNgay,TienNuoc";
                        value += "'" + d.CSCu + "','" + d.CSMoi + "','" + d.CodeCu + "','" + d.CodeMoi + "','" + d.TTDHNCu + "','" + d.TTDHNMoi + "','" + d.TieuThuCu + "','" + d.TieuThuMoi + "','" + d.TuNgay + "','" + d.DenNgay + "','" + d.TienNuoc + "',";

                        d.BVMT = 0; d.Thue = 0; d.TongTien = 0; d.SoThanCu = i.SoThan; d.SoThanMoi = ""; d.HieuCu = i.Hieu; d.HieuMoi = ""; d.CoCu = i.Co.ToString(); d.CoMoi = ""; d.GiengCu = ""; d.GiengMoi = ""; d.Van1Cu = "";
                        insert += ",BVMT,Thue,TongTien,SoThanCu,SoThanMoi,HieuCu,HieuMoi,CoCu,CoMoi,GiengCu,GiengMoi,Van1Cu,";
                        value += "'" + d.BVMT + "','" + d.Thue + "','" + d.TongTien + "','" + d.SoThanCu + "','" + d.SoThanMoi + "','" + d.HieuCu + "','" + d.HieuMoi + "','" + d.CoCu + "','" + d.CoMoi + "','" + d.GiengCu + "','" + d.GiengMoi + "','" + d.Van1Cu + "',";

                        d.Van1Moi = ""; d.MVCu = ""; d.MVMoi = ""; d.ChiCoCu = ""; d.ChiCoMoi = ""; d.ChiThanCu = ""; d.ChiThanMoi = ""; d.ViTriCu = ""; d.ViTriMoi = ""; d.CapDoCu = ""; d.CapDoMoi = "";
                        insert += "Van1Moi,MVCu,MVMoi,ChiCoCu,ChiCoMoi,ChiThanCu,ChiThanMoi,ViTriCu,ViTriMoi,CapDoCu,CapDoMoi,";
                        value += "'" + d.Van1Moi + "','" + d.MVCu + "','" + d.MVMoi + "','" + d.ChiCoCu + "','" + d.ChiCoMoi + "','" + d.ChiThanCu + "','" + d.ChiThanMoi + "','" + d.ViTriCu + "','" + d.ViTriMoi + "','" + d.CapDoCu + "','" + d.CapDoMoi + "',";

                        d.CongDungCu = ""; d.CongDungMoi = ""; d.DMACu = ""; d.DMAMoi = ""; d.GhiChuKH = ""; d.GhiChuDS = ""; d.GhiChuTV = "";
                        insert += "CongDungCu,CongDungMoi,DMACu,DMAMoi,GhiChuKH,GhiChuDS,GhiChuTV,";
                        value += "'" + d.CongDungCu + "','" + d.CongDungMoi + "','" + d.DMACu + "','" + d.DMAMoi + "','" + d.GhiChuKH + "','" + d.GhiChuDS + "','" + d.GhiChuTV + "',";

                        d.GPSDATA = ""; d.TODS = int.Parse(cmbToDS.SelectedValue.ToString()); d.TenKH = i.TenKH; d.NVTaoDS = CNguoiDung.TaiKhoan; ;
                        insert += "GPSDATA,TODS,TenKH,NVTaoDS,";
                        value += "'" + d.GPSDATA + "','" + d.TODS + "','" + d.TenKH + "','" + d.NVTaoDS + "',";

                        d.DutChiThan = "0_0"; d.DutChiGoc = "0_0"; d.DHNSaiTT = "0_0"; d.BaoKinhDoanh = "0_0";
                        insert += "DutChiThan,DutChiGoc,DHNSaiTT,BaoKinhDoanh)";
                        value += "'" + d.DutChiThan + "','" + d.DutChiGoc + "','" + d.DHNSaiTT + "','" + d.BaoKinhDoanh + "')";


                        command = new SqlCommand(insert + value, thisConnection);
                        command.ExecuteNonQuery();
                    }
                    thisConnection.Close();
                    // Cập Nhật Thông Tin Biến Động
                    _cChuanBi.UpdateStoredProcedure("UpdateDocSo", nam, ky, dot);
                    SoDocSo();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi tạo dữ liệu đọc số  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
               // MessageBox.Show(this, total + "==-" + fl);
                
            }
            else
            {
                MessageBox.Show("Chưa load biến động liệu sổ đọc số !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}