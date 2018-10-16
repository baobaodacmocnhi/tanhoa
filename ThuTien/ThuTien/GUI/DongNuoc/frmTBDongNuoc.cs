using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.QuanTri;
using ThuTien.BaoCao;
using ThuTien.BaoCao.DongNuoc;
using ThuTien.GUI.BaoCao;
using System.Globalization;
using ThuTien.DAL;
using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraGrid.Views.Grid;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmTBDongNuoc : Form
    {
        string _mnu = "mnuTBDongNuoc";
        CHoaDon _cHoaDon = new CHoaDon();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDocSo _cDocSo = new CDocSo();

        DataRowView _selectedRow=null;

        public frmTBDongNuoc()
        {
            InitializeComponent();
        }

        private void frmLenhDongNuoc_Load(object sender, EventArgs e)
        {
            gridControl.LevelTree.Nodes.Add("Chi Tiết Đóng Nước", gridViewCTDN);

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;

            if (CNguoiDung.Doi || CNguoiDung.ToTruong)
                groupBox_ThemDN.Visible = true;
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 13)
                    {
                        if (lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                        {
                            lstHD.Items.Add(item.Trim().ToUpper());
                            lstHD.EnsureVisible(lstHD.Items.Count - 1);
                        }
                    }
                    else
                        ///Trung An thêm 'K' phía cuối liên hóa đơn
                        if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 14)
                        {
                            if (lstHD.FindItemWithText(item.Trim().ToUpper().Replace("K", "")) == null)
                            {
                                lstHD.Items.Add(item.Trim().ToUpper().Replace("K", ""));
                                lstHD.EnsureVisible(lstHD.Items.Count - 1);
                            }
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                List<HOADON> lstHDTemp = new List<HOADON>();
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
                    if (_cDongNuoc.CheckExist_CTDongNuoc(item.Text))
                    {
                        MessageBox.Show("Hóa Đơn đã Lập TB Đóng Nước: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                    lstHDTemp.Add(_cHoaDon.Get(item.Text));
                }

                try
                {
                    _cHoaDon.BeginTransaction();
                    while (lstHDTemp.Count > 0)
                    {
                        TT_DongNuoc dongnuoc = new TT_DongNuoc();
                        dongnuoc.DanhBo = lstHDTemp[0].DANHBA;
                        dongnuoc.HoTen = lstHDTemp[0].TENKH;
                        dongnuoc.DiaChi = lstHDTemp[0].SO + " " + lstHDTemp[0].DUONG;
                        dongnuoc.MLT = lstHDTemp[0].MALOTRINH;

                        TT_CTDongNuoc ctdongnuoc = new TT_CTDongNuoc();
                        ctdongnuoc.MaDN = dongnuoc.MaDN;
                        ctdongnuoc.MaHD = lstHDTemp[0].ID_HOADON;
                        ctdongnuoc.SoHoaDon = lstHDTemp[0].SOHOADON;
                        ctdongnuoc.Ky = lstHDTemp[0].KY + "/" + lstHDTemp[0].NAM;
                        ctdongnuoc.TieuThu = (int)lstHDTemp[0].TIEUTHU;
                        ctdongnuoc.GiaBan = (int)lstHDTemp[0].GIABAN;
                        ctdongnuoc.ThueGTGT = (int)lstHDTemp[0].THUE;
                        ctdongnuoc.PhiBVMT = (int)lstHDTemp[0].PHI;
                        ctdongnuoc.TongCong = (int)lstHDTemp[0].TONGCONG;
                        ctdongnuoc.CreateBy = CNguoiDung.MaND;
                        ctdongnuoc.CreateDate = DateTime.Now;

                        dongnuoc.TT_CTDongNuocs.Add(ctdongnuoc);

                        for (int j = 1; j < lstHDTemp.Count; j++)
                            if (lstHDTemp[0].DANHBA == lstHDTemp[j].DANHBA)
                            {
                                TT_CTDongNuoc ctdongnuoc2 = new TT_CTDongNuoc();
                                ctdongnuoc2.MaDN = dongnuoc.MaDN;
                                ctdongnuoc2.MaHD = lstHDTemp[j].ID_HOADON;
                                ctdongnuoc2.SoHoaDon = lstHDTemp[j].SOHOADON;
                                ctdongnuoc2.Ky = lstHDTemp[j].KY + "/" + lstHDTemp[j].NAM;
                                ctdongnuoc2.TieuThu = (int)lstHDTemp[j].TIEUTHU;
                                ctdongnuoc2.GiaBan = (int)lstHDTemp[j].GIABAN;
                                ctdongnuoc2.ThueGTGT = (int)lstHDTemp[j].THUE;
                                ctdongnuoc2.PhiBVMT = (int)lstHDTemp[j].PHI;
                                ctdongnuoc2.TongCong = (int)lstHDTemp[j].TONGCONG;
                                ctdongnuoc2.CreateBy = CNguoiDung.MaND;
                                ctdongnuoc2.CreateDate = DateTime.Now;

                                dongnuoc.TT_CTDongNuocs.Add(ctdongnuoc2);
                            }

                        if (_cDongNuoc.ThemDN(dongnuoc))
                        {
                            for (int i = lstHDTemp.Count - 1; i >= 0; i--)
                                if (lstHDTemp[i].DANHBA == dongnuoc.DanhBo)
                                {
                                    lstHDTemp.RemoveAt(i);
                                }
                        }
                    }
                    _cHoaDon.CommitTransaction();
                    lstHD.Items.Clear();
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    _cHoaDon.Rollback();
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa Toàn Bộ Lệnh?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        _cDongNuoc.SqlBeginTransaction();

                        for (int i = 0; i < gridViewDN.SelectedRowsCount; i++)
                            if (gridViewDN.GetSelectedRows()[i] >= 0)
                                if (!_cDongNuoc.CheckExist_KQDongNuoc(decimal.Parse(gridViewDN.GetDataRow(gridViewDN.GetSelectedRows()[i])["MaDN"].ToString())))
                                    if (!_cDongNuoc.Xoa(decimal.Parse(gridViewDN.GetDataRow(gridViewDN.GetSelectedRows()[i])["MaDN"].ToString())))
                                    {
                                        _cHoaDon.SqlRollbackTransaction();
                                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }

                        _cDongNuoc.SqlCommitTransaction();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        _cHoaDon.SqlRollbackTransaction();
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                gridControl.DataSource = _cDongNuoc.GetDSByCreateByCreateDates(CNguoiDung.TenTo, CNguoiDung.MaND, dateTu.Value, dateDen.Value).Tables["DongNuoc"];
            }
        }

        private void btnInTB_Click(object sender, EventArgs e)
        {
            //PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == DialogResult.OK)
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
                        dr["MaDN"] = item["MaDN"].ToString().Insert(item["MaDN"].ToString().Length - 2, "-");
                        dr["ThemHoaDon"] = item["ThemHoaDon"];
                        dr["HoTen"] = item["HoTen"];
                        dr["DiaChi"] = item["DiaChi"];
                        dr["DienThoai"] = _cDocSo.GetDienThoai(item["DanhBo"].ToString());
                        if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                        {
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                            TB_DULIEUKHACHHANG ttkh = _cDocSo.GetTTKH(item["DanhBo"].ToString());
                            if(ttkh!=null)
                            dr["DiaChiDHN"] = ttkh.SONHA + " " + ttkh.TENDUONG;
                        }
                        dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = Ky;
                        dr["TongCong"] = TongCong;
                        dr["NhanVien"] = CNguoiDung.HoTen;
                        if (!string.IsNullOrEmpty(item["CreateBy"].ToString()))
                            dr["NhanVienDN"] = _cNguoiDung.GetDienThoaiByMaND(int.Parse(item["CreateBy"].ToString()));
                        if (!string.IsNullOrEmpty(item["MaNV_DongNuoc"].ToString()))
                            dr["NhanVienDN"] = _cNguoiDung.GetDienThoaiByMaND(int.Parse(item["MaNV_DongNuoc"].ToString()));
                        if (chkChuKy.Checked)
                            dr["ChuKy"] = true;
                        if (chkCoTenNguoiKy.Checked)
                            dr["NguoiKy"] = "Nguyễn Ngọc Ẩn";

                        dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);

                        //ReportDocument rpt = new ReportDocument();
                        //if (radA4.Checked == true)
                        //    rpt = new rptTBDongNuocPhotoA4();
                        //else
                        //    if (radA5.Checked == true)
                        //        rpt = new rptTBDongNuocPhotoA5();
                        //rpt.SetDataSource(dsBaoCao);

                        //printDialog.AllowSomePages = true;
                        //printDialog.ShowHelp = true;

                        //rpt.PrintOptions.PaperOrientation = rpt.PrintOptions.PaperOrientation;
                        //rpt.PrintOptions.PaperSize = rpt.PrintOptions.PaperSize;
                        //rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                        //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, true, 0, 0);
                        //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                    }
                ReportDocument rpt = new ReportDocument();
                if (radA4.Checked == true)
                    rpt = new rptTBDongNuocPhotoA4();
                else
                    if (radA5.Checked == true)
                        rpt = new rptTBDongNuocPhotoA5();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
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
        }

        private void gridViewDN_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
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

        private void btnDSTB_Click(object sender, EventArgs e)
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
                    dr["NhanVien"] = CNguoiDung.HoTen;
                    dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                }
            }
            rptDSHDDongNuoc rpt = new rptDSHDDongNuoc();
            rpt.SetDataSource(dsBaoCao);
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

        private void btnThemDN_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (!string.IsNullOrEmpty(txtMaDN.Text.Trim()) && _cDongNuoc.CheckExist_DongNuoc(decimal.Parse(txtMaDN.Text.Trim().Replace("-", ""))))
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
                        if (_cDongNuoc.CheckExist_CTDongNuoc(item.Text))
                        {
                            MessageBox.Show("Hóa Đơn đã Lập TB Đóng Nước: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            item.Selected = true;
                            item.Focused = true;
                            return;
                        }
                    }

                    TT_DongNuoc dongnuoc = _cDongNuoc.GetDongNuocByMaDN(decimal.Parse(txtMaDN.Text.Trim().Replace("-", "")));
                    foreach (ListViewItem item in lstHD.Items)
                    {
                        HOADON hoadon = _cHoaDon.Get(item.Text);
                        TT_CTDongNuoc ctdongnuoc = new TT_CTDongNuoc();
                        ctdongnuoc.MaDN = dongnuoc.MaDN;
                        ctdongnuoc.MaHD = hoadon.ID_HOADON;
                        ctdongnuoc.SoHoaDon = hoadon.SOHOADON;
                        ctdongnuoc.Ky = hoadon.KY + "/" + hoadon.NAM;
                        ctdongnuoc.TieuThu = (int)hoadon.TIEUTHU;
                        ctdongnuoc.GiaBan = (int)hoadon.GIABAN;
                        ctdongnuoc.ThueGTGT = (int)hoadon.THUE;
                        ctdongnuoc.PhiBVMT = (int)hoadon.PHI;
                        ctdongnuoc.TongCong = (int)hoadon.TONGCONG;
                        ctdongnuoc.CreateBy = CNguoiDung.MaND;
                        ctdongnuoc.CreateDate = DateTime.Now;

                        dongnuoc.TT_CTDongNuocs.Add(ctdongnuoc);
                    }
                    if (_cDongNuoc.SuaDN(dongnuoc))
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInGiayXN_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
            foreach (DataRow item in dt.Rows)
                if (bool.Parse(item["In"].ToString()))
                {
                    string Ky = "";
                    int TongCong = 0;
                    List<HOADON> lstHD = null;
                    if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                        lstHD = _cHoaDon.GetDSTon(item["DanhBo"].ToString());
                    if (lstHD != null)
                    {
                        foreach (HOADON itemHD in lstHD)
                        {
                            if (string.IsNullOrEmpty(Ky))
                                Ky += itemHD.KY + "/" + itemHD.NAM;
                            else
                                Ky += ", " + itemHD.KY + "/" + itemHD.NAM;
                            TongCong += (int)itemHD.TONGCONG;
                        }

                        DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                        dr["DiaChi"] = item["DiaChi"];
                        if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["Ky"] = Ky;
                        dr["SoTien"] = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);

                        dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                    }
                }
            rptGiayXacNhanNoKhoDoi rpt = new rptGiayXacNhanNoKhoDoi();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void gridViewDN_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (gridViewDN.RowCount > 0&&e.RowHandle>=0)
            {
                if (bool.Parse(gridViewDN.GetRowCellValue(e.RowHandle, "ThemHoaDon").ToString()) == true)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                else
                {
                    //e.Appearance.BackColor = Color.LightGreen;
                }

                //Override any other formatting
                e.HighPriority = true;      
            }
        }

        private void gridViewCTDN_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell)
            {
                e.Allow = false;
                popupMenu1.ShowPopup(gridControl.PointToScreen(e.Point));
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_selectedRow != null)
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa Hóa Đơn " + _selectedRow["Ky"].ToString()+"?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        try
                        {
                            TT_CTDongNuoc en = _cDongNuoc.getCTDongNuoc(decimal.Parse(_selectedRow["MaDN"].ToString()), int.Parse(_selectedRow["MaHD"].ToString()));
                            if(en!=null)
                                if(_cDongNuoc.XoaCT(en)==true)
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridViewCTDN_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridView = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _selectedRow = (DataRowView)gridView.GetRow(gridView.GetSelectedRows()[0]);
        }


    }
}
