using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using System.Globalization;

namespace ThuTien.GUI.TongHop
{
    public partial class frmThu2Lan : Form
    {
        string _mnu = "mnuThu2Lan";
        CHoaDon _cHoaDon = new CHoaDon();

        public frmThu2Lan()
        {
            InitializeComponent();
        }

        private void frmThu2Lan_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnXem.PerformClick();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (_cHoaDon.Thu2Lan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()),txtDanhBo.Text.Trim(), true))
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    _cHoaDon.BeginTransaction();
                    foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                    {
                        HOADON hoadon = _cHoaDon.GetByMaHD(int.Parse(item.Cells["MaHD"].Value.ToString()));
                        hoadon.Thu2Lan = false;
                    }
                    _cHoaDon.SubmitChanges();
                    _cHoaDon.CommitTransaction();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cHoaDon.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cHoaDon.GetDSThu2Lan(txtDanhBo.Text.Trim().Replace(" ",""));
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "Tra")
            {
                if (bool.Parse(dgvHoaDon["Tra", e.RowIndex].Value.ToString()))
                {
                    _cHoaDon.Thu2Lan_Tra(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString());
                }
                else
                {
                    _cHoaDon.Thu2Lan_XoaTra(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString());
                }
            }

            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GhiChu")
            {
                _cHoaDon.Thu2Lan_GhiChu(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString(), dgvHoaDon["GhiChu", e.RowIndex].Value.ToString());
            }
        }
 
    }
}
