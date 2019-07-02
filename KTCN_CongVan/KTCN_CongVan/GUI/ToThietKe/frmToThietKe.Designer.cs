namespace KTCN_CongVan.GUI.ToThietKe
{
    partial class frmToThietKe
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
            this.btnTimKiem_TTK = new System.Windows.Forms.Button();
            this.txtMaDot_TTK = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbLoaiHoSo_TTK = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.radTon = new System.Windows.Forms.RadioButton();
            this.radNgayChuyen = new System.Windows.Forms.RadioButton();
            this.radNgayLap = new System.Windows.Forms.RadioButton();
            this.btnXem_TTK = new System.Windows.Forms.Button();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvDSHoSo = new System.Windows.Forms.DataGridView();
            this.SoHoSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoSoCha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaoSDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLapBG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTraHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHoanCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoaiHoSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDotThiCong = new System.Windows.Forms.DataGridView();
            this.MaDot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaoSDV_DTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoanCong_DTC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHoSo)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDotThiCong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTimKiem_TTK
            // 
            this.btnTimKiem_TTK.Location = new System.Drawing.Point(775, 11);
            this.btnTimKiem_TTK.Name = "btnTimKiem_TTK";
            this.btnTimKiem_TTK.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem_TTK.TabIndex = 40;
            this.btnTimKiem_TTK.Text = "Tìm Kiếm";
            this.btnTimKiem_TTK.UseVisualStyleBackColor = true;
            this.btnTimKiem_TTK.Click += new System.EventHandler(this.btnTimKiem_TTK_Click);
            // 
            // txtMaDot_TTK
            // 
            this.txtMaDot_TTK.Location = new System.Drawing.Point(669, 12);
            this.txtMaDot_TTK.Name = "txtMaDot_TTK";
            this.txtMaDot_TTK.Size = new System.Drawing.Size(100, 20);
            this.txtMaDot_TTK.TabIndex = 39;
            this.txtMaDot_TTK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDot_TTK_KeyPress);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(639, 15);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(24, 13);
            this.label26.TabIndex = 38;
            this.label26.Text = "Đợt";
            // 
            // cmbLoaiHoSo_TTK
            // 
            this.cmbLoaiHoSo_TTK.FormattingEnabled = true;
            this.cmbLoaiHoSo_TTK.Items.AddRange(new object[] {
            "Tất Cả",
            "Gắn Mới",
            "Bít Hủy",
            "Dịch Vụ (Nâng, Dời, Hạ Cỡ,...)"});
            this.cmbLoaiHoSo_TTK.Location = new System.Drawing.Point(247, 38);
            this.cmbLoaiHoSo_TTK.Name = "cmbLoaiHoSo_TTK";
            this.cmbLoaiHoSo_TTK.Size = new System.Drawing.Size(121, 21);
            this.cmbLoaiHoSo_TTK.TabIndex = 37;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(181, 41);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 13);
            this.label25.TabIndex = 36;
            this.label25.Text = "Loại Hồ Sơ";
            // 
            // radTon
            // 
            this.radTon.AutoSize = true;
            this.radTon.Location = new System.Drawing.Point(107, 35);
            this.radTon.Name = "radTon";
            this.radTon.Size = new System.Drawing.Size(44, 17);
            this.radTon.TabIndex = 35;
            this.radTon.Text = "Tồn";
            this.radTon.UseVisualStyleBackColor = true;
            // 
            // radNgayChuyen
            // 
            this.radNgayChuyen.AutoSize = true;
            this.radNgayChuyen.Checked = true;
            this.radNgayChuyen.Location = new System.Drawing.Point(12, 35);
            this.radNgayChuyen.Name = "radNgayChuyen";
            this.radNgayChuyen.Size = new System.Drawing.Size(89, 17);
            this.radNgayChuyen.TabIndex = 34;
            this.radNgayChuyen.TabStop = true;
            this.radNgayChuyen.Text = "Ngày Chuyển";
            this.radNgayChuyen.UseVisualStyleBackColor = true;
            // 
            // radNgayLap
            // 
            this.radNgayLap.AutoSize = true;
            this.radNgayLap.Location = new System.Drawing.Point(12, 12);
            this.radNgayLap.Name = "radNgayLap";
            this.radNgayLap.Size = new System.Drawing.Size(71, 17);
            this.radNgayLap.TabIndex = 33;
            this.radNgayLap.Text = "Ngày Lập";
            this.radNgayLap.UseVisualStyleBackColor = true;
            this.radNgayLap.Visible = false;
            // 
            // btnXem_TTK
            // 
            this.btnXem_TTK.Location = new System.Drawing.Point(498, 10);
            this.btnXem_TTK.Name = "btnXem_TTK";
            this.btnXem_TTK.Size = new System.Drawing.Size(75, 23);
            this.btnXem_TTK.TabIndex = 32;
            this.btnXem_TTK.Text = "Xem";
            this.btnXem_TTK.UseVisualStyleBackColor = true;
            this.btnXem_TTK.Click += new System.EventHandler(this.btnXem_TTK_Click);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(397, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(95, 20);
            this.dateDen.TabIndex = 31;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(336, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 13);
            this.label24.TabIndex = 30;
            this.label24.Text = "Đến Ngày";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(235, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(95, 20);
            this.dateTu.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(181, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 13);
            this.label23.TabIndex = 28;
            this.label23.Text = "Từ Ngày";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvDSHoSo);
            this.groupBox4.Location = new System.Drawing.Point(400, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(905, 590);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh Sách Hồ Sơ";
            // 
            // dgvDSHoSo
            // 
            this.dgvDSHoSo.AllowUserToAddRows = false;
            this.dgvDSHoSo.AllowUserToDeleteRows = false;
            this.dgvDSHoSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHoSo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoHoSo,
            this.HoSoCha,
            this.HoTen,
            this.DiaChi,
            this.NgayNhan,
            this.Loai,
            this.NgayGiaoSDV,
            this.SoDoVien,
            this.NgayLapBG,
            this.NgayTraHS,
            this.NgayHoanCong,
            this.MaLoaiHoSo});
            this.dgvDSHoSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSHoSo.Location = new System.Drawing.Point(3, 16);
            this.dgvDSHoSo.Name = "dgvDSHoSo";
            this.dgvDSHoSo.Size = new System.Drawing.Size(899, 571);
            this.dgvDSHoSo.TabIndex = 6;
            this.dgvDSHoSo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSHoSo_RowPostPaint);
            this.dgvDSHoSo.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDSHoSo_RowPrePaint);
            // 
            // SoHoSo
            // 
            this.SoHoSo.DataPropertyName = "SoHoSo";
            this.SoHoSo.HeaderText = "Số Hồ Sơ";
            this.SoHoSo.Name = "SoHoSo";
            this.SoHoSo.Width = 70;
            // 
            // HoSoCha
            // 
            this.HoSoCha.DataPropertyName = "HoSoCha";
            this.HoSoCha.HeaderText = "Hồ Sơ Đại Diện";
            this.HoSoCha.Name = "HoSoCha";
            this.HoSoCha.Width = 80;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            // 
            // NgayNhan
            // 
            this.NgayNhan.DataPropertyName = "NgayNhan";
            this.NgayNhan.HeaderText = "Ngày Nhận";
            this.NgayNhan.Name = "NgayNhan";
            this.NgayNhan.Width = 70;
            // 
            // Loai
            // 
            this.Loai.DataPropertyName = "Loai";
            this.Loai.HeaderText = "Loại";
            this.Loai.Name = "Loai";
            this.Loai.Width = 70;
            // 
            // NgayGiaoSDV
            // 
            this.NgayGiaoSDV.DataPropertyName = "NgayGiaoSDV";
            this.NgayGiaoSDV.HeaderText = "Ngày Giao SĐV";
            this.NgayGiaoSDV.Name = "NgayGiaoSDV";
            this.NgayGiaoSDV.Width = 70;
            // 
            // SoDoVien
            // 
            this.SoDoVien.DataPropertyName = "SoDoVien";
            this.SoDoVien.HeaderText = "SĐV";
            this.SoDoVien.Name = "SoDoVien";
            this.SoDoVien.Width = 80;
            // 
            // NgayLapBG
            // 
            this.NgayLapBG.DataPropertyName = "NgayLapBG";
            this.NgayLapBG.HeaderText = "Ngày Lập Bảng Giá";
            this.NgayLapBG.Name = "NgayLapBG";
            this.NgayLapBG.Width = 75;
            // 
            // NgayTraHS
            // 
            this.NgayTraHS.DataPropertyName = "NgayTraHS";
            this.NgayTraHS.HeaderText = "Ngày Trả Hồ Sơ";
            this.NgayTraHS.Name = "NgayTraHS";
            this.NgayTraHS.Width = 70;
            // 
            // NgayHoanCong
            // 
            this.NgayHoanCong.DataPropertyName = "NgayHoanCong";
            this.NgayHoanCong.HeaderText = "Ngày Hoàn Công";
            this.NgayHoanCong.Name = "NgayHoanCong";
            this.NgayHoanCong.Width = 70;
            // 
            // MaLoaiHoSo
            // 
            this.MaLoaiHoSo.DataPropertyName = "MaLoaiHoSo";
            this.MaLoaiHoSo.HeaderText = "MaLoaiHoSo";
            this.MaLoaiHoSo.Name = "MaLoaiHoSo";
            this.MaLoaiHoSo.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDotThiCong);
            this.groupBox3.Location = new System.Drawing.Point(9, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 590);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Đợt Thi Công";
            // 
            // dgvDotThiCong
            // 
            this.dgvDotThiCong.AllowUserToAddRows = false;
            this.dgvDotThiCong.AllowUserToDeleteRows = false;
            this.dgvDotThiCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDotThiCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDot,
            this.MaLoai,
            this.TenLoai,
            this.NgayLap,
            this.NgayChuyen,
            this.NgayGiaoSDV_DTC,
            this.HoanCong_DTC});
            this.dgvDotThiCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDotThiCong.Location = new System.Drawing.Point(3, 16);
            this.dgvDotThiCong.Name = "dgvDotThiCong";
            this.dgvDotThiCong.Size = new System.Drawing.Size(374, 571);
            this.dgvDotThiCong.TabIndex = 6;
            this.dgvDotThiCong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDotThiCong_CellContentClick);
            this.dgvDotThiCong.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDotThiCong_RowPostPaint);
            this.dgvDotThiCong.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDotThiCong_RowPrePaint);
            // 
            // MaDot
            // 
            this.MaDot.DataPropertyName = "MaDot";
            this.MaDot.HeaderText = "Mã Đợt";
            this.MaDot.Name = "MaDot";
            this.MaDot.Width = 80;
            // 
            // MaLoai
            // 
            this.MaLoai.DataPropertyName = "MaLoai";
            this.MaLoai.HeaderText = "MaLoai";
            this.MaLoai.Name = "MaLoai";
            this.MaLoai.Visible = false;
            // 
            // TenLoai
            // 
            this.TenLoai.DataPropertyName = "TenLoai";
            this.TenLoai.HeaderText = "Tên Loại";
            this.TenLoai.Name = "TenLoai";
            // 
            // NgayLap
            // 
            this.NgayLap.DataPropertyName = "NgayLap";
            this.NgayLap.HeaderText = "Ngày Lập Đơn";
            this.NgayLap.Name = "NgayLap";
            this.NgayLap.Width = 70;
            // 
            // NgayChuyen
            // 
            this.NgayChuyen.DataPropertyName = "NgayChuyen";
            this.NgayChuyen.HeaderText = "Ngày Chuyển Đơn";
            this.NgayChuyen.Name = "NgayChuyen";
            this.NgayChuyen.Width = 80;
            // 
            // NgayGiaoSDV_DTC
            // 
            this.NgayGiaoSDV_DTC.DataPropertyName = "NgayGiaoSDV";
            this.NgayGiaoSDV_DTC.HeaderText = "NgayGiaoSDV";
            this.NgayGiaoSDV_DTC.Name = "NgayGiaoSDV_DTC";
            this.NgayGiaoSDV_DTC.Visible = false;
            // 
            // HoanCong_DTC
            // 
            this.HoanCong_DTC.DataPropertyName = "HoanCong";
            this.HoanCong_DTC.HeaderText = "HoanCong";
            this.HoanCong_DTC.Name = "HoanCong_DTC";
            this.HoanCong_DTC.Visible = false;
            // 
            // frmToThietKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 657);
            this.Controls.Add(this.btnTimKiem_TTK);
            this.Controls.Add(this.txtMaDot_TTK);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.cmbLoaiHoSo_TTK);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.radTon);
            this.Controls.Add(this.radNgayChuyen);
            this.Controls.Add(this.radNgayLap);
            this.Controls.Add(this.btnXem_TTK);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmToThietKe";
            this.Text = "Tổ Thiết Kế";
            this.Load += new System.EventHandler(this.frmToThietKe_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHoSo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDotThiCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTimKiem_TTK;
        private System.Windows.Forms.TextBox txtMaDot_TTK;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cmbLoaiHoSo_TTK;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.RadioButton radTon;
        private System.Windows.Forms.RadioButton radNgayChuyen;
        private System.Windows.Forms.RadioButton radNgayLap;
        private System.Windows.Forms.Button btnXem_TTK;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvDSHoSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoSoCha;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaoSDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLapBG;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTraHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHoanCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiHoSo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDotThiCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDot;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaoSDV_DTC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HoanCong_DTC;
    }
}