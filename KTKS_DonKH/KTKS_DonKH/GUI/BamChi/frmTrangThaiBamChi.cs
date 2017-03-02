using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmTrangThaiBamChi : Form
    {
        string _mnu = "mnuTrangThaiBamChi";
        CTrangThaiBamChi _cTrangThaiBamChi = new CTrangThaiBamChi();
        int _selectedindexTTBC = -1;
        BindingList<TrangThaiBamChi> _blTrangThaiBamChi;

        public frmTrangThaiBamChi()
        {
            InitializeComponent();
        }

        private void frmTrangThaiBamChi_Load(object sender, EventArgs e)
        {
            dgvDSTrangThaiBC.AutoGenerateColumns = false;
            LoadDataTable();
        }

        public void LoadDataTable()
        {
            _blTrangThaiBamChi = new BindingList<TrangThaiBamChi>(_cTrangThaiBamChi.GetDS());
            dgvDSTrangThaiBC.DataSource = _blTrangThaiBamChi;
        }

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
                dgvDSTrangThaiBC.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception)
            {
            }
        }

        private void btnThemTrangThaiBC_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (txtTrangThaiBC.Text.Trim() != "")
                {
                    TrangThaiBamChi trangthaibamchi = new TrangThaiBamChi();
                    trangthaibamchi.TenTTBC = txtTrangThaiBC.Text.Trim();
                    trangthaibamchi.STT = _cTrangThaiBamChi.GetMaxSTT() + 1;

                    if (_cTrangThaiBamChi.Them(trangthaibamchi))
                    {
                        txtTrangThaiBC.Text = "";
                        LoadDataTable();
                    }
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSuaTrangThaiBC_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                if (_selectedindexTTBC != -1)
                    if (txtTrangThaiBC.Text.Trim() != "")
                    {
                        TrangThaiBamChi trangthaibamchi = _cTrangThaiBamChi.Get(int.Parse(dgvDSTrangThaiBC["MaTTBC", _selectedindexTTBC].Value.ToString()));
                        trangthaibamchi.TenTTBC = txtTrangThaiBC.Text.Trim();

                        if (_cTrangThaiBamChi.Sua(trangthaibamchi))
                        {
                            txtTrangThaiBC.Text = "";
                            _selectedindexTTBC = -1;
                            LoadDataTable();
                        }
                    }
                    else
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoaTrangThaiBC_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                if (_selectedindexTTBC != -1 && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    if (_cTrangThaiBamChi.Xoa(_cTrangThaiBamChi.Get(int.Parse(dgvDSTrangThaiBC["MaTTBC", _selectedindexTTBC].Value.ToString()))))
                    {
                        txtTrangThaiBC.Text = "";
                        _selectedindexTTBC = -1;
                        LoadDataTable();
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnUpTrangThaiBC_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvDSTrangThaiBC.SelectedRows[0].Index; // get the index of the currently selected row
                if (rowIndex == 0)
                {
                    MessageBox.Show("first line");
                    return;
                }
                List<string> list = new List<string>();
                for (int i = 0; i < dgvDSTrangThaiBC.Columns.Count; i++)
                {
                    list.Add(dgvDSTrangThaiBC.SelectedRows[0].Cells[i].Value.ToString());// array of data stored in the list of the currently selected row 
                }
                for (int j = 0; j < dgvDSTrangThaiBC.Columns.Count; j++)
                {
                    dgvDSTrangThaiBC.Rows[rowIndex].Cells[j].Value = dgvDSTrangThaiBC.Rows[rowIndex - 1].Cells[j].Value;
                    dgvDSTrangThaiBC.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
                }
                dgvDSTrangThaiBC.Rows[rowIndex - 1].Selected = true;
                //dgvDSTrangThaiBC.Rows[rowIndex].Selected = false;
                for (int i = 0; i < dgvDSTrangThaiBC.Rows.Count; i++)
                {
                    TrangThaiBamChi trangthaibamchi = _cTrangThaiBamChi.Get(int.Parse(dgvDSTrangThaiBC["MaTTBC", i].Value.ToString()));
                    trangthaibamchi.STT = i;
                    _cTrangThaiBamChi.Sua(trangthaibamchi);
                }
                _selectedindexTTBC = -1;
            }
            catch
            {
            }
        }

        private void btnDownTrangThaiBC_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvDSTrangThaiBC.SelectedRows[0].Index; // get the index of the currently selected row
                if (rowIndex == dgvDSTrangThaiBC.Rows.Count - 1)
                {
                    MessageBox.Show("is the last line!");
                    return;
                }
                List<string> list = new List<string>();
                for (int i = 0; i < dgvDSTrangThaiBC.Columns.Count; i++)
                {
                    list.Add(dgvDSTrangThaiBC.SelectedRows[0].Cells[i].Value.ToString()); // array of data stored in the list of the currently selected row 
                }
                for (int j = 0; j < dgvDSTrangThaiBC.Columns.Count; j++)
                {
                    dgvDSTrangThaiBC.Rows[rowIndex].Cells[j].Value = dgvDSTrangThaiBC.Rows[rowIndex + 1].Cells[j].Value;
                    dgvDSTrangThaiBC.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
                }
                dgvDSTrangThaiBC.Rows[rowIndex + 1].Selected = true;
                //dgvDSTrangThaiBC.Rows[rowIndex].Selected = false;
                for (int i = 0; i < dgvDSTrangThaiBC.Rows.Count; i++)
                {
                    TrangThaiBamChi trangthaibamchi = _cTrangThaiBamChi.Get(int.Parse(dgvDSTrangThaiBC["MaTTBC", i].Value.ToString()));
                    trangthaibamchi.STT = i;
                    _cTrangThaiBamChi.Sua(trangthaibamchi);
                }
                _selectedindexTTBC = -1;
            }
            catch
            {
            }
        }

        #endregion

        int rowIndexFromMouseDown;
        DataGridViewRow rw;
        private void dgvDSTrangThaiBC_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvDSTrangThaiBC.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvDSTrangThaiBC.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var item = this._blTrangThaiBamChi[rowIndexFromMouseDown];
                _blTrangThaiBamChi.RemoveAt(rowIndexFromMouseDown);
                _blTrangThaiBamChi.Insert(rowIndexOfItemUnderMouseToDrop, item);

                ///update STT dô database
                for (int i = 0; i < _blTrangThaiBamChi.Count; i++)
                {
                    _blTrangThaiBamChi[i].STT = i + 1;
                }
                _cTrangThaiBamChi.SubmitChanges();
            }
        }

        private void dgvDSTrangThaiBC_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvDSTrangThaiBC.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvDSTrangThaiBC_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDSTrangThaiBC.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw = dgvDSTrangThaiBC.SelectedRows[0];
                    rowIndexFromMouseDown = dgvDSTrangThaiBC.SelectedRows[0].Index;
                    dgvDSTrangThaiBC.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }
    }
}
