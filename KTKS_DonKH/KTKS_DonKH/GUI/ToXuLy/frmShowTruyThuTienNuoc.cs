﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmShowTruyThuTienNuoc : Form
    {
        decimal _MaTTTN = 0;
        TruyThuTienNuoc _tttn = null;
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        private DateTimePicker cellDateTimePicker;

        public frmShowTruyThuTienNuoc()
        {
            InitializeComponent();
        }

        public frmShowTruyThuTienNuoc(decimal MaTTTN)
        {
            InitializeComponent();
            _MaTTTN = MaTTTN;
        }

        private void frmShowTruyThuTienNuoc_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,50);
            dgvThanhToanTruyThuTienNuoc.AutoGenerateColumns = false;
            dgvTruyThuTienNuoc.AutoGenerateColumns = false;

            this.cellDateTimePicker = new DateTimePicker();
            this.cellDateTimePicker.ValueChanged += new EventHandler(cellDateTimePickerValueChanged);
            this.cellDateTimePicker.Visible = false;
            this.cellDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.cellDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dgvThanhToanTruyThuTienNuoc.Controls.Add(cellDateTimePicker);
            try
            {

            
            if (_cTTTN.getTruyThuTienNuocbyMaTTTN(_MaTTTN) != null)
            {
                _tttn = _cTTTN.getTruyThuTienNuocbyMaTTTN(_MaTTTN);
                if (_tttn.ToXuLy)
                    txtMaDon.Text = "TXL" + _tttn.MaDonTXL.Value.ToString().Insert(_tttn.MaDonTXL.Value.ToString().Length - 2, "-");
                else
                    txtMaDon.Text = _tttn.MaDon.Value.ToString().Insert(_tttn.MaDon.Value.ToString().Length - 2, "-");

                txtDanhBo.Text = _tttn.DanhBo;
                txtHopDong.Text = _tttn.HopDong;
                txtLoTrinh.Text = _tttn.LoTrinh;
                txtGiaBieu.Text = _tttn.GiaBieu.Value.ToString();
                txtDinhMuc.Text = _tttn.DinhMuc.Value.ToString();
                txtHoTen.Text = _tttn.HoTen;
                txtDiaChi.Text = _tttn.DiaChi;
                txtDienThoai.Text = _tttn.DienThoai;
                txtNoiDung.Text = _tttn.NoiDung;

                foreach (CTTruyThuTienNuoc item in _tttn.CTTruyThuTienNuocs.ToList())
                {
                    dgvTruyThuTienNuoc.Rows.Insert(dgvTruyThuTienNuoc.RowCount-1, 1);

                    dgvTruyThuTienNuoc["Ky", dgvTruyThuTienNuoc.RowCount - 2].Value = item.Ky;
                    dgvTruyThuTienNuoc["Nam", dgvTruyThuTienNuoc.RowCount - 2].Value = item.Nam;
                    dgvTruyThuTienNuoc["GiaBieu_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.GiaBieuCu;
                    dgvTruyThuTienNuoc["DinhMuc_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.DinhMucCu;
                    dgvTruyThuTienNuoc["TieuThu_Cu", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TieuThuCu;
                    dgvTruyThuTienNuoc["GiaBieu_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.GiaBieuMoi;
                    dgvTruyThuTienNuoc["DinhMuc_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.DinhMucMoi;
                    dgvTruyThuTienNuoc["TieuThu_Moi", dgvTruyThuTienNuoc.RowCount - 2].Value = item.TieuThuMoi;
                    dgvTruyThuTienNuoc["MaCTTTTN", dgvTruyThuTienNuoc.RowCount - 2].Value = item.MaCTTTTN;
                }

                foreach (ThanhToanTruyThuTienNuoc item in _tttn.ThanhToanTruyThuTienNuocs.ToList())
                {
                    dgvThanhToanTruyThuTienNuoc.Rows.Insert(dgvThanhToanTruyThuTienNuoc.RowCount, 1);

                    dgvThanhToanTruyThuTienNuoc["NgayDong", dgvThanhToanTruyThuTienNuoc.RowCount - 2].Value = item.NgayDong.Value.ToString("dd/MM/yyyy");
                    dgvThanhToanTruyThuTienNuoc["SoTien", dgvThanhToanTruyThuTienNuoc.RowCount - 2].Value = item.SoTien;
                    dgvThanhToanTruyThuTienNuoc["DaThanhToan", dgvThanhToanTruyThuTienNuoc.RowCount - 2].Value = item.DaThanhToan;
                    dgvThanhToanTruyThuTienNuoc["MaTTTTTN", dgvThanhToanTruyThuTienNuoc.RowCount - 2].Value = item.MaTTTTTN;
                }

                int Tongm3HoaDon = 0;
                int Tongm3ThucTe = 0;
                int GiaBan = 0;
                int ThueGTGT = 0;
                int PhiBVMT = 0;
                int TongCongCu = 0;
                int TongCongMoi = 0;
                foreach (DataGridViewRow item in dgvTruyThuTienNuoc.Rows)
                    if (item.Cells["Ky"].Value != null)
                    {
                        Tongm3HoaDon += int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                        Tongm3ThucTe += int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                        GiaBan += int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                        ThueGTGT += int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                        PhiBVMT += int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                        TongCongMoi += int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                        TongCongCu += int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                    }
                txtSoKy.Text = (dgvTruyThuTienNuoc.RowCount - 1).ToString();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void cellDateTimePickerValueChanged(object sender, EventArgs e)
        {
            dgvThanhToanTruyThuTienNuoc.CurrentCell.Value = cellDateTimePicker.Value.ToString("dd/MM/yyyy");
            cellDateTimePicker.Visible = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _tttn.DanhBo = txtDanhBo.Text.Trim();
            _tttn.HopDong = txtHopDong.Text.Trim();
            _tttn.LoTrinh = txtLoTrinh.Text.Trim();
            _tttn.HoTen = txtHoTen.Text.Trim();
            _tttn.DiaChi = txtDiaChi.Text.Trim();
            _tttn.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
            _tttn.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
            _tttn.NoiDung = txtNoiDung.Text.Trim();
            _tttn.DienThoai = txtDienThoai.Text.Trim();

            if(_cTTTN.SuaTruyThuTienNuoc(_tttn))
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_tttn != null)
                if (MessageBox.Show("Bạn có chắc chắn xóa Toàn bộ Truy Thu Tiền Nước?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_cTTTN.XoaTruyThuTienNuoc(_tttn))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
        }

        private void dgvThanhToanTruyThuTienNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvThanhToanTruyThuTienNuoc.RowHeadersDefaultCellStyle.ForeColor))
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

        private void dgvThanhToanTruyThuTienNuoc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThanhToanTruyThuTienNuoc["MaTTTTTN", e.RowIndex].Value != null)
            {
                ThanhToanTruyThuTienNuoc tttttn = _cTTTN.getThanhToanTruyThuTienNuocbyMaTTTTTN(int.Parse(dgvThanhToanTruyThuTienNuoc["MaTTTTTN", e.RowIndex].Value.ToString()));

                string[] date = dgvThanhToanTruyThuTienNuoc["NgayDong", e.RowIndex].Value.ToString().Split('/');
                tttttn.NgayDong = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                tttttn.SoTien = int.Parse(dgvThanhToanTruyThuTienNuoc["SoTien", e.RowIndex].Value.ToString());
                tttttn.DaThanhToan = bool.Parse(dgvThanhToanTruyThuTienNuoc["DaThanhToan", e.RowIndex].Value.ToString());

                _cTTTN.SuaThanhToanTruyThuTienNuoc(tttttn);
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

        private void dgvThanhToanTruyThuTienNuoc_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvThanhToanTruyThuTienNuoc["MaTTTTTN", dgvThanhToanTruyThuTienNuoc.CurrentRow.Index].Value != null)
            {
                ThanhToanTruyThuTienNuoc tttttn = _cTTTN.getThanhToanTruyThuTienNuocbyMaTTTTTN(int.Parse(dgvThanhToanTruyThuTienNuoc["MaTTTTTN", dgvThanhToanTruyThuTienNuoc.CurrentRow.Index].Value.ToString()));

                _cTTTN.XoaThanhToanTruyThuTienNuoc(tttttn);
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

        private void dgvTruyThuTienNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTruyThuTienNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTruyThuTienNuoc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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

            if (e.RowIndex >= 0)
            if (dgvTruyThuTienNuoc["MaCTTTTN", e.RowIndex].Value != null)
            {
                CTTruyThuTienNuoc cttttn = _cTTTN.getCTTruyThuTienNuocbyMaCTTTTN(int.Parse(dgvTruyThuTienNuoc["MaCTTTTN", e.RowIndex].Value.ToString()));

                cttttn.Ky = dgvTruyThuTienNuoc["Ky", e.RowIndex].Value.ToString();
                cttttn.Nam = dgvTruyThuTienNuoc["Nam", e.RowIndex].Value.ToString();
                cttttn.GiaBieuCu = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Cu", e.RowIndex].Value.ToString());
                cttttn.DinhMucCu = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Cu", e.RowIndex].Value.ToString());
                cttttn.TieuThuCu = int.Parse(dgvTruyThuTienNuoc["TieuThu_Cu", e.RowIndex].Value.ToString());
                cttttn.TongCongCu = int.Parse(dgvTruyThuTienNuoc["TongCong_Cu", e.RowIndex].Value.ToString());
                ///
                cttttn.GiaBieuMoi = int.Parse(dgvTruyThuTienNuoc["GiaBieu_Moi", e.RowIndex].Value.ToString());
                cttttn.DinhMucMoi = int.Parse(dgvTruyThuTienNuoc["DinhMuc_Moi", e.RowIndex].Value.ToString());
                cttttn.TieuThuMoi = int.Parse(dgvTruyThuTienNuoc["TieuThu_Moi", e.RowIndex].Value.ToString());
                cttttn.GiaBanMoi = int.Parse(dgvTruyThuTienNuoc["GiaBan_Moi", e.RowIndex].Value.ToString());
                cttttn.ThueGTGTMoi = int.Parse(dgvTruyThuTienNuoc["ThueGTGT_Moi", e.RowIndex].Value.ToString());
                cttttn.PhiBVMTMoi = int.Parse(dgvTruyThuTienNuoc["PhiBVMT_Moi", e.RowIndex].Value.ToString());
                cttttn.TongCongMoi = int.Parse(dgvTruyThuTienNuoc["TongCong_Moi", e.RowIndex].Value.ToString());
                cttttn.TangGiam = dgvTruyThuTienNuoc["TangGiam", e.RowIndex].Value.ToString();

                _cTTTN.SuaCTTruyThuTienNuoc(cttttn);
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
                if (item.Cells["Ky"].Value != null)
                {
                    Tongm3HoaDon += int.Parse(item.Cells["TieuThu_Cu"].Value.ToString());
                    Tongm3ThucTe += int.Parse(item.Cells["TieuThu_Moi"].Value.ToString());
                    GiaBan += int.Parse(item.Cells["GiaBan_Moi"].Value.ToString());
                    ThueGTGT += int.Parse(item.Cells["ThueGTGT_Moi"].Value.ToString());
                    PhiBVMT += int.Parse(item.Cells["PhiBVMT_Moi"].Value.ToString());
                    TongCongMoi += int.Parse(item.Cells["TongCong_Moi"].Value.ToString());
                    TongCongCu += int.Parse(item.Cells["TongCong_Cu"].Value.ToString());
                }
            txtSoKy.Text = (dgvTruyThuTienNuoc.RowCount - 1).ToString();
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

        private void dgvTruyThuTienNuoc_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvTruyThuTienNuoc["MaCTTTTN", dgvTruyThuTienNuoc.CurrentRow.Index].Value != null)
            {
                CTTruyThuTienNuoc cttttn = _cTTTN.getCTTruyThuTienNuocbyMaCTTTTN(int.Parse(dgvTruyThuTienNuoc["MaCTTTTN", dgvTruyThuTienNuoc.CurrentRow.Index].Value.ToString()));

                _cTTTN.XoaCTTruyThuTienNuoc(cttttn);
            }
        }

        
    }
}
