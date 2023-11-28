using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using System.Net;
using System.Net.Sockets;

namespace ThuTien.GUI.HeThong
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public delegate void GetValue(bool result);
        public GetValue GetLoginResult;

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            try
            {
                CTo _ct = new CTo();
                CNguoiDung _cNguoiDung = new CNguoiDung();

                if (_cNguoiDung.DangNhap(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim()))
                {
                    TT_NguoiDung nguoidung = _cNguoiDung.GetByTaiKhoan(txtTaiKhoan.Text.Trim());
                    if (nguoidung != null)
                    {
                        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
                        CPhanQuyenNguoiDung _cPhanQuyenNguoiDung = new CPhanQuyenNguoiDung();

                        CNguoiDung.MaND = nguoidung.MaND;
                        CNguoiDung.HoTen = nguoidung.HoTen;
                        CNguoiDung.MaKemBamChi = nguoidung.MaKemBamChi;
                        CNguoiDung.Admin = nguoidung.Admin;
                        CNguoiDung.PhoGiamDoc = nguoidung.PhoGiamDoc;
                        CNguoiDung.Doi = nguoidung.Doi;
                        CNguoiDung.ToTruong = nguoidung.ToTruong;
                        CNguoiDung.ChucVu = _cNguoiDung.getChucVu();
                        CNguoiDung.NguoiKy = _cNguoiDung.getNguoiKy();
                        CNguoiDung.SyncNopTien = nguoidung.SyncNopTien;
                        if (nguoidung.MaTo != null)
                        {
                            CNguoiDung.IDPhong = nguoidung.TT_To.IDPhong.Value;
                            CNguoiDung.TenPhong = nguoidung.TT_To.Phong.Name;
                            CNguoiDung.TuDot = nguoidung.TT_To.Phong.TuDot.Value;
                            CNguoiDung.DenDot = nguoidung.TT_To.Phong.DenDot.Value;
                            CNguoiDung.MaTo = nguoidung.MaTo.Value;
                            CNguoiDung.TenTo = nguoidung.TT_To.TenTo;
                            if (_ct.get(nguoidung.MaTo.Value).TuMay != null)
                                CNguoiDung.TuMayDS = _ct.get(nguoidung.MaTo.Value).TuMay.Value;
                            if (_ct.get(nguoidung.MaTo.Value).DenMay != null)
                                CNguoiDung.DenMayDS = _ct.get(nguoidung.MaTo.Value).DenMay.Value;
                        }
                        else
                        {
                            CNguoiDung.IDPhong = 0;
                            CNguoiDung.TenPhong = "";
                            CNguoiDung.TuDot = 0;
                            CNguoiDung.DenDot = 0;
                            CNguoiDung.MaTo = 0;
                            CNguoiDung.TenTo = "";
                            CNguoiDung.TuMayDS = 0;
                            CNguoiDung.DenMayDS = 0;
                        }
                        if (nguoidung.MaNhom != null)
                            CNguoiDung.dtQuyenNhom = _cPhanQuyenNhom.GetDSByMaNhom(true, nguoidung.MaNhom.Value);
                        CNguoiDung.dtQuyenNguoiDung = _cPhanQuyenNguoiDung.GetDSByMaND(true, nguoidung.MaND);

                        //CNguoiDung.Name_PC = SystemInformation.ComputerName;
                        //var host = Dns.GetHostEntry(Dns.GetHostName());
                        //foreach (var ip in host.AddressList)
                        //{
                        //    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        //    {
                        //        CNguoiDung.IP_PC = ip.ToString();
                        //    }
                        //}
                        //TT_DangNhap en = new TT_DangNhap();
                        //en.MaND = nguoidung.MaND;
                        //en.Name_PC = CNguoiDung.Name_PC;
                        //en.IP_PC = CNguoiDung.IP_PC;
                        ////if (_cNguoiDung.DangNhap(en))
                        ////    CNguoiDung.ID_DangNhap = en.ID;
                        GetLoginResult(true);
                        this.Hide();
                    }
                }
                else
                    MessageBox.Show("Sai Tài Khoản hoặc Mật Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
