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
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThaoThuTraLoi;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToXuLy;

namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    public partial class frmTTTL : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CTTKH _cTTKH = new CTTKH();
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        TTKhachHang _ttkhachhang = null;
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CKTXM _cKTXM = new CKTXM();
        CTTTL _cTTTL = new CTTTL();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        bool _direct = false;///Mở form trực tiếp không qua Danh Sách Đơn
        //bool _flagTXL = false;
  
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
        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtLoTrinh.Text = ttkhachhang.Dot + ttkhachhang.CuonGCS + ttkhachhang.CuonSTT;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
            txtGiaBieu.Text = ttkhachhang.GB;
            txtDinhMuc.Text = ttkhachhang.TGDM;
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
                    LoadTTKH(_ttkhachhang);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ///Nếu đơn thuộc Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_dontxl != null && txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "" & txtNoiNhan.Text.Trim() != "")
                    {
                        if (!_cTTTL.CheckTTTLbyMaDon_TXL(_dontxl.MaDon))
                        {
                            TTTL tttl = new TTTL();
                            tttl.ToXuLy = true;
                            tttl.MaDonTXL = _dontxl.MaDon;
                            if (_direct)
                            {
                                ///Sợ phía dưới bị lỗi nên phải thêm như thế
                                if (!_source.ContainsKey("NoiChuyenDen"))
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
                                        ///Báo cho bảng DonTXL là đơn này đã được nơi nhận xử lý
                                        DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                        dontxl.Nhan = true;
                                        _cDonTXL.SuaDonTXL(dontxl, true);
                                        break;
                                    case "Kiểm Tra Xác Minh":
                                        ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                                        KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                        ktxm.Nhan = true;
                                        _cKTXM.SuaKTXM(ktxm, true);
                                        break;
                                }
                                _source.Add("MaTTTL", _cTTTL.getMaxMaTTTL().ToString());
                                if (string.IsNullOrEmpty(_donkh.TienTrinh))
                                    _dontxl.TienTrinh = "TTTL";
                                else
                                    _dontxl.TienTrinh += ",TTTL";
                                _dontxl.Nhan = true;
                                _cDonTXL.SuaDonTXL(_dontxl, true);
                            }
                        }
                        //if (_cTTTL.CheckCTTTTLbyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim()))
                        //{
                        //    MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                        CTTTTL cttttl = new CTTTTL();
                        cttttl.MaTTTL = _cTTTL.getTTTLbyMaDon_TXL(_dontxl.MaDon).MaTTTL;
                        cttttl.DanhBo = txtDanhBo.Text.Trim();
                        cttttl.HopDong = txtHopDong.Text.Trim();
                        cttttl.LoTrinh = txtLoTrinh.Text.Trim();
                        cttttl.HoTen = txtHoTen.Text.Trim();
                        cttttl.DiaChi = txtDiaChi.Text.Trim();
                        cttttl.GiaBieu = txtGiaBieu.Text.Trim();
                        cttttl.DinhMuc = txtDinhMuc.Text.Trim();
                        if (_ttkhachhang != null)
                        {
                            cttttl.Dot = _ttkhachhang.Dot;
                            cttttl.Ky = _ttkhachhang.Ky;
                            cttttl.Nam = _ttkhachhang.Nam;
                        }
                        cttttl.VeViec = txtVeViec.Text.Trim();
                        cttttl.NoiDung = txtNoiDung.Text;
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
                            cttttl.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        cttttl.ThuDuocKy = true;

                        if (_cTTTL.ThemCTTTTL(cttttl))
                        {
                            MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                ///Nếu đơn thuộc Tổ Khách Hàng
                else
                    if (_donkh != null && txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "" & txtNoiNhan.Text.Trim() != "")
                    {
                        if (!_cTTTL.CheckTTTLbyMaDon(_donkh.MaDon))
                        {
                            TTTL tttl = new TTTL();
                            tttl.MaDon = _donkh.MaDon;
                            if (_direct)
                            {
                                ///Sợ phía dưới bị lỗi nên phải thêm như thế
                                if (!_source.ContainsKey("NoiChuyenDen"))
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
                                        _cDonKH.SuaDonKH(donkh, true);
                                        break;
                                    case "Kiểm Tra Xác Minh":
                                        ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                                        KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                        ktxm.Nhan = true;
                                        _cKTXM.SuaKTXM(ktxm, true);
                                        break;
                                }
                                //_source.Add("MaTTTL", _cTTTL.getMaxMaTTTL().ToString());
                                if (string.IsNullOrEmpty(_donkh.TienTrinh))
                                    _donkh.TienTrinh = "TTTL";
                                else
                                    _donkh.TienTrinh += ",TTTL";
                                _donkh.Nhan = true;
                                _cDonKH.SuaDonKH(_donkh, true);
                            }
                        }
                        //if (_cTTTL.CheckCTTTTLbyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim()))
                        //{
                        //    MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                        CTTTTL cttttl = new CTTTTL();
                        cttttl.MaTTTL = _cTTTL.getTTTLbyMaDon(_donkh.MaDon).MaTTTL;
                        cttttl.DanhBo = txtDanhBo.Text.Trim();
                        cttttl.HopDong = txtHopDong.Text.Trim();
                        cttttl.LoTrinh = txtLoTrinh.Text.Trim();
                        cttttl.HoTen = txtHoTen.Text.Trim();
                        cttttl.DiaChi = txtDiaChi.Text.Trim();
                        cttttl.GiaBieu = txtGiaBieu.Text.Trim();
                        cttttl.DinhMuc = txtDinhMuc.Text.Trim();
                        if (_ttkhachhang != null)
                        {
                            cttttl.Dot = _ttkhachhang.Dot;
                            cttttl.Ky = _ttkhachhang.Ky;
                            cttttl.Nam = _ttkhachhang.Nam;
                        }
                        cttttl.VeViec = txtVeViec.Text.Trim();
                        cttttl.NoiDung = txtNoiDung.Text;
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
                            cttttl.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        cttttl.ThuDuocKy = true;

                        if (_cTTTL.ThemCTTTTL(cttttl))
                        {
                            MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            //DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                            //dr["SoPhieu"] = _cTTTL.getMaxMaCTTTTL().ToString().Insert(_cTTTL.getMaxMaCTTTTL().ToString().Length - 2, "-");
                            //dr["LoTrinh"] = cttttl.LoTrinh;
                            //dr["HoTen"] = cttttl.HoTen;
                            //dr["DiaChi"] = cttttl.DiaChi;
                            //dr["DanhBo"] = cttttl.DanhBo.Insert(7, " ").Insert(4, " ");
                            //dr["HopDong"] = cttttl.HopDong;
                            //dr["GiaBieu"] = cttttl.GiaBieu;
                            //dr["DinhMuc"] = cttttl.DinhMuc;
                            //dr["NgayNhanDon"] = _donkh.CreateDate.Value.ToString("dd/MM/yyyy");
                            //dr["VeViec"] = cttttl.VeViec;
                            //dr["NoiDung"] = cttttl.NoiDung;
                            //dr["NoiNhan"] = cttttl.NoiNhan;
                            //dr["ChucVu"] = cttttl.ChucVu;
                            //dr["NguoiKy"] = cttttl.NguoiKy;

                            //dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                            //rptThaoThuTraLoi rpt = new rptThaoThuTraLoi();
                            //rpt.SetDataSource(dsBaoCao);
                            //frmBaoCao frm = new frmBaoCao(rpt);
                            //frm.ShowDialog();

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                        if (_cTTKH.getTTKHbyID(_dontxl.DanhBo) != null)
                        {
                            _ttkhachhang = _cTTKH.getTTKHbyID(_dontxl.DanhBo);
                            LoadTTKH(_ttkhachhang);
                        }
                        else
                        {
                            Clear();
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        _dontxl = null;
                        Clear();
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ///Đơn Tổ Khách Hàng
                else
                    if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                    {
                        _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                        //txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                        if (_cTTKH.getTTKHbyID(_donkh.DanhBo) != null)
                        {
                            _ttkhachhang = _cTTKH.getTTKHbyID(_donkh.DanhBo);
                            LoadTTKH(_ttkhachhang);
                        }
                        else
                        {
                            Clear();
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                    LoadTTKH(_ttkhachhang);
                }
                else
                {
                    _ttkhachhang = null;
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
