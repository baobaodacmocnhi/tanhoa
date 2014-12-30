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
using ThuTien.LinQ;
using System.Globalization;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmGiaoHDHanhThu : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();

        public frmGiaoHDHanhThu()
        {
            InitializeComponent();
        }

        private void frmGiaoHoaDonHanhThu_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;
            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            cmbNhanVien.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
            cmbNhanVien.DisplayMember = "HoTen";
            cmbNhanVien.ValueMember = "MaND";

            lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
        }

        public void LoadDataGridView()
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {

                dgvHDTuGia.DataSource = _cHoaDon.GetDSChiaByNamKyDot(CNguoiDung.MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {

                    dgvHDCoQuan.DataSource = _cHoaDon.GetDSChiaByNamKyDot(CNguoiDung.MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                }
        }

        private void txtTuMLT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDenMLT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbKy.SelectedIndex != -1 && cmbDot.SelectedIndex != -1)
            {
                LoadDataGridView();
            }
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongLNCC" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongPhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongLNCC" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongPhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
                if (dgvHDTuGia.RowCount > 0 && txtTuMLT.Text.Trim() != "" && txtDenMLT.Text.Trim() != "")
                {
                    DataTable dt = (DataTable)dgvHDTuGia.DataSource;
                    if (int.Parse(txtTuMLT.Text.Trim()) <= int.Parse(txtDenMLT.Text.Trim()))
                        if (_cHoaDon.CheckMLTByNamKyDot(CNguoiDung.MaTo, txtTuMLT.Text.Trim(), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()))
                            && _cHoaDon.CheckMLTByNamKyDot(CNguoiDung.MaTo, txtDenMLT.Text.Trim(), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                        {
                            List<HOADON> lstHD = _cHoaDon.GetDSByMLTNamKyDot(CNguoiDung.MaTo, txtTuMLT.Text.Trim(), txtDenMLT.Text.Trim(), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                            foreach (HOADON item in lstHD)
                            {
                                item.MaNV_HanhThu = int.Parse(cmbNhanVien.SelectedValue.ToString());
                                item.ModifyDate = DateTime.Now;
                                item.ModifyBy = CNguoiDung.MaND;
                            }
                            if (_cHoaDon.ThemChia(lstHD))
                            {
                                LoadDataGridView();
                            }
                        }
                        else
                            MessageBox.Show("Sai MLT", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }


    }
}
