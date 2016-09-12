using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.GUI.HeThong;
using KTKS_DonKH.GUI.CapNhat;

namespace KTKS_DonKH
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            mnuDangNhap.PerformClick();
        }

        public void OpenForm(Form frm)
        {
            //foreach (Form item in this.MdiChildren)
            //{
            //    this.ActiveMdiChild.Close();
            //}
            //frm.MdiParent = this;
            //frm.FormBorderStyle = FormBorderStyle.None;
            //frm.Dock = DockStyle.Fill;
            //frm.Show();
            //StripStatus_Form.Text = "Đang mở Form: " + frm.Text;

            //foreach (Form form in Application.OpenForms)
            //{
            //    if (form.Name == frm.Name)
            //    {
            //        tabControl.TabPages.con;
            //        return;
            //    }
            //}
            if (tabControl.TabPages.ContainsKey(frm.Name))
            {
                tabControl.SelectedTab = tabControl.TabPages[frm.Name];
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabControl.SelectedTab != null) && (tabControl.SelectedTab.Tag != null))
                (tabControl.SelectedTab.Tag as Form).Select();
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                tabControl.Visible = false; // If no any child form, hide tabControl
            else
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized; // Child form always maximized

                foreach (TabPage item in tabControl.TabPages)
                {
                    if (this.ActiveMdiChild.Text == item.Text)
                        return;
                }

                // If child form is new and no has tabPage, create new tabPage
                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child form caption
                    TabPage tp = new TabPage();
                    tp.Name = this.ActiveMdiChild.Name;
                    tp.Text = this.ActiveMdiChild.Text;
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                }
                else
                {
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                    tabControl.SelectedTab = tp;
                }

                if (!tabControl.Visible) tabControl.Visible = true;
            }
        }

        // If child form closed, remove tabPage
        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        public void GetLoginResult(bool result)
        {
            if (result)
            {
                mnuDangNhap.Enabled = false;
                mnuDoiMatKhau.Enabled = true;
                mnuDangXuat.Enabled = true;
                //StripStatus_HoTen.Text = "Xin Chào: " + CNguoiDung.HoTen;
                //if (CNguoiDung.MaND == 0)
                //    mnuAdmin.Enabled = true;
                //else
                //    mnuAdmin.Enabled = false;
                //if (CNguoiDung.PhoGiamDoc)
                //    mnuPhoGiamDoc.Visible = true;
                //else
                //    mnuPhoGiamDoc.Visible = false;
            }
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.GetLoginResult = new frmDangNhap.GetValue(GetLoginResult);
            frm.ShowDialog();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            OpenForm(frm);
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
            {
                this.ActiveMdiChild.Close();
            }
            //StripStatus_HoTen.Text = "";
            //mnuPhoGiamDoc.Visible = false;
            mnuDangNhap_Click(sender, e);
        }

        private void mnuLoaiDon_Click(object sender, EventArgs e)
        {
            frmLoaiDon frm = new frmLoaiDon();
            OpenForm(frm);
        }

        private void mnuLoaiChungTu_Click(object sender, EventArgs e)
        {
            frmLoaiChungTu frm = new frmLoaiChungTu();
            OpenForm(frm);
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmTTKH frm = new frmTTKH();
            OpenForm(frm);
        }

        private void mnuChiNhanhCapNuoc_Click(object sender, EventArgs e)
        {
            frmChiNhanh frm = new frmChiNhanh();
            OpenForm(frm);
        }

        private void mnuGiaNuoc_Click(object sender, EventArgs e)
        {
            frmGiaNuoc frm = new frmGiaNuoc();
            OpenForm(frm);
        }

        private void mnuBanGiamDoc_Click(object sender, EventArgs e)
        {
            frmBanGiamDoc frm = new frmBanGiamDoc();
            OpenForm(frm);
        }

        
    }
}
