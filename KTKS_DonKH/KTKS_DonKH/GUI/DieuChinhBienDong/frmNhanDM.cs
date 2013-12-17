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
    public partial class frmNhanDM : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();

        public frmNhanDM()
        {
            InitializeComponent();
        }

        public frmNhanDM(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmNhanDM_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            txtDanhBo_Nhan.Text = _source["DanhBo"];
            txtHoTen_Nhan.Text = _source["HoTen"];
            txtDiaChi_Nhan.Text = _source["DiaChi"];

            cmbChiNhanh.DataSource = _cChiNhanh.LoadDSChiNhanh(true, "Tân Hòa");
            cmbChiNhanh.DisplayMember = "TenCN";
            cmbChiNhanh.ValueMember = "MaCN";

            cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            cmbLoaiCT.DisplayMember = "TenLCT";
            cmbLoaiCT.ValueMember = "MaLCT";
        }

        private void txtMaCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtThoiHan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoNKTong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoNKNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaCT.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "" && txtSoNKNhan.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "0" && txtSoNKNhan.Text.Trim() != "0")
                if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKNhan.Text.Trim()))
                {
                    ChungTu chungtu = new ChungTu();
                    chungtu.MaCT = txtMaCT.Text.Trim();
                    chungtu.DiaChi = txtDiaChiCT_Cat.Text.Trim();
                    chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());
                    chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());

                    CTChungTu ctchungtu = new CTChungTu();
                    ctchungtu.DanhBo = txtDanhBo_Nhan.Text.Trim();
                    ctchungtu.MaCT = txtMaCT.Text.Trim();
                    ctchungtu.SoNKDangKy = int.Parse(txtSoNKNhan.Text.Trim());
                    if (txtThoiHan.Text.Trim() != "")
                        ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                    else
                        ctchungtu.ThoiHan = null;

                    LichSuChungTu lichsuchungtu = new LichSuChungTu();
                    lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);
                    lichsuchungtu.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                    lichsuchungtu.NhanDM = true;
                    lichsuchungtu.NhanNK_DanhBo = txtDanhBo_Nhan.Text.Trim();
                    lichsuchungtu.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
                    lichsuchungtu.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();
                    lichsuchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                    lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                    lichsuchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                    lichsuchungtu.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
                    lichsuchungtu.SoNKNhan = int.Parse(txtSoNKNhan.Text.Trim());
                    ///Ký Tên
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                    else
                        lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                    lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();

                    if (_cChungTu.NhanChungTu(chungtu, ctchungtu, lichsuchungtu))
                    {
                        DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                        DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                        dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                        dr["ChiNhanh"] = ((ChiNhanh)cmbChiNhanh.SelectedItem).TenCN;
                        dr["DanhBoNhan"] = txtDanhBo_Nhan.Text.Trim();
                        dr["HoTenNhan"] = txtHoTen_Nhan.Text.Trim();
                        dr["DiaChiNhan"] = txtDiaChi_Nhan.Text.Trim();
                        dr["DanhBoCat"] = txtDanhBo_Cat.Text.Trim();
                        dr["HoTenCat"] = txtHoTen_Cat.Text.Trim();
                        dr["DiaChiCat"] = txtDiaChi_Cat.Text.Trim();
                        dr["SoNKCat"] = txtSoNKNhan.Text.Trim() + " nhân khẩu (HK: " + txtMaCT.Text.Trim() + ")";

                        dr["ChucVu"] = lichsuchungtu.ChucVu;
                        dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                        dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                        rptPhieuYCCatDM rpt = new rptPhieuYCCatDM();
                        rpt.SetDataSource(dsBaoCao);
                        frmBaoCao frm = new frmBaoCao(rpt);
                        frm.ShowDialog();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbLoaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLoaiCT.SelectedIndex != -1)
            {
                txtThoiHan.Text = ((KTKS_DonKH.LinQ.LoaiChungTu)cmbLoaiCT.SelectedItem).ThoiHan.ToString();
            }
        }

    }
}
