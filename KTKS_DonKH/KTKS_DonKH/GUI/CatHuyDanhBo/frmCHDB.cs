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
using KTKS_DonKH.DAL.ToXuLy;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmCHDB : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        TTKhachHang _ttkhachhang = null;
        CTTKH _cTTKH = new CTTKH();
        CCHDB _cCHDB = new CCHDB();
        CTCHDB _ctchdb = null;
        CTCTDB _ctctdb = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CKTXM _cKTXM = new CKTXM();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CVeViecCHDB _cVeViecCHDB = new CVeViecCHDB();
        bool _direct = false;///Mở form trực tiếp không qua Danh Sách Đơn
                             
        public frmCHDB()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load Form trực tiếp không qua Danh Sách Đơn
        /// </summary>
        /// <param name="direct"></param>
        public frmCHDB(bool direct)
        {
            InitializeComponent();
            _direct = direct;
        }

        public frmCHDB(Dictionary<string, string> source)
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
            dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(ttkhachhang.DanhBo);
        }

        public void Clear()
        {
            //txtMaThongBaoCH.Text = "";
            //txtMaThongBaoCT.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            ///
            //groupBoxNguyenNhanXuLy.Enabled = false;
            cmbLyDo.SelectedIndex = -1;
            txtSoTien.Text = "";
            txtGhiChuXuLy.Text = "";
            cmbNoiDung.SelectedIndex = -1;
            dateXuLy.Value = DateTime.Now;
            chkNgayXuLy.Checked = false;
            ///
            chkKetQuaTCTBXuLy.Checked = false;
            dateLichSuXuLy.Value = DateTime.Now;
            txtNoiDung.Text = "";
            chkTroNgai.Checked = false;
            chkCatTam.Checked = false;
            txtGhiChu.Text = "";
            txtNoiNhanXuLy.Text = "";
            txtNoiNhan.Text = "";
            ///
            chkKetQuaCapTrenXuLy.Checked = false;
            dateCapTrenXuLy.Value = DateTime.Now;
            txtKetQuaCapTrenXuLy.Text = "";
            txtThoiGianLapPhieu.Text = "";
            ///
            txtHieuLucKy.Text = "";
            _ttkhachhang = null;
            _ctchdb = null;
            _ctctdb = null;
            btnSua.Enabled = false;
            txtHieuLucKy.ReadOnly = true;
            btnInPhieu.Enabled = true;
        }

        private void frmCHDB_Load(object sender, EventArgs e)
        {
            if (_direct)
            {
                this.ControlBox = false;
                this.WindowState = FormWindowState.Maximized;
                this.BringToFront();
                txtMaDon.ReadOnly = false;
                txtMaThongBaoCH.ReadOnly = false;
                txtMaThongBaoCT.ReadOnly = false;

                dgvLichSuXuLy.AutoGenerateColumns = false;
                dgvLichSuCHDB.AutoGenerateColumns = false;

                cmbLyDo.DataSource = _cVeViecCHDB.LoadDS(true);
                cmbLyDo.DisplayMember = "TenVV";
                cmbLyDo.ValueMember = "TenVV";

                DataTable dt1 = _cCHDB.GetDSNoiDungLichSuXyLy();
                AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
                foreach (DataRow item in dt1.Rows)
                {
                    auto1.Add(item["NoiDung"].ToString());
                }
                txtNoiDung.AutoCompleteCustomSource = auto1;

                DataTable dt2 = _cCHDB.GetDSNoiNhanXuLyLichSuXyLy();
                AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();
                foreach (DataRow item in dt2.Rows)
                {
                    auto2.Add(item["NoiNhan"].ToString());
                }
                txtNoiNhanXuLy.AutoCompleteCustomSource = auto2;
            }
            else
            {
                this.Location = new Point(70, 70);
                ///Tạo Cắt Hủy
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
                    ///Sửa Cắt Hủy
                    if (_source["Action"] == "Sửa")
                    {
                        groupBoxKetQuaTCTBXuLy.Enabled = true;
                        groupBoxKetQuaCapTrenXuLy.Enabled = true;
                        txtHieuLucKy.ReadOnly = false;
                        btnInPhieu.Enabled = true;
                        if (_cCHDB.getCTCHDBbyID(decimal.Parse(_source["MaCTCHDB"])) != null)
                        {
                            _ctchdb = _cCHDB.getCTCHDBbyID(decimal.Parse(_source["MaCTCHDB"]));
                            ///Thông Tin
                            txtMaDon.Text = _ctchdb.CHDB.MaDon.ToString().Insert(_ctchdb.CHDB.MaDon.ToString().Length - 2, "-");
                            txtMaThongBaoCH.Text = _ctchdb.MaCTCHDB.ToString().Insert(_ctchdb.MaCTCHDB.ToString().Length - 2, "-");
                            txtDanhBo.Text = _ctchdb.DanhBo;
                            txtHopDong.Text = _ctchdb.HopDong;
                            txtHoTen.Text = _ctchdb.HoTen;
                            txtDiaChi.Text = _ctchdb.DiaChi;
                            ///Nguyên Nhân Xử Lý
                            cmbLyDo.SelectedValue = _ctchdb.LyDo;
                            txtGhiChuXuLy.Text = _ctchdb.GhiChuLyDo;
                            txtSoTien.Text = _ctchdb.SoTien.ToString();
                            ///Kết Quả Xử Lý
                            if (_ctchdb.TCTBXuLy)
                            {
                                dateLichSuXuLy.Value = _ctchdb.NgayTCTBXuLy.Value;
                                txtNoiDung.Text = _ctchdb.KetQuaTCTBXuLy;
                            }
                            ///Cấp Trên Xử Lý
                            if (_ctchdb.CapTrenXuLy)
                            {
                                dateCapTrenXuLy.Value = _ctchdb.NgayCapTrenXuLy.Value;
                                txtKetQuaCapTrenXuLy.Text = _ctchdb.KetQuaCapTrenXuLy;
                                txtThoiGianLapPhieu.Text = _ctchdb.ThoiGianLapPhieu.ToString();
                            }
                        }
                    }
                    else
                        ///Từ Cắt Tạm lập Cắt Hủy
                        if (_source["Action"] == "CTDBThêm")
                        {
                            groupBoxNguyenNhanXuLy.Enabled = true;
                            ///Kiểm tra record bên bảng CTCTDB để lấy qua bên bảng CTCHDB
                            if (_cCHDB.getCTCTDBbyID(decimal.Parse(_source["MaCTCTDB"])) != null)
                            {
                                _ctctdb = _cCHDB.getCTCTDBbyID(decimal.Parse(_source["MaCTCTDB"]));
                                ///Thông Tin
                                if (_cDonKH.getDonKHbyID(_ctctdb.CHDB.MaDon.Value) != null)
                                {
                                    _donkh = _cDonKH.getDonKHbyID(_ctctdb.CHDB.MaDon.Value);
                                    txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                                }
                                txtMaThongBaoCT.Text = _ctctdb.MaCTCTDB.ToString().Insert(_ctctdb.CHDB.MaDon.ToString().Length - 2, "-");
                                txtDanhBo.Text = _ctctdb.DanhBo;
                                txtHopDong.Text = _ctctdb.HopDong;
                                txtHoTen.Text = _ctctdb.HoTen;
                                txtDiaChi.Text = _ctctdb.DiaChi;
                                ///Nguyên Nhân Xử Lý
                                cmbLyDo.SelectedValue = _ctctdb.LyDo;
                                txtGhiChuXuLy.Text = _ctctdb.GhiChuLyDo;
                                txtSoTien.Text = _ctctdb.SoTien.ToString();
                            }
                        }
            }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtThoiGianLapPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cmbLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLyDo.SelectedIndex != -1)
            {
                VeViecCHDB vv = (VeViecCHDB)cmbLyDo.SelectedItem;
                //txtNoiDung.Text = vv.NoiDung;
                txtNoiNhan.Text = vv.NoiNhan + "\r\n(" + txtMaDon.Text.Trim() + ")";

                if (cmbLyDo.SelectedItem.ToString() == "Nợ Tiền Gian Lận Nước" || cmbLyDo.SelectedValue.ToString() == "Không Thanh Toán Tiền Bồi Thường ĐHN")
                    txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", 1283641);
            }
            else
            {
                //txtNoiDung.Text = "";
                txtNoiNhan.Text = "";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (_direct)
                {
                    ///Nếu đơn thuộc Tổ Xử Lý
                    if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                    {
                        if ((_dontxl != null || _ctchdb != null) && cmbLyDo.SelectedIndex != -1)
                        {
                            if (!_cCHDB.CheckCHDBbyMaDon_TXL(_dontxl.MaDon))
                            {
                                CHDB chdb = new CHDB();
                                chdb.ToXuLy = true;
                                chdb.MaDonTXL = _dontxl.MaDon;
                                if (_cCHDB.ThemCHDB(chdb))
                                {
                                    if (string.IsNullOrEmpty(_dontxl.TienTrinh))
                                        _dontxl.TienTrinh = "CHDB";
                                    else
                                        _dontxl.TienTrinh += ",CHDB";
                                    _dontxl.Nhan = true;
                                    _cDonTXL.SuaDonTXL(_dontxl, true);
                                }
                            }
                            if (_cCHDB.CheckCTCHDBbyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim()))
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            CTCHDB ctchdb = new CTCHDB();
                            ctchdb.MaCHDB = _cCHDB.getCHDBbyMaDon_TXL(_dontxl.MaDon).MaCHDB;
                            if (txtMaThongBaoCT.Text.Trim().Replace("-", "") != "")
                                ctchdb.MaCTCTDB = decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", ""));
                            ctchdb.DanhBo = txtDanhBo.Text.Trim();
                            ctchdb.HopDong = txtHopDong.Text.Trim();
                            ctchdb.HoTen = txtHoTen.Text.Trim();
                            ctchdb.DiaChi = txtDiaChi.Text.Trim();
                            if (_ttkhachhang != null)
                            {
                                ctchdb.Dot = _ttkhachhang.Dot;
                                ctchdb.Ky = _ttkhachhang.Ky;
                                ctchdb.Nam = _ttkhachhang.Nam;
                            }
                            ctchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                            ctchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                            ctchdb.NoiDung = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiDung;
                            if (txtSoTien.Text.Trim() != "")
                                ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".",""));

                            ctchdb.NoiNhan = txtNoiNhan.Text.Trim();

                            ///Đã lập Cắt Tạm
                            if (_ctctdb!=null)
                            {
                                ctchdb.DaLapCatTam = true;
                                ctchdb.MaCTCTDB = decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", ""));

                                if (_ctctdb.NgayXuLy != null && _ctctdb.NoiDungXuLy != "Lập thông báo cắt hủy")
                                {
                                    LichSuXuLyCTCHDB lsxl = new LichSuXuLyCTCHDB();
                                    lsxl.NgayXuLy = _ctctdb.NgayXuLy;
                                    lsxl.NoiDung = _ctctdb.NoiDungXuLy;
                                    lsxl.MaCTCTDB = _ctctdb.MaCTCTDB;
                                    if (_cCHDB.ThemLichSuXuLy(lsxl))
                                    {
                                    }
                                }
                                _ctctdb.NgayXuLy = DateTime.Now;
                                _ctctdb.NoiDungXuLy = "Lập thông báo cắt hủy";
                                _ctctdb.CreateDate_NgayXuLy = DateTime.Now;
                                _cCHDB.SuaCTCTDB(_ctctdb);
                            }
                            ///Ký Tên
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctchdb.ChucVu = "GIÁM ĐỐC";
                            else
                                ctchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            ctchdb.ThongBaoDuocKy = true;

                            if (_cCHDB.ThemCTCHDB(ctchdb))
                            {
                                MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        if ((_donkh != null || _ctchdb != null) && cmbLyDo.SelectedIndex != -1)
                        {
                            if (!_cCHDB.CheckCHDBbyMaDon(_donkh.MaDon))
                            {
                                CHDB chdb = new CHDB();
                                chdb.MaDon = _donkh.MaDon;
                                if (_cCHDB.ThemCHDB(chdb))
                                {
                                    if (string.IsNullOrEmpty(_donkh.TienTrinh))
                                        _donkh.TienTrinh = "CHDB";
                                    else
                                        _donkh.TienTrinh += ",CHDB";
                                    _donkh.Nhan = true;
                                    _cDonKH.SuaDonKH(_donkh, true);
                                }
                            }
                            if (_cCHDB.CheckCTCHDBbyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim()))
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Cắt Hủy Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            CTCHDB ctchdb = new CTCHDB();
                            ctchdb.MaCHDB = _cCHDB.getCHDBbyMaDon(_donkh.MaDon).MaCHDB;
                            if (txtMaThongBaoCT.Text.Trim().Replace("-", "") != "")
                                ctchdb.MaCTCTDB = decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", ""));
                            ctchdb.DanhBo = txtDanhBo.Text.Trim();
                            ctchdb.HopDong = txtHopDong.Text.Trim();
                            ctchdb.HoTen = txtHoTen.Text.Trim();
                            ctchdb.DiaChi = txtDiaChi.Text.Trim();
                            if (_ttkhachhang != null)
                            {
                                ctchdb.Dot = _ttkhachhang.Dot;
                                ctchdb.Ky = _ttkhachhang.Ky;
                                ctchdb.Nam = _ttkhachhang.Nam;
                            }
                            ctchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                            ctchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                            ctchdb.NoiDung = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiDung;
                            if (txtSoTien.Text.Trim() != "")
                                ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));

                            ctchdb.NoiNhan = txtNoiNhan.Text.Trim();

                            ///Đã lập Cắt Tạm
                            if (_ctctdb!=null)
                            {
                                ctchdb.DaLapCatTam = true;
                                ctchdb.MaCTCTDB = decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", ""));

                                if (_ctctdb.NgayXuLy != null && _ctctdb.NoiDungXuLy != "Lập thông báo cắt hủy")
                                {
                                    LichSuXuLyCTCHDB lsxl = new LichSuXuLyCTCHDB();
                                    lsxl.NgayXuLy = _ctctdb.NgayXuLy;
                                    lsxl.NoiDung = _ctctdb.NoiDungXuLy;
                                    lsxl.MaCTCTDB = _ctctdb.MaCTCTDB;
                                    if (_cCHDB.ThemLichSuXuLy(lsxl))
                                    {
                                    }
                                }
                                _ctctdb.NgayXuLy = DateTime.Now;
                                _ctctdb.NoiDungXuLy = "Lập thông báo cắt hủy";
                                _ctctdb.CreateDate_NgayXuLy = DateTime.Now;
                                _cCHDB.SuaCTCTDB(_ctctdb);
                            }
                            ///Ký Tên
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctchdb.ChucVu = "GIÁM ĐỐC";
                            else
                                ctchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            ctchdb.ThongBaoDuocKy = true;

                            if (_cCHDB.ThemCTCHDB(ctchdb))
                            {
                                MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                //DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                                //dr["SoPhieu"] = _cCHDB.getMaxMaCTCHDB().ToString().Insert(_cCHDB.getMaxMaCTCHDB().ToString().Length - 2, "-");
                                //dr["HoTen"] = ctchdb.HoTen;
                                //dr["DiaChi"] = ctchdb.DiaChi;
                                //dr["DanhBo"] = ctchdb.DanhBo;
                                //dr["HopDong"] = ctchdb.HopDong;
                                //dr["LyDo"] = ctchdb.LyDo + ". ";
                                //if (ctchdb.GhiChuLyDo != "")
                                //    dr["LyDo"] += ctchdb.GhiChuLyDo + ". ";
                                //if (ctchdb.SoTien.ToString() != "")
                                //    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctchdb.SoTien);
                                //dr["ChucVu"] = ctchdb.ChucVu;
                                //dr["NguoiKy"] = ctchdb.NguoiKy;

                                //dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                                //rptThongBaoCHDB rpt = new rptThongBaoCHDB();
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
                ///Xử lý theo cách Chuột Phải Chọn
                else
                {
                    if (_source["Action"] == "Thêm")
                    {
                        if (cmbLyDo.SelectedIndex != -1)
                        {
                            CHDB chdb = new CHDB();
                            chdb.MaDon = decimal.Parse(_source["MaDon"]);
                            chdb.MaNoiChuyenDen = decimal.Parse(_source["MaNoiChuyenDen"]);
                            chdb.NoiChuyenDen = _source["NoiChuyenDen"];
                            chdb.LyDoChuyenDen = _source["LyDoChuyenDen"];
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
                                _source.Add("MaCHDB", _cCHDB.getMaxMaCHDB().ToString());
                                if (string.IsNullOrEmpty(_donkh.TienTrinh))
                                    _donkh.TienTrinh = "CHDB";
                                else
                                    _donkh.TienTrinh += ",CHDB";
                                _donkh.Nhan = true;
                                _cDonKH.SuaDonKH(_donkh, true);
                            }
                            CTCHDB ctchdb = new CTCHDB();
                            ctchdb.MaCHDB = decimal.Parse(_source["MaCHDB"]);
                            ctchdb.DanhBo = txtDanhBo.Text.Trim();
                            ctchdb.HopDong = txtHopDong.Text.Trim();
                            ctchdb.HoTen = txtHoTen.Text.Trim();
                            ctchdb.DiaChi = txtDiaChi.Text.Trim();
                            ctchdb.Dot = _ttkhachhang.Dot;
                            ctchdb.Ky = _ttkhachhang.Ky;
                            ctchdb.Nam = _ttkhachhang.Nam;
                            ctchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                            ctchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                            if (txtSoTien.Text.Trim() != "")
                                ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));

                            ///Ký Tên
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctchdb.ChucVu = "GIÁM ĐỐC";
                            else
                                ctchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();

                            if (_cCHDB.ThemCTCHDB(ctchdb))
                            {
                                MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                                dr["SoPhieu"] = _cCHDB.getMaxMaCTCTDB().ToString().Insert(_cCHDB.getMaxMaCTCTDB().ToString().Length - 2, "-");
                                dr["HoTen"] = ctchdb.HoTen;
                                dr["DiaChi"] = ctchdb.DiaChi;
                                dr["DanhBo"] = ctchdb.DanhBo;
                                dr["HopDong"] = ctchdb.HopDong;
                                dr["LyDo"] = ctchdb.LyDo + ". ";
                                if (ctchdb.GhiChuLyDo != "")
                                    dr["LyDo"] += ctchdb.GhiChuLyDo + ". ";
                                if (ctchdb.SoTien.ToString() != "")
                                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctchdb.SoTien);
                                dr["ChucVu"] = ctchdb.ChucVu;
                                dr["NguoiKy"] = ctchdb.NguoiKy;

                                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                                rptThongBaoCHDB rpt = new rptThongBaoCHDB();
                                rpt.SetDataSource(dsBaoCao);
                                frmBaoCao frm = new frmBaoCao(rpt);
                                frm.ShowDialog();

                                Clear();

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                    }
                    else
                        ///Từ Cắt Tạm lập Cắt Hủy
                        if (_source["Action"] == "CTDBThêm" && _ctctdb != null)
                            if (!_cCHDB.CheckCTCHDBbyCTCTDB(_ctctdb.MaCTCTDB))
                            {
                                CTCHDB ctchdb = new CTCHDB();
                                ctchdb.MaCHDB = _ctctdb.MaCHDB;
                                ctchdb.DanhBo = txtDanhBo.Text.Trim();
                                ctchdb.HopDong = txtHopDong.Text.Trim();
                                ctchdb.HoTen = txtHoTen.Text.Trim();
                                ctchdb.DiaChi = txtDiaChi.Text.Trim();
                                ///
                                _ttkhachhang = _cTTKH.getTTKHbyID(_ctctdb.DanhBo);
                                ctchdb.Dot = _ttkhachhang.Dot;
                                ctchdb.Ky = _ttkhachhang.Ky;
                                ctchdb.Nam = _ttkhachhang.Nam;
                                ///
                                ctchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                                ctchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                                if (txtSoTien.Text.Trim() != "")
                                    ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                                ///Đã lập Cắt Tạm
                                ctchdb.DaLapCatTam = true;
                                ctchdb.MaCTCTDB = _ctctdb.MaCTCTDB;
                                ///Ký Tên
                                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    ctchdb.ChucVu = "GIÁM ĐỐC";
                                else
                                    ctchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();

                                if (_cCHDB.ThemCTCHDB(ctchdb))
                                {
                                    MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                    //DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                                    //dr["SoPhieu"] = _cCHDB.getMaxMaCTCHDB().ToString().Insert(_cCHDB.getMaxMaCTCHDB().ToString().Length - 2, "-");
                                    //dr["HoTen"] = ctchdb.HoTen;
                                    //dr["DiaChi"] = ctchdb.DiaChi;
                                    //dr["DanhBo"] = ctchdb.DanhBo;
                                    //dr["HopDong"] = ctchdb.HopDong;
                                    //dr["LyDo"] = ctchdb.LyDo + ". ";
                                    //if (ctchdb.GhiChuLyDo != "")
                                    //    dr["LyDo"] += ctchdb.GhiChuLyDo + ". ";
                                    //if (ctchdb.SoTien.ToString() != "")
                                    //    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctchdb.SoTien);
                                    //dr["ChucVu"] = ctchdb.ChucVu;
                                    //dr["NguoiKy"] = ctchdb.NguoiKy;

                                    //dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                                    //rptThongBaoCHDB rpt = new rptThongBaoCHDB();
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
                                MessageBox.Show("Cắt Hủy đã được lập với Cắt Tạm này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCapNhatTCTBXuLy_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctchdb != null)
                {
                    //_ctchdb.TCTBXuLy = true;
                    //_ctchdb.NgayTCTBXuLy = dateTCTBXuLy.Value;
                    //_ctchdb.KetQuaTCTBXuLy = txtKetQuaTCTBXuLy.Text.Trim();
                    LichSuXuLyCTCHDB lsxl = new LichSuXuLyCTCHDB();
                    lsxl.NgayXuLy = dateLichSuXuLy.Value;
                    lsxl.NoiDung = txtNoiDung.Text.Trim();
                    lsxl.NoiNhan = txtNoiNhanXuLy.Text.Trim();
                    lsxl.GhiChu = txtGhiChu.Text.Trim();
                    lsxl.MaCTCHDB = _ctchdb.MaCTCHDB;
                    if (_cCHDB.ThemLichSuXuLy(lsxl))
                    {
                        dgvLichSuXuLy.DataSource = _cCHDB.LoadDSLichSuXuLyByMaCTCHDB(_ctchdb.MaCTCHDB);
                        MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        if (!_direct)
                        {
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

        private void btnCapNhatCapTrenXuLy_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctchdb != null)
                {
                    _ctchdb.CapTrenXuLy = true;
                    _ctchdb.NgayCapTrenXuLy = dateCapTrenXuLy.Value;
                    _ctchdb.KetQuaCapTrenXuLy = txtKetQuaCapTrenXuLy.Text.Trim();
                    _ctchdb.ThoiGianLapPhieu = int.Parse(txtThoiGianLapPhieu.Text.Trim());
                    if (_cCHDB.SuaCTCHDB(_ctchdb))
                    {
                        MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        if (!_direct)
                        {
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

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (_ctchdb != null)
            {
                ///Nếu Chưa Lập Phiếu
                if (!_cCHDB.CheckYeuCauCHDBbyMaCTCHDB(_ctchdb.MaCTCHDB))
                {
                    if (txtHieuLucKy.Text.Trim() != "")
                    {
                        YeuCauCHDB ycchdb = new YeuCauCHDB();
                        if (_ctchdb.CHDB.ToXuLy)
                        {
                            ycchdb.ToXuLy = true;
                            ycchdb.MaDonTXL = _ctchdb.CHDB.MaDonTXL;
                        }
                        else
                            ycchdb.MaDon = _ctchdb.CHDB.MaDon;
                        ycchdb.TBCHDB = true;
                        ycchdb.MaCTCHDB = _ctchdb.MaCTCHDB;
                        ycchdb.DanhBo = _ctchdb.DanhBo;
                        ycchdb.HopDong = _ctchdb.HopDong;
                        ycchdb.HoTen = _ctchdb.HoTen;
                        ycchdb.DiaChi = _ctchdb.DiaChi;
                        ycchdb.LyDo = _ctchdb.LyDo;
                        ycchdb.GhiChuLyDo = _ctchdb.GhiChuLyDo;
                        ycchdb.SoTien = _ctchdb.SoTien;
                        ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                        TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(_ctchdb.DanhBo);
                        if (ttkhachhang != null)
                        {
                            ycchdb.Dot = ttkhachhang.Dot;
                            ycchdb.Ky = ttkhachhang.Ky;
                            ycchdb.Nam = ttkhachhang.Nam;
                        }
                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ycchdb.ChucVu = "GIÁM ĐỐC";
                        else
                            ycchdb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ycchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        ycchdb.PhieuDuocKy = true;

                        if (_cCHDB.ThemYeuCauCHDB(ycchdb))
                        {
                            _ctchdb.DaLapPhieu = true;
                            _ctchdb.SoPhieu = ycchdb.MaYCCHDB;
                            _ctchdb.NgayLapPhieu = ycchdb.CreateDate;
                            _ctchdb.HieuLucKy = ycchdb.HieuLucKy;
                            _ctchdb.PhieuDuocKy = true;
                            _cCHDB.SuaCTCHDB(_ctchdb);

                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                            dr["SoPhieu"] = ycchdb.MaYCCHDB.ToString().Insert(ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                            dr["HieuLucKy"] = ycchdb.HieuLucKy;
                            dr["Dot"] = ycchdb.Dot;
                            dr["HoTen"] = ycchdb.HoTen;
                            dr["DiaChi"] = ycchdb.DiaChi;
                            dr["DanhBo"] = ycchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["HopDong"] = ycchdb.HopDong;

                            if (ycchdb.LyDo == "Vấn Đề Khác")
                                dr["LyDo"] = "";
                            else
                                dr["LyDo"] = ycchdb.LyDo + ". ";

                            if (ycchdb.GhiChuLyDo != "")
                                dr["LyDo"] += ycchdb.GhiChuLyDo + ". ";
                            if (ycchdb.SoTien.ToString() != "")
                                dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ycchdb.SoTien);

                            dr["ChucVu"] = ycchdb.ChucVu;
                            dr["NguoiKy"] = ycchdb.NguoiKy;

                            if (!string.IsNullOrEmpty(ycchdb.MaDonTXL.ToString()))
                                dr["MaDon"] = "TXL" + ycchdb.MaDonTXL.ToString().Insert(ycchdb.MaDonTXL.ToString().Length - 2, "-");
                            else
                                if (!string.IsNullOrEmpty(ycchdb.MaDon.ToString()))
                                    dr["MaDon"] = ycchdb.MaDon.ToString().Insert(ycchdb.MaDon.ToString().Length - 2, "-");

                            dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                            rptPhieuCHDBx2 rpt = new rptPhieuCHDBx2();
                            for (int j = 0; j < rpt.Subreports.Count; j++)
                            {
                                rpt.Subreports[j].SetDataSource(dsBaoCao);
                            }
                            frmBaoCao frm = new frmBaoCao(rpt);
                            frm.ShowDialog();

                            if (!_direct)
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }

                    }
                    else
                        MessageBox.Show("Chưa có Hiệu Lực Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ///Nếu Đã Lập Phiếu
                else
                    if (MessageBox.Show("Đã Lập Phiếu, Bạn có muốn Lấp Phiếu Mới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (txtHieuLucKy.Text.Trim() != "")
                        {
                            YeuCauCHDB ycchdb = new YeuCauCHDB();
                            if (_ctchdb.CHDB.ToXuLy)
                            {
                                ycchdb.ToXuLy = true;
                                ycchdb.MaDonTXL = _ctchdb.CHDB.MaDonTXL;
                            }
                            else
                                ycchdb.MaDon = _ctchdb.CHDB.MaDon;
                            ycchdb.TBCHDB = true;
                            ycchdb.MaCTCHDB = _ctchdb.MaCTCHDB;
                            ycchdb.DanhBo = _ctchdb.DanhBo;
                            ycchdb.HopDong = _ctchdb.HopDong;
                            ycchdb.HoTen = _ctchdb.HoTen;
                            ycchdb.DiaChi = _ctchdb.DiaChi;
                            ycchdb.LyDo = _ctchdb.LyDo;
                            ycchdb.GhiChuLyDo = _ctchdb.GhiChuLyDo;
                            ycchdb.SoTien = _ctchdb.SoTien;
                            ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                            TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(_ctchdb.DanhBo);
                            if (ttkhachhang != null)
                            {
                                ycchdb.Dot = ttkhachhang.Dot;
                                ycchdb.Ky = ttkhachhang.Ky;
                                ycchdb.Nam = ttkhachhang.Nam;
                            }
                            ///Ký Tên
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ycchdb.ChucVu = "GIÁM ĐỐC";
                            else
                                ycchdb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ycchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            ycchdb.PhieuDuocKy = true;

                            if (_cCHDB.ThemYeuCauCHDB(ycchdb))
                            {
                                _ctchdb.DaLapPhieu = true;
                                _ctchdb.SoPhieu = ycchdb.MaYCCHDB;
                                _ctchdb.HieuLucKy = ycchdb.HieuLucKy;
                                _ctchdb.NgayLapPhieu = ycchdb.CreateDate;
                                _ctchdb.PhieuDuocKy = true;
                                _cCHDB.SuaCTCHDB(_ctchdb);

                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                                dr["SoPhieu"] = ycchdb.MaYCCHDB.ToString().Insert(ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                                dr["HieuLucKy"] = ycchdb.HieuLucKy;
                                dr["Dot"] = ycchdb.Dot;
                                dr["HoTen"] = ycchdb.HoTen;
                                dr["DiaChi"] = ycchdb.DiaChi;
                                dr["DanhBo"] = ycchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ycchdb.HopDong;

                                if (ycchdb.LyDo == "Vấn Đề Khác")
                                    dr["LyDo"] = "";
                                else
                                    dr["LyDo"] = ycchdb.LyDo + ". ";

                                if (ycchdb.GhiChuLyDo != "")
                                    dr["LyDo"] += ycchdb.GhiChuLyDo + ". ";
                                if (ycchdb.SoTien.ToString() != "")
                                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ycchdb.SoTien);

                                dr["ChucVu"] = ycchdb.ChucVu;
                                dr["NguoiKy"] = ycchdb.NguoiKy;

                                if (!string.IsNullOrEmpty(ycchdb.MaDonTXL.ToString()))
                                    dr["MaDon"] = "TXL" + ycchdb.MaDonTXL.ToString().Insert(ycchdb.MaDonTXL.ToString().Length - 2, "-");
                                else
                                    if (!string.IsNullOrEmpty(ycchdb.MaDon.ToString()))
                                        dr["MaDon"] = ycchdb.MaDon.ToString().Insert(ycchdb.MaDon.ToString().Length - 2, "-");

                                dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                                rptPhieuCHDBx2 rpt = new rptPhieuCHDBx2();
                                for (int j = 0; j < rpt.Subreports.Count; j++)
                                {
                                    rpt.Subreports[j].SetDataSource(dsBaoCao);
                                }
                                frmBaoCao frm = new frmBaoCao(rpt);
                                frm.ShowDialog();

                                if (!_direct)
                                {
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                            }

                        }
                        else
                            MessageBox.Show("Chưa có Hiệu Lực Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        YeuCauCHDB ycchdb = _cCHDB.getYeuCauCHDBbyMaCTCHDB(_ctchdb.MaCTCHDB);
                        DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                        DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                        dr["SoPhieu"] = ycchdb.MaYCCHDB.ToString().Insert(ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                        dr["HieuLucKy"] = ycchdb.HieuLucKy;
                        dr["Dot"] = ycchdb.Dot;
                        dr["HoTen"] = ycchdb.HoTen;
                        dr["DiaChi"] = ycchdb.DiaChi;
                        dr["DanhBo"] = ycchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                        dr["HopDong"] = ycchdb.HopDong;

                        if (ycchdb.LyDo == "Vấn Đề Khác")
                            dr["LyDo"] = "";
                        else
                            dr["LyDo"] = ycchdb.LyDo + ". ";

                        if (ycchdb.GhiChuLyDo != "")
                            dr["LyDo"] += ycchdb.GhiChuLyDo + ". ";
                        if (ycchdb.SoTien.ToString() != "")
                            dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ycchdb.SoTien);

                        dr["ChucVu"] = ycchdb.ChucVu;
                        dr["NguoiKy"] = ycchdb.NguoiKy;

                        dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                        rptPhieuCHDBx2 rpt = new rptPhieuCHDBx2();
                        for (int j = 0; j < rpt.Subreports.Count; j++)
                        {
                            rpt.Subreports[j].SetDataSource(dsBaoCao);
                        }
                        frmBaoCao frm = new frmBaoCao(rpt);
                        frm.ShowDialog();

                        if (!_direct)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
            }
            else
                MessageBox.Show("Chưa có Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                Clear();
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL"+_dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        if (_cTTKH.getTTKHbyID(_dontxl.DanhBo) != null)
                        {
                            _ttkhachhang = _cTTKH.getTTKHbyID(_dontxl.DanhBo);
                            LoadTTKH(_ttkhachhang);
                            string ThongTin;
                            if (_cCHDB.CheckCHDBbyDanhBo(_ttkhachhang.DanhBo, out ThongTin))
                                MessageBox.Show("Danh Bộ này đã lập " + ThongTin, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Clear();
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //groupBoxNguyenNhanXuLy.Enabled = true;
                        //groupBoxKetQuaTCTBXuLy.Enabled = false;
                        //groupBoxKetQuaCapTrenXuLy.Enabled = false;
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
                    txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                    if (_cTTKH.getTTKHbyID(_donkh.DanhBo) != null)
                    {
                        _ttkhachhang = _cTTKH.getTTKHbyID(_donkh.DanhBo);
                        LoadTTKH(_ttkhachhang);
                        string ThongTin;
                        if (_cCHDB.CheckCHDBbyDanhBo(_ttkhachhang.DanhBo, out ThongTin))
                            MessageBox.Show("Danh Bộ này đã lập " + ThongTin, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Clear();
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //groupBoxNguyenNhanXuLy.Enabled = true;
                    //groupBoxKetQuaTCTBXuLy.Enabled = false;
                    //groupBoxKetQuaCapTrenXuLy.Enabled = false;
                }
                else
                {
                    _donkh = null;
                    Clear();
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMaThongBaoCH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cCHDB.getCTCHDBbyID(decimal.Parse(txtMaThongBaoCH.Text.Trim().Replace("-", ""))) != null)
                {
                    Clear();
                    _ctchdb = _cCHDB.getCTCHDBbyID(decimal.Parse(txtMaThongBaoCH.Text.Trim().Replace("-", "")));
                    if (!string.IsNullOrEmpty(_ctchdb.CHDB.MaDonTXL.ToString()))
                        txtMaDon.Text = "TXL"+_ctchdb.CHDB.MaDonTXL.ToString().Insert(_ctchdb.CHDB.MaDonTXL.ToString().Length - 2, "-");
                    else
                        if (!string.IsNullOrEmpty(_ctchdb.CHDB.MaDon.ToString()))
                            txtMaDon.Text = _ctchdb.CHDB.MaDon.ToString().Insert(_ctchdb.CHDB.MaDon.ToString().Length - 2, "-");

                    txtMaThongBaoCH.Text = _ctchdb.MaCTCHDB.ToString().Insert(_ctchdb.MaCTCHDB.ToString().Length - 2, "-");

                    if (!string.IsNullOrEmpty(_ctchdb.MaCTCTDB.ToString()))
                        txtMaThongBaoCT.Text = _ctchdb.MaCTCTDB.ToString().Insert(_ctchdb.MaCTCTDB.ToString().Length - 2, "-");
                    ///
                    //LoadTTKH(_cTTKH.getTTKHbyID(_ctchdb.DanhBo));
                    txtDanhBo.Text = _ctchdb.DanhBo;
                    txtHopDong.Text = _ctchdb.HopDong;
                    txtHoTen.Text = _ctchdb.HoTen;
                    txtDiaChi.Text = _ctchdb.DiaChi;
                    ///Nguyên Nhân Xử Lý
                    cmbLyDo.SelectedValue = _ctchdb.LyDo;
                    txtGhiChuXuLy.Text = _ctchdb.GhiChuLyDo;
                    txtSoTien.Text = _ctchdb.SoTien.ToString();

                    if (_ctchdb.NoiDungXuLy != null)
                    {
                        chkNgayXuLy.Checked = true;
                        dateXuLy.Value = _ctchdb.NgayXuLy.Value;
                        cmbNoiDung.SelectedItem = _ctchdb.NoiDungXuLy;
                    }
                    else
                    {
                        chkNgayXuLy.Checked = false;
                        dateXuLy.Value = DateTime.Now;
                        cmbNoiDung.SelectedIndex = -1;
                    }

                    txtNoiNhan.Text = _ctchdb.NoiNhan;

                    dgvLichSuXuLy.DataSource = _cCHDB.LoadDSLichSuXuLyByMaCTCHDB(_ctchdb.MaCTCHDB);
                    dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(_ctchdb.DanhBo);
                    ///Kết Quả Xử Lý
                    //if (_ctchdb.TCTBXuLy)
                    //{
                    //    chkKetQuaTCTBXuLy.Checked = true;
                    //    dateTCTBXuLy.Value = _ctchdb.NgayTCTBXuLy.Value;
                    //    if (_ctchdb.TroNgai)
                    //        chkTroNgai.Checked = true;
                    //    else
                    //        chkTroNgai.Checked = false;
                    //    if (_ctchdb.CatTam)
                    //        chkCatTam.Checked = true;
                    //    else
                    //        chkCatTam.Checked = false;
                    //    txtKetQuaTCTBXuLy.Text = _ctchdb.KetQuaTCTBXuLy;
                    //}
                    //else
                    //{
                    //    chkKetQuaTCTBXuLy.Checked = false;
                    //    dateTCTBXuLy.Value = DateTime.Now;
                    //    chkTroNgai.Checked = false;
                    //    chkCatTam.Checked = false;
                    //    txtKetQuaTCTBXuLy.Text = "";
                    //}
                    ///Cấp Trên Xử Lý
                    //if (_ctchdb.CapTrenXuLy)
                    //{
                    //    chkKetQuaCapTrenXuLy.Checked = true;
                    //    dateCapTrenXuLy.Value = _ctchdb.NgayCapTrenXuLy.Value;
                    //    txtKetQuaCapTrenXuLy.Text = _ctchdb.KetQuaCapTrenXuLy;
                    //    txtThoiGianLapPhieu.Text = _ctchdb.ThoiGianLapPhieu.ToString();
                    //}
                    //else
                    //{
                    //    chkKetQuaCapTrenXuLy.Checked = false;
                    //    dateCapTrenXuLy.Value = DateTime.Now;
                    //    txtKetQuaCapTrenXuLy.Text = "";
                    //    txtThoiGianLapPhieu.Text = "";
                    //}
                    ///Đã lấp Phiếu Yêu Cầu CHDB
                    if (_cCHDB.CheckYeuCauCHDBbyMaCTCHDB(_ctchdb.MaCTCHDB))
                    {
                        txtHieuLucKy.Text = _ctchdb.YeuCauCHDBs.LastOrDefault(itemYCCHDB => itemYCCHDB.MaCTCHDB == _ctchdb.MaCTCHDB).HieuLucKy;
                    }
                    else
                    {
                        txtHieuLucKy.Text = "";
                    }
                    groupBoxNguyenNhanXuLy.Enabled = true;
                    btnSua.Enabled = true;
                    txtHieuLucKy.ReadOnly = false;
                    btnInPhieu.Enabled = true;
                }
                else
                {
                    Clear();
                    _ctchdb = null;
                    MessageBox.Show("Mã Thông Báo này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMaThongBaoCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cCHDB.getCTCTDBbyID(decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", ""))) != null)
                {
                    Clear();
                    _ctctdb = _cCHDB.getCTCTDBbyID(decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", "")));

                    if (!string.IsNullOrEmpty(_ctctdb.CHDB.MaDonTXL.ToString()))
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(_ctctdb.CHDB.MaDonTXL.Value);
                        txtMaDon.Text = "TXL" + _ctctdb.CHDB.MaDonTXL.ToString().Insert(_ctctdb.CHDB.MaDonTXL.ToString().Length - 2, "-");
                    }
                    else
                        if (!string.IsNullOrEmpty(_ctctdb.CHDB.MaDon.ToString()))
                        {
                            _donkh = _cDonKH.getDonKHbyID(_ctctdb.CHDB.MaDon.Value);
                            txtMaDon.Text = _ctctdb.CHDB.MaDon.ToString().Insert(_ctctdb.CHDB.MaDon.ToString().Length - 2, "-");
                        }
                    
                    //txtMaThongBaoCH.Text = _ctchdb.MaCTCHDB.ToString().Insert(_ctchdb.MaCTCHDB.ToString().Length - 2, "-");

                    txtMaThongBaoCT.Text = _ctctdb.MaCTCTDB.ToString().Insert(_ctctdb.MaCTCTDB.ToString().Length - 2, "-");

                    txtDanhBo.Text = _ctctdb.DanhBo;
                    txtHopDong.Text = _ctctdb.HopDong;
                    txtHoTen.Text = _ctctdb.HoTen;
                    txtDiaChi.Text = _ctctdb.DiaChi;

                    ///Nguyên Nhân Xử Lý
                    cmbLyDo.SelectedValue = _ctctdb.LyDo;
                    txtGhiChuXuLy.Text = _ctctdb.GhiChuLyDo;
                    txtSoTien.Text = _ctctdb.SoTien.ToString();
                }
                else
                {
                    Clear();
                    MessageBox.Show("Mã Thông Báo này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctchdb != null)
                {
                    //if (_ctchdb.DanhBo != txtDanhBo.Text.Trim())
                    //{
                        _ctchdb.DanhBo = txtDanhBo.Text.Trim();
                        _ctchdb.HopDong = txtHopDong.Text.Trim();
                        _ctchdb.HoTen = txtHoTen.Text.Trim();
                        _ctchdb.DiaChi = txtDiaChi.Text.Trim();
                        if (_ttkhachhang != null)
                        {
                            _ctchdb.Dot = _ttkhachhang.Dot;
                            _ctchdb.Ky = _ttkhachhang.Ky;
                            _ctchdb.Nam = _ttkhachhang.Nam;
                        }
                    //}

                    if (txtMaThongBaoCT.Text.Trim().Replace("-", "") != "")
                        _ctchdb.MaCTCTDB = decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", ""));

                    if (!string.IsNullOrEmpty(cmbLyDo.SelectedValue.ToString()))
                        _ctchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                    _ctchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                    _ctchdb.NoiDung = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiDung;
                    if (txtSoTien.Text.Trim() != "")
                        _ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                    else
                        _ctchdb.SoTien = null;
                    ///
                    if (chkNgayXuLy.Checked)
                    {
                        if (_ctchdb.NgayXuLy != null && _ctchdb.NgayXuLy != dateXuLy.Value)
                        {
                            LichSuXuLyCTCHDB lsxl = new LichSuXuLyCTCHDB();
                            lsxl.NgayXuLy = _ctchdb.NgayXuLy;
                            lsxl.NoiDung = _ctchdb.NoiDungXuLy;
                            lsxl.MaCTCHDB = _ctchdb.MaCTCHDB;
                            if (_cCHDB.ThemLichSuXuLy(lsxl))
                            {
                                dgvLichSuXuLy.DataSource = _cCHDB.LoadDSLichSuXuLyByMaCTCHDB(_ctchdb.MaCTCHDB);
                            }
                        }
                        _ctchdb.NgayXuLy = dateXuLy.Value;
                        _ctchdb.NoiDungXuLy = cmbNoiDung.SelectedItem.ToString();
                        _ctchdb.CreateDate_NgayXuLy = DateTime.Now;
                    }
                    else
                    {
                        _ctchdb.NgayXuLy = null;
                        _ctchdb.NoiDungXuLy = null;
                        _ctchdb.CreateDate_NgayXuLy = null;
                    }

                    _ctchdb.NoiNhan = txtNoiNhan.Text.Trim();

                    //if (_ctchdb.TCTBXuLy != chkKetQuaTCTBXuLy.Checked)
                        //if (chkKetQuaTCTBXuLy.Checked)
                        //{
                        //    _ctchdb.TCTBXuLy = true;
                        //    _ctchdb.NgayTCTBXuLy = dateTCTBXuLy.Value;
                        //    if (chkTroNgai.Checked)
                        //        _ctchdb.TroNgai = true;
                        //    else
                        //        _ctchdb.TroNgai = false;
                        //    if (chkCatTam.Checked)
                        //        _ctchdb.CatTam = true;
                        //    else
                        //        _ctchdb.CatTam = false;
                        //    _ctchdb.KetQuaTCTBXuLy = txtKetQuaTCTBXuLy.Text.Trim();
                        //}
                        //else
                        //{
                        //    _ctchdb.TCTBXuLy = false;
                        //    _ctchdb.NgayTCTBXuLy = null;
                        //    _ctchdb.TroNgai = false;
                        //    _ctchdb.CatTam = false;
                        //    _ctchdb.KetQuaTCTBXuLy = null;
                        //}

                    //if (_ctchdb.CapTrenXuLy != chkKetQuaCapTrenXuLy.Checked)
                        //if (chkKetQuaCapTrenXuLy.Checked)
                        //{
                        //    _ctchdb.CapTrenXuLy = true;
                        //    _ctchdb.NgayCapTrenXuLy = dateCapTrenXuLy.Value;
                        //    _ctchdb.KetQuaCapTrenXuLy = txtKetQuaCapTrenXuLy.Text.Trim();
                        //    _ctchdb.ThoiGianLapPhieu = int.Parse(txtThoiGianLapPhieu.Text.Trim());
                        //}
                        //else
                        //{
                        //    _ctchdb.CapTrenXuLy = false;
                        //    _ctchdb.NgayCapTrenXuLy = null;
                        //    _ctchdb.KetQuaCapTrenXuLy = null;
                        //    _ctchdb.ThoiGianLapPhieu = null;
                        //}

                    if (_ctchdb.DaLapPhieu && _ctchdb.YeuCauCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCHDB == _ctchdb.MaCTCHDB).HieuLucKy != txtHieuLucKy.Text.Trim())
                    {
                        YeuCauCHDB ycchdb = _ctchdb.YeuCauCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCHDB == _ctchdb.MaCTCHDB);
                        ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                        _cCHDB.SuaYeuCauCHDB(ycchdb);
                    }

                    if (_cCHDB.SuaCTCHDB(_ctchdb))
                    {
                        MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        if (!_direct)
                        {
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

        private void chkKetQuaTCTBXuLy_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkKetQuaTCTBXuLy.Checked)
            //    groupBoxKetQuaTCTBXuLy.Enabled = true;
            //else
            //    groupBoxKetQuaTCTBXuLy.Enabled = false;
        }

        private void chkKetQuaCapTrenXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKetQuaCapTrenXuLy.Checked)
                groupBoxKetQuaCapTrenXuLy.Enabled = true;
            else
                groupBoxKetQuaCapTrenXuLy.Enabled = false;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                    LoadTTKH(_ttkhachhang);
                    string ThongTin;
                    if (_cCHDB.CheckCHDBbyDanhBo(_ttkhachhang.DanhBo, out ThongTin))
                        MessageBox.Show("Danh Bộ này đã lập " + ThongTin, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtDanhBo.Text = "";
                    txtHopDong.Text = "";
                    txtHoTen.Text = "";
                    txtDiaChi.Text = "";
                    _ttkhachhang = null;
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_cCHDB.XoaLichSuXuLy(_cCHDB.GetLichSuXyLyByID(decimal.Parse(dgvLichSuXuLy.CurrentRow.Cells["MaLSXuLy"].Value.ToString()))))
                {
                    dgvLichSuXuLy.DataSource = _cCHDB.LoadDSLichSuXuLyByMaCTCHDB(_ctchdb.MaCTCHDB);
                }
            }
        }

        private void dgvLichSuXuLy_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLichSuXuLy.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvLichSuXuLy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvLichSuXuLy.CurrentCell = dgvLichSuXuLy.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvLichSuXuLy_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_ctchdb != null))
            {
                contextMenuStrip1.Show(dgvLichSuXuLy, new Point(e.X, e.Y));
            }
        }

        private void cmbNoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbNoiDung.SelectedIndex != -1)
            //    dateXuLy.Enabled = true;
        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            if (txtSoTien.Text.Trim() != "")
                txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
        }

        private void chkNgayXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayXuLy.Checked)
            {
                dateXuLy.Enabled = true;
                cmbNoiDung.Enabled = true;
            }
            else
            {
                dateXuLy.Enabled = false;
                cmbNoiDung.Enabled = false;
            }
        }

        private void txtDenMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTuMa.Text.Trim().Replace("-", "").Length > 2 && txtDenMa.Text.Trim().Replace("-", "").Length > 2 && e.KeyChar == 13)
                if (txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2) == txtDenMa.Text.Trim().Replace("-", "").Substring(txtDenMa.Text.Trim().Replace("-", "").Length - 2, 2))
                {
                    int TuMa = int.Parse(txtTuMa.Text.Trim().Replace("-", "").Substring(0, txtTuMa.Text.Trim().Replace("-", "").Length - 2));
                    int DenMa = int.Parse(txtDenMa.Text.Trim().Replace("-", "").Substring(0, txtDenMa.Text.Trim().Replace("-", "").Length - 2));
                    while (TuMa <= DenMa)
                    {
                        lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                        TuMa++;
                    }
                }
                else
                {
                    MessageBox.Show("Từ Mã, Đến Mã phải cùng 1 năm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnLuuNhieu_Click(object sender, EventArgs e)
        {
            if (radToKH.Checked)
                foreach (ListViewItem itemMa in lstMa.Items)
                {
                    DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));

                    if (!_cCHDB.CheckCHDBbyMaDon(donkh.MaDon))
                    {
                        CHDB chdb = new CHDB();
                        chdb.MaDon = donkh.MaDon;
                        _cCHDB.ThemCHDB(chdb);

                        TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(donkh.DanhBo);

                        CTCHDB ctchdb = new CTCHDB();
                        ctchdb.MaCHDB = chdb.MaCHDB;
                        ctchdb.DanhBo = ttkhachhang.DanhBo;
                        ctchdb.HopDong = ttkhachhang.GiaoUoc;
                        ctchdb.HoTen = ttkhachhang.HoTen;
                        ctchdb.DiaChi = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);

                        if (ttkhachhang != null)
                        {
                            ctchdb.Dot = ttkhachhang.Dot;
                            ctchdb.Ky = ttkhachhang.Ky;
                            ctchdb.Nam = ttkhachhang.Nam;
                        }
                        ctchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                        ctchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                        if (txtSoTien.Text.Trim() != "")
                            ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                        ctchdb.NoiDung = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiDung;
                        ctchdb.NoiNhan = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiNhan + "\r\n(" + itemMa.Text.Insert(itemMa.Text.Length - 2, "-") + ")";

                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ctchdb.ChucVu = "GIÁM ĐỐC";
                        else
                            ctchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        ctchdb.ThongBaoDuocKy = true;

                        _cCHDB.ThemCTCHDB(ctchdb);
                        lstMa.Items.Remove(itemMa);
                    }
                }
            else
                if (radTXL.Checked)
                    foreach (ListViewItem itemMa in lstMa.Items)
                    {
                        DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));

                        if (!_cCHDB.CheckCHDBbyMaDon_TXL(dontxl.MaDon))
                        {
                            CHDB chdb = new CHDB();
                            chdb.ToXuLy = true;
                            chdb.MaDonTXL = dontxl.MaDon;
                            _cCHDB.ThemCHDB(chdb);

                            TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(dontxl.DanhBo);

                            CTCHDB ctchdb = new CTCHDB();
                            ctchdb.MaCHDB = chdb.MaCHDB;
                            ctchdb.DanhBo = ttkhachhang.DanhBo;
                            ctchdb.HopDong = ttkhachhang.GiaoUoc;
                            ctchdb.HoTen = ttkhachhang.HoTen;
                            ctchdb.DiaChi = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);

                            if (ttkhachhang != null)
                            {
                                ctchdb.Dot = ttkhachhang.Dot;
                                ctchdb.Ky = ttkhachhang.Ky;
                                ctchdb.Nam = ttkhachhang.Nam;
                            }
                            ctchdb.LyDo = cmbLyDo.SelectedValue.ToString();
                            ctchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                            if (txtSoTien.Text.Trim() != "")
                                ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                            ctchdb.NoiDung = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiDung;
                            ctchdb.NoiNhan = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiNhan + "\r\n(TXL" + itemMa.Text.Insert(itemMa.Text.Length - 2, "-") + ")";

                            ///Ký Tên
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctchdb.ChucVu = "GIÁM ĐỐC";
                            else
                                ctchdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            ctchdb.ThongBaoDuocKy = true;

                            _cCHDB.ThemCTCHDB(ctchdb);
                            lstMa.Items.Remove(itemMa);
                        }
                    }
        }

        private void lstMa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstMa.Items.Count > 0 && e.Button == MouseButtons.Left)
            {
                foreach (ListViewItem item in lstMa.SelectedItems)
                {
                    lstMa.Items.Remove(item);
                }
            }
        }

        private void radTXL_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radToKH_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lstMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMa.SelectedItems.Count == 0)
                return;

            if (radToKH.Checked)
            {
                DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(lstMa.SelectedItems[0].Text.Trim().Replace("-", "")));
                dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(donkh.DanhBo);
            }
            else
                if (radTXL.Checked)
                {
                    DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(lstMa.SelectedItems[0].Text.Trim().Replace("-", "")));
                    dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(dontxl.DanhBo);
                }
        }

    }
}
