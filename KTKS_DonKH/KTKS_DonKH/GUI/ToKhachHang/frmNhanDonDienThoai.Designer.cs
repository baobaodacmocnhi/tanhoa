﻿namespace KTKS_DonKH.GUI.ToKhachHang
{
    partial class frmNhanDonDienThoai
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
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNguoiBao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvLichSuDonDT = new System.Windows.Forms.DataGridView();
            this.MaDonDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiBao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dateBao = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbNoiDung = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuDonDT)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(106, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(132, 22);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(106, 40);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(316, 22);
            this.txtHoTen.TabIndex = 3;
            this.txtHoTen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoTen_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Khách Hàng:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(106, 68);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(316, 22);
            this.txtDiaChi.TabIndex = 5;
            this.txtDiaChi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaChi_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Địa Chỉ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 99);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nội Dung:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(106, 126);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(316, 22);
            this.txtGhiChu.TabIndex = 9;
            this.txtGhiChu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGhiChu_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ghi Chú:";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(106, 154);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(316, 22);
            this.txtDienThoai.TabIndex = 11;
            this.txtDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDienThoai_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 157);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Điện Thoại:";
            // 
            // txtNguoiBao
            // 
            this.txtNguoiBao.Location = new System.Drawing.Point(106, 182);
            this.txtNguoiBao.Name = "txtNguoiBao";
            this.txtNguoiBao.Size = new System.Drawing.Size(316, 22);
            this.txtNguoiBao.TabIndex = 13;
            this.txtNguoiBao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNguoiBao_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 185);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Người Báo:";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(428, 181);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvLichSuDonDT
            // 
            this.dgvLichSuDonDT.AllowUserToAddRows = false;
            this.dgvLichSuDonDT.AllowUserToDeleteRows = false;
            this.dgvLichSuDonDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuDonDT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDonDT,
            this.MaDon,
            this.CreateDate,
            this.NoiDung,
            this.GhiChu,
            this.NguoiBao,
            this.NgayBao,
            this.HoTen,
            this.DiaChi,
            this.DienThoai});
            this.dgvLichSuDonDT.Location = new System.Drawing.Point(12, 210);
            this.dgvLichSuDonDT.Name = "dgvLichSuDonDT";
            this.dgvLichSuDonDT.ReadOnly = true;
            this.dgvLichSuDonDT.Size = new System.Drawing.Size(883, 292);
            this.dgvLichSuDonDT.TabIndex = 17;
            this.dgvLichSuDonDT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichSuDonDT_CellContentClick);
            this.dgvLichSuDonDT.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLichSuDonDT_CellFormatting);
            this.dgvLichSuDonDT.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLichSuDonDT_RowPostPaint);
            // 
            // MaDonDT
            // 
            this.MaDonDT.DataPropertyName = "MaDonDT";
            this.MaDonDT.HeaderText = "MaDonDT";
            this.MaDonDT.Name = "MaDonDT";
            this.MaDonDT.ReadOnly = true;
            this.MaDonDT.Visible = false;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Nhận";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 120;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 200;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            this.GhiChu.Width = 200;
            // 
            // NguoiBao
            // 
            this.NguoiBao.DataPropertyName = "NguoiBao";
            this.NguoiBao.HeaderText = "Người Báo";
            this.NguoiBao.Name = "NguoiBao";
            this.NguoiBao.ReadOnly = true;
            // 
            // NgayBao
            // 
            this.NgayBao.DataPropertyName = "NgayBao";
            this.NgayBao.HeaderText = "Ngày Báo";
            this.NgayBao.Name = "NgayBao";
            this.NgayBao.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "HoTen";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Visible = false;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "DiaChi";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Visible = false;
            // 
            // DienThoai
            // 
            this.DienThoai.DataPropertyName = "DienThoai";
            this.DienThoai.HeaderText = "DienThoai";
            this.DienThoai.Name = "DienThoai";
            this.DienThoai.ReadOnly = true;
            this.DienThoai.Visible = false;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(509, 181);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(590, 181);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dateBao
            // 
            this.dateBao.CustomFormat = "dd/MM/yyyy";
            this.dateBao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBao.Location = new System.Drawing.Point(322, 12);
            this.dateBao.Name = "dateBao";
            this.dateBao.Size = new System.Drawing.Size(100, 22);
            this.dateBao.TabIndex = 19;
            this.dateBao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateBao_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(244, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Ngày Báo:";
            // 
            // cmbNoiDung
            // 
            this.cmbNoiDung.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbNoiDung.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNoiDung.FormattingEnabled = true;
            this.cmbNoiDung.Items.AddRange(new object[] {
            "Kiểm tra ĐHN",
            "Mất ĐHN",
            "ĐHN bị ngưng",
            "Đứt chì góc/mặt số",
            "Bể/mất nắp hộp bảo vệ",
            "Khiếu nại TN/GB",
            "Tái lập DB",
            "Bị khóa nước",
            "Tạm ngưng SD nước"});
            this.cmbNoiDung.Location = new System.Drawing.Point(106, 96);
            this.cmbNoiDung.Name = "cmbNoiDung";
            this.cmbNoiDung.Size = new System.Drawing.Size(200, 24);
            this.cmbNoiDung.TabIndex = 7;
            // 
            // frmNhanDonDienThoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(913, 528);
            this.Controls.Add(this.cmbNoiDung);
            this.Controls.Add(this.dateBao);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.dgvLichSuDonDT);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtNguoiBao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmNhanDonDienThoai";
            this.Text = "Nhận Đơn Điện Thoại";
            this.Load += new System.EventHandler(this.frmNhanDonDienThoai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuDonDT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNguoiBao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvLichSuDonDT;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DateTimePicker dateBao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDonDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiBao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBao;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
        private System.Windows.Forms.ComboBox cmbNoiDung;
    }
}