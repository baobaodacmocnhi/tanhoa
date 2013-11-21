namespace KTKS_DonKH
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnDangNhap = new System.Windows.Forms.RibbonButton();
            this.ribbtnDangXuat = new System.Windows.Forms.RibbonButton();
            this.ribbtnDoiMatKhau = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnTaiKhoan = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnLoaiDonThu = new System.Windows.Forms.RibbonButton();
            this.ribbtnChungTuMoi = new System.Windows.Forms.RibbonButton();
            this.ribbtnKhachHang = new System.Windows.Forms.RibbonButton();
            this.ribbtnChiNhanh = new System.Windows.Forms.RibbonButton();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnNhanDon = new System.Windows.Forms.RibbonButton();
            this.ribbtnQLDonKH = new System.Windows.Forms.RibbonButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatus_TaiKhoan = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnDSDonKTXM = new System.Windows.Forms.RibbonButton();
            this.ribbonTab5 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnDSDonDCBD = new System.Windows.Forms.RibbonButton();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbtnGiaNuoc = new System.Windows.Forms.RibbonButton();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Text = "Hệ Thống";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreEnabled = false;
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.ribbtnDangNhap);
            this.ribbonPanel1.Items.Add(this.ribbtnDangXuat);
            this.ribbonPanel1.Items.Add(this.ribbtnDoiMatKhau);
            this.ribbonPanel1.Text = "Đăng Nhập";
            // 
            // ribbtnDangNhap
            // 
            this.ribbtnDangNhap.Image = global::KTKS_DonKH.Properties.Resources.login_48x48;
            this.ribbtnDangNhap.MinimumSize = new System.Drawing.Size(80, 0);
            this.ribbtnDangNhap.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnDangNhap.SmallImage")));
            this.ribbtnDangNhap.Text = "Đăng Nhập";
            this.ribbtnDangNhap.Click += new System.EventHandler(this.ribbtnDangNhap_Click);
            // 
            // ribbtnDangXuat
            // 
            this.ribbtnDangXuat.Enabled = false;
            this.ribbtnDangXuat.Image = global::KTKS_DonKH.Properties.Resources.logout_48x48;
            this.ribbtnDangXuat.MinimumSize = new System.Drawing.Size(80, 0);
            this.ribbtnDangXuat.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnDangXuat.SmallImage")));
            this.ribbtnDangXuat.Text = "Đăng Xuất";
            this.ribbtnDangXuat.Click += new System.EventHandler(this.ribbtnDangXuat_Click);
            // 
            // ribbtnDoiMatKhau
            // 
            this.ribbtnDoiMatKhau.Enabled = false;
            this.ribbtnDoiMatKhau.Image = global::KTKS_DonKH.Properties.Resources.key_48x48;
            this.ribbtnDoiMatKhau.MinimumSize = new System.Drawing.Size(90, 0);
            this.ribbtnDoiMatKhau.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnDoiMatKhau.SmallImage")));
            this.ribbtnDoiMatKhau.Text = "Đổi Mật Khẩu";
            this.ribbtnDoiMatKhau.Click += new System.EventHandler(this.ribbtnDoiMatKhau_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreEnabled = false;
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.ribbtnTaiKhoan);
            this.ribbonPanel2.Text = "Tạo Tài Khoản & Cấp Quyền";
            // 
            // ribbtnTaiKhoan
            // 
            this.ribbtnTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("ribbtnTaiKhoan.Image")));
            this.ribbtnTaiKhoan.MinimumSize = new System.Drawing.Size(150, 70);
            this.ribbtnTaiKhoan.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnTaiKhoan.SmallImage")));
            this.ribbtnTaiKhoan.Text = "";
            this.ribbtnTaiKhoan.Click += new System.EventHandler(this.ribbtnTaiKhoan_Click);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Panels.Add(this.ribbonPanel3);
            this.ribbonTab2.Text = "Cập Nhật";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ButtonMoreEnabled = false;
            this.ribbonPanel3.ButtonMoreVisible = false;
            this.ribbonPanel3.Items.Add(this.ribbtnLoaiDonThu);
            this.ribbonPanel3.Items.Add(this.ribbtnChungTuMoi);
            this.ribbonPanel3.Items.Add(this.ribbtnKhachHang);
            this.ribbonPanel3.Items.Add(this.ribbtnChiNhanh);
            this.ribbonPanel3.Items.Add(this.ribbtnGiaNuoc);
            this.ribbonPanel3.Text = "Thông Tin";
            // 
            // ribbtnLoaiDonThu
            // 
            this.ribbtnLoaiDonThu.Image = global::KTKS_DonKH.Properties.Resources.stock_example;
            this.ribbtnLoaiDonThu.MinimumSize = new System.Drawing.Size(90, 0);
            this.ribbtnLoaiDonThu.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnLoaiDonThu.SmallImage")));
            this.ribbtnLoaiDonThu.Text = "Loại Đơn Thư";
            this.ribbtnLoaiDonThu.Click += new System.EventHandler(this.ribbtnLoaiDonThu_Click);
            // 
            // ribbtnChungTuMoi
            // 
            this.ribbtnChungTuMoi.Image = global::KTKS_DonKH.Properties.Resources.stock_example;
            this.ribbtnChungTuMoi.MinimumSize = new System.Drawing.Size(100, 0);
            this.ribbtnChungTuMoi.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnChungTuMoi.SmallImage")));
            this.ribbtnChungTuMoi.Text = "Chứng Từ Mới";
            this.ribbtnChungTuMoi.Click += new System.EventHandler(this.ribbtnChungTuMoi_Click);
            // 
            // ribbtnKhachHang
            // 
            this.ribbtnKhachHang.Image = global::KTKS_DonKH.Properties.Resources.stock_example;
            this.ribbtnKhachHang.MinimumSize = new System.Drawing.Size(80, 0);
            this.ribbtnKhachHang.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnKhachHang.SmallImage")));
            this.ribbtnKhachHang.Text = "Khách Hàng";
            this.ribbtnKhachHang.Click += new System.EventHandler(this.ribbtnKhachHang_Click);
            // 
            // ribbtnChiNhanh
            // 
            this.ribbtnChiNhanh.Image = global::KTKS_DonKH.Properties.Resources.stock_example;
            this.ribbtnChiNhanh.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbtnChiNhanh.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnChiNhanh.SmallImage")));
            this.ribbtnChiNhanh.Text = "Chi Nhánh";
            this.ribbtnChiNhanh.Click += new System.EventHandler(this.ribbtnChiNhanh_Click);
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Panels.Add(this.ribbonPanel4);
            this.ribbonTab3.Text = "Khách Hàng";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.ButtonMoreEnabled = false;
            this.ribbonPanel4.ButtonMoreVisible = false;
            this.ribbonPanel4.Items.Add(this.ribbtnNhanDon);
            this.ribbonPanel4.Items.Add(this.ribbtnQLDonKH);
            this.ribbonPanel4.Text = "Đơn Từ";
            // 
            // ribbtnNhanDon
            // 
            this.ribbtnNhanDon.Image = global::KTKS_DonKH.Properties.Resources.stock_example;
            this.ribbtnNhanDon.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbtnNhanDon.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnNhanDon.SmallImage")));
            this.ribbtnNhanDon.Text = "Nhận Đơn";
            this.ribbtnNhanDon.Click += new System.EventHandler(this.ribbtnNhanDon_Click);
            // 
            // ribbtnQLDonKH
            // 
            this.ribbtnQLDonKH.Image = global::KTKS_DonKH.Properties.Resources.stock_example;
            this.ribbtnQLDonKH.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbtnQLDonKH.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnQLDonKH.SmallImage")));
            this.ribbtnQLDonKH.Text = "Quản Lý";
            this.ribbtnQLDonKH.Click += new System.EventHandler(this.ribbtnQLDonKH_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.StripStatus_TaiKhoan});
            this.statusStrip1.Location = new System.Drawing.Point(0, 640);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(787, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(475, 17);
            this.toolStripStatusLabel3.Text = "Bản quyền(2013) thuộc Công ty TNHH MTV Cấp Nước Tân Hòa. Được P.CNTT phát triển";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(631, 15);
            this.toolStripStatusLabel4.Text = resources.GetString("toolStripStatusLabel4.Text");
            // 
            // StripStatus_TaiKhoan
            // 
            this.StripStatus_TaiKhoan.Name = "StripStatus_TaiKhoan";
            this.StripStatus_TaiKhoan.Size = new System.Drawing.Size(0, 0);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(475, 17);
            this.toolStripStatusLabel1.Text = "Bản quyền(2013) thuộc Công ty TNHH MTV Cấp Nước Tân Hòa. Được P.CNTT phát triển";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Panels.Add(this.ribbonPanel5);
            this.ribbonTab4.Text = "Kiểm Tra Xác Minh";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.ButtonMoreEnabled = false;
            this.ribbonPanel5.ButtonMoreVisible = false;
            this.ribbonPanel5.Items.Add(this.ribbtnDSDonKTXM);
            this.ribbonPanel5.Text = "";
            // 
            // ribbtnDSDonKTXM
            // 
            this.ribbtnDSDonKTXM.Image = global::KTKS_DonKH.Properties.Resources.stock_example;
            this.ribbtnDSDonKTXM.MinimumSize = new System.Drawing.Size(100, 0);
            this.ribbtnDSDonKTXM.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnDSDonKTXM.SmallImage")));
            this.ribbtnDSDonKTXM.Text = "Danh Sách Đơn";
            this.ribbtnDSDonKTXM.Click += new System.EventHandler(this.ribbtnDSDonKTXM_Click);
            // 
            // ribbonTab5
            // 
            this.ribbonTab5.Panels.Add(this.ribbonPanel6);
            this.ribbonTab5.Text = "Điều Chỉnh Biến Động";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.ButtonMoreEnabled = false;
            this.ribbonPanel6.ButtonMoreVisible = false;
            this.ribbonPanel6.Items.Add(this.ribbtnDSDonDCBD);
            this.ribbonPanel6.Text = "";
            // 
            // ribbtnDSDonDCBD
            // 
            this.ribbtnDSDonDCBD.Image = global::KTKS_DonKH.Properties.Resources.stock_example;
            this.ribbtnDSDonDCBD.MinimumSize = new System.Drawing.Size(100, 0);
            this.ribbtnDSDonDCBD.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnDSDonDCBD.SmallImage")));
            this.ribbtnDSDonDCBD.Text = "Danh Sách Đơn";
            this.ribbtnDSDonDCBD.Click += new System.EventHandler(this.ribbtnDSDonDCBD_Click);
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = global::KTKS_DonKH.Properties.Resources.logocty;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Visible = false;
            this.ribbon1.Size = new System.Drawing.Size(787, 145);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.Tabs.Add(this.ribbonTab3);
            this.ribbon1.Tabs.Add(this.ribbonTab4);
            this.ribbon1.Tabs.Add(this.ribbonTab5);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbtnGiaNuoc
            // 
            this.ribbtnGiaNuoc.Image = global::KTKS_DonKH.Properties.Resources.stock_example;
            this.ribbtnGiaNuoc.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbtnGiaNuoc.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnGiaNuoc.SmallImage")));
            this.ribbtnGiaNuoc.Text = "Giá Nước";
            this.ribbtnGiaNuoc.Click += new System.EventHandler(this.ribbtnGiaNuoc_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 662);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "Main";
            this.Text = "Chương trình Quản Lý Đơn Từ Khách Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonButton ribbtnDangNhap;
        private System.Windows.Forms.RibbonButton ribbtnDangXuat;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton ribbtnTaiKhoan;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton ribbtnLoaiDonThu;
        private System.Windows.Forms.RibbonButton ribbtnChungTuMoi;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton ribbtnNhanDon;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel StripStatus_TaiKhoan;
        private System.Windows.Forms.RibbonButton ribbtnDoiMatKhau;
        private System.Windows.Forms.RibbonButton ribbtnKhachHang;
        private System.Windows.Forms.RibbonButton ribbtnQLDonKH;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonTab ribbonTab5;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton ribbtnDSDonKTXM;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton ribbtnDSDonDCBD;
        private System.Windows.Forms.RibbonButton ribbtnChiNhanh;
        private System.Windows.Forms.RibbonButton ribbtnGiaNuoc;
    }
}

