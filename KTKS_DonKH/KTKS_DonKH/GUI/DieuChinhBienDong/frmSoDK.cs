using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmSoDK : Form
    {
        string _mnu = "mnuDCBD";
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        CChiNhanh _cChiNhanh = new CChiNhanh();
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();

        public frmSoDK()
        {
            InitializeComponent();
        }

        public frmSoDK(Dictionary<string, string> source)
        {
            _source = source;
            InitializeComponent();
        }

        private void frmSoDK_Load(object sender, EventArgs e)
        {
            dgvDSDanhBo.AutoGenerateColumns = false;
            try
            {
                this.Location = new Point(70, 70);
                
                cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
                cmbLoaiCT.DisplayMember = "TenLCT";
                cmbLoaiCT.ValueMember = "MaLCT";

                cmbChiNhanh_YCC1.DataSource = _cChiNhanh.LoadDSChiNhanh(true, "Tân Hòa");
                cmbChiNhanh_YCC1.DisplayMember = "TenCN";
                cmbChiNhanh_YCC1.ValueMember = "MaCN";

                cmbChiNhanh_YCC2.DataSource = _cChiNhanh.LoadDSChiNhanh(true, "Tân Hòa");
                cmbChiNhanh_YCC2.DisplayMember = "TenCN";
                cmbChiNhanh_YCC2.ValueMember = "MaCN";

                cmbChiNhanh_YCC3.DataSource = _cChiNhanh.LoadDSChiNhanh(true, "Tân Hòa");
                cmbChiNhanh_YCC3.DisplayMember = "TenCN";
                cmbChiNhanh_YCC3.ValueMember = "MaCN";

                cmbChiNhanh_YCC4.DataSource = _cChiNhanh.LoadDSChiNhanh(true, "Tân Hòa");
                cmbChiNhanh_YCC4.DisplayMember = "TenCN";
                cmbChiNhanh_YCC4.ValueMember = "MaCN";

                cmbChiNhanh_YCC5.DataSource = _cChiNhanh.LoadDSChiNhanh(true, "Tân Hòa");
                cmbChiNhanh_YCC5.DisplayMember = "TenCN";
                cmbChiNhanh_YCC5.ValueMember = "MaCN";

                //HOADON hoadon = _cThuTien.GetMoiNhat(_source["DanhBo"]);
                txtDanhBo.Text = _source["DanhBo"];

                if (_source["MaCT"].ToString().Trim()!=null)
                if (_cChungTu.CheckCTChungTu(_source["DanhBo"], _source["MaCT"]))
                {
                    CTChungTu ctchungtu = _cChungTu.getCTChungTubyID(_source["DanhBo"], _source["MaCT"]);
                    if (ctchungtu.YeuCauCat2)
                        this.Location = new Point(10, 70);
                    
                    cmbLoaiCT.SelectedValue = ctchungtu.ChungTu.MaLCT;
                    txtMaCT.Text = ctchungtu.MaCT;
                    txtHoTen.Text = _source["HoTenKH"];
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

                    if (ctchungtu.YeuCauCat)
                    {
                        chkYCCat1.Checked = true;
                        cmbChiNhanh_YCC1.SelectedValue = ctchungtu.CatNK_MaCN;
                        txtDanhBo_Cat_YCC1.Text = ctchungtu.CatNK_DanhBo;
                        txtHoTen_Cat_YCC1.Text = ctchungtu.CatNK_HoTen;
                        txtDiaChiKH_Cat_YCC1.Text = ctchungtu.CatNK_DiaChi;
                        txtSoNKCat_YCC1.Text = ctchungtu.CatNK_SoNKCat.ToString();
                    }
                    if (ctchungtu.YeuCauCat2)
                    {
                        panel_YCCat2.Visible = true;
                        this.Size = new Size(1370, 356);
                        this.Location = new Point(10, 70);
                        ///
                        chkYCCat2.Checked = true;
                        cmbChiNhanh_YCC2.SelectedValue = ctchungtu.CatNK_MaCN2;
                        txtDanhBo_Cat_YCC2.Text = ctchungtu.CatNK_DanhBo2;
                        txtHoTen_Cat_YCC2.Text = ctchungtu.CatNK_HoTen2;
                        txtDiaChiKH_Cat_YCC2.Text = ctchungtu.CatNK_DiaChi2;
                        txtSoNKCat_YCC2.Text = ctchungtu.CatNK_SoNKCat2.ToString();
                    }
                    if (ctchungtu.YeuCauCat3)
                    {
                        panel_YCCat3.Visible = true;
                        this.Size = new Size(1370, 477);
                        ///
                        chkYCCat3.Checked = true;
                        cmbChiNhanh_YCC3.SelectedValue = ctchungtu.CatNK_MaCN3;
                        txtDanhBo_Cat_YCC3.Text = ctchungtu.CatNK_DanhBo3;
                        txtHoTen_Cat_YCC3.Text = ctchungtu.CatNK_HoTen3;
                        txtDiaChiKH_Cat_YCC3.Text = ctchungtu.CatNK_DiaChi3;
                        txtSoNKCat_YCC3.Text = ctchungtu.CatNK_SoNKCat3.ToString();
                    }
                    if (ctchungtu.YeuCauCat4)
                    {
                        panel_YCCat4.Visible = true;
                        this.Size = new Size(1370, 477);
                        ///
                        chkYCCat4.Checked = true;
                        cmbChiNhanh_YCC4.SelectedValue = ctchungtu.CatNK_MaCN4;
                        txtDanhBo_Cat_YCC4.Text = ctchungtu.CatNK_DanhBo4;
                        txtHoTen_Cat_YCC4.Text = ctchungtu.CatNK_HoTen4;
                        txtDiaChiKH_Cat_YCC4.Text = ctchungtu.CatNK_DiaChi4;
                        txtSoNKCat_YCC4.Text = ctchungtu.CatNK_SoNKCat4.ToString();
                    }
                    if (ctchungtu.YeuCauCat5)
                    {
                        panel_YCCat5.Visible = true;
                        this.Size = new Size(1370, 515);
                        ///
                        chkYCCat5.Checked = true;
                        cmbChiNhanh_YCC5.SelectedValue = ctchungtu.CatNK_MaCN5;
                        txtDanhBo_Cat_YCC5.Text = ctchungtu.CatNK_DanhBo5;
                        txtHoTen_Cat_YCC5.Text = ctchungtu.CatNK_HoTen5;
                        txtDiaChiKH_Cat_YCC5.Text = ctchungtu.CatNK_DiaChi5;
                        txtSoNKCat_YCC5.Text = ctchungtu.CatNK_SoNKCat5.ToString();
                    }
                }
                else
                {
                    txtHoTen.Text = _source["HoTenKH"];
                    txtDiaChi.Text = _source["DiaChiKH"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them();
            //try
            //{
            //    if (txtMaCT.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "0" && txtSoNKDangKy.Text.Trim() != "0")
            //        if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKDangKy.Text.Trim()))
            //        {
            //            ChungTu chungtu = new ChungTu();
            //            chungtu.MaCT = txtMaCT.Text.Trim();
            //            chungtu.DiaChi = txtDiaChi.Text.Trim();
            //            chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());
            //            chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());

            //            CTChungTu ctchungtu = new CTChungTu();
            //            ctchungtu.DanhBo = txtDanhBo.Text.Trim();
            //            ctchungtu.MaCT = txtMaCT.Text.Trim();
            //            ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
            //            if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
            //                ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
            //            else
            //                ctchungtu.ThoiHan = null;
            //            ctchungtu.GhiChu = txtGhiChu.Text.Trim();
            //            ctchungtu.Lo = txtLo.Text.Trim();
            //            ctchungtu.Phong = txtPhong.Text.Trim();

            //            LichSuChungTu lichsuchungtu = new LichSuChungTu();
            //            if (bool.Parse(_source["ChungCu"]) == false)
            //                if (bool.Parse(_source["TXL"]) == true)
            //                {
            //                    lichsuchungtu.ToXuLy = true;
            //                    lichsuchungtu.MaDonTXL = decimal.Parse(_source["MaDon"]);
            //                }
            //                else
            //                    lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);
            //            lichsuchungtu.GhiChu = txtGhiChu.Text.Trim();

            //            if (chkYCCat1.Checked)
            //                if (txtSoNKCat_YCC1.Text.Trim() == "")
            //                {
            //                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC1", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //                else
            //                {
            //                    /////Cập nhật cái mới nhất(cuối cùng)
            //                    //chungtu.YeuCauCat = true;
            //                    //chungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
            //                    //chungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
            //                    //chungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
            //                    //chungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
            //                    //chungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
            //                    ///Chi tiết liên quan đến Danh Bộ nào
            //                    ctchungtu.YeuCauCat = true;
            //                    ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
            //                    ctchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
            //                    ctchungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
            //                    ctchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
            //                    ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
            //                    ctchungtu.SoLuongDC_YCC = 1;
            //                    ///
            //                    lichsuchungtu.YeuCauCat = true;
            //                    lichsuchungtu.NhanNK_DanhBo = txtDanhBo.Text.Trim();
            //                    //lichsuchungtu.NhanNK_HoTen = _source["HoTenKH"];
            //                    lichsuchungtu.NhanNK_HoTen = txtHoTen.Text.Trim();
            //                    //lichsuchungtu.NhanNK_DiaChi = _source["DiaChiKH"];
            //                    lichsuchungtu.NhanNK_DiaChi = txtDiaChi.Text.Trim();
            //                    //lichsuchungtu.PhieuDuocKy = true;

            //                    //lichsuchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
            //                    //lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
            //                    //lichsuchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
            //                    //lichsuchungtu.CatNK_DiaChi = txtDiaChiKH_Cat.Text.Trim();
            //                    //lichsuchungtu.SoNKNhan = int.Parse(txtSoNKCat.Text.Trim());
            //                    /////Ký Tên
            //                    //BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
            //                    //if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
            //                    //    lichsuchungtu.ChucVu = "GIÁM ĐỐC";
            //                    //else
            //                    //    lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
            //                    //lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
            //                }

            //            #region Yêu Cầu Cắt 2,3,4,5

            //            if (chkYCCat2.Checked)
            //            {
            //                //List<LichSuChungTu> lstLichSuChungTu = new List<LichSuChungTu>();
            //                if (txtSoNKCat_YCC2.Text.Trim() == "")
            //                {
            //                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC2", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //                else
            //                {
            //                    //LichSuChungTu lichsuchungtu2 = lichsuchungtu;
            //                    ///Chi tiết liên quan đến Danh Bộ nào
            //                    ctchungtu.YeuCauCat2 = true;
            //                    ctchungtu.CatNK_MaCN2 = int.Parse(cmbChiNhanh_YCC2.SelectedValue.ToString());
            //                    ctchungtu.CatNK_DanhBo2 = txtDanhBo_Cat_YCC2.Text.Trim();
            //                    ctchungtu.CatNK_HoTen2 = txtHoTen_Cat_YCC2.Text.Trim();
            //                    ctchungtu.CatNK_DiaChi2 = txtDiaChiKH_Cat_YCC2.Text.Trim();
            //                    ctchungtu.CatNK_SoNKCat2 = int.Parse(txtSoNKCat_YCC2.Text.Trim());
            //                    ctchungtu.SoLuongDC_YCC = 2;
            //                    /////
            //                    //lichsuchungtu2.NhanDM = true;
            //                    //lichsuchungtu2.NhanNK_DanhBo = txtDanhBo.Text.Trim();
            //                    //lichsuchungtu2.NhanNK_HoTen = _source["HoTenKH"];
            //                    //lichsuchungtu2.NhanNK_DiaChi = _source["DiaChiKH"];
            //                    //lichsuchungtu2.PhieuDuocKy = true;
            //                    /////
            //                    //lstLichSuChungTu.Add(lichsuchungtu2);
            //                }
            //            }

            //            if (chkYCCat3.Checked)
            //                if (txtSoNKCat_YCC3.Text.Trim() == "")
            //                {
            //                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC3", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //                else
            //                {
            //                    //LichSuChungTu lichsuchungtu3 = lichsuchungtu;
            //                    ///Chi tiết liên quan đến Danh Bộ nào
            //                    ctchungtu.YeuCauCat3 = true;
            //                    ctchungtu.CatNK_MaCN3 = int.Parse(cmbChiNhanh_YCC3.SelectedValue.ToString());
            //                    ctchungtu.CatNK_DanhBo3 = txtDanhBo_Cat_YCC3.Text.Trim();
            //                    ctchungtu.CatNK_HoTen3 = txtHoTen_Cat_YCC3.Text.Trim();
            //                    ctchungtu.CatNK_DiaChi3 = txtDiaChiKH_Cat_YCC3.Text.Trim();
            //                    ctchungtu.CatNK_SoNKCat3 = int.Parse(txtSoNKCat_YCC3.Text.Trim());
            //                    ctchungtu.SoLuongDC_YCC = 3;
            //                    /////
            //                    //lichsuchungtu3.NhanDM = true;
            //                    //lichsuchungtu3.NhanNK_DanhBo = txtDanhBo.Text.Trim();
            //                    //lichsuchungtu3.NhanNK_HoTen = _source["HoTenKH"];
            //                    //lichsuchungtu3.NhanNK_DiaChi = _source["DiaChiKH"];
            //                    //lichsuchungtu3.PhieuDuocKy = true;
            //                    /////
            //                    //lstLichSuChungTu.Add(lichsuchungtu3);
            //                }

            //            if (chkYCCat4.Checked)
            //                if (txtSoNKCat_YCC4.Text.Trim() == "")
            //                {
            //                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC4", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //                else
            //                {
            //                    //LichSuChungTu lichsuchungtu4 = lichsuchungtu;
            //                    ///Chi tiết liên quan đến Danh Bộ nào
            //                    ctchungtu.YeuCauCat4 = true;
            //                    ctchungtu.CatNK_MaCN4 = int.Parse(cmbChiNhanh_YCC4.SelectedValue.ToString());
            //                    ctchungtu.CatNK_DanhBo4 = txtDanhBo_Cat_YCC4.Text.Trim();
            //                    ctchungtu.CatNK_HoTen4 = txtHoTen_Cat_YCC4.Text.Trim();
            //                    ctchungtu.CatNK_DiaChi4 = txtDiaChiKH_Cat_YCC4.Text.Trim();
            //                    ctchungtu.CatNK_SoNKCat4 = int.Parse(txtSoNKCat_YCC4.Text.Trim());
            //                    ctchungtu.SoLuongDC_YCC = 4;
            //                    /////
            //                    //lichsuchungtu4.NhanDM = true;
            //                    //lichsuchungtu4.NhanNK_DanhBo = txtDanhBo.Text.Trim();
            //                    //lichsuchungtu4.NhanNK_HoTen = _source["HoTenKH"];
            //                    //lichsuchungtu4.NhanNK_DiaChi = _source["DiaChiKH"];
            //                    //lichsuchungtu4.PhieuDuocKy = true;
            //                    /////
            //                    //lstLichSuChungTu.Add(lichsuchungtu4);
            //                }

            //            if (chkYCCat5.Checked)
            //                if (txtSoNKCat_YCC5.Text.Trim() == "")
            //                {
            //                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //                else
            //                {
            //                    //LichSuChungTu lichsuchungtu5 = lichsuchungtu;
            //                    ///Chi tiết liên quan đến Danh Bộ nào
            //                    ctchungtu.YeuCauCat5 = true;
            //                    ctchungtu.CatNK_MaCN5 = int.Parse(cmbChiNhanh_YCC5.SelectedValue.ToString());
            //                    ctchungtu.CatNK_DanhBo5 = txtDanhBo_Cat_YCC5.Text.Trim();
            //                    ctchungtu.CatNK_HoTen5 = txtHoTen_Cat_YCC5.Text.Trim();
            //                    ctchungtu.CatNK_DiaChi5 = txtDiaChiKH_Cat_YCC5.Text.Trim();
            //                    ctchungtu.CatNK_SoNKCat5 = int.Parse(txtSoNKCat_YCC5.Text.Trim());
            //                    ctchungtu.SoLuongDC_YCC = 5;
            //                    /////
            //                    //lichsuchungtu5.NhanDM = true;
            //                    //lichsuchungtu5.NhanNK_DanhBo = txtDanhBo.Text.Trim();
            //                    //lichsuchungtu5.NhanNK_HoTen = _source["HoTenKH"];
            //                    //lichsuchungtu5.NhanNK_DiaChi = _source["DiaChiKH"];
            //                    //lichsuchungtu5.PhieuDuocKy = true;
            //                    /////
            //                    //lstLichSuChungTu.Add(lichsuchungtu5);
            //                }


            //            #endregion

            //            if (_cChungTu.ThemChungTu(chungtu, ctchungtu, lichsuchungtu))
            //            {
            //                MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                if (bool.Parse(_source["ChungCu"]) == false)
            //                {
            //                    this.DialogResult = DialogResult.OK;
            //                    this.Close();
            //                }
            //            }

            //        }
            //        else
            //            MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Sua();
            //try
            //{
            //    ///Vì Số Chứng Từ là Khóa Chính mà lại cho sửa Khóa Chính nên phải xét riêng có thay đổi hay không
            //    if (txtMaCT.Text.Trim() != _ctchungtu.MaCT)
            //    {
            //        if (_cChungTu.SuaSoChungTu(txtDanhBo.Text.Trim(), _ctchungtu.MaCT, txtMaCT.Text.Trim()))
            //            MessageBox.Show("Sửa Số Sổ Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //    if (txtSoNKTong.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "0")
            //        if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKDangKy.Text.Trim()))
            //        {
            //            ChungTu chungtu = new ChungTu();
            //            chungtu.MaCT = txtMaCT.Text.Trim();
            //            chungtu.DiaChi = txtDiaChi.Text.Trim();
            //            chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());
            //            chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());

            //            CTChungTu ctchungtu = new CTChungTu();
            //            ctchungtu.DanhBo = txtDanhBo.Text.Trim();
            //            ctchungtu.MaCT = txtMaCT.Text.Trim();
            //            ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
            //            if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
            //                ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
            //            else
            //                ctchungtu.ThoiHan = null;

            //            if (chkSuaNgayHetHan.Checked)
            //                ctchungtu.NgayHetHan = dateHetHan.Value;
            //            else
            //                ctchungtu.NgayHetHan = null;

            //            ctchungtu.GhiChu = txtGhiChu.Text.Trim();
            //            ctchungtu.Lo = txtLo.Text.Trim();
            //            ctchungtu.Phong = txtPhong.Text.Trim();

            //            LichSuChungTu lichsuchungtu = new LichSuChungTu();
            //            if (bool.Parse(_source["ChungCu"]) == false)
            //                if (bool.Parse(_source["TXL"]) == true)
            //                {
            //                    lichsuchungtu.ToXuLy = true;
            //                    lichsuchungtu.MaDonTXL = decimal.Parse(_source["MaDon"]);
            //                }
            //                else
            //                    lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);
            //            lichsuchungtu.GhiChu = txtGhiChu.Text.Trim();

            //            if (chkYCCat1.Checked)
            //                if (txtSoNKCat_YCC1.Text.Trim() == "")
            //                {
            //                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //                else
            //                {
            //                    /////Cập nhật cái mới nhất(cuối cùng)
            //                    //chungtu.YeuCauCat = true;
            //                    //chungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
            //                    //chungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
            //                    //chungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
            //                    //chungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
            //                    //chungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
            //                    ///Chi tiết liên quan đến Danh Bộ nào
            //                    ctchungtu.YeuCauCat = true;
            //                    ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
            //                    ctchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
            //                    ctchungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
            //                    ctchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
            //                    ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
            //                    ctchungtu.SoLuongDC_YCC = 1;
            //                    ///
            //                    lichsuchungtu.YeuCauCat = true;
            //                    lichsuchungtu.NhanNK_DanhBo = txtDanhBo.Text.Trim();
            //                    //lichsuchungtu.NhanNK_HoTen = _source["HoTenKH"];
            //                    //lichsuchungtu.NhanNK_DiaChi = _source["DiaChiKH"];
            //                    lichsuchungtu.NhanNK_HoTen = txtHoTen.Text.Trim();
            //                    lichsuchungtu.NhanNK_DiaChi = txtDiaChi.Text.Trim();
            //                    lichsuchungtu.PhieuDuocKy = true;
            //                }
            //            else
            //            {
            //                //chungtu.YeuCauCat = false;
            //                ctchungtu.YeuCauCat = false;
            //            }

            //            #region Yêu Cầu Cắt 2,3,4,5

            //            if (chkYCCat2.Checked)
            //                if (txtSoNKCat_YCC2.Text.Trim() == "")
            //                {
            //                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC2", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //                else
            //                {
            //                    LichSuChungTu lichsuchungtu2 = lichsuchungtu;
            //                    ///Chi tiết liên quan đến Danh Bộ nào
            //                    ctchungtu.YeuCauCat2 = true;
            //                    ctchungtu.CatNK_MaCN2 = int.Parse(cmbChiNhanh_YCC2.SelectedValue.ToString());
            //                    ctchungtu.CatNK_DanhBo2 = txtDanhBo_Cat_YCC2.Text.Trim();
            //                    ctchungtu.CatNK_HoTen2 = txtHoTen_Cat_YCC2.Text.Trim();
            //                    ctchungtu.CatNK_DiaChi2 = txtDiaChiKH_Cat_YCC2.Text.Trim();
            //                    ctchungtu.CatNK_SoNKCat2 = int.Parse(txtSoNKCat_YCC2.Text.Trim());
            //                    ctchungtu.SoLuongDC_YCC = 2;
            //                    ///
            //                    lichsuchungtu2.YeuCauCat = true;
            //                    lichsuchungtu2.NhanNK_DanhBo = txtDanhBo.Text.Trim();
            //                    lichsuchungtu2.NhanNK_HoTen = txtHoTen.Text.Trim();
            //                    lichsuchungtu2.NhanNK_DiaChi = txtDiaChi.Text.Trim();
            //                    lichsuchungtu2.PhieuDuocKy = true;
            //                    ///
            //                }
            //            else
            //            {
            //                ctchungtu.YeuCauCat2 = false;
            //            }

            //            if (chkYCCat3.Checked)
            //                if (txtSoNKCat_YCC3.Text.Trim() == "")
            //                {
            //                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC3", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //                else
            //                {
            //                    LichSuChungTu lichsuchungtu3 = lichsuchungtu;
            //                    ///Chi tiết liên quan đến Danh Bộ nào
            //                    ctchungtu.YeuCauCat3 = true;
            //                    ctchungtu.CatNK_MaCN3 = int.Parse(cmbChiNhanh_YCC3.SelectedValue.ToString());
            //                    ctchungtu.CatNK_DanhBo3 = txtDanhBo_Cat_YCC3.Text.Trim();
            //                    ctchungtu.CatNK_HoTen3 = txtHoTen_Cat_YCC3.Text.Trim();
            //                    ctchungtu.CatNK_DiaChi3 = txtDiaChiKH_Cat_YCC3.Text.Trim();
            //                    ctchungtu.CatNK_SoNKCat3 = int.Parse(txtSoNKCat_YCC3.Text.Trim());
            //                    ctchungtu.SoLuongDC_YCC = 3;
            //                    ///
            //                    lichsuchungtu3.YeuCauCat = true;
            //                    lichsuchungtu3.NhanNK_DanhBo = txtDanhBo.Text.Trim();
            //                    lichsuchungtu3.NhanNK_HoTen = txtHoTen.Text.Trim();
            //                    lichsuchungtu3.NhanNK_DiaChi = txtDiaChi.Text.Trim();
            //                    lichsuchungtu3.PhieuDuocKy = true;
            //                    ///
            //                }
            //            else
            //            {
            //                ctchungtu.YeuCauCat3 = false;
            //            }

            //            if (chkYCCat4.Checked)
            //                if (txtSoNKCat_YCC4.Text.Trim() == "")
            //                {
            //                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC4", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //                else
            //                {
            //                    LichSuChungTu lichsuchungtu4 = lichsuchungtu;
            //                    ///Chi tiết liên quan đến Danh Bộ nào
            //                    ctchungtu.YeuCauCat4 = true;
            //                    ctchungtu.CatNK_MaCN4 = int.Parse(cmbChiNhanh_YCC4.SelectedValue.ToString());
            //                    ctchungtu.CatNK_DanhBo4 = txtDanhBo_Cat_YCC4.Text.Trim();
            //                    ctchungtu.CatNK_HoTen4 = txtHoTen_Cat_YCC4.Text.Trim();
            //                    ctchungtu.CatNK_DiaChi4 = txtDiaChiKH_Cat_YCC4.Text.Trim();
            //                    ctchungtu.CatNK_SoNKCat4 = int.Parse(txtSoNKCat_YCC4.Text.Trim());
            //                    ctchungtu.SoLuongDC_YCC = 4;
            //                    ///
            //                    lichsuchungtu4.YeuCauCat = true;
            //                    lichsuchungtu4.NhanNK_DanhBo = txtDanhBo.Text.Trim();
            //                    lichsuchungtu4.NhanNK_HoTen = txtHoTen.Text.Trim();
            //                    lichsuchungtu4.NhanNK_DiaChi = txtDiaChi.Text.Trim();
            //                    lichsuchungtu4.PhieuDuocKy = true;
            //                    ///
            //                }
            //            else
            //            {
            //                ctchungtu.YeuCauCat4 = false;
            //            }

            //            if (chkYCCat5.Checked)
            //                if (txtSoNKCat_YCC5.Text.Trim() == "")
            //                {
            //                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //                else
            //                {
            //                    LichSuChungTu lichsuchungtu5 = lichsuchungtu;
            //                    ///Chi tiết liên quan đến Danh Bộ nào
            //                    ctchungtu.YeuCauCat5 = true;
            //                    ctchungtu.CatNK_MaCN5 = int.Parse(cmbChiNhanh_YCC5.SelectedValue.ToString());
            //                    ctchungtu.CatNK_DanhBo5 = txtDanhBo_Cat_YCC5.Text.Trim();
            //                    ctchungtu.CatNK_HoTen5 = txtHoTen_Cat_YCC5.Text.Trim();
            //                    ctchungtu.CatNK_DiaChi5 = txtDiaChiKH_Cat_YCC5.Text.Trim();
            //                    ctchungtu.CatNK_SoNKCat5 = int.Parse(txtSoNKCat_YCC5.Text.Trim());
            //                    ctchungtu.SoLuongDC_YCC = 5;
            //                    ///
            //                    lichsuchungtu5.YeuCauCat = true;
            //                    lichsuchungtu5.NhanNK_DanhBo = txtDanhBo.Text.Trim();
            //                    lichsuchungtu5.NhanNK_HoTen = txtHoTen.Text.Trim();
            //                    lichsuchungtu5.NhanNK_DiaChi = txtDiaChi.Text.Trim();
            //                    lichsuchungtu5.PhieuDuocKy = true;
            //                    ///

            //                }
            //            else
            //            {
            //                ctchungtu.YeuCauCat5 = false;
            //            }

            //            #endregion

            //            if (_cChungTu.SuaChungTu(chungtu, ctchungtu, lichsuchungtu))
            //            {
            //                MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //                this.DialogResult = DialogResult.OK;
            //                this.Close();
            //            }

            //            //if (!chkYCCat2.Checked)
            //            //    if (_cChungTu.SuaChungTu(chungtu, ctchungtu, lichsuchungtu))
            //            //    {
            //            //        MessageBox.Show("SửaThành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            //        this.DialogResult = DialogResult.OK;
            //            //        this.Close();
            //            //    }
            //        }
            //        else
            //            MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cmbLoaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtThoiHan.Text = ((LoaiChungTu)cmbLoaiCT.SelectedItem).ThoiHan.ToString();

            if (cmbLoaiCT.SelectedValue.ToString() == "7")
                txtGhiChu.Text = "DINH MUC NHAP CU";
            else
                txtGhiChu.Text = "";
        }

        #region Configure TextBox

        private void cmbLoaiCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtMaCT.Focus();
        }

        private void txtMaCT_Leave(object sender, EventArgs e)
        {

        }

        private void txtMaCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //    e.Handled = true;
            if (e.KeyChar == 13)
            {
                if (_cChungTu.CheckCTChungTu(txtDanhBo.Text.Trim(), txtMaCT.Text.Trim()))
                    MessageBox.Show("Số đăng ký này đã đăng ký với danh bạ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    if (_cChungTu.CheckCTChungTubyMaCT(txtMaCT.Text.Trim()))
                        MessageBox.Show("Số đăng ký này đã có đăng ký trước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                dgvDSDanhBo.DataSource = _cChungTu.LoadDSCTChungTubyMaCT(txtMaCT.Text.Trim());
            }
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
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
                this.Size = new Size(1370, 478);
                this.Location = new Point(10, 70);
            }
            else
                if (!panel_YCCat3.Visible)
                {
                    panel_YCCat3.Visible = true;
                    this.Size = new Size(1370, 478);
                }
                else
                    if (!panel_YCCat4.Visible)
                    {
                        panel_YCCat4.Visible = true;
                        this.Size = new Size(1370, 478);
                    }
                    else
                        if (!panel_YCCat5.Visible)
                        {
                            panel_YCCat5.Visible = true;
                            this.Size = new Size(1370, 692);
                        }
                        else
                        {
                            panel_YCCat2.Visible = false;
                            panel_YCCat3.Visible = false;
                            panel_YCCat4.Visible = false;
                            panel_YCCat5.Visible = false;
                            this.Size = new Size(919, 510);
                            this.Location = new Point(70, 70);
                        }

        }

        private void frmSoDK_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void Them()
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (txtMaCT.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "0" && txtSoNKDangKy.Text.Trim() != "0")
                    {
                        ///Kiểm tra Danh Bộ & Số Chứng Từ
                        if (_cChungTu.CheckCTChungTu(txtDanhBo.Text.Trim(), txtMaCT.Text.Trim()) == true)
                        {
                            MessageBox.Show("Danh Bộ trên đã đăng ký Số Chứng Từ trên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ///Kiểm tra Số Chứng Từ
                        if (_cChungTu.CheckChungTu(txtMaCT.Text.Trim()) == false)
                        {
                            ChungTu chungtu = new ChungTu();
                            chungtu.MaCT = txtMaCT.Text.Trim();
                            chungtu.DiaChi = txtDiaChi.Text.Trim();
                            chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());
                            chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
                            _cChungTu.ThemChungTu(chungtu);
                        }
                        ///Lấy thông tin Chứng Từ để kiểm tra
                        ChungTu _chungtu = _cChungTu.getChungTubyID(txtMaCT.Text.Trim());
                        if (_chungtu.SoNKTong - _chungtu.CTChungTus.Sum(item => item.SoNKDangKy) < int.Parse(txtSoNKDangKy.Text.Trim()))
                        {
                            MessageBox.Show("Vượt Nhân Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ///
                        CTChungTu ctchungtu = new CTChungTu();
                        ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                        ctchungtu.MaCT = txtMaCT.Text.Trim();
                        ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                        if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                        {
                            ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                            ctchungtu.NgayHetHan = DateTime.Now.AddMonths(int.Parse(txtThoiHan.Text.Trim()));
                        }
                        ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                        ctchungtu.Lo = txtLo.Text.Trim();
                        ctchungtu.Phong = txtPhong.Text.Trim();
                        #region Yêu Cầu Cắt
                        if (chkYCCat1.Checked)
                            if (txtSoNKCat_YCC1.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC1", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                ctchungtu.YeuCauCat = true;
                                ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                                ctchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                                ctchungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                                ctchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                                ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                                ctchungtu.SoLuongDC_YCC = 1;
                            }
                        if (chkYCCat2.Checked)
                            if (txtSoNKCat_YCC2.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC2", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                ctchungtu.YeuCauCat2 = true;
                                ctchungtu.CatNK_MaCN2 = int.Parse(cmbChiNhanh_YCC2.SelectedValue.ToString());
                                ctchungtu.CatNK_DanhBo2 = txtDanhBo_Cat_YCC2.Text.Trim();
                                ctchungtu.CatNK_HoTen2 = txtHoTen_Cat_YCC2.Text.Trim();
                                ctchungtu.CatNK_DiaChi2 = txtDiaChiKH_Cat_YCC2.Text.Trim();
                                ctchungtu.CatNK_SoNKCat2 = int.Parse(txtSoNKCat_YCC2.Text.Trim());
                                ctchungtu.SoLuongDC_YCC = 2;
                            }
                        if (chkYCCat3.Checked)
                            if (txtSoNKCat_YCC3.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC3", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                ctchungtu.YeuCauCat3 = true;
                                ctchungtu.CatNK_MaCN3 = int.Parse(cmbChiNhanh_YCC3.SelectedValue.ToString());
                                ctchungtu.CatNK_DanhBo3 = txtDanhBo_Cat_YCC3.Text.Trim();
                                ctchungtu.CatNK_HoTen3 = txtHoTen_Cat_YCC3.Text.Trim();
                                ctchungtu.CatNK_DiaChi3 = txtDiaChiKH_Cat_YCC3.Text.Trim();
                                ctchungtu.CatNK_SoNKCat3 = int.Parse(txtSoNKCat_YCC3.Text.Trim());
                                ctchungtu.SoLuongDC_YCC = 3;
                            }
                        if (chkYCCat4.Checked)
                            if (txtSoNKCat_YCC4.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC4", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                ctchungtu.YeuCauCat4 = true;
                                ctchungtu.CatNK_MaCN4 = int.Parse(cmbChiNhanh_YCC4.SelectedValue.ToString());
                                ctchungtu.CatNK_DanhBo4 = txtDanhBo_Cat_YCC4.Text.Trim();
                                ctchungtu.CatNK_HoTen4 = txtHoTen_Cat_YCC4.Text.Trim();
                                ctchungtu.CatNK_DiaChi4 = txtDiaChiKH_Cat_YCC4.Text.Trim();
                                ctchungtu.CatNK_SoNKCat4 = int.Parse(txtSoNKCat_YCC4.Text.Trim());
                                ctchungtu.SoLuongDC_YCC = 4;
                            }
                        if (chkYCCat5.Checked)
                            if (txtSoNKCat_YCC5.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                ctchungtu.YeuCauCat5 = true;
                                ctchungtu.CatNK_MaCN5 = int.Parse(cmbChiNhanh_YCC5.SelectedValue.ToString());
                                ctchungtu.CatNK_DanhBo5 = txtDanhBo_Cat_YCC5.Text.Trim();
                                ctchungtu.CatNK_HoTen5 = txtHoTen_Cat_YCC5.Text.Trim();
                                ctchungtu.CatNK_DiaChi5 = txtDiaChiKH_Cat_YCC5.Text.Trim();
                                ctchungtu.CatNK_SoNKCat5 = int.Parse(txtSoNKCat_YCC5.Text.Trim());
                                ctchungtu.SoLuongDC_YCC = 5;
                            }
                        #endregion
                        ///Ghi thông tin Lịch Sử chung
                        LichSuChungTu lichsuchungtu = new LichSuChungTu();
                        if (bool.Parse(_source["TXL"]) == true)
                        {
                            lichsuchungtu.ToXuLy = true;
                            lichsuchungtu.MaDonTXL = decimal.Parse(_source["MaDon"]);
                        }
                        else
                            lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);
                        lichsuchungtu.DanhBo = ctchungtu.DanhBo;
                        lichsuchungtu.MaCT = ctchungtu.MaCT;
                        lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
                        lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
                        lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
                        lichsuchungtu.GhiChu = ctchungtu.GhiChu;
                        lichsuchungtu.Lo = ctchungtu.Lo;
                        lichsuchungtu.Phong = ctchungtu.Phong;

                        if (_cChungTu.ThemCTChungTu(ctchungtu))
                        {
                            ///Thêm Lịch Sử đầu tiên
                            _cChungTu.ThemLichSuChungTu(lichsuchungtu);
                            #region Yêu Cầu Cắt
                            if (ctchungtu.YeuCauCat)
                            {
                                LichSuChungTu lichsuchungtu1 = new LichSuChungTu();
                                lichsuchungtu1 = lichsuchungtu;
                                lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                ///
                                lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                lichsuchungtu1.NhanNK_HoTen = txtHoTen.Text.Trim();
                                lichsuchungtu1.NhanNK_DiaChi = txtDiaChi.Text.Trim();
                                ///
                                lichsuchungtu1.YeuCauCat = true;
                                lichsuchungtu1.CatNK_MaCN = ctchungtu.CatNK_MaCN;
                                lichsuchungtu1.CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
                                lichsuchungtu1.CatNK_HoTen = ctchungtu.CatNK_HoTen;
                                lichsuchungtu1.CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
                                lichsuchungtu1.SoNKNhan = ctchungtu.CatNK_SoNKCat;
                                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                else
                                    lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                lichsuchungtu1.PhieuDuocKy = true;

                                if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                    ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                            }
                            if (ctchungtu.YeuCauCat2)
                            {
                                LichSuChungTu lichsuchungtu1 = new LichSuChungTu();
                                lichsuchungtu1 = lichsuchungtu;
                                lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                ///
                                lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                lichsuchungtu1.NhanNK_HoTen = txtHoTen.Text.Trim();
                                lichsuchungtu1.NhanNK_DiaChi = txtDiaChi.Text.Trim();
                                ///
                                lichsuchungtu1.YeuCauCat = true;
                                lichsuchungtu1.CatNK_MaCN = ctchungtu.CatNK_MaCN2;
                                lichsuchungtu1.CatNK_DanhBo = ctchungtu.CatNK_DanhBo2;
                                lichsuchungtu1.CatNK_HoTen = ctchungtu.CatNK_HoTen2;
                                lichsuchungtu1.CatNK_DiaChi = ctchungtu.CatNK_DiaChi2;
                                lichsuchungtu1.SoNKNhan = ctchungtu.CatNK_SoNKCat2;
                                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                else
                                    lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                lichsuchungtu1.PhieuDuocKy = true;

                                if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                    ctchungtu.SoPhieu2 = lichsuchungtu1.SoPhieu;
                            }
                            if (ctchungtu.YeuCauCat3)
                            {
                                LichSuChungTu lichsuchungtu1 = new LichSuChungTu();
                                lichsuchungtu1 = lichsuchungtu;
                                lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                ///
                                lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                lichsuchungtu1.NhanNK_HoTen = txtHoTen.Text.Trim();
                                lichsuchungtu1.NhanNK_DiaChi = txtDiaChi.Text.Trim();
                                ///
                                lichsuchungtu1.YeuCauCat = true;
                                lichsuchungtu1.CatNK_MaCN = ctchungtu.CatNK_MaCN3;
                                lichsuchungtu1.CatNK_DanhBo = ctchungtu.CatNK_DanhBo3;
                                lichsuchungtu1.CatNK_HoTen = ctchungtu.CatNK_HoTen3;
                                lichsuchungtu1.CatNK_DiaChi = ctchungtu.CatNK_DiaChi3;
                                lichsuchungtu1.SoNKNhan = ctchungtu.CatNK_SoNKCat3;
                                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                else
                                    lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                lichsuchungtu1.PhieuDuocKy = true;

                                if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                    ctchungtu.SoPhieu3 = lichsuchungtu1.SoPhieu;
                            }
                            if (ctchungtu.YeuCauCat4)
                            {
                                LichSuChungTu lichsuchungtu1 = new LichSuChungTu();
                                lichsuchungtu1 = lichsuchungtu;
                                lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                ///
                                lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                lichsuchungtu1.NhanNK_HoTen = txtHoTen.Text.Trim();
                                lichsuchungtu1.NhanNK_DiaChi = txtDiaChi.Text.Trim();
                                ///
                                lichsuchungtu1.YeuCauCat = true;
                                lichsuchungtu1.CatNK_MaCN = ctchungtu.CatNK_MaCN4;
                                lichsuchungtu1.CatNK_DanhBo = ctchungtu.CatNK_DanhBo4;
                                lichsuchungtu1.CatNK_HoTen = ctchungtu.CatNK_HoTen4;
                                lichsuchungtu1.CatNK_DiaChi = ctchungtu.CatNK_DiaChi4;
                                lichsuchungtu1.SoNKNhan = ctchungtu.CatNK_SoNKCat4;
                                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                else
                                    lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                lichsuchungtu1.PhieuDuocKy = true;

                                if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                    ctchungtu.SoPhieu4 = lichsuchungtu1.SoPhieu;
                            }
                            if (ctchungtu.YeuCauCat5)
                            {
                                LichSuChungTu lichsuchungtu1 = new LichSuChungTu();
                                lichsuchungtu1 = lichsuchungtu;
                                lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                ///
                                lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                lichsuchungtu1.NhanNK_HoTen = txtHoTen.Text.Trim();
                                lichsuchungtu1.NhanNK_DiaChi = txtDiaChi.Text.Trim();
                                ///
                                lichsuchungtu1.YeuCauCat = true;
                                lichsuchungtu1.CatNK_MaCN = ctchungtu.CatNK_MaCN5;
                                lichsuchungtu1.CatNK_DanhBo = ctchungtu.CatNK_DanhBo5;
                                lichsuchungtu1.CatNK_HoTen = ctchungtu.CatNK_HoTen5;
                                lichsuchungtu1.CatNK_DiaChi = ctchungtu.CatNK_DiaChi5;
                                lichsuchungtu1.SoNKNhan = ctchungtu.CatNK_SoNKCat5;
                                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                else
                                    lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                lichsuchungtu1.PhieuDuocKy = true;

                                if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                    ctchungtu.SoPhieu5 = lichsuchungtu1.SoPhieu;
                            }
                            #endregion
                            _cChungTu.SubmitChanges();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
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

        public void Sua()
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (txtMaCT.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "0")
                    {
                        ChungTu _chungtu = _cChungTu.getChungTubyID(txtMaCT.Text.Trim());
                        CTChungTu _ctchungtu = _cChungTu.getCTChungTubyID(txtDanhBo.Text.Trim(), txtMaCT.Text.Trim());

                        _chungtu.DiaChi = txtDiaChi.Text.Trim();
                        _chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());
                        _chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
                        _cChungTu.SuaChungTu(_chungtu);

                        if (_chungtu.SoNKTong - _chungtu.CTChungTus.Sum(item => item.SoNKDangKy) + _ctchungtu.SoNKDangKy < int.Parse(txtSoNKDangKy.Text.Trim()))
                        {
                            MessageBox.Show("Vượt Nhân Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ///
                        _ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                        _ctchungtu.Lo = txtLo.Text.Trim();
                        _ctchungtu.Phong = txtPhong.Text.Trim();
                        _ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                        ///
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
                        ///
                        if (chkSuaNgayHetHan.Checked)
                            if (_ctchungtu.NgayHetHan.Value.Date != dateHetHan.Value.Date)
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
                            else
                            {
                                _ctchungtu.YeuCauCat = true;
                                _ctchungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                                _ctchungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                                _ctchungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                                _ctchungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                                _ctchungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                                _ctchungtu.SoLuongDC_YCC = 1;
                            }
                        if (chkYCCat2.Checked)
                            if (txtSoNKCat_YCC2.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC2", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                _ctchungtu.YeuCauCat2 = true;
                                _ctchungtu.CatNK_MaCN2 = int.Parse(cmbChiNhanh_YCC2.SelectedValue.ToString());
                                _ctchungtu.CatNK_DanhBo2 = txtDanhBo_Cat_YCC2.Text.Trim();
                                _ctchungtu.CatNK_HoTen2 = txtHoTen_Cat_YCC2.Text.Trim();
                                _ctchungtu.CatNK_DiaChi2 = txtDiaChiKH_Cat_YCC2.Text.Trim();
                                _ctchungtu.CatNK_SoNKCat2 = int.Parse(txtSoNKCat_YCC2.Text.Trim());
                                _ctchungtu.SoLuongDC_YCC = 2;
                            }
                        if (chkYCCat3.Checked)
                            if (txtSoNKCat_YCC3.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC3", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                _ctchungtu.YeuCauCat3 = true;
                                _ctchungtu.CatNK_MaCN3 = int.Parse(cmbChiNhanh_YCC3.SelectedValue.ToString());
                                _ctchungtu.CatNK_DanhBo3 = txtDanhBo_Cat_YCC3.Text.Trim();
                                _ctchungtu.CatNK_HoTen3 = txtHoTen_Cat_YCC3.Text.Trim();
                                _ctchungtu.CatNK_DiaChi3 = txtDiaChiKH_Cat_YCC3.Text.Trim();
                                _ctchungtu.CatNK_SoNKCat3 = int.Parse(txtSoNKCat_YCC3.Text.Trim());
                                _ctchungtu.SoLuongDC_YCC = 3;
                            }
                        if (chkYCCat4.Checked)
                            if (txtSoNKCat_YCC4.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC4", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                _ctchungtu.YeuCauCat4 = true;
                                _ctchungtu.CatNK_MaCN4 = int.Parse(cmbChiNhanh_YCC4.SelectedValue.ToString());
                                _ctchungtu.CatNK_DanhBo4 = txtDanhBo_Cat_YCC4.Text.Trim();
                                _ctchungtu.CatNK_HoTen4 = txtHoTen_Cat_YCC4.Text.Trim();
                                _ctchungtu.CatNK_DiaChi4 = txtDiaChiKH_Cat_YCC4.Text.Trim();
                                _ctchungtu.CatNK_SoNKCat4 = int.Parse(txtSoNKCat_YCC4.Text.Trim());
                                _ctchungtu.SoLuongDC_YCC = 4;
                            }
                        if (chkYCCat5.Checked)
                            if (txtSoNKCat_YCC5.Text.Trim() == "")
                            {
                                MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                _ctchungtu.YeuCauCat5 = true;
                                _ctchungtu.CatNK_MaCN5 = int.Parse(cmbChiNhanh_YCC5.SelectedValue.ToString());
                                _ctchungtu.CatNK_DanhBo5 = txtDanhBo_Cat_YCC5.Text.Trim();
                                _ctchungtu.CatNK_HoTen5 = txtHoTen_Cat_YCC5.Text.Trim();
                                _ctchungtu.CatNK_DiaChi5 = txtDiaChiKH_Cat_YCC5.Text.Trim();
                                _ctchungtu.CatNK_SoNKCat5 = int.Parse(txtSoNKCat_YCC5.Text.Trim());
                                _ctchungtu.SoLuongDC_YCC = 5;
                            }
                        #endregion
                        ///Ghi thông tin Lịch Sử chung
                        LichSuChungTu lichsuchungtu = new LichSuChungTu();
                        if (bool.Parse(_source["TXL"]) == true)
                        {
                            lichsuchungtu.ToXuLy = true;
                            lichsuchungtu.MaDonTXL = decimal.Parse(_source["MaDon"]);
                        }
                        else
                            lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);
                        lichsuchungtu.DanhBo = _ctchungtu.DanhBo;
                        lichsuchungtu.MaCT = _ctchungtu.MaCT;
                        lichsuchungtu.SoNKDangKy = _ctchungtu.SoNKDangKy;
                        lichsuchungtu.ThoiHan = _ctchungtu.ThoiHan;
                        lichsuchungtu.NgayHetHan = _ctchungtu.NgayHetHan;
                        lichsuchungtu.GhiChu = _ctchungtu.GhiChu;
                        lichsuchungtu.Lo = _ctchungtu.Lo;
                        lichsuchungtu.Phong = _ctchungtu.Phong;

                        if (_cChungTu.SuaCTChungTu(_ctchungtu))
                        {
                            ///Thêm Lịch Sử đầu tiên
                            _cChungTu.ThemLichSuChungTu(lichsuchungtu);
                            #region Yêu Cầu Cắt
                            if (_ctchungtu.YeuCauCat)
                                if (_ctchungtu.SoPhieu != null)
                                {
                                    LichSuChungTu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu.Value);
                                    _lichsuchungtu.CatNK_MaCN = _ctchungtu.CatNK_MaCN;
                                    _lichsuchungtu.CatNK_DanhBo = _ctchungtu.CatNK_DanhBo;
                                    _lichsuchungtu.CatNK_HoTen = _ctchungtu.CatNK_HoTen;
                                    _lichsuchungtu.CatNK_DiaChi = _ctchungtu.CatNK_DiaChi;
                                    _lichsuchungtu.SoNKNhan = _ctchungtu.CatNK_SoNKCat;
                                    _cChungTu.SuaLichSuChungTu(_lichsuchungtu);
                                }
                                else
                                {
                                    LichSuChungTu lichsuchungtu1 = new LichSuChungTu();
                                    lichsuchungtu1 = lichsuchungtu;
                                    lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                    _ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                    ///
                                    lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu1.NhanNK_HoTen = txtHoTen.Text.Trim();
                                    lichsuchungtu1.NhanNK_DiaChi = txtDiaChi.Text.Trim();
                                    ///
                                    lichsuchungtu1.YeuCauCat = true;
                                    lichsuchungtu1.CatNK_MaCN = _ctchungtu.CatNK_MaCN;
                                    lichsuchungtu1.CatNK_DanhBo = _ctchungtu.CatNK_DanhBo;
                                    lichsuchungtu1.CatNK_HoTen = _ctchungtu.CatNK_HoTen;
                                    lichsuchungtu1.CatNK_DiaChi = _ctchungtu.CatNK_DiaChi;
                                    lichsuchungtu1.SoNKNhan = _ctchungtu.CatNK_SoNKCat;
                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                    else
                                        lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    lichsuchungtu1.PhieuDuocKy = true;

                                    if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                        _ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                }
                            if (_ctchungtu.YeuCauCat2)
                                if (_ctchungtu.SoPhieu2 != null)
                                {
                                    LichSuChungTu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu2.Value);
                                    _lichsuchungtu.CatNK_MaCN = _ctchungtu.CatNK_MaCN2;
                                    _lichsuchungtu.CatNK_DanhBo = _ctchungtu.CatNK_DanhBo2;
                                    _lichsuchungtu.CatNK_HoTen = _ctchungtu.CatNK_HoTen2;
                                    _lichsuchungtu.CatNK_DiaChi = _ctchungtu.CatNK_DiaChi2;
                                    _lichsuchungtu.SoNKNhan = _ctchungtu.CatNK_SoNKCat2;
                                    _cChungTu.SuaLichSuChungTu(_lichsuchungtu);
                                }
                                else
                                {
                                    LichSuChungTu lichsuchungtu1 = new LichSuChungTu();
                                    lichsuchungtu1 = lichsuchungtu;
                                    lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                    _ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                    ///
                                    lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu1.NhanNK_HoTen = txtHoTen.Text.Trim();
                                    lichsuchungtu1.NhanNK_DiaChi = txtDiaChi.Text.Trim();
                                    ///
                                    lichsuchungtu1.YeuCauCat = true;
                                    lichsuchungtu1.CatNK_MaCN = _ctchungtu.CatNK_MaCN2;
                                    lichsuchungtu1.CatNK_DanhBo = _ctchungtu.CatNK_DanhBo2;
                                    lichsuchungtu1.CatNK_HoTen = _ctchungtu.CatNK_HoTen2;
                                    lichsuchungtu1.CatNK_DiaChi = _ctchungtu.CatNK_DiaChi2;
                                    lichsuchungtu1.SoNKNhan = _ctchungtu.CatNK_SoNKCat2;
                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                    else
                                        lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    lichsuchungtu1.PhieuDuocKy = true;

                                    if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                        _ctchungtu.SoPhieu2 = lichsuchungtu1.SoPhieu;
                                }
                            if (_ctchungtu.YeuCauCat3)
                                if (_ctchungtu.SoPhieu3 != null)
                                {
                                    LichSuChungTu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu3.Value);
                                    _lichsuchungtu.CatNK_MaCN = _ctchungtu.CatNK_MaCN3;
                                    _lichsuchungtu.CatNK_DanhBo = _ctchungtu.CatNK_DanhBo3;
                                    _lichsuchungtu.CatNK_HoTen = _ctchungtu.CatNK_HoTen3;
                                    _lichsuchungtu.CatNK_DiaChi = _ctchungtu.CatNK_DiaChi3;
                                    _lichsuchungtu.SoNKNhan = _ctchungtu.CatNK_SoNKCat3;
                                    _cChungTu.SuaLichSuChungTu(_lichsuchungtu);
                                }
                                else
                                {
                                    LichSuChungTu lichsuchungtu1 = new LichSuChungTu();
                                    lichsuchungtu1 = lichsuchungtu;
                                    lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                    _ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                    ///
                                    lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu1.NhanNK_HoTen = txtHoTen.Text.Trim();
                                    lichsuchungtu1.NhanNK_DiaChi = txtDiaChi.Text.Trim();
                                    ///
                                    lichsuchungtu1.YeuCauCat = true;
                                    lichsuchungtu1.CatNK_MaCN = _ctchungtu.CatNK_MaCN3;
                                    lichsuchungtu1.CatNK_DanhBo = _ctchungtu.CatNK_DanhBo3;
                                    lichsuchungtu1.CatNK_HoTen = _ctchungtu.CatNK_HoTen3;
                                    lichsuchungtu1.CatNK_DiaChi = _ctchungtu.CatNK_DiaChi3;
                                    lichsuchungtu1.SoNKNhan = _ctchungtu.CatNK_SoNKCat3;
                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                    else
                                        lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    lichsuchungtu1.PhieuDuocKy = true;

                                    if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                        _ctchungtu.SoPhieu3 = lichsuchungtu1.SoPhieu;
                                }
                            if (_ctchungtu.YeuCauCat4)
                                if (_ctchungtu.SoPhieu4 != null)
                                {
                                    LichSuChungTu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu4.Value);
                                    _lichsuchungtu.CatNK_MaCN = _ctchungtu.CatNK_MaCN4;
                                    _lichsuchungtu.CatNK_DanhBo = _ctchungtu.CatNK_DanhBo4;
                                    _lichsuchungtu.CatNK_HoTen = _ctchungtu.CatNK_HoTen4;
                                    _lichsuchungtu.CatNK_DiaChi = _ctchungtu.CatNK_DiaChi4;
                                    _lichsuchungtu.SoNKNhan = _ctchungtu.CatNK_SoNKCat4;
                                    _cChungTu.SuaLichSuChungTu(_lichsuchungtu);
                                }
                                else
                                {
                                    LichSuChungTu lichsuchungtu1 = new LichSuChungTu();
                                    lichsuchungtu1 = lichsuchungtu;
                                    lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                    _ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                    ///
                                    lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu1.NhanNK_HoTen = txtHoTen.Text.Trim();
                                    lichsuchungtu1.NhanNK_DiaChi = txtDiaChi.Text.Trim();
                                    ///
                                    lichsuchungtu1.YeuCauCat = true;
                                    lichsuchungtu1.CatNK_MaCN = _ctchungtu.CatNK_MaCN4;
                                    lichsuchungtu1.CatNK_DanhBo = _ctchungtu.CatNK_DanhBo4;
                                    lichsuchungtu1.CatNK_HoTen = _ctchungtu.CatNK_HoTen4;
                                    lichsuchungtu1.CatNK_DiaChi = _ctchungtu.CatNK_DiaChi4;
                                    lichsuchungtu1.SoNKNhan = _ctchungtu.CatNK_SoNKCat4;
                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                    else
                                        lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    lichsuchungtu1.PhieuDuocKy = true;

                                    if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                        _ctchungtu.SoPhieu4 = lichsuchungtu1.SoPhieu;
                                }
                            if (_ctchungtu.YeuCauCat5)
                                if (_ctchungtu.SoPhieu5 != null)
                                {
                                    LichSuChungTu _lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(_ctchungtu.SoPhieu5.Value);
                                    _lichsuchungtu.CatNK_MaCN = _ctchungtu.CatNK_MaCN5;
                                    _lichsuchungtu.CatNK_DanhBo = _ctchungtu.CatNK_DanhBo5;
                                    _lichsuchungtu.CatNK_HoTen = _ctchungtu.CatNK_HoTen5;
                                    _lichsuchungtu.CatNK_DiaChi = _ctchungtu.CatNK_DiaChi5;
                                    _lichsuchungtu.SoNKNhan = _ctchungtu.CatNK_SoNKCat5;
                                    _cChungTu.SuaLichSuChungTu(_lichsuchungtu);
                                }
                                else
                                {
                                    LichSuChungTu lichsuchungtu1 = new LichSuChungTu();
                                    lichsuchungtu1 = lichsuchungtu;
                                    lichsuchungtu1.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                                    _ctchungtu.SoPhieu = lichsuchungtu1.SoPhieu;
                                    ///
                                    lichsuchungtu1.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                                    lichsuchungtu1.NhanNK_HoTen = txtHoTen.Text.Trim();
                                    lichsuchungtu1.NhanNK_DiaChi = txtDiaChi.Text.Trim();
                                    ///
                                    lichsuchungtu1.YeuCauCat = true;
                                    lichsuchungtu1.CatNK_MaCN = _ctchungtu.CatNK_MaCN5;
                                    lichsuchungtu1.CatNK_DanhBo = _ctchungtu.CatNK_DanhBo5;
                                    lichsuchungtu1.CatNK_HoTen = _ctchungtu.CatNK_HoTen5;
                                    lichsuchungtu1.CatNK_DiaChi = _ctchungtu.CatNK_DiaChi5;
                                    lichsuchungtu1.SoNKNhan = _ctchungtu.CatNK_SoNKCat5;
                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        lichsuchungtu1.ChucVu = "GIÁM ĐỐC";
                                    else
                                        lichsuchungtu1.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    lichsuchungtu1.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    lichsuchungtu1.PhieuDuocKy = true;

                                    if (_cChungTu.ThemLichSuChungTu(lichsuchungtu1))
                                        _ctchungtu.SoPhieu5 = lichsuchungtu1.SoPhieu;
                                }
                            #endregion
                            _cChungTu.SubmitChanges();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
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

        

    }
}
