using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;

namespace ThuTien.GUI.Quay
{
    public partial class frmPhiMoNuocQuay : Form
    {
        string _mnu = "mnuPhiMoNuocQuay";
        CDongNuoc _cDongNuoc = new CDongNuoc();

        public frmPhiMoNuocQuay()
        {
            InitializeComponent();
        }

        private void frmPhiMoNuoc_Load(object sender, EventArgs e)
        {
            dgvKQDongNuoc.AutoGenerateColumns = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (txtDanhBo.Text.Trim().Replace(" ", "").Length == 11)
                dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuoc_PhiMoNuoc(false, txtDanhBo.Text.Trim().Replace(" ", ""));
            else
                dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuoc_PhiMoNuoc(false, dateTu.Value, dateDen.Value);
        }

        private void dgvKQDongNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "MaDN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvKQDongNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKQDongNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvKQDongNuoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "DongPhi" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvKQDongNuoc[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(dgvKQDongNuoc["MaKQDN", e.RowIndex].Value.ToString()));
                    if (kqdongnuoc.DongPhi == true && kqdongnuoc.ChuyenKhoan == true)
                    {
                        MessageBox.Show("Đã có đóng phí Chuyển Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    kqdongnuoc.DongPhi = bool.Parse(e.FormattedValue.ToString());
                    if (kqdongnuoc.DongPhi)
                        kqdongnuoc.NgayDongPhi = DateTime.Now;
                    else
                        kqdongnuoc.NgayDongPhi = null;
                    if (_cDongNuoc.SuaKQ(kqdongnuoc))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace(" ", "").Length == 11)
                btnXem.PerformClick();
        }

    }
}
