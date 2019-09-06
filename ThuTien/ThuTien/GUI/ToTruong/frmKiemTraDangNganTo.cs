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

namespace ThuTien.GUI.ToTruong
{
    public partial class frmKiemTraDangNganTo : Form
    {
        //string _mnu = "mnuKiemTraDangNganTo";
        CHoaDon _cHoaDon = new CHoaDon();
        CTo _cTo = new CTo();

        public frmKiemTraDangNganTo()
        {
            InitializeComponent();
        }

        private void frmKiemTraDangNgan_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                cmbTo.DataSource = _cTo.GetDSHanhThu();
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;

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

            tabTuGia.Text = "Hóa Đơn";
            tabControl.TabPages.Remove(tabCoQuan);
        }

        public void CountdgvHDTuGia()
        {
            int TongHDTonDau = 0;
            int TongCongTonDau = 0;
            int TongHDDangNgan = 0;
            int TongCongDangNgan = 0;
            int TongHDDangNganQuay = 0;
            int TongCongDangNganQuay = 0;
            int TongHDDangNganChuyenKhoan = 0;
            int TongCongDangNganChuyenKhoan = 0;
            int TongHDTonCuoi = 0;
            int TongCongTonCuoi = 0;
            int TongHDInGiayBao = 0;
            int TongCongInGiayBao = 0;
            int TongHDXoa = 0;
            int TongCongXoa = 0;
            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (item.Cells["TongHDTonDau"].Value.ToString() != "")
                        TongHDTonDau += int.Parse(item.Cells["TongHDTonDau"].Value.ToString());
                    if (item.Cells["TongCongTonDau"].Value.ToString() != "")
                        TongCongTonDau += int.Parse(item.Cells["TongCongTonDau"].Value.ToString());
                    if (item.Cells["TongHDDangNgan"].Value.ToString() != "")
                        TongHDDangNgan += int.Parse(item.Cells["TongHDDangNgan"].Value.ToString());
                    if (item.Cells["TongCongDangNgan"].Value.ToString() != "")
                        TongCongDangNgan += int.Parse(item.Cells["TongCongDangNgan"].Value.ToString());
                    if (item.Cells["TongHDDangNganQuay"].Value.ToString() != "")
                        TongHDDangNganQuay += int.Parse(item.Cells["TongHDDangNganQuay"].Value.ToString());
                    if (item.Cells["TongCongDangNganQuay"].Value.ToString() != "")
                        TongCongDangNganQuay += int.Parse(item.Cells["TongCongDangNganQuay"].Value.ToString());
                    if (item.Cells["TongHDDangNganChuyenKhoan"].Value.ToString() != "")
                        TongHDDangNganChuyenKhoan += int.Parse(item.Cells["TongHDDangNganChuyenKhoan"].Value.ToString());
                    if (item.Cells["TongCongDangNganChuyenKhoan"].Value.ToString() != "")
                        TongCongDangNganChuyenKhoan += int.Parse(item.Cells["TongCongDangNganChuyenKhoan"].Value.ToString());
                    if (item.Cells["TongHDTonCuoi"].Value.ToString() != "")
                        TongHDTonCuoi += int.Parse(item.Cells["TongHDTonCuoi"].Value.ToString());
                    if (item.Cells["TongCongTonCuoi"].Value.ToString() != "")
                        TongCongTonCuoi += int.Parse(item.Cells["TongCongTonCuoi"].Value.ToString());
                    if (item.Cells["TongHDInGiayBao"].Value.ToString() != "")
                        TongHDInGiayBao += int.Parse(item.Cells["TongHDInGiayBao"].Value.ToString());
                    if (item.Cells["TongCongInGiayBao"].Value.ToString() != "")
                        TongCongInGiayBao += int.Parse(item.Cells["TongCongInGiayBao"].Value.ToString());
                    if (item.Cells["TongHDXoa"].Value.ToString() != "")
                        TongHDXoa += int.Parse(item.Cells["TongHDXoa"].Value.ToString());
                    if (item.Cells["TongCongXoa"].Value.ToString() != "")
                        TongCongXoa += int.Parse(item.Cells["TongCongXoa"].Value.ToString());
                }
                txtTongHDTonDau_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTonDau);
                txtTongCongTonDau_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTonDau);
                txtTongHDDangNgan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDDangNgan);
                txtTongCongDangNgan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongDangNgan);
                txtTongHDDangNganQuay_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDDangNganQuay);
                txtTongCongDangNganQuay_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongDangNganQuay);
                txtTongHDDangNganChuyenKhoan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDDangNganChuyenKhoan);
                txtTongCongDangNganChuyenKhoan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongDangNganChuyenKhoan);
                txtTongHDTonCuoi_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTonCuoi);
                txtTongCongTonCuoi_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTonCuoi);
                txtTongHDInGiayBao_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDInGiayBao);
                txtTongCongInGiayBao_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongInGiayBao);
                txtTongHDXoa_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDXoa);
                txtTongCongXoa_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongXoa);
            }
        }

        public void CountdgvHDCoQuan()
        {
            int TongHD = 0;
            int TongGiaBan = 0;
            int TongThueGTGT = 0;
            int TongPhiBVMT = 0;
            int TongCong = 0;

            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    TongHD += int.Parse(item.Cells["TongHD_CQ"].Value.ToString());
                    TongGiaBan += int.Parse(item.Cells["TongGiaBan_CQ"].Value.ToString());
                    TongThueGTGT += int.Parse(item.Cells["TongThueGTGT_CQ"].Value.ToString());
                    TongPhiBVMT += int.Parse(item.Cells["TongPhiBVMT_CQ"].Value.ToString());
                    TongCong += int.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (CNguoiDung.Doi == true)
                    dgvHDTuGia.DataSource = _cHoaDon.GetTongDangNgan_To(int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()), dateGiaiTrach.Value);
                else
                    dgvHDTuGia.DataSource = _cHoaDon.GetTongDangNgan_To(CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()), dateGiaiTrach.Value);
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
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                DataTable dt = _cHoaDon.GetDSDangNgan("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV"].Value.ToString()), dateGiaiTrach.Value);
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "ĐÃ THU";
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item["Ky"];
                    dr["MLT"] = item["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = item["TongCong"];
                    //dr["SoPhatHanh"] = item["SoPhatHanh"];
                    dr["SoHoaDon"] = item["SoHoaDon"];
                    dr["NhanVien"] = dgvHDTuGia.SelectedRows[0].Cells["HoTen_TG"].Value.ToString();
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
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
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHD_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBan_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongThueGTGT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongPhiBVMT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
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
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
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
    }
}
