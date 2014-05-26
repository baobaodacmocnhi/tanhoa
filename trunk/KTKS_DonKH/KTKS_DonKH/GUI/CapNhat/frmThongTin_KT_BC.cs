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
    public partial class frmThongTin_KT_BC : Form
    {
        CHienTrangKiemTra _cHienTrangKiemTra = new CHienTrangKiemTra();
        CTrangThaiBamChi _cTrangThaiBamChi = new CTrangThaiBamChi();
        int _selectedindexHTKT = -1;
        int _selectedindexTTBC = -1;

        public frmThongTin_KT_BC()
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

        private void frmThongTin_KT_BC_Load(object sender, EventArgs e)
        {
            dgvDSHienTrangKT.AutoGenerateColumns = false;
            dgvDSHienTrangKT.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSHienTrangKT.Font, FontStyle.Bold);
            dgvDSHienTrangKT.DataSource = _cHienTrangKiemTra.LoadDSHienTrangKiemTra();

            dgvDSTrangThaiBC.AutoGenerateColumns = false;
            dgvDSTrangThaiBC.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSTrangThaiBC.Font, FontStyle.Bold);
            dgvDSTrangThaiBC.DataSource = _cTrangThaiBamChi.LoadDSTrangThaiBamChi();
        }

        #region Hiện Trạng Kiểm Tra

        private void dgvDSHienTrangKT_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSHienTrangKT.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSHienTrangKT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindexHTKT = e.RowIndex;
                txtHienTrangKT.Text = dgvDSHienTrangKT["TenHTKT", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThemHienTrangKT_Click(object sender, EventArgs e)
        {
            if (txtHienTrangKT.Text.Trim() != "")
            {
                HienTrangKiemTra hientrangkiemtra = new HienTrangKiemTra();
                hientrangkiemtra.TenHTKT = txtHienTrangKT.Text.Trim();

                if (_cHienTrangKiemTra.ThemHienTrangKiemTra(hientrangkiemtra))
                {
                    txtHienTrangKT.Text = "";
                    dgvDSHienTrangKT.DataSource = _cHienTrangKiemTra.LoadDSHienTrangKiemTra();
                }
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSuaHienTrangKT_Click(object sender, EventArgs e)
        {
            if (_selectedindexHTKT != -1)
                if (txtHienTrangKT.Text.Trim() != "")
                {
                    HienTrangKiemTra hientrangkiemtra = _cHienTrangKiemTra.getHienTrangKiemTrabyID(int.Parse(dgvDSHienTrangKT["MaHTKT", _selectedindexHTKT].Value.ToString()));
                    hientrangkiemtra.TenHTKT = txtHienTrangKT.Text.Trim();

                    if (_cHienTrangKiemTra.SuaHienTrangKiemTra(hientrangkiemtra))
                    {
                        txtHienTrangKT.Text = "";
                        _selectedindexHTKT = -1;
                        dgvDSHienTrangKT.DataSource = _cHienTrangKiemTra.LoadDSHienTrangKiemTra();
                    }
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Trạng Thái Bấm Chì

        private void dgvDSTrangThaiBC_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSTrangThaiBC.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSTrangThaiBC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindexTTBC = e.RowIndex;
                txtTrangThaiBC.Text = dgvDSTrangThaiBC["TenTTBC", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThemTrangThaiBC_Click(object sender, EventArgs e)
        {
            if (txtTrangThaiBC.Text.Trim() != "")
            {
                TrangThaiBamChi trangthaibamchi = new TrangThaiBamChi();
                trangthaibamchi.TenTTBC = txtTrangThaiBC.Text.Trim();

                if (_cTrangThaiBamChi.ThemTrangThaiBamChi(trangthaibamchi))
                {
                    txtTrangThaiBC.Text = "";
                    dgvDSTrangThaiBC.DataSource = _cTrangThaiBamChi.LoadDSTrangThaiBamChi();
                }
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSuaTrangThaiBC_Click(object sender, EventArgs e)
        {
            if (_selectedindexTTBC != -1)
                if (txtTrangThaiBC.Text.Trim() != "")
                {
                    TrangThaiBamChi trangthaibamchi = _cTrangThaiBamChi.getTrangThaiBamChibyID(int.Parse(dgvDSTrangThaiBC["MaTTBC", _selectedindexTTBC].Value.ToString()));
                    trangthaibamchi.TenTTBC = txtTrangThaiBC.Text.Trim();

                    if (_cTrangThaiBamChi.SuaTrangThaiBamChi(trangthaibamchi))
                    {
                        txtTrangThaiBC.Text = "";
                        _selectedindexTTBC = -1;
                        dgvDSTrangThaiBC.DataSource = _cTrangThaiBamChi.LoadDSTrangThaiBamChi();
                    }
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
