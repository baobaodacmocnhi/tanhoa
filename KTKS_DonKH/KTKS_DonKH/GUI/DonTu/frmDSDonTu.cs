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
using KTKS_DonKH.LinQ;

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
                //lbPhong.Visible = true;
                //cmbPhong.Visible = true;
                //DataTable dt = _cPhongBanDoi.getDS_ConfigChuongTrinh();
                //DataRow dr = dt.NewRow();
                //dr["ID"] = 0;
                //dr["Name"] = "Tất Cả";
                //dt.Rows.InsertAt(dr, 0);
                //cmbPhong.DataSource = dt;
                //cmbPhong.ValueMember = "ID";
                //cmbPhong.DisplayMember = "Name";
            }
            else
            {
                lbPhong.Visible = false;
                cmbPhong.Visible = false;
            }

            List<Quan> lst = _cDonTu.GetDSQuan();
            Quan quan = new Quan();
            quan.ID = 0;
            quan.Name2 = "Tất Cả";
            lst.Insert(0, quan);
            cmbQuan.DataSource = lst;
            cmbQuan.DisplayMember = "Name2";
            cmbQuan.ValueMember = "ID";

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
                //if (cmbPhong.SelectedIndex == 0)
                //    switch (cmbTimTheo.SelectedItem.ToString())
                //    {
                //        case "Mã Đơn":
                //            //if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                //            //    dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(txtNoiDungTimKiem2.Text.Trim()));
                //            //else
                //            if (txtNoiDungTimKiem.Text.Trim() != "")
                //                dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()));
                //            break;
                //        case "Danh Bộ":
                //            if (txtNoiDungTimKiem.Text.Trim() != "")
                //                dgvDSDonTu.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                //            break;
                //        case "Số Công Văn":
                //            if (txtNoiDungTimKiem.Text.Trim() != "")
                //                dgvDSDonTu.DataSource = _cDonTu.getDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                //            break;
                //        case "Ngày":
                //            dgvDSDonTu.DataSource = _cDonTu.getDS(dateTu.Value, dateDen.Value);
                //            //gridControl1.DataSource = _cDonTu.GetDS(dateTu.Value, dateDen.Value);
                //            break;
                //        default:
                //            break;
                //    }
                //else
                //    //chia phòng
                //    if (cmbPhong.SelectedIndex > 0)
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        //if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        //    dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(txtNoiDungTimKiem2.Text.Trim()));
                        //else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            //dgvDSDonTu.DataSource = _cDonTu.getDS_Phong(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(cmbPhong.SelectedValue.ToString()));
                            gridControl.DataSource = _cDonTu.getDS_Phong_GridControl(int.Parse(txtNoiDungTimKiem.Text.Trim())).Tables["DonTu"];
                        break;
                    case "Danh Bộ":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            //dgvDSDonTu.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""), int.Parse(cmbPhong.SelectedValue.ToString()));
                            gridControl.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo_GridControl(txtNoiDungTimKiem.Text.Trim().Replace(" ", "")).Tables["DonTu"];
                        break;
                    case "Số Công Văn":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            //dgvDSDonTu.DataSource = _cDonTu.getDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper(), int.Parse(cmbPhong.SelectedValue.ToString()));
                            gridControl.DataSource = _cDonTu.getDSBySoCongVan_GridControl(txtNoiDungTimKiem.Text.Trim().ToUpper()).Tables["DonTu"];
                        break;
                    case "Ngày":
                        //dgvDSDonTu.DataSource = _cDonTu.getDS(cmbLoai.Text, dateTu.Value, dateDen.Value, int.Parse(cmbPhong.SelectedValue.ToString()));
                        if (cmbQuan.SelectedIndex == 0)
                            gridControl.DataSource = _cDonTu.getDS_GridControl(cmbLoai.Text, dateTu.Value, dateDen.Value).Tables["DonTu"];
                        else
                            if (cmbQuan.SelectedIndex > 0)
                                if (cmbPhuong.SelectedIndex == 0)
                                    gridControl.DataSource = _cDonTu.getDS_GridControl_Quan(cmbLoai.Text, dateTu.Value, dateDen.Value, int.Parse(cmbQuan.SelectedValue.ToString())).Tables["DonTu"];
                                else
                                    gridControl.DataSource = _cDonTu.getDS_GridControl_QuanPhuong(cmbLoai.Text, dateTu.Value, dateDen.Value, int.Parse(cmbQuan.SelectedValue.ToString()), int.Parse(cmbPhuong.SelectedValue.ToString())).Tables["DonTu"];
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
                            gridControl.DataSource = _cDonTu.getDS_Phong_GridControl(int.Parse(txtNoiDungTimKiem.Text.Trim())).Tables["DonTu"];
                        break;
                    case "Danh Bộ":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            //dgvDSDonTu.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""), CTaiKhoan.MaPhong);
                            gridControl.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo_GridControl(txtNoiDungTimKiem.Text.Trim().Replace(" ", "")).Tables["DonTu"];
                        break;
                    case "Số Công Văn":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            //dgvDSDonTu.DataSource = _cDonTu.getDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper(), CTaiKhoan.MaPhong);
                            gridControl.DataSource = _cDonTu.getDSBySoCongVan_GridControl(txtNoiDungTimKiem.Text.Trim().ToUpper()).Tables["DonTu"];
                        break;
                    case "Ngày":
                        //dgvDSDonTu.DataSource = _cDonTu.getDS(cmbLoai.Text, dateTu.Value, dateDen.Value, CTaiKhoan.MaPhong);
                        if (cmbQuan.SelectedIndex == 0)
                            gridControl.DataSource = _cDonTu.getDS_GridControl(cmbLoai.Text, dateTu.Value, dateDen.Value).Tables["DonTu"];
                        else
                            if (cmbQuan.SelectedIndex > 0)
                                if (cmbPhuong.SelectedIndex == 0)
                                    gridControl.DataSource = _cDonTu.getDS_GridControl_Quan(cmbLoai.Text, dateTu.Value, dateDen.Value, int.Parse(cmbQuan.SelectedValue.ToString())).Tables["DonTu"];
                                else
                                    gridControl.DataSource = _cDonTu.getDS_GridControl_QuanPhuong(cmbLoai.Text, dateTu.Value, dateDen.Value, int.Parse(cmbQuan.SelectedValue.ToString()), int.Parse(cmbPhuong.SelectedValue.ToString())).Tables["DonTu"];
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
                frmNhanDonTu_Old frm = new frmNhanDonTu_Old(int.Parse(dgvDSDonTu["MaDon", dgvDSDonTu.CurrentRow.Index].Value.ToString()));
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

            //foreach (DataRow item in dt.Rows)
            //{
            //    DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();

            //    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy HH:mm");
            //    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy HH:mm");
            //    dr["Ma"] = item["MaDon"].ToString();
            //    dr["CreateDate"] = item["CreateDate"].ToString();
            //    if (item["DanhBo"].ToString().Length == 11)
            //        dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
            //    dr["DiaChi"] = item["DiaChi"].ToString();
            //    dr["NoiDung"] = item["NoiDung"].ToString();
            //    dr["GhiChu"] = item["SoCongVan"].ToString();
            //    if (CTaiKhoan.MaPhong == 1)
            //    {
            //        dr["NoiNhan"] = _cPhongBanDoi.getTenPhong_ConfigChuongTrinh(2);
            //        dr["VisibleNoiNhan"] = true;
            //    }
            //    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
            //    dr["NguoiLap"] = CTaiKhoan.HoTen;
            //    dr["NguoiKy"] = CTaiKhoan.NguoiKy;

            //    dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            //}

            for (int i = 0; i < gridViewDon.DataRowCount; i++)
            {
                DataRow row = gridViewDon.GetDataRow(i);

                DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy HH:mm");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy HH:mm");
                dr["MaChiTiet"] = row["MaDon"].ToString();
                dr["CreateDate"] = row["CreateDate"].ToString();
                if (row["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = row["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = row["DiaChi"].ToString();
                dr["NoiDung"] = row["NoiDungPKH"].ToString();
                dr["GhiChu"] = row["SoCongVan"].ToString();
                if (CTaiKhoan.MaPhong == 1)
                {
                    dr["NoiNhan"] = _cPhongBanDoi.getTenPhong_ConfigChuongTrinh(2);
                    dr["VisibleNoiNhan"] = true;
                }
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["NguoiLap"] = CTaiKhoan.HoTen;
                dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            }
            rptDSChuyenDonTu rpt = new rptDSChuyenDonTu();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
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
                DataRow[] childRows = item.GetChildRows("Chi Tiết Đơn");

                if (childRows.Count() == 0)
                {
                    DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();
                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy HH:mm");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy HH:mm");
                    dr["Ma"] = item["MaDon"].ToString();
                    dr["MaChiTiet"] = item["MaDon"].ToString();
                    //if (item["DanhBo"].ToString().Length == 11)
                    //    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["DiaChi"] = item["NoiDungPKHB"].ToString();
                    dr["CreateDate"] = item["CreateDate"].ToString();
                    dr["NoiDung"] = item["NoiDungPTV"].ToString();
                    //mượn đỡ 2 cột để xét tình trạng
                    dr["GhiChu"] = item["TinhTrang"].ToString();
                    dr["NguoiNhan"] = item["TinhTrang"].ToString();
                    if (CTaiKhoan.MaPhong == 1)
                    {
                        dr["NoiNhan"] = _cPhongBanDoi.getTenPhong_ConfigChuongTrinh(2);
                        dr["VisibleNoiNhan"] = true;
                    }
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                    dr["NguoiLap"] = CTaiKhoan.HoTen;
                    dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                    dsBaoCao.Tables["CongVan"].Rows.Add(dr);
                }
                else
                {
                    foreach (DataRow itemChild in childRows)
                    {
                        DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();
                        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy HH:mm");
                        dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy HH:mm");
                        dr["Ma"] = itemChild["MaDon"].ToString();
                        dr["MaChiTiet"] = item["MaDon"].ToString() + "." + itemChild["STT"].ToString();
                        //if (itemChild["DanhBo"].ToString().Length == 11)
                        //    dr["DanhBo"] = itemChild["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["DiaChi"] = item["NoiDungPKHB"].ToString();
                        dr["CreateDate"] = item["CreateDate"].ToString();
                        dr["NoiDung"] = item["NoiDungPTV"].ToString();
                        //mượn đỡ 2 cột để xét tình trạng
                        dr["GhiChu"] = itemChild["TinhTrang"].ToString();
                        dr["NguoiNhan"] = item["TinhTrang"].ToString();
                        if (CTaiKhoan.MaPhong == 1)
                        {
                            dr["NoiNhan"] = _cPhongBanDoi.getTenPhong_ConfigChuongTrinh(2);
                            dr["VisibleNoiNhan"] = true;
                        }
                        dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                        dr["NguoiLap"] = CTaiKhoan.HoTen;
                        dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                        dsBaoCao.Tables["CongVan"].Rows.Add(dr);
                    }
                }

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

        private void btnInThongKeTon_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            List<LinQ.DonTu> lst = _cDonTu.getDS_GridControl_Ton(cmbLoai.Text, dateTu.Value, dateDen.Value);
            foreach (LinQ.DonTu item in lst)
            {
                if (item.DonTu_ChiTiets.Count() == 1)
                {
                    DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();
                    //dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy HH:mm");
                    //dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy HH:mm");
                    dr["LoaiVanBan"] = "TỒN";
                    dr["Ma"] = item.MaDon;
                    dr["MaChiTiet"] = item.MaDon;
                    if (item.DonTu_ChiTiets.SingleOrDefault().DanhBo != null && item.DonTu_ChiTiets.SingleOrDefault().DanhBo.Length == 11)
                        dr["DanhBo"] = item.DonTu_ChiTiets.SingleOrDefault().DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["DiaChi"] = item.DonTu_ChiTiets.SingleOrDefault().DiaChi;
                    dr["CreateDate"] = item.CreateDate;
                    if (item.CreateDate.Value.Month == 12)
                    {
                        if (item.CreateDate.Value.Day <= 20)
                            dr["NoiDung"] = item.CreateDate.Value.Month.ToString("00") + "/" + item.CreateDate.Value.Year;
                        else
                            dr["NoiDung"] = "01/" + item.CreateDate.Value.Year + 1;
                    }
                    else
                    {
                        if (item.CreateDate.Value.Day <= 20)
                            dr["NoiDung"] = item.CreateDate.Value.Month.ToString("00") + "/" + item.CreateDate.Value.Year;
                        else
                            dr["NoiDung"] = (item.CreateDate.Value.Month + 1).ToString("00") + "/" + item.CreateDate.Value.Year;
                    }
                    //mượn đỡ 2 cột để xét tình trạng
                    dr["GhiChu"] = item.TinhTrang;
                    dr["NoiNhan"] = item.TinhTrang;
                    if (CTaiKhoan.MaPhong == 1)
                    {
                        dr["NoiNhan"] = _cPhongBanDoi.getTenPhong_ConfigChuongTrinh(2);
                        dr["VisibleNoiNhan"] = true;
                    }
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                    dr["NguoiLap"] = CTaiKhoan.HoTen;
                    dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                    dsBaoCao.Tables["CongVan"].Rows.Add(dr);
                }
                else
                {
                    foreach (DonTu_ChiTiet itemCT in item.DonTu_ChiTiets)
                    {
                        DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();
                        //dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy HH:mm");
                        //dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy HH:mm");
                        dr["LoaiVanBan"] = "TỒN";
                        dr["Ma"] = itemCT.MaDon;
                        dr["MaChiTiet"] = itemCT.MaDon + "." + itemCT.STT;
                        if (itemCT.DanhBo != null && itemCT.DanhBo.Length == 11)
                            dr["DanhBo"] = itemCT.DanhBo.Insert(7, " ").Insert(4, " ");
                        dr["DiaChi"] = itemCT.DiaChi;
                        dr["CreateDate"] = itemCT.CreateDate;

                        if (item.CreateDate.Value.Month == 12)
                        {
                            if (item.CreateDate.Value.Day <= 20)
                                dr["NoiDung"] = item.CreateDate.Value.Month.ToString("00") + "/" + item.CreateDate.Value.Year;
                            else
                                dr["NoiDung"] = "01/" + item.CreateDate.Value.Year + 1;
                        }
                        else
                        {
                            if (item.CreateDate.Value.Day <= 20)
                                dr["NoiDung"] = item.CreateDate.Value.Month.ToString("00") + "/" + item.CreateDate.Value.Year;
                            else
                                dr["NoiDung"] = (item.CreateDate.Value.Month + 1).ToString("00") + "/" + item.CreateDate.Value.Year;
                        }
                        //mượn đỡ 2 cột để xét tình trạng
                        dr["GhiChu"] = itemCT.TinhTrang;
                        dr["NoiNhan"] = item.TinhTrang;
                        if (CTaiKhoan.MaPhong == 1)
                        {
                            dr["NoiNhan"] = _cPhongBanDoi.getTenPhong_ConfigChuongTrinh(2);
                            dr["VisibleNoiNhan"] = true;
                        }
                        dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                        dr["NguoiLap"] = CTaiKhoan.HoTen;
                        dr["NguoiKy"] = CTaiKhoan.NguoiKy;

                        dsBaoCao.Tables["CongVan"].Rows.Add(dr);
                    }
                }

            }
            rptDonTu_GroupNoiDung rpt = new rptDonTu_GroupNoiDung();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void cmbQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Phuong> lst = _cDonTu.GetDSPhuong(((Quan)cmbQuan.SelectedItem).ID.Value);
            Phuong phuong = new Phuong();
            phuong.IDPhuong = 0;
            phuong.Name2 = "Tất Cả";
            lst.Insert(0, phuong);
            cmbPhuong.DataSource = lst;
            cmbPhuong.DisplayMember = "Name2";
            cmbPhuong.ValueMember = "IDPhuong";
        }


    }
}
