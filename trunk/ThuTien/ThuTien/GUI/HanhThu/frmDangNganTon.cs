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
using ThuTien.DAL.Quay;
using ThuTien.DAL.TongHop;
using System.Globalization;

namespace ThuTien.GUI.HanhThu
{
    public partial class frmDangNganTon : Form
    {
        string _mnu = "mnuDangNganTon";
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();
        CDCHD _cDCHD = new CDCHD();

        public frmDangNganTon()
        {
            InitializeComponent();
        }

        private void frmDangNganTon_Load(object sender, EventArgs e)
        {
            dgvHDChuaThu.AutoGenerateColumns = false;
            dgvHDDaThu.AutoGenerateColumns = false;
        }

        public void LoadDanhSachHD()
        {
            dgvHDChuaThu.DataSource = _cHoaDon.GetDSTonGiaoTonByMaNVDates(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
            dgvHDDaThu.DataSource = _cHoaDon.GetDSDangNganGiaoTonByMaNVDates(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
            int TongCong = 0;
            if (dgvHDDaThu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDDaThu.Rows)
                {
                    TongCong += int.Parse(item.Cells["TongCong_DT"].Value.ToString());
                }
                txtTongCong_DT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
            TongCong = 0;
            if (dgvHDChuaThu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDChuaThu.Rows)
                {
                    TongCong += int.Parse(item.Cells["TongCong_CT"].Value.ToString());
                }
                txtTongCong_CT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
                if (!lstHD.Items.Contains(txtSoHoaDon.Text.Trim()))
                {
                    lstHD.Items.Add(txtSoHoaDon.Text.Trim());
                    txtSoHoaDon.Text = "";
                }
                else
                    txtSoHoaDon.Text = "";
        }

        private void lstHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHD.Items.Count > 0)
                lstHD.Items.RemoveAt(lstHD.SelectedIndex);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                dgvHDChuaThu.DataSource = _cHoaDon.GetDSTonGiaoTonByMaNVDates(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
                dgvHDDaThu.DataSource = _cHoaDon.GetDSDangNganGiaoTonByMaNVDates(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
                LoadDanhSachHD();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (lstHD.Items.Count > 0)
                {
                    string loai;
                    foreach (var item in lstHD.Items)
                    {
                        if (!_cHoaDon.CheckGiaoTonBySoHoaDonMaNV(item.ToString(),CNguoiDung.MaND))
                        {
                            MessageBox.Show("Hóa Đơn không được giao cho bạn: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lstHD.SelectedItem = item;
                            return;
                        }
                        if (_cHoaDon.CheckDangNganBySoHoaDon(item.ToString()))
                        {
                            MessageBox.Show("Hóa Đơn đã Đăng Ngân: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lstHD.SelectedItem = item;
                            return;
                        }
                        if (_cTamThu.CheckBySoHoaDon(item.ToString(), out loai))
                        {
                            MessageBox.Show("Hóa Đơn đã được Tạm Thu(" + loai + "): " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lstHD.SelectedItem = item;
                            return;
                        }
                        if (_cDCHD.CheckBySoHoaDon(item.ToString()))
                        {
                            MessageBox.Show("Hóa Đơn đã rút đi Điều Chỉnh: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lstHD.SelectedItem = item;
                            return;
                        }
                    }
                    try
                    {
                        _cHoaDon.SqlBeginTransaction();
                        foreach (var item in lstHD.Items)
                            if (!_cHoaDon.DangNganTon(item.ToString(), CNguoiDung.MaND))
                            {
                                _cHoaDon.SqlRollbackTransaction();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        _cHoaDon.SqlCommitTransaction();
                        LoadDanhSachHD();
                        lstHD.Items.Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        _cHoaDon.SqlRollbackTransaction();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        _cHoaDon.SqlBeginTransaction();
                        foreach (DataGridViewRow item in dgvHDDaThu.SelectedRows)
                        {
                            if (!_cHoaDon.XoaDangNganTon(item.Cells["SoHoaDon_DT"].Value.ToString(), CNguoiDung.MaND))
                            {
                                _cHoaDon.SqlRollbackTransaction();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        _cHoaDon.SqlCommitTransaction();
                        LoadDanhSachHD();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        _cHoaDon.SqlRollbackTransaction();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHDDaThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "DanhBo_DT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "TieuThu_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "GiaBan_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "ThueGTGT_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "PhiBVMT_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "TongCong_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDChuaThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "DanhBo_CT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "TieuThu_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "GiaBan_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "ThueGTGT_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "PhiBVMT_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "TongCong_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDDaThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDDaThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDChuaThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDChuaThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
