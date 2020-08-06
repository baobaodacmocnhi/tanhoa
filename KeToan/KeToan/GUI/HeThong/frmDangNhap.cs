using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeToan.DAL.QuanTri;
using KeToan.LinQ;

namespace KeToan.GUI.HeThong
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
            //btnDangNhap.PerformClick();
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
            try
            {
                CUser cUser = new CUser();

                if (cUser.DangNhap(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim()))
                {
                    User user = cUser.Get(txtTaiKhoan.Text.Trim());
                    if (user != null)
                    {
                        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
                        CPhanQuyenUser _cPhanQuyenUser = new CPhanQuyenUser();

                        CUser.MaUser = user.ID;
                        CUser.Name = user.Name;
                        CUser.Admin = user.Admin;
                        if (user.MaNhom != null)
                            CUser.dtQuyenNhom = _cPhanQuyenNhom.GetDS(user.MaNhom.Value);
                        CUser.dtQuyenNguoiDung = _cPhanQuyenUser.GetDS(user.ID);

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
