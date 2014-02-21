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
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDCBD : Form
    {
        DonKH _donkh = null;
        TTKhachHang _ttkhachhang = null;
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        CTTKH _cTTKH = new CTTKH();
        CDCBD _cDCBD = new CDCBD();
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CDonKH _cDonKH = new CDonKH();
        CKTXM _cKTXM = new CKTXM();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        bool flagFirst = true;///Lần đầu Load Form (trường hợp 1 đơn nhiều Danh Bộ)
        bool _direct = false;///Mở form trực tiếp không qua Danh Sách Đơn

        public frmDCBD()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load Form trực tiếp không qua Danh Sách Đơn
        /// </summary>
        /// <param name="direct">true</param>
        public frmDCBD(bool direct)
        {
            InitializeComponent();
            _direct = direct;
        }

        public frmDCBD(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmDCBD_Load(object sender, EventArgs e)
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
            dgvDSSoDangKy.AutoGenerateColumns = false;
            dgvDSSoDangKy.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSChungTu.Font, FontStyle.Bold);
            //DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSSoDangKy.Columns["MaLCT"];
            //cmbColumn.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            //cmbColumn.DisplayMember = "TenLCT";
            //cmbColumn.ValueMember = "MaLCT";

            dgvDSDieuChinh.AutoGenerateColumns = false;
            dgvDSDieuChinh.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSChungTu.Font, FontStyle.Bold);

            dgvLichSuChungTu.AutoGenerateColumns = false;
            dgvLichSuChungTu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvLichSuChungTu.Font, FontStyle.Bold);

            dgvDSChungTu.AutoGenerateColumns = false;
            dgvDSChungTu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSChungTu.Font, FontStyle.Bold);
        }

        /// <summary>
        /// Nhận Entity TTKhachHang để điền vào textbox
        /// </summary>
        /// <param name="ttkhachhang"></param>
        public void LoadThongTin(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2;
            txtMSThue.Text = ttkhachhang.MSThue;
            txtGiaBieu.Text = ttkhachhang.GB;
            txtDinhMuc.Text = ttkhachhang.TGDM;
            txtSH.Text = ttkhachhang.SH;
            txtSX.Text = ttkhachhang.SX;
            txtDV.Text = ttkhachhang.DV;
            txtHCSN.Text = ttkhachhang.HCSN;

            dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(ttkhachhang.DanhBo);
            dgvDSDieuChinh.DataSource = _cDCBD.LoadDSDCbyDanhBo(ttkhachhang.DanhBo);

        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtMSThue.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtSH.Text = "";
            txtSX.Text = "";
            txtDV.Text = "";
            txtHCSN.Text = "";
            txtHieuLucKy.Text = "";
            chkCatMSThue.Checked = false;

            _ttkhachhang = null;
            dgvDSSoDangKy.DataSource = null;
        }

        private void dgvDSSoDangKy_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSSoDangKy.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
            if (bool.Parse(dgvDSSoDangKy.Rows[e.RowIndex].Cells["Cat"].Value.ToString()) == true)
                dgvDSSoDangKy.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSlateGray;
        }

        private void dgvDSSoDangKy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    sửaToolStripMenuItem.Enabled = true;
                    cắtChuyểnĐịnhMứcToolStripMenuItem.Enabled = true;
                }
                else
                {
                    sửaToolStripMenuItem.Enabled = false;
                    cắtChuyểnĐịnhMứcToolStripMenuItem.Enabled = false;
                }
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvDSSoDangKy.CurrentCell = dgvDSSoDangKy.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvDSSoDangKy_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvDSSoDangKy, new Point(e.X, e.Y));
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("MaDon", _donkh.MaDon.ToString());
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("HoTenKH", txtHoTen.Text.Trim());
            source.Add("DiaChiKH", txtDiaChi.Text.Trim());
            source.Add("MaLCT", "1");
            source.Add("MaCT", "");
            source.Add("DiaChi", "");
            source.Add("SoNKTong", "");
            source.Add("SoNKDangKy", "");
            source.Add("NgayHetHan", "");
            source.Add("ThoiHan", "");
            frmSoDK frm = new frmSoDK("Thêm", source);
            if (frm.ShowDialog() == DialogResult.OK)
                dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(_donkh.DanhBo);
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("MaDon", _donkh.MaDon.ToString());
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("MaLCT", dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString());
            source.Add("MaCT", dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString());
            source.Add("DiaChi", dgvDSSoDangKy.CurrentRow.Cells["DiaChi"].Value.ToString());
            source.Add("SoNKTong", dgvDSSoDangKy.CurrentRow.Cells["SoNKTong"].Value.ToString());
            source.Add("SoNKDangKy", dgvDSSoDangKy.CurrentRow.Cells["SoNKDangKy"].Value.ToString());
            source.Add("NgayHetHan", dgvDSSoDangKy.CurrentRow.Cells["NgayHetHan"].Value.ToString());
            source.Add("ThoiHan", dgvDSSoDangKy.CurrentRow.Cells["ThoiHan"].Value.ToString());
            frmSoDK frm = new frmSoDK("Sửa", source);
            if (frm.ShowDialog() == DialogResult.OK)
                dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(_donkh.DanhBo);
        }

        private void cắtChuyểnĐịnhMứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("MaDon", _donkh.MaDon.ToString());
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("HoTen", txtHoTen.Text.Trim());
            source.Add("DiaChi", txtDiaChi.Text.Trim());
            source.Add("MaLCT", dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString());
            source.Add("MaCT", dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString());
            source.Add("SoNKDangKy", dgvDSSoDangKy.CurrentRow.Cells["SoNKDangKy"].Value.ToString());
            frmCatChuyenDM frm = new frmCatChuyenDM(source);
            if (frm.ShowDialog() == DialogResult.OK)
                dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(_donkh.DanhBo);
        }

        private void nhậnĐịnhMứctoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("MaDon", _donkh.MaDon.ToString());
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("HoTen", txtHoTen.Text.Trim());
            source.Add("DiaChi", txtDiaChi.Text.Trim());
            frmNhanDM frm = new frmNhanDM(source);
            if (frm.ShowDialog() == DialogResult.OK)
                dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(_donkh.DanhBo);
        }

        private void dgvDSSoDangKy_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.ControlBox = false;
            contextMenuStrip1.Enabled = false;
        }

        private void dgvDSSoDangKy_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ///Hiện tại nếu check SoChinh mà exit bằng X thì dữ liệu không được lưu
            ///Sau khi check phải check qua chỗ khác mới lưu
            CTChungTu ctchungtu = _cChungTu.getCTChungTubyID(dgvDSSoDangKy["DanhBo", e.RowIndex].Value.ToString(), dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString());
            if (bool.Parse(dgvDSSoDangKy["SoChinh", e.RowIndex].Value.ToString()) != ctchungtu.SoChinh)
            {
                ctchungtu.SoChinh = bool.Parse(dgvDSSoDangKy["SoChinh", e.RowIndex].Value.ToString());
                _cChungTu.SuaCTChungTu(ctchungtu);
            }

            //if (bool.Parse(dgvDSSoDangKy["Cat", e.RowIndex].Value.ToString()) == true)
            //    ctchungtu.Cat = true;
            //else
            //    ctchungtu.Cat = false;

            this.ControlBox = true;
            contextMenuStrip1.Enabled = true;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                    LoadThongTin(_ttkhachhang);
                }
                else
                {
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_donkh!=null && _ttkhachhang != null && txtHieuLucKy.Text.Trim() != "")
            {
                ///Nếu DCBD chưa có thì thêm vào
                if (!_cDCBD.CheckDCBDbyMaDon(_donkh.MaDon))
                //if (flagFirst)
                {
                    DCBD dcbd = new DCBD();
                    dcbd.MaDon = _donkh.MaDon;
                    if (_direct)
                    {
                        ///mới check DonKH còn KTXM chưa
                        //string a, b, c;
                        //_cDonKH.GetInfobyMaDon(_donkh.MaDon, "DCBD", out a, out b, out c);
                        //_source.Add("MaNoiChuyenDen", a);
                        _source.Add("NoiChuyenDen", "");
                        //_source.Add("LyDoChuyenDen", c);
                    }
                    else
                    {
                        dcbd.MaNoiChuyenDen = decimal.Parse(_source["MaNoiChuyenDen"]);
                        dcbd.NoiChuyenDen = _source["NoiChuyenDen"];
                        dcbd.LyDoChuyenDen = _source["LyDoChuyenDen"];
                    }
                    if (_cDCBD.ThemDCBD(dcbd))
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
                        //_source.Add("MaDCBD", _cDCBD.getMaxMaDCBD().ToString());
                        //flagFirst = false;
                        if (_donkh.LyDoChuyen == "")
                            _donkh.LyDoChuyen = "DCBD";
                        else
                            _donkh.LyDoChuyen += ",DCBD";
                        _donkh.Nhan = true;
                        _cDonKH.SuaDonKH(_donkh);
                    }
                }
                ///Biến lưu Điều Chỉnh về gì (Họ Tên,Địa Chỉ,Định Mức,Giá Biểu,MSThuế)
                string ThongTin = "";
                ///Thêm CTDCBD
                CTDCBD ctdcbd = new CTDCBD();
                ctdcbd.MaDCBD = _cDCBD.getDCBDbyMaDon(_donkh.MaDon).MaDCBD;
                ctdcbd.DanhBo = txtDanhBo.Text.Trim();
                ctdcbd.HopDong = txtHopDong.Text.Trim();
                ctdcbd.HoTen = txtHoTen.Text.Trim();
                ctdcbd.DiaChi = txtDiaChi.Text.Trim();
                ctdcbd.MSThue = txtMSThue.Text.Trim();
                ctdcbd.GiaBieu = txtGiaBieu.Text.Trim();
                ctdcbd.DinhMuc = txtDinhMuc.Text.Trim();
                ctdcbd.SH = txtSH.Text.Trim();
                ctdcbd.SX = txtSX.Text.Trim();
                ctdcbd.DV = txtDV.Text.Trim();
                ctdcbd.HCSN = txtHCSN.Text.Trim();
                ctdcbd.Dot = _ttkhachhang.Dot;
                ctdcbd.Ky = _ttkhachhang.Ky;
                ctdcbd.Nam = _ttkhachhang.Nam;
                ///Họ Tên
                if (txtHoTen_BD.Text.Trim() != "")
                {
                    ThongTin += "Họ Tên. ";
                    ctdcbd.HoTen_BD = txtHoTen_BD.Text.Trim();
                }
                ///Địa Chỉ
                if (txtDiaChi_BD.Text.Trim() != "")
                {
                    ThongTin += "Địa Chỉ. ";
                    ctdcbd.DiaChi_BD = txtDiaChi_BD.Text.Trim();
                }
                ///Mã Số Thuế
                if (txtMSThue_BD.Text.Trim() != "")
                {
                    ThongTin += "MST. ";
                    ctdcbd.MSThue_BD = txtMSThue_BD.Text.Trim();
                }
                if (chkCatMSThue.Checked)
                {
                    ThongTin += "MST. ";
                    ctdcbd.CatMSThue = true;
                }
                ///Giá Biểu
                if (txtGiaBieu_BD.Text.Trim() != "")
                {
                    ThongTin += "GB. ";
                    ctdcbd.GiaBieu_BD = txtGiaBieu_BD.Text.Trim();
                }
                ///Định Mức
                if (txtDinhMuc_BD.Text.Trim() != "")
                {
                    ThongTin += "ĐM. ";
                    ctdcbd.DinhMuc_BD = txtDinhMuc_BD.Text.Trim();
                }
                ///SH
                if (txtSH_BD.Text.Trim() != "")
                    ctdcbd.SH_BD = txtSH_BD.Text.Trim();
                ///SX
                if (txtSX_BD.Text.Trim() != "")
                    ctdcbd.SX_BD = txtSX_BD.Text.Trim();
                ///DV
                if (txtDV_BD.Text.Trim() != "")
                    ctdcbd.DV_BD = txtDV_BD.Text.Trim();
                ///HCSN
                if (txtHCSN_BD.Text.Trim() != "")
                    ctdcbd.HCSN_BD = txtHCSN_BD.Text.Trim();

                ctdcbd.ThongTin = ThongTin;
                ctdcbd.HieuLucKy = txtHieuLucKy.Text.Trim();

                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                    ctdcbd.ChucVu = "GIÁM ĐỐC";
                else
                    ctdcbd.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                ctdcbd.NguoiKy = bangiamdoc.HoTen.ToUpper();

                if (_cDCBD.ThemCTDCBD(ctdcbd))
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                    dr["SoPhieu"] = _cDCBD.getMaxMaCTDCBD().ToString().Insert(_cDCBD.getMaxMaCTDCBD().ToString().Length - 2, "-");
                    dr["ThongTin"] = ctdcbd.ThongTin;
                    dr["HieuLucKy"] = ctdcbd.HieuLucKy;
                    dr["Dot"] = ctdcbd.Dot;
                    ///Hiện tại xử lý mã số thuế như vậy
                    if (chkCatMSThue.Checked)
                        dr["MSThue"] = "MST: Cắt MST";
                    if (txtMSThue_BD.Text.Trim() != "")
                        dr["MSThue"] = "MST: " + ctdcbd.MSThue_BD;
                    dr["DanhBo"] = ctdcbd.DanhBo;
                    dr["HopDong"] = ctdcbd.HopDong;
                    dr["HoTen"] = ctdcbd.HoTen;
                    dr["DiaChi"] = ctdcbd.DiaChi;
                    dr["GiaBieu"] = ctdcbd.GiaBieu;
                    dr["DinhMuc"] = ctdcbd.DinhMuc;
                    ///Biến Động
                    dr["HoTenBD"] = ctdcbd.HoTen_BD;
                    dr["DiaChiBD"] = ctdcbd.DiaChi_BD;
                    dr["GiaBieuBD"] = ctdcbd.GiaBieu_BD;
                    dr["DinhMucBD"] = ctdcbd.DinhMuc_BD;
                    ///Ký Tên
                    dr["ChucVu"] = ctdcbd.ChucVu;
                    dr["NguoiKy"] = ctdcbd.NguoiKy;

                    dsBaoCao.Tables["DCBD"].Rows.Add(dr);

                    rptPhieuDCBD rpt = new rptPhieuDCBD();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();

                    Clear();
                }
            }
            else
            {
                MessageBox.Show("Chưa có Mã Đơn/Danh Bộ/Hiệu Lực Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDCBD_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgvDSDonKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDieuChinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSChungTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSChungTu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSSoDangKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvDSChungTu.DataSource = _cChungTu.LoadDSCTChungTubyID(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString());
                dgvLichSuChungTu.DataSource = _cChungTu.LoadDSLichSuChungTubyID(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString());
            }
            catch (Exception)
            {

            }
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
                }
                else
                {
                    _donkh = null;
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
