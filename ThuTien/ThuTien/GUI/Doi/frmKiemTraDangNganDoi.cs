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
    public partial class frmKiemTraDangNganDoi : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmKiemTraDangNganDoi()
        {
            InitializeComponent();
        }

        private void frmKiemTraDangNganDoi_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            List<TT_To> lst = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lst.Insert(0, to);
            cmbTo.DataSource = lst;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (int.Parse(cmbTo.SelectedValue.ToString()) == 0)
            {
                DataTable dtTG = new DataTable();
                DataTable dtCQ = new DataTable();
                List<TT_To> lst = _cTo.GetDSHanhThu();
                dtTG = _cHoaDon.GetTongDangNganByNgayDangNgan_Doi(lst[0].MaTo, "TG", dateDangNgan.Value);
                dtCQ = _cHoaDon.GetTongDangNganByNgayDangNgan_Doi(lst[0].MaTo, "CQ", dateDangNgan.Value);
                for (int i = 1; i < lst.Count; i++)
                {
                    dtTG.Merge(_cHoaDon.GetTongDangNganByNgayDangNgan_Doi(lst[i].MaTo, "TG", dateDangNgan.Value));
                    dtCQ.Merge(_cHoaDon.GetTongDangNganByNgayDangNgan_Doi(lst[i].MaTo, "CQ", dateDangNgan.Value));
                }
            }
            else
            {
                dgvHDTuGia.DataSource = _cHoaDon.GetTongDangNganByNgayDangNgan_Doi(int.Parse(cmbTo.SelectedValue.ToString()), "TG", dateDangNgan.Value);
                dgvHDCoQuan.DataSource = _cHoaDon.GetTongDangNganByNgayDangNgan_Doi(int.Parse(cmbTo.SelectedValue.ToString()), "CQ", dateDangNgan.Value);
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
        }

        private void dgvHDTuGia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDTuGia.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
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
