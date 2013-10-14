using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.GUI.HeThong;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH
{
    public partial class Main : RibbonForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ribbtnDangNhap_Click(sender, e);
        }

        public void GetLoginResult(bool result)
        {
            if (result)
            {
                ribbtnDangNhap.Enabled = false;
                ribbtnDangXuat.Enabled = true;
                ribbtnDoiMatKhau.Enabled = true;
                StripStatus_TaiKhoan.Text = "Tài Khoản đang dùng: " + CDangNhap.TaiKhoan;
            }
        }

        private void ribbtnDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.GetLoginResult = new frmDangNhap.GetValue(GetLoginResult);
            frm.ShowDialog();
        }

        private void ribbtnDangXuat_Click(object sender, EventArgs e)
        {
            ribbtnDangNhap.Enabled = true;
            ribbtnDangXuat.Enabled = false;
            ribbtnDoiMatKhau.Enabled = false;

            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            ribbtnDangNhap_Click(sender, e);
            StripStatus_TaiKhoan.Text = "";
        }

        private void ribbtnDoiMatKhau_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (item.GetType() == typeof(frmDoiMatKhau))
                {
                    item.Activate();
                    return;
                }
            }
            Form frm = new frmDoiMatKhau();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbtnTaiKhoan_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (item.GetType() == typeof(frmTaiKhoan))
                {
                    item.Activate();
                    return;
                }
            }
            Form frm = new frmTaiKhoan();
            frm.MdiParent = this;
            frm.Show();
        }

        
    }
}
