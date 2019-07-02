using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTCN_CongVan.DAL.QuanTri;
using KTCN_CongVan.GUI.QuanTri;
using KTCN_CongVan.GUI.HeThong;
using KTCN_CongVan.GUI.CongVan;
using KTCN_CongVan.GUI.ToThietKe;

namespace KTCN_CongVan
{
    public partial class frmMain : Form
    {
        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
        CPhanQuyenUser _cPhanQuyenUser = new CPhanQuyenUser();

        public frmMain()
        {
            InitializeComponent();
        }

        public void GetLoginResult(bool result)
        {
            if (result)
            {
                mnuDangNhap.Enabled = false;
                mnuDoiMatKhau.Enabled = true;
                mnuDangXuat.Enabled = true;
                StripStatus_HoTen.Text = "Xin Chào: " + CUser.HoTen;
                if (CUser.ID == 0)
                    mnuAdmin.Enabled = true;
                else
                    mnuAdmin.Enabled = false;

                foreach (ToolStripMenuItem itemParent in this.MainMenuStrip.Items)
                {
                    if (itemParent.Name == "mnuHeThong" || itemParent.Name == "mnuTimKiem")// || itemParent.Name == "mnuTrungTamKhachHang")
                        continue;
                    if (_cPhanQuyenNhom.checkExist_TenMenuChaMaNhom(itemParent.Name, CUser.IDNhom))
                        itemParent.Visible = true;
                    else
                        if (_cPhanQuyenUser.checkExist_TenMenuChaMaND(itemParent.Name, CUser.ID))
                            itemParent.Visible = true;
                        else
                            itemParent.Visible = false;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Application.Idle += new EventHandler(Application_Idle);
            mnuDangNhap.PerformClick();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            if (CUser.MaTo == 5 && CUser.ID != 51)
                timer.Stop();
            else
                timer.Start();
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            //timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Application.Exit();
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

        #region Hệ Thống

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
            StripStatus_HoTen.Text = "";
            CUser.ID = -1;
            CUser.HoTen = "";
            CUser.Admin = false;
            CUser.IDPhong = -1;
            CUser.IDNhom = -1;
            mnuDangNhap_Click(sender, e);
        }

        private void mnuAdmin_Click(object sender, EventArgs e)
        {
            frmAdmin frm = new frmAdmin();
            OpenForm(frm);
        }

        #endregion

        #region Quản Trị

        private void mnuNhom_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuNhom", "Xem"))
            {
                frmNhom frm = new frmNhom();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuUser_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuUser", "Xem"))
            {
                frmUser frm = new frmUser();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Công Văn

        private void mnuCongVanDen_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuCongVanDen", "Xem"))
            {
                frmCongVanDen frm = new frmCongVanDen();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuCongVanDi_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuCongVanDi", "Xem"))
            {
                frmCongVanDi frm = new frmCongVanDi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Tổ Thiết Kế

        private void mnuTimKiemTTK_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuTimKiemTTK", "Xem"))
            {
                frmToThietKe frm = new frmToThietKe();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        






    }
}
    