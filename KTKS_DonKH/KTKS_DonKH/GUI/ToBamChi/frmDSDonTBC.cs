using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.ToBamChi
{
    public partial class frmDSDonTBC : Form
    {
        CDonTBC _cDonTBC = new CDonTBC();

        public frmDSDonTBC()
        {
            InitializeComponent();
        }

        private void frmDSDonTBC_Load(object sender, EventArgs e)
        {
            dgvDonTBC.AutoGenerateColumns = false;
            cmbTimTheo.SelectedItem = "Ngày";
        }

        private void dgvDonTBC_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDonTBC.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDonTBC_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDonTBC.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmNhanDonTBC frm = new frmNhanDonTBC(decimal.Parse(dgvDonTBC["MaDon", dgvDonTBC.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void dgvDonTBC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDonTBC.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null&&e.Value.ToString().Length>2)
            {
                e.Value = "TBC" + e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Địa Chỉ":
                case "Số Công Văn":
                    txtNoiDungTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvDonTBC.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC") && txtNoiDungTimKiem.Text.Trim().Length > 3)
                        dgvDonTBC.DataSource = _cDonTBC.GetDSByMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("TBC", "").Replace("-", "")));
                    break;
                case "Số Công Văn":
                    dgvDonTBC.DataSource = _cDonTBC.GetDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
                case "Danh Bộ":
                    dgvDonTBC.DataSource = _cDonTBC.GetDSByDanhBo(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
                case "Địa Chỉ":
                    dgvDonTBC.DataSource = _cDonTBC.GetDSByDiaChi(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
                case "Ngày":
                    dgvDonTBC.DataSource = _cDonTBC.GetDSByCreateDate(dateTu.Value, dateDen.Value);
                    break;
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataGridViewRow item in dgvDonTBC.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                dr["LoaiBaoCao"] = "TỔ BẤM CHÌ";
                dr["MaDon"] = "TBC" + item.Cells["MaDon"].Value.ToString().Insert(item.Cells["MaDon"].Value.ToString().Length - 2, "-");
                dr["STT"] = item.Cells["STT"].Value;
                dr["TenLD"] = item.Cells["TenLD"].Value.ToString();
                dr["SoCongVan"] = item.Cells["SoCongVan"].Value.ToString();
                dr["NgayNhan"] = item.Cells["CreateDate"].Value.ToString();
                if (!string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString()) && item.Cells["DanhBo"].Value.ToString().Length == 11)
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item.Cells["HoTen"].Value;
                dr["DiaChi"] = item.Cells["DiaChi"].Value;
                dr["NoiDung"] = item.Cells["NoiDung"].Value;

                dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
            }
            rptDSDonTXL rpt = new rptDSDonTXL();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }


    }
}
