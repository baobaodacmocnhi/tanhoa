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
        string _mnu = "mnuGiaoHDHanhThu";
        int _selectedindex = -1;

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

        public void Clear()
        {
            _selectedindex = -1;
            cmbNhanVien.SelectedIndex = -1;
            txtTuMLT.Text = "";
            txtDenMLT.Text = "";
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
                Clear();
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
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                var startTime = System.Diagnostics.Stopwatch.StartNew();
                if (tabControl.SelectedTab.Name == "tabTuGia")
                {
                    if (dgvHDTuGia.RowCount > 0 && cmbNhanVien.SelectedIndex != -1 && txtTuMLT.Text.Trim() != "" && txtDenMLT.Text.Trim() != "")
                    {
                        if (int.Parse(txtTuMLT.Text.Trim()) <= int.Parse(txtDenMLT.Text.Trim()))
                            if (_cHoaDon.CheckMLTByNamKyDot(CNguoiDung.MaTo, "TG", txtTuMLT.Text.Trim(), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()))
                                && _cHoaDon.CheckMLTByNamKyDot(CNguoiDung.MaTo, "TG", txtDenMLT.Text.Trim(), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                            {
                                if (_cHoaDon.ThemChia(CNguoiDung.MaTo, "TG", txtTuMLT.Text.Trim(), txtDenMLT.Text.Trim(), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                {
                                    LoadDataGridView();
                                    Clear();
                                }
                            }
                            else
                                MessageBox.Show("Sai MLT", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    if (tabControl.SelectedTab.Name == "tabCoQuan")
                    {
                        if (dgvHDCoQuan.RowCount > 0 && cmbNhanVien.SelectedIndex != -1 && txtTuMLT.Text.Trim() != "" && txtDenMLT.Text.Trim() != "")
                        {
                            if (int.Parse(txtTuMLT.Text.Trim()) <= int.Parse(txtDenMLT.Text.Trim()))
                                if (_cHoaDon.CheckMLTByNamKyDot(CNguoiDung.MaTo, "CQ", txtTuMLT.Text.Trim(), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()))
                                    && _cHoaDon.CheckMLTByNamKyDot(CNguoiDung.MaTo, "CQ", txtDenMLT.Text.Trim(), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                                {
                                    if (_cHoaDon.ThemChia(CNguoiDung.MaTo, "CQ", txtTuMLT.Text.Trim(), txtDenMLT.Text.Trim(), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                    {
                                        LoadDataGridView();
                                        Clear();
                                    }
                                }
                                else
                                    MessageBox.Show("Sai MLT", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                startTime.Stop();
                MessageBox.Show(startTime.ElapsedMilliseconds.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (_selectedindex != -1)
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        var startTime = System.Diagnostics.Stopwatch.StartNew();
                        if (tabControl.SelectedTab.Name == "tabTuGia")
                        {
                            if (_cHoaDon.XoaChia(CNguoiDung.MaTo, "TG", txtTuMLT.Text.Trim(), txtDenMLT.Text.Trim(), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                            {
                                LoadDataGridView();
                                Clear();
                            }
                        }
                        if (tabControl.SelectedTab.Name == "tabCoQuan")
                        {
                            if (_cHoaDon.XoaChia(CNguoiDung.MaTo, "CQ", txtTuMLT.Text.Trim(), txtDenMLT.Text.Trim(), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                            {
                                LoadDataGridView();
                                Clear();
                            }
                        }
                        startTime.Stop();
                        MessageBox.Show(startTime.ElapsedMilliseconds.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }  
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHDTuGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                if (dgvHDTuGia["MaNV", e.RowIndex].Value.ToString() != "")
                    cmbNhanVien.SelectedValue = dgvHDTuGia["MaNV", e.RowIndex].Value;
                txtTuMLT.Text = dgvHDTuGia["TuMLT", e.RowIndex].Value.ToString();
                txtDenMLT.Text = dgvHDTuGia["DenMLT", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void dgvHDCoQuan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                if (dgvHDCoQuan["MaNV", e.RowIndex].Value.ToString() != "")
                    cmbNhanVien.SelectedValue = dgvHDCoQuan["MaNV", e.RowIndex].Value;
                txtTuMLT.Text = dgvHDCoQuan["TuMLT", e.RowIndex].Value.ToString();
                txtDenMLT.Text = dgvHDCoQuan["DenMLT", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }


    }
}
