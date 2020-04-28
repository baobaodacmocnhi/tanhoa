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
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.BaoCao.DongNuoc;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmPhiMoNuoc : Form
    {
        string _mnu = "mnuPhiMoNuoc";
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CTo _cTo = new CTo();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        bool _flagLoadFirst = false;

        public frmPhiMoNuoc()
        {
            InitializeComponent();
        }

        private void frmPhiMoNuoc_Load(object sender, EventArgs e)
        {
            dgvKQDongNuoc.AutoGenerateColumns = false;
            if (CNguoiDung.Doi == true)
            {
                panel_To.Visible = true;
                panel_NhanVien.Visible = true;
                cmbTo.DataSource = _cTo.GetDSHanhThu();
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
                cmbTo.SelectedIndex = -1;
            }
            else if (CNguoiDung.ToTruong == true)
            {
                panel_NhanVien.Visible = true;
                cmbNhanVien.DataSource = _cNguoiDung.GetDSDongNuocByMaTo(CNguoiDung.MaTo);
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            _flagLoadFirst = true;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi == true || CNguoiDung.ToTruong == true)
                dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuoc_DongPhi(int.Parse(cmbNhanVien.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
            else
                dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuoc_DongPhi(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
        }

        private void dgvKQDongNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "MaDN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvKQDongNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKQDongNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                for (int i = 0; i < dgvKQDongNuoc.Rows.Count; i++)
                {
                    dgvKQDongNuoc["In", i].Value = true;
                }
            }
            else
                for (int i = 0; i < dgvKQDongNuoc.Rows.Count; i++)
                {
                    dgvKQDongNuoc["In", i].Value = false;
                }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
                if (item.Cells["In"].Value != null && bool.Parse(item.Cells["In"].Value.ToString()) == true)
                {
                    DataRow dr = dsBaoCao.Tables["KQDongNuoc"].NewRow();
                    dr["NhanVien"] = CNguoiDung.HoTen;
                    dr["STT"] = item.Cells["MaKQDN"];
                    dr["DanhBo"] = item.Cells["DanhBo"];
                    dr["HoTen"] = item.Cells["HoTen"];
                    dr["DiaChi"] = item.Cells["DiaChi"];
                    dr["Co"] = item.Cells["Co"];
                    dr["Hieu"] = item.Cells["Hieu"];
                    dr["SoThan"] = item.Cells["SoThan"];
                    dr["ChiSo"] = item.Cells["ChiSoDN"];
                    dr["GhiChu"] = item.Cells["LyDo"];
                    dr["PhiMoNuoc"] = item.Cells["PhiMoNuoc"];

                    dsBaoCao.Tables["KQDongNuoc"].Rows.Add(dr);
                }
            rptBBDongNuoc rpt = new rptBBDongNuoc();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex != -1)
            {
                cmbNhanVien.DataSource = _cNguoiDung.GetDSDongNuocByMaTo(int.Parse(cmbTo.SelectedValue.ToString()));
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            else
                cmbNhanVien.DataSource = null;
        }


    }
}