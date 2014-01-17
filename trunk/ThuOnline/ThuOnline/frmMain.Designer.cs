namespace ThuOnline
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKey = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dateDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.dgvDSThuOnline = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_NoiDung = new System.Windows.Forms.GroupBox();
            this.groupBox_ThoiGian = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongCong = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSThuOnline)).BeginInit();
            this.groupBox_NoiDung.SuspendLayout();
            this.groupBox_ThoiGian.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm Theo:";
            // 
            // cmbKey
            // 
            this.cmbKey.FormattingEnabled = true;
            this.cmbKey.Items.AddRange(new object[] {
            "==?==",
            "Số Hóa Đơn",
            "Ngày",
            "Tháng",
            "Khoảng Thời Gian"});
            this.cmbKey.Location = new System.Drawing.Point(215, 12);
            this.cmbKey.Name = "cmbKey";
            this.cmbKey.Size = new System.Drawing.Size(141, 25);
            this.cmbKey.TabIndex = 1;
            this.cmbKey.SelectedIndexChanged += new System.EventHandler(this.cmbKey_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ Ngày:";
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dateTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTuNgay.Location = new System.Drawing.Point(80, 22);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Size = new System.Drawing.Size(105, 25);
            this.dateTuNgay.TabIndex = 3;
            this.dateTuNgay.ValueChanged += new System.EventHandler(this.dateTuNgay_ValueChanged);
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dateDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDenNgay.Location = new System.Drawing.Point(269, 22);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Size = new System.Drawing.Size(105, 25);
            this.dateDenNgay.TabIndex = 5;
            this.dateDenNgay.Visible = false;
            this.dateDenNgay.ValueChanged += new System.EventHandler(this.dateDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đến Ngày:";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nội Dung:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(84, 22);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(105, 25);
            this.txtNoiDung.TabIndex = 7;
            this.txtNoiDung.TextChanged += new System.EventHandler(this.txtNoiDung_TextChanged);
            // 
            // dgvDSThuOnline
            // 
            this.dgvDSThuOnline.AllowUserToAddRows = false;
            this.dgvDSThuOnline.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSThuOnline.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSThuOnline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSThuOnline.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.Dot,
            this.Ky,
            this.Nam,
            this.TongTien,
            this.SoHoaDon,
            this.NgayThanhToan});
            this.dgvDSThuOnline.Location = new System.Drawing.Point(0, 56);
            this.dgvDSThuOnline.Name = "dgvDSThuOnline";
            this.dgvDSThuOnline.Size = new System.Drawing.Size(1145, 451);
            this.dgvDSThuOnline.TabIndex = 8;
            this.dgvDSThuOnline.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSThuOnline_CellFormatting);
            this.dgvDSThuOnline.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSThuOnline_RowPostPaint);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
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
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 250;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 300;
            // 
            // Dot
            // 
            this.Dot.DataPropertyName = "Dot";
            this.Dot.HeaderText = "Đợt";
            this.Dot.Name = "Dot";
            this.Dot.Width = 50;
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
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.HeaderText = "Tổng Tiền";
            this.TongTien.Name = "TongTien";
            // 
            // SoHoaDon
            // 
            this.SoHoaDon.DataPropertyName = "SoHoaDon";
            this.SoHoaDon.HeaderText = "Số Hóa Đơn";
            this.SoHoaDon.Name = "SoHoaDon";
            this.SoHoaDon.Width = 90;
            // 
            // NgayThanhToan
            // 
            this.NgayThanhToan.DataPropertyName = "NgayThanhToan";
            this.NgayThanhToan.HeaderText = "Ngày Thanh Toán";
            this.NgayThanhToan.Name = "NgayThanhToan";
            this.NgayThanhToan.Width = 110;
            // 
            // groupBox_NoiDung
            // 
            this.groupBox_NoiDung.Controls.Add(this.txtNoiDung);
            this.groupBox_NoiDung.Controls.Add(this.label4);
            this.groupBox_NoiDung.Location = new System.Drawing.Point(362, -10);
            this.groupBox_NoiDung.Name = "groupBox_NoiDung";
            this.groupBox_NoiDung.Size = new System.Drawing.Size(204, 60);
            this.groupBox_NoiDung.TabIndex = 9;
            this.groupBox_NoiDung.TabStop = false;
            this.groupBox_NoiDung.Visible = false;
            // 
            // groupBox_ThoiGian
            // 
            this.groupBox_ThoiGian.Controls.Add(this.dateDenNgay);
            this.groupBox_ThoiGian.Controls.Add(this.label2);
            this.groupBox_ThoiGian.Controls.Add(this.dateTuNgay);
            this.groupBox_ThoiGian.Controls.Add(this.label3);
            this.groupBox_ThoiGian.Location = new System.Drawing.Point(572, -10);
            this.groupBox_ThoiGian.Name = "groupBox_ThoiGian";
            this.groupBox_ThoiGian.Size = new System.Drawing.Size(382, 60);
            this.groupBox_ThoiGian.TabIndex = 10;
            this.groupBox_ThoiGian.TabStop = false;
            this.groupBox_ThoiGian.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(749, 521);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tổng Cộng:";
            // 
            // txtTongCong
            // 
            this.txtTongCong.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong.ForeColor = System.Drawing.Color.Red;
            this.txtTongCong.Location = new System.Drawing.Point(841, 513);
            this.txtTongCong.Name = "txtTongCong";
            this.txtTongCong.Size = new System.Drawing.Size(150, 25);
            this.txtTongCong.TabIndex = 12;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1147, 550);
            this.Controls.Add(this.txtTongCong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox_ThoiGian);
            this.Controls.Add(this.groupBox_NoiDung);
            this.Controls.Add(this.dgvDSThuOnline);
            this.Controls.Add(this.cmbKey);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Quản Lý Thu Online";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSThuOnline)).EndInit();
            this.groupBox_NoiDung.ResumeLayout(false);
            this.groupBox_NoiDung.PerformLayout();
            this.groupBox_ThoiGian.ResumeLayout(false);
            this.groupBox_ThoiGian.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTuNgay;
        private System.Windows.Forms.DateTimePicker dateDenNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.DataGridView dgvDSThuOnline;
        private System.Windows.Forms.GroupBox groupBox_NoiDung;
        private System.Windows.Forms.GroupBox groupBox_ThoiGian;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThanhToan;
    }
}

