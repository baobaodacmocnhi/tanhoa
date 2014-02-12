namespace KTKS_DonKH
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barSubItem_Giaodien = new DevExpress.XtraBars.BarSubItem();
            this.barbtnDangNhap = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnDoiMatKhau = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage6 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage7 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage8 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonStatusBar2 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.TabControl = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barSubItem_Giaodien,
            this.barbtnDangNhap,
            this.barbtnDangXuat,
            this.barbtnDoiMatKhau,
            this.barbtnTaiKhoan});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4);
            this.ribbonControl1.MaxItemId = 18;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.barSubItem_Giaodien);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3,
            this.ribbonPage4,
            this.ribbonPage5,
            this.ribbonPage6,
            this.ribbonPage7,
            this.ribbonPage8});
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1146, 148);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar2;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // barSubItem_Giaodien
            // 
            this.barSubItem_Giaodien.Caption = "barSubItem1";
            this.barSubItem_Giaodien.Id = 8;
            this.barSubItem_Giaodien.Name = "barSubItem_Giaodien";
            // 
            // barbtnDangNhap
            // 
            this.barbtnDangNhap.Caption = "Đăng Nhập";
            this.barbtnDangNhap.Id = 11;
            this.barbtnDangNhap.LargeGlyph = global::KTKS_DonKH.Properties.Resources.login_48x48;
            this.barbtnDangNhap.LargeWidth = 100;
            this.barbtnDangNhap.Name = "barbtnDangNhap";
            this.barbtnDangNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnDangNhap_ItemClick);
            // 
            // barbtnDangXuat
            // 
            this.barbtnDangXuat.Caption = "Đăng Xuất";
            this.barbtnDangXuat.Enabled = false;
            this.barbtnDangXuat.Id = 12;
            this.barbtnDangXuat.LargeGlyph = global::KTKS_DonKH.Properties.Resources.logout_48x48;
            this.barbtnDangXuat.Name = "barbtnDangXuat";
            this.barbtnDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnDangXuat_ItemClick);
            // 
            // barbtnDoiMatKhau
            // 
            this.barbtnDoiMatKhau.Caption = "Đổi Mật Khẩu";
            this.barbtnDoiMatKhau.Enabled = false;
            this.barbtnDoiMatKhau.Id = 13;
            this.barbtnDoiMatKhau.LargeGlyph = global::KTKS_DonKH.Properties.Resources.key_48x48;
            this.barbtnDoiMatKhau.LargeWidth = 80;
            this.barbtnDoiMatKhau.Name = "barbtnDoiMatKhau";
            this.barbtnDoiMatKhau.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnDoiMatKhau_ItemClick);
            // 
            // barbtnTaiKhoan
            // 
            this.barbtnTaiKhoan.Caption = "Người Dùng";
            this.barbtnTaiKhoan.Id = 14;
            this.barbtnTaiKhoan.LargeGlyph = global::KTKS_DonKH.Properties.Resources.people_48x48;
            this.barbtnTaiKhoan.LargeWidth = 120;
            this.barbtnTaiKhoan.Name = "barbtnTaiKhoan";
            this.barbtnTaiKhoan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnTaiKhoan_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonPage1.Appearance.Options.UseFont = true;
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hệ Thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnDangNhap);
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnDangXuat);
            this.ribbonPageGroup1.ItemLinks.Add(this.barbtnDoiMatKhau);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Đăng Nhập";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barbtnTaiKhoan);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Tài Khoản & Cấp Quyền";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonPage2.Appearance.Options.UseFont = true;
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Cập Nhật";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonPage3.Appearance.Options.UseFont = true;
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Khách Hàng";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonPage4.Appearance.Options.UseFont = true;
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "Kiểm Tra Xác Minh";
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonPage5.Appearance.Options.UseFont = true;
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "Điều Chỉnh Biến Động";
            // 
            // ribbonPage6
            // 
            this.ribbonPage6.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonPage6.Appearance.Options.UseFont = true;
            this.ribbonPage6.Name = "ribbonPage6";
            this.ribbonPage6.Text = "Cắt Hủy Danh Bộ";
            // 
            // ribbonPage7
            // 
            this.ribbonPage7.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonPage7.Appearance.Options.UseFont = true;
            this.ribbonPage7.Name = "ribbonPage7";
            this.ribbonPage7.Text = "Thảo Thư Trả Lời";
            // 
            // ribbonPage8
            // 
            this.ribbonPage8.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonPage8.Appearance.Options.UseFont = true;
            this.ribbonPage8.Name = "ribbonPage8";
            this.ribbonPage8.Text = "Liên Hệ";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(1, 515);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1140, 27);
            // 
            // ribbonStatusBar2
            // 
            this.ribbonStatusBar2.Location = new System.Drawing.Point(1, 515);
            this.ribbonStatusBar2.Name = "ribbonStatusBar2";
            this.ribbonStatusBar2.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar2.Size = new System.Drawing.Size(1140, 27);
            // 
            // TabControl
            // 
            this.TabControl.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 148);
            this.TabControl.Name = "TabControl";
            this.TabControl.Size = new System.Drawing.Size(1146, 547);
            this.TabControl.TabIndex = 3;
            // 
            // frmMain
            // 
            this.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 695);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 696);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Chương trình Quản Lý Đơn Khách Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.BarSubItem barSubItem_Giaodien;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barbtnDangNhap;
        private DevExpress.XtraBars.BarButtonItem barbtnDangXuat;
        private DevExpress.XtraBars.BarButtonItem barbtnDoiMatKhau;
        private DevExpress.XtraBars.BarButtonItem barbtnTaiKhoan;
        public DevExpress.XtraTab.XtraTabControl TabControl;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage6;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage7;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage8;
    }
}