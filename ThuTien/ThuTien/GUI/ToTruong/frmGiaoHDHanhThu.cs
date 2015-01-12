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
            txtTuSoPhatHanh.Text = "";
            txtDenSoPhatHanh.Text = "";
        }

        public void LoadDataGridView()
        {
            //if (tabControl.SelectedTab.Name == "tabTuGia")
            //{

                dgvHDTuGia.DataSource = _cHoaDon.GetDSGiaoByNamKyDot(CNguoiDung.MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
            //}
            //else
            //    if (tabControl.SelectedTab.Name == "tabCoQuan")
            //    {

                    dgvHDCoQuan.DataSource = _cHoaDon.GetDSGiaoByNamKyDot(CNguoiDung.MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                //}
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
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHD_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBan_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongThueGTGT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongPhiBVMT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHD_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBan_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongThueGTGT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongPhiBVMT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDTuGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                if (dgvHDTuGia["MaNV_TG", e.RowIndex].Value.ToString() != "")
                    cmbNhanVien.SelectedValue = dgvHDTuGia["MaNV_TG", e.RowIndex].Value;
                txtTuSoPhatHanh.Text = dgvHDTuGia["TuSoPhatHanh_TG", e.RowIndex].Value.ToString();
                txtDenSoPhatHanh.Text = dgvHDTuGia["DenSoPhatHanh_TG", e.RowIndex].Value.ToString();
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
                if (dgvHDCoQuan["MaNV_CQ", e.RowIndex].Value.ToString() != "")
                    cmbNhanVien.SelectedValue = dgvHDCoQuan["MaNV_CQ", e.RowIndex].Value;
                txtTuSoPhatHanh.Text = dgvHDCoQuan["TuSoPhatHanh_CQ", e.RowIndex].Value.ToString();
                txtDenSoPhatHanh.Text = dgvHDCoQuan["DenSoPhatHanh_CQ", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                //var startTime = System.Diagnostics.Stopwatch.StartNew();
                if (tabControl.SelectedTab.Name == "tabTuGia")
                {
                    if (dgvHDTuGia.RowCount > 0 && cmbNhanVien.SelectedIndex != -1 && txtTuSoPhatHanh.Text.Trim() != "" && txtDenSoPhatHanh.Text.Trim() != "")
                    {
                        if (int.Parse(txtTuSoPhatHanh.Text.Trim()) <= int.Parse(txtDenSoPhatHanh.Text.Trim()))
                            if (!_cHoaDon.CheckGiaoByNamKyDot(decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString())))
                                if (_cHoaDon.CheckSoPhatHanhByNamKyDot(CNguoiDung.MaTo, "TG", decimal.Parse(txtTuSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()))
                                    && _cHoaDon.CheckSoPhatHanhByNamKyDot(CNguoiDung.MaTo, "TG", decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                                {
                                    if (_cHoaDon.ThemChia(CNguoiDung.MaTo, "TG", decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()),
                                        int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                    {
                                        LoadDataGridView();
                                        Clear();
                                    }
                                }
                                else
                                    MessageBox.Show("Sai Số Phát Hành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                MessageBox.Show("Có Hóa Đơn được giao\nVui lòng kiểm tra lại Số Phát Hành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    if (tabControl.SelectedTab.Name == "tabCoQuan")
                    {
                        if (dgvHDCoQuan.RowCount > 0 && cmbNhanVien.SelectedIndex != -1 && txtTuSoPhatHanh.Text.Trim() != "" && txtDenSoPhatHanh.Text.Trim() != "")
                        {
                            if (int.Parse(txtTuSoPhatHanh.Text.Trim()) <= int.Parse(txtDenSoPhatHanh.Text.Trim()))
                                if (!_cHoaDon.CheckGiaoByNamKyDot(decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString())))
                                    if (_cHoaDon.CheckSoPhatHanhByNamKyDot(CNguoiDung.MaTo, "CQ", decimal.Parse(txtTuSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()))
                                        && _cHoaDon.CheckSoPhatHanhByNamKyDot(CNguoiDung.MaTo, "CQ", decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                                    {
                                        if (_cHoaDon.ThemChia(CNguoiDung.MaTo, "CQ", decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()),
                                            int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                        {
                                            LoadDataGridView();
                                            Clear();
                                        }
                                    }
                                    else
                                        MessageBox.Show("Sai Số Phát Hành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    MessageBox.Show("Có Hóa Đơn được giao\nVui lòng kiểm tra lại Số Phát Hành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                //startTime.Stop();
                //MessageBox.Show(startTime.ElapsedMilliseconds.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {

                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_selectedindex != -1)
                    {
                        //var startTime = System.Diagnostics.Stopwatch.StartNew();
                        if (tabControl.SelectedTab.Name == "tabTuGia")
                        {
                            if (!_cHoaDon.CheckDangNganByNamKyDot(decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString())))
                            {
                                if (_cHoaDon.XoaChia(CNguoiDung.MaTo, "TG", decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()),
                                                    int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                                {
                                    LoadDataGridView();
                                    Clear();
                                }
                            }
                            else
                                MessageBox.Show("Hóa Đơn đã được Đăng Ngân, Không được Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (tabControl.SelectedTab.Name == "tabCoQuan")
                        {
                            if (!_cHoaDon.CheckDangNganByNamKyDot(decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString())))
                            {
                                if (_cHoaDon.XoaChia(CNguoiDung.MaTo, "CQ", decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()),
                                                    int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                                {
                                    LoadDataGridView();
                                    Clear();
                                }
                            }
                            else
                                MessageBox.Show("Hóa Đơn đã được Đăng Ngân, Không được Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //startTime.Stop();
                        //MessageBox.Show(startTime.ElapsedMilliseconds.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Hóa Đơn(đã giao) cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
