using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.HeThong;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ToXuLy;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmCapNhatDonKH : Form
    {
        CLoaiDon _cLoaiDon = new CLoaiDon();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        DonKH _donkh = new DonKH();


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        public frmCapNhatDonKH()
        {
            InitializeComponent();
        }

        private void frmCapNhatDonKH_Load(object sender, EventArgs e)
        {
            cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon(true);
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            cmbNguoiDi.DataSource = _cTaiKhoan.LoadDSTaiKhoanTKH();
            cmbNguoiDi.DisplayMember = "HoTen";
            cmbNguoiDi.ValueMember = "MaU";
            cmbNguoiDi.SelectedIndex = -1;

            cmbVanPhong.DataSource = _cTaiKhoan.LoadDSTaiKhoanTVP();
            cmbVanPhong.DisplayMember = "HoTen";
            cmbVanPhong.ValueMember = "MaU";
            cmbVanPhong.SelectedIndex = -1;
        }

        public void Clear()
        {
            cmbLD.SelectedIndex = -1;
            txtMaDon.Text = "";
            txtNgayNhan.Text = "";
            txtNoiDung.Text = "";
            txtSoCongVan.Text = "";
            txtTongSoDanhBo.Text = "1";

            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtDienThoai.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtMSThue.Text = "";
            //cmbNVKiemTra.SelectedIndex = 0;

            chkChuyenKT.Checked = false;
            dateChuyenKT.Value = DateTime.Now;
            cmbNguoiDi.SelectedIndex = -1;
            chkChuyenBanDoiKhac.Checked = false;
            dateChuyenBanDoiKhac.Value = DateTime.Now;
            txtGhiChuChuyenBanDoiKhac.Text = "";
            chkChuyenToXuLy.Checked = false;
            dateChuyenToXuLy.Value = DateTime.Now;
            txtGhiChuChuyenToXuLy.Text = "";
            chkChuyenKhac.Checked = false;
            dateChuyenKhac.Value = DateTime.Now;
            txtGhiChuChuyenKhac.Text = "";
        }

        private void btnNhapNhieuDB_Click(object sender, EventArgs e)
        {
            frmNhapNhieuDBTKH frm = new frmNhapNhieuDBTKH();
            frm.ShowDialog();
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                {
                    _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));

                    cmbLD.SelectedValue = _donkh.MaLD.Value;
                    txtSoCongVan.Text = _donkh.SoCongVan;
                    if (_donkh.TongSoDanhBo != null)
                        txtTongSoDanhBo.Text = _donkh.TongSoDanhBo.Value.ToString();
                    txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                    txtNgayNhan.Text = _donkh.CreateDate.Value.ToString("dd/MM/yyyy");
                    txtNoiDung.Text = _donkh.NoiDung;
                    //txtMaXepDon.Text = _donkh.MaXepDon.ToString().Insert(_donkh.MaXepDon.ToString().Length - 2, "-") + "/" + _cLoaiDon.getKyHieuLDubyID(int.Parse(cmbLD.SelectedValue.ToString()));

                    txtDanhBo.Text = _donkh.DanhBo;
                    txtHopDong.Text = _donkh.HopDong;
                    txtDienThoai.Text = _donkh.DienThoai;
                    txtHoTen.Text = _donkh.HoTen;
                    txtDiaChi.Text = _donkh.DiaChi;
                    txtMSThue.Text = _donkh.MSThue;
                    txtGiaBieu.Text = _donkh.GiaBieu;
                    txtDinhMuc.Text = _donkh.DinhMuc;
                    //cmbNVKiemTra.Text = _donkh.GhiChuNguoiDi;
                    ///
                    DataTable dt = _cDonTXL.LoadDSLichSuChuyenKTbyMaDonTKH(_donkh.MaDon);
                    dt.Merge(_cDonKH.LoadDSLichSuChuyenVanPhongbyMaDonTKH(_donkh.MaDon));
                    dgvLichSuChuyenKT.DataSource = dt;
                    ///
                    if (_donkh.ChuyenKT)
                    {
                        chkChuyenKT.Checked = true;
                        dateChuyenKT.Value = _donkh.NgayChuyenKT.Value;
                        cmbNguoiDi.SelectedValue = _donkh.NguoiDi;
                        txtGhiChuChuyenKT.Text = _donkh.GhiChuChuyenKT;
                    }
                    if (_donkh.ChuyenVanPhong)
                    {
                        chkChuyenVanPhong.Checked = true;
                        dateChuyenVanPhong.Value = _donkh.NgayChuyenVanPhong.Value;
                        cmbVanPhong.SelectedValue = _donkh.NguoiVanPhong;
                        txtGhiChuChuyenVanPhong.Text = _donkh.GhiChuChuyenVanPhong;
                    }
                    if (_donkh.ChuyenBanDoiKhac)
                    {
                        chkChuyenBanDoiKhac.Checked = true;
                        dateChuyenBanDoiKhac.Value = _donkh.NgayChuyenBanDoiKhac.Value;
                        txtGhiChuChuyenBanDoiKhac.Text = _donkh.GhiChuChuyenBanDoiKhac;
                    }
                    if (_donkh.ChuyenToXuLy)
                    {
                        chkChuyenToXuLy.Checked = true;
                        dateChuyenToXuLy.Value = _donkh.NgayChuyenToXuLy.Value;
                        txtGhiChuChuyenToXuLy.Text = _donkh.GhiChuChuyenToXuLy;
                    }
                    if (_donkh.ChuyenKhac)
                    {
                        chkChuyenKhac.Checked = true;
                        dateChuyenKhac.Value = _donkh.NgayChuyenKhac.Value;
                        txtGhiChuChuyenKhac.Text = _donkh.GhiChuChuyenKhac;
                    }
                }
                else
                {
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_donkh != null)
            {
                bool flagSuaChuyenKT = false;
                bool flagSuaChuyenVP = false;
                if (chkChuyenKT.Checked)
                {
                    _donkh.ChuyenKT = true;
                    if (_donkh.NgayChuyenKT != dateChuyenKT.Value || _donkh.NguoiDi != int.Parse(cmbNguoiDi.SelectedValue.ToString()) || _donkh.GhiChuChuyenKT != txtGhiChuChuyenKT.Text.Trim())
                        flagSuaChuyenKT = true;
                    _donkh.NgayChuyenKT = dateChuyenKT.Value;
                    if (cmbNguoiDi.SelectedIndex != -1)
                        _donkh.NguoiDi = int.Parse(cmbNguoiDi.SelectedValue.ToString());
                    _donkh.GhiChuChuyenKT = txtGhiChuChuyenKT.Text.Trim();
                }
                else
                {
                    _donkh.ChuyenKT = false;
                    _donkh.NgayChuyenKT = null;
                    _donkh.NguoiDi = null;
                    _donkh.GhiChuChuyenKT = null;
                }

                if (chkChuyenVanPhong.Checked)
                {
                    _donkh.ChuyenVanPhong = true;
                    if (_donkh.NgayChuyenVanPhong != dateChuyenVanPhong.Value || _donkh.NguoiVanPhong != int.Parse(cmbVanPhong.SelectedValue.ToString()) || _donkh.GhiChuChuyenVanPhong != txtGhiChuChuyenVanPhong.Text.Trim())
                        flagSuaChuyenVP = true;
                    _donkh.NgayChuyenVanPhong = dateChuyenVanPhong.Value;
                    if (cmbVanPhong.SelectedIndex != -1)
                        _donkh.NguoiVanPhong = int.Parse(cmbVanPhong.SelectedValue.ToString());
                    _donkh.GhiChuChuyenVanPhong = txtGhiChuChuyenVanPhong.Text.Trim();
                }
                else
                {
                    _donkh.ChuyenVanPhong = false;
                    _donkh.NgayChuyenVanPhong = null;
                    _donkh.NguoiVanPhong = null;
                    _donkh.GhiChuChuyenVanPhong = null;
                }

                if (chkChuyenBanDoiKhac.Checked)
                {
                    _donkh.ChuyenBanDoiKhac = true;
                    _donkh.NgayChuyenBanDoiKhac = dateChuyenBanDoiKhac.Value;
                    _donkh.GhiChuChuyenBanDoiKhac = txtGhiChuChuyenBanDoiKhac.Text.Trim();
                }
                else
                {
                    _donkh.ChuyenBanDoiKhac = false;
                    _donkh.NgayChuyenBanDoiKhac = null;
                    _donkh.GhiChuChuyenBanDoiKhac = null;
                }

                if (chkChuyenToXuLy.Checked)
                {
                    _donkh.ChuyenToXuLy = true;
                    _donkh.NgayChuyenToXuLy = dateChuyenToXuLy.Value;
                    _donkh.GhiChuChuyenToXuLy = txtGhiChuChuyenToXuLy.Text.Trim();
                }
                else
                {
                    _donkh.ChuyenToXuLy = false;
                    _donkh.NgayChuyenToXuLy = null;
                    _donkh.GhiChuChuyenToXuLy = null;
                }

                if (chkChuyenKhac.Checked)
                {
                    _donkh.ChuyenKhac = true;
                    _donkh.NgayChuyenKhac = dateChuyenKhac.Value;
                    _donkh.GhiChuChuyenKhac = txtGhiChuChuyenKhac.Text.Trim();
                }
                else
                {
                    _donkh.ChuyenKhac = false;
                    _donkh.NgayChuyenKhac = null;
                    _donkh.GhiChuChuyenKhac = null;
                }

                if (_cDonKH.SuaDonKH(_donkh))
                {
                    if (flagSuaChuyenKT)
                    {
                        LichSuChuyenKT lichsuchuyenkt = new LichSuChuyenKT();
                        lichsuchuyenkt.NgayChuyenKT = _donkh.NgayChuyenKT;
                        lichsuchuyenkt.NguoiDi = _donkh.NguoiDi;
                        lichsuchuyenkt.GhiChuChuyenKT = _donkh.GhiChuChuyenKT;
                        lichsuchuyenkt.MaDon = _donkh.MaDon;
                        _cDonTXL.ThemLichSuChuyenKT(lichsuchuyenkt);
                        flagSuaChuyenKT = false;
                    }
                    if (flagSuaChuyenVP)
                    {
                        LichSuChuyenVanPhong lichsuchuyenvanphong = new LichSuChuyenVanPhong();
                        lichsuchuyenvanphong.NgayChuyenVanPhong = _donkh.NgayChuyenVanPhong;
                        lichsuchuyenvanphong.NguoiDi = _donkh.NguoiVanPhong;
                        lichsuchuyenvanphong.GhiChuChuyenVanPhong = _donkh.GhiChuChuyenVanPhong;
                        lichsuchuyenvanphong.MaDon = _donkh.MaDon;
                        _cDonKH.ThemLichSuChuyenVanPhong(lichsuchuyenvanphong);
                        flagSuaChuyenVP = false;
                    }
                    MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvLichSuChuyenKT.CurrentRow.Cells["Table"].Value.ToString()=="LichSuChuyenKT")
                    if (_cDonTXL.XoaLichSuChuyenKT(_cDonTXL.getLichSuChuyenKTbyID(decimal.Parse(dgvLichSuChuyenKT.CurrentRow.Cells["MaLSChuyenKT"].Value.ToString()))))
                    {
                        DataTable dt = _cDonTXL.LoadDSLichSuChuyenKTbyMaDonTKH(_donkh.MaDon);
                        dt.Merge(_cDonKH.LoadDSLichSuChuyenVanPhongbyMaDonTKH(_donkh.MaDon));
                        dgvLichSuChuyenKT.DataSource = dt;
                    }
                if (dgvLichSuChuyenKT.CurrentRow.Cells["Table"].Value.ToString() == "LichSuChuyenVanPhong")
                    if (_cDonKH.XoaLichSuChuyenVanPhong(_cDonKH.getLichSuChuyenVanPhongbyID(decimal.Parse(dgvLichSuChuyenKT.CurrentRow.Cells["MaLSChuyenKT"].Value.ToString()))))
                    {
                        DataTable dt = _cDonTXL.LoadDSLichSuChuyenKTbyMaDonTKH(_donkh.MaDon);
                        dt.Merge(_cDonKH.LoadDSLichSuChuyenVanPhongbyMaDonTKH(_donkh.MaDon));
                        dgvLichSuChuyenKT.DataSource = dt;
                    }
            }
        }

        private void chkChuyenKT_CheckedChanged(object sender, EventArgs e)
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

        private void chkChuyenVanPhong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenVanPhong.Checked)
            {
                groupBoxChuyenVanPhong.Enabled = true;
            }
            else
            {
                groupBoxChuyenVanPhong.Enabled = false;
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

        private void chkChuyenToXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenToXuLy.Checked)
            {
                groupBoxChuyenToXuLy.Enabled = true;
            }
            else
            {
                groupBoxChuyenToXuLy.Enabled = false;
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

        
    }
}
