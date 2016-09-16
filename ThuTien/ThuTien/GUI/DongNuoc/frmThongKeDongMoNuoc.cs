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

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmThongKeDongMoNuoc : Form
    {
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CTo _cTo = new CTo();

        public frmThongKeDongMoNuoc()
        {
            InitializeComponent();
        }

        private void frmThongKeDongMoNuoc_Load(object sender, EventArgs e)
        {
            dgvKQDongNuoc.AutoGenerateColumns = false;
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
        }
    }
}
