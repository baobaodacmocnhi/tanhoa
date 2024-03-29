﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.GUI.BaoCao;
using System.Transactions;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.Doi;
using ThuTien.BaoCao.DongNuoc;
using ThuTien.DAL;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmPhiMoNuocChuyenKhoan : Form
    {
        string _mnu = "mnuPhiMoNuocChuyenKhoan";
        CTienDu _cTienDu = new CTienDu();
        CPhiMoNuoc _cPhiMoNuoc = new CPhiMoNuoc();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CBangKe _cBangKe = new CBangKe();
        CDHN _cDHN = new CDHN();

        public frmPhiMoNuocChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmPhiMoNuocChuyenKhoan_Load(object sender, EventArgs e)
        {
            dgvTienDu.AutoGenerateColumns = false;
            dgvPhiMoNuoc.AutoGenerateColumns = false;
            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvTienDu.DataSource = _cTienDu.getDS_PhiMoNuoc();
            if (dateTu.Value <= dateDen.Value)
                if (radPhiMoNuocChung.Checked)
                    dgvPhiMoNuoc.DataSource = _cPhiMoNuoc.getDS_Chung(dateTu.Value, dateDen.Value, CNguoiDung.FromDot, CNguoiDung.ToDot);
                else if (radPhiMoNuocRieng.Checked)
                    dgvPhiMoNuoc.DataSource = _cPhiMoNuoc.getDS_Rieng(dateTu.Value, dateDen.Value, CNguoiDung.FromDot, CNguoiDung.ToDot);

            foreach (DataGridViewRow item in dgvPhiMoNuoc.Rows)
            {
                if (item.Cells["PhiMoNuoc"].Value != null && item.Cells["PhiMoNuoc"].Value.ToString() != "")
                    if (int.Parse(item.Cells["PhiMoNuoc"].Value.ToString()) / _cDongNuoc.GetPhiMoNuoc(int.Parse(item.Cells["Co"].Value.ToString())) > 1)
                        item.DefaultCellStyle.BackColor = Color.Orange;
            }
        }

        private void dgvPhiMoNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "MaPMN" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "DanhBo_PMN" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvPhiMoNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvPhiMoNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvPhiMoNuoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "GhiChu_PMN" && e.FormattedValue.ToString() != dgvPhiMoNuoc[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(dgvPhiMoNuoc["MaPMN", e.RowIndex].Value.ToString()));
                    phimonuoc.GhiChu = e.FormattedValue.ToString();
                    _cPhiMoNuoc.Sua(phimonuoc);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "Chot_PMN" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvPhiMoNuoc[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(dgvPhiMoNuoc["MaPMN", e.RowIndex].Value.ToString()));
                    if (bool.Parse(e.FormattedValue.ToString()) == true)
                    {
                        phimonuoc.Chot = bool.Parse(e.FormattedValue.ToString());
                        phimonuoc.NgayChot = DateTime.Now;
                    }
                    else
                    {
                        MessageBox.Show("Đã Chốt không được xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        //phimonuoc.Chot = bool.Parse(e.FormattedValue.ToString());
                        //phimonuoc.NgayChot = null;
                    }
                    _cPhiMoNuoc.Sua(phimonuoc);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "TraHD_PMN" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvPhiMoNuoc[e.ColumnIndex, e.RowIndex].Value.ToString()))
            //{
            //    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            //    {
            //        TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(dgvPhiMoNuoc["MaPMN", e.RowIndex].Value.ToString()));
            //        if (bool.Parse(e.FormattedValue.ToString()))
            //        {
            //            phimonuoc.TraHD = bool.Parse(e.FormattedValue.ToString());
            //            phimonuoc.NgayTraHD = DateTime.Now;
            //        }
            //        else
            //        {
            //            phimonuoc.TraHD = bool.Parse(e.FormattedValue.ToString());
            //            phimonuoc.NgayTraHD = null;
            //        }
            //        _cPhiMoNuoc.Sua(phimonuoc);
            //    }
            //    else
            //        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (radPhiMoNuocChung.Checked)
            {
                foreach (DataGridViewRow item in dgvPhiMoNuoc.Rows)
                {
                    DataRow dr = ds.Tables["PhiMoNuoc"].NewRow();
                    dr["SoPhieu"] = item.Cells["MaPMN"].Value.ToString().Insert(item.Cells["MaPMN"].Value.ToString().Length - 2, "-");
                    dr["DanhBo"] = item.Cells["DanhBo_PMN"].Value.ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = item.Cells["HoTen_PMN"].Value.ToString();
                    dr["DiaChi"] = item.Cells["DiaChi_PMN"].Value.ToString();
                    DateTime NgayBK = new DateTime();
                    DateTime.TryParse(item.Cells["NgayBK_PMN"].Value.ToString(), out NgayBK);
                    dr["NgayBK"] = NgayBK.ToString("dd/MM/yyyy");
                    dr["NgayGiaiTrach"] = NgayBK.ToString("dd/MM/yyyy");
                    if (item.Cells["SoTien_PMN"].Value != null && item.Cells["SoTien_PMN"].Value.ToString() != "")
                        dr["SoTien"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(item.Cells["SoTien_PMN"].Value.ToString()));
                    if (item.Cells["TongCong_PMN"].Value != null && item.Cells["TongCong_PMN"].Value.ToString() != "")
                        dr["TongCong"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(item.Cells["TongCong_PMN"].Value.ToString()));
                    if (item.Cells["PhiMoNuoc"].Value.ToString() != "")
                    {
                        dr["PhiMoNuoc"] = int.Parse(item.Cells["PhiMoNuoc"].Value.ToString());
                        dr["PhiMoNuocChu"] = _cPhiMoNuoc.ConvertMoneyToWord(item.Cells["PhiMoNuoc"].Value.ToString());
                    }
                    else
                    {
                        dr["PhiMoNuoc"] = 235000;
                        dr["PhiMoNuocChu"] = _cPhiMoNuoc.ConvertMoneyToWord(dr["PhiMoNuoc"].ToString());
                    }
                    dr["SoTK"] = item.Cells["SoTK_PMN"].Value.ToString();
                    dr["ChucVu"] = CNguoiDung.ChucVu.Replace(" PHÒNG", "");
                    dr["TenPhong"] = CNguoiDung.TenPhong.ToUpper();
                    dr["NguoiKy"] = CNguoiDung.NguoiKy;
                    ds.Tables["PhiMoNuoc"].Rows.Add(dr);
                }
                rptChuyenPhiMoNuoc rpt = new rptChuyenPhiMoNuoc();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
            else if (radPhiMoNuocRieng.Checked)
            {
                foreach (DataGridViewRow item in dgvPhiMoNuoc.Rows)
                {
                    DataRow dr = ds.Tables["KQDongNuoc"].NewRow();
                    dr["NhanVien"] = item.Cells["CreateBy"].Value;
                    dr["STT"] = item.Cells["MaKQDN"].Value;
                    dr["DanhBo"] = item.Cells["DanhBo_PMN"].Value;
                    dr["HoTen"] = item.Cells["HoTen_PMN"].Value;
                    dr["DiaChi"] = item.Cells["DiaChi_PMN"].Value + _cDHN.getPhuongQuan(item.Cells["DanhBo_PMN"].Value.ToString());
                    dr["Co"] = item.Cells["Co"].Value;
                    dr["Hieu"] = item.Cells["Hieu"].Value;
                    dr["SoThan"] = item.Cells["SoThan"].Value;
                    dr["ChiSo"] = item.Cells["ChiSoDN"].Value;
                    dr["GhiChu"] = item.Cells["LyDo"].Value;
                    dr["PhiMoNuoc"] = item.Cells["PhiMoNuoc"].Value;
                    DateTime NgayDN = new DateTime();
                    DateTime.TryParse(item.Cells["NgayDN"].Value.ToString(), out NgayDN);
                    dr["NgayDN"] = NgayDN;
                    ds.Tables["KQDongNuoc"].Rows.Add(dr);
                }
                rptBBDongNuoc rpt = new rptBBDongNuoc();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn Xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    using (var scope = new TransactionScope())
                    {
                        if (_cTienDu.Update(dgvPhiMoNuoc.SelectedRows[0].Cells["DanhBo_PMN"].Value.ToString(), int.Parse(dgvPhiMoNuoc.SelectedRows[0].Cells["SoTien_PMN"].Value.ToString()) - int.Parse(dgvPhiMoNuoc.SelectedRows[0].Cells["TongCong_PMN"].Value.ToString()), "Điều Chỉnh Tiền", "Xóa Chuyển Phí Mở Nước"))
                        {
                            TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(dgvPhiMoNuoc.SelectedRows[0].Cells["MaPMN"].Value.ToString()));
                            TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(phimonuoc.MaKQDN.Value);
                            kqdongnuoc.DongPhi = false;
                            kqdongnuoc.NgayDongPhi = null;
                            kqdongnuoc.ChuyenKhoan = false;
                            if (_cDongNuoc.SuaKQ(kqdongnuoc))
                                if (_cPhiMoNuoc.Xoa(phimonuoc))
                                {
                                    scope.Complete();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                        }
                    }
                    btnXem.PerformClick();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvTienDu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
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

            oSheet.Name = "DANH SÁCH CHUYỂN PHÍ MỞ NƯỚC";
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl0 = oSheet.get_Range("A1", "A1");
            cl0.Value2 = "STT";
            cl0.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("B1", "B1");
            cl5.Value2 = "Ngày tháng";
            cl5.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("C1", "C1");
            cl7.Value2 = "Khách Hàng";
            cl7.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("D1", "D1");
            cl8.Value2 = "Địa Chỉ";
            cl8.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("E1", "E1");
            cl1.Value2 = "Danh Bộ";
            cl1.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("F1", "F1");
            cl9.Value2 = "Tổng số tiền đã chuyển về TCTy";
            cl9.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("G1", "G1");
            cl3.Value2 = "Tiền Nước";
            cl3.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("H1", "H1");
            cl4.Value2 = "Tiền Phí đóng mở nước";
            cl4.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("I1", "I1");
            cl2.Value2 = "Số Tiền Vào TK";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("J1", "J1");
            cl6.Value2 = "Số Phiếu";
            cl6.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("K1", "K1");
            cl10.Value2 = "Phường";
            cl10.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("L1", "L1");
            cl11.Value2 = "Quận";
            cl11.ColumnWidth = 10;
            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            int countColumn = 12;
            object[,] arr = new object[dgvPhiMoNuoc.Rows.Count, countColumn];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dgvPhiMoNuoc.Rows.Count; i++)
            {
                arr[i, 0] = i + 1;
                if (dgvPhiMoNuoc["NgayBK_PMN", i].Value != null && dgvPhiMoNuoc["NgayBK_PMN", i].Value.ToString() != "")
                {
                    TT_BangKe bk = _cBangKe.get(dgvPhiMoNuoc["DanhBo_PMN", i].Value.ToString(), DateTime.Parse(dgvPhiMoNuoc["NgayBK_PMN", i].Value.ToString()));
                    if (bk != null && bk.SoPhieuThu != null && bk.SoPhieuThu != "")
                        arr[i, 8] = _cBangKe.getTongSoTien(bk.SoPhieuThu);
                    arr[i, 1] = dgvPhiMoNuoc["NgayBK_PMN", i].Value.ToString();
                }
                else
                    arr[i, 1] = dgvPhiMoNuoc["CreateDate", i].Value.ToString();
                arr[i, 2] = dgvPhiMoNuoc["HoTen_PMN", i].Value.ToString();
                arr[i, 3] = dgvPhiMoNuoc["DiaChi_PMN", i].Value.ToString();
                arr[i, 4] = dgvPhiMoNuoc["DanhBo_PMN", i].Value.ToString();
                if (dgvPhiMoNuoc["TongCong_PMN", i].Value != null)
                {
                    arr[i, 5] = int.Parse(dgvPhiMoNuoc["TongCong_PMN", i].Value.ToString()) + int.Parse(dgvPhiMoNuoc["PhiMoNuoc", i].Value.ToString());
                    arr[i, 6] = dgvPhiMoNuoc["TongCong_PMN", i].Value.ToString();
                }
                arr[i, 7] = dgvPhiMoNuoc["PhiMoNuoc", i].Value.ToString();
                if (dgvPhiMoNuoc["MaPMN", i].Value != null)
                    arr[i, 9] = dgvPhiMoNuoc["MaPMN", i].Value.ToString();
                string phuong, quan;
                _cDHN.GetPhuongQuan(dgvPhiMoNuoc["DanhBo_PMN", i].Value.ToString(), out phuong, out quan);
                arr[i, 10] = phuong;
                arr[i, 11] = quan;
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dgvPhiMoNuoc.Rows.Count - 1;
            int columnEnd = countColumn;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            c3b.NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            c3d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void chkChotTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvPhiMoNuoc.RowCount > 0 && chkChotTatCa.Checked == true)
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    foreach (DataGridViewRow item in dgvPhiMoNuoc.Rows)
                    {
                        TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(item.Cells["MaPMN"].Value.ToString()));
                        phimonuoc.Chot = true;
                        phimonuoc.NgayChot = DateTime.Now;
                        _cPhiMoNuoc.Sua(phimonuoc);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
