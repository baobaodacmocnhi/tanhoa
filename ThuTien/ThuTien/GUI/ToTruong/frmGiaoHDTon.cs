using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using System.Globalization;
using ThuTien.LinQ;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmGiaoHDTon : Form
    {
        string _mnu = "mnuGiaoHDTon";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CHoaDon _cHoaDon = new CHoaDon();
        CTo _cTo = new CTo();
        List<TT_NguoiDung> _lstND;
        bool _flagLoadFirst = false;

        public frmGiaoHDTon()
        {
            InitializeComponent();
        }

        private void frmGiaoHDTon_Load(object sender, EventArgs e)
        {
            dgvHDTon.AutoGenerateColumns = false;

            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                cmbTo.DataSource = _cTo.getDS_HanhThu();
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";

                cmbTo.SelectedIndex = -1;
            }
            else
            {
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;

                _lstND = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = -1;
                nguoidung.HoTen = "Tất cả";
                _lstND.Insert(0, nguoidung);

                cmbNhanVien.DataSource = _lstND;
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;

            _flagLoadFirst = true;
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()))
                    {
                        if (lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                        {
                            lstHD.Items.Add(item.Trim().ToUpper());
                            lstHD.EnsureVisible(lstHD.Items.Count - 1);
                        }
                    }
                    //else
                    //    ///Trung An thêm 'K' phía cuối liên hóa đơn
                    //    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 14)
                    //    {
                    //        if (lstHD.FindItemWithText(item.Trim().ToUpper().Replace("K", "")) == null)
                    //        {
                    //            lstHD.Items.Add(item.Trim().ToUpper().Replace("K", ""));
                    //            lstHD.EnsureVisible(lstHD.Items.Count - 1);
                    //        }
                        //}
                txtSoLuong.Text = lstHD.Items.Count.ToString();
                txtSoHoaDon.Text = "";
            }
        }

        private void lstHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHD.Items.Count > 0 && e.Button == MouseButtons.Left)
            {
                foreach (ListViewItem item in lstHD.SelectedItems)
                {
                    lstHD.Items.Remove(item);
                }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
            }
        }

        private void lstHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Text = lstHD.Items.Count.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi == false)
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    foreach (ListViewItem item in lstHD.Items)
                    {
                        if (_cHoaDon.CheckDangNganBySoHoaDon(item.Text))
                        {
                            MessageBox.Show("Hóa Đơn đã Đăng Ngân: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            item.Selected = true;
                            item.Focused = true;
                            return;
                        }
                    }
                    try
                    {
                        _cHoaDon.SqlBeginTransaction();

                        foreach (ListViewItem item in lstHD.Items)
                            if (!_cHoaDon.GiaoTon(item.Text, int.Parse(cmbNhanVien.SelectedValue.ToString())))
                            {
                                _cHoaDon.SqlRollbackTransaction();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        _cHoaDon.SqlCommitTransaction();
                        lstHD.Items.Clear();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        _cHoaDon.SqlRollbackTransaction();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi == false)
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    try
                    {
                        _cHoaDon.SqlBeginTransaction();

                        foreach (DataGridViewRow item in dgvHDTon.SelectedRows)
                            if (!_cHoaDon.CheckDangNganBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString()))
                                if (!_cHoaDon.XoaGiaoTon(item.Cells["SoHoaDon"].Value.ToString()))
                                {
                                    _cHoaDon.SqlRollbackTransaction();
                                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                        _cHoaDon.SqlCommitTransaction();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        _cHoaDon.SqlRollbackTransaction();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbNhanVien.SelectedIndex == 0)
            {
                DataTable dt = new DataTable();
                for (int i = 1; i < _lstND.Count; i++)
                    dt.Merge(_cHoaDon.GetDSGiaoTonByNVDates(_lstND[i].MaND, dateTu.Value, dateDen.Value));
                dgvHDTon.DataSource = dt;
            }
            else
                if (cmbNhanVien.SelectedIndex > 0)
                {
                    dgvHDTon.DataSource = _cHoaDon.GetDSGiaoTonByNVDates(int.Parse(cmbNhanVien.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
                }
        }

        private void dgvHDTon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTon.Columns[e.ColumnIndex].Name == "MLT_CQ" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvHDTon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDTon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDTon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDTon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstHD.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi && _flagLoadFirst == true && cmbTo.SelectedIndex != -1)
            {
                _lstND = _cNguoiDung.GetDSHanhThuByMaTo((int)cmbTo.SelectedValue);
                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = -1;
                nguoidung.HoTen = "Tất cả";
                _lstND.Insert(0, nguoidung);

                cmbNhanVien.DataSource = _lstND;
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            else
                cmbNhanVien.DataSource = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

    }
}
