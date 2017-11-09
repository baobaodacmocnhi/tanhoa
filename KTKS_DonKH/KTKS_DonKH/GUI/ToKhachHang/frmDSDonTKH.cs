using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToKhachHang;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.ToKhachHang
{
    public partial class frmDSDonTKH : Form
    {
        CDonKH _cDonKH = new CDonKH();
        CLoaiDon _cLoaiDon = new CLoaiDon();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CDonTXL _cDonTXL = new CDonTXL();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();

        public frmDSDonTKH()
        {
            InitializeComponent();
        }

        private void frmQLDonKH_Load(object sender, EventArgs e)
        {
            dgvDSDonKH.AutoGenerateColumns = false;

            cmbTimTheo.SelectedIndex = 4;
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Số Công Văn":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvDSDonKH.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != ""&&txtNoiDungTimKiem2.Text.Trim() != "")
                        dgvDSDonKH.DataSource = _cDonKH.GetDS(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                    else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSDonKH.DataSource = _cDonKH.GetDS(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                    break;
                case "Danh Bộ":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSDonKH.DataSource = _cDonKH.GetDSByDanhBo(txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Số Công Văn":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSDonKH.DataSource = _cDonKH.GetDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
                case "Ngày":
                    dgvDSDonKH.DataSource = _cDonKH.GetDS(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)dgvDSDonKH.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                //dr["MaLD"] = itemRow["MaLD"];
                dr["TenLD"] = itemRow["TenLD"];
                dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                DonKH donkh = _cDonKH.Get(decimal.Parse(itemRow["MaDon"].ToString()));
                dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-") + "/" + _cLoaiDon.getKyHieuLDubyID(donkh.MaLD.Value);
                if (donkh.KiemTraDHN)
                    dr["ChiTiet"] += "Kiểm Tra ĐHN, ";
                if (donkh.TienNuoc)
                    dr["ChiTiet"] += "Tiền Nước, ";
                if (donkh.ChiSoNuoc)
                    dr["ChiTiet"] += "Chỉ Số Nước, ";
                if (donkh.DonGiaNuoc)
                    dr["ChiTiet"] += "Đơn Giá Nước, ";
                if (donkh.SangTen)
                    dr["ChiTiet"] += "Sang Tên, ";
                if (donkh.NuocDuc)
                    dr["ChiTiet"] += "Nước Đục, ";
                if (donkh.DangKyDM || donkh.CatChuyenDM)
                    dr["ChiTiet"] += "Định Mức, ";
                if (donkh.LoaiKhac)
                    dr["ChiTiet"] += donkh.LyDoLoaiKhac + ", ";
                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Trim().Length==11)
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                dr["NoiDung"] = itemRow["NoiDung"];

                //string str = "";
                //str = _cDonTXL.GetNVKiemTraDonKHbyMaDon(donkh.MaDon);
                //if (donkh.ChuyenToXuLy)
                //    str = ", TXL";
                //dr["NVKiemTra"] = str;

                dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
            }

            rptDSDonKH rpt = new rptDSDonKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvDSDonKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDonKH.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDonKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDonKH.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmNhanDonTKH frm = new frmNhanDonTKH(decimal.Parse(dgvDSDonKH["MaDon", dgvDSDonKH.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void dgvDSDonKH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDonKH.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null && e.Value.ToString().Length > 2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void btnInChiTiet_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)dgvDSDonKH.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DonKH donkh = _cDonKH.Get(decimal.Parse(itemRow["MaDon"].ToString()));
                if (donkh.Chuyen_KTXM)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

                    dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString();
                    dr["NoiDung"] = itemRow["NoiDung"].ToString();
                    dr["LoaiChuyen"] = "Đi Kiểm Tra";
                    if (donkh.NgayChuyen_KTXM != null)
                        dr["NgayChuyen"] = donkh.NgayChuyen_KTXM.Value.ToString("dd/MM/yyyy");
                    if (donkh.NguoiDi_KTXM != null)
                        dr["GhiChu"] = _cTaiKhoan.GetHoTen(int.Parse(donkh.NguoiDi_KTXM.Value.ToString()));
                    dr["GhiChu"] += ". " + donkh.GhiChuChuyen_KTXM;

                    dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                }
                if (donkh.ChuyenBanDoiKhac)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

                    dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString();
                    dr["NoiDung"] = itemRow["NoiDung"].ToString();
                    dr["LoaiChuyen"] = "Đi Ban Đội Khác";
                    if (donkh.NgayChuyenBanDoiKhac != null)
                        dr["NgayChuyen"] = donkh.NgayChuyenBanDoiKhac.Value.ToString("dd/MM/yyyy");
                    dr["GhiChu"] = donkh.GhiChuChuyenBanDoiKhac;

                    dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                }
                if (donkh.ChuyenToXuLy)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

                    dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString();
                    dr["NoiDung"] = itemRow["NoiDung"].ToString();
                    dr["LoaiChuyen"] = "Đi Tổ Khách Hàng";
                    if (donkh.NgayChuyenToXuLy != null)
                        dr["NgayChuyen"] = donkh.NgayChuyenToXuLy.Value.ToString("dd/MM/yyyy");
                    dr["GhiChu"] = donkh.GhiChuChuyenToXuLy;

                    dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                }
                if (donkh.ChuyenBanDoiKhac)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

                    dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString();
                    dr["NoiDung"] = itemRow["NoiDung"].ToString();
                    dr["LoaiChuyen"] = "Đi Khác";
                    if (donkh.NgayChuyenKhac != null)
                        dr["NgayChuyen"] = donkh.NgayChuyenKhac.Value.ToString("dd/MM/yyyy");
                    dr["GhiChu"] = donkh.GhiChuChuyenKhac;

                    dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                }
            }
            rptChiTietDonTXL rpt = new rptChiTietDonTXL();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }
    }
}
