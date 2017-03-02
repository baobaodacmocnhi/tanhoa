using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmLoaiDonTXL : Form
    {
        string _mnu = "mnuLoaiDonTXL";
        int _selectedindex = -1;
        BindingList<LoaiDonTXL> _bSource;
        CLoaiDonTXL _cLoaiDonTXL = new CLoaiDonTXL();

        public frmLoaiDonTXL()
        {
            InitializeComponent();
        }

        private void frmLoaiDonTXL_Load(object sender, EventArgs e)
        {
            dgvLoaiDon.AutoGenerateColumns = false;
            _bSource = new BindingList<LoaiDonTXL>(_cLoaiDonTXL.GetDS_All());
            dgvLoaiDon.DataSource = _bSource;
        }

        public void Clear()
        {
            txtKyHieuLD.Text = "";
            txtTenLD.Text = "";
            _selectedindex = -1;
            _bSource = new BindingList<LoaiDonTXL>(_cLoaiDonTXL.GetDS_All());
            dgvLoaiDon.DataSource = _bSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (txtKyHieuLD.Text.Trim() != "" && txtTenLD.Text.Trim() != "")
                    {
                        LoaiDonTXL entity = new LoaiDonTXL();
                        entity.KyHieuLD = txtKyHieuLD.Text.Trim();
                        entity.TenLD = txtTenLD.Text.Trim();
                        entity.STT = _cLoaiDonTXL.GetMaxSTT() + 1;

                        if (_cLoaiDonTXL.Them(entity))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_selectedindex != -1)
                    {
                        if (txtKyHieuLD.Text.Trim() != "" && txtTenLD.Text.Trim() != "")
                        {
                            LoaiDonTXL entity = _cLoaiDonTXL.Get(int.Parse(dgvLoaiDon["MaLD", _selectedindex].Value.ToString()));
                            entity.KyHieuLD = txtKyHieuLD.Text.Trim();
                            entity.TenLD = txtTenLD.Text.Trim();

                            if (_cLoaiDonTXL.Sua(entity))
                            {
                                Clear();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_selectedindex != -1)
                    {
                        if (_cLoaiDonTXL.Xoa(_cLoaiDonTXL.Get(int.Parse(dgvLoaiDon["MaLD", _selectedindex].Value.ToString()))))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvLoaiDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtKyHieuLD.Text = dgvLoaiDon["KyHieuLD", e.RowIndex].Value.ToString();
                txtTenLD.Text = dgvLoaiDon["TenLD", e.RowIndex].Value.ToString();
                dgvLoaiDon.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception)
            {
            }
        }

        private void dgvLoaiDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLoaiDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvLoaiDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiDon.Columns[e.ColumnIndex].Name == "An")
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    try
                    {
                        LoaiDonTXL loaidontxl = _cLoaiDonTXL.Get(int.Parse(dgvLoaiDon["MaLD", e.RowIndex].Value.ToString()));
                        loaidontxl.An = bool.Parse(dgvLoaiDon["An", e.RowIndex].Value.ToString());
                        _cLoaiDonTXL.Sua(loaidontxl);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int rowIndexFromMouseDown;
        DataGridViewRow rw;
        private void dgvLoaiDon_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvLoaiDon.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvLoaiDon.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var item = this._bSource[rowIndexFromMouseDown];
                _bSource.RemoveAt(rowIndexFromMouseDown);
                _bSource.Insert(rowIndexOfItemUnderMouseToDrop, item);

                ///update STT dô database
                for (int i = 0; i < _bSource.Count; i++)
                {
                    _bSource[i].STT = i + 1;
                }
                _cLoaiDonTXL.SubmitChanges();
            }
        }

        private void dgvLoaiDon_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvLoaiDon.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvLoaiDon_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvLoaiDon.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw = dgvLoaiDon.SelectedRows[0];
                    rowIndexFromMouseDown = dgvLoaiDon.SelectedRows[0].Index;
                    dgvLoaiDon.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }

    }
}
