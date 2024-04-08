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
using CrystalDecisions.CrystalReports.Engine;
using ThuTien.DAL.Doi;
using DevExpress.XtraGrid.Views.Grid;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmGiaoTBDongNuoc2020 : Form
    {
        string _mnu = "mnuGiaoTBDongNuoc";
        CTo _cTo = new CTo();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        List<TT_NguoiDung> _lstND = new List<TT_NguoiDung>();
        CDHN _cDocSo = new CDHN();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CHoaDon _cHoaDon = new CHoaDon();
        CThuongVu _cKinhDoanh = new CThuongVu();
        CDHN _cDHN = new CDHN();
        DataRowView _selectedRow = null;

        public frmGiaoTBDongNuoc2020()
        {
            InitializeComponent();
        }

        private void frmGiaoTBDongNuoc_Load(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi || (CNguoiDung.ToTruong && _cNguoiDung.GetByMaND(CNguoiDung.MaND).DongNuoc))
            {
                cmbTo.DataSource = _cTo.getDS_HanhThu(CNguoiDung.IDPhong);
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
                cmbTo.Visible = true;
                btnXoaLenh.Visible = true;
            }
            else
            {
                if (CNguoiDung.ToTruong)
                    btnXoaLenh.Visible = true;
                else
                    btnXoaLenh.Visible = false;
                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = -1;
                nguoidung.HoTen = "Tất cả";
                _lstND = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
                _lstND.Insert(0, nguoidung);
                cmbNhanVienLap.DataSource = _lstND;
                cmbNhanVienLap.DisplayMember = "HoTen";
                cmbNhanVienLap.ValueMember = "MaND";
                cmbTo.Visible = false;
                lbTo.Text = "Tổ: " + CNguoiDung.TenTo;
            }
            gridControl.LevelTree.Nodes.Add("Chi Tiết Đóng Nước", gridViewCTDN);

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            cmbNhanVienGiao.DataSource = _cNguoiDung.getDS_DongNuoc(CNguoiDung.IDPhong);
            cmbNhanVienGiao.DisplayMember = "HoTen";
            cmbNhanVienGiao.ValueMember = "MaND";
            cmbToCapNhat.DataSource = _cTo.getDS_HanhThu(CNguoiDung.IDPhong);
            cmbToCapNhat.ValueMember = "MaTo";
            cmbToCapNhat.DisplayMember = "TenTo";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            if (CNguoiDung.Doi == true)
            {
                if (cmbNhanVienLap.SelectedIndex == 0 && dateTu.Value <= dateDen.Value)
                {
                    for (int i = 1; i < _lstND.Count; i++)
                        if (ds == null)
                            ds = _cDongNuoc.GetDSByCreateByCreateDates(((TT_To)cmbTo.SelectedItem).TenTo, _lstND[i].MaND, dateTu.Value, dateDen.Value);
                        else
                            ds.Merge(_cDongNuoc.GetDSByCreateByCreateDates(((TT_To)cmbTo.SelectedItem).TenTo, _lstND[i].MaND, dateTu.Value, dateDen.Value));
                }
                else
                    if (cmbNhanVienLap.SelectedIndex > 0 && dateTu.Value <= dateDen.Value)
                        ds = _cDongNuoc.GetDSByCreateByCreateDates(((TT_To)cmbTo.SelectedItem).TenTo, int.Parse(cmbNhanVienLap.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
            }
            else
            {
                if (cmbNhanVienLap.SelectedIndex == 0 && dateTu.Value <= dateDen.Value)
                {
                    for (int i = 1; i < _lstND.Count; i++)
                        if (ds == null)
                            ds = _cDongNuoc.GetDSByCreateByCreateDates(CNguoiDung.TenTo, _lstND[i].MaND, dateTu.Value, dateDen.Value);
                        else
                            ds.Merge(_cDongNuoc.GetDSByCreateByCreateDates(CNguoiDung.TenTo, _lstND[i].MaND, dateTu.Value, dateDen.Value));
                }
                else
                    if (cmbNhanVienLap.SelectedIndex > 0 && dateTu.Value <= dateDen.Value)
                        ds = _cDongNuoc.GetDSByCreateByCreateDates(CNguoiDung.TenTo, int.Parse(cmbNhanVienLap.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
            }
            gridControl.DataSource = ds.Tables["DongNuoc"];
            ///Kiểm Tra Tình Trạng, Giải Trách hết Hóa Đơn trong Thông Báo Đóng Nước mới tính
            for (int i = 0; i < gridViewDN.DataRowCount; i++)
            {
                DataRow row = gridViewDN.GetDataRow(i);
                DataRow[] childRows = row.GetChildRows("Chi Tiết Đóng Nước");
                string TinhTrang = "Tồn";
                //if (_cDongNuoc.CheckExist_KQDongNuoc(int.Parse(row["MaDN"].ToString()), dateDen.Value.Date))
                if (row["MaKQDN"].ToString() != "")
                {
                    TinhTrang = "Đã Khóa Nước";
                }
                else
                {
                    int DangNgan = 0;
                    int ThuHo = 0;
                    foreach (DataRow itemChild in childRows)
                    {
                        //DateTime NgayGiaiTrach;
                        //DateTime.TryParse(itemChild["NgayGiaiTrach"].ToString(), out NgayGiaiTrach);
                        ///xét ngày đăng ngân để lấy tồn lùi
                        if (!string.IsNullOrEmpty(itemChild["NgayGiaiTrach"].ToString()))// && NgayGiaiTrach.Date <= dateDen.Value.Date)
                        {
                            //TinhTrang = "Đăng Ngân";
                            DangNgan++;
                        }
                        else
                            if (!string.IsNullOrEmpty(itemChild["NgayGiaiTrach"].ToString()))
                                ThuHo++;
                    }
                    if (DangNgan == childRows.Count())
                        TinhTrang = "Đăng Ngân";
                    else
                        if (ThuHo == childRows.Count())
                            TinhTrang = "Thu Hộ";
                }
                gridViewDN.SetRowCellValue(i, "TinhTrang", TinhTrang);
                TB_DULIEUKHACHHANG ttkh = _cDHN.get(gridViewDN.GetRowCellValue(i, "DanhBo").ToString());
                if (ttkh != null)
                {
                    gridViewDN.SetRowCellValue(i, "ViTriDHN", ttkh.VITRIDHN);
                    gridViewDN.SetRowCellValue(i, "ViTriDHN_Hop", ttkh.ViTriDHN_Hop);
                    gridViewDN.SetRowCellValue(i, "ViTriDHN_Ngoai", ttkh.ViTriDHN_Ngoai);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    //_cDongNuoc.SqlBeginTransaction();
                    DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
                    foreach (DataRow item in dt.Rows)
                        if (bool.Parse(item["In"].ToString()))
                            //if ((!CNguoiDung.Admin || !CNguoiDung.Doi || !CNguoiDung.ToTruong) && _cDongNuoc.countDongNuoc(decimal.Parse(item["MaDN"].ToString())) > 140)
                            //{
                            //    MessageBox.Show("Vượt quá 140 lệnh đã giao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                            //else
                            if (!_cDongNuoc.GiaoDongNuoc(decimal.Parse(item["MaDN"].ToString()), int.Parse(cmbNhanVienGiao.SelectedValue.ToString())))
                            {
                                //_cDongNuoc.SqlRollbackTransaction();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                    //_cDongNuoc.SqlCommitTransaction();
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                //_cDongNuoc.SqlRollbackTransaction();
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    //_cDongNuoc.SqlBeginTransaction();
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
                        foreach (DataRow item in dt.Rows)
                            if (bool.Parse(item["In"].ToString()))
                            {
                                if (item["MaNV_DongNuoc"].ToString() != "" && _cDongNuoc.CheckExist_KQDongNuoc(decimal.Parse(item["MaDN"].ToString()), int.Parse(item["MaNV_DongNuoc"].ToString())) == false)
                                {
                                    if (_cDongNuoc.XoaGiaoDongNuoc(decimal.Parse(item["MaDN"].ToString())) == false)
                                    {
                                        //_cDongNuoc.SqlRollbackTransaction();
                                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        //DevExpress.XtraGrid.Views.Grid.GridView gv = ((DevExpress.XtraGrid.Views.Grid.GridView)gridControl.DefaultView);
                        //int[] rows = gv.GetSelectedRows();
                        //foreach (int i in rows)
                        //    if (!_cDongNuoc.CheckExist_KQDongNuoc(decimal.Parse(gv.GetDataRow(i)["MaDN"].ToString()), int.Parse(gv.GetDataRow(i)["MaNV_DongNuoc"].ToString())))
                        //    {
                        //        if (!_cDongNuoc.XoaGiaoDongNuoc(decimal.Parse(gv.GetDataRow(i)["MaDN"].ToString())))
                        //        {
                        //            _cDongNuoc.SqlRollbackTransaction();
                        //            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            return;
                        //        }
                        //    }
                        //_cDongNuoc.SqlCommitTransaction();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridControl.DataSource = _cDongNuoc.GetDSByCreateByCreateDates(CNguoiDung.TenTo, int.Parse(cmbNhanVienLap.SelectedValue.ToString()), dateTu.Value, dateDen.Value).Tables["DongNuoc"];
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                //_cDongNuoc.SqlRollbackTransaction();
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (e.Column.FieldName == "TongCongLenh" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            //if (e.Column.FieldName == "CreateBy" && !string.IsNullOrEmpty(e.Value.ToString()))
            //{
            //    e.DisplayText = _cNguoiDung.GetHoTenByMaND(int.Parse(e.Value.ToString()));
            //}
            //if (e.Column.FieldName == "MaNV_DongNuoc" && !string.IsNullOrEmpty(e.Value.ToString()))
            //{
            //    e.DisplayText = _cNguoiDung.GetHoTenByMaND(int.Parse(e.Value.ToString()));
            //}
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
                DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
                //for (int i = 0; i < gridViewDN.DataRowCount; i++)
                foreach (DataRow item in dt.Rows)
                    if (bool.Parse(item["In"].ToString()))
                    {
                        //DataRow row = gridViewDN.GetDataRow(i);
                        DataRow[] childRows = item.GetChildRows("Chi Tiết Đóng Nước");
                        foreach (DataRow itemChild in childRows)
                        {
                            DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                            dr["Loai"] = "CHUYỂN";
                            dr["MaDN"] = item["MaDN"].ToString().Insert(item["MaDN"].ToString().Length - 2, "-");
                            dr["To"] = item["TenTo"];
                            dr["HoTen"] = item["HoTen"];
                            dr["DiaChi"] = item["DiaChi"];
                            if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                                dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                            dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                            dr["Ky"] = itemChild["Ky"];
                            dr["TongCong"] = itemChild["TongCong"];
                            dr["NhanVien"] = cmbNhanVienLap.Text;
                            dr["HanhThu"] = item["HanhThu"];
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
                            dr["To"] = row["TenTo"];
                            dr["HoTen"] = row["HoTen"];
                            dr["DiaChi"] = row["DiaChi"];
                            if (!string.IsNullOrEmpty(row["DanhBo"].ToString()))
                                dr["DanhBo"] = row["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                            dr["MLT"] = row["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                            dr["Ky"] = itemChild["Ky"];
                            dr["TongCong"] = itemChild["TongCong"];
                            dr["NhanVien"] = cmbNhanVienGiao.Text;
                            dr["HanhThu"] = row["HanhThu"];
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
                                dr["To"] = row["TenTo"];
                                dr["HoTen"] = row["HoTen"];
                                dr["DiaChi"] = row["DiaChi"];
                                if (!string.IsNullOrEmpty(row["DanhBo"].ToString()))
                                    dr["DanhBo"] = row["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["MLT"] = row["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                                dr["Ky"] = itemChild["Ky"];
                                dr["TongCong"] = itemChild["TongCong"];
                                dr["NhanVien"] = cmbNhanVienGiao.Text;
                                dr["HanhThu"] = row["HanhThu"];
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
                            Ky += itemChild["Ky"] + "  Số tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemChild["TongCong"]) + "; ";
                            TongCong += int.Parse(itemChild["TongCong"].ToString());
                        }
                        DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                        dr["Ngay"] = DateTime.Parse(item["CreateDate"].ToString()).Day.ToString("00");
                        dr["Thang"] = DateTime.Parse(item["CreateDate"].ToString()).Month.ToString("00");
                        dr["Nam"] = DateTime.Parse(item["CreateDate"].ToString()).Year.ToString("0000");
                        dr["MaDN"] = item["MaDN"].ToString().Insert(item["MaDN"].ToString().Length - 2, "-");
                        dr["ThemHoaDon"] = item["ThemHoaDon"];
                        dr["HoTen"] = item["HoTen"];
                        dr["DiaChi"] = item["DiaChi"];
                        dr["DienThoai"] = _cDocSo.getDienThoai(item["DanhBo"].ToString());
                        if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                        {
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                            TB_DULIEUKHACHHANG ttkh = _cDocSo.get(item["DanhBo"].ToString());
                            if (ttkh != null)
                                dr["DiaChiDHN"] = ttkh.SONHA + " " + ttkh.TENDUONG;
                        }
                        dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = Ky;
                        dr["TongCong"] = TongCong;
                        dr["NhanVien"] = _cNguoiDung.GetHoTenByMaND(int.Parse(item["CreateBy"].ToString()));
                        if (!string.IsNullOrEmpty(item["CreateBy"].ToString()))
                            dr["NhanVienDN"] = _cNguoiDung.GetDienThoaiByMaND(int.Parse(item["CreateBy"].ToString()));
                        if (!string.IsNullOrEmpty(item["MaNV_DongNuoc"].ToString()))
                            dr["NhanVienDN"] = _cNguoiDung.GetDienThoaiByMaND(int.Parse(item["MaNV_DongNuoc"].ToString()));
                        if (chkChuKy.Checked)
                        {
                            dr["ChuKy"] = CNguoiDung.ChuKy;
                        }
                        if (chkCoTenNguoiKy.Checked)
                        {
                            dr["ChucVu"] = CNguoiDung.ChucVu;
                            dr["NguoiKy"] = CNguoiDung.NguoiKy;
                        }
                        dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                        //ReportDocument rpt = new ReportDocument();
                        //if(radA4.Checked==true)
                        // rpt = new rptTBDongNuocPhotoA4();
                        //else
                        //    if(radA5.Checked==true)
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
                            if (string.IsNullOrEmpty(itemChild["NgayGiaiTrach"].ToString()) && _cLenhHuy.CheckExist(itemChild["SoHoaDon"].ToString()) == false)
                            {
                                DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                                dr["Loai"] = "CHUYỂN CÒN TỒN";
                                dr["MaDN"] = row["MaDN"].ToString().Insert(row["MaDN"].ToString().Length - 2, "-");
                                dr["To"] = row["TenTo"];
                                dr["HoTen"] = row["HoTen"];
                                dr["DiaChi"] = row["DiaChi"];
                                if (!string.IsNullOrEmpty(row["DanhBo"].ToString()))
                                    dr["DanhBo"] = row["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["MLT"] = row["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                                dr["Ky"] = itemChild["Ky"];
                                dr["TongCong"] = itemChild["TongCong"];
                                dr["NhanVien"] = cmbNhanVienGiao.Text;
                                dr["HanhThu"] = row["HanhThu"];

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
                    dr["HanhThu"] = row["HanhThu"];
                    dr["To"] = row["TenTo"];

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

        private void cmbToCapNhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbToCapNhat.SelectedIndex > -1)
            {
                cmbNhanVien.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(((TT_To)cmbToCapNhat.SelectedItem).MaTo);
                cmbNhanVien.ValueMember = "MaND";
                cmbNhanVien.DisplayMember = "HoTen";
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
                    foreach (DataRow item in dt.Rows)
                        if (bool.Parse(item["In"].ToString()))
                        {
                            TT_DongNuoc dn = _cDongNuoc.GetDongNuocByMaDN(decimal.Parse(item["MaDN"].ToString()));
                            dn.CreateBy_Old = dn.CreateBy;
                            dn.CreateBy = ((TT_NguoiDung)cmbNhanVien.SelectedItem).MaND;
                            dn.CreateDate_MaNV_DongNuoc = DateTime.Now;
                            _cDongNuoc.SuaDN(dn);
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CNguoiDung.Doi == true || (CNguoiDung.ToTruong && _cNguoiDung.GetByMaND(CNguoiDung.MaND).DongNuoc)) && cmbTo.SelectedIndex >= 0)
            {
                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = -1;
                nguoidung.HoTen = "Tất cả";
                _lstND = _cNguoiDung.GetDSHanhThuByMaTo(((TT_To)cmbTo.SelectedItem).MaTo);
                _lstND.Insert(0, nguoidung);
                cmbNhanVienLap.DataSource = _lstND;
                cmbNhanVienLap.DisplayMember = "HoTen";
                cmbNhanVienLap.ValueMember = "MaND";

                cmbNhanVienGiao.DataSource = _cNguoiDung.getDS_DongNuoc(CNguoiDung.IDPhong);
                cmbNhanVienGiao.DisplayMember = "HoTen";
                cmbNhanVienGiao.ValueMember = "MaND";
            }
        }

        private void gridViewDN_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (gridViewDN.RowCount > 0 && e.RowHandle >= 0)
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

        private void btnInTBTrang_Click(object sender, EventArgs e)
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
                        Ky += itemChild["Ky"] + "  Số tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemChild["TongCong"]) + "; ";
                        TongCong += int.Parse(itemChild["TongCong"].ToString());
                    }

                    DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                    dr["MaDN"] = item["MaDN"].ToString().Insert(item["MaDN"].ToString().Length - 2, "-");
                    dr["ThemHoaDon"] = item["ThemHoaDon"];
                    dr["HoTen"] = item["HoTen"];
                    dr["DiaChi"] = item["DiaChi"];
                    dr["DienThoai"] = _cDocSo.getDienThoai(item["DanhBo"].ToString());
                    if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                    {
                        dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        TB_DULIEUKHACHHANG ttkh = _cDocSo.get(item["DanhBo"].ToString());
                        if (ttkh != null)
                        {
                            dr["DiaChiDHN"] = ttkh.SONHA + " " + ttkh.TENDUONG;
                            dr["SoTien"] = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cDongNuoc.GetPhiMoNuoc(int.Parse(ttkh.CODH)));
                        }
                    }
                    dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                    dr["Ky"] = Ky;
                    dr["TongCong"] = TongCong;
                    dr["NhanVien"] = _cNguoiDung.GetHoTenByMaND(int.Parse(item["CreateBy"].ToString()));
                    if (!string.IsNullOrEmpty(item["CreateBy"].ToString()))
                        dr["NhanVienDN"] = _cNguoiDung.GetDienThoaiByMaND(int.Parse(item["CreateBy"].ToString()));
                    if (!string.IsNullOrEmpty(item["MaNV_DongNuoc"].ToString()))
                        dr["NhanVienDN"] = _cNguoiDung.GetDienThoaiByMaND(int.Parse(item["MaNV_DongNuoc"].ToString()));
                    if (chkChuKy.Checked)
                    {
                        dr["ChuKy"] = CNguoiDung.ChuKy;
                    }
                    if (chkCoTenNguoiKy.Checked)
                    {
                        dr["ChucVu"] = CNguoiDung.ChucVu;
                        dr["NguoiKy"] = CNguoiDung.NguoiKy;
                    }
                    dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                    //ReportDocument rpt = new ReportDocument();
                    //if(radA4.Checked==true)
                    // rpt = new rptTBDongNuocPhotoA4();
                    //else
                    //    if(radA5.Checked==true)
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
                rpt = new rptTBDongNuocA4();
            else
                if (radA5.Checked == true)
                    rpt = new rptTBDongNuocA5();
            DataRow dr1 = dsBaoCao.Tables["DSHoaDon"].NewRow();
            dr1["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
            dsBaoCao.Tables["DSHoaDon"].Rows.Add(dr1);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnExcelTon_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            for (int i = 0; i < gridViewDN.DataRowCount; i++)
                if (gridViewDN.GetDataRow(i)["TinhTrang"].ToString() != "Đăng Ngân")
                {
                    DataRow row = gridViewDN.GetDataRow(i);
                    DataRow[] childRows = row.GetChildRows("Chi Tiết Đóng Nước");
                    string Ky = "";
                    int TongCong = 0;
                    foreach (DataRow itemChild in childRows)
                        if (_cHoaDon.CheckDangNganByMaHD(int.Parse(itemChild["MaHD"].ToString())) == false)
                        {
                            if (Ky != "")
                                Ky += "; " + itemChild["Ky"];
                            else
                                Ky += itemChild["Ky"];
                            TongCong += int.Parse(itemChild["TongCong"].ToString());
                        }
                    DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                    dr["HoTen"] = row["HoTen"];
                    dr["DiaChi"] = row["DiaChi"];
                    if (!string.IsNullOrEmpty(row["DanhBo"].ToString()))
                        dr["DanhBo"] = row["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["MLT"] = row["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                    dr["Ky"] = Ky;
                    dr["TongCong"] = TongCong;
                    HOADON hd = _cHoaDon.GetMoiNhat(row["DanhBo"].ToString());
                    dr["HanhThu"] = _cKinhDoanh.getPhuong(int.Parse(hd.Quan), int.Parse(hd.Phuong));
                    dr["To"] = _cKinhDoanh.getQuan(int.Parse(hd.Quan));
                    dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
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

            oSheet.Name = "DANH SÁCH TB ĐÓNG NƯỚC TỒN";
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "MLT";
            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Danh Bộ";
            cl2.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Khách Hàng";
            cl3.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Địa Chỉ";
            cl4.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "Kỳ";
            cl5.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
            cl6.Value2 = "Tổng Cộng";
            cl6.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
            cl7.Value2 = "Phường";
            cl7.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
            cl8.Value2 = "Quận";
            cl8.ColumnWidth = 10;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dsBaoCao.Tables["TBDongNuoc"].Rows.Count, 8];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dsBaoCao.Tables["TBDongNuoc"].Rows.Count; i++)
            {
                DataRow dr = dsBaoCao.Tables["TBDongNuoc"].Rows[i];

                arr[i, 0] = dr["MLT"].ToString();
                arr[i, 1] = dr["DanhBo"].ToString();
                arr[i, 2] = dr["HoTen"].ToString();
                arr[i, 3] = dr["DiaChi"].ToString();
                arr[i, 4] = dr["Ky"].ToString();
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
            c3d.NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            c3e.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            c3e.NumberFormat = "@";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void gridViewCTDN_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell)
            {
                e.Allow = false;
                GridView gridView = (GridView)gridControl.GetViewAt(e.Point);
                _selectedRow = (DataRowView)gridView.GetRow(gridView.GetSelectedRows()[0]);
                popupMenu1.ShowPopup(gridControl.PointToScreen(e.Point));
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_selectedRow != null)
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa Hóa Đơn " + _selectedRow["Ky"].ToString() + "?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        try
                        {
                            TT_CTDongNuoc en = _cDongNuoc.getCTDongNuoc(decimal.Parse(_selectedRow["MaDN"].ToString()), int.Parse(_selectedRow["MaHD"].ToString()));
                            if (en != null)
                                if (_cDongNuoc.XoaCT(en) == true)
                                {
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btnXem.PerformClick();
                                }
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

        private void btnXoaLenh_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
                        foreach (DataRow item in dt.Rows)
                            if (bool.Parse(item["In"].ToString()))
                            {
                                if (!_cDongNuoc.CheckExist_KQDongNuoc(decimal.Parse(item["MaDN"].ToString())))
                                {
                                    if (!_cDongNuoc.Xoa(decimal.Parse(item["MaDN"].ToString())))
                                    {

                                    }
                                }
                                else
                                    MessageBox.Show("Có Đóng Nước không xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        MessageBox.Show("Đã xử lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnXem.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
