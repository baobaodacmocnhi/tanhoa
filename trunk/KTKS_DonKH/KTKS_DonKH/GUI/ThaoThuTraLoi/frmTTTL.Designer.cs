﻿namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    partial class frmTTTL
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
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLoTrinh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDinhMuc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGiaBieu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHopDong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkThuBao = new System.Windows.Forms.CheckBox();
            this.chkThuMoi = new System.Windows.Forms.CheckBox();
            this.chkDieuChinh_GB_DM = new System.Windows.Forms.CheckBox();
            this.chkThayDHN = new System.Windows.Forms.CheckBox();
            this.chkKiemDinhDHN_Dung = new System.Windows.Forms.CheckBox();
            this.chkKiemDinhDHN_Sai = new System.Windows.Forms.CheckBox();
            this.chkGiamNuocXaBo = new System.Windows.Forms.CheckBox();
            this.txtNoiNhan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtVeViec = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvLichSuTTTL = new System.Windows.Forms.DataGridView();
            this.MaCTTTTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VeViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbVeViec = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuTTTL)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(409, 8);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.ReadOnly = true;
            this.txtMaDon.Size = new System.Drawing.Size(100, 25);
            this.txtMaDon.TabIndex = 1;
            this.txtMaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDon_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(342, 11);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 17);
            this.label21.TabIndex = 0;
            this.label21.Text = "Mã Đơn:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLoTrinh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDinhMuc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGiaBieu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHopDong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDanhBo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1097, 93);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // txtLoTrinh
            // 
            this.txtLoTrinh.Location = new System.Drawing.Point(428, 24);
            this.txtLoTrinh.Name = "txtLoTrinh";
            this.txtLoTrinh.Size = new System.Drawing.Size(100, 25);
            this.txtLoTrinh.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Lộ Trình:";
            // 
            // txtDinhMuc
            // 
            this.txtDinhMuc.Location = new System.Drawing.Point(720, 24);
            this.txtDinhMuc.Name = "txtDinhMuc";
            this.txtDinhMuc.Size = new System.Drawing.Size(35, 25);
            this.txtDinhMuc.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(643, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Định Mức:";
            // 
            // txtGiaBieu
            // 
            this.txtGiaBieu.Location = new System.Drawing.Point(602, 24);
            this.txtGiaBieu.Name = "txtGiaBieu";
            this.txtGiaBieu.Size = new System.Drawing.Size(35, 25);
            this.txtGiaBieu.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(534, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Giá Biểu:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(423, 55);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(558, 25);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa Chỉ:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(98, 55);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(260, 25);
            this.txtHoTen.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách Hàng:";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(258, 24);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.Size = new System.Drawing.Size(100, 25);
            this.txtHopDong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hợp Đồng:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(76, 24);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 25);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkThuBao);
            this.groupBox2.Controls.Add(this.chkThuMoi);
            this.groupBox2.Controls.Add(this.chkDieuChinh_GB_DM);
            this.groupBox2.Controls.Add(this.chkThayDHN);
            this.groupBox2.Controls.Add(this.chkKiemDinhDHN_Dung);
            this.groupBox2.Controls.Add(this.chkKiemDinhDHN_Sai);
            this.groupBox2.Controls.Add(this.chkGiamNuocXaBo);
            this.groupBox2.Controls.Add(this.txtNoiNhan);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtNoiDung);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtVeViec);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1097, 320);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nội Dung Thư";
            // 
            // chkThuBao
            // 
            this.chkThuBao.AutoSize = true;
            this.chkThuBao.Location = new System.Drawing.Point(895, 288);
            this.chkThuBao.Name = "chkThuBao";
            this.chkThuBao.Size = new System.Drawing.Size(67, 17);
            this.chkThuBao.TabIndex = 12;
            this.chkThuBao.Text = "Thư Báo";
            this.chkThuBao.UseVisualStyleBackColor = true;
            // 
            // chkThuMoi
            // 
            this.chkThuMoi.AutoSize = true;
            this.chkThuMoi.Location = new System.Drawing.Point(895, 261);
            this.chkThuMoi.Name = "chkThuMoi";
            this.chkThuMoi.Size = new System.Drawing.Size(65, 17);
            this.chkThuMoi.TabIndex = 11;
            this.chkThuMoi.Text = "Thư Mời";
            this.chkThuMoi.UseVisualStyleBackColor = true;
            // 
            // chkDieuChinh_GB_DM
            // 
            this.chkDieuChinh_GB_DM.AutoSize = true;
            this.chkDieuChinh_GB_DM.Location = new System.Drawing.Point(895, 192);
            this.chkDieuChinh_GB_DM.Name = "chkDieuChinh_GB_DM";
            this.chkDieuChinh_GB_DM.Size = new System.Drawing.Size(116, 17);
            this.chkDieuChinh_GB_DM.TabIndex = 10;
            this.chkDieuChinh_GB_DM.Text = "Điều Chỉnh GB-ĐM";
            this.chkDieuChinh_GB_DM.UseVisualStyleBackColor = true;
            // 
            // chkThayDHN
            // 
            this.chkThayDHN.AutoSize = true;
            this.chkThayDHN.Location = new System.Drawing.Point(895, 165);
            this.chkThayDHN.Name = "chkThayDHN";
            this.chkThayDHN.Size = new System.Drawing.Size(77, 17);
            this.chkThayDHN.TabIndex = 9;
            this.chkThayDHN.Text = "Thay ĐHN";
            this.chkThayDHN.UseVisualStyleBackColor = true;
            // 
            // chkKiemDinhDHN_Dung
            // 
            this.chkKiemDinhDHN_Dung.AutoSize = true;
            this.chkKiemDinhDHN_Dung.Location = new System.Drawing.Point(895, 138);
            this.chkKiemDinhDHN_Dung.Name = "chkKiemDinhDHN_Dung";
            this.chkKiemDinhDHN_Dung.Size = new System.Drawing.Size(145, 17);
            this.chkKiemDinhDHN_Dung.TabIndex = 8;
            this.chkKiemDinhDHN_Dung.Text = "Thử Kiểm Định ĐHN (sai)";
            this.chkKiemDinhDHN_Dung.UseVisualStyleBackColor = true;
            // 
            // chkKiemDinhDHN_Sai
            // 
            this.chkKiemDinhDHN_Sai.AutoSize = true;
            this.chkKiemDinhDHN_Sai.Location = new System.Drawing.Point(895, 111);
            this.chkKiemDinhDHN_Sai.Name = "chkKiemDinhDHN_Sai";
            this.chkKiemDinhDHN_Sai.Size = new System.Drawing.Size(157, 17);
            this.chkKiemDinhDHN_Sai.TabIndex = 7;
            this.chkKiemDinhDHN_Sai.Text = "Thử Kiểm Định ĐHN (đúng)";
            this.chkKiemDinhDHN_Sai.UseVisualStyleBackColor = true;
            // 
            // chkGiamNuocXaBo
            // 
            this.chkGiamNuocXaBo.AutoSize = true;
            this.chkGiamNuocXaBo.Location = new System.Drawing.Point(895, 84);
            this.chkGiamNuocXaBo.Name = "chkGiamNuocXaBo";
            this.chkGiamNuocXaBo.Size = new System.Drawing.Size(144, 17);
            this.chkGiamNuocXaBo.TabIndex = 6;
            this.chkGiamNuocXaBo.Text = "Giảm Lượng Nước Xả Bỏ";
            this.chkGiamNuocXaBo.UseVisualStyleBackColor = true;
            // 
            // txtNoiNhan
            // 
            this.txtNoiNhan.Location = new System.Drawing.Point(737, 82);
            this.txtNoiNhan.Multiline = true;
            this.txtNoiNhan.Name = "txtNoiNhan";
            this.txtNoiNhan.Size = new System.Drawing.Size(149, 227);
            this.txtNoiNhan.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(734, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Nơi Nhận:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(12, 82);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(719, 227);
            this.txtNoiDung.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Nội Dung:";
            // 
            // txtVeViec
            // 
            this.txtVeViec.Location = new System.Drawing.Point(75, 24);
            this.txtVeViec.Name = "txtVeViec";
            this.txtVeViec.Size = new System.Drawing.Size(656, 25);
            this.txtVeViec.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Về Việc:";
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::KTKS_DonKH.Properties.Resources.save_24x24;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(861, 456);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(70, 35);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dgvLichSuTTTL
            // 
            this.dgvLichSuTTTL.AllowUserToAddRows = false;
            this.dgvLichSuTTTL.AllowUserToDeleteRows = false;
            this.dgvLichSuTTTL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuTTTL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTTTTL,
            this.MaDon,
            this.VeViec});
            this.dgvLichSuTTTL.Location = new System.Drawing.Point(1115, 41);
            this.dgvLichSuTTTL.Name = "dgvLichSuTTTL";
            this.dgvLichSuTTTL.Size = new System.Drawing.Size(470, 200);
            this.dgvLichSuTTTL.TabIndex = 5;
            this.dgvLichSuTTTL.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLichSuTTTL_CellFormatting);
            // 
            // MaCTTTTL
            // 
            this.MaCTTTTL.DataPropertyName = "MaCTTTTL";
            this.MaCTTTTL.HeaderText = "Mã Thư";
            this.MaCTTTTL.Name = "MaCTTTTL";
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            // 
            // VeViec
            // 
            this.VeViec.DataPropertyName = "VeViec";
            this.VeViec.HeaderText = "Về Việc";
            this.VeViec.Name = "VeViec";
            this.VeViec.Width = 200;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 465);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Về Việc:";
            // 
            // cmbVeViec
            // 
            this.cmbVeViec.FormattingEnabled = true;
            this.cmbVeViec.Location = new System.Drawing.Point(87, 462);
            this.cmbVeViec.Name = "cmbVeViec";
            this.cmbVeViec.Size = new System.Drawing.Size(269, 25);
            this.cmbVeViec.TabIndex = 14;
            this.cmbVeViec.SelectedIndexChanged += new System.EventHandler(this.cmbVeViec_SelectedIndexChanged);
            // 
            // frmTTTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1360, 531);
            this.Controls.Add(this.cmbVeViec);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvLichSuTTTL);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTTTL";
            this.Text = "Thảo Thư Trả Lời";
            this.Load += new System.EventHandler(this.frmTTTL_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuTTTL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDinhMuc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGiaBieu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHopDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNoiNhan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtVeViec;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.CheckBox chkThuBao;
        private System.Windows.Forms.CheckBox chkThuMoi;
        private System.Windows.Forms.CheckBox chkDieuChinh_GB_DM;
        private System.Windows.Forms.CheckBox chkThayDHN;
        private System.Windows.Forms.CheckBox chkKiemDinhDHN_Dung;
        private System.Windows.Forms.CheckBox chkKiemDinhDHN_Sai;
        private System.Windows.Forms.CheckBox chkGiamNuocXaBo;
        private System.Windows.Forms.TextBox txtLoTrinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvLichSuTTTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTTTTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn VeViec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbVeViec;
    }
}