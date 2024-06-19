using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.QuanTri;
using System.Transactions;
using KTKS_DonKH.DAL;
using KTKS_DonKH.wrThuongVu;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmSoDK : Form
    {
        string _mnu = "mnuDCBD";
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CThuTien _cThuTien = new CThuTien();
        wsThuongVu _wsThuongVu = new wsThuongVu();
        ChungTu_LichSu _LSCT = null;
        CDataTransfer _dataT = new CDataTransfer();
        HOADON _hd = null;
        bool _flagLoadFirst = false;

        public frmSoDK()
        {
            InitializeComponent();
        }

        public frmSoDK(CDataTransfer dataT)
        {
            InitializeComponent();
            _dataT = dataT;
        }

        public frmSoDK(ChungTu_LichSu LSCT)
        {
            InitializeComponent();
            _LSCT = LSCT;
        }

        private void frmSoDK_Load(object sender, EventArgs e)
        {
            dgvDSDanhBo.AutoGenerateColumns = false;
            try
            {
                this.Location = new Point(70, 70);

                cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu();
                cmbLoaiCT.DisplayMember = "TenLCT";
                cmbLoaiCT.ValueMember = "MaLCT";
                cmbLoaiCT.SelectedIndex = 14;

                cmbChiNhanh_YCC1.DataSource = _cChiNhanh.LoadDSChiNhanh("Tân Hòa");
                cmbChiNhanh_YCC1.DisplayMember = "TenCN";
                cmbChiNhanh_YCC1.ValueMember = "MaCN";

                cmbChiNhanh_YCC2.DataSource = _cChiNhanh.LoadDSChiNhanh("Tân Hòa");
                cmbChiNhanh_YCC2.DisplayMember = "TenCN";
                cmbChiNhanh_YCC2.ValueMember = "MaCN";

                cmbChiNhanh_YCC3.DataSource = _cChiNhanh.LoadDSChiNhanh("Tân Hòa");
                cmbChiNhanh_YCC3.DisplayMember = "TenCN";
                cmbChiNhanh_YCC3.ValueMember = "MaCN";

                cmbChiNhanh_YCC4.DataSource = _cChiNhanh.LoadDSChiNhanh("Tân Hòa");
                cmbChiNhanh_YCC4.DisplayMember = "TenCN";
                cmbChiNhanh_YCC4.ValueMember = "MaCN";

                cmbChiNhanh_YCC5.DataSource = _cChiNhanh.LoadDSChiNhanh("Tân Hòa");
                cmbChiNhanh_YCC5.DisplayMember = "TenCN";
                cmbChiNhanh_YCC5.ValueMember = "MaCN";

                txtHoTenDB.Text = _dataT.HoTenDB;
                txtDiaChiDB.Text = _dataT.DiaChiDB;
                //hiện thị từ DCBD, bình thường trước giờ
                if (_LSCT == null)
                {
                    txtDanhBo.Text = _dataT.DanhBo;
                    _hd = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                    if (_dataT.MaCT != "")
                    {
                        if (_cChungTu.CheckExist_CT(_dataT.DanhBo, _dataT.MaCT, _dataT.MaLCT))
                        {
                            ChungTu_ChiTiet ctchungtu = _cChungTu.GetCT(_dataT.DanhBo, _dataT.MaCT, _dataT.MaLCT);
                            if (ctchungtu.YeuCauCat2)
                                this.Location = new Point(10, 70);

                            txtDanhBo.Text = ctchungtu.DanhBo;
                            chkKhacDiaBan.Checked = ctchungtu.ChungTu.KhacDiaBan;
                            chkThuongTru.Checked = ctchungtu.ThuongTru;
                            chkTamTru.Checked = ctchungtu.TamTru;

                            cmbLoaiCT.SelectedValue = ctchungtu.ChungTu.MaLCT;
                            txtMaCT.Text = ctchungtu.MaCT;
                            txtHoTen.Text = ctchungtu.ChungTu.HoTen;
                            if (ctchungtu.ChungTu.NgaySinh != null)
                                txtNgaySinh.Text = ctchungtu.ChungTu.NgaySinh.Value.ToString("dd/MM/yyyy");
                            txtDiaChi.Text = ctchungtu.ChungTu.DiaChi;
                            txtSoNKTong.Text = ctchungtu.ChungTu.SoNKTong.ToString();
                            txtSoNKDangKy.Text = ctchungtu.SoNKDangKy.ToString();
                            txtLo.Text = ctchungtu.Lo;
                            txtPhong.Text = ctchungtu.Phong;
                            if (ctchungtu.ThoiHan != null)
                                txtThoiHan.Text = ctchungtu.ThoiHan.Value.ToString();
                            if (ctchungtu.NgayHetHan != null)
                            {
                                dateHetHan.Enabled = true;
                                dateHetHan.Value = ctchungtu.NgayHetHan.Value;
                            }
                            txtGhiChu.Text = ctchungtu.GhiChu;
                            txtHoTenCat.Text = ctchungtu.HoTenCat;

                            if (ctchungtu.YeuCauCat)
                            {
                                chkYCCat1.Checked = true;
                                cmbChiNhanh_YCC1.SelectedValue = ctchungtu.CatNK_MaCN;
                                txtDanhBo_Cat_YCC1.Text = ctchungtu.CatNK_DanhBo;
                                txtHoTen_Cat_YCC1.Text = ctchungtu.CatNK_HoTen;
                                txtDiaChiKH_Cat_YCC1.Text = ctchungtu.CatNK_DiaChi;
                                txtSoNKCat_YCC1.Text = ctchungtu.CatNK_SoNKCat.ToString();
                                txtHoTensCat_YCC1.Text = ctchungtu.CatNK_HoTens;
                            }
                            if (ctchungtu.YeuCauCat2)
                            {
                                panel_YCCat2.Visible = true;
                                this.Size = new Size(1323, 557);
                                this.Location = new Point(10, 70);
                                ///
                                chkYCCat2.Checked = true;
                                cmbChiNhanh_YCC2.SelectedValue = ctchungtu.CatNK_MaCN2;
                                txtDanhBo_Cat_YCC2.Text = ctchungtu.CatNK_DanhBo2;
                                txtHoTen_Cat_YCC2.Text = ctchungtu.CatNK_HoTen2;
                                txtDiaChiKH_Cat_YCC2.Text = ctchungtu.CatNK_DiaChi2;
                                txtSoNKCat_YCC2.Text = ctchungtu.CatNK_SoNKCat2.ToString();
                                txtHoTensCat_YCC2.Text = ctchungtu.CatNK_HoTens2;
                            }
                            if (ctchungtu.YeuCauCat3)
                            {
                                panel_YCCat3.Visible = true;
                                this.Size = new Size(1323, 557);
                                ///
                                chkYCCat3.Checked = true;
                                cmbChiNhanh_YCC3.SelectedValue = ctchungtu.CatNK_MaCN3;
                                txtDanhBo_Cat_YCC3.Text = ctchungtu.CatNK_DanhBo3;
                                txtHoTen_Cat_YCC3.Text = ctchungtu.CatNK_HoTen3;
                                txtDiaChiKH_Cat_YCC3.Text = ctchungtu.CatNK_DiaChi3;
                                txtSoNKCat_YCC3.Text = ctchungtu.CatNK_SoNKCat3.ToString();
                                txtHoTensCat_YCC3.Text = ctchungtu.CatNK_HoTens3;
                            }
                            if (ctchungtu.YeuCauCat4)
                            {
                                panel_YCCat4.Visible = true;
                                this.Size = new Size(1323, 557);
                                ///
                                chkYCCat4.Checked = true;
                                cmbChiNhanh_YCC4.SelectedValue = ctchungtu.CatNK_MaCN4;
                                txtDanhBo_Cat_YCC4.Text = ctchungtu.CatNK_DanhBo4;
                                txtHoTen_Cat_YCC4.Text = ctchungtu.CatNK_HoTen4;
                                txtDiaChiKH_Cat_YCC4.Text = ctchungtu.CatNK_DiaChi4;
                                txtSoNKCat_YCC4.Text = ctchungtu.CatNK_SoNKCat4.ToString();
                                txtHoTensCat_YCC4.Text = ctchungtu.CatNK_HoTens4;
                            }
                            if (ctchungtu.YeuCauCat5)
                            {
                                panel_YCCat5.Visible = true;
                                this.Size = new Size(1323, 557);
                                ///
                                chkYCCat5.Checked = true;
                                cmbChiNhanh_YCC5.SelectedValue = ctchungtu.CatNK_MaCN5;
                                txtDanhBo_Cat_YCC5.Text = ctchungtu.CatNK_DanhBo5;
                                txtHoTen_Cat_YCC5.Text = ctchungtu.CatNK_HoTen5;
                                txtDiaChiKH_Cat_YCC5.Text = ctchungtu.CatNK_DiaChi5;
                                txtSoNKCat_YCC5.Text = ctchungtu.CatNK_SoNKCat5.ToString();
                                txtHoTensCat_YCC5.Text = ctchungtu.CatNK_HoTens5;
                            }
                        }
                        else
                        {
                            txtHoTen.Text = _dataT.HoTen;
                            txtDiaChi.Text = _dataT.DiaChi;
                        }
                        dgvDSDanhBo.DataSource = _cChungTu.getDS_ChiTiet(txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString()));
                    }
                    else
                    {
                        txtHoTen.Text = _dataT.HoTen;
                        txtDiaChi.Text = _dataT.DiaChi;
                        dateHetHan.Enabled = true;
                    }
                }
                //hiện thị cắt chuyển từ DSDCBD, cái làm mới
                else
                {
                    if (_cChungTu.CheckExist_CT(_LSCT.DanhBo, _LSCT.MaCT, _LSCT.MaLCT.Value))
                    {
                        txtHoTenDB.Text = _LSCT.NhanNK_HoTen;
                        txtDiaChiDB.Text = _LSCT.NhanNK_DiaChi;
                        _hd = _cThuTien.GetMoiNhat(_LSCT.DanhBo);
                        ChungTu_ChiTiet ctchungtu = _cChungTu.GetCT(_LSCT.DanhBo, _LSCT.MaCT, _LSCT.MaLCT.Value);
                        if (ctchungtu.YeuCauCat2)
                            this.Location = new Point(10, 70);

                        txtDanhBo.Text = ctchungtu.DanhBo;
                        chkKhacDiaBan.Checked = ctchungtu.ChungTu.KhacDiaBan;
                        chkThuongTru.Checked = ctchungtu.ThuongTru;
                        chkTamTru.Checked = ctchungtu.TamTru;

                        cmbLoaiCT.SelectedValue = ctchungtu.ChungTu.MaLCT;
                        txtMaCT.Text = ctchungtu.MaCT;
                        txtHoTen.Text = ctchungtu.ChungTu.HoTen;
                        if (ctchungtu.ChungTu.NgaySinh != null)
                            txtNgaySinh.Text = ctchungtu.ChungTu.NgaySinh.Value.ToString("dd/MM/yyyy");
                        txtDiaChi.Text = ctchungtu.ChungTu.DiaChi;
                        txtSoNKTong.Text = ctchungtu.ChungTu.SoNKTong.ToString();
                        txtSoNKDangKy.Text = ctchungtu.SoNKDangKy.ToString();
                        txtLo.Text = ctchungtu.Lo;
                        txtPhong.Text = ctchungtu.Phong;
                        if (ctchungtu.ThoiHan != null)
                            txtThoiHan.Text = ctchungtu.ThoiHan.Value.ToString();
                        if (ctchungtu.NgayHetHan != null)
                        {
                            dateHetHan.Enabled = true;
                            dateHetHan.Value = ctchungtu.NgayHetHan.Value;
                        }

                        txtGhiChu.Text = ctchungtu.GhiChu;
                        txtHoTenCat.Text = ctchungtu.HoTenCat;

                        if (ctchungtu.YeuCauCat)
                        {
                            chkYCCat1.Checked = true;
                            cmbChiNhanh_YCC1.SelectedValue = ctchungtu.CatNK_MaCN;
                            txtDanhBo_Cat_YCC1.Text = ctchungtu.CatNK_DanhBo;
                            txtHoTen_Cat_YCC1.Text = ctchungtu.CatNK_HoTen;
                            txtDiaChiKH_Cat_YCC1.Text = ctchungtu.CatNK_DiaChi;
                            txtSoNKCat_YCC1.Text = ctchungtu.CatNK_SoNKCat.ToString();
                            txtHoTensCat_YCC1.Text = ctchungtu.CatNK_HoTens;
                        }
                        if (ctchungtu.YeuCauCat2)
                        {
                            panel_YCCat2.Visible = true;
                            this.Size = new Size(1323, 557);
                            this.Location = new Point(10, 70);
                            ///
                            chkYCCat2.Checked = true;
                            cmbChiNhanh_YCC2.SelectedValue = ctchungtu.CatNK_MaCN2;
                            txtDanhBo_Cat_YCC2.Text = ctchungtu.CatNK_DanhBo2;
                            txtHoTen_Cat_YCC2.Text = ctchungtu.CatNK_HoTen2;
                            txtDiaChiKH_Cat_YCC2.Text = ctchungtu.CatNK_DiaChi2;
                            txtSoNKCat_YCC2.Text = ctchungtu.CatNK_SoNKCat2.ToString();
                            txtHoTensCat_YCC2.Text = ctchungtu.CatNK_HoTens2;
                        }
                        if (ctchungtu.YeuCauCat3)
                        {
                            panel_YCCat3.Visible = true;
                            this.Size = new Size(1323, 557);
                            ///
                            chkYCCat3.Checked = true;
                            cmbChiNhanh_YCC3.SelectedValue = ctchungtu.CatNK_MaCN3;
                            txtDanhBo_Cat_YCC3.Text = ctchungtu.CatNK_DanhBo3;
                            txtHoTen_Cat_YCC3.Text = ctchungtu.CatNK_HoTen3;
                            txtDiaChiKH_Cat_YCC3.Text = ctchungtu.CatNK_DiaChi3;
                            txtSoNKCat_YCC3.Text = ctchungtu.CatNK_SoNKCat3.ToString();
                            txtHoTensCat_YCC3.Text = ctchungtu.CatNK_HoTens3;
                        }
                        if (ctchungtu.YeuCauCat4)
                        {
                            panel_YCCat4.Visible = true;
                            this.Size = new Size(1323, 557);
                            ///
                            chkYCCat4.Checked = true;
                            cmbChiNhanh_YCC4.SelectedValue = ctchungtu.CatNK_MaCN4;
                            txtDanhBo_Cat_YCC4.Text = ctchungtu.CatNK_DanhBo4;
                            txtHoTen_Cat_YCC4.Text = ctchungtu.CatNK_HoTen4;
                            txtDiaChiKH_Cat_YCC4.Text = ctchungtu.CatNK_DiaChi4;
                            txtSoNKCat_YCC4.Text = ctchungtu.CatNK_SoNKCat4.ToString();
                            txtHoTensCat_YCC4.Text = ctchungtu.CatNK_HoTens4;
                        }
                        if (ctchungtu.YeuCauCat5)
                        {
                            panel_YCCat5.Visible = true;
                            this.Size = new Size(1323, 557);
                            ///
                            chkYCCat5.Checked = true;
                            cmbChiNhanh_YCC5.SelectedValue = ctchungtu.CatNK_MaCN5;
                            txtDanhBo_Cat_YCC5.Text = ctchungtu.CatNK_DanhBo5;
                            txtHoTen_Cat_YCC5.Text = ctchungtu.CatNK_HoTen5;
                            txtDiaChiKH_Cat_YCC5.Text = ctchungtu.CatNK_DiaChi5;
                            txtSoNKCat_YCC5.Text = ctchungtu.CatNK_SoNKCat5.ToString();
                            txtHoTensCat_YCC5.Text = ctchungtu.CatNK_HoTens5;
                        }
                    }
                    else
                    {
                        txtHoTen.Text = _dataT.HoTen;
                        txtDiaChi.Text = _dataT.DiaChi;
                    }
                    dgvDSDanhBo.DataSource = _cChungTu.getDS_ChiTiet(txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString()));
                }
                _flagLoadFirst = true;
                if (_dataT.Loai == "ChungCu")
                {
                    btnThem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (txtMaCT.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "0" && txtSoNKDangKy.Text.Trim() != "0" && txtDanhBo.Text.Trim().Length == 11)
                    {
                        string resultCheckCCCD = "";
                        int result = _wsThuongVu.checkExists_CCCD("", txtMaCT.Text.Trim(), out resultCheckCCCD);
                        if (result == 1)
                        {
                            if (!resultCheckCCCD.Contains("Tân Hòa"))
                            {
                                MessageBox.Show(resultCheckCCCD, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                if (_cChungTu.CheckExist_CT(txtDanhBo.Text.Trim(), txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString())) == true)
                                {
                                    MessageBox.Show("Dữ liệu đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        else
                            if (result == -1)
                            {
                                MessageBox.Show("Lỗi, vui lòng thao tác lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            ///Kiểm tra Số Chứng Từ
                            if (_cChungTu.CheckExist(txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString())) == false)
                            {
                                ChungTu chungtu = new ChungTu();
                                chungtu.MaCT = txtMaCT.Text.Trim();
                                if (txtNgaySinh.Text.ToString() != "")
                                {
                                    string[] NgaySinhs = null;
                                    if (txtNgaySinh.Text.ToString().Contains("/"))
                                        NgaySinhs = txtNgaySinh.Text.ToString().Split('/');
                                    else
                                        if (txtNgaySinh.Text.ToString().Contains("-"))
                                            NgaySinhs = txtNgaySinh.Text.ToString().Split('-');
                                    if (NgaySinhs != null && NgaySinhs.Count() == 3)
                                        chungtu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                                    else
                                        chungtu.NgaySinh = new DateTime(int.Parse(txtNgaySinh.Text.Trim()), 1, 1);
                                }
                                chungtu.HoTen = txtHoTen.Text.Trim();
                                chungtu.DiaChi = txtDiaChi.Text.Trim();
                                chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());
                                chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
                                chungtu.KhacDiaBan = chkKhacDiaBan.Checked;
                                _cChungTu.Them(chungtu);
                            }
                            ///Lấy thông tin Chứng Từ để kiểm tra
                            ChungTu _chungtu = _cChungTu.Get(txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString()));
                            if (_chungtu.SoNKTong - _chungtu.ChungTu_ChiTiets.Sum(o => o.SoNKDangKy) < int.Parse(txtSoNKDangKy.Text.Trim()))
                            {
                                MessageBox.Show("Vượt Nhân Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ChungTu_ChiTiet ctchungtu = new ChungTu_ChiTiet();
                            ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                            ctchungtu.ThuongTru = chkThuongTru.Checked;
                            ctchungtu.TamTru = chkTamTru.Checked;
                            ctchungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
                            ctchungtu.MaCT = txtMaCT.Text.Trim();
                            ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                            if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                            {
                                ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                                ctchungtu.NgayHetHan = dateHetHan.Value;
                            }
                            ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                            ctchungtu.HoTenCat = txtHoTenCat.Text.Trim();
                            ctchungtu.Lo = txtLo.Text.Trim();
                            ctchungtu.Phong = txtPhong.Text.Trim();
                            if (_hd != null)
                            {
                                ctchungtu.Phuong = _hd.Phuong;
                                ctchungtu.Quan = _hd.Quan;
                            }
                            #region Yêu Cầu Cắt
                            if (chkYCCat1.Checked)
                                if (txtSoNKCat_YCC1.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC1", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (chkYCCat2.Checked)
                                if (txtSoNKCat_YCC2.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC2", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (chkYCCat3.Checked)
                                if (txtSoNKCat_YCC3.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC3", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (chkYCCat4.Checked)
                                if (txtSoNKCat_YCC4.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC4", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (chkYCCat5.Checked)
                                if (txtSoNKCat_YCC5.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            #endregion
                            if (_cChungTu.ThemCT(ctchungtu))
                            {
                                ///Thêm Lịch Sử đầu tiên
                                ///Ghi thông tin Lịch Sử chung
                                ChungTu_LichSu lichsuchungtu = _cChungTu.ChungTuToLichSu(ctchungtu);
                                lichsuchungtu.Loai = "Thêm";
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
                                lichsuchungtu.Phuong = ctchungtu.Phuong;
                                lichsuchungtu.Quan = ctchungtu.Quan;
                                //lichsuchungtu.DanhBo = ctchungtu.DanhBo;
                                //lichsuchungtu.MaLCT = ctchungtu.MaLCT;
                                //lichsuchungtu.MaCT = ctchungtu.MaCT;
                                //lichsuchungtu.SoNKTong = _chungtu.SoNKTong;
                                //lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
                                //lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
                                //lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
                                //lichsuchungtu.GhiChu = ctchungtu.GhiChu;
                                //lichsuchungtu.Lo = ctchungtu.Lo;
                                //lichsuchungtu.Phong = ctchungtu.Phong;
                                //lichsuchungtu.ThuongTru = ctchungtu.ThuongTru;
                                //lichsuchungtu.TamTru = ctchungtu.TamTru;
                                _cChungTu.ThemLichSuChungTu(lichsuchungtu);
                                #region Yêu Cầu Cắt
                                if (chkYCCat1.Checked)
                                {
                                    ChungTu_LichSu lichsuchungtu1 = new ChungTu_LichSu();
                                    _cChungTu.CopyLichSuChungTu(lichsuchungtu, ref lichsuchungtu1);
                                    lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                    ///
                                    lichsuchungtu1.NhanNK_MaCN = _cChiNhanh.GetIDByTenCN("Tân Hòa");
                                    lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu1.NhanNK_HoTen = txtHoTenDB.Text.Trim();
                                    lichsuchungtu1.NhanNK_DiaChi = txtDiaChiDB.Text.Trim();
                                    lichsuchungtu1.NhanNK_GhiChu = txtGhiChu.Text.Trim();
                                    ///
                                    lichsuchungtu1.YeuCauCat = true;
                                    lichsuchungtu1.SoNK = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                                    lichsuchungtu1.CatNK_HoTens = txtHoTensCat_YCC1.Text.Trim();
                                    ///
                                    lichsuchungtu1.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                                    lichsuchungtu1.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                                    lichsuchungtu1.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                                    lichsuchungtu1.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();

                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                    else
                                        lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    lichsuchungtu1.PhieuDuocKy = true;

                                    if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                    {
                                        ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                        ctchungtu.YeuCauCat = true;
                                        ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                                        ctchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                                        ctchungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                                        ctchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                                        ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                                        ctchungtu.CatNK_HoTens = txtHoTensCat_YCC1.Text.Trim();
                                        ctchungtu.SoLuongDC_YCC = 1;
                                    }
                                }
                                if (chkYCCat2.Checked)
                                {
                                    ChungTu_LichSu lichsuchungtu1 = new ChungTu_LichSu();
                                    _cChungTu.CopyLichSuChungTu(lichsuchungtu, ref lichsuchungtu1);
                                    lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                    ///
                                    lichsuchungtu1.NhanNK_MaCN = _cChiNhanh.GetIDByTenCN("Tân Hòa");
                                    lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu1.NhanNK_HoTen = txtHoTenDB.Text.Trim();
                                    lichsuchungtu1.NhanNK_DiaChi = txtDiaChiDB.Text.Trim();
                                    lichsuchungtu1.NhanNK_GhiChu = txtGhiChu.Text.Trim();
                                    ///
                                    lichsuchungtu1.YeuCauCat = true;
                                    lichsuchungtu1.SoNK = int.Parse(txtSoNKCat_YCC2.Text.Trim());
                                    lichsuchungtu1.CatNK_HoTens = txtHoTensCat_YCC2.Text.Trim();
                                    ///
                                    lichsuchungtu1.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC2.SelectedValue.ToString());
                                    lichsuchungtu1.CatNK_DanhBo = txtDanhBo_Cat_YCC2.Text.Trim();
                                    lichsuchungtu1.CatNK_HoTen = txtHoTen_Cat_YCC2.Text.Trim();
                                    lichsuchungtu1.CatNK_DiaChi = txtDiaChiKH_Cat_YCC2.Text.Trim();

                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                    else
                                        lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    lichsuchungtu1.PhieuDuocKy = true;

                                    if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                    {
                                        ctchungtu.SoPhieu2 = lichsuchungtu1.SoPhieu;
                                        ctchungtu.YeuCauCat2 = true;
                                        ctchungtu.CatNK_MaCN2 = int.Parse(cmbChiNhanh_YCC2.SelectedValue.ToString());
                                        ctchungtu.CatNK_DanhBo2 = txtDanhBo_Cat_YCC2.Text.Trim();
                                        ctchungtu.CatNK_HoTen2 = txtHoTen_Cat_YCC2.Text.Trim();
                                        ctchungtu.CatNK_DiaChi2 = txtDiaChiKH_Cat_YCC2.Text.Trim();
                                        ctchungtu.CatNK_SoNKCat2 = int.Parse(txtSoNKCat_YCC2.Text.Trim());
                                        ctchungtu.CatNK_HoTens2 = txtHoTensCat_YCC2.Text.Trim();
                                        ctchungtu.SoLuongDC_YCC = 2;
                                    }
                                }
                                if (chkYCCat3.Checked)
                                {
                                    ChungTu_LichSu lichsuchungtu1 = new ChungTu_LichSu();
                                    _cChungTu.CopyLichSuChungTu(lichsuchungtu, ref lichsuchungtu1);
                                    lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                    ///
                                    lichsuchungtu1.NhanNK_MaCN = _cChiNhanh.GetIDByTenCN("Tân Hòa");
                                    lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu1.NhanNK_HoTen = txtHoTenDB.Text.Trim();
                                    lichsuchungtu1.NhanNK_DiaChi = txtDiaChiDB.Text.Trim();
                                    lichsuchungtu1.NhanNK_GhiChu = txtGhiChu.Text.Trim();
                                    ///
                                    lichsuchungtu1.YeuCauCat = true;
                                    lichsuchungtu1.SoNK = int.Parse(txtSoNKCat_YCC3.Text.Trim());
                                    lichsuchungtu1.CatNK_HoTens = txtHoTensCat_YCC3.Text.Trim();
                                    ///
                                    lichsuchungtu1.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC3.SelectedValue.ToString());
                                    lichsuchungtu1.CatNK_DanhBo = txtDanhBo_Cat_YCC3.Text.Trim();
                                    lichsuchungtu1.CatNK_HoTen = txtHoTen_Cat_YCC3.Text.Trim();
                                    lichsuchungtu1.CatNK_DiaChi = txtDiaChiKH_Cat_YCC3.Text.Trim();

                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                    else
                                        lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    lichsuchungtu1.PhieuDuocKy = true;

                                    if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                    {
                                        ctchungtu.SoPhieu3 = lichsuchungtu1.SoPhieu;
                                        ctchungtu.YeuCauCat3 = true;
                                        ctchungtu.CatNK_MaCN3 = int.Parse(cmbChiNhanh_YCC3.SelectedValue.ToString());
                                        ctchungtu.CatNK_DanhBo3 = txtDanhBo_Cat_YCC3.Text.Trim();
                                        ctchungtu.CatNK_HoTen3 = txtHoTen_Cat_YCC3.Text.Trim();
                                        ctchungtu.CatNK_DiaChi3 = txtDiaChiKH_Cat_YCC3.Text.Trim();
                                        ctchungtu.CatNK_SoNKCat3 = int.Parse(txtSoNKCat_YCC3.Text.Trim());
                                        ctchungtu.CatNK_HoTens3 = txtHoTensCat_YCC3.Text.Trim();
                                        ctchungtu.SoLuongDC_YCC = 3;
                                    }
                                }
                                if (chkYCCat4.Checked)
                                {
                                    ChungTu_LichSu lichsuchungtu1 = new ChungTu_LichSu();
                                    _cChungTu.CopyLichSuChungTu(lichsuchungtu, ref lichsuchungtu1);
                                    lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                    ///
                                    lichsuchungtu1.NhanNK_MaCN = _cChiNhanh.GetIDByTenCN("Tân Hòa");
                                    lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu1.NhanNK_HoTen = txtHoTenDB.Text.Trim();
                                    lichsuchungtu1.NhanNK_DiaChi = txtDiaChiDB.Text.Trim();
                                    lichsuchungtu1.NhanNK_GhiChu = txtGhiChu.Text.Trim();
                                    ///
                                    lichsuchungtu1.YeuCauCat = true;
                                    lichsuchungtu1.SoNK = int.Parse(txtSoNKCat_YCC4.Text.Trim());
                                    lichsuchungtu1.CatNK_HoTens = txtHoTensCat_YCC4.Text.Trim();
                                    ///
                                    lichsuchungtu1.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC4.SelectedValue.ToString());
                                    lichsuchungtu1.CatNK_DanhBo = txtDanhBo_Cat_YCC4.Text.Trim();
                                    lichsuchungtu1.CatNK_HoTen = txtHoTen_Cat_YCC4.Text.Trim();
                                    lichsuchungtu1.CatNK_DiaChi = txtDiaChiKH_Cat_YCC4.Text.Trim();

                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                    else
                                        lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    lichsuchungtu1.PhieuDuocKy = true;

                                    if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                    {
                                        ctchungtu.SoPhieu4 = lichsuchungtu1.SoPhieu;
                                        ctchungtu.YeuCauCat4 = true;
                                        ctchungtu.CatNK_MaCN4 = int.Parse(cmbChiNhanh_YCC4.SelectedValue.ToString());
                                        ctchungtu.CatNK_DanhBo4 = txtDanhBo_Cat_YCC4.Text.Trim();
                                        ctchungtu.CatNK_HoTen4 = txtHoTen_Cat_YCC4.Text.Trim();
                                        ctchungtu.CatNK_DiaChi4 = txtDiaChiKH_Cat_YCC4.Text.Trim();
                                        ctchungtu.CatNK_SoNKCat4 = int.Parse(txtSoNKCat_YCC4.Text.Trim());
                                        ctchungtu.CatNK_HoTens4 = txtHoTensCat_YCC4.Text.Trim();
                                        ctchungtu.SoLuongDC_YCC = 4;
                                    }
                                }
                                if (chkYCCat5.Checked)
                                {
                                    ChungTu_LichSu lichsuchungtu1 = new ChungTu_LichSu();
                                    _cChungTu.CopyLichSuChungTu(lichsuchungtu, ref lichsuchungtu1);
                                    lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                    ///
                                    lichsuchungtu1.NhanNK_MaCN = _cChiNhanh.GetIDByTenCN("Tân Hòa");
                                    lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu1.NhanNK_HoTen = txtHoTenDB.Text.Trim();
                                    lichsuchungtu1.NhanNK_DiaChi = txtDiaChiDB.Text.Trim();
                                    lichsuchungtu1.NhanNK_GhiChu = txtGhiChu.Text.Trim();
                                    ///
                                    lichsuchungtu1.YeuCauCat = true;
                                    lichsuchungtu1.SoNK = int.Parse(txtSoNKCat_YCC5.Text.Trim());
                                    lichsuchungtu1.CatNK_HoTens = txtHoTensCat_YCC5.Text.Trim();
                                    ///
                                    lichsuchungtu1.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC5.SelectedValue.ToString());
                                    lichsuchungtu1.CatNK_DanhBo = txtDanhBo_Cat_YCC5.Text.Trim();
                                    lichsuchungtu1.CatNK_HoTen = txtHoTen_Cat_YCC5.Text.Trim();
                                    lichsuchungtu1.CatNK_DiaChi = txtDiaChiKH_Cat_YCC5.Text.Trim();

                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                    else
                                        lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    lichsuchungtu1.PhieuDuocKy = true;

                                    if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                    {
                                        ctchungtu.SoPhieu5 = lichsuchungtu1.SoPhieu;
                                        ctchungtu.YeuCauCat5 = true;
                                        ctchungtu.CatNK_MaCN5 = int.Parse(cmbChiNhanh_YCC5.SelectedValue.ToString());
                                        ctchungtu.CatNK_DanhBo5 = txtDanhBo_Cat_YCC5.Text.Trim();
                                        ctchungtu.CatNK_HoTen5 = txtHoTen_Cat_YCC5.Text.Trim();
                                        ctchungtu.CatNK_DiaChi5 = txtDiaChiKH_Cat_YCC5.Text.Trim();
                                        ctchungtu.CatNK_SoNKCat5 = int.Parse(txtSoNKCat_YCC5.Text.Trim());
                                        ctchungtu.CatNK_HoTens5 = txtHoTensCat_YCC5.Text.Trim();
                                        ctchungtu.SoLuongDC_YCC = 5;
                                    }
                                }
                                #endregion
                                _cChungTu.SubmitChanges();
                                scope.Complete();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua") || _dataT.Loai == "ChungCu")
            {
                try
                {
                    if (txtMaCT.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "0")
                    {
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            ChungTu _chungtu = _cChungTu.Get(txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString()));
                            ChungTu_ChiTiet _ctchungtu = _cChungTu.GetCT(txtDanhBo.Text.Trim(), txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString()));
                            _chungtu.HoTen = txtHoTen.Text.Trim();
                            if (txtNgaySinh.Text.Trim() != "")
                            {
                                string[] NgaySinhs = null;
                                if (txtNgaySinh.Text.ToString().Contains("/"))
                                    NgaySinhs = txtNgaySinh.Text.ToString().Split('/');
                                else
                                    if (txtNgaySinh.Text.ToString().Contains("-"))
                                        NgaySinhs = txtNgaySinh.Text.ToString().Split('-');
                                if (NgaySinhs != null || NgaySinhs.Count() == 3)
                                    _chungtu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                                else
                                    _chungtu.NgaySinh = new DateTime(int.Parse(txtNgaySinh.Text.Trim()), 1, 1);
                            }
                            _chungtu.DiaChi = txtDiaChi.Text.Trim();
                            _chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());
                            if (_chungtu.MaLCT != int.Parse(cmbLoaiCT.SelectedValue.ToString()))
                            {
                                _ctchungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
                                _chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
                            }
                            _chungtu.KhacDiaBan = chkKhacDiaBan.Checked;
                            _cChungTu.Sua(_chungtu);
                            if (_chungtu.SoNKTong - _chungtu.ChungTu_ChiTiets.Sum(item => item.SoNKDangKy) + _ctchungtu.SoNKDangKy < int.Parse(txtSoNKDangKy.Text.Trim()))
                            {
                                MessageBox.Show("Vượt Nhân Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            _ctchungtu.ThuongTru = chkThuongTru.Checked;
                            _ctchungtu.TamTru = chkTamTru.Checked;
                            _ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                            _ctchungtu.Lo = txtLo.Text.Trim();
                            _ctchungtu.Phong = txtPhong.Text.Trim();
                            _ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                            _ctchungtu.HoTenCat = txtHoTenCat.Text.Trim();
                            if (_hd != null)
                            {
                                _ctchungtu.Phuong = _hd.Phuong;
                                _ctchungtu.Quan = _hd.Quan;
                            }
                            if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                            {
                                if (_ctchungtu.ThoiHan != int.Parse(txtThoiHan.Text.Trim()))
                                {
                                    _ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                                    ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                                    ///Khi gia hạn refresh lại ngày tạo để tính ngày gia hạn
                                    if (_ctchungtu.CreateDateGoc == null)
                                        _ctchungtu.CreateDateGoc = _ctchungtu.CreateDate;
                                    _ctchungtu.CreateDate = DateTime.Now;
                                    _ctchungtu.NgayHetHan = _ctchungtu.CreateDate.Value.AddMonths(int.Parse(txtThoiHan.Text.Trim()));
                                }
                            }
                            else
                            {
                                _ctchungtu.ThoiHan = null;
                                _ctchungtu.NgayHetHan = null;
                            }
                            if (chkSuaNgayHetHan.Checked)
                                if (_ctchungtu.NgayHetHan == null || _ctchungtu.NgayHetHan.Value.Date != dateHetHan.Value.Date)
                                {
                                    if (_ctchungtu.CreateDateGoc == null)
                                        _ctchungtu.CreateDateGoc = _ctchungtu.CreateDate;
                                    _ctchungtu.CreateDate = DateTime.Now;
                                    _ctchungtu.NgayHetHan = dateHetHan.Value;
                                }
                            #region Yêu Cầu Cắt

                            if (chkYCCat1.Checked)
                                if (txtSoNKCat_YCC1.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC1", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (chkYCCat2.Checked)
                                if (txtSoNKCat_YCC2.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC2", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (chkYCCat3.Checked)
                                if (txtSoNKCat_YCC3.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC3", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (chkYCCat4.Checked)
                                if (txtSoNKCat_YCC4.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC4", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (chkYCCat5.Checked)
                                if (txtSoNKCat_YCC5.Text.Trim() == "")
                                {
                                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                            #endregion
                            ///Ghi thông tin Lịch Sử chung
                            ChungTu_LichSu lichsuchungtu = _cChungTu.ChungTuToLichSu(_ctchungtu);
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
                            if (_hd != null)
                            {
                                lichsuchungtu.Phuong = _hd.Phuong;
                                lichsuchungtu.Quan = _hd.Quan;
                            }
                            if (_cChungTu.SuaCT(_ctchungtu))
                            {
                                ///Thêm Lịch Sử đầu tiên
                                _cChungTu.ThemLichSuChungTu(lichsuchungtu);
                                #region Yêu Cầu Cắt
                                if (chkYCCat1.Checked)
                                {
                                    if (_ctchungtu.SoPhieu != null)
                                    {
                                        ChungTu_LichSu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu.Value);
                                        _lichsuchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                                        _lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                                        _lichsuchungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                                        _lichsuchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                                        _lichsuchungtu.SoNK = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                                        _lichsuchungtu.CatNK_HoTens = txtHoTensCat_YCC1.Text.Trim();
                                        if (_cChungTu.SuaLichSuChungTu(_lichsuchungtu))
                                        {
                                            _ctchungtu.SoPhieu = _lichsuchungtu.SoPhieu;
                                            _ctchungtu.YeuCauCat = true;
                                            _ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                                            _ctchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                                            _ctchungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                                            _ctchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                                            _ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                                            _ctchungtu.CatNK_HoTens = txtHoTensCat_YCC1.Text.Trim();
                                            _ctchungtu.SoLuongDC_YCC = 1;
                                        }
                                    }
                                    else
                                    {
                                        ChungTu_LichSu lichsuchungtu1 = new ChungTu_LichSu();
                                        _cChungTu.CopyLichSuChungTu(lichsuchungtu, ref lichsuchungtu1);
                                        lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                        ///
                                        lichsuchungtu1.NhanNK_MaCN = _cChiNhanh.GetIDByTenCN("Tân Hòa");
                                        lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                        lichsuchungtu1.NhanNK_HoTen = txtHoTenDB.Text.Trim();
                                        lichsuchungtu1.NhanNK_DiaChi = txtDiaChiDB.Text.Trim();
                                        lichsuchungtu1.NhanNK_GhiChu = txtGhiChu.Text.Trim();
                                        ///
                                        lichsuchungtu1.YeuCauCat = true;
                                        lichsuchungtu1.SoNK = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                                        lichsuchungtu1.CatNK_HoTens = txtHoTensCat_YCC1.Text.Trim();
                                        ///
                                        lichsuchungtu1.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                                        lichsuchungtu1.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                                        lichsuchungtu1.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                                        lichsuchungtu1.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                            lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                        else
                                            lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                        lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                        lichsuchungtu1.PhieuDuocKy = true;
                                        if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                        {
                                            _ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                            _ctchungtu.YeuCauCat = true;
                                            _ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                                            _ctchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                                            _ctchungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                                            _ctchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                                            _ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                                            _ctchungtu.CatNK_HoTens = txtHoTensCat_YCC1.Text.Trim();
                                            _ctchungtu.SoLuongDC_YCC = 1;
                                        }
                                    }
                                }
                                else
                                {
                                    if (_ctchungtu.SoPhieu != null)
                                    {
                                        ChungTu_LichSu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu.Value);
                                        _cChungTu.XoaLichSuChungTu(_lichsuchungtu);
                                        _ctchungtu.SoPhieu = null;
                                        _ctchungtu.YeuCauCat = false;
                                        _ctchungtu.CatNK_MaCN = null;
                                        _ctchungtu.CatNK_DanhBo = null;
                                        _ctchungtu.CatNK_HoTen = null;
                                        _ctchungtu.CatNK_DiaChi = null;
                                        _ctchungtu.CatNK_SoNKCat = null;
                                        _ctchungtu.CatNK_HoTens = null;
                                    }
                                }
                                if (chkYCCat2.Checked)
                                {
                                    if (_ctchungtu.SoPhieu2 != null)
                                    {
                                        ChungTu_LichSu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu2.Value);
                                        _lichsuchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC2.SelectedValue.ToString());
                                        _lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC2.Text.Trim();
                                        _lichsuchungtu.CatNK_HoTen = txtHoTen_Cat_YCC2.Text.Trim();
                                        _lichsuchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC2.Text.Trim();
                                        _lichsuchungtu.SoNK = int.Parse(txtSoNKCat_YCC2.Text.Trim());
                                        _lichsuchungtu.CatNK_HoTens = txtHoTensCat_YCC2.Text.Trim();
                                        if (_cChungTu.SuaLichSuChungTu(_lichsuchungtu))
                                        {
                                            _ctchungtu.SoPhieu2 = _lichsuchungtu.SoPhieu;
                                            _ctchungtu.YeuCauCat2 = true;
                                            _ctchungtu.CatNK_MaCN2 = int.Parse(cmbChiNhanh_YCC2.SelectedValue.ToString());
                                            _ctchungtu.CatNK_DanhBo2 = txtDanhBo_Cat_YCC2.Text.Trim();
                                            _ctchungtu.CatNK_HoTen2 = txtHoTen_Cat_YCC2.Text.Trim();
                                            _ctchungtu.CatNK_DiaChi2 = txtDiaChiKH_Cat_YCC2.Text.Trim();
                                            _ctchungtu.CatNK_SoNKCat2 = int.Parse(txtSoNKCat_YCC2.Text.Trim());
                                            _ctchungtu.CatNK_HoTens2 = txtHoTensCat_YCC2.Text.Trim();
                                            _ctchungtu.SoLuongDC_YCC = 2;
                                        }
                                    }
                                    else
                                    {
                                        ChungTu_LichSu lichsuchungtu1 = new ChungTu_LichSu();
                                        _cChungTu.CopyLichSuChungTu(lichsuchungtu, ref lichsuchungtu1);
                                        lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                        ///
                                        lichsuchungtu1.NhanNK_MaCN = _cChiNhanh.GetIDByTenCN("Tân Hòa");
                                        lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                        lichsuchungtu1.NhanNK_HoTen = txtHoTenDB.Text.Trim();
                                        lichsuchungtu1.NhanNK_DiaChi = txtDiaChiDB.Text.Trim();
                                        lichsuchungtu1.NhanNK_GhiChu = txtGhiChu.Text.Trim();
                                        ///
                                        lichsuchungtu1.YeuCauCat = true;
                                        lichsuchungtu1.SoNK = int.Parse(txtSoNKCat_YCC2.Text.Trim());
                                        lichsuchungtu1.CatNK_HoTens = txtHoTensCat_YCC2.Text.Trim();
                                        ///
                                        lichsuchungtu1.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC2.SelectedValue.ToString());
                                        lichsuchungtu1.CatNK_DanhBo = txtDanhBo_Cat_YCC2.Text.Trim();
                                        lichsuchungtu1.CatNK_HoTen = txtHoTen_Cat_YCC2.Text.Trim();
                                        lichsuchungtu1.CatNK_DiaChi = txtDiaChiKH_Cat_YCC2.Text.Trim();
                                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                            lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                        else
                                            lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                        lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                        lichsuchungtu1.PhieuDuocKy = true;

                                        if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                        {
                                            _ctchungtu.SoPhieu2 = lichsuchungtu1.SoPhieu;
                                            _ctchungtu.YeuCauCat2 = true;
                                            _ctchungtu.CatNK_MaCN2 = int.Parse(cmbChiNhanh_YCC2.SelectedValue.ToString());
                                            _ctchungtu.CatNK_DanhBo2 = txtDanhBo_Cat_YCC2.Text.Trim();
                                            _ctchungtu.CatNK_HoTen2 = txtHoTen_Cat_YCC2.Text.Trim();
                                            _ctchungtu.CatNK_DiaChi2 = txtDiaChiKH_Cat_YCC2.Text.Trim();
                                            _ctchungtu.CatNK_SoNKCat2 = int.Parse(txtSoNKCat_YCC2.Text.Trim());
                                            _ctchungtu.CatNK_HoTens2 = txtHoTensCat_YCC2.Text.Trim();
                                            _ctchungtu.SoLuongDC_YCC = 2;
                                        }
                                    }
                                }
                                else
                                {
                                    if (_ctchungtu.SoPhieu2 != null)
                                    {
                                        ChungTu_LichSu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu2.Value);
                                        _cChungTu.XoaLichSuChungTu(_lichsuchungtu);
                                        _ctchungtu.SoPhieu2 = null;
                                        _ctchungtu.YeuCauCat2 = false;
                                        _ctchungtu.CatNK_MaCN2 = null;
                                        _ctchungtu.CatNK_DanhBo2 = null;
                                        _ctchungtu.CatNK_HoTen2 = null;
                                        _ctchungtu.CatNK_DiaChi2 = null;
                                        _ctchungtu.CatNK_SoNKCat2 = null;
                                        _ctchungtu.CatNK_HoTen2 = null;
                                    }
                                }
                                if (chkYCCat3.Checked)
                                {
                                    if (_ctchungtu.SoPhieu3 != null)
                                    {
                                        ChungTu_LichSu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu3.Value);
                                        _lichsuchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC3.SelectedValue.ToString());
                                        _lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC3.Text.Trim();
                                        _lichsuchungtu.CatNK_HoTen = txtHoTen_Cat_YCC3.Text.Trim();
                                        _lichsuchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC3.Text.Trim();
                                        _lichsuchungtu.SoNK = int.Parse(txtSoNKCat_YCC3.Text.Trim());
                                        _lichsuchungtu.CatNK_HoTens = txtHoTensCat_YCC3.Text.Trim();
                                        if (_cChungTu.SuaLichSuChungTu(_lichsuchungtu))
                                        {
                                            _ctchungtu.SoPhieu3 = _lichsuchungtu.SoPhieu;
                                            _ctchungtu.YeuCauCat3 = true;
                                            _ctchungtu.CatNK_MaCN3 = int.Parse(cmbChiNhanh_YCC3.SelectedValue.ToString());
                                            _ctchungtu.CatNK_DanhBo3 = txtDanhBo_Cat_YCC3.Text.Trim();
                                            _ctchungtu.CatNK_HoTen3 = txtHoTen_Cat_YCC3.Text.Trim();
                                            _ctchungtu.CatNK_DiaChi3 = txtDiaChiKH_Cat_YCC3.Text.Trim();
                                            _ctchungtu.CatNK_SoNKCat3 = int.Parse(txtSoNKCat_YCC3.Text.Trim());
                                            _ctchungtu.CatNK_HoTens3 = txtHoTensCat_YCC3.Text.Trim();
                                            _ctchungtu.SoLuongDC_YCC = 3;
                                        }
                                    }
                                    else
                                    {
                                        ChungTu_LichSu lichsuchungtu1 = new ChungTu_LichSu();
                                        _cChungTu.CopyLichSuChungTu(lichsuchungtu, ref lichsuchungtu1);
                                        lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                        ///
                                        lichsuchungtu1.NhanNK_MaCN = _cChiNhanh.GetIDByTenCN("Tân Hòa");
                                        lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                        lichsuchungtu1.NhanNK_HoTen = txtHoTenDB.Text.Trim();
                                        lichsuchungtu1.NhanNK_DiaChi = txtDiaChiDB.Text.Trim();
                                        lichsuchungtu1.NhanNK_GhiChu = txtGhiChu.Text.Trim();
                                        ///
                                        lichsuchungtu1.YeuCauCat = true;
                                        lichsuchungtu1.SoNK = int.Parse(txtSoNKCat_YCC3.Text.Trim());
                                        lichsuchungtu1.CatNK_HoTens = txtHoTensCat_YCC3.Text.Trim();
                                        ///
                                        lichsuchungtu1.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC3.SelectedValue.ToString());
                                        lichsuchungtu1.CatNK_DanhBo = txtDanhBo_Cat_YCC3.Text.Trim();
                                        lichsuchungtu1.CatNK_HoTen = txtHoTen_Cat_YCC3.Text.Trim();
                                        lichsuchungtu1.CatNK_DiaChi = txtDiaChiKH_Cat_YCC3.Text.Trim();

                                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                            lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                        else
                                            lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                        lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                        lichsuchungtu1.PhieuDuocKy = true;

                                        if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                        {
                                            _ctchungtu.SoPhieu3 = lichsuchungtu1.SoPhieu;
                                            _ctchungtu.YeuCauCat3 = true;
                                            _ctchungtu.CatNK_MaCN3 = int.Parse(cmbChiNhanh_YCC3.SelectedValue.ToString());
                                            _ctchungtu.CatNK_DanhBo3 = txtDanhBo_Cat_YCC3.Text.Trim();
                                            _ctchungtu.CatNK_HoTen3 = txtHoTen_Cat_YCC3.Text.Trim();
                                            _ctchungtu.CatNK_DiaChi3 = txtDiaChiKH_Cat_YCC3.Text.Trim();
                                            _ctchungtu.CatNK_SoNKCat3 = int.Parse(txtSoNKCat_YCC3.Text.Trim());
                                            _ctchungtu.CatNK_HoTens3 = txtHoTensCat_YCC3.Text.Trim();
                                            _ctchungtu.SoLuongDC_YCC = 3;
                                        }
                                    }
                                }
                                else
                                {
                                    if (_ctchungtu.SoPhieu3 != null)
                                    {
                                        ChungTu_LichSu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu3.Value);
                                        _cChungTu.XoaLichSuChungTu(_lichsuchungtu);
                                        _ctchungtu.SoPhieu3 = null;
                                        _ctchungtu.YeuCauCat3 = false;
                                        _ctchungtu.CatNK_MaCN3 = null;
                                        _ctchungtu.CatNK_DanhBo3 = null;
                                        _ctchungtu.CatNK_HoTen3 = null;
                                        _ctchungtu.CatNK_DiaChi3 = null;
                                        _ctchungtu.CatNK_SoNKCat3 = null;
                                        _ctchungtu.CatNK_HoTen3 = null;
                                    }
                                }
                                if (chkYCCat4.Checked)
                                {
                                    if (_ctchungtu.SoPhieu4 != null)
                                    {
                                        ChungTu_LichSu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu4.Value);
                                        _lichsuchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC4.SelectedValue.ToString());
                                        _lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC4.Text.Trim();
                                        _lichsuchungtu.CatNK_HoTen = txtHoTen_Cat_YCC4.Text.Trim();
                                        _lichsuchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC4.Text.Trim();
                                        _lichsuchungtu.SoNK = int.Parse(txtSoNKCat_YCC4.Text.Trim());
                                        _lichsuchungtu.CatNK_HoTens = txtHoTensCat_YCC4.Text.Trim();
                                        if (_cChungTu.SuaLichSuChungTu(_lichsuchungtu))
                                        {
                                            _ctchungtu.SoPhieu4 = _lichsuchungtu.SoPhieu;
                                            _ctchungtu.YeuCauCat4 = true;
                                            _ctchungtu.CatNK_MaCN4 = int.Parse(cmbChiNhanh_YCC4.SelectedValue.ToString());
                                            _ctchungtu.CatNK_DanhBo4 = txtDanhBo_Cat_YCC4.Text.Trim();
                                            _ctchungtu.CatNK_HoTen4 = txtHoTen_Cat_YCC4.Text.Trim();
                                            _ctchungtu.CatNK_DiaChi4 = txtDiaChiKH_Cat_YCC4.Text.Trim();
                                            _ctchungtu.CatNK_SoNKCat4 = int.Parse(txtSoNKCat_YCC4.Text.Trim());
                                            _ctchungtu.CatNK_HoTens4 = txtHoTensCat_YCC4.Text.Trim();
                                            _ctchungtu.SoLuongDC_YCC = 4;
                                        }
                                    }
                                    else
                                    {
                                        ChungTu_LichSu lichsuchungtu1 = new ChungTu_LichSu();
                                        _cChungTu.CopyLichSuChungTu(lichsuchungtu, ref lichsuchungtu1);
                                        lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                        ///
                                        lichsuchungtu1.NhanNK_MaCN = _cChiNhanh.GetIDByTenCN("Tân Hòa");
                                        lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                        lichsuchungtu1.NhanNK_HoTen = txtHoTenDB.Text.Trim();
                                        lichsuchungtu1.NhanNK_DiaChi = txtDiaChiDB.Text.Trim();
                                        lichsuchungtu1.NhanNK_GhiChu = txtGhiChu.Text.Trim();
                                        ///
                                        lichsuchungtu1.YeuCauCat = true;
                                        lichsuchungtu1.SoNK = int.Parse(txtSoNKCat_YCC4.Text.Trim());
                                        lichsuchungtu1.CatNK_HoTens = txtHoTensCat_YCC4.Text.Trim();
                                        ///
                                        lichsuchungtu1.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC4.SelectedValue.ToString());
                                        lichsuchungtu1.CatNK_DanhBo = txtDanhBo_Cat_YCC4.Text.Trim();
                                        lichsuchungtu1.CatNK_HoTen = txtHoTen_Cat_YCC4.Text.Trim();
                                        lichsuchungtu1.CatNK_DiaChi = txtDiaChiKH_Cat_YCC4.Text.Trim();
                                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                            lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                        else
                                            lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                        lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                        lichsuchungtu1.PhieuDuocKy = true;

                                        if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                        {
                                            _ctchungtu.SoPhieu4 = lichsuchungtu1.SoPhieu;
                                            _ctchungtu.YeuCauCat4 = true;
                                            _ctchungtu.CatNK_MaCN4 = int.Parse(cmbChiNhanh_YCC4.SelectedValue.ToString());
                                            _ctchungtu.CatNK_DanhBo4 = txtDanhBo_Cat_YCC4.Text.Trim();
                                            _ctchungtu.CatNK_HoTen4 = txtHoTen_Cat_YCC4.Text.Trim();
                                            _ctchungtu.CatNK_DiaChi4 = txtDiaChiKH_Cat_YCC4.Text.Trim();
                                            _ctchungtu.CatNK_SoNKCat4 = int.Parse(txtSoNKCat_YCC4.Text.Trim());
                                            _ctchungtu.CatNK_HoTens4 = txtHoTensCat_YCC4.Text.Trim();
                                            _ctchungtu.SoLuongDC_YCC = 4;
                                        }
                                    }
                                }
                                else
                                {
                                    if (_ctchungtu.SoPhieu4 != null)
                                    {
                                        ChungTu_LichSu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu4.Value);
                                        _cChungTu.XoaLichSuChungTu(_lichsuchungtu);
                                        _ctchungtu.SoPhieu4 = null;
                                        _ctchungtu.YeuCauCat4 = false;
                                        _ctchungtu.CatNK_MaCN4 = null;
                                        _ctchungtu.CatNK_DanhBo4 = null;
                                        _ctchungtu.CatNK_HoTen4 = null;
                                        _ctchungtu.CatNK_DiaChi4 = null;
                                        _ctchungtu.CatNK_SoNKCat4 = null;
                                        _ctchungtu.CatNK_HoTen4 = null;
                                    }
                                }
                                if (chkYCCat5.Checked)
                                {
                                    if (_ctchungtu.SoPhieu5 != null)
                                    {
                                        ChungTu_LichSu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu5.Value);
                                        _lichsuchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC5.SelectedValue.ToString());
                                        _lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC5.Text.Trim();
                                        _lichsuchungtu.CatNK_HoTen = txtHoTen_Cat_YCC5.Text.Trim();
                                        _lichsuchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC5.Text.Trim();
                                        _lichsuchungtu.SoNK = int.Parse(txtSoNKCat_YCC5.Text.Trim());
                                        _lichsuchungtu.CatNK_HoTens = txtHoTensCat_YCC5.Text.Trim();
                                        if (_cChungTu.SuaLichSuChungTu(_lichsuchungtu))
                                        {
                                            _ctchungtu.SoPhieu5 = _lichsuchungtu.SoPhieu;
                                            _ctchungtu.YeuCauCat5 = true;
                                            _ctchungtu.CatNK_MaCN5 = int.Parse(cmbChiNhanh_YCC5.SelectedValue.ToString());
                                            _ctchungtu.CatNK_DanhBo5 = txtDanhBo_Cat_YCC5.Text.Trim();
                                            _ctchungtu.CatNK_HoTen5 = txtHoTen_Cat_YCC5.Text.Trim();
                                            _ctchungtu.CatNK_DiaChi5 = txtDiaChiKH_Cat_YCC5.Text.Trim();
                                            _ctchungtu.CatNK_SoNKCat5 = int.Parse(txtSoNKCat_YCC5.Text.Trim());
                                            _ctchungtu.CatNK_HoTens5 = txtHoTensCat_YCC5.Text.Trim();
                                            _ctchungtu.SoLuongDC_YCC = 5;
                                        }
                                    }
                                    else
                                    {
                                        ChungTu_LichSu lichsuchungtu1 = new ChungTu_LichSu();
                                        _cChungTu.CopyLichSuChungTu(lichsuchungtu, ref lichsuchungtu1);
                                        lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                        ///
                                        lichsuchungtu1.NhanNK_MaCN = _cChiNhanh.GetIDByTenCN("Tân Hòa");
                                        lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                        lichsuchungtu1.NhanNK_HoTen = txtHoTenDB.Text.Trim();
                                        lichsuchungtu1.NhanNK_DiaChi = txtDiaChiDB.Text.Trim();
                                        lichsuchungtu1.NhanNK_GhiChu = txtGhiChu.Text.Trim();
                                        ///
                                        lichsuchungtu1.YeuCauCat = true;
                                        lichsuchungtu1.SoNK = int.Parse(txtSoNKCat_YCC5.Text.Trim());
                                        lichsuchungtu1.CatNK_HoTens = txtHoTensCat_YCC5.Text.Trim();
                                        ///
                                        lichsuchungtu1.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC5.SelectedValue.ToString());
                                        lichsuchungtu1.CatNK_DanhBo = txtDanhBo_Cat_YCC5.Text.Trim();
                                        lichsuchungtu1.CatNK_HoTen = txtHoTen_Cat_YCC5.Text.Trim();
                                        lichsuchungtu1.CatNK_DiaChi = txtDiaChiKH_Cat_YCC5.Text.Trim();

                                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                            lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                        else
                                            lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                        lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                        lichsuchungtu1.PhieuDuocKy = true;

                                        if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                        {
                                            _ctchungtu.SoPhieu5 = lichsuchungtu1.SoPhieu;
                                            _ctchungtu.YeuCauCat5 = true;
                                            _ctchungtu.CatNK_MaCN5 = int.Parse(cmbChiNhanh_YCC5.SelectedValue.ToString());
                                            _ctchungtu.CatNK_DanhBo5 = txtDanhBo_Cat_YCC5.Text.Trim();
                                            _ctchungtu.CatNK_HoTen5 = txtHoTen_Cat_YCC5.Text.Trim();
                                            _ctchungtu.CatNK_DiaChi5 = txtDiaChiKH_Cat_YCC5.Text.Trim();
                                            _ctchungtu.CatNK_SoNKCat5 = int.Parse(txtSoNKCat_YCC5.Text.Trim());
                                            _ctchungtu.CatNK_HoTens5 = txtHoTensCat_YCC5.Text.Trim();
                                            _ctchungtu.SoLuongDC_YCC = 5;
                                        }
                                    }
                                }
                                else
                                {
                                    if (_ctchungtu.SoPhieu5 != null)
                                    {
                                        ChungTu_LichSu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu5.Value);
                                        _cChungTu.XoaLichSuChungTu(_lichsuchungtu);
                                        _ctchungtu.SoPhieu5 = null;
                                        _ctchungtu.YeuCauCat5 = false;
                                        _ctchungtu.CatNK_MaCN5 = null;
                                        _ctchungtu.CatNK_DanhBo5 = null;
                                        _ctchungtu.CatNK_HoTen5 = null;
                                        _ctchungtu.CatNK_DiaChi5 = null;
                                        _ctchungtu.CatNK_SoNKCat5 = null;
                                        _ctchungtu.CatNK_HoTen5 = null;
                                    }
                                }

                                #endregion
                                _cChungTu.SubmitChanges();
                                scope.Complete();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                        _cChungTu.Refresh();
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

        private void cmbLoaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst)
            {
                txtThoiHan.Text = ((LoaiChungTu)cmbLoaiCT.SelectedItem).ThoiHan.ToString();
                if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                    dateHetHan.Value = DateTime.Now.AddMonths(int.Parse(txtThoiHan.Text.Trim()));
                if (cmbLoaiCT.SelectedValue.ToString() == "7")
                    txtGhiChu.Text = "DINH MUC NHAP CU";
                else
                    txtGhiChu.Text = "";
            }
        }

        #region Configure TextBox

        private void cmbLoaiCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtMaCT.Focus();
        }

        private void txtMaCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //    e.Handled = true;
            if (e.KeyChar == 13)
            {
                txtHoTen.Focus();
            }
        }

        private void txtMaCT_Leave(object sender, EventArgs e)
        {
            if (txtMaCT.Text.Trim() != "")
            {
                if (txtMaCT.Text.Trim() != "" && int.Parse(cmbLoaiCT.SelectedValue.ToString()) == 15 && txtMaCT.Text.Trim().Length != 12)
                {
                    MessageBox.Show("CCCD gồm 12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string resultCheckCCCD = "";
                int result = _wsThuongVu.checkExists_CCCD("", txtMaCT.Text.Trim(), out resultCheckCCCD);
                if (result == 1)
                {
                    if (!resultCheckCCCD.Contains("Tân Hòa"))
                    {
                        MessageBox.Show(resultCheckCCCD, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (_cChungTu.CheckExist_CT(txtDanhBo.Text.Trim(), txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString())) == true)
                        {
                            MessageBox.Show("Dữ liệu đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                dgvDSDanhBo.DataSource = _cChungTu.getDS_ChiTiet(txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString()));
            }
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNgaySinh.Focus();
        }

        private void txtNgaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //    e.Handled = true;
            if (e.KeyChar == 13)
                txtGhiChu.Focus();
        }

        private void chkCatChuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYCCat1.Checked)
            {
                groupBox1.Enabled = true;
                txtHoTen_Cat_YCC1.Text = txtHoTen.Text.Trim();
                txtDiaChiKH_Cat_YCC1.Text = "";
                txtSoNKCat_YCC1.Text = "1";
            }
            else
            {
                groupBox1.Enabled = false;
                txtHoTen_Cat_YCC1.Text = "";
                txtDiaChiKH_Cat_YCC1.Text = "";
                txtSoNKCat_YCC1.Text = "";
            }
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

        private void chkYCCat2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYCCat2.Checked)
                groupBox2.Enabled = true;
            else
                groupBox2.Enabled = false;
        }

        private void chkYCCat3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYCCat3.Checked)
                groupBox3.Enabled = true;
            else
                groupBox3.Enabled = false;
        }

        private void chkYCCat4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYCCat4.Checked)
                groupBox4.Enabled = true;
            else
                groupBox4.Enabled = false;
        }

        private void chkYCCat5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYCCat5.Checked)
                groupBox5.Enabled = true;
            else
                groupBox5.Enabled = false;
        }

        private void txtDanhBo_Cat_YCC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen_Cat_YCC2.Focus();
        }

        private void txtHoTen_Cat_YCC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChiKH_Cat_YCC2.Focus();
        }

        private void txtDiaChiKH_Cat_YCC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoNKCat_YCC2.Focus();
        }

        private void txtSoNKCat_YCC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnThem.Focus();
        }

        private void txtDanhBo_Cat_YCC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen_Cat_YCC3.Focus();
        }

        private void txtHoTen_Cat_YCC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChiKH_Cat_YCC3.Focus();
        }

        private void txtDiaChiKH_Cat_YCC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoNKCat_YCC3.Focus();
        }

        private void txtSoNKCat_YCC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnThem.Focus();
        }

        #endregion

        private void btnYCCat_Click(object sender, EventArgs e)
        {
            if (!panel_YCCat2.Visible)
            {
                panel_YCCat2.Visible = true;
                this.Size = new Size(1323, 557);
                this.Location = new Point(10, 70);
            }
            else
                if (!panel_YCCat3.Visible)
                {
                    panel_YCCat3.Visible = true;
                    this.Size = new Size(1323, 557);
                }
                else
                    if (!panel_YCCat4.Visible)
                    {
                        panel_YCCat4.Visible = true;
                        this.Size = new Size(1323, 557);
                    }
                    else
                        if (!panel_YCCat5.Visible)
                        {
                            panel_YCCat5.Visible = true;
                            this.Size = new Size(1323, 557);
                        }
                        else
                        {
                            panel_YCCat2.Visible = false;
                            panel_YCCat3.Visible = false;
                            panel_YCCat4.Visible = false;
                            panel_YCCat5.Visible = false;
                            this.Size = new Size(910, 557);
                            this.Location = new Point(70, 70);
                        }

        }

        private void frmSoDK_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //public void _cChungTu.CopyLichSuChungTu(ChungTu_LichSu A, ref ChungTu_LichSu B)
        //{
        //    B.MaDonMoi = A.MaDonMoi;
        //    B.STT = A.STT;
        //    B.MaDonTBC = A.MaDonTBC;
        //    B.MaDonTXL = A.MaDonTXL;
        //    B.MaDon = A.MaDon;
        //    B.DanhBo = A.DanhBo;
        //    B.MaLCT = A.MaLCT;
        //    B.MaCT = A.MaCT;
        //    B.SoNKTong = A.SoNKTong;
        //    B.SoNKDangKy = A.SoNKDangKy;
        //    B.ThoiHan = A.ThoiHan;
        //    B.NgayHetHan = A.NgayHetHan;
        //    B.CatNK_HoTens = A.CatNK_HoTens;
        //    B.GhiChu = A.GhiChu;
        //    B.Lo = A.Lo;
        //    B.Phong = A.Phong;
        //    B.Quan = A.Quan;
        //    B.Phuong = A.Phuong;
        //}

        private void chkSuaNgayHetHan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSuaNgayHetHan.Checked)
                dateHetHan.Enabled = true;
            else
                dateHetHan.Enabled = false;
        }

        private void chkThuongTru_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThuongTru.Checked == true)
                chkTamTru.Checked = false;
        }

        private void chkTamTru_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTamTru.Checked == true)
            {
                chkThuongTru.Checked = false;
                txtThoiHan.Text = "6";
            }
        }






    }
}
