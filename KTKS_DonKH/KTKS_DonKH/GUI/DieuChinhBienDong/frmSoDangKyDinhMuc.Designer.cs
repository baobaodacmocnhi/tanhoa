﻿namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmSoDangKyDinhMuc
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaCT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.btnFileBilling = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLichSuChungTu = new System.Windows.Forms.DataGridView();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNKTong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNKDangKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuChungTu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã CT";
            // 
            // txtMaCT
            // 
            this.txtMaCT.Location = new System.Drawing.Point(117, 13);
            this.txtMaCT.Name = "txtMaCT";
            this.txtMaCT.Size = new System.Drawing.Size(114, 22);
            this.txtMaCT.TabIndex = 1;
            this.txtMaCT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaCT_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "(enter)";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(294, 11);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(86, 25);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Loai,
            this.MaLCT,
            this.TenLCT,
            this.MaCT,
            this.SoNKTong,
            this.DanhBo,
            this.SoNKDangKy,
            this.CreateDate,
            this.CreateBy});
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 41);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.Size = new System.Drawing.Size(880, 134);
            this.dgvDanhSach.TabIndex = 38;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            // 
            // btnFileBilling
            // 
            this.btnFileBilling.Location = new System.Drawing.Point(386, 11);
            this.btnFileBilling.Name = "btnFileBilling";
            this.btnFileBilling.Size = new System.Drawing.Size(130, 25);
            this.btnFileBilling.TabIndex = 39;
            this.btnFileBilling.Text = "Xuất CCCD Billing";
            this.btnFileBilling.UseVisualStyleBackColor = true;
            this.btnFileBilling.Click += new System.EventHandler(this.btnFileBilling_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(713, 11);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(86, 25);
            this.btnXoa.TabIndex = 40;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLichSuChungTu);
            this.groupBox1.Location = new System.Drawing.Point(12, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 313);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lịch Sử Chứng Từ";
            // 
            // dgvLichSuChungTu
            // 
            this.dgvLichSuChungTu.AllowUserToAddRows = false;
            this.dgvLichSuChungTu.AllowUserToDeleteRows = false;
            this.dgvLichSuChungTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuChungTu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.dataGridViewTextBoxColumn1});
            this.dgvLichSuChungTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSuChungTu.Location = new System.Drawing.Point(3, 18);
            this.dgvLichSuChungTu.Name = "dgvLichSuChungTu";
            this.dgvLichSuChungTu.Size = new System.Drawing.Size(661, 292);
            this.dgvLichSuChungTu.TabIndex = 39;
            this.dgvLichSuChungTu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLichSuChungTu_RowPostPaint);
            // 
            // Loai
            // 
            this.Loai.DataPropertyName = "Loai";
            this.Loai.HeaderText = "Loại";
            this.Loai.Name = "Loai";
            // 
            // MaLCT
            // 
            this.MaLCT.DataPropertyName = "MaLCT";
            this.MaLCT.HeaderText = "MaLCT";
            this.MaLCT.Name = "MaLCT";
            this.MaLCT.Visible = false;
            // 
            // TenLCT
            // 
            this.TenLCT.DataPropertyName = "TenLCT";
            this.TenLCT.HeaderText = "Loại Chứng Từ";
            this.TenLCT.Name = "TenLCT";
            this.TenLCT.Width = 120;
            // 
            // MaCT
            // 
            this.MaCT.DataPropertyName = "MaCT";
            this.MaCT.HeaderText = "Mã CT";
            this.MaCT.Name = "MaCT";
            // 
            // SoNKTong
            // 
            this.SoNKTong.DataPropertyName = "SoNKTong";
            this.SoNKTong.HeaderText = "Số NK Tổng";
            this.SoNKTong.Name = "SoNKTong";
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // SoNKDangKy
            // 
            this.SoNKDangKy.DataPropertyName = "SoNKDangKy";
            this.SoNKDangKy.HeaderText = "Số NK Đăng Ký";
            this.SoNKDangKy.Name = "SoNKDangKy";
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "Người Lập";
            this.CreateBy.Name = "CreateBy";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CreateDate";
            this.Column1.HeaderText = "Ngày Lập";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Loai";
            this.Column2.HeaderText = "Loại";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DanhBo";
            this.Column3.HeaderText = "Danh Bộ";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MaCT";
            this.Column4.HeaderText = "Mã CT";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SoNKDangKy";
            this.Column5.HeaderText = "Số NK Đăng Ký";
            this.Column5.Name = "Column5";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CreateBy";
            this.dataGridViewTextBoxColumn1.HeaderText = "Người Lập";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // frmSoDangKyDinhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(983, 506);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnFileBilling);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaCT);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "frmSoDangKyDinhMuc";
            this.Text = "Quản Lý Sổ Đăng Ký Định Mức";
            this.Load += new System.EventHandler(this.frmSoDangKyDinhMuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuChungTu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaCT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Button btnFileBilling;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLichSuChungTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNKTong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNKDangKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}