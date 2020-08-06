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
using KeToan.DAL.QuanTri;
using System.Globalization;

namespace KeToan.GUI.NhapLieu
{
    public partial class frmPhieuThu : Form
    {
        string _mnu = "mnuPhieuThu";
        CNganHang _cNganHang = new CNganHang();
        CDoiTuong _cDoiTuong = new CDoiTuong();
        CPhieuThu _cPhieuThu = new CPhieuThu();
        PhieuThu _phieuthu = null;

        public frmPhieuThu()
        {
            InitializeComponent();
        }

        private void frmPhieuThu_Load(object sender, EventArgs e)
        {
            dgvPhieuThu.AutoGenerateColumns = false;

            cmbNganHang.DataSource = _cNganHang.GetDS();
            cmbNganHang.DisplayMember = "Name";
            cmbNganHang.ValueMember = "ID";
        }

        public void Clear()
        {
            txtSoTien.Text = "";
            _phieuthu = null;

            btnXem.PerformClick();
        }

        public void LoadEntity(PhieuThu entity)
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
                    PhieuThu phieuthu = new PhieuThu();
                    phieuthu.ID_NganHang = ((NganHang)cmbNganHang.SelectedItem).ID;
                    phieuthu.KyHieu = "PT" + ((NganHang)cmbNganHang.SelectedItem).KyHieu;
                    if (txtSoTK_No.Text.Trim() != "")
                        phieuthu.SoTK_No = int.Parse(txtSoTK_No.Text.Trim());
                    if (txtSoTK_Co.Text.Trim() != "")
                        phieuthu.SoTK_Co = int.Parse(txtSoTK_Co.Text.Trim());
                    phieuthu.NgayLap = dateNgayLap.Value.Date;
                    if (txtSoTien.Text.Trim() != "")
                        phieuthu.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                    phieuthu.KhoanMuc = txtKhoanMuc.Text.Trim();
                    if (txtMaDT.Text.Trim() != "")
                        phieuthu.DoiTuong = int.Parse(txtMaDT.Text.Trim());
                    phieuthu.HoTen = txtHoTenDT.Text.Trim();
                    phieuthu.DiaChi = txtDiaChiDT.Text.Trim();
                    phieuthu.NoiDung = txtNoiDungDT.Text.Trim();

                    if (_cPhieuThu.Them(phieuthu))
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
                    if (_phieuthu != null)
                    {
                        if (txtSoTien.Text.Trim() == "")
                        {
                            MessageBox.Show("Chưa nhập Số Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _phieuthu.ID_NganHang = ((NganHang)cmbNganHang.SelectedItem).ID;
                        _phieuthu.KyHieu = "PT" + ((NganHang)cmbNganHang.SelectedItem).KyHieu;
                        if (txtSoTK_No.Text.Trim() != "")
                            _phieuthu.SoTK_No = int.Parse(txtSoTK_No.Text.Trim());
                        if (txtSoTK_Co.Text.Trim() != "")
                            _phieuthu.SoTK_Co = int.Parse(txtSoTK_Co.Text.Trim());
                        _phieuthu.NgayLap = dateNgayLap.Value.Date;
                        if (txtSoTien.Text.Trim() != "")
                            _phieuthu.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                        _phieuthu.KhoanMuc = txtKhoanMuc.Text.Trim();
                        if (txtMaDT.Text.Trim() != "")
                            _phieuthu.DoiTuong = int.Parse(txtMaDT.Text.Trim());
                        _phieuthu.HoTen = txtHoTenDT.Text.Trim();
                        _phieuthu.DiaChi = txtDiaChiDT.Text.Trim();
                        _phieuthu.NoiDung = txtNoiDungDT.Text.Trim();

                        if (_cPhieuThu.Sua(_phieuthu))
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
                        if (_phieuthu != null)
                        {
                            if (_cPhieuThu.Xoa(_phieuthu))
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
            dgvPhieuThu.DataSource = _cPhieuThu.GetDS(dateFrom.Value, dateTo.Value);
        }

        private void dgvPhieuThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _phieuthu = _cPhieuThu.Get(int.Parse(dgvPhieuThu.CurrentRow.Cells["ID"].Value.ToString()));
                LoadEntity(_phieuthu);
            }
            catch (Exception)
            {
            }
        }

        private void dgvPhieuThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhieuThu.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvPhieuThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvPhieuThu.RowHeadersDefaultCellStyle.ForeColor))
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
