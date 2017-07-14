using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.DongNuoc;
using System.Globalization;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.BaoCao.DongNuoc;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL;
using ThuTien.DAL.Quay;
using ThuTien.DAL.HanhThu;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmGiaoTBDongNuoc : Form
    {
        string _mnu = "mnuGiaoTBDongNuoc";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        List<TT_NguoiDung> _lstND = new List<TT_NguoiDung>();
        //CCAPNUOCTANHOA _cCapNuocTanHoa = new CCAPNUOCTANHOA();
        CThongTinKhachHang _cTTKH = new CThongTinKhachHang();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        public frmGiaoTBDongNuoc()
        {
            InitializeComponent();
        }

        private void frmGiaoTBDongNuoc_Load(object sender, EventArgs e)
        {
            TT_NguoiDung nguoidung = new TT_NguoiDung();
            nguoidung.MaND = -1;
            nguoidung.HoTen = "Tất cả";
            _lstND = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
            _lstND.Insert(0, nguoidung);
            cmbNhanVienLap.DataSource = _lstND;
            cmbNhanVienLap.DisplayMember = "HoTen";
            cmbNhanVienLap.ValueMember = "MaND";

            cmbNhanVienGiao.DataSource = _cNguoiDung.GetDSDongNuocByMaTo(CNguoiDung.MaTo);
            cmbNhanVienGiao.DisplayMember = "HoTen";
            cmbNhanVienGiao.ValueMember = "MaND";

            lbTo.Text = "Tổ  " + CNguoiDung.TenTo;

            gridControl.LevelTree.Nodes.Add("Chi Tiết Đóng Nước", gridViewCTDN);

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbNhanVienLap.SelectedIndex == 0 && dateTu.Value <= dateDen.Value)
            {
                DataSet ds = null;
                for (int i = 1; i < _lstND.Count; i++)
                    if (ds == null)
                        ds = _cDongNuoc.GetDSByMaNVCreateDates(CNguoiDung.TenTo, _lstND[i].MaND, dateTu.Value, dateDen.Value);
                    else
                        ds.Merge(_cDongNuoc.GetDSByMaNVCreateDates(CNguoiDung.TenTo, _lstND[i].MaND, dateTu.Value, dateDen.Value));
                gridControl.DataSource = ds.Tables["DongNuoc"];
            }
            else
                if (cmbNhanVienLap.SelectedIndex > 0 && dateTu.Value <= dateDen.Value)
                    gridControl.DataSource = _cDongNuoc.GetDSByMaNVCreateDates(CNguoiDung.TenTo, int.Parse(cmbNhanVienLap.SelectedValue.ToString()), dateTu.Value, dateDen.Value).Tables["DongNuoc"];

            ///Kiểm Tra Tình Trạng, Giải Trách hết Hóa Đơn trong Thông Báo Đóng Nước mới tính
            for (int i = 0; i < gridViewDN.DataRowCount; i++)
            {
                DataRow row = gridViewDN.GetDataRow(i);
                DataRow[] childRows = row.GetChildRows("Chi Tiết Đóng Nước");

                string TinhTrang = "Tồn";
                int DangNgan = 0;
                foreach (DataRow itemChild in childRows)
                {
                    DateTime NgayGiaiTrach;
                    DateTime.TryParse(itemChild["NgayGiaiTrach"].ToString(), out NgayGiaiTrach);
                    ///xét ngày đăng ngân để lấy tồn lùi
                    if (!string.IsNullOrEmpty(itemChild["NgayGiaiTrach"].ToString()) && NgayGiaiTrach.Date <= dateDen.Value.Date)
                    {
                        //TinhTrang = "Đăng Ngân";
                        DangNgan++;
                    }
                    if(DangNgan==childRows.Count())
                        TinhTrang = "Đăng Ngân";
                    if (_cDongNuoc.CheckExist_KQDongNuoc(int.Parse(row["MaDN"].ToString()), dateDen.Value.Date))
                    {
                        TinhTrang = "Đã Khóa Nước";
                    }
                }
                gridViewDN.SetRowCellValue(i, "TinhTrang", TinhTrang);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    _cDongNuoc.SqlBeginTransaction();
                    DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
                    foreach (DataRow item in dt.Rows)
                        //if (_cDongNuoc.XoaGiaoDongNuoc(decimal.Parse(item["MaDN"].ToString())))
                        //{
                        if (!_cDongNuoc.GiaoDongNuoc(decimal.Parse(item["MaDN"].ToString()), int.Parse(cmbNhanVienGiao.SelectedValue.ToString())))
                        {
                            _cDongNuoc.SqlRollbackTransaction();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    //}
                    _cDongNuoc.SqlCommitTransaction();
                    btnXem.PerformClick();
                    //gridControl.DataSource = _cDongNuoc.GetDSByMaNVCreateDates(int.Parse(cmbNhanVienLap.SelectedValue.ToString()), dateTu.Value, dateDen.Value).Tables["DongNuoc"];
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cDongNuoc.SqlRollbackTransaction();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {

            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    _cDongNuoc.SqlBeginTransaction();
                    //DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
                    DevExpress.XtraGrid.Views.Grid.GridView gv = ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl.DefaultView);
                    int[] rows = gv.GetSelectedRows();
                    foreach (int i in rows)
                        if (!_cDongNuoc.CheckExist_KQDongNuoc(decimal.Parse(gv.GetDataRow(i)["MaDN"].ToString()), int.Parse(gv.GetDataRow(i)["MaNV_DongNuoc"].ToString())))
                        {
                            if (!_cDongNuoc.XoaGiaoDongNuoc(decimal.Parse(gv.GetDataRow(i)["MaDN"].ToString())))
                            {
                                _cDongNuoc.SqlRollbackTransaction();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    _cDongNuoc.SqlCommitTransaction();
                    gridControl.DataSource = _cDongNuoc.GetDSByMaNVCreateDates(CNguoiDung.TenTo, int.Parse(cmbNhanVienLap.SelectedValue.ToString()), dateTu.Value, dateDen.Value).Tables["DongNuoc"];
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cDongNuoc.SqlRollbackTransaction();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void gridViewDN_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MLT" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (e.Column.FieldName == "DanhBo" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (e.Column.FieldName == "MaDN" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (e.Column.FieldName == "CreateBy" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.DisplayText = _cNguoiDung.GetHoTenByMaND(int.Parse(e.Value.ToString()));
            }
            if (e.Column.FieldName == "MaNV_DongNuoc" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.DisplayText = _cNguoiDung.GetHoTenByMaND(int.Parse(e.Value.ToString()));
            }
        }

        private void gridViewDN_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridViewCTDN_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "TieuThu" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "GiaBan" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "ThueGTGT" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "PhiBVMT" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "TongCong" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void btnInDSTBNguoiLap_Click(object sender, EventArgs e)
        {
            if (cmbNhanVienLap.SelectedIndex > 0)
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                for (int i = 0; i < gridViewDN.DataRowCount; i++)
                {
                    DataRow row = gridViewDN.GetDataRow(i);
                    DataRow[] childRows = row.GetChildRows("Chi Tiết Đóng Nước");

                    foreach (DataRow itemChild in childRows)
                    {
                        DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                        dr["Loai"] = "CHUYỂN";
                        dr["MaDN"] = row["MaDN"].ToString().Insert(row["MaDN"].ToString().Length - 2, "-");
                        dr["To"] = CNguoiDung.TenTo;
                        dr["HoTen"] = row["HoTen"];
                        dr["DiaChi"] = row["DiaChi"];
                        if (!string.IsNullOrEmpty(row["DanhBo"].ToString()))
                            dr["DanhBo"] = row["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["MLT"] = row["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = itemChild["Ky"];
                        dr["TongCong"] = itemChild["TongCong"];
                        dr["NhanVien"] = cmbNhanVienLap.Text;
                        dr["HanhThu"] = _cNguoiDung.GetHoTenByMaND(int.Parse(row["CreateBy"].ToString()));

                        dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                    }
                }
                rptDSHDDongNuoc rpt = new rptDSHDDongNuoc();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void btnInDSTBNguoiGiao_Click(object sender, EventArgs e)
        {
            if (cmbNhanVienLap.SelectedIndex > -1)
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                for (int i = 0; i < gridViewDN.DataRowCount; i++)
                {
                    DataRow row = gridViewDN.GetDataRow(i);
                    if (row["MaNV_DongNuoc"].ToString() == cmbNhanVienGiao.SelectedValue.ToString())
                    {
                        DataRow[] childRows = row.GetChildRows("Chi Tiết Đóng Nước");

                        foreach (DataRow itemChild in childRows)
                        {
                            DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                            dr["Loai"] = "CHUYỂN";
                            dr["MaDN"] = row["MaDN"].ToString().Insert(row["MaDN"].ToString().Length - 2, "-");
                            dr["To"] = CNguoiDung.TenTo;
                            dr["HoTen"] = row["HoTen"];
                            dr["DiaChi"] = row["DiaChi"];
                            if (!string.IsNullOrEmpty(row["DanhBo"].ToString()))
                                dr["DanhBo"] = row["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                            dr["MLT"] = row["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                            dr["Ky"] = itemChild["Ky"];
                            dr["TongCong"] = itemChild["TongCong"];
                            dr["NhanVien"] = cmbNhanVienGiao.Text;
                            dr["HanhThu"] = _cNguoiDung.GetHoTenByMaND(int.Parse(row["CreateBy"].ToString()));

                            dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                        }
                    }
                }
                rptDSHDDongNuoc rpt = new rptDSHDDongNuoc();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void btnInDSTBTonNguoiGiao_Click(object sender, EventArgs e)
        {
            if (cmbNhanVienLap.SelectedIndex > -1)
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                for (int i = 0; i < gridViewDN.DataRowCount; i++)
                {
                    DataRow row = gridViewDN.GetDataRow(i);
                    if (row["MaNV_DongNuoc"].ToString() == cmbNhanVienGiao.SelectedValue.ToString())
                    {
                        DataRow[] childRows = row.GetChildRows("Chi Tiết Đóng Nước");

                        foreach (DataRow itemChild in childRows)
                            if (string.IsNullOrEmpty(itemChild["NgayGiaiTrach"].ToString()))
                            {
                                DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                                dr["Loai"] = "CHUYỂN CÒN TỒN";
                                dr["MaDN"] = row["MaDN"].ToString().Insert(row["MaDN"].ToString().Length - 2, "-");
                                dr["To"] = CNguoiDung.TenTo;
                                dr["HoTen"] = row["HoTen"];
                                dr["DiaChi"] = row["DiaChi"];
                                if (!string.IsNullOrEmpty(row["DanhBo"].ToString()))
                                    dr["DanhBo"] = row["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["MLT"] = row["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                                dr["Ky"] = itemChild["Ky"];
                                dr["TongCong"] = itemChild["TongCong"];
                                dr["NhanVien"] = cmbNhanVienGiao.Text;
                                dr["HanhThu"] = _cNguoiDung.GetHoTenByMaND(int.Parse(row["CreateBy"].ToString()));
                                if (_cLenhHuy.CheckExist(itemChild["SoHoaDon"].ToString()))
                                    dr["LenhHuy"] = true;
                                else
                                    dr["LenhHuy"] = false;

                                dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                            }
                    }
                }
                rptDSHDDongNuoc rpt = new rptDSHDDongNuoc();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
                for (int i = 0; i < gridViewDN.RowCount; i++)
                    gridViewDN.SetRowCellValue(i, gridViewDN.Columns["In"], "True");
            else
                for (int i = 0; i < gridViewDN.RowCount; i++)
                    gridViewDN.SetRowCellValue(i, gridViewDN.Columns["In"], "False");
        }

        private void btnInTB_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
                foreach (DataRow item in dt.Rows)
                    if (bool.Parse(item["In"].ToString()))
                    {
                        DataRow[] childRows = item.GetChildRows("Chi Tiết Đóng Nước");
                        string Ky = "";
                        int TongCong = 0; ;
                        foreach (DataRow itemChild in childRows)
                        {
                            Ky += itemChild["Ky"] + "  Số tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemChild["TongCong"]) + "\n";
                            TongCong += int.Parse(itemChild["TongCong"].ToString());
                        }

                        DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                        dr["MaDN"] = item["MaDN"].ToString().Insert(item["MaDN"].ToString().Length - 2, "-"); ;
                        dr["HoTen"] = item["HoTen"];
                        dr["DiaChi"] = item["DiaChi"];
                        dr["DienThoai"] = _cTTKH.GetDienThoai(item["DanhBo"].ToString());
                        if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = Ky;
                        dr["TongCong"] = TongCong;
                        dr["NhanVien"] = _cNguoiDung.GetHoTenByMaND(int.Parse(item["CreateBy"].ToString()));
                        if (!string.IsNullOrEmpty(item["CreateBy"].ToString()))
                            dr["NhanVienDN"] = _cNguoiDung.GetDienThoaiByMaND(int.Parse(item["CreateBy"].ToString()));
                        if (!string.IsNullOrEmpty(item["MaNV_DongNuoc"].ToString()))
                            dr["NhanVienDN"] = _cNguoiDung.GetDienThoaiByMaND(int.Parse(item["MaNV_DongNuoc"].ToString()));
                        if (chkChuKy.Checked)
                            dr["ChuKy"] = true;

                        dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);

                        rptTBDongNuocPhoto rpt = new rptTBDongNuocPhoto();
                        rpt.SetDataSource(dsBaoCao);
                        //frmBaoCao frm = new frmBaoCao(rpt);
                        //frm.ShowDialog();
                        printDialog.AllowSomePages = true;
                        printDialog.ShowHelp = true;

                        rpt.PrintOptions.PaperOrientation = rpt.PrintOptions.PaperOrientation;
                        rpt.PrintOptions.PaperSize = rpt.PrintOptions.PaperSize;
                        rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                        rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, false, 1, 1);
                    }
            }
        }

        private void btnInDSTBTonThucTeNguoiGiao_Click(object sender, EventArgs e)
        {
            if (cmbNhanVienLap.SelectedIndex > -1)
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                for (int i = 0; i < gridViewDN.DataRowCount; i++)
                {
                    DataRow row = gridViewDN.GetDataRow(i);
                    if (row["MaNV_DongNuoc"].ToString() == cmbNhanVienGiao.SelectedValue.ToString())
                    {
                        DataRow[] childRows = row.GetChildRows("Chi Tiết Đóng Nước");

                        foreach (DataRow itemChild in childRows)
                            if (string.IsNullOrEmpty(itemChild["NgayGiaiTrach"].ToString()) && _cLenhHuy.CheckExist(itemChild["SoHoaDon"].ToString())==false)
                            {
                                DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                                dr["Loai"] = "CHUYỂN CÒN TỒN";
                                dr["MaDN"] = row["MaDN"].ToString().Insert(row["MaDN"].ToString().Length - 2, "-");
                                dr["To"] = CNguoiDung.TenTo;
                                dr["HoTen"] = row["HoTen"];
                                dr["DiaChi"] = row["DiaChi"];
                                if (!string.IsNullOrEmpty(row["DanhBo"].ToString()))
                                    dr["DanhBo"] = row["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["MLT"] = row["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                                dr["Ky"] = itemChild["Ky"];
                                dr["TongCong"] = itemChild["TongCong"];
                                dr["NhanVien"] = cmbNhanVienGiao.Text;
                                dr["HanhThu"] = _cNguoiDung.GetHoTenByMaND(int.Parse(row["CreateBy"].ToString()));

                                dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                            }
                    }
                }
                rptDSHDDongNuoc rpt = new rptDSHDDongNuoc();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
                for (int i = 0; i < gridViewDN.DataRowCount; i++)
                {
                    DataRow row = gridViewDN.GetDataRow(i);
                    DataRow[] childRows = row.GetChildRows("Chi Tiết Đóng Nước");

                    foreach (DataRow itemChild in childRows)
                    {
                        DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                        dr["SoHoaDon"] = itemChild["SoHoaDon"];
                        dr["HoTen"] = row["HoTen"];
                        dr["DiaChi"] = row["DiaChi"];
                        if (!string.IsNullOrEmpty(row["DanhBo"].ToString()))
                            dr["DanhBo"] = row["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["MLT"] = row["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = itemChild["Ky"];
                        dr["TongCong"] = itemChild["TongCong"];
                        dr["NhanVien"] = cmbNhanVienLap.Text;
                        dr["HanhThu"] = _cNguoiDung.GetHoTenByMaND(int.Parse(row["CreateBy"].ToString()));
                        dr["To"] = CNguoiDung.TenTo;

                        dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                    }
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

            oSheet.Name = "DANH SÁCH THÔNG BÁO ĐÓNG NƯỚC";
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
            cl6.Value2 = "Tổng Cộng";
            cl6.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
            cl7.Value2 = "Hành Thu";
            cl7.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
            cl8.Value2 = "Tổ";
            cl8.ColumnWidth = 5;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dsBaoCao.Tables["TBDongNuoc"].Rows.Count, 8];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dsBaoCao.Tables["TBDongNuoc"].Rows.Count; i++)
            {
                DataRow dr = dsBaoCao.Tables["TBDongNuoc"].Rows[i];

                arr[i, 0] = dr["SoHoaDon"].ToString();
                arr[i, 1] = dr["Ky"].ToString();
                arr[i, 2] = dr["DanhBo"].ToString();
                arr[i, 3] = dr["HoTen"].ToString();
                arr[i, 4] = dr["MLT"].ToString();
                arr[i, 5] = dr["TongCong"].ToString();
                arr[i, 6] = dr["HanhThu"].ToString();
                arr[i, 7] = dr["To"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dsBaoCao.Tables["TBDongNuoc"].Rows.Count - 1;
            int columnEnd = 8;

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

    }
}
