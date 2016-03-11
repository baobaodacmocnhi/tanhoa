using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using System.Globalization;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;
using ThuTien.GUI.TimKiem;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.Quay;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmDuLieuKhachHang : Form
    {
        string _mnu = "mnuDuLieuKhachHang";
        CHoaDon _cHoaDon = new CHoaDon();
        CDuLieuKhachHang _cDLKH = new CDuLieuKhachHang();
        CTo _cTo = new CTo();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CTienDu _cTienDu = new CTienDu();

        public frmDuLieuKhachHang()
        {
            InitializeComponent();
        }

        private void frmDuLieuKhachHang_Load(object sender, EventArgs e)
        {
            dgvDanhBo.AutoGenerateColumns = false;
            dgvHoaDon.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;

            cmbDot.SelectedIndex = 0;
            cmbDenDot.SelectedIndex = 0;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbDot.SelectedIndex == 0)
                dgvDanhBo.DataSource = _cDLKH.GetDSDanhBoTon();
            else
                if (cmbDot.SelectedIndex > 0)
                    if (cmbDenDot.SelectedIndex == 0)
                        dgvDanhBo.DataSource = _cDLKH.GetDSDanhBoTon(int.Parse(cmbDot.SelectedItem.ToString()));
                    else
                        if (cmbDenDot.SelectedIndex > 0)
                            dgvDanhBo.DataSource = _cDLKH.GetDSDanhBoTon(int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(cmbDenDot.SelectedItem.ToString()));
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            //List<TT_To> lstTo=_cTo.GetDSHanhThu();
            List<TT_DuLieuKhachHang_DanhBo> lstDB = _cDLKH.GetDS();
            foreach (TT_DuLieuKhachHang_DanhBo item in lstDB)
            {
                DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                dr["DanhBo"] = item.DanhBo.Insert(4, " ").Insert(8, " ");

                HOADON hoadon = _cHoaDon.GetMoiNhat(item.DanhBo);
                dr["HoTen"] = hoadon.TENKH;
                dr["MLT"] = hoadon.MALOTRINH.Insert(4, " ").Insert(2, " ");
                if (hoadon.MaNV_HanhThu == null)
                {
                    hoadon = _cHoaDon.GetMoiNhi(item.DanhBo);
                }
                dr["To"] = _cNguoiDung.GetTenToByMaND(hoadon.MaNV_HanhThu.Value);
                dr["HanhThu"] = _cNguoiDung.GetHoTenByMaND(hoadon.MaNV_HanhThu.Value);
                ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
            }
            rptDSDLKH rpt = new rptDSDLKH();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    try
                    {
                        foreach (DataGridViewRow item in dgvDanhBo.SelectedRows)
                        {
                            _cDLKH.Xoa(_cDLKH.GetByDanhBo(item.Cells["DanhBo_DB"].Value.ToString()));
                        }
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 13 && lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                    {
                        lstHD.Items.Add(item.Trim().ToUpper());
                        lstHD.EnsureVisible(lstHD.Items.Count - 1);
                    }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
                txtSoHoaDon.Text = "";
            }
        }

        private void lstHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHD.Items.Count > 0 && e.Button == MouseButtons.Left)
            {
                foreach (ListViewItem item in lstHD.SelectedItems)
                {
                    lstHD.Items.Remove(item);
                }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
            }
        }

        private void lstHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Text = lstHD.Items.Count.ToString();
        }

        private void btnXem2_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cDLKH.GetDS2(dateTu.Value, dateDen.Value);
        }

        private void btnThem2_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                foreach (ListViewItem item in lstHD.Items)
                {
                    if (!_cHoaDon.CheckExist(item.Text))
                    {
                        MessageBox.Show("Hóa Đơn sai: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                }
                try
                {
                    //_cDLKH.BeginTransaction();
                    foreach (ListViewItem item in lstHD.Items)
                        if (!_cDLKH.CheckExist2(item.Text))
                        {
                            TT_DuLieuKhachHang_SoHoaDon dlkh = new TT_DuLieuKhachHang_SoHoaDon();
                            dlkh.MaHD = _cHoaDon.Get(item.Text).ID_HOADON;
                            dlkh.SoHoaDon = item.Text;
                            if (!_cDLKH.Them2(dlkh))
                            {
                                //_cDLKH.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    //_cDLKH.CommitTransaction();
                    lstHD.Items.Clear();
                    btnXem2.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    //_cDLKH.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    try
                    {
                        _cDLKH.BeginTransaction();
                        foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                        {
                            TT_DuLieuKhachHang_SoHoaDon dlkh = _cDLKH.GetBySoHoaDon2(item.Cells["SoHoaDon_HD"].Value.ToString());
                            if (!_cDLKH.Xoa2(dlkh))
                            {
                                _cDLKH.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        _cDLKH.CommitTransaction();
                        btnXem2.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        _cDLKH.Rollback();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXuatExcel2_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvHoaDon.DataSource;

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

            XuatExcel2(dt, oSheet, "ĐÔNG Á");
        }

        private void XuatExcel2(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
            oSheet.Name = SheetName;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "CN";
            cl2.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Năm";
            cl3.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Kỳ";
            cl4.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "Đợt";
            cl5.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
            cl6.Value2 = "Danh Bộ";
            cl6.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("G1", "G1");
            cl14.Value2 = "Khách Hàng";
            cl14.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("H1", "H1");
            cl7.Value2 = "Số Phát Hành";
            cl7.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("I1", "I1");
            cl8.Value2 = "Số Tài Khoản";
            cl8.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("J1", "J1");
            cl9.Value2 = "Số Tiền Phải Thu";
            cl9.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("K1", "K1");
            cl10.Value2 = "LNTT";
            cl10.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("L1", "L1");
            cl11.Value2 = "Tiền Nước";
            cl11.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("M1", "M1");
            cl12.Value2 = "Thuế GTGT";
            cl12.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("N1", "N1");
            cl13.Value2 = "Phí BVMT";
            cl13.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O1", "O1");
            cl15.Value2 = "Trừ Tiền Dư";
            cl15.ColumnWidth = 10;

            //for (int i = 0; i < dt.Rows.Count; i++)
            //    if (!string.IsNullOrEmpty(dt.Rows[i]["NgayGiaiTrach"].ToString()))
            //    {
            //        dt.Rows.RemoveAt(i);
            //        i--;
            //    }

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 15];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                arr[i, 0] = i + 1;
                arr[i, 1] = "TH";
                arr[i, 2] = dr["Nam"].ToString();
                arr[i, 3] = dr["Ky"].ToString();
                arr[i, 4] = int.Parse(dr["Dot"].ToString()).ToString("00");
                arr[i, 5] = dr["DanhBo"].ToString();
                arr[i, 6] = dr["HoTen"].ToString();
                arr[i, 7] = int.Parse(dr["SoPhatHanh"].ToString()).ToString("00000000");
                arr[i, 8] = dr["SoTaiKhoan"].ToString();
                int TienDu=_cTienDu.GetTienDu(dr["DanhBo"].ToString());
                if (TienDu > 0)
                {
                    arr[i, 14] = "Có";
                    if (TienDu >= int.Parse(dr["TongCong"].ToString()))
                        arr[i, 9] = 0;
                    else
                        arr[i, 9] = int.Parse(dr["TongCong"].ToString()) - TienDu;
                }
                else
                {
                    arr[i, 9] = int.Parse(dr["TongCong"].ToString());
                }
                arr[i, 10] = int.Parse(dr["TieuThu"].ToString()).ToString("00");
                arr[i, 11] = dr["GiaBan"].ToString();
                arr[i, 12] = dr["ThueGTGT"].ToString();
                arr[i, 13] = dr["PhiBVMT"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 15;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            //c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            c3a.NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 11];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            //c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            c3b.NumberFormat = "@";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            //if (tabControl.SelectedTab.Name == "tabDLKH1")
            //{
            //    if (tabControl1.SelectedTab.Name == "tabDaThu")
            //    {
            //        foreach (DataGridViewRow item in dgvDanhBo.Rows)
            //            if (item.Cells["DanhBo_DT"].Value.ToString() == NoiDung)
            //            {
            //                dgvDanhBo.CurrentCell = item.Cells["DanhBo_DT"];
            //                item.Selected = true;
            //            }
            //    }
            //    else
            //        if (tabControl1.SelectedTab.Name == "tabChuaThu")
            //        {
            //            foreach (DataGridViewRow item in dgvHDChuaThu.Rows)
            //                if (item.Cells["DanhBo_CT"].Value.ToString() == NoiDung)
            //                {
            //                    dgvHDChuaThu.CurrentCell = item.Cells["DanhBo_CT"];
            //                    item.Selected = true;
            //                }
            //        }
            //}
        }

        private void frmDuLieuKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                //frmTimKiemForm frm = new frmTimKiemForm();
                //bool flag = false;
                //foreach (var item in this.OwnedForms)
                //    if (item.Name == frm.Name)
                //    {
                //        item.Activate();
                //        flag = true;
                //    }
                //if (flag == false)
                //{
                //    frm.MyGetNoiDung = new frmTimKiemForm.GetNoiDung(GetNoiDungfrmTimKiem);
                //    frm.Owner = this;
                //    frm.Show();
                //}
            }
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
                    {
                        Excel fileExcel = new Excel(dialog.FileName);
                        DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                        foreach (DataRow item in dtExcel.Rows)
                            if (item[0].ToString().Length == 11 && !_cDLKH.CheckExistDanhBo(item[0].ToString()))
                            {
                                TT_DuLieuKhachHang_DanhBo dlkh = new TT_DuLieuKhachHang_DanhBo();
                                dlkh.DanhBo = item[0].ToString();
                                dlkh.HoTen = item[1].ToString();
                                dlkh.SoTaiKhoan = item[2].ToString();
                                _cDLKH.Them(dlkh);
                            }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDanhBo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "DanhBo_DB" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "TieuThu_DB" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "GiaBan_DB" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "ThueGTGT_DB" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "PhiBVMT_DB" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "TongCong_DB" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDanhBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "MLT_HD" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo_HD" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu_HD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan_HD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT_HD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT_HD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong_HD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnInDSTon_DB_Click(object sender, EventArgs e)
        {
            //DataTable dt = (DataTable)dgvDanhBo.DataSource;

            ////Tạo các đối tượng Excel
            //Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Workbooks oBooks;
            //Microsoft.Office.Interop.Excel.Sheets oSheets;
            //Microsoft.Office.Interop.Excel.Workbook oBook;
            //Microsoft.Office.Interop.Excel.Worksheet oSheet;
            ////Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;

            ////Tạo mới một Excel WorkBook 
            //oExcel.Visible = true;
            //oExcel.DisplayAlerts = false;
            ////khai báo số lượng sheet
            //oExcel.Application.SheetsInNewWorkbook = 1;
            //oBooks = oExcel.Workbooks;

            //oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            //oSheets = oBook.Worksheets;
            //oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            //XuatExcel(dt, oSheet, "ĐÔNG Á");

            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDanhBo.Rows)
            {
                DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                //dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                //dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = "CHUYỂN KHOẢN CẦN RÚT";
                dr["DanhBo"] = item.Cells["DanhBo_DB"].Value.ToString().Insert(4, " ").Insert(8, " ");
                dr["HoTen"] = item.Cells["HoTen_DB"].Value.ToString();
                dr["MLT"] = item.Cells["MLT_DB"].Value.ToString().Insert(4, " ").Insert(2, " ");
                dr["Ky"] = item.Cells["Ky_DB"].Value.ToString();
                dr["TongCong"] = item.Cells["TongCong_DB"].Value.ToString();
                dr["HanhThu"] = item.Cells["HanhThu_DB"].Value.ToString();
                dr["To"] = item.Cells["To_DB"].Value.ToString();
                if (int.Parse(item.Cells["GiaBieu_DB"].Value.ToString()) > 20)
                    dr["Loai"] = "CQ";
                else
                    dr["Loai"] = "TG";
                if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_DB"].Value.ToString()))
                    dr["LenhHuy"] = true;
                ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
            }
            rptDSTamThuChuyenKhoan rpt = new rptDSTamThuChuyenKhoan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
            oSheet.Name = SheetName;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "CN";
            cl2.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Năm";
            cl3.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Kỳ";
            cl4.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "Đợt";
            cl5.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
            cl6.Value2 = "Danh Bộ";
            cl6.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("G1", "G1");
            cl14.Value2 = "Khách Hàng";
            cl14.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("H1", "H1");
            cl7.Value2 = "Số Phát Hành";
            cl7.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("I1", "I1");
            cl8.Value2 = "Số Tài Khoản";
            cl8.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("J1", "J1");
            cl9.Value2 = "Số Tiền Phải Thu";
            cl9.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("K1", "K1");
            cl10.Value2 = "LNTT";
            cl10.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("L1", "L1");
            cl11.Value2 = "Tiền Nước";
            cl11.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("M1", "M1");
            cl12.Value2 = "Thuế GTGT";
            cl12.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("N1", "N1");
            cl13.Value2 = "Phí BVMT";
            cl13.ColumnWidth = 10;

            //for (int i = 0; i < dt.Rows.Count; i++)
            //    if (!string.IsNullOrEmpty(dt.Rows[i]["NgayGiaiTrach"].ToString()))
            //    {
            //        dt.Rows.RemoveAt(i);
            //        i--;
            //    }

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 14];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                arr[i, 0] = i + 1;
                arr[i, 1] = "TH";
                arr[i, 2] = dr["Nam"].ToString();
                arr[i, 3] = dr["Ky"].ToString();
                arr[i, 4] = int.Parse(dr["Dot"].ToString()).ToString("00");
                arr[i, 5] = dr["DanhBo"].ToString();
                arr[i, 6] = dr["HoTen"].ToString();
                arr[i, 7] = int.Parse(dr["SoPhatHanh"].ToString()).ToString("00000000");
                arr[i, 8] = dr["SoTaiKhoan"].ToString();
                arr[i, 9] = dr["TongCong"].ToString();
                arr[i, 10] = int.Parse(dr["TieuThu"].ToString()).ToString("00");
                arr[i, 11] = dr["GiaBan"].ToString();
                arr[i, 12] = dr["ThueGTGT"].ToString();
                arr[i, 13] = dr["PhiBVMT"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 14;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            //oSheet.get_Range(c2a, c3a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            oSheet.get_Range(c2a, c3a).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 11];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            //oSheet.get_Range(c2b, c3b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            oSheet.get_Range(c2b, c3b).NumberFormat = "@";

            //Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            //Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            //Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            //oSheet.get_Range(c2c, c3c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            //Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            //Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            //oSheet.get_Range(c2d, c3d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            //Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            //Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            //oSheet.get_Range(c2e, c3e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
            //Microsoft.Office.Interop.Excel.Range c2f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
            //Microsoft.Office.Interop.Excel.Range c3f = oSheet.get_Range(c1f, c2f);
            //oSheet.get_Range(c2f, c3f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void btnXemDanhBo_Click(object sender, EventArgs e)
        {
            dgvDanhBo.DataSource = _cDLKH.GetDS();
        }

        private void btnXuatExcelQuet_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                List<TT_To> lstTo = _cTo.GetDSHanhThu();
                
                //Tạo các đối tượng Excel
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                //khai báo số lượng sheet
                oExcel.Application.SheetsInNewWorkbook = lstTo.Count;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;

                Microsoft.Office.Interop.Excel.Worksheet[] dtoSheet = new Microsoft.Office.Interop.Excel.Worksheet[lstTo.Count];
                for (int i = 0; i < lstTo.Count; i++)
                {
                    dtoSheet[i] = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(i + 1);
                    XuatExcelBaoCao(_cDLKH.GetTongQuet(lstTo[i].MaTo, dateTu.Value, dateDen.Value), dtoSheet[i],"BÁO CÁO SỐ LIỆU UNC QUÉT", lstTo[i].TenTo, dateDen.Value.Month.ToString() + "/" + dateDen.Value.Year.ToString());
                }
            }
        }

        private void btnXuatExcelDangNgan_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                List<TT_To> lstTo = _cTo.GetDSHanhThu();

                //Tạo các đối tượng Excel
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                //khai báo số lượng sheet
                oExcel.Application.SheetsInNewWorkbook = lstTo.Count;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;

                Microsoft.Office.Interop.Excel.Worksheet[] dtoSheet = new Microsoft.Office.Interop.Excel.Worksheet[lstTo.Count];
                for (int i = 0; i < lstTo.Count; i++)
                {
                    dtoSheet[i] = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(i + 1);
                    XuatExcelBaoCao(_cDLKH.GetTongQuetDangNgan(lstTo[i].MaTo, dateTu.Value, dateDen.Value), dtoSheet[i], "BÁO CÁO SỐ LIỆU UNC QUÉT ĐĂNG NGÂN", lstTo[i].TenTo, dateDen.Value.Month.ToString() + "/" + dateDen.Value.Year.ToString());
                }
            }
        }

        private void btnXuatExcelTon_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                List<TT_To> lstTo = _cTo.GetDSHanhThu();

                //Tạo các đối tượng Excel
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                //khai báo số lượng sheet
                oExcel.Application.SheetsInNewWorkbook = lstTo.Count;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;

                Microsoft.Office.Interop.Excel.Worksheet[] dtoSheet = new Microsoft.Office.Interop.Excel.Worksheet[lstTo.Count];
                for (int i = 0; i < lstTo.Count; i++)
                {
                    dtoSheet[i] = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(i + 1);
                    XuatExcelBaoCao(_cDLKH.GetTongQuetTon(lstTo[i].MaTo, dateTu.Value, dateDen.Value), dtoSheet[i], "BÁO CÁO SỐ LIỆU UNC QUÉT TỒN", lstTo[i].TenTo, dateDen.Value.Month.ToString() + "/" + dateDen.Value.Year.ToString());
                }
            }
        }

        private void XuatExcelBaoCao(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet,string TieuDe, string SheetName, string Ky)
        {
            oSheet.Name = SheetName;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "C1");
            head.MergeCells = true;
            head.Value2 = TieuDe+" \r\n " + Ky + " - TỔ " + SheetName;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Ngày";
            cl1.ColumnWidth = 30;
            cl1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tổng HĐ";
            cl2.ColumnWidth = 30;
            cl2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Tổng Cộng";
            cl3.ColumnWidth = 30;
            cl3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 3];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["Ngay"].ToString();
                arr[i, 1] = dr["TongHD"].ToString();
                arr[i, 2] = dr["TongCong"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 3;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            c3a.Font.Bold = true;
            c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            c3a.NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            c3b.Font.Bold = true;
            c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            c3b.NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            c3c.Font.Bold = true;
            c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            c3c.NumberFormat = "#,##0";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void btnInDSTon_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
                if (string.IsNullOrEmpty(item.Cells["NgayGiaiTrach_HD"].Value.ToString()))
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    dr["DanhBo"] = item.Cells["DanhBo_HD"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = item.Cells["HoTen_HD"].Value.ToString();
                    dr["MLT"] = item.Cells["MLT_HD"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    dr["Ky"] = item.Cells["Ky_HD"].Value.ToString() + "/" + item.Cells["Nam_HD"].Value.ToString();
                    dr["TongCong"] = item.Cells["TongCong_HD"].Value.ToString();
                    dr["HanhThu"] = item.Cells["HanhThu_HD"].Value.ToString();
                    dr["To"] = item.Cells["To_HD"].Value.ToString();
                    if (int.Parse(item.Cells["GiaBieu_HD"].Value.ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            rptDSTamThuChuyenKhoan rpt = new rptDSTamThuChuyenKhoan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (ListViewItem item in lstHD.Items)
                    {
                        if (!_cHoaDon.CheckExist(item.Text))
                        {
                            MessageBox.Show("Hóa Đơn sai: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            item.Selected = true;
                            item.Focused = true;
                            return;
                        }
                    }
                    try
                    {
                        //_cDLKH.BeginTransaction();
                        foreach (ListViewItem item in lstHD.Items)
                        {
                            TT_DuLieuKhachHang_SoHoaDon dlkh = _cDLKH.GetBySoHoaDon2(item.Text);
                            if (!_cDLKH.Xoa2(dlkh))
                            {
                                //_cDLKH.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        //_cDLKH.CommitTransaction();
                        lstHD.Items.Clear();
                        btnXem2.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        //_cDLKH.Rollback();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstHD.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
        }

        
    }
}
