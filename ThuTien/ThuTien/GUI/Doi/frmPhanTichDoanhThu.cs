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
using ThuTien.BaoCao;
using ThuTien.BaoCao.Doi;
using ThuTien.GUI.BaoCao;

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
            dgvDoanhThu.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            cmbKy.SelectedItem = DateTime.Now.Month.ToString();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dtTong = new DataTable();
            DataTable dtPhanTich = new DataTable();
            if (radGiaBieu.Checked)
            {
                if (cmbKy.SelectedIndex == 0)
                {
                    dtTong = _cHoaDon.GetGiaBanBinhQuan(int.Parse(cmbNam.SelectedValue.ToString()));
                    dtPhanTich = _cHoaDon.PhanTichDoanhThuByGiaBieu(int.Parse(cmbNam.SelectedValue.ToString()));
                }
                else
                    if (cmbKy.SelectedIndex > 0)
                    {
                        dtTong = _cHoaDon.GetGiaBanBinhQuan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                        dtPhanTich = _cHoaDon.PhanTichDoanhThuByGiaBieu(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    }
            }
            else
                if (radDinhMuc.Checked)
                {
                    if (cmbKy.SelectedIndex == 0)
                    {
                        dtTong = _cHoaDon.GetGiaBanBinhQuan(int.Parse(cmbNam.SelectedValue.ToString()));
                        dtPhanTich = _cHoaDon.PhanTichDoanhThuByDinhMuc(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtTuDM.Text.Trim()), int.Parse(txtDenDM.Text.Trim()));
                    }
                    else
                        if (cmbKy.SelectedIndex > 0)
                        {
                            dtTong = _cHoaDon.GetGiaBanBinhQuan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            if (string.IsNullOrEmpty(txtTuDM2.Text.Trim()) == false && string.IsNullOrEmpty(txtTuDM2.Text.Trim()) == false && string.IsNullOrEmpty(txtTuDM3.Text.Trim()) == false && string.IsNullOrEmpty(txtTuDM3.Text.Trim()) == false)
                                dtPhanTich = _cHoaDon.PhanTichDoanhThuByDinhMuc(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtTuDM.Text.Trim()), int.Parse(txtDenDM.Text.Trim()), int.Parse(txtTuDM2.Text.Trim()), int.Parse(txtDenDM2.Text.Trim()), int.Parse(txtTuDM3.Text.Trim()), int.Parse(txtDenDM3.Text.Trim()));
                            else
                                if (string.IsNullOrEmpty(txtTuDM2.Text.Trim()) == false && string.IsNullOrEmpty(txtTuDM2.Text.Trim()) == false)
                                    dtPhanTich = _cHoaDon.PhanTichDoanhThuByDinhMuc(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtTuDM.Text.Trim()), int.Parse(txtDenDM.Text.Trim()), int.Parse(txtTuDM2.Text.Trim()), int.Parse(txtDenDM2.Text.Trim()));
                                else
                                    dtPhanTich = _cHoaDon.PhanTichDoanhThuByDinhMuc(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtTuDM.Text.Trim()), int.Parse(txtDenDM.Text.Trim()));
                        }
                }

            txtTongHD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", decimal.Parse(dtTong.Rows[0]["TongHD"].ToString()));
            txtTongDinhMuc.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", decimal.Parse(dtTong.Rows[0]["TongDinhMuc"].ToString()));
            txtTongTieuThu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", decimal.Parse(dtTong.Rows[0]["TongTieuThu"].ToString()));
            txtTongGiaBan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", decimal.Parse(dtTong.Rows[0]["TongGiaBan"].ToString()));
            txtGiaBanBinhQuan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", decimal.Parse(dtTong.Rows[0]["GiaBanBinhQuan"].ToString()));

            dgvDoanhThu.DataSource = dtPhanTich;

            foreach (DataGridViewRow item in dgvDoanhThu.Rows)
                if (decimal.Parse(item.Cells["TongGiaBan"].Value.ToString()) > 0 && decimal.Parse(item.Cells["TongTieuThu"].Value.ToString()) > 0)
                {
                    item.Cells["GiaBanBinhQuan"].Value =decimal.Parse(item.Cells["TongGiaBan"].Value.ToString()) / decimal.Parse(item.Cells["TongTieuThu"].Value.ToString());
                    item.Cells["TyLeTongTieuThu"].Value = Math.Round((decimal.Parse(item.Cells["TongTieuThu"].Value.ToString()) / decimal.Parse(dtTong.Rows[0]["TongTieuThu"].ToString())) * 100, 2);
                    item.Cells["TyLeTongGiaBan"].Value = Math.Round((decimal.Parse(item.Cells["TongGiaBan"].Value.ToString()) / decimal.Parse(dtTong.Rows[0]["TongGiaBan"].ToString())) * 100, 2);
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
            if (dgvDoanhThu.Columns[e.ColumnIndex].Name == "TongHD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
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
                ///
                lbTuDM2.Visible = true;
                txtTuDM2.Visible = true;
                lbDenDM2.Visible = true;
                txtDenDM2.Visible = true;
                ///
                lbTuDM3.Visible = true;
                txtTuDM3.Visible = true;
                lbDenDM3.Visible = true;
                txtDenDM3.Visible = true;
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
                ///
                lbTuDM2.Visible = false;
                txtTuDM2.Visible = false;
                lbDenDM2.Visible = false;
                txtDenDM2.Visible = false;
                ///
                lbTuDM3.Visible = false;
                txtTuDM3.Visible = false;
                lbDenDM3.Visible = false;
                txtDenDM3.Visible = false;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDoanhThu.Rows)
            {
                DataRow dr = ds.Tables["PhanTichDoanhThu"].NewRow();
                if (radGiaBieu.Checked)
                    dr["LoaiBaoCao"] = "Giá Biểu";
                else
                    if (radDinhMuc.Checked)
                        dr["LoaiBaoCao"] = "Định Mức";
                dr["Ky"] = cmbKy.SelectedItem.ToString();
                dr["Nam"] = cmbNam.SelectedValue.ToString();
                dr["Loai"] = item.Cells["Loai"].Value.ToString();
                dr["TongHD"] = item.Cells["TongHD"].Value;
                dr["TongDinhMuc"] = item.Cells["TongDinhMuc"].Value;
                dr["TongTieuThu"] = item.Cells["TongTieuThu"].Value;
                dr["TongGiaBan"] = item.Cells["TongGiaBan"].Value;
                dr["GiaBanBinhQuan"] = item.Cells["GiaBanBinhQuan"].Value;
                dr["TyLeTongTieuThu"] = item.Cells["TyLeTongTieuThu"].Value;
                dr["TyLeTongGiaBan"] = item.Cells["TyLeTongGiaBan"].Value;

                ds.Tables["PhanTichDoanhThu"].Rows.Add(dr);
            }
            rptPhanTichDoanhThu rpt = new rptPhanTichDoanhThu();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }
    }
}
