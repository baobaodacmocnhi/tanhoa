using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTCN_CongVan.DAL.QuanTri;
using KTCN_CongVan.LinQ;
using System.Net;
using System.Net.Sockets;

namespace KTCN_CongVan.GUI.HeThong
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
                CUser _cUser = new CUser();

                if (_cUser.DangNhap(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim()))
                {
                    User en = _cUser.GetByTaiKhoan(txtTaiKhoan.Text.Trim());
                    if (en != null)
                    {
                        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
                        CPhanQuyenUser _cPhanQuyenNguoiDung = new CPhanQuyenUser();

                        CUser.ID = en.ID;
                        CUser.HoTen = en.Name;
                        CUser.Admin = en.Admin;
                        if (en.Admin == false)
                            CUser.IDPhong = en.IDPhong.Value;

                        if (en.IDNhom != null)
                        {
                            CUser.dtQuyenNhom = _cPhanQuyenNhom.getDS(true, en.IDNhom.Value);
                            CUser.IDNhom = en.IDNhom.Value;
                        }
                        CUser.dtQuyenNguoiDung = _cPhanQuyenNguoiDung.GetDSByMaND(true, en.ID);

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
