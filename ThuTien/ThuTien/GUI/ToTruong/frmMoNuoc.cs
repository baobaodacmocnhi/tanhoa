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

namespace ThuTien.GUI.ToTruong
{
    public partial class frmMoNuoc : Form
    {
        CDongNuoc _cDongNuoc = new CDongNuoc();

        public frmMoNuoc()
        {
            InitializeComponent();
        }

        private void frmMoNuoc_Load(object sender, EventArgs e)
        {
            dgvKQDongNuoc.AutoGenerateColumns = false;

            dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSCanMoNuoc(CNguoiDung.MaTo);
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
    }
}
