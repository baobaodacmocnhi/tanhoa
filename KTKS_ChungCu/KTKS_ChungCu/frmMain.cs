﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_ChungCu.LinQ;
using KTKS_ChungCu.DAL;
using KTKS_ChungCu.BaoCao;

namespace KTKS_ChungCu
{
    public partial class frmMain : Form
    {
        CTTKH _cTTKH = new CTTKH();
        TTKhachHang _ttkhachhang = new TTKhachHang();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        int _selectedindex = -1;
        BindingSource DSKHCC_BS = new BindingSource();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvKhachHangChungCu.AutoGenerateColumns = false;
            dgvKhachHangChungCu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvKhachHangChungCu.Font, FontStyle.Bold);
            dgvKhachHangChungCu.DataSource = DSKHCC_BS;

            cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            cmbLoaiCT.DisplayMember = "TenLCT";
            cmbLoaiCT.ValueMember = "MaLCT";

            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvKhachHangChungCu.Columns["MaLCT"];
            cmbColumn.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            cmbColumn.DisplayMember = "TenLCT";
            cmbColumn.ValueMember = "MaLCT";
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            ///
            txtLo.Text = "";
            txtPhong.Text = "";
            cmbLoaiCT.SelectedIndex = 0;
            txtMaCT.Text = "";
            txtDiaChiCT.Text = "";
            txtSoNKTong.Text = "";
            txtSoNKDangKy.Text = "";
            txtThoiHan.Text = "";
            txtGhiChu.Text = "";
            _ttkhachhang = null;
            _selectedindex = -1;
        }

        private void dgvKhachHangChungTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKhachHangChungCu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                    LoadTTKH(_ttkhachhang);
                    DSKHCC_BS.DataSource = _cChungTu.LoadDSChungTu(_ttkhachhang.DanhBo);
                }
                else
                {
                    _ttkhachhang = null;
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaCT.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "0" && txtSoNKDangKy.Text.Trim() != "0")
                    if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKDangKy.Text.Trim()))
                    {
                        ChungTu chungtu = new ChungTu();
                        chungtu.MaCT = txtMaCT.Text.Trim();
                        chungtu.DiaChi = txtDiaChiCT.Text.Trim();
                        chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());
                        chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());

                        CTChungTu ctchungtu = new CTChungTu();
                        ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                        ctchungtu.MaCT = txtMaCT.Text.Trim();
                        ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                        if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                            ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                        else
                            ctchungtu.ThoiHan = null;
                        ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                        ctchungtu.Lo = txtLo.Text.Trim();
                        ctchungtu.Phong = txtPhong.Text.Trim();

                        LichSuChungTu lichsuchungtu = new LichSuChungTu();
                        lichsuchungtu.GhiChu = txtGhiChu.Text.Trim();

                        if (_cChungTu.ThemChungTu(chungtu, ctchungtu, lichsuchungtu))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DSKHCC_BS.DataSource = _cChungTu.LoadDSChungTu(_ttkhachhang.DanhBo);
                        }

                    }
                    else
                        MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
            {
                try
                {
                    if (txtSoNKTong.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "" && txtSoNKTong.Text.Trim() != "0" && txtSoNKDangKy.Text.Trim() != "0")
                        if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKDangKy.Text.Trim()))
                        {
                            ChungTu chungtu = new ChungTu();
                            chungtu.MaCT = txtMaCT.Text.Trim();
                            chungtu.DiaChi = txtDiaChiCT.Text.Trim();
                            chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());

                            CTChungTu ctchungtu = new CTChungTu();
                            ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                            ctchungtu.MaCT = txtMaCT.Text.Trim();
                            ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                            if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                                ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                            else
                                ctchungtu.ThoiHan = null;
                            ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                            ctchungtu.Lo = txtLo.Text.Trim();
                            ctchungtu.Phong = txtPhong.Text.Trim();

                            LichSuChungTu lichsuchungtu = new LichSuChungTu();
                            lichsuchungtu.GhiChu = txtGhiChu.Text.Trim();

                            if (_cChungTu.SuaChungTu(chungtu, ctchungtu, lichsuchungtu))
                            {
                                MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DSKHCC_BS.DataSource = _cChungTu.LoadDSChungTu(_ttkhachhang.DanhBo);
                            }
                        }
                        else
                            MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvKhachHangChungCu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedindex = e.RowIndex;
            txtLo.Text = dgvKhachHangChungCu["Lo", e.RowIndex].Value.ToString();
            txtPhong.Text = dgvKhachHangChungCu["Phong", e.RowIndex].Value.ToString();
            cmbLoaiCT.SelectedValue = int.Parse(dgvKhachHangChungCu["MaLCT", e.RowIndex].Value.ToString());
            txtMaCT.Text = dgvKhachHangChungCu["MaCT", e.RowIndex].Value.ToString();
            txtDiaChiCT.Text = dgvKhachHangChungCu["DiaChi", e.RowIndex].Value.ToString();
            txtSoNKTong.Text = dgvKhachHangChungCu["SoNKTong", e.RowIndex].Value.ToString();
            txtSoNKDangKy.Text = dgvKhachHangChungCu["SoNKDangKy", e.RowIndex].Value.ToString();
            txtThoiHan.Text = dgvKhachHangChungCu["ThoiHan", e.RowIndex].Value.ToString();
            txtGhiChu.Text = dgvKhachHangChungCu["GhiChu", e.RowIndex].Value.ToString();
        }

        private void txtMaCT_TimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaCT_TimKiem.Text.Trim() != "")
            {
                string expression = String.Format("MaCT = {0}", txtMaCT_TimKiem.Text.Trim());
                DSKHCC_BS.Filter = expression;
            }
            else
                DSKHCC_BS.RemoveFilter();
        }

        private void txtSoNKTong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoNKDangKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtThoiHan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_ttkhachhang != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                for (int i = 0; i < dgvKhachHangChungCu.Rows.Count; i++)
                {
                    DataRow dr = dsBaoCao.Tables["DSChungTu"].NewRow();

                    dr["DanhBo"] = txtDanhBo.Text.Trim();
                    dr["HoTen"] = txtHoTen.Text.Trim();
                    dr["DiaChi"] = txtDiaChi.Text.Trim();
                    dr["TenLCT"] = dgvKhachHangChungCu["TenLCT", i].Value.ToString();
                    dr["MaCT"] = dgvKhachHangChungCu["MaCT", i].Value.ToString();
                    dr["SoNKTong"] = dgvKhachHangChungCu["SoNKTong", i].Value.ToString();
                    dr["SoNKDangKy"] = dgvKhachHangChungCu["SoNKDangKy", i].Value.ToString();
                    dr["GhiChu"] = dgvKhachHangChungCu["GhiChu", i].Value.ToString();
                    dr["Lo"] = dgvKhachHangChungCu["Lo", i].Value.ToString();
                    dr["Phong"] = dgvKhachHangChungCu["Phong", i].Value.ToString();

                    dsBaoCao.Tables["DSChungTu"].Rows.Add(dr);
                }
                rptDSChungTu rpt = new rptDSChungTu();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();

            }
        }
        
    }
}
