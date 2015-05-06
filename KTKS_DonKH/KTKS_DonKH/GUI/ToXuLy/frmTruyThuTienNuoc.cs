using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmTruyThuTienNuoc : Form
    {
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        TTKhachHang _ttkhachhang = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CTTKH _cTTKH = new CTTKH();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        private DateTimePicker cellDateTimePicker;

        public frmTruyThuTienNuoc()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();

        }
        private void frmTruyThuTienNuoc_Load(object sender, EventArgs e)
        {
            dgvTruyThuTienNuoc.AutoGenerateColumns = false;
            dgvThanhToanTruyThuTienNuoc.AutoGenerateColumns = false;

            this.cellDateTimePicker = new DateTimePicker();
            this.cellDateTimePicker.ValueChanged += new EventHandler(cellDateTimePickerValueChanged);
            this.cellDateTimePicker.Visible = false;
            this.cellDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.cellDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dgvThanhToanTruyThuTienNuoc.Controls.Add(cellDateTimePicker);
        }

        void cellDateTimePickerValueChanged(object sender, EventArgs e)
        {
            dgvThanhToanTruyThuTienNuoc.CurrentCell.Value = cellDateTimePicker.Value.ToString("dd/MM/yyyy");
            cellDateTimePicker.Visible = false;
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtLoTrinh.Text = ttkhachhang.Dot + ttkhachhang.CuonGCS + ttkhachhang.CuonSTT;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
            txtGiaBieu.Text = ttkhachhang.GB;
            txtDinhMuc.Text = ttkhachhang.TGDM;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtLoTrinh.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            ///
            txtDienThoai.Text = "";
            txtNoiDung.Text = "";
            ///
            _donkh = null;
            _dontxl = null;
            _ttkhachhang = null;
            ///
            dgvTruyThuTienNuoc.DataSource = null;
            dgvThanhToanTruyThuTienNuoc.DataSource = null;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        if (_cTTKH.getTTKHbyID(_dontxl.DanhBo) != null)
                        {
                            _ttkhachhang = _cTTKH.getTTKHbyID(_dontxl.DanhBo);
                            LoadTTKH(_ttkhachhang);
                        }
                        else
                        {
                            _ttkhachhang = null;
                            Clear();
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //MessageBox.Show("Mã Đơn TXL này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //txtDanhBo.Focus();
                    }
                    else
                    {
                        _dontxl = null;
                        Clear();
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ///Đơn Tổ Khách Hàng
                else
                    if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                    {
                        _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                        txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                        if (_cTTKH.getTTKHbyID(_donkh.DanhBo) != null)
                        {
                            _ttkhachhang = _cTTKH.getTTKHbyID(_donkh.DanhBo);
                            LoadTTKH(_ttkhachhang);
                        }
                        else
                        {
                            _ttkhachhang = null;
                            Clear();
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //MessageBox.Show("Mã Đơn KH này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //txtDanhBo.Focus();
                    }
                    else
                    {
                        _donkh = null;
                        Clear();
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void dgvThanhToanTruyThuTienNuoc_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvThanhToanTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "NgayDong")
            {
                Rectangle tempRect = this.dgvThanhToanTruyThuTienNuoc.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                cellDateTimePicker.Location = tempRect.Location;
                cellDateTimePicker.Width = tempRect.Width;
                try
                {
                    cellDateTimePicker.Value = DateTime.Parse(dgvThanhToanTruyThuTienNuoc.CurrentCell.Value.ToString());
                }
                catch
                {
                    cellDateTimePicker.Value = DateTime.Now;
                }
                cellDateTimePicker.Visible = true;
            }
        }

        private void dgvThanhToanTruyThuTienNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvThanhToanTruyThuTienNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTruyThuTienNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTruyThuTienNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvThanhToanTruyThuTienNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvThanhToanTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTruyThuTienNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TongCong_Cu" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "GiaBan_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "ThueGTGT_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "PhiBVMT_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TongCong_Moi" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTruyThuTienNuoc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TieuThu_Cu")
            {
                string ChiTietCu = "";
                int TongTienCu = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()), out ChiTietCu);
                dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100);
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TieuThu_Moi")
            {
                string ChiTietMoi = "";
                int TongTienMoi = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()), out ChiTietMoi);
                dgvTruyThuTienNuoc["GiaBan_Moi", e.RowIndex].Value = TongTienMoi;
                dgvTruyThuTienNuoc["ThueGTGT_Moi", e.RowIndex].Value = Math.Round((double)TongTienMoi * 5 / 100);
                dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = TongTienMoi * 10 / 100;
                dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100);
                if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                    dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                else
                    dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }


    }
}
