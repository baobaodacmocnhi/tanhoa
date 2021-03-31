namespace KeToan
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
            this.mnuNhom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCapNhat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNganHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiTuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhieuThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhieuChi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSoLieuChungTu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDonDienTu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBienLaiThuTien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiaiTrachTienNuoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiaiTrachTienNuoc_Nhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiaiTrachTienNuoc_Xuat = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuQuanTri,
            this.mnuCapNhat,
            this.mnuNhapLieu,
            this.mnuHoaDonDienTu,
            this.mnuGiaiTrachTienNuoc});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1068, 24);
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
            this.mnuNhom,
            this.mnuUser});
            this.mnuQuanTri.Name = "mnuQuanTri";
            this.mnuQuanTri.Size = new System.Drawing.Size(63, 20);
            this.mnuQuanTri.Text = "Quản Trị";
            // 
            // mnuNhom
            // 
            this.mnuNhom.Name = "mnuNhom";
            this.mnuNhom.Size = new System.Drawing.Size(139, 22);
            this.mnuNhom.Text = "Nhóm";
            this.mnuNhom.Click += new System.EventHandler(this.mnuNhom_Click);
            // 
            // mnuUser
            // 
            this.mnuUser.Name = "mnuUser";
            this.mnuUser.Size = new System.Drawing.Size(139, 22);
            this.mnuUser.Text = "Người Dùng";
            this.mnuUser.Click += new System.EventHandler(this.mnuUser_Click);
            // 
            // mnuCapNhat
            // 
            this.mnuCapNhat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNganHang,
            this.mnuDoiTuong});
            this.mnuCapNhat.Name = "mnuCapNhat";
            this.mnuCapNhat.Size = new System.Drawing.Size(69, 20);
            this.mnuCapNhat.Text = "Cập Nhật";
            // 
            // mnuNganHang
            // 
            this.mnuNganHang.Name = "mnuNganHang";
            this.mnuNganHang.Size = new System.Drawing.Size(135, 22);
            this.mnuNganHang.Text = "Ngân Hàng";
            this.mnuNganHang.Click += new System.EventHandler(this.mnuNganHang_Click);
            // 
            // mnuDoiTuong
            // 
            this.mnuDoiTuong.Name = "mnuDoiTuong";
            this.mnuDoiTuong.Size = new System.Drawing.Size(135, 22);
            this.mnuDoiTuong.Text = "Đối Tượng";
            this.mnuDoiTuong.Click += new System.EventHandler(this.mnuDoiTuong_Click);
            // 
            // mnuNhapLieu
            // 
            this.mnuNhapLieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPhieuThu,
            this.mnuPhieuChi,
            this.mnuSoLieuChungTu});
            this.mnuNhapLieu.Name = "mnuNhapLieu";
            this.mnuNhapLieu.Size = new System.Drawing.Size(73, 20);
            this.mnuNhapLieu.Text = "Nhập Liệu";
            // 
            // mnuPhieuThu
            // 
            this.mnuPhieuThu.Name = "mnuPhieuThu";
            this.mnuPhieuThu.Size = new System.Drawing.Size(167, 22);
            this.mnuPhieuThu.Text = "Phiếu Thu";
            this.mnuPhieuThu.Click += new System.EventHandler(this.mnuPhieuThu_Click);
            // 
            // mnuPhieuChi
            // 
            this.mnuPhieuChi.Name = "mnuPhieuChi";
            this.mnuPhieuChi.Size = new System.Drawing.Size(167, 22);
            this.mnuPhieuChi.Text = "Phiếu Chi";
            this.mnuPhieuChi.Click += new System.EventHandler(this.mnuPhieuChi_Click);
            // 
            // mnuSoLieuChungTu
            // 
            this.mnuSoLieuChungTu.Name = "mnuSoLieuChungTu";
            this.mnuSoLieuChungTu.Size = new System.Drawing.Size(167, 22);
            this.mnuSoLieuChungTu.Text = "Số Liệu Chứng Từ";
            this.mnuSoLieuChungTu.Click += new System.EventHandler(this.mnuSoLieuChungTu_Click);
            // 
            // mnuHoaDonDienTu
            // 
            this.mnuHoaDonDienTu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBienLaiThuTien});
            this.mnuHoaDonDienTu.Name = "mnuHoaDonDienTu";
            this.mnuHoaDonDienTu.Size = new System.Drawing.Size(109, 20);
            this.mnuHoaDonDienTu.Text = "Hóa Đơn Điện Tử";
            // 
            // mnuBienLaiThuTien
            // 
            this.mnuBienLaiThuTien.Name = "mnuBienLaiThuTien";
            this.mnuBienLaiThuTien.Size = new System.Drawing.Size(163, 22);
            this.mnuBienLaiThuTien.Text = "Biên Lai Thu Tiền";
            this.mnuBienLaiThuTien.Click += new System.EventHandler(this.mnuBienLaiThuTien_Click);
            // 
            // mnuGiaiTrachTienNuoc
            // 
            this.mnuGiaiTrachTienNuoc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGiaiTrachTienNuoc_Nhap,
            this.mnuGiaiTrachTienNuoc_Xuat});
            this.mnuGiaiTrachTienNuoc.Name = "mnuGiaiTrachTienNuoc";
            this.mnuGiaiTrachTienNuoc.Size = new System.Drawing.Size(127, 20);
            this.mnuGiaiTrachTienNuoc.Text = "Giải Trách Tiền Nước";
            // 
            // mnuGiaiTrachTienNuoc_Nhap
            // 
            this.mnuGiaiTrachTienNuoc_Nhap.Name = "mnuGiaiTrachTienNuoc_Nhap";
            this.mnuGiaiTrachTienNuoc_Nhap.Size = new System.Drawing.Size(152, 22);
            this.mnuGiaiTrachTienNuoc_Nhap.Text = "Nhập";
            this.mnuGiaiTrachTienNuoc_Nhap.Click += new System.EventHandler(this.mnuGiaiTrachTienNuoc_Nhap_Click);
            // 
            // mnuGiaiTrachTienNuoc_Xuat
            // 
            this.mnuGiaiTrachTienNuoc_Xuat.Name = "mnuGiaiTrachTienNuoc_Xuat";
            this.mnuGiaiTrachTienNuoc_Xuat.Size = new System.Drawing.Size(152, 22);
            this.mnuGiaiTrachTienNuoc_Xuat.Text = "Xuất";
            this.mnuGiaiTrachTienNuoc_Xuat.Click += new System.EventHandler(this.mnuGiaiTrachTienNuoc_Xuat_Click);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1068, 26);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 433);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1068, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // StripStatus_Version
            // 
            this.StripStatus_Version.Name = "StripStatus_Version";
            this.StripStatus_Version.Size = new System.Drawing.Size(533, 17);
            this.StripStatus_Version.Text = "Bản quyền(2018) thuộc Công ty CP Cấp Nước Tân Hòa. Được Phòng Kỹ Thuật Công Nghệ " +
                "phát triển";
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
            this.ClientSize = new System.Drawing.Size(1068, 455);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Text = "Phần Mềm Kế Toán";
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
        private System.Windows.Forms.ToolStripMenuItem mnuNhom;
        private System.Windows.Forms.ToolStripMenuItem mnuUser;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StripStatus_Version;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel StripStatus_HoTen;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem mnuCapNhat;
        private System.Windows.Forms.ToolStripMenuItem mnuNganHang;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapLieu;
        private System.Windows.Forms.ToolStripMenuItem mnuPhieuThu;
        private System.Windows.Forms.ToolStripMenuItem mnuPhieuChi;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiTuong;
        private System.Windows.Forms.ToolStripMenuItem mnuHoaDonDienTu;
        private System.Windows.Forms.ToolStripMenuItem mnuBienLaiThuTien;
        private System.Windows.Forms.ToolStripMenuItem mnuSoLieuChungTu;
        private System.Windows.Forms.ToolStripMenuItem mnuGiaiTrachTienNuoc;
        private System.Windows.Forms.ToolStripMenuItem mnuGiaiTrachTienNuoc_Nhap;
        private System.Windows.Forms.ToolStripMenuItem mnuGiaiTrachTienNuoc_Xuat;
    }
}

