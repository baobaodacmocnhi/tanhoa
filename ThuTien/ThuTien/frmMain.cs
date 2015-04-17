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
            mnuDangNhap.PerformClick();
        }

        public void OpenForm(Form frm)
        {
            foreach (Form item in this.MdiChildren)
            {
                this.ActiveMdiChild.Close();
            }
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            StripStatus_Form.Text = "Đang mở Form: " + frm.Text;
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
            StripStatus_Form.Text = "";
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
                frmDieuChinhDangNgan frm = new frmDieuChinhDangNgan();
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

        private void mnuKiemTraDangNgan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuGiaoTBDongNuoc", "Xem"))
            {
                frmKiemTraDangNgan frm = new frmKiemTraDangNgan();
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

        private void mnuNangSuatThuTien_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuKiemTraTon", "Xem"))
            {
                frmNangSuatThuTien frm = new frmNangSuatThuTien();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuHDTienLon_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuHDTienLon", "Xem"))
            {
                frmHDTienLon frm = new frmHDTienLon();
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
            if (CNguoiDung.CheckQuyen("mnuTamThuQuay", "Xem"))
            {
                frmLenhHuy frm = new frmLenhHuy();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTraGop_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuTamThuQuay", "Xem"))
            {
                frmTraGop frm = new frmTraGop();
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

        #endregion 

        

        #region



        #endregion
    }
}
