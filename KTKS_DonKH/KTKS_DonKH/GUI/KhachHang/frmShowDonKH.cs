using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.DAL.HeThong;
using KTKS_DonKH.BaoCao.KhachHang;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.KhachHang;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmShowDonKH : Form
    {
        CLoaiDon _cLoaiDon = new CLoaiDon();
        DonKH _donkh = null;
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CDonKH _cDonKH = new CDonKH();
        CTTKH _cTTKH=new CTTKH();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();

        public frmShowDonKH()
        {
            InitializeComponent();
        }

        public frmShowDonKH(Dictionary<string, string> source)
        {
            _source = source;
            InitializeComponent();
        }

        private void frmShowDonKH_Load(object sender, EventArgs e)
        {
            if (_cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"])) != null)
            {
                _donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"]));
                cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon(true);
                cmbLD.DisplayMember = "TenLD";
                cmbLD.ValueMember = "MaLD";

                cmbLD.SelectedValue = _donkh.MaLD.Value;
                txtSoCongVan.Text = _donkh.SoCongVan;
                txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                txtNgayNhan.Text = _donkh.CreateDate.Value.ToString("dd/MM/yyyy");
                txtNoiDung.Text = _donkh.NoiDung;

                if (_donkh.KiemTraDHN)
                    chkKiemTraDHN.Checked = true;
                if (_donkh.TienNuoc)
                    chkTienNuoc.Checked = true;
                if (_donkh.ChiSoNuoc)
                    chkChiSoNuoc.Checked = true;
                if (_donkh.DonGiaNuoc)
                    chkDonGiaNuoc.Checked = true;
                if (_donkh.SangTen)
                    chkSangTen.Checked = true;
                if (_donkh.DangKyDM)
                    chkDangKyDM.Checked = true;
                if (_donkh.CatChuyenDM)
                    chkCatChuyenDM.Checked = true;
                if (_donkh.NuocDuc)
                    chkNuocDuc.Checked = true;
                if (_donkh.LoaiKhac)
                    chkLyDoKhac.Checked = true;

                txtLyDoKhac.Text = _donkh.LyDoLoaiKhac;
                txtDanhBo.Text = _donkh.DanhBo;
                txtHopDong.Text = _donkh.HopDong;
                txtDienThoai.Text = _donkh.DienThoai;
                txtKhachHang.Text = _donkh.HoTen;
                txtDiaChi.Text = _donkh.DiaChi;
                txtMSThue.Text = _donkh.MSThue;
                txtGiaBieu.Text = _donkh.GiaBieu;
                txtDinhMuc.Text = _donkh.DinhMuc;
                txtGhiChu.Text = _donkh.GhiChu;

                if (_donkh.CT_HoaDon)
                    chkCT_HoaDon.Checked = true;
                if (_donkh.CT_HK_KT3)
                    chkCT_HK_KT3.Checked = true;
                if (_donkh.CT_STT_GXNTT)
                    chkCT_STT_GXNTT.Checked = true;
                if (_donkh.CT_HDTN_CQN)
                    chkCT_HDTN_CQN.Checked = true;
                if (_donkh.CT_GC_SDSN)
                    chkCT_GC_SDSN.Checked = true;
                if (_donkh.CT_GXN2SN)
                    chkCT_GXN2SN.Checked = true;
                if (_donkh.CT_GDKKD)
                    chkCT_GDKKD.Checked = true;
                if (_donkh.CT_GCNDTDHN)
                    chkCT_GCNDTDHN.Checked = true;

                txtDinhMucSau.Text = _donkh.DinhMucSau;
                txtHieuLucTuKy.Text = _donkh.HieuLucTuKy;

                if (_source["Action"] == "Cập Nhật")
                {
                    btnSua.Visible = true;
                    btnXoa.Visible = true;
                }
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                if (ttkhachhang != null)
                {
                    txtHopDong.Text = ttkhachhang.GiaoUoc;
                    txtKhachHang.Text = ttkhachhang.HoTen;
                    txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
                    txtMSThue.Text = ttkhachhang.MSThue;
                    txtGiaBieu.Text = ttkhachhang.GB;
                    txtDinhMuc.Text = ttkhachhang.TGDM;
                    //SH = ttkhachhang.SH;
                    //SX = ttkhachhang.SX;
                    //DV = ttkhachhang.DV;
                    //HCSN = ttkhachhang.HCSN;
                    //Dot = ttkhachhang.Dot;
                    //Ky = ttkhachhang.Ky;
                    //Nam = ttkhachhang.Nam;
                }
            }
        }

        private void chkLyDoKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLyDoKhac.Checked)
                txtLyDoKhac.ReadOnly = false;
            else
                txtLyDoKhac.ReadOnly = true;
        }

        private void btnInBienNhan_Click(object sender, EventArgs e)
        {
            if (_donkh != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                dr["MaDon"] = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                dr["TenLD"] = _donkh.LoaiDon.TenLD;
                dr["KhachHang"] = _donkh.HoTen;
                if (_donkh.DanhBo != "")
                    dr["DanhBo"] = _donkh.DanhBo.Insert(4, ".").Insert(8, ".");
                dr["DiaChi"] = _donkh.DiaChi;
                dr["HopDong"] = _donkh.HopDong;
                dr["DienThoai"] = _donkh.DienThoai;

                #region CheckBox
                if (_donkh.KiemTraDHN)
                {
                    dr["KiemTraDHN"] = true;
                }
                else
                {
                    dr["KiemTraDHN"] = false;
                }

                if (_donkh.TienNuoc)
                {
                    dr["TienNuoc"] = true;
                }
                else
                {
                    dr["TienNuoc"] = false;
                }

                if (_donkh.ChiSoNuoc)
                {
                    dr["ChiSoNuoc"] = true;
                }
                else
                {
                    dr["ChiSoNuoc"] = false;
                }

                if (_donkh.DonGiaNuoc)
                {
                    dr["DonGiaNuoc"] = true;
                }
                else
                {
                    dr["DonGiaNuoc"] = false;
                }

                if (_donkh.SangTen)
                {
                    dr["SangTen"] = true;
                }
                else
                {
                    dr["SangTen"] = false;
                }

                if (_donkh.DangKyDM)
                {
                    dr["DangKyDM"] = true;
                }
                else
                {
                    dr["DangKyDM"] = false;
                }

                if (_donkh.CatChuyenDM)
                {
                    dr["CatChuyenDM"] = true;
                }
                else
                {
                    dr["CatChuyenDM"] = false;
                }

                if (_donkh.NuocDuc)
                {
                    dr["NuocDuc"] = true;
                }
                else
                {
                    dr["NuocDuc"] = false;
                }

                if (_donkh.LoaiKhac)
                {
                    dr["LoaiKhac"] = true;
                    dr["LyDoLoaiKhac"] = _donkh.LyDoLoaiKhac;
                }
                else
                {
                    dr["LoaiKhac"] = false;
                }

                if (_donkh.CT_HoaDon)
                {
                    dr["CT_HoaDon"] = true;
                }
                else
                {
                    dr["CT_HoaDon"] = false;
                }

                if (_donkh.CT_HK_KT3)
                {
                    dr["CT_HK_KT3"] = true;
                }
                else
                {
                    dr["CT_HK_KT3"] = false;
                }

                if (_donkh.CT_STT_GXNTT)
                {
                    dr["CT_STT_GXNTT"] = true;
                }
                else
                {
                    dr["CT_STT_GXNTT"] = false;
                }

                if (_donkh.CT_HDTN_CQN)
                {
                    dr["CT_HDTN_CQN"] = true;
                }
                else
                {
                    dr["CT_HDTN_CQN"] = false;
                }

                if (_donkh.CT_GC_SDSN)
                {
                    dr["CT_GC_SDSN"] = true;
                }
                else
                {
                    dr["CT_GC_SDSN"] = false;
                }

                if (_donkh.CT_GXN2SN)
                {
                    dr["CT_GXN2SN"] = true;
                }
                else
                {
                    dr["CT_GXN2SN"] = false;
                }

                if (_donkh.CT_GDKKD)
                {
                    dr["CT_GDKKD"] = true;
                }
                else
                {
                    dr["CT_GDKKD"] = false;
                }

                if (_donkh.CT_GCNDTDHN)
                {
                    dr["CT_GCNDTDHN"] = true;
                }
                else
                {
                    dr["CT_GCNDTDHN"] = false;
                }
                #endregion

                dr["DinhMucSau"] = _donkh.DinhMucSau;
                dr["HieuLucTuKy"] = _donkh.HieuLucTuKy;
                CTaiKhoan _cTaiKhoan = new CTaiKhoan();
                dr["HoTenNV"] = _cTaiKhoan.getHoTenUserbyTaiKhoan(_donkh.CreateBy);
                
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
                rptBienNhanDonKH rpt = new rptBienNhanDonKH();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_donkh != null)
            {
                _donkh.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                _donkh.SoCongVan = txtSoCongVan.Text.Trim();
                _donkh.DanhBo = txtDanhBo.Text.Trim();
                _donkh.HopDong = txtHopDong.Text.Trim();
                _donkh.HoTen = txtKhachHang.Text.Trim();
                _donkh.DiaChi = txtDiaChi.Text.Trim();
                _donkh.DienThoai = txtDienThoai.Text.Trim();
                _donkh.MSThue = txtMSThue.Text.Trim();
                _donkh.GiaBieu = txtGiaBieu.Text.Trim();
                _donkh.DinhMuc = txtDinhMuc.Text.Trim();
                //donkh.SH = SH;
                //donkh.SX = SX;
                //donkh.DV = DV;
                //donkh.HCSN = HCSN;
                //donkh.Dot = Dot;
                //donkh.Ky = Ky;
                //donkh.Nam = Nam;
                _donkh.NoiDung = txtNoiDung.Text.Trim();
                _donkh.GhiChu = txtGhiChu.Text.Trim();
                _donkh.DinhMucSau = txtDinhMucSau.Text.Trim();
                _donkh.HieuLucTuKy = txtHieuLucTuKy.Text.Trim();

                #region CheckBox
                if (chkKiemTraDHN.Checked)
                    _donkh.KiemTraDHN = true;

                if (chkTienNuoc.Checked)
                    _donkh.TienNuoc = true;

                if (chkChiSoNuoc.Checked)
                    _donkh.ChiSoNuoc = true;

                if (chkDonGiaNuoc.Checked)
                    _donkh.DonGiaNuoc = true;

                if (chkSangTen.Checked)
                    _donkh.SangTen = true;

                if (chkDangKyDM.Checked)
                    _donkh.DangKyDM = true;

                if (chkCatChuyenDM.Checked)
                    _donkh.CatChuyenDM = true;

                if (chkNuocDuc.Checked)
                    _donkh.NuocDuc = true;

                if (chkLyDoKhac.Checked)
                {
                    _donkh.LoaiKhac = true;
                    _donkh.LyDoLoaiKhac = txtLyDoKhac.Text.Trim();
                }

                if (chkCT_HoaDon.Checked)
                    _donkh.CT_HoaDon = true;

                if (chkCT_HK_KT3.Checked)
                    _donkh.CT_HK_KT3 = true;

                if (chkCT_STT_GXNTT.Checked)
                    _donkh.CT_STT_GXNTT = true;

                if (chkCT_HDTN_CQN.Checked)
                    _donkh.CT_HDTN_CQN = true;

                if (chkCT_GC_SDSN.Checked)
                    _donkh.CT_GC_SDSN = true;

                if (chkCT_GXN2SN.Checked)
                    _donkh.CT_GXN2SN = true;

                if (chkCT_GDKKD.Checked)
                    _donkh.CT_GDKKD = true;

                if (chkCT_GCNDTDHN.Checked)
                    _donkh.CT_GCNDTDHN = true;

                #endregion

                if (_cDonKH.SuaDonKH(_donkh))
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                    dr["MaDon"] = txtMaDon.Text.Trim();
                    dr["TenLD"] = cmbLD.Text;
                    dr["KhachHang"] = txtKhachHang.Text.Trim();
                    if (txtDanhBo.Text.Trim() != "")
                        dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, ".").Insert(4, ".");
                    dr["DiaChi"] = txtDiaChi.Text.Trim();
                    dr["HopDong"] = txtHopDong.Text.Trim();
                    dr["DienThoai"] = txtDienThoai.Text.Trim();

                    #region CheckBox
                    if (_donkh.KiemTraDHN)
                    {
                        dr["KiemTraDHN"] = true;
                    }
                    else
                    {
                        dr["KiemTraDHN"] = false;
                    }

                    if (_donkh.TienNuoc)
                    {
                        dr["TienNuoc"] = true;
                    }
                    else
                    {
                        dr["TienNuoc"] = false;
                    }

                    if (_donkh.ChiSoNuoc)
                    {
                        dr["ChiSoNuoc"] = true;
                    }
                    else
                    {
                        dr["ChiSoNuoc"] = false;
                    }

                    if (_donkh.DonGiaNuoc)
                    {
                        dr["DonGiaNuoc"] = true;
                    }
                    else
                    {
                        dr["DonGiaNuoc"] = false;
                    }

                    if (_donkh.SangTen)
                    {
                        dr["SangTen"] = true;
                    }
                    else
                    {
                        dr["SangTen"] = false;
                    }

                    if (_donkh.DangKyDM)
                    {
                        dr["DangKyDM"] = true;
                    }
                    else
                    {
                        dr["DangKyDM"] = false;
                    }

                    if (_donkh.CatChuyenDM)
                    {
                        dr["CatChuyenDM"] = true;
                    }
                    else
                    {
                        dr["CatChuyenDM"] = false;
                    }

                    if (_donkh.NuocDuc)
                    {
                        dr["NuocDuc"] = true;
                    }
                    else
                    {
                        dr["NuocDuc"] = false;
                    }

                    if (_donkh.LoaiKhac)
                    {
                        dr["LoaiKhac"] = true;
                        dr["LyDoLoaiKhac"] = _donkh.LyDoLoaiKhac;
                    }
                    else
                    {
                        dr["LoaiKhac"] = false;
                    }

                    if (_donkh.CT_HoaDon)
                    {
                        dr["CT_HoaDon"] = true;
                    }
                    else
                    {
                        dr["CT_HoaDon"] = false;
                    }

                    if (_donkh.CT_HK_KT3)
                    {
                        dr["CT_HK_KT3"] = true;
                    }
                    else
                    {
                        dr["CT_HK_KT3"] = false;
                    }

                    if (_donkh.CT_STT_GXNTT)
                    {
                        dr["CT_STT_GXNTT"] = true;
                    }
                    else
                    {
                        dr["CT_STT_GXNTT"] = false;
                    }

                    if (_donkh.CT_HDTN_CQN)
                    {
                        dr["CT_HDTN_CQN"] = true;
                    }
                    else
                    {
                        dr["CT_HDTN_CQN"] = false;
                    }

                    if (_donkh.CT_GC_SDSN)
                    {
                        dr["CT_GC_SDSN"] = true;
                    }
                    else
                    {
                        dr["CT_GC_SDSN"] = false;
                    }

                    if (_donkh.CT_GXN2SN)
                    {
                        dr["CT_GXN2SN"] = true;
                    }
                    else
                    {
                        dr["CT_GXN2SN"] = false;
                    }

                    if (_donkh.CT_GDKKD)
                    {
                        dr["CT_GDKKD"] = true;
                    }
                    else
                    {
                        dr["CT_GDKKD"] = false;
                    }

                    if (_donkh.CT_GCNDTDHN)
                    {
                        dr["CT_GCNDTDHN"] = true;
                    }
                    else
                    {
                        dr["CT_GCNDTDHN"] = false;
                    }
                    #endregion

                    dr["DinhMucSau"] = txtDinhMucSau.Text.Trim();
                    dr["HieuLucTuKy"] = txtHieuLucTuKy.Text.Trim();
                    dr["HoTenNV"] = CTaiKhoan.HoTen;
                    dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
                    rptBienNhanDonKH rpt = new rptBienNhanDonKH();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_donkh != null)
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_cDonKH.XoaDonKH(_donkh))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                
        }

       
    }
}
