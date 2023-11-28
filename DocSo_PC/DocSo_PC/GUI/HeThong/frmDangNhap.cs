using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using DocSo_PC.DAL;

namespace DocSo_PC.GUI.HeThong
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
            Application.Exit();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnDangNhap.PerformClick();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            CNguoiDung _cNguoiDung = new CNguoiDung();
            CTo _ct = new CTo();
            CLichDocSo _cLDS = new CLichDocSo();
            if (_cNguoiDung.DangNhap(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim()))
            {
                NguoiDung nguoidung = _cNguoiDung.GetByTaiKhoan(txtTaiKhoan.Text.Trim());
                if (nguoidung != null)
                {
                    CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
                    CPhanQuyenNguoiDung _cPhanQuyenNguoiDung = new CPhanQuyenNguoiDung();

                    CNguoiDung.MaND = nguoidung.MaND;
                    CNguoiDung.TaiKhoan = nguoidung.TaiKhoan;
                    CNguoiDung.HoTen = nguoidung.HoTen;
                    CNguoiDung.Admin = nguoidung.Admin;
                    CNguoiDung.PhoGiamDoc = nguoidung.PhoGiamDoc;
                    CNguoiDung.Doi = nguoidung.Doi;
                    CNguoiDung.DoiXem = nguoidung.DoiXem;
                    CNguoiDung.ToTruong = nguoidung.ToTruong;
                    CNguoiDung.ThuKy = nguoidung.ThuKy;
                    CNguoiDung.ChucVu = _cNguoiDung.getChucVu();
                    CNguoiDung.NguoiKy = _cNguoiDung.getNguoiKy();
                    CNguoiDung.updateChuyenListing = nguoidung.updateChuyenListing;
                    if (nguoidung.MaTo != null)
                    {
                        CNguoiDung.IDPhong = nguoidung.To.IDPhong.Value;
                        CNguoiDung.TenPhong = nguoidung.To.Phong.Name;
                        CNguoiDung.TuDot = nguoidung.To.Phong.TuDot.Value;
                        CNguoiDung.DenDot = nguoidung.To.Phong.DenDot.Value;
                        CNguoiDung.MaTo = nguoidung.MaTo.Value;
                        CNguoiDung.TenTo = nguoidung.To.TenTo;
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
                    string NamKyDot = _cLDS.getNamKyDot(DateTime.Now);
                    if (NamKyDot != "")
                    {
                        string[] NamKyDots = NamKyDot.Split('-');
                        CNguoiDung.Nam = NamKyDots[0];
                        CNguoiDung.Ky = NamKyDots[1];
                        CNguoiDung.Dot = NamKyDots[2];
                    }
                    else
                    {
                        CNguoiDung.Nam = DateTime.Now.Year.ToString();
                        CNguoiDung.Ky = DateTime.Now.Month.ToString("00");
                        CNguoiDung.Dot = "01";
                    }
                    GetLoginResult(true);
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Sai Tài Khoản hoặc Mật Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
