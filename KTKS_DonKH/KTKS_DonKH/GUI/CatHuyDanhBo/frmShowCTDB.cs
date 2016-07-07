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
    public partial class frmShowCTDB : Form
    {
        decimal _MaCTCTDB = 0;
        CCHDB _cCHDB = new CCHDB();
        CTCTDB _ctctdb = null;
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CTTKH _cTTKH = new CTTKH();
        TTKhachHang _ttkhachhang = null;
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CKTXM _cKTXM = new CKTXM();

        public frmShowCTDB()
        {
            InitializeComponent();
        }

        public frmShowCTDB(decimal MaCTCTDB)
        {
            InitializeComponent();
            _MaCTCTDB = MaCTCTDB;
        }

        public frmShowCTDB(decimal MaCTCTDB,bool TimKiem)
        {
            InitializeComponent();
            _MaCTCTDB = MaCTCTDB;
            if (TimKiem)
            {
                btnCapNhatCapTrenXuLy.Enabled = false;
                btnCapNhatTCTBXuLy.Enabled = false;
                btnIn.Enabled = false;
                btnSua.Enabled = false;
                txtHieuLucKy.ReadOnly = true;
                btnInPhieu.Enabled = false;
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

        private void frmShowCTDB_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70,50);
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

            if (_cCHDB.getCTCTDBbyID(_MaCTCTDB) != null)
            {
                _ctctdb = _cCHDB.getCTCTDBbyID(_MaCTCTDB);
                if (!string.IsNullOrEmpty(_ctctdb.CHDB.MaDonTXL.ToString()))
                    txtMaDon.Text = "TXL" + _ctctdb.CHDB.MaDonTXL.Value.ToString().Insert(_ctctdb.CHDB.MaDonTXL.Value.ToString().Length - 2, "-");
                else
                    if (!string.IsNullOrEmpty(_ctctdb.CHDB.MaDon.ToString()))
                        txtMaDon.Text = _ctctdb.CHDB.MaDon.Value.ToString().Insert(_ctctdb.CHDB.MaDon.Value.ToString().Length - 2, "-");
                txtMaThongBao.Text = _ctctdb.MaCTCTDB.ToString().Insert(_ctctdb.MaCTCTDB.ToString().Length - 2, "-");
                txtDanhBo.Text = _ctctdb.DanhBo;
                txtHopDong.Text = _ctctdb.HopDong;
                txtHoTen.Text = _ctctdb.HoTen;
                txtDiaChi.Text = _ctctdb.DiaChi;
                ///
                cmbLyDo.SelectedItem = _ctctdb.LyDo;
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
                    cmbNoiDung.SelectedIndex = -1;
                }

                txtNoiNhan.Text = _ctctdb.NoiNhan;

                dgvLichSuXuLy.DataSource = _cCHDB.LoadDSLichSuXuLyByMaCTCTDB(_ctctdb.MaCTCTDB);
                ///
                ///phải có if ở đây vì dateTCTBXuLy không nhận giá trị null
                //if (_ctctdb.TCTBXuLy)
                //{
                //    chkKetQuaTCTBXuLy.Checked = true;
                //    dateTCTBXuLy.Value = _ctctdb.NgayTCTBXuLy.Value;
                //    if (_ctctdb.TroNgai)
                //        chkTroNgai.Checked = true;
                //    else
                //        chkTroNgai.Checked = false;
                //    txtKetQuaTCTBXuLy.Text = _ctctdb.KetQuaTCTBXuLy;
                //}
                ///
                ///phải có if ở đây vì dateCapTrenXuLy không nhận giá trị null
                //if (_ctctdb.CapTrenXuLy)
                //{
                //    chkKetQuaCapTrenXuLy.Checked = true;
                //    dateCapTrenXuLy.Value = _ctctdb.NgayCapTrenXuLy.Value;
                //    txtKetQuaCapTrenXuLy.Text = _ctctdb.KetQuaCapTrenXuLy;
                //    txtThoiGianLapCatHuy.Text = _ctctdb.ThoiGianLapCatHuy.Value.ToString();
                //}
                ///
                if (_cCHDB.CheckYeuCauCHDBbyMaCTCTDB(_ctctdb.MaCTCTDB))
                {
                    txtHieuLucKy.Text = _ctctdb.YeuCauCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCTDB == _ctctdb.MaCTCTDB).HieuLucKy;
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_ctctdb != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                CTKTXM ctktxm = null;
                if (_ctctdb.CHDB.ToXuLy)
                {
                    ctktxm = _cKTXM.getCTKTXMbyMaDonTXLDanhBo(_ctctdb.CHDB.MaDonTXL.Value, _ctctdb.DanhBo);
                }
                else
                {
                    ctktxm = _cKTXM.getCTKTXMbyMaDonKHDanhBo(_ctctdb.CHDB.MaDon.Value, _ctctdb.DanhBo);
                }

                dr["SoPhieu"] = _ctctdb.MaCTCTDB.ToString().Insert(_ctctdb.MaCTCTDB.ToString().Length - 2, "-");
                dr["HoTen"] = _ctctdb.HoTen;
                dr["DiaChi"] = _ctctdb.DiaChi;
                if (!string.IsNullOrEmpty(_ctctdb.DanhBo))
                    dr["DanhBo"] = _ctctdb.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HopDong"] = _ctctdb.HopDong;

                if (ctktxm != null)
                    if (!string.IsNullOrEmpty(ctktxm.ViTriDHN1) || !string.IsNullOrEmpty(ctktxm.ViTriDHN2))
                        dr["ViTriDHN"] = "Vị trí ĐHN lắp đặt: " + ctktxm.ViTriDHN1 + ", " + ctktxm.ViTriDHN2;

                if (_ctctdb.LyDo != "Vấn Đề Khác")
                    dr["LyDo"] = _ctctdb.LyDo + ". ";
                if (_ctctdb.GhiChuLyDo != "")
                    dr["LyDo"] += _ctctdb.GhiChuLyDo + ". ";
                if (_ctctdb.SoTien.ToString() != "")
                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctctdb.SoTien);

                dr["NoiNhan"] = _ctctdb.NoiNhan;

                if (chkNgayXuLy.Checked)
                    dr["NgayXuLy"] = dateXuLy.Value.ToString("dd/MM/yyyy") + " : " + cmbNoiDung.SelectedItem.ToString();

                dr["ChucVu"] = _ctctdb.ChucVu;
                dr["NguoiKy"] = _ctctdb.NguoiKy;

                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                rptThongBaoCTDB rpt = new rptThongBaoCTDB();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void frmShowCTDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
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

                    if (!string.IsNullOrEmpty(cmbLyDo.SelectedItem.ToString()))
                        _ctctdb.LyDo = cmbLyDo.SelectedItem.ToString();
                    _ctctdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                    if (txtSoTien.Text.Trim() != "")
                        _ctctdb.SoTien = int.Parse(txtSoTien.Text.Trim().Replace(".", ""));
                    ///
                    if (chkNgayXuLy.Checked)
                    {
                        if (_ctctdb.NgayXuLy != dateXuLy.Value)
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
                if (_ctctdb != null)
                {
                    //_ctctdb.TCTBXuLy = true;
                    //_ctctdb.NgayTCTBXuLy = dateTCTBXuLy.Value;
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
                    YeuCauCHDB ycchdb = _cCHDB.getYeuCauCHDBbyMaCTCTDB(_ctctdb.MaCTCTDB);
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
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctctdb != null)
                {
                    CHDB chdb = _ctctdb.CHDB;
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (!_ctctdb.DaLapPhieu)
                        {
                            if (_cCHDB.XoaCTCTDB(_ctctdb))
                            {
                                if (chdb.CTCTDBs.Count == 0 && chdb.CTCHDBs.Count == 0)
                                    _cCHDB.XoaCHDB(chdb);
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
                    txtNoiNhan.Text = "- Như trên.\r\n- Đội TCTB: thực hiện.\r\n- Đội QLĐHN: để biết.\r\n- Lưu.(" + txtMaDon.Text.Trim() + ")";
                    txtSoTien.Text = "";
                    break;
                case "Nợ Tiền Nước":
                    txtNoiNhan.Text = "- Như trên.\r\n- Đội TT: gửi thông báo.\r\n- Đội TCTB: thực hiện. (Đội TT)\r\n- Lưu.(" + txtMaDon.Text.Trim() + ")";
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
    }
}
