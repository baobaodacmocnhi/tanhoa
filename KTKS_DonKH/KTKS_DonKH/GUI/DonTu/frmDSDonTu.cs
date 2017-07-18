using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmDSDonTu : Form
    {
        CDonTu _cDonTu = new CDonTu();

        public frmDSDonTu()
        {
            InitializeComponent();
        }

        private void frmDSDonTu_Load(object sender, EventArgs e)
        {
            dgvDSDonTu.AutoGenerateColumns = false;

            cmbTimTheo.SelectedItem = "Ngày";
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Số Công Văn":
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
            dgvDSDonTu.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        dgvDSDonTu.DataSource = _cDonTu.GetDS(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(txtNoiDungTimKiem2.Text.Trim()));
                    else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSDonTu.DataSource = _cDonTu.GetDS(int.Parse(txtNoiDungTimKiem.Text.Trim()));
                    break;
                case "Danh Bộ":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSDonTu.DataSource = _cDonTu.GetDSByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ",""));
                    break;
                case "Số Công Văn":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSDonTu.DataSource = _cDonTu.GetDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
                case "Ngày":
                    dgvDSDonTu.DataSource = _cDonTu.GetDS(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }

        private void dgvDSDonTu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDonTu.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length ==11)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvDSDonTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDonTu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDonTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDonTu.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmNhanDonTu frm = new frmNhanDonTu(int.Parse(dgvDSDonTu["MaDon", dgvDSDonTu.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        
    }
}
