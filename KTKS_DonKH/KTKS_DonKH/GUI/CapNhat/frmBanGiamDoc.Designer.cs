﻿namespace KTKS_DonKH.GUI.CapNhat
{
    partial class frmBanGiamDoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dgvDSBanGiamDoc = new System.Windows.Forms.DataGridView();
            this.MaBGD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyTen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnSuaNguoiKy = new System.Windows.Forms.Button();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.CapNhat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dateTimKiem = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSBanGiamDoc)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chức Vụ:";
            // 
            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(160, 11);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(150, 21);
            this.txtChucVu.TabIndex = 1;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(160, 38);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(150, 21);
            this.txtHoTen.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ Tên:";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(180, 65);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(66, 31);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(253, 65);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(57, 31);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dgvDSBanGiamDoc
            // 
            this.dgvDSBanGiamDoc.AllowUserToAddRows = false;
            this.dgvDSBanGiamDoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSBanGiamDoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSBanGiamDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSBanGiamDoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaBGD,
            this.ChucVu,
            this.HoTen,
            this.KyTen});
            this.dgvDSBanGiamDoc.Location = new System.Drawing.Point(10, 101);
            this.dgvDSBanGiamDoc.Name = "dgvDSBanGiamDoc";
            this.dgvDSBanGiamDoc.Size = new System.Drawing.Size(397, 132);
            this.dgvDSBanGiamDoc.TabIndex = 6;
            this.dgvDSBanGiamDoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSBanGiamDoc_CellContentClick);
            this.dgvDSBanGiamDoc.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSBanGiamDoc_CellEndEdit);
            this.dgvDSBanGiamDoc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSBanGiamDoc_RowPostPaint);
            // 
            // MaBGD
            // 
            this.MaBGD.DataPropertyName = "MaBGD";
            this.MaBGD.HeaderText = "MaBGD";
            this.MaBGD.Name = "MaBGD";
            this.MaBGD.Visible = false;
            // 
            // ChucVu
            // 
            this.ChucVu.DataPropertyName = "ChucVu";
            this.ChucVu.HeaderText = "Chức Vụ";
            this.ChucVu.Name = "ChucVu";
            this.ChucVu.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 200;
            // 
            // KyTen
            // 
            this.KyTen.DataPropertyName = "KyTen";
            this.KyTen.HeaderText = "Ký Tên Phiếu";
            this.KyTen.Name = "KyTen";
            this.KyTen.Width = 110;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNoiDung);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chkSelectAll);
            this.groupBox1.Controls.Add(this.btnSuaNguoiKy);
            this.groupBox1.Controls.Add(this.cmbTimTheo);
            this.groupBox1.Controls.Add(this.dgvDanhSach);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.dateTimKiem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbLoai);
            this.groupBox1.Location = new System.Drawing.Point(420, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 415);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cập Nhật Người Ký";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(442, 24);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(85, 21);
            this.txtNoiDung.TabIndex = 17;
            this.txtNoiDung.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tìm Theo:";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.ForeColor = System.Drawing.Color.Red;
            this.chkSelectAll.Location = new System.Drawing.Point(8, 26);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(106, 19);
            this.chkSelectAll.TabIndex = 14;
            this.chkSelectAll.Text = "Chọn In Tất Cả";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnSuaNguoiKy
            // 
            this.btnSuaNguoiKy.Location = new System.Drawing.Point(527, 378);
            this.btnSuaNguoiKy.Name = "btnSuaNguoiKy";
            this.btnSuaNguoiKy.Size = new System.Drawing.Size(57, 31);
            this.btnSuaNguoiKy.TabIndex = 8;
            this.btnSuaNguoiKy.Text = "Sửa";
            this.btnSuaNguoiKy.UseVisualStyleBackColor = true;
            this.btnSuaNguoiKy.Click += new System.EventHandler(this.btnSuaNguoiKy_Click);
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "Mã",
            "Ngày"});
            this.cmbTimTheo.Location = new System.Drawing.Point(393, 24);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(44, 23);
            this.cmbTimTheo.TabIndex = 15;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CapNhat,
            this.Ma,
            this.DanhBo,
            this.KhachHang,
            this.NguoiKy});
            this.dgvDanhSach.Location = new System.Drawing.Point(8, 55);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.Size = new System.Drawing.Size(576, 318);
            this.dgvDanhSach.TabIndex = 8;
            this.dgvDanhSach.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDanhSach_CellFormatting);
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            // 
            // CapNhat
            // 
            this.CapNhat.DataPropertyName = "In";
            this.CapNhat.HeaderText = "Cập Nhật";
            this.CapNhat.Name = "CapNhat";
            this.CapNhat.Width = 80;
            // 
            // Ma
            // 
            this.Ma.DataPropertyName = "Ma";
            this.Ma.HeaderText = "Mã Số";
            this.Ma.Name = "Ma";
            this.Ma.ReadOnly = true;
            this.Ma.Width = 80;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // KhachHang
            // 
            this.KhachHang.DataPropertyName = "HoTen";
            this.KhachHang.HeaderText = "Khách Hàng";
            this.KhachHang.Name = "KhachHang";
            this.KhachHang.ReadOnly = true;
            this.KhachHang.Width = 200;
            // 
            // NguoiKy
            // 
            this.NguoiKy.DataPropertyName = "NguoiKy";
            this.NguoiKy.HeaderText = "Người Ký";
            this.NguoiKy.Name = "NguoiKy";
            this.NguoiKy.Width = 140;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(532, 19);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(88, 31);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dateTimKiem
            // 
            this.dateTimKiem.CustomFormat = "dd/MM/yyyy";
            this.dateTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimKiem.Location = new System.Drawing.Point(442, 24);
            this.dateTimKiem.Name = "dateTimKiem";
            this.dateTimKiem.Size = new System.Drawing.Size(85, 21);
            this.dateTimKiem.TabIndex = 3;
            this.dateTimKiem.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Loại:";
            // 
            // cmbLoai
            // 
            this.cmbLoai.FormattingEnabled = true;
            this.cmbLoai.Items.AddRange(new object[] {
            "Điều Chỉnh Biến Động",
            "Điều Chỉnh Hóa Đơn",
            "Cắt Chuyển",
            "Cắt Tạm Danh Bộ",
            "Cắt Hủy Danh Bộ",
            "Yêu Cầu Cắt Hủy Danh Bộ",
            "Đóng Nước",
            "Mở Nước",
            "Thảo Thư Trả Lời"});
            this.cmbLoai.Location = new System.Drawing.Point(155, 22);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(168, 23);
            this.cmbLoai.TabIndex = 0;
            this.cmbLoai.SelectedIndexChanged += new System.EventHandler(this.cmbLoai_SelectedIndexChanged);
            // 
            // frmBanGiamDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1158, 436);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDSBanGiamDoc);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtChucVu);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBanGiamDoc";
            this.Text = "Ban Giám Đốc";
            this.Load += new System.EventHandler(this.frmBanGiamDoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSBanGiamDoc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dgvDSBanGiamDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBGD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn KyTen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLoai;
        private System.Windows.Forms.DateTimePicker dateTimKiem;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnSuaNguoiKy;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CapNhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiKy;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTimTheo;
    }
}