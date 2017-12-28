using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.GUI.HeThong;
using DocSo_PC.GUI.QuanTri;
using DocSo_PC.GUI.ChuanBiDocSo;
using DocSo_PC.GUI.XuLyDocSo;
using DocSo_PC.GUI.ChuyenBillding;

namespace DocSo_PC
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

        public void GetLoginResult(bool result)
        {
            if (result)
            {
                mnuDangNhap.Enabled = false;
                mnuDoiMatKhau.Enabled = true;
                mnuDangXuat.Enabled = true;
                StripStatus_HoTen.Text = "Xin Chào: " + CNguoiDung.HoTen;
                if (CNguoiDung.MaND == 0)
                    mnuAdmin.Enabled = true;
                else
                    mnuAdmin.Enabled = false;
            }
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void OpenForm(Form frm)
        {
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
            mnuDangNhap_Click(sender, e);
        }

        private void mnuAdmin_Click(object sender, EventArgs e)
        {
            frmAdmin frm = new frmAdmin();
            OpenForm(frm);
        }

        #endregion

        #region Quản Trị

        private void mnuTo_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTo", "Xem"))
            {
                frmTo frm = new frmTo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuNhom_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuNhom", "Xem"))
            {
                frmNhom frm = new frmNhom();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuNguoiDung_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuNguoiDung", "Xem"))
            {
                frmNguoiDung frm = new frmNguoiDung();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Chuẩn Bị Đọc Số

        private void mnuLuuHD_Click(object sender, EventArgs e)
        {
            //if (CNguoiDung.CheckQuyen("mnuLuuHD", "Xem"))
            //{
            frmCapNhatHoaDon frm = new frmCapNhatHoaDon();
            OpenForm(frm);
            //}
            //else
            //    MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuCapNhatBienDong_Click(object sender, EventArgs e)
        {
            //if (CNguoiDung.CheckQuyen("mnuLuuHD", "Xem"))
            //{
            frmCapNhatBienDong frm = new frmCapNhatBienDong();
            OpenForm(frm);
            //}
            //else
            //    MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }
        private void mnuTaoDuLieu_Click(object sender, EventArgs e)
        {
            //if (CNguoiDung.CheckQuyen("mnuLuuHD", "Xem"))
            //{
            frmTaoDocSo frm = new frmTaoDocSo();
            OpenForm(frm);
            //}
            //else
            //    MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void mnGiaoTangCuong_Click(object sender, EventArgs e)
        {
            //if (CNguoiDung.CheckQuyen("mnuLuuHD", "Xem"))
            //{
            frmGiaoTangCuong frm = new frmGiaoTangCuong();
            OpenForm(frm);
            //}
            //else
            //    MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Điều chỉnh dữ liệu đọc số
        private void mnuKiemSoatDS_Click(object sender, EventArgs e)
        {
            frmKiemSoatDocSo frm = new frmKiemSoatDocSo();
            OpenForm(frm);
            
        }

       

        private void mnuDieuChinhDS_Click(object sender, EventArgs e)
        {
            frmDieuChinhDocSo frm = new frmDieuChinhDocSo();
            OpenForm(frm);
        }
         #endregion

          #region Chuyển dữ liệu billding2
        private void mnuKiemsoatDL_Click(object sender, EventArgs e)
        {
            frmKiemTraDuLieu frm = new frmKiemTraDuLieu();
            OpenForm(frm);
            
        }
          #endregion
    }
}