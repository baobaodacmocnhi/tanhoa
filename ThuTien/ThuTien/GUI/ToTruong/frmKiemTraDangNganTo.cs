using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.BaoCao;
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao.Quay;
using ThuTien.LinQ;
using ThuTien.BaoCao.NhanVien;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmKiemTraDangNganTo : Form
    {
        //string _mnu = "mnuKiemTraDangNganTo";
        CHoaDon _cHoaDon = new CHoaDon();
        CTo _cTo = new CTo();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        bool _flagLoadFirst = false;

        public frmKiemTraDangNganTo()
        {
            InitializeComponent();
        }

        private void frmKiemTraDangNgan_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;
            dgvLichSuDangNganA.AutoGenerateColumns = false;
            dgvLichSuDangNganB.AutoGenerateColumns = false;
            dgvCongViec.AutoGenerateColumns = false;

            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                cmbTo.DataSource = _cTo.getDS_HanhThu();
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
                cmbTo.SelectedIndex = -1;
            }
            else
            {
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
                cmbNhanVien.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";

                cmbNhanVien_CongViec.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
                cmbNhanVien_CongViec.DisplayMember = "HoTen";
                cmbNhanVien_CongViec.ValueMember = "MaND";
            }

            DataTable dtNam = _cHoaDon.GetNam();
            //DataRow dr = dtNam.NewRow();
            //dr["ID"] = "Tất Cả";
            //dtNam.Rows.InsertAt(dr, 0);
            cmbNam.DataSource = dtNam;
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";

            dateGiaiTrach.Value = DateTime.Now;

            cmbNam.SelectedValue = DateTime.Now.Year.ToString();
            cmbKy.SelectedItem = DateTime.Now.Month.ToString();
            cmbFromDot.SelectedIndex = 0;
            cmbToDot.SelectedIndex = 0;

            //tabTuGia.Text = "Hóa Đơn";
            //tabControl.TabPages.Remove(tabCoQuan);
            _flagLoadFirst = true;
        }

        public void CountdgvHDTuGia()
        {
            int TongHDTonDau = 0;
            long TongCongTonDau = 0;
            int TongHDDangNgan = 0;
            long TongCongDangNgan = 0;
            int TongHDDangNganTangCuong = 0;
            long TongCongDangNganTangCuong = 0;
            int TongHDDangNganQuay = 0;
            long TongCongDangNganQuay = 0;
            int TongHDDangNganChuyenKhoan = 0;
            long TongCongDangNganChuyenKhoan = 0;
            int TongHDTonCuoi = 0;
            long TongCongTonCuoi = 0;
            int TongHDInPhieuBao = 0;
            int TongHDTBDongNuoc = 0;
            int TongHDXoa = 0;
            long TongCongXoa = 0;
            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (item.Cells["TongHDTonDau"].Value.ToString() != "")
                        TongHDTonDau += int.Parse(item.Cells["TongHDTonDau"].Value.ToString());
                    if (item.Cells["TongCongTonDau"].Value.ToString() != "")
                        TongCongTonDau += long.Parse(item.Cells["TongCongTonDau"].Value.ToString());
                    if (item.Cells["TongHDDangNgan"].Value.ToString() != "")
                        TongHDDangNgan += int.Parse(item.Cells["TongHDDangNgan"].Value.ToString());
                    if (item.Cells["TongCongDangNgan"].Value.ToString() != "")
                        TongCongDangNgan += long.Parse(item.Cells["TongCongDangNgan"].Value.ToString());
                    if (item.Cells["TongHDDangNganTangCuong"].Value.ToString() != "")
                        TongHDDangNganTangCuong += int.Parse(item.Cells["TongHDDangNganTangCuong"].Value.ToString());
                    if (item.Cells["TongCongDangNganTangCuong"].Value.ToString() != "")
                        TongCongDangNganTangCuong += long.Parse(item.Cells["TongCongDangNganTangCuong"].Value.ToString());
                    if (item.Cells["TongHDDangNganQuay"].Value.ToString() != "")
                        TongHDDangNganQuay += int.Parse(item.Cells["TongHDDangNganQuay"].Value.ToString());
                    if (item.Cells["TongCongDangNganQuay"].Value.ToString() != "")
                        TongCongDangNganQuay += long.Parse(item.Cells["TongCongDangNganQuay"].Value.ToString());
                    if (item.Cells["TongHDDangNganChuyenKhoan"].Value.ToString() != "")
                        TongHDDangNganChuyenKhoan += int.Parse(item.Cells["TongHDDangNganChuyenKhoan"].Value.ToString());
                    if (item.Cells["TongCongDangNganChuyenKhoan"].Value.ToString() != "")
                        TongCongDangNganChuyenKhoan += long.Parse(item.Cells["TongCongDangNganChuyenKhoan"].Value.ToString());
                    if (item.Cells["TongHDTonCuoi"].Value.ToString() != "")
                        TongHDTonCuoi += int.Parse(item.Cells["TongHDTonCuoi"].Value.ToString());
                    if (item.Cells["TongCongTonCuoi"].Value.ToString() != "")
                        TongCongTonCuoi += long.Parse(item.Cells["TongCongTonCuoi"].Value.ToString());
                    if (item.Cells["TongHDInPhieuBao"].Value.ToString() != "")
                        TongHDInPhieuBao += int.Parse(item.Cells["TongHDInPhieuBao"].Value.ToString());
                    if (item.Cells["TongHDTBDongNuoc"].Value.ToString() != "")
                        TongHDTBDongNuoc += int.Parse(item.Cells["TongHDTBDongNuoc"].Value.ToString());
                    if (item.Cells["TongHDXoa"].Value.ToString() != "")
                        TongHDXoa += int.Parse(item.Cells["TongHDXoa"].Value.ToString());
                    if (item.Cells["TongCongXoa"].Value.ToString() != "")
                        TongCongXoa += long.Parse(item.Cells["TongCongXoa"].Value.ToString());
                }
                txtTongHDTonDau_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTonDau);
                txtTongCongTonDau_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTonDau);
                txtTongHDDangNgan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDDangNgan);
                txtTongCongDangNgan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongDangNgan);
                txtTongHDDangNganTangCuong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDDangNganTangCuong);
                txtTongCongDangNganTangCuong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongDangNganTangCuong);
                txtTongHDDangNganQuay_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDDangNganQuay);
                txtTongCongDangNganQuay_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongDangNganQuay);
                txtTongHDDangNganChuyenKhoan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDDangNganChuyenKhoan);
                txtTongCongDangNganChuyenKhoan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongDangNganChuyenKhoan);
                txtTongHDTonCuoi_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTonCuoi);
                txtTongCongTonCuoi_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTonCuoi);
                txtTongHDInPhieuBao_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDInPhieuBao);
                txtTongHDTBDongNuoc_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTBDongNuoc);
                txtTongHDXoa_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDXoa);
                txtTongCongXoa_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongXoa);
            }
        }

        public void CountdgvHDCoQuan()
        {
            long TongCong = 0;
            long TongGiaiTrach = 0;
            long TongCongGiaiTrach = 0;
            long TongDienThoai = 0;
            long TongCongDienThoai = 0;
            long TongPhieuBao = 0;
            long TongPhieuBao2 = 0;
            long TongXoa = 0;

            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    TongCong += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                    if (item.Cells["NgayGiaiTrach"].Value.ToString() != "")
                    {
                        TongGiaiTrach++;
                        TongCongGiaiTrach += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                    }
                    if (bool.Parse(item.Cells["DangNgan_DienThoai"].Value.ToString()) == true)
                    {
                        TongDienThoai++;
                        TongCongDienThoai += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                    }
                    if (item.Cells["InPhieuBao_Ngay"].Value.ToString() != "")
                        TongPhieuBao++;
                    if (item.Cells["InPhieuBao2_Ngay"].Value.ToString() != "")
                        TongPhieuBao2++;
                    if (item.Cells["XoaDangNgan_Ngay_DienThoai"].Value.ToString() != "")
                        TongXoa++;
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDCoQuan.RowCount);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongGiaiTrach_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaiTrach);
                txtTongCongGiaiTrach_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongGiaiTrach);
                txtTongDienThoai_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongDienThoai);
                txtTongCongDienThoai_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongDienThoai);
                txtTongPhieuBao_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhieuBao);
                txtTongPhieuBao2_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhieuBao2);
                txtTongXoa_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongXoa);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                List<TT_NguoiDung> lst = new List<TT_NguoiDung>();
                if (CNguoiDung.Doi == true)
                {
                    lst = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo.SelectedValue.ToString()));
                }
                else
                {
                    lst = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
                }
                DataTable dt = new DataTable();
                if (cmbFromDot.SelectedIndex == 0)
                    foreach (TT_NguoiDung item in lst)
                    {
                        dt.Merge(_cHoaDon.GetTongDangNgan_NV(item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value));
                    }
                else
                    if (cmbFromDot.SelectedIndex > 0)
                        foreach (TT_NguoiDung item in lst)
                        {
                            dt.Merge(_cHoaDon.GetTongDangNgan_NV(item.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()), dateGiaiTrach.Value));
                        }
                dgvHDTuGia.DataSource = dt;
                CountdgvHDTuGia();
            }
            //else
            //    if (tabControl.SelectedTab.Name == "tabCoQuan")
            //    {
            //        dgvHDCoQuan.DataSource = _cHoaDon.GetTongDangNgan_To("CQ", CNguoiDung.MaTo, dateGiaiTrach.Value);
            //        CountdgvHDCoQuan();
            //}
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            dsBaoCao ds2 = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                DataTable dt = _cHoaDon.GetDSDangNgan("", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV"].Value.ToString()), dateGiaiTrach.Value);
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "ĐĂNG NGÂN";
                    dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["SoHoaDon"] = item["SoHoaDon"];
                    dr["Ky"] = item["Ky"];
                    dr["GiaBan"] = item["GiaBan"];
                    dr["ThueGTGT"] = item["ThueGTGT"];
                    dr["PhiBVMT"] = item["PhiBVMT"];
                    dr["TongCong"] = item["TongCong"];
                    dr["NgayLap"] = item["NgayGiaiTrach"];
                    dr["NhanVien"] = dgvHDTuGia.SelectedRows[0].Cells["HoTen"].Value.ToString();
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }
                dt = _cHoaDon.getDSXoaDangNgan_HoaDonDienTu(int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV"].Value.ToString()), dateGiaiTrach.Value);
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds2.Tables["DSHoaDon"].NewRow();
                    dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["SoHoaDon"] = item["SoHoaDon"];
                    dr["Ky"] = item["Ky"];
                    dr["GiaBan"] = item["GiaBan"];
                    dr["ThueGTGT"] = item["ThueGTGT"];
                    dr["PhiBVMT"] = item["PhiBVMT"];
                    dr["TongCong"] = item["TongCong"];
                    dr["NgayLap"] = item["XoaDangNgan_Ngay_DienThoai"];
                    ds2.Tables["DSHoaDon"].Rows.Add(dr);
                }
            }
            //else
            //    if (tabControl.SelectedTab.Name == "tabCoQuan")
            //    {
            //        DataTable dt = _cHoaDon.GetDSDangNgan("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), dateGiaiTrach.Value);
            //        foreach (DataRow item in dt.Rows)
            //        {
            //            DataRow dr = ds.Tables["DSHoaDon"].NewRow();
            //            dr["LoaiBaoCao"] = "CƠ QUAN ĐÃ THU";
            //            dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
            //            dr["Ky"] = item["Ky"];
            //            dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
            //            dr["TongCong"] = item["TongCong"];
            //            //dr["SoPhatHanh"] = item["SoPhatHanh"];
            //            dr["SoHoaDon"] = item["SoHoaDon"];
            //            dr["NhanVien"] = dgvHDCoQuan.SelectedRows[0].Cells["HoTen_CQ"].Value.ToString();
            //            ds.Tables["DSHoaDon"].Rows.Add(dr);
            //        }
            //    }
            rptDSDangNgan_HoaDonDienTu rpt = new rptDSDangNgan_HoaDonDienTu();
            rpt.SetDataSource(ds);
            rpt.Subreports["DanhSachXoaDangNgan"].SetDataSource(ds2);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDTonDau" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongTonDau" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDDangNgan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongDangNgan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDDangNganTangCuong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongDangNganTangCuong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDDangNganQuay" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongDangNganQuay" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDDangNganChuyenKhoan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongDangNganChuyenKhoan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDTonCuoi" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongTonCuoi" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDInGiayBao" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongInGiayBao" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDXoa" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongXoa" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHD_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBan_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongThueGTGT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongPhiBVMT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
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

        private void dgvHDCoQuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDCoQuan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnInDSCoThuHo_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                DataTable dt = _cHoaDon.GetDSDangNganHanhThu_To_CoThuHo("TG", CNguoiDung.MaTo, dateGiaiTrach.Value);
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["LoaiBaoCao"] = "CÓ THU HỘ";
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = item["HoTen"];
                    dr["Ky"] = item["Ky"];
                    dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = item["TongCong"];
                    dr["SoHoaDon"] = item["SoHoaDon"];
                    dr["HanhThu"] = item["HanhThu"];
                    dr["To"] = item["To"];
                    //dr["Loai"] = "TG";
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            }
            //else
            //    if (tabControl.SelectedTab.Name == "tabCoQuan")
            //    {
            //        DataTable dt = _cHoaDon.GetDSDangNganHanhThu_To_CoThuHo("CQ", CNguoiDung.MaTo, dateGiaiTrach.Value);
            //        foreach (DataRow item in dt.Rows)
            //        {
            //            DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
            //            dr["LoaiBaoCao"] = "CÓ THU HỘ CƠ QUAN";
            //            dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
            //            dr["HoTen"] = item["HoTen"];
            //            dr["Ky"] = item["Ky"];
            //            dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
            //            dr["TongCong"] = item["TongCong"];
            //            dr["SoHoaDon"] = item["SoHoaDon"];
            //            dr["HanhThu"] = item["HanhThu"];
            //            dr["To"] = item["To"];
            //            dr["Loai"] = "CQ";
            //            ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
            //        }
            //    }
            rptDSDangNganQuay rpt = new rptDSDangNganQuay();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSPhieuBao_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            DataTable dt = _cHoaDon.getDSInPhieuBao_HoaDonDienTu(int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV"].Value.ToString()), dateGiaiTrach.Value);
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                dr["LoaiBaoCao"] = "IN PHIẾU BÁO";
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["Ky"] = item["Ky"];
                dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                dr["TongCong"] = item["TongCong"];
                dr["SoPhatHanh"] = item["SoPhatHanh"];
                dr["SoHoaDon"] = item["SoHoaDon"];
                dr["NhanVien"] = CNguoiDung.HoTen;
                ds.Tables["DSHoaDon"].Rows.Add(dr);
            }

            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnDSTBDongNuoc_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            DataTable dt = _cHoaDon.getDSInTBDongNuoc_HoaDonDienTu(int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV"].Value.ToString()), dateGiaiTrach.Value);
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                dr["LoaiBaoCao"] = "IN TB ĐÓNG NƯỚC";
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["Ky"] = item["Ky"];
                dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                dr["TongCong"] = item["TongCong"];
                dr["SoPhatHanh"] = item["SoPhatHanh"];
                dr["SoHoaDon"] = item["SoHoaDon"];
                dr["NhanVien"] = CNguoiDung.HoTen;
                ds.Tables["DSHoaDon"].Rows.Add(dr);
            }

            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi == true)
                if (_flagLoadFirst == true && cmbTo.SelectedIndex != -1)
                {
                    if ((_cTo.checkHanhThu(int.Parse(cmbTo.SelectedValue.ToString()))))
                    {
                        cmbNhanVien.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo.SelectedValue.ToString()));
                        cmbNhanVien_CongViec.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo.SelectedValue.ToString()));
                    }
                    //else
                    //{
                    //    cmbNhanVien.DataSource = _cNguoiDung.GetDSByToVanPhong(int.Parse(cmbTo.SelectedValue.ToString()));
                    //}
                    cmbNhanVien.DisplayMember = "HoTen";
                    cmbNhanVien.ValueMember = "MaND";
                    cmbNhanVien_CongViec.DisplayMember = "HoTen";
                    cmbNhanVien_CongViec.ValueMember = "MaND";
                }
                else
                    cmbNhanVien.DataSource = null;
        }

        private void btnTheoDoi_Click(object sender, EventArgs e)
        {
            if (cmbFromDot.SelectedIndex > 0)
            {
                dgvHDCoQuan.DataSource = _cHoaDon.getDS_HoaDonDienTu(int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                CountdgvHDCoQuan();
            }
            else
                MessageBox.Show("Chọn Từ Đợt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDanhBo.Text.Trim().Replace(" ", "") != "" && e.KeyChar == 13)
            {
                dgvLichSuDangNganA.DataSource = _cHoaDon.GetDSByDanhBo(txtDanhBo.Text.Trim().Replace(" ", ""));
            }
        }

        private void dgvLichSuDangNganA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvLichSuDangNganB.DataSource = _cHoaDon.getDS_LichSuDangNgan(int.Parse(dgvLichSuDangNganA.CurrentRow.Cells["MaHD"].Value.ToString()));
        }

        private void dgvLichSuDangNganA_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLichSuDangNganA.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvLichSuDangNganB_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLichSuDangNganB.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDCoQuan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "btnLocation_DangNgan")
                {
                    if (dgvHDCoQuan.CurrentRow.Cells["DangNgan_DienThoai_Location"].Value.ToString() != "")
                        System.Diagnostics.Process.Start("https://maps.google.com?q=" + dgvHDCoQuan.CurrentRow.Cells["DangNgan_DienThoai_Location"].Value.ToString());
                    else
                        MessageBox.Show("Không có Vị Trí", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "btnLocation_InPhieuBao")
                    {
                        if (dgvHDCoQuan.CurrentRow.Cells["InPhieuBao_Location"].Value.ToString() != "")
                            System.Diagnostics.Process.Start("https://maps.google.com?q=" + dgvHDCoQuan.CurrentRow.Cells["InPhieuBao_Location"].Value.ToString());
                        else
                            MessageBox.Show("Không có Vị Trí", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "btnLocation_InPhieuBao2")
                        {
                            if (dgvHDCoQuan.CurrentRow.Cells["InPhieuBao2_Location"].Value.ToString() != "")
                                System.Diagnostics.Process.Start("https://maps.google.com?q=" + dgvHDCoQuan.CurrentRow.Cells["InPhieuBao2_Location"].Value.ToString());
                            else
                                MessageBox.Show("Không có Vị Trí", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "btnLocation_TBDongNuoc")
                            {
                                if (dgvHDCoQuan.CurrentRow.Cells["TBDongNuoc_Location"].Value.ToString() != "")
                                    System.Diagnostics.Process.Start("https://maps.google.com?q=" + dgvHDCoQuan.CurrentRow.Cells["TBDongNuoc_Location"].Value.ToString());
                                else
                                    MessageBox.Show("Không có Vị Trí", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "btnLocation_XoaDangNgan")
                                {
                                    if (dgvHDCoQuan.CurrentRow.Cells["XoaDangNgan_Location_DienThoai"].Value.ToString() != "")
                                        System.Diagnostics.Process.Start("https://maps.google.com?q=" + dgvHDCoQuan.CurrentRow.Cells["XoaDangNgan_Location_DienThoai"].Value.ToString());
                                    else
                                        MessageBox.Show("Không có Vị Trí", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_CongViec_Click(object sender, EventArgs e)
        {
            if (cmbFromDot.SelectedIndex > 0)
            {
                dgvCongViec.DataSource = _cHoaDon.getCount_CongViec(int.Parse(cmbNhanVien_CongViec.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()),dateGiaiTrach.Value);
            }
            else
                MessageBox.Show("Chọn Từ Đợt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
