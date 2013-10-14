using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.GUI.HeThong
{
    public partial class frmDangNhap : Form
    {
        CDangNhap _CDangNhap = new CDangNhap();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public delegate void GetValue(bool result);
        public GetValue GetLoginResult;

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
           if(_CDangNhap.DangNhap(txtTaiKhoan.Text.Trim(),txtMatKhau.Text.Trim()))
           {
               this.Hide();
               GetLoginResult(true);
           }
           

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

    }
}
