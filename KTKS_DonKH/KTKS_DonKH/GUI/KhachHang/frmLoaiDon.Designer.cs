﻿namespace KTKS_DonKH.GUI.KhachHang
{
    partial class frmLoaiDon
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
            this.txtKyHieuLD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenLD = new System.Windows.Forms.TextBox();
            this.dgvDSLoaiDon = new System.Windows.Forms.DataGridView();
            this.MaLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyHieuLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDownTXL = new System.Windows.Forms.Button();
            this.btnUpTXL = new System.Windows.Forms.Button();
            this.btnXoaTXL = new System.Windows.Forms.Button();
            this.txtKyHieuLDTXL = new System.Windows.Forms.TextBox();
            this.btnSuaTXL = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThemTXL = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDSLoaiDonTXL = new System.Windows.Forms.DataGridView();
            this.MaLDTXL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyHieuLDTXL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLDTXL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTenLDTXL = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSLoaiDon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSLoaiDonTXL)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ký Hiệu Loại Đơn:";
            // 
            // txtKyHieuLD
            // 
            this.txtKyHieuLD.Location = new System.Drawing.Point(169, 23);
            this.txtKyHieuLD.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtKyHieuLD.Name = "txtKyHieuLD";
            this.txtKyHieuLD.Size = new System.Drawing.Size(165, 22);
            this.txtKyHieuLD.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Loại Đơn:";
            // 
            // txtTenLD
            // 
            this.txtTenLD.Location = new System.Drawing.Point(169, 55);
            this.txtTenLD.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTenLD.Name = "txtTenLD";
            this.txtTenLD.Size = new System.Drawing.Size(165, 22);
            this.txtTenLD.TabIndex = 3;
            // 
            // dgvDSLoaiDon
            // 
            this.dgvDSLoaiDon.AllowUserToAddRows = false;
            this.dgvDSLoaiDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSLoaiDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSLoaiDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSLoaiDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLD,
            this.KyHieuLD,
            this.TenLD});
            this.dgvDSLoaiDon.Location = new System.Drawing.Point(7, 129);
            this.dgvDSLoaiDon.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvDSLoaiDon.MultiSelect = false;
            this.dgvDSLoaiDon.Name = "dgvDSLoaiDon";
            this.dgvDSLoaiDon.ReadOnly = true;
            this.dgvDSLoaiDon.Size = new System.Drawing.Size(418, 384);
            this.dgvDSLoaiDon.TabIndex = 6;
            this.dgvDSLoaiDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSLoaiDon_CellContentClick);
            this.dgvDSLoaiDon.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSLoaiDon_RowPostPaint);
            // 
            // MaLD
            // 
            this.MaLD.DataPropertyName = "MaLD";
            this.MaLD.HeaderText = "MaLD";
            this.MaLD.Name = "MaLD";
            this.MaLD.ReadOnly = true;
            this.MaLD.Visible = false;
            // 
            // KyHieuLD
            // 
            this.KyHieuLD.DataPropertyName = "KyHieuLD";
            this.KyHieuLD.HeaderText = "Ký Hiệu Loại Đơn";
            this.KyHieuLD.Name = "KyHieuLD";
            this.KyHieuLD.ReadOnly = true;
            this.KyHieuLD.Width = 150;
            // 
            // TenLD
            // 
            this.TenLD.DataPropertyName = "TenLD";
            this.TenLD.HeaderText = "Tên Loại Đơn";
            this.TenLD.Name = "TenLD";
            this.TenLD.ReadOnly = true;
            this.TenLD.Width = 200;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(256, 87);
            this.btnSua.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(66, 33);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(169, 87);
            this.btnThem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(77, 33);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDown);
            this.groupBox1.Controls.Add(this.btnUp);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.txtKyHieuLD);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvDSLoaiDon);
            this.groupBox1.Controls.Add(this.txtTenLD);
            this.groupBox1.Location = new System.Drawing.Point(43, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 519);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổ Khách Hàng";
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(86, 87);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 33);
            this.btnDown.TabIndex = 91;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(24, 87);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(56, 33);
            this.btnUp.TabIndex = 90;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(336, 87);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(67, 33);
            this.btnXoa.TabIndex = 86;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Visible = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDownTXL);
            this.groupBox2.Controls.Add(this.btnUpTXL);
            this.groupBox2.Controls.Add(this.btnXoaTXL);
            this.groupBox2.Controls.Add(this.txtKyHieuLDTXL);
            this.groupBox2.Controls.Add(this.btnSuaTXL);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnThemTXL);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dgvDSLoaiDonTXL);
            this.groupBox2.Controls.Add(this.txtTenLDTXL);
            this.groupBox2.Location = new System.Drawing.Point(501, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 519);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tổ Xử Lý";
            // 
            // btnDownTXL
            // 
            this.btnDownTXL.Location = new System.Drawing.Point(86, 87);
            this.btnDownTXL.Name = "btnDownTXL";
            this.btnDownTXL.Size = new System.Drawing.Size(75, 33);
            this.btnDownTXL.TabIndex = 91;
            this.btnDownTXL.Text = "Down";
            this.btnDownTXL.UseVisualStyleBackColor = true;
            this.btnDownTXL.Click += new System.EventHandler(this.btnDownTXL_Click);
            // 
            // btnUpTXL
            // 
            this.btnUpTXL.Location = new System.Drawing.Point(24, 87);
            this.btnUpTXL.Name = "btnUpTXL";
            this.btnUpTXL.Size = new System.Drawing.Size(56, 33);
            this.btnUpTXL.TabIndex = 90;
            this.btnUpTXL.Text = "Up";
            this.btnUpTXL.UseVisualStyleBackColor = true;
            this.btnUpTXL.Click += new System.EventHandler(this.btnUpTXL_Click);
            // 
            // btnXoaTXL
            // 
            this.btnXoaTXL.Location = new System.Drawing.Point(336, 87);
            this.btnXoaTXL.Name = "btnXoaTXL";
            this.btnXoaTXL.Size = new System.Drawing.Size(67, 33);
            this.btnXoaTXL.TabIndex = 87;
            this.btnXoaTXL.Text = "Xóa";
            this.btnXoaTXL.UseVisualStyleBackColor = true;
            this.btnXoaTXL.Visible = false;
            this.btnXoaTXL.Click += new System.EventHandler(this.btnXoaTXL_Click);
            // 
            // txtKyHieuLDTXL
            // 
            this.txtKyHieuLDTXL.Location = new System.Drawing.Point(169, 23);
            this.txtKyHieuLDTXL.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtKyHieuLDTXL.Name = "txtKyHieuLDTXL";
            this.txtKyHieuLDTXL.Size = new System.Drawing.Size(165, 22);
            this.txtKyHieuLDTXL.TabIndex = 1;
            // 
            // btnSuaTXL
            // 
            this.btnSuaTXL.Location = new System.Drawing.Point(256, 87);
            this.btnSuaTXL.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSuaTXL.Name = "btnSuaTXL";
            this.btnSuaTXL.Size = new System.Drawing.Size(66, 33);
            this.btnSuaTXL.TabIndex = 5;
            this.btnSuaTXL.Text = "Sửa";
            this.btnSuaTXL.UseVisualStyleBackColor = true;
            this.btnSuaTXL.Click += new System.EventHandler(this.btnSuaTXL_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ký Hiệu Loại Đơn:";
            // 
            // btnThemTXL
            // 
            this.btnThemTXL.Location = new System.Drawing.Point(169, 87);
            this.btnThemTXL.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnThemTXL.Name = "btnThemTXL";
            this.btnThemTXL.Size = new System.Drawing.Size(77, 33);
            this.btnThemTXL.TabIndex = 4;
            this.btnThemTXL.Text = "Thêm";
            this.btnThemTXL.UseVisualStyleBackColor = true;
            this.btnThemTXL.Click += new System.EventHandler(this.btnThemTXL_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tên Loại Đơn:";
            // 
            // dgvDSLoaiDonTXL
            // 
            this.dgvDSLoaiDonTXL.AllowUserToAddRows = false;
            this.dgvDSLoaiDonTXL.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSLoaiDonTXL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSLoaiDonTXL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSLoaiDonTXL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLDTXL,
            this.KyHieuLDTXL,
            this.TenLDTXL});
            this.dgvDSLoaiDonTXL.Location = new System.Drawing.Point(7, 129);
            this.dgvDSLoaiDonTXL.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvDSLoaiDonTXL.MultiSelect = false;
            this.dgvDSLoaiDonTXL.Name = "dgvDSLoaiDonTXL";
            this.dgvDSLoaiDonTXL.ReadOnly = true;
            this.dgvDSLoaiDonTXL.Size = new System.Drawing.Size(467, 384);
            this.dgvDSLoaiDonTXL.TabIndex = 6;
            this.dgvDSLoaiDonTXL.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSLoaiDonTXL_CellContentClick);
            this.dgvDSLoaiDonTXL.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSLoaiDonTXL_RowPostPaint);
            // 
            // MaLDTXL
            // 
            this.MaLDTXL.DataPropertyName = "MaLD";
            this.MaLDTXL.HeaderText = "MaLD";
            this.MaLDTXL.Name = "MaLDTXL";
            this.MaLDTXL.ReadOnly = true;
            this.MaLDTXL.Visible = false;
            // 
            // KyHieuLDTXL
            // 
            this.KyHieuLDTXL.DataPropertyName = "KyHieuLD";
            this.KyHieuLDTXL.HeaderText = "Ký Hiệu Loại Đơn";
            this.KyHieuLDTXL.Name = "KyHieuLDTXL";
            this.KyHieuLDTXL.ReadOnly = true;
            this.KyHieuLDTXL.Width = 150;
            // 
            // TenLDTXL
            // 
            this.TenLDTXL.DataPropertyName = "TenLD";
            this.TenLDTXL.HeaderText = "Tên Loại Đơn";
            this.TenLDTXL.Name = "TenLDTXL";
            this.TenLDTXL.ReadOnly = true;
            this.TenLDTXL.Width = 250;
            // 
            // txtTenLDTXL
            // 
            this.txtTenLDTXL.Location = new System.Drawing.Point(169, 55);
            this.txtTenLDTXL.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTenLDTXL.Name = "txtTenLDTXL";
            this.txtTenLDTXL.Size = new System.Drawing.Size(165, 22);
            this.txtTenLDTXL.TabIndex = 3;
            // 
            // frmLoaiDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(992, 531);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmLoaiDon";
            this.Text = "Loại Đơn";
            this.Load += new System.EventHandler(this.frmCapNhatLoaiDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSLoaiDon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSLoaiDonTXL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKyHieuLD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenLD;
        private System.Windows.Forms.DataGridView dgvDSLoaiDon;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyHieuLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtKyHieuLDTXL;
        private System.Windows.Forms.Button btnSuaTXL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThemTXL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDSLoaiDonTXL;
        private System.Windows.Forms.TextBox txtTenLDTXL;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnXoaTXL;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLDTXL;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyHieuLDTXL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLDTXL;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDownTXL;
        private System.Windows.Forms.Button btnUpTXL;
    }
}