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
    public partial class frmDoiMatKhau : Form
    {
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text.Trim() != "" && txtMatKhauMoi.Text.Trim() != "" && txtXNMatKhauMoi.Text.Trim() != "")
                if (txtMatKhauMoi.Text.Trim() == txtXNMatKhauMoi.Text.Trim())
                {
                    _cTaiKhoan.ThayDoiMatKhau(txtMatKhauCu.Text.Trim(), txtMatKhauMoi.Text.Trim());
                    txtMatKhauCu.Text = "";
                    txtMatKhauMoi.Text = "";
                    txtXNMatKhauMoi.Text = "";
                }
                else
                    MessageBox.Show("Xác nhận Mật khẩu không giống nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
