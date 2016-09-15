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
    public partial class frmCTDB : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        TTKhachHang _ttkhachhang = null;
        CTTKH _cTTKH = new CTTKH();
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CKTXM _cKTXM = new CKTXM();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CVeViecCHDB _cVeViecCHDB = new CVeViecCHDB();
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
            dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(ttkhachhang.DanhBo);
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            ///
            //groupBoxNguyenNhanXuLy.Enabled = false;
            cmbLyDo.SelectedIndex = 0;
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
            txtGhiChu.Text = "";
            txtNoiNhanXuLy.Text = "";
            txtNoiNhan.Text = "";
            ///
            txtHieuLucKy.Text = "";
            chkKetQuaCapTrenXuLy.Checked=false;
            dateCapTrenXuLy.Value = DateTime.Now;
            txtKetQuaCapTrenXuLy.Text = "";
            txtThoiGianLapCatHuy.Text = "";
            _ttkhachhang = null;
            _ctctdb = null;
            btnSua.Enabled = false;
        }

        private void frmCTDB_Load(object sender, EventArgs e)
        {
            if (_direct)
            {
                try
                {
                    this.ControlBox = false;
                    this.WindowState = FormWindowState.Maximized;
                    this.BringToFront();
                    txtMaDon.ReadOnly = false;
                    txtMaThongBao.ReadOnly = false;

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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
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
                        groupBoxKetQuaTCTBXuLy.Enabled = true;
                        groupBoxKetQuaCapTrenXuLy.Enabled = true;
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
                            cmbLyDo.SelectedValue = _ctctdb.LyDo;
                            txtGhiChuXuLy.Text = _ctctdb.GhiChuLyDo;
                            txtSoTien.Text = _ctctdb.SoTien.ToString();
                            ///Kết Quả Xử Lý
                            if (_ctctdb.TCTBXuLy)
                            {
                                dateLichSuXuLy.Value = _ctctdb.NgayTCTBXuLy.Value;
                                txtNoiDung.Text = _ctctdb.KetQuaTCTBXuLy;
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
                ///Nếu đơn thuộc Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if ((_dontxl != null ||_ctctdb!=null) && cmbLyDo.SelectedIndex != -1)
                    {
                        if (!_cCHDB.CheckCHDBbyMaDon_TXL(_dontxl.MaDon))
                        {
                            CHDB chdb = new CHDB();
                            chdb.ToXuLy = true;
                            chdb.MaDonTXL = _dontxl.MaDon;
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
                                //_source.Add("MaCHDB", _cCHDB.getMaxMaCHDB().ToString());
                                if (string.IsNullOrEmpty(_dontxl.TienTrinh))
                                    _dontxl.TienTrinh = "CHDB";
                                else
                                    _dontxl.TienTrinh += ",CHDB";
                                _dontxl.Nhan = true;
                                _cDonTXL.SuaDonTXL(_dontxl, true);
                            }
                        }
                        if (_cCHDB.CheckCTCTDBbyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim()))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Cắt Tạm Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        CTCTDB ctctdb = new CTCTDB();
                        ctctdb.MaCHDB = _cCHDB.getCHDBbyMaDon_TXL(_dontxl.MaDon).MaCHDB;
                        ctctdb.DanhBo = txtDanhBo.Text.Trim();
                        ctctdb.HopDong = txtHopDong.Text.Trim();
                        ctctdb.HoTen = txtHoTen.Text.Trim();
                        ctctdb.DiaChi = txtDiaChi.Text.Trim();
                        if (_ttkhachhang != null)
                        {
                            ctctdb.Dot = _ttkhachhang.Dot;
                            ctctdb.Ky = _ttkhachhang.Ky;
                            ctctdb.Nam = _ttkhachhang.Nam;
                        }
                        ctctdb.LyDo = cmbLyDo.SelectedValue.ToString();
                        ctctdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                        if (txtSoTien.Text.Trim() != "")
                            ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                        ctctdb.NoiDung = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiDung;

                        ctctdb.NoiNhan = txtNoiNhan.Text.Trim();

                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ctctdb.ChucVu = "GIÁM ĐỐC";
                        else
                            ctctdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ctctdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        ctctdb.ThongBaoDuocKy = true;

                        if (_cCHDB.ThemCTCTDB(ctctdb))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            //DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                            //dr["SoPhieu"] = _cCHDB.getMaxMaCTCTDB().ToString().Insert(_cCHDB.getMaxMaCTCTDB().ToString().Length - 2, "-");
                            //dr["HoTen"] = ctctdb.HoTen;
                            //dr["DiaChi"] = ctctdb.DiaChi;
                            //dr["DanhBo"] = ctctdb.DanhBo;
                            //dr["HopDong"] = ctctdb.HopDong;
                            //dr["LyDo"] = ctctdb.LyDo + ". ";
                            //if (ctctdb.GhiChuLyDo != "")
                            //    dr["LyDo"] += ctctdb.GhiChuLyDo + ". ";
                            //if (ctctdb.SoTien.ToString() != "")
                            //    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctctdb.SoTien);
                            //dr["ChucVu"] = ctctdb.ChucVu;
                            //dr["NguoiKy"] = ctctdb.NguoiKy;

                            //dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                            //rptThongBaoCTDB rpt = new rptThongBaoCTDB();
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
                ///Nếu đơn thuộc Tổ Khách Hàng
                else
                    if ((_donkh != null || _ctctdb != null) && cmbLyDo.SelectedIndex != -1)
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
                                _donkh.TienTrinh = "CHDB";
                            else
                                _donkh.TienTrinh += ",CHDB";
                            _donkh.Nhan = true;
                            _cDonKH.SuaDonKH(_donkh, true);
                        }
                    }
                    if (_cCHDB.CheckCTCTDBbyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim()))
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
                    if (_ttkhachhang != null)
                    {
                        ctctdb.Dot = _ttkhachhang.Dot;
                        ctctdb.Ky = _ttkhachhang.Ky;
                        ctctdb.Nam = _ttkhachhang.Nam;
                    }
                    ctctdb.LyDo = cmbLyDo.SelectedValue.ToString();
                    ctctdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                    if (txtSoTien.Text.Trim() != "")
                        ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                    ctctdb.NoiDung = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiDung;

                    ctctdb.NoiNhan = txtNoiNhan.Text.Trim();
                    ///Ký Tên
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        ctctdb.ChucVu = "GIÁM ĐỐC";
                    else
                        ctctdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                    ctctdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                    ctctdb.ThongBaoDuocKy = true;

                    if (_cCHDB.ThemCTCTDB(ctctdb))
                    {
                        MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                        //DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                        //dr["SoPhieu"] = _cCHDB.getMaxMaCTCTDB().ToString().Insert(_cCHDB.getMaxMaCTCTDB().ToString().Length - 2, "-");
                        //dr["HoTen"] = ctctdb.HoTen;
                        //dr["DiaChi"] = ctctdb.DiaChi;
                        //dr["DanhBo"] = ctctdb.DanhBo;
                        //dr["HopDong"] = ctctdb.HopDong;
                        //dr["LyDo"] = ctctdb.LyDo + ". ";
                        //if (ctctdb.GhiChuLyDo != "")
                        //    dr["LyDo"] += ctctdb.GhiChuLyDo + ". ";
                        //if (ctctdb.SoTien.ToString() != "")
                        //    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctctdb.SoTien);
                        //dr["ChucVu"] = ctctdb.ChucVu;
                        //dr["NguoiKy"] = ctctdb.NguoiKy;

                        //dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                        //rptThongBaoCTDB rpt = new rptThongBaoCTDB();
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

        private void btnCapNhatTCTBXuLy_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctctdb != null)
                {
                    //_ctctdb.TCTBXuLy = true;
                    //_ctctdb.NgayTCTBXuLy = dateXuLy.Value;
                    //_ctctdb.KetQuaTCTBXuLy = txtKetQuaTCTBXuLy.Text.Trim();
                    LichSuXuLyCTCHDB lsxl = new LichSuXuLyCTCHDB();
                    lsxl.NgayXuLy = dateLichSuXuLy.Value;
                    lsxl.NoiDung = txtNoiDung.Text.Trim();
                    lsxl.NoiNhan = txtNoiNhanXuLy.Text.Trim();
                    lsxl.GhiChu = txtGhiChu.Text.Trim();
                    lsxl.MaCTCTDB = _ctctdb.MaCTCTDB;
                    if (_cCHDB.ThemLichSuXuLy(lsxl))
                    {
                        dgvLichSuXuLy.DataSource = _cCHDB.LoadDSLichSuXuLyByMaCTCTDB(_ctctdb.MaCTCTDB);
                        MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Clear();
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
                if (_ctctdb != null)
                {
                    _ctctdb.CapTrenXuLy = true;
                    _ctctdb.NgayCapTrenXuLy = dateCapTrenXuLy.Value;
                    _ctctdb.KetQuaCapTrenXuLy = txtKetQuaCapTrenXuLy.Text.Trim();
                    _ctctdb.ThoiGianLapCatHuy = int.Parse(txtThoiGianLapCatHuy.Text.Trim());
                    if (_cCHDB.SuaCTCTDB(_ctctdb))
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
                ///Nếu đơn thuộc Tổ Khách Hàng
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

        private void txtMaThongBao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cCHDB.getCTCTDBbyID(decimal.Parse(txtMaThongBao.Text.Trim().Replace("-", ""))) != null)
                {
                    Clear();
                    _ctctdb = _cCHDB.getCTCTDBbyID(decimal.Parse(txtMaThongBao.Text.Trim().Replace("-", "")));
                    if(!string.IsNullOrEmpty(_ctctdb.CHDB.MaDonTXL.ToString()))
                    txtMaDon.Text = "TXL"+_ctctdb.CHDB.MaDonTXL.ToString().Insert(_ctctdb.CHDB.MaDonTXL.ToString().Length - 2, "-");
                    else
                        if (!string.IsNullOrEmpty(_ctctdb.CHDB.MaDon.ToString()))
                            txtMaDon.Text = _ctctdb.CHDB.MaDon.ToString().Insert(_ctctdb.CHDB.MaDon.ToString().Length - 2, "-");
                    txtMaThongBao.Text = _ctctdb.MaCTCTDB.ToString().Insert(_ctctdb.MaCTCTDB.ToString().Length - 2, "-");
                    ///
                    //LoadTTKH(_cTTKH.getTTKHbyID(_ctctdb.DanhBo));
                    txtDanhBo.Text = _ctctdb.DanhBo;
                    txtHopDong.Text = _ctctdb.HopDong;
                    txtHoTen.Text = _ctctdb.HoTen;
                    txtDiaChi.Text = _ctctdb.DiaChi;
                    ///Nguyên Nhân Xử Lý
                    cmbLyDo.SelectedValue = _ctctdb.LyDo;
                    txtGhiChuXuLy.Text = _ctctdb.GhiChuLyDo;
                    txtSoTien.Text = _ctctdb.SoTien.ToString();

                    if (_ctctdb.NoiDungXuLy != null)
                    {
                        chkNgayXuLy.Checked = true;
                        dateXuLy.Value = _ctctdb.NgayXuLy.Value;
                        cmbNoiDung.SelectedItem = _ctctdb.NoiDungXuLy;
                    }
                    else
                    {
                        chkNgayXuLy.Checked = false;
                        dateXuLy.Value = DateTime.Now;
                        cmbNoiDung.SelectedIndex=-1;
                    }

                    txtNoiNhan.Text = _ctctdb.NoiNhan;
                    ///Kết Quả Xử Lý
                    //if (_ctctdb.TCTBXuLy)
                    //{
                    //    chkKetQuaTCTBXuLy.Checked = true;
                    //    dateXuLy.Value = _ctctdb.NgayTCTBXuLy.Value;
                    //    if (_ctctdb.TroNgai)
                    //        chkTroNgai.Checked = true;
                    //    else
                    //        chkTroNgai.Checked = false;
                    //    txtNoiDung.Text = _ctctdb.KetQuaTCTBXuLy;
                    //}
                    //else
                    //{
                    //    chkKetQuaTCTBXuLy.Checked = false;
                    //    dateXuLy.Value = DateTime.Now;
                    //    chkTroNgai.Checked = false;
                    //    txtNoiDung.Text = "";
                    //}
                    dgvLichSuXuLy.DataSource = _cCHDB.LoadDSLichSuXuLyByMaCTCTDB(_ctctdb.MaCTCTDB);
                    dgvLichSuCHDB.DataSource = _cCHDB.GetLichSuCHDB(_ctctdb.DanhBo);
                    ///Cấp Trên Xử Lý
                    //if (_ctctdb.CapTrenXuLy)
                    //{
                    //    chkKetQuaCapTrenXuLy.Checked = true;
                    //    dateCapTrenXuLy.Value = _ctctdb.NgayCapTrenXuLy.Value;
                    //    txtKetQuaCapTrenXuLy.Text = _ctctdb.KetQuaCapTrenXuLy;
                    //    txtThoiGianLapCatHuy.Text = _ctctdb.ThoiGianLapCatHuy.ToString();
                    //}
                    //else
                    //{
                    //    chkKetQuaCapTrenXuLy.Checked = false;
                    //    dateCapTrenXuLy.Value = DateTime.Now;
                    //    txtKetQuaCapTrenXuLy.Text = "";
                    //    txtThoiGianLapCatHuy.Text = "";
                    //}
                    ///Đã lấp Phiếu Yêu Cầu CHDB
                    if (_cCHDB.CheckYeuCauCHDBbyMaCTCTDB(_ctctdb.MaCTCTDB))
                    {
                        txtHieuLucKy.Text = _ctctdb.YeuCauCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCTDB == _ctctdb.MaCTCTDB).HieuLucKy;
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
                    MessageBox.Show("Mã Thông Báo này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctctdb != null)
                {
                    //if (_ctctdb.DanhBo != txtDanhBo.Text.Trim())
                    //{
                        _ctctdb.DanhBo = txtDanhBo.Text.Trim();
                        _ctctdb.HopDong = txtHopDong.Text.Trim();
                        _ctctdb.HoTen = txtHoTen.Text.Trim();
                        _ctctdb.DiaChi = txtDiaChi.Text.Trim();
                        if (_ttkhachhang != null)
                        {
                            _ctctdb.Dot = _ttkhachhang.Dot;
                            _ctctdb.Ky = _ttkhachhang.Ky;
                            _ctctdb.Nam = _ttkhachhang.Nam;
                        }
                    //}

                    if (!string.IsNullOrEmpty(cmbLyDo.SelectedValue.ToString()))
                        _ctctdb.LyDo = cmbLyDo.SelectedValue.ToString();
                    _ctctdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                    _ctctdb.NoiDung = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiDung;
                    if (txtSoTien.Text.Trim() != "")
                        _ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                    else
                        _ctctdb.SoTien = null;
                    ///
                    if (chkNgayXuLy.Checked)
                    {
                        if (_ctctdb.NgayXuLy != null && _ctctdb.NgayXuLy != dateXuLy.Value)
                        {
                            LichSuXuLyCTCHDB lsxl = new LichSuXuLyCTCHDB();
                            lsxl.NgayXuLy = _ctctdb.NgayXuLy;
                            lsxl.NoiDung = _ctctdb.NoiDungXuLy;
                            lsxl.MaCTCTDB = _ctctdb.MaCTCTDB;
                            if (_cCHDB.ThemLichSuXuLy(lsxl))
                            {
                                dgvLichSuXuLy.DataSource = _cCHDB.LoadDSLichSuXuLyByMaCTCTDB(_ctctdb.MaCTCTDB);
                            }
                        }
                        _ctctdb.NgayXuLy = dateXuLy.Value;
                        _ctctdb.NoiDungXuLy = cmbNoiDung.SelectedItem.ToString();
                        _ctctdb.CreateDate_NgayXuLy = DateTime.Now;
                    }
                    else
                    {
                        _ctctdb.NgayXuLy = null;
                        _ctctdb.NoiDungXuLy = null;
                        _ctctdb.CreateDate_NgayXuLy = null;
                    }

                    _ctctdb.NoiNhan = txtNoiNhan.Text.Trim();

                    //if (_ctctdb.TCTBXuLy != chkKetQuaTCTBXuLy.Checked)
                        //if (chkKetQuaTCTBXuLy.Checked)
                        //{
                        //    _ctctdb.TCTBXuLy = true;
                        //    _ctctdb.NgayTCTBXuLy = dateTCTBXuLy.Value;
                        //    if (chkTroNgai.Checked)
                        //        _ctctdb.TroNgai = true;
                        //    else
                        //        _ctctdb.TroNgai = false;
                        //    _ctctdb.KetQuaTCTBXuLy = txtKetQuaTCTBXuLy.Text.Trim();
                        //}
                        //else
                        //{
                        //    _ctctdb.TCTBXuLy = false;
                        //    _ctctdb.NgayTCTBXuLy = null;
                        //    _ctctdb.TroNgai = false;
                        //    _ctctdb.KetQuaTCTBXuLy = null;
                        //}

                    //if (_ctctdb.CapTrenXuLy != chkKetQuaCapTrenXuLy.Checked)
                        //if (chkKetQuaCapTrenXuLy.Checked)
                        //{
                        //    _ctctdb.CapTrenXuLy = true;
                        //    _ctctdb.NgayCapTrenXuLy = dateCapTrenXuLy.Value;
                        //    _ctctdb.KetQuaCapTrenXuLy = txtKetQuaCapTrenXuLy.Text.Trim();
                        //    _ctctdb.ThoiGianLapCatHuy = int.Parse(txtThoiGianLapCatHuy.Text.Trim());
                        //}
                        //else
                        //{
                        //    _ctctdb.CapTrenXuLy = false;
                        //    _ctctdb.NgayCapTrenXuLy = null;
                        //    _ctctdb.KetQuaCapTrenXuLy = null;
                        //    _ctctdb.ThoiGianLapCatHuy = null;
                        //}

                    if (_ctctdb.DaLapPhieu && _ctctdb.YeuCauCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCTDB == _ctctdb.MaCTCTDB).HieuLucKy != txtHieuLucKy.Text.Trim())
                    {
                        YeuCauCHDB ycchdb = _ctctdb.YeuCauCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCTDB == _ctctdb.MaCTCTDB);
                        ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                        _cCHDB.SuaYeuCauCHDB(ycchdb);
                    }

                    if (_cCHDB.SuaCTCTDB(_ctctdb))
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

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (_ctctdb != null)
            {
                ///Nếu Chưa Lập Phiếu
                if (!_cCHDB.CheckYeuCauCHDBbyMaCTCTDB(_ctctdb.MaCTCTDB))
                {
                    if (txtHieuLucKy.Text.Trim() != "")
                    {
                        YeuCauCHDB ycchdb = new YeuCauCHDB();
                        if (_ctctdb.CHDB.ToXuLy)
                        {
                            ycchdb.ToXuLy = true;
                            ycchdb.MaDonTXL = _ctctdb.CHDB.MaDonTXL;
                        }
                        else
                            ycchdb.MaDon = _ctctdb.CHDB.MaDon;
                        ycchdb.TBCTDB = true;
                        ycchdb.MaCTCTDB = _ctctdb.MaCTCTDB;
                        ycchdb.DanhBo = _ctctdb.DanhBo;
                        ycchdb.HopDong = _ctctdb.HopDong;
                        ycchdb.HoTen = _ctctdb.HoTen;
                        ycchdb.DiaChi = _ctctdb.DiaChi;
                        ycchdb.LyDo = _ctctdb.LyDo;
                        ycchdb.GhiChuLyDo = _ctctdb.GhiChuLyDo;
                        ycchdb.SoTien = _ctctdb.SoTien;
                        ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                        TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(_ctctdb.DanhBo);
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
                            _ctctdb.DaLapPhieu = true;
                            _ctctdb.SoPhieu = ycchdb.MaYCCHDB;
                            _ctctdb.NgayLapPhieu = ycchdb.CreateDate;
                            _ctctdb.HieuLucKy = ycchdb.HieuLucKy;
                            _ctctdb.PhieuDuocKy = true;
                            _cCHDB.SuaCTCTDB(_ctctdb);

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
                            if (_ctctdb.CHDB.ToXuLy)
                            {
                                ycchdb.ToXuLy = true;
                                ycchdb.MaDonTXL = _ctctdb.CHDB.MaDonTXL;
                            }
                            else
                                ycchdb.MaDon = _ctctdb.CHDB.MaDon;
                            ycchdb.TBCTDB = true;
                            ycchdb.MaCTCTDB = _ctctdb.MaCTCTDB;
                            ycchdb.DanhBo = _ctctdb.DanhBo;
                            ycchdb.HopDong = _ctctdb.HopDong;
                            ycchdb.HoTen = _ctctdb.HoTen;
                            ycchdb.DiaChi = _ctctdb.DiaChi;
                            ycchdb.LyDo = _ctctdb.LyDo;
                            ycchdb.GhiChuLyDo = _ctctdb.GhiChuLyDo;
                            ycchdb.SoTien = _ctctdb.SoTien;
                            ycchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                            TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(_ctctdb.DanhBo);
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
                                _ctctdb.DaLapPhieu = true;
                                _ctctdb.SoPhieu = ycchdb.MaYCCHDB;
                                _ctctdb.HieuLucKy = ycchdb.HieuLucKy;
                                _ctctdb.NgayLapPhieu = ycchdb.CreateDate;
                                _ctctdb.PhieuDuocKy = true;
                                _cCHDB.SuaCTCTDB(_ctctdb);

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
                    YeuCauCHDB ycchdb = _cCHDB.getYeuCauCHDBbyMaCTCTDB(_ctctdb.MaCTCTDB);
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
                    dgvLichSuXuLy.DataSource = _cCHDB.LoadDSLichSuXuLyByMaCTCTDB(_ctctdb.MaCTCTDB);
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
            if (e.Button == MouseButtons.Right && (_ctctdb != null))
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

                        CTCTDB ctctdb = new CTCTDB();
                        ctctdb.MaCHDB = chdb.MaCHDB;
                        ctctdb.DanhBo = ttkhachhang.DanhBo;
                        ctctdb.HopDong = ttkhachhang.GiaoUoc;
                        ctctdb.HoTen = ttkhachhang.HoTen;
                        ctctdb.DiaChi = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);

                        if (ttkhachhang != null)
                        {
                            ctctdb.Dot = ttkhachhang.Dot;
                            ctctdb.Ky = ttkhachhang.Ky;
                            ctctdb.Nam = ttkhachhang.Nam;
                        }
                        ctctdb.LyDo = cmbLyDo.SelectedValue.ToString();
                        ctctdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                        if (txtSoTien.Text.Trim() != "")
                            ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                        ctctdb.NoiDung = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiDung;
                        ctctdb.NoiNhan = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiNhan + "\r\n(" + itemMa.Text.Insert(itemMa.Text.Length - 2, "-") + ")";

                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ctctdb.ChucVu = "GIÁM ĐỐC";
                        else
                            ctctdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ctctdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        ctctdb.ThongBaoDuocKy = true;

                        _cCHDB.ThemCTCTDB(ctctdb);
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

                            CTCTDB ctctdb = new CTCTDB();
                            ctctdb.MaCHDB = chdb.MaCHDB;
                            ctctdb.DanhBo = ttkhachhang.DanhBo;
                            ctctdb.HopDong = ttkhachhang.GiaoUoc;
                            ctctdb.HoTen = ttkhachhang.HoTen;
                            ctctdb.DiaChi = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);

                            if (ttkhachhang != null)
                            {
                                ctctdb.Dot = ttkhachhang.Dot;
                                ctctdb.Ky = ttkhachhang.Ky;
                                ctctdb.Nam = ttkhachhang.Nam;
                            }
                            ctctdb.LyDo = cmbLyDo.SelectedValue.ToString();
                            ctctdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                            if (txtSoTien.Text.Trim() != "")
                                ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                            ctctdb.NoiDung = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiDung;
                            ctctdb.NoiNhan = ((VeViecCHDB)cmbLyDo.SelectedItem).NoiNhan + "\r\n(TXL" + itemMa.Text.Insert(itemMa.Text.Length - 2, "-") + ")";

                            ///Ký Tên
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctctdb.ChucVu = "GIÁM ĐỐC";
                            else
                                ctctdb.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctctdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            ctctdb.ThongBaoDuocKy = true;

                            _cCHDB.ThemCTCTDB(ctctdb);
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

    }
}
