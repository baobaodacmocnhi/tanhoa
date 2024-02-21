using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.GUI.HeThong;
using ThuTien.GUI.QuanTri;
using ThuTien.DAL.QuanTri;
using ThuTien.GUI.Doi;
using ThuTien.GUI.ToTruong;
using ThuTien.GUI.HanhThu;
using ThuTien.GUI.Quay;
using ThuTien.GUI.ChuyenKhoan;
using ThuTien.GUI.TongHop;
using ThuTien.GUI.DongNuoc;
using ThuTien.GUI.TimKiem;
using ThuTien.GUI.PhoGiamDoc;
using ThuTien.GUI.VanThu;

namespace ThuTien
{
    public partial class frmMain : Form
    {
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
                StripStatus_HoTen.Text = "Xin Chào: " + CNguoiDung.HoTen;
                if (CNguoiDung.MaND == 0)
                    mnuAdmin.Enabled = true;
                else
                    mnuAdmin.Enabled = false;
                if (CNguoiDung.PhoGiamDoc)
                    mnuPhoGiamDoc.Visible = true;
                else
                    mnuPhoGiamDoc.Visible = false;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Application.Idle += new EventHandler(Application_Idle);
            mnuDangNhap.PerformClick();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            if ((CNguoiDung.MaTo == 5 && CNguoiDung.MaND != 51) || CNguoiDung.Admin == true)
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
            //CNguoiDung.DangXuat();
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
            CNguoiDung.initial();
            //CNguoiDung.DangXuat();
            foreach (Form item in this.MdiChildren)
            {
                this.ActiveMdiChild.Close();
            }
            mnuDangNhap.Enabled = true;
            mnuDoiMatKhau.Enabled = false;
            mnuDangXuat.Enabled = false;
            StripStatus_HoTen.Text = "";
            mnuPhoGiamDoc.Visible = false;
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

        #region Đội

        private void mnuLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuLuuHD", "Xem"))
            {
                frmLuuHD frm = new frmLuuHD();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKiemTraDangNganDoi_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKiemTraDangNganDoi", "Xem"))
            {
                frmKiemTraDangNganDoi frm = new frmKiemTraDangNganDoi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKiemTraTonDoi_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKiemTraTonDoi", "Xem"))
            {
                frmKiemTraTonDoi frm = new frmKiemTraTonDoi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuNangSuatThuTienDoi_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuNangSuatThuTienDoi", "Xem"))
            {
                frmNangSuatThuTienDoi frm = new frmNangSuatThuTienDoi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuChuanThu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuChuanThu", "Xem"))
            {
                frmChuanThu frm = new frmChuanThu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuHDTienLonDoi_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuHDTienLonDoi", "Xem"))
            {
                frmHDTienLonDoi frm = new frmHDTienLonDoi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuXemTBDongNuoc_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuXemTBDongNuoc", "Xem"))
            {
                frmXemTBDongNuocDoi frm = new frmXemTBDongNuocDoi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTinhGiaBanBinhQuan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTinhGiaBanBinhQuan", "Xem"))
            {
                frmTinhGiaBanBinhQuan frm = new frmTinhGiaBanBinhQuan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuPhanTichHD0_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuPhanTichHD0", "Xem"))
            {
                frmPhanTichHD0 frm = new frmPhanTichHD0();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuPhanTichDoanhThu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuPhanTichDoanhThu", "Xem"))
            {
                frmPhanTichDoanhThu frm = new frmPhanTichDoanhThu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKetThucNamTaiKhoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKetThucNamTaiKhoa", "Xem"))
            {
                frmKetThucNamTaiKhoa frm = new frmKetThucNamTaiKhoa();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBangTongHop_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuBangTongHop", "Xem"))
            {
                frmBangTongHop frm = new frmBangTongHop();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKiemPortTon_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKiemPortTon", "Xem"))
            {
                frmKiemPortTon frm = new frmKiemPortTon();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuToTrinhCatHuy_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuToTrinhCatHuy", "Xem"))
            {
                frmToTrinhCatHuy frm = new frmToTrinhCatHuy();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDieuChinhDangNganDoi_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDieuChinhDangNganDoi", "Xem"))
            {
                frmDieuChinhDangNganDoi frm = new frmDieuChinhDangNganDoi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKiemTraSaiBiet_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKiemTraSaiBiet", "Xem"))
            {
                frmKiemTraSaiBiet frm = new frmKiemTraSaiBiet();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaoVatTu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuBaoCaoVatTu", "Xem"))
            {
                frmBaoCaoVatTu frm = new frmBaoCaoVatTu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDongMoNuocDoi_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDongMoNuocDoi", "Xem"))
            {
                frmDongMoNuocDoi frm = new frmDongMoNuocDoi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDieuChinhMLT_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDieuChinhMLT", "Xem"))
            {
                frmDieuChinhMLT frm = new frmDieuChinhMLT();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuGuiThongBao_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuGuiThongBao", "Xem"))
            {
                frmGuiThongBao frm = new frmGuiThongBao();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuNiemChi_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuNiemChi", "Xem"))
            {
                frmNiemChi frm = new frmNiemChi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuCuaHangThuHo_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuCuaHangThuHo", "Xem"))
            {
                frmCuaHangThuHo frm = new frmCuaHangThuHo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Tổ Trưởng

        private void mnuGiaoHoaDonHanhThu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuGiaoHDHanhThu", "Xem"))
            {
                frmGiaoHDHanhThu frm = new frmGiaoHDHanhThu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuGiaoHDTon_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuGiaoHDTon", "Xem"))
            {
                frmGiaoHDTon frm = new frmGiaoHDTon();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuGiaoHDDienThoai_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuGiaoHDDienThoai", "Xem"))
            {
                frmGiaoHDDienThoai frm = new frmGiaoHDDienThoai();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDieuChinhDangNgan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDieuChinhDangNgan", "Xem"))
            {
                frmDieuChinhDangNganTo frm = new frmDieuChinhDangNganTo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuGiaoTBDongNuoc_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuGiaoTBDongNuoc", "Xem"))
            {
                frmGiaoTBDongNuoc2020 frm = new frmGiaoTBDongNuoc2020();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKiemTraDangNganTo_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKiemTraDangNganTo", "Xem"))
            {
                frmKiemTraDangNganTo frm = new frmKiemTraDangNganTo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKiemTraTonTo_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKiemTraTonTo", "Xem"))
            {
                frmKiemTraTonTo frm = new frmKiemTraTonTo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuNangSuatThuTienTo_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuNangSuatThuTienTo", "Xem"))
            {
                frmNangSuatThuTienTo frm = new frmNangSuatThuTienTo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuHDTienLonTo_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuHDTienLonTo", "Xem"))
            {
                frmHDTienLonTo frm = new frmHDTienLonTo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTongHopNo_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTongHopNo", "Xem"))
            {
                frmTongHopNo frm = new frmTongHopNo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuMoNuoc_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuMoNuoc", "Xem"))
            {
                frmMoNuoc2020 frm = new frmMoNuoc2020();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuHDTamThu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuHDTamThu", "Xem"))
            {
                frmHDTamThu frm = new frmHDTamThu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuHDChuyenKhoan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuHDChuyenKhoan", "Xem"))
            {
                frmHDChuyenKhoan frm = new frmHDChuyenKhoan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKiemTraHienTruong_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKiemTraHienTruong", "Xem"))
            {
                frmKiemTraHienTruong frm = new frmKiemTraHienTruong();
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

        private void mnuCongVanDenTo_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuCongVanDenTo", "Xem"))
            {
                frmCongVanDenTo frm = new frmCongVanDenTo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Hành Thu

        private void mnuDangNganHD_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDangNganHanhThu", "Xem"))
            {
                frmDangNganHanhThu frm = new frmDangNganHanhThu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDangNganTon_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDangNganTon", "Xem"))
            {
                frmDangNganTon frm = new frmDangNganTon();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuQuetTam_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuQuetTam", "Xem"))
            {
                frmQuetTam frm = new frmQuetTam();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Đóng Nước

        private void mnuLenhDongNuoc_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTBDongNuoc", "Xem"))
            {
                frmTBDongNuoc frm = new frmTBDongNuoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKQDongNuoc_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKQDongNuoc", "Xem"))
            {
                frmKQDongNuoc frm = new frmKQDongNuoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuVanTu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuVanTu", "Xem"))
            {
                frmVanTu frm = new frmVanTu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuThongKeDongMoNuoc_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuThongKeDongMoNuoc", "Xem"))
            {
                frmThongKeDongMoNuoc frm = new frmThongKeDongMoNuoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuPhoiHop_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuPhoiHop", "Xem"))
            {
                frmPhoiHop frm = new frmPhoiHop();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuPhiMoNuoc_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuPhiMoNuoc", "Xem"))
            {
                frmPhiMoNuoc frm = new frmPhiMoNuoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTheoDoiDongNuoc_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTheoDoiDongNuoc", "Xem"))
            {
                frmTheoDoiDongNuoc frm = new frmTheoDoiDongNuoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Chuyển Khoản

        private void mnuDangNganChuyenKhoan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDangNganChuyenKhoan", "Xem"))
            {
                frmDangNganChuyenKhoan frm = new frmDangNganChuyenKhoan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTamThuChuyenKhoan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTamThuChuyenKhoan", "Xem"))
            {
                frmTamThuChuyenKhoan frm = new frmTamThuChuyenKhoan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDuLieuKhachHang_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTamThuChuyenKhoan", "Xem"))
            {
                frmDuLieuKhachHang frm = new frmDuLieuKhachHang();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuNganHang_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuNganHang", "Xem"))
            {
                frmNganHang frm = new frmNganHang();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDieuChinhDangNganChuyenKhoan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDieuChinhDangNganChuyenKhoan", "Xem"))
            {
                frmDieuChinhDangNganChuyenKhoan frm = new frmDieuChinhDangNganChuyenKhoan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaoChuyenKhoan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuBaoCaoChuyenKhoan", "Xem"))
            {
                frmBaoCaoChuyenKhoan frm = new frmBaoCaoChuyenKhoan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBangKe_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuBangKe", "Xem"))
            {
                frmBangKe frm = new frmBangKe();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBangKePhiMoNuoc_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuBangKePhiMoNuoc", "Xem"))
            {
                frmBangKe_PhiMoNuoc frm = new frmBangKe_PhiMoNuoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDangNganTienMatChuyenKhoan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDangNganTienMatChuyenKhoan", "Xem"))
            {
                frmDangNganTienMatChuyenKhoan frm = new frmDangNganTienMatChuyenKhoan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDichVuThu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDichVuThu", "Xem"))
            {
                frmDichVuThu frm = new frmDichVuThu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTienDu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTienDu", "Xem"))
            {
                frmTienDu frm = new frmTienDu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuLichSuDieuChinhTienDu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuLichSuDieuChinhTienDu", "Xem"))
            {
                frmLichSuDieuChinhTienDu frm = new frmLichSuDieuChinhTienDu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuPhiMoNuocChuyenKhoan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuPhiMoNuocChuyenKhoan", "Xem"))
            {
                frmPhiMoNuocChuyenKhoan frm = new frmPhiMoNuocChuyenKhoan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuChanTienDu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuChanTienDu", "Xem"))
            {
                frmChanTienDu frm = new frmChanTienDu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuPhanTichChuyenKhoan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuPhanTichChuyenKhoan", "Xem"))
            {
                frmPhanTichChuyenKhoan frm = new frmPhanTichChuyenKhoan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuXacNhanThanhToan", "Xem"))
            {
                frmXacNhanThanhToan frm = new frmXacNhanThanhToan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Quầy

        private void mnuDangNganQuay_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDangNganQuay", "Xem"))
            {
                frmDangNganQuay frm = new frmDangNganQuay();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTamThu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTamThuQuay", "Xem"))
            {
                frmTamThuQuay frm = new frmTamThuQuay();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuLenhHuy_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuLenhHuy", "Xem"))
            {
                frmLenhHuy frm = new frmLenhHuy();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTraGop_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTraGop", "Xem"))
            {
                frmTraGop frm = new frmTraGop();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDieuChinhDangNganQuay_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDieuChinhDangNganQuay", "Xem"))
            {
                frmDieuChinhDangNganQuay frm = new frmDieuChinhDangNganQuay();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuPhiMoNuocQuay_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuPhiMoNuocQuay", "Xem"))
            {
                frmPhiMoNuocQuay frm = new frmPhiMoNuocQuay();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuThu2Lan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuThu2Lan", "Xem"))
            {
                frmThu2Lan frm = new frmThu2Lan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTienDuQuay_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTienDuQuay", "Xem"))
            {
                frmTienDuQuay frm = new frmTienDuQuay();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuLichSuDieuChinhTienDuQuay_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuLichSuDieuChinhTienDuQuay", "Xem"))
            {
                frmLichSuDieuChinhTienDuQuay frm = new frmLichSuDieuChinhTienDuQuay();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDangNganTienDuQuay_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDangNganTienDuQuay", "Xem"))
            {
                frmDangNganTienDuQuay frm = new frmDangNganTienDuQuay();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuQuetGiaoTon_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuQuetGiaoTon", "Xem"))
            {
                frmQuetGiaoTon frm = new frmQuetGiaoTon();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaoQuay_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuBaoCaoQuay", "Xem"))
            {
                frmBaoCaoQuay frm = new frmBaoCaoQuay();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Tổng Hợp

        private void mnuDCHD_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDCHD", "Xem"))
            {
                frmDCHD frm = new frmDCHD();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuThu2LanTH_Click(object sender, EventArgs e)
        {
            //if (CNguoiDung.CheckQuyen("mnuThu2Lan", "Xem"))
            //{
            //    frmThu2Lan frm = new frmThu2Lan();
            //    OpenForm(frm);
            //}
            //else
            //    MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuChuyenNoKhoDoi_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuChuyenNoKhoDoi", "Xem"))
            {
                frmChuyenNoKhoDoi frm = new frmChuyenNoKhoDoi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaoTongHop_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuBaoCaoTongHop", "Xem"))
            {
                frmBaoCaoTongHop frm = new frmBaoCaoTongHop();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuChamCong_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuChamCong", "Xem"))
            {
                frmChamCong frm = new frmChamCong();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuCongVan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuCongVan", "Xem"))
            {
                frmCongVan frm = new frmCongVan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDangKyKiemTra_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDangKyKiemTra", "Xem"))
            {
                frmDangKyKiemTra frm = new frmDangKyKiemTra();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuToTrinhDCHD_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuToTrinhDCHD", "Xem"))
            {
                frmToTrinhDCHD frm = new frmToTrinhDCHD();
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

        #region Tìm Kiếm

        private void mnuTimKiemKhachHang_Click(object sender, EventArgs e)
        {
            //if (CNguoiDung.CheckQuyen("mnuTimKiemKhachHang", "Xem"))
            //{
            frmTimKiemKhachHang frm = new frmTimKiemKhachHang();
            OpenForm(frm);
            //}
            //else
            //    MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTimKiemDienThoai_Click(object sender, EventArgs e)
        {
            //if (CNguoiDung.CheckQuyen("mnuTimKiemDienThoai", "Xem"))
            //{
            frmTimKiemDienThoai frm = new frmTimKiemDienThoai();
            OpenForm(frm);
            //}
            //else
            //    MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Phó Giám Đốc

        private void mnuKiemTraThu2Lan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKiemTraThu2Lan", "Xem"))
            {
                frmKiemTraThu2Lan frm = new frmKiemTraThu2Lan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKiemTraTon_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKiemTraTon", "Xem"))
            {
                frmKiemTraTon frm = new frmKiemTraTon();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion


        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CNguoiDung.DangXuat();
        }

    }
}
