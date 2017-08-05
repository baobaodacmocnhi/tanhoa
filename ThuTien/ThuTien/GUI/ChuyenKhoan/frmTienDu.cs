using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.BaoCao;
using ThuTien.DAL.Doi;
using ThuTien.DAL.Quay;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.GUI.BaoCao;
using ThuTien.GUI.TimKiem;
using ThuTien.DAL;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmTienDu : Form
    {
        string _mnu = "mnuTienDu";
        CTienDu _cTienDu = new CTienDu();
        CHoaDon _cHoaDon = new CHoaDon();
        CDichVuThu _cDichVuThu = new CDichVuThu();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CTamThu _cTamThu = new CTamThu();
        CBangKe _cBangKe = new CBangKe();
        CDocSo _cDocSo = new CDocSo();


        public frmTienDu()
        {
            InitializeComponent();
        }

        private void frmTienDu_Load(object sender, EventArgs e)
        {
            dgvTienAm.AutoGenerateColumns = false;
            dgvTienDu.AutoGenerateColumns = false;

            dateNgayGiaiTrach.Value = DateTime.Now;

            cmbFromDot.SelectedIndex = 0;
            cmbToDot.SelectedIndex = 0;
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

        private void dgvTienDu_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvTienDu.Columns[e.ColumnIndex].Name == "DienThoai_TienDu" && e.FormattedValue.ToString().Replace(" ", "") != dgvTienDu[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                //if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                //{
                TT_TienDu tiendu = _cTienDu.Get(dgvTienDu["DanhBo_TienDu", e.RowIndex].Value.ToString());
                tiendu.DienThoai = e.FormattedValue.ToString();
                _cTienDu.Sua(tiendu);
                //}
                //else
                //    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dgvTienDu.Columns[e.ColumnIndex].Name == "ChoXuLy_TienDu" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvTienDu[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                //if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                //{
                TT_TienDu tiendu = _cTienDu.Get(dgvTienDu["DanhBo_TienDu", e.RowIndex].Value.ToString());
                tiendu.ChoXuLy = bool.Parse(e.FormattedValue.ToString());
                _cTienDu.Sua(tiendu);
                //}
                //else
                //    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTienDu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTienDu.RowCount > 0 && e.Button == MouseButtons.Left && dgvTienDu.Columns[e.ColumnIndex].Name != "DienThoai_TienDu")
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    frmDieuChinhTienDu frm = new frmDieuChinhTienDu(dgvTienDu["DanhBo_TienDu", e.RowIndex].Value.ToString(), dgvTienDu["SoTien_TienDu", e.RowIndex].Value.ToString());
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        _cTienDu.Refresh();
                        btnXem.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvTienAm.DataSource = _cTienDu.GetDSTienAm();
            CountdgvTienAm();
            dgvTienDu.DataSource = _cTienDu.GetDSTienDu();
            CountdgvTienDu();
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

        private void btnChuyenTamThu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTamThuChuyenKhoan", "Them"))
            {
                if (MessageBox.Show("Bạn có chắc chắn Chuyển Tạm Thu " + cmbFromDot.SelectedItem.ToString() + "?", "Xác nhận chuyển", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (DataGridViewRow item in dgvTienDu.Rows)
                    {
                        if(item.Cells["DanhBo_TienDu"].Value.ToString()=="13111798220")
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        List<HOADON> lstHD = _cHoaDon.GetDSTon(item.Cells["DanhBo_TienDu"].Value.ToString());
                        if (lstHD != null && !bool.Parse(item.Cells["ChoXuLy_TienDu"].Value.ToString()) && lstHD[0].DOT >= int.Parse(cmbFromDot.SelectedItem.ToString()) && lstHD[0].DOT <= int.Parse(cmbToDot.SelectedItem.ToString()) && int.Parse(item.Cells["SoTien_TienDu"].Value.ToString()) >= lstHD.Sum(itemHD => itemHD.TONGCONG))
                        {
                            foreach (HOADON itemHD in lstHD)
                                if (!_cTamThu.CheckExist(itemHD.SOHOADON))
                                {
                                    TAMTHU tamthu = new TAMTHU();
                                    tamthu.DANHBA = itemHD.DANHBA;
                                    tamthu.FK_HOADON = itemHD.ID_HOADON;
                                    tamthu.SoHoaDon = itemHD.SOHOADON;
                                    tamthu.ChuyenKhoan = true;
                                    tamthu.TienDu = true;
                                    _cTamThu.Them(tamthu);
                                }

                        }
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form Tạm Thu Chuyển Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXuatExcelTienDu_Click(object sender, EventArgs e)
        {
            DataTable dt = _cTienDu.GetDSTienDu(dateNgayGiaiTrach.Value);

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

                TT_BangKe bangke = _cBangKe.Get(dr["DanhBo"].ToString());
                if (bangke != null)
                    arr[i, 2] = bangke.CreateDate.Value.ToString("dd/MM/yyyy");

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
                arr[i, 8] = _cBangKe.GetBank(dr["DanhBo"].ToString());
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

        private int _searchIndex = -1;
        private string _searchNoiDung = "";

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            if (_searchNoiDung != NoiDung)
                _searchIndex = -1;

            for (int i = 0; i < dgvTienDu.Rows.Count; i++)
            {
                if (_searchNoiDung != NoiDung)
                    _searchNoiDung = NoiDung;

                _searchIndex = (_searchIndex + 1) % dgvTienDu.Rows.Count;
                DataGridViewRow row = dgvTienDu.Rows[_searchIndex];
                if (row.Cells["DanhBo_TienDu"].Value == null)
                {
                    continue;
                }
                if (row.Cells["DanhBo_TienDu"].Value.ToString() == NoiDung)
                {
                    dgvTienDu.CurrentCell = row.Cells["DanhBo_TienDu"];
                    dgvTienDu.Rows[_searchIndex].Selected = true;
                    return;
                }
            }
        }

        private void frmTienDu_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvTienAm_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTienAm.RowCount > 0 && e.Button == MouseButtons.Left)
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    frmDieuChinhTienDu frm = new frmDieuChinhTienDu(dgvTienAm["DanhBo_TienAm", e.RowIndex].Value.ToString(), dgvTienAm["SoTien_TienAm", e.RowIndex].Value.ToString());
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        _cTienDu.Refresh();
                        btnXem.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInTBTienDu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTienDu.SelectedRows)
            {
                HOADON hoadon = _cHoaDon.GetTonMoiNhat(item.Cells["DanhBo_TienDu"].Value.ToString());
                if (hoadon != null)
                {
                    DataRow dr = ds.Tables["TienDuKhachHang"].NewRow();

                    dr["DanhBo"] = item.Cells["DanhBo_TienDu"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = hoadon.TENKH;
                    dr["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                    dr["MLT"] = hoadon.MALOTRINH;
                    dr["DienThoai"] = _cDocSo.GetDienThoai(hoadon.DANHBA);
                    dr["Ky"] = hoadon.KY + "/" + hoadon.NAM;
                    dr["TienDu"] = item.Cells["SoTien_TienDu"].Value;
                    dr["TongCong"] = hoadon.TONGCONG-(int)item.Cells["SoTien_TienDu"].Value;

                    ds.Tables["TienDuKhachHang"].Rows.Add(dr);
                }
            }

            rptThongBaoTienDu rpt = new rptThongBaoTienDu();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

    }
}
