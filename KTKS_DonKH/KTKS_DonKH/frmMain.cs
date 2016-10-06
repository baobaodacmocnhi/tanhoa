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
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.GUI.KhachHang;
using KTKS_DonKH.GUI.TimKiem;
using KTKS_DonKH.GUI.CongVan;
using KTKS_DonKH.GUI.ThaoThuTraLoi;
using KTKS_DonKH.GUI.KiemTraXacMinh;
using KTKS_DonKH.GUI.BamChi;
using KTKS_DonKH.GUI.DieuChinhBienDong;
using KTKS_DonKH.GUI.CatHuyDanhBo;
using KTKS_DonKH.GUI.DongNuoc;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.GUI.QuanTri;

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
                StripStatus_HoTen.Text = "                                                 Xin Chào: " + CTaiKhoan.HoTen;
                if (CTaiKhoan.MaUser == 0)
                    mnuAdmin.Enabled = true;
                else
                    mnuAdmin.Enabled = false;
                //if (CTaiKhoan.PhoGiamDoc)
                //    mnuPhoGiamDoc.Visible = true;
                //else
                //    mnuPhoGiamDoc.Visible = false;
            }
        }

        private void mnuBaoCao_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao();
            OpenForm(frm);
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
            StripStatus_HoTen.Text = "                                                 Xin Chào: ";
            //mnuPhoGiamDoc.Visible = false;
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

        }

        private void mnuNhom_Click(object sender, EventArgs e)
        {
            frmNhom frm = new frmNhom();
            OpenForm(frm);
        }

        private void mnuNguoiDung_Click(object sender, EventArgs e)
        {
            frmTaiKhoan frm = new frmTaiKhoan();
            OpenForm(frm);
        }

        private void mnuBanGiamDoc_Click(object sender, EventArgs e)
        {
            frmBanGiamDoc frm = new frmBanGiamDoc();
            OpenForm(frm);
        }

        #endregion

        #region Đơn Từ

        private void mnuNhanDonQuay_Click(object sender, EventArgs e)
        {
            frmNhanDonKH frm = new frmNhanDonKH();
            OpenForm(frm);
        }

        private void mnuNhanDonDienThoai_Click(object sender, EventArgs e)
        {
            frmNhanDonDienThoai frm = new frmNhanDonDienThoai();
            OpenForm(frm);
        }

        private void mnuCapNhatDon_Click(object sender, EventArgs e)
        {
            frmCapNhatDonKH frm = new frmCapNhatDonKH();
            OpenForm(frm);
        }

        private void mnuLoaiDon_Click(object sender, EventArgs e)
        {
            frmLoaiDon frm = new frmLoaiDon();
            OpenForm(frm);
        }

        #endregion

        #region Kiểm Tra Xác Minh

        private void mnuNhapKQKTXM_Click(object sender, EventArgs e)
        {
            frmKTXM frm = new frmKTXM();
            OpenForm(frm);
        }

        private void mnuDongTienBoiThuong_Click(object sender, EventArgs e)
        {
            frmDongTienBoiThuong frm = new frmDongTienBoiThuong();
            OpenForm(frm);
        }

        private void mnuDSKQKTXM_Click(object sender, EventArgs e)
        {
            frmDSKTXM frm = new frmDSKTXM();
            OpenForm(frm);
        }
        private void mnuHienTrangKiemTra_Click(object sender, EventArgs e)
        {
            frmHienTrangKiemTra frm = new frmHienTrangKiemTra();
            OpenForm(frm);
        }

        #endregion

        #region Bấm Chì

        private void mnuNhapKQBamChi_Click(object sender, EventArgs e)
        {
            frmBamChi frm = new frmBamChi();
            OpenForm(frm);
        }

        private void mnuDSKQBamChi_Click(object sender, EventArgs e)
        {
            frmDSBamChi frm = new frmDSBamChi();
            OpenForm(frm);
        }

        private void mnuTrangThaiBamChi_Click(object sender, EventArgs e)
        {
            frmTrangThaiBamChi frm = new frmTrangThaiBamChi();
            OpenForm(frm);
        }

        #endregion

        #region Truy Thu



        #endregion

        #region Điều Chỉnh Biến Động

        private void mnuDCBD_Click(object sender, EventArgs e)
        {
            frmDCBD frm = new frmDCBD();
            OpenForm(frm);
        }

        private void mnuDCHD_Click(object sender, EventArgs e)
        {
            frmDCHD frm = new frmDCHD();
            OpenForm(frm);
        }

        private void mnuDSDCBD_Click(object sender, EventArgs e)
        {
            frmDSDCBD frm = new frmDSDCBD();
            OpenForm(frm);
        }

        private void mnuLoaiChungTu_Click(object sender, EventArgs e)
        {
            frmLoaiChungTu frm = new frmLoaiChungTu();
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

        #endregion

        #region Cắt Hủy

        private void mnuCTDB_Click(object sender, EventArgs e)
        {
            frmCTDB frm = new frmCTDB();
            OpenForm(frm);
        }

        private void mnuCHDB_Click(object sender, EventArgs e)
        {
            frmCHDB frm = new frmCHDB();
            OpenForm(frm);
        }

        private void mnuYCHDB_Click(object sender, EventArgs e)
        {
            frmYCCHDB frm = new frmYCCHDB();
            OpenForm(frm);
        }

        private void mnuDongNuoc_Click(object sender, EventArgs e)
        {
            frmDongNuoc frm = new frmDongNuoc();
            OpenForm(frm);
        }

        private void mnuDSCHDB_Click(object sender, EventArgs e)
        {
            frmDSCHDB frm = new frmDSCHDB();
            OpenForm(frm);
        }

        private void mnuLyDoCHDB_Click(object sender, EventArgs e)
        {
            frmVeViecCHDB frm = new frmVeViecCHDB();
            OpenForm(frm);
        }

        #endregion

        #region Thảo Thư Trả Lời

        private void mnuTTTL_Click(object sender, EventArgs e)
        {
            frmTTTL frm = new frmTTTL();
            OpenForm(frm);
        }

        private void mnuVeViecTTTL_Click(object sender, EventArgs e)
        {
            frmVeViecTTTL frm = new frmVeViecTTTL();
            OpenForm(frm);
        }

        #endregion

        #region Báo Cáo



        #endregion

        #region Công Văn

        private void mnuCongVanDi_Click(object sender, EventArgs e)
        {
            frmCongVanDi frm = new frmCongVanDi();
            OpenForm(frm);
        }

        #endregion

        #region



        #endregion

        #region



        #endregion

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            frmTienTrinhDon frm = new frmTienTrinhDon();
            OpenForm(frm);
        }

        private void mnuNhanDonTXL_Click(object sender, EventArgs e)
        {
            frmNhanDonTXL frm = new frmNhanDonTXL();
            OpenForm(frm);
        }

        private void mnuDSDonTXL_Click(object sender, EventArgs e)
        {
            frmDSDonTXL frm = new frmDSDonTXL();
            OpenForm(frm);
        }

        

        
    }
}
