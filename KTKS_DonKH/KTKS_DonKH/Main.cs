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
using KTKS_DonKH.GUI.CapNhat;
using KTKS_DonKH.GUI.KhachHang;
using KTKS_DonKH.GUI.KiemTraXacMinh;
using KTKS_DonKH.GUI.DieuChinhBienDong;

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
                StripStatus_TaiKhoan.Text = "Tài Khoản đang dùng: " + CTaiKhoan.TaiKhoan;
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
            CTaiKhoan _CTaiKhoan = new CTaiKhoan();
            _CTaiKhoan.DangXuat();

            ribbtnDangNhap.Enabled = true;
            ribbtnDangXuat.Enabled = false;
            ribbtnDoiMatKhau.Enabled = false;
            StripStatus_TaiKhoan.Text = "";

            foreach (Form item in this.MdiChildren)
            {
                this.ActiveMdiChild.Close();
            }

            ribbtnDangNhap_Click(sender, e);  
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            CTaiKhoan _CTaiKhoan = new CTaiKhoan();
            _CTaiKhoan.DangXuat();
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
            //foreach (Form item in this.MdiChildren)
            //{
            //    if (item.GetType() == typeof(frmTaiKhoan))
            //    {
            //        item.Activate();
            //        return;
            //    }
            //}
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmTaiKhoan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbtnKhachHang_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmTTKH();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbtnLoaiDonThu_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmLoaiDon();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbtnChungTuMoi_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmLoaiChungTu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbtnNhanDon_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmNhanDonKH();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbtnQLDonKH_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmQLDonKH();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbtnDSDonKTXM_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmKTXM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbtnDSDonDCBD_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmDSDCBD();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbtnChiNhanh_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmChiNhanh();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbtnGiaNuoc_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmGiaNuoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbtnTest_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmTest();
            frm.MdiParent = this;
            frm.Show();
        }

        

        
    }
}
