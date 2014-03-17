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
            this.ribbtnGiaNuoc = new System.Windows.Forms.RibbonButton();
            this.ribbtnNVKiemTra = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel9 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnBanGiamDoc = new System.Windows.Forms.RibbonButton();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnNhanDon = new System.Windows.Forms.RibbonButton();
            this.ribbtnQLDonKH = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel14 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnNhanDonTXL = new System.Windows.Forms.RibbonButton();
            this.ribbtnQLDonTXL = new System.Windows.Forms.RibbonButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StripStatus_Version = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatus_Form = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatus_TaiKhoan = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnDSDonKTXM = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel11 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnNhapKetQua = new System.Windows.Forms.RibbonButton();
            this.ribbonTab5 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnDSDonDCBD = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnDCBD = new System.Windows.Forms.RibbonButton();
            this.ribbtnDCHD = new System.Windows.Forms.RibbonButton();
            this.ribbonTab6 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel8 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnDSDonCHDB = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel12 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnCTDB = new System.Windows.Forms.RibbonButton();
            this.ribbtnCHDB = new System.Windows.Forms.RibbonButton();
            this.ribbonTab7 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel10 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnDSDonTTTL = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel13 = new System.Windows.Forms.RibbonPanel();
            this.ribbtnTTTL = new System.Windows.Forms.RibbonButton();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
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
            this.ribbonTab2.Panels.Add(this.ribbonPanel9);
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
            this.ribbonPanel3.Items.Add(this.ribbtnNVKiemTra);
            this.ribbonPanel3.Text = "Thông Tin";
            // 
            // ribbtnLoaiDonThu
            // 
            this.ribbtnLoaiDonThu.Image = global::KTKS_DonKH.Properties.Resources.folder_document_48x48;
            this.ribbtnLoaiDonThu.MinimumSize = new System.Drawing.Size(90, 0);
            this.ribbtnLoaiDonThu.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnLoaiDonThu.SmallImage")));
            this.ribbtnLoaiDonThu.Text = "Loại Đơn Thư";
            this.ribbtnLoaiDonThu.Click += new System.EventHandler(this.ribbtnLoaiDonThu_Click);
            // 
            // ribbtnChungTuMoi
            // 
            this.ribbtnChungTuMoi.Image = global::KTKS_DonKH.Properties.Resources.id_home_48x48;
            this.ribbtnChungTuMoi.MinimumSize = new System.Drawing.Size(100, 0);
            this.ribbtnChungTuMoi.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnChungTuMoi.SmallImage")));
            this.ribbtnChungTuMoi.Text = "Chứng Từ Mới";
            this.ribbtnChungTuMoi.Click += new System.EventHandler(this.ribbtnChungTuMoi_Click);
            // 
            // ribbtnKhachHang
            // 
            this.ribbtnKhachHang.Image = global::KTKS_DonKH.Properties.Resources.customer_48x48;
            this.ribbtnKhachHang.MinimumSize = new System.Drawing.Size(80, 0);
            this.ribbtnKhachHang.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnKhachHang.SmallImage")));
            this.ribbtnKhachHang.Text = "Khách Hàng";
            this.ribbtnKhachHang.Click += new System.EventHandler(this.ribbtnKhachHang_Click);
            // 
            // ribbtnChiNhanh
            // 
            this.ribbtnChiNhanh.Image = global::KTKS_DonKH.Properties.Resources.office_building_48x48;
            this.ribbtnChiNhanh.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbtnChiNhanh.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnChiNhanh.SmallImage")));
            this.ribbtnChiNhanh.Text = "Chi Nhánh";
            this.ribbtnChiNhanh.Click += new System.EventHandler(this.ribbtnChiNhanh_Click);
            // 
            // ribbtnGiaNuoc
            // 
            this.ribbtnGiaNuoc.Image = global::KTKS_DonKH.Properties.Resources.cash_48x48;
            this.ribbtnGiaNuoc.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbtnGiaNuoc.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnGiaNuoc.SmallImage")));
            this.ribbtnGiaNuoc.Text = "Giá Nước";
            this.ribbtnGiaNuoc.Click += new System.EventHandler(this.ribbtnGiaNuoc_Click);
            // 
            // ribbtnNVKiemTra
            // 
            this.ribbtnNVKiemTra.Image = global::KTKS_DonKH.Properties.Resources.man_48x48;
            this.ribbtnNVKiemTra.MinimumSize = new System.Drawing.Size(90, 0);
            this.ribbtnNVKiemTra.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnNVKiemTra.SmallImage")));
            this.ribbtnNVKiemTra.Text = "NV Kiểm Tra";
            this.ribbtnNVKiemTra.Visible = false;
            this.ribbtnNVKiemTra.Click += new System.EventHandler(this.ribbtnNVKiemTra_Click);
            // 
            // ribbonPanel9
            // 
            this.ribbonPanel9.ButtonMoreEnabled = false;
            this.ribbonPanel9.ButtonMoreVisible = false;
            this.ribbonPanel9.Items.Add(this.ribbtnBanGiamDoc);
            this.ribbonPanel9.Text = "Trình Ký";
            // 
            // ribbtnBanGiamDoc
            // 
            this.ribbtnBanGiamDoc.Image = global::KTKS_DonKH.Properties.Resources.Chief_48x48;
            this.ribbtnBanGiamDoc.MinimumSize = new System.Drawing.Size(90, 0);
            this.ribbtnBanGiamDoc.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnBanGiamDoc.SmallImage")));
            this.ribbtnBanGiamDoc.Text = "Ban Giám Đốc";
            this.ribbtnBanGiamDoc.Click += new System.EventHandler(this.ribbtnBanGiamDoc_Click);
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Panels.Add(this.ribbonPanel4);
            this.ribbonTab3.Panels.Add(this.ribbonPanel14);
            this.ribbonTab3.Text = "Đơn Từ";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.ButtonMoreEnabled = false;
            this.ribbonPanel4.ButtonMoreVisible = false;
            this.ribbonPanel4.Items.Add(this.ribbtnNhanDon);
            this.ribbonPanel4.Items.Add(this.ribbtnQLDonKH);
            this.ribbonPanel4.Text = "Khách Hàng";
            // 
            // ribbtnNhanDon
            // 
            this.ribbtnNhanDon.Image = global::KTKS_DonKH.Properties.Resources.forms_48x48;
            this.ribbtnNhanDon.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbtnNhanDon.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnNhanDon.SmallImage")));
            this.ribbtnNhanDon.Text = "Nhận Đơn";
            this.ribbtnNhanDon.Click += new System.EventHandler(this.ribbtnNhanDon_Click);
            // 
            // ribbtnQLDonKH
            // 
            this.ribbtnQLDonKH.Image = global::KTKS_DonKH.Properties.Resources.my_documents_48x48;
            this.ribbtnQLDonKH.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbtnQLDonKH.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnQLDonKH.SmallImage")));
            this.ribbtnQLDonKH.Text = "Quản Lý";
            this.ribbtnQLDonKH.Click += new System.EventHandler(this.ribbtnQLDonKH_Click);
            // 
            // ribbonPanel14
            // 
            this.ribbonPanel14.ButtonMoreEnabled = false;
            this.ribbonPanel14.ButtonMoreVisible = false;
            this.ribbonPanel14.Items.Add(this.ribbtnNhanDonTXL);
            this.ribbonPanel14.Items.Add(this.ribbtnQLDonTXL);
            this.ribbonPanel14.Text = "Tổ Xử Lý";
            // 
            // ribbtnNhanDonTXL
            // 
            this.ribbtnNhanDonTXL.Image = global::KTKS_DonKH.Properties.Resources.forms_48x48_b;
            this.ribbtnNhanDonTXL.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbtnNhanDonTXL.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnNhanDonTXL.SmallImage")));
            this.ribbtnNhanDonTXL.Text = "Nhận Đơn";
            this.ribbtnNhanDonTXL.Click += new System.EventHandler(this.ribbtnNhanDonTXL_Click);
            // 
            // ribbtnQLDonTXL
            // 
            this.ribbtnQLDonTXL.Image = global::KTKS_DonKH.Properties.Resources.my_documents_48x48_b;
            this.ribbtnQLDonTXL.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbtnQLDonTXL.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnQLDonTXL.SmallImage")));
            this.ribbtnQLDonTXL.Text = "Quản Lý";
            this.ribbtnQLDonTXL.Click += new System.EventHandler(this.ribbtnQLDonTXL_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripStatus_Version,
            this.toolStripStatusLabel4,
            this.StripStatus_Form,
            this.toolStripStatusLabel5,
            this.StripStatus_TaiKhoan});
            this.statusStrip1.Location = new System.Drawing.Point(0, 640);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1140, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StripStatus_Version
            // 
            this.StripStatus_Version.Name = "StripStatus_Version";
            this.StripStatus_Version.Size = new System.Drawing.Size(475, 17);
            this.StripStatus_Version.Text = "Bản quyền(2013) thuộc Công ty TNHH MTV Cấp Nước Tân Hòa. Được P.CNTT phát triển";
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
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(172, 17);
            this.toolStripStatusLabel5.Text = "                                                       ";
            // 
            // StripStatus_TaiKhoan
            // 
            this.StripStatus_TaiKhoan.Name = "StripStatus_TaiKhoan";
            this.StripStatus_TaiKhoan.Size = new System.Drawing.Size(124, 17);
            this.StripStatus_TaiKhoan.Text = "Tài Khoản đang dùng:";
            this.StripStatus_TaiKhoan.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
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
            this.ribbonTab4.Panels.Add(this.ribbonPanel11);
            this.ribbonTab4.Text = "Kiểm Tra Xác Minh";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.ButtonMoreEnabled = false;
            this.ribbonPanel5.ButtonMoreVisible = false;
            this.ribbonPanel5.Items.Add(this.ribbtnDSDonKTXM);
            this.ribbonPanel5.Text = "Thông Tin";
            // 
            // ribbtnDSDonKTXM
            // 
            this.ribbtnDSDonKTXM.Image = global::KTKS_DonKH.Properties.Resources.list_48x48;
            this.ribbtnDSDonKTXM.MinimumSize = new System.Drawing.Size(100, 0);
            this.ribbtnDSDonKTXM.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnDSDonKTXM.SmallImage")));
            this.ribbtnDSDonKTXM.Text = "Danh Sách Đơn";
            this.ribbtnDSDonKTXM.Click += new System.EventHandler(this.ribbtnDSDonKTXM_Click);
            // 
            // ribbonPanel11
            // 
            this.ribbonPanel11.ButtonMoreEnabled = false;
            this.ribbonPanel11.ButtonMoreVisible = false;
            this.ribbonPanel11.Items.Add(this.ribbtnNhapKetQua);
            this.ribbonPanel11.Text = "Xử Lý";
            // 
            // ribbtnNhapKetQua
            // 
            this.ribbtnNhapKetQua.Image = global::KTKS_DonKH.Properties.Resources.Search_Results_48x48;
            this.ribbtnNhapKetQua.MinimumSize = new System.Drawing.Size(100, 0);
            this.ribbtnNhapKetQua.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnNhapKetQua.SmallImage")));
            this.ribbtnNhapKetQua.Text = "Nhập Kết Quả";
            this.ribbtnNhapKetQua.Click += new System.EventHandler(this.ribbtnNhapKetQua_Click);
            // 
            // ribbonTab5
            // 
            this.ribbonTab5.Panels.Add(this.ribbonPanel6);
            this.ribbonTab5.Panels.Add(this.ribbonPanel7);
            this.ribbonTab5.Text = "Điều Chỉnh Biến Động";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.ButtonMoreEnabled = false;
            this.ribbonPanel6.ButtonMoreVisible = false;
            this.ribbonPanel6.Items.Add(this.ribbtnDSDonDCBD);
            this.ribbonPanel6.Text = "Thông Tin";
            // 
            // ribbtnDSDonDCBD
            // 
            this.ribbtnDSDonDCBD.Image = global::KTKS_DonKH.Properties.Resources.list_48x48;
            this.ribbtnDSDonDCBD.MinimumSize = new System.Drawing.Size(100, 0);
            this.ribbtnDSDonDCBD.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnDSDonDCBD.SmallImage")));
            this.ribbtnDSDonDCBD.Text = "Danh Sách Đơn";
            this.ribbtnDSDonDCBD.Click += new System.EventHandler(this.ribbtnDSDonDCBD_Click);
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.ButtonMoreEnabled = false;
            this.ribbonPanel7.ButtonMoreVisible = false;
            this.ribbonPanel7.Items.Add(this.ribbtnDCBD);
            this.ribbonPanel7.Items.Add(this.ribbtnDCHD);
            this.ribbonPanel7.Text = "Xử Lý";
            // 
            // ribbtnDCBD
            // 
            this.ribbtnDCBD.Image = global::KTKS_DonKH.Properties.Resources.edit_paper_48x48;
            this.ribbtnDCBD.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbtnDCBD.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnDCBD.SmallImage")));
            this.ribbtnDCBD.Text = "Biến Động";
            this.ribbtnDCBD.Click += new System.EventHandler(this.ribbtnDCBD_Click);
            // 
            // ribbtnDCHD
            // 
            this.ribbtnDCHD.Image = global::KTKS_DonKH.Properties.Resources.bill_48x48;
            this.ribbtnDCHD.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbtnDCHD.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnDCHD.SmallImage")));
            this.ribbtnDCHD.Text = "Hóa Đơn";
            this.ribbtnDCHD.Click += new System.EventHandler(this.ribbtnDCHD_Click);
            // 
            // ribbonTab6
            // 
            this.ribbonTab6.Panels.Add(this.ribbonPanel8);
            this.ribbonTab6.Panels.Add(this.ribbonPanel12);
            this.ribbonTab6.Text = "Cắt Hủy Danh Bộ";
            // 
            // ribbonPanel8
            // 
            this.ribbonPanel8.ButtonMoreEnabled = false;
            this.ribbonPanel8.ButtonMoreVisible = false;
            this.ribbonPanel8.Items.Add(this.ribbtnDSDonCHDB);
            this.ribbonPanel8.Text = "Thông Tin";
            // 
            // ribbtnDSDonCHDB
            // 
            this.ribbtnDSDonCHDB.Image = global::KTKS_DonKH.Properties.Resources.list_48x48;
            this.ribbtnDSDonCHDB.MinimumSize = new System.Drawing.Size(100, 0);
            this.ribbtnDSDonCHDB.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnDSDonCHDB.SmallImage")));
            this.ribbtnDSDonCHDB.Text = "Danh Sách Đơn";
            this.ribbtnDSDonCHDB.Click += new System.EventHandler(this.ribbtnDSDonCHDB_Click);
            // 
            // ribbonPanel12
            // 
            this.ribbonPanel12.ButtonMoreEnabled = false;
            this.ribbonPanel12.ButtonMoreVisible = false;
            this.ribbonPanel12.Items.Add(this.ribbtnCTDB);
            this.ribbonPanel12.Items.Add(this.ribbtnCHDB);
            this.ribbonPanel12.Text = "Xử Lý";
            // 
            // ribbtnCTDB
            // 
            this.ribbtnCTDB.Image = global::KTKS_DonKH.Properties.Resources.cut_48x48;
            this.ribbtnCTDB.MinimumSize = new System.Drawing.Size(110, 0);
            this.ribbtnCTDB.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnCTDB.SmallImage")));
            this.ribbtnCTDB.Text = "Cắt Tạm Danh Bộ";
            this.ribbtnCTDB.Click += new System.EventHandler(this.ribbtnCTDB_Click);
            // 
            // ribbtnCHDB
            // 
            this.ribbtnCHDB.Image = global::KTKS_DonKH.Properties.Resources.Close_48x48;
            this.ribbtnCHDB.MinimumSize = new System.Drawing.Size(110, 0);
            this.ribbtnCHDB.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnCHDB.SmallImage")));
            this.ribbtnCHDB.Text = "Cắt Hủy Danh Bộ";
            this.ribbtnCHDB.Click += new System.EventHandler(this.ribbtnCHDB_Click);
            // 
            // ribbonTab7
            // 
            this.ribbonTab7.Panels.Add(this.ribbonPanel10);
            this.ribbonTab7.Panels.Add(this.ribbonPanel13);
            this.ribbonTab7.Text = "Thảo Thư Trả Lời";
            // 
            // ribbonPanel10
            // 
            this.ribbonPanel10.ButtonMoreEnabled = false;
            this.ribbonPanel10.ButtonMoreVisible = false;
            this.ribbonPanel10.Items.Add(this.ribbtnDSDonTTTL);
            this.ribbonPanel10.Text = "Thông Tin";
            // 
            // ribbtnDSDonTTTL
            // 
            this.ribbtnDSDonTTTL.Image = global::KTKS_DonKH.Properties.Resources.list_48x48;
            this.ribbtnDSDonTTTL.MinimumSize = new System.Drawing.Size(100, 0);
            this.ribbtnDSDonTTTL.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnDSDonTTTL.SmallImage")));
            this.ribbtnDSDonTTTL.Text = "Danh Sách Đơn";
            this.ribbtnDSDonTTTL.Click += new System.EventHandler(this.ribbtnDSDonTTTL_Click);
            // 
            // ribbonPanel13
            // 
            this.ribbonPanel13.ButtonMoreEnabled = false;
            this.ribbonPanel13.ButtonMoreVisible = false;
            this.ribbonPanel13.Items.Add(this.ribbtnTTTL);
            this.ribbonPanel13.Text = "Xử Lý";
            // 
            // ribbtnTTTL
            // 
            this.ribbtnTTTL.Image = global::KTKS_DonKH.Properties.Resources.letter_48x48;
            this.ribbtnTTTL.MinimumSize = new System.Drawing.Size(110, 0);
            this.ribbtnTTTL.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnTTTL.SmallImage")));
            this.ribbtnTTTL.Text = "Thảo Thư Trả Lời";
            this.ribbtnTTTL.Click += new System.EventHandler(this.ribbtnTTTL_Click);
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
            this.ribbon1.Size = new System.Drawing.Size(1140, 145);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.Tabs.Add(this.ribbonTab3);
            this.ribbon1.Tabs.Add(this.ribbonTab4);
            this.ribbon1.Tabs.Add(this.ribbonTab5);
            this.ribbon1.Tabs.Add(this.ribbonTab6);
            this.ribbon1.Tabs.Add(this.ribbonTab7);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 662);
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
        private System.Windows.Forms.ToolStripStatusLabel StripStatus_Version;
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
        private System.Windows.Forms.RibbonTab ribbonTab6;
        private System.Windows.Forms.RibbonPanel ribbonPanel8;
        private System.Windows.Forms.RibbonButton ribbtnDSDonCHDB;
        private System.Windows.Forms.RibbonPanel ribbonPanel9;
        private System.Windows.Forms.RibbonButton ribbtnBanGiamDoc;
        private System.Windows.Forms.ToolStripStatusLabel StripStatus_Form;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.RibbonTab ribbonTab7;
        private System.Windows.Forms.RibbonPanel ribbonPanel10;
        private System.Windows.Forms.RibbonButton ribbtnDSDonTTTL;
        private System.Windows.Forms.RibbonButton ribbtnNVKiemTra;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonButton ribbtnDCBD;
        private System.Windows.Forms.RibbonButton ribbtnDCHD;
        private System.Windows.Forms.RibbonPanel ribbonPanel11;
        private System.Windows.Forms.RibbonButton ribbtnNhapKetQua;
        private System.Windows.Forms.RibbonPanel ribbonPanel12;
        private System.Windows.Forms.RibbonButton ribbtnCTDB;
        private System.Windows.Forms.RibbonButton ribbtnCHDB;
        private System.Windows.Forms.RibbonPanel ribbonPanel13;
        private System.Windows.Forms.RibbonButton ribbtnTTTL;
        private System.Windows.Forms.RibbonPanel ribbonPanel14;
        private System.Windows.Forms.RibbonButton ribbtnNhanDonTXL;
        private System.Windows.Forms.RibbonButton ribbtnQLDonTXL;
    }
}

