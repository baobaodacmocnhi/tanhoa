using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DonTu;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmDSDonTu : Form
    {
        CDonTu _cDonTu = new CDonTu();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CPhongBanDoi _cPhongBanDoi = new CPhongBanDoi();

        public frmDSDonTu()
        {
            InitializeComponent();
        }

        private void frmDSDonTu_Load(object sender, EventArgs e)
        {
            dgvDSDonTu.AutoGenerateColumns = false;

            if (CTaiKhoan.Admin)
            {
                lbPhong.Visible = true;
                cmbPhong.Visible = true;
                DataTable dt = _cPhongBanDoi.getDS_ConfigChuongTrinh();
                DataRow dr = dt.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "Tất Cả";
                dt.Rows.InsertAt(dr, 0);
                cmbPhong.DataSource = dt;
                cmbPhong.ValueMember = "ID";
                cmbPhong.DisplayMember = "Name";
            }
            else
            {
                lbPhong.Visible = false;
                cmbPhong.Visible = false;
            }

            cmbTimTheo.SelectedItem = "Ngày";
            cmbLoai.SelectedIndex = 0;
            gridControl.LevelTree.Nodes.Add("Chi Tiết Đơn", gridViewDonChiTiet);
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Số Công Văn":
                    txtNoiDungTimKiem.Visible = true;
                    //txtNoiDungTimKiem2.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    //txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    cmbLoai.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    //txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    cmbLoai.Visible = false;
                    break;
            }
            dgvDSDonTu.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.Admin == true)
            {
                //tất cả
                if (cmbPhong.SelectedIndex == 0)
                    switch (cmbTimTheo.SelectedItem.ToString())
                    {
                        case "Mã Đơn":
                            //if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                            //    dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(txtNoiDungTimKiem2.Text.Trim()));
                            //else
                            if (txtNoiDungTimKiem.Text.Trim() != "")
                                dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()));
                            break;
                        case "Danh Bộ":
                            if (txtNoiDungTimKiem.Text.Trim() != "")
                                dgvDSDonTu.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                            break;
                        case "Số Công Văn":
                            if (txtNoiDungTimKiem.Text.Trim() != "")
                                dgvDSDonTu.DataSource = _cDonTu.getDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                            break;
                        case "Ngày":
                            dgvDSDonTu.DataSource = _cDonTu.getDS(dateTu.Value, dateDen.Value);
                            //gridControl1.DataSource = _cDonTu.GetDS(dateTu.Value, dateDen.Value);
                            break;
                        default:
                            break;
                    }
                else
                    //chia phòng
                    if (cmbPhong.SelectedIndex > 0)
                        switch (cmbTimTheo.SelectedItem.ToString())
                        {
                            case "Mã Đơn":
                                //if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                                //    dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(txtNoiDungTimKiem2.Text.Trim()));
                                //else
                                if (txtNoiDungTimKiem.Text.Trim() != "")
                                    //dgvDSDonTu.DataSource = _cDonTu.getDS_Phong(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(cmbPhong.SelectedValue.ToString()));
                                    dgvDSDonTu.DataSource = _cDonTu.getDS_Phong_GridControl(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(cmbPhong.SelectedValue.ToString())).Tables["DonTu"];
                                break;
                            case "Danh Bộ":
                                if (txtNoiDungTimKiem.Text.Trim() != "")
                                    //dgvDSDonTu.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""), int.Parse(cmbPhong.SelectedValue.ToString()));
                                    dgvDSDonTu.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo_GridControl(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""), int.Parse(cmbPhong.SelectedValue.ToString())).Tables["DonTu"];
                                break;
                            case "Số Công Văn":
                                if (txtNoiDungTimKiem.Text.Trim() != "")
                                    //dgvDSDonTu.DataSource = _cDonTu.getDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper(), int.Parse(cmbPhong.SelectedValue.ToString()));
                                    dgvDSDonTu.DataSource = _cDonTu.getDSBySoCongVan_GridControl(txtNoiDungTimKiem.Text.Trim().ToUpper(), int.Parse(cmbPhong.SelectedValue.ToString())).Tables["DonTu"];
                                break;
                            case "Ngày":
                                //dgvDSDonTu.DataSource = _cDonTu.getDS(cmbLoai.Text, dateTu.Value, dateDen.Value, int.Parse(cmbPhong.SelectedValue.ToString()));
                                gridControl.DataSource = _cDonTu.getDS_GridControl(cmbLoai.Text, dateTu.Value, dateDen.Value, int.Parse(cmbPhong.SelectedValue.ToString())).Tables["DonTu"];
                                break;
                            default:
                                break;
                        }
            }
            else
            {
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        //if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        //    dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(txtNoiDungTimKiem2.Text.Trim()));
                        //else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            //dgvDSDonTu.DataSource = _cDonTu.getDS_Phong(int.Parse(txtNoiDungTimKiem.Text.Trim()), CTaiKhoan.MaPhong);
                            dgvDSDonTu.DataSource = _cDonTu.getDS_Phong_GridControl(int.Parse(txtNoiDungTimKiem.Text.Trim()), CTaiKhoan.MaPhong).Tables["DonTu"];
                        break;
                    case "Danh Bộ":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            //dgvDSDonTu.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""), CTaiKhoan.MaPhong);
                            dgvDSDonTu.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo_GridControl(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""), CTaiKhoan.MaPhong).Tables["DonTu"];
                        break;
                    case "Số Công Văn":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            //dgvDSDonTu.DataSource = _cDonTu.getDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper(), CTaiKhoan.MaPhong);
                            dgvDSDonTu.DataSource = _cDonTu.getDSBySoCongVan_GridControl(txtNoiDungTimKiem.Text.Trim().ToUpper(), CTaiKhoan.MaPhong).Tables["DonTu"];
                        break;
                    case "Ngày":
                        //dgvDSDonTu.DataSource = _cDonTu.getDS(cmbLoai.Text, dateTu.Value, dateDen.Value, CTaiKhoan.MaPhong);
                        gridControl.DataSource = _cDonTu.getDS_GridControl(cmbLoai.Text, dateTu.Value, dateDen.Value, CTaiKhoan.MaPhong).Tables["DonTu"];
                        break;
                    default:
                        break;
                }
            }
        }

        private void dgvDSDonTu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDonTu.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvDSDonTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDonTu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDonTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDonTu.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmNhanDonTu frm = new frmNhanDonTu(int.Parse(dgvDSDonTu["MaDon", dgvDSDonTu.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void btnInDSDon_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
            //foreach (DataGridViewRow item in dgvDSDonTu.Rows)
            //{
            //        DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();

            //        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy HH:mm");
            //        dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy HH:mm");
            //        dr["Ma"] = item.Cells["MaDon"].Value.ToString();
            //        dr["CreateDate"] = item.Cells["CreateDate"].Value.ToString();
            //        if (item.Cells["DanhBo"].Value.ToString().Length == 11)
            //            dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
            //        dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
            //        dr["NoiDung"] = item.Cells["NoiDung"].Value.ToString();
            //        if (CTaiKhoan.MaPhong == 1)
            //        {
            //            dr["NoiNhan"] = _cPhongBanDoi.getTenPhong_ConfigChuongTrinh(2);
            //            dr["VisibleNoiNhan"] = true;
            //        }
            //        dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
            //        dr["NguoiLap"] = CTaiKhoan.HoTen;
            //        dr["ChuKy"] = CTaiKhoan.ChuKy;

            //        dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            //}
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy HH:mm");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy HH:mm");
                dr["Ma"] = item["MaDon"].ToString();
                dr["CreateDate"] = item["CreateDate"].ToString();
                if (item["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = item["DiaChi"].ToString();
                dr["NoiDung"] = item["NoiDung"].ToString();
                if (CTaiKhoan.MaPhong == 1)
                {
                    dr["NoiNhan"] = _cPhongBanDoi.getTenPhong_ConfigChuongTrinh(2);
                    dr["VisibleNoiNhan"] = true;
                }
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["NguoiLap"] = CTaiKhoan.HoTen;
                dr["ChuKy"] = CTaiKhoan.ChuKy;

                dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            }
            rptDSChuyenDonTu rpt = new rptDSChuyenDonTu();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInThongKe_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
            //foreach (DataGridViewRow item in dgvDSDonTu.Rows)
            //{
            //    DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();

            //    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy HH:mm");
            //    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy HH:mm");
            //    dr["Ma"] = item.Cells["MaDon"].Value.ToString();
            //    dr["CreateDate"] = item.Cells["CreateDate"].Value.ToString();
            //    if (item.Cells["DanhBo"].Value.ToString().Length == 11)
            //        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
            //    dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
            //    dr["NoiDung"] = item.Cells["NoiDung"].Value.ToString();
            //    if (CTaiKhoan.MaPhong == 1)
            //    {
            //        dr["NoiNhan"] = _cPhongBanDoi.getTenPhong_ConfigChuongTrinh(2);
            //        dr["VisibleNoiNhan"] = true;
            //    }
            //    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
            //    dr["NguoiLap"] = CTaiKhoan.HoTen;
            //    dr["ChuKy"] = CTaiKhoan.ChuKy;

            //    dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            //}
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy HH:mm");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy HH:mm");
                dr["Ma"] = item["MaDon"].ToString();
                dr["CreateDate"] = item["CreateDate"].ToString();
                if (item["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = item["DiaChi"].ToString();
                dr["NoiDung"] = item["NoiDung"].ToString();
                if (CTaiKhoan.MaPhong == 1)
                {
                    dr["NoiNhan"] = _cPhongBanDoi.getTenPhong_ConfigChuongTrinh(2);
                    dr["VisibleNoiNhan"] = true;
                }
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["NguoiLap"] = CTaiKhoan.HoTen;
                dr["ChuKy"] = CTaiKhoan.ChuKy;

                dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            }
            rptDonTu_GroupNoiDung rpt = new rptDonTu_GroupNoiDung();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();

        }

        private void gridViewDon_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "DanhBo" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.DisplayText = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void gridViewDonChiTiet_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "DanhBo" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.DisplayText = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void gridViewDon_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridViewDonChiTiet_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridViewDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridViewDon.RowCount > 0 && e.Control && e.KeyCode == Keys.F)
            {
                string MaDon = ((DataRowView)gridViewDon.GetRow(gridViewDon.GetSelectedRows()[0])).Row["MaDon"].ToString();

                if (MaDon.Contains(".") == true)
                    MaDon = MaDon.Substring(0, MaDon.IndexOf("."));

                frmNhanDonTu frm = new frmNhanDonTu(int.Parse(MaDon));
                frm.ShowDialog();
            }
        }


    }
}
