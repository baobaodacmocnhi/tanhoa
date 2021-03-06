﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToKhachHang;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.ToKhachHang
{
    public partial class frmDSDonDienThoai : Form
    {
        CDonDienThoai _cDonDT = new CDonDienThoai();
        CDonKH _cDonKH = new CDonKH();
        CLoaiDon _cLoaiDon = new CLoaiDon();

        public frmDSDonDienThoai()
        {
            InitializeComponent();
        }

        private void frmQLDonDienThoai_Load(object sender, EventArgs e)
        {
            dgvDonDT.AutoGenerateColumns = false;

            //DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDonDT.Columns["MaLD"];
            //cmbColumn.DataSource = _cLoaiDon.LoadDSLoaiDon(true);
            //cmbColumn.DisplayMember = "TenLD";
            //cmbColumn.ValueMember = "MaLD";

            cmbTimTheo.SelectedIndex = 3;
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Danh Bộ":
                case "Địa Chỉ":
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
            dgvDonDT.DataSource = null;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //DataTable dt = ((DataTable)dgvDonDT.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataGridViewRow item in dgvDonDT.Rows)
                if (bool.Parse(item.Cells["In"].Value.ToString()))
                {
                    DataRow dr = dsBaoCao.Tables["DSDonDienThoai"].NewRow();

                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    //dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                    if (!string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString()))
                        if (item.Cells["DanhBo"].Value.ToString().ToUpper() == "GM")
                            dr["DanhBo"] = "GM";
                        else
                            dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");

                    dr["HoTen"] = item.Cells["HoTen"].Value;
                    dr["DiaChi"] = item.Cells["DiaChi"].Value;
                    dr["NoiDung"] = item.Cells["NoiDung"].Value;
                    dr["DienThoai"] = item.Cells["DienThoai"].Value;
                    dr["NguoiBao"] = item.Cells["NguoiBao"].Value;

                    dsBaoCao.Tables["DSDonDienThoai"].Rows.Add(dr);
                }

            rptDSDonDienThoai rpt = new rptDSDonDienThoai();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInDaLapDon_Click(object sender, EventArgs e)
        {
            //DataTable dt = ((DataTable)dgvDonDT.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataGridViewRow item in dgvDonDT.Rows)
                if (!string.IsNullOrEmpty(item.Cells["MaDon"].Value.ToString()))
                {
                    DataRow dr = dsBaoCao.Tables["DSDonDienThoai"].NewRow();

                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    //dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                    dr["MaDon"] = item.Cells["MaDon"].Value.ToString().Insert(item.Cells["MaDon"].Value.ToString().Length - 2, "-");
                    if (!string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString()))
                        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = item.Cells["HoTen"].Value;
                    dr["DiaChi"] = item.Cells["DiaChi"].Value;
                    dr["NoiDung"] = item.Cells["NoiDung"].Value;
                    dr["DienThoai"] = item.Cells["DienThoai"].Value;
                    dr["NguoiBao"] = item.Cells["NguoiBao"].Value;

                    dsBaoCao.Tables["DSDonDienThoai"].Rows.Add(dr);
                }

            rptDSDonDienThoai rpt = new rptDSDonDienThoai();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnLapDon_Click(object sender, EventArgs e)
        {
            try
            {
                _cDonKH.beginTransaction();
                foreach (DataGridViewRow item in dgvDonDT.Rows)
                    if (bool.Parse(item.Cells["LapDon"].Value.ToString()) && string.IsNullOrEmpty(item.Cells["MaDon"].Value.ToString()))
                    {
                        DonDienThoai dondt = _cDonDT.getDonDienThoaibyID(decimal.Parse(item.Cells["MaDonDT"].Value.ToString()));
                        DonKH donkh = new DonKH();

                        donkh.MaLD = int.Parse(item.Cells["MaLD"].Value.ToString());
                        donkh.NoiDung = dondt.NoiDung;

                        donkh.DanhBo = dondt.DanhBo;
                        donkh.HopDong = dondt.HopDong;
                        donkh.HoTen = dondt.HoTen;
                        donkh.DiaChi = dondt.DiaChi;
                        donkh.DienThoai = dondt.DienThoai;
                        donkh.GiaBieu = dondt.GiaBieu;
                        donkh.DinhMuc = dondt.DinhMuc;
                        donkh.Dot = dondt.Dot;
                        donkh.Ky = dondt.Ky;
                        donkh.Nam = dondt.Nam;

                        if (_cDonKH.Them(donkh))
                        {
                            dondt.MaDon = donkh.MaDon;
                            _cDonDT.Sua(dondt);
                        }
                    }
                _cDonKH.commitTransaction();
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _cDonKH.rollback();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
                for (int i = 0; i < dgvDonDT.Rows.Count; i++)
                {
                    dgvDonDT["In", i].Value = true;
                }
            else
                for (int i = 0; i < dgvDonDT.Rows.Count; i++)
                {
                    dgvDonDT["In", i].Value = false;
                }
        }

        private void dgvDonDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDonDT.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmShowNhanDonDienThoai frm = new frmShowNhanDonDienThoai(decimal.Parse(dgvDonDT["MaDonDT", dgvDonDT.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void dgvDonDT_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDonDT.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Danh Bộ":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        if (chkTheoUser.Checked)
                            dgvDonDT.DataSource = _cDonDT.getDSDonDienThoaiByDanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                        else
                            dgvDonDT.DataSource = _cDonDT.getDSDonDienThoaiByDiaChi(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Địa Chỉ":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        if (chkTheoUser.Checked)
                            dgvDonDT.DataSource = _cDonDT.getDSDonDienThoaiByDanhBo(txtNoiDungTimKiem.Text.Trim());
                        else
                            dgvDonDT.DataSource = _cDonDT.getDSDonDienThoaiByDiaChi(txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Ngày":
                    if (chkTheoUser.Checked)
                        dgvDonDT.DataSource = _cDonDT.getDSDonDienThoaiByDates(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                    else
                        dgvDonDT.DataSource = _cDonDT.getDSDonDienThoaiByDates(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }
    }
}
