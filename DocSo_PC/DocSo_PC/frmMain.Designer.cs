﻿namespace DocSo_PC
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanTri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVienDocSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTaoDot = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLichDocSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhongTinhPBVMT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChuyenBilling = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToTruong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXuLySoLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTheoDoiDocSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiaoTangCuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDocSoTruoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGhiChu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhieuChuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDHNDienTu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDonTu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKTXM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDieuChinhThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToTrinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimKiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhBoBoQua = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVanThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCongVanDen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnusDHN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDSsDHN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaosDHN = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StripStatus_Version = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatus_HoTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuQuanTri,
            this.mnuDoi,
            this.mnuToTruong,
            this.mnuMaHoa,
            this.mnuVanThu,
            this.mnuBaoCao,
            this.mnusDHN});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNhap,
            this.mnuDoiMatKhau,
            this.mnuDangXuat,
            this.mnuAdmin});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(71, 20);
            this.mnuHeThong.Text = "Hệ Thống";
            // 
            // mnuDangNhap
            // 
            this.mnuDangNhap.Name = "mnuDangNhap";
            this.mnuDangNhap.Size = new System.Drawing.Size(146, 22);
            this.mnuDangNhap.Text = "Đăng Nhập";
            this.mnuDangNhap.Click += new System.EventHandler(this.mnuDangNhap_Click);
            // 
            // mnuDoiMatKhau
            // 
            this.mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            this.mnuDoiMatKhau.Size = new System.Drawing.Size(146, 22);
            this.mnuDoiMatKhau.Text = "Đổi Mật Khẩu";
            this.mnuDoiMatKhau.Click += new System.EventHandler(this.mnuDoiMatKhau_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(146, 22);
            this.mnuDangXuat.Text = "Đăng Xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuAdmin
            // 
            this.mnuAdmin.Enabled = false;
            this.mnuAdmin.Name = "mnuAdmin";
            this.mnuAdmin.Size = new System.Drawing.Size(146, 22);
            this.mnuAdmin.Text = "Admin";
            this.mnuAdmin.Click += new System.EventHandler(this.mnuAdmin_Click);
            // 
            // mnuQuanTri
            // 
            this.mnuQuanTri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTo,
            this.mnuNhom,
            this.mnuNguoiDung,
            this.mnuNhanVienDocSo});
            this.mnuQuanTri.Name = "mnuQuanTri";
            this.mnuQuanTri.Size = new System.Drawing.Size(63, 20);
            this.mnuQuanTri.Text = "Quản Trị";
            // 
            // mnuTo
            // 
            this.mnuTo.Name = "mnuTo";
            this.mnuTo.Size = new System.Drawing.Size(152, 22);
            this.mnuTo.Text = "Tổ";
            this.mnuTo.Click += new System.EventHandler(this.mnuTo_Click);
            // 
            // mnuNhom
            // 
            this.mnuNhom.Name = "mnuNhom";
            this.mnuNhom.Size = new System.Drawing.Size(152, 22);
            this.mnuNhom.Text = "Nhóm";
            this.mnuNhom.Click += new System.EventHandler(this.mnuNhom_Click);
            // 
            // mnuNguoiDung
            // 
            this.mnuNguoiDung.Name = "mnuNguoiDung";
            this.mnuNguoiDung.Size = new System.Drawing.Size(152, 22);
            this.mnuNguoiDung.Text = "Người Dùng";
            this.mnuNguoiDung.Click += new System.EventHandler(this.mnuNguoiDung_Click);
            // 
            // mnuNhanVienDocSo
            // 
            this.mnuNhanVienDocSo.Name = "mnuNhanVienDocSo";
            this.mnuNhanVienDocSo.Size = new System.Drawing.Size(152, 22);
            this.mnuNhanVienDocSo.Text = "Máy Đọc Số";
            this.mnuNhanVienDocSo.Click += new System.EventHandler(this.mnuNhanVienDocSo_Click);
            // 
            // mnuDoi
            // 
            this.mnuDoi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTaoDot,
            this.mnuLichDocSo,
            this.mnuKhongTinhPBVMT,
            this.mnuChuyenBilling});
            this.mnuDoi.Name = "mnuDoi";
            this.mnuDoi.Size = new System.Drawing.Size(37, 20);
            this.mnuDoi.Text = "Đội";
            // 
            // mnuTaoDot
            // 
            this.mnuTaoDot.Name = "mnuTaoDot";
            this.mnuTaoDot.Size = new System.Drawing.Size(176, 22);
            this.mnuTaoDot.Text = "Tạo Đợt";
            this.mnuTaoDot.Click += new System.EventHandler(this.mnuTaoDot_Click);
            // 
            // mnuLichDocSo
            // 
            this.mnuLichDocSo.Name = "mnuLichDocSo";
            this.mnuLichDocSo.Size = new System.Drawing.Size(176, 22);
            this.mnuLichDocSo.Text = "Lịch Đọc Số";
            this.mnuLichDocSo.Click += new System.EventHandler(this.mnuLichDocSo_Click);
            // 
            // mnuKhongTinhPBVMT
            // 
            this.mnuKhongTinhPBVMT.Name = "mnuKhongTinhPBVMT";
            this.mnuKhongTinhPBVMT.Size = new System.Drawing.Size(176, 22);
            this.mnuKhongTinhPBVMT.Text = "Không Tính PBVMT";
            this.mnuKhongTinhPBVMT.Click += new System.EventHandler(this.mnuKhongTinhPBVMT_Click);
            // 
            // mnuChuyenBilling
            // 
            this.mnuChuyenBilling.Name = "mnuChuyenBilling";
            this.mnuChuyenBilling.Size = new System.Drawing.Size(176, 22);
            this.mnuChuyenBilling.Text = "Chuyển Billing";
            this.mnuChuyenBilling.Click += new System.EventHandler(this.mnuChuyenBilling_Click);
            // 
            // mnuToTruong
            // 
            this.mnuToTruong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuXuLySoLieu,
            this.mnuTheoDoiDocSo,
            this.mnuGiaoTangCuong,
            this.mnuDocSoTruoc,
            this.mnuGhiChu,
            this.mnuPhieuChuyen,
            this.mnuDHNDienTu});
            this.mnuToTruong.Name = "mnuToTruong";
            this.mnuToTruong.Size = new System.Drawing.Size(72, 20);
            this.mnuToTruong.Text = "Tổ Trưởng";
            // 
            // mnuXuLySoLieu
            // 
            this.mnuXuLySoLieu.Name = "mnuXuLySoLieu";
            this.mnuXuLySoLieu.Size = new System.Drawing.Size(165, 22);
            this.mnuXuLySoLieu.Text = "Xử Lý Số Liệu";
            this.mnuXuLySoLieu.Click += new System.EventHandler(this.mnuXuLySoLieu_Click);
            // 
            // mnuTheoDoiDocSo
            // 
            this.mnuTheoDoiDocSo.Name = "mnuTheoDoiDocSo";
            this.mnuTheoDoiDocSo.Size = new System.Drawing.Size(165, 22);
            this.mnuTheoDoiDocSo.Text = "Theo Dõi Đọc Số";
            this.mnuTheoDoiDocSo.Click += new System.EventHandler(this.mnuTheoDoiDot_Click);
            // 
            // mnuGiaoTangCuong
            // 
            this.mnuGiaoTangCuong.Name = "mnuGiaoTangCuong";
            this.mnuGiaoTangCuong.Size = new System.Drawing.Size(165, 22);
            this.mnuGiaoTangCuong.Text = "Giao Tăng Cường";
            this.mnuGiaoTangCuong.Click += new System.EventHandler(this.mnuGiaoTangCuong_Click);
            // 
            // mnuDocSoTruoc
            // 
            this.mnuDocSoTruoc.Name = "mnuDocSoTruoc";
            this.mnuDocSoTruoc.Size = new System.Drawing.Size(165, 22);
            this.mnuDocSoTruoc.Text = "Đọc Số Trước";
            this.mnuDocSoTruoc.Click += new System.EventHandler(this.mnuDocSoTruoc_Click);
            // 
            // mnuGhiChu
            // 
            this.mnuGhiChu.Name = "mnuGhiChu";
            this.mnuGhiChu.Size = new System.Drawing.Size(165, 22);
            this.mnuGhiChu.Text = "Ghi Chú";
            this.mnuGhiChu.Click += new System.EventHandler(this.mnuGhiChu_Click);
            // 
            // mnuPhieuChuyen
            // 
            this.mnuPhieuChuyen.Name = "mnuPhieuChuyen";
            this.mnuPhieuChuyen.Size = new System.Drawing.Size(165, 22);
            this.mnuPhieuChuyen.Text = "Phiếu Chuyển";
            this.mnuPhieuChuyen.Click += new System.EventHandler(this.mnuPhieuChuyen_Click);
            // 
            // mnuDHNDienTu
            // 
            this.mnuDHNDienTu.Name = "mnuDHNDienTu";
            this.mnuDHNDienTu.Size = new System.Drawing.Size(165, 22);
            this.mnuDHNDienTu.Text = "ĐHN Điện Từ";
            this.mnuDHNDienTu.Click += new System.EventHandler(this.mnuDHNDienTu_Click);
            // 
            // mnuMaHoa
            // 
            this.mnuMaHoa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDonTu,
            this.mnuKTXM,
            this.mnuDieuChinhThongTin,
            this.mnuToTrinh,
            this.mnuTimKiem,
            this.mnuDanhBoBoQua});
            this.mnuMaHoa.Name = "mnuMaHoa";
            this.mnuMaHoa.Size = new System.Drawing.Size(61, 20);
            this.mnuMaHoa.Text = "Mã Hóa";
            // 
            // mnuDonTu
            // 
            this.mnuDonTu.Name = "mnuDonTu";
            this.mnuDonTu.Size = new System.Drawing.Size(189, 22);
            this.mnuDonTu.Text = "Đơn Từ";
            this.mnuDonTu.Click += new System.EventHandler(this.mnuDonTu_Click);
            // 
            // mnuKTXM
            // 
            this.mnuKTXM.Name = "mnuKTXM";
            this.mnuKTXM.Size = new System.Drawing.Size(189, 22);
            this.mnuKTXM.Text = "Kiểm Tra Xác Minh";
            this.mnuKTXM.Click += new System.EventHandler(this.mnuKTXM_Click);
            // 
            // mnuDieuChinhThongTin
            // 
            this.mnuDieuChinhThongTin.Name = "mnuDieuChinhThongTin";
            this.mnuDieuChinhThongTin.Size = new System.Drawing.Size(189, 22);
            this.mnuDieuChinhThongTin.Text = "Điều Chỉnh Thông Tin";
            this.mnuDieuChinhThongTin.Click += new System.EventHandler(this.mnuDieuChinhThongTin_Click);
            // 
            // mnuToTrinh
            // 
            this.mnuToTrinh.Name = "mnuToTrinh";
            this.mnuToTrinh.Size = new System.Drawing.Size(189, 22);
            this.mnuToTrinh.Text = "Tờ Trình";
            this.mnuToTrinh.Click += new System.EventHandler(this.mnuToTrinh_Click);
            // 
            // mnuTimKiem
            // 
            this.mnuTimKiem.Name = "mnuTimKiem";
            this.mnuTimKiem.Size = new System.Drawing.Size(189, 22);
            this.mnuTimKiem.Text = "Tìm Kiếm";
            this.mnuTimKiem.Click += new System.EventHandler(this.mnuTimKiem_Click);
            // 
            // mnuDanhBoBoQua
            // 
            this.mnuDanhBoBoQua.Name = "mnuDanhBoBoQua";
            this.mnuDanhBoBoQua.Size = new System.Drawing.Size(189, 22);
            this.mnuDanhBoBoQua.Text = "Danh Bộ (Bỏ Qua)";
            this.mnuDanhBoBoQua.Click += new System.EventHandler(this.mnuDanhBoBoQua_Click);
            // 
            // mnuVanThu
            // 
            this.mnuVanThu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCongVanDen});
            this.mnuVanThu.Name = "mnuVanThu";
            this.mnuVanThu.Size = new System.Drawing.Size(61, 20);
            this.mnuVanThu.Text = "Văn Thư";
            // 
            // mnuCongVanDen
            // 
            this.mnuCongVanDen.Name = "mnuCongVanDen";
            this.mnuCongVanDen.Size = new System.Drawing.Size(149, 22);
            this.mnuCongVanDen.Text = "Công Văn Đến";
            this.mnuCongVanDen.Click += new System.EventHandler(this.mnuCongVanDen_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThongKe});
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Size = new System.Drawing.Size(63, 20);
            this.mnuBaoCao.Text = "Báo Cáo";
            // 
            // mnuThongKe
            // 
            this.mnuThongKe.Name = "mnuThongKe";
            this.mnuThongKe.Size = new System.Drawing.Size(124, 22);
            this.mnuThongKe.Text = "Thống Kê";
            this.mnuThongKe.Click += new System.EventHandler(this.mnuThongKe_Click);
            // 
            // mnusDHN
            // 
            this.mnusDHN.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDSsDHN,
            this.mnuBaoCaosDHN});
            this.mnusDHN.Name = "mnusDHN";
            this.mnusDHN.Size = new System.Drawing.Size(113, 20);
            this.mnusDHN.Text = "ĐHN Thông Minh";
            // 
            // mnuDSsDHN
            // 
            this.mnuDSsDHN.Name = "mnuDSsDHN";
            this.mnuDSsDHN.Size = new System.Drawing.Size(130, 22);
            this.mnuDSsDHN.Text = "Danh Sách";
            this.mnuDSsDHN.Click += new System.EventHandler(this.mnuDSsDHN_Click);
            // 
            // mnuBaoCaosDHN
            // 
            this.mnuBaoCaosDHN.Name = "mnuBaoCaosDHN";
            this.mnuBaoCaosDHN.Size = new System.Drawing.Size(130, 22);
            this.mnuBaoCaosDHN.Text = "Báo Cáo";
            this.mnuBaoCaosDHN.Click += new System.EventHandler(this.mnuBaoCaosDHN_Click);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1184, 26);
            this.tabControl.TabIndex = 6;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripStatus_Version,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.StripStatus_HoTen});
            this.statusStrip.Location = new System.Drawing.Point(0, 639);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // StripStatus_Version
            // 
            this.StripStatus_Version.Name = "StripStatus_Version";
            this.StripStatus_Version.Size = new System.Drawing.Size(423, 17);
            this.StripStatus_Version.Text = "Bản quyền(2017) thuộc Công ty CP Cấp Nước Tân Hòa. Được T.CNTT phát triển";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(151, 17);
            this.toolStripStatusLabel4.Text = "                                                ";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(172, 17);
            this.toolStripStatusLabel5.Text = "                                                       ";
            // 
            // StripStatus_HoTen
            // 
            this.StripStatus_HoTen.Name = "StripStatus_HoTen";
            this.StripStatus_HoTen.Size = new System.Drawing.Size(58, 17);
            this.StripStatus_HoTen.Text = "Xin Chào:";
            this.StripStatus_HoTen.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // timer
            // 
            this.timer.Interval = 1200000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "frmMain";
            this.Text = "Quản Lý Ghi Chỉ Số Nước";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuAdmin;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanTri;
        private System.Windows.Forms.ToolStripMenuItem mnuTo;
        private System.Windows.Forms.ToolStripMenuItem mnuNhom;
        private System.Windows.Forms.ToolStripMenuItem mnuNguoiDung;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StripStatus_Version;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel StripStatus_HoTen;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem mnuDoi;
        private System.Windows.Forms.ToolStripMenuItem mnuTaoDot;
        private System.Windows.Forms.ToolStripMenuItem mnuKhongTinhPBVMT;
        private System.Windows.Forms.ToolStripMenuItem mnuToTruong;
        private System.Windows.Forms.ToolStripMenuItem mnuGiaoTangCuong;
        private System.Windows.Forms.ToolStripMenuItem mnuXuLySoLieu;
        private System.Windows.Forms.ToolStripMenuItem mnuTheoDoiDocSo;
        private System.Windows.Forms.ToolStripMenuItem mnuLichDocSo;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVienDocSo;
        private System.Windows.Forms.ToolStripMenuItem mnuChuyenBilling;
        private System.Windows.Forms.ToolStripMenuItem mnuVanThu;
        private System.Windows.Forms.ToolStripMenuItem mnuCongVanDen;
        private System.Windows.Forms.ToolStripMenuItem mnuDocSoTruoc;
        private System.Windows.Forms.ToolStripMenuItem mnuGhiChu;
        private System.Windows.Forms.ToolStripMenuItem mnuPhieuChuyen;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKe;
        private System.Windows.Forms.ToolStripMenuItem mnusDHN;
        private System.Windows.Forms.ToolStripMenuItem mnuDSsDHN;
        private System.Windows.Forms.ToolStripMenuItem mnuMaHoa;
        private System.Windows.Forms.ToolStripMenuItem mnuDonTu;
        private System.Windows.Forms.ToolStripMenuItem mnuKTXM;
        private System.Windows.Forms.ToolStripMenuItem mnuDieuChinhThongTin;
        private System.Windows.Forms.ToolStripMenuItem mnuToTrinh;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKiem;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaosDHN;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhBoBoQua;
        private System.Windows.Forms.ToolStripMenuItem mnuDHNDienTu;
    }
}

