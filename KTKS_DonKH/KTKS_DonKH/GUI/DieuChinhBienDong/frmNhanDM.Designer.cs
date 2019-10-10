namespace KTKS_DonKH.GUI.DieuChinhBienDong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvDSDanhBo = new System.Windows.Forms.DataGridView();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNKDangKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtHoTens_Cat = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDanhBo)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLoaiCT
            // 
            this.cmbLoaiCT.FormattingEnabled = true;
            this.cmbLoaiCT.Location = new System.Drawing.Point(127, 140);
            this.cmbLoaiCT.Name = "cmbLoaiCT";
            this.cmbLoaiCT.Size = new System.Drawing.Size(201, 24);
            this.cmbLoaiCT.TabIndex = 9;
            this.cmbLoaiCT.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiCT_SelectedIndexChanged);
            this.cmbLoaiCT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbLoaiCT_KeyPress);
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(127, 22);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(290, 24);
            this.cmbChiNhanh.TabIndex = 1;
            this.cmbChiNhanh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbChiNhanh_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Nơi Cắt/Chuyển:";
            // 
            // txtSoNKNhan
            // 
            this.txtSoNKNhan.Location = new System.Drawing.Point(317, 227);
            this.txtSoNKNhan.Name = "txtSoNKNhan";
            this.txtSoNKNhan.Size = new System.Drawing.Size(100, 22);
            this.txtSoNKNhan.TabIndex = 19;
            this.txtSoNKNhan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoNKNhan_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Số NK Nhận:";
            // 
            // txtMaCT
            // 
            this.txtMaCT.Location = new System.Drawing.Point(127, 169);
            this.txtMaCT.Name = "txtMaCT";
            this.txtMaCT.Size = new System.Drawing.Size(100, 22);
            this.txtMaCT.TabIndex = 11;
            this.txtMaCT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaCT_KeyPress);
            this.txtMaCT.Leave += new System.EventHandler(this.txtMaCT_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Số Chứng Từ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Loại Chứng Từ:";
            // 
            // txtDiaChi_Cat
            // 
            this.txtDiaChi_Cat.Location = new System.Drawing.Point(127, 110);
            this.txtDiaChi_Cat.Name = "txtDiaChi_Cat";
            this.txtDiaChi_Cat.Size = new System.Drawing.Size(290, 22);
            this.txtDiaChi_Cat.TabIndex = 7;
            this.txtDiaChi_Cat.TextChanged += new System.EventHandler(this.txtDiaChi_Cat_TextChanged);
            this.txtDiaChi_Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaChi_Cat_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Địa Chỉ KH:";
            // 
            // txtHoTen_Cat
            // 
            this.txtHoTen_Cat.Location = new System.Drawing.Point(127, 81);
            this.txtHoTen_Cat.Name = "txtHoTen_Cat";
            this.txtHoTen_Cat.Size = new System.Drawing.Size(290, 22);
            this.txtHoTen_Cat.TabIndex = 5;
            this.txtHoTen_Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoTen_Cat_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Khách Hàng:";
            // 
            // txtDanhBo_Cat
            // 
            this.txtDanhBo_Cat.Location = new System.Drawing.Point(127, 52);
            this.txtDanhBo_Cat.Name = "txtDanhBo_Cat";
            this.txtDanhBo_Cat.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo_Cat.TabIndex = 3;
            this.txtDanhBo_Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_Cat_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh Bộ:";
            // 
            // txtSoNKTong
            // 
            this.txtSoNKTong.Location = new System.Drawing.Point(127, 227);
            this.txtSoNKTong.Name = "txtSoNKTong";
            this.txtSoNKTong.Size = new System.Drawing.Size(100, 22);
            this.txtSoNKTong.TabIndex = 17;
            this.txtSoNKTong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoNKTong_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tổng Số NK:";
            // 
            // txtDiaChiCT_Cat
            // 
            this.txtDiaChiCT_Cat.Location = new System.Drawing.Point(127, 197);
            this.txtDiaChiCT_Cat.Name = "txtDiaChiCT_Cat";
            this.txtDiaChiCT_Cat.Size = new System.Drawing.Size(290, 22);
            this.txtDiaChiCT_Cat.TabIndex = 15;
            this.txtDiaChiCT_Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaChiCT_Cat_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
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
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nơi Nhận";
            // 
            // txtDiaChi_Nhan
            // 
            this.txtDiaChi_Nhan.Location = new System.Drawing.Point(126, 81);
            this.txtDiaChi_Nhan.Name = "txtDiaChi_Nhan";
            this.txtDiaChi_Nhan.Size = new System.Drawing.Size(290, 22);
            this.txtDiaChi_Nhan.TabIndex = 5;
            // 
            // txtDanhBo_Nhan
            // 
            this.txtDanhBo_Nhan.Location = new System.Drawing.Point(126, 22);
            this.txtDanhBo_Nhan.Name = "txtDanhBo_Nhan";
            this.txtDanhBo_Nhan.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo_Nhan.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Địa Chỉ:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Danh Bộ:";
            // 
            // txtHoTen_Nhan
            // 
            this.txtHoTen_Nhan.Location = new System.Drawing.Point(126, 52);
            this.txtHoTen_Nhan.Name = "txtHoTen_Nhan";
            this.txtHoTen_Nhan.Size = new System.Drawing.Size(290, 22);
            this.txtHoTen_Nhan.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Khách Hàng:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtHoTens_Cat);
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
            this.groupBox2.Location = new System.Drawing.Point(447, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 393);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nơi Cắt/Chuyển:";
            // 
            // txtPhong
            // 
            this.txtPhong.Location = new System.Drawing.Point(127, 364);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(194, 22);
            this.txtPhong.TabIndex = 34;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(14, 366);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(50, 16);
            this.label35.TabIndex = 33;
            this.label35.Text = "Phòng:";
            // 
            // txtLo
            // 
            this.txtLo.Location = new System.Drawing.Point(127, 334);
            this.txtLo.Name = "txtLo";
            this.txtLo.Size = new System.Drawing.Size(194, 22);
            this.txtLo.TabIndex = 32;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(14, 337);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(26, 16);
            this.label34.TabIndex = 31;
            this.label34.Text = "Lô:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(127, 305);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(290, 22);
            this.txtGhiChu.TabIndex = 21;
            this.txtGhiChu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGhiChu_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 308);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 16);
            this.label14.TabIndex = 20;
            this.label14.Text = "Ghi Chú:";
            // 
            // txtThoiHan
            // 
            this.txtThoiHan.Location = new System.Drawing.Point(317, 169);
            this.txtThoiHan.Name = "txtThoiHan";
            this.txtThoiHan.Size = new System.Drawing.Size(100, 22);
            this.txtThoiHan.TabIndex = 13;
            this.txtThoiHan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThoiHan_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(233, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Thời Hạn:";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(802, 412);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvDSDanhBo
            // 
            this.dgvDSDanhBo.AllowUserToAddRows = false;
            this.dgvDSDanhBo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSDanhBo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDSDanhBo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDanhBo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo,
            this.SoNKDangKy,
            this.CreateDate});
            this.dgvDSDanhBo.Location = new System.Drawing.Point(12, 134);
            this.dgvDSDanhBo.Name = "dgvDSDanhBo";
            this.dgvDSDanhBo.Size = new System.Drawing.Size(357, 160);
            this.dgvDSDanhBo.TabIndex = 27;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // SoNKDangKy
            // 
            this.SoNKDangKy.DataPropertyName = "SoNKDangKy";
            this.SoNKDangKy.HeaderText = "Số NK Đăng Ký";
            this.SoNKDangKy.Name = "SoNKDangKy";
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // txtHoTens_Cat
            // 
            this.txtHoTens_Cat.Location = new System.Drawing.Point(127, 255);
            this.txtHoTens_Cat.Multiline = true;
            this.txtHoTens_Cat.Name = "txtHoTens_Cat";
            this.txtHoTens_Cat.Size = new System.Drawing.Size(290, 44);
            this.txtHoTens_Cat.TabIndex = 35;
            this.txtHoTens_Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoTens_Cat_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 258);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 16);
            this.label15.TabIndex = 36;
            this.label15.Text = "DS Họ Tên Cắt:";
            // 
            // frmNhanDM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(881, 442);
            this.Controls.Add(this.dgvDSDanhBo);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmNhanDM";
            this.Text = "Tiếp Nhận Định Mức";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhanDM_FormClosing);
            this.Load += new System.EventHandler(this.frmNhanDM_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDanhBo)).EndInit();
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
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtThoiHan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtLo;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.DataGridView dgvDSDanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNKDangKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtHoTens_Cat;
    }
}