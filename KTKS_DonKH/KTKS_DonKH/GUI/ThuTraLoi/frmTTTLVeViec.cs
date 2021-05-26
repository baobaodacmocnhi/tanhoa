using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.ThuTraLoi
{
    public partial class frmTTTLVeViec : Form
    {
        string _mnu = "mnuVeViecTTTL";
        CTTTL_VeViec _cVeViecTTTL = new CTTTL_VeViec();
        BindingList<ThuTraLoi_VeViec> _bSource;
        int selectedindex = -1;

        public frmTTTLVeViec()
        {
            InitializeComponent();
        }

        private void frmVeViecTTTL_Load(object sender, EventArgs e)
        {
            dgvDSVeViecTTTL.AutoGenerateColumns = false;
            LoadData();
        }

        public void Clear()
        {
            txtVeViec.Text = "";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";
            selectedindex = -1;
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "" && txtNoiNhan.Text.Trim() != "")
                {
                    ThuTraLoi_VeViec vv = new ThuTraLoi_VeViec();
                    vv.STT = _cVeViecTTTL.GetMaxSTT() + 1;
                    vv.TenVV = txtVeViec.Text.Trim();
                    vv.NoiDung = txtNoiDung.Text;
                    vv.NoiNhan = txtNoiNhan.Text.Trim();
                    if (radThuTraLoi.Checked)
                        vv.ThuTraLoi = true;
                    else
                        if (radVanBan.Checked == true)
                            vv.VanBan = true;
                    if (_cVeViecTTTL.Them(vv))
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
                if (selectedindex != -1)
                    if (txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "" && txtNoiNhan.Text.Trim() != "")
                    {
                        ThuTraLoi_VeViec vv = _cVeViecTTTL.Get(int.Parse(dgvDSVeViecTTTL["MaVV", selectedindex].Value.ToString()));
                        vv.TenVV = txtVeViec.Text.Trim();
                        vv.NoiDung = txtNoiDung.Text;
                        vv.NoiNhan = txtNoiNhan.Text.Trim();

                        if (_cVeViecTTTL.Sua(vv))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                if (selectedindex != -1 && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        ThuTraLoi_VeViec vv = _cVeViecTTTL.Get(int.Parse(dgvDSVeViecTTTL["MaVV", selectedindex].Value.ToString()));

                        if (_cVeViecTTTL.Xoa(vv))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDSVeViecTTTL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                txtVeViec.Text = dgvDSVeViecTTTL["TenVV", e.RowIndex].Value.ToString();
                txtNoiDung.Text = dgvDSVeViecTTTL["NoiDung", e.RowIndex].Value.ToString();
                txtNoiNhan.Text = dgvDSVeViecTTTL["NoiNhan", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {

            }
             else
                 MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDSVeViecTTTL_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSVeViecTTTL.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        int rowIndexFromMouseDown;
        DataGridViewRow rw;
        private void dgvDSVeViecTTTL_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvDSVeViecTTTL.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvDSVeViecTTTL.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

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
                _cVeViecTTTL.SubmitChanges();
            }
        }

        private void dgvDSVeViecTTTL_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvDSVeViecTTTL.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvDSVeViecTTTL_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDSVeViecTTTL.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw = dgvDSVeViecTTTL.SelectedRows[0];
                    rowIndexFromMouseDown = dgvDSVeViecTTTL.SelectedRows[0].Index;
                    dgvDSVeViecTTTL.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radThuTraLoi_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void radVanBan_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
                if (radThuTraLoi.Checked)
                {
                    _bSource = new BindingList<ThuTraLoi_VeViec>(_cVeViecTTTL.getDS_ThuTraLoi());
                }
                else
                    if (radVanBan.Checked)
                    {
                        _bSource = new BindingList<ThuTraLoi_VeViec>(_cVeViecTTTL.getDS_VanBan());
                    }
            dgvDSVeViecTTTL.DataSource = _bSource;
        }
    }
}
