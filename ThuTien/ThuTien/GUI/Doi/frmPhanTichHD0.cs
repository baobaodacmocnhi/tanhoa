using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;

namespace ThuTien.GUI.Doi
{
    public partial class frmPhanTichHD0 : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();

        public frmPhanTichHD0()
        {
            InitializeComponent();
        }

        private void frmPhanTichHD0_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbKy.SelectedIndex == 0)
                dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0(int.Parse(cmbNam.SelectedValue.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
            else
                if (cmbKy.SelectedIndex > 0)
                    dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
