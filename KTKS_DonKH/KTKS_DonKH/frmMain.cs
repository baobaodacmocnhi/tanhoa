using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.GUI.HeThong;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.GUI.ToKhachHang;
using KTKS_DonKH.GUI.TimKiem;
using KTKS_DonKH.GUI.CongVan;
using KTKS_DonKH.GUI.ThuTraLoi;
using KTKS_DonKH.GUI.KiemTraXacMinh;
using KTKS_DonKH.GUI.BamChi;
using KTKS_DonKH.GUI.DieuChinhBienDong;
using KTKS_DonKH.GUI.CatHuyDanhBo;
using KTKS_DonKH.GUI.DongNuoc;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.GUI.QuanTri;
using KTKS_DonKH.GUI.ToBamChi;
using KTKS_DonKH.GUI.TruyThu;
using KTKS_DonKH.GUI.CallCenter;
using KTKS_DonKH.GUI.DonTu;
using System.Deployment.Application;
using KTKS_DonKH.GUI.ThuMoi;
using KTKS_DonKH.GUI.PhongKhachHang;
using KTKS_DonKH.GUI;
using KTKS_DonKH.GUI.VanBan;

namespace KTKS_DonKH
{
    public partial class frmMain : Form
    {
        CPhanQuyenNhom _cPhanQuyenNhom = new CPhanQuyenNhom();
        CPhanQuyenNguoiDung _cPhanQuyenNguoiDung = new CPhanQuyenNguoiDung();

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

                foreach (ToolStripMenuItem itemParent in this.MainMenuStrip.Items)
                {
                    if (itemParent.Name == "mnuHeThong" || itemParent.Name == "mnuTimKiem" || itemParent.Name == "mnuTinhTienNuoc")
                        continue;
                    if (_cPhanQuyenNhom.CheckByTenMenuChaMaNhom(itemParent.Name, CTaiKhoan.MaNhom))
                        itemParent.Visible = true;
                    else
                        if (_cPhanQuyenNguoiDung.CheckByTenMenuChaMaND(itemParent.Name, CTaiKhoan.MaUser))
                            itemParent.Visible = true;
                        else
                            itemParent.Visible = false;
                }
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
            CTaiKhoan.DangXuat();
            foreach (Form item in this.MdiChildren)
            {
                this.ActiveMdiChild.Close();
            }
            mnuDangNhap.Enabled = true;
            mnuDoiMatKhau.Enabled = false;
            mnuDangXuat.Enabled = false;
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
            if (CTaiKhoan.CheckQuyen("mnuTo", "Xem"))
            {
                frmTo frm = new frmTo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuNhom_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuNhom", "Xem"))
            {
                frmNhom frm = new frmNhom();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuNguoiDung_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuNguoiDung", "Xem"))
            {
                frmTaiKhoan frm = new frmTaiKhoan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBanGiamDoc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuBanGiamDoc", "Xem"))
            {
                frmBanGiamDoc frm = new frmBanGiamDoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Đơn Tổ Khách Hàng

        private void mnuNhanDonTKH_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuNhanDonTKH", "Xem"))
            {
                frmNhanDonTKH frm = new frmNhanDonTKH();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuNhanDonDienThoai_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuNhanDonDienThoai", "Xem"))
            {
                frmNhanDonDienThoai frm = new frmNhanDonDienThoai();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuCapNhatDon_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuCapNhatDon", "Xem"))
            {
                frmCapNhatDonTKH frm = new frmCapNhatDonTKH();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSDonTKH_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSDonTKH", "Xem"))
            {
                frmDSDonTKH frm = new frmDSDonTKH();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSDonDienThoai_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSDonDienThoai", "Xem"))
            {
                frmDSDonDienThoai frm = new frmDSDonDienThoai();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuLoaiDonTKH_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuLoaiDonTKH", "Xem"))
            {
                frmLoaiDonTKH frm = new frmLoaiDonTKH();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaoDonTKH_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuBaoCaoDonTKH", "Xem"))
            {
                frmBaoCaoDonTKH frm = new frmBaoCaoDonTKH();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Tổ Xử Lý

        private void mnuNhanDonTXL_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuNhanDonTXL", "Xem"))
            {
                frmNhanDonTXL frm = new frmNhanDonTXL();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSDonTXL_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSDonTXL", "Xem"))
            {
                frmDSDonTXL frm = new frmDSDonTXL();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuLoaiDonTXL_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuLoaiDonTXL", "Xem"))
            {
                frmLoaiDonTXL frm = new frmLoaiDonTXL();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaoDonTXL_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuBaoCaoDonTXL", "Xem"))
            {
                frmBaoCaoDonTXL frm = new frmBaoCaoDonTXL();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Tổ Bấm Chì

        private void mnuNhanDonTBC_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuNhanDonTBC", "Xem"))
            {
                frmNhanDonTBC frm = new frmNhanDonTBC();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSDonTBC_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSDonTBC", "Xem"))
            {
                frmDSDonTBC frm = new frmDSDonTBC();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuLoaiDonTBC_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuLoaiDonTBC", "Xem"))
            {
                frmLoaiDonTBC frm = new frmLoaiDonTBC();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaoTBC_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuBaoCaoTBC", "Xem"))
            {
                frmBaoCaoDonTBC frm = new frmBaoCaoDonTBC();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuNiemChi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuNiemChi", "Xem"))
            {
                frmNiemChi frm = new frmNiemChi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Kiểm Tra Xác Minh

        private void mnuNhapKQKTXM_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuNhapKQKTXM", "Xem"))
            {
                frmKTXM frm = new frmKTXM();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDongTien_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDongTien", "Xem"))
            {
                frmDongTien frm = new frmDongTien();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSKQKTXM_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSKQKTXM", "Xem"))
            {
                frmDSKTXM frm = new frmDSKTXM();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuHienTrangKiemTra_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuHienTrangKiemTra", "Xem"))
            {
                frmHienTrangKiemTra frm = new frmHienTrangKiemTra();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaoKTXM_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuBaoCaoKTXM", "Xem"))
            {
                frmBaoCaoKTXM frm = new frmBaoCaoKTXM();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Bấm Chì

        private void mnuNhapKQBamChi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuNhapKQBamChi", "Xem"))
            {
                frmBamChi frm = new frmBamChi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSKQBamChi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSKQBamChi", "Xem"))
            {
                frmDSBamChi frm = new frmDSBamChi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTrangThaiBamChi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuTrangThaiBamChi", "Xem"))
            {
                frmTrangThaiBamChi frm = new frmTrangThaiBamChi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaoBamChi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuBaoCaoBamChi", "Xem"))
            {
                frmBaoCaoBamChi frm = new frmBaoCaoBamChi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Truy Thu

        private void mnuTruyThuDMNuoc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuTruyThuDMNuoc", "Xem"))
            {
                frmTruyThuTienNuoc frm = new frmTruyThuTienNuoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuGianLanTienNuoc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuGianLanTienNuoc", "Xem"))
            {
                frmGianLan frm = new frmGianLan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSTruyThuDMNuoc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSTruyThuDMNuoc", "Xem"))
            {
                frmDSTruyThuTienNuoc frm = new frmDSTruyThuTienNuoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void mnuBaoCaoTruyThu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuBaoCaoTruyThu", "Xem"))
            {
                frmBaoCaoTruyThu frm = new frmBaoCaoTruyThu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Điều Chỉnh Biến Động

        private void mnuDCBD_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDCBD", "Xem"))
            {
                frmDCBD frm = new frmDCBD();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDCHD_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDCHD", "Xem"))
            {
                frmDCHD frm = new frmDCHD();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSDCBD_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSDCBD", "Xem"))
            {
                frmDSDCBD frm = new frmDSDCBD();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuTBKQYCCatDM_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuTBKQYCCatDM", "Xem"))
            {
                frmTBKetQuaYCCatDM frm = new frmTBKetQuaYCCatDM();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void mnuLoaiChungTu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuLoaiChungTu", "Xem"))
            {
                frmLoaiChungTu frm = new frmLoaiChungTu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuChiNhanhCapNuoc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuChiNhanhCapNuoc", "Xem"))
            {
                frmChiNhanh frm = new frmChiNhanh();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuGiaNuoc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuGiaNuoc", "Xem"))
            {
                frmGiaNuoc frm = new frmGiaNuoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaoDCBD_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuBaoCaoDCBD", "Xem"))
            {
                frmBaoCaoDCBD frm = new frmBaoCaoDCBD();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKhuCongNghiep_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuKhuCongNghiep", "Xem"))
            {
                frmKhuCongNghiep frm = new frmKhuCongNghiep();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuHoNgheo_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuHoNgheo", "Xem"))
            {
                frmHoNgheo frm = new frmHoNgheo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuSoDangKyDinhMuc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuSoDangKyDinhMuc", "Xem"))
            {
                frmSoDangKyDinhMuc frm = new frmSoDangKyDinhMuc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDanhSachDocLoChiSoNuoc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDanhSachDocLoChiSoNuoc", "Xem"))
            {
                frmDanhSachDocLoChiSoNuoc frm = new frmDanhSachDocLoChiSoNuoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Cắt Hủy

        private void mnuCTDB_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuCTDB", "Xem"))
            {
                frmCTDB frm = new frmCTDB();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuCHDB_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuCHDB", "Xem"))
            {
                frmCHDB frm = new frmCHDB();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuYCHDB_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuPhieuCHDB", "Xem"))
            {
                frmYCCHDB frm = new frmYCCHDB();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDongNuoc_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDongNuoc", "Xem"))
            {
                frmDongNuoc frm = new frmDongNuoc();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSCHDB_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSCHDB", "Xem"))
            {
                frmDSCHDB frm = new frmDSCHDB();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuLyDoCHDB_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuLyDoCHDB", "Xem"))
            {
                frmLyDoCHDB frm = new frmLyDoCHDB();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuNoiDungXuLyCHDB_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuNoiDungXuLyCHDB", "Xem"))
            {
                frmNoiDungXuLyCHDB frm = new frmNoiDungXuLyCHDB();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaoCHDB_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuBaoCaoCHDB", "Xem"))
            {
                frmBaoCaoCHDB frm = new frmBaoCaoCHDB();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Thảo Thư Trả Lời

        private void mnuTTTL_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuTTTL", "Xem"))
            {
                frmTTTL frm = new frmTTTL();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuVeViecTTTL_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuVeViecTTTL", "Xem"))
            {
                frmTTTLVeViec frm = new frmTTTLVeViec();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSTTTL_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSTTTL", "Xem"))
            {
                frmDSTTTL frm = new frmDSTTTL();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuToTrinh_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuToTrinh", "Xem"))
            {
                frmToTrinh2021 frm = new frmToTrinh2021();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSToTrinh_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSToTrinh", "Xem"))
            {
                frmDSToTrinh2021 frm = new frmDSToTrinh2021();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuVeViecToTrinh_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuVeViecToTrinh", "Xem"))
            {
                frmToTrinhVeViec frm = new frmToTrinhVeViec();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuVanBan_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuVanBan", "Xem"))
            {
                frmVanBan frm = new frmVanBan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Thư Mời

        private void mnuThaoThuMoi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuThaoThuMoi", "Xem"))
            {
                frmThaoThuMoi frm = new frmThaoThuMoi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSThuMoi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSThuMoi", "Xem"))
            {
                frmDSThuMoi frm = new frmDSThuMoi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuInBienBan_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuInBienBan", "Xem"))
            {
                frmInBienBan frm = new frmInBienBan();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Báo Cáo



        #endregion

        #region Công Văn

        private void mnuCongVanDi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuCongVanDi", "Xem"))
            {
                frmCongVanDi frm = new frmCongVanDi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Trung Tâm Khách Hàng

        private void mnuThongTinKhachHang_Click(object sender, EventArgs e)
        {
            //if (CTaiKhoan.CheckQuyen("mnuThongTinKhachHang", "Xem"))
            {
                frmKhachHang frm = new frmKhachHang();
                OpenForm(frm);
            }
            //else
            //    MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuKhachHangGanMoi_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuKhachHangGanMoi", "Xem"))
            {
                frmKhachHangGanMoi frm = new frmKhachHangGanMoi();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSTiepNhan_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSTiepNhan", "Xem"))
            {
                frmDanhSachKN frm = new frmDanhSachKN();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnBaoBe_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnBaoBe", "Xem"))
            {
                //  frmBaoBe frm = new frmBaoBe();
                //  OpenForm(frm);
                string url = "http://hp_g7/callbaobe.aspx?u=" + CTaiKhoan.TaiKhoan;
                System.Diagnostics.Process.Start(url);


            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            frmTienTrinhDon frm = new frmTienTrinhDon();
            OpenForm(frm);
        }

        private void mnuTinhTienNuoc_Click(object sender, EventArgs e)
        {
            frmTinhTienNuoc frm = new frmTinhTienNuoc();
            OpenForm(frm);
        }

        private void mnuToTrinhDCHD_Click(object sender, EventArgs e)
        {
            frmToTrinhDCHD frm = new frmToTrinhDCHD();
            OpenForm(frm);
        }

        #region Đơn Từ

        private void mnuNhanDonTu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuNhanDonTu", "Xem"))
            {
                frmNhanDonTu2019 frm = new frmNhanDonTu2019();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuDSDonTu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuDSDonTu", "Xem"))
            {
                frmDSDonTu frm = new frmDSDonTu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuCapNhatDonTu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuCapNhatDonTu", "Xem"))
            {
                frmCapNhatDonTu2019 frm = new frmCapNhatDonTu2019();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuBaoCaoDonTu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuBaoCaoDonTu", "Xem"))
            {
                frmBaoCaoDonTu frm = new frmBaoCaoDonTu();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuNhomDon_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuNhomDon", "Xem"))
            {
                frmNhomDon frm = new frmNhomDon();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion


        #region Phòng Khách Hàng

        private void mnuTraHopDong_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuTraHopDong", "Xem"))
            {
                frmTraHopDong frm = new frmTraHopDong();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuCongVanDi_PKH_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuCongVanDi_PKH", "Xem"))
            {
                frmCongVanDi_PKH frm = new frmCongVanDi_PKH();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuGuiTinNhanZalo_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen("mnuGuiTinNhanZalo", "Xem"))
            {
                frmGuiTinNhanZalo frm = new frmGuiTinNhanZalo();
                OpenForm(frm);
            }
            else
                MessageBox.Show("Bạn không có quyền Xem Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion













    }
}
