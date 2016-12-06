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
        BindingList<LoaiDon> _bSourceLD;
        int _selectedindexTXL = -1;
        BindingList<LoaiDonTXL> _bSourceLDTXL;
        CLoaiDon _cLoaiDon = new CLoaiDon();
        CLoaiDonTXL _cLoaiDonTXL = new CLoaiDonTXL();

        public frmLoaiDon()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtKyHieuLD.Text = "";
            txtTenLD.Text = "";
            _selectedindex = -1;
            _bSourceLD = new BindingList<LoaiDon>(_cLoaiDon.LoadDSLoaiDon_All());
            dgvDSLoaiDon.DataSource = _bSourceLD;
            ///
            txtKyHieuLDTXL.Text = "";
            txtTenLDTXL.Text = "";
            _selectedindexTXL = -1;
            _bSourceLDTXL = new BindingList<LoaiDonTXL>(_cLoaiDonTXL.LoadDSLoaiDonTXL_All());
            dgvDSLoaiDonTXL.DataSource = _bSourceLDTXL;
        }

        private void frmCapNhatLoaiDon_Load(object sender, EventArgs e)
        {
            dgvDSLoaiDon.AutoGenerateColumns = false;
            _bSourceLD = new BindingList<LoaiDon>(_cLoaiDon.LoadDSLoaiDon_All());
            dgvDSLoaiDon.DataSource = _bSourceLD;

            dgvDSLoaiDonTXL.AutoGenerateColumns = false;
            _bSourceLDTXL = new BindingList<LoaiDonTXL>(_cLoaiDonTXL.LoadDSLoaiDonTXL_All());
            dgvDSLoaiDonTXL.DataSource = _bSourceLDTXL;
        }

        #region Tổ Khách Hàng

        int rowIndexFromMouseDown;
        DataGridViewRow rw;
        private void dgvDSLoaiDon_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvDSLoaiDon.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvDSLoaiDon.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var item = this._bSourceLD[rowIndexFromMouseDown];
                _bSourceLD.RemoveAt(rowIndexFromMouseDown);
                _bSourceLD.Insert(rowIndexOfItemUnderMouseToDrop, item);

                ///update STT dô database
                for (int i = 0; i < _bSourceLD.Count; i++)
                {
                    _bSourceLD[i].STT = i + 1;
                }
                _cLoaiDon.SubmitChanges();
            }
        }

        private void dgvDSLoaiDon_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvDSLoaiDon.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvDSLoaiDon_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDSLoaiDon.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw = dgvDSLoaiDon.SelectedRows[0];
                    rowIndexFromMouseDown = dgvDSLoaiDon.SelectedRows[0].Index;
                    dgvDSLoaiDon.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }

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

        private void dgvDSLoaiDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSLoaiDon.Columns[e.ColumnIndex].Name == "AnLD")
            {
                LoaiDon loaidon = _cLoaiDon.getLoaiDonbyID(int.Parse(dgvDSLoaiDon["MaLD", e.RowIndex].Value.ToString()));
                _cLoaiDon.SuaLoaiDon(loaidon);
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

        int rowIndexFromMouseDownTXL;
        DataGridViewRow rwTXL;
        private void dgvDSLoaiDonTXL_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvDSLoaiDonTXL.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvDSLoaiDonTXL.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var item = this._bSourceLDTXL[rowIndexFromMouseDownTXL];
                _bSourceLDTXL.RemoveAt(rowIndexFromMouseDownTXL);
                _bSourceLDTXL.Insert(rowIndexOfItemUnderMouseToDrop, item);

                ///update STT dô database
                for (int i = 0; i < _bSourceLDTXL.Count; i++)
                {
                    _bSourceLDTXL[i].STT = i + 1;
                }
                _cLoaiDonTXL.SubmitChanges();
            }
        }

        private void dgvDSLoaiDonTXL_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvDSLoaiDonTXL.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvDSLoaiDonTXL_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDSLoaiDonTXL.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rwTXL = dgvDSLoaiDonTXL.SelectedRows[0];
                    rowIndexFromMouseDownTXL = dgvDSLoaiDonTXL.SelectedRows[0].Index;
                    dgvDSLoaiDonTXL.DoDragDrop(rwTXL, DragDropEffects.Move);
                }
            }
        }

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

        private void dgvDSLoaiDonTXL_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSLoaiDonTXL.Columns[e.ColumnIndex].Name == "AnLDTXL")
            {
                LoaiDonTXL loaidontxl = _cLoaiDonTXL.getLoaiDonTXLbyID(int.Parse(dgvDSLoaiDonTXL["MaLDTXL", e.RowIndex].Value.ToString()));
                _cLoaiDonTXL.SuaLoaiDonTXL(loaidontxl);
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
