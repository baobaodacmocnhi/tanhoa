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

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmLyDoCHDB : Form
    {
        string _mnu = "mnuLyDoCHDB";
        CLyDoCHDB _cLyDoCHDB = new CLyDoCHDB();
        int _selectedindex = -1;

        public frmLyDoCHDB()
        {
            InitializeComponent();
        }

        private void frmVeViecCHDB_Load(object sender, EventArgs e)
        {
            dgvLyDoCHDB.AutoGenerateColumns = false;
            dgvLyDoCHDB.DataSource = _cLyDoCHDB.LoadDS();
        }

        public void Clear()
        {
            txtLyDo.Text = "";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";
            _selectedindex = -1;
            dgvLyDoCHDB.DataSource = _cLyDoCHDB.LoadDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (txtLyDo.Text.Trim() != "" && txtNoiDung.Text.Trim() != "")
                {
                    LyDoCHDB vv = new LyDoCHDB();
                    vv.LyDo = txtLyDo.Text.Trim();
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
                        LyDoCHDB vv = _cLyDoCHDB.GetByID(int.Parse(dgvLyDoCHDB["ID", _selectedindex].Value.ToString()));
                        vv.LyDo = txtLyDo.Text.Trim();
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
                if (_selectedindex != -1)
                {
                    LyDoCHDB vv = _cLyDoCHDB.GetByID(int.Parse(dgvLyDoCHDB["ID", _selectedindex].Value.ToString()));
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

    }
}
