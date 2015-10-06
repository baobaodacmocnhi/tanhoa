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
using ThuTien.DAL.DongNuoc;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmVanTu : Form
    {
        string _mnu = "mnuVanTu";
        CVanTu _cVanTu = new CVanTu();

        public frmVanTu()
        {
            InitializeComponent();
        }

        private void frmVanTu_Load(object sender, EventArgs e)
        {
            dgvVanTu.AutoGenerateColumns = false;
            dgvVanTu.DataSource = _cVanTu.GetDS();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Length == 11)
                btnThem.PerformClick();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (_cVanTu.CheckExist(txtDanhBo.Text.Trim()))
                {
                    MessageBox.Show("Danh Bộ đã có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TT_VanTu vantu = new TT_VanTu();
                vantu.DanhBo = txtDanhBo.Text.Trim();
                if(_cVanTu.Them(vantu))
                    dgvVanTu.DataSource = _cVanTu.GetDS();
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                foreach (DataGridViewRow item in dgvVanTu.SelectedRows)
                {
                    TT_VanTu vantu = _cVanTu.GetByID(item.Cells["DanhBo"].Value.ToString());
                    _cVanTu.Xoa(vantu);
                }
                dgvVanTu.DataSource = _cVanTu.GetDS();
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvVanTu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvVanTu.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvVanTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvVanTu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        
    }
}
