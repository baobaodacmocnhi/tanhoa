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
using System.Transactions;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmCatChuyenDM : Form
    {
        string _mnu = "mnuDCBD";
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CThuTien _cThuTien = new CThuTien();
        CChungTu _cChungTu = new CChungTu();
        CDHN _cDocSo = new CDHN();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();

        ChungTu_ChiTiet _ctchungtu = null;
        ChungTu_LichSu _lichsuchungtu = null;
        CDataTransfer _dataT = new CDataTransfer();
        decimal _MaLSCT = -1;

        public frmCatChuyenDM()
        {
            InitializeComponent();
        }

        public frmCatChuyenDM(CDataTransfer dataT)
        {
            InitializeComponent();
            _dataT = dataT;
        }

        public frmCatChuyenDM(decimal MaLSCT)
        {
            _MaLSCT = MaLSCT;
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

            if (_MaLSCT != -1)
            {
                _lichsuchungtu = _cChungTu.getLSCTbyID(_MaLSCT);

                cmbChiNhanh_Cat.SelectedValue = _lichsuchungtu.CatNK_MaCN.Value;
                txtDanhBo_Cat.Text = _lichsuchungtu.CatNK_DanhBo;
                txtHoTen_Cat.Text = _lichsuchungtu.CatNK_HoTen;
                txtDiaChi_Cat.Text = _lichsuchungtu.CatNK_DiaChi;
                txtGhiChu_Cat.Text = _lichsuchungtu.CatNK_GhiChu;
                ///
                txtMaCT_Cat.Text = _lichsuchungtu.MaCT;
                txtSoNK_Cat.Text = _lichsuchungtu.SoNK.Value.ToString();
                ///
                cmbChiNhanh_Nhan.SelectedValue = _lichsuchungtu.NhanNK_MaCN.Value;
                txtDanhBo_Nhan.Text = _lichsuchungtu.NhanNK_DanhBo;
                txtHoTen_Nhan.Text = _lichsuchungtu.NhanNK_HoTen;
                txtDiaChi_Nhan.Text = _lichsuchungtu.NhanNK_DiaChi;
                txtGhiChu_Nhan.Text = _lichsuchungtu.NhanNK_GhiChu;
            }
            else
            {
                _ctchungtu = _cChungTu.GetCT(_dataT.DanhBo, _dataT.MaCT, _dataT.MaLCT);

                txtDanhBo_Cat.Text = _ctchungtu.DanhBo;
                txtHoTen_Cat.Text = _dataT.HoTen;
                txtDiaChi_Cat.Text = _ctchungtu.ChungTu.DiaChi;
                cmbLoaiCT_Cat.SelectedValue = _ctchungtu.ChungTu.MaLCT;
                txtMaCT_Cat.Text = _ctchungtu.MaCT;
            }
        }

        public void LoadDS(HOADON hoadon)
        {
            txtDanhBo_Nhan.Text = hoadon.DANHBA;
            txtHoTen_Nhan.Text = hoadon.TENKH;
            txtDiaChi_Nhan.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
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
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_lichsuchungtu == null && txtSoNK_Cat.Text.Trim() != "" && txtSoNK_Cat.Text.Trim() != "0" && cmbChiNhanh_Nhan.SelectedIndex != -1)
                        using (var scope = new TransactionScope())
                        {
                            if (_ctchungtu.SoNKDangKy < int.Parse(txtSoNK_Cat.Text.Trim()))
                            {
                                MessageBox.Show("Cắt vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ///Cùng Chi Nhánh
                            if (((ChiNhanh)cmbChiNhanh_Nhan.SelectedItem).TenCN.ToUpper().Contains("TÂN HÒA")==true)
                            //if (_cChiNhanh.getChiNhanhbyID(int.Parse(cmbChiNhanh_Nhan.SelectedValue.ToString())).TenCN.ToUpper().Contains("TÂN HÒA"))
                            {
                                ///Cập nhật ChungTu_ChiTiet, Danh Bộ Cắt
                                _ctchungtu.SoNKDangKy -= int.Parse(txtSoNK_Cat.Text.Trim());
                                _ctchungtu.GhiChu = txtGhiChu_Cat.Text.Trim();
                                _ctchungtu.ModifyDate = DateTime.Now;
                                _ctchungtu.ModifyBy = CTaiKhoan.MaUser;

                                ChungTu_ChiTiet ctchungtuNhan = new ChungTu_ChiTiet();
                                ///Nếu Chứng Từ đã đăng ký với Danh Bộ
                                if (_cChungTu.CheckExist_CT(txtDanhBo_Nhan.Text.Trim(), txtMaCT_Cat.Text.Trim(), int.Parse(cmbLoaiCT_Cat.SelectedValue.ToString())))
                                {
                                    ///Cập nhật ChungTu_ChiTiet, Danh Bộ Nhận
                                    ctchungtuNhan = _cChungTu.GetCT(txtDanhBo_Nhan.Text.Trim(), txtMaCT_Cat.Text.Trim(), int.Parse(cmbLoaiCT_Cat.SelectedValue.ToString()));
                                    ctchungtuNhan.SoNKDangKy += int.Parse(txtSoNK_Cat.Text.Trim());
                                    ctchungtuNhan.GhiChu = txtGhiChu_Nhan.Text.Trim();
                                    _cChungTu.SuaCT(ctchungtuNhan);
                                }
                                ///Nếu Chứng Từ chưa đăng ký với Danh Bộ
                                else
                                {
                                    ///Thêm ChungTu_ChiTiet, Danh Bộ Nhận
                                    ctchungtuNhan.DanhBo = txtDanhBo_Nhan.Text.Trim();
                                    ctchungtuNhan.MaLCT = int.Parse(cmbLoaiCT_Cat.SelectedValue.ToString());
                                    ctchungtuNhan.MaCT = txtMaCT_Cat.Text.Trim();
                                    ctchungtuNhan.SoNKDangKy = int.Parse(txtSoNK_Cat.Text.Trim());
                                    ctchungtuNhan.GhiChu = txtGhiChu_Nhan.Text.Trim();
                                    _cChungTu.ThemCT(ctchungtuNhan);
                                }
                                ///Cập nhật ChungTu_LichSu, Chứng Từ & Danh Bộ Cắt
                                ChungTu_LichSu lichsuchungtu = new ChungTu_LichSu();
                                switch (_dataT.Loai)
                                {
                                    case "MaDonMoi":
                                        lichsuchungtu.MaDonMoi = _dataT.MaDonMoi;
                                        lichsuchungtu.STT = _dataT.STT;
                                        break;
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

                                lichsuchungtu.MaLCT = _ctchungtu.MaLCT;
                                lichsuchungtu.MaCT = _ctchungtu.MaCT;
                                lichsuchungtu.DanhBo = _ctchungtu.DanhBo;
                                lichsuchungtu.SoNKTong = _ctchungtu.ChungTu.SoNKTong;
                                lichsuchungtu.SoNKDangKy = _ctchungtu.SoNKDangKy;
                                lichsuchungtu.ThoiHan = _ctchungtu.ThoiHan;
                                lichsuchungtu.NgayHetHan = _ctchungtu.NgayHetHan;
                                ///
                                lichsuchungtu.SoPhieu = null;
                                lichsuchungtu.CatDM = true;
                                lichsuchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_Cat.SelectedValue.ToString());
                                lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                lichsuchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                lichsuchungtu.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
                                lichsuchungtu.CatNK_GhiChu = txtGhiChu_Cat.Text.Trim();
                                lichsuchungtu.NhanNK_MaCN = int.Parse(cmbChiNhanh_Nhan.SelectedValue.ToString());
                                lichsuchungtu.NhanNK_DanhBo = txtDanhBo_Nhan.Text.Trim();
                                lichsuchungtu.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
                                lichsuchungtu.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();
                                lichsuchungtu.SoNK = int.Parse(txtSoNK_Cat.Text.Trim());

                                _cChungTu.ThemLichSuChungTu(lichsuchungtu);

                                ///Cập nhật ChungTu_LichSu, Chứng Từ & Danh Bộ Nhận
                                ChungTu_LichSu lichsuchungtuNhan = new ChungTu_LichSu();
                                switch (_dataT.Loai)
                                {
                                    case "MaDonMoi":
                                        lichsuchungtu.MaDonMoi = _dataT.MaDonMoi;
                                        lichsuchungtu.STT = _dataT.STT;
                                        break;
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

                                lichsuchungtuNhan.MaLCT = ctchungtuNhan.MaLCT;
                                lichsuchungtuNhan.MaCT = ctchungtuNhan.MaCT;
                                lichsuchungtuNhan.DanhBo = ctchungtuNhan.DanhBo;
                                lichsuchungtuNhan.SoNKTong = ctchungtuNhan.ChungTu.SoNKTong;
                                lichsuchungtuNhan.SoNK = int.Parse(txtSoNK_Cat.Text.Trim());
                                lichsuchungtuNhan.SoNKDangKy = ctchungtuNhan.SoNKDangKy;
                                lichsuchungtuNhan.ThoiHan = ctchungtuNhan.ThoiHan;
                                lichsuchungtuNhan.NgayHetHan = ctchungtuNhan.NgayHetHan;
                                ///Chuyển đổi vị trí Cắt & Nhận
                                lichsuchungtuNhan.CatNK_MaCN = lichsuchungtu.NhanNK_MaCN;
                                lichsuchungtuNhan.CatNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
                                lichsuchungtuNhan.CatNK_HoTen = lichsuchungtu.NhanNK_HoTen;
                                lichsuchungtuNhan.CatNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
                                lichsuchungtuNhan.CatNK_MaCN = lichsuchungtu.NhanNK_MaCN;
                                lichsuchungtuNhan.NhanDM = true;
                                lichsuchungtuNhan.NhanNK_MaCN = lichsuchungtu.CatNK_MaCN;
                                lichsuchungtuNhan.NhanNK_DanhBo = lichsuchungtu.CatNK_DanhBo;
                                lichsuchungtuNhan.NhanNK_HoTen = lichsuchungtu.CatNK_HoTen;
                                lichsuchungtuNhan.NhanNK_DiaChi = lichsuchungtu.CatNK_DiaChi;
                                lichsuchungtuNhan.NhanNK_GhiChu = txtGhiChu_Nhan.Text.Trim();
                                lichsuchungtuNhan.SoNK = lichsuchungtu.SoNK;

                                _cChungTu.ThemLichSuChungTu(lichsuchungtuNhan);
                            }
                            ///Khác Chi Nhánh
                            else
                            {
                                _ctchungtu.SoNKDangKy -= int.Parse(txtSoNK_Cat.Text.Trim());
                                _ctchungtu.GhiChu = txtGhiChu_Cat.Text.Trim();
                                _cChungTu.SuaCT(_ctchungtu);

                                ChungTu_LichSu lichsuchungtu = new ChungTu_LichSu();
                                switch (_dataT.Loai)
                                {
                                    case "MaDonMoi":
                                        lichsuchungtu.MaDonMoi = _dataT.MaDonMoi;
                                        lichsuchungtu.STT = _dataT.STT;
                                        break;
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

                                lichsuchungtu.MaLCT = _ctchungtu.MaLCT;
                                lichsuchungtu.MaCT = _ctchungtu.MaCT;
                                lichsuchungtu.DanhBo = _ctchungtu.DanhBo;
                                lichsuchungtu.SoNKTong = _ctchungtu.ChungTu.SoNKTong;
                                lichsuchungtu.SoNKDangKy = _ctchungtu.SoNKDangKy;
                                lichsuchungtu.ThoiHan = _ctchungtu.ThoiHan;
                                lichsuchungtu.NgayHetHan = _ctchungtu.NgayHetHan;
                                ///
                                lichsuchungtu.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                lichsuchungtu.CatDM = true;
                                lichsuchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_Cat.SelectedValue.ToString());
                                lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                                lichsuchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                                lichsuchungtu.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
                                lichsuchungtu.CatNK_GhiChu = txtGhiChu_Cat.Text.Trim();
                                lichsuchungtu.NhanNK_MaCN = int.Parse(cmbChiNhanh_Nhan.SelectedValue.ToString());
                                lichsuchungtu.NhanNK_DanhBo = txtDanhBo_Nhan.Text.Trim();
                                lichsuchungtu.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
                                lichsuchungtu.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();
                                lichsuchungtu.SoNK = int.Parse(txtSoNK_Cat.Text.Trim());
                                lichsuchungtu.NhanNK_GhiChu = txtGhiChu_Nhan.Text.Trim();
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
                            _cChungTu.SubmitChanges();
                            scope.Complete();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
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
                //if (_lichsuchungtu != null)
                //{
                    MessageBox.Show("Xin liên hệ BaoBao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.DialogResult = DialogResult.OK;
                    //this.Close();
                //}
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtGhiChu_Nhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnThem.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                MessageBox.Show("Xin liên hệ BaoBao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //if (_lichsuchungtu != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                //    if (_cChungTu.XoaLichSuChungTu(_lichsuchungtu))
                //    {
                //        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        this.DialogResult = DialogResult.OK;
                //        this.Close();
                //    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
