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
using ThuTien.DAL;

namespace ThuTien.GUI.TongHop
{
    public partial class frmDCHD : Form
    {
        string _mnu = "mnuDCHD";
        CDCHD _cDCHD = new CDCHD();
        CHoaDon _cHoaDon = new CHoaDon();
        CThuongVu _cThuongVu = new CThuongVu();

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

            loadHoaDon();
        }

        public void loadHoaDon()
        {
            DataTable dt = _cDCHD.getDS_HDDC_DangNgan_HD0();
            if (dt != null && dt.Rows.Count > 0)
                lbHD0.Text = dt.Rows.Count + " HĐ = 0 chưa Đăng Ngân";
            else
                lbHD0.Text = "";
            dt = _cDCHD.getDS_HDDC_Cho_DangNgan();
            dt.Merge(_cDCHD.getDS_HDDC_Cho_DangNgan_HD0());
            if (dt != null && dt.Rows.Count > 0)
                lbHDDCCho.Text = dt.Rows.Count + " HĐ chờ HĐĐC";
            else
                lbHDDCCho.Text = "";
            dt = _cDCHD.getDS_HDDC_DangNgan();
            if (dt != null && dt.Rows.Count > 0)
                lbHDDC.Text = dt.Rows.Count + " HĐĐC chưa Đăng Ngân";
            else
                lbHDDC.Text = "";
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")) && e.KeyChar == 13)
            {
                btnXem.PerformClick();
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
                    //_cDCHD.Refresh();
                    //btnXem.PerformClick();
                }
                else
                {
                    //_cDCHD.Refresh();
                    //btnXem.PerformClick();
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")))
            {
                dgvHoaDon.DataSource = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim().Replace(" ", ""));
                dgvDCHD.DataSource = _cDCHD.getDS_DanhBo(txtDanhBo.Text.Trim().Replace(" ", ""));
            }
            else
            {
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
                            if (chkTrongKy.Checked == true)
                                if (radNgayDC.Checked == true)
                                    dt = _cDCHD.GetDSByNgayDC(dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                else
                                    dt = _cDCHD.GetDSByNgayChan(dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            else
                                if (radNgayDC.Checked == true)
                                    dt = _cDCHD.GetDSByNgayDC(dateTu.Value, dateDen.Value);
                                else
                                    dt = _cDCHD.GetDSByNgayChan(dateTu.Value, dateDen.Value);
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
                                if (chkTrongKy.Checked == true)
                                    if (radNgayDC.Checked == true)
                                        dt = _cDCHD.GetDSByNgayDC(dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                    else
                                        dt = _cDCHD.GetDSByNgayChan(dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                else
                                    if (radNgayDC.Checked == true)
                                        dt = _cDCHD.GetDSByNgayDC(dateTu.Value, dateDen.Value);
                                    else
                                        dt = _cDCHD.GetDSByNgayChan(dateTu.Value, dateDen.Value);
                    }
                dgvDCHD.DataSource = dt;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (CNguoiDung.Admin == false)
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
                            HOADON hd = _cHoaDon.Get(dchd.FK_HOADON);
                            if (hd.SoHoaDonCu != null)
                            {
                                hd.SOHOADON = hd.SoHoaDonCu;
                                hd.SoHoaDonCu = null;
                            }
                            hd.GB = dchd.GiaBieu.Value;
                            hd.DM = dchd.DinhMuc;
                            hd.TIEUTHU = dchd.TIEUTHU_BD;
                            hd.GIABAN = dchd.GIABAN_BD;
                            hd.THUE = dchd.THUE_BD;
                            hd.PHI = dchd.PHI_BD;
                            hd.ThueGTGT_TDVTN = dchd.PHI_Thue_BD;
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
                DataTable dt = _cDCHD.getDS_HDDC_Cho_DangNgan();
                dt.Merge(_cDCHD.getDS_HDDC_Cho_DangNgan_HD0());

                //Tạo các đối tượng Excel
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;
                Microsoft.Office.Interop.Excel.Worksheet oSheet;

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                //khai báo số lượng sheet
                oExcel.Application.SheetsInNewWorkbook = 1;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

                oSheet.Name = "TH_BinhThuong(" + dt.Rows.Count + ")";
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
                cl6.Value2 = "Chỉ Số Mới";
                cl6.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
                cl7.Value2 = "Chỉ Số Cũ";
                cl7.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
                cl8.Value2 = "Mẫu Số Cũ";
                cl8.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
                cl9.Value2 = "Ký Hiệu Cũ";
                cl9.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
                cl10.Value2 = "Số Hóa Đơn Cũ";
                cl10.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
                cl11.Value2 = "Họ Tên Người Mua Hàng";
                cl11.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L1", "L1");
                cl12.Value2 = "Tên Đơn Vị";
                cl12.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M1", "M1");
                cl13.Value2 = "Địa Chỉ Đơn Vị Mua";
                cl13.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N1", "N1");
                cl14.Value2 = "Mã Số Thuế";
                cl14.ColumnWidth = 11;

                Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O1", "O1");
                cl15.Value2 = "Giá Biểu Mới";
                cl15.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("P1", "P1");
                cl16.Value2 = "Định Mức Mới";
                cl16.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl17 = oSheet.get_Range("Q1", "Q1");
                cl17.Value2 = "Tiêu Thụ Mới";
                cl17.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl18 = oSheet.get_Range("R1", "R1");
                cl18.Value2 = "Số Lượng";
                cl18.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl19 = oSheet.get_Range("S1", "S1");
                cl19.Value2 = "Đơn Giá";
                cl19.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl20 = oSheet.get_Range("T1", "T1");
                cl20.Value2 = "Thành Tiền";
                cl20.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl21 = oSheet.get_Range("U1", "U1");
                cl21.Value2 = "Thuế GTGT";
                cl21.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl22 = oSheet.get_Range("V1", "V1");
                cl22.Value2 = "Phí BVMT";
                cl22.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl23 = oSheet.get_Range("W1", "W1");
                cl23.Value2 = "Cộng Tiền Dịch Vụ Chưa Thuế";
                cl23.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl24 = oSheet.get_Range("X1", "X1");
                cl24.Value2 = "Thuế GTGT Mới";
                cl24.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl25 = oSheet.get_Range("Y1", "Y1");
                cl25.Value2 = "Phí BVMT Mới";
                cl25.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl26 = oSheet.get_Range("Z1", "Z1");
                cl26.Value2 = "Tổng Cộng Mới";
                cl26.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl27 = oSheet.get_Range("AA1", "AA1");
                cl27.Value2 = "Thuế GTGT 10% ";
                cl27.ColumnWidth = 15;

                int indexRow = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    DCBD_ChiTietHoaDon dchd = _cThuongVu.get_HoaDon(decimal.Parse(dr["SoPhieu"].ToString()));
                    indexRow++;
                    oSheet.Cells[indexRow, 1] = dr["Dot"].ToString();
                    oSheet.Cells[indexRow, 2] = dr["Ky2"].ToString();
                    oSheet.Cells[indexRow, 3] = dr["Nam"].ToString();
                    oSheet.Cells[indexRow, 4] = dr["DanhBo"].ToString();
                    oSheet.Cells[indexRow, 5] = dr["SoPhatHanh"].ToString();
                    oSheet.Cells[indexRow, 6] = "";
                    oSheet.Cells[indexRow, 7] = "";
                    if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("1K"))
                    {
                        oSheet.Cells[indexRow, 8] = _cHoaDon.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 7));
                        oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 7);
                        oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(7, 7);
                    }
                    else
                        if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("CT"))
                        {
                            oSheet.Cells[indexRow, 8] = _cHoaDon.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 6));
                            oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 6);
                            oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(6, 7);
                        }
                    oSheet.Cells[indexRow, 11] = "";
                    oSheet.Cells[indexRow, 12] = "";
                    oSheet.Cells[indexRow, 13] = "";
                    oSheet.Cells[indexRow, 14] = "";
                    oSheet.Cells[indexRow, 15] = dr["GiaBieuMoi"].ToString();
                    oSheet.Cells[indexRow, 16] = dr["DinhMucMoi"].ToString();
                    oSheet.Cells[indexRow, 17] = dr["TieuThuMoi"].ToString();
                    if (dchd.KhauTru == true)
                    {
                        oSheet.Cells[indexRow, 18] = "0";
                        oSheet.Cells[indexRow, 19] = "0";
                    }
                    else
                    {
                        oSheet.Cells[indexRow, 18] = dr["TieuThu_BD"].ToString();
                        oSheet.Cells[indexRow, 19] = "0";
                    }
                    oSheet.Cells[indexRow, 20] = dr["GiaBan_BD"].ToString();
                    oSheet.Cells[indexRow, 21] = "5";
                    oSheet.Cells[indexRow, 22] = "15";
                    oSheet.Cells[indexRow, 23] = dr["GiaBan_BD"].ToString();
                    oSheet.Cells[indexRow, 24] = dr["ThueGTGT_BD"].ToString();
                    oSheet.Cells[indexRow, 25] = dr["PhiBVMT_BD"].ToString();
                    oSheet.Cells[indexRow, 26] = dr["TongCong_BD"].ToString();
                    oSheet.Cells[indexRow, 27] = dr["PhiBVMT_Thue_BD"].ToString();
                }
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
                            DataTable dtExcel = _cHoaDon.ExcelToDataTable(dialog.FileName);
                            //CExcel fileExcel = new CExcel(dialog.FileName);
                            //DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                            //string KyHieu = (string)_cHoaDon.ExecuteQuery_ReturnOneValue("select SoHoaDon from TT_DeviceConfig");
                            int countXuLy = 0, countDaXuLy = 0;
                            string messageTCT = "\nHĐ có lỗi từ tct", messageTV = "\nP.TV chưa cập nhật";
                            foreach (DataRow item in dtExcel.Rows)
                            {
                                //cấu hình điều chỉnh bằng chương trình
                                DIEUCHINH_HD dchd = _cDCHD.get(item[1].ToString().Trim() + item[2].ToString().Trim());
                                if (dchd != null && dchd.UpdatedHDDT == false)
                                    if (dchd.TONGCONG_END != null)
                                        using (TransactionScope scope = new TransactionScope())
                                        {
                                            if (item[3].ToString().All(char.IsDigit) == true)
                                            {
                                                dchd.UpdatedHDDT = true;
                                                dchd.SoHoaDonMoi = item[1].ToString().Trim() + item[3].ToString().Trim();
                                                if (_cDCHD.Sua(dchd) == true)
                                                {
                                                    HOADON hd = _cHoaDon.Get(dchd.FK_HOADON);
                                                    if (hd.SOHOADON != dchd.SoHoaDonMoi)
                                                    {
                                                        hd.SoHoaDonCu = hd.SOHOADON;
                                                        hd.SOHOADON = dchd.SoHoaDonMoi;
                                                    }
                                                    hd.BaoCaoThue = dchd.BaoCaoThue;
                                                    if (_cHoaDon.Sua(hd) == true)
                                                    {
                                                        ///lưu lịch sử
                                                        _cDCHD.LuuLichSuDC(dchd);
                                                        scope.Complete();
                                                        scope.Dispose();
                                                        countXuLy++;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                HOADON hd = _cHoaDon.Get(dchd.FK_HOADON);
                                                messageTCT += "\n" + item[3].ToString() + " - " + hd.DANHBA + " - " + hd.KY + "/" + hd.NAM;
                                            }
                                        }
                                    else
                                    {
                                        HOADON hd = _cHoaDon.Get(dchd.FK_HOADON);
                                        messageTV += "\n" + item[3].ToString() + " - " + hd.DANHBA + " - " + hd.KY + "/" + hd.NAM;
                                    }
                                else
                                {
                                    countDaXuLy++;
                                }
                                //cấu hình điều chỉnh bằng tay
                                //if (string.IsNullOrEmpty(item[20].ToString().Trim()) == false && item[20].ToString().Trim() != "")
                                //{
                                //    if (item[20].ToString().Trim().Length != 7 && item[20].ToString().Trim().Length != 13)
                                //    {
                                //        MessageBox.Show("Sai Số Hóa Đơn Điều Chỉnh, liên hệ P.TV để báo TCT cập nhật lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //        return;
                                //    }
                                //    DIEUCHINH_HD dchd = _cDCHD.get(item[5].ToString().Trim());
                                //    if (dchd != null && dchd.UpdatedHDDT == false)
                                //        if (dchd.TONGCONG_END != null)
                                //            using (TransactionScope scope = new TransactionScope())
                                //            {
                                //                dchd.UpdatedHDDT = true;
                                //                if (item[20].ToString().Trim().Contains("CT/") == true)
                                //                    dchd.SoHoaDonMoi = item[20].ToString().Trim();
                                //                else
                                //                    dchd.SoHoaDonMoi = KyHieu + item[20].ToString().Trim();
                                //                if (item[21].ToString().Trim() != "")
                                //                    dchd.BaoCaoThue = bool.Parse(item[21].ToString().Trim());
                                //                if (_cDCHD.Sua(dchd) == true)
                                //                {
                                //                    HOADON hd = _cHoaDon.Get(dchd.FK_HOADON);
                                //                    if (hd.SOHOADON != dchd.SoHoaDonMoi)
                                //                    {
                                //                        hd.SoHoaDonCu = hd.SOHOADON;
                                //                        hd.SOHOADON = dchd.SoHoaDonMoi;
                                //                    }
                                //                    hd.BaoCaoThue = dchd.BaoCaoThue;
                                //                    if (_cHoaDon.Sua(hd) == true)
                                //                    {
                                //                        scope.Complete();
                                //                        scope.Dispose();
                                //                        count++;
                                //                    }
                                //                }
                                //            }
                                //        else
                                //            message += "\n" + item[3].ToString() + " - " + item[1].ToString() + "/" + item[2].ToString();
                                //}
                            }
                            MessageBox.Show("Đã xử lý xong " + countXuLy + " hđ\nĐã xử lý trước đó " + countDaXuLy + "\nLỗi Không Xử lý" + messageTCT + messageTV + "\nVui lòng kiểm tra lại dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadHoaDon();
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
                        DataTable dt = _cDCHD.getDS_HDDC_DangNgan_HD0();
                        foreach (DataRow item in dt.Rows)
                        {
                            _cHoaDon.DangNgan("ChuyenKhoan", item["SoHoaDon"].ToString(), _cNguoiDung.getChuyenKhoan().MaND);
                            _cDCHD.ExecuteNonQuery("delete from TT_HDDC_DangNgan where MaHD=" + item["MaHD"].ToString());
                        }
                        loadHoaDon();
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

        private void btnXem_HDDC_Cho_DangNgan_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDCHD.getDS_HDDC_Cho_DangNgan();
            dt.Merge(_cDCHD.getDS_HDDC_Cho_DangNgan_HD0());
            dgvDCHD.DataSource = dt;
        }

        private void btnDangNgan_HDDC_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen("mnuDangNganChuyenKhoan", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        CNguoiDung _cNguoiDung = new CNguoiDung();
                        CTienDu _cTienDu = new CTienDu();
                        DataTable dt = _cDCHD.getDS_HDDC_DangNgan();
                        foreach (DataRow item in dt.Rows)
                        {
                            var transactionOptions = new TransactionOptions();
                            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                            {
                                if (bool.Parse(item["ChuyenKhoan"].ToString()))
                                {
                                    if (_cHoaDon.DangNgan("ChuyenKhoan", item["SoHoaDon"].ToString(), _cNguoiDung.getChuyenKhoan().MaND))
                                        if (_cTienDu.UpdateThem(item["SoHoaDon"].ToString()))
                                        {
                                            _cDCHD.LinQ_ExecuteNonQuery("delete from TT_HDDC_DangNgan where MaHD=" + item["MaHD"].ToString());
                                            scope.Complete();
                                            scope.Dispose();
                                        }
                                }
                                else
                                {
                                    if (_cHoaDon.DangNgan("Quay", item["SoHoaDon"].ToString(), _cNguoiDung.getQuay().MaND))
                                    {
                                        _cDCHD.LinQ_ExecuteNonQuery("delete from TT_HDDC_DangNgan where MaHD=" + item["MaHD"].ToString());
                                        scope.Complete();
                                        scope.Dispose();
                                    }
                                }
                            }
                        }
                        loadHoaDon();
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

        private void btnInGiaoNhan_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDCHD.getDS_HDDC_DangNgan_GiaoNhan(dateTu.Value, dateDen.Value);
            dsBaoCao ds = new dsBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["DSDCHD"].NewRow();
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                dr["Ky"] = item["Ky"];
                dr["TongCong"] = item["TongCong"];
                dr["HanhThu"] = item["SoPhieu"].ToString().Insert(item["SoPhieu"].ToString().Length - 2, "-");
                dr["To"] = item["NgayGiaiTrach"];
                if (bool.Parse(item["DangNgan_ChuyenKhoan"].ToString()))
                    dr["SoHoaDon"] = "CK";
                else
                    if (bool.Parse(item["DangNgan_Quay"].ToString()))
                        dr["SoHoaDon"] = "Q";
                ds.Tables["DSDCHD"].Rows.Add(dr);
            }
            rptDSDCHD_GiaoNhan rpt = new rptDSDCHD_GiaoNhan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnExportExcelTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBinhThuong2021 = new DataTable();
                DataTable dtBinhThuong2022 = new DataTable();
                DataTable dt = new DataTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (bool.Parse(dt.Rows[i]["BaoCaoThue"].ToString()) == false)
                        if (dt.Rows[i]["SoHoaDon"].ToString().Contains("CT/22E") || dt.Rows[i]["SoHoaDon"].ToString().Contains("1K22TCT"))
                            dtBinhThuong2022.Rows.Add(dt.Rows[i]);
                        else
                            if (dt.Rows[i]["SoHoaDon"].ToString().Contains("CT/20E") || dt.Rows[i]["SoHoaDon"].ToString().Contains("CT/21E"))
                                dtBinhThuong2021.Rows.Add(dt.Rows[i]);
                }
                if (dtBinhThuong2021.Rows.Count > 0)
                {
                    int scale = 1000;
                    int num1 = dtBinhThuong2021.Rows.Count / scale;
                    int num2 = dtBinhThuong2021.Rows.Count % scale;
                    if (num2 > 0)
                        num2 = 1;
                    else
                        num2 = 0;
                    DataTable[] dts = new DataTable[num1 + num2];
                    for (int i = 0; i < dtBinhThuong2021.Rows.Count; i++)
                    {
                        if (dts[i / scale] == null)
                            dts[i / scale] = dtBinhThuong2021.Clone();

                        dts[i / scale].ImportRow(dtBinhThuong2021.Rows[i]);
                    }
                    foreach (DataTable item in dts)
                    {
                        ExcelBinhThuong2021(item);
                    }
                }
                if (dtBinhThuong2022.Rows.Count > 0)
                {
                    int scale = 1000;
                    int num1 = dtBinhThuong2022.Rows.Count / scale;
                    int num2 = dtBinhThuong2022.Rows.Count % scale;
                    if (num2 > 0)
                        num2 = 1;
                    else
                        num2 = 0;
                    DataTable[] dts = new DataTable[num1 + num2];
                    for (int i = 0; i < dtBinhThuong2022.Rows.Count; i++)
                    {
                        if (dts[i / scale] == null)
                            dts[i / scale] = dtBinhThuong2022.Clone();

                        dts[i / scale].ImportRow(dtBinhThuong2022.Rows[i]);
                    }
                    foreach (DataTable item in dts)
                    {
                        ExcelBinhThuong2022(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExcelBinhThuong2021(DataTable dt)
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

            oSheet.Name = "TH_BinhThuong(" + dt.Rows.Count + ")";
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
            cl6.Value2 = "Chỉ Số Mới";
            cl6.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
            cl7.Value2 = "Chỉ Số Cũ";
            cl7.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
            cl8.Value2 = "Mẫu Số Cũ";
            cl8.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
            cl9.Value2 = "Ký Hiệu Cũ";
            cl9.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
            cl10.Value2 = "Số Hóa Đơn Cũ";
            cl10.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
            cl11.Value2 = "Họ Tên Người Mua Hàng";
            cl11.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L1", "L1");
            cl12.Value2 = "Tên Đơn Vị";
            cl12.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M1", "M1");
            cl13.Value2 = "Địa Chỉ Đơn Vị Mua";
            cl13.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N1", "N1");
            cl14.Value2 = "Mã Số Thuế";
            cl14.ColumnWidth = 11;

            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O1", "O1");
            cl15.Value2 = "Giá Biểu Mới";
            cl15.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("P1", "P1");
            cl16.Value2 = "Định Mức Mới";
            cl16.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl17 = oSheet.get_Range("Q1", "Q1");
            cl17.Value2 = "Tiêu Thụ Mới";
            cl17.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl18 = oSheet.get_Range("R1", "R1");
            cl18.Value2 = "Số Lượng";
            cl18.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl19 = oSheet.get_Range("S1", "S1");
            cl19.Value2 = "Đơn Giá";
            cl19.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl20 = oSheet.get_Range("T1", "T1");
            cl20.Value2 = "Thành Tiền";
            cl20.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl21 = oSheet.get_Range("U1", "U1");
            cl21.Value2 = "Thuế GTGT";
            cl21.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl22 = oSheet.get_Range("V1", "V1");
            cl22.Value2 = "Phí BVMT";
            cl22.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl23 = oSheet.get_Range("W1", "W1");
            cl23.Value2 = "Cộng Tiền Dịch Vụ Chưa Thuế";
            cl23.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl24 = oSheet.get_Range("X1", "X1");
            cl24.Value2 = "Thuế GTGT Mới";
            cl24.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl25 = oSheet.get_Range("Y1", "Y1");
            cl25.Value2 = "Phí BVMT Mới";
            cl25.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl26 = oSheet.get_Range("Z1", "Z1");
            cl26.Value2 = "Tổng Cộng Mới";
            cl26.ColumnWidth = 15;

            int indexRow = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (int.Parse(dr["TongCong_End"].ToString()) == 0)
                {
                    indexRow++;
                    oSheet.Cells[indexRow, 1] = dr["Dot"].ToString();
                    oSheet.Cells[indexRow, 2] = dr["Ky"].ToString();
                    oSheet.Cells[indexRow, 3] = dr["Nam"].ToString();
                    oSheet.Cells[indexRow, 4] = dr["DanhBo"].ToString();
                    oSheet.Cells[indexRow, 5] = dr["SoPhatHanh"].ToString();
                    oSheet.Cells[indexRow, 6] = "";
                    oSheet.Cells[indexRow, 7] = "";
                    if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("1K"))
                    {
                        oSheet.Cells[indexRow, 8] = _cHoaDon.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 7));
                        oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 7);
                        oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(7, 7);
                    }
                    else
                        if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("CT"))
                        {
                            oSheet.Cells[indexRow, 8] = _cHoaDon.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 6));
                            oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 6);
                            oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(6, 7);
                        }
                    oSheet.Cells[indexRow, 11] = dr["HoTen_BD"].ToString();
                    oSheet.Cells[indexRow, 12] = dr["HoTen_BD"].ToString();
                    oSheet.Cells[indexRow, 13] = dr["DiaChi_BD"].ToString();
                    oSheet.Cells[indexRow, 14] = dr["MST_BD"].ToString();
                    oSheet.Cells[indexRow, 15] = dr["GiaBieu_BD"].ToString();
                    oSheet.Cells[indexRow, 16] = dr["DinhMuc_BD"].ToString();
                    oSheet.Cells[indexRow, 17] = dr["TieuThu_BD"].ToString();
                    if (bool.Parse(dr["KhauTru"].ToString()) == true)
                        oSheet.Cells[indexRow, 20] = dr["TienNuoc_End"].ToString();
                    oSheet.Cells[indexRow, 21] = "5";
                    oSheet.Cells[indexRow, 22] = "10";
                    oSheet.Cells[indexRow, 23] = dr["TienNuoc_End"].ToString();
                    oSheet.Cells[indexRow, 24] = dr["ThueGTGT_End"].ToString();
                    oSheet.Cells[indexRow, 25] = dr["PhiBVMT_End"].ToString();
                    oSheet.Cells[indexRow, 26] = dr["TongCong_End"].ToString();
                }
                else
                    if (bool.Parse(dr["KhauTru"].ToString()) == true)
                    {
                        indexRow++;
                        oSheet.Cells[indexRow, 1] = dr["Dot"].ToString();
                        oSheet.Cells[indexRow, 2] = dr["Ky"].ToString();
                        oSheet.Cells[indexRow, 3] = dr["Nam"].ToString();
                        oSheet.Cells[indexRow, 4] = dr["DanhBo"].ToString();
                        oSheet.Cells[indexRow, 5] = dr["SoPhatHanh"].ToString();
                        oSheet.Cells[indexRow, 6] = "";
                        oSheet.Cells[indexRow, 7] = "";
                        if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("1K"))
                        {
                            oSheet.Cells[indexRow, 8] = _cHoaDon.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 7));
                            oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 7);
                            oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(7, 7);
                        }
                        else
                            if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("CT"))
                            {
                                oSheet.Cells[indexRow, 8] = _cHoaDon.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 6));
                                oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 6);
                                oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(6, 7);
                            }
                        oSheet.Cells[indexRow, 11] = dr["HoTen_BD"].ToString();
                        oSheet.Cells[indexRow, 12] = dr["HoTen_BD"].ToString();
                        oSheet.Cells[indexRow, 13] = dr["DiaChi_BD"].ToString();
                        oSheet.Cells[indexRow, 14] = dr["MST_BD"].ToString();
                        oSheet.Cells[indexRow, 15] = dr["GiaBieu_BD"].ToString();
                        oSheet.Cells[indexRow, 16] = dr["DinhMuc_BD"].ToString();
                        oSheet.Cells[indexRow, 17] = dr["TieuThu_BD"].ToString();
                        oSheet.Cells[indexRow, 20] = dr["TienNuoc_End"].ToString();//khấu trừ
                        oSheet.Cells[indexRow, 21] = "5";
                        oSheet.Cells[indexRow, 22] = "10";
                        oSheet.Cells[indexRow, 23] = dr["TienNuoc_End"].ToString();
                        oSheet.Cells[indexRow, 24] = dr["ThueGTGT_End"].ToString();
                        oSheet.Cells[indexRow, 25] = dr["PhiBVMT_End"].ToString();
                        oSheet.Cells[indexRow, 26] = dr["TongCong_End"].ToString();
                    }
                    else
                    {
                        string[] ChiTietMois = dr["ChiTietMoi"].ToString().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                        foreach (string item in ChiTietMois)
                            if (item.Trim() != "")
                            {
                                indexRow++;
                                oSheet.Cells[indexRow, 1] = dr["Dot"].ToString();
                                oSheet.Cells[indexRow, 2] = dr["Ky"].ToString();
                                oSheet.Cells[indexRow, 3] = dr["Nam"].ToString();
                                oSheet.Cells[indexRow, 4] = dr["DanhBo"].ToString();
                                oSheet.Cells[indexRow, 5] = dr["SoPhatHanh"].ToString();
                                oSheet.Cells[indexRow, 6] = "";
                                oSheet.Cells[indexRow, 7] = "";
                                if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("1K"))
                                {
                                    oSheet.Cells[indexRow, 8] = _cHoaDon.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 7));
                                    oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 7);
                                    oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(7, 7);
                                }
                                else
                                    if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("CT"))
                                    {
                                        oSheet.Cells[indexRow, 8] = _cHoaDon.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 6));
                                        oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 6);
                                        oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(6, 7);
                                    }
                                oSheet.Cells[indexRow, 11] = dr["HoTen_BD"].ToString();
                                oSheet.Cells[indexRow, 12] = dr["HoTen_BD"].ToString();
                                oSheet.Cells[indexRow, 13] = dr["DiaChi_BD"].ToString();
                                oSheet.Cells[indexRow, 14] = dr["MST_BD"].ToString();
                                oSheet.Cells[indexRow, 15] = dr["GiaBieu_BD"].ToString();
                                oSheet.Cells[indexRow, 16] = dr["DinhMuc_BD"].ToString();
                                oSheet.Cells[indexRow, 17] = dr["TieuThu_BD"].ToString();
                                string[] DonGia = item.Split('x');
                                oSheet.Cells[indexRow, 18] = DonGia[0].Trim().Replace(".", "");
                                oSheet.Cells[indexRow, 19] = DonGia[1].Trim().Replace(".", "");
                                oSheet.Cells[indexRow, 20] = int.Parse(DonGia[0].Trim().Replace(".", "")) * int.Parse(DonGia[1].Trim().Replace(".", ""));
                                oSheet.Cells[indexRow, 21] = "5";
                                oSheet.Cells[indexRow, 22] = "10";
                                oSheet.Cells[indexRow, 23] = dr["TienNuoc_End"].ToString();
                                oSheet.Cells[indexRow, 24] = dr["ThueGTGT_End"].ToString();
                                oSheet.Cells[indexRow, 25] = dr["PhiBVMT_End"].ToString();
                                oSheet.Cells[indexRow, 26] = dr["TongCong_End"].ToString();
                            }
                    }
            }
        }

        private void ExcelBinhThuong2022(DataTable dt)
        {
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            //khai báo số lượng sheet
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = "TH_BinhThuong(" + dt.Rows.Count + ")";
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
            cl6.Value2 = "Chỉ Số Mới";
            cl6.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
            cl7.Value2 = "Chỉ Số Cũ";
            cl7.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
            cl8.Value2 = "Mẫu Số Cũ";
            cl8.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
            cl9.Value2 = "Ký Hiệu Cũ";
            cl9.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
            cl10.Value2 = "Số Hóa Đơn Cũ";
            cl10.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
            cl11.Value2 = "Họ Tên Người Mua Hàng";
            cl11.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L1", "L1");
            cl12.Value2 = "Tên Đơn Vị";
            cl12.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M1", "M1");
            cl13.Value2 = "Địa Chỉ Đơn Vị Mua";
            cl13.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N1", "N1");
            cl14.Value2 = "Mã Số Thuế";
            cl14.ColumnWidth = 11;

            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O1", "O1");
            cl15.Value2 = "Giá Biểu Mới";
            cl15.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("P1", "P1");
            cl16.Value2 = "Định Mức Mới";
            cl16.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl17 = oSheet.get_Range("Q1", "Q1");
            cl17.Value2 = "Tiêu Thụ Mới";
            cl17.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl18 = oSheet.get_Range("R1", "R1");
            cl18.Value2 = "Số Lượng";
            cl18.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl19 = oSheet.get_Range("S1", "S1");
            cl19.Value2 = "Đơn Giá";
            cl19.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl20 = oSheet.get_Range("T1", "T1");
            cl20.Value2 = "Thành Tiền";
            cl20.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl21 = oSheet.get_Range("U1", "U1");
            cl21.Value2 = "Thuế GTGT";
            cl21.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl22 = oSheet.get_Range("V1", "V1");
            cl22.Value2 = "Phí BVMT";
            cl22.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl23 = oSheet.get_Range("W1", "W1");
            cl23.Value2 = "Cộng Tiền Dịch Vụ Chưa Thuế";
            cl23.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl24 = oSheet.get_Range("X1", "X1");
            cl24.Value2 = "Thuế GTGT Mới";
            cl24.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl25 = oSheet.get_Range("Y1", "Y1");
            cl25.Value2 = "Phí BVMT Mới";
            cl25.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl26 = oSheet.get_Range("Z1", "Z1");
            cl26.Value2 = "Tổng Cộng Mới";
            cl26.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl27 = oSheet.get_Range("AA1", "AA1");
            cl27.Value2 = "Thuế GTGT 10% ";
            cl27.ColumnWidth = 15;

            int indexRow = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (int.Parse(dr["TongCong_End"].ToString()) == 0)
                {
                    indexRow++;
                    oSheet.Cells[indexRow, 1] = dr["Dot"].ToString();
                    oSheet.Cells[indexRow, 2] = dr["Ky"].ToString();
                    oSheet.Cells[indexRow, 3] = dr["Nam"].ToString();
                    oSheet.Cells[indexRow, 4] = dr["DanhBo"].ToString();
                    oSheet.Cells[indexRow, 5] = dr["SoPhatHanh"].ToString();
                    oSheet.Cells[indexRow, 6] = "";
                    oSheet.Cells[indexRow, 7] = "";
                    if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("1K"))
                    {
                        oSheet.Cells[indexRow, 8] = _cThuTien.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 7));
                        oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 7);
                        oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(7, 7);
                    }
                    else
                        if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("CT"))
                        {
                            oSheet.Cells[indexRow, 8] = _cThuTien.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 6));
                            oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 6);
                            oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(6, 7);
                        }
                    oSheet.Cells[indexRow, 11] = dr["HoTen_BD"].ToString();
                    oSheet.Cells[indexRow, 12] = dr["HoTen_BD"].ToString();
                    oSheet.Cells[indexRow, 13] = dr["DiaChi_BD"].ToString();
                    oSheet.Cells[indexRow, 14] = dr["MST_BD"].ToString();
                    oSheet.Cells[indexRow, 15] = dr["GiaBieu_BD"].ToString();
                    oSheet.Cells[indexRow, 16] = dr["DinhMuc_BD"].ToString();
                    oSheet.Cells[indexRow, 17] = dr["TieuThu_BD"].ToString();
                    if (bool.Parse(dr["KhauTru"].ToString()) == true)
                        oSheet.Cells[indexRow, 20] = dr["TienNuoc_End"].ToString();
                    oSheet.Cells[indexRow, 21] = "5";
                    oSheet.Cells[indexRow, 22] = "10";
                    oSheet.Cells[indexRow, 23] = dr["TienNuoc_End"].ToString();
                    oSheet.Cells[indexRow, 24] = dr["ThueGTGT_End"].ToString();
                    oSheet.Cells[indexRow, 25] = dr["PhiBVMT_End"].ToString();
                    oSheet.Cells[indexRow, 26] = dr["TongCong_End"].ToString();
                    oSheet.Cells[indexRow, 27] = dr["PhiBVMT_Thue_End"].ToString();
                }
                else
                    if (bool.Parse(dr["KhauTru"].ToString()) == true)
                    {
                        indexRow++;
                        oSheet.Cells[indexRow, 1] = dr["Dot"].ToString();
                        oSheet.Cells[indexRow, 2] = dr["Ky"].ToString();
                        oSheet.Cells[indexRow, 3] = dr["Nam"].ToString();
                        oSheet.Cells[indexRow, 4] = dr["DanhBo"].ToString();
                        oSheet.Cells[indexRow, 5] = dr["SoPhatHanh"].ToString();
                        oSheet.Cells[indexRow, 6] = "";
                        oSheet.Cells[indexRow, 7] = "";
                        if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("1K"))
                        {
                            oSheet.Cells[indexRow, 8] = _cThuTien.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 7));
                            oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 7);
                            oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(7, 7);
                        }
                        else
                            if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("CT"))
                            {
                                oSheet.Cells[indexRow, 8] = _cThuTien.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 6));
                                oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 6);
                                oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(6, 7);
                            }
                        oSheet.Cells[indexRow, 11] = dr["HoTen_BD"].ToString();
                        oSheet.Cells[indexRow, 12] = dr["HoTen_BD"].ToString();
                        oSheet.Cells[indexRow, 13] = dr["DiaChi_BD"].ToString();
                        oSheet.Cells[indexRow, 14] = dr["MST_BD"].ToString();
                        oSheet.Cells[indexRow, 15] = dr["GiaBieu_BD"].ToString();
                        oSheet.Cells[indexRow, 16] = dr["DinhMuc_BD"].ToString();
                        oSheet.Cells[indexRow, 17] = dr["TieuThu_BD"].ToString();
                        oSheet.Cells[indexRow, 20] = dr["TienNuoc_End"].ToString();//khấu trừ
                        oSheet.Cells[indexRow, 21] = "5";
                        oSheet.Cells[indexRow, 22] = "10";
                        oSheet.Cells[indexRow, 23] = dr["TienNuoc_End"].ToString();
                        oSheet.Cells[indexRow, 24] = dr["ThueGTGT_End"].ToString();
                        oSheet.Cells[indexRow, 25] = dr["PhiBVMT_End"].ToString();
                        oSheet.Cells[indexRow, 26] = dr["TongCong_End"].ToString();
                        oSheet.Cells[indexRow, 27] = dr["PhiBVMT_Thue_End"].ToString();
                    }
                    else
                    {
                        string[] ChiTietMois = dr["ChiTietMoi"].ToString().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                        foreach (string item in ChiTietMois)
                            if (item.Trim() != "")
                            {
                                indexRow++;
                                oSheet.Cells[indexRow, 1] = dr["Dot"].ToString();
                                oSheet.Cells[indexRow, 2] = dr["Ky"].ToString();
                                oSheet.Cells[indexRow, 3] = dr["Nam"].ToString();
                                oSheet.Cells[indexRow, 4] = dr["DanhBo"].ToString();
                                oSheet.Cells[indexRow, 5] = dr["SoPhatHanh"].ToString();
                                oSheet.Cells[indexRow, 6] = "";
                                oSheet.Cells[indexRow, 7] = "";
                                if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("1K"))
                                {
                                    oSheet.Cells[indexRow, 8] = _cThuTien.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 7));
                                    oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 7);
                                    oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(7, 7);
                                }
                                else
                                    if (dr["SoHoaDon"].ToString().Substring(0, 2).Contains("CT"))
                                    {
                                        oSheet.Cells[indexRow, 8] = _cThuTien.getBieuMau(dr["SoHoaDon"].ToString().Substring(0, 6));
                                        oSheet.Cells[indexRow, 9] = dr["SoHoaDon"].ToString().Substring(0, 6);
                                        oSheet.Cells[indexRow, 10] = dr["SoHoaDon"].ToString().Substring(6, 7);
                                    }
                                oSheet.Cells[indexRow, 11] = dr["HoTen_BD"].ToString();
                                oSheet.Cells[indexRow, 12] = dr["HoTen_BD"].ToString();
                                oSheet.Cells[indexRow, 13] = dr["DiaChi_BD"].ToString();
                                oSheet.Cells[indexRow, 14] = dr["MST_BD"].ToString();
                                oSheet.Cells[indexRow, 15] = dr["GiaBieu_BD"].ToString();
                                oSheet.Cells[indexRow, 16] = dr["DinhMuc_BD"].ToString();
                                oSheet.Cells[indexRow, 17] = dr["TieuThu_BD"].ToString();
                                string[] DonGia = item.Split('x');
                                oSheet.Cells[indexRow, 18] = DonGia[0].Trim().Replace(".", "");
                                oSheet.Cells[indexRow, 19] = DonGia[1].Trim().Replace(".", "");
                                oSheet.Cells[indexRow, 20] = int.Parse(DonGia[0].Trim().Replace(".", "")) * int.Parse(DonGia[1].Trim().Replace(".", ""));
                                oSheet.Cells[indexRow, 21] = "5";
                                oSheet.Cells[indexRow, 22] = "10";
                                oSheet.Cells[indexRow, 23] = dr["TienNuoc_End"].ToString();
                                oSheet.Cells[indexRow, 24] = dr["ThueGTGT_End"].ToString();
                                oSheet.Cells[indexRow, 25] = dr["PhiBVMT_End"].ToString();
                                oSheet.Cells[indexRow, 26] = dr["TongCong_End"].ToString();
                                oSheet.Cells[indexRow, 27] = dr["PhiBVMT_Thue_End"].ToString();
                            }
                    }
            }
        }

    }
}
