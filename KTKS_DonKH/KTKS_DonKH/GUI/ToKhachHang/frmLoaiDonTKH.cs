using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.ToKhachHang
{
    public partial class frmLoaiDonTKH : Form
    {
        int _selectedindex = -1;
        BindingList<LoaiDon> _bSourceLD;
        CLoaiDon _cLoaiDon = new CLoaiDon();

        public frmLoaiDonTKH()
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
        }

        private void frmCapNhatLoaiDon_Load(object sender, EventArgs e)
        {
            dgvDSLoaiDon.AutoGenerateColumns = false;
            _bSourceLD = new BindingList<LoaiDon>(_cLoaiDon.LoadDSLoaiDon_All());
            dgvDSLoaiDon.DataSource = _bSourceLD;
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
                loaidon.An = bool.Parse(dgvDSLoaiDon["An", e.RowIndex].Value.ToString());
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

    }
}
