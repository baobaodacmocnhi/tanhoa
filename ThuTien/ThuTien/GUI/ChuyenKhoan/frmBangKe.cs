﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.GUI.TimKiem;
using System.Transactions;
using ThuTien.DAL;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmBangKe : Form
    {
        string _mnu = "mnuBangKe";
        CBangKe _cBangKe = new CBangKe();
        CNganHang _cNganHang = new CNganHang();
        CTienDu _cTienDu = new CTienDu();
        CDHN _cDHN = new CDHN();

        public frmBangKe()
        {
            InitializeComponent();
        }

        private void frmBangKe_Load(object sender, EventArgs e)
        {
            dgvBangKe.AutoGenerateColumns = false;
            dgvBangKeGroup.AutoGenerateColumns = false;
            dgvBangKeGroup3.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            dateNgayLap.Value = DateTime.Now;

        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            CExcel fileExcel = new CExcel(dialog.FileName);
                            DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                            //foreach (DataRow item in dtExcel.Rows)
                            //    if ((!string.IsNullOrEmpty(item[1].ToString()) && item[1].ToString().Replace(" ", "").Length == 11))
                            //    {
                            //        dbThuTienDataContext db = new dbThuTienDataContext();
                            //        TT_ThoatNgheo en = new TT_ThoatNgheo();
                            //        en.DanhBo = item[1].ToString().Replace(" ", "");
                            //        db.TT_ThoatNgheos.InsertOnSubmit(en);
                            //        db.SubmitChanges();
                            //    }

                            foreach (DataRow item in dtExcel.Rows)
                                if ((string.IsNullOrEmpty(item[0].ToString()) || item[0].ToString().Replace(" ", "").Length == 11) && !string.IsNullOrEmpty(item[1].ToString()) && !string.IsNullOrEmpty(item[2].ToString()))
                                {
                                    var transactionOptions = new TransactionOptions();
                                    transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                                    {
                                        //if (item[0].ToString().Length == 11 && _cBangKe.CheckExist(item[0].ToString(), DateTime.Now))
                                        //{
                                        //    MessageBox.Show("Danh Bộ: " + item[0].ToString() + " đã thêm trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //    continue;
                                        //}
                                        TT_BangKe bangke = new TT_BangKe();
                                        bangke.DanhBo = item[0].ToString().Trim().Replace(" ", "");
                                        bangke.SoTien = int.Parse(item[1].ToString().Trim());
                                        if (_cNganHang.CheckExist(item[2].ToString().Trim()))
                                            bangke.MaNH = _cNganHang.GetMaNHByKyHieu(item[2].ToString().Trim());
                                        else
                                        {
                                            MessageBox.Show("Lỗi Tên Ngân Hàng tại Danh Bộ: " + bangke.DanhBo + "\nBảng Kê đã lưu được tới đây", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }

                                        bangke.CreateBy = CNguoiDung.MaND;
                                        bangke.CreateDate2 = DateTime.Now;
                                        if (chkNgayLap.Checked == true)
                                        {
                                            bangke.CreateDate = dateNgayLap.Value;
                                            if (_cBangKe.Them(bangke))
                                                if (_cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value, "Bảng Kê", "Thêm", bangke.MaNH.Value, dateNgayLap.Value))
                                                {
                                                    scope.Complete();
                                                    scope.Dispose();
                                                }
                                        }
                                        else
                                        {
                                            bangke.CreateDate = DateTime.Now;
                                            if (_cBangKe.Them(bangke))
                                                if (_cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value, "Bảng Kê", "Thêm", bangke.MaNH.Value))
                                                {
                                                    scope.Complete();
                                                    scope.Dispose();
                                                }
                                        }
                                    }
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvBangKe.DataSource = _cBangKe.GetDS_BangKe_DangNgan(dateTu.Value, dateDen.Value);
            long TongSoTien = 0;
            int TongHD = 0;
            long TongCong = 0;
            if (dgvBangKe.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvBangKe.Rows)
                {
                    TongSoTien += long.Parse(item.Cells["SoTien"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["HoaDon"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["HoaDon"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString()) && !_cCapNuocTanHoa.CheckExist(item.Cells["DanhBo"].Value.ToString()))
                    //    item.DefaultCellStyle.BackColor = Color.Red;
                }
                txtTongDanhBo.Text = dgvBangKe.RowCount.ToString();
                txtTongSoTien.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongSoTien);
                txtTongHD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongCong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
            dgvBangKeGroup.DataSource = _cBangKe.GetDS_Group(dateTu.Value, dateDen.Value);
            dgvBangKeGroup3.DataSource = _cBangKe.GetDS_Group3(dateTu.Value, dateDen.Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    try
                    {
                        if (CNguoiDung.Doi == false)
                        {
                            DateTime CreateDate = new DateTime();
                            DateTime.TryParse(dgvBangKe.SelectedRows[0].Cells["CreateDate"].Value.ToString(), out CreateDate);
                            if (CreateDate.Date != DateTime.Now.Date)
                            {
                                MessageBox.Show("Chỉ được Điều Chỉnh trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        foreach (DataGridViewRow item in dgvBangKe.SelectedRows)
                        {
                            var transactionOptions = new TransactionOptions();
                            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                            {
                                TT_BangKe bangke = _cBangKe.get(int.Parse(item.Cells["MaBK"].Value.ToString()));
                                bool flagLuiNgay = false;
                                DateTime CreateDate = new DateTime();
                                if (bangke.CreateDate.Value.Date != bangke.CreateDate2.Value.Date)
                                {
                                    flagLuiNgay = true;
                                    CreateDate = bangke.CreateDate.Value;
                                }
                                if (_cBangKe.Xoa(bangke))
                                    if (flagLuiNgay == true)
                                    {
                                        if (_cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value * -1, "Bảng Kê", "Xóa", CreateDate))
                                        {
                                            scope.Complete();
                                            scope.Dispose();
                                        }
                                    }
                                    else
                                    {
                                        if (_cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value * -1, "Bảng Kê", "Xóa"))
                                        {
                                            scope.Complete();
                                            scope.Dispose();
                                        }
                                    }
                            }
                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnXem.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int _searchIndex = -1;
        private string _searchNoiDung = "";

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            if (_searchNoiDung != NoiDung)
                _searchIndex = -1;

            for (int i = 0; i < dgvBangKe.Rows.Count; i++)
            {
                if (_searchNoiDung != NoiDung)
                    _searchNoiDung = NoiDung;

                _searchIndex = (_searchIndex + 1) % dgvBangKe.Rows.Count;
                DataGridViewRow row = dgvBangKe.Rows[_searchIndex];
                if (row.Cells["DanhBo"].Value == null || row.Cells["SoTien"].Value == null)
                {
                    continue;
                }
                if (row.Cells["DanhBo"].Value.ToString() == NoiDung || row.Cells["SoTien"].Value.ToString() == NoiDung)
                {
                    dgvBangKe.CurrentCell = row.Cells["DanhBo"];
                    dgvBangKe.Rows[_searchIndex].Selected = true;
                    return;
                }
            }
        }

        private void dgvBangKe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "ChenhLech" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvBangKe_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBangKe.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvBangKe_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "DanhBo" && e.FormattedValue.ToString().Replace(" ", "") != dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString() && e.FormattedValue.ToString().Replace(" ", "").Length == 11)
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    try
                    {
                        if (CNguoiDung.Doi == false)
                        {
                            DateTime CreateDate = new DateTime();
                            DateTime.TryParse(dgvBangKe["CreateDate", e.RowIndex].Value.ToString(), out CreateDate);
                            if (CreateDate.Date != DateTime.Now.Date)
                            {
                                MessageBox.Show("Chỉ được Điều Chỉnh trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            TT_BangKe bangke = _cBangKe.get(int.Parse(dgvBangKe["MaBK", e.RowIndex].Value.ToString()));
                            int SoTien = bangke.SoTien.Value;
                            bangke.DanhBo = e.FormattedValue.ToString().Replace(" ", "");
                            if (_cBangKe.Sua(bangke))
                                if (_cTienDu.Update(dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(" ", ""), bangke.SoTien.Value * (-1), "Bảng Kê", "Sửa Đến Danh Bộ " + e.FormattedValue.ToString().Replace(" ", "").Insert(7, " ").Insert(4, " ")))
                                    if (string.IsNullOrEmpty(dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(" ", "")))
                                    {
                                        if (_cTienDu.Update(bangke.DanhBo, SoTien, "Bảng Kê", "Sửa Từ Danh Bộ Rỗng"))
                                            scope.Complete();
                                    }
                                    else
                                        if (_cTienDu.Update(bangke.DanhBo, SoTien, "Bảng Kê", "Sửa Từ Danh Bộ " + dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(" ", "").Insert(7, " ").Insert(4, " ")))
                                            scope.Complete();
                        }
                        _cTienDu.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBangKe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                frmTimKiemForm frm = new frmTimKiemForm();
                bool flag = false;
                foreach (var item in this.OwnedForms)
                    if (item.Name == frm.Name)
                    {
                        item.Activate();
                        flag = true;
                    }
                if (flag == false)
                {
                    frm.MyGetNoiDung = new frmTimKiemForm.GetNoiDung(GetNoiDungfrmTimKiem);
                    frm.Owner = this;
                    frm.Show();
                }
            }
        }

        private void dgvBangKeGroup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangKeGroup.Columns[e.ColumnIndex].Name == "TongCong_Group" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvBangKeGroup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBangKeGroup.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvBangKeGroup3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangKeGroup3.Columns[e.ColumnIndex].Name == "TongCong_Group3" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvBangKe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dgvBangKe.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString()) && !_cDHN.CheckExist(item.Cells["DanhBo"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void btnChonFileCapNhatPhieuThu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dgvBangKe.Rows.Count == 0)
                    {
                        MessageBox.Show("Chưa tải dữ liệu Bảng kê", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn Cập nhật ngày " + dgvBangKe.Rows[0].Cells["CreateDate"].Value.ToString() + "?", "Xác nhận Cập nhật", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            CExcel fileExcel = new CExcel(dialog.FileName);
                            DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                            //check 2 source
                            if (dgvBangKe.Rows.Count != dtExcel.Rows.Count)
                            {
                                MessageBox.Show("2 Danh Sách Khác Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            var transactionOptions = new TransactionOptions();
                            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                            {
                                for (int i = 0; i < dgvBangKe.Rows.Count; i++)
                                    //if (dgvBangKe.Rows[i].Cells["DanhBo"].Value.ToString() == "13152203536")
                                    //{
                                    //    string str = dtExcel.Rows[i][0].ToString().Replace(" ", "");
                                    //    string str2 = dtExcel.Rows[i][1].ToString();
                                    //    string str3 = dtExcel.Rows[i][3].ToString();
                                    //    string str4 = dtExcel.Rows[i][4].ToString();
                                    //}
                                    if (dgvBangKe.Rows[i].Cells["DanhBo"].Value.ToString() == dtExcel.Rows[i][0].ToString().Replace(" ", "") && dgvBangKe.Rows[i].Cells["SoTien"].Value.ToString() == dtExcel.Rows[i][1].ToString().Trim()
                                        && !string.IsNullOrEmpty(dtExcel.Rows[i][3].ToString().Trim()) && !string.IsNullOrEmpty(dtExcel.Rows[i][4].ToString().Trim()))
                                    {
                                        TT_BangKe bangke = _cBangKe.get(int.Parse(dgvBangKe.Rows[i].Cells["MaBK"].Value.ToString()));
                                        bangke.SoPhieuThu = dtExcel.Rows[i][3].ToString().Trim();
                                        string[] date = dtExcel.Rows[i][4].ToString().Trim().Split('/');
                                        string[] year = date[2].Split(' ');
                                        bangke.NgayPhieuThu = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]));
                                        _cBangKe.Sua(bangke);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Lỗi Danh Bộ " + dtExcel.Rows[i][0].ToString().Replace(" ", ""), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                scope.Complete();
                            }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkNgayLap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayLap.Checked == true)
                dateNgayLap.Enabled = true;
            else
                dateNgayLap.Enabled = false;
        }

    }
}

