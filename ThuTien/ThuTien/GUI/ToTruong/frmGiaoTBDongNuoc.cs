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

namespace ThuTien.GUI.ToTruong
{
    public partial class frmGiaoTBDongNuoc : Form
    {
        string _mnu = "mnuGiaoTBDongNuoc";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDongNuoc _cDongNuoc = new CDongNuoc();

        public frmGiaoTBDongNuoc()
        {
            InitializeComponent();
        }

        private void frmGiaoTBDongNuoc_Load(object sender, EventArgs e)
        {
            cmbNhanVienLap.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
            cmbNhanVienLap.DisplayMember = "HoTen";
            cmbNhanVienLap.ValueMember = "MaND";

            cmbNhanVienGiao.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
            cmbNhanVienGiao.DisplayMember = "HoTen";
            cmbNhanVienGiao.ValueMember = "MaND";

            lbTo.Text = "Tổ  " + CNguoiDung.TenTo;

            gridControl.LevelTree.Nodes.Add("Chi Tiết Đóng Nước", gridViewCTDN);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbNhanVienLap.SelectedIndex != -1 && dateTu.Value <= dateDen.Value)
            {
                gridControl.DataSource = _cDongNuoc.GetDSByMaNVCreateDates(int.Parse(cmbNhanVienLap.SelectedValue.ToString()), dateTu.Value, dateDen.Value).Tables["DongNuoc"];
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
                        if (!_cDongNuoc.XoaGiaoDongNuoc(decimal.Parse(item["MaDN"].ToString())))
                        {
                            if (!_cDongNuoc.GiaoDongNuoc(decimal.Parse(item["MaDN"].ToString()), int.Parse(cmbNhanVienGiao.SelectedValue.ToString())))
                            {
                                _cDongNuoc.SqlRollbackTransaction();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    _cDongNuoc.SqlCommitTransaction();
                    gridControl.DataSource = _cDongNuoc.GetDSByMaNVCreateDates(int.Parse(cmbNhanVienLap.SelectedValue.ToString()), dateTu.Value, dateDen.Value).Tables["DongNuoc"];
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
                    DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
                    foreach (DataRow item in dt.Rows)
                        if (!_cDongNuoc.CheckKQDongNuocByMaDNMaNV_DongNuoc(decimal.Parse(item["MaDN"].ToString()), int.Parse(item["MaNV_DongNuoc"].ToString())))
                        {
                            if (!_cDongNuoc.XoaGiaoDongNuoc(decimal.Parse(item["MaDN"].ToString())))
                            {
                                _cDongNuoc.SqlRollbackTransaction();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    _cDongNuoc.SqlCommitTransaction();
                    gridControl.DataSource = _cDongNuoc.GetDSByMaNVCreateDates(int.Parse(cmbNhanVienLap.SelectedValue.ToString()), dateTu.Value, dateDen.Value).Tables["DongNuoc"];
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
    }
}
