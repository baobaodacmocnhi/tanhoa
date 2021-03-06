﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.HeThong
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public delegate void GetValue(bool result);
        public GetValue GetLoginResult;

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            CTaiKhoan _CTaiKhoan = new CTaiKhoan();
            if (_CTaiKhoan.DangNhap(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim()))
            {
                User nguoidung = _CTaiKhoan.Get(txtTaiKhoan.Text.Trim());
                if (nguoidung != null)
                {
                    CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
                    CPhanQuyenNguoiDung _cPhanQuyenNguoiDung = new CPhanQuyenNguoiDung();

                    CTaiKhoan.MaUser = nguoidung.MaU;
                    if (nguoidung.MaTo != null)
                        CTaiKhoan.MaTo = nguoidung.MaTo.Value;
                    if (nguoidung.MaNhom != null)
                        CTaiKhoan.MaNhom = nguoidung.MaNhom.Value;
                    CTaiKhoan.TaiKhoan = nguoidung.TaiKhoan;
                    CTaiKhoan.HoTen = nguoidung.HoTen;
                    CTaiKhoan.MaKiemBamChi = nguoidung.MaKiemBamChi;
                    CTaiKhoan.Admin = nguoidung.Admin;
                    CTaiKhoan.ThuKy = nguoidung.ThuKy;

                    if (nguoidung.MaTo != null)
                    {
                        //if ("ToGD" == nguoidung.To.KyHieu)
                        //{
                        //    CTaiKhoan.ToGD = true;
                        //}
                        //else
                        //    if ("ToTB" == nguoidung.To.KyHieu)
                        //    {
                        //        CTaiKhoan.ToTB = true;
                        //    }
                        //    else
                        //        if ("ToTP" == nguoidung.To.KyHieu)
                        //        {
                        //            CTaiKhoan.ToTP = true;
                        //        }
                        //        else
                        //            if ("ToBC" == nguoidung.To.KyHieu)
                        //            {
                        //                CTaiKhoan.ToBC = true;
                        //            }
                        CTaiKhoan.KyHieuMaTo = nguoidung.To.KyHieu;
                        CTaiKhoan.TenTo = nguoidung.To.TenTo;
                    }
                    CTaiKhoan.ToTruong = nguoidung.ToTruong;
                    CTaiKhoan.PhoGiamDoc = nguoidung.PhoGiamDoc;
                    CTaiKhoan.TruongPhong = nguoidung.TruongPhong;
                    CTaiKhoan.MaPhong = nguoidung.MaPhong.Value;
                    CTaiKhoan.TenPhong = nguoidung.Phong.Name;
                    CTaiKhoan.KyHieuPhong = nguoidung.Phong.KyHieu;
                    CTaiKhoan.ChucVu = nguoidung.Phong.Users.SingleOrDefault(item => item.MaPhong.Value == nguoidung.MaPhong.Value && item.ChuKy == true).ChucVu;
                    CTaiKhoan.NguoiKy = nguoidung.Phong.Users.SingleOrDefault(item => item.MaPhong.Value == nguoidung.MaPhong.Value && item.ChuKy == true).HoTen;
                    if (nguoidung.MaNhom != null)
                        CTaiKhoan.dtQuyenNhom = _cPhanQuyenNhom.GetDSByMaNhom(true, nguoidung.MaNhom.Value);
                    CTaiKhoan.dtQuyenNguoiDung = _cPhanQuyenNguoiDung.GetDSByMaND(true, nguoidung.MaU);

                    DisableTimer();
                    this.Hide();
                    GetLoginResult(true);
                }
            }
            else
            {
                MessageBox.Show("Sai mật khẩu/Không kết nối csdl", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnDangNhap.PerformClick();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            //Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            IdleTimer.Interval = 10000;
            IdleTimer.Enabled = true;
            IdleTimer.Start();
            IdleTimer.Tick += new EventHandler(IdleTimer_Tick);
        }

        void IdleTimer_Tick(object sender, EventArgs e)
        {
            IdleTimer.Enabled = false;
            Application.Exit();
        }

        private void DisableTimer()
        {
            IdleTimer.Enabled = false;
            IdleTimer.Stop();
        }

        private void frmDangNhap_MouseMove(object sender, MouseEventArgs e)
        {
            DisableTimer();
        }

        private void frmDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            DisableTimer();
        }

    }
}
