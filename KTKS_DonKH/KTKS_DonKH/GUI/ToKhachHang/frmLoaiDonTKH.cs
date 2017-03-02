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
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.ToKhachHang
{
    public partial class frmLoaiDonTKH : Form
    {
        string _mnu = "mnuLoaiDon";
        int _selectedindex = -1;
        BindingList<LoaiDon> _bSourceLD;
        CLoaiDon _cLoaiDon = new CLoaiDon();

        public frmLoaiDonTKH()
        {
            InitializeComponent();
        }

        private void frmCapNhatLoaiDon_Load(object sender, EventArgs e)
        {
            dgvDSLoaiDon.AutoGenerateColumns = false;
            _bSourceLD = new BindingList<LoaiDon>(_cLoaiDon.LoadDSLoaiDon_All());
            dgvDSLoaiDon.DataSource = _bSourceLD;
        }

        public void Clear()
        {
            txtKyHieuLD.Text = "";
            txtTenLD.Text = "";
            _selectedindex = -1;
            _bSourceLD = new BindingList<LoaiDon>(_cLoaiDon.LoadDSLoaiDon_All());
            dgvDSLoaiDon.DataSource = _bSourceLD;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (txtKyHieuLD.Text.Trim() != "" && txtTenLD.Text.Trim() != "")
                    {
                        LoaiDon loaidon = new LoaiDon();
                        loaidon.KyHieuLD = txtKyHieuLD.Text.Trim();
                        loaidon.TenLD = txtTenLD.Text.Trim();
                        loaidon.STT = _cLoaiDon.GetMaxSTT() + 1;

                        if (_cLoaiDon.Them(loaidon))
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
                            LoaiDon loaidon = _cLoaiDon.getLoaiDonbyID(int.Parse(dgvDSLoaiDon["MaLD", _selectedindex].Value.ToString()));
                            loaidon.KyHieuLD = txtKyHieuLD.Text.Trim();
                            loaidon.TenLD = txtTenLD.Text.Trim();

                            if (_cLoaiDon.Sua(loaidon))
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
                        if (_cLoaiDon.Xoa(_cLoaiDon.getLoaiDonbyID(int.Parse(dgvDSLoaiDon["MaLD", _selectedindex].Value.ToString()))))
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
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    try
                    {
                        LoaiDon loaidon = _cLoaiDon.getLoaiDonbyID(int.Parse(dgvDSLoaiDon["MaLD", e.RowIndex].Value.ToString()));
                        loaidon.An = bool.Parse(dgvDSLoaiDon["An", e.RowIndex].Value.ToString());
                        _cLoaiDon.Sua(loaidon);
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
    }
}

