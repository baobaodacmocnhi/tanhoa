﻿namespace ThuTien
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
            this.mnuDoi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLuuHD = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToTruong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiaoHDHanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiaoHDTon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDieuChinhDangNgan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiaoTBDongNuoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKiemTraDangNgan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKiemTraTon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNganHanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNganTon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDongNuoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTBDongNuoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKQDongNuoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChuyenKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNganChuyenKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTamThuChuyenKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNganHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNganQuay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTamThuQuay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTongHop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDCHD = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StripStatus_Version = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatus_Form = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatus_HoTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuNangSuatThuTien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuQuanTri,
            this.mnuDoi,
            this.mnuToTruong,
            this.mnuHanhThu,
            this.mnuDongNuoc,
            this.mnuChuyenKhoan,
            this.mnuQuay,
            this.mnuTongHop});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(761, 24);
            this.menuStrip.TabIndex = 0;
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
            this.mnuHeThong.Size = new System.Drawing.Size(72, 20);
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
            this.mnuNguoiDung});
            this.mnuQuanTri.Name = "mnuQuanTri";
            this.mnuQuanTri.Size = new System.Drawing.Size(65, 20);
            this.mnuQuanTri.Text = "Quản Trị";
            // 
            // mnuTo
            // 
            this.mnuTo.Name = "mnuTo";
            this.mnuTo.Size = new System.Drawing.Size(139, 22);
            this.mnuTo.Text = "Tổ";
            this.mnuTo.Click += new System.EventHandler(this.mnuTo_Click);
            // 
            // mnuNhom
            // 
            this.mnuNhom.Name = "mnuNhom";
            this.mnuNhom.Size = new System.Drawing.Size(139, 22);
            this.mnuNhom.Text = "Nhóm";
            this.mnuNhom.Click += new System.EventHandler(this.mnuNhom_Click);
            // 
            // mnuNguoiDung
            // 
            this.mnuNguoiDung.Name = "mnuNguoiDung";
            this.mnuNguoiDung.Size = new System.Drawing.Size(139, 22);
            this.mnuNguoiDung.Text = "Người Dùng";
            this.mnuNguoiDung.Click += new System.EventHandler(this.mnuNguoiDung_Click);
            // 
            // mnuDoi
            // 
            this.mnuDoi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLuuHD});
            this.mnuDoi.Name = "mnuDoi";
            this.mnuDoi.Size = new System.Drawing.Size(37, 20);
            this.mnuDoi.Text = "Đội";
            // 
            // mnuLuuHD
            // 
            this.mnuLuuHD.Name = "mnuLuuHD";
            this.mnuLuuHD.Size = new System.Drawing.Size(144, 22);
            this.mnuLuuHD.Text = "Lưu Hóa Đơn";
            this.mnuLuuHD.Click += new System.EventHandler(this.mnuLuuHoaDon_Click);
            // 
            // mnuToTruong
            // 
            this.mnuToTruong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGiaoHDHanhThu,
            this.mnuGiaoHDTon,
            this.mnuDieuChinhDangNgan,
            this.mnuGiaoTBDongNuoc,
            this.mnuKiemTraDangNgan,
            this.mnuKiemTraTon,
            this.mnuNangSuatThuTien});
            this.mnuToTruong.Name = "mnuToTruong";
            this.mnuToTruong.Size = new System.Drawing.Size(75, 20);
            this.mnuToTruong.Text = "Tổ Trưởng";
            // 
            // mnuGiaoHDHanhThu
            // 
            this.mnuGiaoHDHanhThu.Name = "mnuGiaoHDHanhThu";
            this.mnuGiaoHDHanhThu.Size = new System.Drawing.Size(223, 22);
            this.mnuGiaoHDHanhThu.Text = "Giao Hóa Đơn Hành Thu";
            this.mnuGiaoHDHanhThu.Click += new System.EventHandler(this.mnuGiaoHoaDonHanhThu_Click);
            // 
            // mnuGiaoHDTon
            // 
            this.mnuGiaoHDTon.Name = "mnuGiaoHDTon";
            this.mnuGiaoHDTon.Size = new System.Drawing.Size(223, 22);
            this.mnuGiaoHDTon.Text = "Giao Hóa Đơn Tồn";
            this.mnuGiaoHDTon.Click += new System.EventHandler(this.mnuGiaoHDTon_Click);
            // 
            // mnuDieuChinhDangNgan
            // 
            this.mnuDieuChinhDangNgan.Name = "mnuDieuChinhDangNgan";
            this.mnuDieuChinhDangNgan.Size = new System.Drawing.Size(223, 22);
            this.mnuDieuChinhDangNgan.Text = "Điều Chỉnh Đăng Ngân";
            this.mnuDieuChinhDangNgan.Click += new System.EventHandler(this.mnuDieuChinhDangNgan_Click);
            // 
            // mnuGiaoTBDongNuoc
            // 
            this.mnuGiaoTBDongNuoc.Name = "mnuGiaoTBDongNuoc";
            this.mnuGiaoTBDongNuoc.Size = new System.Drawing.Size(223, 22);
            this.mnuGiaoTBDongNuoc.Text = "Giao Thông Báo Đóng Nước";
            this.mnuGiaoTBDongNuoc.Click += new System.EventHandler(this.mnuGiaoTBDongNuoc_Click_1);
            // 
            // mnuKiemTraDangNgan
            // 
            this.mnuKiemTraDangNgan.Name = "mnuKiemTraDangNgan";
            this.mnuKiemTraDangNgan.Size = new System.Drawing.Size(223, 22);
            this.mnuKiemTraDangNgan.Text = "Kiểm Tra Đăng Ngân";
            this.mnuKiemTraDangNgan.Click += new System.EventHandler(this.mnuKiemTraDangNgan_Click);
            // 
            // mnuKiemTraTon
            // 
            this.mnuKiemTraTon.Name = "mnuKiemTraTon";
            this.mnuKiemTraTon.Size = new System.Drawing.Size(223, 22);
            this.mnuKiemTraTon.Text = "Kiểm Tra Tồn";
            this.mnuKiemTraTon.Click += new System.EventHandler(this.mnuKiemTraTon_Click);
            // 
            // mnuHanhThu
            // 
            this.mnuHanhThu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNganHanhThu,
            this.mnuDangNganTon});
            this.mnuHanhThu.Name = "mnuHanhThu";
            this.mnuHanhThu.Size = new System.Drawing.Size(72, 20);
            this.mnuHanhThu.Text = "Hành Thu";
            // 
            // mnuDangNganHanhThu
            // 
            this.mnuDangNganHanhThu.Name = "mnuDangNganHanhThu";
            this.mnuDangNganHanhThu.Size = new System.Drawing.Size(190, 22);
            this.mnuDangNganHanhThu.Text = "Đăng Ngân Hành Thu";
            this.mnuDangNganHanhThu.Click += new System.EventHandler(this.mnuDangNganHD_Click);
            // 
            // mnuDangNganTon
            // 
            this.mnuDangNganTon.Name = "mnuDangNganTon";
            this.mnuDangNganTon.Size = new System.Drawing.Size(190, 22);
            this.mnuDangNganTon.Text = "Đăng Ngân Tồn";
            this.mnuDangNganTon.Click += new System.EventHandler(this.mnuDangNganTon_Click);
            // 
            // mnuDongNuoc
            // 
            this.mnuDongNuoc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTBDongNuoc,
            this.mnuKQDongNuoc});
            this.mnuDongNuoc.Name = "mnuDongNuoc";
            this.mnuDongNuoc.Size = new System.Drawing.Size(80, 20);
            this.mnuDongNuoc.Text = "Đóng Nước";
            // 
            // mnuTBDongNuoc
            // 
            this.mnuTBDongNuoc.Name = "mnuTBDongNuoc";
            this.mnuTBDongNuoc.Size = new System.Drawing.Size(196, 22);
            this.mnuTBDongNuoc.Text = "Thông Báo Đóng Nước";
            this.mnuTBDongNuoc.Click += new System.EventHandler(this.mnuLenhDongNuoc_Click);
            // 
            // mnuKQDongNuoc
            // 
            this.mnuKQDongNuoc.Name = "mnuKQDongNuoc";
            this.mnuKQDongNuoc.Size = new System.Drawing.Size(196, 22);
            this.mnuKQDongNuoc.Text = "Kết Quả Đóng Nước";
            this.mnuKQDongNuoc.Click += new System.EventHandler(this.mnuKQDongNuoc_Click);
            // 
            // mnuChuyenKhoan
            // 
            this.mnuChuyenKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNganChuyenKhoan,
            this.mnuTamThuChuyenKhoan,
            this.mnuNganHang});
            this.mnuChuyenKhoan.Name = "mnuChuyenKhoan";
            this.mnuChuyenKhoan.Size = new System.Drawing.Size(97, 20);
            this.mnuChuyenKhoan.Text = "Chuyển Khoản";
            // 
            // mnuDangNganChuyenKhoan
            // 
            this.mnuDangNganChuyenKhoan.Name = "mnuDangNganChuyenKhoan";
            this.mnuDangNganChuyenKhoan.Size = new System.Drawing.Size(215, 22);
            this.mnuDangNganChuyenKhoan.Text = "Đăng Ngân Chuyển Khoản";
            this.mnuDangNganChuyenKhoan.Click += new System.EventHandler(this.mnuDangNganChuyenKhoan_Click);
            // 
            // mnuTamThuChuyenKhoan
            // 
            this.mnuTamThuChuyenKhoan.Name = "mnuTamThuChuyenKhoan";
            this.mnuTamThuChuyenKhoan.Size = new System.Drawing.Size(215, 22);
            this.mnuTamThuChuyenKhoan.Text = "Tạm Thu Chuyển Khoản";
            this.mnuTamThuChuyenKhoan.Click += new System.EventHandler(this.mnuTamThuChuyenKhoan_Click);
            // 
            // mnuNganHang
            // 
            this.mnuNganHang.Name = "mnuNganHang";
            this.mnuNganHang.Size = new System.Drawing.Size(215, 22);
            this.mnuNganHang.Text = "Ngân Hàng";
            this.mnuNganHang.Click += new System.EventHandler(this.mnuNganHang_Click);
            // 
            // mnuQuay
            // 
            this.mnuQuay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNganQuay,
            this.mnuTamThuQuay});
            this.mnuQuay.Name = "mnuQuay";
            this.mnuQuay.Size = new System.Drawing.Size(47, 20);
            this.mnuQuay.Text = "Quầy";
            // 
            // mnuDangNganQuay
            // 
            this.mnuDangNganQuay.Name = "mnuDangNganQuay";
            this.mnuDangNganQuay.Size = new System.Drawing.Size(165, 22);
            this.mnuDangNganQuay.Text = "Đăng Ngân Quầy";
            this.mnuDangNganQuay.Click += new System.EventHandler(this.mnuDangNganQuay_Click);
            // 
            // mnuTamThuQuay
            // 
            this.mnuTamThuQuay.Name = "mnuTamThuQuay";
            this.mnuTamThuQuay.Size = new System.Drawing.Size(165, 22);
            this.mnuTamThuQuay.Text = "Tạm Thu Quầy";
            this.mnuTamThuQuay.Click += new System.EventHandler(this.mnuTamThu_Click);
            // 
            // mnuTongHop
            // 
            this.mnuTongHop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDCHD});
            this.mnuTongHop.Name = "mnuTongHop";
            this.mnuTongHop.Size = new System.Drawing.Size(73, 20);
            this.mnuTongHop.Text = "Tổng Hợp";
            // 
            // mnuDCHD
            // 
            this.mnuDCHD.Name = "mnuDCHD";
            this.mnuDCHD.Size = new System.Drawing.Size(183, 22);
            this.mnuDCHD.Text = "Điều Chỉnh Hóa Đơn";
            this.mnuDCHD.Click += new System.EventHandler(this.mnuDCHD_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripStatus_Version,
            this.toolStripStatusLabel4,
            this.StripStatus_Form,
            this.toolStripStatusLabel5,
            this.StripStatus_HoTen});
            this.statusStrip1.Location = new System.Drawing.Point(0, 391);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(761, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StripStatus_Version
            // 
            this.StripStatus_Version.Name = "StripStatus_Version";
            this.StripStatus_Version.Size = new System.Drawing.Size(410, 17);
            this.StripStatus_Version.Text = "Bản quyền(2014) thuộc Công ty Cấp Nước Tân Hòa. Được T.CNTT phát triển";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(151, 17);
            this.toolStripStatusLabel4.Text = "                                                ";
            // 
            // StripStatus_Form
            // 
            this.StripStatus_Form.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StripStatus_Form.Name = "StripStatus_Form";
            this.StripStatus_Form.Size = new System.Drawing.Size(93, 17);
            this.StripStatus_Form.Text = "Đang mở Form:";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(172, 15);
            this.toolStripStatusLabel5.Text = "                                                       ";
            // 
            // StripStatus_HoTen
            // 
            this.StripStatus_HoTen.Name = "StripStatus_HoTen";
            this.StripStatus_HoTen.Size = new System.Drawing.Size(58, 15);
            this.StripStatus_HoTen.Text = "Xin Chào:";
            this.StripStatus_HoTen.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // mnuNangSuatThuTien
            // 
            this.mnuNangSuatThuTien.Name = "mnuNangSuatThuTien";
            this.mnuNangSuatThuTien.Size = new System.Drawing.Size(223, 22);
            this.mnuNangSuatThuTien.Text = "Năng Suất Thu Tiền";
            this.mnuNangSuatThuTien.Click += new System.EventHandler(this.mnuNangSuatThuTien_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(761, 413);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Text = "Quản Lý Thu Ngân";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanTri;
        private System.Windows.Forms.ToolStripMenuItem mnuTo;
        private System.Windows.Forms.ToolStripMenuItem mnuNhom;
        private System.Windows.Forms.ToolStripMenuItem mnuNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem mnuAdmin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StripStatus_Version;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel StripStatus_Form;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel StripStatus_HoTen;
        private System.Windows.Forms.ToolStripMenuItem mnuDoi;
        private System.Windows.Forms.ToolStripMenuItem mnuLuuHD;
        private System.Windows.Forms.ToolStripMenuItem mnuToTruong;
        private System.Windows.Forms.ToolStripMenuItem mnuGiaoHDHanhThu;
        private System.Windows.Forms.ToolStripMenuItem mnuGiaoHDTon;
        private System.Windows.Forms.ToolStripMenuItem mnuHanhThu;
        private System.Windows.Forms.ToolStripMenuItem mnuDangNganHanhThu;
        private System.Windows.Forms.ToolStripMenuItem mnuDongNuoc;
        private System.Windows.Forms.ToolStripMenuItem mnuChuyenKhoan;
        private System.Windows.Forms.ToolStripMenuItem mnuQuay;
        private System.Windows.Forms.ToolStripMenuItem mnuTongHop;
        private System.Windows.Forms.ToolStripMenuItem mnuDangNganChuyenKhoan;
        private System.Windows.Forms.ToolStripMenuItem mnuDangNganQuay;
        private System.Windows.Forms.ToolStripMenuItem mnuTamThuQuay;
        private System.Windows.Forms.ToolStripMenuItem mnuTamThuChuyenKhoan;
        private System.Windows.Forms.ToolStripMenuItem mnuNganHang;
        private System.Windows.Forms.ToolStripMenuItem mnuDCHD;
        private System.Windows.Forms.ToolStripMenuItem mnuDieuChinhDangNgan;
        private System.Windows.Forms.ToolStripMenuItem mnuTBDongNuoc;
        private System.Windows.Forms.ToolStripMenuItem mnuKQDongNuoc;
        private System.Windows.Forms.ToolStripMenuItem mnuGiaoTBDongNuoc;
        private System.Windows.Forms.ToolStripMenuItem mnuDangNganTon;
        private System.Windows.Forms.ToolStripMenuItem mnuKiemTraDangNgan;
        private System.Windows.Forms.ToolStripMenuItem mnuKiemTraTon;
        private System.Windows.Forms.ToolStripMenuItem mnuNangSuatThuTien;
    }
}

