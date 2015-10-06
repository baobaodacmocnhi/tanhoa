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
using ThuTien.BaoCao;
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao.ToTruong;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmGiaoHDHanhThu : Form
    {
        string _mnu = "mnuGiaoHDHanhThu";
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();
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

            cmbCucChia.SelectedIndex = 0;
        }

        public void Clear()
        {
            _selectedindex = -1;
            cmbNhanVien.SelectedIndex = -1;
            txtTuSoPhatHanh.Text = "";
            txtDenSoPhatHanh.Text = "";
        }

        public void CountdgvHDTuGia()
        {
            int TongHD = 0;
            int TongGiaBan = 0;
            int TongThueGTGT = 0;
            int TongPhiBVMT = 0;
            int TongCong = 0;
            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_TG"].Value.ToString()))
                    TongHD += int.Parse(item.Cells["TongHD_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBan_TG"].Value.ToString()))
                    TongGiaBan += int.Parse(item.Cells["TongGiaBan_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongThueGTGT_TG"].Value.ToString()))
                    TongThueGTGT += int.Parse(item.Cells["TongThueGTGT_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongPhiBVMT_TG"].Value.ToString()))
                    TongPhiBVMT += int.Parse(item.Cells["TongPhiBVMT_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_TG"].Value.ToString()))
                    TongCong += int.Parse(item.Cells["TongCong_TG"].Value.ToString());
                }
                txtTongHD_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
            
        }

        public void CountdgvHDCoQuan()
        {
            int TongHD = 0;
            int TongGiaBan = 0;
            int TongThueGTGT = 0;
            int TongPhiBVMT = 0;
            int TongCong = 0;
            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_CQ"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["TongHD_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBan_CQ"].Value.ToString()))
                        TongGiaBan += int.Parse(item.Cells["TongGiaBan_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongThueGTGT_CQ"].Value.ToString()))
                        TongThueGTGT += int.Parse(item.Cells["TongThueGTGT_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongPhiBVMT_CQ"].Value.ToString()))
                        TongPhiBVMT += int.Parse(item.Cells["TongPhiBVMT_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_CQ"].Value.ToString()))
                        TongCong += int.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
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
                if (tabControl.SelectedTab.Name == "tabTuGia")
                {
                    dgvHDTuGia.DataSource = _cHoaDon.GetTongGiaoByNamKyDot("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                    CountdgvHDTuGia();
                }
                else
                    if (tabControl.SelectedTab.Name == "tabCoQuan")
                    {
                        dgvHDCoQuan.DataSource = _cHoaDon.GetTongGiaoByNamKyDot("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                        CountdgvHDCoQuan();
                    }
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
                cmbCucChia.SelectedItem = dgvHDTuGia["DotChia_TG", e.RowIndex].Value.ToString();
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
                cmbCucChia.SelectedItem = dgvHDCoQuan["DotChia_CQ", e.RowIndex].Value.ToString();
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
                            if (!_cHoaDon.CheckGiaoBySoPhatHanhsNam(decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString())))
                                if (_cHoaDon.CheckSoPhatHanhByNamKyDot("TG", CNguoiDung.MaTo, decimal.Parse(txtTuSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()))
                                    && _cHoaDon.CheckSoPhatHanhByNamKyDot("TG", CNguoiDung.MaTo, decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                                {
                                    if (_cHoaDon.ThemChia("TG", CNguoiDung.MaTo, int.Parse(cmbCucChia.SelectedItem.ToString()), decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()),
                                        int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                    {
                                        btnXem.PerformClick();
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
                                if (!_cHoaDon.CheckGiaoBySoPhatHanhsNam(decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString())))
                                    if (_cHoaDon.CheckSoPhatHanhByNamKyDot("CQ", CNguoiDung.MaTo, decimal.Parse(txtTuSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()))
                                        && _cHoaDon.CheckSoPhatHanhByNamKyDot("CQ", CNguoiDung.MaTo, decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                                    {
                                        if (_cHoaDon.ThemChia("CQ", CNguoiDung.MaTo, int.Parse(cmbCucChia.SelectedItem.ToString()), decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()),
                                            int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                                        {
                                            btnXem.PerformClick();
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
                            //if (!_cHoaDon.CheckDangNganBySoPhatHanhsNam(decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                            //{
                                if (_cHoaDon.XoaChia("TG", CNguoiDung.MaTo, decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()),
                                                    int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                                {
                                    btnXem.PerformClick();
                                    Clear();
                                }
                            //}
                            //else
                            //    MessageBox.Show("Hóa Đơn đã được Đăng Ngân, Không được Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (tabControl.SelectedTab.Name == "tabCoQuan")
                        {
                            //if (!_cHoaDon.CheckDangNganBySoPhatHanhsNam(decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbNhanVien.SelectedValue.ToString())))
                            //{
                                if (_cHoaDon.XoaChia("CQ", CNguoiDung.MaTo, decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()),
                                                    int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                                {
                                    btnXem.PerformClick();
                                    Clear();
                                }
                            //}
                            //else
                            //    MessageBox.Show("Hóa Đơn đã được Đăng Ngân, Không được Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtDenSoPhatHanh_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtDenSoPhatHanh.Text))
                txtSoHD.Text = _cHoaDon.CountBySoPhatHanhs(decimal.Parse(txtTuSoPhatHanh.Text.Trim()), decimal.Parse(txtDenSoPhatHanh.Text.Trim()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())).ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = ds.Tables["ChiaHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "TƯ GIA";
                    dr["To"] = CNguoiDung.TenTo;
                    dr["Dot"] = cmbDot.SelectedItem.ToString();
                    dr["Ky"] = cmbKy.SelectedItem.ToString();
                    dr["Nam"] = cmbNam.SelectedValue.ToString();
                    dr["NhanVien"] = item.Cells["HoTen_TG"].Value;
                    dr["MLT"] = item.Cells["TuMLT_TG"].Value.ToString() + " - " + item.Cells["DenMLT_TG"].Value.ToString();
                    dr["SoPhatHanh"] = item.Cells["TuSoPhatHanh_TG"].Value.ToString() + " - " + item.Cells["DenSoPhatHanh_TG"].Value.ToString();
                    dr["TongHD"] = item.Cells["TongHD_TG"].Value;
                    dr["TongGiaBan"] = item.Cells["TongGiaBan_TG"].Value;
                    dr["TongThueGTGT"] = item.Cells["TongThueGTGT_TG"].Value;
                    dr["TongPhiBVMT"] = item.Cells["TongPhiBVMT_TG"].Value;
                    dr["TongCong"] = item.Cells["TongCong_TG"].Value;
                    ds.Tables["ChiaHoaDon"].Rows.Add(dr);
                } 
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        DataRow dr = ds.Tables["ChiaHoaDon"].NewRow();
                        dr["LoaiBaoCao"] = "CƠ QUAN";
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Dot"] = cmbDot.SelectedItem.ToString();
                        dr["Ky"] = cmbKy.SelectedItem.ToString();
                        dr["Nam"] = cmbNam.SelectedValue.ToString();
                        dr["NhanVien"] = item.Cells["HoTen_CQ"].Value;
                        dr["MLT"] = item.Cells["TuMLT_CQ"].Value.ToString() + " - " + item.Cells["DenMLT_CQ"].Value.ToString();
                        dr["SoPhatHanh"] = item.Cells["TuSoPhatHanh_CQ"].Value.ToString() + " - " + item.Cells["DenSoPhatHanh_CQ"].Value.ToString();
                        dr["TongHD"] = item.Cells["TongHD_CQ"].Value;
                        dr["TongGiaBan"] = item.Cells["TongGiaBan_CQ"].Value;
                        dr["TongThueGTGT"] = item.Cells["TongThueGTGT_CQ"].Value;
                        dr["TongPhiBVMT"] = item.Cells["TongPhiBVMT_CQ"].Value;
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value;
                        ds.Tables["ChiaHoaDon"].Rows.Add(dr);
                    }
                }
            rptDSChiaHoaDon rpt = new rptDSChiaHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

    }
}
