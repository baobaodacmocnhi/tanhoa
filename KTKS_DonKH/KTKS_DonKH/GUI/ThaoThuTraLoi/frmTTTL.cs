﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThaoThuTraLoi;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    public partial class frmTTTL : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CTTKH _cTTKH = new CTTKH();
        DonKH _donkh = null;
        TTKhachHang _ttkhachhang = null;
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();
        CKTXM _cKTXM = new CKTXM();
        CTTTL _cTTTL = new CTTTL();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        bool _direct = false;///Mở form trực tiếp không qua Danh Sách Đơn
                             
        public frmTTTL()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load Form trực tiếp không qua Danh Sách Đơn
        /// </summary>
        /// <param name="direct"></param>
        public frmTTTL(bool direct)
        {
            InitializeComponent();
            _direct = direct;
        }

        public frmTTTL(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        /// <summary>
        /// Nhận Entity TTKhachHang để điền vào textbox
        /// </summary>
        /// <param name="ttkhachhang"></param>
        public void LoadThongTin(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = _ttkhachhang.DanhBo;
            txtHopDong.Text = _ttkhachhang.GiaoUoc;
            txtHoTen.Text = _ttkhachhang.HoTen;
            txtDiaChi.Text = _ttkhachhang.DC1 + " " + _ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(_ttkhachhang.Quan, _ttkhachhang.Phuong);
            txtGiaBieu.Text = _ttkhachhang.GB;
            txtDinhMuc.Text = _ttkhachhang.TGDM;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            ///
            txtVeViec.Text = "";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";
            ///
            chkGiamNuocXaBo.Checked = false;
            chkKiemDinhDHN_Dung.Checked = false;
            chkKiemDinhDHN_Sai.Checked = false;
            chkThayDHN.Checked = false;
            chkDieuChinh_GB_DM.Checked = false;
            chkThuMoi.Checked = false;
            chkThuBao.Checked = false;
            _ttkhachhang = null;
        }

        private void frmTTTL_Load(object sender, EventArgs e)
        {
            if (_direct)
            {
                this.ControlBox = false;
                this.WindowState = FormWindowState.Maximized;
                this.BringToFront();
                txtMaDon.ReadOnly = false;
            }
            else
            {
                this.Location = new Point(70, 70);
                if (_cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"])) != null)
                {
                    _donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"]));
                    txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                }
                if (_cTTKH.getTTKHbyID(_source["DanhBo"]) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(_source["DanhBo"]);
                    LoadThongTin(_ttkhachhang);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_donkh != null && _ttkhachhang != null && txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "" & txtNoiNhan.Text.Trim() != "")
            {
                if (!_cTTTL.CheckTTTLbyMaDon(_donkh.MaDon))
                {
                    TTTL tttl = new TTTL();
                    tttl.MaDon = _donkh.MaDon;
                    if (_direct)
                    {
                        ///Sợ phía dưới bị lỗi nên phải thêm như thế
                        _source.Add("NoiChuyenDen", "");
                    }
                    else
                    {
                        tttl.MaNoiChuyenDen = decimal.Parse(_source["MaNoiChuyenDen"]);
                        tttl.NoiChuyenDen = _source["NoiChuyenDen"];
                        tttl.LyDoChuyenDen = _source["LyDoChuyenDen"];
                    }
                    if (_cTTTL.ThemTTTL(tttl))
                    {
                        switch (_source["NoiChuyenDen"])
                        {
                            case "Khách Hàng":
                                ///Báo cho bảng DonKH là đơn này đã được nơi nhận xử lý
                                DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                donkh.Nhan = true;
                                _cDonKH.SuaDonKH(donkh);
                                break;
                            case "Kiểm Tra Xác Minh":
                                ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                                KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                ktxm.Nhan = true;
                                _cKTXM.SuaKTXM(ktxm);
                                break;
                        }
                        //_source.Add("MaTTTL", _cTTTL.getMaxMaTTTL().ToString());
                    }
                }
                CTTTTL cttttl = new CTTTTL();
                cttttl.MaTTTL = _cTTTL.getTTTLbyMaDon(_donkh.MaDon).MaTTTL;
                cttttl.DanhBo = txtDanhBo.Text.Trim();
                cttttl.HopDong = txtHopDong.Text.Trim();
                cttttl.HoTen = txtHoTen.Text.Trim();
                cttttl.DiaChi = txtDiaChi.Text.Trim();
                cttttl.GiaBieu = txtGiaBieu.Text.Trim();
                cttttl.DinhMuc = txtDinhMuc.Text.Trim();
                cttttl.VeViec = txtVeViec.Text.Trim();
                cttttl.NoiDung = txtNoiDung.Text.Trim();
                cttttl.NoiNhan = txtNoiNhan.Text.Trim();
                ///
                if (chkGiamNuocXaBo.Checked)
                    cttttl.GiamNuocXaBo = true;
                if (chkKiemDinhDHN_Dung.Checked)
                    cttttl.KiemDinhDHN_Dung = true;
                if (chkKiemDinhDHN_Sai.Checked)
                    cttttl.KiemDinhDHN_Sai = true;
                if (chkThayDHN.Checked)
                    cttttl.ThayDHN = true;
                if (chkDieuChinh_GB_DM.Checked)
                    cttttl.DieuChinh_GB_DM = true;
                if (chkThuMoi.Checked)
                    cttttl.ThuMoi = true;
                if (chkThuBao.Checked)
                    cttttl.ThuBao = true;

                ///Ký Tên
                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                    cttttl.ChucVu = "GIÁM ĐỐC";
                else
                    cttttl.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();

                if (_cTTTL.ThemCTTTTL(cttttl))
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                    dr["SoPhieu"] = _cTTTL.getMaxMaCTTTTL().ToString().Insert(_cTTTL.getMaxMaCTTTTL().ToString().Length - 2, "-");
                    dr["HoTen"] = cttttl.HoTen;
                    dr["DiaChi"] = cttttl.DiaChi;
                    dr["DanhBo"] = cttttl.DanhBo;
                    dr["HopDong"] = cttttl.HopDong;
                    dr["GiaBieu"] = cttttl.GiaBieu;
                    dr["DinhMuc"] = cttttl.DinhMuc;
                    dr["NgayNhanDon"] = _donkh.CreateDate;
                    dr["VeViec"] = cttttl.VeViec;
                    dr["NoiDung"] = cttttl.NoiDung;
                    dr["NoiNhan"] = cttttl.NoiNhan;
                    dr["ChucVu"] = cttttl.ChucVu;
                    dr["NguoiKy"] = cttttl.NguoiKy;

                    dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                    rptThaoThuTraLoi rpt = new rptThaoThuTraLoi();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();

                    Clear();

                    if (!_direct)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                {
                    _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                    //txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                    if (_cTTKH.getTTKHbyID(_donkh.DanhBo) != null)
                    {
                        _ttkhachhang = _cTTKH.getTTKHbyID(_donkh.DanhBo);
                        LoadThongTin(_ttkhachhang);
                    }
                    else
                    {
                        Clear();
                        MessageBox.Show("Danh Bộ không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    _donkh = null;
                    Clear();
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
