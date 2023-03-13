﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.QuanTri;
using System.Transactions;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmCapDinhMucNuocChungCu : Form
    {
        string _mnu = "mnuCapDinhMucNuocChungCuCCCD";
        CChungTu _cChungTu = new CChungTu();
        CThuTien _cThuTien = new CThuTien();
        HOADON _hoadon = null;
        ChungTu_ChiTiet _ctchungtu = null;
        int _TongNK = 0;

        public frmCapDinhMucNuocChungCu()
        {
            InitializeComponent();
        }

        private void frmCapDinhMucNuocChungCu_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDSDanhBo.AutoGenerateColumns = false;
        }

        public void Clear()
        {
            txtHoTen.Text = "";
            txtNgaySinh.Text = "";
            txtCCCD.Text = "";
            txtGhiChu.Text = "";
            chkCat.Checked = false;
            _ctchungtu = null;

            LoadTongNK();
            txtHoTen.Focus();
        }

        /// <summary>
        /// Hiện thị Tổng số NK Đăng Ký của Danh Bộ
        /// </summary>
        private void LoadTongNK()
        {
            dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(txtDanhBo.Text.Trim());
            int TongNK = 0;
            foreach (DataRow itemRow in ((DataTable)dgvDanhSach.DataSource).Rows)
                if (!bool.Parse(itemRow["Cat"].ToString()))
                {
                    TongNK++;
                }
            _TongNK = TongNK;
            lbTongNK.Text = "Tổng NK: " + TongNK;
            lbTongDM.Text = "Tổng ĐM: " + TongNK * 4;

            dgvDanhSach.Focus();
            dgvDanhSach.CurrentCell = dgvDanhSach.Rows[dgvDanhSach.Rows.Count - 1].Cells[3];
        }

        public void FillForm(ChungTu_ChiTiet en)
        {
            txtLo.Text = en.Lo;
            txtPhong.Text = en.Phong;
            txtCCCD.Text = en.MaCT;
            txtHoTen.Text = en.ChungTu.HoTen;
            if (en.ChungTu.NgaySinh != null)
                txtNgaySinh.Text = en.ChungTu.NgaySinh.Value.ToString("dd/MM/yyyy");
            txtDiaChi.Text = en.ChungTu.DiaChi;
            //if (en.NgayHetHan != null)
            //    txtNgayHetHan.Text = en.NgayHetHan.Value.ToString("dd/MM/yyyy");
            txtGhiChu.Text = en.GhiChu;
            chkCat.Checked = en.Cat;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13 && txtDanhBo.Text.Trim() != "")
                {
                    _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                    if (_hoadon != null)
                    {
                        txtDanhBo.Text = _hoadon.DANHBA;
                        txtMLT.Text = _hoadon.MALOTRINH;
                        txtHoTenCC.Text = _hoadon.TENKH;
                        txtDiaChiCC.Text = _hoadon.SO + " " + _hoadon.DUONG;
                        txtGiaBieu.Text = _hoadon.GB.ToString();
                        if (_hoadon.DM != null)
                            txtDinhMuc.Text = _hoadon.DM.Value.ToString();
                        LoadTongNK();
                    }
                    else
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    ChungTu_ChiTiet ctchungtu = _cChungTu.GetCT(txtDanhBo.Text.Trim(), e.Row.Cells["CCCD"].Value.ToString(), 15);
                    if (ctchungtu != null)
                    {
                        if (_cChungTu.XoaCT(ctchungtu))
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (_hoadon != null && txtCCCD.Text.Trim() != "")
                    {
                        if (txtCCCD.Text.Trim().Length != 12)
                        {
                            MessageBox.Show("CCCD gồm 12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ///Kiểm tra Danh Bộ & Số Chứng Từ
                        if (_cChungTu.CheckExist_CT(txtCCCD.Text.Trim(), 15))
                        {
                            MessageBox.Show("Số đăng ký này đã có đăng ký trước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //else
                        //    if (_cChungTu.CheckExist_CT(_hoadon.DANHBA, txtCCCD.Text.Trim(), 15))
                        //    {
                        //        MessageBox.Show("Số đăng ký này đã đăng ký với Danh Bộ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        return;
                        //    }
                        //using (var scope = new TransactionScope())
                        {
                            ChungTu chungtu;
                            ///Kiểm tra Số Chứng Từ
                            if (_cChungTu.CheckExist(txtCCCD.Text.Trim(), 15) == false)
                            {
                                chungtu = new ChungTu();
                                chungtu.MaCT = txtCCCD.Text.Trim();
                                string[] NgaySinhs = null;
                                if (txtNgaySinh.Text.Trim().Contains("/"))
                                    NgaySinhs = txtNgaySinh.Text.Trim().Split('/');
                                else
                                    if (txtNgaySinh.Text.Trim().Contains("-"))
                                        NgaySinhs = txtNgaySinh.Text.Trim().Split('-');
                                if (NgaySinhs != null && NgaySinhs.Count() == 3)
                                {
                                    chungtu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                                }
                                else
                                    chungtu.NgaySinh = new DateTime(int.Parse(txtNgaySinh.Text.Trim()), 1, 1);
                                chungtu.HoTen = txtHoTen.Text.Trim();
                                chungtu.DiaChi = txtDiaChi.Text.Trim();
                                chungtu.SoNKTong = 1;
                                chungtu.MaLCT = 15;
                                _cChungTu.Them(chungtu);
                            }
                            else
                            {
                                chungtu = _cChungTu.Get(txtCCCD.Text.Trim(), 15);
                                chungtu.HoTen = txtHoTen.Text.Trim();
                                chungtu.DiaChi = txtDiaChi.Text.Trim();
                                string[] NgaySinhs = null;
                                if (txtNgaySinh.Text.Trim().Contains("/"))
                                    NgaySinhs = txtNgaySinh.Text.Trim().Split('/');
                                else
                                    if (txtNgaySinh.Text.Trim().Contains("-"))
                                        NgaySinhs = txtNgaySinh.Text.Trim().Split('-');
                                if (NgaySinhs != null && NgaySinhs.Count() == 3)
                                {
                                    chungtu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                                }
                                else
                                    chungtu.NgaySinh = new DateTime(int.Parse(txtNgaySinh.Text.Trim()), 1, 1);
                                _cChungTu.Sua(chungtu);
                            }
                            ChungTu_ChiTiet ctchungtu = new ChungTu_ChiTiet();
                            ctchungtu.DanhBo = _hoadon.DANHBA;
                            ctchungtu.MaLCT = 15;
                            ctchungtu.MaCT = chungtu.MaCT;
                            ctchungtu.SoNKDangKy = 1;
                            //if (txtNgayHetHan.Text.Trim() != "")
                            //{
                            //    string[] NgayHetHans = null;
                            //    if (txtNgayHetHan.Text.Trim().Contains("/"))
                            //        NgayHetHans = txtNgayHetHan.Text.Trim().Split('/');
                            //    else
                            //        if (txtNgayHetHan.Text.Trim().Contains("-"))
                            //            NgayHetHans = txtNgayHetHan.Text.Trim().Split('-');
                            //    if (NgayHetHans.Count() == 3)
                            //    {
                            //        ctchungtu.NgayHetHan = new DateTime(int.Parse(NgayHetHans[2]), int.Parse(NgayHetHans[1]), int.Parse(NgayHetHans[0]));
                            //    }
                            //}
                            ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                            ctchungtu.Lo = txtLo.Text.Trim();
                            ctchungtu.Phong = txtPhong.Text.Trim();
                            if (_hoadon != null)
                            {
                                ctchungtu.Phuong = _hoadon.Phuong;
                                ctchungtu.Quan = _hoadon.Quan;
                            }
                            _cChungTu.ThemCT(ctchungtu);
                            ///Ghi thông tin Lịch Sử chung
                            ChungTu_LichSu lichsuchungtu = new ChungTu_LichSu();
                            lichsuchungtu.Phuong = ctchungtu.Phuong;
                            lichsuchungtu.Quan = ctchungtu.Quan;
                            lichsuchungtu.DanhBo = ctchungtu.DanhBo;
                            lichsuchungtu.MaLCT = ctchungtu.MaLCT;
                            lichsuchungtu.MaCT = ctchungtu.MaCT;
                            lichsuchungtu.SoNKTong = chungtu.SoNKTong;
                            lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
                            lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
                            lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
                            lichsuchungtu.GhiChu = ctchungtu.GhiChu;
                            lichsuchungtu.Lo = ctchungtu.Lo;
                            lichsuchungtu.Phong = ctchungtu.Phong;
                            _cChungTu.ThemLichSuChungTu(lichsuchungtu);
                            //scope.Complete();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctchungtu != null)
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        string[] NgaySinhs = null;
                        if (txtNgaySinh.Text.Trim().Contains("/"))
                            NgaySinhs = txtNgaySinh.Text.Trim().Split('/');
                        else
                            if (txtNgaySinh.Text.Trim().Contains("-"))
                                NgaySinhs = txtNgaySinh.Text.Trim().Split('-');
                        if (NgaySinhs != null && NgaySinhs.Count() == 3)
                        {
                            _ctchungtu.ChungTu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                        }
                        else
                            _ctchungtu.ChungTu.NgaySinh = new DateTime(int.Parse(txtNgaySinh.Text.Trim()), 1, 1);
                        _ctchungtu.ChungTu.HoTen = txtHoTen.Text.Trim();
                        _ctchungtu.ChungTu.DiaChi = txtDiaChi.Text.Trim();
                        //if (txtNgayHetHan.Text.Trim() != "")
                        //{
                        //    string[] NgayHetHans = null;
                        //    if (txtGhiChu.Text.Trim().Contains("/"))
                        //        NgayHetHans = txtGhiChu.Text.Trim().Split('/');
                        //    else
                        //        if (txtGhiChu.Text.Trim().Contains("-"))
                        //            NgayHetHans = txtGhiChu.Text.Trim().Split('-');
                        //    if (NgayHetHans.Count() == 3)
                        //    {
                        //        _ctchungtu.NgayHetHan = new DateTime(int.Parse(NgayHetHans[2]), int.Parse(NgayHetHans[1]), int.Parse(NgayHetHans[0]));
                        //    }
                        //}
                        _ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                        _ctchungtu.Lo = txtLo.Text.Trim();
                        _ctchungtu.Phong = txtPhong.Text.Trim();
                        _ctchungtu.Cat = chkCat.Checked;
                        if (_cChungTu.SuaCT(_ctchungtu))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _ctchungtu = _cChungTu.GetCT(txtDanhBo.Text.Trim(), dgvDanhSach["CCCD", e.RowIndex].Value.ToString(), 15);
                if (_ctchungtu != null)
                    FillForm(_ctchungtu);
            }
            catch
            {

            }
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            
        }

        private void frmCapDinhMucNuocChungCu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.D1://lưu
                        btnThem.PerformClick();
                        break;
                    case Keys.D4:
                        frmTimKiemChungTu frm = new frmTimKiemChungTu();
                        frm.ShowDialog();
                        break;
                    default:
                        break;
                }
        }

        private void dgvDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    sửaToolStripMenuItem.Enabled = true;
                    xóaToolStripMenuItem.Enabled = true;
                }
                else
                {
                    sửaToolStripMenuItem.Enabled = false;
                    xóaToolStripMenuItem.Enabled = false;
                }
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvDanhSach.CurrentCell = dgvDanhSach.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvDanhSach_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvDanhSach, new Point(e.X, e.Y));
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                CDataTransfer dataT = new CDataTransfer();
                dataT.Loai = "ChungCu";
                if (_hoadon != null)
                {
                    dataT.Quan = _hoadon.Quan;
                    dataT.Phuong = _hoadon.Phuong;
                }
                dataT.DanhBo = txtDanhBo.Text.Trim();
                dataT.HoTenDB = txtHoTenCC.Text.Trim();
                dataT.DiaChiDB = txtDiaChiCC.Text.Trim();
                dataT.MaCT = dgvDanhSach.CurrentRow.Cells["CCCD"].Value.ToString();
                dataT.MaLCT = 15;

                frmSoDK frm = new frmSoDK(dataT);
                frm.Show();
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                _ctchungtu = _cChungTu.GetCT(txtDanhBo.Text.Trim(), dgvDanhSach.CurrentRow.Cells["CCCD"].Value.ToString(), int.Parse(dgvDanhSach.CurrentRow.Cells["MaLCT"].Value.ToString()));
                if (_ctchungtu != null && MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_cChungTu.XoaCT(_ctchungtu))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtLo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtPhong.Focus();
        }

        private void txtPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen.Focus();
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNgaySinh.Focus();
        }

        private void txtNgaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChi.Focus();
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtCCCD.Focus();
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 )
            {
                try
                {
                    DataTable dt = new DataTable();
                    if (_cChungTu.CheckExist_CT(txtCCCD.Text.Trim(), 15))
                    {
                        dt = _cChungTu.getDS_ChiTiet(txtCCCD.Text.Trim(), 15);
                        MessageBox.Show("Số đăng ký này đã có đăng ký trước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        foreach (DataGridViewRow item in dgvDanhSach.Rows)
                            if (item.Cells["CCCD"].Value.ToString() == txtCCCD.Text.Trim())
                            {
                                dgvDanhSach.Focus();
                                dgvDanhSach.CurrentCell = dgvDanhSach.Rows[item.Index].Cells[3];
                            }
                    }
                    //else
                    //    if (_cChungTu.CheckExist_CT(txtDanhBo.Text.Trim(), txtCCCD.Text.Trim(), 15))
                    //    {
                    //        dt = _cChungTu.getDS_ChiTiet(txtCCCD.Text.Trim(), 15);
                    //        MessageBox.Show("Số đăng ký này đã đăng ký với Danh Bộ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    dgvDSDanhBo.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtGhiChu.Focus();
            }
        }

        private void txtNgayHetHan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnThem.Focus();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_hoadon != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                for (int i = 0; i < dgvDanhSach.Rows.Count; i++)
                {
                    DataRow dr = dsBaoCao.Tables["DSChungTu"].NewRow();

                    dr["STT"] = i + 1;
                    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = txtHoTenCC.Text.Trim();
                    dr["DiaChi"] = txtDiaChiCC.Text.Trim();
                    dr["HopDong"] = _hoadon.HOPDONG;
                    dr["Dot"] = _hoadon.DOT.ToString();
                    dr["GiaBieu"] = _hoadon.GB;
                    dr["DinhMuc"] = _hoadon.DM;
                    dr["LoTrinh"] = _hoadon.DOT + _hoadon.MAY + _hoadon.STT;
                    //dr["TenLCT"] = dgvKhachHangChungCu["TenLCT", i].Value.ToString();
                    dr["HoTenCT"] = dgvDanhSach["HoTen", i].Value.ToString();
                    dr["MaCT"] = dgvDanhSach["CCCD", i].Value.ToString();
                    dr["SoNKTong"] = _TongNK;
                    dr["SoNKDangKy"] = 1;
                    //if (chkAnGhiChu.Checked == false)
                    dr["GhiChu"] = dgvDanhSach["GhiChu", i].Value.ToString();
                    dr["Lo"] = dgvDanhSach["Lo", i].Value.ToString();
                    dr["Phong"] = dgvDanhSach["Phong", i].Value.ToString();

                    dsBaoCao.Tables["DSChungTu"].Rows.Add(dr);
                }
                rptDSChungTuChungCu rpt = new rptDSChungTuChungCu();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Ngày":
                    panel1.Visible = false;
                    panel2.Visible = true;
                    break;
                default:
                    panel1.Visible = true;
                    panel2.Visible = false;
                    break;
            }
            dgvDanhSach.DataSource = null;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "CCCD":
                    if (string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_CCCD(txtNoiDungTimKiem.Text.Trim());
                    else
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_CCCD(txtDanhBo.Text.Trim(), txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Họ Tên":
                    dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_HoTen(txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Lô":
                    if (string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_Lo(txtNoiDungTimKiem.Text.Trim());
                    else
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_Lo(txtDanhBo.Text.Trim(), txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Phòng":
                    if (string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_Phong(txtNoiDungTimKiem.Text.Trim());
                    else
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_Phong(txtDanhBo.Text.Trim(), txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Ngày":
                    dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_Ngay(txtDanhBo.Text.Trim(), txtLo.Text.Trim(), dateTu_TimKiem.Value, dateDen_TimKiem.Value);
                    break;
                default:

                    break;
            }
        }

        









    }
}
