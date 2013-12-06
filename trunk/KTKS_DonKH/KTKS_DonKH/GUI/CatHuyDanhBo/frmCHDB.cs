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

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmCHDB : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        TTKhachHang _ttkhachhang = new TTKhachHang();
        CTTKH _cTTKH = new CTTKH();
        CCHDB _cCHDB = new CCHDB();
        CTCHDB _ctchdb = null;
        CTCTDB _ctctdb = null;
        CDonKH _cDonKH = new CDonKH();
        CKTXM _cKTXM = new CKTXM();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();

        public frmCHDB()
        {
            InitializeComponent();
        }

        public frmCHDB(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmCHDB_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            ///Tạo Cắt Hủy
            if (_source["Action"] == "Thêm")
            {
                groupBoxNguyenNhanXuLy.Enabled = true;
                txtMaDon.Text = _source["MaDon"].Insert(4, "-");
                if (_cTTKH.getTTKHbyID(_source["DanhBo"]) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(_source["DanhBo"]);
                    txtDanhBo.Text = _ttkhachhang.DanhBo;
                    txtHopDong.Text = _ttkhachhang.GiaoUoc;
                    txtHoTen.Text = _ttkhachhang.HoTen;
                    txtDiaChi.Text = _ttkhachhang.DC1 + _ttkhachhang.DC2 + _cCHDB.getPhuongQuanByID(_ttkhachhang.Quan, _ttkhachhang.Phuong);
                }
            }
            else
                ///Sửa Cắt Hủy
                if (_source["Action"] == "Sửa")
                {
                    groupBoxKetQuaXuLy.Enabled = true;
                    groupBoxCapTrenXuLy.Enabled = true;
                    txtHieuLucKy.ReadOnly = false;
                    btnInPhieu.Enabled = true;
                    if (_cCHDB.getCTCHDBbyID(decimal.Parse(_source["MaCTCHDB"])) != null)
                    {
                        _ctchdb = _cCHDB.getCTCHDBbyID(decimal.Parse(_source["MaCTCHDB"]));
                        ///Thông Tin
                        txtMaDon.Text = _ctchdb.CHDB.MaDon.ToString().Insert(4, "-");
                        txtMaThongBaoCH.Text = _ctchdb.MaCTCHDB.ToString().Insert(4, "-");
                        txtDanhBo.Text = _ctchdb.DanhBo;
                        txtHopDong.Text = _ctchdb.HopDong;
                        txtHoTen.Text = _ctchdb.HoTen;
                        txtDiaChi.Text = _ctchdb.DiaChi;
                        ///Nguyên Nhân Xử Lý
                        cmbLyDo.SelectedText = _ctchdb.LyDo;
                        txtGhiChuXuLy.Text = _ctchdb.GhiChuLyDo;
                        txtSoTien.Text = _ctchdb.SoTien.ToString();
                        ///Kết Quả Xử Lý
                        if (_ctchdb.TCTBXuLy)
                        {
                            dateTCTBXuLy.Value = _ctchdb.NgayTCTBXuLy.Value;
                            txtKetQuaTCTBXuLy.Text = _ctchdb.KetQuaTCTBXuLy;
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
                            txtMaDon.Text = _ctctdb.CHDB.MaDon.ToString().Insert(4, "-");
                            txtMaThongBaoCT.Text = _ctctdb.MaCTCTDB.ToString().Insert(4, "-");
                            txtDanhBo.Text = _ctctdb.DanhBo;
                            txtHopDong.Text = _ctctdb.HopDong;
                            txtHoTen.Text = _ctctdb.HoTen;
                            txtDiaChi.Text = _ctctdb.DiaChi;
                            ///Nguyên Nhân Xử Lý
                            cmbLyDo.SelectedItem = _ctctdb.LyDo;
                            txtGhiChuXuLy.Text = _ctctdb.GhiChuLyDo;
                            txtSoTien.Text = _ctctdb.SoTien.ToString();
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
            if (cmbLyDo.SelectedItem.ToString().ToUpper().Contains("TIỀN"))
                txtSoTien.ReadOnly = false;
            else
                txtSoTien.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
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
                                _cDonKH.SuaDonKH(donkh);
                                break;
                            case "Kiểm Tra Xác Minh":
                                ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                                KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                ktxm.Nhan = true;
                                _cKTXM.SuaKTXM(ktxm);
                                break;
                        }
                        _source.Add("MaCHDB", _cCHDB.getMaxMaCHDB().ToString());
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
                    ctchdb.LyDo = cmbLyDo.SelectedItem.ToString();
                    ctchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                    if (txtSoTien.Text.Trim() != "")
                        ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim());

                    ///Ký Tên
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        ctchdb.ChucVu = "GIÁM ĐỐC";
                    else
                        ctchdb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                    ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();

                    if (_cCHDB.ThemCTCHDB(ctchdb))
                    {
                        DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                        DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                        dr["SoPhieu"] = _cCHDB.getMaxMaCTCTDB().ToString().Insert(4, "-");
                        dr["HoTen"] = ctchdb.HoTen;
                        dr["DiaChi"] = ctchdb.DiaChi;
                        dr["DanhBo"] = ctchdb.DanhBo;
                        dr["HopDong"] = ctchdb.HopDong;
                        dr["LyDo"] = ctchdb.LyDo + ". ";
                        if (ctchdb.GhiChuLyDo != "")
                            dr["LyDo"] += ctchdb.GhiChuLyDo + ". ";
                        if (ctchdb.SoTien.ToString() != "")
                            dr["LyDo"] += "Số Tiền: " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctchdb.SoTien);
                        dr["ChucVu"] = ctchdb.ChucVu;
                        dr["NguoiKy"] = ctchdb.NguoiKy;

                        dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                        rptThongBaoCHDB rpt = new rptThongBaoCHDB();
                        rpt.SetDataSource(dsBaoCao);
                        frmBaoCao frm = new frmBaoCao(rpt);
                        frm.ShowDialog();

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
                        ctchdb.LyDo = cmbLyDo.SelectedItem.ToString();
                        ctchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                        if (txtSoTien.Text.Trim() != "")
                            ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim());
                        ///Đã lập Cắt Tạm
                        ctchdb.DaLapCatTam = true;
                        ctchdb.MaCTCTDB = _ctctdb.MaCTCTDB;
                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ctchdb.ChucVu = "GIÁM ĐỐC";
                        else
                            ctchdb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();

                        if (_cCHDB.ThemCTCHDB(ctchdb))
                        {
                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                            dr["SoPhieu"] = _cCHDB.getMaxMaCTCTDB().ToString().Insert(4, "-");
                            dr["HoTen"] = ctchdb.HoTen;
                            dr["DiaChi"] = ctchdb.DiaChi;
                            dr["DanhBo"] = ctchdb.DanhBo;
                            dr["HopDong"] = ctchdb.HopDong;
                            dr["LyDo"] = ctchdb.LyDo + ". ";
                            if (ctchdb.GhiChuLyDo != "")
                                dr["LyDo"] += ctchdb.GhiChuLyDo + ". ";
                            if (ctchdb.SoTien.ToString() != "")
                                dr["LyDo"] += "Số Tiền: " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctchdb.SoTien);
                            dr["ChucVu"] = ctchdb.ChucVu;
                            dr["NguoiKy"] = ctchdb.NguoiKy;

                            dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                            rptThongBaoCHDB rpt = new rptThongBaoCHDB();
                            rpt.SetDataSource(dsBaoCao);
                            frmBaoCao frm = new frmBaoCao(rpt);
                            frm.ShowDialog();

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show("Cắt Hủy đã được lập với Cắt Tạm này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCapNhatTCTBXuLy_Click(object sender, EventArgs e)
        {
            if (_ctchdb != null)
            {
                _ctchdb.TCTBXuLy = true;
                _ctchdb.NgayTCTBXuLy = dateTCTBXuLy.Value;
                _ctchdb.KetQuaTCTBXuLy = txtKetQuaTCTBXuLy.Text.Trim();
                if (_cCHDB.SuaCTCHDB(_ctchdb))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCapNhatCapTrenXuLy_Click(object sender, EventArgs e)
        {
            if (_ctchdb != null)
            {
                _ctchdb.CapTrenXuLy = true;
                _ctchdb.NgayCapTrenXuLy = dateCapTrenXuLy.Value;
                _ctchdb.KetQuaCapTrenXuLy = txtKetQuaCapTrenXuLy.Text.Trim();
                _ctchdb.ThoiGianLapPhieu = int.Parse(txtThoiGianLapPhieu.Text.Trim());
                if (_cCHDB.SuaCTCHDB(_ctchdb))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (_ctchdb != null)
            {
                ///Nếu Chưa Lập Phiếu
                if (!_cCHDB.CheckDaLapPhieuCHDB(_ctchdb.MaCTCHDB))
                {
                    if (txtHieuLucKy.Text.Trim() != "")
                    {
                        _ctchdb.DaLapPhieu = true;
                        _ctchdb.SoPhieu = _cCHDB.getMaxNextSoPhieuCHDB();
                        _ctchdb.NgayLapPhieu = DateTime.Now;
                        _ctchdb.HieuLucKy = txtHieuLucKy.Text.Trim();
                        TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(_ctchdb.DanhBo);
                        _ctchdb.DotLapPhieu = ttkhachhang.Dot;
                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            _ctchdb.ChucVuLapPhieu = "GIÁM ĐỐC";
                        else
                            _ctchdb.ChucVuLapPhieu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        _ctchdb.NguoiKyLapPhieu = bangiamdoc.HoTen.ToUpper();

                        if (_cCHDB.SuaCTCHDB(_ctchdb))
                        {
                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                            dr["SoPhieu"] = _ctchdb.SoPhieu.ToString().Insert(4, "-");
                            dr["HieuLucKy"] = _ctchdb.HieuLucKy;
                            dr["Dot"] = _ctchdb.DotLapPhieu;
                            dr["HoTen"] = _ctchdb.HoTen;
                            dr["DiaChi"] = _ctchdb.DiaChi;
                            dr["DanhBo"] = _ctchdb.DanhBo;
                            dr["HopDong"] = _ctchdb.HopDong;
                            dr["LyDo"] = _ctchdb.LyDo + ". ";
                            if (_ctchdb.GhiChuLyDo != "")
                                dr["LyDo"] += _ctchdb.GhiChuLyDo + ". ";
                            if (_ctchdb.SoTien.ToString() != "")
                                dr["LyDo"] += "Số Tiền: " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctchdb.SoTien);

                            dr["ChucVu"] = _ctchdb.ChucVuLapPhieu;
                            dr["NguoiKy"] = _ctchdb.NguoiKyLapPhieu;

                            dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                            rptPhieuCHDB rpt = new rptPhieuCHDB();
                            rpt.SetDataSource(dsBaoCao);
                            frmBaoCao frm = new frmBaoCao(rpt);
                            frm.ShowDialog();

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show("Chưa có Hiệu Lực Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ///Nếu Đã Lập Phiếu
                else
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                    dr["SoPhieu"] = _ctchdb.SoPhieu.ToString().Insert(4, "-");
                    dr["HieuLucKy"] = _ctchdb.HieuLucKy;
                    dr["Dot"] = _ctchdb.DotLapPhieu;
                    dr["HoTen"] = _ctchdb.HoTen;
                    dr["DiaChi"] = _ctchdb.DiaChi;
                    dr["DanhBo"] = _ctchdb.DanhBo;
                    dr["HopDong"] = _ctchdb.HopDong;
                    dr["LyDo"] = _ctchdb.LyDo + ". ";
                    if (_ctchdb.GhiChuLyDo != "")
                        dr["LyDo"] += _ctchdb.GhiChuLyDo + ". ";
                    if (_ctchdb.SoTien.ToString() != "")
                        dr["LyDo"] += "Số Tiền: " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctchdb.SoTien);

                    dr["ChucVu"] = _ctchdb.ChucVuLapPhieu;
                    dr["NguoiKy"] = _ctchdb.NguoiKyLapPhieu;

                    dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                    rptPhieuCHDB rpt = new rptPhieuCHDB();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
                MessageBox.Show("Chưa có Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }    

    }
}
