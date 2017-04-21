using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.TruyThu;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.TruyThu;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.TruyThu
{
    public partial class frmDSTruyThuTienNuoc : Form
    {
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();

        public frmDSTruyThuTienNuoc()
        {
            InitializeComponent();
        }

        private void frmQLTruyThuTienNuoc_Load(object sender, EventArgs e)
        {
            dgvDSTruyThuTienNuoc.AutoGenerateColumns = false;
            cmbTimTheo.SelectedItem = "Ngày";
        }

        private void CountdgvDSTruyThuTienNuoc()
        {
            int Tongm3 = 0;
            int TongTien = 0;
            foreach (DataGridViewRow item in dgvDSTruyThuTienNuoc.Rows)
            {
                Tongm3 += int.Parse(item.Cells["Tongm3"].Value.ToString());
                TongTien += int.Parse(item.Cells["TongTien"].Value.ToString());
            }
            txtTongm3.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Tongm3);
            txtTongTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTien);
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Số Phiếu":
                    txtNoiDungTimKiem.Visible = true;
                    //txtNoiDungTimKiem2.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Danh Bộ":
                    txtNoiDungTimKiem.Visible = true;
                    //txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    //txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    //txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvDSTruyThuTienNuoc.DataSource = null;
        }



        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Số Phiếu":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSTruyThuTienNuoc.DataSource = _cTTTN.GetDS(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                    break;
                case "Danh Bộ":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSTruyThuTienNuoc.DataSource = _cTTTN.GetDS(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                    break;
                case "Ngày":
                    dgvDSTruyThuTienNuoc.DataSource = _cTTTN.GetDS(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
            CountdgvDSTruyThuTienNuoc();
        }

        private void dgvDSTruyThuTienNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "MaDon")
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "MaTTTN" && e.Value != null && e.Value.ToString().Length > 2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "Tongm3")
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", decimal.Parse(dgvDSTruyThuTienNuoc["Tongm3", e.RowIndex].Value.ToString()));
            }
            if (dgvDSTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TongTien")
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", decimal.Parse(dgvDSTruyThuTienNuoc["TongTien", e.RowIndex].Value.ToString()));
            }
        }

        private void dgvDSTruyThuTienNuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSTruyThuTienNuoc.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmTruyThuTienNuoc frm = new frmTruyThuTienNuoc(decimal.Parse(dgvDSTruyThuTienNuoc["MaTTTN", dgvDSTruyThuTienNuoc.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataGridViewRow item in dgvDSTruyThuTienNuoc.Rows)
            {
                DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["MaDon"] = item.Cells["MaDon"].Value.ToString().Insert(item.Cells["MaDon"].Value.ToString().Length - 2, "-");
                dr["NgayLap"] = item.Cells["CreateDate"].Value;
                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item.Cells["HoTen"].Value;
                dr["DiaChi"] = item.Cells["DiaChi"].Value;
                dr["NoiDung"] = item.Cells["NoiDung"].Value;

                dr["TieuThuMoi"] = item.Cells["Tongm3"].Value.ToString();
                dr["TongCongMoi"] = item.Cells["TongTien"].Value.ToString();

                dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
            }

            rptDSTruyThuTienNuoc rpt = new rptDSTruyThuTienNuoc();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }
    }
}
