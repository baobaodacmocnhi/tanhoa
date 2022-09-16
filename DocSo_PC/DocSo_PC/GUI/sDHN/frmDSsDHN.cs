using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.sDHN;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.DAL.Doi;

namespace DocSo_PC.GUI.sDHN
{
    public partial class frmDSsDHN : Form
    {
        string _mnu = "mnuDSsDHN";
        CsDHN _csDHN = new CsDHN();

        public frmDSsDHN()
        {
            InitializeComponent();
        }

        private void frmDSsDHN_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            cmbNCC.DataSource = _csDHN.getDS_NCC();
            cmbNCC.DisplayMember = "Name";
            cmbNCC.ValueMember = "ID";
            cmbLoaiXem.SelectedIndex = 0;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _csDHN.getDS(int.Parse(cmbNCC.SelectedValue.ToString()));
        }

        private void btnCapNhatDS_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    switch (int.Parse(cmbNCC.SelectedValue.ToString()))
                    {
                        case 1:
                            if (_csDHN.updateDS_DHN_HoaSen() == true)
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 2:
                            if (_csDHN.updateDS_DHN_Rynan() == true)
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 3:
                            if (_csDHN.updateDS_DHN_Deviwas() == true)
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 4:
                            if (_csDHN.updateDS_DHN_PhamLam() == true)
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        default:
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

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
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

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (int.Parse(cmbNCC.SelectedValue.ToString()))
                {
                    case 1:
                        switch (cmbLoaiXem.SelectedItem.ToString())
                        {
                            case "Chỉ Số":
                                dgvLichSu.DataSource = _csDHN.get_ChiSoNuoc_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Chỉ Số giờ":
                                dgvLichSu.DataSource = _csDHN.get_ChiSoNuoc_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value, dateTu.Value.Hour);
                                break;
                            case "Chất Lượng Sóng":
                                dgvLichSu.DataSource = _csDHN.get_ChatLuongSong_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Cảnh Báo":
                                dgvLichSu.DataSource = _csDHN.get_CanhBao_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "% Pin":
                                dgvLichSu.DataSource = _csDHN.get_Pin_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Tất Cả 1 ngày":
                                dgvLichSu.DataSource = _csDHN.get_All_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Tất Cả 10 ngày":
                                dgvLichSu.DataSource = _csDHN.get_All_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value.AddDays(-10), dateTu.Value);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        switch (cmbLoaiXem.SelectedItem.ToString())
                        {
                            case "Chỉ Số":
                                dgvLichSu.DataSource = _csDHN.get_ChiSoNuoc_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Chỉ Số giờ":
                                dgvLichSu.DataSource = _csDHN.get_ChiSoNuoc_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value, dateTu.Value.Hour);
                                break;
                            case "Chất Lượng Sóng":
                                dgvLichSu.DataSource = _csDHN.get_ChatLuongSong_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Cảnh Báo":
                                dgvLichSu.DataSource = _csDHN.get_CanhBao_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "% Pin":
                                dgvLichSu.DataSource = _csDHN.get_Pin_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Tất Cả 1 ngày":
                                dgvLichSu.DataSource = _csDHN.get_All_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Tất Cả 1 ngày giờ":
                                dgvLichSu.DataSource = _csDHN.get_All_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value, dateTu.Value.Hour);
                                break;
                            case "Tất Cả 10 ngày":
                                dgvLichSu.DataSource = _csDHN.get_All_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value.AddDays(-10), dateTu.Value);
                                break;
                            case "Tất Cả 10 ngày giờ":
                                dgvLichSu.DataSource = _csDHN.get_All_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value.AddDays(-10), dateTu.Value, dateTu.Value.Hour);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        switch (cmbLoaiXem.SelectedItem.ToString())
                        {
                            case "Chỉ Số":
                                dgvLichSu.DataSource = _csDHN.get_ChiSoNuoc_Deviwas(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Chỉ Số giờ":
                                dgvLichSu.DataSource = _csDHN.get_ChiSoNuoc_Deviwas(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value, dateTu.Value.Hour);
                                break;
                            case "Chất Lượng Sóng":
                                dgvLichSu.DataSource = _csDHN.get_ChatLuongSong_Deviwas(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Cảnh Báo":
                                dgvLichSu.DataSource = _csDHN.get_CanhBao_Deviwas(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "% Pin":
                                dgvLichSu.DataSource = _csDHN.get_Pin_Deviwas(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Tất Cả 1 ngày":
                                dgvLichSu.DataSource = _csDHN.get_All_Deviwas(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Tất Cả 1 ngày giờ":
                                dgvLichSu.DataSource = _csDHN.get_All_Deviwas(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value, dateTu.Value.Hour);
                                break;
                            case "Tất Cả 10 ngày":
                                dgvLichSu.DataSource = _csDHN.get_All_Deviwas(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value.AddDays(-10), dateTu.Value);
                                break;
                            //case "Tất Cả 10 ngày giờ":
                            //    dgvLichSu.DataSource = _csDHN.get_All_Deviwas(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value.AddDays(-10), dateTu.Value, dateTu.Value.Hour);
                            //    break;
                            default:
                                break;
                        }
                        break;
                    case 4:
                        switch (cmbLoaiXem.SelectedItem.ToString())
                        {
                            case "Chỉ Số":
                                dgvLichSu.DataSource = _csDHN.get_ChiSoNuoc_PhamLam(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Chỉ Số giờ":
                                dgvLichSu.DataSource = _csDHN.get_ChiSoNuoc_PhamLam(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value, dateTu.Value.Hour);
                                break;
                            //case "Chất Lượng Sóng":
                            //    dgvLichSu.DataSource = _csDHN.get_ChatLuongSong_PhamLam(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                            //    break;
                            case "Cảnh Báo":
                                dgvLichSu.DataSource = _csDHN.get_CanhBao_PhamLam(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "% Pin":
                                dgvLichSu.DataSource = _csDHN.get_Pin_PhamLam(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Tất Cả 1 ngày":
                                dgvLichSu.DataSource = _csDHN.get_All_PhamLam(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value);
                                break;
                            case "Tất Cả 1 ngày giờ":
                                dgvLichSu.DataSource = _csDHN.get_All_PhamLam(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value, dateTu.Value.Hour);
                                break;
                            case "Tất Cả 10 ngày":
                                dgvLichSu.DataSource = _csDHN.get_All_PhamLam(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value.AddDays(-10), dateTu.Value);
                                break;
                            case "Tất Cả 10 ngày giờ":
                                dgvLichSu.DataSource = _csDHN.get_All_PhamLam(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dateTu.Value.AddDays(-10), dateTu.Value, dateTu.Value.Hour);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLichSu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
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

                oSheet.Name = "Tân Hòa";
                // Tạo tiêu đề cột 
                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
                cl1.Value2 = "TT";
                cl1.ColumnWidth = 5;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
                cl2.Value2 = "Danh bộ (danh bạ KH)";
                cl2.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
                cl3.Value2 = "Địa chỉ (Số, đường, phường, quận)";
                cl3.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
                cl4.Value2 = "Tên khách hàng";
                cl4.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
                cl5.Value2 = "Mã DMA";
                cl5.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
                cl6.Value2 = "Cỡ ĐH";
                cl6.ColumnWidth = 3;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
                cl7.Value2 = "Tên hiệu ĐHTM";
                cl7.ColumnWidth = 8;

                Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
                cl8.Value2 = "Kiểu loại ĐHTM";
                cl8.ColumnWidth = 8;

                Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
                cl9.Value2 = "Số thân đồng hồ (số Seri trên thân ĐH)";
                cl9.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
                cl10.Value2 = "Kiểu Module phát sóng";
                cl10.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
                cl11.Value2 = "Số seri bộ phát sóng (Seri Module)";
                cl11.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L1", "L1");
                cl12.Value2 = "Đơn vị thi công lắp đặt";
                cl12.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M1", "M1");
                cl13.Value2 = "Nhà cung cấp đồng hồ";
                cl13.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N1", "N1");
                cl14.Value2 = "Nhà tích hợp đồng hồ thông minh";
                cl14.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O1", "O1");
                cl15.Value2 = "Xuất xứ đồng hồ";
                cl15.ColumnWidth = 8;

                Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("P1", "P1");
                cl16.Value2 = "Hộp bảo vệ (Hộp đồng hồ)";
                cl16.ColumnWidth = 5;

                Microsoft.Office.Interop.Excel.Range cl17 = oSheet.get_Range("Q1", "Q1");
                cl17.Value2 = "Ngày kiểm định";
                cl17.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl18 = oSheet.get_Range("R1", "R1");
                cl18.Value2 = "Ngày lắp đặt";
                cl18.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl19 = oSheet.get_Range("S1", "S1");
                cl19.Value2 = "Chỉ số trung bình 03 kỳ trước của đồng hồ cũ truyền thống (m3)";
                cl19.ColumnWidth = 10;

                //Microsoft.Office.Interop.Excel.Range cl20 = oSheet.get_Range("T1", "T1");
                //cl20.Value2 = "Tỉ lệ chênh lệch đọc số kỳ 7";
                //cl20.ColumnWidth = 8;

                //Microsoft.Office.Interop.Excel.Range cl21 = oSheet.get_Range("U1", "U1");
                //cl21.Value2 = "Tỉ lệ chênh lệch đọc số kỳ 8";
                //cl21.ColumnWidth = 8;

                //Microsoft.Office.Interop.Excel.Range cl22 = oSheet.get_Range("V1", "V1");
                //cl22.Value2 = "Tỉ lệ chênh lệch đọc số kỳ 9";
                //cl22.ColumnWidth = 8;

                //Microsoft.Office.Interop.Excel.Range cl23 = oSheet.get_Range("W1", "W1");
                //cl23.Value2 = "Tỉ lệ chênh lệch đọc số kỳ 5";
                //cl23.ColumnWidth = 8;

                //Microsoft.Office.Interop.Excel.Range cl24 = oSheet.get_Range("X1", "X1");
                //cl24.Value2 = "Tỉ lệ chênh lệch đọc số kỳ 6";
                //cl24.ColumnWidth = 8;

                //Microsoft.Office.Interop.Excel.Range cl19 = oSheet.get_Range("S1", "S1");
                //cl19.Value2 = "25/7";
                //cl19.ColumnWidth = 10;

                //Microsoft.Office.Interop.Excel.Range cl20 = oSheet.get_Range("T1", "T1");
                //cl20.Value2 = "26/7";
                //cl20.ColumnWidth = 8;

                //Microsoft.Office.Interop.Excel.Range cl21 = oSheet.get_Range("U1", "U1");
                //cl21.Value2 = "27/7";
                //cl21.ColumnWidth = 8;

                //Microsoft.Office.Interop.Excel.Range cl22 = oSheet.get_Range("V1", "V1");
                //cl22.Value2 = "28/7";
                //cl22.ColumnWidth = 8;

                //Microsoft.Office.Interop.Excel.Range cl23 = oSheet.get_Range("W1", "W1");
                //cl23.Value2 = "29/7";
                //cl23.ColumnWidth = 8;

                //Microsoft.Office.Interop.Excel.Range cl24 = oSheet.get_Range("X1", "X1");
                //cl24.Value2 = "30/7";
                //cl24.ColumnWidth = 8;

                //Microsoft.Office.Interop.Excel.Range cl25 = oSheet.get_Range("Y1", "Y1");
                //cl25.Value2 = "31/7";
                //cl25.ColumnWidth = 8;

                //Microsoft.Office.Interop.Excel.Range cl26 = oSheet.get_Range("Z1", "Z1");
                //cl26.Value2 = "1/8";
                //cl26.ColumnWidth = 8;

                Microsoft.Office.Interop.Excel.Range clHeader = oSheet.get_Range("A1", "Z1");
                clHeader.WrapText = true;
                clHeader.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                clHeader.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //Microsoft.Office.Interop.Excel.Range cl25 = oSheet.get_Range("Y1", "Y1");
                //cl25.Value2 = "Phí BVMT Mới";
                //cl25.ColumnWidth = 15;

                //Microsoft.Office.Interop.Excel.Range cl26 = oSheet.get_Range("Z1", "Z1");
                //cl26.Value2 = "Tổng Cộng Mới";
                //cl26.ColumnWidth = 15;

                //Microsoft.Office.Interop.Excel.Range cl27 = oSheet.get_Range("AA1", "AA1");
                //cl27.Value2 = "Thuế GTGT 10% ";
                //cl27.ColumnWidth = 15;
                CDocSo _cDocSo = new CDocSo();
                DataTable dt = CsDHN._cDAL.ExecuteQuery_DataTable("select *,NGAYKIEMDINH1=CONVERT(varchar(10),NGAYKIEMDINH,103),NGAYTHAY1=CONVERT(varchar(10),NGAYTHAY,103) from sDHN sdhn,[DHTM_THONGTIN] ttdhn,server8.[CAPNUOCTANHOA].[dbo].[TB_DULIEUKHACHHANG] ttkh"
                + " where Valid=1 and sdhn.IDNCC=ttdhn.ID and sdhn.DanhBo=ttkh.DANHBO and MADMA='TH-08-12' and sdhn.DanhBo not in (select DanhBo from server8.[CAPNUOCTANHOA].[dbo].DHTM_NGHIEMTHU) order by IDNCC");
                int indexRow = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    indexRow++;
                    Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, 17];
                    Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[indexRow, 17];
                    Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
                    c3a.NumberFormat = "@";

                    Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, 18];
                    Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[indexRow, 18];
                    Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
                    c3b.NumberFormat = "@";
                    oSheet.Cells[indexRow, 1] = i + 1;
                    oSheet.Cells[indexRow, 2] = dr["DanhBo"].ToString();
                    oSheet.Cells[indexRow, 3] = dr["SoNha"].ToString() + " " + dr["TenDuong"].ToString();
                    oSheet.Cells[indexRow, 4] = dr["HoTen"].ToString();
                    oSheet.Cells[indexRow, 5] = dr["MaDMA"].ToString();
                    oSheet.Cells[indexRow, 6] = dr["CoDH"].ToString();
                    oSheet.Cells[indexRow, 7] = dr["HIEU_DHTM"].ToString();
                    oSheet.Cells[indexRow, 8] = dr["LOAI_DHTM"].ToString();
                    oSheet.Cells[indexRow, 9] = dr["SoThanDH"].ToString();
                    oSheet.Cells[indexRow, 10] = dr["KIEUPHATSONG"].ToString();
                    oSheet.Cells[indexRow, 11] = dr["IDLogger"].ToString();
                    oSheet.Cells[indexRow, 12] = dr["DVLAPDAT"].ToString();
                    oSheet.Cells[indexRow, 13] = dr["NHA_CCDHN"].ToString();
                    oSheet.Cells[indexRow, 14] = dr["NHA_TICHHOP"].ToString();
                    oSheet.Cells[indexRow, 15] = dr["XUATXU"].ToString();
                    if (bool.Parse(dr["ViTriDHN_Hop"].ToString()))
                        oSheet.Cells[indexRow, 16] = "x";
                    oSheet.Cells[indexRow, 17] = dr["NgayKiemDinh1"].ToString();
                    oSheet.Cells[indexRow, 18] = dr["NgayThay1"].ToString();

                    DataTable dtTCT = new DataTable();
                    switch (dr["IDNCC"].ToString())
                    {
                        case "1":
                            dtTCT = _csDHN.get_ChiSoNuoc_HoaSen_Survey(dr["DanhBo"].ToString(), new DateTime(2022, 09, 14));
                            break;
                        case "2":
                            dtTCT = _csDHN.get_ChiSoNuoc_Rynan(dr["DanhBo"].ToString(), new DateTime(2022, 09, 14));
                            break;
                        case "3":
                            dtTCT = _csDHN.get_ChiSoNuoc_Deviwas(dr["DanhBo"].ToString(), new DateTime(2022, 09, 14));
                            break;
                        case "4":
                            dtTCT = _csDHN.get_ChiSoNuoc_PhamLam(dr["DanhBo"].ToString(), new DateTime(2022, 09, 14));
                            break;
                        default:
                            break;
                    }
                    if (dtTCT != null && dtTCT.Rows.Count > 0)
                    {
                        oSheet.Cells[indexRow, 20] = dtTCT.Rows.Count.ToString();
                        //oSheet.Cells[indexRow, 21] = dtTCT.Rows[0]["ChiSo"].ToString();
                    }

                    // ======================
                    //DataTable dtC = CDocSo._cDAL.ExecuteQuery_DataTable("select ky,nam,CSMoi,GIOGHI,TBTT,CodeMoi from DocSo where Nam=2022 and ky in (9) and DanhBa='" + dr["DanhBo"].ToString() + "'");
                    //oSheet.Cells[indexRow, 19] = dtC.Rows[0]["TBTT"].ToString();
                    //foreach (DataRow item in dtC.Rows)
                    //    if (item["GIOGHI"].ToString() != "")
                    //    {
                    //        DateTime date = DateTime.Parse(item["GIOGHI"].ToString());
                    //        DataTable dtTCT = new DataTable();
                    //        switch (dr["IDNCC"].ToString())
                    //        {
                    //            case "1":
                    //                dtTCT = _csDHN.get_ChiSoNuoc_HoaSen(dr["DanhBo"].ToString(), date, date.Hour);
                    //                break;
                    //            case "2":
                    //                dtTCT = _csDHN.get_ChiSoNuoc_Rynan(dr["DanhBo"].ToString(), date, date.Hour);
                    //                break;
                    //            case "3":
                    //                dtTCT = _csDHN.get_ChiSoNuoc_Deviwas(dr["DanhBo"].ToString(), date, date.Hour);
                    //                break;
                    //            case "4":
                    //                dtTCT = _csDHN.get_ChiSoNuoc_PhamLam(dr["DanhBo"].ToString(), date, date.Hour);
                    //                break;
                    //            default:
                    //                break;
                    //        }
                    //        string TyLe = "";
                    //        //if (dtTCT != null && dtTCT.Rows.Count > 0 && dtTCT.Rows[0]["ChiSo"].ToString() != "")
                    //        {
                    //            //double a = double.Parse(dtTCT.Rows[0]["ChiSo"].ToString());
                    //            //int b = (int)a;
                    //            //if (b != 0)
                    //            //    TyLe = (((double)b - int.Parse(item["CSMoi"].ToString())) / int.Parse(item["CSMoi"].ToString()) * 100).ToString("0.00");
                    //            //else
                    //            //    TyLe = "0";
                    //            switch (item["ky"].ToString())
                    //            {
                    //                case "09":
                    //                    oSheet.Cells[indexRow, 20] = item["CodeMoi"].ToString();
                    //                    oSheet.Cells[indexRow, 21] = item["GIOGHI"].ToString();
                    //                    oSheet.Cells[indexRow, 22] = item["CSMoi"].ToString();
                    //                    if (dtTCT != null && dtTCT.Rows.Count > 0)
                    //                    {
                    //                        oSheet.Cells[indexRow, 23] = dtTCT.Rows[0]["ThoiGianCapNhat"].ToString();
                    //                        oSheet.Cells[indexRow, 24] = dtTCT.Rows[0]["ChiSo"].ToString();
                    //                    }
                    //                    //oSheet.Cells[indexRow, 25] = TyLe;
                    //                    break;
                    //                //case "08":
                    //                //    oSheet.Cells[indexRow, 26] = item["CodeMoi"].ToString();
                    //                //    oSheet.Cells[indexRow, 27] = item["GIOGHI"].ToString();
                    //                //    oSheet.Cells[indexRow, 28] = item["CSMoi"].ToString();
                    //                //    oSheet.Cells[indexRow, 29] = dtTCT.Rows[0]["ThoiGianCapNhat"].ToString();
                    //                //    oSheet.Cells[indexRow, 30] = dtTCT.Rows[0]["ChiSo"].ToString();
                    //                //    oSheet.Cells[indexRow, 31] = TyLe;
                    //                //    break;
                    //                //case "09":
                    //                //    oSheet.Cells[indexRow, 32] = item["CodeMoi"].ToString();
                    //                //    oSheet.Cells[indexRow, 33] = item["GIOGHI"].ToString();
                    //                //    oSheet.Cells[indexRow, 34] = item["CSMoi"].ToString();
                    //                //    oSheet.Cells[indexRow, 35] = dtTCT.Rows[0]["ThoiGianCapNhat"].ToString();
                    //                //    oSheet.Cells[indexRow, 36] = dtTCT.Rows[0]["ChiSo"].ToString();
                    //                //    oSheet.Cells[indexRow, 37] = TyLe;
                    //                //    break;
                    //                default:
                    //                    break;
                    //            }
                    //        }

                    //    }

                    //====================================
                    //DataTable dtTCT = _csDHN.get_ChiSoNuoc_HoaSen_Survey(dr["DanhBo"].ToString(), new DateTime(2022, 7, 25));
                    //if (dtTCT != null)
                    //    oSheet.Cells[indexRow, 19] = dtTCT.Rows.Count.ToString();
                    //dtTCT = _csDHN.get_ChiSoNuoc_HoaSen_Survey(dr["DanhBo"].ToString(), new DateTime(2022, 7, 26));
                    //if (dtTCT != null)
                    //    oSheet.Cells[indexRow, 20] = dtTCT.Rows.Count.ToString();
                    //dtTCT = _csDHN.get_ChiSoNuoc_HoaSen_Survey(dr["DanhBo"].ToString(), new DateTime(2022, 7, 27));
                    //if (dtTCT != null)
                    //    oSheet.Cells[indexRow, 21] = dtTCT.Rows.Count.ToString();
                    //dtTCT = _csDHN.get_ChiSoNuoc_HoaSen_Survey(dr["DanhBo"].ToString(), new DateTime(2022, 7, 28));
                    //if (dtTCT != null)
                    //    oSheet.Cells[indexRow, 22] = dtTCT.Rows.Count.ToString();
                    //dtTCT = _csDHN.get_ChiSoNuoc_HoaSen_Survey(dr["DanhBo"].ToString(), new DateTime(2022, 7, 29));
                    //if (dtTCT != null)
                    //    oSheet.Cells[indexRow, 23] = dtTCT.Rows.Count.ToString();
                    //dtTCT = _csDHN.get_ChiSoNuoc_HoaSen_Survey(dr["DanhBo"].ToString(), new DateTime(2022, 7, 30));
                    //if (dtTCT != null)
                    //    oSheet.Cells[indexRow, 24] = dtTCT.Rows.Count.ToString();
                    //dtTCT = _csDHN.get_ChiSoNuoc_HoaSen_Survey(dr["DanhBo"].ToString(), new DateTime(2022, 7, 31));
                    //if (dtTCT != null)
                    //    oSheet.Cells[indexRow, 25] = dtTCT.Rows.Count.ToString();
                    //dtTCT = _csDHN.get_ChiSoNuoc_HoaSen_Survey(dr["DanhBo"].ToString(), new DateTime(2022, 8, 1));
                    //if (dtTCT != null)
                    //    oSheet.Cells[indexRow, 26] = dtTCT.Rows.Count.ToString();
                }
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcelTinHieu_Click(object sender, EventArgs e)
        {
            try
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

                oSheet.Name = "Tân Hòa";
                DateTime FromDate = new DateTime(2022, 08, 20);
                DateTime ToDate = new DateTime(2022, 08, 22);
                TimeSpan t = ToDate - FromDate;
                int count = t.Days + 1;
                int k = 0;
                while (k < count)
                {
                    Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, k + 3];
                    Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, k + 3];
                    Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
                    c3a.NumberFormat = "@";
                    DateTime date = FromDate.AddDays(k);
                    c3a.Value2 = date.ToString("dd/MM/yyyy");
                    k++;
                }
                oSheet.Cells[1, 1] = "Danh Bộ";
                oSheet.Cells[1, 2] = "DMA";
                //Microsoft.Office.Interop.Excel.Range clHeader = oSheet.get_Range("A1", "Z1");
                //clHeader.WrapText = true;
                //clHeader.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //clHeader.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                CDocSo _cDocSo = new CDocSo();
                DataTable dt = CDocSo._cDAL.ExecuteQuery_DataTable("select *,NGAYKIEMDINH1=CONVERT(varchar(10),NGAYKIEMDINH,103),NGAYTHAY1=CONVERT(varchar(10),NGAYTHAY,103) from sDHN sdhn,[DHTM_TANHOA].[dbo].[DHTM_THONGTIN] ttdhn,[CAPNUOCTANHOA].[dbo].[TB_DULIEUKHACHHANG] ttkh"
                + " where Valid=1 and sdhn.IDNCC=ttdhn.ID and sdhn.DanhBo=ttkh.DANHBO and IDNCC=" + int.Parse(cmbNCC.SelectedValue.ToString()) + " order by IDNCC");
                int indexRow = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    indexRow++;
                    oSheet.Cells[indexRow, 1] = dr["DanhBo"].ToString();
                    oSheet.Cells[indexRow, 2] = dr["MaDMA"].ToString();
                    k = 0;
                    while (k < count)
                    {
                        DateTime date = FromDate.AddDays(k);
                        DataTable dtTCT = new DataTable();
                        switch (int.Parse(cmbNCC.SelectedValue.ToString()))
                        {
                            case 1:
                                dtTCT = _csDHN.get_ChiSoNuoc_HoaSen_Survey(dr["DanhBo"].ToString(), date);
                                break;
                            case 2:
                                dtTCT = _csDHN.get_ChiSoNuoc_Rynan(dr["DanhBo"].ToString(), date);
                                break;
                            case 3:
                                dtTCT = _csDHN.get_ChiSoNuoc_Deviwas(dr["DanhBo"].ToString(), date);
                                break;
                            case 4:
                                dtTCT = _csDHN.get_ChiSoNuoc_PhamLam(dr["DanhBo"].ToString(), date);
                                break;
                        }
                        if (dtTCT != null)
                        {
                            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[indexRow, k + 3];
                            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[indexRow, k + 3];
                            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
                            c3a.NumberFormat = "@";
                            c3a.Value2 = dtTCT.Rows.Count.ToString();
                        }
                        k++;
                    }
                }
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
