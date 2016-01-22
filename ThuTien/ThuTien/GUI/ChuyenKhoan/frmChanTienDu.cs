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

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmChanTienDu : Form
    {
        string _mnu = "mnuChanTienDu";
        CHoaDon _cHoaDon = new CHoaDon();

        public frmChanTienDu()
        {
            InitializeComponent();
        }

        private void frmChanTienDu_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvDSChanTienDu.AutoGenerateColumns = false;

            dgvDSChanTienDu.DataSource = _cHoaDon.GetDSChanTienDu();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()) && e.KeyChar == 13)
                dgvHoaDon.DataSource = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim().Replace(" ", ""));
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                item.Cells["Chon"].Value = "True";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                        if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()))
                        {
                            HOADON hoadon = _cHoaDon.Get(item.Cells["SoHoaDon_HD"].Value.ToString());
                            hoadon.ChanTienDu = true;
                            hoadon.NgayChanTienDu = DateTime.Now;
                            hoadon.NGAYGIAITRACH = DateTime.Now;
                            _cHoaDon.Sua(hoadon);
                        }
                    dgvDSChanTienDu.DataSource = _cHoaDon.GetDSChanTienDu();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    foreach (DataGridViewRow item in dgvDSChanTienDu.SelectedRows)
                    {
                        HOADON hoadon = _cHoaDon.Get(item.Cells["SoHoaDon_Chan"].Value.ToString());
                        hoadon.ChanTienDu = false;
                        hoadon.NGAYGIAITRACH = null;
                        _cHoaDon.Sua(hoadon);
                    }
                    dgvDSChanTienDu.DataSource = _cHoaDon.GetDSChanTienDu();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo_HD" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong_HD" && e.Value != null)
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

        private void dgvDSChanTienDu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSChanTienDu.Columns[e.ColumnIndex].Name == "DanhBo_Chan" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDSChanTienDu.Columns[e.ColumnIndex].Name == "TongCong_Chan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDSChanTienDu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSChanTienDu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
