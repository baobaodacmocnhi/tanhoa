using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.BaoCao;
using System.Globalization;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmShowCHDB : Form
    {
        decimal _MaCTCHDB = 0;
        CCHDB _cCHDB = new CCHDB();
        CTCHDB _ctchdb = null;
        CTTKH _cTTKH = new CTTKH();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        TTKhachHang _ttkhachhang = null;
        CKTXM _cKTXM = new CKTXM();

        public frmShowCHDB()
        {
            InitializeComponent();
        }

        public frmShowCHDB(decimal MaCTCHDB)
        {
            InitializeComponent();
            _MaCTCHDB = MaCTCHDB;
        }

        public frmShowCHDB(decimal MaCTCHDB,bool TimKiem)
        {
            InitializeComponent();
            _MaCTCHDB = MaCTCHDB;
            if (TimKiem)
            {
                btnCapNhatCapTrenXuLy.Enabled = false;
                btnCapNhatTCTBXuLy.Enabled = false;
                btnIn.Enabled = false;
                btnInPhieu.Enabled = false;
                txtHieuLucKy.ReadOnly = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
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

        private void frmShowCHDB_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 50);
            dgvLichSuXuLy.AutoGenerateColumns = false;
            cmbNoiDung.SelectedIndex = -1;

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

            if (_cCHDB.getCTCHDBbyID(_MaCTCHDB) != null)
            {
                _ctchdb = _cCHDB.getCTCHDBbyID(_MaCTCHDB);
                if (!string.IsNullOrEmpty(_ctchdb.CHDB.MaDonTXL.ToString()))
                    txtMaDon.Text = "TXL"+_ctchdb.CHDB.MaDonTXL.Value.ToString().Insert(_ctchdb.CHDB.MaDonTXL.Value.ToString().Length - 2, "-");
                else
                    if (!string.IsNullOrEmpty(_ctchdb.CHDB.MaDon.ToString()))
                        txtMaDon.Text = _ctchdb.CHDB.MaDon.Value.ToString().Insert(_ctchdb.CHDB.MaDon.Value.ToString().Length - 2, "-");
                txtMaThongBaoCH.Text = _ctchdb.MaCTCHDB.ToString().Insert(_ctchdb.MaCTCHDB.ToString().Length - 2, "-");
                if (!string.IsNullOrEmpty(_ctchdb.MaCTCTDB.ToString()))
                    txtMaThongBaoCT.Text = _ctchdb.MaCTCTDB.ToString().Insert(_ctchdb.MaCTCTDB.ToString().Length - 2, "-");
                txtDanhBo.Text = _ctchdb.DanhBo;
                txtHopDong.Text = _ctchdb.HopDong;
                txtHoTen.Text = _ctchdb.HoTen;
                txtDiaChi.Text = _ctchdb.DiaChi;
                ///
                cmbLyDo.SelectedItem = _ctchdb.LyDo;
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
                    cmbNoiDung.SelectedIndex=-1;
                }

                txtNoiNhan.Text = _ctchdb.NoiNhan;

                dgvLichSuXuLy.DataSource = _cCHDB.LoadDSLichSuXuLyByMaCTCHDB(_ctchdb.MaCTCHDB);

                ///phải có if ở đây vì dateTCTBXuLy không nhận giá trị null
                //if (_ctchdb.TCTBXuLy)
                //{
                //    dateTCTBXuLy.Value = _ctchdb.NgayTCTBXuLy.Value;
                //    txtKetQuaTCTBXuLy.Text = _ctchdb.KetQuaTCTBXuLy;
                //}
                ///
                ///phải có if ở đây vì dateCapTrenXuLy không nhận giá trị null
                //if (_ctchdb.CapTrenXuLy)
                //{
                //    dateCapTrenXuLy.Value = _ctchdb.NgayCapTrenXuLy.Value;
                //    txtKetQuaCapTrenXuLy.Text = _ctchdb.KetQuaCapTrenXuLy;
                //    txtThoiGianLapPhieu.Text = _ctchdb.ThoiGianLapPhieu.Value.ToString();
                //}
                ///
                if (_cCHDB.CheckYeuCauCHDBbyMaCTCHDB(_ctchdb.MaCTCHDB))
                {
                    txtHieuLucKy.Text = _ctchdb.YeuCauCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCHDB == _ctchdb.MaCTCHDB).HieuLucKy;
                }
            }
        }

        private void frmShowCHDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_ctchdb != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                CTKTXM ctktxm = null;
                if (_ctchdb.CHDB.ToXuLy)
                {
                    ctktxm = _cKTXM.getCTKTXMbyMaDonTXLDanhBo(_ctchdb.CHDB.MaDonTXL.Value, _ctchdb.DanhBo);
                }
                else
                {
                    ctktxm = _cKTXM.getCTKTXMbyMaDonKHDanhBo(_ctchdb.CHDB.MaDon.Value, _ctchdb.DanhBo);
                }

                dr["SoPhieu"] = _ctchdb.MaCTCHDB.ToString().Insert(_ctchdb.MaCTCHDB.ToString().Length-2, "-");
                dr["HoTen"] = _ctchdb.HoTen;
                dr["DiaChi"] = _ctchdb.DiaChi;
                if (!string.IsNullOrEmpty(_ctchdb.DanhBo))
                    dr["DanhBo"] = _ctchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HopDong"] = _ctchdb.HopDong;

                if(ctktxm!=null)
                dr["ViTriDHN"] = ctktxm.ViTriDHN1 + ", " + ctktxm.ViTriDHN2;

                if (_ctchdb.LyDo != "Vấn Đề Khác")
                    dr["LyDo"] = _ctchdb.LyDo + ". ";
                if (_ctchdb.GhiChuLyDo != "")
                    dr["LyDo"] += _ctchdb.GhiChuLyDo + ". ";
                if (_ctchdb.SoTien.ToString() != "")
                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctchdb.SoTien);

                dr["NoiNhan"] = _ctchdb.NoiNhan;

                dr["ChucVu"] = _ctchdb.ChucVu;
                dr["NguoiKy"] = _ctchdb.NguoiKy;

                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                rptThongBaoCHDB rpt = new rptThongBaoCHDB();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
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
                            _ctchdb.PhieuDuocKy = true;
                            _cCHDB.SuaCTCHDB(_ctchdb);

                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                            dr["SoPhieu"] = ycchdb.MaYCCHDB.ToString().Insert(ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                            dr["HieuLucKy"] = ycchdb.HieuLucKy;
                            dr["Dot"] = ycchdb.Dot;
                            dr["HoTen"] = ycchdb.HoTen;
                            dr["DiaChi"] = ycchdb.DiaChi;
                            if (!string.IsNullOrEmpty(ycchdb.DanhBo))
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
                                if (!string.IsNullOrEmpty(ycchdb.DanhBo))
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
                    if (!string.IsNullOrEmpty(ycchdb.DanhBo))
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
                }
            }

            else
                MessageBox.Show("Chưa lập Phiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    if (!string.IsNullOrEmpty(cmbLyDo.SelectedItem.ToString()))
                        _ctchdb.LyDo = cmbLyDo.SelectedItem.ToString();
                    _ctchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                    if (txtSoTien.Text.Trim() != "")
                        _ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                    else
                        _ctchdb.SoTien = null;

                    if (chkNgayXuLy.Checked)
                    {
                        _ctchdb.NgayXuLy = dateXuLy.Value;
                        _ctchdb.NoiDungXuLy = cmbNoiDung.SelectedItem.ToString();
                    }
                    else
                    {
                        _ctchdb.NgayXuLy = null;
                        _ctchdb.NoiDungXuLy = null;
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
                    }
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbLyDo.SelectedItem.ToString())
            {
                case "Theo Yêu Cầu Khách Hàng":
                case "Theo Yêu Cầu Công Ty":
                    txtNoiNhan.Text = "- Như trên.\r\n- Đội QLĐHN, Đội TT: để biết.\r\n- Đội TCTB: thực hiện.\r\n- Lưu.(" + txtMaDon.Text.Trim() + ")";
                    txtSoTien.Text = "";
                    break;
                case "Khách Hàng Không Sử Dụng Nước Máy Theo Cam Kết Ngày":
                    txtNoiNhan.Text = "- Như trên.\r\n- Đội TCTB: thực hiện.\r\n- Lưu.(" + txtMaDon.Text.Trim() + ")";
                    txtSoTien.Text = "";
                    break;
                case "Nợ Tiền Nước":
                    txtNoiNhan.Text = "- Như trên.\r\n- Đội TT: thông báo khách hàng.\r\n- Đội TCTB: thực hiện.\r\n- Lưu.(" + txtMaDon.Text.Trim() + ")";
                    txtSoTien.Text = "";
                    break;
                case "Nợ Tiền Gian Lận Nước":
                case "Không Thanh Toán Tiền Bồi Thường ĐHN":
                    txtNoiNhan.Text = "- Như trên\r\n- Đội QLĐHN: để biết.\r\n- Đội TCTB: thực hiện\r\n- Lưu.(" + txtMaDon.Text.Trim() + ")";
                    txtSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", 1283641);
                    break;
                default:
                    txtNoiNhan.Text = "";
                    txtSoTien.Text = "";
                    break;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctchdb != null)
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (!_ctchdb.DaLapPhieu)
                        {
                            if (_cCHDB.XoaCTCHDB(_ctchdb))
                            {
                                MessageBox.Show("Xóa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                        else
                            MessageBox.Show("Đã lập Phiếu, Không xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtDanhBo.Text = "";
                    txtHopDong.Text = "";
                    txtHoTen.Text = "";
                    txtDiaChi.Text = "";
                    _ttkhachhang = null;
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
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

        private void txtMaThongBaoCT_KeyPress(object sender, KeyPressEventArgs e)
        {

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
    }
}
