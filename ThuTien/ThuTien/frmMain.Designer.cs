namespace ThuTien
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
            this.mnuHanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StripStatus_Version = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatus_Form = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatus_HoTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuDangNganHD = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnuHanhThu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(630, 24);
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
            this.mnuGiaoHDTon});
            this.mnuToTruong.Name = "mnuToTruong";
            this.mnuToTruong.Size = new System.Drawing.Size(75, 20);
            this.mnuToTruong.Text = "Tổ Trưởng";
            // 
            // mnuGiaoHDHanhThu
            // 
            this.mnuGiaoHDHanhThu.Name = "mnuGiaoHDHanhThu";
            this.mnuGiaoHDHanhThu.Size = new System.Drawing.Size(204, 22);
            this.mnuGiaoHDHanhThu.Text = "Giao Hóa Đơn Hành Thu";
            this.mnuGiaoHDHanhThu.Click += new System.EventHandler(this.mnuGiaoHoaDonHanhThu_Click);
            // 
            // mnuGiaoHDTon
            // 
            this.mnuGiaoHDTon.Name = "mnuGiaoHDTon";
            this.mnuGiaoHDTon.Size = new System.Drawing.Size(204, 22);
            this.mnuGiaoHDTon.Text = "Giao Hóa Đơn Tồn";
            // 
            // mnuHanhThu
            // 
            this.mnuHanhThu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNganHD});
            this.mnuHanhThu.Name = "mnuHanhThu";
            this.mnuHanhThu.Size = new System.Drawing.Size(72, 20);
            this.mnuHanhThu.Text = "Hành Thu";
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
            this.statusStrip1.Size = new System.Drawing.Size(630, 22);
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
            this.StripStatus_Form.Size = new System.Drawing.Size(93, 15);
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
            // mnuDangNganHD
            // 
            this.mnuDangNganHD.Name = "mnuDangNganHD";
            this.mnuDangNganHD.Size = new System.Drawing.Size(184, 22);
            this.mnuDangNganHD.Text = "Đăng Ngân Hóa Đơn";
            this.mnuDangNganHD.Click += new System.EventHandler(this.mnuDangNganHD_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(630, 413);
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
        private System.Windows.Forms.ToolStripMenuItem mnuDangNganHD;
    }
}

