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

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmShowCHDB : Form
    {
        decimal _MaCTCHDB = 0;
        CCHDB _cCHDB = new CCHDB();
        CTCHDB _ctchdb = null;
        CTTKH _cTTKH = new CTTKH();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();

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
            }
        }

        private void frmShowCHDB_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
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
                ///
                ///phải có if ở đây vì dateTCTBXuLy không nhận giá trị null
                if (_ctchdb.TCTBXuLy)
                {
                    dateTCTBXuLy.Value = _ctchdb.NgayTCTBXuLy.Value;
                    txtKetQuaTCTBXuLy.Text = _ctchdb.KetQuaTCTBXuLy;
                }
                ///
                ///phải có if ở đây vì dateCapTrenXuLy không nhận giá trị null
                if (_ctchdb.CapTrenXuLy)
                {
                    dateCapTrenXuLy.Value = _ctchdb.NgayCapTrenXuLy.Value;
                    txtKetQuaCapTrenXuLy.Text = _ctchdb.KetQuaCapTrenXuLy;
                    txtThoiGianLapPhieu.Text = _ctchdb.ThoiGianLapPhieu.Value.ToString();
                }
                ///
                if (_cCHDB.CheckYeuCauCHDBbyMaCTCHDB(_ctchdb.MaCTCHDB))
                {
                    txtHieuLucKy.Text = _ctchdb.YeuCauCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaCTCHDB == _ctchdb.MaCTCHDB).HieuLucKy;
                }
            }
        }

        private void frmShowCHDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_ctchdb != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                dr["SoPhieu"] = _ctchdb.MaCTCHDB.ToString().Insert(_ctchdb.MaCTCHDB.ToString().Length-2, "-");
                dr["HoTen"] = _ctchdb.HoTen;
                dr["DiaChi"] = _ctchdb.DiaChi;
                dr["DanhBo"] = _ctchdb.DanhBo.Insert(7, " ").Insert(4, " "); ;
                dr["HopDong"] = _ctchdb.HopDong;
                if (_ctchdb.LyDo != "Vấn Đề Khác")
                    dr["LyDo"] = _ctchdb.LyDo + ". ";
                if (_ctchdb.GhiChuLyDo != "")
                    dr["LyDo"] += _ctchdb.GhiChuLyDo + ". ";
                if (_ctchdb.SoTien.ToString() != "")
                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", _ctchdb.SoTien);
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
                    if (txtMaThongBaoCT.Text.Trim().Replace("-", "") != "")
                        _ctchdb.MaCTCTDB = decimal.Parse(txtMaThongBaoCT.Text.Trim().Replace("-", ""));

                    if (!string.IsNullOrEmpty(cmbLyDo.SelectedItem.ToString()))
                        _ctchdb.LyDo = cmbLyDo.SelectedItem.ToString();
                    _ctchdb.GhiChuLyDo = txtGhiChuXuLy.Text.Trim();
                    if (txtSoTien.Text.Trim() != "")
                        _ctchdb.SoTien = int.Parse(txtSoTien.Text.Trim());
                    else
                        _ctchdb.SoTien = null;

                    //if (_ctchdb.TCTBXuLy != chkKetQuaTCTBXuLy.Checked)
                        if (chkKetQuaTCTBXuLy.Checked)
                        {
                            _ctchdb.TCTBXuLy = true;
                            _ctchdb.NgayTCTBXuLy = dateTCTBXuLy.Value;
                            if (chkTroNgai.Checked)
                                _ctchdb.TroNgai = true;
                            else
                                _ctchdb.TroNgai = false;
                            if (chkCatTam.Checked)
                                _ctchdb.CatTam = true;
                            else
                                _ctchdb.CatTam = false;
                            _ctchdb.KetQuaTCTBXuLy = txtKetQuaTCTBXuLy.Text.Trim();
                        }
                        else
                        {
                            _ctchdb.TCTBXuLy = false;
                            _ctchdb.NgayTCTBXuLy = null;
                            _ctchdb.TroNgai = false;
                            _ctchdb.CatTam = false;
                            _ctchdb.KetQuaTCTBXuLy = null;
                        }

                    //if (_ctchdb.CapTrenXuLy != chkKetQuaCapTrenXuLy.Checked)
                        if (chkKetQuaCapTrenXuLy.Checked)
                        {
                            _ctchdb.CapTrenXuLy = true;
                            _ctchdb.NgayCapTrenXuLy = dateCapTrenXuLy.Value;
                            _ctchdb.KetQuaCapTrenXuLy = txtKetQuaCapTrenXuLy.Text.Trim();
                            _ctchdb.ThoiGianLapPhieu = int.Parse(txtThoiGianLapPhieu.Text.Trim());
                        }
                        else
                        {
                            _ctchdb.CapTrenXuLy = false;
                            _ctchdb.NgayCapTrenXuLy = null;
                            _ctchdb.KetQuaCapTrenXuLy = null;
                            _ctchdb.ThoiGianLapPhieu = null;
                        }

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
                    _ctchdb.TCTBXuLy = true;
                    _ctchdb.NgayTCTBXuLy = dateTCTBXuLy.Value;
                    _ctchdb.KetQuaTCTBXuLy = txtKetQuaTCTBXuLy.Text.Trim();
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
            if (cmbLyDo.SelectedItem.ToString().ToUpper().Contains("TIỀN"))
                txtSoTien.ReadOnly = false;
            else
                txtSoTien.ReadOnly = true;
        }

        private void chkKetQuaTCTBXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKetQuaTCTBXuLy.Checked)
                groupBoxKetQuaTCTBXuLy.Enabled = true;
            else
                groupBoxKetQuaTCTBXuLy.Enabled = false;
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
                            if (_cCHDB.SuaCTCHDB(_ctchdb))
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
    }
}
