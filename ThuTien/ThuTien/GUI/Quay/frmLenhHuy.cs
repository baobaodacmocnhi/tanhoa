﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.Quay;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.BaoCao.Quay;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.TongHop;
using ThuTien.DAL;

namespace ThuTien.GUI.Quay
{
    public partial class frmLenhHuy : Form
    {
        string _mnu = "mnuLenhHuy";
        CHoaDon _cHoaDon = new CHoaDon();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CChuyenNoKhoDoi _cCNKD = new CChuyenNoKhoDoi();
        CTo _cTo = new CTo();
        CToTrinhCatHuy _cTTCH = new CToTrinhCatHuy();
        CThuongVu _cKinhDoanh = new CThuongVu();

        public frmLenhHuy()
        {
            InitializeComponent();
        }

        private void frmLenhHuy_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            dateLap.Value = DateTime.Now;

            List<TT_To> lstTo = _cTo.getDS_HanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lstTo.Insert(0, to);
            cmbTo.DataSource = lstTo;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            DataTable dtNam = _cHoaDon.GetNam();
            DataRow dr = dtNam.NewRow();
            dr["ID"] = "Tất Cả";
            dtNam.Rows.InsertAt(dr, 0);
            cmbNam.DataSource = dtNam;
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()))
                    {
                        if (lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                        {
                            lstHD.Items.Add(item.Trim().ToUpper());
                            lstHD.EnsureVisible(lstHD.Items.Count - 1);
                        }
                    }
                //else
                //    ///Trung An thêm 'K' phía cuối liên hóa đơn
                //    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 14)
                //    {
                //        if (lstHD.FindItemWithText(item.Trim().ToUpper().Replace("K", "")) == null)
                //        {
                //            lstHD.Items.Add(item.Trim().ToUpper().Replace("K", ""));
                //            lstHD.EnsureVisible(lstHD.Items.Count - 1);
                //        }
                //    }
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

        private void btnThem_Click(object sender, EventArgs e)
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
                    if (_cHoaDon.CheckDangNganBySoHoaDon(item.Text))
                    {
                        MessageBox.Show("Hóa Đơn đã Đăng Ngân: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                    if (_cLenhHuy.CheckExist(item.Text))
                    {
                        MessageBox.Show("Hóa Đơn đã có trong Lệnh Hủy: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                }
                try
                {
                    //_cLenhHuy.BeginTransaction();
                    foreach (ListViewItem item in lstHD.Items)
                    {
                        TT_LenhHuy lenhhuy = new TT_LenhHuy();
                        HOADON hd = _cHoaDon.Get(item.Text);
                        lenhhuy.MaHD = hd.ID_HOADON;
                        lenhhuy.SoHoaDon = item.Text;
                        lenhhuy.DanhBo = hd.DANHBA;
                        TT_LenhHuy lhMoiNhat = _cLenhHuy.getMoiNhat(hd.DANHBA);
                        if (lhMoiNhat != null)
                        {
                            lenhhuy.TinhTrang = lhMoiNhat.TinhTrang;
                            lenhhuy.Cat = lhMoiNhat.Cat;
                        }
                        if (!_cLenhHuy.Them(lenhhuy))
                        {
                            //_cLenhHuy.Rollback();
                            MessageBox.Show("Lỗi, Vui lòng thử lại \r\n" + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //_cLenhHuy.CommitTransaction();
                    lstHD.Items.Clear();
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    //_cLenhHuy.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        //_cLenhHuy.BeginTransaction();
                        foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                        {
                            TT_LenhHuy lenhhuy = _cLenhHuy.Get(int.Parse(item.Cells["MaHD"].Value.ToString()));
                            if (!_cLenhHuy.Xoa(lenhhuy))
                            {
                                //_cLenhHuy.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        //_cLenhHuy.CommitTransaction();
                        lstHD.Items.Clear();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //_cLenhHuy.Rollback();
                        MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (radTon.Checked)
            {
                ///chọn tất cả tổ
                if (cmbTo.SelectedIndex == 0)
                {
                    ///chọn tất cả năm
                    if (cmbNam.SelectedIndex == 0)
                        dgvHoaDon.DataSource = _cLenhHuy.GetDSTon();
                    else
                        ///chọn 1 năm cụ thể
                        if (cmbNam.SelectedIndex > 0)
                            dgvHoaDon.DataSource = _cLenhHuy.GetDSTon(int.Parse(cmbNam.SelectedValue.ToString()));
                }
                ///chọn 1 tổ cụ thể
                else
                {
                    ///chọn tất cả năm
                    if (cmbNam.SelectedIndex == 0)
                        dgvHoaDon.DataSource = _cLenhHuy.GetDSTon_To(int.Parse(cmbTo.SelectedValue.ToString()));
                    else
                        ///chọn 1 năm cụ thể
                        if (cmbNam.SelectedIndex > 0)
                            dgvHoaDon.DataSource = _cLenhHuy.GetDSTon_To(int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));

                }
            }
            else
                if (radDangNgan.Checked)
                {
                    ///chọn tất cả tổ
                    if (cmbTo.SelectedIndex == 0)
                    {
                        ///chọn tất cả năm
                        if (cmbNam.SelectedIndex == 0)
                            dgvHoaDon.DataSource = _cLenhHuy.GetDSDangNgan();
                        else
                            ///chọn 1 năm cụ thể
                            if (cmbNam.SelectedIndex > 0)
                                dgvHoaDon.DataSource = _cLenhHuy.GetDSDangNgan(int.Parse(cmbNam.SelectedValue.ToString()));
                    }
                    ///chọn 1 tổ cụ thể
                    else
                    {
                        ///chọn tất cả năm
                        if (cmbNam.SelectedIndex == 0)
                            dgvHoaDon.DataSource = _cLenhHuy.GetDSDangNgan_To(int.Parse(cmbTo.SelectedValue.ToString()));
                        else
                            ///chọn 1 năm cụ thể
                            if (cmbNam.SelectedIndex > 0)
                                dgvHoaDon.DataSource = _cLenhHuy.GetDSDangNgan_To(int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                    }
                }
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                TT_CTChuyenNoKhoDoi ctcnkd = _cCNKD.GetCT(item.Cells["SoHoaDon"].Value.ToString());
                //if (_cCNKD.CheckExistCT(item.Cells["SoHoaDon"].Value.ToString()))
                if (ctcnkd != null)
                {
                    //TT_CTChuyenNoKhoDoi ctcnkd = _cCNKD.GetCT(item.Cells["SoHoaDon"].Value.ToString());

                    //item.Cells["NgayGiaiTrach"].Value = ctcnkd.CreateDate.Value.ToString("dd/MM/yyyy");
                    item.Cells["DangNgan"].Value = "CNKĐ";
                }
                if (chkKiemTraToTrinh.Checked == true)
                {
                    item.Cells["MaTT"].Value = _cTTCH.getMaTT(item.Cells["SoHoaDon"].Value.ToString());
                    item.Cells["MaCatHuy"].Value = _cKinhDoanh.getLastMaCatHuy(item.Cells["DanhBo"].Value.ToString());
                }
            }
        }

        private void dgvHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
                if (string.IsNullOrEmpty(item.Cells["NgayGiaiTrach"].Value.ToString()))
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["DiaChi"] = item.Cells["DiaChi"].Value;
                    dr["Ky"] = item.Cells["Ky"].Value;
                    dr["MLT"] = item.Cells["MLT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = item.Cells["TongCong"].Value;
                    dr["TinhTrang"] = item.Cells["TinhTrang"].Value;
                    dr["Cat"] = item.Cells["Cat"].Value;
                    //dr["SoHoaDon"] = item.Cells["SoHoaDon"].Value;
                    dr["HanhThu"] = item.Cells["HanhThu"].Value.ToString();
                    dr["To"] = item.Cells["To"].Value.ToString();
                    if (int.Parse(item.Cells["GiaBieu"].Value.ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            rptDSLenhHuy rpt = new rptDSLenhHuy();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TinhTrang")
                {
                    TT_LenhHuy lenhhuy = _cLenhHuy.Get(int.Parse(dgvHoaDon["MaHD", e.RowIndex].Value.ToString()));
                    lenhhuy.TinhTrang = dgvHoaDon["TinhTrang", e.RowIndex].Value.ToString();
                    _cLenhHuy.Sua(lenhhuy);
                }
                if (dgvHoaDon.Columns[e.ColumnIndex].Name == "Cat")
                {
                    TT_LenhHuy lenhhuy = _cLenhHuy.Get(int.Parse(dgvHoaDon["MaHD", e.RowIndex].Value.ToString()));
                    lenhhuy.Cat = bool.Parse(dgvHoaDon["Cat", e.RowIndex].Value.ToString());
                    _cLenhHuy.Sua(lenhhuy);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInDSKhongTrung_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvHoaDon.DataSource;
            dsBaoCao ds = new dsBaoCao();
            ds.Tables["TamThuChuyenKhoan"].PrimaryKey = new DataColumn[] { ds.Tables["TamThuChuyenKhoan"].Columns["DanhBo"] };
            foreach (DataRow item in dt.Rows)
                if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()) && !ds.Tables["TamThuChuyenKhoan"].Rows.Contains(item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ")))
                {
                    DataRow[] drDGV = dt.Select("DanhBo=" + item["DanhBo"]);
                    string Ky = "";
                    int TongCong = 0;
                    foreach (DataRow itemRow in drDGV)
                    {
                        Ky += itemRow["Ky"].ToString().Trim() + ", ";
                        TongCong += int.Parse(itemRow["TongCong"].ToString());
                    }
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["DanhBo"] = drDGV[drDGV.Count() - 1]["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                    dr["DiaChi"] = drDGV[drDGV.Count() - 1]["DiaChi"];
                    dr["Ky"] = Ky;
                    dr["MLT"] = drDGV[drDGV.Count() - 1]["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = TongCong;
                    dr["TinhTrang"] = drDGV[drDGV.Count() - 1]["TinhTrang"];
                    dr["Cat"] = drDGV[drDGV.Count() - 1]["Cat"];
                    //dr["SoHoaDon"] = item.Cells["SoHoaDon"].Value;
                    dr["HanhThu"] = drDGV[drDGV.Count() - 1]["HanhThu"];
                    dr["To"] = drDGV[drDGV.Count() - 1]["To"];
                    if (int.Parse(drDGV[drDGV.Count() - 1]["GiaBieu"].ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            rptDSLenhHuy rpt = new rptDSLenhHuy();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
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

        private void dgvHoaDon_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
                if (_cCNKD.CheckExistCT(item.Cells["SoHoaDon"].Value.ToString()))
                {
                    TT_CTChuyenNoKhoDoi ctcnkd = _cCNKD.GetCT(item.Cells["SoHoaDon"].Value.ToString());

                    //item.Cells["NgayGiaiTrach"].Value = ctcnkd.CreateDate.Value.ToString("dd/MM/yyyy");
                    item.Cells["DangNgan"].Value = "CNKĐ";
                }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvHoaDon.DataSource;
            dsBaoCao ds = new dsBaoCao();
            ds.Tables["TamThuChuyenKhoan"].PrimaryKey = new DataColumn[] { ds.Tables["TamThuChuyenKhoan"].Columns["DanhBo"] };
            foreach (DataRow item in dt.Rows)
                if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()) && !ds.Tables["TamThuChuyenKhoan"].Rows.Contains(item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ")))
                {
                    DataRow[] drDGV = dt.Select("DanhBo=" + item["DanhBo"]);
                    string Ky = "";
                    int TongCong = 0;
                    foreach (DataRow itemRow in drDGV)
                    {
                        Ky += itemRow["Ky"].ToString().Trim() + ", ";
                        TongCong += int.Parse(itemRow["TongCong"].ToString());
                    }
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["DanhBo"] = drDGV[drDGV.Count() - 1]["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                    dr["DiaChi"] = drDGV[drDGV.Count() - 1]["DiaChi"];
                    dr["Ky"] = Ky;
                    dr["MLT"] = drDGV[drDGV.Count() - 1]["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = TongCong;
                    dr["TinhTrang"] = drDGV[drDGV.Count() - 1]["TinhTrang"];
                    dr["Cat"] = drDGV[drDGV.Count() - 1]["Cat"];
                    //dr["SoHoaDon"] = item.Cells["SoHoaDon"].Value;
                    dr["HanhThu"] = drDGV[drDGV.Count() - 1]["HanhThu"];
                    dr["To"] = drDGV[drDGV.Count() - 1]["To"];
                    if (int.Parse(drDGV[drDGV.Count() - 1]["GiaBieu"].ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }

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
            cl1.Value2 = "Danh Bộ";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Địa Chỉ";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "MLT";
            cl3.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Kỳ";
            cl4.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "Tổng Cộng";
            cl5.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
            cl6.Value2 = "Tình Trạng";
            cl6.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
            cl7.Value2 = "Tổ";
            cl7.ColumnWidth = 15;

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + ds.Tables["TamThuChuyenKhoan"].Rows.Count - 1;
            int columnEnd = 7;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[ds.Tables["TamThuChuyenKhoan"].Rows.Count, 7];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < ds.Tables["TamThuChuyenKhoan"].Rows.Count; i++)
            {
                DataRow dr = ds.Tables["TamThuChuyenKhoan"].Rows[i];

                arr[i, 0] = dr["DanhBo"].ToString();
                arr[i, 1] = dr["DiaChi"].ToString();
                arr[i, 2] = dr["MLT"].ToString();
                arr[i, 3] = dr["Ky"].ToString();
                arr[i, 4] = dr["TongCong"].ToString();
                arr[i, 5] = dr["TinhTrang"].ToString();
                arr[i, 6] = dr["To"].ToString();
            }

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
            c3d.NumberFormat = "@";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void radTon_CheckedChanged(object sender, EventArgs e)
        {
            if (radTon.Checked)
            {
                DataTable dtNam = _cHoaDon.GetNam();
                DataRow dr = dtNam.NewRow();
                dr["ID"] = "Tất Cả";
                dtNam.Rows.InsertAt(dr, 0);
                cmbNam.DataSource = dtNam;
                cmbNam.DisplayMember = "ID";
                cmbNam.ValueMember = "Nam";
            }
        }

        private void radDangNgan_CheckedChanged(object sender, EventArgs e)
        {
            if (radDangNgan.Checked)
            {
                DataTable dtNam = _cHoaDon.GetAllNam();
                DataRow dr = dtNam.NewRow();
                dr["ID"] = "Tất Cả";
                dtNam.Rows.InsertAt(dr, 0);
                cmbNam.DataSource = dtNam;
                cmbNam.DisplayMember = "ID";
                cmbNam.ValueMember = "Nam";
            }
        }
    }
}
