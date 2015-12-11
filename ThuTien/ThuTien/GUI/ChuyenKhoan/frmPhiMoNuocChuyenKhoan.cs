﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmPhiMoNuocChuyenKhoan : Form
    {
        string _mnu = "mnuPhiMoNuocChuyenKhoan";
        CTienDu _cTienDu = new CTienDu();
        CPhiMoNuoc _cPhiMoNuoc = new CPhiMoNuoc();

        public frmPhiMoNuocChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmPhiMoNuocChuyenKhoan_Load(object sender, EventArgs e)
        {
            dgvTienDu.AutoGenerateColumns = false;
            dgvPhiMoNuoc.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvTienDu.DataSource = _cTienDu.GetDSPhiMoNuoc();

            if (dateTu.Value <= dateDen.Value)
                dgvPhiMoNuoc.DataSource = _cPhiMoNuoc.GetDS(dateTu.Value, dateDen.Value);
        }

        private void dgvPhiMoNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "MaPMN" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "DanhBo_PMN" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvPhiMoNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvPhiMoNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvPhiMoNuoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "GhiChu_PMN" && e.FormattedValue.ToString() != dgvPhiMoNuoc[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(dgvPhiMoNuoc["MaPMN", e.RowIndex].Value.ToString()));
                    phimonuoc.GhiChu = e.FormattedValue.ToString();
                    _cPhiMoNuoc.Sua(phimonuoc);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "NhanHD_PMN" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvPhiMoNuoc[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(dgvPhiMoNuoc["MaPMN", e.RowIndex].Value.ToString()));
                    if (bool.Parse(e.FormattedValue.ToString()))
                    {
                        phimonuoc.NhanHD = bool.Parse(e.FormattedValue.ToString());
                        phimonuoc.NgayNhanHD = DateTime.Now;
                    }
                    else
                    {
                        phimonuoc.NhanHD = bool.Parse(e.FormattedValue.ToString());
                        phimonuoc.NgayNhanHD = null;
                    }
                    _cPhiMoNuoc.Sua(phimonuoc);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "TraHD_PMN" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvPhiMoNuoc[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(dgvPhiMoNuoc["MaPMN", e.RowIndex].Value.ToString()));
                    if (bool.Parse(e.FormattedValue.ToString()))
                    {
                        phimonuoc.TraHD = bool.Parse(e.FormattedValue.ToString());
                        phimonuoc.NgayTraHD = DateTime.Now;
                    }
                    else
                    {
                        phimonuoc.TraHD = bool.Parse(e.FormattedValue.ToString());
                        phimonuoc.NgayTraHD = null;
                    }
                    _cPhiMoNuoc.Sua(phimonuoc);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();

            DataRow dr = ds.Tables["PhiMoNuoc"].NewRow();
            dr["SoPhieu"] = dgvPhiMoNuoc.SelectedRows[0].Cells["MaPMN"].Value.ToString().Insert(dgvPhiMoNuoc.SelectedRows[0].Cells["MaPMN"].Value.ToString().Length-2, "-");
            dr["DanhBo"] = dgvPhiMoNuoc.SelectedRows[0].Cells["DanhBo_PMN"].Value.ToString();
            dr["HoTen"] = dgvPhiMoNuoc.SelectedRows[0].Cells["HoTen_PMN"].Value.ToString();
            dr["DiaChi"] = dgvPhiMoNuoc.SelectedRows[0].Cells["DiaChi_PMN"].Value.ToString();
            DateTime NgayBK=new DateTime();
            DateTime.TryParse(dgvPhiMoNuoc.SelectedRows[0].Cells["NgayBK_PMN"].Value.ToString(), out NgayBK);
            dr["NgayBK"] = NgayBK.ToString("dd/MM/yyyy");
            dr["SoTien"] = dgvPhiMoNuoc.SelectedRows[0].Cells["SoTien_PMN"].Value.ToString();
            dr["TongCong"] = dgvPhiMoNuoc.SelectedRows[0].Cells["TongCong_PMN"].Value.ToString();
            ds.Tables["PhiMoNuoc"].Rows.Add(dr);

            rptChuyenPhiMoNuoc rpt = new rptChuyenPhiMoNuoc();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn Xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_cTienDu.Update(dgvPhiMoNuoc.SelectedRows[0].Cells["DanhBo_PMN"].Value.ToString(), 50000, "Điều Chỉnh Tiền", "Xóa Chuyển Phí Mở Nước"))
                    {
                        TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(dgvPhiMoNuoc.SelectedRows[0].Cells["MaPMN"].Value.ToString()));
                        if (_cPhiMoNuoc.Xoa(phimonuoc))
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
    }
}
