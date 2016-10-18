﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmDSTruyThuTienNuoc : Form
    {
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();

        public frmDSTruyThuTienNuoc()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmQLTruyThuTienNuoc_Load(object sender, EventArgs e)
        {
            dgvDSTruyThuTienNuoc.AutoGenerateColumns = false;
            dateTimKiem.Location = txtNoiDungTimKiem.Location;
        }

        private void CountdgvDSTruyThuTienNuoc()
        {
            int Tongm3 = 0;
            int TongTien = 0;
            foreach (DataGridViewRow item in dgvDSTruyThuTienNuoc.Rows)
            {
                Tongm3 += _cTTTN.CountTongm3(decimal.Parse(item.Cells["MaTTTN"].Value.ToString()));
                TongTien += _cTTTN.CountTongTienThanhToan(decimal.Parse(item.Cells["MaTTTN"].Value.ToString()));
            }
            txtTongm3.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Tongm3);
            txtTongTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTien);
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Số Phiếu":
                    txtNoiDungTimKiem.Visible = true;
                    //txtNoiDungTimKiem2.Visible = true;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Danh Bộ":
                    txtNoiDungTimKiem.Visible = true;
                    //txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    //txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Khoảng Thời Gian":
                    txtNoiDungTimKiem.Visible = false;
                    //txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    //txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvDSTruyThuTienNuoc.DataSource = null;
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiDungTimKiem.Text.Trim() != "")
            {
                txtNoiDungTimKiem2.Text = "";
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Số Phiếu":
                        dgvDSTruyThuTienNuoc.DataSource = _cTTTN.LoadDSTruyThuTienNuocbySoPhieu(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                        break;
                    case "Danh Bộ":
                        dgvDSTruyThuTienNuoc.DataSource = _cTTTN.LoadDSTruyThuTienNuocbyDanhBo(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                        break;
                }
                CountdgvDSTruyThuTienNuoc();
            }
        }

        private void txtNoiDungTimKiem2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            dgvDSTruyThuTienNuoc.DataSource = _cTTTN.LoadDSTruyThuTienNuocbyCreateDate(dateTimKiem.Value);
            CountdgvDSTruyThuTienNuoc();
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            dgvDSTruyThuTienNuoc.DataSource = _cTTTN.LoadDSTruyThuTienNuocbyCreateDates(dateTu.Value, dateDen.Value);
            CountdgvDSTruyThuTienNuoc();
        }

        private void dgvDSTruyThuTienNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "MaDon")
            {
                //TruyThuTienNuoc tttn = _cTTTN.getTruyThuTienNuocbyMaTTTN(decimal.Parse(dgvDSTruyThuTienNuoc["MaTTTN", e.RowIndex].Value.ToString()));
                //if (tttn.ToXuLy)
                //    e.Value = "TXL" + tttn.MaDonTXL.Value.ToString().Insert(tttn.MaDonTXL.Value.ToString().Length - 2, "-");
                //else
                //    e.Value = tttn.MaDonTXL.Value.ToString().Insert(tttn.MaDonTXL.Value.ToString().Length - 2, "-");
            }
            if (dgvDSTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "MaTTTN" && e.Value != null&&e.Value.ToString().Length>2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "Tongm3" )
            {
                e.Value = _cTTTN.CountTongm3(decimal.Parse(dgvDSTruyThuTienNuoc["MaTTTN",e.RowIndex].Value.ToString()));
            }
            if (dgvDSTruyThuTienNuoc.Columns[e.ColumnIndex].Name == "TongTien" )
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cTTTN.CountTongTienThanhToan(decimal.Parse(dgvDSTruyThuTienNuoc["MaTTTN", e.RowIndex].Value.ToString())));
            }
        }

        private void dgvDSTruyThuTienNuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSTruyThuTienNuoc.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmShowTruyThuTienNuoc frm = new frmShowTruyThuTienNuoc(decimal.Parse(dgvDSTruyThuTienNuoc["MaTTTN", dgvDSTruyThuTienNuoc.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        

        
    }
}