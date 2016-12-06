using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmCatChuyenDM : Form
    {
        string _mnu = "mnuDCBD";
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CThuTien _cThuTien = new CThuTien();
        CChungTu _cChungTu = new CChungTu();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CTChungTu _ctchungtu = null;
        decimal _MaLSCT = 0;
        LichSuChungTu _lichsuchungtu = null;

        public frmCatChuyenDM()
        {
            InitializeComponent();
        }

        public frmCatChuyenDM(decimal MaLSCT)
        {
            _MaLSCT = MaLSCT;
            InitializeComponent();
        }

        public frmCatChuyenDM(Dictionary<string, string> source)
        {
            _source = source;
            InitializeComponent();
        }

        private void frmCatChuyenDM_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            cmbChiNhanh_Cat.DataSource = _cChiNhanh.LoadDSChiNhanh();
            cmbChiNhanh_Cat.DisplayMember = "TenCN";
            cmbChiNhanh_Cat.ValueMember = "MaCN";

            cmbChiNhanh_Nhan.DataSource = _cChiNhanh.LoadDSChiNhanh();
            cmbChiNhanh_Nhan.DisplayMember = "TenCN";
            cmbChiNhanh_Nhan.ValueMember = "MaCN";
            cmbChiNhanh_Nhan.SelectedIndex = -1;

            cmbLoaiCT_Cat.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu();
            cmbLoaiCT_Cat.DisplayMember = "TenLCT";
            cmbLoaiCT_Cat.ValueMember = "MaLCT";

            if (_MaLSCT != 0)
            {
                _lichsuchungtu = _cChungTu.getLSCTbyID(_MaLSCT);

                if (_lichsuchungtu.CatDM)
                {
                    txtDanhBo_Cat.Text = _lichsuchungtu.CatNK_DanhBo;
                    txtHoTen_Cat.Text = _lichsuchungtu.CatNK_HoTen;
                    txtDiaChi_Cat.Text = _lichsuchungtu.CatNK_DiaChi;
                    txtMaCT_Cat.Text = _lichsuchungtu.MaCT;
                    txtSoNK_Cat.Text = _lichsuchungtu.SoNKCat.Value.ToString();
                    txtGhiChu_Cat.Text = _lichsuchungtu.GhiChu;
                    ///
                    cmbChiNhanh_Nhan.SelectedValue = _lichsuchungtu.NhanNK_MaCN.Value;
                    txtDanhBo_Nhan.Text = _lichsuchungtu.NhanNK_DanhBo;
                    txtHoTen_Nhan.Text = _lichsuchungtu.NhanNK_HoTen;
                    txtDiaChi_Nhan.Text = _lichsuchungtu.NhanNK_DiaChi;
                }
            }
            else
            {
                _ctchungtu = _cChungTu.getCTChungTubyID(_source["DanhBo"], _source["MaCT"]);

                txtDanhBo_Cat.Text = _ctchungtu.DanhBo;
                txtHoTen_Cat.Text = _source["HoTen"];
                txtDiaChi_Cat.Text = _ctchungtu.ChungTu.DiaChi;
                cmbLoaiCT_Cat.SelectedValue = _ctchungtu.ChungTu.MaLCT;
                txtMaCT_Cat.Text = _ctchungtu.MaCT;
            }
        }

        public void LoadDS(HOADON hoadon)
        {
            txtDanhBo_Nhan.Text = hoadon.DANHBA;
            txtHoTen_Nhan.Text = hoadon.TENKH;
            txtDiaChi_Nhan.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
        }

        public void Clear()
        {
            txtDanhBo_Nhan.Text = "";
            txtHoTen_Nhan.Text = "";
            txtDiaChi_Nhan.Text = "";
        }

        private void txtDanhBo_Nhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

            if (e.KeyChar == 13 && ((ChiNhanh)cmbChiNhanh_Nhan.SelectedItem).TenCN.ToUpper().Contains("TÂN HÒA") && txtDanhBo_Cat.Text.Trim() != txtDanhBo_Nhan.Text.Trim())
            {
                if (_cThuTien.GetMoiNhat(txtDanhBo_Nhan.Text.Trim()) != null)
                    LoadDS(_cThuTien.GetMoiNhat(txtDanhBo_Nhan.Text.Trim()));
                else
                    Clear();
            }
        }

        private void txtSoNK_Cat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them();
            //try
            //{
            //    if (txtSoNK_Cat.Text.Trim() != "" && txtSoNK_Cat.Text.Trim() != "0" && cmbChiNhanh_Nhan.SelectedIndex != -1)
            //    {
            //        if (int.Parse(_source["SoNKDangKy"]) >= int.Parse(txtSoNK_Cat.Text.Trim()))
            //        {
            //            CTChungTu ctchungtuCat = new CTChungTu();
            //            ctchungtuCat.DanhBo = _source["DanhBo"];
            //            ctchungtuCat.MaCT = _source["MaCT"];

            //            CTChungTu ctchungtuNhan = new CTChungTu();
            //            ctchungtuNhan.DanhBo = txtDanhBo_Nhan.Text.Trim();
            //            ctchungtuNhan.MaCT = _source["MaCT"];

            //            int SoNKCat = int.Parse(txtSoNK_Cat.Text.Trim());

            //            LichSuChungTu lichsuchungtu = new LichSuChungTu();
            //            if (bool.Parse(_source["TXL"]) == true)
            //            {
            //                lichsuchungtu.ToXuLy = true;
            //                lichsuchungtu.MaDonTXL = decimal.Parse(_source["MaDon"]);
            //            }
            //            else
            //                lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);
            //            lichsuchungtu.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
            //            lichsuchungtu.CatDM = true;
            //            lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
            //            lichsuchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
            //            lichsuchungtu.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
            //            lichsuchungtu.NhanNK_MaCN = int.Parse(cmbChiNhanh_Nhan.SelectedValue.ToString());
            //            lichsuchungtu.NhanNK_DanhBo = txtDanhBo_Nhan.Text.Trim();
            //            lichsuchungtu.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
            //            lichsuchungtu.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();
            //            lichsuchungtu.SoNKCat = int.Parse(txtSoNK_Cat.Text.Trim());
            //            lichsuchungtu.GhiChu = txtGhiChu_Nhan.Text.Trim();
            //            ///Ký Tên
            //            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
            //            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
            //                lichsuchungtu.ChucVu = "GIÁM ĐỐC";
            //            else
            //                lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
            //            lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
            //            lichsuchungtu.PhieuDuocKy = true;

            //            if (_cChungTu.CatChuyenChungTu(ctchungtuCat, ctchungtuNhan, int.Parse(txtSoNK_Cat.Text.Trim()), lichsuchungtu))
            //            {
            //                if (!((ChiNhanh)cmbChiNhanh_Nhan.SelectedItem).TenCN.ToUpper().Contains("TÂN HÒA"))
            //                {
            //                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            //                    DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

            //                    dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
            //                    dr["ChiNhanh"] = ((ChiNhanh)cmbChiNhanh_Nhan.SelectedItem).TenCN;
            //                    dr["DanhBoNhan"] = txtDanhBo_Nhan.Text.Trim();
            //                    dr["HoTenNhan"] = txtHoTen_Nhan.Text.Trim();
            //                    dr["DiaChiNhan"] = txtDiaChi_Nhan.Text.Trim();
            //                    dr["DanhBoCat"] = txtDanhBo_Cat.Text.Trim();
            //                    dr["HoTenCat"] = txtHoTen_Cat.Text.Trim();
            //                    dr["DiaChiCat"] = txtDiaChi_Cat.Text.Trim();
            //                    dr["SoNKCat"] = txtSoNK_Cat.Text.Trim() + " nhân khẩu (HK: " + txtMaCT_Cat.Text.Trim() + ")";

            //                    dr["ChucVu"] = lichsuchungtu.ChucVu;
            //                    dr["NguoiKy"] = lichsuchungtu.NguoiKy;

            //                    dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

            //                    rptPhieuYCNhanDM rpt = new rptPhieuYCNhanDM();
            //                    rpt.SetDataSource(dsBaoCao);
            //                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
            //                    frm.ShowDialog();
            //                }

            //                this.DialogResult = DialogResult.OK;
            //                this.Close();
            //            }
            //        }
            //        else
            //            MessageBox.Show("Cắt vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //        MessageBox.Show("Bạn chưa nhập Số NK Cắt hoặc chưa chọn Chi Nhánh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        public void Them()
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (txtSoNK_Cat.Text.Trim() != "" && txtSoNK_Cat.Text.Trim() != "0" && cmbChiNhanh_Nhan.SelectedIndex != -1)
                    {
                        if (_ctchungtu.SoNKDangKy < int.Parse(txtSoNK_Cat.Text.Trim()))
                        {
                            MessageBox.Show("Cắt vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ///Cùng Chi Nhánh
                        if (_cChiNhanh.getChiNhanhbyID(int.Parse(cmbChiNhanh_Nhan.SelectedValue.ToString())).TenCN.ToUpper().Contains("TÂN HÒA"))
                        {
                                ///Cập nhật CTChungTu, Danh Bộ Cắt
                                _ctchungtu.SoNKDangKy -= int.Parse(txtSoNK_Cat.Text.Trim());
                                _ctchungtu.GhiChu = txtGhiChu_Cat.Text.Trim();
                                _ctchungtu.ModifyDate = DateTime.Now;
                                _ctchungtu.ModifyBy = CTaiKhoan.MaUser;

                                CTChungTu ctchungtuNhan = new CTChungTu();
                                ///Nếu Chứng Từ đã đăng ký với Danh Bộ
                                if (_cChungTu.CheckCTChungTu(txtDanhBo_Nhan.Text.Trim(), txtMaCT_Cat.Text.Trim()))
                                {
                                    ///Cập nhật CTChungTu, Danh Bộ Nhận
                                    ctchungtuNhan = _cChungTu.getCTChungTubyID(txtDanhBo_Nhan.Text.Trim(), txtMaCT_Cat.Text.Trim());
                                    ctchungtuNhan.SoNKDangKy += int.Parse(txtSoNK_Cat.Text.Trim());
                                    ctchungtuNhan.GhiChu = txtGhiChu_Nhan.Text.Trim();
                                    _cChungTu.SuaCTChungTu(ctchungtuNhan);
                                }
                                ///Nếu Chứng Từ chưa đăng ký với Danh Bộ
                                else
                                {
                                    ///Thêm CTChungTu, Danh Bộ Nhận
                                    ctchungtuNhan.DanhBo = txtDanhBo_Nhan.Text.Trim();
                                    ctchungtuNhan.MaCT = txtMaCT_Cat.Text.Trim();
                                    ctchungtuNhan.SoNKDangKy = int.Parse(txtSoNK_Cat.Text.Trim());
                                    ctchungtuNhan.GhiChu = txtGhiChu_Nhan.Text.Trim();
                                    _cChungTu.ThemCTChungTu(ctchungtuNhan);
                                }
                                ///Cập nhật LichSuChungTu, Chứng Từ & Danh Bộ Cắt
                                LichSuChungTu lichsuchungtu = new LichSuChungTu();
                                if (bool.Parse(_source["TXL"]) == true)
                                {
                                    lichsuchungtu.ToXuLy = true;
                                    lichsuchungtu.MaDonTXL = decimal.Parse(_source["MaDon"]);
                                }
                                else
                                    lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);
                                lichsuchungtu.MaCT = _ctchungtu.MaCT;
                                lichsuchungtu.DanhBo = _ctchungtu.DanhBo;
                                lichsuchungtu.SoNKTong = _ctchungtu.ChungTu.SoNKTong;
                                lichsuchungtu.SoNKDangKy = _ctchungtu.SoNKDangKy;
                                lichsuchungtu.ThoiHan = _ctchungtu.ThoiHan;
                                lichsuchungtu.NgayHetHan = _ctchungtu.NgayHetHan;
                                ///
                                lichsuchungtu.SoPhieu = null;
                                lichsuchungtu.CatDM = true;
                                lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                lichsuchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                lichsuchungtu.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
                                lichsuchungtu.NhanNK_MaCN = int.Parse(cmbChiNhanh_Nhan.SelectedValue.ToString());
                                lichsuchungtu.NhanNK_DanhBo = txtDanhBo_Nhan.Text.Trim();
                                lichsuchungtu.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
                                lichsuchungtu.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();
                                lichsuchungtu.SoNKCat = int.Parse(txtSoNK_Cat.Text.Trim());
                                lichsuchungtu.GhiChu = txtGhiChu_Cat.Text.Trim();

                                _cChungTu.ThemLichSuChungTu(lichsuchungtu);

                                ///Cập nhật LichSuChungTu, Chứng Từ & Danh Bộ Nhận
                                LichSuChungTu lichsuchungtuNhan = new LichSuChungTu();
                                if (bool.Parse(_source["TXL"]) == true)
                                {
                                    lichsuchungtuNhan.ToXuLy = true;
                                    lichsuchungtuNhan.MaDonTXL = decimal.Parse(_source["MaDon"]);
                                }
                                else
                                    lichsuchungtuNhan.MaDon = decimal.Parse(_source["MaDon"]);
                                lichsuchungtuNhan.MaCT = ctchungtuNhan.MaCT;
                                lichsuchungtuNhan.DanhBo = ctchungtuNhan.DanhBo;
                                lichsuchungtuNhan.SoNKTong = ctchungtuNhan.ChungTu.SoNKTong;
                                lichsuchungtuNhan.SoNKNhan = int.Parse(txtSoNK_Cat.Text.Trim());
                                lichsuchungtuNhan.SoNKDangKy = ctchungtuNhan.SoNKDangKy;
                                lichsuchungtuNhan.ThoiHan = ctchungtuNhan.ThoiHan;
                                lichsuchungtuNhan.NgayHetHan = ctchungtuNhan.NgayHetHan;
                                ///Chuyển đổi vị trí Cắt & Nhận
                                lichsuchungtuNhan.CatNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
                                lichsuchungtuNhan.CatNK_HoTen = lichsuchungtu.NhanNK_HoTen;
                                lichsuchungtuNhan.CatNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
                                lichsuchungtuNhan.CatNK_MaCN = lichsuchungtu.NhanNK_MaCN;
                                lichsuchungtuNhan.NhanDM = true;
                                lichsuchungtuNhan.NhanNK_MaCN = lichsuchungtu.CatNK_MaCN;
                                lichsuchungtuNhan.NhanNK_DanhBo = lichsuchungtu.CatNK_DanhBo;
                                lichsuchungtuNhan.NhanNK_HoTen = lichsuchungtu.CatNK_HoTen;
                                lichsuchungtuNhan.NhanNK_DiaChi = lichsuchungtu.CatNK_DiaChi;
                                lichsuchungtuNhan.GhiChu = txtGhiChu_Nhan.Text.Trim();

                                _cChungTu.ThemLichSuChungTu(lichsuchungtuNhan);
                        }
                        ///Khác Chi Nhánh
                        else
                        {
                            _ctchungtu.SoNKDangKy -= int.Parse(txtSoNK_Cat.Text.Trim());
                            _ctchungtu.GhiChu = txtGhiChu_Cat.Text.Trim();
                            _ctchungtu.ModifyDate = DateTime.Now;
                            _ctchungtu.ModifyBy = CTaiKhoan.MaUser;

                            LichSuChungTu lichsuchungtu = new LichSuChungTu();
                            if (bool.Parse(_source["TXL"]) == true)
                            {
                                lichsuchungtu.ToXuLy = true;
                                lichsuchungtu.MaDonTXL = decimal.Parse(_source["MaDon"]);
                            }
                            else
                                lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);
                            lichsuchungtu.MaCT = _ctchungtu.MaCT;
                            lichsuchungtu.DanhBo = _ctchungtu.DanhBo;
                            lichsuchungtu.SoNKTong = _ctchungtu.ChungTu.SoNKTong;
                            lichsuchungtu.SoNKDangKy = _ctchungtu.SoNKDangKy;
                            lichsuchungtu.ThoiHan = _ctchungtu.ThoiHan;
                            lichsuchungtu.NgayHetHan = _ctchungtu.NgayHetHan;
                            ///
                            lichsuchungtu.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                            lichsuchungtu.CatDM = true;
                            lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                            lichsuchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                            lichsuchungtu.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
                            lichsuchungtu.NhanNK_MaCN = int.Parse(cmbChiNhanh_Nhan.SelectedValue.ToString());
                            lichsuchungtu.NhanNK_DanhBo = txtDanhBo_Nhan.Text.Trim();
                            lichsuchungtu.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
                            lichsuchungtu.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();
                            lichsuchungtu.SoNKCat = int.Parse(txtSoNK_Cat.Text.Trim());
                            lichsuchungtu.GhiChu = txtGhiChu_Cat.Text.Trim();
                            ///Ký Tên
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                            else
                                lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            lichsuchungtu.PhieuDuocKy = true;

                            _cChungTu.ThemLichSuChungTu(lichsuchungtu);
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                if (_lichsuchungtu != null)
                {

                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
