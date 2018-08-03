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
        BindingList<KTXM_HienTrang> _blHienTrangKiemTra;

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
            _blHienTrangKiemTra = new BindingList<KTXM_HienTrang>(_cHienTrangKiemTra.GetDS());
            dgvDSHienTrangKT.DataSource = _blHienTrangKiemTra;
        }

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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (txtHienTrangKT.Text.Trim() != "")
                    {
                        KTXM_HienTrang hientrangkiemtra = new KTXM_HienTrang();
                        hientrangkiemtra.TenHTKT = txtHienTrangKT.Text.Trim();
                        hientrangkiemtra.STT = _cHienTrangKiemTra.GetMaxSTT() + 1;

                        if (_cHienTrangKiemTra.Them(hientrangkiemtra))
                        {
                            txtHienTrangKT.Text = "";
                            LoadDataTable();
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
                if (_selectedindexHTKT != -1)
                    if (txtHienTrangKT.Text.Trim() != "")
                    {
                        KTXM_HienTrang hientrangkiemtra = _cHienTrangKiemTra.Get(int.Parse(dgvDSHienTrangKT["MaHTKT", _selectedindexHTKT].Value.ToString()));
                        hientrangkiemtra.TenHTKT = txtHienTrangKT.Text.Trim();

                        if (_cHienTrangKiemTra.Sua(hientrangkiemtra))
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_selectedindexHTKT != -1 && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (_cHienTrangKiemTra.Xoa(_cHienTrangKiemTra.Get(int.Parse(dgvDSHienTrangKT["MaHTKT", _selectedindexHTKT].Value.ToString()))))
                        {
                            txtHienTrangKT.Text = "";
                            _selectedindexHTKT = -1;
                            LoadDataTable();
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
