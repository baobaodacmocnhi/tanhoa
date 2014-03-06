using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.BaoCao;
using System.Globalization;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmCTDB : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        DonKH _donkh = null;
        TTKhachHang _ttkhachhang = null;
        CTTKH _cTTKH = new CTTKH();
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();
        CKTXM _cKTXM = new CKTXM();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CTCTDB _ctctdb = null;
        bool _direct = false;///Mở form trực tiếp không qua Danh Sách Đơn
                             
        public frmCTDB()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load Form trực tiếp không qua Danh Sách Đơn
        /// </summary>
        /// <param name="direct"></param>
        public frmCTDB(bool direct)
        {
            InitializeComponent();
            _direct = direct;
        }

        public frmCTDB(Dictionary<string, string> source)
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
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            ///
            cmbLyDo.SelectedIndex = -1;
            txtSoTien.Text = "";
            txtGhiChuXuLy.Text = "";
            ///
            dateTCTBXuLy.Value = DateTime.Now;
            txtKetQuaTCTBXuLy.Text = "";
            ///
            dateCapTrenXuLy.Value = DateTime.Now;
            txtKetQuaCapTrenXuLy.Text = "";
            txtThoiGianLapCatHuy.Text = "";
            _ttkhachhang = null;
        }

        private void frmCTDB_Load(object sender, EventArgs e)
        {
            if (_direct)
            {
                this.ControlBox = false;
                this.WindowState = FormWindowState.Maximized;
                this.BringToFront();
                txtMaDon.ReadOnly = false;
                txtMaThongBao.ReadOnly = false;
            }
            else
            {
                this.Location = new Point(70, 70);
                if (_source["Action"] == "Thêm")
                {
                    groupBoxNguyenNhanXuLy.Enabled = true;
                    if (_cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"])) != null)
                    {
                        _donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"]));
                        txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                    }
                    if (_cTTKH.getTTKHbyID(_source["DanhBo"]) != null)
                    {
                        _ttkhachhang = _cTTKH.getTTKHbyID(_source["DanhBo"]);
                        txtDanhBo.Text = _ttkhachhang.DanhBo;
                        txtHopDong.Text = _ttkhachhang.GiaoUoc;
                        txtHoTen.Text = _ttkhachhang.HoTen;
                        txtDiaChi.Text = _ttkhachhang.DC1 + " " + _ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(_ttkhachhang.Quan, _ttkhachhang.Phuong);
                    }
                }
                else
                    if (_source["Action"] == "Sửa")
                    {
                        groupBoxKetQuaXuLy.Enabled = true;
                        groupBoxCapTrenXuLy.Enabled = true;
                        if (_cCHDB.getCTCTDBbyID(decimal.Parse(_source["MaCTCTDB"])) != null)
                        {
                            _ctctdb = _cCHDB.getCTCTDBbyID(decimal.Parse(_source["MaCTCTDB"]));
                            ///Thông Tin
                            txtMaDon.Text = _ctctdb.CHDB.MaDon.ToString().Insert(_ctctdb.CHDB.MaDon.ToString().Length - 2, "-");
                            txtMaThongBao.Text = _ctctdb.MaCTCTDB.ToString().Insert(_ctctdb.MaCTCTDB.ToString().Length - 2, "-");
                            txtDanhBo.Text = _ctctdb.DanhBo;
                            txtHopDong.Text = _ctctdb.HopDong;
                            txtHoTen.Text = _ctctdb.HoTen;
                            txtDiaChi.Text = _ctctdb.DiaChi;
                            ///Nguyên Nhân Xử Lý
                            cmbLyDo.SelectedText = _ctctdb.LyDo;
                            txtGhiChuXuLy.Text = _ctctdb.GhiChuLyDo;
                            txtSoTien.Text = _ctctdb.SoTien.ToString();
                            ///Kết Quả Xử Lý
                            if (_ctctdb.TCTBXuLy)
                            {
                                dateTCTBXuLy.Value = _ctctdb.NgayTCTBXuLy.Value;
                                txtKetQuaTCTBXuLy.Text = _ctctdb.KetQuaTCTBXuLy;
                            }
                            ///Cấp Trên Xử Lý
                            if (_ctctdb.CapTrenXuLy)
                            {
                                dateCapTrenXuLy.Value = _ctctdb.NgayCapTrenXuLy.Value;
                                txtKetQuaCapTrenXuLy.Text = _ctctdb.KetQuaCapTrenXuLy;
                                txtThoiGianLapCatHuy.Text = _ctctdb.ThoiGianLapCatHuy.ToString();
                            }
                        }
                    }
            }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtThoiGianLapCatHuy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cmbLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLyDo.SelectedItem.ToString().ToUpper().Contains("TIỀN"))
                txtSoTien.ReadOnly = false;
            else
                txtSoTien.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_donkh != null && _ttkhachhang != null && cmbLyDo.SelectedIndex != -1)
            {
                if (!_cCHDB.CheckCHDBbyMaDon(_donkh.MaDon))
                {
                    CHDB chdb = new CHDB();
                    chdb.MaDon = _donkh.MaDon;
                    if (_direct)
                    {
                        ///Sợ phía dưới bị lỗi nên phải thêm như thế
                        if (!_source.ContainsKey("NoiChuyenDen"))
                        _source.Add("NoiChuyenDen", "");
                    }
                    else
                    {
                        chdb.MaNoiChuyenDen = decimal.Parse(_source["MaNoiChuyenDen"]);
                        chdb.NoiChuyenDen = _source["NoiChuyenDen"];
                        chdb.LyDoChuyenDen = _source["LyDoChuyenDen"];
                    }
                    if (_cCHDB.ThemCHDB(chdb))
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
                        //_source.Add("MaCHDB", _cCHDB.getMaxMaCHDB().ToString());
                        if (string.IsNullOrEmpty(_donkh.TienTrinh))
                            _donkh.TienTrinh = "CTCHDB";
                        else
                            _donkh.TienTrinh += ",CTCHDB";
                        _donkh.Nhan = true;
                        _cDonKH.SuaDonKH(_donkh, true);
                    }
                }
                if (_cCHDB.CheckCTCHDBbyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim()))
                {
                    MessageBox.Show("Danh Bộ này đã được Lập Cắt Tạm Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CTCTDB ctctdb = new CTCTDB();
                ctctdb.MaCHDB = _cCHDB.getCHDBbyMaDon(_donkh.MaDon).MaCHDB;
                ctctdb.DanhBo = txtDanhBo.Text.Trim();
                ctctdb.HopDong = txtHopDong.Text.Trim();
                ctctdb.HoTen = txtHoTen.Text.Trim();
                ctctdb.DiaChi = txtDiaChi.Text.Trim();
                ctctdb.Dot = _ttkhachhang.Dot;
                ctctdb.Ky = _ttkhachhang.Ky;
                ctctdb.Nam = _ttkhachhang.Nam;
                ctctdb.LyDo = cmbLyDo.SelectedItem.ToString();
                ctctdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                if (txtSoTien.Text.Trim() != "")
                    ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim());

                ///Ký Tên
                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                    ctctdb.ChucVu = "GIÁM ĐỐC";
                else
                    ctctdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                ctctdb.NguoiKy = bangiamdoc.HoTen.ToUpper();

                if (_cCHDB.ThemCTCTDB(ctctdb))
                {
                    MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                    dr["SoPhieu"] = _cCHDB.getMaxMaCTCTDB().ToString().Insert(_cCHDB.getMaxMaCTCTDB().ToString().Length - 2, "-");
                    dr["HoTen"] = ctctdb.HoTen;
                    dr["DiaChi"] = ctctdb.DiaChi;
                    dr["DanhBo"] = ctctdb.DanhBo;
                    dr["HopDong"] = ctctdb.HopDong;
                    dr["LyDo"] = ctctdb.LyDo + ". ";
                    if (ctctdb.GhiChuLyDo != "")
                        dr["LyDo"] += ctctdb.GhiChuLyDo + ". ";
                    if (ctctdb.SoTien.ToString() != "")
                        dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctctdb.SoTien);
                    dr["ChucVu"] = ctctdb.ChucVu;
                    dr["NguoiKy"] = ctctdb.NguoiKy;

                    dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                    rptThongBaoCTDB rpt = new rptThongBaoCTDB();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();

                    Clear();
                    _ttkhachhang = null;

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

        private void btnCapNhatTCTBXuLy_Click(object sender, EventArgs e)
        {
            if (_ctctdb != null)
            {
                _ctctdb.TCTBXuLy = true;
                _ctctdb.NgayTCTBXuLy = dateTCTBXuLy.Value;
                _ctctdb.KetQuaTCTBXuLy = txtKetQuaTCTBXuLy.Text.Trim();
                if (_cCHDB.SuaCTCTDB(_ctctdb))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCapNhatCapTrenXuLy_Click(object sender, EventArgs e)
        {
            if (_ctctdb != null)
            {
                _ctctdb.CapTrenXuLy = true;
                _ctctdb.NgayCapTrenXuLy = dateCapTrenXuLy.Value;
                _ctctdb.KetQuaCapTrenXuLy = txtKetQuaCapTrenXuLy.Text.Trim();
                _ctctdb.ThoiGianLapCatHuy = int.Parse(txtThoiGianLapCatHuy.Text.Trim());
                if (_cCHDB.SuaCTCTDB(_ctctdb))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                {
                    _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                    //txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                    if (_cTTKH.getTTKHbyID(_donkh.DanhBo) != null)
                    {
                        _ttkhachhang = _cTTKH.getTTKHbyID(_donkh.DanhBo);
                        LoadTTKH(_ttkhachhang);
                        groupBoxNguyenNhanXuLy.Enabled = true;
                        groupBoxKetQuaXuLy.Enabled = false;
                        groupBoxCapTrenXuLy.Enabled = false;
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

        private void txtMaThongBao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cCHDB.getCTCHDBbyID(decimal.Parse(txtMaThongBao.Text.Trim().Replace("-", ""))) != null)
                {
                    _ctctdb = _cCHDB.getCTCTDBbyID(decimal.Parse(txtMaThongBao.Text.Trim().Replace("-", "")));
                    txtMaDon.Text = _ctctdb.CHDB.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                    txtMaThongBao.Text = _ctctdb.MaCTCTDB.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                    ///
                    LoadTTKH(_cTTKH.getTTKHbyID(_ctctdb.DanhBo));
                    ///Nguyên Nhân Xử Lý
                    cmbLyDo.SelectedText = _ctctdb.LyDo;
                    txtGhiChuXuLy.Text = _ctctdb.GhiChuLyDo;
                    txtSoTien.Text = _ctctdb.SoTien.ToString();
                    ///Kết Quả Xử Lý
                    if (_ctctdb.TCTBXuLy)
                    {
                        dateTCTBXuLy.Value = _ctctdb.NgayTCTBXuLy.Value;
                        txtKetQuaTCTBXuLy.Text = _ctctdb.KetQuaTCTBXuLy;
                    }
                    ///Cấp Trên Xử Lý
                    if (_ctctdb.CapTrenXuLy)
                    {
                        dateCapTrenXuLy.Value = _ctctdb.NgayCapTrenXuLy.Value;
                        txtKetQuaCapTrenXuLy.Text = _ctctdb.KetQuaCapTrenXuLy;
                        txtThoiGianLapCatHuy.Text = _ctctdb.ThoiGianLapCatHuy.ToString();
                    }
                    groupBoxNguyenNhanXuLy.Enabled = false;
                    groupBoxKetQuaXuLy.Enabled = true;
                    groupBoxCapTrenXuLy.Enabled = true;
                }
                else
                {
                    Clear();
                    _ctctdb = null;
                    MessageBox.Show("Mã Thông Báo này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
