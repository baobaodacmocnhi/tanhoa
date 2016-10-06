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

namespace KTKS_DonKH.GUI.KhachHang
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
            dgvDSLoaiDonTXL.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSLoaiDonTXL.Font, FontStyle.Bold);
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
                dgvDSLoaiDon.Rows[e.RowIndex].Selected = true;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
            {
                if (_cLoaiDon.XoaLoaiDon(_cLoaiDon.getLoaiDonbyID(int.Parse(dgvDSLoaiDon["MaLD", _selectedindex].Value.ToString()))))
                    Clear();
            }
        }

        #endregion

        #region Tổ Xử Lý

        private void dgvDSLoaiDonTXL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindexTXL = e.RowIndex;
                txtKyHieuLDTXL.Text = dgvDSLoaiDonTXL["KyHieuLDTXL", e.RowIndex].Value.ToString();
                txtTenLDTXL.Text = dgvDSLoaiDonTXL["TenLDTXL", e.RowIndex].Value.ToString();
                dgvDSLoaiDonTXL.Rows[e.RowIndex].Selected = true;
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
                    LoaiDonTXL loaidontxl = _cLoaiDonTXL.getLoaiDonTXLbyID(int.Parse(dgvDSLoaiDonTXL["MaLDTXL", _selectedindexTXL].Value.ToString()));
                    loaidontxl.KyHieuLD = txtKyHieuLDTXL.Text.Trim();
                    loaidontxl.TenLD = txtTenLDTXL.Text.Trim();

                    if (_cLoaiDonTXL.SuaLoaiDonTXL(loaidontxl))
                        Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTXL_Click(object sender, EventArgs e)
        {
            if (_selectedindexTXL != -1)
            {
                if (_cLoaiDonTXL.XoaLoaiDonTXL(_cLoaiDonTXL.getLoaiDonTXLbyID(int.Parse(dgvDSLoaiDonTXL["MaLD", _selectedindexTXL].Value.ToString()))))
                    Clear();
            }
        }

        #endregion

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvDSLoaiDon.SelectedRows[0].Index; // get the index of the currently selected row
                if (rowIndex == 0)
                {
                    MessageBox.Show("first line");
                    return;
                }
                List<string> list = new List<string>();
                for (int i = 0; i < dgvDSLoaiDon.Columns.Count; i++)
                {
                    list.Add(dgvDSLoaiDon.SelectedRows[0].Cells[i].Value.ToString());// array of data stored in the list of the currently selected row 
                }
                for (int j = 0; j < dgvDSLoaiDon.Columns.Count; j++)
                {
                    dgvDSLoaiDon.Rows[rowIndex].Cells[j].Value = dgvDSLoaiDon.Rows[rowIndex - 1].Cells[j].Value;
                    dgvDSLoaiDon.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
                }
                dgvDSLoaiDon.Rows[rowIndex - 1].Selected = true;
                //dgvDSLoaiDon.Rows[rowIndex].Selected = false;
                for (int i = 0; i < dgvDSLoaiDon.Rows.Count; i++)
                {
                    LoaiDon loaidon = _cLoaiDon.getLoaiDonbyID(int.Parse(dgvDSLoaiDon["MaLD", i].Value.ToString()));
                    loaidon.STT = i;
                    _cLoaiDon.SuaLoaiDon(loaidon);
                }
                _selectedindex = -1;
            }
            catch
            {
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvDSLoaiDon.SelectedRows[0].Index; // get the index of the currently selected row
                if (rowIndex == dgvDSLoaiDon.Rows.Count - 1)
                {
                    MessageBox.Show("is the last line!");
                    return;
                }
                List<string> list = new List<string>();
                for (int i = 0; i < dgvDSLoaiDon.Columns.Count; i++)
                {
                    list.Add(dgvDSLoaiDon.SelectedRows[0].Cells[i].Value.ToString()); // array of data stored in the list of the currently selected row 
                }
                for (int j = 0; j < dgvDSLoaiDon.Columns.Count; j++)
                {
                    dgvDSLoaiDon.Rows[rowIndex].Cells[j].Value = dgvDSLoaiDon.Rows[rowIndex + 1].Cells[j].Value;
                    dgvDSLoaiDon.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
                }
                dgvDSLoaiDon.Rows[rowIndex + 1].Selected = true;
                //dgvDSLoaiDon.Rows[rowIndex].Selected = false;
                for (int i = 0; i < dgvDSLoaiDon.Rows.Count; i++)
                {
                    LoaiDon loaidon = _cLoaiDon.getLoaiDonbyID(int.Parse(dgvDSLoaiDon["MaLD", i].Value.ToString()));
                    loaidon.STT = i;
                    _cLoaiDon.SuaLoaiDon(loaidon);
                }
                _selectedindex = -1;
            }
            catch
            {
            }
        }

        private void btnUpTXL_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvDSLoaiDonTXL.SelectedRows[0].Index; // get the index of the currently selected row
                if (rowIndex == 0)
                {
                    MessageBox.Show("first line");
                    return;
                }
                List<string> list = new List<string>();
                for (int i = 0; i < dgvDSLoaiDonTXL.Columns.Count; i++)
                {
                    list.Add(dgvDSLoaiDonTXL.SelectedRows[0].Cells[i].Value.ToString());// array of data stored in the list of the currently selected row 
                }
                for (int j = 0; j < dgvDSLoaiDonTXL.Columns.Count; j++)
                {
                    dgvDSLoaiDonTXL.Rows[rowIndex].Cells[j].Value = dgvDSLoaiDonTXL.Rows[rowIndex - 1].Cells[j].Value;
                    dgvDSLoaiDonTXL.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
                }
                dgvDSLoaiDonTXL.Rows[rowIndex - 1].Selected = true;
                //dgvDSLoaiDonTXL.Rows[rowIndex].Selected = false;
                for (int i = 0; i < dgvDSLoaiDonTXL.Rows.Count; i++)
                {
                    LoaiDonTXL loaidontxl = _cLoaiDonTXL.getLoaiDonTXLbyID(int.Parse(dgvDSLoaiDonTXL["MaLDTXL", i].Value.ToString()));
                    loaidontxl.STT = i;
                    _cLoaiDonTXL.SuaLoaiDonTXL(loaidontxl);
                }
                _selectedindexTXL = -1;
            }
            catch
            {
            }
        }

        private void btnDownTXL_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvDSLoaiDonTXL.SelectedRows[0].Index; // get the index of the currently selected row
                if (rowIndex == dgvDSLoaiDonTXL.Rows.Count - 1)
                {
                    MessageBox.Show("is the last line!");
                    return;
                }
                List<string> list = new List<string>();
                for (int i = 0; i < dgvDSLoaiDonTXL.Columns.Count; i++)
                {
                    list.Add(dgvDSLoaiDonTXL.SelectedRows[0].Cells[i].Value.ToString()); // array of data stored in the list of the currently selected row 
                }
                for (int j = 0; j < dgvDSLoaiDonTXL.Columns.Count; j++)
                {
                    dgvDSLoaiDonTXL.Rows[rowIndex].Cells[j].Value = dgvDSLoaiDonTXL.Rows[rowIndex + 1].Cells[j].Value;
                    dgvDSLoaiDonTXL.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
                }
                dgvDSLoaiDonTXL.Rows[rowIndex + 1].Selected = true;
                //dgvDSTrangThaiBC.Rows[rowIndex].Selected = false;
                for (int i = 0; i < dgvDSLoaiDonTXL.Rows.Count; i++)
                {
                    LoaiDonTXL loaidontxl = _cLoaiDonTXL.getLoaiDonTXLbyID(int.Parse(dgvDSLoaiDonTXL["MaLDTXL", i].Value.ToString()));
                    loaidontxl.STT = i;
                    _cLoaiDonTXL.SuaLoaiDonTXL(loaidontxl);
                }
                _selectedindexTXL = -1;
            }
            catch
            {
            }
        }

    }
}
