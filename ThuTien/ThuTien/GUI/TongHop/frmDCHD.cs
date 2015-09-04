﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.BaoCao;
using ThuTien.BaoCao.TongHop;
using KTKS_DonKH.GUI.BaoCao;

namespace ThuTien.GUI.TongHop
{
    public partial class frmDCHD : Form
    {
        string _mnu = "mnuDCHD";
        CDCHD _cDCHD = new CDCHD();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmDCHD()
        {
            InitializeComponent();
        }

        private void frmDCHDNew_Load(object sender, EventArgs e)
        {

        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()) && e.KeyChar == 13)
            {
                dgvHoaDon.DataSource = _cHoaDon.GetDSByDanhBo(txtDanhBo.Text.Trim());
            }
        }

        private void dgvHoaDon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvHoaDon.RowCount > 0 && e.Button == MouseButtons.Left)
            {
                frmShowDCHD frm = new frmShowDCHD(dgvHoaDon.SelectedRows[0].Cells["SoHoaDon"].Value.ToString());
                frm.ShowDialog();
                btnXem.PerformClick();
            }
        }

        private void dgvDCHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvDCHD.RowCount > 0 && e.Button==MouseButtons.Left)
            {
                frmShowDCHD frm = new frmShowDCHD(dgvDCHD.SelectedRows[0].Cells["SoHoaDon_DC"].Value.ToString());
                frm.ShowDialog();
                btnXem.PerformClick();
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDCHD.DataSource = _cDCHD.GetDSByNgayDC(dateTu.Value, dateDen.Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _cDCHD.BeginTransaction();
                    foreach (DataGridViewRow item in dgvDCHD.SelectedRows)
                    {
                        DIEUCHINH_HD dchd = _cDCHD.GetByMaDCHD(int.Parse(item.Cells["MaDCHD"].Value.ToString()));
                        if (!_cHoaDon.CheckDangNganBySoHoaDon(dchd.SoHoaDon))
                        {
                            if (_cDCHD.Xoa(dchd))
                            {
                                try
                                {
                                    HOADON hoadon = _cHoaDon.GetBySoHoaDon(item.Cells["SoHoaDon_DC"].Value.ToString());
                                    hoadon.GIABAN = dchd.GIABAN_BD;
                                    hoadon.THUE = dchd.THUE_BD;
                                    hoadon.PHI = dchd.PHI_BD;
                                    hoadon.TONGCONG = dchd.TONGCONG_BD;
                                    _cHoaDon.Sua(hoadon);
                                }
                                catch (Exception)
                                {
                                    _cDCHD.Rollback();
                                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                _cDCHD.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            _cDCHD.Rollback();
                            dgvDCHD.ClearSelection();
                            dgvDCHD.Rows[item.Index].Selected = true;
                            MessageBox.Show("Hóa đơn đã Đăng Ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    _cDCHD.CommitTransaction();
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInDSDangNgan_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDCHD.GetDSDangNgan(dateTu.Value, dateDen.Value);
            dsBaoCao ds = new dsBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["DSDCHD"].NewRow();
                dr["LoaiBaoCao"] = "ĐĂNG NGÂN";
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                dr["Ky"] = item["Ky"].ToString();
                dr["SoHoaDon"] = item["SoHoaDon"].ToString();
                dr["GiaBan"] = item["GiaBan_End"].ToString();
                dr["ThueGTGT"] = item["ThueGTGT_End"].ToString();
                dr["PhiBVMT"] = item["PhiBVMT_End"].ToString();
                dr["TongCong"] = item["TongCong_End"].ToString();
                dr["TongCongTruoc"] = item["TongCong_Start"].ToString();
                dr["TongCongBD"] = item["TongCong_BD"].ToString();
                dr["HanhThu"] = item["HanhThu"].ToString();
                dr["To"] = item["To"].ToString();
                ds.Tables["DSDCHD"].Rows.Add(dr);
            }
            rptDSDCHD rpt = new rptDSDCHD();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInDSTon_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDCHD.GetDSTon();
            dsBaoCao ds = new dsBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["DSDCHD"].NewRow();
                dr["LoaiBaoCao"] = "TỒN";
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                dr["Ky"] = item["Ky"].ToString();
                dr["SoHoaDon"] = item["SoHoaDon"].ToString();
                dr["GiaBan"] = item["GiaBan_End"].ToString();
                dr["ThueGTGT"] = item["ThueGTGT_End"].ToString();
                dr["PhiBVMT"] = item["PhiBVMT_End"].ToString();
                dr["TongCong"] = item["TongCong_End"].ToString();
                dr["TongCongTruoc"] = item["TongCong_Start"].ToString();
                dr["TongCongBD"] = item["TongCong_BD"].ToString();
                dr["HanhThu"] = item["HanhThu"].ToString();
                dr["To"] = item["To"].ToString();
                ds.Tables["DSDCHD"].Rows.Add(dr);
            }
            rptDSDCHD rpt = new rptDSDCHD();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDCHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "DanhBo_DC" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "GiaBan_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "ThueGTGT_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "PhiBVMT_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TongCong_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TongCong_BD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TongCong_Start" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDCHD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDCHD.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    
    }
}
