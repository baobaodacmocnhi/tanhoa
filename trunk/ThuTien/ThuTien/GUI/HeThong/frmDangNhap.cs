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
            btnDangNhap_Click(sender, e);
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
            CPhanQuyenNhom _cPhanQuyenNhom=new CPhanQuyenNhom();
            CPhanQuyenNguoiDung _cPhanQuyenNguoiDung=new CPhanQuyenNguoiDung();

            if (_cNguoiDung.DangNhap(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim()))
            {
                TT_NguoiDung nguoidung = _cNguoiDung.GetByTaiKhoan(txtTaiKhoan.Text.Trim());
                CNguoiDung.MaND = nguoidung.MaND;
                CNguoiDung.HoTen = nguoidung.HoTen;
                if (nguoidung.MaNhom != null)
                    CNguoiDung.dtQuyenNhom = _cPhanQuyenNhom.GetDSByMaNhom(nguoidung.MaNhom.Value);
                CNguoiDung.dtQuyenNguoiDung = _cPhanQuyenNguoiDung.GetDSByMaND(nguoidung.MaND);
                GetLoginResult(true);
                this.Hide();
            }
            else
                MessageBox.Show("Sai Tài Khoản hoặc Mật Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
