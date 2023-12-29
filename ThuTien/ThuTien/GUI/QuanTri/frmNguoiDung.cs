﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL.TongHop;

namespace ThuTien.GUI.QuanTri
{
    public partial class frmNguoiDung : Form
    {
        CTo _cTo = new CTo();
        CNhom _cNhom = new CNhom();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CMenu _cMenu = new CMenu();
        CPhanQuyenNguoiDung _cPhanQuyenNguoiDung = new CPhanQuyenNguoiDung();
        CChamCong _cChamCong = new CChamCong();
        TT_NguoiDung _nguoidung = null;
        string _mnu = "mnuNguoiDung";
        BindingList<TT_NguoiDung> _blNguoiDung;

        public frmNguoiDung()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtHoTen.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtDienThoai.Text = "";
            txtZalo.Text = "";
            txtNam.Text = "";
            txtMaKemBamChi.Text = "";
            txtMay.Text = "";
            txtIDMobile.Text = "";
            cmbTo.SelectedIndex = -1;
            cmbNhom.SelectedIndex = -1;
            chkPhoGiamDoc.Checked = false;
            chkDoi.Checked = false;
            chkToTruong.Checked = false;
            chkHanhThu.Checked = false;
            chkHanhThuVanPhong.Checked = false;
            chkDongNuoc.Checked = false;
            chkVanPhong.Checked = false;
            chkTestApp.Checked = false;
            txtChucVu.Text = "";
            chkKyTen.Checked = false;
            loaddgv();
            _nguoidung = null;
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            dgvNguoiDung.AutoGenerateColumns = false;

            cmbNhom.DataSource = _cNhom.GetDS();
            cmbNhom.DisplayMember = "TenNhom";
            cmbNhom.ValueMember = "MaNhom";
            //cmbNhom.SelectedIndex = -1;

            if (CNguoiDung.Admin)
            {
                panel1.Visible = true;
                cmbPhong.DataSource = _cTo.getDS_Phong();
                cmbPhong.DisplayMember = "Name";
                cmbPhong.ValueMember = "ID";
            }
            else
            {
                panel1.Visible = false;
                cmbTo.DataSource = _cTo.getDS(CNguoiDung.IDPhong);
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            loaddgv();
        }

        public void fillEntity(TT_NguoiDung en)
        {
            try
            {
                txtHoTen.Text = en.HoTen;
                txtDienThoai.Text = en.DienThoai;
                txtZalo.Text = en.Zalo;
                txtTaiKhoan.Text = en.TaiKhoan;
                txtMatKhau.Text = en.MatKhau;
                if (en.NamVaoLam != null)
                    txtNam.Text = en.NamVaoLam.Value.ToString();
                else
                    txtNam.Text = "";
                if (en.MaKemBamChi != null)
                    txtMaKemBamChi.Text = en.MaKemBamChi;
                else
                    txtMaKemBamChi.Text = "";
                if (en.MaTo != null)
                    cmbTo.SelectedValue = en.MaTo.Value;
                else
                    cmbTo.SelectedIndex = -1;
                if (en.MaNhom != null)
                    cmbNhom.SelectedValue = en.MaNhom.Value;
                else
                    cmbNhom.SelectedIndex = -1;
                if (en.May != null)
                    txtMay.Text = en.May.Value.ToString();
                else
                    txtMay.Text = "";
                chkPhoGiamDoc.Checked = en.PhoGiamDoc;
                chkAn.Checked = en.An;
                chkDoi.Checked = en.Doi;
                chkToTruong.Checked = en.ToTruong;
                chkHanhThu.Checked = en.HanhThu;
                chkHanhThuVanPhong.Checked = en.HanhThuVanPhong;
                chkDongNuoc.Checked = en.DongNuoc;
                chkVanPhong.Checked = en.VanPhong;
                chkChamCong.Checked = en.ChamCong;
                chkInPhieuBao.Checked = en.InPhieuBao;
                chkTestApp.Checked = en.TestApp;
                txtChucVu.Text = en.ChucVu;
                chkKyTen.Checked = en.KyTen;
                if (en.IDMobile != null)
                    txtIDMobile.Text = en.IDMobile;
                else
                    txtIDMobile.Text = "";
                if (CNguoiDung.Admin)
                    gridControl.DataSource = _cPhanQuyenNguoiDung.GetDSByMaND(true, en.MaND);
                else
                    gridControl.DataSource = _cPhanQuyenNguoiDung.GetDSByMaND(false, en.MaND);
            }
            catch (Exception)
            {
            }
        }

        public void loaddgv()
        {
            if (CNguoiDung.Admin)
            {
                chkPhoGiamDoc.Visible = true;
                chkAn.Visible = true;
                _blNguoiDung = new BindingList<TT_NguoiDung>(_cNguoiDung.GetDS_Admin(((Phong)cmbPhong.SelectedItem).ID));
            }
            else
                if (CNguoiDung.Doi)
                {
                    chkAn.Visible = true;
                    _blNguoiDung = new BindingList<TT_NguoiDung>(_cNguoiDung.GetDSExceptMaND_Doi(CNguoiDung.MaND));
                }
                else
                {
                    chkPhoGiamDoc.Visible = false;
                    chkAn.Visible = false;
                    _blNguoiDung = new BindingList<TT_NguoiDung>(_cNguoiDung.GetDSExceptMaND(CNguoiDung.MaND));
                }
            dgvNguoiDung.DataSource = _blNguoiDung;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
                {
                    TT_NguoiDung nguoidung = new TT_NguoiDung();
                    nguoidung.HoTen = txtHoTen.Text.Trim();
                    nguoidung.DienThoai = txtDienThoai.Text.Trim();
                    nguoidung.Zalo = txtZalo.Text.Trim();
                    nguoidung.TaiKhoan = txtTaiKhoan.Text.Trim();
                    nguoidung.MatKhau = txtMatKhau.Text.Trim();
                    if (txtIDMobile.Text.Trim() != "")
                        nguoidung.IDMobile = txtIDMobile.Text.Trim();
                    nguoidung.STT = _cNguoiDung.GetMaxSTT() + 1;
                    if (!string.IsNullOrEmpty(txtNam.Text.Trim()))
                    {
                        nguoidung.NamVaoLam = int.Parse(txtNam.Text.Trim());
                        nguoidung.NgayPhepNamCu = nguoidung.NgayPhepNamMoi = 0;
                    }
                    nguoidung.MaKemBamChi = txtMaKemBamChi.Text.Trim();
                    if (txtMay.Text.Trim() != "")
                        nguoidung.May = int.Parse(txtMay.Text.Trim());
                    if (cmbTo.SelectedIndex != -1)
                        nguoidung.MaTo = (int)cmbTo.SelectedValue;
                    if (cmbNhom.SelectedIndex != -1)
                        nguoidung.MaNhom = (int)cmbNhom.SelectedValue;
                    nguoidung.PhoGiamDoc = chkPhoGiamDoc.Checked;
                    nguoidung.An = chkAn.Checked;
                    nguoidung.Doi = chkDoi.Checked;
                    nguoidung.ToTruong = chkToTruong.Checked;
                    nguoidung.HanhThu = chkHanhThu.Checked;
                    nguoidung.HanhThuVanPhong = chkHanhThuVanPhong.Checked;
                    nguoidung.DongNuoc = chkDongNuoc.Checked;
                    nguoidung.VanPhong = chkVanPhong.Checked;
                    nguoidung.ChamCong = chkChamCong.Checked;
                    nguoidung.InPhieuBao = chkInPhieuBao.Checked;
                    nguoidung.TestApp = chkTestApp.Checked;
                    nguoidung.KyTen = chkKyTen.Checked;
                    nguoidung.ChucVu = txtChucVu.Text.Trim();
                    ///tự động thêm quyền cho người mới
                    foreach (var item in _cMenu.GetDS())
                    {
                        TT_PhanQuyenNguoiDung phanquyennguoidung = new TT_PhanQuyenNguoiDung();
                        phanquyennguoidung.MaMenu = item.MaMenu;
                        phanquyennguoidung.MaND = nguoidung.MaND;
                        nguoidung.TT_PhanQuyenNguoiDungs.Add(phanquyennguoidung);
                    }
                    if (chkChamCong.Checked)
                    {
                        TT_CTChamCong ctchamcong = new TT_CTChamCong();
                        ctchamcong.MaCC = _cChamCong.GetMaxMaCC();
                        nguoidung.TT_CTChamCongs.Add(ctchamcong);
                    }
                    if (_cNguoiDung.Them(nguoidung))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (_nguoidung != null)
                {
                    if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
                    {
                        _nguoidung.HoTen = txtHoTen.Text.Trim();
                        _nguoidung.DienThoai = txtDienThoai.Text.Trim();
                        _nguoidung.Zalo = txtZalo.Text.Trim();
                        _nguoidung.TaiKhoan = txtTaiKhoan.Text.Trim();
                        _nguoidung.MatKhau = txtMatKhau.Text.Trim();
                        if (txtIDMobile.Text.Trim() != "")
                            _nguoidung.IDMobile = txtIDMobile.Text.Trim();
                        else
                            _nguoidung.IDMobile = null;
                        if (!string.IsNullOrEmpty(txtNam.Text.Trim()))
                            _nguoidung.NamVaoLam = int.Parse(txtNam.Text.Trim());
                        _nguoidung.MaKemBamChi = txtMaKemBamChi.Text.Trim();
                        if (txtMay.Text.Trim() != "")
                            _nguoidung.May = int.Parse(txtMay.Text.Trim());
                        else
                            _nguoidung.May = null;
                        _nguoidung.MaTo = (int)cmbTo.SelectedValue;
                        _nguoidung.MaNhom = (int)cmbNhom.SelectedValue;
                        _nguoidung.PhoGiamDoc = chkPhoGiamDoc.Checked;
                        _nguoidung.An = chkAn.Checked;
                        _nguoidung.Doi = chkDoi.Checked;
                        _nguoidung.ToTruong = chkToTruong.Checked;
                        _nguoidung.HanhThu = chkHanhThu.Checked;
                        _nguoidung.HanhThuVanPhong = chkHanhThuVanPhong.Checked;
                        _nguoidung.DongNuoc = chkDongNuoc.Checked;
                        _nguoidung.VanPhong = chkVanPhong.Checked;
                        _nguoidung.ChamCong = chkChamCong.Checked;
                        _nguoidung.InPhieuBao = chkInPhieuBao.Checked;
                        _nguoidung.TestApp = chkTestApp.Checked;

                        _cNguoiDung.Sua(_nguoidung);
                    }
                    DataTable dt = ((DataView)gridView.DataSource).Table;
                    foreach (DataRow item in dt.Rows)
                    {
                        TT_PhanQuyenNguoiDung phanquyennguoidung = _cPhanQuyenNguoiDung.GetByMaMenuMaND(int.Parse(item["MaMenu"].ToString()), _nguoidung.MaND);
                        if (phanquyennguoidung.Xem != bool.Parse(item["Xem"].ToString()) || phanquyennguoidung.Them != bool.Parse(item["Them"].ToString()) ||
                            phanquyennguoidung.Sua != bool.Parse(item["Sua"].ToString()) || phanquyennguoidung.Xoa != bool.Parse(item["Xoa"].ToString()) ||
                            phanquyennguoidung.QuanLy != bool.Parse(item["QuanLy"].ToString()))
                        {
                            phanquyennguoidung.Xem = bool.Parse(item["Xem"].ToString());
                            phanquyennguoidung.Them = bool.Parse(item["Them"].ToString());
                            phanquyennguoidung.Sua = bool.Parse(item["Sua"].ToString());
                            phanquyennguoidung.Xoa = bool.Parse(item["Xoa"].ToString());
                            phanquyennguoidung.QuanLy = bool.Parse(item["QuanLy"].ToString());
                            _cPhanQuyenNguoiDung.Sua(phanquyennguoidung);
                        }
                    }
                    Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_nguoidung != null)
                    {
                        ///xóa quan hệ 1 nhiều
                        //_cPhanQuyenNguoiDung.Xoa(nguoidung.TT_PhanQuyenNguoiDungs.ToList());
                        _nguoidung.An = true;
                        _cNguoiDung.Sua(_nguoidung);
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Người Dùng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _nguoidung = _cNguoiDung.GetByMaND(int.Parse(dgvNguoiDung.Rows[e.RowIndex].Cells["MaND"].Value.ToString()));
                fillEntity(_nguoidung);
            }
            catch (Exception)
            {
            }

        }

        private void dgvNguoiDung_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNguoiDung.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvNguoiDung_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNguoiDung.Columns[e.ColumnIndex].Name == "TenTo" && dgvNguoiDung["MaTo", e.RowIndex].Value != null)
                e.Value = _cTo.getHoTen(int.Parse(dgvNguoiDung["MaTo", e.RowIndex].Value.ToString()));
            if (dgvNguoiDung.Columns[e.ColumnIndex].Name == "TenNhom" && dgvNguoiDung["MaNhom", e.RowIndex].Value != null)
                e.Value = _cNhom.GetTenNhomByMaNhom(int.Parse(dgvNguoiDung["MaNhom", e.RowIndex].Value.ToString()));
        }

        private void gridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "ToanQuyen")
                if (bool.Parse(e.Value.ToString()))
                {
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xem"], "True");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Them"], "True");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Sua"], "True");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xoa"], "True");
                }
                else
                {
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xem"], "False");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Them"], "False");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Sua"], "False");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xoa"], "False");
                }
        }

        //private void dgvNguoiDung_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode.Equals(Keys.Up))
        //    {
        //        moveUp();
        //    }
        //    if (e.KeyCode.Equals(Keys.Down))
        //    {
        //        moveDown();
        //    }
        //    e.Handled = true;
        //}

        //private void moveUp()
        //{
        //    if (dgvNguoiDung.RowCount > 0)
        //    {
        //        if (dgvNguoiDung.SelectedRows.Count > 0)
        //        {
        //            int rowCount = dgvNguoiDung.Rows.Count;
        //            int index = dgvNguoiDung.SelectedCells[0].OwningRow.Index;

        //            if (index == 0)
        //            {
        //                return;
        //            }
        //            //DataGridViewRowCollection rows = dgvNguoiDung.Rows;

        //            // remove the previous row and add it behind the selected row.
        //            //DataGridViewRow prevRow = rows[index - 1];
        //            //rows.Remove(prevRow);
        //            //prevRow.Frozen = false;
        //            //rows.Insert(index, prevRow);
        //            //dgvNguoiDung.ClearSelection();
        //            //dgvNguoiDung.Rows[index - 1].Selected = true;
        //            var itemToMoveUp = this._blNguoiDung[index];
        //            this._blNguoiDung.RemoveAt(index);
        //            this._blNguoiDung.Insert(index - 1, itemToMoveUp);
        //            dgvNguoiDung.ClearSelection();
        //            dgvNguoiDung.Rows[index - 1].Selected = true;
        //        }
        //    }
        //}

        //private void moveDown()
        //{
        //    if (dgvNguoiDung.RowCount > 0)
        //    {
        //        if (dgvNguoiDung.SelectedRows.Count > 0)
        //        {
        //            int rowCount = dgvNguoiDung.Rows.Count;
        //            int index = dgvNguoiDung.SelectedCells[0].OwningRow.Index;

        //            if (index == (rowCount - 2)) // include the header row
        //            {
        //                return;
        //            }
        //            //DataGridViewRowCollection rows = dgvNguoiDung.Rows;

        //            // remove the next row and add it in front of the selected row.
        //            //DataGridViewRow nextRow = rows[index + 1];
        //            //rows.Remove(nextRow);
        //            //nextRow.Frozen = false;
        //            //rows.Insert(index, nextRow);
        //            //dgvNguoiDung.ClearSelection();
        //            //dgvNguoiDung.Rows[index + 1].Selected = true;
        //            var itemToMoveDown = this._blNguoiDung[index];
        //            this._blNguoiDung.RemoveAt(index);
        //            this._blNguoiDung.Insert(index + 1, itemToMoveDown);
        //            dgvNguoiDung.ClearSelection();
        //            dgvNguoiDung.Rows[index + 1].Selected = true;
        //        }
        //    }
        //}

        int rowIndexFromMouseDown;
        DataGridViewRow rw;
        private void dgvNguoiDung_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvNguoiDung.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvNguoiDung.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var item = this._blNguoiDung[rowIndexFromMouseDown];
                _blNguoiDung.RemoveAt(rowIndexFromMouseDown);
                _blNguoiDung.Insert(rowIndexOfItemUnderMouseToDrop, item);

                ///update STT dô database
                for (int i = 0; i < _blNguoiDung.Count; i++)
                {
                    _blNguoiDung[i].STT = i + 1;
                }
                _cNguoiDung.SubmitChanges();
            }
        }

        private void dgvNguoiDung_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvNguoiDung.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvNguoiDung_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvNguoiDung.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw = dgvNguoiDung.SelectedRows[0];
                    rowIndexFromMouseDown = dgvNguoiDung.SelectedRows[0].Index;
                    dgvNguoiDung.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _blNguoiDung.Count; i++)
            {
                _blNguoiDung[i].ActiveMobile = chkAll.Checked;
            }
            _cNguoiDung.SubmitChanges();
            loaddgv();
        }

        private void dgvNguoiDung_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvNguoiDung.Columns[e.ColumnIndex].Name == "ActiveMobile")
                    {
                        TT_NguoiDung en = _cNguoiDung.GetByMaND(int.Parse(dgvNguoiDung["MaND", e.RowIndex].Value.ToString()));
                        en.ActiveMobile = bool.Parse(dgvNguoiDung["ActiveMobile", e.RowIndex].Value.ToString());
                        _cNguoiDung.Sua(en);
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                loaddgv();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTo.DataSource = _cTo.getDS(((Phong)cmbPhong.SelectedItem).ID);
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";
        }

    }
}
