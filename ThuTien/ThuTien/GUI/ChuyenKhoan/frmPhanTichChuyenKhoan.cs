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
using ThuTien.DAL.Doi;
using System.Globalization;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmPhanTichChuyenKhoan : Form
    {
        CDichVuThu _cDichVuThu = new CDichVuThu();
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CNganHang _cNganHang = new CNganHang();

        public frmPhanTichChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmPhanTichChuyenKhoan_Load(object sender, EventArgs e)
        {
            dgvTo_TuGia_PhanTich.AutoGenerateColumns = false;
            dgvNhanVien_TuGia_PhanTich.AutoGenerateColumns = false;

            DataTable dtNganHang = _cNganHang.GetDS();
            DataRow dr = dtNganHang.NewRow();
            dr["MaNH"] = "-1";
            dr["TenNH"] = "Tất Cả";
            dtNganHang.Rows.InsertAt(dr, 0);
            cmbNganHang_PhanTich.DataSource = dtNganHang;
            cmbNganHang_PhanTich.DisplayMember = "TenNH";
            cmbNganHang_PhanTich.ValueMember = "MaNH";

            List<TT_To> lstTo = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lstTo.Insert(0, to);
            cmbTo_PhanTich.DataSource = lstTo;
            cmbTo_PhanTich.DisplayMember = "TenTo";
            cmbTo_PhanTich.ValueMember = "MaTo";

            DataTable dtNam = _cHoaDon.GetNam();
            cmbNam_PhanTich.DataSource = dtNam;
            cmbNam_PhanTich.DisplayMember = "Nam";
            cmbNam_PhanTich.ValueMember = "Nam";

            dgvDichVuThu.AutoGenerateColumns = false;
            dgvBienDong_HD.AutoGenerateColumns = false;

            dtNganHang = _cNganHang.GetDS();
            dr = dtNganHang.NewRow();
            dr["MaNH"] = "-2";
            dr["TenNH"] = "Tất Cả";
            dtNganHang.Rows.InsertAt(dr, 0);
            dr = dtNganHang.NewRow();
            dr["MaNH"] = "-1";
            dr["TenNH"] = "Khác";
            dtNganHang.Rows.InsertAt(dr, 1);
            cmbNganHang_HD.DataSource = dtNganHang;
            cmbNganHang_HD.DisplayMember = "TenNH";
            cmbNganHang_HD.ValueMember = "MaNH";

            cmbTo_HD.DataSource = lstTo;
            cmbTo_HD.DisplayMember = "TenTo";
            cmbTo_HD.ValueMember = "MaTo";

            cmbNam_HD.DataSource = dtNam;
            cmbNam_HD.DisplayMember = "Nam";
            cmbNam_HD.ValueMember = "Nam";
        }

        public void CountdgvTo_TuGia_PhanTich()
        {
            int TongHDCKB = 0;
            long TongGiaBanCKB = 0;
            long TongCongCKB = 0;
            int TongHDCK = 0;
            long TongGiaBanCK = 0;
            long TongCongCK = 0;
            int TongHDChuaCK = 0;
            long TongGiaBanChuaCK = 0;
            long TongCongChuaCK = 0;

            if (dgvTo_TuGia_PhanTich.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvTo_TuGia_PhanTich.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHDCKB_TG"].Value.ToString()))
                        TongHDCKB += int.Parse(item.Cells["TongHDCKB_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanCKB_TG"].Value.ToString()))
                        TongGiaBanCKB += long.Parse(item.Cells["TongGiaBanCKB_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongCKB_TG"].Value.ToString()))
                        TongCongCKB += long.Parse(item.Cells["TongCongCKB_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDCK_TG"].Value.ToString()))
                        TongHDCK += int.Parse(item.Cells["TongHDCK_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanCK_TG"].Value.ToString()))
                        TongGiaBanCK += long.Parse(item.Cells["TongGiaBanCK_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongCK_TG"].Value.ToString()))
                        TongCongCK += long.Parse(item.Cells["TongCongCK_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDKhongCK_TG"].Value.ToString()))
                        TongHDChuaCK += int.Parse(item.Cells["TongHDKhongCK_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanKhongCK_TG"].Value.ToString()))
                        TongGiaBanChuaCK += long.Parse(item.Cells["TongGiaBanKhongCK_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongKhongCK_TG"].Value.ToString()))
                        TongCongChuaCK += long.Parse(item.Cells["TongCongKhongCK_TG"].Value.ToString());

                    if (string.IsNullOrEmpty(item.Cells["TongHDCKB_TG"].Value.ToString()))
                        item.Cells["TyLeHDCKB_TG"].Value = "0%";
                    else
                        item.Cells["TyLeHDCKB_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDCKB_TG"].Value.ToString()) / double.Parse(item.Cells["TongHD_TG"].Value.ToString())) * 100);

                    if (string.IsNullOrEmpty(item.Cells["TongHDCK_TG"].Value.ToString()))
                        item.Cells["TyLeHDCK_TG"].Value = "0%";
                    else
                        item.Cells["TyLeHDCK_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDCK_TG"].Value.ToString()) / double.Parse(item.Cells["TongHD_TG"].Value.ToString())) * 100);

                    if (string.IsNullOrEmpty(item.Cells["TongHDKhongCK_TG"].Value.ToString()))
                        item.Cells["TyLeHDKhongCK_TG"].Value = "0%";
                    else
                        item.Cells["TyLeHDKhongCK_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDKhongCK_TG"].Value.ToString()) / double.Parse(item.Cells["TongHD_TG"].Value.ToString())) * 100);

                    if (string.IsNullOrEmpty(item.Cells["TongHDTon_TG"].Value.ToString()))
                        item.Cells["TyLeHDTon_TG"].Value = "0%";
                    else
                        item.Cells["TyLeHDTon_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDTon_TG"].Value.ToString()) / double.Parse(item.Cells["TongHD_TG"].Value.ToString())) * 100);
                }
                txtTongHDCKB_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDCKB);
                txtTongGiaBanCKB_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanCKB);
                txtTongCongCKB_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCKB);

                txtTongHDCK_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDCK);
                txtTongGiaBanCK_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanCK);
                txtTongCongCK_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCK);

                txtTongHDKhongCK_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDChuaCK);
                txtTongGiaBanaKhongCK_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanChuaCK);
                txtTongCongKhongCK_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongChuaCK);
            }
        }

        public void CountdgvTo_CoQuan_PhanTich()
        {
            int TongHDCKB = 0;
            long TongGiaBanCKB = 0;
            long TongCongCKB = 0;
            int TongHDCK = 0;
            long TongGiaBanCK = 0;
            long TongCongCK = 0;
            int TongHDChuaCK = 0;
            long TongGiaBanChuaCK = 0;
            long TongCongChuaCK = 0;

            if (dgvTo_CoQuan_PhanTich.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvTo_CoQuan_PhanTich.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHDCKB_CQ"].Value.ToString()))
                        TongHDCKB += int.Parse(item.Cells["TongHDCKB_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanCKB_CQ"].Value.ToString()))
                        TongGiaBanCKB += long.Parse(item.Cells["TongGiaBanCKB_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongCKB_CQ"].Value.ToString()))
                        TongCongCKB += long.Parse(item.Cells["TongCongCKB_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDCK_CQ"].Value.ToString()))
                        TongHDCK += int.Parse(item.Cells["TongHDCK_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanCK_CQ"].Value.ToString()))
                        TongGiaBanCK += long.Parse(item.Cells["TongGiaBanCK_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongCK_CQ"].Value.ToString()))
                        TongCongCK += long.Parse(item.Cells["TongCongCK_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDKhongCK_CQ"].Value.ToString()))
                        TongHDChuaCK += int.Parse(item.Cells["TongHDKhongCK_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanKhongCK_CQ"].Value.ToString()))
                        TongGiaBanChuaCK += long.Parse(item.Cells["TongGiaBanKhongCK_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongKhongCK_CQ"].Value.ToString()))
                        TongCongChuaCK += long.Parse(item.Cells["TongCongKhongCK_CQ"].Value.ToString());

                    if (string.IsNullOrEmpty(item.Cells["TongHDCKB_CQ"].Value.ToString()))
                        item.Cells["TyLeHDCKB_CQ"].Value = "0%";
                    else
                        item.Cells["TyLeHDCKB_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDCKB_CQ"].Value.ToString()) / double.Parse(item.Cells["TongHD_CQ"].Value.ToString())) * 100);

                    if (string.IsNullOrEmpty(item.Cells["TongHDCK_CQ"].Value.ToString()))
                        item.Cells["TyLeHDCK_CQ"].Value = "0%";
                    else
                        item.Cells["TyLeHDCK_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDCK_CQ"].Value.ToString()) / double.Parse(item.Cells["TongHD_CQ"].Value.ToString())) * 100);

                    if (string.IsNullOrEmpty(item.Cells["TongHDKhongCK_CQ"].Value.ToString()))
                        item.Cells["TyLeHDKhongCK_CQ"].Value = "0%";
                    else
                        item.Cells["TyLeHDKhongCK_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDKhongCK_CQ"].Value.ToString()) / double.Parse(item.Cells["TongHD_CQ"].Value.ToString())) * 100);

                    if (string.IsNullOrEmpty(item.Cells["TongHDTon_CQ"].Value.ToString()))
                        item.Cells["TyLeHDTon_CQ"].Value = "0%";
                    else
                        item.Cells["TyLeHDTon_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDTon_CQ"].Value.ToString()) / double.Parse(item.Cells["TongHD_CQ"].Value.ToString())) * 100);
                }
                txtTongHDCKB_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDCKB);
                txtTongGiaBanCKB_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanCKB);
                txtTongCongCKB_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCKB);

                txtTongHDCK_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDCK);
                txtTongGiaBanCK_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanCK);
                txtTongCongCK_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCK);

                txtTongHDKhongCK_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDChuaCK);
                txtTongGiaBanaKhongCK_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanChuaCK);
                txtTongCongKhongCK_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongChuaCK);
            }
        }

        public void CountdgvNhanVien_TuGia_PhanTich()
        {
            //int TongHDCKB = 0;
            //long TongGiaBanCKB = 0;
            //long TongCongCKB = 0;
            //int TongHDCK = 0;
            //long TongGiaBanCK = 0;
            //long TongCongCK = 0;
            //int TongHDChuaCK = 0;
            //long TongGiaBanChuaCK = 0;
            //long TongCongChuaCK = 0;

            if (dgvNhanVien_TuGia_PhanTich.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvNhanVien_TuGia_PhanTich.Rows)
                {
                    //if (!string.IsNullOrEmpty(item.Cells["TongHDCKB_NV"].Value.ToString()))
                    //    TongHDCKB += int.Parse(item.Cells["TongHDCKB_NV"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["TongGiaBanCKB_NV"].Value.ToString()))
                    //    TongGiaBanCKB += long.Parse(item.Cells["TongGiaBanCKB_NV"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["TongCongCKB_NV"].Value.ToString()))
                    //    TongCongCKB += long.Parse(item.Cells["TongCongCKB_NV"].Value.ToString());

                    //if (!string.IsNullOrEmpty(item.Cells["TongHDCK_NV"].Value.ToString()))
                    //    TongHDCK += int.Parse(item.Cells["TongHDCK_NV"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["TongGiaBanCK_NV"].Value.ToString()))
                    //    TongGiaBanCK += long.Parse(item.Cells["TongGiaBanCK_NV"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["TongCongCK_NV"].Value.ToString()))
                    //    TongCongCK += long.Parse(item.Cells["TongCongCK_NV"].Value.ToString());

                    //if (!string.IsNullOrEmpty(item.Cells["TongHDKhongCK_NV"].Value.ToString()))
                    //    TongHDChuaCK += int.Parse(item.Cells["TongHDKhongCK_NV"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["TongGiaBanKhongCK_NV"].Value.ToString()))
                    //    TongGiaBanChuaCK += long.Parse(item.Cells["TongGiaBanKhongCK_NV"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["TongCongKhongCK_NV"].Value.ToString()))
                    //    TongCongChuaCK += long.Parse(item.Cells["TongCongKhongCK_NV"].Value.ToString());

                    if (string.IsNullOrEmpty(item.Cells["TongHDCKB_NV_TG"].Value.ToString()))
                        item.Cells["TyLeHDCKB_NV_TG"].Value = "0%";
                    else
                        item.Cells["TyLeHDCKB_NV_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDCKB_NV_TG"].Value.ToString()) / double.Parse(item.Cells["TongHD_NV_TG"].Value.ToString())) * 100);

                    if (string.IsNullOrEmpty(item.Cells["TongHDCK_NV_TG"].Value.ToString()))
                        item.Cells["TyLeHDCK_NV_TG"].Value = "0%";
                    else
                        item.Cells["TyLeHDCK_NV_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDCK_NV_TG"].Value.ToString()) / double.Parse(item.Cells["TongHD_NV_TG"].Value.ToString())) * 100);

                    if (string.IsNullOrEmpty(item.Cells["TongHDKhongCK_NV_TG"].Value.ToString()))
                        item.Cells["TyLeHDKhongCK_NV_TG"].Value = "0%";
                    else
                        item.Cells["TyLeHDKhongCK_NV_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDKhongCK_NV_TG"].Value.ToString()) / double.Parse(item.Cells["TongHD_NV_TG"].Value.ToString())) * 100);

                    if (string.IsNullOrEmpty(item.Cells["TongHDTon_NV_TG"].Value.ToString()))
                        item.Cells["TyLeHDTon_NV_TG"].Value = "0%";
                    else
                        item.Cells["TyLeHDTon_NV_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDTon_NV_TG"].Value.ToString()) / double.Parse(item.Cells["TongHD_NV_TG"].Value.ToString())) * 100);
                }
                //txtTongHDCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDCK);
                //txtTongGiaBanCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanCK);
                //txtTongCongCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCK);
                //txtTongHDChuaCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDChuaCK);
                //txtTongGiaBanaChuaCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanChuaCK);
                //txtTongCongChuaCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongChuaCK);
            }
        }

        public void CountdgvNhanVien_CoQuan_PhanTich()
        {
            //int TongHDCKB = 0;
            //long TongGiaBanCKB = 0;
            //long TongCongCKB = 0;
            //int TongHDCK = 0;
            //long TongGiaBanCK = 0;
            //long TongCongCK = 0;
            //int TongHDChuaCK = 0;
            //long TongGiaBanChuaCK = 0;
            //long TongCongChuaCK = 0;

            if (dgvNhanVien_CoQuan_PhanTich.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvNhanVien_CoQuan_PhanTich.Rows)
                {
                    //if (!string.IsNullOrEmpty(item.Cells["TongHDCKB_NV"].Value.ToString()))
                    //    TongHDCKB += int.Parse(item.Cells["TongHDCKB_NV"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["TongGiaBanCKB_NV"].Value.ToString()))
                    //    TongGiaBanCKB += long.Parse(item.Cells["TongGiaBanCKB_NV"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["TongCongCKB_NV"].Value.ToString()))
                    //    TongCongCKB += long.Parse(item.Cells["TongCongCKB_NV"].Value.ToString());

                    //if (!string.IsNullOrEmpty(item.Cells["TongHDCK_NV"].Value.ToString()))
                    //    TongHDCK += int.Parse(item.Cells["TongHDCK_NV"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["TongGiaBanCK_NV"].Value.ToString()))
                    //    TongGiaBanCK += long.Parse(item.Cells["TongGiaBanCK_NV"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["TongCongCK_NV"].Value.ToString()))
                    //    TongCongCK += long.Parse(item.Cells["TongCongCK_NV"].Value.ToString());

                    //if (!string.IsNullOrEmpty(item.Cells["TongHDKhongCK_NV"].Value.ToString()))
                    //    TongHDChuaCK += int.Parse(item.Cells["TongHDKhongCK_NV"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["TongGiaBanKhongCK_NV"].Value.ToString()))
                    //    TongGiaBanChuaCK += long.Parse(item.Cells["TongGiaBanKhongCK_NV"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["TongCongKhongCK_NV"].Value.ToString()))
                    //    TongCongChuaCK += long.Parse(item.Cells["TongCongKhongCK_NV"].Value.ToString());

                    if (string.IsNullOrEmpty(item.Cells["TongHDCKB_NV_CQ"].Value.ToString()))
                        item.Cells["TyLeHDCKB_NV_CQ"].Value = "0%";
                    else
                        item.Cells["TyLeHDCKB_NV_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDCKB_NV_CQ"].Value.ToString()) / double.Parse(item.Cells["TongHD_NV_CQ"].Value.ToString())) * 100);

                    if (string.IsNullOrEmpty(item.Cells["TongHDCK_NV_CQ"].Value.ToString()))
                        item.Cells["TyLeHDCK_NV_CQ"].Value = "0%";
                    else
                        item.Cells["TyLeHDCK_NV_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDCK_NV_CQ"].Value.ToString()) / double.Parse(item.Cells["TongHD_NV_CQ"].Value.ToString())) * 100);

                    if (string.IsNullOrEmpty(item.Cells["TongHDKhongCK_NV_CQ"].Value.ToString()))
                        item.Cells["TyLeHDKhongCK_NV_CQ"].Value = "0%";
                    else
                        item.Cells["TyLeHDKhongCK_NV_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDKhongCK_NV_CQ"].Value.ToString()) / double.Parse(item.Cells["TongHD_NV_CQ"].Value.ToString())) * 100);

                    if (string.IsNullOrEmpty(item.Cells["TongHDTon_NV_CQ"].Value.ToString()))
                        item.Cells["TyLeHDTon_NV_CQ"].Value = "0%";
                    else
                        item.Cells["TyLeHDTon_NV_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDTon_NV_CQ"].Value.ToString()) / double.Parse(item.Cells["TongHD_NV_CQ"].Value.ToString())) * 100);
                }
                //txtTongHDCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDCK);
                //txtTongGiaBanCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanCK);
                //txtTongCongCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCK);
                //txtTongHDChuaCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDChuaCK);
                //txtTongGiaBanaChuaCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanChuaCK);
                //txtTongCongChuaCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongChuaCK);
            }
        }

        private void btnXem_PhanTich_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab.Name == "tabTuGia")
            {
                if (chkNgayKiemTra.Checked == true)
                {
                    ///chọn tất cả tổ
                    if (cmbTo_PhanTich.SelectedIndex == 0)
                    {
                        DataTable dt = new DataTable();
                        ///chọn tất cả kỳ
                        if (cmbKy_PhanTich.SelectedIndex == 0)
                        {
                            for (int i = 1; i < cmbTo_PhanTich.Items.Count; i++)
                                dt.Merge(_cDichVuThu.GetPhanTichChuyenKhoan("TG",int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), ((TT_To)cmbTo_PhanTich.Items[i]).MaTo, int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), dateGiaiTrach.Value));
                        }
                        else
                            ///chọn 1 kỳ
                            if (cmbKy_PhanTich.SelectedIndex > 0)
                            {
                                for (int i = 1; i < cmbTo_PhanTich.Items.Count; i++)
                                    dt.Merge(_cDichVuThu.GetPhanTichChuyenKhoan("TG", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), ((TT_To)cmbTo_PhanTich.Items[i]).MaTo, int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()), dateGiaiTrach.Value));
                            }
                        dgvTo_TuGia_PhanTich.DataSource = dt;
                    }
                    ///chọn 1 tổ
                    else
                        if (cmbTo_PhanTich.SelectedIndex > 0)
                            ///chọn tất cả kỳ
                            if (cmbKy_PhanTich.SelectedIndex == 0)
                                dgvTo_TuGia_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan("TG", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(cmbTo_PhanTich.SelectedValue.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), dateGiaiTrach.Value);
                            else
                                ///chọn 1 kỳ
                                if (cmbKy_PhanTich.SelectedIndex > 0)
                                    dgvTo_TuGia_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan("TG", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(cmbTo_PhanTich.SelectedValue.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()), dateGiaiTrach.Value);
                }
                else
                {
                    ///chọn tất cả tổ
                    if (cmbTo_PhanTich.SelectedIndex == 0)
                    {
                        DataTable dt = new DataTable();
                        ///chọn tất cả kỳ
                        if (cmbKy_PhanTich.SelectedIndex == 0)
                        {
                            for (int i = 1; i < cmbTo_PhanTich.Items.Count; i++)
                                dt.Merge(_cDichVuThu.GetPhanTichChuyenKhoan("TG", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), ((TT_To)cmbTo_PhanTich.Items[i]).MaTo, int.Parse(cmbNam_PhanTich.SelectedValue.ToString())));
                        }
                        else
                            ///chọn 1 kỳ
                            if (cmbKy_PhanTich.SelectedIndex > 0)
                            {
                                for (int i = 1; i < cmbTo_PhanTich.Items.Count; i++)
                                    dt.Merge(_cDichVuThu.GetPhanTichChuyenKhoan("TG", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), ((TT_To)cmbTo_PhanTich.Items[i]).MaTo, int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString())));
                            }
                        dgvTo_TuGia_PhanTich.DataSource = dt;
                    }
                    ///chọn 1 tổ
                    else
                        if (cmbTo_PhanTich.SelectedIndex > 0)
                            ///chọn tất cả kỳ
                            if (cmbKy_PhanTich.SelectedIndex == 0)
                                dgvTo_TuGia_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan("TG", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(cmbTo_PhanTich.SelectedValue.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()));
                            else
                                ///chọn 1 kỳ
                                if (cmbKy_PhanTich.SelectedIndex > 0)
                                    dgvTo_TuGia_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan("TG", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(cmbTo_PhanTich.SelectedValue.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()));
                }
                CountdgvTo_TuGia_PhanTich();
            }
            else
                if (tabControl2.SelectedTab.Name == "tabCoQuan")
                {
                    if (chkNgayKiemTra.Checked == true)
                    {
                        ///chọn tất cả tổ
                        if (cmbTo_PhanTich.SelectedIndex == 0)
                        {
                            DataTable dt = new DataTable();
                            ///chọn tất cả kỳ
                            if (cmbKy_PhanTich.SelectedIndex == 0)
                            {
                                for (int i = 1; i < cmbTo_PhanTich.Items.Count; i++)
                                    dt.Merge(_cDichVuThu.GetPhanTichChuyenKhoan("CQ", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), ((TT_To)cmbTo_PhanTich.Items[i]).MaTo, int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), dateGiaiTrach.Value));
                            }
                            else
                                ///chọn 1 kỳ
                                if (cmbKy_PhanTich.SelectedIndex > 0)
                                {
                                    for (int i = 1; i < cmbTo_PhanTich.Items.Count; i++)
                                        dt.Merge(_cDichVuThu.GetPhanTichChuyenKhoan("CQ", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), ((TT_To)cmbTo_PhanTich.Items[i]).MaTo, int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()), dateGiaiTrach.Value));
                                }
                            dgvTo_CoQuan_PhanTich.DataSource = dt;
                        }
                        ///chọn 1 tổ
                        else
                            if (cmbTo_PhanTich.SelectedIndex > 0)
                                ///chọn tất cả kỳ
                                if (cmbKy_PhanTich.SelectedIndex == 0)
                                    dgvTo_CoQuan_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan("CQ", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(cmbTo_PhanTich.SelectedValue.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), dateGiaiTrach.Value);
                                else
                                    ///chọn 1 kỳ
                                    if (cmbKy_PhanTich.SelectedIndex > 0)
                                        dgvTo_CoQuan_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan("CQ", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(cmbTo_PhanTich.SelectedValue.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()), dateGiaiTrach.Value);
                    }
                    else
                    {
                        ///chọn tất cả tổ
                        if (cmbTo_PhanTich.SelectedIndex == 0)
                        {
                            DataTable dt = new DataTable();
                            ///chọn tất cả kỳ
                            if (cmbKy_PhanTich.SelectedIndex == 0)
                            {
                                for (int i = 1; i < cmbTo_PhanTich.Items.Count; i++)
                                    dt.Merge(_cDichVuThu.GetPhanTichChuyenKhoan("CQ", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), ((TT_To)cmbTo_PhanTich.Items[i]).MaTo, int.Parse(cmbNam_PhanTich.SelectedValue.ToString())));
                            }
                            else
                                ///chọn 1 kỳ
                                if (cmbKy_PhanTich.SelectedIndex > 0)
                                {
                                    for (int i = 1; i < cmbTo_PhanTich.Items.Count; i++)
                                        dt.Merge(_cDichVuThu.GetPhanTichChuyenKhoan("CQ", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), ((TT_To)cmbTo_PhanTich.Items[i]).MaTo, int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString())));
                                }
                            dgvTo_CoQuan_PhanTich.DataSource = dt;
                        }
                        ///chọn 1 tổ
                        else
                            if (cmbTo_PhanTich.SelectedIndex > 0)
                                ///chọn tất cả kỳ
                                if (cmbKy_PhanTich.SelectedIndex == 0)
                                    dgvTo_CoQuan_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan("CQ", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(cmbTo_PhanTich.SelectedValue.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()));
                                else
                                    ///chọn 1 kỳ
                                    if (cmbKy_PhanTich.SelectedIndex > 0)
                                        dgvTo_CoQuan_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan("CQ", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(cmbTo_PhanTich.SelectedValue.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()));
                    }
                    CountdgvTo_CoQuan_PhanTich();
                }
        }

        private void dgvTo_TuGia_PhanTich_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTo_TuGia_PhanTich.RowCount > 0)
            {
                if (chkNgayKiemTra.Checked == true)
                {
                    ///chọn tất cả kỳ
                    if (cmbKy_PhanTich.SelectedIndex == 0)
                        dgvNhanVien_TuGia_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan_NV("TG",int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(dgvTo_TuGia_PhanTich.CurrentRow.Cells["MaTo"].Value.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), dateGiaiTrach.Value);
                    else
                        ///chọn 1 kỳ
                        if (cmbKy_PhanTich.SelectedIndex > 0)
                            dgvNhanVien_TuGia_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan_NV("TG", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(dgvTo_TuGia_PhanTich.CurrentRow.Cells["MaTo"].Value.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()), dateGiaiTrach.Value);
                }
                else
                {
                    ///chọn tất cả kỳ
                    if (cmbKy_PhanTich.SelectedIndex == 0)
                        dgvNhanVien_TuGia_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan_NV("TG", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(dgvTo_TuGia_PhanTich.CurrentRow.Cells["MaTo"].Value.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()));
                    else
                        ///chọn 1 kỳ
                        if (cmbKy_PhanTich.SelectedIndex > 0)
                            dgvNhanVien_TuGia_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan_NV("TG", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(dgvTo_TuGia_PhanTich.CurrentRow.Cells["MaTo"].Value.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()));
                }
                CountdgvNhanVien_TuGia_PhanTich();
            }
        }

        private void dgvTo_TuGia_PhanTich_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTo_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongHDCKB_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanCKB_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongCongCKB_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongHDCK_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanCK_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongCongCK_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongHDKhongCK_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanKhongCK_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongCongKhongCK_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTo_TuGia_PhanTich_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTo_TuGia_PhanTich.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvNhanVien_TuGia_PhanTich_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongHDCK_NV_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanCK_NV_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongCongCK_NV_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongHDChuaCK_NV_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanChuaCK_NV_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_TuGia_PhanTich.Columns[e.ColumnIndex].Name == "TongCongChuaCK_NV_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvNhanVien_TuGia_PhanTich_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNhanVien_TuGia_PhanTich.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTo_CoQuan_PhanTich_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTo_CoQuan_PhanTich.RowCount > 0)
            {
                if (chkNgayKiemTra.Checked == true)
                {
                    ///chọn tất cả kỳ
                    if (cmbKy_PhanTich.SelectedIndex == 0)
                        dgvNhanVien_CoQuan_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan_NV("CQ", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(dgvTo_CoQuan_PhanTich.CurrentRow.Cells["MaTo"].Value.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), dateGiaiTrach.Value);
                    else
                        ///chọn 1 kỳ
                        if (cmbKy_PhanTich.SelectedIndex > 0)
                            dgvNhanVien_CoQuan_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan_NV("CQ", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(dgvTo_CoQuan_PhanTich.CurrentRow.Cells["MaTo"].Value.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()), dateGiaiTrach.Value);
                }
                else
                {
                    ///chọn tất cả kỳ
                    if (cmbKy_PhanTich.SelectedIndex == 0)
                        dgvNhanVien_CoQuan_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan_NV("CQ", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(dgvTo_CoQuan_PhanTich.CurrentRow.Cells["MaTo"].Value.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()));
                    else
                        ///chọn 1 kỳ
                        if (cmbKy_PhanTich.SelectedIndex > 0)
                            dgvNhanVien_CoQuan_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan_NV("CQ", int.Parse(cmbNganHang_PhanTich.SelectedValue.ToString()), int.Parse(dgvTo_CoQuan_PhanTich.CurrentRow.Cells["MaTo"].Value.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()));
                }
                CountdgvNhanVien_CoQuan_PhanTich();
            }
        }

        private void dgvTo_CoQuan_PhanTich_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTo_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongHDCKB_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanCKB_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongCongCKB_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongHDCK_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanCK_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongCongCK_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongHDKhongCK_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanKhongCK_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongCongKhongCK_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTo_CoQuan_PhanTich_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTo_CoQuan_PhanTich.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvNhanVien_CoQuan_PhanTich_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongHDCK_NV_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanCK_NV_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongCongCK_NV_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongHDChuaCK_NV_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanChuaCK_NV_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_CoQuan_PhanTich.Columns[e.ColumnIndex].Name == "TongCongChuaCK_NV_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvNhanVien_CoQuan_PhanTich_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNhanVien_CoQuan_PhanTich.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }




        public void CountdgvDichVuThu()
        {
            long TongCong = 0;

            if (dgvDichVuThu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvDichVuThu.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongCong"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong"].Value.ToString());
                }
                txtTongHD_HD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvDichVuThu.RowCount);
                txtTongCong_HD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void btnXem_HD_Click(object sender, EventArgs e)
        {
            ///chọn tất cả tổ
            if (cmbTo_HD.SelectedIndex == 0)
            {
                DataTable dt = new DataTable();
                ///chọn tất cả kỳ
                if (cmbKy_HD.SelectedIndex == 0)
                {
                    for (int i = 1; i < cmbTo_HD.Items.Count; i++)
                        dt.Merge(_cDichVuThu.GetDS(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), ((TT_To)cmbTo_HD.Items[i]).MaTo, int.Parse(cmbNam_HD.SelectedValue.ToString())));
                    DataTable dtBD = new DataTable();
                    for (int i = 1; i <= 12; i++)
                    {
                        dtBD.Merge(_cDichVuThu.GetBienDongChuyenKhoan(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), i));
                    }
                    dgvBienDong_HD.DataSource = dtBD;
                }
                else
                    ///chọn 1 kỳ
                    if (cmbKy_HD.SelectedIndex > 0)
                        ///chọn tất cả đợt
                        if (cmbFromDot_HD.SelectedIndex == 0)
                        {
                            for (int i = 1; i < cmbTo_HD.Items.Count; i++)
                                dt.Merge(_cDichVuThu.GetDS(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), ((TT_To)cmbTo_HD.Items[i]).MaTo, int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString())));
                            dgvBienDong_HD.DataSource = _cDichVuThu.GetBienDongChuyenKhoan(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()));
                        }
                        else
                            ///chọn từ đợt đến đợt
                            if (cmbFromDot_HD.SelectedIndex > 0)
                                for (int i = 1; i < cmbTo_HD.Items.Count; i++)
                                    dt.Merge(_cDichVuThu.GetDS(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), ((TT_To)cmbTo_HD.Items[i]).MaTo, int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()), int.Parse(cmbFromDot_HD.SelectedItem.ToString()), int.Parse(cmbToDot_HD.SelectedItem.ToString())));
                dgvDichVuThu.DataSource = dt;
            }
            ///chọn 1 tổ
            else
                if (cmbTo_HD.SelectedIndex > 0)
                    ///chọn tất cả nhân viên
                    if (cmbNhanVien_HD.SelectedIndex == 0)
                    {
                        ///chọn tất cả kỳ
                        if (cmbKy_HD.SelectedIndex == 0)
                        {
                            dgvDichVuThu.DataSource = _cDichVuThu.GetDS(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), int.Parse(cmbTo_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()));
                            DataTable dt = new DataTable();
                            for (int i = 1; i <= 12; i++)
                            {
                                dt.Merge(_cDichVuThu.GetBienDongChuyenKhoan(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), int.Parse(cmbTo_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), i));
                            }
                            dgvBienDong_HD.DataSource = dt;
                        }
                        else
                            ///chọn 1 kỳ
                            if (cmbKy_HD.SelectedIndex > 0)
                                ///chọn tất cả đợt
                                if (cmbFromDot_HD.SelectedIndex == 0)
                                {
                                    dgvDichVuThu.DataSource = _cDichVuThu.GetDS(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), int.Parse(cmbTo_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()));
                                    dgvBienDong_HD.DataSource = _cDichVuThu.GetBienDongChuyenKhoan(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), int.Parse(cmbTo_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()));
                                }
                                else
                                    ///chọn từ đợt đến đợt
                                    if (cmbFromDot_HD.SelectedIndex > 0)
                                        dgvDichVuThu.DataSource = _cDichVuThu.GetDS(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), int.Parse(cmbTo_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()), int.Parse(cmbFromDot_HD.SelectedItem.ToString()), int.Parse(cmbToDot_HD.SelectedItem.ToString()));
                    }
                    else
                        ///chọn 1 nhân viên
                        if (cmbNhanVien_HD.SelectedIndex > 0)
                        {
                            ///chọn tất cả kỳ
                            if (cmbKy_HD.SelectedIndex == 0)
                            {
                                dgvDichVuThu.DataSource = _cDichVuThu.GetDS_NV(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), int.Parse(cmbNhanVien_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()));
                                DataTable dt = new DataTable();
                                for (int i = 1; i <= 12; i++)
                                {
                                    dt.Merge(_cDichVuThu.GetBienDongChuyenKhoan_NV(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), int.Parse(cmbNhanVien_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), i));
                                }
                                dgvBienDong_HD.DataSource = dt;
                            }
                            else
                                ///chọn 1 kỳ
                                if (cmbKy_HD.SelectedIndex > 0)
                                    ///chọn tất cả đợt
                                    if (cmbFromDot_HD.SelectedIndex == 0)
                                    {
                                        dgvDichVuThu.DataSource = _cDichVuThu.GetDS_NV(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), int.Parse(cmbNhanVien_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()));
                                        dgvBienDong_HD.DataSource = _cDichVuThu.GetBienDongChuyenKhoan_NV(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), int.Parse(cmbNhanVien_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()));
                                    }
                                    else
                                        ///chọn từ đợt đến đợt
                                        if (cmbFromDot_HD.SelectedIndex > 0)
                                            dgvDichVuThu.DataSource = _cDichVuThu.GetDS_NV(int.Parse(cmbNganHang_HD.SelectedValue.ToString()), int.Parse(cmbNhanVien_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()), int.Parse(cmbFromDot_HD.SelectedItem.ToString()), int.Parse(cmbToDot_HD.SelectedItem.ToString()));
                        }
            CountdgvDichVuThu();
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
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
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

        private void cmbTo_HD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTo_HD.SelectedIndex > 0)
            {
                List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo_HD.SelectedValue.ToString()));
                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = 0;
                nguoidung.HoTen = "Tất Cả";
                lstND.Insert(0, nguoidung);
                cmbNhanVien_HD.DataSource = lstND;
                cmbNhanVien_HD.DisplayMember = "HoTen";
                cmbNhanVien_HD.ValueMember = "MaND";
            }
            else
            {
                cmbNhanVien_HD.DataSource = null;
            }
        }

        private void chkNgayKiemTra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayKiemTra.Checked == true)
                dateGiaiTrach.Enabled = true;
            else
                dateGiaiTrach.Enabled = false;
        }

        private void cmbNam_HD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbNam_HD.SelectedIndex >= 0)
                {
                    //DataTable dt = _cHoaDon.GetGroupGiaBieu(int.Parse(cmbNam_HD.SelectedValue.ToString()));
                    //DataRow dr = dt.NewRow();
                    //dr["GiaBieu"] = "Tất Cả";
                    //dt.Rows.InsertAt(dr, 0);
                    //cmbGiaBieu_HD.DataSource = dt;
                    //cmbGiaBieu_HD.DisplayMember = "GiaBieu";
                    //cmbGiaBieu_HD.ValueMember = "GiaBieu";
                }
            }
            catch (Exception)
            {
            }
        }

       
    }
}
