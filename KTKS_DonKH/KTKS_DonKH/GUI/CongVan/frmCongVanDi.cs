using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CongVan;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CongVan;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.CongVan
{
    public partial class frmCongVanDi : Form
    {
        CCongVanDi _cCongVanDi = new CCongVanDi();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CKTXM _cKTXM = new CKTXM();
        CBamChi _cBamChi = new CBamChi();
        CDCBD _cDCBD = new CDCBD();
        CCHDB _cCHDB = new CCHDB();
        CTTTL _cTTTL = new CTTTL();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        bool _toxuly = false;
        decimal _madon = 0;

        public frmCongVanDi()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmCongVanDi_Load(object sender, EventArgs e)
        {
            dgvDSCongVan.AutoGenerateColumns = false;

            cmbTuGio.SelectedItem = "7";
            cmbDenGio.SelectedItem = DateTime.Now.Hour.ToString();

            DataTable dt1 = _cCongVanDi.GetDSNoiDung();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (DataRow item in dt1.Rows)
            {
                auto1.Add(item["NoiDung"].ToString());
            }
            txtNoiDung.AutoCompleteCustomSource = auto1;
        }

        public string GetTenTable()
        {
            string TenTable = "";
            if (cmbLoaiVanBan.SelectedIndex != -1)
            {
                switch (cmbLoaiVanBan.SelectedItem.ToString())
                {
                    case "Đơn Tổ Khách Hàng":
                        TenTable = "DonKH";
                        break;
                    case "Đơn Tổ Xử Lý":
                        TenTable = "DonTXL";
                        break;
                    case "Kiểm Tra Xác Minh":
                        TenTable = "CTKTXM";
                        break;
                    case "Bấm Chì":
                        TenTable = "CTBamChi";
                        break;
                    case "Điều Chỉnh Biến Động":
                        TenTable = "CTDCBD";
                        break;
                    case "Điều Chỉnh Hóa Đơn":
                        TenTable = "CTDCHD";
                        break;
                    case "Cắt Tạm Danh Bộ":
                        TenTable = "CTCTDB";
                        break;
                    case "Cắt Hủy Danh Bộ":
                        TenTable = "CTCHDB";
                        break;
                    case "Phiếu Hủy Danh Bộ":
                        TenTable = "PhieuCHDB";
                        break;
                    case "Thư Trả Lời":
                        TenTable = "CTTTTL";
                        break;
                    default:

                        break;
                }
            }
            return TenTable;
        }

        public void Clear()
        {
            lstMa.Items.Clear();
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            _toxuly = false;
            _madon = 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cmbLoaiVanBan.SelectedIndex != -1 && cmbNoiChuyen.SelectedIndex != -1)
                if (lstMa.Items.Count == 0)
                {
                    CongVanDi item = new CongVanDi();
                    item.LoaiVanBan = cmbLoaiVanBan.SelectedItem.ToString();
                    item.TenTable = GetTenTable();
                    item.Ma = txtTuMa.Text.Trim().Replace("-", "");
                    item.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    item.HoTen = txtHoTen.Text.Trim();
                    item.DiaChi = txtDiaChi.Text.Trim();
                    item.NoiDung = txtNoiDung.Text.Trim();
                    item.NoiChuyen = cmbNoiChuyen.SelectedItem.ToString();
                    item.ToXuLy = _toxuly;
                    if (_toxuly)
                        item.MaDonTXL = _madon;
                    else
                        item.MaDon = _madon;
                    if (!_cCongVanDi.CheckExist(item.LoaiVanBan, item.Ma, item.NoiChuyen, DateTime.Now))
                    {
                        if (_cCongVanDi.Them(item))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
                    }
                    else
                            MessageBox.Show("Đã có: "+item.Ma, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (ListViewItem itemMa in lstMa.Items)
                    {
                        CongVanDi item = new CongVanDi();
                        item.LoaiVanBan = cmbLoaiVanBan.SelectedItem.ToString();
                        item.TenTable = GetTenTable();
                        item.Ma = itemMa.Text.Replace("-", "");
                        switch (cmbLoaiVanBan.SelectedItem.ToString())
                        {
                            case "Đơn Tổ Khách Hàng":
                                DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = donkh.DanhBo;
                                item.HoTen = donkh.HoTen;
                                item.DiaChi = donkh.DiaChi;
                                _toxuly = false;
                                _madon = donkh.MaDon;
                                break;
                            case "Đơn Tổ Xử Lý":
                                DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = dontxl.DanhBo;
                                item.HoTen = dontxl.HoTen;
                                item.DiaChi = dontxl.DiaChi;
                                _toxuly = true;
                                _madon = dontxl.MaDon;
                                break;
                            case "Kiểm Tra Xác Minh":
                                CTKTXM ctktxm = _cKTXM.getCTKTXMbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = ctktxm.DanhBo;
                                item.HoTen = ctktxm.HoTen;
                                item.DiaChi = ctktxm.DiaChi;
                                _toxuly = ctktxm.KTXM.ToXuLy;
                                if (ctktxm.KTXM.ToXuLy)
                                    _madon = ctktxm.KTXM.MaDonTXL.Value;
                                else
                                    _madon = ctktxm.KTXM.MaDon.Value;
                                break;
                            case "Bấm Chì":
                                CTBamChi ctbamchi = _cBamChi.getCTBamChibyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = ctbamchi.DanhBo;
                                item.HoTen = ctbamchi.HoTen;
                                item.DiaChi = ctbamchi.DiaChi;
                                _toxuly = ctbamchi.BamChi.ToXuLy;
                                if (ctbamchi.BamChi.ToXuLy)
                                    _madon = ctbamchi.BamChi.MaDonTXL.Value;
                                else
                                    _madon = ctbamchi.BamChi.MaDon.Value;
                                break;
                            case "Điều Chỉnh Biến Động":
                                CTDCBD dcbd = _cDCBD.getCTDCBDbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = dcbd.DanhBo;
                                item.HoTen = dcbd.HoTen;
                                item.DiaChi = dcbd.DiaChi;
                                _toxuly = dcbd.DCBD.ToXuLy;
                                if (dcbd.DCBD.ToXuLy)
                                    _madon = dcbd.DCBD.MaDonTXL.Value;
                                else
                                    _madon = dcbd.DCBD.MaDon.Value;
                                break;
                            case "Điều Chỉnh Hóa Đơn":
                                CTDCHD dchd = _cDCBD.getCTDCHDbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = dchd.DanhBo;
                                item.HoTen = dchd.HoTen;
                                item.DiaChi = dchd.DiaChi;
                                _toxuly = dchd.DCBD.ToXuLy;
                                if (dchd.DCBD.ToXuLy)
                                    _madon = dchd.DCBD.MaDonTXL.Value;
                                else
                                    _madon = dchd.DCBD.MaDon.Value;
                                break;
                            case "Cắt Tạm Danh Bộ":
                                CTCTDB ctctdb = _cCHDB.getCTCTDBbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = ctctdb.DanhBo;
                                item.HoTen = ctctdb.HoTen;
                                item.DiaChi = ctctdb.DiaChi;
                                _toxuly = ctctdb.CHDB.ToXuLy;
                                if (ctctdb.CHDB.ToXuLy)
                                    _madon = ctctdb.CHDB.MaDonTXL.Value;
                                else
                                    _madon = ctctdb.CHDB.MaDon.Value;
                                break;
                            case "Cắt Hủy Danh Bộ":
                                CTCHDB ctchdb = _cCHDB.getCTCHDBbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = ctchdb.DanhBo;
                                item.HoTen = ctchdb.HoTen;
                                item.DiaChi = ctchdb.DiaChi;
                                _toxuly = ctchdb.CHDB.ToXuLy;
                                if (ctchdb.CHDB.ToXuLy)
                                    _madon = ctchdb.CHDB.MaDonTXL.Value;
                                else
                                    _madon = ctchdb.CHDB.MaDon.Value;
                                break;
                            case "Phiếu Hủy Danh Bộ":
                                PhieuCHDB ycchdb = _cCHDB.getYeuCauCHDbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = ycchdb.DanhBo;
                                item.HoTen = ycchdb.HoTen;
                                item.DiaChi = ycchdb.DiaChi;
                                _toxuly = ycchdb.ToXuLy;
                                if (ycchdb.ToXuLy)
                                    _madon = ycchdb.MaDonTXL.Value;
                                else
                                    _madon = ycchdb.MaDon.Value;
                                break;
                            case "Thư Trả Lời":
                                CTTTTL cttttl = _cTTTL.GetCTByID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = cttttl.DanhBo;
                                item.HoTen = cttttl.HoTen;
                                item.DiaChi = cttttl.DiaChi;
                                _toxuly = cttttl.TTTL.ToXuLy;
                                if (cttttl.TTTL.ToXuLy)
                                    _madon = cttttl.TTTL.MaDonTXL.Value;
                                else
                                    _madon = cttttl.TTTL.MaDon.Value;
                                break;
                            default:

                                break;
                        }
                        item.NoiDung = txtNoiDung.Text.Trim();
                        item.NoiChuyen = cmbNoiChuyen.SelectedItem.ToString();
                        item.ToXuLy = _toxuly;
                        if (_toxuly)
                            item.MaDonTXL = _madon;
                        else
                            item.MaDon = _madon;
                        if (!_cCongVanDi.CheckExist(item.LoaiVanBan, item.Ma, item.NoiChuyen, DateTime.Now))
                            _cCongVanDi.Them(item);
                        else
                            MessageBox.Show("Đã có: "+item.Ma, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Clear();
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoiDungTimKiem.Text.Trim()))
            dgvDSCongVan.DataSource = _cCongVanDi.GetDS(dateTu.Value, int.Parse(cmbTuGio.SelectedItem.ToString()), dateDen.Value, int.Parse(cmbDenGio.SelectedItem.ToString()));
            else
                switch (cmbTimKiem.SelectedItem.ToString())
                {
                    case "Danh Bộ":
                        if (txtNoiDungTimKiem.Text.Trim().Length == 11)
                        {
                            dgvDSCongVan.DataSource = _cCongVanDi.GetDS(txtNoiDungTimKiem.Text.Trim());
                        }
                        break;
                    case "Mã Đơn/TB":
                        dgvDSCongVan.DataSource = _cCongVanDi.GetDS_Ma(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                        break;
                    default:
                        break;
                }
        }

        private void txtTuMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbLoaiVanBan.SelectedIndex != -1&&txtTuMa.Text.Trim().Replace("-", "").Length > 2 && e.KeyChar == 13)
            {
                switch (cmbLoaiVanBan.SelectedItem.ToString())
                {
                    case "Đơn Tổ Khách Hàng":
                        DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = donkh.DanhBo;
                        txtHoTen.Text = donkh.HoTen;
                        txtDiaChi.Text = donkh.DiaChi;
                        _madon = donkh.MaDon;
                        break;
                    case "Đơn Tổ Xử Lý":
                        DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = dontxl.DanhBo;
                        txtHoTen.Text = dontxl.HoTen;
                        txtDiaChi.Text = dontxl.DiaChi;
                        _madon = dontxl.MaDon;
                        break;
                    case "Kiểm Tra Xác Minh":
                        CTKTXM ctktxm = _cKTXM.getCTKTXMbyID(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ctktxm.DanhBo;
                        txtHoTen.Text = ctktxm.HoTen;
                        txtDiaChi.Text = ctktxm.DiaChi;
                        _toxuly = ctktxm.KTXM.ToXuLy;
                        if (ctktxm.KTXM.ToXuLy)
                            _madon = ctktxm.KTXM.MaDonTXL.Value;
                        else
                            _madon = ctktxm.KTXM.MaDon.Value;
                        break;
                    case "Bấm Chì":
                        CTBamChi ctbamchi = _cBamChi.getCTBamChibyID(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ctbamchi.DanhBo;
                        txtHoTen.Text = ctbamchi.HoTen;
                        txtDiaChi.Text = ctbamchi.DiaChi;
                        _toxuly = ctbamchi.BamChi.ToXuLy;
                        if (ctbamchi.BamChi.ToXuLy)
                            _madon = ctbamchi.BamChi.MaDonTXL.Value;
                        else
                            _madon = ctbamchi.BamChi.MaDon.Value;
                        break;
                    case "Điều Chỉnh Biến Động":
                        CTDCBD dcbd = _cDCBD.getCTDCBDbyID(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = dcbd.DanhBo;
                        txtHoTen.Text = dcbd.HoTen;
                        txtDiaChi.Text = dcbd.DiaChi;
                        _toxuly = dcbd.DCBD.ToXuLy;
                        if (dcbd.DCBD.ToXuLy)
                            _madon = dcbd.DCBD.MaDonTXL.Value;
                        else
                            _madon = dcbd.DCBD.MaDon.Value;
                        break;
                    case "Điều Chỉnh Hóa Đơn":
                        CTDCHD dchd = _cDCBD.getCTDCHDbyID(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = dchd.DanhBo;
                        txtHoTen.Text = dchd.HoTen;
                        txtDiaChi.Text = dchd.DiaChi;
                        _toxuly = dchd.DCBD.ToXuLy;
                        if (dchd.DCBD.ToXuLy)
                            _madon = dchd.DCBD.MaDonTXL.Value;
                        else
                            _madon = dchd.DCBD.MaDon.Value;
                        break;
                    case "Cắt Tạm Danh Bộ":
                        CTCTDB ctctdb = _cCHDB.getCTCTDBbyID(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ctctdb.DanhBo;
                        txtHoTen.Text = ctctdb.HoTen;
                        txtDiaChi.Text = ctctdb.DiaChi;
                        _toxuly = ctctdb.CHDB.ToXuLy;
                        if (ctctdb.CHDB.ToXuLy)
                            _madon = ctctdb.CHDB.MaDonTXL.Value;
                        else
                            _madon = ctctdb.CHDB.MaDon.Value;
                        break;
                    case "Cắt Hủy Danh Bộ":
                        CTCHDB ctchdb = _cCHDB.getCTCHDBbyID(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ctchdb.DanhBo;
                        txtHoTen.Text = ctchdb.HoTen;
                        txtDiaChi.Text = ctchdb.DiaChi;
                        _toxuly = ctchdb.CHDB.ToXuLy;
                        if (ctchdb.CHDB.ToXuLy)
                            _madon = ctchdb.CHDB.MaDonTXL.Value;
                        else
                            _madon = ctchdb.CHDB.MaDon.Value;
                        break;
                    case "Phiếu Hủy Danh Bộ":
                        PhieuCHDB ycchdb = _cCHDB.getYeuCauCHDbyID(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ycchdb.DanhBo;
                        txtHoTen.Text = ycchdb.HoTen;
                        txtDiaChi.Text = ycchdb.DiaChi;
                        _toxuly = ycchdb.ToXuLy;
                        if (ycchdb.ToXuLy)
                            _madon = ycchdb.MaDonTXL.Value;
                        else
                            _madon = ycchdb.MaDon.Value;
                        break;
                    case "Thư Trả Lời":
                        CTTTTL cttttl = _cTTTL.GetCTByID(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = cttttl.DanhBo;
                        txtHoTen.Text = cttttl.HoTen;
                        txtDiaChi.Text = cttttl.DiaChi;
                        _toxuly = cttttl.TTTL.ToXuLy;
                        if (cttttl.TTTL.ToXuLy)
                            _madon = cttttl.TTTL.MaDonTXL.Value;
                        else
                            _madon = cttttl.TTTL.MaDon.Value;
                        break;
                    default:

                        break;
                }
            }
        }

        private void txtDenMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbLoaiVanBan.SelectedIndex != -1 && txtTuMa.Text.Trim().Replace("-", "").Length > 2 && txtDenMa.Text.Trim().Replace("-", "").Length > 2 && e.KeyChar == 13)
                if (txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2) == txtDenMa.Text.Trim().Replace("-", "").Substring(txtDenMa.Text.Trim().Replace("-", "").Length - 2, 2))
                {
                    int TuMa = int.Parse(txtTuMa.Text.Trim().Replace("-", "").Substring(0, txtTuMa.Text.Trim().Replace("-", "").Length - 2));
                    int DenMa = int.Parse(txtDenMa.Text.Trim().Replace("-", "").Substring(0, txtDenMa.Text.Trim().Replace("-", "").Length - 2));
                    while (TuMa <= DenMa)
                    {
                        switch (cmbLoaiVanBan.SelectedItem.ToString())
                        {
                            case "Đơn Tổ Khách Hàng":
                                if (_cDonKH.CheckExist(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                    lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                break;
                            case "Đơn Tổ Xử Lý":
                                if (_cDonTXL.CheckExist(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                    lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                break;
                            case "Kiểm Tra Xác Minh":
                                break;
                            case "Bấm Chì":
                                break;
                            case "Điều Chỉnh Biến Động":
                                if (_cDCBD.CheckExist_DCBD(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                    lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                break;
                            case "Điều Chỉnh Hóa Đơn":
                                if (_cDCBD.CheckExist_DCHD(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                    lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                break;
                            case "Cắt Tạm Danh Bộ":
                                if (_cCHDB.CheckCTCTDBbyID(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                    lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                break;
                            case "Cắt Hủy Danh Bộ":
                                if (_cCHDB.CheckCTCHDBByMaCTCHDB(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                    lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                break;
                            case "Phiếu Hủy Danh Bộ":
                                if (_cCHDB.CheckExist_PhieuHuy(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                    lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                break;
                            case "Thư Trả Lời":
                                if (_cTTTL.CheckExist(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                    lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                break;
                            default:

                                break;
                        }
                        //lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                        TuMa++;
                    }
                }
                else
                {
                    MessageBox.Show("Từ Mã, Đến Mã phải cùng 1 năm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvDSCongVan.SelectedRows)
            {
                CongVanDi congvandi = _cCongVanDi.Get(int.Parse(item.Cells["ID"].Value.ToString()));
                _cCongVanDi.Xoa(congvandi);
            }
            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnXem.PerformClick();
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

        private void dgvDSCongVan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSCongVan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataGridViewRow item in dgvDSCongVan.Rows)
            {
                DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["LoaiVanBan"] = item.Cells["LoaiVanBan"].Value.ToString();
                if (item.Cells["Ma"].Value.ToString().Length > 2)
                    dr["Ma"] = item.Cells["Ma"].Value.ToString().Insert(item.Cells["Ma"].Value.ToString().Length - 2, "-");
                dr["CreateDate"] = item.Cells["CreateDate"].Value.ToString();
                if (item.Cells["DanhBo"].Value.ToString().Length == 11)
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                dr["NoiChuyen"] = item.Cells["NoiChuyen"].Value.ToString();
                dr["NoiDung"] = item.Cells["NoiDung"].Value.ToString();
                dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            }
            rptDSCongVan rpt = new rptDSCongVan();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvDSCongVan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSCongVan.Columns[e.ColumnIndex].Name == "Ma" && e.Value != null && e.Value.ToString().Length > 2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDanhBo.Text.Trim().Length == 11 && e.KeyChar == 13)
            {
                HOADON hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                txtDanhBo.Text = hoadon.DANHBA;
                txtHoTen.Text = hoadon.TENKH;
                txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
            }
        }

        private void cmbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

       

    }
}
