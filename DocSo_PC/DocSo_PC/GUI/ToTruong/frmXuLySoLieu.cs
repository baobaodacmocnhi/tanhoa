﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.Doi;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using DocSo_PC.DAL;
using DocSo_PC.wrBilling;
using DocSo_PC.wrDHN;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmXuLySoLieu : Form
    {
        string _mnu = "mnuXuLySoLieu";
        CDocSo _cDocSo = new CDocSo();
        CDocSo12 _cDocSo12 = new CDocSo12();
        CTo _cTo = new CTo();
        CMayDS _cMayDS = new CMayDS();
        CDHN _cDHN = new CDHN();
        DocSo _docso = null;
        wsBilling wsBilling = new wsBilling();
        wsDHN wsDHN = new wsDHN();
        bool _flagLoadFirst = false;

        public frmXuLySoLieu()
        {
            InitializeComponent();
        }

        private void frmXuLySoLieu_Load(object sender, EventArgs e)
        {
            try
            {
                dgvDanhSach.AutoGenerateColumns = false;
                dgvThongBao.AutoGenerateColumns = false;
                dgvBaoThay.AutoGenerateColumns = false;
                dgvLichSu.AutoGenerateColumns = false;

                cmbNam.DataSource = _cDocSo.getDS_Nam();
                cmbNam.DisplayMember = "Nam";
                cmbNam.ValueMember = "Nam";
                cmbKy.SelectedItem = DateTime.Now.Month.ToString("00");
                cmbDot.SelectedIndex = 0;
                DataTable dtCode = _cDocSo.getDS_Code();
                DataRow dr = dtCode.NewRow();
                dr["Code"] = "Tất Cả";
                dtCode.Rows.InsertAt(dr, 0);
                cmbCode.DataSource = dtCode;
                cmbCode.DisplayMember = "Code";
                cmbCode.ValueMember = "Code";

                dtCode = _cDocSo.getDS_Code();
                cmbCodeMoi.DataSource = dtCode;
                cmbCodeMoi.DisplayMember = "Code";
                cmbCodeMoi.ValueMember = "Code";
                if (CNguoiDung.Doi)
                {
                    cmbTo.Visible = true;
                    List<To> lst = _cTo.getDS_HanhThu();
                    To en = new To();
                    en.MaTo = 0;
                    en.TenTo = "Tất Cả";
                    lst.Insert(0, en);
                    cmbTo.DataSource = lst;
                    cmbTo.DisplayMember = "TenTo";
                    cmbTo.ValueMember = "MaTo";
                    cmbTo.SelectedIndex = -1;
                }
                else
                {
                    lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
                    loadMay(CNguoiDung.MaTo.ToString());
                }
                _flagLoadFirst = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadMay(string MaTo)
        {
            try
            {
                DataTable dtMay = new DataTable();
                if (MaTo == "0")
                    for (int i = 1; i < cmbTo.Items.Count; i++)
                    {
                        dtMay.Merge(_cMayDS.getDS(((To)cmbTo.Items[i]).MaTo.ToString()));
                    }
                else
                    dtMay = _cMayDS.getDS(MaTo);
                DataRow dr = dtMay.NewRow();
                dr["May"] = "Tất Cả";
                dtMay.Rows.InsertAt(dr, 0);
                cmbMay.DataSource = dtMay;
                cmbMay.DisplayMember = "May";
                cmbMay.ValueMember = "May";
                cmbMay.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadThongTin()
        {
            try
            {
                if (_docso != null)
                {
                    TB_DULIEUKHACHHANG dhn = _cDHN.get(_docso.DanhBa);
                    if (dhn != null)
                    {
                        txtCSC.Text = _docso.CSCu.Value.ToString();
                        txtHoTen.Text = dhn.HOTEN;
                        txtDanhBo.Text = dhn.DANHBO.Insert(7, " ").Insert(4, " ");
                        txtHieu.Text = dhn.HIEUDH;
                        txtCo.Text = dhn.CODH;
                        txtSoThan.Text = dhn.SOTHANDH;
                        txtViTri.Text = dhn.VITRIDHN;
                        txtHopDong.Text = dhn.HOPDONG;
                        txtDiaChi.Text = dhn.SONHA + " " + dhn.TENDUONG;
                        txtMLT.Text = dhn.LOTRINH.Insert(4, " ").Insert(2, " ");
                        txtGiaBieu.Text = dhn.GIABIEU;
                        txtDinhMuc.Text = dhn.DINHMUC;
                        if (_docso.GIOGHI != null)
                            txtNgayGhiCS.Text = _docso.GIOGHI.Value.ToString();
                        if (_docso.NVCapNhat != null)
                            txtNguoiCapNhat.Text = _docso.NVCapNhat;
                        if (_docso.NgayCapNhat != null)
                            txtNgayCapNhat.Text = _docso.NgayCapNhat.Value.ToString();
                        tbxGCDS.Text = _docso.GhiChuDS;
                        tbxGCKH.Text = _docso.GhiChuKH;
                        tbxGCTV.Text = _docso.GhiChuTV;
                        dgvThongBao.DataSource = _cDocSo.getThongBao(_docso.DanhBa);
                        dgvBaoThay.DataSource = _cDocSo.getBaoThay(_docso.DanhBa);
                        dgvLichSu.DataSource = _cDocSo.getLichSu(_docso.DanhBa, _docso.Nam.Value.ToString(), _docso.Ky);
                        foreach (DataGridViewColumn item in dgvLichSu.Columns)
                        {
                            if (item.Name.Contains("Ky") == true && dgvLichSu[item.Index, dgvLichSu.Rows.Count - 2].Value.ToString() != "")
                                dgvLichSu[item.Index, dgvLichSu.Rows.Count - 2].Style.BackColor = Color.LimeGreen;
                        }
                        dgvLichSu.Rows.RemoveAt(dgvLichSu.Rows.Count - 1);
                        if (chkLoadHinh.Checked == true)
                            btnXemHinh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex > -1)
                loadMay(cmbTo.SelectedValue.ToString());
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtTong = new DataTable();
            if (CNguoiDung.Doi == true)
            {
                if (txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                {
                    dt = _cDocSo.getDS_XuLy_DanhBo(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", ""));
                }
                else
                {
                    dt = _cDocSo.getDS_XuLy(cmbTo.SelectedValue.ToString(), cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString(), cmbMay.SelectedValue.ToString(), cmbCode.SelectedValue.ToString(), ref dtTong);
                }
            }
            else
            {
                if (txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                {
                    dt = _cDocSo.getDS_XuLy_DanhBo(CNguoiDung.MaTo.ToString(), cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", ""));
                }
                else
                {
                    dt = _cDocSo.getDS_XuLy(CNguoiDung.MaTo.ToString(), cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString(), cmbMay.SelectedValue.ToString(), cmbCode.SelectedValue.ToString(), ref dtTong);
                }
            }
            dgvDanhSach.DataSource = dt;
            if (dtTong != null && dtTong.Rows.Count > 0)
            {
                lbTongSL.Text = dtTong.Rows[0]["TongSL"].ToString();
                lbSLDaGhi.Text = dtTong.Rows[0]["SLDaGhi"].ToString();
                lbSLChuaGhi.Text = dtTong.Rows[0]["SLChuaGhi"].ToString();
                lbSanLuong.Text = dtTong.Rows[0]["SanLuong"].ToString();
                lbSLHD0.Text = dtTong.Rows[0]["SLHD0"].ToString();
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                btnXem.PerformClick();
        }

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _docso = _cDocSo.get_DocSo(dgvDanhSach.CurrentRow.Cells["DocSoID"].Value.ToString());
                loadThongTin();
            }
            catch
            {
            }
        }

        private void btnXemHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_docso != null)
                {
                    lblKy0.Text = (int.Parse(_docso.Ky)).ToString("00") + "/" + (_docso.Nam);
                    byte[] img = _cDocSo12.getHinh((_docso.Nam) + (int.Parse(_docso.Ky)).ToString("00") + _docso.DanhBa);
                    if (img != null)
                        ptbKy0.Image = _cDocSo.byteArrayToImage(img);
                    else
                        ptbKy0.Image = Properties.Resources.no_image;
                    if (_docso.Ky == "01")
                    {
                        lblKy1.Text = "12" + "/" + (_docso.Nam - 1);
                        lblKy2.Text = "11" + "/" + (_docso.Nam - 1);
                        lblKy3.Text = "10" + "/" + (_docso.Nam - 1);
                        img = _cDocSo12.getHinh((_docso.Nam - 1) + "12" + _docso.DanhBa);
                        if (img != null)
                            ptbKy1.Image = _cDocSo.byteArrayToImage(img);
                        else
                            ptbKy1.Image = Properties.Resources.no_image;
                        img = _cDocSo12.getHinh((_docso.Nam - 1) + "11" + _docso.DanhBa);
                        if (img != null)
                            ptbKy2.Image = _cDocSo.byteArrayToImage(img);
                        else
                            ptbKy2.Image = Properties.Resources.no_image;
                        img = _cDocSo12.getHinh((_docso.Nam - 1) + "10" + _docso.DanhBa);
                        if (img != null)
                            ptbKy3.Image = _cDocSo.byteArrayToImage(img);
                        else
                            ptbKy3.Image = Properties.Resources.no_image;
                    }
                    else
                        if (_docso.Ky == "02")
                        {
                            lblKy1.Text = "01" + "/" + (_docso.Nam);
                            lblKy2.Text = "12" + "/" + (_docso.Nam - 1);
                            lblKy3.Text = "11" + "/" + (_docso.Nam - 1);
                            img = _cDocSo12.getHinh((_docso.Nam) + "01" + _docso.DanhBa);
                            if (img != null)
                                ptbKy1.Image = _cDocSo.byteArrayToImage(img);
                            else
                                ptbKy1.Image = Properties.Resources.no_image;
                            img = _cDocSo12.getHinh((_docso.Nam - 1) + "12" + _docso.DanhBa);
                            if (img != null)
                                ptbKy2.Image = _cDocSo.byteArrayToImage(img);
                            else
                                ptbKy2.Image = Properties.Resources.no_image;
                            img = _cDocSo12.getHinh((_docso.Nam - 1) + "11" + _docso.DanhBa);
                            if (img != null)
                                ptbKy3.Image = _cDocSo.byteArrayToImage(img);
                            else
                                ptbKy3.Image = Properties.Resources.no_image;
                        }
                        else
                            if (_docso.Ky == "03")
                            {
                                lblKy1.Text = "01" + "/" + (_docso.Nam);
                                lblKy2.Text = "02" + "/" + (_docso.Nam);
                                lblKy3.Text = "12" + "/" + (_docso.Nam - 1);
                                img = _cDocSo12.getHinh((_docso.Nam) + "01" + _docso.DanhBa);
                                if (img != null)
                                    ptbKy1.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy1.Image = Properties.Resources.no_image;
                                img = _cDocSo12.getHinh((_docso.Nam) + "02" + _docso.DanhBa);
                                if (img != null)
                                    ptbKy2.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy2.Image = Properties.Resources.no_image;
                                img = _cDocSo12.getHinh((_docso.Nam - 1) + "12" + _docso.DanhBa);
                                if (img != null)
                                    ptbKy3.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy3.Image = Properties.Resources.no_image;
                            }
                            else
                            {
                                lblKy1.Text = (int.Parse(_docso.Ky) - 1).ToString("00") + "/" + (_docso.Nam);
                                lblKy2.Text = (int.Parse(_docso.Ky) - 2).ToString("00") + "/" + (_docso.Nam);
                                lblKy3.Text = (int.Parse(_docso.Ky) - 3).ToString("00") + "/" + (_docso.Nam);
                                img = _cDocSo12.getHinh((_docso.Nam) + (int.Parse(_docso.Ky) - 1).ToString("00") + _docso.DanhBa);
                                if (img != null)
                                    ptbKy1.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy1.Image = Properties.Resources.no_image;
                                img = _cDocSo12.getHinh((_docso.Nam) + (int.Parse(_docso.Ky) - 2).ToString("00") + _docso.DanhBa);
                                if (img != null)
                                    ptbKy2.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy2.Image = Properties.Resources.no_image;
                                img = _cDocSo12.getHinh((_docso.Nam) + (int.Parse(_docso.Ky) - 3).ToString("00") + _docso.DanhBa);
                                if (img != null)
                                    ptbKy3.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy3.Image = Properties.Resources.no_image;
                            }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ptbKy0_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _cDocSo.LoadImageView(_cDocSo.imageToByteArray(ptbKy0.Image));
        }

        private void ptbKy1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _cDocSo.LoadImageView(_cDocSo.imageToByteArray(ptbKy1.Image));
        }

        private void ptbKy2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _cDocSo.LoadImageView(_cDocSo.imageToByteArray(ptbKy2.Image));
        }

        private void ptbKy3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _cDocSo.LoadImageView(_cDocSo.imageToByteArray(ptbKy3.Image));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_docso != null)
                    {
                        if (_cDocSo.checkChot_BillState(_docso.Nam.Value.ToString(), _docso.Ky, _docso.Dot) == true)
                        {
                            MessageBox.Show("Năm " + _docso.Nam.Value.ToString() + " Kỳ " + _docso.Ky + " Đợt " + _docso.Dot + " đã chuyển billing", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int TienNuoc = 0, ThueGTGT = 0, TDVTN = 0, ThueTDVTN = 0, TieuThu = 0;
                        //if (wsDHN.tinhCodeTieuThu_CSM(_docso.DocSoID, cmbCodeMoi.SelectedValue.ToString(), int.Parse(txtCSM.Text.Trim()), out TieuThu, out GiaBan, out ThueGTGT, out PhiBVMT, out TongCong) == true)
                        if (wsDHN.tinhCodeTieuThu_TieuThu(_docso.DocSoID, cmbCodeMoi.SelectedValue.ToString(), int.Parse(txtTieuThu.Text.Trim()), out TienNuoc, out ThueGTGT, out TDVTN, out ThueTDVTN) == true)
                        {
                            _docso.CodeMoi = cmbCodeMoi.SelectedValue.ToString();
                            _docso.TTDHNMoi = _cDocSo.getTTDHNCode(_docso.CodeMoi);
                            _docso.CSCu = int.Parse(txtCSC.Text.Trim());
                            _docso.CSMoi = int.Parse(txtCSM.Text.Trim());
                            //_docso.TieuThuMoi = TieuThu;
                            _docso.TieuThuMoi = int.Parse(txtTieuThu.Text.Trim());

                            _docso.TienNuoc = TienNuoc;
                            _docso.Thue = ThueGTGT;
                            _docso.BVMT = TDVTN;
                            _docso.TongTien = TienNuoc + ThueGTGT + TDVTN + ThueTDVTN;
                            _cDocSo.SubmitChanges();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
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

        private void txtCSM_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtCSM.Text.Trim() != "" && e.KeyChar == 13)
                {
                    txtTieuThu.Text = _cDocSo.tinhCodeTieuThu(_docso.DocSoID, cmbCodeMoi.SelectedValue.ToString(), int.Parse(txtCSM.Text.Trim())).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDieuChinhXuat_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cDocSo.checkChot_BillState(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString()) == true)
                        {
                            MessageBox.Show("Năm " + cmbNam.SelectedValue.ToString() + " Kỳ " + cmbKy.SelectedItem.ToString() + " Đợt " + cmbDot.SelectedItem.ToString() + " đã chuyển billing", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        DataTable dt = new DataTable();
                        switch (cmbDieuChinhXuat.SelectedItem.ToString())
                        {
                            case "Điều chỉnh Code 5N, 5K":
                                dt = _cDocSo.getDS_Code5K5N(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString());
                                break;
                            default:
                                break;
                        }
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //Tạo các đối tượng Excel
                            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                            Microsoft.Office.Interop.Excel.Workbooks oBooks;
                            Microsoft.Office.Interop.Excel.Sheets oSheets;
                            Microsoft.Office.Interop.Excel.Workbook oBook;
                            Microsoft.Office.Interop.Excel.Worksheet oSheet;
                            //Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;

                            //Tạo mới một Excel WorkBook 
                            oExcel.Visible = true;
                            oExcel.DisplayAlerts = false;
                            //khai báo số lượng sheet
                            oExcel.Application.SheetsInNewWorkbook = 1;
                            oBooks = oExcel.Workbooks;

                            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                            oSheets = oBook.Worksheets;
                            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

                            _cDocSo.XuatExcel(dt, oSheet, "5K,5N");
                            if (_cDocSo.updateDS_Code5K5N(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString()) == true)
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
