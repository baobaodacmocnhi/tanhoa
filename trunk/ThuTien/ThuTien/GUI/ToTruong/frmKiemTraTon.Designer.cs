﻿namespace ThuTien.GUI.ToTruong
{
    partial class frmKiemTraTon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MaNV_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbTo = new System.Windows.Forms.Label();
            this.HoTen_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHD_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuMLT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHDTon_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHDCoQuan = new System.Windows.Forms.DataGridView();
            this.DenMLT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuSoPhatHanh_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenSoPhatHanh_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHD_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHDThu_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCongThu_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHDTon_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCongTon_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCongTon_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCoQuan = new System.Windows.Forms.TabPage();
            this.TongCongThu_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHDThu_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTuGia = new System.Windows.Forms.TabPage();
            this.dgvHDTuGia = new System.Windows.Forms.DataGridView();
            this.MaHD_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuMLT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenMLT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuSoPhatHanh_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenSoPhatHanh_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHD_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).BeginInit();
            this.tabCoQuan.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabTuGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).BeginInit();
            this.SuspendLayout();
            // 
            // MaNV_CQ
            // 
            this.MaNV_CQ.DataPropertyName = "MaNV";
            this.MaNV_CQ.HeaderText = "MaNV";
            this.MaNV_CQ.Name = "MaNV_CQ";
            this.MaNV_CQ.ReadOnly = true;
            this.MaNV_CQ.Visible = false;
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTo.Location = new System.Drawing.Point(748, 15);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(32, 19);
            this.lbTo.TabIndex = 28;
            this.lbTo.Text = "Tổ:";
            // 
            // HoTen_CQ
            // 
            this.HoTen_CQ.DataPropertyName = "HoTen";
            this.HoTen_CQ.HeaderText = "Nhân Viên";
            this.HoTen_CQ.Name = "HoTen_CQ";
            this.HoTen_CQ.ReadOnly = true;
            // 
            // MaHD_CQ
            // 
            this.MaHD_CQ.DataPropertyName = "MaHD";
            this.MaHD_CQ.HeaderText = "MaHD";
            this.MaHD_CQ.Name = "MaHD_CQ";
            this.MaHD_CQ.ReadOnly = true;
            this.MaHD_CQ.Visible = false;
            // 
            // TuMLT_CQ
            // 
            this.TuMLT_CQ.DataPropertyName = "TuMLT";
            this.TuMLT_CQ.HeaderText = "Từ MLT";
            this.TuMLT_CQ.Name = "TuMLT_CQ";
            this.TuMLT_CQ.ReadOnly = true;
            this.TuMLT_CQ.Width = 80;
            // 
            // TongHDTon_TG
            // 
            this.TongHDTon_TG.DataPropertyName = "TongHDTon";
            this.TongHDTon_TG.HeaderText = "Tổng HĐ Tồn";
            this.TongHDTon_TG.Name = "TongHDTon_TG";
            this.TongHDTon_TG.ReadOnly = true;
            this.TongHDTon_TG.Width = 80;
            // 
            // dgvHDCoQuan
            // 
            this.dgvHDCoQuan.AllowUserToAddRows = false;
            this.dgvHDCoQuan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDCoQuan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHDCoQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDCoQuan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD_CQ,
            this.MaNV_CQ,
            this.HoTen_CQ,
            this.TuMLT_CQ,
            this.DenMLT_CQ,
            this.TuSoPhatHanh_CQ,
            this.DenSoPhatHanh_CQ,
            this.TongHD_CQ,
            this.TongCong_CQ,
            this.TongHDThu_CQ,
            this.TongCongThu_CQ,
            this.TongHDTon_CQ,
            this.TongCongTon_CQ});
            this.dgvHDCoQuan.Location = new System.Drawing.Point(6, 6);
            this.dgvHDCoQuan.MultiSelect = false;
            this.dgvHDCoQuan.Name = "dgvHDCoQuan";
            this.dgvHDCoQuan.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDCoQuan.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHDCoQuan.Size = new System.Drawing.Size(1040, 395);
            this.dgvHDCoQuan.TabIndex = 1;
            this.dgvHDCoQuan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDCoQuan_CellFormatting);
            this.dgvHDCoQuan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDCoQuan_RowPostPaint);
            // 
            // DenMLT_CQ
            // 
            this.DenMLT_CQ.DataPropertyName = "DenMLT";
            this.DenMLT_CQ.HeaderText = "Đến MLT";
            this.DenMLT_CQ.Name = "DenMLT_CQ";
            this.DenMLT_CQ.ReadOnly = true;
            this.DenMLT_CQ.Width = 80;
            // 
            // TuSoPhatHanh_CQ
            // 
            this.TuSoPhatHanh_CQ.DataPropertyName = "TuSoPhatHanh";
            this.TuSoPhatHanh_CQ.HeaderText = "Từ Số Phát Hành";
            this.TuSoPhatHanh_CQ.Name = "TuSoPhatHanh_CQ";
            this.TuSoPhatHanh_CQ.ReadOnly = true;
            this.TuSoPhatHanh_CQ.Width = 85;
            // 
            // DenSoPhatHanh_CQ
            // 
            this.DenSoPhatHanh_CQ.DataPropertyName = "DenSoPhatHanh";
            this.DenSoPhatHanh_CQ.HeaderText = "Đến Số Phát Hành";
            this.DenSoPhatHanh_CQ.Name = "DenSoPhatHanh_CQ";
            this.DenSoPhatHanh_CQ.ReadOnly = true;
            this.DenSoPhatHanh_CQ.Width = 90;
            // 
            // TongHD_CQ
            // 
            this.TongHD_CQ.DataPropertyName = "TongHD";
            this.TongHD_CQ.HeaderText = "Tổng HĐ";
            this.TongHD_CQ.Name = "TongHD_CQ";
            this.TongHD_CQ.ReadOnly = true;
            this.TongHD_CQ.Width = 80;
            // 
            // TongCong_CQ
            // 
            this.TongCong_CQ.DataPropertyName = "TongCong";
            this.TongCong_CQ.HeaderText = "Tổng Cộng";
            this.TongCong_CQ.Name = "TongCong_CQ";
            this.TongCong_CQ.ReadOnly = true;
            // 
            // TongHDThu_CQ
            // 
            this.TongHDThu_CQ.DataPropertyName = "TongHDThu";
            this.TongHDThu_CQ.HeaderText = "Tổng HĐ Thu";
            this.TongHDThu_CQ.Name = "TongHDThu_CQ";
            this.TongHDThu_CQ.ReadOnly = true;
            this.TongHDThu_CQ.Width = 80;
            // 
            // TongCongThu_CQ
            // 
            this.TongCongThu_CQ.DataPropertyName = "TongCongThu";
            this.TongCongThu_CQ.HeaderText = "Tổng Cộng Thu";
            this.TongCongThu_CQ.Name = "TongCongThu_CQ";
            this.TongCongThu_CQ.ReadOnly = true;
            // 
            // TongHDTon_CQ
            // 
            this.TongHDTon_CQ.DataPropertyName = "TongHDTon";
            this.TongHDTon_CQ.HeaderText = "Tổng HĐ Tồn";
            this.TongHDTon_CQ.Name = "TongHDTon_CQ";
            this.TongHDTon_CQ.ReadOnly = true;
            this.TongHDTon_CQ.Width = 80;
            // 
            // TongCongTon_CQ
            // 
            this.TongCongTon_CQ.DataPropertyName = "TongCongTon";
            this.TongCongTon_CQ.HeaderText = "Tổng Cộng Tồn";
            this.TongCongTon_CQ.Name = "TongCongTon_CQ";
            this.TongCongTon_CQ.ReadOnly = true;
            // 
            // TongCongTon_TG
            // 
            this.TongCongTon_TG.DataPropertyName = "TongCongTon";
            this.TongCongTon_TG.HeaderText = "Tổng Cộng Tồn";
            this.TongCongTon_TG.Name = "TongCongTon_TG";
            this.TongCongTon_TG.ReadOnly = true;
            // 
            // tabCoQuan
            // 
            this.tabCoQuan.Controls.Add(this.dgvHDCoQuan);
            this.tabCoQuan.Location = new System.Drawing.Point(4, 22);
            this.tabCoQuan.Name = "tabCoQuan";
            this.tabCoQuan.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoQuan.Size = new System.Drawing.Size(1055, 409);
            this.tabCoQuan.TabIndex = 1;
            this.tabCoQuan.Text = "Cơ Quan";
            this.tabCoQuan.UseVisualStyleBackColor = true;
            // 
            // TongCongThu_TG
            // 
            this.TongCongThu_TG.DataPropertyName = "TongCongThu";
            this.TongCongThu_TG.HeaderText = "Tổng Cộng Thu";
            this.TongCongThu_TG.Name = "TongCongThu_TG";
            this.TongCongThu_TG.ReadOnly = true;
            // 
            // TongHDThu_TG
            // 
            this.TongHDThu_TG.DataPropertyName = "TongHDThu";
            this.TongHDThu_TG.HeaderText = "Tổng HĐ Thu";
            this.TongHDThu_TG.Name = "TongHDThu_TG";
            this.TongHDThu_TG.ReadOnly = true;
            this.TongHDThu_TG.Width = 80;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTuGia);
            this.tabControl.Controls.Add(this.tabCoQuan);
            this.tabControl.Location = new System.Drawing.Point(12, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1063, 435);
            this.tabControl.TabIndex = 29;
            // 
            // tabTuGia
            // 
            this.tabTuGia.Controls.Add(this.dgvHDTuGia);
            this.tabTuGia.Location = new System.Drawing.Point(4, 22);
            this.tabTuGia.Name = "tabTuGia";
            this.tabTuGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabTuGia.Size = new System.Drawing.Size(1055, 409);
            this.tabTuGia.TabIndex = 0;
            this.tabTuGia.Text = "Tư Gia";
            this.tabTuGia.UseVisualStyleBackColor = true;
            // 
            // dgvHDTuGia
            // 
            this.dgvHDTuGia.AllowUserToAddRows = false;
            this.dgvHDTuGia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDTuGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHDTuGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDTuGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD_TG,
            this.MaNV_TG,
            this.HoTen_TG,
            this.TuMLT_TG,
            this.DenMLT_TG,
            this.TuSoPhatHanh_TG,
            this.DenSoPhatHanh_TG,
            this.TongHD_TG,
            this.TongCong_TG,
            this.TongHDThu_TG,
            this.TongCongThu_TG,
            this.TongHDTon_TG,
            this.TongCongTon_TG});
            this.dgvHDTuGia.Location = new System.Drawing.Point(6, 6);
            this.dgvHDTuGia.MultiSelect = false;
            this.dgvHDTuGia.Name = "dgvHDTuGia";
            this.dgvHDTuGia.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDTuGia.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHDTuGia.Size = new System.Drawing.Size(1040, 395);
            this.dgvHDTuGia.TabIndex = 0;
            this.dgvHDTuGia.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDTuGia_CellFormatting);
            this.dgvHDTuGia.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDTuGia_RowPostPaint);
            // 
            // MaHD_TG
            // 
            this.MaHD_TG.DataPropertyName = "MaHD";
            this.MaHD_TG.HeaderText = "MaHD";
            this.MaHD_TG.Name = "MaHD_TG";
            this.MaHD_TG.ReadOnly = true;
            this.MaHD_TG.Visible = false;
            // 
            // MaNV_TG
            // 
            this.MaNV_TG.DataPropertyName = "MaNV";
            this.MaNV_TG.HeaderText = "MaNV";
            this.MaNV_TG.Name = "MaNV_TG";
            this.MaNV_TG.ReadOnly = true;
            this.MaNV_TG.Visible = false;
            // 
            // HoTen_TG
            // 
            this.HoTen_TG.DataPropertyName = "HoTen";
            this.HoTen_TG.HeaderText = "Nhân Viên";
            this.HoTen_TG.Name = "HoTen_TG";
            this.HoTen_TG.ReadOnly = true;
            // 
            // TuMLT_TG
            // 
            this.TuMLT_TG.DataPropertyName = "TuMLT";
            this.TuMLT_TG.HeaderText = "Từ MLT";
            this.TuMLT_TG.Name = "TuMLT_TG";
            this.TuMLT_TG.ReadOnly = true;
            this.TuMLT_TG.Width = 80;
            // 
            // DenMLT_TG
            // 
            this.DenMLT_TG.DataPropertyName = "DenMLT";
            this.DenMLT_TG.HeaderText = "Đến MLT";
            this.DenMLT_TG.Name = "DenMLT_TG";
            this.DenMLT_TG.ReadOnly = true;
            this.DenMLT_TG.Width = 80;
            // 
            // TuSoPhatHanh_TG
            // 
            this.TuSoPhatHanh_TG.DataPropertyName = "TuSoPhatHanh";
            this.TuSoPhatHanh_TG.HeaderText = "Từ Số Phát Hành";
            this.TuSoPhatHanh_TG.Name = "TuSoPhatHanh_TG";
            this.TuSoPhatHanh_TG.ReadOnly = true;
            this.TuSoPhatHanh_TG.Width = 85;
            // 
            // DenSoPhatHanh_TG
            // 
            this.DenSoPhatHanh_TG.DataPropertyName = "DenSoPhatHanh";
            this.DenSoPhatHanh_TG.HeaderText = "Đến Số Phát Hành";
            this.DenSoPhatHanh_TG.Name = "DenSoPhatHanh_TG";
            this.DenSoPhatHanh_TG.ReadOnly = true;
            this.DenSoPhatHanh_TG.Width = 90;
            // 
            // TongHD_TG
            // 
            this.TongHD_TG.DataPropertyName = "TongHD";
            this.TongHD_TG.HeaderText = "Tổng HĐ";
            this.TongHD_TG.Name = "TongHD_TG";
            this.TongHD_TG.ReadOnly = true;
            this.TongHD_TG.Width = 80;
            // 
            // TongCong_TG
            // 
            this.TongCong_TG.DataPropertyName = "TongCong";
            this.TongCong_TG.HeaderText = "Tổng Cộng";
            this.TongCong_TG.Name = "TongCong_TG";
            this.TongCong_TG.ReadOnly = true;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(544, 11);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 27;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbKy
            // 
            this.cmbKy.FormattingEnabled = true;
            this.cmbKy.Items.AddRange(new object[] {
            "Tất cả",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbKy.Location = new System.Drawing.Point(488, 12);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(50, 21);
            this.cmbKy.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Kỳ:";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(394, 12);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Năm:";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(232, 12);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(118, 21);
            this.cmbNhanVien.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Nhân Viên:";
            // 
            // frmKiemTraTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 496);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbKy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.label2);
            this.Name = "frmKiemTraTon";
            this.Text = "Kiểm Tra Tồn";
            this.Load += new System.EventHandler(this.frmKiemTraTon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).EndInit();
            this.tabCoQuan.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabTuGia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV_CQ;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuMLT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHDTon_TG;
        private System.Windows.Forms.DataGridView dgvHDCoQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenMLT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuSoPhatHanh_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenSoPhatHanh_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHD_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHDThu_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCongThu_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHDTon_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCongTon_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCongTon_TG;
        private System.Windows.Forms.TabPage tabCoQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCongThu_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHDThu_TG;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTuGia;
        private System.Windows.Forms.DataGridView dgvHDTuGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuMLT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenMLT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuSoPhatHanh_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenSoPhatHanh_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHD_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_TG;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label label4;
    }
}