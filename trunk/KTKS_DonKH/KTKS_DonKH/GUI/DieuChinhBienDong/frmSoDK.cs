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
                        chkCatChuyen.Checked = true;
                        cmbChiNhanh.SelectedValue = ctchungtu.CatNK_MaCN;
                        txtDanhBo_Cat.Text = ctchungtu.CatNK_DanhBo;
                        txtHoTen_Cat.Text = ctchungtu.CatNK_HoTen;
                        txtDiaChiKH_Cat.Text = ctchungtu.CatNK_DiaChi;
                        txtSoNKCat.Text = ctchungtu.CatNK_SoNKCat.ToString();
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

                cmbChiNhanh.DataSource = _cChiNhanh.LoadDSChiNhanh(true, "Tân Hòa");
                cmbChiNhanh.DisplayMember = "TenCN";
                cmbChiNhanh.ValueMember = "MaCN";
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

                        if (chkCatChuyen.Checked)
                            if (txtSoNKCat.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                ///Cập nhật cái mới nhất(cuối cùng)
                                chungtu.YeuCauCat = true;
                                chungtu.CatNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                chungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                chungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                chungtu.CatNK_DiaChi = txtDiaChiKH_Cat.Text.Trim();
                                chungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat.Text.Trim());
                                ///Chi tiết liên quan đến Danh Bộ nào
                                ctchungtu.YeuCauCat = true;
                                ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                ctchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                ctchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                ctchungtu.CatNK_DiaChi = txtDiaChiKH_Cat.Text.Trim();
                                ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat.Text.Trim());
                                ///
                                lichsuchungtu.NhanDM = true;
                                lichsuchungtu.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                lichsuchungtu.NhanNK_HoTen = _source["HoTenKH"];
                                lichsuchungtu.NhanNK_DiaChi = _source["DiaChiKH"];
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

                        if (chkCatChuyen.Checked)
                            if (txtSoNKCat.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                ///Cập nhật cái mới nhất(cuối cùng)
                                chungtu.YeuCauCat = true;
                                chungtu.CatNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                chungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                chungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                chungtu.CatNK_DiaChi = txtDiaChiKH_Cat.Text.Trim();
                                chungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat.Text.Trim());
                                ///Chi tiết liên quan đến Danh Bộ nào
                                ctchungtu.YeuCauCat = true;
                                ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                ctchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                ctchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                ctchungtu.CatNK_DiaChi = txtDiaChiKH_Cat.Text.Trim();
                                ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat.Text.Trim());
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
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
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
            if (chkCatChuyen.Checked)
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
                txtHoTen_Cat.Focus();
        }

        private void txtHoTen_Cat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChiKH_Cat.Focus();
        }

        private void txtDiaChiKH_Cat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoNKCat.Focus();
        }

        #endregion
    }
}
