using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.DAL.Quay;

namespace ThuTien.GUI.TongHop
{
    public partial class frmDCHD : Form
    {
        string _mnu = "mnuDCHD";
        CHoaDon _cHoaDon = new CHoaDon();
        DonKH _donkh;
        DonTXL _dontxl;
        CDCHD _cDCHD = new CDCHD();
        CTamThu _cTamThu = new CTamThu();

        public frmDCHD()
        {
            InitializeComponent();
        }

        private void frmDCHD_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvDCHD.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
        }

        public void Clear()
        {
            txtMaDon.Text = "";
            txtDanhBo.Text = "";
            _donkh = null;
            _dontxl = null;
            dgvHoaDon.DataSource = null;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtMaDon.Text.Trim()))
            {
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDCHD.GetDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                    {
                        _dontxl = _cDCHD.GetDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        if (!string.IsNullOrEmpty(_dontxl.DanhBo))
                        {
                            txtDanhBo.Text = _dontxl.DanhBo;
                            dgvHoaDon.DataSource = _cHoaDon.GetDSByDanhBo(txtDanhBo.Text.Trim());
                        }
                        else
                        {
                            //Clear();
                            MessageBox.Show("Danh Bộ không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //_dontxl = null;
                        Clear();
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ///Đơn Tổ Khách Hàng
                else
                    if (_cDCHD.GetDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                    {
                        _donkh = _cDCHD.GetDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                        //txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                        if (!string.IsNullOrEmpty(_donkh.DanhBo))
                        {
                            txtDanhBo.Text = _donkh.DanhBo;
                            dgvHoaDon.DataSource = _cHoaDon.GetDSByDanhBo(txtDanhBo.Text.Trim());
                        }
                        else
                        {
                            //Clear();
                            MessageBox.Show("Danh Bộ không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //_donkh = null;
                        Clear();
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()) && e.KeyChar == 13)
            {
                dgvHoaDon.DataSource = _cHoaDon.GetDSByDanhBo(txtDanhBo.Text.Trim());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                ///Có nhiều hơn 1 hóa đơn
                if (dgvHoaDon.RowCount > 1)
                {
                    ///Kiểm tra có chọn hóa đơn đăng ngân chưa
                    int Count = 0;
                    int index = -1;
                    for (int i = 0; i < dgvHoaDon.RowCount; i++)
                    {
                        if (dgvHoaDon["Chon", i].Value!=null && bool.Parse(dgvHoaDon["Chon", i].Value.ToString()))
                        {
                            Count++;
                            index = i;
                        }
                    }
                    if (Count == 0)
                    {
                        MessageBox.Show("Chưa chọn Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        if (Count > 1)
                        {
                            MessageBox.Show("Chọn quá 1 Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    ///Bắt đầu đăng ngân chỉ 1 hóa đơn được chọn
                    if (bool.Parse(dgvHoaDon["Chon", index].Value.ToString()) && !_cDCHD.CheckBySoHoaDon(dgvHoaDon["SoHoaDon", index].Value.ToString()))
                    {
                        string loai;
                        if (_cTamThu.CheckBySoHoaDon(dgvHoaDon["SoHoaDon", index].Value.ToString(),out loai))
                        {
                            MessageBox.Show("Hóa Đơn này đã Tạm Thu(" + loai + ")", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        DIEUCHINH_HD dchd = new DIEUCHINH_HD();
                        HOADON hoadon = _cHoaDon.GetByMaHD(int.Parse(dgvHoaDon["MaHD", index].Value.ToString()));
                        dchd.FK_HOADON = int.Parse(dgvHoaDon["MaHD", index].Value.ToString());
                        dchd.SoHoaDon = dgvHoaDon["SoHoaDon", index].Value.ToString();
                        dchd.GiaBieu = hoadon.GB;
                        dchd.DinhMuc = (int)hoadon.DM;
                        dchd.TIEUTHU_BD = (int)hoadon.TIEUTHU;
                        dchd.GIABAN_BD = hoadon.GIABAN;
                        dchd.PHI_BD = hoadon.PHI;
                        dchd.THUE_BD = hoadon.THUE;
                        dchd.TONGCONG_BD = hoadon.TONGCONG;

                        if (_donkh != null)
                        {
                            dchd.PHIEU_DC = (int)_donkh.MaDon;
                            dchd.NGAY_VB = _donkh.CreateDate;
                        }
                        else
                            if (_dontxl != null)
                            {
                                dchd.PHIEU_DC = (int)_dontxl.MaDon;
                                dchd.NGAY_VB = _dontxl.CreateDate;
                            }

                        if (_cDCHD.Them(dchd))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Chưa Chọn Hóa Đơn \nhoặc Hóa Đơn này đã Rút Điều Chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    ///Có 1 hóa đơn nên set mặc định row 0
                    if (dgvHoaDon.RowCount == 1 && !_cDCHD.CheckBySoHoaDon(dgvHoaDon["SoHoaDon", 0].Value.ToString()))
                    {
                        string loai;
                        if (_cTamThu.CheckBySoHoaDon(dgvHoaDon["SoHoaDon", 0].Value.ToString(), out loai))
                        {
                            MessageBox.Show("Hóa Đơn này đã Tạm Thu(" + loai + ")", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        DIEUCHINH_HD dchd = new DIEUCHINH_HD();
                        HOADON hoadon = _cHoaDon.GetByMaHD(int.Parse(dgvHoaDon["MaHD", 0].Value.ToString()));
                        dchd.FK_HOADON = int.Parse(dgvHoaDon["MaHD", 0].Value.ToString());
                        dchd.SoHoaDon = dgvHoaDon["SoHoaDon", 0].Value.ToString();
                        dchd.GiaBieu = hoadon.GB;
                        dchd.DinhMuc = (int)hoadon.DM;
                        dchd.TIEUTHU_BD = (int)hoadon.TIEUTHU;
                        dchd.GIABAN_BD = hoadon.GIABAN;
                        dchd.PHI_BD = hoadon.PHI;
                        dchd.THUE_BD = hoadon.THUE;
                        dchd.TONGCONG_BD = hoadon.TONGCONG;

                        if (_donkh != null)
                        {
                            dchd.PHIEU_DC = (int)_donkh.MaDon;
                            dchd.NGAY_VB = _donkh.CreateDate;
                        }
                        else
                            if (_dontxl != null)
                            {
                                dchd.PHIEU_DC = (int)_dontxl.MaDon;
                                dchd.NGAY_VB = _dontxl.CreateDate;
                            }

                        if (_cDCHD.Them(dchd))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Chưa có thông tin Hóa Đơn \nhoặc Hóa Đơn này đã Rút Điều Chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void radChuaDCHD_CheckedChanged(object sender, EventArgs e)
        {
            //if (radChuaDCHD.Checked)
            //{
            //    dgvDCHD.DataSource = _cDCHD.GetDSChuaDCHD(CNguoiDung.MaND);
            //}
        }

        private void radDaDCHD_CheckedChanged(object sender, EventArgs e)
        {
            //if (radDaDCHD.Checked)
            //{
            //    dgvDCHD.DataSource = _cDCHD.GetDSDaDCHD(CNguoiDung.MaND);
            //}
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _cDCHD.BeginTransaction();
                    foreach (DataGridViewRow item in dgvDCHD.SelectedRows)
                    {
                        DIEUCHINH_HD dchd = _cDCHD.GetByMaDCHD(int.Parse(item.Cells["MaDCHD"].Value.ToString()));
                        if (!_cHoaDon.CheckDangNganBySoHoaDon(dchd.SoHoaDon))
                        {
                            if (_cDCHD.Xoa(dchd))
                            {
                                try
                                {
                                    HOADON hoadon = _cHoaDon.GetBySoHoaDon(item.Cells["SoHoaDon_DC"].Value.ToString());
                                    hoadon.GIABAN = dchd.GIABAN_BD;
                                    hoadon.THUE = dchd.THUE_BD;
                                    hoadon.PHI = dchd.PHI_BD;
                                    hoadon.TONGCONG = dchd.TONGCONG_BD;
                                    _cHoaDon.Sua(hoadon);
                                }
                                catch (Exception)
                                {
                                    _cDCHD.Rollback();
                                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                _cDCHD.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            _cDCHD.Rollback();
                            dgvDCHD.ClearSelection();
                            dgvDCHD.Rows[item.Index].Selected = true;
                            MessageBox.Show("Hóa đơn đã Đăng Ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    _cDCHD.CommitTransaction();
                    dgvDCHD.DataSource = null;
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (radChuaDCHD.Checked)
                dgvDCHD.DataSource = _cDCHD.GetDSByMaNVCreateDates(false, CNguoiDung.MaND, dateTu.Value, dateDen.Value);
            else
                if (radDaDCHD.Checked)
                    dgvDCHD.DataSource = _cDCHD.GetDSByMaNVCreateDates(true, CNguoiDung.MaND, dateTu.Value, dateDen.Value);
        }

        private void dgvDCHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvDCHD.RowCount > 0)
            {
                frmShowDCHD frm = new frmShowDCHD(int.Parse(dgvDCHD.SelectedRows[0].Cells["MaDCHD"].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDCHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "DanhBo_DC" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "GiaBan_Start" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "ThueGTGT_Start" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "PhiBVMT_Start" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TongCong_Start" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TongCong_BD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TongCong_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDCHD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDCHD.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
