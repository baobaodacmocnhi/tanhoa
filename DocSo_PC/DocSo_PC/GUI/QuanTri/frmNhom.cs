using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;

namespace DocSo_PC.GUI.QuanTri
{
    public partial class frmNhom : Form
    {
        int _selectedindex = -1;
        CNhom _cNhom = new CNhom();
        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
        CMenu _cMenu = new CMenu();
        string _mnu = "mnuNhom";

        public frmNhom()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            _selectedindex = -1;
            txtTenNhom.Text = "";
            dgvNhom.DataSource = _cNhom.GetDS();
            gridControl.DataSource = null;
        }

        private void frmNhom_Load(object sender, EventArgs e)
        {
            dgvNhom.AutoGenerateColumns = false;
            dgvNhom.DataSource = _cNhom.GetDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtTenNhom.Text.Trim() != "")
                {
                    Nhom nhom = new Nhom();
                    nhom.TenNhom = txtTenNhom.Text.Trim();
                    ///tự động thêm quyền cho nhóm mới
                    foreach (var item in _cMenu.GetDS())
                    {
                        PhanQuyenNhom phanquyennhom = new PhanQuyenNhom();
                        phanquyennhom.MaMenu = item.MaMenu;
                        phanquyennhom.MaNhom = nhom.MaNhom;
                        nhom.PhanQuyenNhoms.Add(phanquyennhom);
                    }
                    _cNhom.Them(nhom);
                    Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (_selectedindex != -1)
                {
                    Nhom nhom = _cNhom.GetByMaNhom(int.Parse(dgvNhom["MaNhom", _selectedindex].Value.ToString()));
                    nhom.TenNhom = txtTenNhom.Text.Trim();
                    _cNhom.Sua(nhom);
                    DataTable dt = ((DataView)gridView.DataSource).Table;
                    foreach (DataRow item in dt.Rows)
                    {
                        PhanQuyenNhom phanquyennhom = _cPhanQuyenNhom.GetByMaMenuMaNhom(int.Parse(item["MaMenu"].ToString()), nhom.MaNhom);
                        if (phanquyennhom.Xem != bool.Parse(item["Xem"].ToString()) || phanquyennhom.Them != bool.Parse(item["Them"].ToString()) ||
                            phanquyennhom.Sua != bool.Parse(item["Sua"].ToString()) || phanquyennhom.Xoa != bool.Parse(item["Xoa"].ToString()) ||
                            phanquyennhom.QuanLy != bool.Parse(item["QuanLy"].ToString()))
                        {
                            phanquyennhom.Xem = bool.Parse(item["Xem"].ToString());
                            phanquyennhom.Them = bool.Parse(item["Them"].ToString());
                            phanquyennhom.Sua = bool.Parse(item["Sua"].ToString());
                            phanquyennhom.Xoa = bool.Parse(item["Xoa"].ToString());
                            phanquyennhom.QuanLy = bool.Parse(item["QuanLy"].ToString());
                            _cPhanQuyenNhom.Sua(phanquyennhom);
                        }
                    }
                    Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Sửa này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {      
                    if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_selectedindex != -1)
                        {
                            Nhom nhom = _cNhom.GetByMaNhom(int.Parse(dgvNhom["MaNhom", _selectedindex].Value.ToString()));
                            ///xóa quan hệ 1 nhiều
                            _cPhanQuyenNhom.Xoa(nhom.PhanQuyenNhoms.ToList());
                            _cNhom.Xoa(nhom);
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Lỗi, Vui lòng chọn Nhóm cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvNhom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtTenNhom.Text = dgvNhom["TenNhom", e.RowIndex].Value.ToString();
                if (CNguoiDung.Admin)
                    gridControl.DataSource = _cPhanQuyenNhom.GetDSByMaNhom(true, int.Parse(dgvNhom["MaNhom", e.RowIndex].Value.ToString()));
                else
                    gridControl.DataSource = _cPhanQuyenNhom.GetDSByMaNhom(false, int.Parse(dgvNhom["MaNhom", e.RowIndex].Value.ToString()));
            }
            catch (Exception)
            {
            }
        }

        private void dgvNhom_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNhom.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
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
