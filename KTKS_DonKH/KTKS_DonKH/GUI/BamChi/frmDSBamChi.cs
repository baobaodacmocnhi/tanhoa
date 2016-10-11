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
using KTKS_DonKH.GUI.KhachHang;
using DevExpress.XtraGrid.Views.Grid;
using KTKS_DonKH.DAL.QuanTri;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.BamChi;
using KTKS_DonKH.GUI.BaoCao;

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
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByMaDon(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                    break;
                case "Danh Bộ":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByDanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Ngày":
                    dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByDates(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //if (chkInBamChiThan_BBDCMS.Checked)
            //{
            //    DataTable dt = ((DataTable)dgvDSCTBamChi.DataSource).DefaultView.ToTable();
            //    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            //    foreach (DataRow itemRow in dt.Rows)
            //        if (itemRow["TrangThaiBC"].ToString() == "Bấm Chì Thân" || itemRow["TrangThaiBC"].ToString() == "BB đứt chì MS")
            //        {
            //            DataRow dr = dsBaoCao.Tables["DSBamChi"].NewRow();

            //            dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
            //            dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
            //            if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
            //                dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
            //            dr["HopDong"] = itemRow["HopDong"];
            //            dr["HoTen"] = itemRow["HoTen"];
            //            dr["DiaChi"] = itemRow["DiaChi"];
            //            dr["NgayBC"] = itemRow["NgayBC"];
            //            dr["Hieu"] = itemRow["Hieu"];
            //            dr["Co"] = itemRow["Co"];
            //            dr["ChiSo"] = itemRow["ChiSo"];
            //            dr["TrangThai"] = itemRow["TrangThaiBC"];
            //            dr["VienChi"] = itemRow["VienChi"];
            //            dr["DayChi"] = itemRow["DayChi"];
            //            dr["MaSoBC"] = itemRow["MaSoBC"];
            //            dr["NguoiBC"] = itemRow["CreateBy"];
            //            dr["TheoYeuCau"] = itemRow["TheoYeuCau"].ToString().ToUpper();
            //            if (CTaiKhoan.MaUser != 1 && CTaiKhoan.MaUser != 26 && CTaiKhoan.MaUser != 27)
            //                dr["NguoiLap"] = CTaiKhoan.HoTen;

            //            dsBaoCao.Tables["DSBamChi"].Rows.Add(dr);
            //        }
            //        else
            //        {
            //            DataRow dr = dsBaoCao.Tables["DSBamChi"].NewRow();

            //            dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
            //            dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
            //            if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
            //                dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
            //            dr["HopDong"] = itemRow["HopDong"];
            //            dr["HoTen"] = itemRow["HoTen"];
            //            dr["DiaChi"] = itemRow["DiaChi"];
            //            dr["NgayBC"] = itemRow["NgayBC"];
            //            dr["Hieu"] = itemRow["Hieu"];
            //            dr["Co"] = itemRow["Co"];
            //            dr["ChiSo"] = itemRow["ChiSo"];
            //            dr["TrangThai"] = "Loại Khác";
            //            dr["VienChi"] = itemRow["VienChi"];
            //            dr["DayChi"] = itemRow["DayChi"];
            //            dr["MaSoBC"] = itemRow["MaSoBC"];
            //            dr["NguoiBC"] = itemRow["CreateBy"];
            //            dr["TheoYeuCau"] = itemRow["TheoYeuCau"].ToString().ToUpper();
            //            if (CTaiKhoan.MaUser != 1 && CTaiKhoan.MaUser != 26 && CTaiKhoan.MaUser != 27)
            //                dr["NguoiLap"] = CTaiKhoan.HoTen;

            //            dsBaoCao.Tables["DSBamChi"].Rows.Add(dr);
            //        }

            //    rptDSBamChi_ChiThan_BBDCMS rpt = new rptDSBamChi_ChiThan_BBDCMS();
            //    rpt.SetDataSource(dsBaoCao);
            //    frmShowBaoCao frm = new frmShowBaoCao(rpt);
            //    frm.ShowDialog();
            //}
            //else
            {
                DataTable dt = ((DataTable)dgvDSCTBamChi.DataSource).DefaultView.ToTable();
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSBamChi"].NewRow();

                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["TenLD"] = itemRow["TenLD"];
                    dr["HopDong"] = itemRow["HopDong"];
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["NgayBC"] = itemRow["NgayBC"];
                    dr["Hieu"] = itemRow["Hieu"];
                    dr["Co"] = itemRow["Co"];
                    dr["ChiSo"] = itemRow["ChiSo"];
                    dr["TrangThai"] = itemRow["TrangThaiBC"];
                    dr["VienChi"] = itemRow["VienChi"];
                    dr["DayChi"] = itemRow["DayChi"];
                    dr["MaSoBC"] = itemRow["MaSoBC"];
                    dr["NguoiBC"] = itemRow["CreateBy"];
                    dr["TheoYeuCau"] = itemRow["TheoYeuCau"].ToString().ToUpper();
                    dr["NguoiLap"] = CTaiKhoan.HoTen;

                    dsBaoCao.Tables["DSBamChi"].Rows.Add(dr);
                }

                //if (CTaiKhoan.MaUser == 1 || CTaiKhoan.MaUser == 25 || CTaiKhoan.MaUser == 26 || CTaiKhoan.MaUser == 27)
                //{
                //    if (chkLoaiDon.Checked)
                //    {
                //        rptThongKeDSBamChi_LoaiDon rpt = new rptThongKeDSBamChi_LoaiDon();
                //        rpt.SetDataSource(dsBaoCao);
                //        rpt.Subreports[0].SetDataSource(dsBaoCao);
                //        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                //        frm.ShowDialog();
                //    }
                //    else
                //    {
                //        rptThongKeDSBamChi rpt = new rptThongKeDSBamChi();
                //        rpt.SetDataSource(dsBaoCao);
                //        rpt.Subreports[0].SetDataSource(dsBaoCao);
                //        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                //        frm.ShowDialog();
                //    }
                //}
                //else
                {
                    rptDSBamChi rpt = new rptDSBamChi();
                    rpt.SetDataSource(dsBaoCao);
                    rpt.Subreports[0].SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.ShowDialog();
                }
            }
        }

        private void btnInQuetToanVatTu_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)dgvDSCTBamChi.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["QuyetToanVatTu"].NewRow();

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["Co"] = itemRow["Co"];
                dr["VienChi"] = itemRow["VienChi"];
                dr["DayChi"] = itemRow["DayChi"];
                dr["TheoYeuCau"] = itemRow["TheoYeuCau"].ToString().ToUpper();
                dr["NguoiLap"] = CTaiKhoan.HoTen;

                dsBaoCao.Tables["QuyetToanVatTu"].Rows.Add(dr);
            }

            rptQuyetToanVatTu rpt = new rptQuyetToanVatTu();
            rpt.SetDataSource(dsBaoCao);
            ///report 0 là header
            for (int j = 1; j < rpt.Subreports.Count; j++)
            {
                rpt.Subreports[j].SetDataSource(dsBaoCao);
            }

            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvDSCTBamChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSCTBamChi.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmShowBamChi frm = new frmShowBamChi(decimal.Parse(dgvDSCTBamChi["MaCTBC", dgvDSCTBamChi.CurrentRow.Index].Value.ToString()));
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
            if (dgvDSCTBamChi.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        
    }
}
