using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ThuTien.DAL.Quay;

namespace ThuTien.GUI.Quay
{
    public partial class frmTienDuQuay : Form
    {
        CTienDuQuay _cTienDuQuay = new CTienDuQuay();

        public frmTienDuQuay()
        {
            InitializeComponent();
        }

        private void frmTienDuQuay_Load(object sender, EventArgs e)
        {
            dgvTienAm.AutoGenerateColumns = false;
            dgvTienDu.AutoGenerateColumns = false;
        }

        public void CountdgvTienDu()
        {
            long TongCong = 0;
            if (dgvTienDu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvTienDu.Rows)
                {
                    TongCong += long.Parse(item.Cells["SoTien_TienDu"].Value.ToString());
                }
                txtTongCongTienDu.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CountdgvTienAm()
        {
            long TongCong = 0;
            if (dgvTienAm.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvTienAm.Rows)
                {
                    TongCong += long.Parse(item.Cells["SoTien_TienAm"].Value.ToString());
                }
                txtTongCongTienAm.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void dgvTienAm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTienAm.Columns[e.ColumnIndex].Name == "DanhBo_TienAm" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvTienAm.Columns[e.ColumnIndex].Name == "SoTien_TienAm" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTienAm_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTienAm.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTienDu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTienDu.Columns[e.ColumnIndex].Name == "DanhBo_TienDu" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvTienDu.Columns[e.ColumnIndex].Name == "SoTien_TienDu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTienDu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTienDu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvTienAm.DataSource = _cTienDuQuay.GetDSTienAm();
            CountdgvTienAm();
            dgvTienDu.DataSource = _cTienDuQuay.GetDSTienDu();
            CountdgvTienDu();
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
            //dialog.Multiselect = false;

            //if (dialog.ShowDialog() == DialogResult.OK)
            //    if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //    {
            //        ThuTien.DAL.ChuyenKhoan.Excel fileExcel = new ThuTien.DAL.ChuyenKhoan.Excel(dialog.FileName);
            //        DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

            //        foreach (DataRow item in dtExcel.Rows)
            //                {
            //                    _cTienDuQuay.Update(item[0].ToString(), int.Parse(item[1].ToString()), "Bảng Kê", "Thêm");
            //                }
            //    }
        }
    }
}
