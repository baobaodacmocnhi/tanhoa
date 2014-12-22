using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;

namespace ThuTien.GUI.QuanTri
{
    public partial class frmTo : Form
    {
        CTo _cTo = new CTo();
        int _selectedindex = -1;

        public frmTo()
        {
            InitializeComponent();
            if (CNguoiDung.CheckQuyen("mnuTao", "Xem"))
            {
                dgvTo.AutoGenerateColumns = false;
                dgvTo.DataSource = _cTo.GetDSTo();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền mở form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void Clear()
        {
            _selectedindex = -1;
            txtTenTo.Text = "";
            dgvTo.DataSource = _cTo.GetDSTo();
        }

        private void frmTo_Load(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenTo.Text.Trim() != "")
            {
                TT_To to = new TT_To();
                to.TenTo = txtTenTo.Text.Trim();
                _cTo.Them(to);
                Clear();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
            {
                TT_To to = _cTo.GetToByMaTo(int.Parse(dgvTo["MaTo", _selectedindex].Value.ToString()));
                to.TenTo = txtTenTo.Text.Trim();
                _cTo.Sua(to);
                Clear();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    TT_To to = _cTo.GetToByMaTo(int.Parse(dgvTo["MaTo", _selectedindex].Value.ToString()));
                    _cTo.Xoa(to);
                    Clear();
                }
        }

        private void dgvTo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedindex = e.RowIndex;
            txtTenTo.Text = dgvTo["TenTo", e.RowIndex].Value.ToString();
        }

        private void dgvTo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }

        }

        
    }
}
