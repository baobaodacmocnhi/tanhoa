using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmNoiDungXuLyCHDB : Form
    {
        string _mnu = "mnuNoiDungXuLyCHDB";
        CNoiDungXuLyCHDB _cNoiDungXuLyCHDB = new CNoiDungXuLyCHDB();
        int _selectedindex = -1;

        public frmNoiDungXuLyCHDB()
        {
            InitializeComponent();
        }

        private void frmNoiDungXuLyCHDB_Load(object sender, EventArgs e)
        {
            dgvNoiDung.AutoGenerateColumns = false;
            dgvNoiDung.DataSource = _cNoiDungXuLyCHDB.LoadDS();
        }

        public void Clear()
        {
            txtNoiDung.Text = "";
            _selectedindex = -1;
            dgvNoiDung.DataSource = _cNoiDungXuLyCHDB.LoadDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                NoiDungXuLyCHDB nd = new NoiDungXuLyCHDB();
                nd.NoiDung = txtNoiDung.Text.Trim();

                if (_cNoiDungXuLyCHDB.Them(nd))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                if (_selectedindex != -1)
                    {
                        NoiDungXuLyCHDB nd = _cNoiDungXuLyCHDB.GetByID(int.Parse(dgvNoiDung["ID", _selectedindex].Value.ToString()));
                        nd.NoiDung = txtNoiDung.Text.Trim();

                        if (_cNoiDungXuLyCHDB.Sua(nd))
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                if (_selectedindex != -1)
                {
                    NoiDungXuLyCHDB nd = _cNoiDungXuLyCHDB.GetByID(int.Parse(dgvNoiDung["ID", _selectedindex].Value.ToString()));

                    if (_cNoiDungXuLyCHDB.Xoa(nd))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvNoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtNoiDung.Text = dgvNoiDung["NoiDung", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void dgvNoiDung_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNoiDung.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
