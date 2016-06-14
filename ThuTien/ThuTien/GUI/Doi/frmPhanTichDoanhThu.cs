using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using System.Globalization;

namespace ThuTien.GUI.Doi
{
    public partial class frmPhanTichDoanhThu : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();

        public frmPhanTichDoanhThu()
        {
            InitializeComponent();
        }

        private void frmPhanTichDoanhThu_Load(object sender, EventArgs e)
        {
            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtPhanTich = new DataTable();
            if (radGiaBieu.Checked)
            {
                if (cmbKy.SelectedIndex == 0)
                {
                    dt = _cHoaDon.GetGiaBanBinhQuan(int.Parse(cmbNam.SelectedValue.ToString()));
                    dtPhanTich = _cHoaDon.PhanTichDoanhThuByGiaBieu(int.Parse(cmbNam.SelectedValue.ToString()));
                }
                else
                    if (cmbKy.SelectedIndex > 0)
                    {
                         dt = _cHoaDon.GetGiaBanBinhQuan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                         dtPhanTich = _cHoaDon.PhanTichDoanhThuByGiaBieu(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    }
            }
            else
                if (radDinhMuc.Checked)
                {
                    if (cmbKy.SelectedIndex == 0)
                    {
                        dt = _cHoaDon.GetGiaBanBinhQuan(int.Parse(cmbNam.SelectedValue.ToString()));
                        dtPhanTich = _cHoaDon.PhanTichDoanhThuByGiaBieu(int.Parse(cmbNam.SelectedValue.ToString()));
                    }
                    else
                        if (cmbKy.SelectedIndex > 0)
                        {
                            dt = _cHoaDon.GetGiaBanBinhQuan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            dtPhanTich = _cHoaDon.PhanTichDoanhThuByDinhMuc(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtTuDM.Text.Trim()), int.Parse(txtDenDM.Text.Trim()));
                        }
                }

            txtTongHD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", decimal.Parse(dt.Rows[0]["TongHD"].ToString()));
            txtTongTieuThu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", decimal.Parse(dt.Rows[0]["TongTieuThu"].ToString()));
            txtTongGiaBan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", decimal.Parse(dt.Rows[0]["TongGiaBan"].ToString()));

            dgvDoanhThu.DataSource = dtPhanTich;

            foreach (DataGridViewRow item in dgvDoanhThu.Rows)
                if ((decimal)item.Cells["TongGiaBan"].Value > 0 && (decimal)item.Cells["TongTieuThu"].Value > 0)
                {
                    item.Cells["GiaBanBinhQuan"].Value = (decimal)item.Cells["TongGiaBan"].Value / (decimal)item.Cells["TongTieuThu"].Value;
                    item.Cells["TyLeTongTieuThu"].Value = Math.Round(((decimal)item.Cells["TongTieuThu"].Value / decimal.Parse(dt.Rows[0]["TongTieuThu"].ToString()))*100,2);
                    item.Cells["TyLeTongGiaBan"].Value = Math.Round(((decimal)item.Cells["TongGiaBan"].Value / decimal.Parse(dt.Rows[0]["TongGiaBan"].ToString()))*100,2);
                }
                else
                {
                    item.Cells["GiaBanBinhQuan"].Value = 0;
                    item.Cells["TyLeTongTieuThu"].Value = 0;
                    item.Cells["TyLeTongGiaBan"].Value = 0;
                }
        }

        private void dgvDoanhThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDoanhThu.Columns[e.ColumnIndex].Name == "TongGiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDoanhThu.Columns[e.ColumnIndex].Name == "TongTieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDoanhThu.Columns[e.ColumnIndex].Name == "TongDinhMuc" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDoanhThu.Columns[e.ColumnIndex].Name == "GiaBanBinhQuan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDoanhThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDoanhThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void radDinhMuc_CheckedChanged(object sender, EventArgs e)
        {
            if (radDinhMuc.Checked)
            {
                lbTuDM.Visible = true;
                txtTuDM.Visible = true;
                lbDenDM.Visible = true;
                txtDenDM.Visible = true;
            }
        }

        private void radGiaBieu_CheckedChanged(object sender, EventArgs e)
        {
            if (radGiaBieu.Checked)
            {
                lbTuDM.Visible = false;
                txtTuDM.Visible = false;
                lbDenDM.Visible = false;
                txtDenDM.Visible = false;
            }
        }
    }
}
