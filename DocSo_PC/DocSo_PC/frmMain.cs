﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.GUI.QuanTri;
using DocSo_PC.GUI.Doi;
using DocSo_PC.GUI.ToTruong;
using DocSo_PC.GUI.HeThong;
using DocSo_PC.GUI.VanThu;
using DocSo_PC.GUI.BaoCao;
using DocSo_PC.GUI.sDHN;
using DocSo_PC.GUI.MaHoa;

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
            //Application.Idle += new EventHandler(Application_Idle);
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

        private void mnuNhanVienDocSo_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuNhanVienDocSo", "Xem"))
            {
                frmNhanVienDocSo frm = new frmNhanVienDocSo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Đội

        private void mnuTaoDot_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTaoDot", "Xem"))
            {
                frmTaoDot frm = new frmTaoDot();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuLichDocSo_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuLichDocSo", "Xem"))
            {
                frmLichDocSo frm = new frmLichDocSo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKhongTinhPBVMT_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKhongTinhPBVMT", "Xem"))
            {
                frmKhongTinhPBVMT frm = new frmKhongTinhPBVMT();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuChuyenBilling_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuChuyenBilling", "Xem"))
            {
                frmChuyenBilling frm = new frmChuyenBilling();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Tổ Trưởng

        private void mnuXuLySoLieu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuXuLySoLieu", "Xem"))
            {
                frmXuLySoLieu frm = new frmXuLySoLieu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTheoDoiDot_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTheoDoiDocSo", "Xem"))
            {
                frmTheoDoiDocSo frm = new frmTheoDoiDocSo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuGiaoTangCuong_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuGiaoTangCuong", "Xem"))
            {
                frmGiaoTangCuong frm = new frmGiaoTangCuong();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDocSoTruoc_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDocSoTruoc", "Xem"))
            {
                frmDocSoTruoc frm = new frmDocSoTruoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuGhiChu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuGhiChu", "Xem"))
            {
                frmGhiChu frm = new frmGhiChu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuPhieuChuyen_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuPhieuChuyen", "Xem"))
            {
                frmPhieuChuyen frm = new frmPhieuChuyen();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDHNDienTu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDHNDienTu", "Xem"))
            {
                frmDHNDienTu frm = new frmDHNDienTu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Mã Hóa

        private void mnuDonTu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDonTu", "Xem"))
            {
                frmDonTu frm = new frmDonTu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKTXM_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKTXM", "Xem"))
            {
                frmKTXM frm = new frmKTXM();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDieuChinhThongTin_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDCBD", "Xem"))
            {
                frmDCBD frm = new frmDCBD();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuToTrinh_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuToTrinh", "Xem"))
            {
                frmToTrinh frm = new frmToTrinh();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTimKiem", "Xem"))
            {
                frmTimKiem frm = new frmTimKiem();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDanhBoBoQua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDanhBoBoQua", "Xem"))
            {
                frmDanhBoBoQua frm = new frmDanhBoBoQua();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Văn Thư

        private void mnuCongVanDen_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuCongVanDen", "Xem"))
            {
                frmCongVanDen frm = new frmCongVanDen();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        private void mnuThongKe_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuThongKe", "Xem"))
            {
                frmThongKe frm = new frmThongKe();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSsDHN_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDSsDHN", "Xem"))
            {
                frmDSsDHN frm = new frmDSsDHN();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaosDHN_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuBaoCaosDHN", "Xem"))
            {
                frmBaoCaosDHN frm = new frmBaoCaosDHN();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        

        

        




    }
}