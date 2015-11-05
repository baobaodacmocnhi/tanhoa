using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.HanhThu;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.GUI.HanhThu
{
    public partial class frmThongTinKhachHang : Form
    {
        string _mnu = "mnuThongTinKhachHang";
        CThongTinKhachHang _cTTKH = new CThongTinKhachHang();

        public frmThongTinKhachHang()
        {
            InitializeComponent();
        }

        private void frmThongTinKhachHang_Load(object sender, EventArgs e)
        {
            dgvTTKH.AutoGenerateColumns = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbDot.SelectedIndex >= 0 && cmbDenDot.SelectedIndex < 0)
                dgvTTKH.DataSource = _cTTKH.GetDS(CNguoiDung.MaND, int.Parse(cmbDot.SelectedItem.ToString()));
            else
                if (cmbDot.SelectedIndex >= 0 && cmbDenDot.SelectedIndex >= 0)
                    dgvTTKH.DataSource = _cTTKH.GetDS(CNguoiDung.MaND, int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(cmbDenDot.SelectedItem.ToString()));
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_cTTKH.CheckExist(txtDanhBo.Text.Trim().Replace(" ", "")))
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_ThongTinKhachHang ttkh = _cTTKH.Get(txtDanhBo.Text.Trim().Replace(" ", ""));
                    ttkh.DienThoai = txtDienThoai.Text.Trim();

                    if (_cTTKH.Sua(ttkh))
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    TT_ThongTinKhachHang ttkh = new TT_ThongTinKhachHang();
                    ttkh.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    ttkh.DienThoai = txtDienThoai.Text.Trim();

                    if (_cTTKH.Them(ttkh))
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvTTKH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTTKH.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvTTKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTTKH.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace(" ","").Length == 11)
            {
                if (_cTTKH.CheckExist(txtDanhBo.Text.Trim().Replace(" ", "")))
                {
                    TT_ThongTinKhachHang ttkh = _cTTKH.Get(txtDanhBo.Text.Trim().Replace(" ", ""));
                    txtDienThoai.Text = ttkh.DienThoai;
                }
            }
        }

    }
}
