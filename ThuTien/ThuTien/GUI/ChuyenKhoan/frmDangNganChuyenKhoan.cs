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
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.DAL.TongHop;
using ThuTien.BaoCao;
using ThuTien.BaoCao.NhanVien;
using ThuTien.GUI.BaoCao;
using ThuTien.GUI.TimKiem;
using ThuTien.LinQ;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.BaoCao.Quay;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmDangNganChuyenKhoan : Form
    {
        string _mnu = "mnuDangNganChuyenKhoan";
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();
        CDCHD _cDCHD = new CDCHD();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CTienDu _cTienDu = new CTienDu();
        CNguoiDung _cNguoiDung = new CNguoiDung();

        public frmDangNganChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmDangNganChuyenKhoan_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;
            dgvTienAm.AutoGenerateColumns = false;
            dgvTienDu.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            dateNgayGiaiTrach.Value = DateTime.Now;

            cmbFromDot.SelectedIndex = 0;
        }

        public void CountdgvHDTuGia()
        {
            long TongGiaBan = 0;
            long TongThueGTGT = 0;
            long TongPhiBVMT = 0;
            long TongCong = 0;
            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    TongGiaBan += long.Parse(item.Cells["GiaBan_TG"].Value.ToString());
                    TongThueGTGT += long.Parse(item.Cells["ThueGTGT_TG"].Value.ToString());
                    TongPhiBVMT += long.Parse(item.Cells["PhiBVMT_TG"].Value.ToString());
                    TongCong += long.Parse(item.Cells["TongCong_TG"].Value.ToString());
                }
                txtTongHD_TG.Text = dgvHDTuGia.RowCount.ToString();
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDTuGia.RowCount);
                txtTongGiaBan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CountdgvHDCoQuan()
        {
            long TongGiaBan = 0;
            long TongThueGTGT = 0;
            long TongPhiBVMT = 0;
            long TongCong = 0;
            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    TongGiaBan += long.Parse(item.Cells["GiaBan_CQ"].Value.ToString());
                    TongThueGTGT += long.Parse(item.Cells["ThueGTGT_CQ"].Value.ToString());
                    TongPhiBVMT += long.Parse(item.Cells["PhiBVMT_CQ"].Value.ToString());
                    TongCong += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = dgvHDCoQuan.RowCount.ToString();
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDCoQuan.RowCount);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                dgvHDTuGia.DataSource = _cHoaDon.GetDSDangNganChuyenKhoanByMaNVNgayGiaiTrach("TG", dateTu.Value, dateDen.Value);
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    dgvHDCoQuan.DataSource = _cHoaDon.GetDSDangNganChuyenKhoanByMaNVNgayGiaiTrach("CQ", dateTu.Value, dateDen.Value);
                    CountdgvHDCoQuan();
                }
                else
                    if (tabControl.SelectedTab.Name == "tabTienDu")
                    {
                        dgvTienAm.DataSource = _cTienDu.GetDSTienAm();
                        CountdgvTienAm();
                        dgvTienDu.DataSource = _cTienDu.GetDSTienDu();
                        CountdgvTienDu();
                    }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                //string loai = "";
                foreach (ListViewItem item in lstHD.Items)
                {
                    //if (!_cHoaDon.CheckBySoHoaDon(item.ToString()))
                    //{
                    //    MessageBox.Show("Hóa Đơn sai: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                    //if (_cHoaDon.CheckDangNganBySoHoaDon(item.ToString()))
                    //{
                    //    MessageBox.Show("Hóa Đơn đã Đăng Ngân: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                    //if (!_cTamThu.CheckBySoHoaDon(item.ToString(), out loai))
                    //{
                    //    MessageBox.Show("Hóa Đơn không có Tạm Thu: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                    //if (loai == "Quầy")
                    //{
                    //    MessageBox.Show("Hóa Đơn có Tạm Thu(Quầy): " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                    //if (_cDCHD.CheckExistByDangRutDC(item.ToString()))
                    //{
                    //    MessageBox.Show("Hóa Đơn đã Rút đi Điều Chỉnh: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lstHD.SelectedItem = item;
                    //    return;
                    //}
                }
                try
                {
                    //_cHoaDon.SqlBeginTransaction();
                    foreach (ListViewItem item in lstHD.Items)
                        if (_cHoaDon.DangNgan("ChuyenKhoan", item.Text, CNguoiDung.MaND))
                        {
                            //if (_cLenhHuy.CheckExist(item.ToString()))
                            //    if (!_cLenhHuy.Xoa(item.ToString()))
                            //    {
                            //        _cHoaDon.SqlRollbackTransaction();
                            //        MessageBox.Show("Lỗi Xóa Lệnh Hủy, Vui lòng thử lại \r\n" + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //        return;
                            //    }
                            if (!_cTienDu.UpdateThem(item.Text))
                            {
                                //_cHoaDon.SqlRollbackTransaction();
                                MessageBox.Show("Lỗi Update Tiền Dư, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            //_cHoaDon.SqlRollbackTransaction();
                            //MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                    //_cHoaDon.SqlCommitTransaction();
                    lstHD.Items.Clear();
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    //_cHoaDon.SqlRollbackTransaction();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (tabControl.SelectedTab.Name == "tabTuGia")
                    {
                        foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                        {
                            if (_cHoaDon.GetNgayGiaiTrach(item.Cells["SoHoaDon_TG"].Value.ToString()).Date != DateTime.Now.Date)
                            {
                                MessageBox.Show("Chỉ được Điều Chỉnh Đăng Ngân trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                        if (tabControl.SelectedTab.Name == "tabCoQuan")
                        {
                            foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                            {
                                if (_cHoaDon.GetNgayGiaiTrach(item.Cells["SoHoaDon_CQ"].Value.ToString()).Date != DateTime.Now.Date)
                                {
                                    MessageBox.Show("Chỉ được Điều Chỉnh Đăng Ngân trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }

                    try
                    {
                        //_cHoaDon.SqlBeginTransaction();
                        if (tabControl.SelectedTab.Name == "tabTuGia")
                        {
                            foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                            {
                                if (_cHoaDon.XoaDangNgan("ChuyenKhoan", item.Cells["SoHoaDon_TG"].Value.ToString(), CNguoiDung.MaND))
                                {
                                    if (!_cTienDu.UpdateXoa(item.Cells["SoHoaDon_TG"].Value.ToString()))
                                    {
                                        //_cHoaDon.SqlRollbackTransaction();
                                        MessageBox.Show("Lỗi Update Tiền Dư, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else
                                {
                                    //_cHoaDon.SqlRollbackTransaction();
                                    //MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //return;
                                }
                            }
                        }
                        else
                            if (tabControl.SelectedTab.Name == "tabCoQuan")
                            {
                                foreach (DataGridViewRow item in dgvHDCoQuan.SelectedRows)
                                {
                                    if (_cHoaDon.XoaDangNgan("ChuyenKhoan", item.Cells["SoHoaDon_CQ"].Value.ToString(), CNguoiDung.MaND))
                                    {
                                        if (!_cTienDu.UpdateXoa(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                                        {
                                            //_cHoaDon.SqlRollbackTransaction();
                                            MessageBox.Show("Lỗi Update Tiền Dư, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        //_cHoaDon.SqlRollbackTransaction();
                                        //MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //return;
                                    }
                                }
                            }
                        //_cHoaDon.SqlCommitTransaction();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        //_cHoaDon.SqlRollbackTransaction();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                DataTable dt = _cHoaDon.GetTongDangNganByMaNV_DangNganNgayGiaiTrach("TG", CNguoiDung.MaND, dateDen.Value);
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                    dr["To"] = CNguoiDung.TenTo;
                    dr["Loai"] = "Tư Gia";
                    dr["NgayDangNgan"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                    dr["TongHD"] = item["TongHD"].ToString();
                    dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                    dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                    dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                    dr["TongCong"] = item["TongCong"].ToString();
                    if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                        dr["TongTienMat"] = item["TongTienMat"].ToString();
                    //else
                    //    dr["TongTienMat"] = 0;
                    dr["NhanVien"] = CNguoiDung.HoTen;
                    ds.Tables["PhieuDangNgan"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    DataTable dt = _cHoaDon.GetTongDangNganByMaNV_DangNganNgayGiaiTrach("CQ", CNguoiDung.MaND, dateDen.Value);
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Loai"] = "Cơ Quan";
                        dr["NgayDangNgan"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                        dr["TongHD"] = item["TongHD"].ToString();
                        dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                        dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                        dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                        dr["TongCong"] = item["TongCong"].ToString();
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            dr["TongTienMat"] = item["TongTienMat"].ToString();
                        //else
                        //    dr["TongTienMat"] = 0;
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["PhieuDangNgan"].Rows.Add(dr);
                    }
                }
            rptPhieuDangNgan rpt = new rptPhieuDangNgan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["LoaiBaoCao"] = "CHUYỂN KHOẢN TƯ GIA";
                    dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = item.Cells["HoTen_TG"].Value;
                    dr["Ky"] = item.Cells["Ky_TG"].Value;
                    dr["MLT"] = item.Cells["MLT_TG"].Value;
                    dr["TongCong"] = item.Cells["TongCong_TG"].Value;
                    dr["SoHoaDon"] = item.Cells["SoHoaDon_TG"].Value;
                    dr["NhanVien"] = item.Cells["HanhThu_TG"].Value.ToString();
                    dr["To"] = item.Cells["To_TG"].Value.ToString();
                    dr["Loai"] = "TG";
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["LoaiBaoCao"] = "CHUYỂN KHOẢN CƠ QUAN";
                        dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen_CQ"].Value;
                        dr["Ky"] = item.Cells["Ky_CQ"].Value;
                        dr["MLT"] = item.Cells["MLT_CQ"].Value;
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value;
                        dr["SoHoaDon"] = item.Cells["SoHoaDon_CQ"].Value;
                        dr["NhanVien"] = item.Cells["HanhThu_CQ"].Value.ToString();
                        dr["To"] = item.Cells["To_CQ"].Value.ToString();
                        dr["Loai"] = "CQ";
                        ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
                }
            rptDSDangNganQuay rpt = new rptDSDangNganQuay();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            //if (tabControl.SelectedTab.Name == "tabTuGia")
            //{
            //    if (dgvHDTuGia.RowCount > 0)
            //    {
            //        CTo _cTo = new CTo();
            //        List<TT_To> lstTo = _cTo.GetDSHanhThu();
            //        DataTable[] dtTos = new DataTable[lstTo.Count];
            //        DataTable dt = (DataTable)dgvHDTuGia.DataSource;

            //        for (int i = 0; i < dtTos.Length; i++)
            //        {
            //            dtTos[i] = new DataTable();
            //        }

            //        for (int i = 0; i < lstTo.Count; i++)
            //        {
            //            foreach (DataColumn item in dt.Columns)
            //            {
            //                dtTos[i].Columns.Add(new DataColumn(item.ColumnName, item.DataType));
            //            }
            //        }

            //        foreach (DataRow item in dt.Rows)
            //            for (int i = 0; i < lstTo.Count; i++)
            //                if (item["To"].ToString() == lstTo[i].TenTo)
            //                {
            //                    dtTos[i].ImportRow(item);
            //                }

            //        //Tạo các đối tượng Excel
            //        Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            //        Microsoft.Office.Interop.Excel.Workbooks oBooks;
            //        //Microsoft.Office.Interop.Excel.Sheets oSheets;
            //        Microsoft.Office.Interop.Excel.Workbook oBook;
            //        Microsoft.Office.Interop.Excel.Worksheet[] oSheets = new Microsoft.Office.Interop.Excel.Worksheet[lstTo.Count];

            //        //Tạo mới một Excel WorkBook 
            //        oExcel.Visible = true;
            //        oExcel.DisplayAlerts = false;
            //        //khai báo số lượng sheet
            //        oExcel.Application.SheetsInNewWorkbook = lstTo.Count;
            //        oBooks = oExcel.Workbooks;

            //        oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            //        //oSheets = oBook.Worksheets;
            //        //oSheetTG = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            //        //oSheetCQ = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);

            //        for (int i = 0; i < lstTo.Count; i++)
            //        {
            //            oSheets[i] = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(i + 1);
            //            XuatExcel(dtTos[i], oSheets[i], lstTo[i].TenTo);
            //        }
            //        //XuatExcel(dtTG, oSheetTG, "Tư Gia");
            //        //XuatExcel(dtCQ, oSheetCQ, "Cơ Quan");
            //    }
            //}
            //else
            //    if (tabControl.SelectedTab.Name == "tabCoQuan")
            //    {
            //        if (dgvHDCoQuan.RowCount > 0)
            //        {
            //            CTo _cTo = new CTo();
            //            List<TT_To> lstTo = _cTo.GetDSHanhThu();
            //            DataTable[] dtTos = new DataTable[lstTo.Count];
            //            DataTable dt = (DataTable)dgvHDCoQuan.DataSource;

            //            for (int i = 0; i < dtTos.Length; i++)
            //            {
            //                dtTos[i] = new DataTable();
            //            }

            //            for (int i = 0; i < lstTo.Count; i++)
            //            {
            //                foreach (DataColumn item in dt.Columns)
            //                {
            //                    dtTos[i].Columns.Add(new DataColumn(item.ColumnName, item.DataType));
            //                }
            //            }

            //            foreach (DataRow item in dt.Rows)
            //                for (int i = 0; i < lstTo.Count; i++)
            //                    if (item["To"].ToString() == lstTo[i].TenTo)
            //                    {
            //                        dtTos[i].ImportRow(item);
            //                    }

            //            //Tạo các đối tượng Excel
            //            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            //            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            //            //Microsoft.Office.Interop.Excel.Sheets oSheets;
            //            Microsoft.Office.Interop.Excel.Workbook oBook;
            //            Microsoft.Office.Interop.Excel.Worksheet[] oSheets = new Microsoft.Office.Interop.Excel.Worksheet[lstTo.Count];

            //            //Tạo mới một Excel WorkBook 
            //            oExcel.Visible = true;
            //            oExcel.DisplayAlerts = false;
            //            //khai báo số lượng sheet
            //            oExcel.Application.SheetsInNewWorkbook = lstTo.Count;
            //            oBooks = oExcel.Workbooks;

            //            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            //            //oSheets = oBook.Worksheets;
            //            //oSheetTG = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            //            //oSheetCQ = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);

            //            for (int i = 0; i < lstTo.Count; i++)
            //            {
            //                oSheets[i] = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(i + 1);
            //                XuatExcel(dtTos[i], oSheets[i], lstTo[i].TenTo);
            //            }
            //            //XuatExcel(dtTG, oSheetTG, "Tư Gia");
            //            //XuatExcel(dtCQ, oSheetCQ, "Cơ Quan");
            //        }
            //    }

            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                DataTable dt = (DataTable)dgvHDTuGia.DataSource;

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

                XuatExcel(dt, oSheet, "ĐĂNG NGÂN TƯ GIA");
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    DataTable dt = (DataTable)dgvHDCoQuan.DataSource;

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

                    XuatExcel(dt, oSheet, "ĐĂNG NGÂN CƠ QUAN");
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
            cl12.Value2 = "Ngân Hàng";
            cl12.ColumnWidth = 20;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 12];

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
                arr[i, 11] = _cTamThu.GetTenNganHang(dr["SoHoaDon"].ToString());
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 12;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            oSheet.get_Range(c2a, c3a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            oSheet.get_Range(c2b, c3b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            oSheet.get_Range(c2b, c3b).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            oSheet.get_Range(c2c, c3c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            oSheet.get_Range(c2d, c3d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

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

        private void btnInDSKhongTamThu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                    if (!_cTamThu.CheckExist(item.Cells["SoHoaDon_TG"].Value.ToString(), true))
                    {
                        DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                        dr["DanhBo"] = item.Cells["DanhBo_TG"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen_TG"].Value.ToString();
                        dr["MLT"] = item.Cells["MLT_TG"].Value.ToString();
                        dr["Ky"] = item.Cells["Ky_TG"].Value.ToString();
                        dr["TongCong"] = item.Cells["TongCong_TG"].Value.ToString();
                        dr["NhanVien"] = item.Cells["HanhThu_TG"].Value.ToString();
                        dr["To"] = item.Cells["To_TG"].Value.ToString();
                        dr["Loai"] = "TG";
                        ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                        if (!_cTamThu.CheckExist(item.Cells["SoHoaDon_CQ"].Value.ToString(), true))
                        {
                            DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                            dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                            dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                            dr["DanhBo"] = item.Cells["DanhBo_CQ"].Value.ToString().Insert(4, " ").Insert(8, " ");
                            dr["HoTen"] = item.Cells["HoTen_CQ"].Value.ToString();
                            dr["MLT"] = item.Cells["MLT_CQ"].Value.ToString();
                            dr["Ky"] = item.Cells["Ky_CQ"].Value.ToString();
                            dr["TongCong"] = item.Cells["TongCong_CQ"].Value.ToString();
                            dr["NhanVien"] = item.Cells["HanhThu_CQ"].Value.ToString();
                            dr["To"] = item.Cells["To_CQ"].Value.ToString();
                            dr["Loai"] = "CQ";
                            ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                        }
                }
            rptDSDangNganKhongTamThu rpt = new rptDSDangNganKhongTamThu();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private int _searchIndex = -1;
        private string _searchNoiDung = "";

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (_searchNoiDung != NoiDung)
                    _searchIndex = -1;

                for (int i = 0; i < dgvHDTuGia.Rows.Count; i++)
                {
                    if (_searchNoiDung != NoiDung)
                        _searchNoiDung = NoiDung;

                    _searchIndex = (_searchIndex + 1) % dgvHDTuGia.Rows.Count;
                    DataGridViewRow row = dgvHDTuGia.Rows[_searchIndex];
                    if (row.Cells["DanhBo_TG"].Value == null)
                    {
                        continue;
                    }
                    if (row.Cells["DanhBo_TG"].Value.ToString() == NoiDung)
                    {
                        dgvHDTuGia.CurrentCell = row.Cells["DanhBo_TG"];
                        dgvHDTuGia.Rows[_searchIndex].Selected = true;
                        return;
                    }
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (_searchNoiDung != NoiDung)
                        _searchIndex = -1;

                    for (int i = 0; i < dgvHDCoQuan.Rows.Count; i++)
                    {
                        if (_searchNoiDung != NoiDung)
                            _searchNoiDung = NoiDung;

                        _searchIndex = (_searchIndex + 1) % dgvHDCoQuan.Rows.Count;
                        DataGridViewRow row = dgvHDCoQuan.Rows[_searchIndex];
                        if (row.Cells["DanhBo_CQ"].Value == null)
                        {
                            continue;
                        }
                        if (row.Cells["DanhBo_CQ"].Value.ToString() == NoiDung)
                        {
                            dgvHDCoQuan.CurrentCell = row.Cells["DanhBo_CQ"];
                            dgvHDCoQuan.Rows[_searchIndex].Selected = true;
                            return;
                        }
                    }
                }
                else
                    if (tabControl.SelectedTab.Name == "tabTienDu")
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
        }

        private void frmDangNganChuyenKhoan_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "DanhBo_TG" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TieuThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "GiaBan_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "ThueGTGT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "PhiBVMT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDTuGia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDTuGia.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "DanhBo_CQ" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TieuThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "GiaBan_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "ThueGTGT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "PhiBVMT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDCoQuan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
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

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstHD.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
        }

        private void btnInDSThuThem_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTienDu.Rows)
            {
                List<HOADON> lstHD = _cHoaDon.GetDSTon(item.Cells["DanhBo_TienDu"].Value.ToString());

                if (lstHD != null && lstHD[0].DOT >= int.Parse(cmbFromDot.SelectedItem.ToString()) && lstHD[0].DOT <= int.Parse(cmbToDot.SelectedItem.ToString()) && int.Parse(item.Cells["SoTien_TienDu"].Value.ToString()) < lstHD.Sum(itemHD => itemHD.TONGCONG))
                {
                    foreach (HOADON itemHD in lstHD)
                    {
                        DataRow dr = ds.Tables["TienDuKhachHang"].NewRow();
                        dr["DanhBo"] = item.Cells["DanhBo_TienDu"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = itemHD.TENKH;
                        dr["Ky"] = itemHD.KY + "/" + itemHD.NAM;
                        dr["MLT"] = itemHD.MALOTRINH;
                        dr["TienDu"] = item.Cells["SoTien_TienDu"].Value;
                        dr["TongCong"] = itemHD.TONGCONG;
                        if (lstHD[0].MaNV_HanhThu != null)
                        {
                            dr["NhanVien"] = _cNguoiDung.GetHoTenByMaND(itemHD.MaNV_HanhThu.Value);
                            dr["To"] = _cNguoiDung.GetTenToByMaND(itemHD.MaNV_HanhThu.Value);
                        }
                        ds.Tables["TienDuKhachHang"].Rows.Add(dr);

                        DataRow drTT = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        drTT["LoaiBaoCao"] = "TIỀN DƯ THU THÊM";
                        drTT["DanhBo"] = itemHD.DANHBA.Insert(4, " ").Insert(8, " ");
                        drTT["HoTen"] = itemHD.TENKH;
                        drTT["MLT"] = itemHD.MALOTRINH;
                        drTT["Ky"] = itemHD.KY+"/"+itemHD.NAM;
                        drTT["TongCong"] = itemHD.TONGCONG;
                        if (itemHD.MaNV_HanhThu != null)
                        {
                            drTT["NhanVien"] = _cNguoiDung.GetHoTenByMaND(itemHD.MaNV_HanhThu.Value);
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
            rpt.Subreports[0].SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInDSDuTien_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTienDu.Rows)
            {
                List<HOADON> lstHD = _cHoaDon.GetDSTon(item.Cells["DanhBo_TienDu"].Value.ToString());

                if (lstHD != null && lstHD[0].DOT >= int.Parse(cmbFromDot.SelectedItem.ToString()) && lstHD[0].DOT <= int.Parse(cmbToDot.SelectedItem.ToString()) && int.Parse(item.Cells["SoTien_TienDu"].Value.ToString()) >= lstHD.Sum(itemHD => itemHD.TONGCONG))
                {
                    foreach (HOADON itemHD in lstHD)
                    {
                        DataRow dr = ds.Tables["TienDuKhachHang"].NewRow();
                        dr["DanhBo"] = item.Cells["DanhBo_TienDu"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = itemHD.TENKH;
                        dr["Ky"] = itemHD.KY + "/" + itemHD.NAM;
                        dr["MLT"] = itemHD.MALOTRINH;
                        dr["TienDu"] = item.Cells["SoTien_TienDu"].Value;
                        dr["TongCong"] = itemHD.TONGCONG;
                        if (lstHD[0].MaNV_HanhThu != null)
                        {
                            dr["NhanVien"] = _cNguoiDung.GetHoTenByMaND(itemHD.MaNV_HanhThu.Value);
                            dr["To"] = _cNguoiDung.GetTenToByMaND(itemHD.MaNV_HanhThu.Value);
                        }
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
                            drTT["NhanVien"] = _cNguoiDung.GetHoTenByMaND(itemHD.MaNV_HanhThu.Value);
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
        }

        private void btnChuyenTamThu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTamThuChuyenKhoan", "Them"))
            {
                if (MessageBox.Show("Bạn có chắc chắn Chuyển Tạm Thu " + cmbFromDot.SelectedItem.ToString() + "?", "Xác nhận chuyển", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (DataGridViewRow item in dgvTienDu.Rows)
                    {
                        List<HOADON> lstHD = _cHoaDon.GetDSTon(item.Cells["DanhBo_TienDu"].Value.ToString());
                        if (lstHD != null && lstHD[0].DOT == int.Parse(cmbFromDot.SelectedItem.ToString()) && int.Parse(item.Cells["SoTien_TienDu"].Value.ToString()) >= lstHD.Sum(itemHD => itemHD.TONGCONG))
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

        private void dgvTienDu_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvTienDu.Columns[e.ColumnIndex].Name == "DienThoai_TienDu" && e.FormattedValue.ToString().Replace(" ", "") != dgvTienDu[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_TienDu tiendu = _cTienDu.Get(dgvTienDu["DanhBo_TienDu", e.RowIndex].Value.ToString());
                    tiendu.DienThoai = e.FormattedValue.ToString();
                    _cTienDu.Sua(tiendu);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTienDu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTienDu.RowCount > 0 && e.Button == MouseButtons.Left && dgvTienDu.Columns[e.ColumnIndex].Name != "DienThoai_TienDu")
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    frmChuyenTien frm = new frmChuyenTien(dgvTienDu["DanhBo_TienDu", e.RowIndex].Value.ToString(), dgvTienDu["SoTien_TienDu", e.RowIndex].Value.ToString());
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        btnXem.PerformClick();
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            cl3.Value2 = "MLT";
            cl3.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Khách Hàng";
            cl4.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Địa Chỉ";
            cl5.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Tổ";
            cl6.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Hành Thu";
            cl7.ColumnWidth = 12;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 7];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["DanhBo"].ToString();
                arr[i, 1] = dr["SoTien"].ToString();

                HOADON hoadon = _cHoaDon.GetMoiNhat(dr["DanhBo"].ToString());
                if (hoadon != null)
                {
                    arr[i, 2] = hoadon.MALOTRINH;
                    arr[i, 3] = hoadon.TENKH;
                    arr[i, 4] = hoadon.SO + " " + hoadon.DUONG;
                    if (hoadon.MaNV_HanhThu != null)
                    {
                        arr[i, 5] = _cNguoiDung.GetTenToByMaND(hoadon.MaNV_HanhThu.Value);
                        arr[i, 6] = _cNguoiDung.GetHoTenByMaND(hoadon.MaNV_HanhThu.Value);
                    }
                }
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 7;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            oSheet.get_Range(c2a, c3a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            oSheet.get_Range(c2b, c3b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            oSheet.get_Range(c2b, c3b).NumberFormat = "#,##0";

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

    }
}
