namespace KTCN_CongVan.GUI.CongVan
{
    partial class frmCongVanDi
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
            this.txtNoiNhan_Di = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkHetHan_Di = new System.Windows.Forms.CheckBox();
            this.btnSua_Di = new System.Windows.Forms.Button();
            this.btnXoa_Di = new System.Windows.Forms.Button();
            this.btnThem_Di = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTimTheo_Di = new System.Windows.Forms.ComboBox();
            this.dgvCongVan_Di = new System.Windows.Forms.DataGridView();
            this.ID_Di = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoCongVan_Di = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhan_Di = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung_Di = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiNhan_Di = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu_Di = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHetHan_Di = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXem_Di = new System.Windows.Forms.Button();
            this.panel_NoiDung_Di = new System.Windows.Forms.Panel();
            this.txtNoiDungTimKiem_Di = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel_ThoiGian_Di = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.dateTu_Di = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.dateDen_Di = new System.Windows.Forms.DateTimePicker();
            this.dateNgayHetHan_Di = new System.Windows.Forms.DateTimePicker();
            this.txtGhiChu_Di = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkBanChinh_Di = new System.Windows.Forms.CheckBox();
            this.txtLoaiCongVan_Di = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoiDung_Di = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCongVanCongTy_Di = new System.Windows.Forms.CheckBox();
            this.dateNgayNhan_Di = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoCongVan_Di = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan_Di)).BeginInit();
            this.panel_NoiDung_Di.SuspendLayout();
            this.panel_ThoiGian_Di.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNoiNhan_Di
            // 
            this.txtNoiNhan_Di.Location = new System.Drawing.Point(87, 90);
            this.txtNoiNhan_Di.Name = "txtNoiNhan_Di";
            this.txtNoiNhan_Di.Size = new System.Drawing.Size(393, 20);
            this.txtNoiNhan_Di.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Nơi Nhận:";
            // 
            // chkHetHan_Di
            // 
            this.chkHetHan_Di.AutoSize = true;
            this.chkHetHan_Di.Location = new System.Drawing.Point(87, 142);
            this.chkHetHan_Di.Name = "chkHetHan_Di";
            this.chkHetHan_Di.Size = new System.Drawing.Size(97, 17);
            this.chkHetHan_Di.TabIndex = 34;
            this.chkHetHan_Di.Text = "Ngày Hết Hạn:";
            this.chkHetHan_Di.UseVisualStyleBackColor = true;
            this.chkHetHan_Di.CheckedChanged += new System.EventHandler(this.chkHetHan_Di_CheckedChanged);
            // 
            // btnSua_Di
            // 
            this.btnSua_Di.Location = new System.Drawing.Point(486, 119);
            this.btnSua_Di.Name = "btnSua_Di";
            this.btnSua_Di.Size = new System.Drawing.Size(75, 23);
            this.btnSua_Di.TabIndex = 38;
            this.btnSua_Di.Text = "Sửa";
            this.btnSua_Di.UseVisualStyleBackColor = true;
            this.btnSua_Di.Click += new System.EventHandler(this.btnSua_Di_Click);
            // 
            // btnXoa_Di
            // 
            this.btnXoa_Di.Location = new System.Drawing.Point(486, 90);
            this.btnXoa_Di.Name = "btnXoa_Di";
            this.btnXoa_Di.Size = new System.Drawing.Size(75, 23);
            this.btnXoa_Di.TabIndex = 37;
            this.btnXoa_Di.Text = "Xóa";
            this.btnXoa_Di.UseVisualStyleBackColor = true;
            this.btnXoa_Di.Click += new System.EventHandler(this.btnXoa_Di_Click);
            // 
            // btnThem_Di
            // 
            this.btnThem_Di.Location = new System.Drawing.Point(486, 61);
            this.btnThem_Di.Name = "btnThem_Di";
            this.btnThem_Di.Size = new System.Drawing.Size(75, 23);
            this.btnThem_Di.TabIndex = 36;
            this.btnThem_Di.Text = "Thêm";
            this.btnThem_Di.UseVisualStyleBackColor = true;
            this.btnThem_Di.Click += new System.EventHandler(this.btnThem_Di_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbTimTheo_Di);
            this.groupBox1.Controls.Add(this.dgvCongVan_Di);
            this.groupBox1.Controls.Add(this.btnXem_Di);
            this.groupBox1.Controls.Add(this.panel_NoiDung_Di);
            this.groupBox1.Controls.Add(this.panel_ThoiGian_Di);
            this.groupBox1.Location = new System.Drawing.Point(6, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1070, 411);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(86, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tìm Theo:";
            // 
            // cmbTimTheo_Di
            // 
            this.cmbTimTheo_Di.FormattingEnabled = true;
            this.cmbTimTheo_Di.Items.AddRange(new object[] {
            "Số Công Văn",
            "Nội Dung",
            "Nơi Nhận",
            "Ngày Nhận",
            "Ngày Hết Hạn"});
            this.cmbTimTheo_Di.Location = new System.Drawing.Point(147, 19);
            this.cmbTimTheo_Di.Name = "cmbTimTheo_Di";
            this.cmbTimTheo_Di.Size = new System.Drawing.Size(121, 21);
            this.cmbTimTheo_Di.TabIndex = 1;
            this.cmbTimTheo_Di.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_Di_SelectedIndexChanged);
            // 
            // dgvCongVan_Di
            // 
            this.dgvCongVan_Di.AllowUserToAddRows = false;
            this.dgvCongVan_Di.AllowUserToDeleteRows = false;
            this.dgvCongVan_Di.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongVan_Di.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Di,
            this.SoCongVan_Di,
            this.NgayNhan_Di,
            this.NoiDung_Di,
            this.NoiNhan_Di,
            this.GhiChu_Di,
            this.NgayHetHan_Di});
            this.dgvCongVan_Di.Location = new System.Drawing.Point(6, 49);
            this.dgvCongVan_Di.Name = "dgvCongVan_Di";
            this.dgvCongVan_Di.Size = new System.Drawing.Size(1058, 356);
            this.dgvCongVan_Di.TabIndex = 5;
            this.dgvCongVan_Di.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCongVan_Di_CellContentClick);
            // 
            // ID_Di
            // 
            this.ID_Di.DataPropertyName = "ID";
            this.ID_Di.HeaderText = "ID";
            this.ID_Di.Name = "ID_Di";
            this.ID_Di.Visible = false;
            // 
            // SoCongVan_Di
            // 
            this.SoCongVan_Di.DataPropertyName = "SoCongVan";
            this.SoCongVan_Di.HeaderText = "Số Công Văn";
            this.SoCongVan_Di.Name = "SoCongVan_Di";
            // 
            // NgayNhan_Di
            // 
            this.NgayNhan_Di.DataPropertyName = "NgayNhan";
            this.NgayNhan_Di.HeaderText = "Ngày Nhận";
            this.NgayNhan_Di.Name = "NgayNhan_Di";
            // 
            // NoiDung_Di
            // 
            this.NoiDung_Di.DataPropertyName = "NoiDung";
            this.NoiDung_Di.HeaderText = "Nội Dung";
            this.NoiDung_Di.Name = "NoiDung_Di";
            this.NoiDung_Di.Width = 300;
            // 
            // NoiNhan_Di
            // 
            this.NoiNhan_Di.DataPropertyName = "NoiNhan";
            this.NoiNhan_Di.HeaderText = "Nơi Nhận";
            this.NoiNhan_Di.Name = "NoiNhan_Di";
            this.NoiNhan_Di.Width = 200;
            // 
            // GhiChu_Di
            // 
            this.GhiChu_Di.DataPropertyName = "GhiChu";
            this.GhiChu_Di.HeaderText = "Ghi Chú";
            this.GhiChu_Di.Name = "GhiChu_Di";
            this.GhiChu_Di.Width = 200;
            // 
            // NgayHetHan_Di
            // 
            this.NgayHetHan_Di.DataPropertyName = "NgayHetHan";
            this.NgayHetHan_Di.HeaderText = "Ngày Hết Hạn";
            this.NgayHetHan_Di.Name = "NgayHetHan_Di";
            // 
            // btnXem_Di
            // 
            this.btnXem_Di.Location = new System.Drawing.Point(606, 17);
            this.btnXem_Di.Name = "btnXem_Di";
            this.btnXem_Di.Size = new System.Drawing.Size(75, 23);
            this.btnXem_Di.TabIndex = 4;
            this.btnXem_Di.Text = "Xem";
            this.btnXem_Di.UseVisualStyleBackColor = true;
            this.btnXem_Di.Click += new System.EventHandler(this.btnXem_Di_Click);
            // 
            // panel_NoiDung_Di
            // 
            this.panel_NoiDung_Di.Controls.Add(this.txtNoiDungTimKiem_Di);
            this.panel_NoiDung_Di.Controls.Add(this.label7);
            this.panel_NoiDung_Di.Location = new System.Drawing.Point(274, 17);
            this.panel_NoiDung_Di.Name = "panel_NoiDung_Di";
            this.panel_NoiDung_Di.Size = new System.Drawing.Size(168, 26);
            this.panel_NoiDung_Di.TabIndex = 2;
            this.panel_NoiDung_Di.Visible = false;
            // 
            // txtNoiDungTimKiem_Di
            // 
            this.txtNoiDungTimKiem_Di.Location = new System.Drawing.Point(64, 3);
            this.txtNoiDungTimKiem_Di.Name = "txtNoiDungTimKiem_Di";
            this.txtNoiDungTimKiem_Di.Size = new System.Drawing.Size(100, 20);
            this.txtNoiDungTimKiem_Di.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Nội Dung:";
            // 
            // panel_ThoiGian_Di
            // 
            this.panel_ThoiGian_Di.Controls.Add(this.label20);
            this.panel_ThoiGian_Di.Controls.Add(this.dateTu_Di);
            this.panel_ThoiGian_Di.Controls.Add(this.label21);
            this.panel_ThoiGian_Di.Controls.Add(this.dateDen_Di);
            this.panel_ThoiGian_Di.Location = new System.Drawing.Point(275, 17);
            this.panel_ThoiGian_Di.Name = "panel_ThoiGian_Di";
            this.panel_ThoiGian_Di.Size = new System.Drawing.Size(324, 26);
            this.panel_ThoiGian_Di.TabIndex = 3;
            this.panel_ThoiGian_Di.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Từ Ngày:";
            // 
            // dateTu_Di
            // 
            this.dateTu_Di.CustomFormat = "dd/MM/yyyy";
            this.dateTu_Di.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_Di.Location = new System.Drawing.Point(60, 3);
            this.dateTu_Di.Name = "dateTu_Di";
            this.dateTu_Di.Size = new System.Drawing.Size(95, 20);
            this.dateTu_Di.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(161, 6);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Đến Ngày:";
            // 
            // dateDen_Di
            // 
            this.dateDen_Di.CustomFormat = "dd/MM/yyyy";
            this.dateDen_Di.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_Di.Location = new System.Drawing.Point(225, 3);
            this.dateDen_Di.Name = "dateDen_Di";
            this.dateDen_Di.Size = new System.Drawing.Size(95, 20);
            this.dateDen_Di.TabIndex = 3;
            // 
            // dateNgayHetHan_Di
            // 
            this.dateNgayHetHan_Di.CustomFormat = "dd/MM/yyyy";
            this.dateNgayHetHan_Di.Enabled = false;
            this.dateNgayHetHan_Di.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayHetHan_Di.Location = new System.Drawing.Point(190, 142);
            this.dateNgayHetHan_Di.Name = "dateNgayHetHan_Di";
            this.dateNgayHetHan_Di.Size = new System.Drawing.Size(95, 20);
            this.dateNgayHetHan_Di.TabIndex = 35;
            // 
            // txtGhiChu_Di
            // 
            this.txtGhiChu_Di.Location = new System.Drawing.Point(87, 116);
            this.txtGhiChu_Di.Name = "txtGhiChu_Di";
            this.txtGhiChu_Di.Size = new System.Drawing.Size(393, 20);
            this.txtGhiChu_Di.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Ghi Chú:";
            // 
            // chkBanChinh_Di
            // 
            this.chkBanChinh_Di.AutoSize = true;
            this.chkBanChinh_Di.Location = new System.Drawing.Point(196, 40);
            this.chkBanChinh_Di.Name = "chkBanChinh_Di";
            this.chkBanChinh_Di.Size = new System.Drawing.Size(127, 17);
            this.chkBanChinh_Di.TabIndex = 27;
            this.chkBanChinh_Di.Text = "Công Văn Bản Chính";
            this.chkBanChinh_Di.UseVisualStyleBackColor = true;
            // 
            // txtLoaiCongVan_Di
            // 
            this.txtLoaiCongVan_Di.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtLoaiCongVan_Di.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLoaiCongVan_Di.Location = new System.Drawing.Point(87, 38);
            this.txtLoaiCongVan_Di.Name = "txtLoaiCongVan_Di";
            this.txtLoaiCongVan_Di.Size = new System.Drawing.Size(100, 20);
            this.txtLoaiCongVan_Di.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Loại Công Văn:";
            // 
            // txtNoiDung_Di
            // 
            this.txtNoiDung_Di.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNoiDung_Di.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNoiDung_Di.Location = new System.Drawing.Point(87, 64);
            this.txtNoiDung_Di.Name = "txtNoiDung_Di";
            this.txtNoiDung_Di.Size = new System.Drawing.Size(393, 20);
            this.txtNoiDung_Di.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Nội Dung:";
            // 
            // chkCongVanCongTy_Di
            // 
            this.chkCongVanCongTy_Di.AutoSize = true;
            this.chkCongVanCongTy_Di.Location = new System.Drawing.Point(364, 11);
            this.chkCongVanCongTy_Di.Name = "chkCongVanCongTy_Di";
            this.chkCongVanCongTy_Di.Size = new System.Drawing.Size(116, 17);
            this.chkCongVanCongTy_Di.TabIndex = 24;
            this.chkCongVanCongTy_Di.Text = "Công Văn Công Ty";
            this.chkCongVanCongTy_Di.UseVisualStyleBackColor = true;
            // 
            // dateNgayNhan_Di
            // 
            this.dateNgayNhan_Di.CustomFormat = "dd/MM/yyyy";
            this.dateNgayNhan_Di.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayNhan_Di.Location = new System.Drawing.Point(263, 12);
            this.dateNgayNhan_Di.Name = "dateNgayNhan_Di";
            this.dateNgayNhan_Di.Size = new System.Drawing.Size(95, 20);
            this.dateNgayNhan_Di.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ngày Nhận:";
            // 
            // txtSoCongVan_Di
            // 
            this.txtSoCongVan_Di.Location = new System.Drawing.Point(87, 12);
            this.txtSoCongVan_Di.Name = "txtSoCongVan_Di";
            this.txtSoCongVan_Di.Size = new System.Drawing.Size(100, 20);
            this.txtSoCongVan_Di.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Số Công Văn:";
            // 
            // frmCongVanDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 594);
            this.Controls.Add(this.txtNoiNhan_Di);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkHetHan_Di);
            this.Controls.Add(this.btnSua_Di);
            this.Controls.Add(this.btnXoa_Di);
            this.Controls.Add(this.btnThem_Di);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateNgayHetHan_Di);
            this.Controls.Add(this.txtGhiChu_Di);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkBanChinh_Di);
            this.Controls.Add(this.txtLoaiCongVan_Di);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNoiDung_Di);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkCongVanCongTy_Di);
            this.Controls.Add(this.dateNgayNhan_Di);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoCongVan_Di);
            this.Controls.Add(this.label1);
            this.Name = "frmCongVanDi";
            this.Text = "Công Văn Đi";
            this.Load += new System.EventHandler(this.frmCongVanDi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongVan_Di)).EndInit();
            this.panel_NoiDung_Di.ResumeLayout(false);
            this.panel_NoiDung_Di.PerformLayout();
            this.panel_ThoiGian_Di.ResumeLayout(false);
            this.panel_ThoiGian_Di.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoiNhan_Di;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkHetHan_Di;
        private System.Windows.Forms.Button btnSua_Di;
        private System.Windows.Forms.Button btnXoa_Di;
        private System.Windows.Forms.Button btnThem_Di;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTimTheo_Di;
        private System.Windows.Forms.DataGridView dgvCongVan_Di;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Di;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoCongVan_Di;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhan_Di;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung_Di;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiNhan_Di;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu_Di;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHetHan_Di;
        private System.Windows.Forms.Button btnXem_Di;
        private System.Windows.Forms.Panel panel_NoiDung_Di;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem_Di;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel_ThoiGian_Di;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dateTu_Di;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dateDen_Di;
        private System.Windows.Forms.DateTimePicker dateNgayHetHan_Di;
        private System.Windows.Forms.TextBox txtGhiChu_Di;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkBanChinh_Di;
        private System.Windows.Forms.TextBox txtLoaiCongVan_Di;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoiDung_Di;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkCongVanCongTy_Di;
        private System.Windows.Forms.DateTimePicker dateNgayNhan_Di;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoCongVan_Di;
        private System.Windows.Forms.Label label1;
    }
}