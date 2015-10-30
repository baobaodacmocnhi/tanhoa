using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Globalization;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmDichVuThu : Form
    {
        CDichVuThu _cDichVuThu = new CDichVuThu();
        CTo _cTo = new CTo();

        public frmDichVuThu()
        {
            InitializeComponent();
        }

        private void frmDichVuThu_Load(object sender, EventArgs e)
        {
            dgvDichVuThu.AutoGenerateColumns = false;

            DataTable dtDichVuThu = _cDichVuThu.GetDichVuThu();
            DataRow dr = dtDichVuThu.NewRow();
            dr["ID"] = "";
            dr["TenDichVu"] = "Tất Cả";
            dtDichVuThu.Rows.InsertAt(dr, 0);
            cmbDichVuThu.DataSource = dtDichVuThu;
            cmbDichVuThu.DisplayMember = "TenDichVu";
            cmbDichVuThu.ValueMember = "ID";

            List<TT_To> lstTo = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lstTo.Insert(0, to);
            cmbTo.DataSource = lstTo;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            ///chọn tất cả tổ
            if (cmbTo.SelectedIndex == 0)
            {
                dgvDichVuThu.DataSource = _cDichVuThu.GetDS(cmbDichVuThu.SelectedValue.ToString(),dateTu.Value, dateDen.Value);
            }
            ///chọn 1 tổ
            else
            {
                dgvDichVuThu.DataSource = _cDichVuThu.GetDS(int.Parse(cmbTo.SelectedValue.ToString()), cmbDichVuThu.SelectedValue.ToString(), dateTu.Value, dateDen.Value);
            }

            long TongSoTien = 0;
            int TongPhi = 0;
            foreach (DataGridViewRow item in dgvDichVuThu.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["SoTien"].Value.ToString()))
                    TongSoTien += int.Parse(item.Cells["SoTien"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["Phi"].Value.ToString()))
                    TongPhi += int.Parse(item.Cells["Phi"].Value.ToString());
            }
            txtTongHD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}",dgvDichVuThu.Rows.Count);
            txtTongSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongSoTien);
            txtTongPhi.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhi);
        }

        private void dgvDichVuThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "Phi" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDichVuThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDichVuThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
