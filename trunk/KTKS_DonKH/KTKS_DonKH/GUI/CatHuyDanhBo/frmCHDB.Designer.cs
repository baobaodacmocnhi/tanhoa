namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    partial class frmCHDB
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
            this.btnLuu = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtThoiGianLapCatHuy = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.dateNgayCat = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHieuLucKy = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.cmbLyDo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHopDong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::KTKS_DonKH.Properties.Resources.save_24x24;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(747, 324);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(70, 35);
            this.btnLuu.TabIndex = 32;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ghi Chú:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(248, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "Số Tháng Lập Phiếu(tháng):";
            // 
            // txtThoiGianLapCatHuy
            // 
            this.txtThoiGianLapCatHuy.Location = new System.Drawing.Point(427, 24);
            this.txtThoiGianLapCatHuy.Name = "txtThoiGianLapCatHuy";
            this.txtThoiGianLapCatHuy.Size = new System.Drawing.Size(58, 25);
            this.txtThoiGianLapCatHuy.TabIndex = 11;
            this.txtThoiGianLapCatHuy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThoiGianLapCatHuy_KeyPress);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(73, 55);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(412, 25);
            this.txtGhiChu.TabIndex = 3;
            // 
            // dateNgayCat
            // 
            this.dateNgayCat.CustomFormat = "dd/MM/yyyy";
            this.dateNgayCat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayCat.Location = new System.Drawing.Point(99, 24);
            this.dateNgayCat.Name = "dateNgayCat";
            this.dateNgayCat.Size = new System.Drawing.Size(109, 25);
            this.dateNgayCat.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Lý Do:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtHieuLucKy);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtThoiGianLapCatHuy);
            this.groupBox3.Controls.Add(this.dateNgayCat);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtKetQua);
            this.groupBox3.Location = new System.Drawing.Point(12, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(805, 95);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kết Quả Xử Lý";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(494, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "Hiệu Lực Kỳ:";
            // 
            // txtHieuLucKy
            // 
            this.txtHieuLucKy.Location = new System.Drawing.Point(589, 24);
            this.txtHieuLucKy.Name = "txtHieuLucKy";
            this.txtHieuLucKy.Size = new System.Drawing.Size(100, 25);
            this.txtHieuLucKy.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Ngày Xử Lý:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Kết Quả:";
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(99, 55);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(386, 25);
            this.txtKetQua.TabIndex = 7;
            // 
            // cmbLyDo
            // 
            this.cmbLyDo.FormattingEnabled = true;
            this.cmbLyDo.Items.AddRange(new object[] {
            "Theo Yêu Cầu Khách Hàng",
            "Theo Yêu Cầu Công Ty",
            "Nợ Tiền Nước",
            "Nợ Tiền Bồi Thường ĐHN",
            "Nợ Tiền Gian Lận Nước",
            "Vấn Đề Khác"});
            this.cmbLyDo.Location = new System.Drawing.Point(73, 24);
            this.cmbLyDo.Name = "cmbLyDo";
            this.cmbLyDo.Size = new System.Drawing.Size(240, 25);
            this.cmbLyDo.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(324, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Số Tiền:";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(385, 24);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(100, 25);
            this.txtSoTien.TabIndex = 5;
            this.txtSoTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTien_KeyPress);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(429, 43);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(365, 25);
            this.txtDiaChi.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Địa Chỉ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSoTien);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtGhiChu);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbLyDo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(805, 94);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nguyên Nhân Xử Lý";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(230, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 17);
            this.label21.TabIndex = 33;
            this.label21.Text = "Mã Đơn:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(223, 43);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(200, 25);
            this.txtHoTen.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHopDong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDanhBo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(805, 80);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Khách Hàng";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(117, 43);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.ReadOnly = true;
            this.txtHopDong.Size = new System.Drawing.Size(100, 25);
            this.txtHopDong.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Hợp Đồng";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(11, 43);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.ReadOnly = true;
            this.txtDanhBo.Size = new System.Drawing.Size(100, 25);
            this.txtDanhBo.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Danh Bộ";
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(297, 6);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.ReadOnly = true;
            this.txtMaDon.Size = new System.Drawing.Size(100, 25);
            this.txtMaDon.TabIndex = 34;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Image = global::KTKS_DonKH.Properties.Resources.save_24x24;
            this.btnInPhieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInPhieu.Location = new System.Drawing.Point(649, 324);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(92, 35);
            this.btnInPhieu.TabIndex = 38;
            this.btnInPhieu.Text = "In Phiếu";
            this.btnInPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInPhieu.UseVisualStyleBackColor = true;
            // 
            // frmCHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(827, 370);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMaDon);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCHDB";
            this.Text = "Cắt Hủy Danh Bộ";
            this.Load += new System.EventHandler(this.frmCHDB_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtThoiGianLapCatHuy;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.DateTimePicker dateNgayCat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHieuLucKy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.ComboBox cmbLyDo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHopDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Button btnInPhieu;
    }
}