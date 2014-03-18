using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmQLDonTXL : Form
    {
        BindingSource DSDonKH_BS = new BindingSource();
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CDonTXL _cDonTXL = new CDonTXL();

        public frmQLDonTXL()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmQLDonTXL_Load(object sender, EventArgs e)
        {
            dgvDSDonTXL.AutoGenerateColumns = false;
            dgvDSDonTXL.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSDonTXL.Font, FontStyle.Bold);
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSDonTXL.Columns["MaChuyen"];
            cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi();
            cmbColumn.DisplayMember = "NoiChuyenDi";
            cmbColumn.ValueMember = "MaChuyen";

            dgvDSDonTXL.DataSource = DSDonKH_BS;
            radAll.Checked = true;

            cmbTimTheo.SelectedIndex = 3;
            dateTimKiem.Location = txtNoiDungTimKiem.Location;
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                DSDonKH_BS.DataSource = _cDonTXL.LoadDSDonTXLDaDuyet();
                cmbTimTheo.SelectedIndex = 0;
            }
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaDuyet.Checked)
            {
                DSDonKH_BS.DataSource = _cDonTXL.LoadDSDonTXLChuaDuyet();
                cmbTimTheo.SelectedIndex = 0;
            }
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radAll.Checked)
            {
                DSDonKH_BS.DataSource = _cDonTXL.LoadDSAllDonTXL();
                cmbTimTheo.SelectedIndex = 0;
            }
        }

        private void dgvDSDonTXL_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDonTXL.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDonTXL_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDonTXL.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "Cập Nhật");
                source.Add("MaDon", dgvDSDonTXL["MaDon", dgvDSDonTXL.CurrentRow.Index].Value.ToString());
                frmShowDonTXL frm = new frmShowDonTXL(source);
                if (frm.ShowDialog() == DialogResult.OK)
                    if (radChuaDuyet.Checked)
                        DSDonKH_BS.DataSource = _cDonTXL.LoadDSDonTXLChuaDuyet();
                    else
                        if (radDaDuyet.Checked)
                            DSDonKH_BS.DataSource = _cDonTXL.LoadDSDonTXLDaDuyet();
                        else
                            if (radAll.Checked)
                                DSDonKH_BS.DataSource = _cDonTXL.LoadDSAllDonTXL();
            }
        }

        private void dgvDSDonTXL_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(dgvDSDonTXL["MaDon", e.RowIndex].ToString()));
            dontxl.Chuyen = true;
            dontxl.MaChuyen = dgvDSDonTXL["MaChuyen", e.RowIndex].ToString();
            dontxl.LyDoChuyen = dgvDSDonTXL["LyDoChuyen", e.RowIndex].ToString();
            //if (string.IsNullOrEmpty(dgvDSDonTXL["SoLuongDiaChi", e.RowIndex].ToString()))
            //    dontxl.SoLuongDiaChi = null;
            //else
            //    dontxl.SoLuongDiaChi = int.Parse(dgvDSDonTXL["SoLuongDiaChi", e.RowIndex].ToString());
            dontxl.NVKiemTra = dgvDSDonTXL["NVKiemTra", e.RowIndex].ToString();
            _cDonTXL.SuaDonTXL(dontxl);
        }

        private void dgvDSDonTXL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDonTXL.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = "TXL"+e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    txtNoiDungTimKiem.Visible = true;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày Lập":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Khoảng Thời Gian":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    DSDonKH_BS.RemoveFilter();
                    break;
            }
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiDungTimKiem.Text.Trim() != "")
            {
                string expression = "";
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                        break;
                }
                DSDonKH_BS.Filter = expression;
            }
            else
                DSDonKH_BS.RemoveFilter();
        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
            DSDonKH_BS.Filter = expression;
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
            DSDonKH_BS.Filter = expression;
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
            DSDonKH_BS.Filter = expression;
        }
    }
}
