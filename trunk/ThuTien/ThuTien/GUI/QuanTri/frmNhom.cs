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
    public partial class frmNhom : Form
    {
        int _selectedindex = -1;
        CNhom _cNhom = new CNhom();
        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
        CMenu _cMenu = new CMenu();

        public frmNhom()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            _selectedindex = -1;
            txtTenNhom.Text = "";
            dgvNhom.DataSource = _cNhom.GetDSNhom();
        }

        private void frmNhom_Load(object sender, EventArgs e)
        {
            dgvNhom.AutoGenerateColumns = false;
            dgvNhom.DataSource = _cNhom.GetDSNhom();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenNhom.Text.Trim() != "")
            {
                TT_Nhom nhom = new TT_Nhom();
                nhom.TenNhom = txtTenNhom.Text.Trim();
                ///tự động thêm quyền cho nhóm mới
                foreach (var item in _cMenu.GetDSMenu())
                {
                    TT_PhanQuyenNhom phanquyennhom = new TT_PhanQuyenNhom();
                    phanquyennhom.MaMenu = item.MaMenu;
                    phanquyennhom.MaNhom = nhom.MaNhom;
                    nhom.TT_PhanQuyenNhoms.Add(phanquyennhom);
                }
                _cNhom.Them(nhom);
                Clear();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
            {
                TT_Nhom nhom = _cNhom.getNhombyMaNhom(int.Parse(dgvNhom["MaNhom", _selectedindex].Value.ToString()));
                nhom.TenNhom = txtTenNhom.Text.Trim();
                _cNhom.Sua(nhom);
                Clear();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    TT_Nhom nhom = _cNhom.getNhombyMaNhom(int.Parse(dgvNhom["MaNhom", _selectedindex].Value.ToString()));
                    ///xóa quan hệ 1 nhiều
                    _cPhanQuyenNhom.Xoa(nhom.TT_PhanQuyenNhoms.ToList());
                    _cNhom.Xoa(nhom);
                    Clear();
                }
        }

        private void dgvNhom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedindex = e.RowIndex;
            txtTenNhom.Text = dgvNhom["TenNhom", e.RowIndex].Value.ToString();
            
        }

        private void dgvNhom_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNhom.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
