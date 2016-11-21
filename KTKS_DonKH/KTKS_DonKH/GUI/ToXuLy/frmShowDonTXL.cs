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
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmShowDonTXL : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CLoaiDonTXL _cLoaiDonTXL = new CLoaiDonTXL();
        DonTXL _dontxl = null;
        HOADON _hoadon = null;
        CDonTXL _cDonTXL = new CDonTXL();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();

        public frmShowDonTXL()
        {
            InitializeComponent();
        }

        public frmShowDonTXL(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
            txtMSThue.Text = hoadon.MST;
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();
        }

        public void Clear()
        {
            cmbLD.SelectedIndex = -1;
            txtMaDon.Text = "";
            txtNgayNhan.Text = "";
            txtNoiDung.Text = "";
            txtSoCongVan.Text = "";

            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtMSThue.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDienThoai.Text = "";
            _hoadon = null;
        }

        private void frmShowDonTXL_Load(object sender, EventArgs e)
        {
            if (_cDonTXL.getDonTXLbyID(decimal.Parse(_source["MaDon"])) != null)
            {
                dgvLichSuChuyenKT.AutoGenerateColumns = false;
                dgvLichSuChuyenKT.ColumnHeadersDefaultCellStyle.Font = new Font(dgvLichSuChuyenKT.Font, FontStyle.Bold);

                this.Location = new Point(0, 70);
                cmbLD.DataSource = _cLoaiDonTXL.LoadDSLoaiDonTXL(true);
                cmbLD.DisplayMember = "TenLD";
                cmbLD.ValueMember = "MaLD";
                cmbLD.SelectedIndex = -1;

                cmbNguoiDi.DataSource = _cTaiKhoan.LoadDSTaiKhoanTXL();
                cmbNguoiDi.DisplayMember = "HoTen";
                cmbNguoiDi.ValueMember = "MaU";
                cmbNguoiDi.SelectedIndex = -1;

                _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(_source["MaDon"]));
                cmbLD.SelectedValue = _dontxl.MaLD.Value;
                txtSoCongVan.Text = _dontxl.SoCongVan;
                if (_dontxl.TongSoDanhBo != null)
                txtTongSoDanhBo.Text = _dontxl.TongSoDanhBo.Value.ToString();
                if (_dontxl.MaDon.ToString().Length>2)
                txtMaDon.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                txtNgayNhan.Text = _dontxl.CreateDate.Value.ToString("dd/MM/yyyy");
                txtNoiDung.Text = _dontxl.NoiDung;
                ///
                txtDanhBo.Text = _dontxl.DanhBo;
                txtHopDong.Text = _dontxl.HopDong;
                txtDienThoai.Text = _dontxl.DienThoai;
                txtHoTen.Text = _dontxl.HoTen;
                txtDiaChi.Text = _dontxl.DiaChi;
                txtMSThue.Text = _dontxl.MSThue;
                txtGiaBieu.Text = _dontxl.GiaBieu;
                txtDinhMuc.Text = _dontxl.DinhMuc;
                ///
                dgvLichSuChuyenKT.DataSource = _cDonTXL.LoadDSLichSuChuyenKTbyMaDonTXL(_dontxl.MaDon);

                if (_dontxl.ChuyenKT)
                {
                    chkChuyenKT.Checked = true;
                    dateChuyenKT.Value = _dontxl.NgayChuyenKT.Value;
                    if (_dontxl.NguoiDi != null)
                    cmbNguoiDi.SelectedValue = _dontxl.NguoiDi;
                    txtGhiChuChuyenKT.Text = _dontxl.GhiChuChuyenKT;
                    chkTKN.Checked = _dontxl.TKN;
                    chkDCG.Checked = _dontxl.DCG;
                    chkDCMS.Checked = _dontxl.DCMS;
                }
                if (_dontxl.ChuyenBanDoiKhac)
                {
                    chkChuyenBanDoiKhac.Checked = true;
                    dateChuyenBanDoiKhac.Value = _dontxl.NgayChuyenBanDoiKhac.Value;
                    txtGhiChuChuyenBanDoiKhac.Text = _dontxl.GhiChuChuyenBanDoiKhac;
                }
                if (_dontxl.ChuyenToKhachHang)
                {
                    chkChuyenToKhachHang.Checked = true;
                    dateChuyenToKhachHang.Value = _dontxl.NgayChuyenToKhachHang.Value;
                    txtGhiChuChuyenToKhachHang.Text = _dontxl.GhiChuChuyenToKhachHang;
                }
                if (_dontxl.ChuyenKhac)
                {
                    chkChuyenKhac.Checked = true;
                    dateChuyenKhac.Value = _dontxl.NgayChuyenKhac.Value;
                    txtGhiChuChuyenKhac.Text = _dontxl.GhiChuChuyenKhac;
                    chkChiBoSung.Checked = _dontxl.ChiBoSung;
                    chkGiuNguyen.Checked = _dontxl.GiuNguyen;
                    chkDieuChinh.Checked = _dontxl.DieuChinh;
                    chkTruyThu.Checked = _dontxl.TruyThu;
                }

                if (_source["Action"] == "Cập Nhật")
                {
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }

                if (_source["Action"].ToString() == "Tìm Kiếm")
                {
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_dontxl != null)
            {
                bool flagSuaChuyenKT = false;

                _dontxl.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                _dontxl.SoCongVan = txtSoCongVan.Text.Trim();
                _dontxl.TongSoDanhBo = int.Parse(txtTongSoDanhBo.Text.Trim());
                if (_hoadon != null && _dontxl.DanhBo != txtDanhBo.Text.Trim())
                {
                    _dontxl.Dot = _hoadon.DOT.ToString();
                    _dontxl.Ky = _hoadon.KY.ToString();
                    _dontxl.Nam = _hoadon.NAM.ToString();
                }
                _dontxl.DanhBo = txtDanhBo.Text.Trim();
                _dontxl.HopDong = txtHopDong.Text.Trim();
                _dontxl.HoTen = txtHoTen.Text.Trim();
                _dontxl.DiaChi = txtDiaChi.Text.Trim();
                _dontxl.DienThoai = txtDienThoai.Text.Trim();
                _dontxl.MSThue = txtMSThue.Text.Trim();
                _dontxl.GiaBieu = txtGiaBieu.Text.Trim();
                _dontxl.DinhMuc = txtDinhMuc.Text.Trim();
                _dontxl.NoiDung = txtNoiDung.Text.Trim();

                if (chkChuyenKT.Checked)
                {
                    _dontxl.ChuyenKT = true;
                    if (_dontxl.NgayChuyenKT != dateChuyenKT.Value || _dontxl.NguoiDi != int.Parse(cmbNguoiDi.SelectedValue.ToString()) || _dontxl.GhiChuChuyenKT != txtGhiChuChuyenKT.Text.Trim())
                        flagSuaChuyenKT = true;
                    _dontxl.NgayChuyenKT = dateChuyenKT.Value;
                    if (cmbNguoiDi.SelectedIndex != -1)
                        _dontxl.NguoiDi = int.Parse(cmbNguoiDi.SelectedValue.ToString());
                    _dontxl.GhiChuChuyenKT = txtGhiChuChuyenKT.Text;
                    _dontxl.TKN = chkTKN.Checked;
                    _dontxl.DCG = chkDCG.Checked;
                    _dontxl.DCMS = chkDCMS.Checked;
                }
                else
                {
                    _dontxl.ChuyenKT = false;
                    _dontxl.NgayChuyenKT = null;
                    _dontxl.NguoiDi = null;
                    _dontxl.GhiChuChuyenKT = null;
                    _dontxl.TKN = false;
                    _dontxl.DCG = false;
                    _dontxl.DCMS = false;
                }

                if (chkChuyenBanDoiKhac.Checked)
                {
                    _dontxl.ChuyenBanDoiKhac = true;
                    _dontxl.NgayChuyenBanDoiKhac = dateChuyenBanDoiKhac.Value;
                    _dontxl.GhiChuChuyenBanDoiKhac = txtGhiChuChuyenBanDoiKhac.Text.Trim();
                }
                else
                {
                    _dontxl.ChuyenBanDoiKhac = false;
                    _dontxl.NgayChuyenBanDoiKhac = null;
                    _dontxl.GhiChuChuyenBanDoiKhac = null;
                }

                if (chkChuyenToKhachHang.Checked)
                {
                    _dontxl.ChuyenToKhachHang = true;
                    _dontxl.NgayChuyenToKhachHang = dateChuyenToKhachHang.Value;
                    _dontxl.GhiChuChuyenToKhachHang = txtGhiChuChuyenToKhachHang.Text.Trim();
                }
                else
                {
                    _dontxl.ChuyenToKhachHang = false;
                    _dontxl.NgayChuyenToKhachHang = null;
                    _dontxl.GhiChuChuyenToKhachHang = null;
                }

                if (chkChuyenKhac.Checked)
                {
                    _dontxl.ChuyenKhac = true;
                    _dontxl.NgayChuyenKhac = dateChuyenKhac.Value;
                    _dontxl.GhiChuChuyenKhac = txtGhiChuChuyenKhac.Text.Trim();
                    _dontxl.ChiBoSung = chkChiBoSung.Checked;
                    _dontxl.GiuNguyen = chkGiuNguyen.Checked;
                    _dontxl.DieuChinh = chkDieuChinh.Checked;
                    _dontxl.TruyThu = chkTruyThu.Checked;
                }
                else
                {
                    _dontxl.ChuyenKhac = false;
                    _dontxl.NgayChuyenKhac = null;
                    _dontxl.GhiChuChuyenKhac = null;
                    _dontxl.GiuNguyen = false;
                    _dontxl.DieuChinh = false;
                    _dontxl.TruyThu = false;
                }

                if (_cDonTXL.SuaDonTXL(_dontxl))
                {
                    if (flagSuaChuyenKT)
                    {
                        LichSuChuyenKT lichsuchuyenkt = new LichSuChuyenKT();
                        lichsuchuyenkt.NgayChuyen = _dontxl.NgayChuyenKT;
                        lichsuchuyenkt.NguoiDi = _dontxl.NguoiDi;
                        lichsuchuyenkt.GhiChuChuyen = _dontxl.GhiChuChuyenKT;
                        lichsuchuyenkt.MaDonTXL = _dontxl.MaDon;
                        _cDonTXL.ThemLichSuChuyenKT(lichsuchuyenkt);
                        flagSuaChuyenKT = false;
                    }
                    MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
                MessageBox.Show("Chưa chọn Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_dontxl != null)
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_cDonTXL.XoaDonTXL(_dontxl))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cThuTien.GetMoiNhat(txtDanhBo.Text.Trim()) != null)
                {
                    _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                    LoadTTKH(_hoadon);
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void chkChuyenKTXM_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenKT.Checked)
            {
                groupBoxChuyenKTXM.Enabled = true;
                cmbNguoiDi.SelectedIndex = 0;
            }
            else
            {
                groupBoxChuyenKTXM.Enabled = false;
            }
        }

        private void chkChuyenBanDoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenBanDoiKhac.Checked)
            {
                groupBoxChuyenBanDoiKhac.Enabled = true;
            }
            else
            {
                groupBoxChuyenBanDoiKhac.Enabled = false;
            }
        }

        private void chkChuyenToKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenToKhachHang.Checked)
            {
                groupBoxChuyenToKhachHang.Enabled = true;
            }
            else
            {
                groupBoxChuyenToKhachHang.Enabled = false;
            }
        }

        private void chkChuyenKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenKhac.Checked)
            {
                groupBoxChuyenKhac.Enabled = true;
            }
            else
            {
                groupBoxChuyenKhac.Enabled = false;
            }
        }

        private void dgvLichSuChuyenKT_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvLichSuChuyenKT.CurrentCell = dgvLichSuChuyenKT.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvLichSuChuyenKT_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_dontxl != null))
            {
                contextMenuStrip1.Show(dgvLichSuChuyenKT, new Point(e.X, e.Y));
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                if (_cDonTXL.XoaLichSuChuyenKT(_cDonTXL.getLichSuChuyenKTbyID(decimal.Parse(dgvLichSuChuyenKT.CurrentRow.Cells["MaLSChuyen"].Value.ToString()))))
                {
                    dgvLichSuChuyenKT.DataSource = _cDonTXL.LoadDSLichSuChuyenKTbyMaDonTXL(_dontxl.MaDon);
                }
        }

        private void txtTongSoDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
