﻿using System;
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

namespace KTKS_DonKH.GUI.ThuMoi
{
    public partial class frmDSThuMoi : Form
    {
        CThuMoi _cThuMoi = new CThuMoi();

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
                            dgvDSThu.DataSource = _cThuMoi.GetDS("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                        else
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                dgvDSThu.DataSource = _cThuMoi.GetDS("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                dgvDSThu.DataSource = _cThuMoi.GetDS("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                    break;
                case "Danh Bộ":
                    dgvDSThu.DataSource = _cThuMoi.GetDS(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                    break;
                case "Ngày":
                    dgvDSThu.DataSource = _cThuMoi.GetDS(dateTu.Value, dateDen.Value);
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
                                dr["DanhBo"] = dgvDSThu["MaCTTTTL", i].Value.ToString().Insert(7, " ").Insert(4, " ");

                            dr["CanCu"] = dgvDSThu["CanCu", i].Value.ToString();
                            dr["VaoLuc"] = dgvDSThu["VaoLuc", i].Value.ToString();
                            dr["VeViec"] = dgvDSThu["VeViec", i].Value.ToString();
                            dr["Lan"] = dgvDSThu["Lan", i].Value.ToString();

                            dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                            rptThuMoi rpt = new rptThuMoi();
                            rpt.SetDataSource(dsBaoCao);

                            printDialog.AllowSomePages = true;
                            printDialog.ShowHelp = true;

                            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                            rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                            rpt.PrintToPrinter(1, false, 0, 0);
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
    }
}
