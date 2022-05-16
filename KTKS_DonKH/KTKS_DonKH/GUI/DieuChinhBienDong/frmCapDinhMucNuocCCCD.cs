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
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using System.Globalization;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;
using System.Transactions;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmCapDinhMucNuocCCCD : Form
    {
        string _mnu = "mnuCapDinhMucNuocCCCD";
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        CDangKyDinhMucCCCD _cDKDM = new CDangKyDinhMucCCCD();
        CDCBD _cDCBD = new CDCBD();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CChungTu _cChungTu = new CChungTu();
        CDHN _cDHN = new CDHN();
        CTTKH _cTTKH = new CTTKH();
        HOADON _hoadon = null;
        DCBD_DKDM_DanhBo _danhbo = null;
        bool _flag = false;

        public frmCapDinhMucNuocCCCD()
        {
            InitializeComponent();
        }

        private void frmCapDinhMucNuocCCCD_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach2.AutoGenerateColumns = false;
            dgvDanhSach_Online.AutoGenerateColumns = false;
            dgvDanhSachCT_Online.AutoGenerateColumns = false;
            DataTable dt = _cDKDM.getDS_NguoiLap();
            DataRow dr = dt.NewRow();
            dr["ID"] = 0;
            dr["Name"] = "Tất Cả";
            dt.Rows.InsertAt(dr, 0);
            cmbNguoiLap.DataSource = dt;
            cmbNguoiLap.DisplayMember = "Name";
            cmbNguoiLap.ValueMember = "ID";
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtSoNK.Text = "";
            chkChungTu.Checked = false;
            chkNhaTro.Checked = false;
            chkDangXuLy.Checked = false;
            txtMaDon.Text = "";
            dgvDanhSach.Rows.Clear();
            _hoadon = null;
            _danhbo = null;
            txtDanhBo.Focus();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim() != "")
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                if (_hoadon != null)
                {
                    txtDanhBo.Text = _hoadon.DANHBA;
                    txtHoTen.Text = _hoadon.TENKH;
                    txtDiaChi.Text = _hoadon.SO + " " + _hoadon.DUONG;
                    txtDienThoai.Focus();
                    if (_cDKDM.checkExists(_hoadon.DANHBA))
                        MessageBox.Show("Danh Bộ này đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (_cDKDM.checkExists(_hoadon.DANHBA) == true)
                    {
                        MessageBox.Show("Danh Bộ này đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (_hoadon != null)
                    {
                        DCBD_DKDM_DanhBo en = new DCBD_DKDM_DanhBo();
                        en.DanhBo = txtDanhBo.Text.Trim();
                        en.SDT = txtDienThoai.Text.Trim();
                        en.Quan = _hoadon.Quan;
                        en.ChungTu = chkChungTu.Checked;
                        en.NhaTro = chkNhaTro.Checked;
                        en.DangXuLy = chkDangXuLy.Checked;
                        en.MaDon = txtMaDon.Text.Trim();
                        foreach (DataGridViewRow item in dgvDanhSach.Rows)
                            if (item.Cells["CCCD"].Value != null && item.Cells["CCCD"].Value.ToString() != "")
                            {
                                DCBD_DKDM_CCCD enCT = new DCBD_DKDM_CCCD();
                                enCT.CCCD = item.Cells["CCCD"].Value.ToString();
                                enCT.HoTen = item.Cells["HoTen"].Value.ToString();
                                string[] NgaySinhs = item.Cells["NgaySinh"].Value.ToString().Split('/');
                                if (NgaySinhs.Count() == 3)
                                {
                                    enCT.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                                }
                                else
                                    enCT.NgaySinh = new DateTime(int.Parse(item.Cells["NgaySinh"].Value.ToString()), 1, 1);
                                if (item.Cells["DCThuongTru"].Value != null && item.Cells["DCThuongTru"].Value.ToString() != "")
                                    enCT.DCThuongTru = item.Cells["DCThuongTru"].Value.ToString();
                                if (item.Cells["DCTamTru"].Value != null && item.Cells["DCTamTru"].Value.ToString() != "")
                                    enCT.DCTamTru = item.Cells["DCTamTru"].Value.ToString();
                                enCT.CreateBy = CTaiKhoan.MaUser;
                                enCT.CreateDate = DateTime.Now;
                                en.DCBD_DKDM_CCCDs.Add(enCT);
                            }
                        string Thung = "";
                        if (_cDKDM.Them(en, out Thung))
                        {
                            MessageBox.Show("Thành công\n" + Thung, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_danhbo != null)
                    {
                        if (_danhbo.DCBD)
                        {
                            MessageBox.Show("Đã lập ĐCBĐ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _danhbo.DanhBo = txtDanhBo.Text.Trim();
                        _danhbo.SDT = txtDienThoai.Text.Trim();
                        _danhbo.Quan = _hoadon.Quan;
                        _danhbo.ChungTu = chkChungTu.Checked;
                        _danhbo.NhaTro = chkNhaTro.Checked;
                        _danhbo.DangXuLy = chkDangXuLy.Checked;
                        _danhbo.MaDon = txtMaDon.Text.Trim();
                        foreach (DataGridViewRow item in dgvDanhSach.Rows)
                            if (item.Cells["ID"].Value != null && item.Cells["ID"].Value.ToString() != "")
                            {
                                _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).CCCD = item.Cells["CCCD"].Value.ToString();
                                _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).HoTen = item.Cells["HoTen"].Value.ToString();
                                string[] NgaySinhs = item.Cells["NgaySinh"].Value.ToString().Split('/');
                                if (NgaySinhs.Count() == 3)
                                {
                                    _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                                }
                                else
                                    _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).NgaySinh = new DateTime(int.Parse(item.Cells["NgaySinh"].Value.ToString()), 1, 1);
                                if (item.Cells["DCThuongTru"].Value != null && item.Cells["DCThuongTru"].Value.ToString() != "")
                                    _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).DCThuongTru = item.Cells["DCThuongTru"].Value.ToString();
                                if (item.Cells["DCTamTru"].Value != null && item.Cells["DCTamTru"].Value.ToString() != "")
                                    _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).DCTamTru = item.Cells["DCTamTru"].Value.ToString();
                                _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).ModifyBy = CTaiKhoan.MaUser;
                                _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).ModifyDate = DateTime.Now;
                            }
                            else
                                if (item.Cells["CCCD"].Value != null && item.Cells["CCCD"].Value.ToString() != "")
                                {
                                    DCBD_DKDM_CCCD enCT = new DCBD_DKDM_CCCD();
                                    enCT.CCCD = item.Cells["CCCD"].Value.ToString();
                                    enCT.HoTen = item.Cells["HoTen"].Value.ToString();
                                    string[] NgaySinhs = item.Cells["NgaySinh"].Value.ToString().Split('/');
                                    if (NgaySinhs.Count() == 3)
                                    {
                                        enCT.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                                    }
                                    else
                                        enCT.NgaySinh = new DateTime(int.Parse(item.Cells["NgaySinh"].Value.ToString()), 1, 1);
                                    if (item.Cells["DCThuongTru"].Value != null && item.Cells["DCThuongTru"].Value.ToString() != "")
                                        enCT.DCThuongTru = item.Cells["DCThuongTru"].Value.ToString();
                                    if (item.Cells["DCTamTru"].Value != null && item.Cells["DCTamTru"].Value.ToString() != "")
                                        enCT.DCTamTru = item.Cells["DCTamTru"].Value.ToString();
                                    enCT.CreateBy = CTaiKhoan.MaUser;
                                    enCT.CreateDate = DateTime.Now;
                                    _danhbo.DCBD_DKDM_CCCDs.Add(enCT);
                                }
                        if (_cDKDM.Sua(_danhbo))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
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

        private void txtSoNK_TextChanged(object sender, EventArgs e)
        {
            //if (txtSoNK.Text.Trim() != "" && txtSoNK.Text.Trim().All(char.IsDigit))
            //{
            //    int count = int.Parse(txtSoNK.Text.Trim());
            //    dgvDanhSach.Rows.Clear();
            //    dgvDanhSach.Rows.Add(count);
            //    for (int i = 0; i < count; i++)
            //    {
            //        dgvDanhSach["STT", i].Value = i + 1;
            //    }
            //}
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                LinQ.DonTu dontu = _cDonTu.get(int.Parse(txtMaDon.Text.Trim()));
                if (dontu != null)
                {
                    _hoadon = _cThuTien.GetMoiNhat(dontu.DonTu_ChiTiets.SingleOrDefault().DanhBo);
                    if (_hoadon != null)
                    {
                        txtDanhBo.Text = _hoadon.DANHBA;
                        txtHoTen.Text = _hoadon.TENKH;
                        txtDiaChi.Text = _hoadon.SO + " " + _hoadon.DUONG;
                        txtDienThoai.Text = dontu.DienThoai;
                        txtDienThoai.Focus();
                    }
                    else
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtDienThoai.Text.Trim() != "" && txtDienThoai.Text.Trim().Length != 10 && txtDienThoai.Text.Trim().Length != 11)
                {
                    MessageBox.Show("Điện thoại phải 10 hoặc 11 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtSoNK.Focus();
            }
        }

        private void txtSoNK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                dgvDanhSach.Focus();
        }

        private void dgvDanhSach_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (_danhbo != null && e.Row.Cells["ID"].Value != null && e.Row.Cells["ID"].Value.ToString() != "")
                {
                    if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                    {
                        if (_danhbo.DCBD)
                        {
                            MessageBox.Show("Đã lập ĐCBĐ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        DCBD_DKDM_CCCD en = _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(item => item.ID == int.Parse(e.Row.Cells["ID"].Value.ToString()));
                        _cDKDM.XoaCT(en);
                        //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_flag == false && dgvDanhSach.Columns[e.ColumnIndex].Name == "CCCD" && dgvDanhSach["CCCD", e.RowIndex].Value.ToString() != "")
            {
                if (dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Trim().Length != 9 && dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Trim().Length != 12)
                {
                    MessageBox.Show("CMND=9 số hoặc CCCD=12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string Thung = "";
                if (_cDKDM.checkExists(dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Trim(), out Thung) == true)
                {
                    MessageBox.Show("CCCD đã tồn tại\n" + Thung, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSach["HoTen", e.RowIndex].Value != null && dgvDanhSach["HoTen", e.RowIndex].Value.ToString() != "")
                {
                    if (e.RowIndex < dgvDanhSach.RowCount - 1)
                    {
                        if ((dgvDanhSach["DCThuongTru", e.RowIndex].Value != null && dgvDanhSach["DCThuongTru", e.RowIndex].Value.ToString() != "")
                            && (dgvDanhSach["DCThuongTru", e.RowIndex + 1].Value == null || dgvDanhSach["DCThuongTru", e.RowIndex + 1].Value.ToString() == ""))
                            dgvDanhSach["DCThuongTru", e.RowIndex + 1].Value = dgvDanhSach["DCThuongTru", e.RowIndex].Value;
                        if ((dgvDanhSach["DCTamTru", e.RowIndex].Value != null && dgvDanhSach["DCTamTru", e.RowIndex].Value.ToString() != "")
                            && (dgvDanhSach["DCTamTru", e.RowIndex + 1].Value == null || dgvDanhSach["DCTamTru", e.RowIndex + 1].Value.ToString() == ""))
                            dgvDanhSach["DCTamTru", e.RowIndex + 1].Value = dgvDanhSach["DCTamTru", e.RowIndex].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //

        private void txtDanhBo_DS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo_DS.Text.Trim() != "")
                btnXem.PerformClick();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (txtDanhBo_DS.Text.Trim() != "")
                dgvDanhSach2.DataSource = _cDKDM.getDS(txtDanhBo_DS.Text.Trim());
            else
                if (txtQuan.Text.Trim() != "")
                {
                    if (txtThung.Text.Trim() != "")
                        if (cmbNguoiLap.SelectedIndex == 0)
                            dgvDanhSach2.DataSource = _cDKDM.getDS_Quan_Thung(txtQuan.Text.Trim(), int.Parse(txtThung.Text.Trim()));
                        else
                            dgvDanhSach2.DataSource = _cDKDM.getDS_Quan_Thung(int.Parse(cmbNguoiLap.SelectedValue.ToString()), txtQuan.Text.Trim(), int.Parse(txtThung.Text.Trim()));
                    else
                        if (cmbNguoiLap.SelectedIndex == 0)
                            dgvDanhSach2.DataSource = _cDKDM.getDS_Quan(txtQuan.Text.Trim());
                        else
                            dgvDanhSach2.DataSource = _cDKDM.getDS_Quan(int.Parse(cmbNguoiLap.SelectedValue.ToString()), txtQuan.Text.Trim());
                }
                else
                    if (CTaiKhoan.TruongPhong || CTaiKhoan.Admin || CTaiKhoan.ThuKy)
                        if (cmbNguoiLap.SelectedIndex == 0)
                            dgvDanhSach2.DataSource = _cDKDM.getDS(dateTu.Value, dateDen.Value);
                        else
                            dgvDanhSach2.DataSource = _cDKDM.getDS(int.Parse(cmbNguoiLap.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
                    else
                        dgvDanhSach2.DataSource = _cDKDM.getDS(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
        }

        private void dgvDanhSach2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                _flag = true;
                Clear();
                _danhbo = _cDKDM.get(int.Parse(dgvDanhSach2["ID_DS", e.RowIndex].Value.ToString()));
                if (_danhbo != null)
                {
                    txtDanhBo.Text = _danhbo.DanhBo;
                    txtDienThoai.Text = _danhbo.SDT;
                    txtSoNK.Text = _danhbo.DCBD_DKDM_CCCDs.Count.ToString();
                    txtMaDon.Text = _danhbo.MaDon;
                    chkChungTu.Checked = _danhbo.ChungTu;
                    chkNhaTro.Checked = _danhbo.NhaTro;
                    chkDangXuLy.Checked = _danhbo.DangXuLy;
                    dgvDanhSach.Rows.Clear();
                    foreach (DCBD_DKDM_CCCD item in _danhbo.DCBD_DKDM_CCCDs.ToList())
                    {
                        var index = dgvDanhSach.Rows.Add();
                        dgvDanhSach.Rows[index].Cells["ID"].Value = item.ID;
                        dgvDanhSach.Rows[index].Cells["HoTen"].Value = item.HoTen;
                        dgvDanhSach.Rows[index].Cells["NgaySinh"].Value = item.NgaySinh.Value.ToString("dd/MM/yyyy");
                        dgvDanhSach.Rows[index].Cells["DCThuongTru"].Value = item.DCThuongTru;
                        dgvDanhSach.Rows[index].Cells["DCTamTru"].Value = item.DCTamTru;
                        dgvDanhSach.Rows[index].Cells["CCCD"].Value = item.CCCD;
                    }
                    _hoadon = _cThuTien.GetMoiNhat(_danhbo.DanhBo);
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
                    _flag = false;
                }
            }
            catch
            {
            }
        }

        private void dgvDanhSach2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach2.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void frmCapDinhMucNuocCCCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")
                if (e.Control && e.KeyCode == Keys.T)
                {
                    btnThem.PerformClick();
                }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen("mnuDCBD", "Them"))
                {
                    switch (cmbKiemTra.SelectedItem.ToString())
                    {
                        case "Tăng":
                            dgvDanhSach2.DataSource = _cDKDM.getDS_KiemTra_Tang(dateTu.Value, dateDen.Value);
                            break;
                        case "Giảm":
                            dgvDanhSach2.DataSource = _cDKDM.getDS_KiemTra_Giam(dateTu.Value, dateDen.Value);
                            break;
                        case "Giữ Nguyên":
                             dgvDanhSach2.DataSource = _cDKDM.getDS_KiemTra_GiuNguyen(dateTu.Value, dateDen.Value);
                            break;
                        default:
                            dgvDanhSach2.DataSource = _cDKDM.getDS_KiemTra_All(dateTu.Value, dateDen.Value);
                            break;
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

        private void btnDCBD_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen("mnuDCBD", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //tạo đơn
                        LinQ.DonTu entity = new LinQ.DonTu();

                        int ID = _cDonTu.getMaxID_ChiTiet();
                        int STT = 0;
                        foreach (DataGridViewRow item in dgvDanhSach2.Rows)
                            if (item.Cells["MaDon"].Value.ToString() == "")
                            {
                                HOADON hd = _cThuTien.GetMoiNhat(item.Cells["DanhBo"].Value.ToString());
                                if (hd != null)
                                {
                                    DonTu_ChiTiet entityCT = new DonTu_ChiTiet();
                                    entityCT.ID = ++ID;
                                    item.Cells["DCBD_STT"].Value = entityCT.STT = ++STT;

                                    entityCT.DanhBo = hd.DANHBA;
                                    entityCT.MLT = hd.MALOTRINH;
                                    entityCT.HopDong = hd.HOPDONG;
                                    entityCT.HoTen = hd.TENKH;
                                    entityCT.DiaChi = hd.SO + " " + hd.DUONG;
                                    entityCT.GiaBieu = hd.GB;
                                    entityCT.DinhMuc = hd.DM;
                                    entityCT.DinhMucHN = hd.DinhMucHN;
                                    entityCT.Dot = hd.DOT;
                                    entityCT.Ky = hd.KY;
                                    entityCT.Nam = hd.NAM;
                                    entityCT.Quan = hd.Quan;
                                    entityCT.Phuong = hd.Phuong;

                                    entityCT.CreateBy = CTaiKhoan.MaUser;
                                    entityCT.CreateDate = DateTime.Now;
                                    //entityCT.TinhTrang = "Tồn";

                                    entity.DonTu_ChiTiets.Add(entityCT);
                                }
                            }
                        entity.SoCongVan_PhongBanDoi = "P. TV";
                        entity.TongDB = entity.DonTu_ChiTiets.Count;
                        entity.ID_NhomDon_PKH = "7";
                        entity.Name_NhomDon_PKH = "Định mức";
                        entity.VanPhong = true;
                        entity.MaPhong = 1;
                        using (var scope = new TransactionScope())
                            if (_cDonTu.Them(entity))
                            {
                                foreach (DataGridViewRow item in dgvDanhSach2.Rows)
                                    if (item.Cells["MaDon"].Value.ToString() == "")
                                    {
                                        item.Cells["DCBD_MaDon"].Value = entity.MaDon;
                                        DCBD_DKDM_DanhBo danhbo = _cDKDM.get(int.Parse(item.Cells["ID_DS"].Value.ToString()));
                                        danhbo.DCBD_MaDon = int.Parse(item.Cells["DCBD_MaDon"].Value.ToString());
                                        danhbo.DCBD_STT = int.Parse(item.Cells["DCBD_STT"].Value.ToString());
                                        _cDKDM.Sua(danhbo);
                                    }
                                scope.Complete();
                            }

                        foreach (DataGridViewRow item in dgvDanhSach2.Rows)
                            if ((item.Cells["MaDon"].Value.ToString() != "" || item.Cells["DCBD_MaDon"].Value.ToString() != "") && bool.Parse(item.Cells["DCBD"].Value.ToString()) == false)
                            {
                                DCBD_DKDM_DanhBo danhbo = _cDKDM.get(int.Parse(item.Cells["ID_DS"].Value.ToString()));
                                DonTu_ChiTiet dontu_ChiTiet = new DonTu_ChiTiet();
                                if (item.Cells["MaDon"].Value.ToString() != "")
                                    dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(item.Cells["MaDon"].Value.ToString()), 1);
                                else
                                    if (item.Cells["DCBD_MaDon"].Value.ToString() != "")
                                        dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(item.Cells["DCBD_MaDon"].Value.ToString()), int.Parse(item.Cells["DCBD_STT"].Value.ToString()));
                                HOADON hoadon = _cThuTien.GetMoiNhat(dontu_ChiTiet.DanhBo);
                                bool flagCCCD = false;
                                foreach (DCBD_DKDM_CCCD itemCC in danhbo.DCBD_DKDM_CCCDs)
                                {
                                    int MaLCT = 0;
                                    if (itemCC.CCCD.Length == 9)
                                        MaLCT = 16;
                                    else
                                        if (itemCC.CCCD.Length == 12)
                                            MaLCT = 15;
                                    if (_cChungTu.checkExist_KhacDanhBo_Active(dontu_ChiTiet.DanhBo, itemCC.CCCD, MaLCT) == true)
                                    {
                                        flagCCCD = true;
                                    }
                                }
                                if (flagCCCD == true)
                                {
                                    danhbo.GhiChu = "CCCD đã đăng ký danh bộ khác";
                                    _cDKDM.Sua(danhbo);
                                }
                                if (flagCCCD == false && danhbo.DangXuLy == false)
                                {
                                    DCBD_ChiTietBienDong ctdcbd = new DCBD_ChiTietBienDong();
                                    if (dontu_ChiTiet != null)
                                    {
                                        if (_cDCBD.checkExist(dontu_ChiTiet.MaDon.Value) == false)
                                        {
                                            DCBD dcbd = new DCBD();
                                            dcbd.MaDonMoi = dontu_ChiTiet.MaDon.Value;
                                            _cDCBD.Them(dcbd);
                                        }
                                        ctdcbd.MaDCBD = _cDCBD.get(dontu_ChiTiet.MaDon.Value).MaDCBD;
                                        ctdcbd.STT = dontu_ChiTiet.STT.Value;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    ctdcbd.DanhBo = hoadon.DANHBA;
                                    ctdcbd.HopDong = hoadon.HOPDONG;
                                    ctdcbd.HoTen = hoadon.TENKH;
                                    ctdcbd.DiaChi = hoadon.SO + " " + hoadon.DUONG + _cDHN.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                                    ctdcbd.MaQuanPhuong = hoadon.Quan + " " + hoadon.Phuong;
                                    ctdcbd.Ky = hoadon.KY.ToString();
                                    ctdcbd.Nam = hoadon.NAM.ToString();
                                    ctdcbd.Phuong = hoadon.Phuong;
                                    ctdcbd.Quan = hoadon.Quan;
                                    ctdcbd.MSThue = hoadon.MST;
                                    ctdcbd.GiaBieu = hoadon.GB;
                                    if (hoadon.DM != null)
                                        ctdcbd.DinhMuc = hoadon.DM;
                                    else
                                        ctdcbd.DinhMuc = null;
                                    if (hoadon.DinhMucHN != null)
                                        ctdcbd.DinhMucHN = hoadon.DinhMucHN;
                                    else
                                        ctdcbd.DinhMucHN = null;
                                    ctdcbd.SH = hoadon.TILESH.ToString();
                                    ctdcbd.SX = hoadon.TILESX.ToString();
                                    ctdcbd.DV = hoadon.TILEDV.ToString();
                                    ctdcbd.HCSN = hoadon.TILEHCSN.ToString();
                                    ctdcbd.Dot = _cDHN.GetDot(hoadon.DANHBA);
                                    ctdcbd.HieuLucKy = _cTTKH.getHieuLucKyToi(false, _hoadon.DOT);
                                    ctdcbd.DienThoai = txtDienThoai.Text.Trim();

                                    ///Biến lưu Điều Chỉnh về gì (Họ Tên,Địa Chỉ,Định Mức,Giá Biểu,MSThuế)
                                    string ThongTin = "";
                                    ///Định Mức
                                    if (item.Cells["DinhMucCu"].Value.ToString() != item.Cells["DinhMucMoi"].Value.ToString())
                                    {
                                        if (string.IsNullOrEmpty(ThongTin) == true)
                                            ThongTin += "Định Mức";
                                        else
                                            ThongTin += ". Định Mức";
                                        ctdcbd.DinhMuc_BD = int.Parse(item.Cells["DinhMucMoi"].Value.ToString());
                                    }
                                    //if (txtDinhMucHN_BD.Text.Trim() != "" && txtDinhMucHN_BD.Text.Trim() != txtDinhMucHN.Text.Trim())
                                    //{
                                    //    if (string.IsNullOrEmpty(ThongTin) == true)
                                    //        ThongTin += "Định Mức Nghèo";
                                    //    else
                                    //        ThongTin += ". Định Mức Nghèo";
                                    //    ctdcbd.DinhMucHN_BD = int.Parse(txtDinhMucHN_BD.Text.Trim());
                                    //}
                                    ctdcbd.ThongTin = ThongTin;
                                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        ctdcbd.ChucVu = "GIÁM ĐỐC";
                                    else
                                        ctdcbd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                    ctdcbd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                    ctdcbd.PhieuDuocKy = true;
                                    using (var scope = new TransactionScope())
                                        if (_cDCBD.ThemDCBD(ctdcbd))
                                        {
                                            if (dontu_ChiTiet != null)
                                            {
                                                if (_cDonTu.Them_LichSu(ctdcbd.CreateDate.Value, "DCBD", "Đã Điều Chỉnh Biến Động, " + ctdcbd.ThongTin, (int)ctdcbd.MaCTDCBD, dontu_ChiTiet.MaDon.Value, dontu_ChiTiet.STT.Value) == true)
                                                {
                                                }
                                            }
                                            //cắt chứng từ cũ
                                            DataTable dt = _cChungTu.getDS_ChiTiet_DanhBo(ctdcbd.DanhBo);
                                            foreach (DataRow itemCT in dt.Rows)
                                            {
                                                ChungTu_ChiTiet ctchungtu = _cChungTu.GetCT(itemCT["DanhBo"].ToString(), itemCT["MaCT"].ToString(), int.Parse(itemCT["MaLCT"].ToString()));
                                                if (ctchungtu.Cat == false)
                                                {
                                                    ctchungtu.Cat = true;
                                                    _cChungTu.SuaCT(ctchungtu);
                                                }
                                            }
                                            //add chứng từ
                                            //Kiểm tra Danh Bộ & Số Chứng Từ
                                            foreach (DCBD_DKDM_CCCD itemCC in danhbo.DCBD_DKDM_CCCDs)
                                            {
                                                int MaLCT = 0;
                                                if (itemCC.CCCD.Length == 9)
                                                    MaLCT = 16;
                                                else
                                                    if (itemCC.CCCD.Length == 12)
                                                        MaLCT = 15;
                                                if (_cChungTu.CheckExist_CT(ctdcbd.DanhBo, itemCC.CCCD, MaLCT) == true)
                                                {
                                                    MessageBox.Show("Danh Bộ trên đã đăng ký Số Chứng Từ trên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                                ///Kiểm tra Số Chứng Từ
                                                if (_cChungTu.CheckExist(itemCC.CCCD, MaLCT) == false)
                                                {
                                                    ChungTu chungtu = new ChungTu();
                                                    chungtu.MaCT = itemCC.CCCD;
                                                    chungtu.HoTen = itemCC.HoTen;
                                                    chungtu.DiaChi = itemCC.DCThuongTru;
                                                    chungtu.SoNKTong = 1;
                                                    chungtu.MaLCT = MaLCT;
                                                    _cChungTu.Them(chungtu);
                                                }
                                                ///
                                                if (_cChungTu.CheckExist_CT(ctdcbd.DanhBo, itemCC.CCCD, MaLCT) == true)
                                                {
                                                    ChungTu_ChiTiet ctchungtu = _cChungTu.GetCT(ctdcbd.DanhBo, itemCC.CCCD, MaLCT);
                                                    ctchungtu.Cat = false;
                                                    _cChungTu.SuaCT(ctchungtu);
                                                }
                                                else
                                                {
                                                    ChungTu_ChiTiet ctchungtu = new ChungTu_ChiTiet();
                                                    ctchungtu.DanhBo = ctdcbd.DanhBo;
                                                    ctchungtu.MaLCT = MaLCT;
                                                    ctchungtu.MaCT = itemCC.CCCD;
                                                    ctchungtu.SoNKDangKy = 1;
                                                    //if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                                                    //{
                                                    //    ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                                                    //    ctchungtu.NgayHetHan = dateHetHan.Value;
                                                    //}
                                                    ctchungtu.Phuong = hoadon.Phuong;
                                                    ctchungtu.Quan = hoadon.Quan;
                                                    ///Ghi thông tin Lịch Sử chung
                                                    ChungTu_LichSu lichsuchungtu = new ChungTu_LichSu();
                                                    lichsuchungtu.MaDonMoi = dontu_ChiTiet.MaDon;
                                                    lichsuchungtu.STT = dontu_ChiTiet.STT;
                                                    lichsuchungtu.Phuong = hoadon.Phuong;
                                                    lichsuchungtu.Quan = hoadon.Quan;
                                                    lichsuchungtu.DanhBo = ctchungtu.DanhBo;
                                                    lichsuchungtu.MaLCT = ctchungtu.MaLCT;
                                                    lichsuchungtu.MaCT = ctchungtu.MaCT;
                                                    lichsuchungtu.SoNKTong = 1;
                                                    lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
                                                    lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
                                                    lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
                                                    lichsuchungtu.GhiChu = ctchungtu.GhiChu;
                                                    lichsuchungtu.Lo = ctchungtu.Lo;
                                                    lichsuchungtu.Phong = ctchungtu.Phong;

                                                    if (_cChungTu.ThemCT(ctchungtu))
                                                    {
                                                        ///Thêm Lịch Sử đầu tiên
                                                        _cChungTu.ThemLichSuChungTu(lichsuchungtu);

                                                        _cChungTu.SubmitChanges();
                                                    }
                                                }
                                            }
                                            scope.Complete();
                                        }
                                }
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

        //

        private void txtDanhBo_Online_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo_Online.Text.Trim() != "")
                btnXem.PerformClick();
        }

        private void btnXem_Online_Click(object sender, EventArgs e)
        {
            if (txtDanhBo_Online.Text.Trim() != "")
                dgvDanhSach_Online.DataSource = _cDKDM.getDS_Online(txtDanhBo_Online.Text.Trim());
            else
                dgvDanhSach_Online.DataSource = _cDKDM.getDS_Online(dateTu_Online.Value, dateDen_Online.Value);
        }

        private void dgvDanhSach_Online_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach_Online.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnIn_Online_Click(object sender, EventArgs e)
        {
            try
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataGridViewRow item in dgvDanhSach_Online.Rows)
                {
                    DCBD_DKDM_DanhBo en = _cDKDM.get(int.Parse(item.Cells["ID_Online"].Value.ToString()));
                    HOADON hd = _cThuTien.GetMoiNhat(en.DanhBo);
                    foreach (DCBD_DKDM_CCCD itemCT in en.DCBD_DKDM_CCCDs)
                    {
                        DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();
                        dr["SoPhieu"] = en.ID;
                        dr["DanhBo"] = en.DanhBo;
                        dr["HoTen"] = hd.TENKH;
                        dr["DiaChi"] = hd.SO + " " + hd.DUONG + _cDHN.GetPhuongQuan(hd.Quan, hd.Phuong); ;
                        dr["HopDong"] = en.SDT;
                        dr["DinhMuc"] = en.DCBD_DKDM_CCCDs.Count * 4;
                        dr["MSThue"] = itemCT.DCThuongTru;
                        dr["MSThueBD"] = itemCT.DCTamTru;
                        dr["GiaBieu"] = itemCT.NgaySinh.Value.ToString("dd/MM/yyyy");
                        dr["DinhMucHN"] = itemCT.CCCD;
                        dr["HoTenBD"] = itemCT.HoTen;
                        dr["MaQuanPhuong"] = hd.Quan;
                        dsBaoCao.Tables["DCBD"].Rows.Add(dr);
                    }
                }
                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);
                if (dsBaoCao.Tables["DCBD"].Rows.Count > 0)
                {
                    rptDKDM_CCCD rpt = new rptDKDM_CCCD();
                    rpt.SetDataSource(dsBaoCao);
                    rpt.Subreports[0].SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_Online_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSach_Online.Columns[e.ColumnIndex].Name == "actionThem")
                {
                    if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                    {
                        DCBD_DKDM_DanhBo en = _cDKDM.get(int.Parse(dgvDanhSach_Online["ID_Online", e.RowIndex].Value.ToString()));
                        if (_cDKDM.checkExists(en.DanhBo))
                        {
                            MessageBox.Show("Danh Bộ này đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string Thung = "";
                        if (_cDKDM.Sua(en, out Thung))
                        {
                            MessageBox.Show("Thành công\n" + Thung, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DCBD_DKDM_DanhBo danhbo = _cDKDM.get(int.Parse(dgvDanhSach_Online["ID_Online", e.RowIndex].Value.ToString()));
                    if (danhbo != null)
                    {
                        dgvDanhSachCT_Online.Rows.Clear();
                        foreach (DCBD_DKDM_CCCD item in danhbo.DCBD_DKDM_CCCDs.ToList())
                        {
                            var index = dgvDanhSachCT_Online.Rows.Add();
                            dgvDanhSachCT_Online.Rows[index].Cells["IDCT_Online"].Value = item.ID;
                            dgvDanhSachCT_Online.Rows[index].Cells["HoTenCT_Online"].Value = item.HoTen;
                            dgvDanhSachCT_Online.Rows[index].Cells["NgaySinhCT_Online"].Value = item.NgaySinh.Value.ToString("dd/MM/yyyy");
                            dgvDanhSachCT_Online.Rows[index].Cells["DCThuongTruCT_Online"].Value = item.DCThuongTru;
                            dgvDanhSachCT_Online.Rows[index].Cells["DCTamTruCT_Online"].Value = item.DCTamTru;
                            dgvDanhSachCT_Online.Rows[index].Cells["CCCDCT_Online"].Value = item.CCCD;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSachCT_Online_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSachCT_Online.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }




    }
}
