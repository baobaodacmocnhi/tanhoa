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
        DataSetBaoCao dsBaoCao = new DataSetBaoCao();
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
                btnThem.Enabled = true;
            }
            else
                if (action == "Sửa")
                {
                    //txtDiaChi.ReadOnly = false;
                    txtSoNKTong.ReadOnly = false;
                    txtSoNKDangKy.ReadOnly = false;
                    txtThoiHan.ReadOnly = false;
                    btnSua.Enabled = true;
                }
            _source = source;
        }

        private void frmSoDK_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            cmbLoaiCT.DisplayMember = "TenLCT";
            cmbLoaiCT.ValueMember = "MaLCT";

            txtDanhBo.Text = _source["DanhBo"];
            cmbLoaiCT.SelectedValue = int.Parse(_source["MaLCT"]);
            txtMaCT.Text = _source["MaCT"];
            txtDiaChi.Text = _source["DiaChi"];
            txtSoNKTong.Text = _source["SoNKTong"];
            txtSoNKDangKy.Text = _source["SoNKDangKy"];
            txtThoiHan.Text = _source["ThoiHan"];

            cmbChiNhanh.DataSource = _cChiNhanh.LoadDSChiNhanh(true,"Tân Hòa");
            cmbChiNhanh.DisplayMember = "TenCN";
            cmbChiNhanh.ValueMember = "MaCN";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaCT.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "0" && txtSoNKDangKy.Text.Trim() != "0")
                if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKDangKy.Text.Trim()))
                {
                    ChungTu chungtu = new ChungTu();
                    chungtu.MaCT = txtMaCT.Text.Trim();
                    chungtu.DiaChi = txtDiaChi.Text.Trim();
                    chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());
                    chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());

                    LichSuChungTu lichsuchungtu = new LichSuChungTu();
                    lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);

                    if (chkCatChuyen.Checked)
                        if (txtSoNKCat.Text.Trim() == "")
                        {
                            MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            chungtu.YeuCauCat = true;
                            chungtu.NhanNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                            chungtu.NhanNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                            chungtu.NhanNK_HoTen = txtHoTen_Cat.Text.Trim();
                            chungtu.NhanNK_DiaChi = txtDiaChiKH_Cat.Text.Trim();
                            chungtu.NhanNK_SoNKCat = int.Parse(txtSoNKCat.Text.Trim());

                            DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                            dr["SoPhieu"] = _cChungTu.getMaxNextSoPhieuLSCT().ToString().Insert(4,"-");
                            dr["ChiNhanh"] = ((ChiNhanh)cmbChiNhanh.SelectedItem).TenCN;
                            dr["DanhBoNhan"] = txtDanhBo.Text.Trim();
                            dr["HoTenNhan"] = _source["HoTenKH"];
                            dr["DiaChiNhan"] = _source["DiaChiKH"];
                            dr["DanhBoCat"] = txtDanhBo_Cat.Text.Trim();
                            dr["HoTenCat"] = txtHoTen_Cat.Text.Trim();
                            dr["DiaChiCat"] = txtDiaChiKH_Cat.Text.Trim();
                            dr["SoNKCat"] = txtSoNKCat.Text.Trim() + " nhân khẩu (HK: " + txtMaCT.Text.Trim() + ")";

                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                dr["ChucVu"] = "GIÁM ĐỐC";
                            else
                                dr["ChucVu"] = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            dr["NguoiKy"] = bangiamdoc.HoTen.ToUpper();

                            dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);
                        }

                    CTChungTu ctchungtu = new CTChungTu();
                    ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                    ctchungtu.MaCT = txtMaCT.Text.Trim();
                    ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                    if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                        ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                    else
                        ctchungtu.ThoiHan = null;

                    if (_cChungTu.ThemChungTu(chungtu, ctchungtu, lichsuchungtu))
                    {
                        if (chkCatChuyen.Checked)
                        {
                            rptPhieuYCCatDM rpt = new rptPhieuYCCatDM();
                            rpt.SetDataSource(dsBaoCao);
                            frmBaoCao frm = new frmBaoCao(rpt);
                            frm.ShowDialog();
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoNKTong.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "")
                if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKDangKy.Text.Trim()))
                {
                    ChungTu chungtu = new ChungTu();
                    chungtu.MaCT = txtMaCT.Text.Trim();
                    //chungtu.DiaChi = txtDiaChi.Text.Trim();
                    chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());

                    LichSuChungTu lichsuchungtu = new LichSuChungTu();
                    lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);

                    CTChungTu ctchungtu = new CTChungTu();
                    ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                    ctchungtu.MaCT = txtMaCT.Text.Trim();
                    ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                    if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                        ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                    else
                        ctchungtu.ThoiHan = null;

                    if (_cChungTu.SuaChungTu(chungtu, ctchungtu, lichsuchungtu))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbLoaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_action == "Thêm" && cmbLoaiCT.SelectedIndex != -1)
            {
                txtThoiHan.Text = ((KTKS_DonKH.LinQ.LoaiChungTu)cmbLoaiCT.SelectedItem).ThoiHan.ToString();
            }
        }

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
        }

        private void txtSoNKTong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoNKDangKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtThoiHan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
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
        }
    }
}
