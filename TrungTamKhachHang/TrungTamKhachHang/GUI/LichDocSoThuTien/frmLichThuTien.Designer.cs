﻿namespace TrungTamKhachHang.GUI.LichDocSoThuTien
{
    partial class frmLichThuTien
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDot = new System.Windows.Forms.DataGridView();
            this.IDThuTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDDot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayChuyenListing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThuTien_From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThuTien_To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvKy = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.txtKy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.btnSua = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDot)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKy)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDot);
            this.groupBox3.Location = new System.Drawing.Point(286, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(419, 521);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi Tiết 20 Đợt Trong Kỳ";
            // 
            // dgvDot
            // 
            this.dgvDot.AllowUserToAddRows = false;
            this.dgvDot.AllowUserToDeleteRows = false;
            this.dgvDot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDThuTien,
            this.IDDot,
            this.NgayChuyenListing,
            this.NgayThuTien_From,
            this.NgayThuTien_To});
            this.dgvDot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDot.Location = new System.Drawing.Point(3, 16);
            this.dgvDot.Name = "dgvDot";
            this.dgvDot.Size = new System.Drawing.Size(413, 502);
            this.dgvDot.TabIndex = 1;
            this.dgvDot.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDot_CellClick);
            this.dgvDot.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvDot_ColumnWidthChanged);
            this.dgvDot.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvDot_Scroll);
            // 
            // IDThuTien
            // 
            this.IDThuTien.DataPropertyName = "IDThuTien";
            this.IDThuTien.HeaderText = "IDThuTien";
            this.IDThuTien.Name = "IDThuTien";
            this.IDThuTien.Visible = false;
            // 
            // IDDot
            // 
            this.IDDot.DataPropertyName = "IDDot";
            this.IDDot.HeaderText = "Đợt";
            this.IDDot.Name = "IDDot";
            this.IDDot.Width = 50;
            // 
            // NgayChuyenListing
            // 
            this.NgayChuyenListing.DataPropertyName = "NgayChuyenListing";
            this.NgayChuyenListing.HeaderText = "Ngày Chuyển Listing";
            this.NgayChuyenListing.Name = "NgayChuyenListing";
            // 
            // NgayThuTien_From
            // 
            this.NgayThuTien_From.DataPropertyName = "NgayThuTien_From";
            this.NgayThuTien_From.HeaderText = "Từ Ngày Thu Tiền";
            this.NgayThuTien_From.Name = "NgayThuTien_From";
            // 
            // NgayThuTien_To
            // 
            this.NgayThuTien_To.DataPropertyName = "NgayThuTien_To";
            this.NgayThuTien_To.HeaderText = "Đến Ngày Thu Tiền";
            this.NgayThuTien_To.Name = "NgayThuTien_To";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvKy);
            this.groupBox2.Location = new System.Drawing.Point(12, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 385);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Kỳ";
            // 
            // dgvKy
            // 
            this.dgvKy.AllowUserToAddRows = false;
            this.dgvKy.AllowUserToDeleteRows = false;
            this.dgvKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Ky,
            this.Nam,
            this.CreateDate});
            this.dgvKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKy.Location = new System.Drawing.Point(3, 16);
            this.dgvKy.Name = "dgvKy";
            this.dgvKy.Size = new System.Drawing.Size(262, 366);
            this.dgvKy.TabIndex = 0;
            this.dgvKy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKy_CellContentClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.Width = 50;
            // 
            // Nam
            // 
            this.Nam.DataPropertyName = "Nam";
            this.Nam.HeaderText = "Năm";
            this.Nam.Name = "Nam";
            this.Nam.Width = 50;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIn);
            this.groupBox1.Controls.Add(this.txtNam);
            this.groupBox1.Controls.Add(this.txtKy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTu);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.dateDen);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 130);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tạo Kỳ Mới";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(75, 47);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(100, 20);
            this.txtNam.TabIndex = 12;
            // 
            // txtKy
            // 
            this.txtKy.Location = new System.Drawing.Point(75, 22);
            this.txtKy.Name = "txtKy";
            this.txtKy.Size = new System.Drawing.Size(100, 20);
            this.txtKy.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ Ngày";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(75, 73);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 1;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(181, 69);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến Ngày";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(181, 40);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(75, 99);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 3;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(181, 11);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kỳ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Năm";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(181, 98);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 14;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmLichThuTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 548);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLichThuTien";
            this.Text = "Lịch Thu Tiền";
            this.Load += new System.EventHandler(this.frmLichThuTien_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDot)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKy)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDot;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.TextBox txtKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDThuTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDot;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChuyenListing;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThuTien_From;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThuTien_To;
        private System.Windows.Forms.Button btnIn;
    }
}