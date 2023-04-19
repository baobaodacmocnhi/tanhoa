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
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CongVan;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.DAL.TruyThu;
using KTKS_DonKH.DAL.VanBan;
using KTKS_DonKH.DAL.ThuMoi;

namespace KTKS_DonKH.GUI.CongVan
{
    public partial class frmCongVanDi : Form
    {
        CCongVanDi _cCongVanDi = new CCongVanDi();
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CKTXM _cKTXM = new CKTXM();
        CBamChi _cBamChi = new CBamChi();
        CDCBD _cDCBD = new CDCBD();
        CCHDB _cCHDB = new CCHDB();
        CTTTL _cTTTL = new CTTTL();
        CGianLan _cGL = new CGianLan();
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();
        CVanBan _cVanBan = new CVanBan();
        CThuMoi _cThuMoi = new CThuMoi();
        CToTrinh _cToTrinh = new CToTrinh();
        CThuTien _cThuTien = new CThuTien();
        CDHN _cDocSo = new CDHN();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CTo _cTo = new CTo();

        public frmCongVanDi()
        {
            InitializeComponent();
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

            cmbNoiChuyen.DataSource = _cNoiChuyen.GetDS("DonTuChuyen");
            cmbNoiChuyen.ValueMember = "ID";
            cmbNoiChuyen.DisplayMember = "Name";

            cmbNoiChuyen_Moi.DataSource = _cNoiChuyen.GetDS("DonTuChuyen");
            cmbNoiChuyen_Moi.ValueMember = "ID";
            cmbNoiChuyen_Moi.DisplayMember = "Name";

            cmbNoiNhan_Moi.DataSource = _cNoiChuyen.GetDS("DonTuNhan");
            cmbNoiNhan_Moi.ValueMember = "ID";
            cmbNoiNhan_Moi.DisplayMember = "Name";

            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.KyHieuMaTo == "ToGD")
            {
                cmbTo.DataSource = _cTo.getDS_KTXM();
                cmbTo.ValueMember = "KyHieu";
                cmbTo.DisplayMember = "TenTo";
                panelTo.Visible = true;
            }
            else
            {
                panelTo.Visible = false;
            }
        }

        public string GetTenTable()
        {
            string TenTable = "";
            if (cmbLoaiVanBan.SelectedIndex != -1)
            {
                switch (cmbLoaiVanBan.SelectedItem.ToString())
                {
                    case "Đơn Từ Mới":
                        TenTable = "DonTu";
                        break;
                    case "Đơn Tổ Khách Hàng":
                        TenTable = "DonKH";
                        break;
                    case "Đơn Tổ Xử Lý":
                        TenTable = "DonTXL";
                        break;
                    case "Kiểm Tra Xác Minh":
                        TenTable = "KTXM_ChiTiet";
                        break;
                    case "Bấm Chì":
                        TenTable = "BamChi_ChiTiet";
                        break;
                    case "Điều Chỉnh Biến Động":
                        TenTable = "DCBD_ChiTietBienDong";
                        break;
                    case "Điều Chỉnh Hóa Đơn":
                        TenTable = "DCBD_ChiTietHoaDon";
                        break;
                    case "Cắt Tạm Danh Bộ":
                        TenTable = "CHDB_ChiTietCatTam";
                        break;
                    case "Cắt Hủy Danh Bộ":
                        TenTable = "CHDB_ChiTietCatHuy";
                        break;
                    case "Phiếu Hủy Danh Bộ":
                        TenTable = "CHDB_Phieu";
                        break;
                    case "Thư Trả Lời":
                        TenTable = "ThuTraLoi_ChiTiet";
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
            chkNgayLap.Checked = false;
            chkKTXM.Checked = false;
            chkToTrinh.Checked = false;
            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                chkcmbNoiNhan.Properties.Items[i].CheckState = CheckState.Unchecked;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cmbLoaiVanBan.SelectedIndex != -1)
                if (lstMa.Items.Count == 0)
                {
                    for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                        if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            CongVanDi item = new CongVanDi();
                            item.LoaiVanBan = cmbLoaiVanBan.SelectedItem.ToString();
                            item.TenTable = GetTenTable();
                            item.Ma = txtTuMa.Text.Trim().Replace("-", "");
                            item.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                            item.HoTen = txtHoTen.Text.Trim();
                            item.DiaChi = txtDiaChi.Text.Trim();
                            item.NoiDung = txtNoiDung.Text.Trim();
                            item.NoiChuyen = chkcmbNoiNhan.Properties.Items[i].ToString();
                            item.KTXM = chkKTXM.Checked;
                            item.ToTrinh = chkToTrinh.Checked;
                            if (txtTuMa.Text.Trim().Replace("-", "") != "")
                                if (!_cCongVanDi.CheckExist(item.LoaiVanBan, item.Ma, item.NoiChuyen, DateTime.Now))
                                {
                                    if (chkNgayLap.Checked)
                                    {
                                        if (_cCongVanDi.Them(item, dateNgayLap.Value))
                                        {
                                            //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //Clear();
                                            //btnXem.PerformClick();
                                        }
                                    }
                                    else
                                    {
                                        if (_cCongVanDi.Them(item))
                                        {
                                            //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //Clear();
                                            //btnXem.PerformClick();
                                        }
                                    }
                                }
                                else
                                    MessageBox.Show("Đã có: " + item.Ma, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                if (chkNgayLap.Checked)
                                {
                                    if (_cCongVanDi.Them(item, dateNgayLap.Value))
                                    {
                                        //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //Clear();
                                        //btnXem.PerformClick();
                                    }
                                }
                                else
                                {
                                    if (_cCongVanDi.Them(item))
                                    {
                                        //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //Clear();
                                        //btnXem.PerformClick();
                                    }
                                }
                        }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    btnXem.PerformClick();
                }
                else
                {
                    foreach (ListViewItem itemMa in lstMa.Items)
                    {
                        for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                            if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                CongVanDi item = new CongVanDi();
                                item.LoaiVanBan = cmbLoaiVanBan.SelectedItem.ToString();
                                item.TenTable = GetTenTable();
                                item.Ma = itemMa.Text.Replace("-", "");

                                switch (cmbLoaiVanBan.SelectedItem.ToString())
                                {
                                    case "Đơn Từ Mới":
                                        LinQ.DonTu_ChiTiet dontu_ChiTiet = null;
                                        if (txtTuMa.Text.Trim().Contains(".") == true)
                                        {
                                            string[] MaDons = txtTuMa.Text.Trim().Split('.');
                                            dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                                        }
                                        else
                                        {
                                            //dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(txtTuMa.Text.Trim()), 1);
                                            //if (dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count > 1)
                                            //{
                                            //    MessageBox.Show("Đơn Công Văn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            //    return;
                                            //}
                                        }
                                        if (dontu_ChiTiet != null)
                                        {
                                            item.DanhBo = dontu_ChiTiet.DanhBo;
                                            item.HoTen = dontu_ChiTiet.HoTen;
                                            item.DiaChi = dontu_ChiTiet.DiaChi;
                                        }
                                        break;
                                    case "Đơn Tổ Khách Hàng":
                                        DonKH donkh = _cDonKH.Get(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                        item.DanhBo = donkh.DanhBo;
                                        item.HoTen = donkh.HoTen;
                                        item.DiaChi = donkh.DiaChi;
                                        break;
                                    case "Đơn Tổ Xử Lý":
                                        DonTXL dontxl = _cDonTXL.Get(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                        item.DanhBo = dontxl.DanhBo;
                                        item.HoTen = dontxl.HoTen;
                                        item.DiaChi = dontxl.DiaChi;
                                        break;
                                    case "Đơn Tổ Bấm Chì":
                                        DonTBC dontbc = _cDonTBC.Get(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                        item.DanhBo = dontbc.DanhBo;
                                        item.HoTen = dontbc.HoTen;
                                        item.DiaChi = dontbc.DiaChi;
                                        break;
                                    case "Kiểm Tra Xác Minh":
                                        KTXM_ChiTiet ctktxm = _cKTXM.GetCT(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                        item.DanhBo = ctktxm.DanhBo;
                                        item.HoTen = ctktxm.HoTen;
                                        item.DiaChi = ctktxm.DiaChi;
                                        break;
                                    case "Bấm Chì":
                                        BamChi_ChiTiet ctbamchi = _cBamChi.GetCT(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                        item.DanhBo = ctbamchi.DanhBo;
                                        item.HoTen = ctbamchi.HoTen;
                                        item.DiaChi = ctbamchi.DiaChi;
                                        break;
                                    case "Điều Chỉnh Biến Động":
                                        DCBD_ChiTietBienDong dcbd = _cDCBD.getBienDong(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                        item.DanhBo = dcbd.DanhBo;
                                        item.HoTen = dcbd.HoTen;
                                        item.DiaChi = dcbd.DiaChi;
                                        break;
                                    case "Điều Chỉnh Hóa Đơn":
                                        DCBD_ChiTietHoaDon dchd = _cDCBD.getHoaDon(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                        item.DanhBo = dchd.DanhBo;
                                        item.HoTen = dchd.HoTen;
                                        item.DiaChi = dchd.DiaChi;
                                        break;
                                    case "Cắt Tạm Danh Bộ":
                                        CHDB_ChiTietCatTam ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                        item.DanhBo = ctctdb.DanhBo;
                                        item.HoTen = ctctdb.HoTen;
                                        item.DiaChi = ctctdb.DiaChi;
                                        break;
                                    case "Cắt Hủy Danh Bộ":
                                        CHDB_ChiTietCatHuy ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                        item.DanhBo = ctchdb.DanhBo;
                                        item.HoTen = ctchdb.HoTen;
                                        item.DiaChi = ctchdb.DiaChi;
                                        break;
                                    case "Phiếu Hủy Danh Bộ":
                                        CHDB_Phieu ycchdb = _cCHDB.GetPhieuHuy(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                        item.DanhBo = ycchdb.DanhBo;
                                        item.HoTen = ycchdb.HoTen;
                                        item.DiaChi = ycchdb.DiaChi;
                                        break;
                                    case "Thư Trả Lời":
                                        ThuTraLoi_ChiTiet cttttl = _cTTTL.GetCT(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                        item.DanhBo = cttttl.DanhBo;
                                        item.HoTen = cttttl.HoTen;
                                        item.DiaChi = cttttl.DiaChi;
                                        break;
                                    default:

                                        break;
                                }
                                item.NoiDung = txtNoiDung.Text.Trim();
                                item.NoiChuyen = chkcmbNoiNhan.Properties.Items[i].ToString();

                                if (!_cCongVanDi.CheckExist(item.LoaiVanBan, item.Ma, item.NoiChuyen, DateTime.Now))
                                {
                                    if (chkNgayLap.Checked)
                                    {
                                        _cCongVanDi.Them(item, dateNgayLap.Value);
                                    }
                                    else
                                    {
                                        _cCongVanDi.Them(item);
                                    }
                                }
                                else
                                    MessageBox.Show("Đã có: " + item.Ma, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    btnXem.PerformClick();
                }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (chkCreateBy.Checked == true)
            {
                if (string.IsNullOrEmpty(txtNoiDungTimKiem.Text.Trim()))
                    dgvDSCongVan.DataSource = _cCongVanDi.GetDS(CTaiKhoan.MaUser, dateTu.Value, int.Parse(cmbTuGio.SelectedItem.ToString()), dateDen.Value, int.Parse(cmbDenGio.SelectedItem.ToString()));
                else
                    switch (cmbTimKiem.SelectedItem.ToString())
                    {
                        case "Danh Bộ":
                            if (txtNoiDungTimKiem.Text.Trim().Length == 11)
                            {
                                dgvDSCongVan.DataSource = _cCongVanDi.GetDS(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                            }
                            break;
                        case "Mã Đơn/TB":
                            dgvDSCongVan.DataSource = _cCongVanDi.GetDS_Ma(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            break;
                        case "Phòng Đội":
                            dgvDSCongVan.DataSource = _cCongVanDi.GetDS_PhongDoi(CTaiKhoan.MaUser, dateTu.Value, int.Parse(cmbTuGio.SelectedItem.ToString()), dateDen.Value, int.Parse(cmbDenGio.SelectedItem.ToString()), txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            break;
                        default:
                            break;
                    }
            }
            else
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
                        case "Phòng Đội":
                            dgvDSCongVan.DataSource = _cCongVanDi.GetDS_PhongDoi(dateTu.Value, int.Parse(cmbTuGio.SelectedItem.ToString()), dateDen.Value, int.Parse(cmbDenGio.SelectedItem.ToString()), txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            break;
                        default:
                            break;
                    }
            }
        }

        private void txtTuMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbLoaiVanBan.SelectedIndex != -1 && txtTuMa.Text.Trim().Replace("-", "").Length > 2 && e.KeyChar == 13)
            {
                switch (cmbLoaiVanBan.SelectedItem.ToString())
                {
                    case "Đơn Từ Mới":
                        LinQ.DonTu_ChiTiet dontu_ChiTiet = null;
                        if (txtTuMa.Text.Trim().Contains(".") == true)
                        {
                            string[] MaDons = txtTuMa.Text.Trim().Split('.');
                            dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                        }
                        else
                        {
                            dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(txtTuMa.Text.Trim()), 1);
                            if (dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count > 1)
                            {
                                MessageBox.Show("Đơn Công Văn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        if (dontu_ChiTiet != null)
                        {
                            txtDanhBo.Text = dontu_ChiTiet.DanhBo;
                            txtHoTen.Text = dontu_ChiTiet.HoTen;
                            txtDiaChi.Text = dontu_ChiTiet.DiaChi;
                        }
                        break;
                    case "Đơn Tổ Khách Hàng":
                        DonKH donkh = _cDonKH.Get(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = donkh.DanhBo;
                        txtHoTen.Text = donkh.HoTen;
                        txtDiaChi.Text = donkh.DiaChi;
                        break;
                    case "Đơn Tổ Xử Lý":
                        DonTXL dontxl = _cDonTXL.Get(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = dontxl.DanhBo;
                        txtHoTen.Text = dontxl.HoTen;
                        txtDiaChi.Text = dontxl.DiaChi;
                        break;
                    case "Đơn Tổ Bấm Chì":
                        DonTBC dontbc = _cDonTBC.Get(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = dontbc.DanhBo;
                        txtHoTen.Text = dontbc.HoTen;
                        txtDiaChi.Text = dontbc.DiaChi;
                        break;
                    case "Kiểm Tra Xác Minh":
                        KTXM_ChiTiet ctktxm = _cKTXM.GetCT(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ctktxm.DanhBo;
                        txtHoTen.Text = ctktxm.HoTen;
                        txtDiaChi.Text = ctktxm.DiaChi;
                        break;
                    case "Bấm Chì":
                        BamChi_ChiTiet ctbamchi = _cBamChi.GetCT(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ctbamchi.DanhBo;
                        txtHoTen.Text = ctbamchi.HoTen;
                        txtDiaChi.Text = ctbamchi.DiaChi;
                        break;
                    case "Điều Chỉnh Biến Động":
                        DCBD_ChiTietBienDong dcbd = _cDCBD.getBienDong(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = dcbd.DanhBo;
                        txtHoTen.Text = dcbd.HoTen;
                        txtDiaChi.Text = dcbd.DiaChi;
                        break;
                    case "Điều Chỉnh Hóa Đơn":
                        DCBD_ChiTietHoaDon dchd = _cDCBD.getHoaDon(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = dchd.DanhBo;
                        txtHoTen.Text = dchd.HoTen;
                        txtDiaChi.Text = dchd.DiaChi;
                        break;
                    case "Cắt Tạm Danh Bộ":
                        CHDB_ChiTietCatTam ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ctctdb.DanhBo;
                        txtHoTen.Text = ctctdb.HoTen;
                        txtDiaChi.Text = ctctdb.DiaChi;
                        break;
                    case "Cắt Hủy Danh Bộ":
                        CHDB_ChiTietCatHuy ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ctchdb.DanhBo;
                        txtHoTen.Text = ctchdb.HoTen;
                        txtDiaChi.Text = ctchdb.DiaChi;
                        break;
                    case "Phiếu Hủy Danh Bộ":
                        CHDB_Phieu ycchdb = _cCHDB.GetPhieuHuy(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ycchdb.DanhBo;
                        txtHoTen.Text = ycchdb.HoTen;
                        txtDiaChi.Text = ycchdb.DiaChi;
                        break;
                    case "Thư Trả Lời":
                        ThuTraLoi_ChiTiet cttttl = _cTTTL.GetCT(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = cttttl.DanhBo;
                        txtHoTen.Text = cttttl.HoTen;
                        txtDiaChi.Text = cttttl.DiaChi;
                        break;
                    default:

                        break;
                }
            }
        }

        private void txtDenMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbLoaiVanBan.SelectedIndex != -1 && txtTuMa.Text.Trim().Replace("-", "").Length > 2 && txtDenMa.Text.Trim().Replace("-", "").Length > 2 && e.KeyChar == 13)
                if (txtTuMa.Text.Trim().Contains(".") == true && txtDenMa.Text.Trim().Contains(".") == true)
                {
                    string[] TuMas = txtTuMa.Text.Trim().Split('.');
                    string[] DenMas = txtDenMa.Text.Trim().Split('.');
                    if (TuMas[0] != DenMas[0])
                    {
                        MessageBox.Show("Mã đơn không trùng nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int TuMa = int.Parse(TuMas[1]);
                    int DenMa = int.Parse(DenMas[1]);
                    while (TuMa <= DenMa)
                    {
                        switch (cmbLoaiVanBan.SelectedItem.ToString())
                        {
                            case "Đơn Từ Mới":
                                if (_cDonTu.checkExist_ChiTiet(int.Parse(TuMas[0]), TuMa) == true)
                                    lstMa.Items.Add(TuMas[0] + "." + TuMa);
                                break;
                        }
                        TuMa++;
                    }
                }
                else
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
                                case "Đơn Tổ Bấm Chì":
                                    if (_cDonTBC.CheckExist(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                        lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                    break;
                                case "Kiểm Tra Xác Minh":
                                    break;
                                case "Bấm Chì":
                                    break;
                                case "Điều Chỉnh Biến Động":
                                    if (_cDCBD.checkExist_BienDong(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                        lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                    break;
                                case "Điều Chỉnh Hóa Đơn":
                                    if (_cDCBD.checkExist_HoaDon(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                        lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                    break;
                                case "Cắt Tạm Danh Bộ":
                                    if (_cCHDB.CheckExist_CTCTDB(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                        lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                    break;
                                case "Cắt Hủy Danh Bộ":
                                    if (_cCHDB.CheckExist_CTCHDB(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                        lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                    break;
                                case "Phiếu Hủy Danh Bộ":
                                    if (_cCHDB.CheckExist_PhieuHuy(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                        lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                    break;
                                case "Thư Trả Lời":
                                    if (_cTTTL.CheckExist_CT(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
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
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["LoaiVanBan"] = item.Cells["LoaiVanBan"].Value.ToString();
                //if (item.Cells["Ma"].Value.ToString().Length > 2)
                dr["Ma"] = item.Cells["Ma"].Value.ToString();
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
                txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            }
        }

        private void cmbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //KTKS_DonKH.DAL.DonTu.CDonTu _cDonTu = new DAL.DonTu.CDonTu();
            //DonTu entity=new DonTu();
            //entity.NoiDung="test";
            //_cDonTu.Them(entity);
            //dgvTest.DataSource = _cDonTu.GetDS();
        }

        private void chkNgayLap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayLap.Checked)
                dateNgayLap.Enabled = true;
            else
                dateNgayLap.Enabled = false;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;

            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            //khai báo số lượng sheet
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = "DANH SÁCH CÔNG VĂN";
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "Danh Bộ";
            cl1.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Khách Hàng";
            cl2.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Địa Chỉ";
            cl3.ColumnWidth = 35;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Hiệu";
            cl4.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "Cỡ";
            cl5.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
            cl6.Value2 = "Số Thân";
            cl6.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
            cl7.Value2 = "Ghi Chú";
            cl7.ColumnWidth = 15;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            int countColumn = 7;
            object[,] arr = new object[dgvDSCongVan.Rows.Count, countColumn];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dgvDSCongVan.Rows.Count; i++)
            {
                arr[i, 0] = dgvDSCongVan["DanhBo", i].Value.ToString();
                arr[i, 1] = dgvDSCongVan["HoTen", i].Value.ToString();
                arr[i, 2] = dgvDSCongVan["DiaChi", i].Value.ToString();
                HOADON hoadon = _cThuTien.GetMoiNhat(dgvDSCongVan["DanhBo", i].Value.ToString());
                if (hoadon != null)
                {
                    arr[i, 3] = hoadon.HIEUDH;
                    arr[i, 4] = hoadon.CoDH;
                    arr[i, 5] = hoadon.SoThanDHN;
                }
                arr[i, 6] = dgvDSCongVan["NoiDung", i].Value.ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dgvDSCongVan.Rows.Count - 1;
            int columnEnd = countColumn;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            c3a.NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            c3b.NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            c3d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void btnIn_Moi_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.KyHieuMaTo == "ToGD")
            {
                dt = _cDonTu.getDS_LichSu_CVD(cmbTo.SelectedValue.ToString(), dateTu_Moi.Value, dateDen_Moi.Value, cmbNoiChuyen_Moi.SelectedValue.ToString(), cmbNoiNhan_Moi.SelectedValue.ToString());
            }
            else
            {
                dt = _cDonTu.getDS_LichSu_CVD(CTaiKhoan.KyHieuMaTo, dateTu_Moi.Value, dateDen_Moi.Value, cmbNoiChuyen_Moi.SelectedValue.ToString(), cmbNoiNhan_Moi.SelectedValue.ToString());
            }
            string ID = "";
            foreach (DataRow item in dt.Rows)
            {
                if (ID == "")
                    ID += item["ID"].ToString();
                else
                    ID += "," + item["ID"].ToString();
            }
            _cDonTu.ExecuteNonQuery("update DonTu_LichSu set CVD_Ngay=getdate() where ID in (" + ID + ") and CVD_Ngay is null");
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.KyHieuMaTo == "ToGD")
            {
                dt = _cDonTu.getDS_LichSu_CVD(cmbTo.SelectedValue.ToString(), dateTu_Moi.Value, dateDen_Moi.Value, cmbNoiChuyen_Moi.SelectedValue.ToString(), cmbNoiNhan_Moi.SelectedValue.ToString());
            }
            else
            {
                dt = _cDonTu.getDS_LichSu_CVD(CTaiKhoan.KyHieuMaTo, dateTu_Moi.Value, dateDen_Moi.Value, cmbNoiChuyen_Moi.SelectedValue.ToString(), cmbNoiNhan_Moi.SelectedValue.ToString());
            }
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();
                dr["TuNgay"] = item["CVD_Ngay"].ToString();
                dr["DenNgay"] = item["CVD_Ngay"].ToString();
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                switch (item["TableName"].ToString())
                {
                    case "BamChi_ChiTiet":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        BamChi_ChiTiet enBC = _cBamChi.GetCT(decimal.Parse(item["IDCT"].ToString()));
                        if (enBC != null)
                        {
                            dr["DanhBo"] = enBC.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enBC.DiaChi;
                            dr["NoiDung"] = enBC.TrangThaiBC;
                        }
                        break;
                    case "CHDB_ChiTietCatHuy":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        CHDB_ChiTietCatHuy enCH = _cCHDB.GetCTCHDB(decimal.Parse(item["IDCT"].ToString()));
                        if (enCH != null)
                        {
                            dr["DanhBo"] = enCH.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enCH.DiaChi;
                            dr["NoiDung"] = enCH.LyDo;
                        }
                        break;
                    case "CHDB_ChiTietCatTam":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        CHDB_ChiTietCatTam enCT = _cCHDB.GetCTCTDB(decimal.Parse(item["IDCT"].ToString()));
                        if (enCT != null)
                        {
                            dr["DanhBo"] = enCT.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enCT.DiaChi;
                            dr["NoiDung"] = enCT.LyDo;
                        }
                        break;
                    case "CHDB_Phieu":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        CHDB_Phieu enP = _cCHDB.GetPhieuHuy(decimal.Parse(item["IDCT"].ToString()));
                        if (enP != null)
                        {
                            dr["DanhBo"] = enP.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enP.DiaChi;
                            dr["NoiDung"] = enP.LyDo;
                        }
                        break;
                    case "DCBD_ChiTietBienDong":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        DCBD_ChiTietBienDong enBD = _cDCBD.getBienDong(decimal.Parse(item["IDCT"].ToString()));
                        if (enBD != null)
                        {
                            dr["DanhBo"] = enBD.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enBD.DiaChi;
                            dr["NoiDung"] = enBD.ThongTin;
                        }
                        break;
                    case "DCBD_ChiTietHoaDon":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        DCBD_ChiTietHoaDon enHD = _cDCBD.getHoaDon(decimal.Parse(item["IDCT"].ToString()));
                        if (enHD != null)
                        {
                            dr["DanhBo"] = enHD.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enHD.DiaChi;
                            dr["NoiDung"] = enHD.KyHD;
                        }
                        break;
                    case "GianLan_ChiTiet":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        GianLan_ChiTiet enGL = _cGL.get_ChiTiet(int.Parse(item["IDCT"].ToString()));
                        if (enGL != null)
                        {
                            dr["DanhBo"] = enGL.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enGL.DiaChi;
                            dr["NoiDung"] = enGL.NoiDungViPham;
                        }
                        break;
                    case "KTXM_ChiTiet":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        KTXM_ChiTiet enKTXM = _cKTXM.GetCT(decimal.Parse(item["IDCT"].ToString()));
                        if (enKTXM != null)
                        {
                            dr["DanhBo"] = enKTXM.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enKTXM.DiaChi;
                            dr["NoiDung"] = enKTXM.HienTrangKiemTra;
                        }
                        break;
                    case "ThuMoi_ChiTiet":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        ThuMoi_ChiTiet enTM = _cThuMoi.get_ChiTiet(int.Parse(item["IDCT"].ToString()));
                        if (enTM != null)
                        {
                            dr["DanhBo"] = enTM.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enTM.DiaChi;
                            dr["NoiDung"] = enTM.VeViec;
                        }
                        break;
                    case "ThuTraLoi_ChiTiet":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        ThuTraLoi_ChiTiet enTTL = _cTTTL.GetCT(decimal.Parse(item["IDCT"].ToString()));
                        if (enTTL != null)
                        {
                            dr["DanhBo"] = enTTL.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enTTL.DiaChi;
                            dr["NoiDung"] = enTTL.VeViec;
                        }
                        break;
                    case "ToTrinh_ChiTiet":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        ToTrinh_ChiTiet enTT = _cToTrinh.get_ChiTiet(int.Parse(item["IDCT"].ToString()));
                        if (enTT != null)
                        {
                            dr["DanhBo"] = enTT.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enTT.DiaChi;
                            dr["NoiDung"] = enTT.VeViec;
                        }
                        break;
                    case "TruyThuTienNuoc_ChiTiet":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        TruyThuTienNuoc_ChiTiet enTTTN = _cTTTN.get_ChiTiet(decimal.Parse(item["IDCT"].ToString()));
                        if (enTTTN != null)
                        {
                            dr["DanhBo"] = enTTTN.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enTTTN.DiaChi;
                            dr["NoiDung"] = enTTTN.NoiDung;
                        }
                        break;
                    case "VanBan_ChiTiet":
                        dr["LoaiVanBan"] = _cBamChi.ExecuteQuery_ReturnOneValue("select [Name] from TableHinh where TableName='" + item["TableName"].ToString() + "'").ToString();
                        VanBan_ChiTiet enVB = _cVanBan.get_ChiTiet(int.Parse(item["IDCT"].ToString()));
                        if (enVB != null)
                        {
                            dr["DanhBo"] = enVB.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = enVB.DiaChi;
                            dr["NoiDung"] = enVB.VeViec;
                        }
                        break;
                }
                dr["Ma"] = item["MaDon"].ToString();
                dr["CreateDate"] = item["CVD_Ngay"].ToString();
                dr["NoiChuyen"] = item["NoiNhan"].ToString();

                dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            }
            rptDSCongVan rpt = new rptDSCongVan();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnXem_Moi_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.KyHieuMaTo == "ToGD")
            {
                dt = _cDonTu.getDS_LichSu_CVD(cmbTo.SelectedValue.ToString(), dateTu_Moi.Value, dateDen_Moi.Value, cmbNoiChuyen_Moi.SelectedValue.ToString(), cmbNoiNhan_Moi.SelectedValue.ToString());
            }
            else
            {
                dt = _cDonTu.getDS_LichSu_CVD(CTaiKhoan.KyHieuMaTo, dateTu_Moi.Value, dateDen_Moi.Value, cmbNoiChuyen_Moi.SelectedValue.ToString(), cmbNoiNhan_Moi.SelectedValue.ToString());
            }
            dgvDSCongVan.DataSource = dt;
        }



    }
}
