using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.GUI.KhachHang;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.DieuChinhBienDong;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDSDCBD : Form
    {
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CDonKH _cDonKH = new CDonKH();
        CDCBD _cDCBD = new CDCBD();

        public frmDSDCBD()
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

        private void frmDSDCBD_Load(object sender, EventArgs e)
        {
            dgvDSDCBD.AutoGenerateColumns = false;
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSDCBD.Columns["MaChuyen"];
            cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi("DCBD","KTXM");
            cmbColumn.DisplayMember = "NoiChuyenDi";
            cmbColumn.ValueMember = "MaChuyen";
            radChuDuyet.Checked = true;
        }

        private void dgvDSDCBD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDCBD.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDCBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDCBD.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(int.Parse(dgvDSDCBD["MaDon", dgvDSDCBD.CurrentRow.Index].Value.ToString())));
                frm.ShowDialog();
            }
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
                dgvDSDCBD.DataSource = _cDCBD.LoadDSKTXMDaDuyet();
        }

        private void radChuDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuDuyet.Checked)
                dgvDSDCBD.DataSource = _cDCBD.LoadDSKTXMChuaDuyet();
        }

        private void dgvDSDCBD_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvDSDCBD.CurrentCell = dgvDSDCBD.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvDSDCBD_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDSDCBD.Rows.Count > 0 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvDSDCBD, new Point(e.X, e.Y));
            }
        }

        private void điềuChỉnhBiếnĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDCBD frm = new frmDCBD(_cDonKH.getDonKHbyID(int.Parse(dgvDSDCBD["MaDon", dgvDSDCBD.CurrentRow.Index].Value.ToString())));
            frm.ShowDialog();
        }

        private void điềuChỉnhHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        

        
    }
}
