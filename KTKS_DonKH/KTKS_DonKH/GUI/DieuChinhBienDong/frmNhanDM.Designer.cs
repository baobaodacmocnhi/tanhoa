﻿namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmNhanDM
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
            this.cmbLoaiCT = new System.Windows.Forms.ComboBox();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSoNKNhan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaCT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiaChi_Cat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen_Cat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo_Cat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoNKTong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiaChiCT_Cat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiaChi_Nhan = new System.Windows.Forms.TextBox();
            this.txtDanhBo_Nhan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtHoTen_Nhan = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtLo = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtThoiHan = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbLoaiCT
            // 
            this.cmbLoaiCT.FormattingEnabled = true;
            this.cmbLoaiCT.Location = new System.Drawing.Point(111, 131);
            this.cmbLoaiCT.Name = "cmbLoaiCT";
            this.cmbLoaiCT.Size = new System.Drawing.Size(176, 23);
            this.cmbLoaiCT.TabIndex = 9;
            this.cmbLoaiCT.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiCT_SelectedIndexChanged);
            this.cmbLoaiCT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbLoaiCT_KeyPress);
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(111, 21);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(254, 23);
            this.cmbChiNhanh.TabIndex = 1;
            this.cmbChiNhanh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbChiNhanh_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Nơi Cắt/Chuyển:";
            // 
            // txtSoNKNhan
            // 
            this.txtSoNKNhan.Location = new System.Drawing.Point(277, 213);
            this.txtSoNKNhan.Name = "txtSoNKNhan";
            this.txtSoNKNhan.Size = new System.Drawing.Size(88, 21);
            this.txtSoNKNhan.TabIndex = 19;
            this.txtSoNKNhan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoNKNhan_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Số NK Nhận:";
            // 
            // txtMaCT
            // 
            this.txtMaCT.Location = new System.Drawing.Point(111, 158);
            this.txtMaCT.Name = "txtMaCT";
            this.txtMaCT.Size = new System.Drawing.Size(88, 21);
            this.txtMaCT.TabIndex = 11;
            this.txtMaCT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaCT_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Số Chứng Từ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Loại Chứng Từ:";
            // 
            // txtDiaChi_Cat
            // 
            this.txtDiaChi_Cat.Location = new System.Drawing.Point(111, 103);
            this.txtDiaChi_Cat.Name = "txtDiaChi_Cat";
            this.txtDiaChi_Cat.Size = new System.Drawing.Size(254, 21);
            this.txtDiaChi_Cat.TabIndex = 7;
            this.txtDiaChi_Cat.TextChanged += new System.EventHandler(this.txtDiaChi_Cat_TextChanged);
            this.txtDiaChi_Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaChi_Cat_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Địa Chỉ KH:";
            // 
            // txtHoTen_Cat
            // 
            this.txtHoTen_Cat.Location = new System.Drawing.Point(111, 76);
            this.txtHoTen_Cat.Name = "txtHoTen_Cat";
            this.txtHoTen_Cat.Size = new System.Drawing.Size(254, 21);
            this.txtHoTen_Cat.TabIndex = 5;
            this.txtHoTen_Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoTen_Cat_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Khách Hàng:";
            // 
            // txtDanhBo_Cat
            // 
            this.txtDanhBo_Cat.Location = new System.Drawing.Point(111, 49);
            this.txtDanhBo_Cat.Name = "txtDanhBo_Cat";
            this.txtDanhBo_Cat.Size = new System.Drawing.Size(88, 21);
            this.txtDanhBo_Cat.TabIndex = 3;
            this.txtDanhBo_Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_Cat_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh Bộ:";
            // 
            // txtSoNKTong
            // 
            this.txtSoNKTong.Location = new System.Drawing.Point(111, 213);
            this.txtSoNKTong.Name = "txtSoNKTong";
            this.txtSoNKTong.Size = new System.Drawing.Size(88, 21);
            this.txtSoNKTong.TabIndex = 17;
            this.txtSoNKTong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoNKTong_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tổng Số NK:";
            // 
            // txtDiaChiCT_Cat
            // 
            this.txtDiaChiCT_Cat.Location = new System.Drawing.Point(111, 185);
            this.txtDiaChiCT_Cat.Name = "txtDiaChiCT_Cat";
            this.txtDiaChiCT_Cat.Size = new System.Drawing.Size(254, 21);
            this.txtDiaChiCT_Cat.TabIndex = 15;
            this.txtDiaChiCT_Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaChiCT_Cat_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Địa Chỉ Sổ:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiaChi_Nhan);
            this.groupBox1.Controls.Add(this.txtDanhBo_Nhan);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtHoTen_Nhan);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nơi Nhận";
            // 
            // txtDiaChi_Nhan
            // 
            this.txtDiaChi_Nhan.Location = new System.Drawing.Point(110, 76);
            this.txtDiaChi_Nhan.Name = "txtDiaChi_Nhan";
            this.txtDiaChi_Nhan.Size = new System.Drawing.Size(254, 21);
            this.txtDiaChi_Nhan.TabIndex = 5;
            // 
            // txtDanhBo_Nhan
            // 
            this.txtDanhBo_Nhan.Location = new System.Drawing.Point(110, 21);
            this.txtDanhBo_Nhan.Name = "txtDanhBo_Nhan";
            this.txtDanhBo_Nhan.Size = new System.Drawing.Size(88, 21);
            this.txtDanhBo_Nhan.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Địa Chỉ:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Danh Bộ:";
            // 
            // txtHoTen_Nhan
            // 
            this.txtHoTen_Nhan.Location = new System.Drawing.Point(110, 49);
            this.txtHoTen_Nhan.Name = "txtHoTen_Nhan";
            this.txtHoTen_Nhan.Size = new System.Drawing.Size(254, 21);
            this.txtHoTen_Nhan.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Khách Hàng:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPhong);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.txtLo);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.txtGhiChu);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtThoiHan);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmbChiNhanh);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtDiaChiCT_Cat);
            this.groupBox2.Controls.Add(this.txtDanhBo_Cat);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtSoNKTong);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtHoTen_Cat);
            this.groupBox2.Controls.Add(this.cmbLoaiCT);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtSoNKNhan);
            this.groupBox2.Controls.Add(this.txtDiaChi_Cat);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMaCT);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(391, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 326);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nơi Cắt/Chuyển:";
            // 
            // txtPhong
            // 
            this.txtPhong.Location = new System.Drawing.Point(111, 295);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(170, 21);
            this.txtPhong.TabIndex = 34;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(12, 297);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(46, 15);
            this.label35.TabIndex = 33;
            this.label35.Text = "Phòng:";
            // 
            // txtLo
            // 
            this.txtLo.Location = new System.Drawing.Point(111, 267);
            this.txtLo.Name = "txtLo";
            this.txtLo.Size = new System.Drawing.Size(170, 21);
            this.txtLo.TabIndex = 32;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(12, 270);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(24, 15);
            this.label34.TabIndex = 31;
            this.label34.Text = "Lô:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(111, 240);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(254, 21);
            this.txtGhiChu.TabIndex = 21;
            this.txtGhiChu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGhiChu_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 15);
            this.label14.TabIndex = 20;
            this.label14.Text = "Ghi Chú:";
            // 
            // txtThoiHan
            // 
            this.txtThoiHan.Location = new System.Drawing.Point(277, 158);
            this.txtThoiHan.Name = "txtThoiHan";
            this.txtThoiHan.Size = new System.Drawing.Size(88, 21);
            this.txtThoiHan.TabIndex = 13;
            this.txtThoiHan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThoiHan_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Thời Hạn:";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(692, 344);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmNhanDM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(779, 384);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNhanDM";
            this.Text = "Tiếp Nhận Định Mức";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhanDM_FormClosing);
            this.Load += new System.EventHandler(this.frmNhanDM_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLoaiCT;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSoNKNhan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaCT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiaChi_Cat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen_Cat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo_Cat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoNKTong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiaChiCT_Cat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDiaChi_Nhan;
        private System.Windows.Forms.TextBox txtDanhBo_Nhan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtHoTen_Nhan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtThoiHan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtLo;
        private System.Windows.Forms.Label label34;
    }
}