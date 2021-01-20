using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.Quay;
using System.Globalization;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.DAL.TongHop;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.GUI.BaoCao;
using System.Data.OleDb;
using ThuTien.GUI.TimKiem;
using ThuTien.DAL.DongNuoc;
using System.Transactions;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmTamThuChuyenKhoan : Form
    {
        string _mnu = "mnuTamThuChuyenKhoan";
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();
        CNganHang _cNganHang = new CNganHang();
        CDCHD _cDCHD = new CDCHD();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CToTrinhCatHuy _cTTCH = new CToTrinhCatHuy();
        CTienDu _cTienDu = new CTienDu();
        frmLoading frm;

        public frmTamThuChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmTamThuChuyenKhoan_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvTamThu.AutoGenerateColumns = false;

            cmbNganHang.DataSource = _cNganHang.GetDS();
            cmbNganHang.DisplayMember = "TenNH";
            cmbNganHang.ValueMember = "MaNH";

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            dateNgayLap.Value = DateTime.Now;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            dgvHoaDon.DataSource = null;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabThongTin")
            {
                if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")) && e.KeyChar == 13)
                {
                    DataTable dt = (DataTable)dgvHoaDon.DataSource;
                    foreach (string item in txtDanhBo.Lines)
                        if (item.Length == 11)
                        {
                            if (dt == null)
                                dt = _cHoaDon.GetDSTonByDanhBo(item);
                            else
                                dt.Merge(_cHoaDon.GetDSTonByDanhBo(item));
                        }
                    dgvHoaDon.DataSource = dt;
                    for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                    {
                        dgvHoaDon["Chon", i].Value = true;
                    }
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabTamThu")
                {
                    if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")) && e.KeyChar == 13)
                    {
                        DataTable dt = new DataTable();
                        foreach (string item in txtDanhBo.Lines)
                            if (item.Length == 11)
                            {
                                if (dt == null)
                                    dt = _cTamThu.GetDS(true, item);
                                else
                                    dt.Merge(_cTamThu.GetDS(true, item));
                            }
                        dgvTamThu.DataSource = dt;
                    }
                }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()))
                    {
                        string loai = "";
                        if (_cTamThu.CheckExist(item.Cells["SoHoaDon"].Value.ToString(), out loai))
                        {
                            MessageBox.Show("Hóa Đơn này đã Tạm Thu(" + loai + ")", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvHoaDon.CurrentCell = item.Cells["DanhBo"];
                            item.Selected = true;
                            return;
                        }
                        //if (_cDCHD.CheckExistByDangRutDC(item.Cells["SoHoaDon"].Value.ToString()))
                        //{
                        //    MessageBox.Show("Hóa Đơn này đã Rút đi Điều Chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    dgvHoaDon.CurrentCell = item.Cells["DanhBo"];
                        //    item.Selected = true;
                        //    return;
                        //}
                    }

                try
                {
                    //_cTamThu.BeginTransaction();
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                        if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()))
                            if (!_cTamThu.CheckExist(item.Cells["SoHoaDon"].Value.ToString(), true))
                            {
                                TAMTHU tamthu = new TAMTHU();
                                tamthu.DANHBA = item.Cells["DanhBo"].Value.ToString();
                                tamthu.FK_HOADON = int.Parse(item.Cells["MaHD"].Value.ToString());
                                tamthu.SoHoaDon = item.Cells["SoHoaDon"].Value.ToString();
                                tamthu.ChuyenKhoan = true;
                                if (item.Cells["NganHang"].Value != null)
                                    tamthu.MaNH = int.Parse(item.Cells["NganHang"].Value.ToString());
                                else
                                    tamthu.MaNH = int.Parse(cmbNganHang.SelectedValue.ToString());
                                if (chkNgayLap.Checked == true)
                                {
                                    if (!_cTamThu.Them(tamthu, dateNgayLap.Value))
                                    {
                                        //_cTamThu.Rollback();
                                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else
                                {
                                    if (!_cTamThu.Them(tamthu))
                                    {
                                        //_cTamThu.Rollback();
                                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                    //_cTamThu.CommitTransaction();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                catch (Exception)
                {
                    //_cTamThu.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            bool HDDT = false;
            if (radDienTu.Checked == true)
                HDDT = true;
            if (dateDen.Value >= dateTu.Value)
                dgvTamThu.DataSource = _cTamThu.getDS(HDDT, true, dateTu.Value, dateDen.Value);
            //string HoTen = "", TenTo = "";
            foreach (DataGridViewRow item in dgvTamThu.Rows)
            {
                if (bool.Parse(item.Cells["TienDu_TT"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Yellow;
                //if (_cDongNuoc.CheckExist_CTDongNuoc(item.Cells["SoHoaDon_TT"].Value.ToString(), out HoTen, out TenTo))
                //{
                //    item.Cells["HanhThu_TT"].Value = HoTen;
                //    item.Cells["To_TT"].Value = TenTo;
                //}
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabThongTin")
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
            }
            else
                if (tabControl.SelectedTab.Name == "tabTamThu")
                {
                    btnThem.Enabled = false;
                    btnXoa.Enabled = true;
                }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (CNguoiDung.Doi == false)
                    {
                        DateTime CreateDate = new DateTime();
                        DateTime.TryParse(dgvTamThu.SelectedRows[0].Cells["CreateDate_TT"].Value.ToString(), out CreateDate);
                        if (CreateDate.Date != DateTime.Now.Date)
                        {
                            MessageBox.Show("Chỉ được Điều Chỉnh trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    foreach (DataGridViewRow item in dgvTamThu.SelectedRows)
                    {
                        TAMTHU tamthu = _cTamThu.GetByMaTT(int.Parse(item.Cells["MaTT"].Value.ToString()));
                        if (!_cHoaDon.CheckDangNganBySoHoaDon(tamthu.SoHoaDon))
                        {
                            if (!_cTamThu.Xoa(tamthu))
                            {
                                //MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;
                            }
                        }
                        else
                        {
                            dgvTamThu.ClearSelection();
                            item.Selected = true;
                            MessageBox.Show("Hóa đơn đã Đăng Ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInDSTamThu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTamThu.Rows)
            //if (!bool.Parse(item.Cells["TienDu_TT"].Value.ToString()))
            {
                DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = "TẠM THU CHUYỂN KHOẢN";
                dr["GhiChu"] = "ĐÃ CHUYỂN KHOẢN";
                dr["DanhBo"] = item.Cells["DanhBo_TT"].Value.ToString().Insert(4, " ").Insert(8, " ");
                dr["MLT"] = item.Cells["MLT_TT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                dr["Ky"] = item.Cells["Ky_TT"].Value.ToString();
                dr["TongCong"] = item.Cells["TongCong_TT"].Value.ToString();
                dr["HanhThu"] = item.Cells["HanhThu_TT"].Value.ToString();
                dr["To"] = item.Cells["To_TT"].Value.ToString();
                if (int.Parse(item.Cells["GiaBieu_TT"].Value.ToString()) > 20)
                {
                    dr["Loai"] = "CQ";
                    //dr["HoTen"] = item.Cells["HoTen_TT"].Value.ToString();
                }
                else
                {
                    dr["Loai"] = "TG";
                    //dr["HoTen"] = item.Cells["DiaChi_TT"].Value.ToString();
                }
                dr["HoTen"] = item.Cells["DiaChi_TT"].Value.ToString();
                if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_TT"].Value.ToString()) == true)
                    dr["LenhHuy"] = true;
                else
                    if (_cTTCH.CheckExist_CT(item.Cells["SoHoaDon_TT"].Value.ToString()) == true)
                        dr["ToTrinhCatHuy"] = true;
                ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
            }
            rptDSTamThuChuyenKhoan_HanhThu rpt = new rptDSTamThuChuyenKhoan_HanhThu();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSTamThuChuaDN_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTamThu.Rows)
                if (string.IsNullOrEmpty(item.Cells["NgayGiaiTrach_TT"].Value.ToString()))
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "TẠM THU CHUYỂN KHOẢN TỒN";
                    dr["GhiChu"] = "ĐÃ CHUYỂN KHOẢN";
                    dr["DanhBo"] = item.Cells["DanhBo_TT"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = item.Cells["HoTen_TT"].Value.ToString();
                    dr["MLT"] = item.Cells["MLT_TT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    dr["Ky"] = item.Cells["Ky_TT"].Value.ToString();
                    dr["TongCong"] = item.Cells["TongCong_TT"].Value.ToString();
                    dr["HanhThu"] = item.Cells["HanhThu_TT"].Value.ToString();
                    dr["To"] = item.Cells["To_TT"].Value.ToString();
                    if (int.Parse(item.Cells["GiaBieu_TT"].Value.ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_TT"].Value.ToString()))
                        dr["LenhHuy"] = true;
                    else
                        if (_cTTCH.CheckExist_CT(item.Cells["SoHoaDon_TT"].Value.ToString()) == true)
                            dr["ToTrinhCatHuy"] = true;
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            rptDSTamThuChuyenKhoan_HanhThu rpt = new rptDSTamThuChuyenKhoan_HanhThu();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string DanhBo = "";
                try
                {
                    CExcel fileExcel = new CExcel(dialog.FileName);
                    DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                    ///kiểm tra danh bộ chặn tiền dư
                    string strTienDu = "";
                    string strDCHD = "";
                    foreach (DataRow item in dtExcel.Rows)
                        if (item[0].ToString().Replace(" ", "").Length == 11 && !string.IsNullOrEmpty(item[1].ToString()) && !string.IsNullOrEmpty(item[2].ToString()))
                            if (_cHoaDon.CheckKhoaTienDuByDanhBo(item[0].ToString().Replace(" ", "")))
                            {
                                strTienDu += item[0].ToString().Replace(" ", "") + "\n";
                            }
                            else
                                if (_cHoaDon.CheckDCHDTienDuByDanhBo(item[0].ToString().Replace(" ", "")))
                                {
                                    strDCHD += item[0].ToString().Replace(" ", "") + "\n";
                                }

                    if (!string.IsNullOrWhiteSpace(strTienDu))
                    {
                        MessageBox.Show("Chặn Tiền Dư:\n" + strTienDu, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!string.IsNullOrWhiteSpace(strDCHD))
                    {
                        MessageBox.Show("DCHD Tiền Dư:\n" + strDCHD, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataTable dt = new DataTable();
                    foreach (DataRow item in dtExcel.Rows)
                        if (item[0].ToString().Replace(" ", "").Length == 11 && !string.IsNullOrEmpty(item[1].ToString()) && !string.IsNullOrEmpty(item[2].ToString()))
                        {
                            if (chkTruHoNgheo.Checked == true)
                                dt.Merge(_cHoaDon.GetDSTonByDanhBo_TruHoNgheo(item[0].ToString().Replace(" ", "")));
                            else
                                dt.Merge(_cHoaDon.GetDSTonByDanhBo(item[0].ToString().Replace(" ", "")));
                        }
                    dgvHoaDon.DataSource = dt;

                    foreach (DataRow itemExcel in dtExcel.Rows)
                        if (itemExcel[0].ToString().Replace(" ", "").Length == 11 && !string.IsNullOrEmpty(itemExcel[1].ToString()) && !string.IsNullOrEmpty(itemExcel[2].ToString()))
                        {
                            DanhBo = itemExcel[0].ToString().Replace(" ", "");
                            string ChenhLech = "";
                            int SoTien = 0;
                            DataRow[] dr = dt.Select("DanhBo like '" + itemExcel[0].ToString().Replace(" ", "") + "'");
                            foreach (DataRow itemRow in dr)
                            {
                                SoTien += int.Parse(itemRow["TongCong"].ToString());
                            }
                            //SoTien += _cDongNuoc.GetPhiMoNuoc(itemExcel[0].ToString().Replace(" ", ""));
                            if (int.Parse(itemExcel[1].ToString()) > SoTien)
                            {
                                ChenhLech = "Dư: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int.Parse(itemExcel[1].ToString()) - SoTien));
                                foreach (DataGridViewRow itemRow in dgvHoaDon.Rows)
                                    if (itemRow.Cells["DanhBo"].Value.ToString() == itemExcel[0].ToString().Replace(" ", ""))
                                    {
                                        itemRow.Cells["ChenhLech"].Value = ChenhLech;
                                        itemRow.DefaultCellStyle.BackColor = Color.GreenYellow;
                                        itemRow.Cells["NganHang"].Value = _cNganHang.GetMaNHByKyHieu(itemExcel[2].ToString());
                                    }
                            }
                            else
                                if (int.Parse(itemExcel[1].ToString()) < SoTien)
                                {
                                    ChenhLech = "Thiếu: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int.Parse(itemExcel[1].ToString()) - SoTien));
                                    foreach (DataGridViewRow itemRow in dgvHoaDon.Rows)
                                        if (itemRow.Cells["DanhBo"].Value.ToString() == itemExcel[0].ToString().Replace(" ", ""))
                                        {
                                            itemRow.Cells["ChenhLech"].Value = ChenhLech;
                                            itemRow.DefaultCellStyle.BackColor = Color.Orange;
                                            itemRow.Cells["NganHang"].Value = _cNganHang.GetMaNHByKyHieu(itemExcel[2].ToString());
                                        }
                                }
                                else
                                {
                                    foreach (DataGridViewRow itemRow in dgvHoaDon.Rows)
                                        if (itemRow.Cells["DanhBo"].Value.ToString() == itemExcel[0].ToString().Replace(" ", ""))
                                        {
                                            itemRow.Cells["NganHang"].Value = _cNganHang.GetMaNHByKyHieu(itemExcel[2].ToString());
                                            if (_cDongNuoc.CheckPhiMoNuoc(itemRow.Cells["DanhBo"].Value.ToString()) == true)
                                                itemRow.DefaultCellStyle.BackColor = Color.Yellow;
                                        }
                                }
                        }
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    {
                        item.Cells["Chon"].Value = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, " + DanhBo + "\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvTamThu.RowCount > 0)
            {
                //DataTable dtTG = new DataTable();
                //DataTable dtCQ = new DataTable();
                DataTable dt = (DataTable)dgvTamThu.DataSource;
                //foreach (DataColumn item in dt.Columns)
                //{
                //    dtTG.Columns.Add(new DataColumn(item.ColumnName, item.DataType));
                //    dtCQ.Columns.Add(new DataColumn(item.ColumnName, item.DataType));
                //}
                //foreach (DataRow item in dt.Rows)
                //    if (int.Parse(item["GiaBieu"].ToString()) >= 11 && int.Parse(item["GiaBieu_TT"].ToString()) <= 20)
                //        dtTG.ImportRow(item);
                //    else
                //        if(int.Parse(item["GiaBieu"].ToString()) > 20)
                //            dtCQ.ImportRow(item);

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
                //oSheetCQ = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);

                XuatExcel(dt, oSheet, "Danh Sách Tạm Thu");
                //XuatExcel(dtCQ, oSheetCQ, "Cơ Quan");
            }
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
            oSheet.Name = SheetName;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "Số Hóa Đơn";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Kỳ";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Danh Bộ";
            cl3.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Khách Hàng";
            cl4.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "MLT";
            cl5.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
            cl6.Value2 = "Giá Bán";
            cl6.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
            cl7.Value2 = "Thuế GTGT";
            cl7.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
            cl8.Value2 = "Phí BVMT";
            cl8.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
            cl9.Value2 = "Tổng Cộng";
            cl9.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
            cl10.Value2 = "Hành Thu";
            cl10.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
            cl11.Value2 = "Tổ";
            cl11.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L1", "L1");
            cl12.Value2 = "Loại";
            cl12.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M1", "M1");
            cl13.Value2 = "Tiền Dư";
            cl13.ColumnWidth = 5;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 13];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["SoHoaDon"].ToString();
                arr[i, 1] = dr["Ky"].ToString();
                arr[i, 2] = dr["DanhBo"].ToString();
                arr[i, 3] = dr["HoTen"].ToString();
                arr[i, 4] = dr["MLT"].ToString();
                arr[i, 5] = dr["GiaBan"].ToString();
                arr[i, 6] = dr["ThueGTGT"].ToString();
                arr[i, 7] = dr["PhiBVMT"].ToString();
                arr[i, 8] = dr["TongCong"].ToString();
                arr[i, 9] = dr["HanhThu"].ToString();
                arr[i, 10] = dr["To"].ToString();
                if (int.Parse(dr["GiaBieu"].ToString()) > 20)
                    arr[i, 11] = "CQ";
                else
                    arr[i, 11] = "TG";
                if (bool.Parse(dr["TienDu"].ToString()))
                    arr[i, 12] = "X";

            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 13;

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

            Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            c3e.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            c3e.NumberFormat = "@";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private int _searchIndex = -1;
        private string _searchNoiDung = "";

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            if (tabControl.SelectedTab.Name == "tabThongTin")
            {
                if (_searchNoiDung != NoiDung)
                    _searchIndex = -1;

                for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                {
                    if (_searchNoiDung != NoiDung)
                        _searchNoiDung = NoiDung;

                    _searchIndex = (_searchIndex + 1) % dgvHoaDon.Rows.Count;
                    DataGridViewRow row = dgvHoaDon.Rows[_searchIndex];
                    if (row.Cells["DanhBo"].Value == null)
                    {
                        continue;
                    }
                    if (row.Cells["DanhBo"].Value.ToString() == NoiDung)
                    {
                        dgvHoaDon.CurrentCell = row.Cells["DanhBo"];
                        dgvHoaDon.Rows[_searchIndex].Selected = true;
                        return;
                    }
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabTamThu")
                {
                    if (_searchNoiDung != NoiDung)
                        _searchIndex = -1;

                    for (int i = 0; i < dgvTamThu.Rows.Count; i++)
                    {
                        if (_searchNoiDung != NoiDung)
                            _searchNoiDung = NoiDung;

                        _searchIndex = (_searchIndex + 1) % dgvTamThu.Rows.Count;
                        DataGridViewRow row = dgvTamThu.Rows[_searchIndex];
                        if (row.Cells["DanhBo_TT"].Value == null)
                        {
                            continue;
                        }
                        if (row.Cells["DanhBo_TT"].Value.ToString() == NoiDung)
                        {
                            dgvTamThu.CurrentCell = row.Cells["DanhBo_TT"];
                            dgvTamThu.Rows[_searchIndex].Selected = true;
                            return;
                        }
                    }
                }
        }

        private void frmTamThuChuyenKhoan_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvTamThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "MLT_TT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "DanhBo_TT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "TieuThu_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "GiaBan_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "ThueGTGT_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "PhiBVMT_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "TongCong_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            //if (dgvTamThu.Columns[e.ColumnIndex].Name == "MaNH_TT" && !string.IsNullOrEmpty(e.Value.ToString()))
            //{
            //    e.Value = _cNganHang.GetByMaNH(int.Parse(e.Value.ToString())).NGANHANG1;
            //}
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTamThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTamThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnInDSTamThuTienDu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTamThu.Rows)
                if (bool.Parse(item.Cells["TienDu_TT"].Value.ToString()))
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "TẠM THU CHUYỂN KHOẢN";
                    dr["GhiChu"] = "ĐÃ CHUYỂN KHOẢN";
                    dr["DanhBo"] = item.Cells["DanhBo_TT"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = item.Cells["HoTen_TT"].Value.ToString();
                    dr["MLT"] = item.Cells["MLT_TT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    dr["Ky"] = item.Cells["Ky_TT"].Value.ToString();
                    dr["TongCong"] = item.Cells["TongCong_TT"].Value.ToString();
                    dr["HanhThu"] = item.Cells["HanhThu_TT"].Value.ToString();
                    dr["To"] = item.Cells["To_TT"].Value.ToString();
                    //if (int.Parse(item.Cells["GiaBieu_TT"].Value.ToString()) > 20)
                    //    dr["Loai"] = "CQ";
                    //else
                    //    dr["Loai"] = "TG";
                    if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_TT"].Value.ToString()))
                        dr["LenhHuy"] = true;

                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            rptDSTamThuChuyenKhoan rpt = new rptDSTamThuChuyenKhoan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void chkNgayLap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayLap.Checked == true)
                dateNgayLap.Enabled = true;
            else
                dateNgayLap.Enabled = false;
        }

        private void btnGuiTBDienThoai_Click(object sender, EventArgs e)
        {
            try
            {
                _cTamThu.ExecuteNonQuery("exec spSendNotificationToClient 'TamThu','true'," + dgvTamThu["MaHD_TT", 1].Value.ToString());
                //foreach (DataGridViewRow item in dgvTamThu.Rows)
                //{
                //    _cTamThu.ExecuteNonQuery("exec spSendNotificationToClient 'TamThu','true'," + item.Cells["MaHD_TT"].Value.ToString());
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChuyenDangNgan_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen("mnuDangNganChuyenKhoan", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn Đăng Ngân?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        
                        if (backgroundWorker.IsBusy)
                            backgroundWorker.CancelAsync();
                        else
                        {
                            backgroundWorker.RunWorkerAsync();
                            frm = new frmLoading();
                            frm.ShowDialog();
                        }
                        //foreach (DataGridViewRow item in dgvTamThu.Rows)
                        //    if (item.Cells["NgayGiaiTrach_TT"].Value==null||item.Cells["NgayGiaiTrach_TT"].Value.ToString() == "")
                        //    {
                        //        using (var scope = new TransactionScope())
                        //        {
                        //            if (_cHoaDon.DangNgan("ChuyenKhoan", item.Cells["SoHoaDon_TT"].Value.ToString(), CNguoiDung.MaND))
                        //                if (_cTienDu.UpdateThem(item.Cells["SoHoaDon_TT"].Value.ToString()))
                        //                    scope.Complete();
                        //        }
                        //    }
                        //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //btnXem.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Đăng Ngân Chuyển Khoản Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dgvTamThu.Rows)
                    if (item.Cells["NgayGiaiTrach_TT"].Value.ToString() == "")
                    {
                        if (_cHoaDon.CheckKhoaTienDuBySoHoaDon(item.Cells["SoHoaDon_TT"].Value.ToString()))
                        {
                            MessageBox.Show("Hóa Đơn đã Khóa Tiền Dư " + item.Cells["SoHoaDon_TT"].Value.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            item.Selected = true;
                            return;
                        }
                        if (_cHoaDon.CheckDCHDTienDuBySoHoaDon(item.Cells["SoHoaDon_TT"].Value.ToString()))
                        {
                            MessageBox.Show("Hóa Đơn đã ĐCHĐ Tiền Dư " + item.Cells["SoHoaDon_TT"].Value.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            item.Selected = true;
                            return;
                        }
                        string DanhBo = "";
                        if (_cDCHD.CheckExist_UpdatedHDDT(item.Cells["SoHoaDon_TT"].Value.ToString(), ref DanhBo) == false)
                        {
                            MessageBox.Show("Hóa Đơn có Điều Chỉnh nhưng chưa update HĐĐT " + DanhBo, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvTamThu.CurrentCell = item.Cells["DanhBo_TT"];
                            dgvTamThu.Rows[item.Index].Selected = true;
                            return;
                        }
                    }
                foreach (DataGridViewRow item in dgvTamThu.Rows)
                    if (item.Cells["NgayGiaiTrach_TT"].Value == null || item.Cells["NgayGiaiTrach_TT"].Value.ToString() == "")
                    {
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            if (_cHoaDon.DangNgan("ChuyenKhoan", item.Cells["SoHoaDon_TT"].Value.ToString(), CNguoiDung.MaND))
                                if (_cTienDu.UpdateThem(item.Cells["SoHoaDon_TT"].Value.ToString()))
                                {
                                    scope.Complete();
                                    scope.Dispose();
                                }
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (frm != null)
                frm.Close();
            MessageBox.Show("Xử lý thành công\nVui lòng kiểm tra lại số liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKiemTraSaiSot_Click(object sender, EventArgs e)
        {
            DataTable dt = _cTamThu.getDSSaiSot_ChuyenKhoan(dateTu.Value, dateDen.Value);
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("DanhBo", typeof(string));
            foreach (DataRow item in dt.Rows)
            {
                DataTable dtTT = _cTamThu.getDS(true, item["DanhBo"].ToString(), dateTu.Value, dateDen.Value);
                DataTable dtTon = _cHoaDon.GetDSTonByDanhBo(item["DanhBo"].ToString());
                if (dtTon.Rows.Count > 0 && (int.Parse(dtTT.Rows[0]["Nam"].ToString()) < int.Parse(dtTon.Rows[0]["Nam"].ToString()) || (int.Parse(dtTT.Rows[0]["Nam"].ToString()) == int.Parse(dtTon.Rows[0]["Nam"].ToString()) && int.Parse(dtTT.Rows[0]["Ky2"].ToString()) < int.Parse(dtTon.Rows[0]["Ky2"].ToString()))))
                    //str += item["DanhBo"].ToString() + " === Tạm Thu: " + item["SLTamThu"].ToString() + " === Tồn: " + item["SLTon"].ToString() + "\n";
                    dtTemp.Rows.Add(item["DanhBo"].ToString());
            }
            dgvTamThu.DataSource = dtTemp;
            //MessageBox.Show(str, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
