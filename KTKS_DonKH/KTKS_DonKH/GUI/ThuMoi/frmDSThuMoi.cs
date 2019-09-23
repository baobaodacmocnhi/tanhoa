using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThuMoi;
using KTKS_DonKH.DAL.ThuMoi;
using KTKS_DonKH.DAL.QuanTri;
using CrystalDecisions.CrystalReports.Engine;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.ThuMoi
{
    public partial class frmDSThuMoi : Form
    {
        CThuMoi _cThuMoi = new CThuMoi();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();

        public frmDSThuMoi()
        {
            InitializeComponent();
        }

        private void frmDSThuMoi_Load(object sender, EventArgs e)
        {
            dgvDSThu.AutoGenerateColumns = false;

            cmbTimTheo.SelectedItem = "Ngày";
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                            dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                        else
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                    dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                else
                                    dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                    break;
                case "Danh Bộ":
                    dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                    break;
                case "Ngày":
                    if (chkCreateBy.Checked == true)
                        dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                    else
                        dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Thư trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {

                    for (int i = 0; i < dgvDSThu.Rows.Count; i++)
                        if (dgvDSThu["In", i].Value != null && bool.Parse(dgvDSThu["In", i].Value.ToString()) == true)
                        {
                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();
                            
                            dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                            dr["SoPhieu"] = dgvDSThu["MaDon", i].Value.ToString();

                            dr["HoTen"] = dgvDSThu["HoTen", i].Value.ToString();
                            dr["DiaChi"] = dgvDSThu["DiaChi", i].Value.ToString();
                            if (!string.IsNullOrEmpty(dgvDSThu["DanhBo", i].Value.ToString()) && dgvDSThu["DanhBo", i].Value.ToString().Length == 11)
                                dr["DanhBo"] = dgvDSThu["DanhBo", i].Value.ToString().Insert(7, " ").Insert(4, " ");
                            dr["GiaBieu"] = dgvDSThu["GiaBieu", i].Value.ToString();
                            if (dgvDSThu["DinhMuc", i].Value != null)
                            dr["DinhMuc"] = dgvDSThu["DinhMuc", i].Value.ToString();
                            dr["CanCu"] = dgvDSThu["CanCu", i].Value.ToString();
                            dr["VaoLuc"] = dgvDSThu["VaoLuc", i].Value.ToString();
                            dr["VeViec"] = dgvDSThu["VeViec", i].Value.ToString();
                            dr["Lan"] = dgvDSThu["Lan", i].Value.ToString();
                            dr["Luuy"] = dgvDSThu["Luuy", i].Value.ToString();
                            dr["NoiNhan"] = dgvDSThu["NoiNhan", i].Value.ToString() + "(" + dgvDSThu["IDCT", i].Value.ToString() + ")";

                            dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                            ReportDocument rpt = new ReportDocument();
                            if (radDutChi.Checked == true)
                                rpt = new rptThuMoiDutChi();
                            else
                                if (radCDDM.Checked == true)
                                    rpt = new rptThuMoiChuyenDe();
                                else
                                    if (radRong.Checked == true)
                                        rpt = new rptThuMoiChuyenDe();
                            rpt.SetDataSource(dsBaoCao);

                            printDialog.AllowSomePages = true;
                            printDialog.ShowHelp = true;

                            //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                            //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                            rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                            rpt.Clone();
                            rpt.Dispose();
                        }
                }
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
                for (int i = 0; i < dgvDSThu.Rows.Count; i++)
                {
                    dgvDSThu["In", i].Value = true;
                }
            else
                for (int i = 0; i < dgvDSThu.Rows.Count; i++)
                {
                    dgvDSThu["In", i].Value = false;
                }
        }

        private void dgvDSThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSThu.Columns[e.ColumnIndex].Name == "IDCT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvDSThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            for (int i = 0; i < dgvDSThu.Rows.Count; i++)
                if (dgvDSThu["In", i].Value != null && bool.Parse(dgvDSThu["In", i].Value.ToString()) == true)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                    dr["LoaiBaoCao"] = "GỬI THƯ MỜI";
                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    dr["MaDon"] = dgvDSThu["MaDon", i].Value.ToString().Insert(dgvDSThu["MaDon", i].Value.ToString().Length-2,"-");
                    if (string.IsNullOrEmpty(dgvDSThu["DanhBo", i].Value.ToString()) == false && dgvDSThu["DanhBo", i].Value.ToString().Length == 11)
                        dr["DanhBo"] = dgvDSThu["DanhBo", i].Value.ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = dgvDSThu["HoTen", i].Value.ToString();
                    dr["DiaChi"] = dgvDSThu["DiaChi", i].Value.ToString();

                    dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
                }
            rptDanhSach_Ngang rpt = new rptDanhSach_Ngang();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void dgvDSThu_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSThu.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmThaoThuMoi frm = new frmThaoThuMoi(int.Parse(dgvDSThu["IDCT", dgvDSThu.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void btnInNhan_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao1 = new DataSetBaoCao();
            DataSetBaoCao dsBaoCao2 = new DataSetBaoCao();
            bool flag = true;///in 2 bên
            ///
            for (int i = 0; i < dgvDSThu.Rows.Count; i++)
                if (dgvDSThu["In", i].Value != null && bool.Parse(dgvDSThu["In", i].Value.ToString()) == true)
                {
                    ThuMoi_ChiTiet en = _cThuMoi.get_ChiTiet(int.Parse(dgvDSThu["IDCT", i].Value.ToString()));
                    if (en != null)
                    {
                        if (flag == true)
                        {
                            DataRow dr = dsBaoCao1.Tables["ThaoThuTraLoi"].NewRow();

                            dr["HoTen"] = en.HoTen;
                            dr["DiaChi"] = en.DiaChi;
                            if (en.ThuMoi.MaDonMoi != null)
                                dr["SoPhieu"] = en.ThuMoi.MaDonMoi.ToString() + "/TB";
                            if (en.ThuMoi.MaDonTKH != null)
                                dr["SoPhieu"] = "TKH" + en.ThuMoi.MaDonTKH.ToString().Insert(en.ThuMoi.MaDonTKH.ToString().Length - 2, "-") + "/TB";
                            else
                                if (en.ThuMoi.MaDonTXL != null)
                                    dr["SoPhieu"] = "TXL" + en.ThuMoi.MaDonTXL.ToString().Insert(en.ThuMoi.MaDonTXL.ToString().Length - 2, "-") + "/TB";
                                else
                                    if (en.ThuMoi.MaDonTBC != null)
                                        dr["SoPhieu"] = "TBC" + en.ThuMoi.MaDonTBC.ToString().Insert(en.ThuMoi.MaDonTBC.ToString().Length - 2, "-") + "/TB";

                            dsBaoCao1.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                            flag = false;
                        }
                        else
                        {
                            DataRow dr = dsBaoCao2.Tables["ThaoThuTraLoi"].NewRow();

                            dr["HoTen"] = en.HoTen;
                            dr["DiaChi"] = en.DiaChi;
                            if (en.ThuMoi.MaDonMoi != null)
                                dr["SoPhieu"] = en.ThuMoi.MaDonMoi.ToString() + "/TB";
                            if (en.ThuMoi.MaDonTKH != null)
                                dr["SoPhieu"] = "TKH" + en.ThuMoi.MaDonTKH.ToString().Insert(en.ThuMoi.MaDonTKH.ToString().Length - 2, "-") + "/TB";
                            else
                                if (en.ThuMoi.MaDonTXL != null)
                                    dr["SoPhieu"] = "TXL" + en.ThuMoi.MaDonTXL.ToString().Insert(en.ThuMoi.MaDonTXL.ToString().Length - 2, "-") + "/TB";
                                else
                                    if (en.ThuMoi.MaDonTBC != null)
                                        dr["SoPhieu"] = "TBC" + en.ThuMoi.MaDonTBC.ToString().Insert(en.ThuMoi.MaDonTBC.ToString().Length - 2, "-") + "/TB";

                            dsBaoCao2.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                            flag = true;
                        }
                    }
                }
            rptKinhGui rpt = new rptKinhGui();
            rpt.Subreports[0].SetDataSource(dsBaoCao1);
            rpt.Subreports[1].SetDataSource(dsBaoCao2);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void txtNoiDungTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtNoiDungTimKiem.Text.Trim() != "")
                btnXem.PerformClick();
        }
    }
}
