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
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.HeThong;

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
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();
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
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "GiaBieu_Cu")
            {
                dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value;

                int DinhMuc = 0;
                int TieuThu = 0;
                if (dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString());

                string ChiTietCu = "";
                int TongTienCu = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()), DinhMuc, TieuThu, out ChiTietCu);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()), DinhMuc, TieuThu);
                
                dgvTruyThuTienNuoc["GiaBan_Cu", e.RowIndex].Value = TongTienCu;
                dgvTruyThuTienNuoc["ThueGTGT_Cu", e.RowIndex].Value = Math.Round((double)TongTienCu * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = TongTienCu * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + PhiBVMT;
                }
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "DinhMuc_Cu")
            {
                dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value;

                int GiaBieu = 0;
                int TieuThu = 0;
                if (dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString());

                string ChiTietCu = "";
                int TongTienCu = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()), TieuThu, out ChiTietCu);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()), TieuThu);

                dgvTruyThuTienNuoc["GiaBan_Cu", e.RowIndex].Value = TongTienCu;
                dgvTruyThuTienNuoc["ThueGTGT_Cu", e.RowIndex].Value = Math.Round((double)TongTienCu * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = TongTienCu * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + PhiBVMT;
                }
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TieuThu_Cu")
            {
                dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value = dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value;

                int GiaBieu = 0;
                int DinhMuc = 0;
                if (dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString());

                string ChiTietCu = "";
                int TongTienCu = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()), out ChiTietCu);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString()));
                
                dgvTruyThuTienNuoc["GiaBan_Cu", e.RowIndex].Value = TongTienCu;
                dgvTruyThuTienNuoc["ThueGTGT_Cu", e.RowIndex].Value = Math.Round((double)TongTienCu * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = TongTienCu * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Cu", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value = TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + PhiBVMT;
                }
            }
            ////////////////////////////////////////////
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TieuThu_Moi")
            {
                int GiaBieu = 0;
                int DinhMuc = 0;
                if (dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString());

                string ChiTietMoi = "";
                int TongTienMoi = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()), out ChiTietMoi);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, DinhMuc, int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()));
                
                dgvTruyThuTienNuoc["GiaBan_Moi", e.RowIndex].Value = TongTienMoi;
                dgvTruyThuTienNuoc["ThueGTGT_Moi", e.RowIndex].Value = Math.Round((double)TongTienMoi * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = TongTienMoi * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + PhiBVMT;
                }
                if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                    dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                else
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
            }

            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "GiaBieu_Moi")
            {
                int DinhMuc = 0;
                int TieuThu = 0;
                if (dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString());

                string ChiTietMoi = "";
                int TongTienMoi = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()), DinhMuc, TieuThu, out ChiTietMoi);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()), DinhMuc, TieuThu);

                dgvTruyThuTienNuoc["GiaBan_Moi", e.RowIndex].Value = TongTienMoi;
                dgvTruyThuTienNuoc["ThueGTGT_Moi", e.RowIndex].Value = Math.Round((double)TongTienMoi * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = TongTienMoi * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + PhiBVMT;
                }
                if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                    dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                else
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
            }
            if (dgvTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "DinhMuc_Moi")
            {
                int GiaBieu = 0;
                int TieuThu = 0;
                if (dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString());
                if (dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString());

                string ChiTietMoi = "";
                int TongTienMoi = _cGiaNuoc.TinhTienNuoc(false, 0, txtDanhBo.Text.Trim(), int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()), TieuThu, out ChiTietMoi);
                int PhiBVMT = _cGiaNuoc.TinhPhiBMVT(int.Parse(dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString()), GiaBieu, int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString()), TieuThu);

                dgvTruyThuTienNuoc["GiaBan_Moi", e.RowIndex].Value = TongTienMoi;
                dgvTruyThuTienNuoc["ThueGTGT_Moi", e.RowIndex].Value = Math.Round((double)TongTienMoi * 5 / 100);
                if (PhiBVMT == 0)
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = TongTienMoi * 10 / 100;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100);
                }
                else
                {
                    dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value = PhiBVMT;
                    dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value = TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + PhiBVMT;
                }
                if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) < int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                    dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Tăng";
                else
                    if (int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString()) > int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString()))
                        dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value = "Giảm";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                ///Nếu đơn thuộc Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_dontxl != null && txtDanhBo.Text.Trim() != "")
                    {
                        if (!_cTTTN.CheckTruyThuTienNuocbyMaDon_TXL(_dontxl.MaDon))
                        {
                            TruyThuTienNuoc tttn = new TruyThuTienNuoc();
                            tttn.ToXuLy = true;
                            tttn.MaDonTXL = _dontxl.MaDon;

                            tttn.DanhBo = txtDanhBo.Text.Trim();
                            tttn.HopDong = txtHopDong.Text.Trim();
                            tttn.LoTrinh = txtLoTrinh.Text.Trim();
                            tttn.HoTen = txtHoTen.Text.Trim();
                            tttn.DiaChi = txtDiaChi.Text.Trim();
                            if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                            tttn.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                            if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                            tttn.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                            tttn.NoiDung = txtNoiDung.Text.Trim();
                            tttn.DienThoai = txtDienThoai.Text.Trim();

                            if (_ttkhachhang != null)
                            {
                                tttn.Dot = _ttkhachhang.Dot;
                                tttn.Ky = _ttkhachhang.Ky;
                                tttn.Nam = _ttkhachhang.Nam;
                            }

                            if (_cTTTN.ThemTruyThuTienNuoc(tttn))
                            {
                                if (string.IsNullOrEmpty(_dontxl.TienTrinh))
                                    _dontxl.TienTrinh = "TTTN";
                                else
                                    _dontxl.TienTrinh += ",TTTN";
                                _dontxl.Nhan = true;
                                _cDonTXL.SuaDonTXL(_dontxl, true);
                            }
                        }

                        foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                            if (item.Cells["Ky"].Value != null)
                            {
                                if (_cTTTN.CheckCTTruyThuTienNuocbyKyNamMaTTTN(_cTTTN.getTruyThuTienNuocbyMaDon_TXL(_dontxl.MaDon).MaTTTN, item.Cells["Ky"].Value.ToString(), item.Cells["Nam"].Value.ToString()))
                                {
                                    MessageBox.Show("Kỳ " + item.Cells["Ky"].Value.ToString() + "/" + item.Cells["Nam"].Value.ToString() + " đã có \rVui lòng xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        decimal MaTTTN = _cTTTN.getTruyThuTienNuocbyMaDon_TXL(_dontxl.MaDon).MaTTTN;

                        foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                            if (item.Cells["Ky"].Value != null && !_cTTTN.CheckCTTruyThuTienNuocbyKyNamMaTTTN(MaTTTN, item.Cells["Ky"].Value.ToString(), item.Cells["Nam"].Value.ToString()))
                            {
                                CTTruyThuTienNuoc cttttn = new CTTruyThuTienNuoc();
                                cttttn.MaTTTN = MaTTTN;
                                cttttn.Ky = item.Cells["Ky"].Value.ToString();
                                cttttn.Nam = item.Cells["Nam"].Value.ToString();
                                cttttn.GiaBieuCu = int.Parse(item.Cells["GiaBieu_Cu"].Value.ToString());
                                cttttn.DinhMucCu = int.Parse(item.Cells["DinhMuc_Cu"].Value.ToString());
                                cttttn.TieuThuCu = int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                                cttttn.GiaBanCu = int.Parse(item.Cells["GiaBan_Cu"].Value.ToString());
                                cttttn.ThueGTGTCu = int.Parse(item.Cells["ThueGTGT_Cu"].Value.ToString());
                                cttttn.PhiBVMTCu = int.Parse(item.Cells["PhiBVMT_Cu"].Value.ToString());
                                cttttn.TongCongCu = int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                                ///
                                cttttn.GiaBieuMoi = int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString());
                                cttttn.DinhMucMoi = int.Parse(item.Cells["DinhMuc_Moi"].Value.ToString());
                                cttttn.TieuThuMoi = int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                                cttttn.GiaBanMoi = int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                                cttttn.ThueGTGTMoi = int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                                cttttn.PhiBVMTMoi = int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                                cttttn.TongCongMoi = int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                                cttttn.TangGiam = item.Cells["TangGiam"].Value.ToString();

                                _cTTTN.ThemCTTruyThuTienNuoc(cttttn);
                            }

                        foreach (DataGridViewRow item in dgvThanhToanTruyThuTienNuoc.Rows)
                            if (item.Cells["NgayDong"].Value != null)
                            {
                                ThanhToanTruyThuTienNuoc tttttn = new ThanhToanTruyThuTienNuoc();

                                tttttn.MaTTTN = _cTTTN.getTruyThuTienNuocbyMaDon_TXL(_dontxl.MaDon).MaTTTN;
                                string[] date = item.Cells["NgayDong"].Value.ToString().Split('/');
                                tttttn.NgayDong = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                                tttttn.SoTien = int.Parse(item.Cells["SoTien"].Value.ToString());

                                _cTTTN.ThemThanhToanTruyThuTienNuoc(tttttn);
                            }
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaDon.Focus();
                    }
                    else
                        MessageBox.Show("Chưa có Mã Đơn/Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ///Nếu đơn thuộc Tổ Khách Hàng
                else
                    if (_donkh != null && txtDanhBo.Text.Trim() != "")
                    {
                        if (!_cTTTN.CheckTruyThuTienNuocbyMaDon(_donkh.MaDon))
                        {
                            TruyThuTienNuoc tttn = new TruyThuTienNuoc();
                            tttn.MaDon = _donkh.MaDon;

                            tttn.DanhBo = txtDanhBo.Text.Trim();
                            tttn.HopDong = txtHopDong.Text.Trim();
                            tttn.LoTrinh = txtLoTrinh.Text.Trim();
                            tttn.HoTen = txtHoTen.Text.Trim();
                            tttn.DiaChi = txtDiaChi.Text.Trim();
                            if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                                tttn.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                            if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                                tttn.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                            tttn.NoiDung = txtNoiDung.Text.Trim();
                            tttn.DienThoai = txtDienThoai.Text.Trim();

                            if (_ttkhachhang != null)
                            {
                                tttn.Dot = _ttkhachhang.Dot;
                                tttn.Ky = _ttkhachhang.Ky;
                                tttn.Nam = _ttkhachhang.Nam;
                            }

                            if (_cTTTN.ThemTruyThuTienNuoc(tttn))
                            {
                                if (string.IsNullOrEmpty(_donkh.TienTrinh))
                                    _donkh.TienTrinh = "TTTN";
                                else
                                    _donkh.TienTrinh += ",TTTN";
                                _donkh.Nhan = true;
                                _cDonKH.SuaDonKH(_donkh, true);
                            }
                        }
                        decimal MaTTTN = _cTTTN.getTruyThuTienNuocbyMaDon(_donkh.MaDon).MaTTTN;

                        foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                            if (item.Cells["Ky"].Value != null && !_cTTTN.CheckCTTruyThuTienNuocbyKyNamMaTTTN(MaTTTN, item.Cells["Ky"].Value.ToString(), item.Cells["Nam"].Value.ToString()))
                            {
                                CTTruyThuTienNuoc cttttn = new CTTruyThuTienNuoc();
                                cttttn.MaTTTN = MaTTTN;
                                cttttn.Ky = item.Cells["Ky"].Value.ToString();
                                cttttn.Nam = item.Cells["Nam"].Value.ToString();
                                cttttn.GiaBieuCu = int.Parse(item.Cells["GiaBieu_Cu"].Value.ToString());
                                cttttn.DinhMucCu = int.Parse(item.Cells["DinhMuc_Cu"].Value.ToString());
                                cttttn.TieuThuCu = int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                                cttttn.GiaBanCu = int.Parse(item.Cells["GiaBan_Cu"].Value.ToString());
                                cttttn.ThueGTGTCu = int.Parse(item.Cells["ThueGTGT_Cu"].Value.ToString());
                                cttttn.PhiBVMTCu = int.Parse(item.Cells["PhiBVMT_Cu"].Value.ToString());
                                cttttn.TongCongCu = int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                                ///
                                cttttn.GiaBieuMoi = int.Parse(item.Cells["GiaBieu_Moi"].Value.ToString());
                                cttttn.DinhMucMoi = int.Parse(item.Cells["DinhMuc_Moi"].Value.ToString());
                                cttttn.TieuThuMoi = int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                                cttttn.GiaBanMoi = int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                                cttttn.ThueGTGTMoi = int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                                cttttn.PhiBVMTMoi = int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                                cttttn.TongCongMoi = int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                                cttttn.TangGiam = item.Cells["TangGiam"].Value.ToString();

                                _cTTTN.ThemCTTruyThuTienNuoc(cttttn);
                            }

                        foreach (DataGridViewRow item in dgvThanhToanTruyThuTienNuoc.Rows)
                            if (item.Cells["NgayDong"].Value != null)
                            {
                                ThanhToanTruyThuTienNuoc tttttn = new ThanhToanTruyThuTienNuoc();

                                tttttn.MaTTTN = _cTTTN.getTruyThuTienNuocbyMaDon(_donkh.MaDon).MaTTTN;
                                string[] date = item.Cells["NgayDong"].Value.ToString().Split('/');
                                tttttn.NgayDong = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                                tttttn.SoTien = int.Parse(item.Cells["SoTien"].Value.ToString());

                                _cTTTN.ThemThanhToanTruyThuTienNuoc(tttttn);
                            }
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaDon.Focus();
                    }
                    else
                        MessageBox.Show("Chưa có Mã Đơn/Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTruyThuTienNuoc_Leave(object sender, EventArgs e)
        {
            int Tongm3HoaDon = 0;
            int Tongm3ThucTe = 0;
            int GiaBan = 0;
            int ThueGTGT = 0;
            int PhiBVMT = 0;
            int TongCongCu = 0;
            int TongCongMoi = 0;
            foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                if (item.Cells["Ky"].Value!=null)
                {
                    Tongm3HoaDon += int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                    Tongm3ThucTe += int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                    GiaBan += int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                    ThueGTGT += int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                    PhiBVMT += int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                    TongCongMoi += int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                    TongCongCu += int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                }
            txtSoKy.Text = (dgvTruyThuTienNuoc.RowCount-1).ToString();
            txtTongm3HoaDon.Text = Tongm3HoaDon.ToString();
            txtTongm3ThucTe.Text = Tongm3ThucTe.ToString();
            txtTongm3TruyThu.Text = (Tongm3ThucTe - Tongm3HoaDon).ToString();
            txtGiaBan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBan);
            txtThueGTGT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGT);
            txtPhiBVMT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", PhiBVMT);
            txtTongCongMoi.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongMoi);
            txtTongCongCu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCu);
            txtTongThanhToan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongMoi - TongCongCu);
        }

        private void dgvTruyThuTienNuoc_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvTruyThuTienNuoc.RowCount - 1)
            {
                dgvTruyThuTienNuoc["Nam", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["Nam", e.RowIndex].Value;
                dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value;
                dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value;
                dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value;
                dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex + 1].Value = dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                if (item.Cells["Ky"].Value != null)
                {
                    DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = txtHoTen.Text.Trim();
                    dr["DiaChi"] = txtDiaChi.Text.Trim();
                    dr["HopDong"] = txtHopDong.Text.Trim();
                    dr["GiaBieu"] = txtGiaBieu.Text.Trim();
                    dr["DinhMuc"] = txtDinhMuc.Text.Trim();

                    dr["Ky"] = item.Cells["Ky"].Value.ToString();
                    dr["Nam"] = item.Cells["Nam"].Value.ToString();
                    dr["GiaBieuCu"] = item.Cells["GiaBieu_Cu"].Value.ToString();
                    dr["DinhMucCu"] = item.Cells["DinhMuc_Cu"].Value.ToString();
                    dr["TieuThuCu"] = item.Cells["TieuThu_Cu"].Value.ToString();
                    dr["GiaBanCu"] = item.Cells["GiaBan_Cu"].Value.ToString();
                    dr["ThueGTGTCu"] = item.Cells["ThueGTGT_Cu"].Value.ToString();
                    dr["PhiBVMTCu"] = item.Cells["PhiBVMT_Cu"].Value.ToString();
                    dr["TongCongCu"] = item.Cells["TongCong_Cu"].Value.ToString();
                    dr["GiaBieuMoi"] = item.Cells["GiaBieu_Moi"].Value.ToString();
                    dr["DinhMucMoi"] = item.Cells["DinhMuc_Moi"].Value.ToString();
                    dr["TieuThuMoi"] = item.Cells["TieuThu_Moi"].Value.ToString();
                    dr["GiaBanMoi"] = item.Cells["GiaBan_Moi"].Value.ToString();
                    dr["ThueGTGTMoi"] = item.Cells["ThueGTGT_Moi"].Value.ToString();
                    dr["PhiBVMTMoi"] = item.Cells["PhiBVMT_Moi"].Value.ToString();
                    dr["TongCongMoi"] = item.Cells["TongCong_Moi"].Value.ToString();
                    dr["TangGiam"] = item.Cells["TangGiam"].Value.ToString();
                    dr["NhanVien"] = CTaiKhoan.HoTen;
                    dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                }

            rptTruyThuTienNuoc rpt = new rptTruyThuTienNuoc();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInChiTiet_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                if (item.Cells["Ky"].Value != null)
                {
                    DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = txtHoTen.Text.Trim();
                    dr["DiaChi"] = txtDiaChi.Text.Trim();
                    dr["HopDong"] = txtHopDong.Text.Trim();
                    dr["GiaBieu"] = txtGiaBieu.Text.Trim();
                    dr["DinhMuc"] = txtDinhMuc.Text.Trim();

                    dr["Ky"] = item.Cells["Ky"].Value.ToString();
                    dr["Nam"] = item.Cells["Nam"].Value.ToString();
                    dr["GiaBieuCu"] = item.Cells["GiaBieu_Cu"].Value.ToString();
                    if (item.Cells["DinhMuc_Cu"].Value != null)
                    dr["DinhMucCu"] = item.Cells["DinhMuc_Cu"].Value.ToString();
                    dr["TieuThuCu"] = item.Cells["TieuThu_Cu"].Value.ToString();
                    dr["GiaBanCu"] = item.Cells["GiaBan_Cu"].Value.ToString();
                    dr["ThueGTGTCu"] = item.Cells["ThueGTGT_Cu"].Value.ToString();
                    dr["PhiBVMTCu"] = item.Cells["PhiBVMT_Cu"].Value.ToString();
                    dr["TongCongCu"] = item.Cells["TongCong_Cu"].Value.ToString();
                    dr["GiaBieuMoi"] = item.Cells["GiaBieu_Moi"].Value.ToString();
                    if (item.Cells["DinhMuc_Moi"].Value != null)
                    dr["DinhMucMoi"] = item.Cells["DinhMuc_Moi"].Value.ToString();
                    dr["TieuThuMoi"] = item.Cells["TieuThu_Moi"].Value.ToString();
                    dr["GiaBanMoi"] = item.Cells["GiaBan_Moi"].Value.ToString();
                    dr["ThueGTGTMoi"] = item.Cells["ThueGTGT_Moi"].Value.ToString();
                    dr["PhiBVMTMoi"] = item.Cells["PhiBVMT_Moi"].Value.ToString();
                    dr["TongCongMoi"] = item.Cells["TongCong_Moi"].Value.ToString();
                    if (item.Cells["TangGiam"].Value!=null)
                    dr["TangGiam"] = item.Cells["TangGiam"].Value.ToString();
                    dr["NhanVien"] = CTaiKhoan.HoTen;
                    dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                }

            rptTruyThuTienNuocChiTiet rpt = new rptTruyThuTienNuocChiTiet();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Length == 11)
            {
                _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                LoadTTKH(_ttkhachhang);
            }
        }



    }
}
