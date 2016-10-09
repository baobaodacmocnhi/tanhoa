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
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CBamChi _cBamChi = new CBamChi();
        string _tuNgay = "", _denNgay = "";

        public frmDSBamChi()
        {
            InitializeComponent();
        }

        private void frmDSBamChi_Load(object sender, EventArgs e)
        {
            dgvDSCTBamChi.AutoGenerateColumns = false;
            dateTimKiem.Location = txtNoiDungTimKiem.Location;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (chkInBamChiThan_BBDCMS.Checked)
            {
                DataTable dt = ((DataTable)dgvDSCTBamChi.DataSource).DefaultView.ToTable();
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                    if (itemRow["TrangThaiBC"].ToString() == "Bấm Chì Thân" || itemRow["TrangThaiBC"].ToString() == "BB đứt chì MS")
                    {
                        DataRow dr = dsBaoCao.Tables["DSBamChi"].NewRow();

                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
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
                        if (CTaiKhoan.MaUser != 1 && CTaiKhoan.MaUser != 26 && CTaiKhoan.MaUser != 27)
                            dr["NguoiLap"] = CTaiKhoan.HoTen;

                        dsBaoCao.Tables["DSBamChi"].Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dsBaoCao.Tables["DSBamChi"].NewRow();

                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HopDong"] = itemRow["HopDong"];
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["NgayBC"] = itemRow["NgayBC"];
                        dr["Hieu"] = itemRow["Hieu"];
                        dr["Co"] = itemRow["Co"];
                        dr["ChiSo"] = itemRow["ChiSo"];
                        dr["TrangThai"] = "Loại Khác";
                        dr["VienChi"] = itemRow["VienChi"];
                        dr["DayChi"] = itemRow["DayChi"];
                        dr["MaSoBC"] = itemRow["MaSoBC"];
                        dr["NguoiBC"] = itemRow["CreateBy"];
                        dr["TheoYeuCau"] = itemRow["TheoYeuCau"].ToString().ToUpper();
                        if (CTaiKhoan.MaUser != 1 && CTaiKhoan.MaUser != 26 && CTaiKhoan.MaUser != 27)
                            dr["NguoiLap"] = CTaiKhoan.HoTen;

                        dsBaoCao.Tables["DSBamChi"].Rows.Add(dr);
                    }

                rptDSBamChi_ChiThan_BBDCMS rpt = new rptDSBamChi_ChiThan_BBDCMS();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
            else
            {
                DataTable dt = ((DataTable)dgvDSCTBamChi.DataSource).DefaultView.ToTable();
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSBamChi"].NewRow();

                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
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

                if (CTaiKhoan.MaUser == 1 || CTaiKhoan.MaUser == 25 || CTaiKhoan.MaUser == 26 || CTaiKhoan.MaUser == 27)
                {
                    if (chkLoaiDon.Checked)
                    {
                        rptThongKeDSBamChi_LoaiDon rpt = new rptThongKeDSBamChi_LoaiDon();
                        rpt.SetDataSource(dsBaoCao);
                        rpt.Subreports[0].SetDataSource(dsBaoCao);
                        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                        frm.ShowDialog();
                    }
                    else
                    {
                        rptThongKeDSBamChi rpt = new rptThongKeDSBamChi();
                        rpt.SetDataSource(dsBaoCao);
                        rpt.Subreports[0].SetDataSource(dsBaoCao);
                        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                        frm.ShowDialog();
                    }
                }
                else
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

                dr["TuNgay"] = _tuNgay;
                dr["DenNgay"] = _denNgay;
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

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                    txtNoiDungTimKiem.Visible = true;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Khoảng Thời Gian":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    //DSDon_BS.RemoveFilter();
                    break;
            }
            dgvDSCTBamChi.DataSource = null;
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txtNoiDungTimKiem.Text.Trim() != "")
                //{
                //    string expression = "";
                //    switch (cmbTimTheo.SelectedItem.ToString())
                //    {
                //        case "Mã Đơn":
                //            expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                //            break;
                //        case "Danh Bộ":
                //            expression = String.Format("DanhBo like '{0}%'", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                //            break;
                //    }
                //    DSDon_BS.Filter = expression;
                //}
                //else
                //    DSDon_BS.RemoveFilter();
                if (txtNoiDungTimKiem.Text.Trim() != "")
                {
                    switch (cmbTimTheo.SelectedItem.ToString())
                    {
                        case "Mã Đơn":
                            //dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                            dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByMaDon(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                            break;
                        case "Danh Bộ":
                            //dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByDanhBo(txtNoiDungTimKiem.Text.Trim());
                            dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByDanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            //string expression = String.Format("NgayBC >= #{0:yyyy-MM-dd} 00:00:00# and NgayBC <= #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
            //DSDon_BS.Filter = expression;
            _tuNgay = dateTimKiem.Value.ToString("dd/MM/yyyy");
            //dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByDate(dateTimKiem.Value);
            dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByDate(CTaiKhoan.MaUser, dateTimKiem.Value);
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            //string expression = String.Format("NgayBC >= #{0:yyyy-MM-dd} 00:00:00# and NgayBC <= #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
            //DSDon_BS.Filter = expression;
            _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
            //dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByDate(dateTimKiem.Value);
            dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByDate(CTaiKhoan.MaUser, dateTimKiem.Value);
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            //string expression = String.Format("NgayBC >= #{0:yyyy-MM-dd} 00:00:00# and NgayBC <= #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
            //DSDon_BS.Filter = expression;
            _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
            //dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByDates(dateTu.Value, dateDen.Value);
            dgvDSCTBamChi.DataSource = _cBamChi.LoadDSCTBamChiByDates(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
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
