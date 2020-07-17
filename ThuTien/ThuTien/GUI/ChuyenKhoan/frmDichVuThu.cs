using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.Quay;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.Doi;
using System.Transactions;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmDichVuThu : Form
    {
        string _mnu = "mnuDichVuThu";
        CDichVuThu _cDichVuThu = new CDichVuThu();
        CTo _cTo = new CTo();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmDichVuThu()
        {
            InitializeComponent();
        }

        private void frmDichVuThu_Load(object sender, EventArgs e)
        {
            dgvDichVuThu.AutoGenerateColumns = false;

            DataTable dtDichVuThu = _cDichVuThu.GetDichVuThu();
            DataRow dr = dtDichVuThu.NewRow();
            dr["ID"] = "";
            dr["TenDichVu"] = "Tất Cả";
            dtDichVuThu.Rows.InsertAt(dr, 0);
            cmbDichVuThu.DataSource = dtDichVuThu;
            cmbDichVuThu.DisplayMember = "TenDichVu";
            cmbDichVuThu.ValueMember = "ID";

            List<TT_To> lstTo = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lstTo.Insert(0, to);
            cmbTo.DataSource = lstTo;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            cmbFromDot.SelectedIndex = 0;
            cmbToDot.SelectedIndex = 0;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")))
            {
                dgvDichVuThu.DataSource = _cDichVuThu.getDS(txtDanhBo.Text.Trim().Replace(" ", ""));
            }
            else
                if (chkKiemTraLenhHuy.Checked == false)
                {
                    ///xem đến kỳ
                    if (chkDenKy.Checked == true)
                    {
                        if (cmbFromDot.SelectedIndex == 0)
                        {
                            ///chọn tất cả tổ
                            if (cmbTo.SelectedIndex == 0)
                                dgvDichVuThu.DataSource = _cDichVuThu.getDS_DenKy(cmbDichVuThu.SelectedValue.ToString(), dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            ///chọn 1 tổ
                            else
                                ///chọn tất cả nhân viên
                                if (cmbNhanVien.SelectedIndex == 0)
                                    dgvDichVuThu.DataSource = _cDichVuThu.getDS_DenKy(cmbDichVuThu.SelectedValue.ToString(), int.Parse(cmbTo.SelectedValue.ToString()), dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                else
                                    ///chọn 1 nhân viên cụ thể
                                    if (cmbNhanVien.SelectedIndex > 0)
                                        dgvDichVuThu.DataSource = _cDichVuThu.getDS_DenKy_NV(cmbDichVuThu.SelectedValue.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString()), dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                        }
                        else
                            if (cmbFromDot.SelectedIndex > 0)
                            {
                                ///chọn tất cả tổ
                                if (cmbTo.SelectedIndex == 0)
                                    dgvDichVuThu.DataSource = _cDichVuThu.getDS_DenKy_Dot(cmbDichVuThu.SelectedValue.ToString(), dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                                ///chọn 1 tổ
                                else
                                    ///chọn tất cả nhân viên
                                    if (cmbNhanVien.SelectedIndex == 0)
                                        dgvDichVuThu.DataSource = _cDichVuThu.getDS_DenKy_Dot(cmbDichVuThu.SelectedValue.ToString(), int.Parse(cmbTo.SelectedValue.ToString()), dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                                    else
                                        ///chọn 1 nhân viên cụ thể
                                        if (cmbNhanVien.SelectedIndex > 0)
                                            dgvDichVuThu.DataSource = _cDichVuThu.getDS_DenKy_NV_Dot(cmbDichVuThu.SelectedValue.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString()), dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                            }
                    }
                    ///xem thời gian
                    else
                        if (cmbFromDot.SelectedIndex == 0)
                        {
                            ///chọn tất cả tổ
                            if (cmbTo.SelectedIndex == 0)
                                dgvDichVuThu.DataSource = _cDichVuThu.getDS(cmbDichVuThu.SelectedValue.ToString(), dateTu.Value, dateDen.Value);
                            ///chọn 1 tổ
                            else
                                ///chọn tất cả nhân viên
                                if (cmbNhanVien.SelectedIndex == 0)
                                    dgvDichVuThu.DataSource = _cDichVuThu.getDS(cmbDichVuThu.SelectedValue.ToString(), int.Parse(cmbTo.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
                                else
                                    ///chọn 1 nhân viên cụ thể
                                    if (cmbNhanVien.SelectedIndex > 0)
                                        dgvDichVuThu.DataSource = _cDichVuThu.getDS_NV(cmbDichVuThu.SelectedValue.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
                        }
                        else
                            if (cmbFromDot.SelectedIndex > 0)
                            {
                                ///chọn tất cả tổ
                                if (cmbTo.SelectedIndex == 0)
                                    dgvDichVuThu.DataSource = _cDichVuThu.getDS_Dot(cmbDichVuThu.SelectedValue.ToString(), dateTu.Value, dateDen.Value, int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                                ///chọn 1 tổ
                                else
                                    ///chọn tất cả nhân viên
                                    if (cmbNhanVien.SelectedIndex == 0)
                                        dgvDichVuThu.DataSource = _cDichVuThu.getDS_Dot(cmbDichVuThu.SelectedValue.ToString(), int.Parse(cmbTo.SelectedValue.ToString()), dateTu.Value, dateDen.Value, int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                                    else
                                        ///chọn 1 nhân viên cụ thể
                                        if (cmbNhanVien.SelectedIndex > 0)
                                            dgvDichVuThu.DataSource = _cDichVuThu.getDS_NV_Dot(cmbDichVuThu.SelectedValue.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString()), dateTu.Value, dateDen.Value, int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                            }
                }
                //lấy có lệnh hủy
                else
                {
                    if (cmbFromDot.SelectedIndex == 0)
                    {
                        ///chọn tất cả tổ
                        if (cmbTo.SelectedIndex == 0)
                            dgvDichVuThu.DataSource = _cDichVuThu.getDS_LenhHuy(cmbDichVuThu.SelectedValue.ToString(), dateTu.Value, dateDen.Value);
                        ///chọn 1 tổ
                        else
                            ///chọn tất cả nhân viên
                            if (cmbNhanVien.SelectedIndex == 0)
                                dgvDichVuThu.DataSource = _cDichVuThu.getDS_LenhHuy(cmbDichVuThu.SelectedValue.ToString(), int.Parse(cmbTo.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
                            else
                                ///chọn 1 nhân viên cụ thể
                                if (cmbNhanVien.SelectedIndex > 0)
                                    dgvDichVuThu.DataSource = _cDichVuThu.getDS_NV_LenhHuy(cmbDichVuThu.SelectedValue.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
                    }
                    else
                        if (cmbFromDot.SelectedIndex > 0)
                        {
                            ///chọn tất cả tổ
                            if (cmbTo.SelectedIndex == 0)
                                dgvDichVuThu.DataSource = _cDichVuThu.getDS_Dot_LenhHuy(cmbDichVuThu.SelectedValue.ToString(), dateTu.Value, dateDen.Value, int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                            ///chọn 1 tổ
                            else
                                ///chọn tất cả nhân viên
                                if (cmbNhanVien.SelectedIndex == 0)
                                    dgvDichVuThu.DataSource = _cDichVuThu.getDS_Dot_LenhHuy(cmbDichVuThu.SelectedValue.ToString(), int.Parse(cmbTo.SelectedValue.ToString()), dateTu.Value, dateDen.Value, int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                                else
                                    ///chọn 1 nhân viên cụ thể
                                    if (cmbNhanVien.SelectedIndex > 0)
                                        dgvDichVuThu.DataSource = _cDichVuThu.getDS_NV_Dot_LenhHuy(cmbDichVuThu.SelectedValue.ToString(), int.Parse(cmbNhanVien.SelectedValue.ToString()), dateTu.Value, dateDen.Value, int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                        }
                }

            long TongSoTien = 0;
            int TongPhi = 0;
            //DataTable dtPMN = new DataTable();
            //dtPMN.Columns.Add("DanhBo", typeof(string));
            string IDGiaoDich = "";

            foreach (DataGridViewRow item in dgvDichVuThu.Rows)
            {
                //string HoTen = "", TenTo = "";
                //if (_cDongNuoc.CheckExist_CTDongNuoc(item.Cells["SoHoaDon"].Value.ToString(), out HoTen, out TenTo))
                //{
                //    item.Cells["HanhThu"].Value = HoTen;
                //    item.Cells["To"].Value = TenTo;
                //    item.DefaultCellStyle.BackColor = Color.Yellow;
                //}

                //if (dtPMN.AsEnumerable().Any(itemPMN => itemPMN.Field<string>("DanhBo") == item.Cells["DanhBo"].Value.ToString()) == false)
                //{
                //    DataRow dr = dtPMN.NewRow();
                //    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString();
                //    dtPMN.Rows.Add(dr);
                //}

                if (chkKiemTraLenhHuy.Checked == false)
                {
                    if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                    {
                        item.DefaultCellStyle.BackColor = Color.Red;
                    }
                    if (bool.Parse(item.Cells["DongNuoc"].Value.ToString()) == true)
                    {
                        item.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    if (bool.Parse(item.Cells["LenhHuy"].Value.ToString()) == true)
                    {
                        item.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                if (item.Cells["SoTien"].Value != null && !string.IsNullOrEmpty(item.Cells["SoTien"].Value.ToString()))
                    TongSoTien += int.Parse(item.Cells["SoTien"].Value.ToString());

                if (item.Cells["Phi"].Value != null && !string.IsNullOrEmpty(item.Cells["Phi"].Value.ToString()) && item.Cells["Phi"].Value.ToString() != "0")
                {
                    if (IDGiaoDich == "")
                    {
                        IDGiaoDich = item.Cells["IDGiaoDich"].Value.ToString();
                        TongPhi += int.Parse(item.Cells["Phi"].Value.ToString());
                    }
                    else
                        if (IDGiaoDich == item.Cells["IDGiaoDich"].Value.ToString())
                            item.Cells["Phi"].Value = 0;
                        else
                        {
                            IDGiaoDich = item.Cells["IDGiaoDich"].Value.ToString();
                            TongPhi += int.Parse(item.Cells["Phi"].Value.ToString());
                        }
                }
            }
            txtTongHD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvDichVuThu.Rows.Count);
            txtTongSoTien.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongSoTien);
            txtTongPhi.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhi);
        }

        private void dgvDichVuThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "Phi" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDichVuThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDichVuThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (cmbNhanVien.SelectedIndex > 0 && ((TT_NguoiDung)(cmbNhanVien.SelectedItem)).DongNuoc == true)
            {
                foreach (DataGridViewRow item in dgvDichVuThu.Rows)
                    if (string.IsNullOrEmpty(item.Cells["NgayGiaiTrach"].Value.ToString()))
                    {
                        DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "DỊCH VỤ THU HỘ";
                        dr["GhiChu"] = "ĐỂ BIẾT, KHÔNG THU";
                        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                        dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                        dr["MLT"] = item.Cells["MLT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = item.Cells["Ky"].Value.ToString();
                        dr["TongCong"] = item.Cells["SoTien"].Value.ToString();
                        dr["NhanVien"] = item.Cells["HanhThu"].Value.ToString();
                        dr["HanhThu"] = _cHoaDon.GetHanhThu(item.Cells["SoHoaDon"].Value.ToString());
                        dr["To"] = item.Cells["To"].Value.ToString();
                        if (int.Parse(item.Cells["GiaBieu"].Value.ToString()) > 20)
                            dr["Loai"] = "CQ";
                        else
                            dr["Loai"] = "TG";
                        if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                            dr["LenhHuy"] = true;
                        ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
            }
            else
                foreach (DataGridViewRow item in dgvDichVuThu.Rows)
                    if (string.IsNullOrEmpty(item.Cells["NgayGiaiTrach"].Value.ToString()))
                    {
                        DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "DỊCH VỤ THU HỘ";
                        dr["GhiChu"] = "ĐỂ BIẾT, KHÔNG THU";
                        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                        dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                        dr["MLT"] = item.Cells["MLT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = item.Cells["Ky"].Value.ToString();
                        dr["TongCong"] = item.Cells["SoTien"].Value.ToString();
                        dr["HanhThu"] = item.Cells["HanhThu"].Value.ToString();
                        dr["To"] = item.Cells["To"].Value.ToString();
                        if (int.Parse(item.Cells["GiaBieu"].Value.ToString()) > 20)
                            dr["Loai"] = "CQ";
                        else
                            dr["Loai"] = "TG";
                        if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                            dr["LenhHuy"] = true;
                        ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
            rptDSTamThuChuyenKhoanDiaChi rpt = new rptDSTamThuChuyenKhoanDiaChi();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTo.SelectedIndex > 0)
            {
                List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo.SelectedValue.ToString()));
                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = 0;
                nguoidung.HoTen = "Tất Cả";
                lstND.Insert(0, nguoidung);
                cmbNhanVien.DataSource = lstND;
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            else
            {
                cmbNhanVien.DataSource = null;
            }
        }

        private void btnInKiemTra_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDichVuThu.Rows)
                if (!string.IsNullOrEmpty(item.Cells["NgayGiaiTrach"].Value.ToString()) && !bool.Parse(item.Cells["DangNgan_ChuyenKhoan"].Value.ToString()) && !bool.Parse(item.Cells["DangNgan_Quay"].Value.ToString()) && int.Parse(item.Cells["TieuThu"].Value.ToString()) != 0)
                {
                    DateTime NgayThu = new DateTime();
                    DateTime NgayGiaiTrach = new DateTime();
                    DateTime.TryParse(item.Cells["CreateDate"].Value.ToString(), out NgayThu);
                    DateTime.TryParse(item.Cells["NgayGiaiTrach"].Value.ToString(), out NgayGiaiTrach);
                    if (NgayThu.Date != NgayGiaiTrach.Date)
                    {
                        DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "KIỂM TRA DỊCH VỤ THU HỘ";
                        dr["GhiChu"] = "ĐỂ BIẾT, KHÔNG THU";
                        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                        dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                        dr["MLT"] = item.Cells["MLT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        dr["Ky"] = item.Cells["Ky"].Value.ToString();
                        dr["TongCong"] = item.Cells["SoTien"].Value.ToString();
                        dr["HanhThu"] = item.Cells["HanhThu"].Value.ToString();
                        dr["To"] = item.Cells["To"].Value.ToString();
                        if (int.Parse(item.Cells["GiaBieu"].Value.ToString()) > 20)
                            dr["Loai"] = "CQ";
                        else
                            dr["Loai"] = "TG";
                        dr["NganHang"] = item.Cells["TenDichVu"].Value.ToString();

                        if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                            dr["LenhHuy"] = true;
                        ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
                }
            rptDSDichVuThu rpt = new rptDSDichVuThu();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInDangNganHanhThu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDichVuThu.Rows)
                if (!string.IsNullOrEmpty(item.Cells["NgayGiaiTrach"].Value.ToString()) && !bool.Parse(item.Cells["DangNgan_ChuyenKhoan"].Value.ToString()) && !bool.Parse(item.Cells["DangNgan_Quay"].Value.ToString()) && int.Parse(item.Cells["TieuThu"].Value.ToString()) != 0)
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "KIỂM TRA DỊCH VỤ THU HỘ";
                    dr["GhiChu"] = "ĐỂ BIẾT, KHÔNG THU";
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                    dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                    dr["MLT"] = item.Cells["MLT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    dr["Ky"] = item.Cells["Ky"].Value.ToString();
                    dr["TongCong"] = item.Cells["SoTien"].Value.ToString();
                    dr["HanhThu"] = item.Cells["HanhThu"].Value.ToString();
                    dr["To"] = item.Cells["To"].Value.ToString();
                    if (int.Parse(item.Cells["GiaBieu"].Value.ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    dr["NganHang"] = item.Cells["TenDichVu"].Value.ToString();

                    if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                        dr["LenhHuy"] = true;
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            rptDSDichVuThu rpt = new rptDSDichVuThu();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnXem.PerformClick();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    try
                    {
                        foreach (DataGridViewRow item in dgvDichVuThu.SelectedRows)
                        {
                            if (item.Cells["IDGiaoDich"].Value.ToString() == "")
                            {
                                //MessageBox.Show("Xóa cơ chế cũ, Liên hệ BảoBảo để xóa tiếp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                TT_DichVuThu dvt = _cDichVuThu.Get(item.Cells["SoHoaDon"].Value.ToString());
                                //if (dvt.TenDichVu == "PAYOO")
                                //{
                                //    _cDichVuThu.ExecuteNonQuery("delete BGW_HOADON where ID_HOADON="+dvt.MaHD);
                                //    _cDichVuThu.ExecuteNonQuery("delete BGW_DANGNGAN_UNC where FK_HOADON=" + dvt.MaHD);
                                //}
                                _cDichVuThu.Xoa(dvt);
                            }
                            else
                            {
                                using (TransactionScope scope = new TransactionScope())
                                {
                                    try
                                    {
                                        _cDichVuThu.ExecuteNonQuery("insert TT_DichVuThu_Huy select * from TT_DichVuThu where TenDichVu=N'" + item.Cells["TenDichVu"].Value.ToString() + "' and IDGiaoDich='" + item.Cells["IDGiaoDich"].Value.ToString() + "'");
                                        _cDichVuThu.ExecuteNonQuery("delete TT_DichVuThu where TenDichVu=N'" + item.Cells["TenDichVu"].Value.ToString() + "' and IDGiaoDich='" + item.Cells["IDGiaoDich"].Value.ToString() + "'");
                                        _cDichVuThu.ExecuteNonQuery("insert TT_DichVuThuTong_Huy select * from TT_DichVuThuTong where TenDichVu=N'" + item.Cells["TenDichVu"].Value.ToString() + "' and IDGiaoDich='" + item.Cells["IDGiaoDich"].Value.ToString() + "'");
                                        _cDichVuThu.ExecuteNonQuery("delete TT_DichVuThuTong where TenDichVu=N'" + item.Cells["TenDichVu"].Value.ToString() + "' and IDGiaoDich='" + item.Cells["IDGiaoDich"].Value.ToString() + "'");
                                        scope.Complete();
                                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        btnXem.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInLenhHuy_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDichVuThu.Rows)
                if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "DỊCH VỤ THU HỘ(LỆNH HỦY)";
                    dr["GhiChu"] = "ĐỂ BIẾT, KHÔNG THU";
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                    dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                    dr["MLT"] = item.Cells["MLT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    dr["Ky"] = item.Cells["Ky"].Value.ToString();
                    dr["TongCong"] = item.Cells["SoTien"].Value.ToString();
                    dr["HanhThu"] = item.Cells["HanhThu"].Value.ToString();
                    dr["To"] = item.Cells["To"].Value.ToString();
                    if (int.Parse(item.Cells["GiaBieu"].Value.ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                        dr["LenhHuy"] = true;
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            rptDSTamThuChuyenKhoanDiaChi rpt = new rptDSTamThuChuyenKhoanDiaChi();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }
    }
}
