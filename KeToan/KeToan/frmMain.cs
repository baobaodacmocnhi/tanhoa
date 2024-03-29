﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeToan.DAL.QuanTri;
using KeToan.GUI.HeThong;
using KeToan.GUI.QuanTri;
using KeToan.GUI.NhapLieu;
using KeToan.GUI.CapNhat;
using KeToan.GUI.HoaDonDienTu;
using KeToan.GUI.GiaiTrachTienNuoc;

namespace KeToan
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(Application_Idle);
            mnuDangNhap.PerformClick();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void GetLoginResult(bool result)
        {
            if (result)
            {
                mnuDangNhap.Enabled = false;
                mnuDoiMatKhau.Enabled = true;
                mnuDangXuat.Enabled = true;
                StripStatus_HoTen.Text = "Xin Chào: " + CUser.Name;
                if (CUser.MaUser == 0)
                    mnuAdmin.Enabled = true;
                else
                    mnuAdmin.Enabled = false;
            }
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
            CUser.initial();
            foreach (Form item in this.MdiChildren)
            {
                this.ActiveMdiChild.Close();
            }
            mnuDangNhap.Enabled = true;
            mnuDoiMatKhau.Enabled = false;
            mnuDangXuat.Enabled = false;
            StripStatus_HoTen.Text = "";
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

        #region Cập Nhật

        private void mnuNganHang_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuNganHang", "Xem"))
            {
                frmNganHang frm = new frmNganHang();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDoiTuong_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuDoiTuong", "Xem"))
            {
                frmDoiTuong frm = new frmDoiTuong();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Nhập Liệu

        private void mnuPhieuThu_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuPhieuThu", "Xem"))
            {
                frmPhieuThu frm = new frmPhieuThu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuPhieuChi_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuPhieuChi", "Xem"))
            {
                frmPhieuChi frm = new frmPhieuChi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuSoLieuChungTu_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuSoLieuChungTu", "Xem"))
            {
                frmSoLieuChungTu frm = new frmSoLieuChungTu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Hoa Đơn Điện Tử

        private void mnuBienLaiThuTien_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuBienLaiThuTien", "Xem"))
            {
                frmBienLaiThuTien frm = new frmBienLaiThuTien();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Giải Trách Tiền Nước

        private void mnuGiaiTrachTienNuoc_Nhap_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuGiaiTrachTienNuoc_Nhap", "Xem"))
            {
                frmGiaiTrachTienNuoc_Nhap frm = new frmGiaiTrachTienNuoc_Nhap();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuGiaiTrachTienNuoc_Xuat_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen("mnuGiaiTrachTienNuoc_Xuat", "Xem"))
            {
                frmGiaiTrachTienNuoc_Xuat frm = new frmGiaiTrachTienNuoc_Xuat();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
            
    }
}
