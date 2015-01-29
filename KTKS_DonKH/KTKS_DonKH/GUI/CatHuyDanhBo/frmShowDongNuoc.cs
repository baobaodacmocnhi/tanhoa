using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DongNuoc;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DongNuoc;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.DAL.KhachHang;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmShowDongNuoc : Form
    {
        decimal _MaCTDN = 0;
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CTDongNuoc _ctdongnuoc = null;
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CBamChi _cBamChi = new CBamChi();
        TTKhachHang _ttkhachhang = null;
        CTTKH _cTTKH = new CTTKH();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();

        public frmShowDongNuoc()
        {
            InitializeComponent();
        }

        public frmShowDongNuoc(decimal MaCTDN)
        {
            InitializeComponent();
            _MaCTDN = MaCTDN;
        }

        public frmShowDongNuoc(decimal MaCTDN, bool TimKiem)
        {
            InitializeComponent();
            _MaCTDN = MaCTDN;
            if (TimKiem)
            {
                btnCapNhatMoNuoc.Enabled = false;
                btnInTBDN.Enabled = false;
                btnInTBMN.Enabled = false;
                btnSua.Enabled = false;
            }
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChiDHN.Text = txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
        }

        private void frmShowDongNuoc_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            dgvDSBamChi.AutoGenerateColumns = false;
            dgvDSBamChi.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSBamChi.Font, FontStyle.Bold);

            if (_cDongNuoc.getCTDongNuocbyID(_MaCTDN) != null)
            {
                _ctdongnuoc = _cDongNuoc.getCTDongNuocbyID(_MaCTDN);
                if (!string.IsNullOrEmpty(_ctdongnuoc.DongNuoc.MaDonTXL.ToString()))
                {
                    txtMaDon.Text = "TXL" + _ctdongnuoc.DongNuoc.MaDonTXL.ToString().Insert(_ctdongnuoc.DongNuoc.MaDonTXL.ToString().Length - 2, "-");
                    dgvDSBamChi.DataSource = _cBamChi.LoadDSCTBamChi_TXL(_ctdongnuoc.DongNuoc.MaDonTXL.Value, _ctdongnuoc.DanhBo);
                }
                else
                    if (!string.IsNullOrEmpty(_ctdongnuoc.DongNuoc.MaDon.ToString()))
                    {
                        txtMaDon.Text = _ctdongnuoc.DongNuoc.MaDon.ToString().Insert(_ctdongnuoc.DongNuoc.MaDon.ToString().Length - 2, "-");
                        dgvDSBamChi.DataSource = _cBamChi.LoadDSCTBamChi(_ctdongnuoc.DongNuoc.MaDon.Value, _ctdongnuoc.DanhBo);
                    }

                txtMaThongBao_DN.Text = _ctdongnuoc.MaCTDN.ToString().Insert(_ctdongnuoc.MaCTDN.ToString().Length - 2, "-");

                if (!string.IsNullOrEmpty(_ctdongnuoc.MaCTMN.ToString()))
                    txtMaThongBao_MN.Text = _ctdongnuoc.MaCTMN.ToString().Insert(_ctdongnuoc.MaCTMN.ToString().Length - 2, "-");
                ///
                txtDanhBo.Text = _ctdongnuoc.DanhBo;
                txtHopDong.Text = _ctdongnuoc.HopDong;
                txtHoTen.Text = _ctdongnuoc.HoTen;
                txtDiaChi.Text = _ctdongnuoc.DiaChi;
                txtDiaChiDHN.Text = _ctdongnuoc.DiaChiDHN;
                ///
                dateDongNuoc.Value = _ctdongnuoc.NgayDN.Value;
                txtSoCongVan_DN.Text = _ctdongnuoc.SoCongVan_DN;
                dateCongVan_DN.Value = _ctdongnuoc.NgayCongVan_DN.Value;
                txtPhuong_DN.Text = _ctdongnuoc.Phuong;
                txtQuan_DN.Text = _ctdongnuoc.Quan;
                ///
                if (_ctdongnuoc.MoNuoc)
                {
                    dateMoNuoc.Value = _ctdongnuoc.NgayMN.Value;
                    txtSoCongVan_MN.Text = _ctdongnuoc.SoCongVan_MN;
                    dateCongVan_MN.Value = _ctdongnuoc.NgayCongVan_MN.Value;
                    txtLyDoDN.Text = _ctdongnuoc.LyDo_DN;
                    txtHinhThucDN.Text = _ctdongnuoc.HinhThuc_DN;
                    btnCapNhatMoNuoc.Enabled = false;
                }
                else
                {
                    btnCapNhatMoNuoc.Enabled = true;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctdongnuoc != null)
                {
                    if (txtMaThongBao_DN.Text.Trim().Replace("-", "") != "")
                        _ctdongnuoc.MaCTDN = decimal.Parse(txtMaThongBao_DN.Text.Trim().Replace("-", ""));

                    _ctdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                    _ctdongnuoc.HopDong = txtHopDong.Text.Trim();
                    _ctdongnuoc.HoTen = txtHoTen.Text.Trim();
                    _ctdongnuoc.DiaChi = txtDiaChi.Text.Trim();
                    if (_ttkhachhang != null)
                    {
                        _ctdongnuoc.Dot = _ttkhachhang.Dot;
                        _ctdongnuoc.Ky = _ttkhachhang.Ky;
                        _ctdongnuoc.Nam = _ttkhachhang.Nam;
                    }

                    _ctdongnuoc.DiaChiDHN = txtDiaChiDHN.Text.Trim();
                    _ctdongnuoc.NgayDN = dateDongNuoc.Value;
                    _ctdongnuoc.SoCongVan_DN = txtSoCongVan_DN.Text.Trim();
                    _ctdongnuoc.NgayCongVan_DN = dateCongVan_DN.Value;
                    _ctdongnuoc.Phuong = txtPhuong_DN.Text.Trim();
                    _ctdongnuoc.Quan = txtQuan_DN.Text.Trim();

                    if (_ctdongnuoc.MoNuoc)
                    {
                        _ctdongnuoc.NgayMN = dateMoNuoc.Value;
                        _ctdongnuoc.SoCongVan_MN = txtSoCongVan_MN.Text.Trim();
                        _ctdongnuoc.NgayCongVan_MN = dateCongVan_MN.Value;
                        _ctdongnuoc.LyDo_DN = txtLyDoDN.Text.Trim();
                        _ctdongnuoc.HinhThuc_DN = txtHinhThucDN.Text.Trim();
                    }

                    if (_cDongNuoc.SuaCTDongNuoc(_ctdongnuoc))
                    {
                        MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatMoNuoc_Click(object sender, EventArgs e)
        {
            if (_ctdongnuoc != null && _ctdongnuoc.MoNuoc == false && txtSoCongVan_MN.Text.Trim() != "")
            {
                if (txtMaThongBao_DN.Text.Trim().Replace("-", "") != "")
                    _ctdongnuoc.MaCTDN = decimal.Parse(txtMaThongBao_DN.Text.Trim().Replace("-", ""));

                _ctdongnuoc.MoNuoc = true;
                _ctdongnuoc.MaCTMN = _cDongNuoc.getMaxNextMaCTMN();
                _ctdongnuoc.SoCongVan_MN = txtSoCongVan_MN.Text.Trim();
                _ctdongnuoc.NgayCongVan_MN = dateCongVan_MN.Value;
                _ctdongnuoc.LyDo_DN = txtLyDoDN.Text.Trim();
                _ctdongnuoc.HinhThuc_DN = txtHinhThucDN.Text.Trim();

                ///Ký Tên
                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                    _ctdongnuoc.ChucVu_MN = "GIÁM ĐỐC";
                else
                    _ctdongnuoc.ChucVu_MN = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                _ctdongnuoc.NguoiKy_MN = bangiamdoc.HoTen.ToUpper();
                _ctdongnuoc.ThongBaoDuocKy_MN = true;

                if (_cDongNuoc.SuaCTDongNuoc(_ctdongnuoc))
                {
                    MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnInTBDN_Click(object sender, EventArgs e)
        {
            if (_ctdongnuoc != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoDongNuoc"].NewRow();

                dr["SoPhieu"] = _ctdongnuoc.MaCTDN.ToString().Insert(_ctdongnuoc.MaCTDN.ToString().Length - 2, "-");
                dr["HoTen"] = _ctdongnuoc.HoTen;
                dr["DiaChi"] = _ctdongnuoc.DiaChi;
                if (!string.IsNullOrEmpty(_ctdongnuoc.DanhBo))
                    dr["DanhBo"] = _ctdongnuoc.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HopDong"] = _ctdongnuoc.HopDong;
                dr["DiaChiDHN"] = _ctdongnuoc.DiaChiDHN;
                ///
                dr["NgayXuLy"] = _ctdongnuoc.NgayDN.Value.ToString("dd/MM/yyyy");
                dr["SoCongVan"] = _ctdongnuoc.SoCongVan_DN;
                dr["NgayCongVan"] = _ctdongnuoc.NgayCongVan_DN.Value.ToString("dd/MM/yyyy");
                dr["Phuong"] = _ctdongnuoc.Phuong;
                dr["Quan"] = _ctdongnuoc.Quan;
                ///
                dr["ChucVu"] = _ctdongnuoc.ChucVu_DN;
                dr["NguoiKy"] = _ctdongnuoc.NguoiKy_DN;

                dsBaoCao.Tables["ThongBaoDongNuoc"].Rows.Add(dr);

                rptThongBaoDN rpt = new rptThongBaoDN();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Chưa có Thông Báo Đóng Nước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInTBMN_Click(object sender, EventArgs e)
        {
            if (_ctdongnuoc != null && _ctdongnuoc.MoNuoc == true)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoDongNuoc"].NewRow();

                dr["SoPhieu"] = _ctdongnuoc.MaCTMN.ToString().Insert(_ctdongnuoc.MaCTMN.ToString().Length - 2, "-");
                dr["HoTen"] = _ctdongnuoc.HoTen;
                dr["DiaChi"] = _ctdongnuoc.DiaChi;
                if (!string.IsNullOrEmpty(_ctdongnuoc.DanhBo))
                dr["DanhBo"] = _ctdongnuoc.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HopDong"] = _ctdongnuoc.HopDong;
                dr["DiaChiDHN"] = _ctdongnuoc.DiaChiDHN;
                ///
                dr["NgayXuLy"] = _ctdongnuoc.NgayMN.Value.ToString("dd/MM/yyyy");
                dr["SoCongVan"] = _ctdongnuoc.SoCongVan_MN;
                dr["NgayCongVan"] = _ctdongnuoc.NgayCongVan_MN.Value.ToString("dd/MM/yyyy");
                dr["Phuong"] = _ctdongnuoc.Phuong;
                dr["Quan"] = _ctdongnuoc.Quan;
                dr["LyDo"] = _ctdongnuoc.LyDo_DN;
                dr["HinhThuc"] = _ctdongnuoc.HinhThuc_DN;
                dr["SoPhieuDN"] = _ctdongnuoc.MaCTDN.ToString().Insert(_ctdongnuoc.MaCTDN.ToString().Length - 2, "-");
                ///
                dr["ChucVu"] = _ctdongnuoc.ChucVu_MN;
                dr["NguoiKy"] = _ctdongnuoc.NguoiKy_MN;

                dsBaoCao.Tables["ThongBaoDongNuoc"].Rows.Add(dr);

                rptThongBaoMN rpt = new rptThongBaoMN();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Chưa có Thông Báo Đóng Nước/Nội Dung Mở Nước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtDanhBo.Text = "";
                    txtHopDong.Text = "";
                    txtHoTen.Text = "";
                    txtDiaChi.Text = "";
                    txtDiaChiDHN.Text = "";
                    _ttkhachhang = null;
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
