using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
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
using KTKS_DonKH.DAL.PhongKhachHang;

namespace KTKS_DonKH.GUI.PhongKhachHang
{
    public partial class frmCongVanDi_PKH : Form
    {
        CCongVanDi_PKH _cCongVanDi = new CCongVanDi_PKH();
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CKTXM _cKTXM = new CKTXM();
        CBamChi _cBamChi = new CBamChi();
        CDCBD _cDCBD = new CDCBD();
        CCHDB _cCHDB = new CCHDB();
        CTTTL _cTTTL = new CTTTL();
        CThuTien _cThuTien = new CThuTien();
        CDHN _cDocSo = new CDHN();

        public frmCongVanDi_PKH()
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
                            PKH_CongVanDi item = new PKH_CongVanDi();
                            item.LoaiVanBan = cmbLoaiVanBan.SelectedItem.ToString();
                            item.TenTable = GetTenTable();
                            item.Ma = txtTuMa.Text.Trim().Replace("-", "");
                            item.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                            item.HoTen = txtHoTen.Text.Trim();
                            item.DiaChi = txtDiaChi.Text.Trim();
                            item.NoiDung = txtNoiDung.Text.Trim();
                            item.NoiChuyen = chkcmbNoiNhan.Properties.Items[i].ToString();

                            if (txtTuMa.Text.Trim().Replace("-", "") != "")
                                if (!_cCongVanDi.CheckExist(item.LoaiVanBan, item.Ma, item.NoiChuyen, DateTime.Now))
                                {
                                    if (chkNgayLap.Checked)
                                    {
                                        if (_cCongVanDi.Them(item, dateNgayLap.Value))
                                        {
                                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Clear();
                                            btnXem.PerformClick();
                                        }
                                    }
                                    else
                                    {
                                        if (_cCongVanDi.Them(item))
                                        {
                                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Clear();
                                            btnXem.PerformClick();
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
                                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Clear();
                                        btnXem.PerformClick();
                                    }
                                }
                                else
                                {
                                    if (_cCongVanDi.Them(item))
                                    {
                                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Clear();
                                        btnXem.PerformClick();
                                    }
                                }
                        }
                }
                else
                {
                    foreach (ListViewItem itemMa in lstMa.Items)
                    {
                        for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                            if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                PKH_CongVanDi item = new PKH_CongVanDi();
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
                        default:
                            break;
                    }
            }
        }

        private void txtTuMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbLoaiVanBan.SelectedIndex != -1&&txtTuMa.Text.Trim()!="" && e.KeyChar == 13)
            {
                switch (cmbLoaiVanBan.SelectedItem.ToString())
                {
                    case "Đơn Từ Mới":
                        LinQ.DonTu_ChiTiet dontu_ChiTiet=null;
                        //if (txtTuMa.Text.Trim().Contains(".") == true)
                        //{
                        //    string[] MaDons = txtTuMa.Text.Trim().Split('.');
                        //    dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                        //}
                        //else
                        {
                            dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(txtTuMa.Text.Trim()), 1);
                            //if (dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count > 1)
                            //{
                            //    MessageBox.Show("Đơn Công Văn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                        }
                        if (dontu_ChiTiet != null)
                        {
                            if (dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                            {
                                txtDanhBo.Text = dontu_ChiTiet.DanhBo;
                                txtHoTen.Text = dontu_ChiTiet.HoTen;
                                txtDiaChi.Text = dontu_ChiTiet.DiaChi;
                            }
                            else
                                txtDanhBo.Text = "Công Văn: " + dontu_ChiTiet.DonTu.SoCongVan + " (" + dontu_ChiTiet.DonTu.TongDB.ToString() + ")";
                        }
                        break;
                    default:

                        break;
                }
            }
        }

        private void txtDenMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbLoaiVanBan.SelectedIndex != -1 && txtTuMa.Text.Trim().Replace("-", "").Length > 2 && txtDenMa.Text.Trim().Replace("-", "").Length > 2 && e.KeyChar == 13)
            //if (txtTuMa.Text.Trim().Contains(".") == true && txtDenMa.Text.Trim().Contains(".") == true)
            //{
            //    string[] TuMas = txtTuMa.Text.Trim().Split('.');
            //    string[] DenMas = txtDenMa.Text.Trim().Split('.');
            //    if (TuMas[0] != DenMas[0])
            //    {
            //        MessageBox.Show("Mã đơn không trùng nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    int TuMa = int.Parse(TuMas[1]);
            //    int DenMa = int.Parse(DenMas[1]);
            //    while (TuMa <= DenMa)
            //    {
            //        switch (cmbLoaiVanBan.SelectedItem.ToString())
            //        {
            //            case "Đơn Từ Mới":
            //                if (_cDonTu.checkExist_ChiTiet(int.Parse(TuMas[0]), TuMa) == true)
            //                    lstMa.Items.Add(TuMas[0] + "." + TuMa);
            //                    break;
            //        }
            //        TuMa++;
            //    }
            //}
            //else
            {
                switch (cmbLoaiVanBan.SelectedItem.ToString())
                {
                    case "Đơn Từ Mới":
                        DataTable dt = _cDonTu.getDS(int.Parse(txtTuMa.Text.Trim()), int.Parse(txtDenMa.Text.Trim()));
                        foreach (DataRow item in dt.Rows)
                        {
                            lstMa.Items.Add(item["MaDon"].ToString());
                        }
                        break;
                    default:

                        break;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvDSCongVan.SelectedRows)
            {
                PKH_CongVanDi congvandi = _cCongVanDi.Get(int.Parse(item.Cells["ID"].Value.ToString()));
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

        private void cmbLoaiVanBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

    }
}
