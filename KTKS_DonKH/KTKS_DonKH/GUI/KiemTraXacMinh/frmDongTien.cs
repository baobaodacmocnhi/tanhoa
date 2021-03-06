﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmDongTien : Form
    {
        string _mnu = "mnuDongTien";
        int _selectedindex = -1;
        CHienTrangKiemTra _cHienTrangKiemTra = new CHienTrangKiemTra();
        CKTXM _cKTXM = new CKTXM();
        CDongTienNoiDung _cDongTienNoiDung = new CDongTienNoiDung();

        public frmDongTien()
        {
            InitializeComponent();
        }

        private void frmDongTien_Load(object sender, EventArgs e)
        {
            dgvDSKetQuaKiemTra.AutoGenerateColumns = false;

            cmbHienTrangKiemTra.DataSource = _cHienTrangKiemTra.getDS();
            cmbHienTrangKiemTra.DisplayMember = "TenHTKT";
            cmbHienTrangKiemTra.ValueMember = "TenHTKT";
            cmbHienTrangKiemTra.SelectedIndex = -1;

            string TenTo = "";
            //if (CTaiKhoan.ToKH == true)
            //    TenTo = "TKH";
            //else
            //    if (CTaiKhoan.ToXL == true)
            //        TenTo = "TXL";
            //    else
            //        if (CTaiKhoan.ToBC == true)
            //            TenTo = "TBC";
            cmbNoiDungXuLy.DataSource = _cDongTienNoiDung.getDS(TenTo);
            cmbNoiDungXuLy.DisplayMember = "Name";
            cmbNoiDungXuLy.ValueMember = "Name";
            cmbNoiDungXuLy.SelectedIndex = -1;

            DataTable dtGhiChuNoiDungXyLy = _cKTXM.GetGhiChuNoiDungXuLy();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (DataRow item in dtGhiChuNoiDungXyLy.Rows)
            {
                auto.Add(item["GhiChuNoiDungXuLy"].ToString());
            }
            txtGhiChuNoiDungXuLy.AutoCompleteCustomSource = auto;
        }

        public void LoadCTKTXM(KTXM_ChiTiet ctktxm)
        {
            dateKTXM.Value = ctktxm.NgayKTXM.Value;

            txtHieu.Text = ctktxm.Hieu;
            txtCo.Text = ctktxm.Co;
            txtSoThan.Text = ctktxm.SoThan;
            txtChiSo.Text = ctktxm.ChiSo;
            cmbTinhTrangChiSo.SelectedItem = ctktxm.TinhTrangChiSo;
            cmbChiMatSo.SelectedItem = ctktxm.ChiMatSo;
            cmbChiKhoaGoc.SelectedItem = ctktxm.ChiKhoaGoc;
            txtMucDichSuDung.Text = ctktxm.MucDichSuDung;
            txtDienThoai.Text = ctktxm.DienThoai;
            txtHoTenKHKy.Text = ctktxm.HoTenKHKy;
            cmbTinhTrangDHN.SelectedItem = ctktxm.TinhTrangDHN;
            txtNoiDungKiemTra.Text = ctktxm.NoiDungKiemTra;
            if (ctktxm.DinhMucMoi != null)
                txtDinhMucMoi.Text = ctktxm.DinhMucMoi.Value.ToString();
            if (ctktxm.DinhMuc_KhongDangKy != null)
                txtDinhMuc_KhongDangKy.Text = ctktxm.DinhMuc_KhongDangKy.Value.ToString();
            chkDutChiGoc.Checked = ctktxm.DutChiGoc;
            chkMoNuoc.Checked = ctktxm.MoNuoc;
            chkCanKhachHangLienHe.Checked = ctktxm.CanKhachHangLienHe;
            if (ctktxm.NoiDungXuLy != null)
            {
                cmbNoiDungXuLy.SelectedValue = ctktxm.NoiDungXuLy;
                txtGhiChuNoiDungXuLy.Text = ctktxm.GhiChuNoiDungXuLy;
            }
            else
            {
                cmbNoiDungXuLy.SelectedIndex = -1;
                txtGhiChuNoiDungXuLy.Text = "";
            }

            if (ctktxm.LapBangGia)
            {
                chkLapBangGia.Checked = true;
                dateLapBangGia.Value = ctktxm.NgayLapBangGia.Value;
                
            }
            else
            {
                chkLapBangGia.Checked = false;
                dateLapBangGia.Value = DateTime.Now;
            }

            if (ctktxm.DongTien)
            {
                chkDongTien.Checked = true;
                //cmbNoiDungDongTien.SelectedValue = ctktxm.NoiDungDongTien;
                dateDongTien.Value = ctktxm.NgayDongTien.Value;
                
            }
            else
            {
                chkDongTien.Checked = false;
                //cmbNoiDungXuLy.SelectedIndex = -1;
                dateDongTien.Value = DateTime.Now;
                
            }

            if (ctktxm.ChuyenLapTBCat)
            {
                chkChuyenLapTBCat.Checked = true;
                dateChuyenCatHuy.Value = ctktxm.NgayChuyenLapTBCat.Value;
            }
            else
            {
                chkChuyenLapTBCat.Checked = false;
                dateChuyenCatHuy.Value = DateTime.Now;
            }
            cmbHienTrangKiemTra.SelectedValue = ctktxm.HienTrangKiemTra;
            dgvBangGia.Rows.Clear();
            foreach (KTXM_BangGia item in ctktxm.KTXM_BangGias.ToList())
            {
                var index = dgvBangGia.Rows.Add();
                dgvBangGia.Rows[index].Cells["IDCTKTXM"].Value = item.IDCTKTXM;
                dgvBangGia.Rows[index].Cells["IDDonGia"].Value = item.IDDonGia;
                dgvBangGia.Rows[index].Cells["Namee"].Value = item.KTXM_DonGia.Name;
                dgvBangGia.Rows[index].Cells["SoTien"].Value = item.KTXM_DonGia.SoTien;
            }
            txtSoTienDongTien.Text = ctktxm.SoTienDongTien;
        }

        public void Clear()
        {
            try
            {
                txtDanhBo.Text = "";
                dateKTXM.Value = DateTime.Now;
                cmbHienTrangKiemTra.SelectedIndex = -1;
                txtChiSo.Text = "";
                cmbTinhTrangChiSo.SelectedIndex = -1;
                txtHieu.Text = "";
                txtCo.Text = "";
                txtSoThan.Text = "";
                cmbChiMatSo.SelectedIndex = -1;
                cmbChiKhoaGoc.SelectedIndex = -1;
                txtMucDichSuDung.Text = "";
                txtDienThoai.Text = "";
                txtHoTenKHKy.Text = "";
                txtNoiDungKiemTra.Text = "";
                txtTheoYeuCau.Text = "";
                txtDinhMucMoi.Text = "";
                txtDinhMuc_KhongDangKy.Text = "";
                chkDutChiGoc.Checked = false;
                chkMoNuoc.Checked = false; 
                cmbNoiDungXuLy.SelectedIndex = -1;
                txtGhiChuNoiDungXuLy.Text = "";
                chkCanKhachHangLienHe.Checked = false;
                ///
                chkLapBangGia.Checked = false;
                dateLapBangGia.Value = DateTime.Now;
                txtSoTienDongTien.Text = "";
                ///
                chkDongTien.Checked = false;
                dateDongTien.Value = DateTime.Now;
                ///
                chkChuyenLapTBCat.Checked = false;
                dateChuyenCatHuy.Value = DateTime.Now;
                _selectedindex = -1;
                ///
                dgvDSKetQuaKiemTra.DataSource = null;
                dgvBangGia.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim() != "")
            {
                string DanhBo = txtDanhBo.Text.Trim();
                Clear();
                txtDanhBo.Text = DanhBo;
                dgvDSKetQuaKiemTra.DataSource = _cKTXM.getDS_ByDanhBo(txtDanhBo.Text.Trim());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua") == true)
            {
                if (_selectedindex != -1)
                {
                    if (_cKTXM.CheckExist_CT(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", _selectedindex].Value.ToString())) == true)
                    {
                        KTXM_ChiTiet ctktxm = _cKTXM.GetCT(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", _selectedindex].Value.ToString()));

                        if (txtDinhMucMoi.Text.Trim() != "")
                            ctktxm.DinhMucMoi = int.Parse(txtDinhMucMoi.Text.Trim());
                        if (txtDinhMuc_KhongDangKy.Text.Trim() != "")
                            ctktxm.DinhMuc_KhongDangKy = int.Parse(txtDinhMuc_KhongDangKy.Text.Trim());

                        ctktxm.DutChiGoc = chkDutChiGoc.Checked;
                        ctktxm.MoNuoc = chkMoNuoc.Checked;
                        ctktxm.CanKhachHangLienHe = chkCanKhachHangLienHe.Checked;
                        ctktxm.LapTruyThu = chkLapTruyThu.Checked;
                        if (cmbNoiDungXuLy.SelectedIndex >-1)
                        {
                            ctktxm.NoiDungXuLy = cmbNoiDungXuLy.SelectedValue.ToString();
                            ctktxm.GhiChuNoiDungXuLy = txtGhiChuNoiDungXuLy.Text.Trim();
                        }

                        if (chkLapBangGia.Checked)
                        {
                            ctktxm.LapBangGia = true;
                            ctktxm.NgayLapBangGia = dateLapBangGia.Value;
                            ctktxm.SoTienDongTien = txtSoTienDongTien.Text.Trim();
                        }
                        else
                        {
                            ctktxm.LapBangGia = false;
                            ctktxm.NgayLapBangGia = null;
                            ctktxm.SoTienDongTien = null;
                        }

                        if (chkDongTien.Checked)
                        {
                            ctktxm.DongTien = true;
                            //ctktxm.NoiDungDongTien = cmbNoiDungDongTien.SelectedValue.ToString();
                            ctktxm.NgayDongTien = dateDongTien.Value;
                            
                        }
                        else
                        {
                            ctktxm.DongTien = false;
                            ctktxm.NoiDungDongTien = null;
                            ctktxm.NgayDongTien = null;
                            
                        }

                        if (chkChuyenLapTBCat.Checked)
                        {
                            ctktxm.ChuyenLapTBCat = true;
                            ctktxm.NgayChuyenLapTBCat = dateChuyenCatHuy.Value;
                        }
                        else
                        {
                            ctktxm.ChuyenLapTBCat = false;
                            ctktxm.NgayChuyenLapTBCat = null;
                        }

                        if (_cKTXM.SuaCT(ctktxm))
                        {
                            Clear();
                            MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM(txtDanhBo.Text.Trim(), CTaiKhoan.MaUser);
                            txtDanhBo.Focus();
                        }
                    }
                }
                else
                    MessageBox.Show("Chưa chọn Biên Bản Kiểm Tra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkLapBangGia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLapBangGia.Checked)
                groupBoxLapBangGia.Enabled = true;
            else
                groupBoxLapBangGia.Enabled = false;
        }

        private void chkDongTienBoiThuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDongTien.Checked)
                groupBoxDongTien.Enabled = true;
            else
                groupBoxDongTien.Enabled = false;
        }

        private void chkChuyenCatHuy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenLapTBCat.Checked)
                groupBoxChuyenCatHuy.Enabled = true;
            else
                groupBoxChuyenCatHuy.Enabled = false;
        }

        private void dgvDSKetQuaKiemTra_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSKetQuaKiemTra.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSKetQuaKiemTra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvDSKetQuaKiemTra.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null&&e.Value.ToString()!="")
            //{
            //    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
        }

        private void dgvDSKetQuaKiemTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                LoadCTKTXM(_cKTXM.GetCT(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", e.RowIndex].Value.ToString())));
            }
            catch (Exception)
            {
            }
        }

        private void cmbNoiDungDongTien_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbNoiDungDongTien.Items.Count>0&&cmbNoiDungDongTien.SelectedIndex >= 0)
            //{
            //    txtGhiChuDongTien.Text = ((DongTienNoiDung)cmbNoiDungDongTien.SelectedItem).GhiChu;
            //}
        }

        private void dgvBangGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangGia.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(e.Value.ToString()));
            }
        }

        private void dgvBangGia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBangGia.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHinh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _cKTXM.LoadImageView(Convert.FromBase64String(dgvHinh.CurrentRow.Cells["Bytes_Hinh"].Value.ToString()));
        }
    }
}
