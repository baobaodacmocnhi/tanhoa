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
                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                            dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                        else
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                    break;
                case "Danh Bộ":
                    dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                    break;
                case "Ngày":
                    if (chkCreateBy.Checked == true)
                        dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet(CTaiKhoan.MaUser,dateTu.Value, dateDen.Value);
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

                            dr["SoPhieu"] = dgvDSThu["MaDon", i].Value.ToString().Insert(dgvDSThu["MaDon", i].Value.ToString().Length - 2, "-");

                            dr["HoTen"] = dgvDSThu["HoTen", i].Value.ToString();
                            dr["DiaChi"] = dgvDSThu["DiaChi", i].Value.ToString();
                            if (!string.IsNullOrEmpty(dgvDSThu["DanhBo", i].Value.ToString()) && dgvDSThu["DanhBo", i].Value.ToString().Length == 11)
                                dr["DanhBo"] = dgvDSThu["DanhBo", i].Value.ToString().Insert(7, " ").Insert(4, " ");
                            dr["GiaBieu"] = dgvDSThu["GiaBieu", i].Value.ToString();
                            dr["DinhMuc"] = dgvDSThu["DinhMuc", i].Value.ToString();
                            dr["CanCu"] = dgvDSThu["CanCu", i].Value.ToString();
                            dr["VaoLuc"] = dgvDSThu["VaoLuc", i].Value.ToString();
                            dr["VeViec"] = dgvDSThu["VeViec", i].Value.ToString();
                            dr["Lan"] = dgvDSThu["Lan", i].Value.ToString();
                            dr["NoiNhan"] = _cTaiKhoan.GetHoTen(int.Parse(dgvDSThu["CreateBy", i].Value.ToString()));

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
            if (dgvDSThu.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
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
            foreach (DataGridViewRow item in dgvDSThu.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                dr["LoaiBaoCao"] = "GỬI THƯ MỜI";
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                if (string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString())==false && item.Cells["DanhBo"].Value.ToString().Length == 11)
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                
                dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
            }
            rptDanhSach rpt = new rptDanhSach();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void dgvDSThu_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSThu.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmThaoThuMoi frm = new frmThaoThuMoi(int.Parse(dgvDSThu["SoPhieu", dgvDSThu.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }
    }
}
