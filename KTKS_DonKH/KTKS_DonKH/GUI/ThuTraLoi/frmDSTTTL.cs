using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using KTKS_DonKH.DAL.ToKhachHang;
using DevExpress.XtraGrid.Views.Grid;
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.GUI.ToKhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao.ThuTraLoi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.ThuTraLoi
{
    public partial class frmDSTTTL : Form
    {
        CTTTL _cTTTL = new CTTTL();
        CDonKH _cDonKH = new CDonKH();
        CKTXM _cKTXM = new CKTXM();

        public frmDSTTTL()
        {
            InitializeComponent();
        }

        private void frmDSTTTL_Load(object sender, EventArgs e)
        {
            dgvDSThu.AutoGenerateColumns = false;

            cmbTimTheo.SelectedItem = "Ngày";
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Mã Thư":
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Thư trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < dgvDSThu.Rows.Count; i++)
                        if (dgvDSThu["In", i].Value!=null&&bool.Parse(dgvDSThu["In", i].Value.ToString()) == true)
                        {
                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                            TTTL_ChiTiet cttttl = _cTTTL.GetCT(decimal.Parse(dgvDSThu["MaCTTTTL", i].Value.ToString()));

                            //dr["SoPhieu"] = cttttl.MaCTTTTL.ToString().Insert(cttttl.MaCTTTTL.ToString().Length - 2, "-");
                            dr["LoTrinh"] = cttttl.LoTrinh;
                            dr["HoTen"] = cttttl.HoTen;
                            dr["DiaChi"] = cttttl.DiaChi;
                            if (!string.IsNullOrEmpty(cttttl.DanhBo) && cttttl.DanhBo.Length == 11)
                                dr["DanhBo"] = cttttl.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["HopDong"] = cttttl.HopDong;
                            dr["GiaBieu"] = cttttl.GiaBieu;
                            dr["DinhMuc"] = cttttl.DinhMuc;
                            if (cttttl.TTTL.MaDon!=null)
                                dr["NgayNhanDon"] = cttttl.TTTL.DonKH.CreateDate.Value.ToString("dd/MM/yyyy");
                            else
                                if (cttttl.TTTL.MaDonTXL != null)
                                dr["NgayNhanDon"] = cttttl.TTTL.DonTXL.CreateDate.Value.ToString("dd/MM/yyyy");
                            else
                                    if (cttttl.TTTL.MaDonTBC != null)
                                        dr["NgayNhanDon"] = cttttl.TTTL.DonTBC.CreateDate.Value.ToString("dd/MM/yyyy");

                            dr["VeViec"] = cttttl.VeViec;
                            dr["NoiDung"] = cttttl.NoiDung;
                            dr["NoiNhan"] = cttttl.NoiNhan + "\r\nTTL" + cttttl.MaCTTTTL.ToString().Insert(cttttl.MaCTTTTL.ToString().Length - 2, "-");
                            dr["ChucVu"] = cttttl.ChucVu;
                            dr["NguoiKy"] = cttttl.NguoiKy;

                            dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                            if (!string.IsNullOrEmpty(cttttl.DanhBo))
                            {
                                rptThaoThuTraLoi rpt = new rptThaoThuTraLoi();
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
                            else
                            {
                                rptThaoThuTraLoi_KhongDanhBo rpt = new rptThaoThuTraLoi_KhongDanhBo();
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
        }

        private void btnInNhan_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao1 = new DataSetBaoCao();
            DataSetBaoCao dsBaoCao2 = new DataSetBaoCao();
            bool flag = true;///in 2 bên
            
            for (int i = 0; i < dgvDSThu.Rows.Count; i++)
                if (dgvDSThu["In", i].Value != null && bool.Parse(dgvDSThu["In", i].Value.ToString()) == true)
                    if (flag==true)
                    {
                        DataRow dr = dsBaoCao1.Tables["ThaoThuTraLoi"].NewRow();

                        TTTL_ChiTiet cttttl = _cTTTL.GetCT(decimal.Parse(dgvDSThu["MaCTTTTL", i].Value.ToString()));

                        dr["HoTen"] = cttttl.HoTen;
                        dr["DiaChi"] = cttttl.DiaChi;

                        dsBaoCao1.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                        flag = false;
                    }
                    else
                    {
                        DataRow dr = dsBaoCao2.Tables["ThaoThuTraLoi"].NewRow();

                        TTTL_ChiTiet cttttl = _cTTTL.GetCT(decimal.Parse(dgvDSThu["MaCTTTTL", i].Value.ToString()));

                        dr["HoTen"] = cttttl.HoTen;
                        dr["DiaChi"] = cttttl.DiaChi;

                        dsBaoCao2.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                        flag = true;
                    }
            rptKinhGui rpt = new rptKinhGui();
            rpt.Subreports[0].SetDataSource(dsBaoCao1);
            rpt.Subreports[1].SetDataSource(dsBaoCao2);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                            dgvDSThu.DataSource = _cTTTL.GetDS("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                else

                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                            dgvDSThu.DataSource = _cTTTL.GetDS("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                        else
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                dgvDSThu.DataSource = _cTTTL.GetDS("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                dgvDSThu.DataSource = _cTTTL.GetDS("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                    break;
                case "Mã Thư":
                    if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        dgvDSThu.DataSource = _cTTTL.GetDS(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                    else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSThu.DataSource = _cTTTL.GetDS(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                    break;
                case "Danh Bộ":
                    dgvDSThu.DataSource = _cTTTL.GetDS(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                    break;
                case "Ngày":
                    dgvDSThu.DataSource = _cTTTL.GetDS(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }

        private void dgvDSThu_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvDSThu.Columns[e.ColumnIndex].Name == "ThuDuocKy" && e.FormattedValue.ToString() != dgvDSThu[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                TTTL_ChiTiet cttttl = _cTTTL.GetCT(decimal.Parse(dgvDSThu["MaCTTTTL", e.RowIndex].Value.ToString()));
                cttttl.ThuDuocKy = bool.Parse(e.FormattedValue.ToString());
                _cTTTL.SuaCT(cttttl);
            }
        }

        private void dgvDSThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSThu_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSThu.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmTTTL frm = new frmTTTL(decimal.Parse(dgvDSThu["MaCTTTTL", dgvDSThu.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void dgvDSThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSThu.Columns[e.ColumnIndex].Name == "MaCTTTTL" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            //if (dgvDSThu.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            //{
            //    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
        }

    }
}
