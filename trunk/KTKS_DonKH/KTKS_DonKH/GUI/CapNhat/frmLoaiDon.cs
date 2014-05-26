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

namespace KTKS_DonKH.GUI.CapNhat
{
    public partial class frmLoaiDon : Form
    {
        int _selectedindex = -1;
        int _selectedindexTXL = -1;
        CLoaiDon _cLoaiDon = new CLoaiDon();
        CLoaiDonTXL _cLoaiDonTXL = new CLoaiDonTXL();

        public frmLoaiDon()
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

        public void Clear()
        {
            txtKyHieuLD.Text = "";
            txtTenLD.Text = "";
            _selectedindex = -1;
            dgvDSLoaiDon.DataSource = _cLoaiDon.LoadDSLoaiDon();
            ///
            txtKyHieuLDTXL.Text = "";
            txtTenLDTXL.Text = "";
            _selectedindexTXL = -1;
            dgvDSLoaiDonTXL.DataSource = _cLoaiDonTXL.LoadDSLoaiDonTXL();
        }

        private void frmCapNhatLoaiDon_Load(object sender, EventArgs e)
        {
            dgvDSLoaiDon.AutoGenerateColumns = false;
            dgvDSLoaiDon.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSLoaiDon.Font, FontStyle.Bold);
            dgvDSLoaiDon.DataSource = _cLoaiDon.LoadDSLoaiDon();

            dgvDSLoaiDonTXL.AutoGenerateColumns = false;
            dgvDSLoaiDonTXL.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSLoaiDon.Font, FontStyle.Bold);
            dgvDSLoaiDonTXL.DataSource = _cLoaiDonTXL.LoadDSLoaiDonTXL();
        }

        #region Tổ Khách Hàng

        private void dgvDSLoaiDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtKyHieuLD.Text = dgvDSLoaiDon["KyHieuLD", e.RowIndex].Value.ToString();
                txtTenLD.Text = dgvDSLoaiDon["TenLD", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void dgvDSLoaiDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSLoaiDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtKyHieuLD.Text.Trim() != "" && txtTenLD.Text.Trim() != "")
            {
                LoaiDon loaidon = new LoaiDon();
                loaidon.KyHieuLD = txtKyHieuLD.Text.Trim();
                loaidon.TenLD = txtTenLD.Text.Trim();

                if (_cLoaiDon.ThemLoaiDon(loaidon))
                    Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
            {
                if (txtKyHieuLD.Text.Trim() != "" && txtTenLD.Text.Trim() != "")
                {
                    LoaiDon loaidon = _cLoaiDon.getLoaiDonbyID(int.Parse(dgvDSLoaiDon["MaLD", _selectedindex].Value.ToString()));
                    loaidon.KyHieuLD = txtKyHieuLD.Text.Trim();
                    loaidon.TenLD = txtTenLD.Text.Trim();

                    if (_cLoaiDon.SuaLoaiDon(loaidon))
                        Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Tổ Xử Lý

        private void dgvDSLoaiDonTXL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindexTXL = e.RowIndex;
                txtKyHieuLDTXL.Text = dgvDSLoaiDonTXL["KyHieuLD", e.RowIndex].Value.ToString();
                txtTenLDTXL.Text = dgvDSLoaiDonTXL["TenLD", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void dgvDSLoaiDonTXL_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSLoaiDonTXL.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnThemTXL_Click(object sender, EventArgs e)
        {
            if (txtKyHieuLDTXL.Text.Trim() != "" && txtTenLDTXL.Text.Trim() != "")
            {
                LoaiDonTXL loaidontxl = new LoaiDonTXL();
                loaidontxl.KyHieuLD = txtKyHieuLDTXL.Text.Trim();
                loaidontxl.TenLD = txtTenLDTXL.Text.Trim();

                if (_cLoaiDonTXL.ThemLoaiDonTXL(loaidontxl))
                    Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSuaTXL_Click(object sender, EventArgs e)
        {
            if (_selectedindexTXL != -1)
            {
                if (txtKyHieuLDTXL.Text.Trim() != "" && txtTenLDTXL.Text.Trim() != "")
                {
                    LoaiDonTXL loaidontxl = _cLoaiDonTXL.getLoaiDonTXLbyID(int.Parse(dgvDSLoaiDonTXL["MaLD", _selectedindexTXL].Value.ToString()));
                    loaidontxl.KyHieuLD = txtKyHieuLDTXL.Text.Trim();
                    loaidontxl.TenLD = txtTenLDTXL.Text.Trim();

                    if (_cLoaiDonTXL.SuaLoaiDonTXL(loaidontxl))
                        Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
