using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.GUI.ToKhachHang;
using DevExpress.XtraGrid.Views.Grid;
using KTKS_DonKH.DAL.QuanTri;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.BamChi;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmDSBamChi : Form
    {
        CBamChi _cBamChi = new CBamChi();

        public frmDSBamChi()
        {
            InitializeComponent();
        }

        private void frmDSBamChi_Load(object sender, EventArgs e)
        {
            dgvDSCTBamChi.AutoGenerateColumns = false;

            cmbTimTheo.SelectedItem = "Ngày";
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
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
            dgvDSCTBamChi.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.TruongPhong == true || CTaiKhoan.ToTruong == true || CTaiKhoan.ThuKy == true)
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                dgvDSCTBamChi.DataSource = _cBamChi.getDS("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                    dgvDSCTBamChi.DataSource = _cBamChi.getDS("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                else
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                        dgvDSCTBamChi.DataSource = _cBamChi.getDS("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        dgvDSCTBamChi.DataSource = _cBamChi.getDS("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                        break;
                    case "Danh Bộ":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSCTBamChi.DataSource = _cBamChi.getDS_DanhBo(txtNoiDungTimKiem.Text.Trim());
                        break;
                    case "Ngày":
                        dgvDSCTBamChi.DataSource = _cBamChi.getDS(dateTu.Value, dateDen.Value);
                        break;
                    default:
                        break;
                }
            else
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                dgvDSCTBamChi.DataSource = _cBamChi.getDS("TKH", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                    dgvDSCTBamChi.DataSource = _cBamChi.getDS("TXL", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                else
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                        dgvDSCTBamChi.DataSource = _cBamChi.getDS("TBC", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        dgvDSCTBamChi.DataSource = _cBamChi.getDS("", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                        break;
                    case "Danh Bộ":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSCTBamChi.DataSource = _cBamChi.getDS(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                        break;
                    case "Ngày":
                        dgvDSCTBamChi.DataSource = _cBamChi.getDS(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                        break;
                    default:
                        break;
                }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtGroupMauSac = _cBamChi.getDS_GroupMauSac(dateTu.Value, dateDen.Value);
                DataSetBaoCao[] dsBaoCao = new DataSetBaoCao[dtGroupMauSac.Rows.Count];
                for (int i = 0; i < dtGroupMauSac.Rows.Count; i++)
                {
                    dsBaoCao[i] = new DataSetBaoCao();
                }
                foreach (DataGridViewRow item in dgvDSCTBamChi.Rows)
                {
                    for (int i = 0; i < dtGroupMauSac.Rows.Count; i++)
                        if (dtGroupMauSac.Rows[i]["MauSac"].ToString() == item.Cells["MauSac"].Value.ToString())
                        {
                            DataRow dr = dsBaoCao[i].Tables["DSBamChi"].NewRow();

                            dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                            dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                            dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                            if (!string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString()))
                                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                            dr["TenLD"] = item.Cells["TenLD"].Value.ToString();
                            dr["HopDong"] = item.Cells["HopDong"].Value.ToString();
                            dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                            dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                            dr["NgayBC"] = item.Cells["NgayBC"].Value.ToString();
                            dr["Hieu"] = item.Cells["Hieu"].Value.ToString();
                            dr["Co"] = item.Cells["Co"].Value.ToString();
                            dr["ChiSo"] = item.Cells["ChiSo"].Value.ToString();
                            dr["TrangThaiBC"] = item.Cells["TrangThaiBC"].Value.ToString();
                            dr["VienChi"] = item.Cells["VienChi"].Value.ToString();
                            dr["DayChi"] = item.Cells["DayChi"].Value.ToString();
                            dr["MaSoBC"] = item.Cells["NiemChi"].Value.ToString();
                            dr["MauSac"] = "(màu " + item.Cells["MauSac"].Value.ToString().ToUpper() + ")";
                            dr["NguoiBC"] = item.Cells["CreateBy"].Value.ToString();
                            dr["TheoYeuCau"] = item.Cells["TheoYeuCau"].Value.ToString().ToUpper();
                            dr["NguoiKy"] = CTaiKhoan.NguoiKy;
                            dr["NguoiLap"] = CTaiKhoan.HoTen;

                            dsBaoCao[i].Tables["DSBamChi"].Rows.Add(dr);
                        }
                }
                for (int i = 0; i < dtGroupMauSac.Rows.Count; i++)
                    if (dsBaoCao[i].Tables["DSBamChi"].Rows.Count > 0)
                    {
                        rptDSBamChi rpt = new rptDSBamChi();
                        rpt.SetDataSource(dsBaoCao[i]);
                        rpt.Subreports[0].SetDataSource(dsBaoCao[i]);
                        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                        frm.Show();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInQuetToanVatTu_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtGroupMauSac = _cBamChi.getDS_GroupMauSac(dateTu.Value, dateDen.Value);
                DataSetBaoCao[] dsBaoCao = new DataSetBaoCao[dtGroupMauSac.Rows.Count];
                for (int i = 0; i < dtGroupMauSac.Rows.Count; i++)
                {
                    dsBaoCao[i] = new DataSetBaoCao();
                }
                foreach (DataGridViewRow item in dgvDSCTBamChi.Rows)
                {
                    for (int i = 0; i < dtGroupMauSac.Rows.Count; i++)
                        if (dtGroupMauSac.Rows[i]["MauSac"].ToString() == item.Cells["MauSac"].Value.ToString())
                        {
                            DataRow dr = dsBaoCao[i].Tables["QuyetToanVatTu"].NewRow();

                            dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                            dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                            if (!string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString()))
                                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                            if (item.Cells["Co"].Value.ToString() == "")
                            {
                                MessageBox.Show("Có Biên Bản không có nhập Cỡ ĐHN", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            dr["Co"] = item.Cells["Co"].Value.ToString();
                            dr["NiemChi"] = item.Cells["NiemChi"].Value.ToString();
                            dr["MauSac"] = "(màu " + item.Cells["MauSac"].Value.ToString().ToUpper() + ")";
                            dr["DayChi"] = double.Parse(item.Cells["DayChi"].Value.ToString());
                            dr["TheoYeuCau"] = item.Cells["TheoYeuCau"].Value.ToString().ToUpper();
                            dr["NguoiLap"] = CTaiKhoan.HoTen;

                            dsBaoCao[i].Tables["QuyetToanVatTu"].Rows.Add(dr);
                        }
                }
                for (int i = 0; i < dtGroupMauSac.Rows.Count; i++)
                    if (dsBaoCao[i].Tables["QuyetToanVatTu"].Rows.Count > 0)
                    {
                        rptQuyetToanVatTu_NiemChi rpt = new rptQuyetToanVatTu_NiemChi();
                        rpt.SetDataSource(dsBaoCao[i]);
                        ///report 0 là header
                        for (int j = 1; j < rpt.Subreports.Count; j++)
                        {
                            rpt.Subreports[j].SetDataSource(dsBaoCao[i]);
                        }
                        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                        frm.Show();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDSCTBamChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSCTBamChi.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmBamChi frm = new frmBamChi(decimal.Parse(dgvDSCTBamChi["MaCTBC", dgvDSCTBamChi.CurrentRow.Index].Value.ToString()));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //if (CTaiKhoan.RoleQLBamChi_Xem || CTaiKhoan.RoleQLBamChi_CapNhat)
                    //    DSDon_BS.DataSource = _cBamChi.LoadDSCTBamChi();
                    //else
                    //    DSDon_BS.DataSource = _cBamChi.LoadDSCTBamChi(CTaiKhoan.MaUser);
                }

            }
        }

        private void dgvDSCTBamChi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSCTBamChi.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSCTBamChi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvDSCTBamChi.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            //{
            //    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
        }

        private void btnChotQuyetToan_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.Admin == true || CTaiKhoan.ToTruong == true)
            {
                foreach (DataGridViewRow item in dgvDSCTBamChi.Rows)
                    if (item.Cells["NgayQuyetToan"].Value.ToString() != "")
                    {
                        MessageBox.Show("Đã Chốt Quyết Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                foreach (DataGridViewRow item in dgvDSCTBamChi.Rows)
                {
                    BamChi_ChiTiet en = _cBamChi.GetCT(decimal.Parse(item.Cells["MaCTBC"].Value.ToString()));
                    en.NgayQuyetToan = dateQuyetToan.Value;
                    _cBamChi.SuaCT(en);
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnHuyChotQuyetToan_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.Admin == true || CTaiKhoan.ToTruong == true)
            {
                foreach (DataGridViewRow item in dgvDSCTBamChi.Rows)
                    if (item.Cells["NgayQuyetToan"].Value.ToString() == "")
                    {
                        MessageBox.Show("BB Chưa Chốt Quyết Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                foreach (DataGridViewRow item in dgvDSCTBamChi.Rows)
                {
                    BamChi_ChiTiet en = _cBamChi.GetCT(decimal.Parse(item.Cells["MaCTBC"].Value.ToString()));
                    en.NgayQuyetToan = null;
                    _cBamChi.SuaCT(en);
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


    }
}
