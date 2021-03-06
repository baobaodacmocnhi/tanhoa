﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ThuTien.DAL.Quay;
using ThuTien.BaoCao;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.DAL;
using ThuTien.DAL.QuanTri;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.Quay
{
    public partial class frmTienDuQuay : Form
    {
        string _mnu = "mnuTienDuQuay";
        CTienDuQuay _cTienDuQuay = new CTienDuQuay();
        CHoaDon _cHoaDon = new CHoaDon();
        CDichVuThu _cDichVuThu = new CDichVuThu();
        CDHN _cDocSo = new CDHN();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        public frmTienDuQuay()
        {
            InitializeComponent();
        }

        private void frmTienDuQuay_Load(object sender, EventArgs e)
        {
            dgvTienAm.AutoGenerateColumns = false;
            dgvTienDu.AutoGenerateColumns = false;
        }

        public void CountdgvTienDu()
        {
            long TongCong = 0;
            if (dgvTienDu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvTienDu.Rows)
                {
                    TongCong += long.Parse(item.Cells["SoTien_TienDu"].Value.ToString());
                }
                txtTongCongTienDu.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CountdgvTienAm()
        {
            long TongCong = 0;
            if (dgvTienAm.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvTienAm.Rows)
                {
                    TongCong += long.Parse(item.Cells["SoTien_TienAm"].Value.ToString());
                }
                txtTongCongTienAm.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void dgvTienAm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTienAm.Columns[e.ColumnIndex].Name == "DanhBo_TienAm" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvTienAm.Columns[e.ColumnIndex].Name == "SoTien_TienAm" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTienAm_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTienAm.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTienDu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTienDu.Columns[e.ColumnIndex].Name == "DanhBo_TienDu" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvTienDu.Columns[e.ColumnIndex].Name == "SoTien_TienDu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTienDu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTienDu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvTienAm.DataSource = _cTienDuQuay.GetDSTienAm();
            CountdgvTienAm();
            dgvTienDu.DataSource = _cTienDuQuay.GetDSTienDu();
            CountdgvTienDu();
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
            //dialog.Multiselect = false;

            //if (dialog.ShowDialog() == DialogResult.OK)
            //    if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //    {
            //        ThuTien.DAL.ChuyenKhoan.Excel fileExcel = new ThuTien.DAL.ChuyenKhoan.Excel(dialog.FileName);
            //        DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

            //        foreach (DataRow item in dtExcel.Rows)
            //                {
            //                    _cTienDuQuay.Update(item[0].ToString(), int.Parse(item[1].ToString()), "Bảng Kê", "Thêm");
            //                }
            //    }
        }

        private void btnInDSThuThem_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTienDu.Rows)
            {
                List<HOADON> lstHD = _cHoaDon.GetDSTon_CoChanTienDu(item.Cells["DanhBo_TienDu"].Value.ToString());

                if (lstHD != null && !bool.Parse(item.Cells["ChoXuLy_TienDu"].Value.ToString()) && lstHD[0].DOT >= int.Parse(cmbFromDot.SelectedItem.ToString()) && lstHD[0].DOT <= int.Parse(cmbToDot.SelectedItem.ToString()) && int.Parse(item.Cells["SoTien_TienDu"].Value.ToString()) < lstHD.Sum(itemHD => itemHD.TONGCONG))
                {
                    string ThongTin = "";
                    foreach (HOADON itemHD in lstHD)
                        ///nếu có trong dịch vụ thu thì không thu thêm
                        if (!_cDichVuThu.CheckExist(itemHD.SOHOADON))
                        {
                            DataRow dr = ds.Tables["TienDuKhachHang"].NewRow();
                            dr["DanhBo"] = item.Cells["DanhBo_TienDu"].Value.ToString().Insert(4, " ").Insert(8, " ");
                            dr["HoTen"] = itemHD.TENKH;
                            dr["MLT"] = itemHD.MALOTRINH;
                            dr["DienThoai"] = _cDocSo.GetDienThoai(itemHD.DANHBA);
                            dr["Ky"] = itemHD.KY + "/" + itemHD.NAM;
                            dr["TienDu"] = item.Cells["SoTien_TienDu"].Value;
                            dr["TongCong"] = itemHD.TONGCONG;
                            if (lstHD[0].MaNV_HanhThu != null)
                            {
                                dr["HanhThu"] = _cNguoiDung.GetHoTenByMaND(itemHD.MaNV_HanhThu.Value);
                                dr["To"] = _cNguoiDung.GetTenToByMaND(itemHD.MaNV_HanhThu.Value);
                            }
                            ThongTin += "Hóa đơn kỳ " + itemHD.KY + "/" + itemHD.NAM + " : " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemHD.TONGCONG) + " đồng\r\n";
                            dr["ThongTin"] = ThongTin;

                            ds.Tables["TienDuKhachHang"].Rows.Add(dr);

                            DataRow drTT = ds.Tables["TamThuChuyenKhoan"].NewRow();
                            drTT["LoaiBaoCao"] = "TIỀN DƯ THU THÊM";
                            drTT["DanhBo"] = itemHD.DANHBA.Insert(4, " ").Insert(8, " ");
                            drTT["HoTen"] = itemHD.TENKH;
                            drTT["MLT"] = itemHD.MALOTRINH;
                            drTT["Ky"] = itemHD.KY + "/" + itemHD.NAM;
                            drTT["TongCong"] = itemHD.TONGCONG;
                            if (itemHD.MaNV_HanhThu != null)
                            {
                                drTT["HanhThu"] = _cNguoiDung.GetHoTenByMaND(itemHD.MaNV_HanhThu.Value);
                                drTT["To"] = _cNguoiDung.GetTenToByMaND(itemHD.MaNV_HanhThu.Value);
                            }
                            if (itemHD.GB.Value > 20)
                                drTT["Loai"] = "CQ";
                            else
                                drTT["Loai"] = "TG";
                            if (_cLenhHuy.CheckExist(itemHD.SOHOADON))
                                drTT["LenhHuy"] = true;
                            ds.Tables["TamThuChuyenKhoan"].Rows.Add(drTT);
                        }
                }
            }
            rptTienDuKhachHang rpt = new rptTienDuKhachHang();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();

            rptDSTamThuChuyenKhoan rptTT = new rptDSTamThuChuyenKhoan();
            rptTT.SetDataSource(ds);
            frmBaoCao frmTT = new frmBaoCao(rptTT);
            frmTT.ShowDialog();
        }

        private void btnInDSDuTien_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTienDu.Rows)
            {
                List<HOADON> lstHD = _cHoaDon.GetDSTon_CoChanTienDu(item.Cells["DanhBo_TienDu"].Value.ToString());

                if (lstHD != null && !bool.Parse(item.Cells["ChoXuLy_TienDu"].Value.ToString()) && lstHD[0].DOT >= int.Parse(cmbFromDot.SelectedItem.ToString()) && lstHD[0].DOT <= int.Parse(cmbToDot.SelectedItem.ToString()) && int.Parse(item.Cells["SoTien_TienDu"].Value.ToString()) >= lstHD.Sum(itemHD => itemHD.TONGCONG))
                {
                    string ThongTin = "";
                    foreach (HOADON itemHD in lstHD)
                    {
                        DataRow dr = ds.Tables["TienDuKhachHang"].NewRow();
                        dr["DanhBo"] = item.Cells["DanhBo_TienDu"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = itemHD.TENKH;
                        dr["MLT"] = itemHD.MALOTRINH;
                        dr["DienThoai"] = _cDocSo.GetDienThoai(itemHD.DANHBA);
                        dr["Ky"] = itemHD.KY + "/" + itemHD.NAM;
                        dr["TienDu"] = item.Cells["SoTien_TienDu"].Value;
                        dr["TongCong"] = itemHD.TONGCONG;
                        if (lstHD[0].MaNV_HanhThu != null)
                        {
                            dr["HanhThu"] = _cNguoiDung.GetHoTenByMaND(itemHD.MaNV_HanhThu.Value);
                            dr["To"] = _cNguoiDung.GetTenToByMaND(itemHD.MaNV_HanhThu.Value);
                        }
                        ThongTin += "Hóa đơn kỳ " + itemHD.KY + "/" + itemHD.NAM + " : " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemHD.TONGCONG) + "đồng\r\n";
                        dr["ThongTin"] = ThongTin;

                        ds.Tables["TienDuKhachHang"].Rows.Add(dr);

                        DataRow drTT = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        drTT["LoaiBaoCao"] = "ĐỦ TIỀN";
                        drTT["DanhBo"] = itemHD.DANHBA.Insert(4, " ").Insert(8, " ");
                        drTT["HoTen"] = itemHD.TENKH;
                        drTT["MLT"] = itemHD.MALOTRINH;
                        drTT["Ky"] = itemHD.KY + "/" + itemHD.NAM;
                        drTT["TongCong"] = itemHD.TONGCONG;
                        if (itemHD.MaNV_HanhThu != null)
                        {
                            drTT["HanhThu"] = _cNguoiDung.GetHoTenByMaND(itemHD.MaNV_HanhThu.Value);
                            drTT["To"] = _cNguoiDung.GetTenToByMaND(itemHD.MaNV_HanhThu.Value);
                        }
                        if (itemHD.GB.Value > 20)
                            drTT["Loai"] = "CQ";
                        else
                            drTT["Loai"] = "TG";
                        if (_cLenhHuy.CheckExist(itemHD.SOHOADON))
                            drTT["LenhHuy"] = true;
                        ds.Tables["TamThuChuyenKhoan"].Rows.Add(drTT);
                    }
                }
            }
            rptTienDuKhachHang rpt = new rptTienDuKhachHang();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();

            rptDSTamThuChuyenKhoan rptTT = new rptDSTamThuChuyenKhoan();
            rptTT.SetDataSource(ds);
            frmBaoCao frmTT = new frmBaoCao(rptTT);
            frmTT.ShowDialog();
        }

        private void dgvTienDu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTienDu.RowCount > 0 && e.Button == MouseButtons.Left && dgvTienDu.Columns[e.ColumnIndex].Name != "DienThoai_TienDu")
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    frmDieuChinhTienDuQuay frm = new frmDieuChinhTienDuQuay(dgvTienDu["DanhBo_TienDu", e.RowIndex].Value.ToString(), dgvTienDu["SoTien_TienDu", e.RowIndex].Value.ToString());
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        _cTienDuQuay.Refresh();
                        btnXem.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcelTienDu_Click(object sender, EventArgs e)
        {
            DataTable dt = _cTienDuQuay.GetDSTienDu(dateNgayGiaiTrach.Value);

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

            oSheet.Name = "Tiền Dư";

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH TIỀN DƯ NGÀY \r\n" + dateNgayGiaiTrach.Value.ToString("dd/MM/yyyy");
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Danh Bộ";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Số Tiền";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Ngày BK";
            cl3.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "MLT";
            cl4.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Khách Hàng";
            cl5.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Địa Chỉ";
            cl6.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Tổ";
            cl7.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Hành Thu";
            cl8.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "Bank";
            cl9.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J3", "J3");
            cl10.Value2 = "Điện Thoại";
            cl10.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K3", "K3");
            cl11.Value2 = "Loại";
            cl11.ColumnWidth = 12;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 11];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["DanhBo"].ToString();
                arr[i, 1] = dr["SoTien"].ToString();

                //TT_BangKe bangke = _cBangKe.Get(dr["DanhBo"].ToString());
                //if (bangke != null)
                //    arr[i, 2] = bangke.CreateDate.Value.ToString("dd/MM/yyyy");

                HOADON hoadon = _cHoaDon.GetMoiNhat(dr["DanhBo"].ToString());
                if (hoadon != null)
                {
                    arr[i, 3] = hoadon.MALOTRINH;
                    arr[i, 4] = hoadon.TENKH;
                    arr[i, 5] = hoadon.SO + " " + hoadon.DUONG;
                    if (hoadon.MaNV_HanhThu != null)
                    {
                        arr[i, 6] = _cNguoiDung.GetTenToByMaND(hoadon.MaNV_HanhThu.Value);
                        arr[i, 7] = _cNguoiDung.GetHoTenByMaND(hoadon.MaNV_HanhThu.Value);
                    }
                    if (hoadon.GB <= 20)
                        arr[i, 10] = "TG";
                    else
                        arr[i, 10] = "CQ";
                }
                //arr[i, 8] = _cBangKe.GetBank(dr["DanhBo"].ToString());
                arr[i, 9] = dr["DienThoai"].ToString();

            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 11;

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
            c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            c3b.NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            c3c.NumberFormat = "@";
            c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            oSheet.Cells[rowEnd + 1, 2] = dt.Compute("sum(SoTien)", "");
            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 2];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 2];
            oSheet.get_Range(c1d, c2d).NumberFormat = "#,##0";
        }

        private void dgvTienDu_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvTienDu.Columns[e.ColumnIndex].Name == "DienThoai_TienDu" && e.FormattedValue.ToString().Replace(" ", "") != dgvTienDu[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                //if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                //{
                TT_TienDuQuay tiendu = _cTienDuQuay.Get(dgvTienDu["DanhBo_TienDu", e.RowIndex].Value.ToString());
                tiendu.DienThoai = e.FormattedValue.ToString();
                _cTienDuQuay.Sua(tiendu);
                //}
                //else
                //    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dgvTienDu.Columns[e.ColumnIndex].Name == "ChoXuLy_TienDu" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvTienDu[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                //if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                //{
                TT_TienDuQuay tiendu = _cTienDuQuay.Get(dgvTienDu["DanhBo_TienDu", e.RowIndex].Value.ToString());
                tiendu.ChoXuLy = bool.Parse(e.FormattedValue.ToString());
                _cTienDuQuay.Sua(tiendu);
                //}
                //else
                //    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTienAm_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTienAm.RowCount > 0 && e.Button == MouseButtons.Left && dgvTienAm.Columns[e.ColumnIndex].Name != "DienThoai_TienDu")
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    frmDieuChinhTienDuQuay frm = new frmDieuChinhTienDuQuay(dgvTienAm["DanhBo_TienAm", e.RowIndex].Value.ToString(), dgvTienAm["SoTien_TienAm", e.RowIndex].Value.ToString());
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        _cTienDuQuay.Refresh();
                        btnXem.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInDSPhanTo_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTienDu.Rows)
            {
                DataRow dr = dsBaoCao.Tables["TamThuChuyenKhoan"].NewRow();

                HOADON hoadon = _cHoaDon.GetMoiNhat(item.Cells["DanhBo_TienDu"].Value.ToString());
                dr["LoaiBaoCao"] = "TIỀN DƯ QUẦY";
                dr["DanhBo"] = hoadon.DANHBA.Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = hoadon.TENKH;
                dr["MLT"] = hoadon.MALOTRINH.Insert(4, " ").Insert(2, " ");
                //dr["Ky"] = item.Cells["Ky_TG"].Value.ToString();
                //dr["TongCong"] = item.Cells["TongCong_TG"].Value.ToString();
                if (hoadon.MaNV_HanhThu != null)
                {
                    TT_NguoiDung nguoidung = _cNguoiDung.GetByMaND(hoadon.MaNV_HanhThu.Value);
                    dr["HanhThu"] = nguoidung.HoTen;
                    dr["To"] = nguoidung.TT_To.TenTo;
                }
                if (hoadon.GB > 20)
                    dr["Loai"] = "CQ";
                else
                    dr["Loai"] = "TG";
                dsBaoCao.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
            }
            rptDSTamThuChuyenKhoan rpt = new rptDSTamThuChuyenKhoan();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }


    }
}