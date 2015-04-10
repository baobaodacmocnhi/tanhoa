using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.QuanTri;
using System.Globalization;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmKiemTraDangNgan : Form
    {
        //string _mnu = "mnuKiemTraDangNgan";
        CHoaDon _cHoaDon = new CHoaDon();

        public frmKiemTraDangNgan()
        {
            InitializeComponent();
        }

        private void frmKiemTraDangNgan_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
        }

        public void LoadDataGridView()
        {
            dgvHDTuGia.DataSource = _cHoaDon.GetTongDangNganByNgayDangNgan(CNguoiDung.MaTo, "TG", dateDangNgan.Value);
            dgvHDCoQuan.DataSource = _cHoaDon.GetTongDangNganByNgayDangNgan(CNguoiDung.MaTo, "CQ", dateDangNgan.Value);
            int TongHD = 0;
            int TongCong = 0;
            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    TongHD += int.Parse(item.Cells["TongHD_TG"].Value.ToString());
                    TongCong += int.Parse(item.Cells["TongCong_TG"].Value.ToString());
                }
                txtTongHD_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
            TongHD = 0;
            TongCong = 0;
            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    TongHD += int.Parse(item.Cells["TongHD_CQ"].Value.ToString());
                    TongCong += int.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHD_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            //if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDThu_TG" && e.Value != null)
            //{
            //    e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            //}
            //if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongThu_TG" && e.Value != null)
            //{
            //    e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            //}
            //if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDTon_TG" && e.Value != null)
            //{
            //    e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            //}
            //if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongTon_TG" && e.Value != null)
            //{
            //    e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            //}
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHD_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            //if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHDThu_CQ" && e.Value != null)
            //{
            //    e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            //}
            //if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCongThu_CQ" && e.Value != null)
            //{
            //    e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            //}
            //if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHDTon_CQ" && e.Value != null)
            //{
            //    e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            //}
            //if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCongTon_CQ" && e.Value != null)
            //{
            //    e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            //}
        }

        private void dgvHDTuGia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDTuGia.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDCoQuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDCoQuan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
