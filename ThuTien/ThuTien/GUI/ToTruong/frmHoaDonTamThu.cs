using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Quay;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.DongNuoc;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmHoaDonTamThu : Form
    {
        CTamThu _cTamThu = new CTamThu();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        public frmHoaDonTamThu()
        {
            InitializeComponent();
        }

        private void frmHoaDonTamThu_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cTamThu.GetDSTon(CNguoiDung.MaTo, false);

            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                if (_cDongNuoc.CheckExist_CTDongNuoc(item.Cells["SoHoaDon"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Yellow;
                if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
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
