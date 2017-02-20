using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.BamChi;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmDSDonTXL : Form
    {
        CDonTXL _cDonTXL = new CDonTXL();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CBamChi _cBamChi = new CBamChi();

        public frmDSDonTXL()
        {
            InitializeComponent();
        }

        private void frmQLDonTXL_Load(object sender, EventArgs e)
        {
            dgvDSDonTXL.AutoGenerateColumns = false;

            cmbTimTheo.SelectedItem = "Ngày";
        }

        private void dgvDSDonTXL_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDonTXL.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDonTXL_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDonTXL.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "Cập Nhật");
                source.Add("MaDon", dgvDSDonTXL["MaDon", dgvDSDonTXL.CurrentRow.Index].Value.ToString());
                frmNhanDonTXL frm = new frmNhanDonTXL(decimal.Parse(dgvDSDonTXL["MaDon", dgvDSDonTXL.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
                //if (frm.ShowDialog() == DialogResult.OK)
                //    if (radChuaChuyen.Checked)
                //        DSDonKH_BS.DataSource = _cDonTXL.LoadDSDonTXLChuaChuyen();
                //    else
                //        if (radDaChuyen.Checked)
                //            DSDonKH_BS.DataSource = _cDonTXL.LoadDSDonTXLDaChuyen();
                //        else
                //            if (radAll.Checked)
                //                DSDonKH_BS.DataSource = _cDonTXL.LoadDSAllDonTXL();
            }
        }

        private void dgvDSDonTXL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDonTXL.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null&&e.Value.ToString().Length>2)
            {
                e.Value = "TXL" + e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSDonTXL.Columns[e.ColumnIndex].Name == "NguoiDi" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = _cTaiKhoan.getHoTenUserbyID(int.Parse(e.Value.ToString()));
            }
            if (dgvDSDonTXL.Columns[e.ColumnIndex].Name == "GiaiQuyet" && !string.IsNullOrEmpty(dgvDSDonTXL["NguoiDi", e.RowIndex].Value.ToString()))
            {
                e.Value = _cDonTXL.CheckGiaiQuyetDonTXLbyUser(int.Parse(dgvDSDonTXL["NguoiDi", e.RowIndex].Value.ToString()), decimal.Parse(dgvDSDonTXL["MaDon", e.RowIndex].Value.ToString()));
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Địa Chỉ":
                case "Số Công Văn":
                    txtNoiDungTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvDSDonTXL.DataSource = null;
        }

        private void btnInDSDonKH_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Ngày":
                    dt = _cDonTXL.LoadDSDonTXLDaChuyenKT(dateTu.Value, dateDen.Value);
                    break;
                case "Số Công Văn":
                    dt = _cDonTXL.LoadDSDonTXLDaChuyenKTbySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            if (chkChuaKT.Checked)
                foreach (DataRow itemRow in dt.Rows)
                {
                    string a = itemRow["NguoiDi"].ToString();
                    string b = itemRow["MaDon"].ToString();
                    if (!_cDonTXL.CheckGiaiQuyetDonTXLbyUser(int.Parse(itemRow["NguoiDi"].ToString()), decimal.Parse(itemRow["MaDon"].ToString())))
                    {
                        DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                        //dr["MaLD"] = itemRow["MaLD"];
                        dr["TenLD"] = itemRow["TenLD"];
                        dr["SoCongVan"] = itemRow["SoCongVan"];
                        dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                        DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                        dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                        dr["TenLD"] = dontxl.LoaiDonTXL.TenLD;

                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length==11)
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["NoiDung"] = itemRow["NoiDung"];
                        dr["GhiChuChuyenKT"] = itemRow["GhiChuChuyenKT"];
                        if (!string.IsNullOrEmpty(itemRow["NguoiDi"].ToString()))
                        {
                            dr["NguoiDi"] = _cTaiKhoan.getHoTenUserbyID(int.Parse(itemRow["NguoiDi"].ToString()));
                            //dr["DaGiaiQuyet"] = _cDonTXL.CheckGiaiQuyetbyUser(int.Parse(itemRow["NguoiDi"].ToString()), dontxl.MaDon).ToString();
                        }

                        dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                    }
                }
            else
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    //dr["MaLD"] = itemRow["MaLD"];
                    dr["TenLD"] = itemRow["TenLD"];
                    dr["SoCongVan"] = itemRow["SoCongVan"];
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                    //DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                    dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();

                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["NoiDung"] = itemRow["NoiDung"];
                    dr["GhiChuChuyenKT"] = itemRow["GhiChuChuyenKT"];
                    if (!string.IsNullOrEmpty(itemRow["NguoiDi"].ToString()))
                    {
                        dr["NguoiDi"] = _cTaiKhoan.getHoTenUserbyID(int.Parse(itemRow["NguoiDi"].ToString()));
                        string NgayGiaiQuyet;
                        dr["DaGiaiQuyet"] = _cDonTXL.CheckGiaiQuyetDonTXLbyUser(int.Parse(itemRow["NguoiDi"].ToString()), decimal.Parse(itemRow["MaDon"].ToString()), out NgayGiaiQuyet).ToString();
                        dr["NgayGiaiQuyet"] = NgayGiaiQuyet;
                    }

                    dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                }

            rptDSDonTXLChuyenKTXM rpt = new rptDSDonTXLChuyenKTXM();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            rpt.Subreports[1].SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInChiTiet_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)dgvDSDonTXL.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                if (dontxl.Chuyen_KTXM)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

                    dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString();
                    dr["NoiDung"] = itemRow["NoiDung"].ToString();
                    dr["LoaiChuyen"] = "Đi Kiểm Tra";
                    if (dontxl.NgayChuyen_KTXM != null)
                        dr["NgayChuyen"] = dontxl.NgayChuyen_KTXM.Value.ToString("dd/MM/yyyy");
                    if (dontxl.NguoiDi_KTXM != null)
                        dr["GhiChu"] = _cTaiKhoan.getHoTenUserbyID(int.Parse(dontxl.NguoiDi_KTXM.Value.ToString()));
                    dr["GhiChu"] += ". " + dontxl.GhiChuChuyen_KTXM;

                    dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                }
                if (dontxl.ChuyenBanDoiKhac)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

                    dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString();
                    dr["NoiDung"] = itemRow["NoiDung"].ToString();
                    dr["LoaiChuyen"] = "Đi Ban Đội Khác";
                    if (dontxl.NgayChuyenBanDoiKhac != null)
                        dr["NgayChuyen"] = dontxl.NgayChuyenBanDoiKhac.Value.ToString("dd/MM/yyyy");
                    dr["GhiChu"] = dontxl.GhiChuChuyenBanDoiKhac;

                    dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                }
                if (dontxl.ChuyenToKhachHang)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

                    dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString();
                    dr["NoiDung"] = itemRow["NoiDung"].ToString();
                    dr["LoaiChuyen"] = "Đi Tổ Khách Hàng";
                    if (dontxl.NgayChuyenToKhachHang != null)
                        dr["NgayChuyen"] = dontxl.NgayChuyenToKhachHang.Value.ToString("dd/MM/yyyy");
                    dr["GhiChu"] = dontxl.GhiChuChuyenToKhachHang;

                    dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                }
                if (dontxl.ChuyenBanDoiKhac)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

                    dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString();
                    dr["NoiDung"] = itemRow["NoiDung"].ToString();
                    dr["LoaiChuyen"] = "Đi Khác";
                    if (dontxl.NgayChuyenKhac != null)
                        dr["NgayChuyen"] = dontxl.NgayChuyenKhac.Value.ToString("dd/MM/yyyy");
                    dr["GhiChu"] = dontxl.GhiChuChuyenKhac;

                    dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                }
            }
            rptChiTietDonTXL rpt = new rptChiTietDonTXL();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInGiaoToKH_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //DataTable dt = ((DataTable)dgvDSDonTXL.DataSource).DefaultView.ToTable();
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Ngày":
                    dt = _cDonTXL.LoadDSDonTXLDaChuyenTKHByDates(dateTu.Value, dateDen.Value);
                    break;
                case "Số Công Văn":
                    dt = _cDonTXL.LoadDSDonTXLDaChuyenTKHBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
            }
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                //dr["TuNgay"] = _tuNgay;
                //dr["DenNgay"] = _denNgay;
                dr["ChiTiet"] = "Tổ KH";
                //dr["MaLD"] = itemRow["MaLD"];
                dr["TenLD"] = itemRow["TenLD"];
                dr["SoCongVan"] = itemRow["SoCongVan"];
                dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                //DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                dr["TenLD"] = itemRow["TenLD"].ToString();

                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");

                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                dr["NoiDung"] = itemRow["NoiDung"];
                dr["NguoiDi"] = itemRow["GhiChuChuyenKT"];
                //if (!string.IsNullOrEmpty(itemRow["NguoiDi"].ToString()))
                //{
                //    dr["NguoiDi"] = _cTaiKhoan.getHoTenUserbyID(int.Parse(itemRow["NguoiDi"].ToString()));
                //    string NgayGiaiQuyet;
                //    dr["DaGiaiQuyet"] = _cDonTXL.CheckGiaiQuyetDonTXLbyUser(int.Parse(itemRow["NguoiDi"].ToString()), dontxl.MaDon, out NgayGiaiQuyet).ToString();
                //    dr["NgayGiaiQuyet"] = NgayGiaiQuyet;
                //}

                dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
            }
            rptDSDonTXLChuyenTKH rpt = new rptDSDonTXLChuyenTKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnGiaoKhac_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //DataTable dt = ((DataTable)dgvDSDonTXL.DataSource).DefaultView.ToTable();
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Ngày":
                    dt = _cDonTXL.LoadDSDonTXLDaChuyenKhacByDates(dateTu.Value, dateDen.Value);
                    break;
                case "Số Công Văn":
                    dt = _cDonTXL.LoadDSDonTXLDaChuyenKhacBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
            }
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                //dr["TuNgay"] = _tuNgay;
                //dr["DenNgay"] = _denNgay;
                //dr["MaLD"] = itemRow["MaLD"];
                dr["TenLD"] = itemRow["TenLD"];
                dr["SoCongVan"] = itemRow["SoCongVan"];
                dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                //DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                dr["TenLD"] = itemRow["TenLD"].ToString();

                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                dr["NoiDung"] = itemRow["NoiDung"];
                dr["GhiChuChuyenKT"] = itemRow["GhiChuChuyenKT"];

                if (bool.Parse(itemRow["ChiBoSung"].ToString()))
                    dr["ChiBoSung"] = "1";
                if (bool.Parse(itemRow["GiuNguyen"].ToString()))
                    dr["GiuNguyen"] = "1";
                if (bool.Parse(itemRow["DieuChinh"].ToString()))
                    dr["DieuChinh"] = "1";
                if (bool.Parse(itemRow["TruyThu"].ToString()))
                    dr["TruyThu"] = "1";
                //if (!string.IsNullOrEmpty(itemRow["NguoiDi"].ToString()))
                //{
                //    dr["NguoiDi"] = _cTaiKhoan.getHoTenUserbyID(int.Parse(itemRow["NguoiDi"].ToString()));
                //    string NgayGiaiQuyet;
                //    dr["DaGiaiQuyet"] = _cDonTXL.CheckGiaiQuyetDonTXLbyUser(int.Parse(itemRow["NguoiDi"].ToString()), dontxl.MaDon, out NgayGiaiQuyet).ToString();
                //    dr["NgayGiaiQuyet"] = NgayGiaiQuyet;
                //}

                dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
            }
            rptDSDonTXLChuyenKhac rpt = new rptDSDonTXLChuyenKhac();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInBamChi_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)dgvDSDonTXL.DataSource).DefaultView.ToTable();

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
                if (itemRow["TenLD"].ToString().Contains("Bấm Chì"))
                {
                    DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                    //dr["TuNgay"] = _tuNgay;
                    //dr["DenNgay"] = _denNgay;
                    dr["TenLD"] = itemRow["TenLD"];
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    if (_cBamChi.CheckBamChibyMaDon_TXL(decimal.Parse(itemRow["MaDon"].ToString())))
                    {
                        dr["DaGiaiQuyet"] = "True";
                    }

                    dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                }

            rptDSDonTXL_BamChi rpt = new rptDSDonTXL_BamChi();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
                foreach (DataGridViewRow item in dgvDSDonTXL.Rows)
                {
                    item.Cells["Chon"].Value = true;
                }
            else
                foreach (DataGridViewRow item in dgvDSDonTXL.Rows)
                {
                    item.Cells["Chon"].Value = false;
                }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                foreach (DataGridViewRow item in dgvDSDonTXL.Rows)
                    if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()))
                    {
                        DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(item.Cells["MaDon"].Value.ToString()));
                        _cDonTXL.XoaDonTXL(dontxl);
                    }
        }

        private void btnInGiaoBanDoiKhac_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //DataTable dt = ((DataTable)dgvDSDonTXL.DataSource).DefaultView.ToTable();
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Ngày":
                    dt = _cDonTXL.LoadDSDonTXLDaChuyenBanDoiKhacByDates(dateTu.Value, dateDen.Value);
                    break;
                case "Số Công Văn":
                    dt = _cDonTXL.LoadDSDonTXLDaChuyenBanDoiKhacBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
            }
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                //dr["TuNgay"] = _tuNgay;
                //dr["DenNgay"] = _denNgay;
                dr["ChiTiet"] = "Ban Đội Khác";
                //dr["MaLD"] = itemRow["MaLD"];
                dr["TenLD"] = itemRow["TenLD"];
                dr["SoCongVan"] = itemRow["SoCongVan"];
                dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                //DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                dr["TenLD"] = itemRow["TenLD"].ToString();

                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                dr["NoiDung"] = itemRow["NoiDung"];
                dr["GhiChuChuyenKT"] = itemRow["GhiChuChuyenKT"];
                //if (!string.IsNullOrEmpty(itemRow["NguoiDi"].ToString()))
                //{
                //    dr["NguoiDi"] = _cTaiKhoan.getHoTenUserbyID(int.Parse(itemRow["NguoiDi"].ToString()));
                //    string NgayGiaiQuyet;
                //    dr["DaGiaiQuyet"] = _cDonTXL.CheckGiaiQuyetDonTXLbyUser(int.Parse(itemRow["NguoiDi"].ToString()), dontxl.MaDon, out NgayGiaiQuyet).ToString();
                //    dr["NgayGiaiQuyet"] = NgayGiaiQuyet;
                //}

                dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
            }
            rptDSDonTXLChuyenTKH rpt = new rptDSDonTXLChuyenTKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL") && txtNoiDungTimKiem.Text.Trim().Length > 3)
                        dgvDSDonTXL.DataSource = _cDonTXL.LoadDSDonTXLByMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("TXL", "").Replace("-", "")));
                    break;
                case "Số Công Văn":
                    dgvDSDonTXL.DataSource = _cDonTXL.LoadDSDonTXLBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
                case "Danh Bộ":
                    dgvDSDonTXL.DataSource = _cDonTXL.LoadDSDonTXLByDanhBo(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
                case "Địa Chỉ":
                    dgvDSDonTXL.DataSource = _cDonTXL.LoadDSDonTXLByDiaChi(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
                case "Ngày":
                    dgvDSDonTXL.DataSource = _cDonTXL.LoadDSDonTXLByDates(dateTu.Value, dateDen.Value);
                    break;
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataGridViewRow item in dgvDSDonTXL.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                dr["LoaiBaoCao"] = "TỔ XỬ LÝ";
                dr["MaDon"] = "TXL" + item.Cells["MaDon"].Value.ToString().Insert(item.Cells["MaDon"].Value.ToString().Length - 2, "-");
                dr["STT"] = item.Cells["STT"].Value;
                dr["TenLD"] = item.Cells["TenLD"].Value.ToString();
                dr["SoCongVan"] = item.Cells["SoCongVan"].Value.ToString();
                dr["NgayNhan"] = item.Cells["CreateDate"].Value.ToString();
                if (!string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString()) && item.Cells["DanhBo"].Value.ToString().Length == 11)
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item.Cells["HoTen"].Value;
                dr["DiaChi"] = item.Cells["DiaChi"].Value;
                dr["NoiDung"] = item.Cells["NoiDung"].Value;

                dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
            }
            rptDSDonTXL rpt = new rptDSDonTXL();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }


    }
}
