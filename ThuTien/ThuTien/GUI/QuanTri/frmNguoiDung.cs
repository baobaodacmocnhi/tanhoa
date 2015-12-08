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
using ThuTien.DAL.TongHop;

namespace ThuTien.GUI.QuanTri
{
    public partial class frmNguoiDung : Form
    {
        CTo _cTo = new CTo();
        CNhom _cNhom = new CNhom();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CMenu _cMenu = new CMenu();
        CPhanQuyenNguoiDung _cPhanQuyenNguoiDung = new CPhanQuyenNguoiDung();
        CChamCong _cChamCong = new CChamCong();
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
            chkToTruong.Checked = false;
            chkHanhThu.Checked = false;
            chkDongNuoc.Checked = false;
            chkVanPhong.Checked = false;
            dgvNguoiDung.DataSource = _cNguoiDung.GetDSExceptMaND(CNguoiDung.MaND);
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            cmbTo.DataSource = _cTo.GetDS();
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";
            //cmbTo.SelectedIndex = -1;

            cmbNhom.DataSource = _cNhom.GetDS();
            cmbNhom.DisplayMember = "TenNhom";
            cmbNhom.ValueMember = "MaNhom";
            //cmbNhom.SelectedIndex = -1;

            dgvNguoiDung.AutoGenerateColumns = false;
            dgvNguoiDung.DataSource = _cNguoiDung.GetDSExceptMaND(CNguoiDung.MaND);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
                {
                    TT_NguoiDung nguoidung = new TT_NguoiDung();
                    nguoidung.HoTen = txtHoTen.Text.Trim();
                    nguoidung.DienThoai = txtDienThoai.Text.Trim();
                    nguoidung.TaiKhoan = txtTaiKhoan.Text.Trim();
                    nguoidung.MatKhau = txtMatKhau.Text.Trim();
                    nguoidung.NamVaoLam = int.Parse(txtNam.Text.Trim());
                    if (cmbTo.SelectedIndex != -1)
                        nguoidung.MaTo = (int)cmbTo.SelectedValue;
                    if (cmbNhom.SelectedIndex != -1)
                        nguoidung.MaNhom = (int)cmbNhom.SelectedValue;
                    nguoidung.Doi = chkDoi.Checked;
                    nguoidung.ToTruong = chkToTruong.Checked;
                    nguoidung.HanhThu = chkHanhThu.Checked;
                    nguoidung.DongNuoc = chkDongNuoc.Checked;
                    nguoidung.VanPhong = chkVanPhong.Checked;
                    nguoidung.ChamCong = chkChamCong.Checked;
                    ///tự động thêm quyền cho nhóm mới
                    foreach (var item in _cMenu.GetDS())
                    {
                        TT_PhanQuyenNguoiDung phanquyennguoidung = new TT_PhanQuyenNguoiDung();
                        phanquyennguoidung.MaMenu = item.MaMenu;
                        phanquyennguoidung.MaND = nguoidung.MaND;
                        nguoidung.TT_PhanQuyenNguoiDungs.Add(phanquyennguoidung);
                    }
                    if (chkChamCong.Checked)
                    {
                        TT_CTChamCong ctchamcong = new TT_CTChamCong();
                        ctchamcong.MaCC = _cChamCong.GetMaxMaCC();
                        nguoidung.TT_CTChamCongs.Add(ctchamcong);
                    }
                    if (_cNguoiDung.Them(nguoidung))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
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
                    TT_NguoiDung nguoidung = _cNguoiDung.GetByMaND(int.Parse(dgvNguoiDung["MaND", _selectedindex].Value.ToString()));
                    nguoidung.HoTen = txtHoTen.Text.Trim();
                    nguoidung.DienThoai = txtDienThoai.Text.Trim();
                    nguoidung.TaiKhoan = txtTaiKhoan.Text.Trim();
                    nguoidung.MatKhau = txtMatKhau.Text.Trim();
                    nguoidung.NamVaoLam = int.Parse(txtNam.Text.Trim());
                    nguoidung.MaTo = (int)cmbTo.SelectedValue;
                    nguoidung.MaNhom = (int)cmbNhom.SelectedValue;
                    nguoidung.Doi = chkDoi.Checked;
                    nguoidung.ToTruong = chkToTruong.Checked;
                    nguoidung.HanhThu = chkHanhThu.Checked;
                    nguoidung.DongNuoc = chkDongNuoc.Checked;
                    nguoidung.VanPhong = chkVanPhong.Checked;
                    nguoidung.ChamCong = chkChamCong.Checked;
                    _cNguoiDung.Sua(nguoidung);
                    DataTable dt = ((DataView)gridView.DataSource).Table;
                    foreach (DataRow item in dt.Rows)
                    {
                        TT_PhanQuyenNguoiDung phanquyennguoidung = _cPhanQuyenNguoiDung.GetByMaMenuMaND(int.Parse(item["MaMenu"].ToString()), nguoidung.MaND);
                        if (phanquyennguoidung.Xem != bool.Parse(item["Xem"].ToString()) || phanquyennguoidung.Them != bool.Parse(item["Them"].ToString()) ||
                            phanquyennguoidung.Sua != bool.Parse(item["Sua"].ToString()) || phanquyennguoidung.Xoa != bool.Parse(item["Xoa"].ToString()) ||
                            phanquyennguoidung.QuanLy != bool.Parse(item["QuanLy"].ToString()))
                        {
                            phanquyennguoidung.Xem = bool.Parse(item["Xem"].ToString());
                            phanquyennguoidung.Them = bool.Parse(item["Them"].ToString());
                            phanquyennguoidung.Sua = bool.Parse(item["Sua"].ToString());
                            phanquyennguoidung.Xoa = bool.Parse(item["Xoa"].ToString());
                            phanquyennguoidung.QuanLy = bool.Parse(item["QuanLy"].ToString());
                            _cPhanQuyenNguoiDung.Sua(phanquyennguoidung);
                        }
                    }
                    Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_selectedindex != -1)
                    {
                        TT_NguoiDung nguoidung = _cNguoiDung.GetByMaND(int.Parse(dgvNguoiDung["MaND", _selectedindex].Value.ToString()));
                        ///xóa quan hệ 1 nhiều
                        _cPhanQuyenNguoiDung.Xoa(nguoidung.TT_PhanQuyenNguoiDungs.ToList());
                        _cNguoiDung.Xoa(nguoidung);
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Người Dùng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtHoTen.Text = dgvNguoiDung["HoTen",e.RowIndex].Value.ToString();
                if (dgvNguoiDung["DienThoai", e.RowIndex].Value != null)
                    txtDienThoai.Text = dgvNguoiDung["DienThoai", e.RowIndex].Value.ToString();
                txtTaiKhoan.Text = dgvNguoiDung["TaiKhoan", e.RowIndex].Value.ToString();
                txtMatKhau.Text = dgvNguoiDung["MatKhau", e.RowIndex].Value.ToString();
                txtNam.Text = dgvNguoiDung["NamVaoLam", e.RowIndex].Value.ToString();
                cmbTo.SelectedValue = int.Parse(dgvNguoiDung["MaTo", e.RowIndex].Value.ToString());
                cmbNhom.SelectedValue = int.Parse(dgvNguoiDung["MaNhom", e.RowIndex].Value.ToString());
                chkDoi.Checked = bool.Parse(dgvNguoiDung["Doi", e.RowIndex].Value.ToString());
                chkToTruong.Checked = bool.Parse(dgvNguoiDung["ToTruong", e.RowIndex].Value.ToString());
                chkHanhThu.Checked = bool.Parse(dgvNguoiDung["HanhThu", e.RowIndex].Value.ToString());
                chkDongNuoc.Checked = bool.Parse(dgvNguoiDung["DongNuoc", e.RowIndex].Value.ToString());
                chkVanPhong.Checked = bool.Parse(dgvNguoiDung["VanPhong", e.RowIndex].Value.ToString());
                chkChamCong.Checked = bool.Parse(dgvNguoiDung["ChamCong", e.RowIndex].Value.ToString());
                gridControl.DataSource = _cPhanQuyenNguoiDung.GetDSByMaND(int.Parse(dgvNguoiDung["MaND", e.RowIndex].Value.ToString()));
            }
            catch (Exception)
            {
            }
            
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

        private void gridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "ToanQuyen")
                if (bool.Parse(e.Value.ToString()))
                {
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xem"], "True");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Them"], "True");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Sua"], "True");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xoa"], "True");
                }
                else
                {
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xem"], "False");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Them"], "False");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Sua"], "False");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xoa"], "False");
                }
        }
    }
}
