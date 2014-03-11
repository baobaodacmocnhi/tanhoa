using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmSoDK : Form
    {
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        CChiNhanh _cChiNhanh = new CChiNhanh();
        Dictionary<string, string> _source = new Dictionary<string, string>();
        string _action = "";
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();

        public frmSoDK()
        {
            InitializeComponent();
        }

        public frmSoDK(string action, Dictionary<string, string> source)
        {
            InitializeComponent();
            ///Check để chọn chức năng Thêm hoặc Sửa
            _action = action;
            if (action == "Thêm")
            {
                cmbLoaiCT.Enabled = true;
                txtMaCT.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtSoNKTong.ReadOnly = false;
                txtSoNKDangKy.ReadOnly = false;
                txtThoiHan.ReadOnly = false;
                txtGhiChu.ReadOnly = false;
                btnThem.Enabled = true;
            }
            else
                if (action == "Sửa")
                {
                    //txtDiaChi.ReadOnly = false;
                    txtSoNKTong.ReadOnly = false;
                    txtSoNKDangKy.ReadOnly = false;
                    txtThoiHan.ReadOnly = false;
                    txtGhiChu.ReadOnly = false;
                    btnSua.Enabled = true;

                    CTChungTu ctchungtu = _cChungTu.getCTChungTubyID(_source["DanhBo"], _source["MaCT"]);
                    if (ctchungtu.YeuCauCat)
                    {
                        chkYCCat1.Checked = true;
                        cmbChiNhanh_YCC1.SelectedValue = ctchungtu.CatNK_MaCN;
                        txtDanhBo_Cat_YCC1.Text = ctchungtu.CatNK_DanhBo;
                        txtHoTen_Cat_YCC1.Text = ctchungtu.CatNK_HoTen;
                        txtDiaChiKH_Cat_YCC1.Text = ctchungtu.CatNK_DiaChi;
                        txtSoNKCat_YCC1.Text = ctchungtu.CatNK_SoNKCat.ToString();
                    }
                }
            _source = source;
        }

        private void frmSoDK_Load(object sender, EventArgs e)
        {
            try
            {
                this.Location = new Point(70, 70);
                cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
                cmbLoaiCT.DisplayMember = "TenLCT";
                cmbLoaiCT.ValueMember = "MaLCT";

                txtDanhBo.Text = _source["DanhBo"];
                cmbLoaiCT.SelectedValue = _cLoaiChungTu.getMaLCTbyTenLCT(_source["TenLCT"]);
                txtMaCT.Text = _source["MaCT"];
                txtDiaChi.Text = _source["DiaChi"];
                txtSoNKTong.Text = _source["SoNKTong"];
                txtSoNKDangKy.Text = _source["SoNKDangKy"];
                txtThoiHan.Text = _source["ThoiHan"];

                cmbChiNhanh_YCC1.DataSource = _cChiNhanh.LoadDSChiNhanh(true, "Tân Hòa");
                cmbChiNhanh_YCC1.DisplayMember = "TenCN";
                cmbChiNhanh_YCC1.ValueMember = "MaCN";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaCT.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "0" && txtSoNKDangKy.Text.Trim() != "0")
                    if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKDangKy.Text.Trim()))
                    {
                        ChungTu chungtu = new ChungTu();
                        chungtu.MaCT = txtMaCT.Text.Trim();
                        chungtu.DiaChi = txtDiaChi.Text.Trim();
                        chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());
                        chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());

                        CTChungTu ctchungtu = new CTChungTu();
                        ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                        ctchungtu.MaCT = txtMaCT.Text.Trim();
                        ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                        if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                            ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                        else
                            ctchungtu.ThoiHan = null;

                        LichSuChungTu lichsuchungtu = new LichSuChungTu();
                        lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);
                        lichsuchungtu.GhiChu = txtGhiChu.Text.Trim();

                        if (chkYCCat1.Checked)
                            if (txtSoNKCat_YCC1.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC1", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                /////Cập nhật cái mới nhất(cuối cùng)
                                //chungtu.YeuCauCat = true;
                                //chungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                                //chungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                                //chungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                                //chungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                                //chungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                                ///Chi tiết liên quan đến Danh Bộ nào
                                ctchungtu.YeuCauCat = true;
                                ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                                ctchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                                ctchungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                                ctchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                                ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                                ctchungtu.SoLuongDC_YCC = 1;
                                ///
                                lichsuchungtu.NhanDM = true;
                                lichsuchungtu.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                lichsuchungtu.NhanNK_HoTen = _source["HoTenKH"];
                                lichsuchungtu.NhanNK_DiaChi = _source["DiaChiKH"];
                                lichsuchungtu.PhieuDuocKy = true;
                                //lichsuchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                //lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                //lichsuchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                //lichsuchungtu.CatNK_DiaChi = txtDiaChiKH_Cat.Text.Trim();
                                //lichsuchungtu.SoNKNhan = int.Parse(txtSoNKCat.Text.Trim());
                                /////Ký Tên
                                //BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                //if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                //    lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                                //else
                                //    lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                //lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            }

                        #region Yêu Cầu Cắt 2,3,4,5

                        if (chkYCCat2.Checked)
                        {
                            List<LichSuChungTu> lstLichSuChungTu = new List<LichSuChungTu>();
                            if (txtSoNKCat_YCC2.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC2", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                LichSuChungTu lichsuchungtu2 = lichsuchungtu;
                                ///Chi tiết liên quan đến Danh Bộ nào
                                ctchungtu.YeuCauCat2 = true;
                                ctchungtu.CatNK_MaCN2 = int.Parse(cmbChiNhanh_YCC2.SelectedValue.ToString());
                                ctchungtu.CatNK_DanhBo2 = txtDanhBo_Cat_YCC2.Text.Trim();
                                ctchungtu.CatNK_HoTen2 = txtHoTen_Cat_YCC2.Text.Trim();
                                ctchungtu.CatNK_DiaChi2 = txtDiaChiKH_Cat_YCC2.Text.Trim();
                                ctchungtu.CatNK_SoNKCat2 = int.Parse(txtSoNKCat_YCC2.Text.Trim());
                                ctchungtu.SoLuongDC_YCC = 2;
                                ///
                                lichsuchungtu2.NhanDM = true;
                                lichsuchungtu2.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                lichsuchungtu2.NhanNK_HoTen = _source["HoTenKH"];
                                lichsuchungtu2.NhanNK_DiaChi = _source["DiaChiKH"];
                                lichsuchungtu2.PhieuDuocKy = true;
                                ///
                                lstLichSuChungTu.Add(lichsuchungtu2);
                            }

                            if (chkYCCat3.Checked)
                                if (txtSoNKCat_YCC3.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC3", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    LichSuChungTu lichsuchungtu3 = lichsuchungtu;
                                    ///Chi tiết liên quan đến Danh Bộ nào
                                    ctchungtu.YeuCauCat3 = true;
                                    ctchungtu.CatNK_MaCN3 = int.Parse(cmbChiNhanh_YCC3.SelectedValue.ToString());
                                    ctchungtu.CatNK_DanhBo3 = txtDanhBo_Cat_YCC3.Text.Trim();
                                    ctchungtu.CatNK_HoTen3 = txtHoTen_Cat_YCC3.Text.Trim();
                                    ctchungtu.CatNK_DiaChi3 = txtDiaChiKH_Cat_YCC3.Text.Trim();
                                    ctchungtu.CatNK_SoNKCat3 = int.Parse(txtSoNKCat_YCC3.Text.Trim());
                                    ctchungtu.SoLuongDC_YCC = 3;
                                    ///
                                    lichsuchungtu3.NhanDM = true;
                                    lichsuchungtu3.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu3.NhanNK_HoTen = _source["HoTenKH"];
                                    lichsuchungtu3.NhanNK_DiaChi = _source["DiaChiKH"];
                                    lichsuchungtu3.PhieuDuocKy = true;
                                    ///
                                    lstLichSuChungTu.Add(lichsuchungtu3);
                                }

                            if (chkYCCat4.Checked)
                                if (txtSoNKCat_YCC4.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC4", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    LichSuChungTu lichsuchungtu4 = lichsuchungtu;
                                    ///Chi tiết liên quan đến Danh Bộ nào
                                    ctchungtu.YeuCauCat4 = true;
                                    ctchungtu.CatNK_MaCN4 = int.Parse(cmbChiNhanh_YCC4.SelectedValue.ToString());
                                    ctchungtu.CatNK_DanhBo4 = txtDanhBo_Cat_YCC4.Text.Trim();
                                    ctchungtu.CatNK_HoTen4 = txtHoTen_Cat_YCC4.Text.Trim();
                                    ctchungtu.CatNK_DiaChi4 = txtDiaChiKH_Cat_YCC4.Text.Trim();
                                    ctchungtu.CatNK_SoNKCat4 = int.Parse(txtSoNKCat_YCC4.Text.Trim());
                                    ctchungtu.SoLuongDC_YCC = 4;
                                    ///
                                    lichsuchungtu4.NhanDM = true;
                                    lichsuchungtu4.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu4.NhanNK_HoTen = _source["HoTenKH"];
                                    lichsuchungtu4.NhanNK_DiaChi = _source["DiaChiKH"];
                                    lichsuchungtu4.PhieuDuocKy = true;
                                    ///
                                    lstLichSuChungTu.Add(lichsuchungtu4);
                                }

                            if (chkYCCat5.Checked)
                                if (txtSoNKCat_YCC5.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    LichSuChungTu lichsuchungtu5 = lichsuchungtu;
                                    ///Chi tiết liên quan đến Danh Bộ nào
                                    ctchungtu.YeuCauCat5 = true;
                                    ctchungtu.CatNK_MaCN5 = int.Parse(cmbChiNhanh_YCC5.SelectedValue.ToString());
                                    ctchungtu.CatNK_DanhBo5 = txtDanhBo_Cat_YCC5.Text.Trim();
                                    ctchungtu.CatNK_HoTen5 = txtHoTen_Cat_YCC5.Text.Trim();
                                    ctchungtu.CatNK_DiaChi5 = txtDiaChiKH_Cat_YCC5.Text.Trim();
                                    ctchungtu.CatNK_SoNKCat5 = int.Parse(txtSoNKCat_YCC5.Text.Trim());
                                    ctchungtu.SoLuongDC_YCC = 5;
                                    ///
                                    lichsuchungtu5.NhanDM = true;
                                    lichsuchungtu5.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu5.NhanNK_HoTen = _source["HoTenKH"];
                                    lichsuchungtu5.NhanNK_DiaChi = _source["DiaChiKH"];
                                    lichsuchungtu5.PhieuDuocKy = true;
                                    ///
                                    lstLichSuChungTu.Add(lichsuchungtu5);
                                }
                            if (_cChungTu.ThemChungTu(chungtu, ctchungtu, lichsuchungtu, lstLichSuChungTu))
                            {
                                MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }

                        #endregion

                        if (!chkYCCat2.Checked)
                            if (_cChungTu.ThemChungTu(chungtu, ctchungtu, lichsuchungtu))
                            {
                                MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //if (chkCatChuyen.Checked)
                                //{
                                //    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                //    DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                //    dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                //    dr["ChiNhanh"] = ((ChiNhanh)cmbChiNhanh.SelectedItem).TenCN;
                                //    dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo;
                                //    dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                //    dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                //    dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo;
                                //    dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                //    dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                //    ///có thể sai MaCT, nếu sai đổi lại lấy txtMaCT
                                //    dr["SoNKCat"] = lichsuchungtu.SoNKNhan.ToString() + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                //    dr["ChucVu"] = lichsuchungtu.ChucVu;
                                //    dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                //    dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                //    rptPhieuYCCatDM rpt = new rptPhieuYCCatDM();
                                //    rpt.SetDataSource(dsBaoCao);
                                //    frmBaoCao frm = new frmBaoCao(rpt);
                                //    frm.ShowDialog();
                                //}
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                    }
                    else
                        MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txtSoNKTong.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "")
                    if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKDangKy.Text.Trim()))
                    {
                        ChungTu chungtu = new ChungTu();
                        chungtu.MaCT = txtMaCT.Text.Trim();
                        //chungtu.DiaChi = txtDiaChi.Text.Trim();
                        chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());

                        CTChungTu ctchungtu = new CTChungTu();
                        ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                        ctchungtu.MaCT = txtMaCT.Text.Trim();
                        ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                        if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                            ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                        else
                            ctchungtu.ThoiHan = null;

                        LichSuChungTu lichsuchungtu = new LichSuChungTu();
                        lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);
                        lichsuchungtu.GhiChu = txtGhiChu.Text.Trim();

                        if (chkYCCat1.Checked)
                            if (txtSoNKCat_YCC1.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                /////Cập nhật cái mới nhất(cuối cùng)
                                //chungtu.YeuCauCat = true;
                                //chungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                                //chungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                                //chungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                                //chungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                                //chungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                                ///Chi tiết liên quan đến Danh Bộ nào
                                ctchungtu.YeuCauCat = true;
                                ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                                ctchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                                ctchungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                                ctchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                                ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                            }
                        else
                        {
                            chungtu.YeuCauCat = false;
                            ctchungtu.YeuCauCat = false;
                        }

                        if (_cChungTu.SuaChungTu(chungtu, ctchungtu, lichsuchungtu))
                        {
                            MessageBox.Show("SửaThành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void cmbLoaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_action == "Thêm" && cmbLoaiCT.SelectedIndex != -1)
            {
                txtThoiHan.Text = ((KTKS_DonKH.LinQ.LoaiChungTu)cmbLoaiCT.SelectedItem).ThoiHan.ToString();
            }
        }  

        #region Configure TextBox

        private void txtMaCT_Leave(object sender, EventArgs e)
        {
            if (_cChungTu.CheckCTChungTu(txtDanhBo.Text.Trim(), txtMaCT.Text.Trim()))
                MessageBox.Show("Số đăng ký này đã đăng ký với danh bạ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                if (_cChungTu.CheckChungTu(txtMaCT.Text.Trim()))
                    MessageBox.Show("Số đăng ký này đã có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtMaCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //    e.Handled = true;
            if (e.KeyChar == 13)
                txtDiaChi.Focus();
        }

        private void txtSoNKTong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtSoNKDangKy.Focus();
        }

        private void txtSoNKDangKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtThoiHan.Focus();
        }

        private void txtThoiHan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtGhiChu.Focus();
        }

        private void chkCatChuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYCCat1.Checked)
                groupBox1.Enabled = true;
            else
                groupBox1.Enabled = false;
        }

        private void txtSoNKCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btnThem.Focus();
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoNKTong.Focus();
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnThem.Focus();
        }

        private void txtDanhBo_Cat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen_Cat_YCC1.Focus();
        }

        private void txtHoTen_Cat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChiKH_Cat_YCC1.Focus();
        }

        private void txtDiaChiKH_Cat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoNKCat_YCC1.Focus();
        }

        #endregion

        private void btnYCCat_Click(object sender, EventArgs e)
        {
            if (!panel_YCCat2.Visible)
            {
                panel_YCCat2.Visible = true;
                this.Size = new Size(1340, 356);
                this.Location = new Point(70, 40);
            }
            else
                if (!panel_YCCat3.Visible)
                {
                    panel_YCCat3.Visible = true;
                    this.Size = new Size(1340, 477);
                }
                else
                    if (!panel_YCCat4.Visible)
                    {
                        panel_YCCat4.Visible = true;
                        this.Size = new Size(1340, 477);
                    }
                    else
                        if (!panel_YCCat5.Visible)
                        {
                            panel_YCCat5.Visible = true;
                            this.Size = new Size(1370, 515);
                        }
                        else
                        {
                            panel_YCCat2.Visible = false;
                            panel_YCCat3.Visible = false;
                            panel_YCCat4.Visible = false;
                            panel_YCCat5.Visible = false;
                            this.Size = new Size(919, 298);
                            this.Location = new Point(70,70);
                        }

        }
    }
}
