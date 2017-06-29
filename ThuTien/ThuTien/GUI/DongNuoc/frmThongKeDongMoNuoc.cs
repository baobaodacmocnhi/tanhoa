using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.DongNuoc;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.DAL;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmThongKeDongMoNuoc : Form
    {
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CTo _cTo = new CTo();
        CDocSoHandheld _cDocSoHandheld = new CDocSoHandheld();

        public frmThongKeDongMoNuoc()
        {
            InitializeComponent();
        }

        private void frmThongKeDongMoNuoc_Load(object sender, EventArgs e)
        {
            dgvKQDongNuoc.AutoGenerateColumns = false;
            dgvDongNuoc.AutoGenerateColumns = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            List<TT_To> lstTo = _cTo.GetDSHanhThu();
            DataTable dt = new DataTable();

            for (int i = 1; i <= lstTo.Count; i++)
            {
                dt.Merge(_cDongNuoc.CountDongMoNuoc(i, dateTu.Value, dateDen.Value));
            }

            dgvKQDongNuoc.DataSource = dt;

            int TongDongNuoc = 0;
            int TongMoNuoc = 0;

            foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["DongNuoc"].Value.ToString()))
                    TongDongNuoc += int.Parse(item.Cells["DongNuoc"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["MoNuoc"].Value.ToString()))
                    TongMoNuoc += int.Parse(item.Cells["MoNuoc"].Value.ToString());
            }
            txtTongDongNuoc.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongDongNuoc);
            txtTongMoNuoc.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongMoNuoc);

            dgvDongNuoc.DataSource= _cDongNuoc.GetDSKQDongNuocByNgayDNs(dateTu.Value, dateDen.Value);
            foreach (DataGridViewRow item in dgvDongNuoc.Rows)
            {
                DocSo entity = _cDocSoHandheld.Get(item.Cells["DanhBo"].Value.ToString());
                item.Cells["ChiSo"].Value = entity.CSMoi;
                item.Cells["NgayDoc"].Value = entity.DenNgay;
                if (bool.Parse(item.Cells["DongPhi"].Value.ToString()) == false 
                    && int.Parse(item.Cells["ChiSoDN"].Value.ToString()) != int.Parse(item.Cells["ChiSo"].Value.ToString())
                    && DateTime.Parse(item.Cells["NgayDN"].Value.ToString()) < DateTime.Parse(item.Cells["NgayDoc"].Value.ToString()))
                {
                    item.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void dgvDongNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDongNuoc.Columns[e.ColumnIndex].Name == "MaDN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDongNuoc.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvDongNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDongNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
