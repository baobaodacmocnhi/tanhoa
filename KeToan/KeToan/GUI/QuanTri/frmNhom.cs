using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeToan.DAL.QuanTri;
using KeToan.LinQ;

namespace KeToan.GUI.QuanTri
{
    public partial class frmNhom : Form
    {
        string _mnu = "mnuNhom";
        CNhom _cNhom = new CNhom();
        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
        CMenu _cMenu = new CMenu();
        Nhom _nhom = null;

        public frmNhom()
        {
            InitializeComponent();
        }

        private void frmNhom_Load(object sender, EventArgs e)
        {
            dgvNhom.AutoGenerateColumns = false;
            dgvNhom.DataSource = _cNhom.GetDS();
        }

        public void Clear()
        {
            txtTenNhom.Text = "";
            _nhom = null;
            dgvNhom.DataSource = _cNhom.GetDS();
            gridControl.DataSource = null;
        }

        public void LoadEntity(Nhom entity)
        {
            txtTenNhom.Text = entity.Name;
            gridControl.DataSource = _cPhanQuyenNhom.GetDS(entity.ID);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Them"))
                {
                    if (txtTenNhom.Text.Trim() != "")
                    {
                        Nhom nhom = new Nhom();
                        nhom.Name = txtTenNhom.Text.Trim();
                        ///tự động thêm quyền cho nhóm mới
                        foreach (var item in _cMenu.GetDS())
                        {
                            PhanQuyenNhom phanquyennhom = new PhanQuyenNhom();
                            phanquyennhom.MaMenu = item.ID;
                            phanquyennhom.MaNhom = nhom.ID;
                            nhom.PhanQuyenNhoms.Add(phanquyennhom);
                        }
                        if (_cNhom.Them(nhom))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Sua"))
                {
                    if (_nhom != null)
                    {
                        _nhom.Name = txtTenNhom.Text.Trim();
                        _cNhom.Sua(_nhom);
                        DataTable dt = ((DataView)gridView.DataSource).Table;
                        foreach (DataRow item in dt.Rows)
                        {
                            PhanQuyenNhom phanquyennhom = _cPhanQuyenNhom.Get(int.Parse(item["MaMenu"].ToString()), _nhom.ID);
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
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Đối Tượng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Sửa này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_nhom != null)
                        {
                            ///xóa quan hệ 1 nhiều
                            _cPhanQuyenNhom.Xoa(_nhom.PhanQuyenNhoms.ToList());
                            _cNhom.Xoa(_nhom);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                        else
                            MessageBox.Show("Lỗi, Vui lòng chọn Nhóm cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _nhom = _cNhom.Get(int.Parse(dgvNhom.CurrentRow.Cells["ID"].Value.ToString()));
                LoadEntity(_nhom);
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
