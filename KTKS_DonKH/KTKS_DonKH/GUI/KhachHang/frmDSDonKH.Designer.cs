﻿namespace KTKS_DonKH.GUI.KhachHang
{
    partial class frmDSDonKH
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDSDonKH = new System.Windows.Forms.DataGridView();
            this.MaChuyen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LyDoChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NVKiemTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimKiem = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.btnInDSDonKH = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.btnInChiTiet = new System.Windows.Forms.Button();
            this.chkChuaKT = new System.Windows.Forms.CheckBox();
            this.btnInDSDonTXL = new System.Windows.Forms.Button();
            this.btnGiaoTXL = new System.Windows.Forms.Button();
            this.txtNoiDungTimKiem2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDonKH)).BeginInit();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSDonKH
            // 
            this.dgvDSDonKH.AllowUserToAddRows = false;
            this.dgvDSDonKH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSDonKH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSDonKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDonKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChuyen,
            this.LyDoChuyen,
            this.SoLuongDiaChi,
            this.NVKiemTra,
            this.MaDon,
            this.MaLD,
            this.TenLD,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung,
            this.CreateBy});
            this.dgvDSDonKH.Location = new System.Drawing.Point(0, 59);
            this.dgvDSDonKH.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSDonKH.MultiSelect = false;
            this.dgvDSDonKH.Name = "dgvDSDonKH";
            this.dgvDSDonKH.RowHeadersWidth = 60;
            this.dgvDSDonKH.Size = new System.Drawing.Size(1192, 415);
            this.dgvDSDonKH.TabIndex = 11;
            this.dgvDSDonKH.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSDonKH_CellFormatting);
            this.dgvDSDonKH.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDSDonKH_EditingControlShowing);
            this.dgvDSDonKH.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSDonKH_RowPostPaint);
            this.dgvDSDonKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSDonKH_KeyDown);
            // 
            // MaChuyen
            // 
            this.MaChuyen.DataPropertyName = "MaChuyen";
            this.MaChuyen.HeaderText = "Chuyển Đi";
            this.MaChuyen.Name = "MaChuyen";
            this.MaChuyen.Visible = false;
            this.MaChuyen.Width = 150;
            // 
            // LyDoChuyen
            // 
            this.LyDoChuyen.DataPropertyName = "LyDoChuyen";
            this.LyDoChuyen.HeaderText = "Ly Do Chuyển";
            this.LyDoChuyen.Name = "LyDoChuyen";
            this.LyDoChuyen.Visible = false;
            this.LyDoChuyen.Width = 200;
            // 
            // SoLuongDiaChi
            // 
            this.SoLuongDiaChi.DataPropertyName = "SoLuongDiaChi";
            this.SoLuongDiaChi.HeaderText = "SL.Địa Chỉ";
            this.SoLuongDiaChi.Name = "SoLuongDiaChi";
            this.SoLuongDiaChi.Visible = false;
            this.SoLuongDiaChi.Width = 110;
            // 
            // NVKiemTra
            // 
            this.NVKiemTra.DataPropertyName = "NVKiemTra";
            this.NVKiemTra.HeaderText = "NV Kiểm Tra";
            this.NVKiemTra.Name = "NVKiemTra";
            this.NVKiemTra.Width = 200;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            dataGridViewCellStyle4.NullValue = null;
            this.MaDon.DefaultCellStyle = dataGridViewCellStyle4;
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
            this.MaDon.Width = 90;
            // 
            // MaLD
            // 
            this.MaLD.DataPropertyName = "MaLD";
            this.MaLD.HeaderText = "MaLD";
            this.MaLD.Name = "MaLD";
            this.MaLD.Visible = false;
            // 
            // TenLD
            // 
            this.TenLD.DataPropertyName = "TenLD";
            this.TenLD.HeaderText = "Tên Loại Đơn";
            this.TenLD.Name = "TenLD";
            this.TenLD.ReadOnly = true;
            this.TenLD.Width = 130;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Nhận";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 110;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            this.DanhBo.Width = 90;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 260;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 270;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 245;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "Người Nhận";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.ReadOnly = true;
            this.CreateBy.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nội Dung:";
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(448, 11);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(114, 21);
            this.txtNoiDungTimKiem.TabIndex = 6;
            this.txtNoiDungTimKiem.Visible = false;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Danh Bộ",
            "Số Công Văn",
            "Ngày",
            "Khoảng Thời Gian"});
            this.cmbTimTheo.Location = new System.Drawing.Point(254, 11);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(124, 23);
            this.cmbTimTheo.TabIndex = 4;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tìm Theo:";
            // 
            // dateTimKiem
            // 
            this.dateTimKiem.CustomFormat = "dd/MM/yyyy";
            this.dateTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimKiem.Location = new System.Drawing.Point(448, 31);
            this.dateTimKiem.Name = "dateTimKiem";
            this.dateTimKiem.Size = new System.Drawing.Size(114, 21);
            this.dateTimKiem.TabIndex = 7;
            this.dateTimKiem.Visible = false;
            this.dateTimKiem.ValueChanged += new System.EventHandler(this.dateTimKiem_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(74, 31);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(88, 21);
            this.dateDen.TabIndex = 14;
            this.dateDen.ValueChanged += new System.EventHandler(this.dateDen_ValueChanged);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(74, 4);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(88, 21);
            this.dateTu.TabIndex = 13;
            this.dateTu.ValueChanged += new System.EventHandler(this.dateTu_ValueChanged);
            // 
            // btnInDSDonKH
            // 
            this.btnInDSDonKH.Location = new System.Drawing.Point(673, 12);
            this.btnInDSDonKH.Name = "btnInDSDonKH";
            this.btnInDSDonKH.Size = new System.Drawing.Size(100, 23);
            this.btnInDSDonKH.TabIndex = 9;
            this.btnInDSDonKH.Text = "In Danh Sách";
            this.btnInDSDonKH.UseVisualStyleBackColor = true;
            this.btnInDSDonKH.Click += new System.EventHandler(this.btnInDSDonKH_Click);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(496, 1);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(168, 56);
            this.panel_KhoangThoiGian.TabIndex = 8;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // btnInChiTiet
            // 
            this.btnInChiTiet.Location = new System.Drawing.Point(991, 12);
            this.btnInChiTiet.Name = "btnInChiTiet";
            this.btnInChiTiet.Size = new System.Drawing.Size(100, 23);
            this.btnInChiTiet.TabIndex = 36;
            this.btnInChiTiet.Text = "In (Chi Tiết)";
            this.btnInChiTiet.UseVisualStyleBackColor = true;
            this.btnInChiTiet.Click += new System.EventHandler(this.btnInChiTiet_Click);
            // 
            // chkChuaKT
            // 
            this.chkChuaKT.AutoSize = true;
            this.chkChuaKT.Location = new System.Drawing.Point(788, 38);
            this.chkChuaKT.Name = "chkChuaKT";
            this.chkChuaKT.Size = new System.Drawing.Size(73, 19);
            this.chkChuaKT.TabIndex = 35;
            this.chkChuaKT.Text = "Chưa KT";
            this.chkChuaKT.UseVisualStyleBackColor = true;
            // 
            // btnInDSDonTXL
            // 
            this.btnInDSDonTXL.Location = new System.Drawing.Point(779, 12);
            this.btnInDSDonTXL.Name = "btnInDSDonTXL";
            this.btnInDSDonTXL.Size = new System.Drawing.Size(100, 23);
            this.btnInDSDonTXL.TabIndex = 34;
            this.btnInDSDonTXL.Text = "In (Ngày Giao)";
            this.btnInDSDonTXL.UseVisualStyleBackColor = true;
            this.btnInDSDonTXL.Click += new System.EventHandler(this.btnInDSDonTXL_Click);
            // 
            // btnGiaoTXL
            // 
            this.btnGiaoTXL.Location = new System.Drawing.Point(885, 12);
            this.btnGiaoTXL.Name = "btnGiaoTXL";
            this.btnGiaoTXL.Size = new System.Drawing.Size(100, 23);
            this.btnGiaoTXL.TabIndex = 37;
            this.btnGiaoTXL.Text = "In (Giao TXL)";
            this.btnGiaoTXL.UseVisualStyleBackColor = true;
            this.btnGiaoTXL.Click += new System.EventHandler(this.btnGiaoTXL_Click);
            // 
            // txtNoiDungTimKiem2
            // 
            this.txtNoiDungTimKiem2.Location = new System.Drawing.Point(448, 33);
            this.txtNoiDungTimKiem2.Name = "txtNoiDungTimKiem2";
            this.txtNoiDungTimKiem2.Size = new System.Drawing.Size(114, 21);
            this.txtNoiDungTimKiem2.TabIndex = 38;
            this.txtNoiDungTimKiem2.Visible = false;
            this.txtNoiDungTimKiem2.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem2_TextChanged);
            // 
            // frmDSDonKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1199, 496);
            this.Controls.Add(this.txtNoiDungTimKiem2);
            this.Controls.Add(this.btnGiaoTXL);
            this.Controls.Add(this.btnInChiTiet);
            this.Controls.Add(this.chkChuaKT);
            this.Controls.Add(this.btnInDSDonTXL);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.btnInDSDonKH);
            this.Controls.Add(this.dateTimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDSDonKH);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDSDonKH";
            this.Text = "Danh Sách Đơn Khách Hàng";
            this.Load += new System.EventHandler(this.frmQLDonKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDonKH)).EndInit();
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSDonKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimKiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Button btnInDSDonKH;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.Button btnInChiTiet;
        private System.Windows.Forms.CheckBox chkChuaKT;
        private System.Windows.Forms.Button btnInDSDonTXL;
        private System.Windows.Forms.Button btnGiaoTXL;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem2;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NVKiemTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;


    }
}