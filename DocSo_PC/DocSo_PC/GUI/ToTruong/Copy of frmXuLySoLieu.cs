using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.DAL;
using DocSo_PC.DAL.ToTruong;
using System.Globalization;
using DocSo_PC.LinQ;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmXuLySoLieu : Form
    {
        string _mnu = "mnuXuLySoLieu";
        CTo _cTo = new CTo();
        CMayDS _cMayDS = new CMayDS();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CXuLyDocSo _cCXuLy = new CXuLyDocSo();
        CDHN _kh = new CDHN();
        int tumay = CNguoiDung.TuMayDS;
        int denmay = CNguoiDung.DenMayDS;
        int nam;
        string dot;
        string ky;
        string danhbo = "";
        public frmXuLySoLieu()
        {
            //frmChonDot f = new frmChonDot();
            //if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    InitializeComponent();
            //nam = f.nam;
            //ky = f.ky;
            //dot = f.dot;
            ////danhbo = "13172425656";
            ////LoadThongTin(danhbo);
        }

        void fromLoad()
        {
            ////Load To 
            //string sql = "SELECT MaTo,TenTo FROM [To] ";
            //if (CNguoiDung.ToTruong)
            //    sql += " WHERE MaTo=" + CNguoiDung.MaTo;
            //DataTable tb = _cCXuLy.ExecuteQuery_SqlDataReader_DataTable(sql);
            //int index = 0;
            //if (tb.Rows.Count > 1)
            //{
            //    DataRow newRow = tb.NewRow();
            //    newRow["MaTo"] = "0";
            //    newRow["TenTo"] = "Tất Cả";
            //    tb.Rows.Add(newRow);
            //    index = tb.Rows.Count - 1;
            //}
            //cmbToDS.DataSource = tb;
            //cmbToDS.DisplayMember = "TenTo";
            //cmbToDS.ValueMember = "MaTo";
            //cmbToDS.SelectedIndex = index;
            //getMayds(CNguoiDung.MaTo);
            //// Load Code DS
            //string sqlCodeDs = "SELECT TTDHN,CODE FROM TTDHN WHERE Vitri IS NOT NULL  ORDER BY Vitri ASC ";
            //DataTable tbCodeDs = _cCXuLy.ExecuteQuery_SqlDataReader_DataTable(sqlCodeDs);

            //if (tbCodeDs.Rows.Count > 1)
            //{
            //    DataRow newRow = tbCodeDs.NewRow();
            //    newRow["TTDHN"] = "Chưa Ghi";
            //    newRow["CODE"] = "";
            //    tbCodeDs.Rows.Add(newRow);

            //    newRow = tbCodeDs.NewRow();
            //    newRow["TTDHN"] = "Tất Cả";
            //    newRow["CODE"] = "-1";
            //    tbCodeDs.Rows.Add(newRow);
            //}
            //cmbCodeDS.DataSource = tbCodeDs;
            //cmbCodeDS.DisplayMember = "TTDHN";
            //cmbCodeDS.ValueMember = "CODE";
            //cmbCodeDS.SelectedValue = "-1";

            //// Load CodeM
            //string sqlCode = "SELECT TTDHN,CODE FROM TTDHN ORDER BY CODE ASC ";
            //cmbCodeDC.DataSource = _cCXuLy.ExecuteQuery_SqlDataReader_DataTable(sqlCode);
            //cmbCodeDC.DisplayMember = "TTDHN";
            //cmbCodeDC.ValueMember = "CODE";

        }

        private void frmDieuChinhDocSo_Load(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                cmbTo.DataSource = _cTo.getDS_HanhThu();
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
                cmbTo.SelectedIndex = -1;
            }
            else
            {
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
                loadMay(CNguoiDung.MaTo.ToString());
            }
            this.Text = "Điều Chỉnh Đọc Số Kỳ " + ky + "/" + nam + " Đợt " + dot;

            //fromLoad();
        }

        public void loadMay(string MaTo)
        {
            cmbMay.DataSource = _cMayDS.getDS(MaTo);
            cmbMay.DisplayMember = "May";
            cmbMay.ValueMember = "May";
            cmbMay.SelectedIndex = -1;
        }

        private void dataDieuChinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataDieuChinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        void getMayds(int tods)
        {
            cmbMay.DataSource = _cCXuLy.getMayDS(tods);
            cmbMay.DisplayMember = "May";
            cmbMay.ValueMember = "May";
        }

        private void cmbToDS_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                int tods = int.Parse(cmbTo.SelectedValue.ToString());
                getMayds(tods);
                SumDHN(tods + "", "", nam, ky, dot);
            }
            catch (Exception)
            {

            }

        }

        private void cmbMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDuLieuDS();
                SumDHN("", cmbMay.Text, nam, ky, dot);
            }
            catch (Exception)
            {

            }

        }

        #region Load Thông Tin

        public void LoadThongTin(string danhbo)
        {
            dataGhiChu.DataSource = _kh.getGhiChuKH(danhbo);
            dataThay.DataSource = _kh.getTTThay(danhbo);
            dataGanMoi.DataSource = _cCXuLy.getGanMoi(danhbo);
            if (ckHoaDon.Checked)
                LoadReport(danhbo);
            else LoadReportHD(danhbo);

            LoadDB(danhbo);

        }
        TB_DULIEUKHACHHANG khachhang = null;

        public void LoadDB(string sodanhbo)
        {

            if (sodanhbo.Length == 11)
            {
                khachhang = DAL.CDHN.finByDanhBo(sodanhbo);
                if (khachhang != null)
                {
                    txtDanhBo.Text = khachhang.DANHBO;
                    txtTenKH.Text = khachhang.HOTEN;
                    txtDiaChi.Text = khachhang.SONHA + ' ' + khachhang.TENDUONG;
                    txtHieuluc.Text = String.Format("{0:00}", khachhang.KY) + "/" + khachhang.NAM;
                    txtGB.Text = khachhang.GIABIEU;
                    txtDM.Text = khachhang.DINHMUC;
                    txtNgayGan.Text = CFormat.NgayVN(khachhang.NGAYTHAY.Value);
                    txtNgayKD.Text = khachhang.NGAYKIEMDINH.Value != null ? CFormat.NgayVN(khachhang.NGAYKIEMDINH.Value) : "";
                    txtHiieu.Text = khachhang.HIEUDH;
                    txtCo.Text = khachhang.CODH;
                    txtSoThan.Text = khachhang.SOTHANDH;
                }
                else
                {
                    TB_DULIEUKHACHHANG_HUYDB khachhanghuy = DAL.CDHN.finByDanhBoHuy(sodanhbo);
                    if (khachhanghuy != null)
                    {
                        txtDanhBo.Text = khachhanghuy.DANHBO;
                        txtTenKH.Text = khachhanghuy.HOTEN;
                        txtDiaChi.Text = khachhanghuy.SONHA + ' ' + khachhanghuy.TENDUONG;
                        txtHieuluc.Text = "Hết HL " + khachhanghuy.HIEULUCHUY;
                        txtGB.Text = khachhanghuy.GIABIEU;
                        txtDM.Text = khachhanghuy.DINHMUC;
                        txtNgayGan.Text = CFormat.NgayVN(khachhanghuy.NGAYTHAY.Value);
                        txtNgayKD.Text = khachhanghuy.NGAYKIEMDINH.Value != null ? CFormat.NgayVN(khachhanghuy.NGAYKIEMDINH.Value) : "";
                        txtHiieu.Text = khachhanghuy.HIEUDH;
                        txtCo.Text = khachhanghuy.CODH;
                        txtSoThan.Text = khachhanghuy.SOTHANDH;
                    }
                    else
                    {
                        //MessageBox.Show(this, "Không Tìm Thấy Thông Tin !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void LoadReport(string db)
        {
            //string sql = " SELECT  TOP(12)  H.DANHBA, H.KY, H.Nam AS NAM, H.CodeMoi AS CODE, H.CSCU, H.CSMOI, CONVERT(NCHAR(10), H.DenNgay, 103) AS DENNGAY, H.TieuThuMoi AS LNCC ";
            //sql += " FROM DocSo H   WHERE DANHBA ='" + db + "'  order by  NAM DESC,KY DESC ";
            //DataTable b = _cCXuLy.ExecuteQuery_SqlDataReader_DataTable(sql);
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("R1", b));
            //this.reportViewer1.RefreshReport();
        }

        public void LoadReportHD(string db)
        {
            CThuTien _tt = new CThuTien();
            string sql = " SELECT  TOP(12)   H.DANHBA, H.KY, H.Nam AS NAM, H.CODE AS CODE, H.CSCU, H.CSMOI, CONVERT(NCHAR(10), H.DenNgay, 103) AS DENNGAY, H.TIEUTHU AS LNCC ";
            sql += " FROM HOADON H   WHERE DANHBA ='" + db + "'  order by  NAM DESC,KY DESC";
            DataTable b = CXuLyDocSo._cDAL.ExecuteQuery_SqlDataReader_DataTable(sql);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("R1", b));
            this.reportViewer1.RefreshReport();
        }

        #endregion

        private void cmbCodeDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtCodeM.Text = cmbCodeDC.SelectedValue.ToString();
            }
            catch (Exception)
            {
            }

        }

        private void ckHoaDon_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHoaDon.Checked)
                LoadReport(danhbo);
            else LoadReportHD(danhbo);
        }

        private void btHinhDHN_Click(object sender, EventArgs e)
        {
            // Đợi hình đhn.

        }

        public void SumDHN(string tods, string may, int nam, string ky, string dot)
        {
            DataTable tb = _cCXuLy.SumTongSoDS(tods, may, nam, ky, dot);
            if (tb.Rows.Count > 0)
            {
                this.lbTongKH.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", tb.Rows[0]["TSKH"]);
                this.lbKHCG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", tb.Rows[0]["TSCG"]);
                this.lbSanLuong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", tb.Rows[0]["SANLUONG"]);
                this.lbDongCua.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", tb.Rows[0]["TSDC"]);
                this.lbHD0.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", tb.Rows[0]["TSHD0"]);
            }


        }

        public void LoadDuLieuDS()
        {
            this.txtDanhBoDs.Text = "";
            //string db = this.txtDanhBoDs.Text.Replace(" ", "").Replace("-", "");
            string code = cmbCodeDS.SelectedValue.ToString();
            string may = cmbMay.Text;
            dataDieuChinh.DataSource = _cCXuLy.getDuLieuDocSo("", code, may, nam, ky, dot);

        }

        private void cmbCodeDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDuLieuDS();
            }
            catch (Exception)
            {
                // MessageBox.Show(this, x.Message);
            }
        }

        private void dataDieuChinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowid = e.RowIndex;
            if (rowid >= 0)
            {
                string db = dataDieuChinh.Rows[rowid].Cells["DanhBa"].Value + "";
                danhbo = db;
                if (!"".Equals(db))
                {
                    string dsID = dataDieuChinh.Rows[rowid].Cells["DocSoID"].Value + "";
                    string dsCodeMoi = dataDieuChinh.Rows[rowid].Cells["TTDHNMoi"].Value + "";
                    string csCu = dataDieuChinh.Rows[rowid].Cells["CSCu"].Value + "";
                    string csMoi = dataDieuChinh.Rows[rowid].Cells["CSMoi"].Value + "";
                    string tieuThuMoi = dataDieuChinh.Rows[rowid].Cells["TieuThu"].Value + "";
                    string codeMoi = dataDieuChinh.Rows[rowid].Cells["CodeMoi"].Value + "";

                    this.txtDanhBoDs.Text = db;
                    cmbCodeDC.SelectedText = dsCodeMoi;
                    txtCodeM.Text = codeMoi;

                    txtCSCu.Text = csCu;
                    txtCSMoi.Text = csMoi;
                    txtTieuThuMoi.Text = tieuThuMoi;
                    lbDocsoID.Text = dsID;
                    LoadThongTin(db);
                }

            }
        }

        private void txtDanhBoDs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string db = this.txtDanhBoDs.Text.Replace(" ", "").Replace("-", "");
                danhbo = db;
                dataDieuChinh.DataSource = _cCXuLy.getDuLieuDocSo(db, "", "", nam, ky, dot);
            }
        }

        private void txtCSMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTieuThuMoi.Text = _cCXuLy.TinhTieuThu(this.txtDanhBo.Text, int.Parse(ky), nam, this.txtCodeM.Text, int.Parse(this.txtCSMoi.Text)).ToString();
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            //string db = this.txtDanhBoDs.Text.Replace(" ", "").Replace("-", "");
            //danhbo = db;
            if (!_cCXuLy.CapNhatChiSo(this.lbDocsoID.Text, this.txtCodeM.Text, this.cmbCodeDC.Text, int.Parse(this.txtCSMoi.Text), int.Parse(txtTieuThuMoi.Text)))
                MessageBox.Show("Lỗi cập nhật", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                dataDieuChinh.CurrentRow.Cells["TTDHNMoi"].Value = this.cmbCodeDC.Text;
                dataDieuChinh.CurrentRow.Cells["CodeMoi"].Value = this.txtCodeM.Text;
                dataDieuChinh.CurrentRow.Cells["CSMoi"].Value = this.txtCSMoi.Text;
                dataDieuChinh.CurrentRow.Cells["TieuThu"].Value = this.txtTieuThuMoi.Text;

            }
            //dataDieuChinh.DataSource = _cCXuLy.getDuLieuDocSo(danhbo, "", "", nam, ky, dot);
        }




    }
}
