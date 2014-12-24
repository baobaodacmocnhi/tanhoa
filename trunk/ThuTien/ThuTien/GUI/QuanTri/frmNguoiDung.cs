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
    public partial class frmNguoiDung : Form
    {
        CTo _cTo = new CTo();
        CNhom _cNhom = new CNhom();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CMenu _cMenu = new CMenu();
        CPhanQuyenNguoiDung _cPhanQuyenNguoiDung = new CPhanQuyenNguoiDung();
        int _selectedindex = -1;
        string _mnu = "mnuNguoiDung";

        public frmNguoiDung()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            _selectedindex = -1;
            txtHoTen.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            dgvNguoiDung.DataSource = _cNguoiDung.GetDSNguoiDungExceptMaND(CNguoiDung.MaND);
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            cmbTo.DataSource = _cTo.GetDSTo();
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";
            //cmbTo.SelectedIndex = -1;

            cmbNhom.DataSource = _cNhom.GetDSNhom();
            cmbNhom.DisplayMember = "TenNhom";
            cmbNhom.ValueMember = "MaNhom";
            //cmbNhom.SelectedIndex = -1;

            dgvNguoiDung.AutoGenerateColumns = false;
            dgvNguoiDung.DataSource = _cNguoiDung.GetDSNguoiDungExceptMaND(CNguoiDung.MaND);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
                {
                    NguoiDung nguoidung = new NguoiDung();
                    nguoidung.HoTen = txtHoTen.Text.Trim();
                    nguoidung.TaiKhoan = txtTaiKhoan.Text.Trim();
                    nguoidung.MatKhau = txtMatKhau.Text.Trim();
                    if (cmbTo.SelectedIndex != -1)
                        nguoidung.MaTo = (int)cmbTo.SelectedValue;
                    if (cmbNhom.SelectedIndex != -1)
                        nguoidung.MaNhom = (int)cmbNhom.SelectedValue;
                    ///tự động thêm quyền cho nhóm mới
                    foreach (var item in _cMenu.GetDSMenu())
                    {
                        PhanQuyenNguoiDung phanquyennguoidung = new PhanQuyenNguoiDung();
                        phanquyennguoidung.MaMenu = item.MaMenu;
                        phanquyennguoidung.MaND = nguoidung.MaND;
                        nguoidung.PhanQuyenNguoiDungs.Add(phanquyennguoidung);
                    }
                    _cNguoiDung.Them(nguoidung);
                    Clear();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sửa"))
            {
                if (_selectedindex != -1)
                {
                    NguoiDung nguoidung = _cNguoiDung.GetNguoiDungByMaND(int.Parse(dgvNguoiDung["MaND", _selectedindex].Value.ToString()));
                    nguoidung.HoTen = txtHoTen.Text.Trim();
                    nguoidung.TaiKhoan = txtTaiKhoan.Text.Trim();
                    nguoidung.MatKhau = txtMatKhau.Text.Trim();
                    nguoidung.MaTo = (int)cmbTo.SelectedValue;
                    nguoidung.MaNhom = (int)cmbNhom.SelectedValue;
                    _cNguoiDung.Sua(nguoidung);
                    DataTable dt = ((DataView)gridView.DataSource).Table;
                    foreach (DataRow item in dt.Rows)
                    {
                        PhanQuyenNguoiDung phanquyennguoidung = _cPhanQuyenNguoiDung.GetPhanQuyenNguoiDungByMaMenuMaND(int.Parse(item["MaMenu"].ToString()), nguoidung.MaND);
                        if (phanquyennguoidung.Xem != bool.Parse(item["Xem"].ToString()) || phanquyennguoidung.Them != bool.Parse(item["Them"].ToString()) ||
                            phanquyennguoidung.Sua != bool.Parse(item["Sua"].ToString()) || phanquyennguoidung.Xoa != bool.Parse(item["Xoa"].ToString()))
                        {
                            phanquyennguoidung.Xem = bool.Parse(item["Xem"].ToString());
                            phanquyennguoidung.Them = bool.Parse(item["Them"].ToString());
                            phanquyennguoidung.Sua = bool.Parse(item["Sua"].ToString());
                            phanquyennguoidung.Xoa = bool.Parse(item["Xoa"].ToString());
                            _cPhanQuyenNguoiDung.Sua(phanquyennguoidung);
                        }
                    }
                    Clear();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (_selectedindex != -1)
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        NguoiDung nguoidung = _cNguoiDung.GetNguoiDungByMaND(int.Parse(dgvNguoiDung["MaND", _selectedindex].Value.ToString()));
                        ///xóa quan hệ 1 nhiều
                        _cPhanQuyenNguoiDung.Xoa(nguoidung.PhanQuyenNguoiDungs.ToList());
                        _cNguoiDung.Xoa(nguoidung);
                        Clear();
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHoTen.Text = dgvNguoiDung["HoTen", e.RowIndex].Value.ToString();
            txtTaiKhoan.Text = dgvNguoiDung["TaiKhoan", e.RowIndex].Value.ToString();
            txtMatKhau.Text = dgvNguoiDung["MatKhau", e.RowIndex].Value.ToString();
            cmbTo.SelectedValue = int.Parse(dgvNguoiDung["MaTo", e.RowIndex].Value.ToString());
            cmbNhom.SelectedValue = int.Parse(dgvNguoiDung["MaNhom", e.RowIndex].Value.ToString());
            gridControl.DataSource = _cPhanQuyenNguoiDung.GetDSPhanQuyenNguoiDungByMaND(int.Parse(dgvNguoiDung["MaND", e.RowIndex].Value.ToString()));
        }

        private void dgvNguoiDung_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNguoiDung.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvNguoiDung_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNguoiDung.Columns[e.ColumnIndex].Name == "TenTo" && dgvNguoiDung["MaTo", e.RowIndex].Value != null)
                e.Value = _cTo.GetTenToByMaTo(int.Parse(dgvNguoiDung["MaTo", e.RowIndex].Value.ToString()));
            if (dgvNguoiDung.Columns[e.ColumnIndex].Name == "TenNhom" && dgvNguoiDung["MaNhom", e.RowIndex].Value != null)
                e.Value = _cNhom.GetTenNhomByMaNhom(int.Parse(dgvNguoiDung["MaNhom", e.RowIndex].Value.ToString()));
        }
    }
}
