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
using ThuTien.DAL.Doi;
using System.Globalization;

namespace ThuTien.GUI.Doi
{
    public partial class frmBangTongHop : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmBangTongHop()
        {
            InitializeComponent();
        }

        private void frmBangTongHop_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            List<TT_To> lst = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lst.Insert(0, to);
            cmbTo.DataSource = lst;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        public void LoadDataGridView()
        {
            int TongHDThu = 0;
            long TongCongThu = 0;
            if (dgvHoaDon.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                {
                    TongHDThu += int.Parse(item.Cells["TongHDThu"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu"].Value.ToString());
                }
                txtTongHDThu.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongCongThu.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            List<TT_To> lst = _cTo.GetDSHanhThu();

            dt = _cHoaDon.GetBangTongHop(lst[0].MaTo, dateTu.Value, dateDen.Value);
            for (int i = 1; i < lst.Count; i++)
            {
                dt.Merge(_cHoaDon.GetBangTongHop(lst[i].MaTo, dateTu.Value, dateDen.Value));
            }
            dgvHoaDon.DataSource = dt;
            LoadDataGridView();
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongHDThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCongThu" && e.Value != null)
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (cmbKy.SelectedIndex != -1)
            {

            }
        }

        
    }
}
