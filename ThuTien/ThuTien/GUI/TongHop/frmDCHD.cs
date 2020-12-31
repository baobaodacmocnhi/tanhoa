using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.BaoCao;
using ThuTien.BaoCao.TongHop;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.ChuyenKhoan;
using System.Transactions;

namespace ThuTien.GUI.TongHop
{
    public partial class frmDCHD : Form
    {
        string _mnu = "mnuDCHD";
        CDCHD _cDCHD = new CDCHD();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmDCHD()
        {
            InitializeComponent();
        }

        private void frmDCHD_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvDCHD.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;

            DataTable dtNam = _cHoaDon.GetNam();
            //DataRow dr = dtNam.NewRow();
            //dr["ID"] = "Tất Cả";
            //dtNam.Rows.InsertAt(dr, 0);
            cmbNam.DataSource = dtNam;
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";

            loadHD0Ton();
        }

        public void loadHD0Ton()
        {
            DataTable dt = _cDCHD.getDS_HD0_Ton();
            if (dt != null && dt.Rows.Count > 0)
                lbHD0.Text = dt.Rows.Count+" Hóa Đơn = 0 chưa Đăng Ngân";
            else
                lbHD0.Text = "";
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()) && e.KeyChar == 13)
            {
                dgvHoaDon.DataSource = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim());
                dgvDCHD.DataSource = _cDCHD.getDS_DanhBo(txtDanhBo.Text.Trim());
            }
        }

        private void dgvHoaDon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvHoaDon.RowCount > 0 && e.Button == MouseButtons.Left)
            {
                frmShowDCHD frm = new frmShowDCHD(int.Parse(dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString()), dgvHoaDon.SelectedRows[0].Cells["SoHoaDon"].Value.ToString());
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _cDCHD.Refresh();
                    dgvHoaDon.DataSource = _cHoaDon.GetDSByDanhBo(txtDanhBo.Text.Trim());
                }
                else
                {
                    _cDCHD.Refresh();
                    dgvHoaDon.DataSource = _cHoaDon.GetDSByDanhBo(txtDanhBo.Text.Trim());
                }
            }
        }

        private void dgvDCHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvDCHD.RowCount > 0 && e.Button == MouseButtons.Left)
            {
                frmShowDCHD frm = new frmShowDCHD(int.Parse(dgvDCHD.CurrentRow.Cells["MaHD_DC"].Value.ToString()), dgvDCHD.CurrentRow.Cells["SoHoaDon_DC"].Value.ToString());
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _cDCHD.Refresh();
                    btnXem.PerformClick();
                }
                else
                {
                    _cDCHD.Refresh();
                    btnXem.PerformClick();
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (radGiay.Checked == true)
            {
                if (chkTV.Checked == true && chkTong.Checked == true)
                {
                    dt = _cDCHD.getDS_Giay_TV_Tong_ChuaCapNhat();
                }
                else
                    if (chkTV.Checked == true)
                    {
                        dt = _cDCHD.getDS_Giay_TV_ChuaCapNhat();
                    }
                    else if (chkTong.Checked == true)
                    {
                        dt = _cDCHD.getDS_Giay_Tong_ChuaCapNhat();
                    }
                    else
                        if (chkTrongKy.Checked)
                            dt = _cDCHD.GetDSByNgayDC(dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                        else
                            dt = _cDCHD.GetDSByNgayDC(dateTu.Value, dateDen.Value);
            }
            else
                if (radDienTu.Checked == true)
                {
                    if (chkTV.Checked == true && chkTong.Checked == true)
                    {
                        dt = _cDCHD.getDS_HDDT_TV_Tong_ChuaCapNhat();
                    }
                    else
                        if (chkTV.Checked == true)
                        {
                            dt = _cDCHD.getDS_HDDT_TV_ChuaCapNhat();
                        }
                        else if (chkTong.Checked == true)
                        {
                            dt = _cDCHD.getDS_HDDT_Tong_ChuaCapNhat();
                        }
                        else
                            if (chkTrongKy.Checked)
                                dt = _cDCHD.GetDSByNgayDC(dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            else
                                dt = _cDCHD.GetDSByNgayDC(dateTu.Value, dateDen.Value);
                }

            dgvDCHD.DataSource = dt;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (DataGridViewRow item in dgvDCHD.SelectedRows)
                        if (_cHoaDon.CheckDangNganBySoHoaDon(item.Cells["SoHoaDon_DC"].Value.ToString()))
                        {
                            dgvDCHD.ClearSelection();
                            dgvDCHD.Rows[item.Index].Selected = true;
                            MessageBox.Show("Hóa đơn đã Đăng Ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    try
                    {
                        _cDCHD.BeginTransaction();
                        foreach (DataGridViewRow item in dgvDCHD.SelectedRows)
                        {
                            DIEUCHINH_HD dchd = _cDCHD.GetByMaDC(int.Parse(item.Cells["MaDCHD"].Value.ToString()));
                            HOADON hd = _cHoaDon.Get(dchd.SoHoaDon);
                            if (hd.SoHoaDonCu != null)
                            {
                                hd.SOHOADON = hd.SoHoaDonCu;
                                hd.SoHoaDonCu = null;
                            }
                            hd.GB = dchd.GiaBieu;
                            hd.DM = dchd.DinhMuc;
                            hd.TIEUTHU = dchd.TIEUTHU_BD;
                            hd.GIABAN = dchd.GIABAN_BD;
                            hd.THUE = dchd.THUE_BD;
                            hd.PHI = dchd.PHI_BD;
                            hd.TONGCONG = dchd.TONGCONG_BD;
                            if (_cHoaDon.Sua(hd))
                                _cDCHD.Xoa(dchd);
                        }
                        _cDCHD.CommitTransaction();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        _cDCHD.Rollback();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInDSDangNgan_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkTrongKy.Checked)
                dt = _cDCHD.GetDSDangNgan(dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            else
                dt = _cDCHD.GetDSDangNgan(dateTu.Value, dateDen.Value);
            dsBaoCao ds = new dsBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["DSDCHD"].NewRow();
                dr["LoaiBaoCao"] = "ĐĂNG NGÂN";
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                dr["Ky"] = item["Ky"];
                dr["SoHoaDon"] = item["SoHoaDon"];
                dr["GiaBan"] = item["GiaBan_End"];
                dr["ThueGTGT"] = item["ThueGTGT_End"];
                dr["PhiBVMT"] = item["PhiBVMT_End"];
                dr["TongCong"] = item["TongCong_End"];
                dr["TongCongTruoc"] = item["TongCong_Start"];
                dr["TongCongBD"] = item["TongCong_BD"];
                dr["TieuThuBD"] = item["TieuThu_BD"];
                dr["HanhThu"] = item["HanhThu"];
                dr["To"] = item["To"];
                ds.Tables["DSDCHD"].Rows.Add(dr);
            }

            rptDSDCHD rpt = new rptDSDCHD();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSTon_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkTrongKy.Checked)
                dt = _cDCHD.GetDSTon(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            else
                dt = _cDCHD.GetDSTon();
            dsBaoCao ds = new dsBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["DSDCHD"].NewRow();
                dr["LoaiBaoCao"] = "TỒN";
                //dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                //dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                dr["Ky"] = item["Ky"];
                dr["SoHoaDon"] = item["SoHoaDon"];
                dr["GiaBan"] = item["GiaBan_End"];
                dr["ThueGTGT"] = item["ThueGTGT_End"];
                dr["PhiBVMT"] = item["PhiBVMT_End"];
                dr["TongCong"] = item["TongCong_End"];
                dr["TongCongTruoc"] = item["TongCong_Start"];
                dr["TongCongBD"] = item["TongCong_BD"];
                dr["TieuThuBD"] = item["TieuThu_BD"];
                dr["HanhThu"] = item["HanhThu"];
                dr["To"] = item["To"];
                ds.Tables["DSDCHD"].Rows.Add(dr);
            }
            rptDSDCHD rpt = new rptDSDCHD();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDCHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "DanhBo_DC" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "GiaBan_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "ThueGTGT_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "PhiBVMT_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TongCong_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TongCong_BD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TongCong_Start" && e.Value != null)
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

        private void dgvDCHD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDCHD.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDCHD_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "ChuanThu1" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvDCHD[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    DIEUCHINH_HD dchd = _cDCHD.Get(int.Parse(dgvDCHD["MaHD_DC", e.RowIndex].Value.ToString()));
                    dchd.ChuanThu1 = bool.Parse(e.FormattedValue.ToString());
                    _cDCHD.Sua(dchd);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTrongKy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrongKy.Checked)
                panel1.Enabled = true;
            else
                panel1.Enabled = false;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = _cDCHD.GetDSByNgayDC(dateTu.Value, dateDen.Value);

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

                oSheet.Name = "Sheet1";
                // Tạo tiêu đề cột 
                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
                cl1.Value2 = "Đợt";
                cl1.ColumnWidth = 5;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
                cl2.Value2 = "Kỳ";
                cl2.ColumnWidth = 5;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
                cl3.Value2 = "Năm";
                cl3.ColumnWidth = 5;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
                cl4.Value2 = "Danh Bộ";
                cl4.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
                cl5.Value2 = "Số Phát Hành";
                cl5.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
                cl6.Value2 = "Số Hóa Đơn Cũ";
                cl6.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
                cl7.Value2 = "Giá Biểu Cũ";
                cl7.ColumnWidth = 11;

                Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
                cl8.Value2 = "Định Mức Cũ";
                cl8.ColumnWidth = 11;

                Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
                cl9.Value2 = "Tiêu Thụ Cũ";
                cl9.ColumnWidth = 11;

                Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
                cl10.Value2 = "Tiền Nước Cũ";
                cl10.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
                cl11.Value2 = "Thuế GTGT Cũ";
                cl11.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L1", "L1");
                cl12.Value2 = "Phí BVMT Cũ";
                cl12.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M1", "M1");
                cl13.Value2 = "Tổng Cộng Cũ";
                cl13.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N1", "N1");
                cl14.Value2 = "Giá Biểu Mới";
                cl14.ColumnWidth = 11;

                Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O1", "O1");
                cl15.Value2 = "Định Mức Mới";
                cl15.ColumnWidth = 11;

                Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("P1", "P1");
                cl16.Value2 = "Tiêu Thụ Mới";
                cl16.ColumnWidth = 11;

                Microsoft.Office.Interop.Excel.Range cl17 = oSheet.get_Range("Q1", "Q1");
                cl17.Value2 = "Tiền Nước Mới";
                cl17.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl18 = oSheet.get_Range("R1", "R1");
                cl18.Value2 = "Thuế GTGT Mới";
                cl18.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl19 = oSheet.get_Range("S1", "S1");
                cl19.Value2 = "Phí BVMT Mới";
                cl19.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl20 = oSheet.get_Range("T1", "T1");
                cl20.Value2 = "Tổng Cộng Mới";
                cl20.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl21 = oSheet.get_Range("U1", "U1");
                cl21.Value2 = "Số Hóa Đơn Mới";
                cl21.ColumnWidth = 15;

                // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
                // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
                object[,] arr = new object[dt.Rows.Count, 20];

                //Chuyển dữ liệu từ DataTable vào mảng đối tượng
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    arr[i, 0] = dr["Dot"].ToString();
                    arr[i, 1] = dr["Ky2"].ToString();
                    arr[i, 2] = dr["Nam"].ToString();
                    arr[i, 3] = dr["DanhBo"].ToString();
                    arr[i, 4] = dr["SoPhatHanh"].ToString();
                    arr[i, 5] = dr["SoHoaDon"].ToString();
                    arr[i, 6] = dr["GiaBieuCu"].ToString();
                    arr[i, 7] = dr["DinhMucCu"].ToString();
                    arr[i, 8] = dr["TieuThuCu"].ToString();
                    arr[i, 9] = dr["GiaBan_Start"].ToString();
                    arr[i, 10] = dr["ThueGTGT_Start"].ToString();
                    arr[i, 11] = dr["PhiBVMT_Start"].ToString();
                    arr[i, 12] = dr["TongCong_Start"].ToString();
                    arr[i, 13] = dr["GiaBieuMoi"].ToString();
                    arr[i, 14] = dr["DinhMucMoi"].ToString();
                    arr[i, 15] = dr["TieuThuMoi"].ToString();
                    arr[i, 16] = dr["GiaBan_End"].ToString();
                    arr[i, 17] = dr["ThueGTGT_End"].ToString();
                    arr[i, 18] = dr["PhiBVMT_End"].ToString();
                    arr[i, 19] = dr["TongCong_End"].ToString();
                }

                //Thiết lập vùng điền dữ liệu
                int rowStart = 2;
                int columnStart = 1;

                int rowEnd = rowStart + dt.Rows.Count - 1;
                int columnEnd = 20;

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Import?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            CExcel fileExcel = new CExcel(dialog.FileName);
                            DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                            string SoHoaDon = (string)_cHoaDon.ExecuteQuery_ReturnOneValue("select SoHoaDon from TT_DeviceConfig");

                            foreach (DataRow item in dtExcel.Rows)
                            {
                                if (string.IsNullOrEmpty(item[20].ToString()) == false && item[20].ToString() != "")
                                {
                                    DIEUCHINH_HD dchd = _cDCHD.get(item[5].ToString());
                                    if (dchd != null && dchd.UpdatedHDDT == false && dchd.TONGCONG_END != null)
                                        using (TransactionScope scope = new TransactionScope())
                                        {
                                            dchd.UpdatedHDDT = true;
                                            if (item[20].ToString().Contains(SoHoaDon) == true)
                                                dchd.SoHoaDonMoi = item[20].ToString();
                                            else
                                                dchd.SoHoaDonMoi = SoHoaDon + item[20].ToString();
                                            if (_cDCHD.Sua(dchd) == true)
                                            //if (_cDCHD.ExecuteNonQuery("update HOADON set SoHoaDonCu=SoHoaDon,SoHoaDon='" + dchd.SoHoaDonMoi + "' where ID_HOADON=" + dchd.FK_HOADON) == true)
                                            {
                                                HOADON hd = _cHoaDon.Get(dchd.FK_HOADON);
                                                hd.SoHoaDonCu = hd.SOHOADON;
                                                hd.SOHOADON = dchd.SoHoaDonMoi;
                                                if (_cHoaDon.Sua(hd) == true)
                                                {
                                                    scope.Complete();
                                                    scope.Dispose();
                                                }
                                            }
                                        }
                                }
                            }
                            MessageBox.Show("Đã xử lý xong, Vui lòng kiểm tra lại dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadHD0Ton();
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

        private void chkTV_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTV.Checked == true)
            {
                dateTu.Enabled = false;
                dateDen.Enabled = false;
            }
            else
                if (chkTong.Checked == true)
                {
                    dateTu.Enabled = false;
                    dateDen.Enabled = false;
                }
                else
                {
                    dateTu.Enabled = true;
                    dateDen.Enabled = true;
                }
        }


        private void chkTong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTong.Checked == true)
            {
                dateTu.Enabled = false;
                dateDen.Enabled = false;
            }
            else
                if (chkTV.Checked == true)
                {
                    dateTu.Enabled = false;
                    dateDen.Enabled = false;
                }
                else
                {
                    dateTu.Enabled = true;
                    dateDen.Enabled = true;
                }
        }

        private void btnHDChoDieuChinh_Click(object sender, EventArgs e)
        {
            frmHoaDonChoDieuChinh frm = new frmHoaDonChoDieuChinh();
            frm.ShowDialog();
        }

        private void btnDangNganHD0_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen("mnuDangNganChuyenKhoan", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        CNguoiDung _cNguoiDung = new CNguoiDung();
                        DataTable dt = _cDCHD.getDS_HD0_Ton();
                        foreach (DataRow item in dt.Rows)
                        {
                            _cHoaDon.DangNgan("ChuyenKhoan", item["SoHoaDon"].ToString(), _cNguoiDung.getChuyenKhoan().MaND);
                        }
                        MessageBox.Show("Xử Lý Hoàn Tất, Vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Đăng Ngân Chuyển Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
