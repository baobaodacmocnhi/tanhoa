﻿namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmDieuChinhDangNganChuyenKhoan
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
            this.btnXem = new System.Windows.Forms.Button();
            this.SoHoaDon_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHD_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTongHD_CQ = new System.Windows.Forms.TextBox();
            this.txtTongGiaBan_CQ = new System.Windows.Forms.TextBox();
            this.txtTongThueGTGT_CQ = new System.Windows.Forms.TextBox();
            this.txtTongPhiBVMT_CQ = new System.Windows.Forms.TextBox();
            this.dgvHDCoQuan = new System.Windows.Forms.DataGridView();
            this.TieuThu_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.dateGiaiTrach = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dateGiaiTrachSua = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTongCong_CQ = new System.Windows.Forms.TextBox();
            this.tabCoQuan = new System.Windows.Forms.TabPage();
            this.TongCong_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.PhiBVMT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTongHD_TG = new System.Windows.Forms.TextBox();
            this.txtTongGiaBan_TG = new System.Windows.Forms.TextBox();
            this.tabTuGia = new System.Windows.Forms.TabPage();
            this.txtTongThueGTGT_TG = new System.Windows.Forms.TextBox();
            this.txtTongPhiBVMT_TG = new System.Windows.Forms.TextBox();
            this.txtTongCong_TG = new System.Windows.Forms.TextBox();
            this.dgvHDTuGia = new System.Windows.Forms.DataGridView();
            this.MaHD_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.lstHD = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).BeginInit();
            this.tabCoQuan.SuspendLayout();
            this.tabTuGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(555, 9);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 33;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // SoHoaDon_CQ
            // 
            this.SoHoaDon_CQ.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_CQ.HeaderText = "Số HĐ";
            this.SoHoaDon_CQ.Name = "SoHoaDon_CQ";
            this.SoHoaDon_CQ.ReadOnly = true;
            // 
            // Ky_CQ
            // 
            this.Ky_CQ.DataPropertyName = "Ky";
            this.Ky_CQ.HeaderText = "Kỳ";
            this.Ky_CQ.Name = "Ky_CQ";
            this.Ky_CQ.ReadOnly = true;
            this.Ky_CQ.Visible = false;
            // 
            // MLT_CQ
            // 
            this.MLT_CQ.DataPropertyName = "MLT";
            this.MLT_CQ.HeaderText = "MLT";
            this.MLT_CQ.Name = "MLT_CQ";
            this.MLT_CQ.ReadOnly = true;
            this.MLT_CQ.Visible = false;
            // 
            // SoPhatHanh_CQ
            // 
            this.SoPhatHanh_CQ.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh_CQ.HeaderText = "Số Phát Hành";
            this.SoPhatHanh_CQ.Name = "SoPhatHanh_CQ";
            this.SoPhatHanh_CQ.ReadOnly = true;
            this.SoPhatHanh_CQ.Visible = false;
            // 
            // DanhBo_CQ
            // 
            this.DanhBo_CQ.DataPropertyName = "DanhBo";
            this.DanhBo_CQ.HeaderText = "Danh Bộ";
            this.DanhBo_CQ.Name = "DanhBo_CQ";
            this.DanhBo_CQ.ReadOnly = true;
            // 
            // NgayGiaiTrach_CQ
            // 
            this.NgayGiaiTrach_CQ.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach_CQ.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach_CQ.Name = "NgayGiaiTrach_CQ";
            this.NgayGiaiTrach_CQ.ReadOnly = true;
            this.NgayGiaiTrach_CQ.Width = 80;
            // 
            // MaHD_CQ
            // 
            this.MaHD_CQ.DataPropertyName = "MaHD";
            this.MaHD_CQ.HeaderText = "MaHD";
            this.MaHD_CQ.Name = "MaHD_CQ";
            this.MaHD_CQ.ReadOnly = true;
            this.MaHD_CQ.Visible = false;
            // 
            // txtTongHD_CQ
            // 
            this.txtTongHD_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD_CQ.Location = new System.Drawing.Point(6, 546);
            this.txtTongHD_CQ.Name = "txtTongHD_CQ";
            this.txtTongHD_CQ.Size = new System.Drawing.Size(40, 20);
            this.txtTongHD_CQ.TabIndex = 33;
            this.txtTongHD_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongGiaBan_CQ
            // 
            this.txtTongGiaBan_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongGiaBan_CQ.Location = new System.Drawing.Point(409, 546);
            this.txtTongGiaBan_CQ.Name = "txtTongGiaBan_CQ";
            this.txtTongGiaBan_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongGiaBan_CQ.TabIndex = 13;
            this.txtTongGiaBan_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongThueGTGT_CQ
            // 
            this.txtTongThueGTGT_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongThueGTGT_CQ.Location = new System.Drawing.Point(509, 546);
            this.txtTongThueGTGT_CQ.Name = "txtTongThueGTGT_CQ";
            this.txtTongThueGTGT_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongThueGTGT_CQ.TabIndex = 12;
            this.txtTongThueGTGT_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongPhiBVMT_CQ
            // 
            this.txtTongPhiBVMT_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongPhiBVMT_CQ.Location = new System.Drawing.Point(609, 546);
            this.txtTongPhiBVMT_CQ.Name = "txtTongPhiBVMT_CQ";
            this.txtTongPhiBVMT_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongPhiBVMT_CQ.TabIndex = 11;
            this.txtTongPhiBVMT_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.NgayGiaiTrach_CQ,
            this.SoHoaDon_CQ,
            this.Ky_CQ,
            this.MLT_CQ,
            this.SoPhatHanh_CQ,
            this.DanhBo_CQ,
            this.TieuThu_CQ,
            this.GiaBan_CQ,
            this.ThueGTGT_CQ,
            this.PhiBVMT_CQ,
            this.TongCong_CQ});
            this.dgvHDCoQuan.Location = new System.Drawing.Point(6, 6);
            this.dgvHDCoQuan.Name = "dgvHDCoQuan";
            this.dgvHDCoQuan.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDCoQuan.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHDCoQuan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHDCoQuan.Size = new System.Drawing.Size(826, 540);
            this.dgvHDCoQuan.TabIndex = 10;
            this.dgvHDCoQuan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDCoQuan_CellFormatting);
            this.dgvHDCoQuan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDCoQuan_RowPostPaint);
            // 
            // TieuThu_CQ
            // 
            this.TieuThu_CQ.DataPropertyName = "TieuThu";
            this.TieuThu_CQ.HeaderText = "Tiêu Thụ";
            this.TieuThu_CQ.Name = "TieuThu_CQ";
            this.TieuThu_CQ.ReadOnly = true;
            this.TieuThu_CQ.Width = 80;
            // 
            // GiaBan_CQ
            // 
            this.GiaBan_CQ.DataPropertyName = "GiaBan";
            this.GiaBan_CQ.HeaderText = "Giá Bán";
            this.GiaBan_CQ.Name = "GiaBan_CQ";
            this.GiaBan_CQ.ReadOnly = true;
            // 
            // ThueGTGT_CQ
            // 
            this.ThueGTGT_CQ.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_CQ.HeaderText = "Thuế GTGT";
            this.ThueGTGT_CQ.Name = "ThueGTGT_CQ";
            this.ThueGTGT_CQ.ReadOnly = true;
            // 
            // PhiBVMT_CQ
            // 
            this.PhiBVMT_CQ.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_CQ.HeaderText = "Phí BVMT";
            this.PhiBVMT_CQ.Name = "PhiBVMT_CQ";
            this.PhiBVMT_CQ.ReadOnly = true;
            // 
            // TongCong_CQ
            // 
            this.TongCong_CQ.DataPropertyName = "TongCong";
            this.TongCong_CQ.HeaderText = "Tổng Cộng";
            this.TongCong_CQ.Name = "TongCong_CQ";
            this.TongCong_CQ.ReadOnly = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(121, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "(Enter)";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(90, 256);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(50, 20);
            this.txtSoLuong.TabIndex = 47;
            // 
            // dateGiaiTrach
            // 
            this.dateGiaiTrach.CustomFormat = "dd/MM/yyyy";
            this.dateGiaiTrach.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateGiaiTrach.Location = new System.Drawing.Point(449, 12);
            this.dateGiaiTrach.Name = "dateGiaiTrach";
            this.dateGiaiTrach.Size = new System.Drawing.Size(100, 20);
            this.dateGiaiTrach.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Số Lượng:";
            // 
            // dateGiaiTrachSua
            // 
            this.dateGiaiTrachSua.CustomFormat = "dd/MM/yyyy";
            this.dateGiaiTrachSua.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateGiaiTrachSua.Location = new System.Drawing.Point(146, 229);
            this.dateGiaiTrachSua.Name = "dateGiaiTrachSua";
            this.dateGiaiTrachSua.Size = new System.Drawing.Size(100, 20);
            this.dateGiaiTrachSua.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(143, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Ngày Giải Trách Sửa:";
            // 
            // txtTongCong_CQ
            // 
            this.txtTongCong_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_CQ.Location = new System.Drawing.Point(709, 546);
            this.txtTongCong_CQ.Name = "txtTongCong_CQ";
            this.txtTongCong_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_CQ.TabIndex = 9;
            this.txtTongCong_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabCoQuan
            // 
            this.tabCoQuan.Controls.Add(this.txtTongHD_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongGiaBan_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongThueGTGT_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongPhiBVMT_CQ);
            this.tabCoQuan.Controls.Add(this.dgvHDCoQuan);
            this.tabCoQuan.Controls.Add(this.txtTongCong_CQ);
            this.tabCoQuan.Location = new System.Drawing.Point(4, 22);
            this.tabCoQuan.Name = "tabCoQuan";
            this.tabCoQuan.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoQuan.Size = new System.Drawing.Size(838, 570);
            this.tabCoQuan.TabIndex = 1;
            this.tabCoQuan.Text = "Cơ Quan";
            this.tabCoQuan.UseVisualStyleBackColor = true;
            // 
            // TongCong_TG
            // 
            this.TongCong_TG.DataPropertyName = "TongCong";
            this.TongCong_TG.HeaderText = "Tổng Cộng";
            this.TongCong_TG.Name = "TongCong_TG";
            this.TongCong_TG.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Số Hóa Đơn:";
            // 
            // PhiBVMT_TG
            // 
            this.PhiBVMT_TG.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_TG.HeaderText = "Phí BVMT";
            this.PhiBVMT_TG.Name = "PhiBVMT_TG";
            this.PhiBVMT_TG.ReadOnly = true;
            // 
            // txtTongHD_TG
            // 
            this.txtTongHD_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD_TG.Location = new System.Drawing.Point(6, 546);
            this.txtTongHD_TG.Name = "txtTongHD_TG";
            this.txtTongHD_TG.Size = new System.Drawing.Size(40, 20);
            this.txtTongHD_TG.TabIndex = 5;
            this.txtTongHD_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongGiaBan_TG
            // 
            this.txtTongGiaBan_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongGiaBan_TG.Location = new System.Drawing.Point(409, 546);
            this.txtTongGiaBan_TG.Name = "txtTongGiaBan_TG";
            this.txtTongGiaBan_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongGiaBan_TG.TabIndex = 4;
            this.txtTongGiaBan_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabTuGia
            // 
            this.tabTuGia.Controls.Add(this.txtTongHD_TG);
            this.tabTuGia.Controls.Add(this.txtTongGiaBan_TG);
            this.tabTuGia.Controls.Add(this.txtTongThueGTGT_TG);
            this.tabTuGia.Controls.Add(this.txtTongPhiBVMT_TG);
            this.tabTuGia.Controls.Add(this.txtTongCong_TG);
            this.tabTuGia.Controls.Add(this.dgvHDTuGia);
            this.tabTuGia.Location = new System.Drawing.Point(4, 22);
            this.tabTuGia.Name = "tabTuGia";
            this.tabTuGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabTuGia.Size = new System.Drawing.Size(838, 570);
            this.tabTuGia.TabIndex = 0;
            this.tabTuGia.Text = "Tư Gia";
            this.tabTuGia.UseVisualStyleBackColor = true;
            // 
            // txtTongThueGTGT_TG
            // 
            this.txtTongThueGTGT_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongThueGTGT_TG.Location = new System.Drawing.Point(509, 546);
            this.txtTongThueGTGT_TG.Name = "txtTongThueGTGT_TG";
            this.txtTongThueGTGT_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongThueGTGT_TG.TabIndex = 3;
            this.txtTongThueGTGT_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongPhiBVMT_TG
            // 
            this.txtTongPhiBVMT_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongPhiBVMT_TG.Location = new System.Drawing.Point(609, 546);
            this.txtTongPhiBVMT_TG.Name = "txtTongPhiBVMT_TG";
            this.txtTongPhiBVMT_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongPhiBVMT_TG.TabIndex = 2;
            this.txtTongPhiBVMT_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongCong_TG
            // 
            this.txtTongCong_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_TG.Location = new System.Drawing.Point(709, 546);
            this.txtTongCong_TG.Name = "txtTongCong_TG";
            this.txtTongCong_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_TG.TabIndex = 1;
            this.txtTongCong_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.NgayGiaiTrach_TG,
            this.SoHoaDon_TG,
            this.Ky_TG,
            this.MLT_TG,
            this.SoPhatHanh_TG,
            this.DanhBo_TG,
            this.TieuThu_TG,
            this.GiaBan_TG,
            this.ThueGTGT_TG,
            this.PhiBVMT_TG,
            this.TongCong_TG});
            this.dgvHDTuGia.Location = new System.Drawing.Point(6, 6);
            this.dgvHDTuGia.Name = "dgvHDTuGia";
            this.dgvHDTuGia.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDTuGia.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHDTuGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHDTuGia.Size = new System.Drawing.Size(826, 540);
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
            // NgayGiaiTrach_TG
            // 
            this.NgayGiaiTrach_TG.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach_TG.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach_TG.Name = "NgayGiaiTrach_TG";
            this.NgayGiaiTrach_TG.ReadOnly = true;
            this.NgayGiaiTrach_TG.Width = 80;
            // 
            // SoHoaDon_TG
            // 
            this.SoHoaDon_TG.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_TG.HeaderText = "Số HĐ";
            this.SoHoaDon_TG.Name = "SoHoaDon_TG";
            this.SoHoaDon_TG.ReadOnly = true;
            // 
            // Ky_TG
            // 
            this.Ky_TG.DataPropertyName = "Ky";
            this.Ky_TG.HeaderText = "Kỳ";
            this.Ky_TG.Name = "Ky_TG";
            this.Ky_TG.ReadOnly = true;
            this.Ky_TG.Visible = false;
            // 
            // MLT_TG
            // 
            this.MLT_TG.DataPropertyName = "MLT";
            this.MLT_TG.HeaderText = "MLT";
            this.MLT_TG.Name = "MLT_TG";
            this.MLT_TG.ReadOnly = true;
            this.MLT_TG.Visible = false;
            // 
            // SoPhatHanh_TG
            // 
            this.SoPhatHanh_TG.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh_TG.HeaderText = "Số Phát Hành";
            this.SoPhatHanh_TG.Name = "SoPhatHanh_TG";
            this.SoPhatHanh_TG.ReadOnly = true;
            this.SoPhatHanh_TG.Visible = false;
            // 
            // DanhBo_TG
            // 
            this.DanhBo_TG.DataPropertyName = "DanhBo";
            this.DanhBo_TG.HeaderText = "Danh Bộ";
            this.DanhBo_TG.Name = "DanhBo_TG";
            this.DanhBo_TG.ReadOnly = true;
            // 
            // TieuThu_TG
            // 
            this.TieuThu_TG.DataPropertyName = "TieuThu";
            this.TieuThu_TG.HeaderText = "Tiêu Thụ";
            this.TieuThu_TG.Name = "TieuThu_TG";
            this.TieuThu_TG.ReadOnly = true;
            this.TieuThu_TG.Width = 80;
            // 
            // GiaBan_TG
            // 
            this.GiaBan_TG.DataPropertyName = "GiaBan";
            this.GiaBan_TG.HeaderText = "Giá Bán";
            this.GiaBan_TG.Name = "GiaBan_TG";
            this.GiaBan_TG.ReadOnly = true;
            // 
            // ThueGTGT_TG
            // 
            this.ThueGTGT_TG.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_TG.HeaderText = "Thuế GTGT";
            this.ThueGTGT_TG.Name = "ThueGTGT_TG";
            this.ThueGTGT_TG.ReadOnly = true;
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(15, 25);
            this.txtSoHoaDon.Multiline = true;
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 45);
            this.txtSoHoaDon.TabIndex = 37;
            this.txtSoHoaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHoaDon_KeyPress);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(146, 134);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 40;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(146, 76);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 38;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(146, 105);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 39;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTuGia);
            this.tabControl.Controls.Add(this.tabCoQuan);
            this.tabControl.Location = new System.Drawing.Point(258, 38);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(846, 596);
            this.tabControl.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Ngày Giải Trách:";
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(636, 9);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(75, 23);
            this.btnInPhieu.TabIndex = 52;
            this.btnInPhieu.Text = "In Phiếu";
            this.btnInPhieu.UseVisualStyleBackColor = true;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // lstHD
            // 
            this.lstHD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstHD.Location = new System.Drawing.Point(15, 76);
            this.lstHD.Name = "lstHD";
            this.lstHD.Size = new System.Drawing.Size(125, 173);
            this.lstHD.TabIndex = 53;
            this.lstHD.UseCompatibleStateImageBehavior = false;
            this.lstHD.View = System.Windows.Forms.View.Details;
            this.lstHD.SelectedIndexChanged += new System.EventHandler(this.lstHD_SelectedIndexChanged);
            this.lstHD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHD_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Danh Sách Hóa Đơn";
            this.columnHeader1.Width = 120;
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(30, 282);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(110, 23);
            this.btnCopyToClipboard.TabIndex = 69;
            this.btnCopyToClipboard.Text = "Copy to Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // frmDieuChinhDangNganChuyenKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 641);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.lstHD);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.dateGiaiTrach);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateGiaiTrachSua);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label1);
            this.Name = "frmDieuChinhDangNganChuyenKhoan";
            this.Text = "Điều Chỉnh Đăng Ngân Chuyển Khoản";
            this.Load += new System.EventHandler(this.frmDieuChinhDangNganChuyenKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).EndInit();
            this.tabCoQuan.ResumeLayout(false);
            this.tabCoQuan.PerformLayout();
            this.tabTuGia.ResumeLayout(false);
            this.tabTuGia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD_CQ;
        private System.Windows.Forms.TextBox txtTongHD_CQ;
        private System.Windows.Forms.TextBox txtTongGiaBan_CQ;
        private System.Windows.Forms.TextBox txtTongThueGTGT_CQ;
        private System.Windows.Forms.TextBox txtTongPhiBVMT_CQ;
        private System.Windows.Forms.DataGridView dgvHDCoQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_CQ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.DateTimePicker dateGiaiTrach;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateGiaiTrachSua;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTongCong_CQ;
        private System.Windows.Forms.TabPage tabCoQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_TG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_TG;
        private System.Windows.Forms.TextBox txtTongHD_TG;
        private System.Windows.Forms.TextBox txtTongGiaBan_TG;
        private System.Windows.Forms.TabPage tabTuGia;
        private System.Windows.Forms.TextBox txtTongThueGTGT_TG;
        private System.Windows.Forms.TextBox txtTongPhiBVMT_TG;
        private System.Windows.Forms.TextBox txtTongCong_TG;
        private System.Windows.Forms.DataGridView dgvHDTuGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_TG;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInPhieu;
        private System.Windows.Forms.ListView lstHD;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnCopyToClipboard;
    }
}