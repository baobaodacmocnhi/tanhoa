﻿namespace KTKS_DonKH.GUI.ThuTraLoi
{
    partial class frmDSTTTL
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInNhan = new System.Windows.Forms.Button();
            this.dgvDSThu = new System.Windows.Forms.DataGridView();
            this.txtNoiDungTimKiem2 = new System.Windows.Forms.TextBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.In = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ThuDuocKy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TraTrinhKy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaCTTTTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VeViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_KhoangThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSThu)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tìm Theo:";
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Mã Thư",
            "Danh Bộ",
            "Ngày"});
            this.cmbTimTheo.Location = new System.Drawing.Point(254, 15);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(100, 24);
            this.cmbTimTheo.TabIndex = 3;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(434, 15);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem.TabIndex = 5;
            this.txtNoiDungTimKiem.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nội Dung:";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.ForeColor = System.Drawing.Color.Red;
            this.chkSelectAll.Location = new System.Drawing.Point(72, 42);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(80, 20);
            this.chkSelectAll.TabIndex = 9;
            this.chkSelectAll.Text = "In Tất Cả";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(695, 18);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 25);
            this.btnIn.TabIndex = 7;
            this.btnIn.Text = "In Thư";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(433, 3);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(175, 59);
            this.panel_KhoangThoiGian.TabIndex = 24;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(80, 5);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 13;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(80, 33);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // btnInNhan
            // 
            this.btnInNhan.Location = new System.Drawing.Point(776, 18);
            this.btnInNhan.Name = "btnInNhan";
            this.btnInNhan.Size = new System.Drawing.Size(75, 25);
            this.btnInNhan.TabIndex = 27;
            this.btnInNhan.Text = "In Nhãn";
            this.btnInNhan.UseVisualStyleBackColor = true;
            this.btnInNhan.Click += new System.EventHandler(this.btnInNhan_Click);
            // 
            // dgvDSThu
            // 
            this.dgvDSThu.AllowUserToAddRows = false;
            this.dgvDSThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In,
            this.ThuDuocKy,
            this.TraTrinhKy,
            this.MaCTTTTL,
            this.CreateDate,
            this.MaDon,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.VeViec,
            this.NoiDung,
            this.NoiNhan});
            this.dgvDSThu.Location = new System.Drawing.Point(12, 68);
            this.dgvDSThu.Name = "dgvDSThu";
            this.dgvDSThu.RowHeadersWidth = 60;
            this.dgvDSThu.Size = new System.Drawing.Size(1311, 540);
            this.dgvDSThu.TabIndex = 11;
            this.dgvDSThu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSThu_CellFormatting);
            this.dgvDSThu.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDSThu_CellValidating);
            this.dgvDSThu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSThu_RowPostPaint);
            this.dgvDSThu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSThu_KeyDown);
            // 
            // txtNoiDungTimKiem2
            // 
            this.txtNoiDungTimKiem2.Location = new System.Drawing.Point(434, 37);
            this.txtNoiDungTimKiem2.Name = "txtNoiDungTimKiem2";
            this.txtNoiDungTimKiem2.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem2.TabIndex = 28;
            this.txtNoiDungTimKiem2.Visible = false;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(614, 18);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 25);
            this.btnXem.TabIndex = 29;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // In
            // 
            this.In.DataPropertyName = "In";
            this.In.FalseValue = "False";
            this.In.HeaderText = "In";
            this.In.Name = "In";
            this.In.TrueValue = "True";
            this.In.Width = 30;
            // 
            // ThuDuocKy
            // 
            this.ThuDuocKy.DataPropertyName = "ThuDuocKy";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.NullValue = false;
            this.ThuDuocKy.DefaultCellStyle = dataGridViewCellStyle2;
            this.ThuDuocKy.HeaderText = "Được Ký";
            this.ThuDuocKy.Name = "ThuDuocKy";
            this.ThuDuocKy.Width = 50;
            // 
            // TraTrinhKy
            // 
            this.TraTrinhKy.DataPropertyName = "TraTrinhKy";
            this.TraTrinhKy.HeaderText = "Trả Trình Ký";
            this.TraTrinhKy.Name = "TraTrinhKy";
            this.TraTrinhKy.Width = 50;
            // 
            // MaCTTTTL
            // 
            this.MaCTTTTL.DataPropertyName = "MaCTTTTL";
            this.MaCTTTTL.HeaderText = "Mã Thư";
            this.MaCTTTTL.Name = "MaCTTTTL";
            this.MaCTTTTL.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 200;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // VeViec
            // 
            this.VeViec.DataPropertyName = "VeViec";
            this.VeViec.HeaderText = "Về Việc";
            this.VeViec.Name = "VeViec";
            this.VeViec.ReadOnly = true;
            this.VeViec.Width = 150;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 200;
            // 
            // NoiNhan
            // 
            this.NoiNhan.DataPropertyName = "NoiNhan";
            this.NoiNhan.HeaderText = "Nơi Nhận";
            this.NoiNhan.Name = "NoiNhan";
            this.NoiNhan.ReadOnly = true;
            // 
            // frmDSTTTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1331, 631);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnInNhan);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.dgvDSThu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoiDungTimKiem2);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmDSTTTL";
            this.Text = "Danh Sách Thảo Thư Trả Lời";
            this.Load += new System.EventHandler(this.frmDSTTTL_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInNhan;
        private System.Windows.Forms.DataGridView dgvDSThu;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem2;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn In;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ThuDuocKy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TraTrinhKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTTTTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn VeViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiNhan;
    }
}