using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmHienTrangKiemTra : Form
    {
        string _mnu = "mnuHienTrangKiemTra";
        CHienTrangKiemTra _cHienTrangKiemTra = new CHienTrangKiemTra();
        int _selectedindexHTKT = -1;
        BindingList<HienTrangKiemTra> _blHienTrangKiemTra;

        public frmHienTrangKiemTra()
        {
            InitializeComponent();
        }

        private void frmThongTin_KT_BC_Load(object sender, EventArgs e)
        {
            dgvDSHienTrangKT.AutoGenerateColumns = false;
            
            LoadDataTable();
        }

        public void LoadDataTable()
        {
            _blHienTrangKiemTra = new BindingList<HienTrangKiemTra>(_cHienTrangKiemTra.LoadDSHienTrangKiemTra());
            dgvDSHienTrangKT.DataSource = _blHienTrangKiemTra;
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
                dgvDSHienTrangKT.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception)
            {
            }
        }

        private void btnThemHienTrangKT_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (txtHienTrangKT.Text.Trim() != "")
                {
                    HienTrangKiemTra hientrangkiemtra = new HienTrangKiemTra();
                    hientrangkiemtra.TenHTKT = txtHienTrangKT.Text.Trim();

                    if (_cHienTrangKiemTra.ThemHienTrangKiemTra(hientrangkiemtra))
                    {
                        txtHienTrangKT.Text = "";
                        LoadDataTable();
                    }
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSuaHienTrangKT_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
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
                            LoadDataTable();
                        }
                    }
                    else
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoaHienTrangKT_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                if (_selectedindexHTKT != -1)
                    if (_cHienTrangKiemTra.XoaHienTrangKiemTra(_cHienTrangKiemTra.getHienTrangKiemTrabyID(int.Parse(dgvDSHienTrangKT["MaHTKT", _selectedindexHTKT].Value.ToString()))))
                    {
                        txtHienTrangKT.Text = "";
                        _selectedindexHTKT = -1;
                        LoadDataTable();
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnUpHienTrangKT_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvDSHienTrangKT.SelectedRows[0].Index; // get the index of the currently selected row
                if (rowIndex == 0)
                {
                    MessageBox.Show("first line");
                    return;
                }
                List<string> list = new List<string>();
                for (int i = 0; i < dgvDSHienTrangKT.Columns.Count; i++)
                {
                    list.Add(dgvDSHienTrangKT.SelectedRows[0].Cells[i].Value.ToString());// array of data stored in the list of the currently selected row 
                }
                for (int j = 0; j < dgvDSHienTrangKT.Columns.Count; j++)
                {
                    dgvDSHienTrangKT.Rows[rowIndex].Cells[j].Value = dgvDSHienTrangKT.Rows[rowIndex - 1].Cells[j].Value;
                    dgvDSHienTrangKT.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
                }
                dgvDSHienTrangKT.Rows[rowIndex - 1].Selected = true;
                //dgvDSHienTrangKT.Rows[rowIndex].Selected = false;
                for (int i = 0; i < dgvDSHienTrangKT.Rows.Count; i++)
                {
                    HienTrangKiemTra hientrangkiemtra = _cHienTrangKiemTra.getHienTrangKiemTrabyID(int.Parse(dgvDSHienTrangKT["MaHTKT", i].Value.ToString()));
                    hientrangkiemtra.STT = i;
                    _cHienTrangKiemTra.SuaHienTrangKiemTra(hientrangkiemtra);
                }
                _selectedindexHTKT = -1;
            }
            catch
            {
            }
        }

        private void btnDownHienTrangKT_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvDSHienTrangKT.SelectedRows[0].Index; // get the index of the currently selected row
                if (rowIndex == dgvDSHienTrangKT.Rows.Count - 1)
                {
                    MessageBox.Show("is the last line!");
                    return;
                }
                List<string> list = new List<string>();
                for (int i = 0; i < dgvDSHienTrangKT.Columns.Count; i++)
                {
                    list.Add(dgvDSHienTrangKT.SelectedRows[0].Cells[i].Value.ToString()); // array of data stored in the list of the currently selected row 
                }
                for (int j = 0; j < dgvDSHienTrangKT.Columns.Count; j++)
                {
                    dgvDSHienTrangKT.Rows[rowIndex].Cells[j].Value = dgvDSHienTrangKT.Rows[rowIndex + 1].Cells[j].Value;
                    dgvDSHienTrangKT.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
                }
                dgvDSHienTrangKT.Rows[rowIndex + 1].Selected = true;
                //dgvDSTrangThaiBC.Rows[rowIndex].Selected = false;
                for (int i = 0; i < dgvDSHienTrangKT.Rows.Count; i++)
                {
                    HienTrangKiemTra hientrangkiemtra = _cHienTrangKiemTra.getHienTrangKiemTrabyID(int.Parse(dgvDSHienTrangKT["MaHTKT", i].Value.ToString()));
                    hientrangkiemtra.STT = i;
                    _cHienTrangKiemTra.SuaHienTrangKiemTra(hientrangkiemtra);
                }
                _selectedindexHTKT = -1;
            }
            catch
            {
            }
        }

        #endregion

        int rowIndexFromMouseDown;
        DataGridViewRow rw;
        private void dgvDSHienTrangKT_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvDSHienTrangKT.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvDSHienTrangKT.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var item = this._blHienTrangKiemTra[rowIndexFromMouseDown];
                _blHienTrangKiemTra.RemoveAt(rowIndexFromMouseDown);
                _blHienTrangKiemTra.Insert(rowIndexOfItemUnderMouseToDrop, item);

                ///update STT dô database
                for (int i = 0; i < _blHienTrangKiemTra.Count; i++)
                {
                    _blHienTrangKiemTra[i].STT = i + 1;
                }
                _cHienTrangKiemTra.SubmitChanges();
            }
        }

        private void dgvDSHienTrangKT_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvDSHienTrangKT.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvDSHienTrangKT_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDSHienTrangKT.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw = dgvDSHienTrangKT.SelectedRows[0];
                    rowIndexFromMouseDown = dgvDSHienTrangKT.SelectedRows[0].Index;
                    dgvDSHienTrangKT.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }

    }
}
