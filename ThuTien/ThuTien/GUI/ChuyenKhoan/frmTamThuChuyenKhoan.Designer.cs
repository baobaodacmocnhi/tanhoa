﻿namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmTamThuChuyenKhoan
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.tabTamThu = new System.Windows.Forms.TabPage();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnInTamThu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTamThu = new System.Windows.Forms.DataGridView();
            this.MaTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNH_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.tabThongTin = new System.Windows.Forms.TabPage();
            this.btnThem = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChenhLech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NganHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTamThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTamThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.tabThongTin.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Danh Bộ:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(377, 9);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 18;
            // 
            // btnXoa
            // 
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(726, 6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 23;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(790, 12);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 22;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(483, 6);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 19;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // tabTamThu
            // 
            this.tabTamThu.Controls.Add(this.btnXuatExcel);
            this.tabTamThu.Controls.Add(this.btnInTamThu);
            this.tabTamThu.Controls.Add(this.btnXem);
            this.tabTamThu.Controls.Add(this.dateDen);
            this.tabTamThu.Controls.Add(this.btnXoa);
            this.tabTamThu.Controls.Add(this.label3);
            this.tabTamThu.Controls.Add(this.dateTu);
            this.tabTamThu.Controls.Add(this.label2);
            this.tabTamThu.Controls.Add(this.dgvTamThu);
            this.tabTamThu.Location = new System.Drawing.Point(4, 22);
            this.tabTamThu.Name = "tabTamThu";
            this.tabTamThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabTamThu.Size = new System.Drawing.Size(1362, 572);
            this.tabTamThu.TabIndex = 1;
            this.tabTamThu.Text = "Danh Sách Tạm Thu";
            this.tabTamThu.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(645, 6);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.TabIndex = 21;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnInTamThu
            // 
            this.btnInTamThu.Location = new System.Drawing.Point(564, 6);
            this.btnInTamThu.Name = "btnInTamThu";
            this.btnInTamThu.Size = new System.Drawing.Size(75, 23);
            this.btnInTamThu.TabIndex = 20;
            this.btnInTamThu.Text = "In Tạm Thu";
            this.btnInTamThu.UseVisualStyleBackColor = true;
            this.btnInTamThu.Click += new System.EventHandler(this.btnInTamThu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Đến Ngày:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(207, 9);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Từ Ngày:";
            // 
            // dgvTamThu
            // 
            this.dgvTamThu.AllowUserToAddRows = false;
            this.dgvTamThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTamThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTamThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTamThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTT,
            this.NgayGiaiTrach_TT,
            this.CreateDate_TT,
            this.SoHoaDon_TT,
            this.Ky_TT,
            this.MLT_TT,
            this.DanhBo_TT,
            this.HoTen_TT,
            this.DiaChi_TT,
            this.TieuThu_TT,
            this.GiaBan_TT,
            this.ThueGTGT_TT,
            this.PhiBVMT_TT,
            this.TongCong_TT,
            this.HanhThu_TT,
            this.To_TT,
            this.MaNH_TT,
            this.GiaBieu});
            this.dgvTamThu.Location = new System.Drawing.Point(6, 35);
            this.dgvTamThu.Name = "dgvTamThu";
            this.dgvTamThu.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTamThu.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTamThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTamThu.Size = new System.Drawing.Size(1350, 530);
            this.dgvTamThu.TabIndex = 14;
            this.dgvTamThu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTamThu_CellFormatting);
            this.dgvTamThu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTamThu_RowPostPaint);
            // 
            // MaTT
            // 
            this.MaTT.DataPropertyName = "MaTT";
            this.MaTT.HeaderText = "MaTT";
            this.MaTT.Name = "MaTT";
            this.MaTT.ReadOnly = true;
            this.MaTT.Visible = false;
            // 
            // NgayGiaiTrach_TT
            // 
            this.NgayGiaiTrach_TT.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach_TT.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach_TT.Name = "NgayGiaiTrach_TT";
            this.NgayGiaiTrach_TT.ReadOnly = true;
            this.NgayGiaiTrach_TT.Width = 80;
            // 
            // CreateDate_TT
            // 
            this.CreateDate_TT.DataPropertyName = "CreateDate";
            this.CreateDate_TT.HeaderText = "Ngày Thu";
            this.CreateDate_TT.Name = "CreateDate_TT";
            this.CreateDate_TT.ReadOnly = true;
            this.CreateDate_TT.Width = 80;
            // 
            // SoHoaDon_TT
            // 
            this.SoHoaDon_TT.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_TT.HeaderText = "Số HĐ";
            this.SoHoaDon_TT.Name = "SoHoaDon_TT";
            this.SoHoaDon_TT.ReadOnly = true;
            // 
            // Ky_TT
            // 
            this.Ky_TT.DataPropertyName = "Ky";
            this.Ky_TT.HeaderText = "Kỳ";
            this.Ky_TT.Name = "Ky_TT";
            this.Ky_TT.ReadOnly = true;
            this.Ky_TT.Width = 50;
            // 
            // MLT_TT
            // 
            this.MLT_TT.DataPropertyName = "MLT";
            this.MLT_TT.HeaderText = "MLT";
            this.MLT_TT.Name = "MLT_TT";
            this.MLT_TT.ReadOnly = true;
            this.MLT_TT.Width = 80;
            // 
            // DanhBo_TT
            // 
            this.DanhBo_TT.DataPropertyName = "DanhBo";
            this.DanhBo_TT.HeaderText = "Danh Bộ";
            this.DanhBo_TT.Name = "DanhBo_TT";
            this.DanhBo_TT.ReadOnly = true;
            // 
            // HoTen_TT
            // 
            this.HoTen_TT.DataPropertyName = "HoTen";
            this.HoTen_TT.HeaderText = "Họ Tên";
            this.HoTen_TT.Name = "HoTen_TT";
            this.HoTen_TT.ReadOnly = true;
            this.HoTen_TT.Width = 150;
            // 
            // DiaChi_TT
            // 
            this.DiaChi_TT.DataPropertyName = "DiaChi";
            this.DiaChi_TT.HeaderText = "Địa Chỉ";
            this.DiaChi_TT.Name = "DiaChi_TT";
            this.DiaChi_TT.ReadOnly = true;
            this.DiaChi_TT.Width = 200;
            // 
            // TieuThu_TT
            // 
            this.TieuThu_TT.DataPropertyName = "TieuThu";
            this.TieuThu_TT.HeaderText = "Tiêu Thụ";
            this.TieuThu_TT.Name = "TieuThu_TT";
            this.TieuThu_TT.ReadOnly = true;
            this.TieuThu_TT.Width = 50;
            // 
            // GiaBan_TT
            // 
            this.GiaBan_TT.DataPropertyName = "GiaBan";
            this.GiaBan_TT.HeaderText = "Giá Bán";
            this.GiaBan_TT.Name = "GiaBan_TT";
            this.GiaBan_TT.ReadOnly = true;
            this.GiaBan_TT.Width = 70;
            // 
            // ThueGTGT_TT
            // 
            this.ThueGTGT_TT.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_TT.HeaderText = "Thuế GTGT";
            this.ThueGTGT_TT.Name = "ThueGTGT_TT";
            this.ThueGTGT_TT.ReadOnly = true;
            this.ThueGTGT_TT.Width = 70;
            // 
            // PhiBVMT_TT
            // 
            this.PhiBVMT_TT.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_TT.HeaderText = "Phí BVMT";
            this.PhiBVMT_TT.Name = "PhiBVMT_TT";
            this.PhiBVMT_TT.ReadOnly = true;
            this.PhiBVMT_TT.Width = 70;
            // 
            // TongCong_TT
            // 
            this.TongCong_TT.DataPropertyName = "TongCong";
            this.TongCong_TT.HeaderText = "Tổng Cộng";
            this.TongCong_TT.Name = "TongCong_TT";
            this.TongCong_TT.ReadOnly = true;
            this.TongCong_TT.Width = 70;
            // 
            // HanhThu_TT
            // 
            this.HanhThu_TT.DataPropertyName = "HanhThu";
            this.HanhThu_TT.HeaderText = "Hành Thu";
            this.HanhThu_TT.Name = "HanhThu_TT";
            this.HanhThu_TT.ReadOnly = true;
            // 
            // To_TT
            // 
            this.To_TT.DataPropertyName = "To";
            this.To_TT.HeaderText = "Tổ";
            this.To_TT.Name = "To_TT";
            this.To_TT.ReadOnly = true;
            this.To_TT.Width = 50;
            // 
            // MaNH_TT
            // 
            this.MaNH_TT.DataPropertyName = "MaNH";
            this.MaNH_TT.HeaderText = "Ngân Hàng";
            this.MaNH_TT.Name = "MaNH_TT";
            this.MaNH_TT.ReadOnly = true;
            // 
            // GiaBieu
            // 
            this.GiaBieu.DataPropertyName = "GiaBieu";
            this.GiaBieu.HeaderText = "GiaBieu";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.ReadOnly = true;
            this.GiaBieu.Visible = false;
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(336, 12);
            this.txtDanhBo.Multiline = true;
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDanhBo.Size = new System.Drawing.Size(100, 45);
            this.txtDanhBo.TabIndex = 19;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chon,
            this.MaHD,
            this.SoHoaDon,
            this.Ky,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.TieuThu,
            this.GiaBan,
            this.ThueGTGT,
            this.PhiBVMT,
            this.TongCong,
            this.HanhThu,
            this.ChenhLech,
            this.NganHang});
            this.dgvHoaDon.Location = new System.Drawing.Point(6, 35);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1350, 530);
            this.dgvHoaDon.TabIndex = 13;
            this.dgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHoaDon_CellFormatting);
            this.dgvHoaDon.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHoaDon_RowPostPaint);
            // 
            // tabThongTin
            // 
            this.tabThongTin.Controls.Add(this.dgvHoaDon);
            this.tabThongTin.Controls.Add(this.btnThem);
            this.tabThongTin.Location = new System.Drawing.Point(4, 22);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongTin.Size = new System.Drawing.Size(1362, 572);
            this.tabThongTin.TabIndex = 0;
            this.tabThongTin.Text = "Thông Tin";
            this.tabThongTin.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(301, 6);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 21;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabThongTin);
            this.tabControl.Controls.Add(this.tabTamThu);
            this.tabControl.Location = new System.Drawing.Point(1, 41);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1370, 598);
            this.tabControl.TabIndex = 20;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(190, 12);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 26;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(442, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "(Enter)";
            // 
            // Chon
            // 
            this.Chon.FalseValue = "false";
            this.Chon.HeaderText = "Chọn";
            this.Chon.Name = "Chon";
            this.Chon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Chon.TrueValue = "true";
            this.Chon.Width = 50;
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.Name = "MaHD";
            this.MaHD.Visible = false;
            // 
            // SoHoaDon
            // 
            this.SoHoaDon.DataPropertyName = "SoHoaDon";
            this.SoHoaDon.HeaderText = "Số HĐ";
            this.SoHoaDon.Name = "SoHoaDon";
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.Width = 50;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // TieuThu
            // 
            this.TieuThu.DataPropertyName = "TieuThu";
            this.TieuThu.HeaderText = "Tiêu Thụ";
            this.TieuThu.Name = "TieuThu";
            this.TieuThu.Width = 50;
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "GiaBan";
            this.GiaBan.HeaderText = "Giá Bán";
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.Width = 70;
            // 
            // ThueGTGT
            // 
            this.ThueGTGT.DataPropertyName = "ThueGTGT";
            this.ThueGTGT.HeaderText = "Thuế GTGT";
            this.ThueGTGT.Name = "ThueGTGT";
            this.ThueGTGT.Width = 70;
            // 
            // PhiBVMT
            // 
            this.PhiBVMT.DataPropertyName = "PhiBVMT";
            this.PhiBVMT.HeaderText = "Phí BVMT";
            this.PhiBVMT.Name = "PhiBVMT";
            this.PhiBVMT.Width = 70;
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            this.TongCong.Width = 70;
            // 
            // HanhThu
            // 
            this.HanhThu.DataPropertyName = "HanhThu";
            this.HanhThu.HeaderText = "Hành Thu";
            this.HanhThu.Name = "HanhThu";
            // 
            // ChenhLech
            // 
            this.ChenhLech.HeaderText = "Chênh Lệch";
            this.ChenhLech.Name = "ChenhLech";
            // 
            // NganHang
            // 
            this.NganHang.DataPropertyName = "NganHang";
            this.NganHang.HeaderText = "NganHang";
            this.NganHang.Name = "NganHang";
            // 
            // frmTamThuChuyenKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 666);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.tabControl);
            this.KeyPreview = true;
            this.Name = "frmTamThuChuyenKhoan";
            this.Text = "Tạm Thu Chuyển Khoản";
            this.Load += new System.EventHandler(this.frmTamThuChuyenKhoan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTamThuChuyenKhoan_KeyDown);
            this.tabTamThu.ResumeLayout(false);
            this.tabTamThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTamThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.tabThongTin.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.TabPage tabTamThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTamThu;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.TabPage tabThongTin;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnInTamThu;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNH_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChenhLech;
        private System.Windows.Forms.DataGridViewTextBoxColumn NganHang;
    }
}