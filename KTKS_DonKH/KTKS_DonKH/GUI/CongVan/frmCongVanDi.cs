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
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CongVan;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.CongVan
{
    public partial class frmCongVanDi : Form
    {
        CCongVanDi _cCongVanDi = new CCongVanDi();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CKTXM _cKTXM = new CKTXM();
        CBamChi _cBamChi = new CBamChi();
        CDCBD _cDCBD = new CDCBD();
        CCHDB _cCHDB = new CCHDB();
        CTTTL _cTTTL = new CTTTL();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();

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

            if (CTaiKhoan.Admin == true)
            {
                btnTest.Visible = true;
                dgvTest.Visible = true;
            }
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

                    if (txtTuMa.Text.Trim().Replace("-", "") != "")
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
                            MessageBox.Show("Đã có: " + item.Ma, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        if (_cCongVanDi.Them(item))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
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
                                CTKTXM ctktxm = _cKTXM.GetCT(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = ctktxm.DanhBo;
                                item.HoTen = ctktxm.HoTen;
                                item.DiaChi = ctktxm.DiaChi;
                                break;
                            case "Bấm Chì":
                                CTBamChi ctbamchi = _cBamChi.GetCT(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = ctbamchi.DanhBo;
                                item.HoTen = ctbamchi.HoTen;
                                item.DiaChi = ctbamchi.DiaChi;
                                break;
                            case "Điều Chỉnh Biến Động":
                                CTDCBD dcbd = _cDCBD.GetDCBDByMaCTDCBD(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = dcbd.DanhBo;
                                item.HoTen = dcbd.HoTen;
                                item.DiaChi = dcbd.DiaChi;
                                break;
                            case "Điều Chỉnh Hóa Đơn":
                                CTDCHD dchd = _cDCBD.getCTDCHDbyID(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = dchd.DanhBo;
                                item.HoTen = dchd.HoTen;
                                item.DiaChi = dchd.DiaChi;
                                break;
                            case "Cắt Tạm Danh Bộ":
                                CTCTDB ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = ctctdb.DanhBo;
                                item.HoTen = ctctdb.HoTen;
                                item.DiaChi = ctctdb.DiaChi;
                                break;
                            case "Cắt Hủy Danh Bộ":
                                CTCHDB ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = ctchdb.DanhBo;
                                item.HoTen = ctchdb.HoTen;
                                item.DiaChi = ctchdb.DiaChi;
                                break;
                            case "Phiếu Hủy Danh Bộ":
                                PhieuCHDB ycchdb = _cCHDB.GetPhieuHuy(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = ycchdb.DanhBo;
                                item.HoTen = ycchdb.HoTen;
                                item.DiaChi = ycchdb.DiaChi;
                                break;
                            case "Thư Trả Lời":
                                CTTTTL cttttl = _cTTTL.GetCT(decimal.Parse(itemMa.Text.Trim().Replace("-", "")));
                                item.DanhBo = cttttl.DanhBo;
                                item.HoTen = cttttl.HoTen;
                                item.DiaChi = cttttl.DiaChi;
                                break;
                            default:

                                break;
                        }
                        item.NoiDung = txtNoiDung.Text.Trim();
                        item.NoiChuyen = cmbNoiChuyen.SelectedItem.ToString();

                        if (!_cCongVanDi.CheckExist(item.LoaiVanBan, item.Ma, item.NoiChuyen, DateTime.Now))
                            _cCongVanDi.Them(item);
                        else
                            MessageBox.Show("Đã có: " + item.Ma, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnXem.PerformClick();
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
                        CTKTXM ctktxm = _cKTXM.GetCT(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ctktxm.DanhBo;
                        txtHoTen.Text = ctktxm.HoTen;
                        txtDiaChi.Text = ctktxm.DiaChi;
                        break;
                    case "Bấm Chì":
                        CTBamChi ctbamchi = _cBamChi.GetCT(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ctbamchi.DanhBo;
                        txtHoTen.Text = ctbamchi.HoTen;
                        txtDiaChi.Text = ctbamchi.DiaChi;
                        break;
                    case "Điều Chỉnh Biến Động":
                        CTDCBD dcbd = _cDCBD.GetDCBDByMaCTDCBD(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = dcbd.DanhBo;
                        txtHoTen.Text = dcbd.HoTen;
                        txtDiaChi.Text = dcbd.DiaChi;
                        break;
                    case "Điều Chỉnh Hóa Đơn":
                        CTDCHD dchd = _cDCBD.getCTDCHDbyID(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = dchd.DanhBo;
                        txtHoTen.Text = dchd.HoTen;
                        txtDiaChi.Text = dchd.DiaChi;
                        break;
                    case "Cắt Tạm Danh Bộ":
                        CTCTDB ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ctctdb.DanhBo;
                        txtHoTen.Text = ctctdb.HoTen;
                        txtDiaChi.Text = ctctdb.DiaChi;
                        break;
                    case "Cắt Hủy Danh Bộ":
                        CTCHDB ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ctchdb.DanhBo;
                        txtHoTen.Text = ctchdb.HoTen;
                        txtDiaChi.Text = ctchdb.DiaChi;
                        break;
                    case "Phiếu Hủy Danh Bộ":
                        PhieuCHDB ycchdb = _cCHDB.GetPhieuHuy(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
                        txtDanhBo.Text = ycchdb.DanhBo;
                        txtHoTen.Text = ycchdb.HoTen;
                        txtDiaChi.Text = ycchdb.DiaChi;
                        break;
                    case "Thư Trả Lời":
                        CTTTTL cttttl = _cTTTL.GetCT(decimal.Parse(txtTuMa.Text.Trim().Replace("-", "")));
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
                                if (_cDCBD.CheckExist_DCBD(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
                                    lstMa.Items.Add(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2));
                                break;
                            case "Điều Chỉnh Hóa Đơn":
                                if (_cDCBD.CheckExist_DCHD(decimal.Parse(TuMa + txtTuMa.Text.Trim().Replace("-", "").Substring(txtTuMa.Text.Trim().Replace("-", "").Length - 2, 2))))
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

       

    }
}
