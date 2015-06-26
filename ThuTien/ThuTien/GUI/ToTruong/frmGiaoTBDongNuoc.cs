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
using KTKS_DonKH.GUI.BaoCao;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmGiaoTBDongNuoc : Form
    {
        string _mnu = "mnuGiaoTBDongNuoc";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        List<TT_NguoiDung> _lst=new List<TT_NguoiDung>();

        public frmGiaoTBDongNuoc()
        {
            InitializeComponent();
        }

        private void frmGiaoTBDongNuoc_Load(object sender, EventArgs e)
        {
            TT_NguoiDung nguoidung = new TT_NguoiDung();
            nguoidung.MaND = -1;
            nguoidung.HoTen = "Tất cả";
            _lst = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
            _lst.Insert(0, nguoidung);
            cmbNhanVienLap.DataSource = _lst;
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
            if (cmbNhanVienLap.SelectedIndex == 0 && dateTu.Value <= dateDen.Value)
            {
                DataSet ds = null;
                for (int i = 1; i < _lst.Count; i++)
                    if (ds == null)
                        ds = _cDongNuoc.GetDSByMaNVCreateDates(_lst[i].MaND, dateTu.Value, dateDen.Value);
                    else
                        ds.Merge(_cDongNuoc.GetDSByMaNVCreateDates(_lst[i].MaND, dateTu.Value, dateDen.Value));
                gridControl.DataSource = ds.Tables["DongNuoc"];
            }
            else
                if (cmbNhanVienLap.SelectedIndex > 0 && dateTu.Value <= dateDen.Value)
                    gridControl.DataSource = _cDongNuoc.GetDSByMaNVCreateDates(int.Parse(cmbNhanVienLap.SelectedValue.ToString()), dateTu.Value, dateDen.Value).Tables["DongNuoc"];
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
                    DevExpress.XtraGrid.Views.Grid.GridView gv=((DevExpress.XtraGrid.Views.Grid.GridView)gridControl.DefaultView);
                    int[] rows= gv.GetSelectedRows();
                    foreach (int i in rows)
                        if (!_cDongNuoc.CheckKQDongNuocByMaDNCreateBy(decimal.Parse(gv.GetDataRow(i)["MaDN"].ToString()), int.Parse(gv.GetDataRow(i)["MaNV_DongNuoc"].ToString())))
                        {
                            if (!_cDongNuoc.XoaGiaoDongNuoc(decimal.Parse(gv.GetDataRow(i)["MaDN"].ToString())))
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

        private void btnInDSTBNguoiLap_Click(object sender, EventArgs e)
        {
            if (cmbNhanVienLap.SelectedIndex > 0)
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
                foreach (DataRow item in dt.Rows)
                //if (bool.Parse(item["In"].ToString()))
                {
                    DataRow[] childRows = item.GetChildRows("Chi Tiết Đóng Nước");

                    foreach (DataRow itemChild in childRows)
                    {
                        DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                        dr["Loai"] = "CHUYỂN";
                        dr["MaDN"] = item["MaDN"].ToString().Insert(item["MaDN"].ToString().Length - 2, "-");
                        dr["To"] = CNguoiDung.TenTo;
                        dr["HoTen"] = item["HoTen"];
                        dr["DiaChi"] = item["DiaChi"];
                        if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["MLT"] = item["MLT"];
                        dr["Ky"] = itemChild["Ky"];
                        dr["SoTien"] = itemChild["TongCong"];
                        dr["NhanVien"] = cmbNhanVienLap.Text;
                        dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                    }
                }
                rptDSDongNuoc rpt = new rptDSDongNuoc();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void btnInDSTBNguoiGiao_Click(object sender, EventArgs e)
        {
            if (cmbNhanVienLap.SelectedIndex > -1)
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
                foreach (DataRow item in dt.Rows)
                if (item["MaNV_DongNuoc"].ToString()==cmbNhanVienGiao.SelectedValue.ToString())
                {
                    DataRow[] childRows = item.GetChildRows("Chi Tiết Đóng Nước");

                    foreach (DataRow itemChild in childRows)
                    {
                        DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                        dr["Loai"] = "NHẬN";
                        dr["MaDN"] = item["MaDN"].ToString().Insert(item["MaDN"].ToString().Length - 2, "-");
                        dr["To"] = CNguoiDung.TenTo;
                        dr["HoTen"] = item["HoTen"];
                        dr["DiaChi"] = item["DiaChi"];
                        if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["MLT"] = item["MLT"];
                        dr["Ky"] = itemChild["Ky"];
                        dr["SoTien"] = itemChild["TongCong"];
                        dr["NhanVien"] = cmbNhanVienGiao.Text;
                        dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                    }
                }
                rptDSDongNuoc rpt = new rptDSDongNuoc();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }
    }
}
