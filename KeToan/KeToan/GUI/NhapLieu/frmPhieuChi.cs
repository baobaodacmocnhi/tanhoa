using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeToan.DAL.CapNhat;
using KeToan.DAL.NhapLieu;
using KeToan.LinQ;
using System.Globalization;
using KeToan.DAL.QuanTri;

namespace KeToan.GUI.NhapLieu
{
    public partial class frmPhieuChi : Form
    {
        string _mnu = "mnuPhieuChi";
        CNganHang _cNganHang = new CNganHang();
        CDoiTuong _cDoiTuong = new CDoiTuong();
        CPhieuChi _cPhieuChi = new CPhieuChi();
        PhieuChi _phieuchi = null;

        public frmPhieuChi()
        {
            InitializeComponent();
        }

        private void frmPhieuChi_Load(object sender, EventArgs e)
        {
            dgvPhieuChi.AutoGenerateColumns = false;

            cmbNganHang.DataSource = _cNganHang.GetDS();
            cmbNganHang.DisplayMember = "Name";
            cmbNganHang.ValueMember = "ID";
        }

        public void Clear()
        {
            txtSoTien.Text = "";
            _phieuchi = null;

            btnXem.PerformClick();
        }

        public void LoadEntity(PhieuChi entity)
        {
            cmbNganHang.SelectedValue = entity.ID_NganHang;
            if (entity.SoTK_No != null)
                txtSoTK_No.Text = entity.SoTK_No.Value.ToString();
            if (entity.SoTK_Co != null)
                txtSoTK_Co.Text = entity.SoTK_Co.Value.ToString();
            dateNgayLap.Value = entity.NgayLap.Value;
            txtSoCT.Text = entity.SoCT;
            if (entity.SoTien != null)
                txtSoTien.Text = entity.SoTien.Value.ToString();
            txtKhoanMuc.Text = entity.KhoanMuc;
            if (entity.DoiTuong != null)
                txtMaDT.Text = entity.DoiTuong.Value.ToString();
            txtHoTenDT.Text = entity.HoTen;
            txtDiaChiDT.Text = entity.DiaChi;
            txtNoiDungDT.Text = entity.NoiDung;
        }

        private void txtMaDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaDT.Text.Trim() != "" && e.KeyChar == 13)
            {
                DoiTuong doituong = _cDoiTuong.Get(int.Parse(txtMaDT.Text.Trim()));
                txtMaDT.Text = doituong.ID.ToString();
                txtHoTenDT.Text = doituong.Name;
                txtDiaChiDT.Text = doituong.DiaChi;
                txtNoiDungDT.Text = doituong.NoiDung;
            }
        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            //Remove previous formatting, or the decimal check will fail including leading zeros
            string value = txtSoTien.Text.Replace(",", "").Replace("$", "").Replace(".", "").TrimStart('0');
            decimal ul;
            //Check we are indeed handling a number
            if (decimal.TryParse(value, out ul))
            {
                //Unsub the event so we don't enter a loop
                txtSoTien.TextChanged -= txtSoTien_TextChanged;
                //Format the text as currency
                txtSoTien.Text = string.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ul);
                txtSoTien.TextChanged += txtSoTien_TextChanged;
                txtSoTien.Select(txtSoTien.Text.Length, 0);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Them"))
                {
                    if (txtSoTien.Text.Trim() == "")
                    {
                        MessageBox.Show("Chưa nhập Số Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    PhieuChi phieuchi = new PhieuChi();
                    phieuchi.ID_NganHang = ((NganHang)cmbNganHang.SelectedItem).ID;
                    phieuchi.KyHieu = "PC" + ((NganHang)cmbNganHang.SelectedItem).KyHieu;
                    if (txtSoTK_No.Text.Trim() != "")
                        phieuchi.SoTK_No = int.Parse(txtSoTK_No.Text.Trim());
                    if (txtSoTK_Co.Text.Trim() != "")
                        phieuchi.SoTK_Co = int.Parse(txtSoTK_Co.Text.Trim());
                    phieuchi.NgayLap = dateNgayLap.Value.Date;
                    if (txtSoTien.Text.Trim() != "")
                        phieuchi.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                    phieuchi.KhoanMuc = txtKhoanMuc.Text.Trim();
                    if (txtMaDT.Text.Trim() != "")
                        phieuchi.DoiTuong = int.Parse(txtMaDT.Text.Trim());
                    phieuchi.HoTen = txtHoTenDT.Text.Trim();
                    phieuchi.DiaChi = txtDiaChiDT.Text.Trim();
                    phieuchi.NoiDung = txtNoiDungDT.Text.Trim();

                    if (_cPhieuChi.Them(phieuchi))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Sua"))
                {
                    if (_phieuchi != null)
                    {
                        if (txtSoTien.Text.Trim() == "")
                        {
                            MessageBox.Show("Chưa nhập Số Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _phieuchi.ID_NganHang = ((NganHang)cmbNganHang.SelectedItem).ID;
                        _phieuchi.KyHieu = "PT" + ((NganHang)cmbNganHang.SelectedItem).KyHieu;
                        if (txtSoTK_No.Text.Trim() != "")
                            _phieuchi.SoTK_No = int.Parse(txtSoTK_No.Text.Trim());
                        if (txtSoTK_Co.Text.Trim() != "")
                            _phieuchi.SoTK_Co = int.Parse(txtSoTK_Co.Text.Trim());
                        _phieuchi.NgayLap = dateNgayLap.Value.Date;
                        if (txtSoTien.Text.Trim() != "")
                            _phieuchi.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                        _phieuchi.KhoanMuc = txtKhoanMuc.Text.Trim();
                        if (txtMaDT.Text.Trim() != "")
                            _phieuchi.DoiTuong = int.Parse(txtMaDT.Text.Trim());
                        _phieuchi.HoTen = txtHoTenDT.Text.Trim();
                        _phieuchi.DiaChi = txtDiaChiDT.Text.Trim();
                        _phieuchi.NoiDung = txtNoiDungDT.Text.Trim();

                        if (_cPhieuChi.Sua(_phieuchi))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Đối Tượng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_phieuchi != null)
                        {
                            if (_cPhieuChi.Xoa(_phieuchi))
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
                        }
                        else
                            MessageBox.Show("Lỗi, Vui lòng chọn Đối Tượng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvPhieuChi.DataSource = _cPhieuChi.GetDS(dateFrom.Value, dateTo.Value);
        }

        private void dgvPhieuChi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _phieuchi = _cPhieuChi.Get(int.Parse(dgvPhieuChi.CurrentRow.Cells["ID"].Value.ToString()));
                LoadEntity(_phieuchi);
            }
            catch (Exception)
            {
            }
        }

        private void dgvPhieuChi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhieuChi.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvPhieuChi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvPhieuChi.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void cmbNganHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSoTK_No.Text = ((NganHang)cmbNganHang.SelectedItem).SoTK_No.Value.ToString();
                txtSoTK_Co.Text = ((NganHang)cmbNganHang.SelectedItem).SoTK_Co.Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
