using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;
using System.Transactions;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmNhanDM : Form
    {
        string _mnu = "mnuDCBD";
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();

        CDataTransfer _dataT = new CDataTransfer();

        public frmNhanDM()
        {
            InitializeComponent();
        }

        public frmNhanDM(CDataTransfer dataT)
        {
            InitializeComponent();
            _dataT = dataT;
        }

        private void frmNhanDM_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);

            cmbChiNhanh.DataSource = _cChiNhanh.LoadDSChiNhanh("Tân Hòa");
            cmbChiNhanh.DisplayMember = "TenCN";
            cmbChiNhanh.ValueMember = "MaCN";

            cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu();
            cmbLoaiCT.DisplayMember = "TenLCT";
            cmbLoaiCT.ValueMember = "MaLCT";

            txtDanhBo_Nhan.Text = _dataT.DanhBo;
            txtHoTen_Nhan.Text = _dataT.HoTen;
            txtDiaChi_Nhan.Text = _dataT.DiaChi;

            dgvDSDanhBo.AutoGenerateColumns = false;
        }

        #region Configure TextBox

        private void txtMaCT_KeyPress(object sender, KeyPressEventArgs e)
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
                txtDiaChiCT_Cat.Focus();
        }

        private void txtSoNKTong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtSoNKNhan.Focus();
        }

        private void txtSoNKNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                txtGhiChu.Focus();
        }

        private void cmbChiNhanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDanhBo_Cat.Focus();
        }

        private void txtDanhBo_Cat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen_Cat.Focus();
        }

        private void txtHoTen_Cat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChi_Cat.Focus();
        }

        private void txtDiaChi_Cat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cmbLoaiCT.Focus();
        }

        private void cmbLoaiCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtMaCT.Focus();
        }

        private void txtDiaChiCT_Cat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoNKTong.Focus();
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnThem.Focus();
        }

        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (txtMaCT.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "" && txtSoNKNhan.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "0" && txtSoNKNhan.Text.Trim() != "0")
                        if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKNhan.Text.Trim()))
                            using (var scope = new TransactionScope())
                            {
                                /////Kiểm tra Danh Bộ & Số Chứng Từ
                                //if (_cChungTu.CheckExist_CT(txtDanhBo_Nhan.Text.Trim(), txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString())) == true)
                                //{
                                //    MessageBox.Show("Danh Bộ trên đã đăng ký Số Chứng Từ trên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    return;
                                //}
                                ///Kiểm tra Số Chứng Từ
                                if (_cChungTu.CheckExist(txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString())) == false)
                                {
                                    ChungTu chungtu = new ChungTu();
                                    chungtu.MaCT = txtMaCT.Text.Trim();
                                    chungtu.DiaChi = txtDiaChiCT_Cat.Text.Trim();
                                    chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());
                                    chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
                                    chungtu.KhacDiaBan = true;
                                    _cChungTu.Them(chungtu);
                                }
                                ///Lấy thông tin Chứng Từ để kiểm tra
                                ChungTu _chungtu = _cChungTu.Get(txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString()));
                                _chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());

                                if (_chungtu.SoNKTong - _chungtu.CTChungTus.Sum(item => item.SoNKDangKy) < int.Parse(txtSoNKNhan.Text.Trim()))
                                {
                                    MessageBox.Show("Vượt Nhân Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                //chưa có
                                if (_cChungTu.CheckExist_CT(txtDanhBo_Nhan.Text.Trim(), txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString())) == false)
                                {
                                    CTChungTu ctchungtu = new CTChungTu();
                                    ctchungtu.DanhBo = txtDanhBo_Nhan.Text.Trim();
                                    ctchungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
                                    ctchungtu.MaCT = txtMaCT.Text.Trim();
                                    ctchungtu.SoNKDangKy = int.Parse(txtSoNKNhan.Text.Trim());
                                    if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                                    {
                                        ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                                        ctchungtu.NgayHetHan = DateTime.Now.AddMonths(int.Parse(txtThoiHan.Text.Trim()));
                                    }
                                    ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                                    ctchungtu.Lo = txtLo.Text.Trim();
                                    ctchungtu.Phong = txtPhong.Text.Trim();
                                    ///Ghi thông tin Lịch Sử chung
                                    LichSuChungTu lichsuchungtu = new LichSuChungTu();
                                    switch (_dataT.Loai)
                                    {
                                        case "TKH":
                                            lichsuchungtu.MaDon = _dataT.MaDon;
                                            break;
                                        case "TXL":
                                            lichsuchungtu.MaDonTXL = _dataT.MaDon;
                                            break;
                                        case "TBC":
                                            lichsuchungtu.MaDonTBC = _dataT.MaDon;
                                            break;
                                        default:
                                            break;
                                    }
                                    lichsuchungtu.MaDonMoi = _dataT.MaDonMoi;
                                    lichsuchungtu.DanhBo = txtDanhBo_Nhan.Text.Trim();
                                    lichsuchungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
                                    lichsuchungtu.MaCT = txtMaCT.Text.Trim();
                                    lichsuchungtu.SoNKTong = _chungtu.SoNKTong;
                                    lichsuchungtu.SoNKDangKy = int.Parse(txtSoNKNhan.Text.Trim());
                                    if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                                    {
                                        lichsuchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                                        lichsuchungtu.NgayHetHan = DateTime.Now.AddMonths(int.Parse(txtThoiHan.Text.Trim()));
                                    }
                                    lichsuchungtu.GhiChu = txtGhiChu.Text.Trim();
                                    lichsuchungtu.Lo = txtLo.Text.Trim();
                                    lichsuchungtu.Phong = txtPhong.Text.Trim();

                                    if (_cChungTu.ThemCT(ctchungtu))
                                    {
                                        ///Thêm Lịch Sử đầu tiên
                                        _cChungTu.ThemLichSuChungTu(lichsuchungtu);

                                        LichSuChungTu lichsuchungtuCat = new LichSuChungTu();
                                        CopyLichSuChungTu(lichsuchungtu, ref lichsuchungtuCat);
                                        lichsuchungtuCat.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                        lichsuchungtuCat.YeuCauCat = true;
                                        lichsuchungtuCat.NhanNK_MaCN = _cChiNhanh.GetIDByTenCN("Tân Hòa");
                                        lichsuchungtuCat.NhanNK_DanhBo = txtDanhBo_Nhan.Text.Trim();
                                        lichsuchungtuCat.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
                                        lichsuchungtuCat.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();
                                        lichsuchungtuCat.CatNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                        lichsuchungtuCat.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                        lichsuchungtuCat.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                        lichsuchungtuCat.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
                                        lichsuchungtuCat.SoNK = int.Parse(txtSoNKNhan.Text.Trim());
                                        lichsuchungtuCat.CatNK_GhiChu = txtGhiChu.Text.Trim();
                                        ///Ký Tên
                                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                            lichsuchungtuCat.ChucVu = "GIÁM ĐỐC";
                                        else
                                            lichsuchungtuCat.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                        lichsuchungtuCat.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                        lichsuchungtuCat.PhieuDuocKy = true;

                                        if (_cChungTu.ThemLichSuChungTu(lichsuchungtuCat))
                                        {
                                            ctchungtu.YeuCauCat = true;
                                            ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                            ctchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                            ctchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                            ctchungtu.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
                                            ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKNhan.Text.Trim());
                                            ctchungtu.SoPhieu = lichsuchungtuCat.SoPhieu;

                                            _cChungTu.SuaCT(ctchungtu);
                                        }
                                    }
                                }
                                //đã có
                                else
                                {
                                    CTChungTu ctchungtu = _cChungTu.GetCT(txtDanhBo_Nhan.Text.Trim(), txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString()));
                                    ctchungtu.SoNKDangKy += int.Parse(txtSoNKNhan.Text.Trim());
                                    ///Ghi thông tin Lịch Sử chung
                                    LichSuChungTu lichsuchungtu = new LichSuChungTu();
                                    switch (_dataT.Loai)
                                    {
                                        case "TKH":
                                            lichsuchungtu.MaDon = _dataT.MaDon;
                                            break;
                                        case "TXL":
                                            lichsuchungtu.MaDonTXL = _dataT.MaDon;
                                            break;
                                        case "TBC":
                                            lichsuchungtu.MaDonTBC = _dataT.MaDon;
                                            break;
                                        default:
                                            break;
                                    }
                                    lichsuchungtu.MaDonMoi = _dataT.MaDonMoi;
                                    lichsuchungtu.DanhBo = txtDanhBo_Nhan.Text.Trim();
                                    lichsuchungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
                                    lichsuchungtu.MaCT = txtMaCT.Text.Trim();
                                    lichsuchungtu.SoNKTong = _chungtu.SoNKTong;
                                    lichsuchungtu.SoNKDangKy = int.Parse(txtSoNKNhan.Text.Trim());
                                    if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                                    {
                                        lichsuchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                                        lichsuchungtu.NgayHetHan = DateTime.Now.AddMonths(int.Parse(txtThoiHan.Text.Trim()));
                                    }
                                    lichsuchungtu.GhiChu = txtGhiChu.Text.Trim();
                                    lichsuchungtu.Lo = txtLo.Text.Trim();
                                    lichsuchungtu.Phong = txtPhong.Text.Trim();

                                    if (_cChungTu.SuaCT(ctchungtu))
                                    {
                                        ///Thêm Lịch Sử đầu tiên
                                        _cChungTu.ThemLichSuChungTu(lichsuchungtu);

                                        LichSuChungTu lichsuchungtuCat = new LichSuChungTu();
                                        CopyLichSuChungTu(lichsuchungtu, ref lichsuchungtuCat);
                                        lichsuchungtuCat.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                        lichsuchungtuCat.YeuCauCat = true;
                                        lichsuchungtuCat.NhanNK_MaCN = _cChiNhanh.GetIDByTenCN("Tân Hòa");
                                        lichsuchungtuCat.NhanNK_DanhBo = txtDanhBo_Nhan.Text.Trim();
                                        lichsuchungtuCat.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
                                        lichsuchungtuCat.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();
                                        lichsuchungtuCat.CatNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                        lichsuchungtuCat.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                        lichsuchungtuCat.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                        lichsuchungtuCat.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
                                        lichsuchungtuCat.SoNK = int.Parse(txtSoNKNhan.Text.Trim());
                                        lichsuchungtuCat.CatNK_GhiChu = txtGhiChu.Text.Trim();
                                        ///Ký Tên
                                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                            lichsuchungtuCat.ChucVu = "GIÁM ĐỐC";
                                        else
                                            lichsuchungtuCat.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                        lichsuchungtuCat.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                        lichsuchungtuCat.PhieuDuocKy = true;

                                        if (_cChungTu.ThemLichSuChungTu(lichsuchungtuCat))
                                        {
                                            #region YeuCauCat

                                            if (ctchungtu.YeuCauCat == false)
                                            {
                                                ctchungtu.YeuCauCat = true;
                                                ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                                ctchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                                ctchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                                ctchungtu.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
                                                ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKNhan.Text.Trim());
                                                ctchungtu.SoPhieu = lichsuchungtuCat.SoPhieu;
                                            }
                                            else
                                                if (ctchungtu.YeuCauCat2 == false)
                                                {
                                                    ctchungtu.YeuCauCat2 = true;
                                                    ctchungtu.CatNK_MaCN2 = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                                    ctchungtu.CatNK_DanhBo2 = txtDanhBo_Cat.Text.Trim();
                                                    ctchungtu.CatNK_HoTen2 = txtHoTen_Cat.Text.Trim();
                                                    ctchungtu.CatNK_DiaChi2 = txtDiaChi_Cat.Text.Trim();
                                                    ctchungtu.CatNK_SoNKCat2 = int.Parse(txtSoNKNhan.Text.Trim());
                                                    ctchungtu.SoPhieu2 = lichsuchungtuCat.SoPhieu;
                                                }
                                                else
                                                    if (ctchungtu.YeuCauCat3 == false)
                                                    {
                                                        ctchungtu.YeuCauCat3 = true;
                                                        ctchungtu.CatNK_MaCN3 = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                                        ctchungtu.CatNK_DanhBo3 = txtDanhBo_Cat.Text.Trim();
                                                        ctchungtu.CatNK_HoTen3 = txtHoTen_Cat.Text.Trim();
                                                        ctchungtu.CatNK_DiaChi3 = txtDiaChi_Cat.Text.Trim();
                                                        ctchungtu.CatNK_SoNKCat3 = int.Parse(txtSoNKNhan.Text.Trim());
                                                        ctchungtu.SoPhieu3 = lichsuchungtuCat.SoPhieu;
                                                    }
                                                    else
                                                        if (ctchungtu.YeuCauCat4 == false)
                                                        {
                                                            ctchungtu.YeuCauCat4 = true;
                                                            ctchungtu.CatNK_MaCN4 = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                                            ctchungtu.CatNK_DanhBo4 = txtDanhBo_Cat.Text.Trim();
                                                            ctchungtu.CatNK_HoTen4 = txtHoTen_Cat.Text.Trim();
                                                            ctchungtu.CatNK_DiaChi4 = txtDiaChi_Cat.Text.Trim();
                                                            ctchungtu.CatNK_SoNKCat4 = int.Parse(txtSoNKNhan.Text.Trim());
                                                            ctchungtu.SoPhieu4 = lichsuchungtuCat.SoPhieu;
                                                        }
                                                        else
                                                            if (ctchungtu.YeuCauCat == false)
                                                            {
                                                                ctchungtu.YeuCauCat5 = true;
                                                                ctchungtu.CatNK_MaCN5 = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                                                                ctchungtu.CatNK_DanhBo5 = txtDanhBo_Cat.Text.Trim();
                                                                ctchungtu.CatNK_HoTen5 = txtHoTen_Cat.Text.Trim();
                                                                ctchungtu.CatNK_DiaChi5 = txtDiaChi_Cat.Text.Trim();
                                                                ctchungtu.CatNK_SoNKCat5 = int.Parse(txtSoNKNhan.Text.Trim());
                                                                ctchungtu.SoPhieu5 = lichsuchungtuCat.SoPhieu;
                                                            }

                                            #endregion

                                            _cChungTu.SuaCT(ctchungtu);
                                        }
                                    }
                                }
                                _cChungTu.SubmitChanges();
                                scope.Complete();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        else
                            MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmNhanDM_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtDiaChi_Cat_TextChanged(object sender, EventArgs e)
        {
            txtDiaChiCT_Cat.Text = txtDiaChi_Cat.Text.Trim();
        }

        public void CopyLichSuChungTu(LichSuChungTu A, ref LichSuChungTu B)
        {
            B.MaDonTXL = A.MaDonTXL;
            B.MaDonTBC = A.MaDonTBC;
            B.MaDon = A.MaDon;
            B.DanhBo = A.DanhBo;
            B.MaLCT = A.MaLCT;
            B.MaCT = A.MaCT;
            B.SoNKTong = A.SoNKTong;
            B.SoNKDangKy = A.SoNKDangKy;
            B.ThoiHan = A.ThoiHan;
            B.NgayHetHan = A.NgayHetHan;
            B.GhiChu = A.GhiChu;
            B.Lo = A.Lo;
            B.Phong = A.Phong;
        }

        private void cmbLoaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtThoiHan.Text = ((LoaiChungTu)cmbLoaiCT.SelectedItem).ThoiHan.ToString();
        }

        private void txtMaCT_Leave(object sender, EventArgs e)
        {
            if (_cChungTu.CheckExist_CT(txtDanhBo_Nhan.Text.Trim(), txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString())))
                MessageBox.Show("Số đăng ký này đã đăng ký với danh bạ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (_cChungTu.CheckExist_CT(txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString())))
                    MessageBox.Show("Số đăng ký này đã có đăng ký trước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvDSDanhBo.DataSource = _cChungTu.GetDSCT(txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString()));
        }
    }
}
