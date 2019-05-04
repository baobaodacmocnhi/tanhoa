using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.DongNuoc;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL;
using ThuTien.BaoCao;
using ThuTien.BaoCao.DongNuoc;
using ThuTien.GUI.BaoCao;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using ThuTien.DAL.Doi;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmKQDongNuoc : Form
    {
        string _mnu = "mnuKQDongNuoc";
        CTo _cTo = new CTo();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        TT_DongNuoc _dongnuoc = null;
        TT_KQDongNuoc _kqdongnuoc = null;
        CDocSo _cCapNuocTanHoa = new CDocSo();
        CNiemChi _cNiemChi = new CNiemChi();

        public frmKQDongNuoc()
        {
            InitializeComponent();
        }

        private void frmKQDongNuoc_Load(object sender, EventArgs e)
        {
            dgvKQDongNuoc.AutoGenerateColumns = false;

            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                List<TT_To> lstTo = _cTo.GetDSHanhThu();
                TT_To to = new TT_To();
                to.MaTo = 0;
                to.TenTo = "Tất Cả";
                lstTo.Insert(0, to);
                cmbTo.DataSource = lstTo;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
        }

        public void Clear()
        {
            chkHuy.Checked = false;
            txtDanhBo.Text = "";
            txtMLT.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            dateDongNuoc.Value = DateTime.Now;
            txtChiSoDN.Text = "";
            txtNiemChi.Text = "";
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            cmbChiMatSo.SelectedIndex = -1;
            cmbChiKhoaGoc.SelectedIndex = -1;
            txtLyDo.Text = "";
            chkMoNuoc.Checked = false;
            dateMoNuoc.Value = DateTime.Now;
            txtChiSoMN.Text = "";
            chkKhoaTu.Checked = false;
            chkButChi.Checked = false;
            chkKhoaKhac.Checked = false;
            txtKhoaKhac_GhiChu.Text = "";
            chkKhongThuTienMoNuoc.Checked = false;
            chkDongNuoc2.Checked = false;
            dateDongNuoc1.Value = DateTime.Now;
            txtChiSoDN1.Text = "";
            txtNiemChi1.Text = "";
            dateDongNuoc2.Value = DateTime.Now;
            txtChiSoDN2.Text = "";
            txtNiemChi2.Text = "";
            _dongnuoc = null;
            _kqdongnuoc = null;
        }

        public void LoadEntity(TT_KQDongNuoc entity)
        {
            chkHuy.Checked = _kqdongnuoc.TT_DongNuoc.Huy;
            txtDanhBo.Text = _kqdongnuoc.DanhBo;
            txtMLT.Text = entity.MLT;
            txtHoTen.Text = entity.HoTen;
            txtDiaChi.Text = entity.DiaChi;
            dateDongNuoc.Value = entity.NgayDN.Value;
            if (entity.ChiSoDN != null)
                txtChiSoDN.Text = entity.ChiSoDN.Value.ToString();
            if (entity.NiemChi != null)
                txtNiemChi.Text = entity.NiemChi.Value.ToString();
            txtHieu.Text = entity.Hieu;
            if (entity.Co != null)
                txtCo.Text = entity.Co.Value.ToString();
            txtSoThan.Text = entity.SoThan;
            cmbChiMatSo.SelectedItem = entity.ChiMatSo;
            cmbChiKhoaGoc.SelectedItem = entity.ChiKhoaGoc;
            txtLyDo.Text = entity.LyDo;
            chkKhoaTu.Checked = entity.KhoaTu;
            chkButChi.Checked = entity.ButChi;
            chkKhoaKhac.Checked = entity.KhoaKhac;
            txtKhoaKhac_GhiChu.Text = entity.KhoaKhac_GhiChu;
            chkKhongThuTienMoNuoc.Checked = entity.KhongThuPhi;
            if (entity.MoNuoc)
            {
                chkMoNuoc.Checked = entity.MoNuoc;
                dateMoNuoc.Value = entity.NgayMN.Value;
                if (entity.ChiSoMN != null)
                    txtChiSoMN.Text = entity.ChiSoMN.Value.ToString();
                txtGhiChuMN.Text = entity.GhiChuMN;
            }
            if (entity.DongNuoc2)
            {
                chkDongNuoc2.Checked = entity.DongNuoc2;
                dateDongNuoc2.Value = entity.NgayDN.Value;
                if (entity.ChiSoDN != null)
                    txtChiSoDN2.Text = entity.ChiSoDN.Value.ToString();
                if (entity.NiemChi != null)
                    txtNiemChi2.Text = entity.NiemChi.Value.ToString();

                dateDongNuoc1.Value = entity.NgayDN1.Value;
                if (entity.ChiSoDN1 != null)
                    txtChiSoDN1.Text = entity.ChiSoDN1.Value.ToString();
                if (entity.NiemChi1 != null)
                    txtNiemChi1.Text = entity.NiemChi1.Value.ToString();
            }
        }

        private void txtMaDN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaDN.Text.Trim().Replace("-", "")) && e.KeyChar == 13)
            {
                Clear();
                if (_cDongNuoc.CheckExist_KQDongNuoc(decimal.Parse(txtMaDN.Text.Trim().Replace("-", ""))))
                {
                    _dongnuoc = _cDongNuoc.GetDongNuocByMaDN(decimal.Parse(txtMaDN.Text.Trim().Replace("-", "")));
                    chkHuy.Checked = _dongnuoc.Huy;
                    cmbTroNgai.SelectedItem = _dongnuoc.TroNgai;
                    txtGhiChuTroNgai.Text = _dongnuoc.GhiChuTroNgai;

                    _kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaDN(decimal.Parse(txtMaDN.Text.Trim().Replace("-", "")));
                    LoadEntity(_kqdongnuoc);
                    //txtDanhBo.Text = _kqdongnuoc.DanhBo;
                    //txtMLT.Text = _kqdongnuoc.MLT;
                    //txtHoTen.Text = _kqdongnuoc.HoTen;
                    //txtDiaChi.Text = _kqdongnuoc.DiaChi;
                    //dateDongNuoc.Value = _kqdongnuoc.NgayDN.Value;
                    //if (_kqdongnuoc.ChiSoDN != null)
                    //    txtChiSoDN.Text = _kqdongnuoc.ChiSoDN.Value.ToString();
                    //txtHieu.Text = _kqdongnuoc.Hieu;
                    //if (_kqdongnuoc.Co != null)
                    //    txtCo.Text = _kqdongnuoc.Co.Value.ToString();
                    //txtSoThan.Text = _kqdongnuoc.SoThan;
                    //cmbChiMatSo.SelectedItem = _kqdongnuoc.ChiMatSo;
                    //cmbChiKhoaGoc.SelectedItem = _kqdongnuoc.ChiKhoaGoc;
                    //txtLyDo.Text = _kqdongnuoc.LyDo;
                    //chkKhongThuTienMoNuoc.Checked = _kqdongnuoc.KhongThuPhi;
                    //if (_kqdongnuoc.MoNuoc)
                    //{
                    //    chkMoNuoc.Checked = _kqdongnuoc.MoNuoc;
                    //    dateMoNuoc.Value = _kqdongnuoc.NgayMN.Value;
                    //    if (_kqdongnuoc.ChiSoMN != null)
                    //        txtChiSoMN.Text = _kqdongnuoc.ChiSoMN.Value.ToString();
                    //    txtGhiChuMN.Text = _kqdongnuoc.GhiChuMN;
                    //}
                    //if (_kqdongnuoc.DongNuoc2)
                    //{
                    //    chkDongNuoc2.Checked = _kqdongnuoc.DongNuoc2;
                    //    dateDongNuoc2.Value = _kqdongnuoc.NgayDN.Value;
                    //    if (_kqdongnuoc.ChiSoDN != null)
                    //        txtChiSoDN2.Text = _kqdongnuoc.ChiSoDN.Value.ToString();
                    //    dateDongNuoc1.Value = _kqdongnuoc.NgayDN1.Value;
                    //    if (_kqdongnuoc.ChiSoDN1 != null)
                    //        txtChiSoDN1.Text = _kqdongnuoc.ChiSoDN1.Value.ToString();
                    //}
                }
                else
                    if (_cDongNuoc.GetDongNuocByMaDN(decimal.Parse(txtMaDN.Text.Trim().Replace("-", ""))) != null)
                    {
                        _dongnuoc = _cDongNuoc.GetDongNuocByMaDN(decimal.Parse(txtMaDN.Text.Trim().Replace("-", "")));
                        txtMaDN.Text = _dongnuoc.MaDN.ToString().Insert(_dongnuoc.MaDN.ToString().Length - 2, "-");
                        txtDanhBo.Text = _dongnuoc.DanhBo;
                        txtMLT.Text = _dongnuoc.MLT;
                        txtHoTen.Text = _dongnuoc.HoTen;
                        txtDiaChi.Text = _dongnuoc.DiaChi;
                        chkHuy.Checked = _dongnuoc.Huy;
                        cmbTroNgai.SelectedItem = _dongnuoc.TroNgai;
                        txtGhiChuTroNgai.Text = _dongnuoc.GhiChuTroNgai;

                        TB_DULIEUKHACHHANG ttkh = _cCapNuocTanHoa.GetTTKH(_dongnuoc.DanhBo);
                        txtHieu.Text = ttkh.HIEUDH;
                        txtCo.Text = ttkh.CODH;
                        txtSoThan.Text = ttkh.SOTHANDH;
                        //dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuocByMaDNDates(_dongnuoc.MaDN, dateTu.Value, dateDen.Value);
                        //btnXem.PerformClick();
                    }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    ///sửa kết quả đóng nước
                    if (_kqdongnuoc != null)
                    {
                        if (!CNguoiDung.ToTruong && !CNguoiDung.Doi)
                            if (!_cDongNuoc.CheckExist_DongNuoc(_kqdongnuoc.MaDN.Value, CNguoiDung.MaND))
                            {
                                MessageBox.Show("Thông báo này không được giao cho bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                        _kqdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                        _kqdongnuoc.MLT = txtMLT.Text.Trim();
                        _kqdongnuoc.HoTen = txtHoTen.Text.Trim();
                        _kqdongnuoc.DiaChi = txtDiaChi.Text.Trim();

                        _kqdongnuoc.NgayDN = dateDongNuoc.Value;
                        _kqdongnuoc.NgayDN_ThucTe = DateTime.Now;
                        if (!string.IsNullOrEmpty(txtChiSoDN.Text.Trim()))
                            _kqdongnuoc.ChiSoDN = int.Parse(txtChiSoDN.Text.Trim());
                        
                        _kqdongnuoc.Hieu = txtHieu.Text.Trim();
                        if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                            _kqdongnuoc.Co = int.Parse(txtCo.Text.Trim());
                        _kqdongnuoc.SoThan = txtSoThan.Text.Trim();
                        if (cmbChiMatSo.SelectedItem != null)
                            _kqdongnuoc.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();
                        if (cmbChiKhoaGoc.SelectedItem != null)
                            _kqdongnuoc.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();
                        _kqdongnuoc.LyDo = txtLyDo.Text.Trim();
                        _kqdongnuoc.KhoaTu = chkKhoaTu.Checked;
                        _kqdongnuoc.ButChi = chkButChi.Checked;
                        _kqdongnuoc.KhoaKhac = chkKhoaKhac.Checked;
                        _kqdongnuoc.KhoaKhac_GhiChu = txtKhoaKhac_GhiChu.Text.Trim();
                        _kqdongnuoc.KhongThuPhi = chkKhongThuTienMoNuoc.Checked;

                        //cập nhật đóng nước lần 2
                        if (chkDongNuoc2.Checked)
                        {
                            _kqdongnuoc.DongNuoc2 = true;
                            _kqdongnuoc.PhiMoNuoc = _cDongNuoc.GetPhiMoNuoc() * 2;

                            if (_kqdongnuoc.HinhDN1 == null)
                                _kqdongnuoc.HinhDN1 = _kqdongnuoc.HinhDN;
                            if (_kqdongnuoc.NgayDN1 == null)
                            {
                                _kqdongnuoc.NgayDN1 = _kqdongnuoc.NgayDN;
                                _kqdongnuoc.NgayDN1_ThucTe = _kqdongnuoc.NgayDN_ThucTe;
                            }
                            if (_kqdongnuoc.ChiSoDN1 == null)
                                _kqdongnuoc.ChiSoDN1 = _kqdongnuoc.ChiSoDN;
                            if (_kqdongnuoc.NiemChi1 == null)
                                _kqdongnuoc.NiemChi1 = _kqdongnuoc.NiemChi;

                            _kqdongnuoc.NgayDN = dateDongNuoc2.Value;
                            _kqdongnuoc.NgayDN_ThucTe = DateTime.Now;
                            if (!string.IsNullOrEmpty(txtChiSoDN2.Text.Trim()))
                                _kqdongnuoc.ChiSoDN = int.Parse(txtChiSoDN2.Text.Trim());
                            if (chkKhoaTu.Checked == false)
                                if (!string.IsNullOrEmpty(txtNiemChi2.Text.Trim()))
                                {
                                    if(_kqdongnuoc.NgayDN1.Value.Date > DateTime.Parse("2018-10-17"))
                                        if( _kqdongnuoc.NiemChi.Value== int.Parse(txtNiemChi2.Text.Trim()))
                                        {
                                            MessageBox.Show("Số Niêm Chì đã Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    if (_cNiemChi.checkExist(int.Parse(txtNiemChi2.Text.Trim())) == false)
                                    {
                                        MessageBox.Show("Số Niêm Chì không Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    if (_cNiemChi.checkSuDung(int.Parse(txtNiemChi2.Text.Trim())) == true)
                                    {
                                        MessageBox.Show("Số Niêm Chì đã Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    //if (_kqdongnuoc.NiemChi != null)
                                    //    _cNiemChi.traSuDung(_kqdongnuoc.NiemChi.Value);
                                    _kqdongnuoc.NiemChi = int.Parse(txtNiemChi2.Text.Trim());
                                    _cNiemChi.suDung(int.Parse(txtNiemChi2.Text.Trim()));
                                }

                            if (_kqdongnuoc.SoPhieuDN1 == null)
                                _kqdongnuoc.SoPhieuDN1 = _kqdongnuoc.SoPhieuDN;
                            if (_kqdongnuoc.NgaySoPhieuDN1 == null)
                                _kqdongnuoc.NgaySoPhieuDN1 = _kqdongnuoc.NgaySoPhieuDN;
                            _kqdongnuoc.ChuyenDN1 = _kqdongnuoc.ChuyenDN;
                            if (_kqdongnuoc.NgayChuyenDN1 == null)
                                _kqdongnuoc.NgayChuyenDN1 = _kqdongnuoc.NgayChuyenDN;

                            _kqdongnuoc.SoPhieuDN = null;
                            _kqdongnuoc.NgaySoPhieuDN = null;
                            _kqdongnuoc.ChuyenDN = false;
                            _kqdongnuoc.NgayChuyenDN = null;
                        }
                        else
                            if (_kqdongnuoc.DongNuoc2 == true)
                            {
                                _kqdongnuoc.DongNuoc2 = false;
                                _kqdongnuoc.PhiMoNuoc = _kqdongnuoc.PhiMoNuoc / 2;
                                if (_kqdongnuoc.HinhDN1 != null)
                                    _kqdongnuoc.HinhDN = _kqdongnuoc.HinhDN1;
                                _kqdongnuoc.NgayDN = _kqdongnuoc.NgayDN1;
                                _kqdongnuoc.ChiSoDN = _kqdongnuoc.ChiSoDN1;
                                if (_kqdongnuoc.NiemChi != null)
                                    _cNiemChi.traSuDung(_kqdongnuoc.NiemChi.Value);
                                _kqdongnuoc.NiemChi = _kqdongnuoc.NiemChi1;
                                _kqdongnuoc.NgayDN1 = null;
                                _kqdongnuoc.ChiSoDN1 = null;
                                _kqdongnuoc.NiemChi1 = null;

                                _kqdongnuoc.SoPhieuDN = _kqdongnuoc.SoPhieuDN1;
                                _kqdongnuoc.NgaySoPhieuDN = _kqdongnuoc.NgaySoPhieuDN1;
                                _kqdongnuoc.ChuyenDN = _kqdongnuoc.ChuyenDN1;
                                _kqdongnuoc.NgayChuyenDN = _kqdongnuoc.NgayChuyenDN1;
                                _kqdongnuoc.SoPhieuDN1 = null;
                                _kqdongnuoc.NgaySoPhieuDN1 = null;
                                _kqdongnuoc.ChuyenDN1 = false;
                                _kqdongnuoc.NgayChuyenDN1 = null;
                            }
                        //cập nhật đóng nước lần 1
                        if (chkKhoaKhac.Checked==false &&  chkKhoaTu.Checked == false && _kqdongnuoc.NgayDN.Value.Date > DateTime.Parse("2018-10-17"))
                        {
                            if (txtNiemChi.Text.Trim() == "")
                            {
                                MessageBox.Show("Thiếu Số Niêm Chì", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (!string.IsNullOrEmpty(txtNiemChi.Text.Trim()) && (_kqdongnuoc.NiemChi == null || _kqdongnuoc.NiemChi.Value != int.Parse(txtNiemChi.Text.Trim())))
                            {
                                if (_cNiemChi.checkExist(int.Parse(txtNiemChi.Text.Trim())) == false)
                                {
                                    MessageBox.Show("Số Niêm Chì không Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (_cNiemChi.checkSuDung(int.Parse(txtNiemChi.Text.Trim())) == true)
                                {
                                    MessageBox.Show("Số Niêm Chì đã Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (_kqdongnuoc.NiemChi != null)
                                    _cNiemChi.traSuDung(_kqdongnuoc.NiemChi.Value);
                                _kqdongnuoc.NiemChi = int.Parse(txtNiemChi.Text.Trim());
                                _cNiemChi.suDung(int.Parse(txtNiemChi.Text.Trim()));
                            }
                        }

                        if (_cDongNuoc.SuaKQ(_kqdongnuoc))
                        {
                            Clear();
                            btnXem.PerformClick();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        ///thêm kết quả đóng nước
                        if (_dongnuoc != null)
                        {
                            if (_cDongNuoc.CheckDangNgan(_dongnuoc.MaDN))
                            {
                                MessageBox.Show("Hóa Đơn trong Lệnh này đã Đăng Ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (_cDongNuoc.CheckExist_KQDongNuoc(_dongnuoc.MaDN))
                            {
                                MessageBox.Show("Lệnh này đã nhập Kết Quả", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (_cDongNuoc.CheckHuyLenh(_dongnuoc.MaDN))
                            {
                                MessageBox.Show("Lệnh này đã bị Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (!CNguoiDung.ToTruong && !CNguoiDung.Doi)
                                if (!_cDongNuoc.CheckExist_DongNuoc(_dongnuoc.MaDN, CNguoiDung.MaND))
                                {
                                    MessageBox.Show("Thông báo này không được giao cho bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                            TT_KQDongNuoc kqdongnuoc = new TT_KQDongNuoc();
                            kqdongnuoc.MaDN = _dongnuoc.MaDN;
                            kqdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                            kqdongnuoc.MLT = txtMLT.Text.Trim();
                            kqdongnuoc.HoTen = txtHoTen.Text.Trim();
                            kqdongnuoc.DiaChi = txtDiaChi.Text.Trim();

                            kqdongnuoc.DongNuoc = true;
                            kqdongnuoc.NgayDN = dateDongNuoc.Value;
                            kqdongnuoc.NgayDN_ThucTe = DateTime.Now;
                            if (!string.IsNullOrEmpty(txtChiSoDN.Text.Trim()))
                                kqdongnuoc.ChiSoDN = int.Parse(txtChiSoDN.Text.Trim());
                            if (chkKhoaKhac.Checked == false && chkKhoaTu.Checked == false)
                            {
                                if (txtNiemChi.Text.Trim() == "")
                                {
                                    MessageBox.Show("Thiếu Số Niêm Chì", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (!string.IsNullOrEmpty(txtNiemChi.Text.Trim()))
                                {
                                    if (_cNiemChi.checkExist(int.Parse(txtNiemChi.Text.Trim())) == false)
                                    {
                                        MessageBox.Show("Số Niêm Chì không Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    if (_cNiemChi.checkSuDung(int.Parse(txtNiemChi.Text.Trim())) == true)
                                    {
                                        MessageBox.Show("Số Niêm Chì đã Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    kqdongnuoc.NiemChi = int.Parse(txtNiemChi.Text.Trim());
                                    _cNiemChi.suDung(int.Parse(txtNiemChi.Text.Trim()));
                                }
                            }
                            kqdongnuoc.Hieu = txtHieu.Text.Trim();
                            if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                                kqdongnuoc.Co = int.Parse(txtCo.Text.Trim());
                            kqdongnuoc.SoThan = txtSoThan.Text.Trim();
                            if (cmbChiMatSo.SelectedItem != null)
                                kqdongnuoc.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();
                            if (cmbChiKhoaGoc.SelectedItem != null)
                                kqdongnuoc.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();
                            kqdongnuoc.LyDo = txtLyDo.Text.Trim();
                            kqdongnuoc.KhoaTu = chkKhoaTu.Checked;
                            kqdongnuoc.ButChi = chkButChi.Checked;
                            kqdongnuoc.KhoaKhac = chkKhoaKhac.Checked;
                            kqdongnuoc.KhoaKhac_GhiChu = txtKhoaKhac_GhiChu.Text.Trim();
                            kqdongnuoc.KhongThuPhi = chkKhongThuTienMoNuoc.Checked;

                            kqdongnuoc.PhiMoNuoc = _cDongNuoc.GetPhiMoNuoc();

                            //if (chkMoNuoc.Checked)
                            //{
                            //    kqdongnuoc.MoNuoc = true;
                            //    kqdongnuoc.NgayMN = dateMoNuoc.Value;
                            //    kqdongnuoc.ChiSoMN = int.Parse(txtChiSoMN.Text.Trim());
                            //}

                            if (_cDongNuoc.ThemKQ(kqdongnuoc))
                            {
                                Clear();
                                btnXem.PerformClick();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (_kqdongnuoc != null)
                {
                    if (!CNguoiDung.ToTruong && !CNguoiDung.Doi)
                        if (!_cDongNuoc.CheckExist_DongNuoc(_kqdongnuoc.MaDN.Value, CNguoiDung.MaND))
                        {
                            MessageBox.Show("Thông báo này không được giao cho bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    //_kqdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                    //_kqdongnuoc.MLT = txtMLT.Text.Trim();
                    //_kqdongnuoc.HoTen = txtHoTen.Text.Trim();
                    //_kqdongnuoc.DiaChi = txtDiaChi.Text.Trim();

                    //_kqdongnuoc.NgayDN = dateDongNuoc.Value;
                    //if (!string.IsNullOrEmpty(txtChiSoDN.Text.Trim()))
                    //    _kqdongnuoc.ChiSoDN = int.Parse(txtChiSoDN.Text.Trim());
                    //_kqdongnuoc.Hieu = txtHieu.Text.Trim();
                    //if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                    //    _kqdongnuoc.Co = int.Parse(txtCo.Text.Trim());
                    //_kqdongnuoc.SoThan = txtSoThan.Text.Trim();
                    //if (cmbChiMatSo.SelectedItem != null)
                    //    _kqdongnuoc.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();
                    //if (cmbChiKhoaGoc.SelectedItem != null)
                    //    _kqdongnuoc.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();
                    //_kqdongnuoc.LyDo = txtLyDo.Text.Trim();

                    //if (chkDongNuoc2.Checked)
                    //{
                    //    _kqdongnuoc.DongNuoc2 = true;
                    //    _kqdongnuoc.PhiMoNuoc = _cDongNuoc.GetPhiMoNuoc() * 2;

                    //    if (_kqdongnuoc.NgayDN1 == null)
                    //        _kqdongnuoc.NgayDN1 = _kqdongnuoc.NgayDN;
                    //    if (_kqdongnuoc.ChiSoDN1 == null)
                    //        _kqdongnuoc.ChiSoDN1 = _kqdongnuoc.ChiSoDN;

                    //    _kqdongnuoc.NgayDN = dateDongNuoc2.Value;
                    //    if (!string.IsNullOrEmpty(txtChiSoDN2.Text.Trim()))
                    //        _kqdongnuoc.ChiSoDN = int.Parse(txtChiSoDN2.Text.Trim());
                    //}
                    //else
                    //    if (_kqdongnuoc.DongNuoc2 == true)
                    //    {
                    //        _kqdongnuoc.DongNuoc2 = false;
                    //        _kqdongnuoc.PhiMoNuoc = _kqdongnuoc.PhiMoNuoc / 2;
                    //        _kqdongnuoc.NgayDN = _kqdongnuoc.NgayDN1;
                    //        _kqdongnuoc.ChiSoDN = _kqdongnuoc.ChiSoDN1;
                    //        _kqdongnuoc.NgayDN1 = null;
                    //        _kqdongnuoc.ChiSoDN1 = null;
                    //    }

                    if (chkMoNuoc.Checked)
                    {
                        _kqdongnuoc.MoNuoc = true;
                        _kqdongnuoc.NgayMN = dateMoNuoc.Value;
                        _kqdongnuoc.NgayMN_ThucTe = DateTime.Now;
                        _kqdongnuoc.ChiSoMN = int.Parse(txtChiSoMN.Text.Trim());
                        _kqdongnuoc.GhiChuMN = txtGhiChuMN.Text.Trim();
                    }
                    else
                    {
                        _kqdongnuoc.MoNuoc = false;
                        _kqdongnuoc.NgayMN = null;
                        _kqdongnuoc.NgayMN_ThucTe = null;
                        _kqdongnuoc.ChiSoMN = null;
                        _kqdongnuoc.GhiChuMN = null;
                    }

                    if (_cDongNuoc.SuaKQ(_kqdongnuoc))
                    {
                        Clear();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (CNguoiDung.Doi)
                    {
                        TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(dgvKQDongNuoc.SelectedRows[0].Cells["MaKQDN"].Value.ToString()));
                        if (kqdongnuoc.MoNuoc == true)
                        {
                            MessageBox.Show("Có mở nước, Không được Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (kqdongnuoc.NiemChi != null)
                            _cNiemChi.traSuDung(kqdongnuoc.NiemChi.Value);
                        if (kqdongnuoc.NiemChi1 != null)
                            _cNiemChi.traSuDung(kqdongnuoc.NiemChi1.Value);
                        if (_cDongNuoc.XoaKQ(kqdongnuoc))
                        {
                            Clear();
                            btnXem.PerformClick();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        DateTime date = new DateTime();
                        DateTime.TryParse(dgvKQDongNuoc.SelectedRows[0].Cells["CreateDate"].Value.ToString(), out date);
                        if (date.Date != DateTime.Now.Date)
                        {
                            MessageBox.Show("Chỉ được Xóa trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(dgvKQDongNuoc.SelectedRows[0].Cells["MaKQDN"].Value.ToString()));
                        if (kqdongnuoc.MoNuoc == true)
                        {
                            MessageBox.Show("Có mở nước, Không được Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (kqdongnuoc.NiemChi != null)
                            _cNiemChi.traSuDung(kqdongnuoc.NiemChi.Value);
                        if (kqdongnuoc.NiemChi1 != null)
                            _cNiemChi.traSuDung(kqdongnuoc.NiemChi1.Value);
                        if (_cDongNuoc.XoaKQ(kqdongnuoc))
                        {
                            Clear();
                            btnXem.PerformClick();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (radDongNuoc.Checked)
            {
                if (CNguoiDung.Doi)
                {
                    if(cmbTo.SelectedIndex==0)
                        dgvKQDongNuoc.DataSource = _cDongNuoc.getDS_KQDongNuoc( dateTu.Value, dateDen.Value);
                    else
                        if(cmbTo.SelectedIndex>0)
                            dgvKQDongNuoc.DataSource = _cDongNuoc.getDS_KQDongNuoc_MaTo_NgayDN((int)cmbTo.SelectedValue, dateTu.Value, dateDen.Value);
                }
                else
                    if (CNguoiDung.ToTruong)
                        dgvKQDongNuoc.DataSource = _cDongNuoc.getDS_KQDongNuoc_MaTo_NgayDN(CNguoiDung.MaTo, dateTu.Value, dateDen.Value);
                    else
                        dgvKQDongNuoc.DataSource = _cDongNuoc.getDS_KQDongNuoc_MaNV_NgayDN(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
            }
            else
                if (radMoNuoc.Checked)
                {
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvKQDongNuoc.DataSource = _cDongNuoc.getDS_KQMoNuoc(dateTu.Value, dateDen.Value);
                        else
                            if (cmbTo.SelectedIndex > 0)
                                dgvKQDongNuoc.DataSource = _cDongNuoc.getDS_KQMoNuoc_MaTo_NgayMN((int)cmbTo.SelectedValue, dateTu.Value, dateDen.Value);
                    }
                    else
                        if (CNguoiDung.ToTruong)
                            dgvKQDongNuoc.DataSource = _cDongNuoc.getDS_KQMoNuoc_MaTo_NgayMN(CNguoiDung.MaTo, dateTu.Value, dateDen.Value);
                        else
                            dgvKQDongNuoc.DataSource = _cDongNuoc.getDS_KQDongNuoc_MaNV_NgayMN(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
                }
            //foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
            //{
            //    item.Cells["In"].Value = true;
            //}
        }

        private void dgvKQDongNuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Clear();
                //dgvKQDongNuoc.Rows[e.RowIndex].Selected = true;
                _kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(dgvKQDongNuoc.SelectedRows[0].Cells["MaKQDN"].Value.ToString()));
                LoadEntity(_kqdongnuoc);
                //txtDanhBo.Text = dgvKQDongNuoc["DanhBo", e.RowIndex].Value.ToString();
                //txtMLT.Text = dgvKQDongNuoc["MLT", e.RowIndex].Value.ToString();
                //txtHoTen.Text = dgvKQDongNuoc["HoTen", e.RowIndex].Value.ToString();
                //txtDiaChi.Text = dgvKQDongNuoc["DiaChi", e.RowIndex].Value.ToString();
                //dateDongNuoc.Value = DateTime.Parse(dgvKQDongNuoc["NgayDN", e.RowIndex].Value.ToString());
                //txtChiSoDN.Text = dgvKQDongNuoc["ChiSoDN", e.RowIndex].Value.ToString();
                //txtHieu.Text = dgvKQDongNuoc["Hieu", e.RowIndex].Value.ToString();
                //txtCo.Text = dgvKQDongNuoc["Co", e.RowIndex].Value.ToString();
                //txtSoThan.Text = dgvKQDongNuoc["SoThan", e.RowIndex].Value.ToString();
                //cmbChiMatSo.SelectedItem = dgvKQDongNuoc["ChiMatSo", e.RowIndex].Value.ToString();
                //cmbChiKhoaGoc.SelectedItem = dgvKQDongNuoc["ChiKhoaGoc", e.RowIndex].Value.ToString();
                //txtLyDo.Text = dgvKQDongNuoc["LyDo", e.RowIndex].Value.ToString();
                //if (bool.Parse(dgvKQDongNuoc["MoNuoc", e.RowIndex].Value.ToString()))
                //{
                //    chkMoNuoc.Checked = bool.Parse(dgvKQDongNuoc["MoNuoc", e.RowIndex].Value.ToString());
                //    dateMoNuoc.Value = DateTime.Parse(dgvKQDongNuoc["NgayMN", e.RowIndex].Value.ToString());
                //    txtChiSoMN.Text = dgvKQDongNuoc["ChiSoMN", e.RowIndex].Value.ToString();
                //    txtGhiChuMN.Text = dgvKQDongNuoc["GhiChuMN", e.RowIndex].Value.ToString();
                //}
                //else
                //{
                //    chkMoNuoc.Checked = false;
                //    dateMoNuoc.Value = DateTime.Now;
                //    txtChiSoMN.Text = "";
                //    txtGhiChuMN.Text = "";
                //}
                //if (bool.Parse(dgvKQDongNuoc["DongNuoc2", e.RowIndex].Value.ToString()))
                //{
                //    chkDongNuoc2.Checked = bool.Parse(dgvKQDongNuoc["DongNuoc2", e.RowIndex].Value.ToString());
                //    dateDongNuoc2.Value = DateTime.Parse(dgvKQDongNuoc["NgayDN", e.RowIndex].Value.ToString());
                //    txtChiSoDN2.Text = dgvKQDongNuoc["ChiSoDN", e.RowIndex].Value.ToString();
                //    dateDongNuoc1.Value = DateTime.Parse(dgvKQDongNuoc["NgayDN1", e.RowIndex].Value.ToString());
                //    txtChiSoDN1.Text = dgvKQDongNuoc["ChiSoDN1", e.RowIndex].Value.ToString();
                //}
                //else
                //{
                //    chkDongNuoc2.Checked = false;
                //    dateDongNuoc2.Value = DateTime.Now;
                //    txtChiSoDN2.Text = "";
                //    dateDongNuoc1.Value = DateTime.Now;
                //    txtChiSoDN1.Text = "";
                //}
            }
            catch
            {
            }
        }

        private void dgvKQDongNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "MaDN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "SoPhieuDN" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "SoPhieuMN" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvKQDongNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKQDongNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtChiSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void chkHuy_CheckedChanged(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (_dongnuoc != null)
                {
                    _dongnuoc.Huy = chkHuy.Checked;
                    if (_cDongNuoc.SuaDN(_dongnuoc))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkMoNuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoNuoc.Checked)
            {
                dateMoNuoc.Enabled = true;
                txtChiSoMN.ReadOnly = false;
                txtGhiChuMN.ReadOnly = false;
            }
            else
            {
                dateMoNuoc.Enabled = false;
                txtChiSoMN.ReadOnly = true;
                txtGhiChuMN.ReadOnly = true;
                dateMoNuoc.Value = DateTime.Now;
                txtChiSoMN.Text = "";
                txtGhiChuMN.Text = "";
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (MessageBox.Show("Bạn có chắc chắn In Phiếu?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    dsBaoCao dsBaoCao = new dsBaoCao();
                    if (radDongNuoc.Checked)
                    {
                        decimal SoPhieuDN = _cDongNuoc.GetNextSoPhieuDN();
                        List<TT_KQDongNuoc> lst = new List<TT_KQDongNuoc>();

                        foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
                            if (item.Cells["In"].Value != null && bool.Parse(item.Cells["In"].Value.ToString()) == true)
                            {
                                if (string.IsNullOrEmpty(item.Cells["SoPhieuDN"].Value.ToString()))
                                {
                                    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(item.Cells["MaKQDN"].Value.ToString()));
                                    kqdongnuoc.SoPhieuDN = SoPhieuDN;
                                    kqdongnuoc.NgaySoPhieuDN = DateTime.Now;
                                    _cDongNuoc.SuaKQ(kqdongnuoc);
                                }
                                else
                                    if (!lst.Any(itemlst => itemlst.SoPhieuDN == decimal.Parse(item.Cells["SoPhieuDN"].Value.ToString())))
                                        lst = lst.Concat(_cDongNuoc.GetDSKQDongNuocBySoPhieuDN(decimal.Parse(item.Cells["SoPhieuDN"].Value.ToString()))).ToList();
                            }

                        lst = lst.Concat(_cDongNuoc.GetDSKQDongNuocBySoPhieuDN(SoPhieuDN)).ToList();
                        foreach (TT_KQDongNuoc item in lst)
                        {
                            DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();

                            dr["MaDN"] = item.SoPhieuDN.ToString().Insert(item.SoPhieuDN.ToString().Length - 2, "-");
                            dr["Loai"] = "ĐÓNG NƯỚC";
                            dr["KyHieuLoai"] = "ĐN";
                            if (item.DanhBo.Length == 11)
                                dr["DanhBo"] = item.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = item.DiaChi;
                            dr["Hieu"] = item.Hieu;
                            string Ky = "";
                            foreach (TT_CTDongNuoc itemDN in item.TT_DongNuoc.TT_CTDongNuocs.ToList())
                            {
                                if (string.IsNullOrEmpty(Ky))
                                {
                                    //Ky = itemDN.Ky.Substring(0, itemDN.Ky.Length - 5);
                                    Ky = itemDN.Ky;
                                }
                                else
                                {
                                    //Ky += ", " + itemDN.Ky.Substring(0, itemDN.Ky.Length - 5);
                                    Ky += ", " + itemDN.Ky;
                                }
                            }
                            dr["Ky"] = Ky;
                            dr["NgayDongMoNuoc"] = item.NgayDN;
                            if (item.Co <= 25)
                                dr["ChiSoDongMoNuoc"] = item.ChiSoDN.Value.ToString("D4");
                            else
                                dr["ChiSoDongMoNuoc"] = item.ChiSoDN.Value.ToString("D5");
                            dr["ChucVu"] = CNguoiKy.getChucVu();
                            dr["NguoiKy"] = CNguoiKy.getNguoiKy();

                            dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                        }
                    }
                    else
                        if (radMoNuoc.Checked)
                        {
                            decimal SoPhieuMN = _cDongNuoc.GetNextSoPhieuMN();
                            List<TT_KQDongNuoc> lst = new List<TT_KQDongNuoc>();

                            foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
                                if (item.Cells["In"].Value != null && bool.Parse(item.Cells["In"].Value.ToString()) == true)
                                {
                                    if (string.IsNullOrEmpty(item.Cells["SoPhieuMN"].Value.ToString()))
                                    {
                                        TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(item.Cells["MaKQDN"].Value.ToString()));
                                        kqdongnuoc.SoPhieuMN = SoPhieuMN;
                                        kqdongnuoc.NgaySoPhieuMN = DateTime.Now;
                                        _cDongNuoc.SuaKQ(kqdongnuoc);
                                    }
                                    else
                                        if (!lst.Any(itemlst => itemlst.SoPhieuMN == decimal.Parse(item.Cells["SoPhieuMN"].Value.ToString())))
                                            lst = lst.Concat(_cDongNuoc.GetDSKQDongNuocBySoPhieuMN(decimal.Parse(item.Cells["SoPhieuMN"].Value.ToString()))).ToList();
                                }

                            lst = lst.Concat(_cDongNuoc.GetDSKQDongNuocBySoPhieuMN(SoPhieuMN)).ToList();

                            bool flagButChi = false;
                            foreach (TT_KQDongNuoc item in lst)
                                if (item.ButChi == true)
                                {
                                    flagButChi = true;
                                    break;
                                }
                            foreach (TT_KQDongNuoc item in lst)
                            {
                                DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();

                                dr["MaDN"] = item.SoPhieuMN.ToString().Insert(item.SoPhieuMN.ToString().Length - 2, "-");
                                dr["Loai"] = "MỞ NƯỚC";
                                dr["KyHieuLoai"] = "MN";
                                if (item.DanhBo.Length == 11)
                                    dr["DanhBo"] = item.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["DiaChi"] = item.DiaChi;
                                dr["Hieu"] = item.Hieu;
                                string Ky = "";
                                foreach (TT_CTDongNuoc itemDN in item.TT_DongNuoc.TT_CTDongNuocs.ToList())
                                {
                                    if (string.IsNullOrEmpty(Ky))
                                    {
                                        //Ky = itemDN.Ky.Substring(0, itemDN.Ky.Length - 5);
                                        Ky = itemDN.Ky;
                                    }
                                    else
                                    {
                                        //Ky += ", " + itemDN.Ky.Substring(0, itemDN.Ky.Length - 5);
                                        Ky += ", " + itemDN.Ky;
                                    }
                                }
                                dr["Ky"] = Ky;
                                dr["NgayDongMoNuoc"] = item.NgayMN;
                                if (item.Co <= 25)
                                    dr["ChiSoDongMoNuoc"] = item.ChiSoMN.Value.ToString("D4");
                                else
                                    dr["ChiSoDongMoNuoc"] = item.ChiSoMN.Value.ToString("D5");
                                if(item.ButChi==true)
                                    dr["ButChi"] = true;
                                dr["ButChiParent"] = flagButChi;
                                dr["ChucVu"] = CNguoiKy.getChucVu();
                                dr["NguoiKy"] = CNguoiKy.getNguoiKy();

                                dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                            }
                        }

                    rptPhieuBaoDongMoNuoc rpt = new rptPhieuBaoDongMoNuoc();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.Show();

                    //btnXem.PerformClick();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (radDongNuoc.Checked)
                    {
                        foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
                            if (item.Cells["In"].Value != null && bool.Parse(item.Cells["In"].Value.ToString()) == true && !string.IsNullOrEmpty(item.Cells["SoPhieuDN"].Value.ToString()))
                            {
                                TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(item.Cells["MaKQDN"].Value.ToString()));
                                kqdongnuoc.SoPhieuDN = null;
                                kqdongnuoc.NgaySoPhieuDN = null;
                                _cDongNuoc.SuaKQ(kqdongnuoc);
                            }
                    }
                    else
                        if (radMoNuoc.Checked)
                        {
                            foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
                                if (item.Cells["In"].Value != null && bool.Parse(item.Cells["In"].Value.ToString()) == true && !string.IsNullOrEmpty(item.Cells["SoPhieuMN"].Value.ToString()))
                                {
                                    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(item.Cells["MaKQDN"].Value.ToString()));
                                    kqdongnuoc.SoPhieuMN = null;
                                    kqdongnuoc.NgaySoPhieuMN = null;
                                    _cDongNuoc.SuaKQ(kqdongnuoc);
                                }
                        }
                    //btnXem.PerformClick();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvKQDongNuoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "DaKy" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvKQDongNuoc[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua") && CNguoiDung.Doi)
                {
                    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(dgvKQDongNuoc["MaKQDN", e.RowIndex].Value.ToString()));
                    if (bool.Parse(e.FormattedValue.ToString()))
                        kqdongnuoc.NgayKy = DateTime.Now;
                    else
                        kqdongnuoc.NgayKy = null;
                    kqdongnuoc.DaKy = bool.Parse(e.FormattedValue.ToString());
                    _cDongNuoc.SuaKQ(kqdongnuoc);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (_dongnuoc != null)
                {
                    _dongnuoc.TroNgai = cmbTroNgai.SelectedItem.ToString();
                    _dongnuoc.GhiChuTroNgai = txtGhiChuTroNgai.Text.Trim();
                    if (_cDongNuoc.SuaDN(_dongnuoc))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {

            dsBaoCao dsBaoCao = new dsBaoCao();
            foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
            {
                DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                dr["MaDN"] = item.Cells["MaDN"].Value.ToString().Insert(item.Cells["MaDN"].Value.ToString().Length - 2, "-");
                if (item.Cells["DanhBo"].Value.ToString() != "")
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["MLT"] = item.Cells["MLT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                dr["DiaChi"] = item.Cells["DiaChi"].Value;

                if (radDongNuoc.Checked)
                {
                    dr["Loai"] = "ĐÓNG NƯỚC";
                    dr["NgayDongMoNuoc"] = item.Cells["NgayDN"].Value;
                    dr["NgayMoNuoc"] = item.Cells["NgayMN"].Value;
                }
                else
                    if (radMoNuoc.Checked)
                    {
                        dr["Loai"] = "MỞ NƯỚC";
                        dr["NgayDongMoNuoc"] = item.Cells["NgayDN"].Value;
                        dr["NgayMoNuoc"] = item.Cells["NgayMN"].Value;
                    }

                dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
            }

            rptDSDongNuoc rpt = new rptDSDongNuoc();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void chkKhongThuTienMoNuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (_kqdongnuoc != null)
                {
                    if (!CNguoiDung.ToTruong && !CNguoiDung.Doi)
                        if (!_cDongNuoc.CheckExist_DongNuoc(_kqdongnuoc.MaDN.Value, CNguoiDung.MaND))
                        {
                            MessageBox.Show("Thông báo này không được giao cho bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    if (chkKhongThuTienMoNuoc.Checked)
                    {
                        _kqdongnuoc.KhongThuPhi = true;
                        _kqdongnuoc.PhiMoNuocKhongThu = _kqdongnuoc.PhiMoNuoc;
                        _kqdongnuoc.PhiMoNuoc = 0;
                    }
                    else
                    {
                        _kqdongnuoc.KhongThuPhi = false;
                        if (_kqdongnuoc.PhiMoNuocKhongThu != null)
                            _kqdongnuoc.PhiMoNuoc = _kqdongnuoc.PhiMoNuocKhongThu;
                        _kqdongnuoc.PhiMoNuocKhongThu = null;
                    }

                    if (_cDongNuoc.SuaKQ(_kqdongnuoc))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnHinhDongNuoc_Click(object sender, EventArgs e)
        {
            if (_kqdongnuoc != null && _kqdongnuoc.HinhDN != null)
            {
                LoadImageView(_kqdongnuoc.HinhDN.ToArray());
            }
        }

        private void btnHinhMoNuoc_Click(object sender, EventArgs e)
        {
            if (_kqdongnuoc != null && _kqdongnuoc.HinhMN != null)
            {
                LoadImageView(_kqdongnuoc.HinhMN.ToArray());
            }
        }

        private void btnHinhDongNuoc2_Click(object sender, EventArgs e)
        {
            if (_kqdongnuoc != null && _kqdongnuoc.HinhDN1 != null)
            {
                LoadImageView(_kqdongnuoc.HinhDN1.ToArray());
            }
        }

        public void LoadImageView(byte[] pData)
        {
            // get a tempfilename and store the image
            var tempFileName = Path.GetTempFileName();

            FileStream mStream = new FileStream(tempFileName, FileMode.Create);
            //byte[] pData = entity.Image.ToArray();
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            // create our startup process and argument
            var psi = new ProcessStartInfo(
                "rundll32.exe",
                String.Format(
                    "\"{0}{1}\", ImageView_Fullscreen {2}",
                    Environment.Is64BitOperatingSystem ?
                        path.Replace(" (x86)", "") :
                        path
                        ,
                    @"\Windows Photo Viewer\PhotoViewer.dll",
                    tempFileName)
                );

            psi.UseShellExecute = false;

            var viewer = Process.Start(psi);
            // cleanup when done...
            viewer.EnableRaisingEvents = true;
            viewer.Exited += (o, args) =>
            {
                File.Delete(tempFileName);
            };
        }

        private void chkKhoaKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhoaKhac.Checked == true)
                txtKhoaKhac_GhiChu.ReadOnly = false;
            else
                txtKhoaKhac_GhiChu.ReadOnly = true;
        }

    }
}
