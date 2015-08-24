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
            }
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

        private void mnuGiaoTBDongNuoc_Click_1(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuGiaoTBDongNuoc", "Xem"))
            {
                frmGiaoTBDongNuoc frm = new frmGiaoTBDongNuoc();
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

        #endregion   

        #region Tìm Kiếm

        private void mnuTimKiemKhachHang_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTimKiemKhachHang", "Xem"))
            {
                frmTimKiemKhachHang frm = new frmTimKiemKhachHang();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

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

        

        

        

    }
}
    