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
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.KhachHang;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmNhanDonTXL : Form
    {
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CTTKH _cTTKH = new CTTKH();
        CLoaiDonTXL _cLoaiDonTXL = new CLoaiDonTXL();
        TTKhachHang _ttkhachhang = null;
        CDonTXL _cDonTXL = new CDonTXL();
        DonTXL _dontxl = null;
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        public frmNhanDonTXL()
        {
            InitializeComponent();
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
            txtMSThue.Text = ttkhachhang.MSThue;
            txtGiaBieu.Text = ttkhachhang.GB;
            txtDinhMuc.Text = ttkhachhang.TGDM;
        }

        public void Clear()
        {
            cmbLD.SelectedIndex = -1;
            txtMaDon.Text = "";
            txtNgayNhan.Text = "";
            txtNoiDung.Text = "";
            txtSoCongVan.Text = "";
            ///
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtMSThue.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDienThoai.Text = "";
            _ttkhachhang = null;
            _dontxl = null;
            ///
            chkChuyenKTXM.Checked = false;
            dateChuyenKTXM.Value = DateTime.Now;
            cmbNguoiDi.SelectedIndex = -1;
            chkChuyenBanDoiKhac.Checked = false;
            dateChuyenBanDoiKhac.Value = DateTime.Now;
            txtGhiChuChuyenBanDoiKhac.Text = "";
            chkChuyenToKhachHang.Checked = false;
            dateChuyenToKhachHang.Value = DateTime.Now;
            txtGhiChuChuyenToKhachHang.Text = "";
            chkChuyenKhac.Checked = false;
            dateChuyenKhac.Value = DateTime.Now;
            txtGhiChuChuyenKhac.Text = "";
        }

        private void frmNhanDonTXL_Load(object sender, EventArgs e)
        {
            cmbLD.DataSource = _cLoaiDonTXL.LoadDSLoaiDonTXL(true);
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            cmbNguoiDi.DataSource = _cTaiKhoan.LoadDSTaiKhoanTXL();
            cmbNguoiDi.DisplayMember = "HoTen";
            cmbNguoiDi.ValueMember = "MaU";
            cmbNguoiDi.SelectedIndex = -1;

            Clear();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                    LoadTTKH(_ttkhachhang);
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLD.SelectedIndex != -1)
                {
                    DonTXL dontxl = new DonTXL();
                    dontxl.MaDon = _cDonTXL.getMaxNextID();
                    dontxl.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                    dontxl.SoCongVan = txtSoCongVan.Text.Trim();
                    dontxl.NoiDung = txtNoiDung.Text.Trim();

                    dontxl.DanhBo = txtDanhBo.Text.Trim();
                    dontxl.HopDong = txtHopDong.Text.Trim();
                    dontxl.HoTen = txtHoTen.Text.Trim();
                    dontxl.DiaChi = txtDiaChi.Text.Trim();
                    dontxl.DienThoai = txtDienThoai.Text.Trim();
                    dontxl.MSThue = txtMSThue.Text.Trim();
                    dontxl.GiaBieu = txtGiaBieu.Text.Trim();
                    dontxl.DinhMuc = txtDinhMuc.Text.Trim();
                    if (_ttkhachhang != null)
                    {
                        dontxl.Dot = _ttkhachhang.Dot;
                        dontxl.Ky = _ttkhachhang.Ky;
                        dontxl.Nam = _ttkhachhang.Nam;
                    }

                    if (chkChuyenKTXM.Checked)
                    {
                        dontxl.ChuyenKTXM = true;
                        dontxl.NgayChuyenKTXM = dateChuyenKTXM.Value;
                        if (cmbNguoiDi.SelectedIndex != -1)
                            dontxl.NguoiDi = int.Parse(cmbNguoiDi.SelectedValue.ToString());
                    }

                    if (chkChuyenBanDoiKhac.Checked)
                    {
                        dontxl.ChuyenBanDoiKhac = true;
                        dontxl.NgayChuyenBanDoiKhac = dateChuyenBanDoiKhac.Value;
                        dontxl.GhiChuChuyenBanDoiKhac = txtGhiChuChuyenBanDoiKhac.Text.Trim();
                    }

                    if (chkChuyenToKhachHang.Checked)
                    {
                        dontxl.ChuyenToKhachHang = true;
                        dontxl.NgayChuyenToKhachHang = dateChuyenToKhachHang.Value;
                        dontxl.GhiChuChuyenToKhachHang = txtGhiChuChuyenToKhachHang.Text.Trim();
                    }

                    if (chkChuyenKhac.Checked)
                    {
                        dontxl.ChuyenKhac = true;
                        dontxl.NgayChuyenKhac = dateChuyenKhac.Value;
                        dontxl.GhiChuChuyenKhac = txtGhiChuChuyenKhac.Text.Trim();
                    }

                    if (_cDonTXL.ThemDonTXL(dontxl))
                    {
                        MessageBox.Show("Thêm Thành công/n Mã Đơn: TXL" + dontxl.MaDon.ToString().Insert(dontxl.MaDon.ToString().Length - 2, "-"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                        //DataRow dr = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                        //dr["MaDon"] = dontxl.MaDon.ToString().Insert(dontxl.MaDon.ToString().Length - 2, "-");// +"/" + _cLoaiDon.getKyHieuLDubyID(int.Parse(cmbLD.SelectedValue.ToString()));
                        ////dr["MaXepDon"] = _cLoaiDon.getKyHieuLDubyID(int.Parse(cmbLD.SelectedValue.ToString()));
                        //dr["TenLD"] = cmbLD.Text;
                        //dr["KhachHang"] = txtHoTen.Text.Trim();
                        //if (txtDanhBo.Text.Trim() != "")
                        //    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, ".").Insert(4, ".");
                        //dr["DiaChi"] = txtDiaChi.Text.Trim();
                        //dr["HopDong"] = txtHopDong.Text.Trim();
                        //dr["DienThoai"] = txtDienThoai.Text.Trim();

                        //dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
                        //rptBienNhanDonKH rpt = new rptBienNhanDonKH();
                        //rpt.SetDataSource(dsBaoCao);
                        //frmBaoCao frm = new frmBaoCao(rpt);
                        //frm.ShowDialog();

                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLD.SelectedIndex != -1)
            {
                //txtMaDon.Text = "TXL" + _cDonTXL.getMaxNextID().ToString().Insert(_cDonTXL.getMaxNextID().ToString().Length - 2, "-");
                txtNgayNhan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                if (_cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("TXL", "").Replace("txl", "").Replace("-", ""))) != null)
                {
                    _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("TXL", "").Replace("txl", "").Replace("-", "")));

                    cmbLD.SelectedValue = _dontxl.MaLD.Value;
                    txtSoCongVan.Text = _dontxl.SoCongVan;
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
                }
                else
                {
                    MessageBox.Show("Mã Đơn TXL này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void chkChuyenKTXM_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenKTXM.Checked)
            {
                groupBoxChuyenKTXM.Enabled = true;
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_dontxl != null)
            {
                _dontxl.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                _dontxl.SoCongVan = txtSoCongVan.Text.Trim();
                if (_ttkhachhang != null && _dontxl.DanhBo != txtDanhBo.Text.Trim())
                {
                    _dontxl.Dot = _ttkhachhang.Dot;
                    _dontxl.Ky = _ttkhachhang.Ky;
                    _dontxl.Nam = _ttkhachhang.Nam;
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
                

                if (chkChuyenKTXM.Checked)
                {
                    _dontxl.ChuyenKTXM = true;
                    _dontxl.NgayChuyenKTXM = dateChuyenKTXM.Value;
                    _dontxl.NguoiDi = int.Parse(cmbNguoiDi.SelectedValue.ToString());
                }
                else
                {
                    _dontxl.ChuyenKTXM = false;
                    _dontxl.NgayChuyenKTXM = null;
                    _dontxl.NguoiDi = null;
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
                }
                else
                {
                    _dontxl.ChuyenKhac = false;
                    _dontxl.NgayChuyenKhac = null;
                    _dontxl.GhiChuChuyenKhac = null;
                }
            }
            else
                MessageBox.Show("Chưa chọn Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (_cDonTXL.SuaDonTXL(_dontxl))
            {
                MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
        }

        
    }
}
