using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLVanThuDen
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtMatKhau.Text.Trim() == "vanthu@tchc")
                    this.Close();
                else
                    MessageBox.Show("Sai mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
