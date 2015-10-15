﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.QuanTri;

namespace ThuTien.GUI.TongHop
{
    public partial class frmCongVan : Form
    {
        string _mnu = "mnuCongVan";
        CDongNuoc _cDongNuoc = new CDongNuoc();

        public frmCongVan()
        {
            InitializeComponent();
        }

        private void frmCongVan_Load(object sender, EventArgs e)
        {
            dgvKQDongNuoc.AutoGenerateColumns = false;
            dgvKQMoNuoc.AutoGenerateColumns = false;

            btnXem.PerformClick();
        }

        private void dgvKQDongNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "SoPhieuDN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvKQDongNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKQDongNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvKQMoNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKQMoNuoc.Columns[e.ColumnIndex].Name == "SoPhieuMN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvKQMoNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKQMoNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvKQDongNuoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "ChuyenDN" && e.FormattedValue.ToString() != dgvKQDongNuoc[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (bool.Parse(e.FormattedValue.ToString()) == true)
                        _cDongNuoc.LinQ_ExecuteNonQuery("update TT_KQDongNuoc set ChuyenDN=1,NgayChuyenDN=getdate(),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() where SoPhieuDN=" + dgvKQDongNuoc["SoPhieuDN", e.RowIndex].Value.ToString());
                    else
                        _cDongNuoc.LinQ_ExecuteNonQuery("update TT_KQDongNuoc set ChuyenDN=0,NgayChuyenDN=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() where SoPhieuDN=" + dgvKQDongNuoc["SoPhieuDN", e.RowIndex].Value.ToString());
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKQMoNuoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvKQMoNuoc.Columns[e.ColumnIndex].Name == "ChuyenMN" && e.FormattedValue.ToString() != dgvKQMoNuoc[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (bool.Parse(e.FormattedValue.ToString()) == true)
                        _cDongNuoc.LinQ_ExecuteNonQuery("update TT_KQDongNuoc set ChuyenMN=1,NgayChuyenMN=getdate(),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() where SoPhieuMN=" + dgvKQMoNuoc["SoPhieuMN", e.RowIndex].Value.ToString());
                    else
                        _cDongNuoc.LinQ_ExecuteNonQuery("update TT_KQDongNuoc set ChuyenMN=0,NgayChuyenMN=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() where SoPhieuMN=" + dgvKQMoNuoc["SoPhieuMN", e.RowIndex].Value.ToString());
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSSoPhieuDN();
            dgvKQMoNuoc.DataSource = _cDongNuoc.GetDSSoPhieuMN();
        }

    }
}
