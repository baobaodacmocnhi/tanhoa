using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DieuChinhBienDong;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDCBD : Form
    {
        DonKH _donkh = new DonKH();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();


        public frmDCBD()
        {
            InitializeComponent();
        }

        public frmDCBD(DonKH donkh)
        {
            _donkh = donkh;
            InitializeComponent();
        }

        private void frmDCBD_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            dgvDSSoDangKy.AutoGenerateColumns = false;
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSSoDangKy.Columns["MaLCT"];
            cmbColumn.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            cmbColumn.DisplayMember = "TenLCT";
            cmbColumn.ValueMember = "MaLCT";

            txtDanhBo.Text = _donkh.DanhBo;
            txtHopDong.Text = _donkh.HopDong;
            txtHoTen_BD.Text = _donkh.HoTen;
            txtDiaChi_BD.Text = _donkh.DiaChi;
            txtMST_BD.Text = _donkh.MSThue;
            txtGB_BD.Text = _donkh.GiaBieu;
            txtDM_BD.Text = _donkh.DinhMuc;
            txtSH_BD.Text = _donkh.SH;
            txtSX_BD.Text = _donkh.SX;
            txtDV_BD.Text = _donkh.DV;
            txtHCSN_BD.Text = _donkh.HCSN;

            dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(_donkh.DanhBo);
        }

        private void dgvDSSoDangKy_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSSoDangKy.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSSoDangKy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                    sửaToolStripMenuItem.Enabled = true;
                else
                    sửaToolStripMenuItem.Enabled = false;
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvDSSoDangKy.CurrentCell = dgvDSSoDangKy.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvDSSoDangKy_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvDSSoDangKy, new Point(e.X, e.Y));
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            frmSoDK frm = new frmSoDK("Thêm", source);
            if (frm.ShowDialog() == DialogResult.OK)
                dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(_donkh.DanhBo);
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("DanhBo",txtDanhBo.Text.Trim());
            source.Add("MaLCT", dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString());
            source.Add("MaCT", dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString());
            source.Add("SoNKTong", dgvDSSoDangKy.CurrentRow.Cells["SoNKTong"].Value.ToString());
            source.Add("SoNKDangKy", dgvDSSoDangKy.CurrentRow.Cells["SoNKDangKy"].Value.ToString());
            source.Add("NgayHetHan", dgvDSSoDangKy.CurrentRow.Cells["NgayHetHan"].Value.ToString());
            source.Add("ThoiHan", dgvDSSoDangKy.CurrentRow.Cells["ThoiHan"].Value.ToString());
            frmSoDK frm = new frmSoDK("Sửa", source);
            if (frm.ShowDialog() == DialogResult.OK)
                dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(_donkh.DanhBo);
        }

        private void cắtChuyểnĐịnhMứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatChuyenDM frm = new frmCatChuyenDM();
            frm.ShowDialog();
        }


    }
}
