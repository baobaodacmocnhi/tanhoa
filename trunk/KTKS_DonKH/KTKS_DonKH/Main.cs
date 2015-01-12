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
using KTKS_DonKH.GUI.CatHuyDanhBo;
using KTKS_DonKH.GUI.ThaoThuTraLoi;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.GUI.TimKiem;
using KTKS_DonKH.GUI.BamChi;
using KTKS_DonKH.GUI.DongNuoc;

namespace KTKS_DonKH
{
    public partial class Main : RibbonForm
    {
        bool _flagAutoExit = false;

        public Main()
        {
            InitializeComponent();  
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(Application_Idle);
            this.MouseMove += new MouseEventHandler(Main_MouseMove);
            ribbtnDangNhap_Click(sender, e);
        }

        public void GetLoginResult(bool result)
        {
            if (result)
            {
                if (CTaiKhoan.MaUser != 2)
                    _flagAutoExit = true;
                ribbtnDangNhap.Enabled = false;
                ribbtnDangXuat.Enabled = true;
                ribbtnDoiMatKhau.Enabled = true;
                StripStatus_TaiKhoan.Text = "Tài Khoản đang dùng: " + CTaiKhoan.TaiKhoan;
                StripStatus_Version.Text += ". V" + Application.ProductVersion.ToString();
                ///Hạn chế Hiện Thị
                if (CTaiKhoan.TaiKhoan == "thutien" && CTaiKhoan.MaUser == 22)
                {
                    ribbonTab2.Visible = false;
                    ribbonTab3.Visible = false;
                    ribbonTab4.Visible = false;
                    ribbonTab5.Visible = false;
                    ribbonTab6.Visible = false;
                    ribbonTab7.Visible = false;
                    ribbonTab9.Visible = false;
                    ribbtnTaiKhoan.Visible = false;
                }
                else
                {
                    ribbonTab2.Visible = true;
                    ribbonTab3.Visible = true;
                    ribbonTab4.Visible = true;
                    ribbonTab5.Visible = true;
                    ribbonTab6.Visible = true;
                    ribbonTab7.Visible = true;
                    ribbonTab9.Visible = true;
                    ribbtnTaiKhoan.Visible = true;
                }
                
            }
        }

        void Application_Idle(object sender, EventArgs e)
        {
            if (_flagAutoExit)
            {
                ///thời gian Idle để tắt chương trình
                IdleTimer.Interval = 60000 * 30;
                IdleTimer.Enabled = true;
                IdleTimer.Start();
                IdleTimer.Tick += new EventHandler(IdleTimer_Tick);
            }
        }

        void IdleTimer_Tick(object sender, EventArgs e)
        {
            IdleTimer.Enabled = false;
            Application.Exit();
        }

        private void DisableTimer()
        {
            IdleTimer.Enabled = false;
            IdleTimer.Stop();
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

            _flagAutoExit = false;
            ribbtnDangNhap.Enabled = true;
            ribbtnDangXuat.Enabled = false;
            ribbtnDoiMatKhau.Enabled = false;
            StripStatus_TaiKhoan.Text = "";
            StripStatus_Form.Text = "";

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
                item.Close();
            Form frm = new frmDoiMatKhau();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
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
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnKhachHang_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmTTKH();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnLoaiDonThu_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmLoaiDon();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnChungTuMoi_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmLoaiChungTu();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnNhanDon_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmNhanDonKH();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnQLDonKH_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmQLDonKH();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnDSDonKTXM_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmDSKTXM();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnDSDonDCBD_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmDSDCBD();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnChiNhanh_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmChiNhanh();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnGiaNuoc_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmGiaNuoc();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnBanGiamDoc_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmBanGiamDoc();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnDSDonCHDB_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmDSCHDB();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnDSDonTTTL_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmDSTTTL();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnNVKiemTra_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmNVKiemTra();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnDCBD_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmDCBD(true);
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
            //MessageBox.Show("Tính năng đang được Chỉnh Sửa, Vui lòng chờ...", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ribbtnDCHD_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmDCHD(true);
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnTBKetQuaYCCatDM_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmTBKetQuaYCCatDM();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnNhapKetQua_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmKTXM();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnCTDB_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmCTDB(true);
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnCHDB_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmCHDB(true);
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnTTTL_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmTTTL(true);
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnNhanDonTXL_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmNhanDonTXL();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnQLDonTXL_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmQLDonTXL();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnTimKiemTienTrinh_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmTienTrinhDon();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnDSBamChi_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmDSBamChi();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnNhapBamChi_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmBamChi();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnBaoCao_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmBaoCaoDCBD();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnChungCu_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmChungCu();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
            //MessageBox.Show("Tính năng đang được Chỉnh Sửa, Vui lòng chờ...", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBaoCaoDonKH_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmBaoCaoDonKH();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnBaoCaoKTXM_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmBaoCaoKTXM();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnBaoCaoCHDB_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmBaoCaoCHDB();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnLapPhieuCatHuyDB_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmYCCHDB();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnKiemTrang_BamChi_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmThongTin_KT_BC();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnDongNuoc_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmDongNuoc();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void ribbtnDongTienBoiThuong_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
                item.Close();
            Form frm = new frmDongTienBoiThuong();
            frm.MdiParent = this;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            DisableTimer();
        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            DisableTimer();
        }

        private void ribbon1_MouseMove(object sender, MouseEventArgs e)
        {
            DisableTimer();
        }

        private void ribbon1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DisableTimer();
        }

        

              
    }
}
