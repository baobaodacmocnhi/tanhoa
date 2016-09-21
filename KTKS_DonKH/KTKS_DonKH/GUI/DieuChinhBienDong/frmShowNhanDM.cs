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
    public partial class frmShowNhanDM : Form
    {
        decimal _MaLSCT = 0;
        CChungTu _cChungTu = new CChungTu();
        LichSuChungTu _lichsuchungtu = null;
        ChungTu _chungtu = null;
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();

        public frmShowNhanDM()
        {
            InitializeComponent();
        }

        public frmShowNhanDM(decimal MaLSCT)
        {
            InitializeComponent();
            _MaLSCT = MaLSCT;
        }

        private void frmShowNhanDM_Load(object sender, EventArgs e)
        {
            cmbChiNhanh.DataSource = _cChiNhanh.LoadDSChiNhanh(true);
            cmbChiNhanh.DisplayMember = "TenCN";
            cmbChiNhanh.ValueMember = "MaCN";

            cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            cmbLoaiCT.DisplayMember = "TenLCT";
            cmbLoaiCT.ValueMember = "MaLCT";

            if (_cChungTu.getLSCTbyID(_MaLSCT) != null)
            {
                _lichsuchungtu = _cChungTu.getLSCTbyID(_MaLSCT);
                _chungtu = _cChungTu.getChungTubyID(_lichsuchungtu.MaCT);

                if (!string.IsNullOrEmpty(_lichsuchungtu.NhanDM.ToString()))
                {
                    if (_lichsuchungtu.NhanDM.Value)
                    {
                        btnSua.Visible = true;
                        txtDanhBo_Nhan.Text = _lichsuchungtu.NhanNK_DanhBo;
                        txtHoTen_Nhan.Text = _lichsuchungtu.NhanNK_HoTen;
                        txtDiaChi_Nhan.Text = _lichsuchungtu.NhanNK_DiaChi;
                        ///
                        cmbChiNhanh.SelectedValue = _lichsuchungtu.CatNK_MaCN;
                        txtDanhBo_Cat.Text = _lichsuchungtu.CatNK_DanhBo;
                        txtHoTen_Cat.Text = _lichsuchungtu.CatNK_HoTen;
                        txtDiaChi_Cat.Text = _lichsuchungtu.CatNK_DiaChi;
                        cmbLoaiCT.SelectedValue = _chungtu.MaLCT;
                        txtMaCT.Text = _lichsuchungtu.MaCT;
                        txtDiaChiCT_Cat.Text = _chungtu.DiaChi;
                        txtSoNKTong.Text = _lichsuchungtu.SoNKTong.ToString();
                        txtSoNKNhan.Text = _lichsuchungtu.SoNKNhan.Value.ToString();
                        txtGhiChu.Text = _lichsuchungtu.GhiChu;
                    }
                }
                else
                    if (!string.IsNullOrEmpty(_lichsuchungtu.YeuCauCat.ToString()))
                    {
                        if (_lichsuchungtu.YeuCauCat.Value)
                        {
                            label6.Text = "Số NK YC Cắt:";
                            
                            txtDanhBo_Nhan.Text = _lichsuchungtu.NhanNK_DanhBo;
                            txtHoTen_Nhan.Text = _lichsuchungtu.NhanNK_HoTen;
                            txtDiaChi_Nhan.Text = _lichsuchungtu.NhanNK_DiaChi;
                            ///
                            cmbChiNhanh.SelectedValue = _lichsuchungtu.CatNK_MaCN;
                            txtDanhBo_Cat.Text = _lichsuchungtu.CatNK_DanhBo;
                            txtHoTen_Cat.Text = _lichsuchungtu.CatNK_HoTen;
                            txtDiaChi_Cat.Text = _lichsuchungtu.CatNK_DiaChi;
                            cmbLoaiCT.SelectedValue = _chungtu.MaLCT;
                            txtMaCT.Text = _lichsuchungtu.MaCT;
                            txtDiaChiCT_Cat.Text = _chungtu.DiaChi;
                            txtSoNKTong.Text = _lichsuchungtu.SoNKTong.ToString();
                            txtSoNKNhan.Text = _lichsuchungtu.SoNKNhan.Value.ToString();
                            txtGhiChu.Text = _lichsuchungtu.GhiChu;
                        }
                    }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_lichsuchungtu != null)
            {
                if (!string.IsNullOrEmpty(_lichsuchungtu.NhanDM.ToString()))
                {
                    if (_lichsuchungtu.NhanDM.Value)
                    {
                        DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                        DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                        if (!string.IsNullOrEmpty(_lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(_lichsuchungtu.MaDonTXL.ToString()))
                            if (_lichsuchungtu.ToXuLy)
                                dr["MaDon"] = "TXL" + _lichsuchungtu.MaDonTXL.ToString().Insert(_lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                            else
                                dr["MaDon"] = _lichsuchungtu.MaDon.ToString().Insert(_lichsuchungtu.MaDon.ToString().Length - 2, "-");

                        dr["SoPhieu"] = _lichsuchungtu.SoPhieu.ToString().Insert(_lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                        dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(_lichsuchungtu.CatNK_MaCN.Value);
                        if (!string.IsNullOrEmpty(_lichsuchungtu.NhanNK_DanhBo))
                            dr["DanhBoNhan"] = _lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " ");
                        dr["HoTenNhan"] = _lichsuchungtu.NhanNK_HoTen;
                        dr["DiaChiNhan"] = _lichsuchungtu.NhanNK_DiaChi;
                        if (!string.IsNullOrEmpty(_lichsuchungtu.CatNK_DanhBo))
                            dr["DanhBoCat"] = _lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " ");
                        dr["HoTenCat"] = _lichsuchungtu.CatNK_HoTen;
                        dr["DiaChiCat"] = _lichsuchungtu.CatNK_DiaChi;
                        dr["SoNKCat"] = _lichsuchungtu.SoNKNhan + " nhân khẩu (HK: " + _lichsuchungtu.MaCT + ")";

                        dr["ChucVu"] = _lichsuchungtu.ChucVu;
                        dr["NguoiKy"] = _lichsuchungtu.NguoiKy;

                        dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                        //rptPhieuYCCatDM rpt = new rptPhieuYCCatDM();
                        //rpt.SetDataSource(dsBaoCao);
                        rptPhieuYCCatDMx2 rpt = new rptPhieuYCCatDMx2();
                        for (int j = 0; j < rpt.Subreports.Count; j++)
                        {
                            rpt.Subreports[j].SetDataSource(dsBaoCao);
                        }
                        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                        frm.ShowDialog();
                    }
                }
                else
                    if (!string.IsNullOrEmpty(_lichsuchungtu.YeuCauCat.ToString()))
                    {
                        if (_lichsuchungtu.YeuCauCat.Value)
                        {
                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                            if (!string.IsNullOrEmpty(_lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(_lichsuchungtu.MaDonTXL.ToString()))
                                if (_lichsuchungtu.ToXuLy)
                                    dr["MaDon"] = "TXL" + _lichsuchungtu.MaDonTXL.ToString().Insert(_lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                else

                                    dr["MaDon"] = _lichsuchungtu.MaDon.ToString().Insert(_lichsuchungtu.MaDon.ToString().Length - 2, "-");
                            dr["SoPhieu"] = _lichsuchungtu.SoPhieu.ToString().Insert(_lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                            dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(_lichsuchungtu.CatNK_MaCN.Value);
                            if (!string.IsNullOrEmpty(_lichsuchungtu.NhanNK_DanhBo))
                                dr["DanhBoNhan"] = _lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["HoTenNhan"] = _lichsuchungtu.NhanNK_HoTen;
                            dr["DiaChiNhan"] = _lichsuchungtu.NhanNK_DiaChi;
                            if (!string.IsNullOrEmpty(_lichsuchungtu.CatNK_DanhBo))
                                dr["DanhBoCat"] = _lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["HoTenCat"] = _lichsuchungtu.CatNK_HoTen;
                            dr["DiaChiCat"] = _lichsuchungtu.CatNK_DiaChi;
                            dr["SoNKCat"] = _lichsuchungtu.SoNKNhan + " nhân khẩu (HK: " + _lichsuchungtu.MaCT + ")";

                            dr["ChucVu"] = _lichsuchungtu.ChucVu;
                            dr["NguoiKy"] = _lichsuchungtu.NguoiKy;

                            dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                            //rptPhieuYCCatDM rpt = new rptPhieuYCCatDM();
                            //rpt.SetDataSource(dsBaoCao);
                            rptPhieuYCCatDMx2 rpt = new rptPhieuYCCatDMx2();
                            for (int j = 0; j < rpt.Subreports.Count; j++)
                            {
                                rpt.Subreports[j].SetDataSource(dsBaoCao);
                            }
                            frmShowBaoCao frm = new frmShowBaoCao(rpt);
                            frm.ShowDialog();
                        }
                    }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_lichsuchungtu != null)
            {
                if (!string.IsNullOrEmpty(_lichsuchungtu.NhanDM.ToString()))
                {
                    if (_lichsuchungtu.NhanDM.Value)
                    {
                        try
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
                                    ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                                    ctchungtu.Lo = txtLo.Text.Trim();
                                    ctchungtu.Phong = txtPhong.Text.Trim();

                                    LichSuChungTu lichsuchungtu = new LichSuChungTu();
                                    lichsuchungtu.MaLSCT = _lichsuchungtu.MaLSCT;
                                    lichsuchungtu.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
                                    lichsuchungtu.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();
                                    lichsuchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                    lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                    lichsuchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                    lichsuchungtu.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
                                    lichsuchungtu.SoNKNhan = int.Parse(txtSoNKNhan.Text.Trim());
                                    lichsuchungtu.GhiChu = txtGhiChu.Text.Trim();

                                    if (_cChungTu.SuaNhanChungTu(chungtu, ctchungtu, lichsuchungtu))
                                    {
                                        MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }

                if (!string.IsNullOrEmpty(_lichsuchungtu.YeuCauCat.ToString()))
                {
                    if (_lichsuchungtu.YeuCauCat.Value)
                    {
                        MessageBox.Show("Chỉ sửa Danh Bộ, Khách Hàng, Địa Chỉ Gắn Mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Yêu Cầu Cắt không được sửa ở đây\n Vui lòng vào Số Đơn, Danh Bộ & Số Chứng Từ để sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LichSuChungTu lichsuchungtu = _cChungTu.getLSCTbyID(_lichsuchungtu.MaLSCT);
                        //lichsuchungtu.MaLSCT = _lichsuchungtu.MaLSCT;

                        lichsuchungtu.NhanNK_DanhBo = txtDanhBo_Nhan.Text.Trim();
                        lichsuchungtu.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
                        lichsuchungtu.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();

                        if (_cChungTu.SuaLichSuChungTu(lichsuchungtu))
                        {
                            MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void txtDiaChi_Cat_TextChanged(object sender, EventArgs e)
        {
            txtDiaChiCT_Cat.Text = txtDiaChi_Cat.Text.Trim();
        }


    }
}
