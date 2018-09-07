using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Globalization;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmLyDoCHDB : Form
    {
        string _mnu = "mnuLyDoCHDB";
        CCHDB_LyDo _cLyDoCHDB = new CCHDB_LyDo();
        BindingList<CHDB_LyDo> _bSource;
        int _selectedindex = -1;

        public frmLyDoCHDB()
        {
            InitializeComponent();
        }

        private void frmVeViecCHDB_Load(object sender, EventArgs e)
        {
            dgvLyDoCHDB.AutoGenerateColumns = false;
            _bSource = new BindingList<CHDB_LyDo>(_cLyDoCHDB.GetDS());
            dgvLyDoCHDB.DataSource = _bSource;
        }

        public void Clear()
        {
            txtLyDo.Text = "";
            txtSoTien.Text = "";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";
            _selectedindex = -1;
            _bSource = new BindingList<CHDB_LyDo>(_cLyDoCHDB.GetDS());
            dgvLyDoCHDB.DataSource = _bSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (txtLyDo.Text.Trim() != "" && txtNoiDung.Text.Trim() != "")
                {
                    CHDB_LyDo vv = new CHDB_LyDo();
                    vv.STT = _cLyDoCHDB.GetMaxSTT() + 1;
                    vv.LyDo = txtLyDo.Text.Trim();
                    if (txtSoTien.Text.Trim()!="")
                    vv.SoTien = int.Parse(txtSoTien.Text.Trim());
                    vv.NoiDung = txtNoiDung.Text;
                    vv.NoiNhan = txtNoiNhan.Text.Trim();

                    if (_cLyDoCHDB.Them(vv))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                if (_selectedindex != -1)
                    if (txtLyDo.Text.Trim() != "" && txtNoiDung.Text.Trim() != "")
                    {
                        CHDB_LyDo vv = _cLyDoCHDB.Get(int.Parse(dgvLyDoCHDB["ID", _selectedindex].Value.ToString()));
                        vv.LyDo = txtLyDo.Text.Trim();
                        if (txtSoTien.Text.Trim() != "")
                            vv.SoTien = int.Parse(txtSoTien.Text.Trim());
                        else
                            vv.SoTien = null;
                        vv.NoiDung = txtNoiDung.Text;
                        vv.NoiNhan = txtNoiNhan.Text.Trim();

                        if (_cLyDoCHDB.Sua(vv))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvLyDoCHDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtLyDo.Text = dgvLyDoCHDB["LyDo", e.RowIndex].Value.ToString();
                if (dgvLyDoCHDB["SoTien", e.RowIndex].Value!=null)
                txtSoTien.Text = dgvLyDoCHDB["SoTien", e.RowIndex].Value.ToString();
                txtNoiDung.Text = dgvLyDoCHDB["NoiDung", e.RowIndex].Value.ToString();
                txtNoiNhan.Text = dgvLyDoCHDB["NoiNhan", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                if (_selectedindex != -1 && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    CHDB_LyDo vv = _cLyDoCHDB.Get(int.Parse(dgvLyDoCHDB["ID", _selectedindex].Value.ToString()));
                    if (_cLyDoCHDB.Xoa(vv))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvLyDoCHDB_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLyDoCHDB.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        int rowIndexFromMouseDown;
        DataGridViewRow rw;
        private void dgvLyDoCHDB_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvLyDoCHDB.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvLyDoCHDB.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

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
                _cLyDoCHDB.SubmitChanges();
            }
        }

        private void dgvLyDoCHDB_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvLyDoCHDB.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvLyDoCHDB_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvLyDoCHDB.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw = dgvLyDoCHDB.SelectedRows[0];
                    rowIndexFromMouseDown = dgvLyDoCHDB.SelectedRows[0].Index;
                    dgvLyDoCHDB.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }

        private void dgvLyDoCHDB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLyDoCHDB.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

    }
}
