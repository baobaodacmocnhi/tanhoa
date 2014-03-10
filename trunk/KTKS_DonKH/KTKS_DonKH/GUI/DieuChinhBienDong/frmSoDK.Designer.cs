namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmSoDK
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLoaiCT = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaCT = new System.Windows.Forms.TextBox();
            this.txtSoNKTong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoNKDangKy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThoiHan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoNKCat = new System.Windows.Forms.TextBox();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDanhBo_Cat = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHoTen_Cat = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDiaChiKH_Cat = new System.Windows.Forms.TextBox();
            this.chkCatChuyen = new System.Windows.Forms.CheckBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Danh Bộ:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(128, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.ReadOnly = true;
            this.txtDanhBo.Size = new System.Drawing.Size(100, 25);
            this.txtDanhBo.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Loại Sổ:";
            // 
            // cmbLoaiCT
            // 
            this.cmbLoaiCT.Enabled = false;
            this.cmbLoaiCT.FormattingEnabled = true;
            this.cmbLoaiCT.Location = new System.Drawing.Point(128, 43);
            this.cmbLoaiCT.Name = "cmbLoaiCT";
            this.cmbLoaiCT.Size = new System.Drawing.Size(200, 25);
            this.cmbLoaiCT.TabIndex = 17;
            this.cmbLoaiCT.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiCT_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số Sổ:";
            // 
            // txtMaCT
            // 
            this.txtMaCT.Location = new System.Drawing.Point(128, 74);
            this.txtMaCT.Name = "txtMaCT";
            this.txtMaCT.ReadOnly = true;
            this.txtMaCT.Size = new System.Drawing.Size(100, 25);
            this.txtMaCT.TabIndex = 1;
            this.txtMaCT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaCT_KeyPress);
            this.txtMaCT.Leave += new System.EventHandler(this.txtMaCT_Leave);
            // 
            // txtSoNKTong
            // 
            this.txtSoNKTong.Location = new System.Drawing.Point(128, 136);
            this.txtSoNKTong.Name = "txtSoNKTong";
            this.txtSoNKTong.ReadOnly = true;
            this.txtSoNKTong.Size = new System.Drawing.Size(100, 25);
            this.txtSoNKTong.TabIndex = 5;
            this.txtSoNKTong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoNKTong_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tổng NK:";
            // 
            // txtSoNKDangKy
            // 
            this.txtSoNKDangKy.Location = new System.Drawing.Point(128, 167);
            this.txtSoNKDangKy.Name = "txtSoNKDangKy";
            this.txtSoNKDangKy.ReadOnly = true;
            this.txtSoNKDangKy.Size = new System.Drawing.Size(100, 25);
            this.txtSoNKDangKy.TabIndex = 7;
            this.txtSoNKDangKy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoNKDangKy_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Số NK Đăng Ký:";
            // 
            // txtThoiHan
            // 
            this.txtThoiHan.Location = new System.Drawing.Point(128, 198);
            this.txtThoiHan.Name = "txtThoiHan";
            this.txtThoiHan.ReadOnly = true;
            this.txtThoiHan.Size = new System.Drawing.Size(100, 25);
            this.txtThoiHan.TabIndex = 9;
            this.txtThoiHan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThoiHan_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Thời Hạn(tháng):";
            // 
            // btnSua
            // 
            this.btnSua.Enabled = false;
            this.btnSua.Image = global::KTKS_DonKH.Properties.Resources.pencil_24x24;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(526, 224);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(66, 35);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Enabled = false;
            this.btnThem.Image = global::KTKS_DonKH.Properties.Resources.add_24x24;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(429, 224);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(77, 35);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Địa Chỉ:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(128, 105);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(285, 25);
            this.txtDiaChi.TabIndex = 3;
            this.txtDiaChi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaChi_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtSoNKCat);
            this.groupBox1.Controls.Add(this.cmbChiNhanh);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtDanhBo_Cat);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtHoTen_Cat);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtDiaChiKH_Cat);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(430, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 179);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nơi Cắt/Chuyển:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Số NK Cắt:";
            // 
            // txtSoNKCat
            // 
            this.txtSoNKCat.Location = new System.Drawing.Point(133, 148);
            this.txtSoNKCat.Name = "txtSoNKCat";
            this.txtSoNKCat.Size = new System.Drawing.Size(100, 25);
            this.txtSoNKCat.TabIndex = 9;
            this.txtSoNKCat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoNKCat_KeyPress);
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(133, 24);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(290, 25);
            this.cmbChiNhanh.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Nơi Cắt/Chuyển:";
            // 
            // txtDanhBo_Cat
            // 
            this.txtDanhBo_Cat.Location = new System.Drawing.Point(133, 55);
            this.txtDanhBo_Cat.Name = "txtDanhBo_Cat";
            this.txtDanhBo_Cat.Size = new System.Drawing.Size(100, 25);
            this.txtDanhBo_Cat.TabIndex = 3;
            this.txtDanhBo_Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_Cat_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Danh Bộ:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "Khách Hàng:";
            // 
            // txtHoTen_Cat
            // 
            this.txtHoTen_Cat.Location = new System.Drawing.Point(133, 86);
            this.txtHoTen_Cat.Name = "txtHoTen_Cat";
            this.txtHoTen_Cat.Size = new System.Drawing.Size(290, 25);
            this.txtHoTen_Cat.TabIndex = 5;
            this.txtHoTen_Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoTen_Cat_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "Địa Chỉ:";
            // 
            // txtDiaChiKH_Cat
            // 
            this.txtDiaChiKH_Cat.Location = new System.Drawing.Point(133, 117);
            this.txtDiaChiKH_Cat.Name = "txtDiaChiKH_Cat";
            this.txtDiaChiKH_Cat.Size = new System.Drawing.Size(290, 25);
            this.txtDiaChiKH_Cat.TabIndex = 7;
            this.txtDiaChiKH_Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaChiKH_Cat_KeyPress);
            // 
            // chkCatChuyen
            // 
            this.chkCatChuyen.AutoSize = true;
            this.chkCatChuyen.Location = new System.Drawing.Point(430, 12);
            this.chkCatChuyen.Name = "chkCatChuyen";
            this.chkCatChuyen.Size = new System.Drawing.Size(97, 21);
            this.chkCatChuyen.TabIndex = 14;
            this.chkCatChuyen.Text = "Cắt/Chuyển";
            this.chkCatChuyen.UseVisualStyleBackColor = true;
            this.chkCatChuyen.CheckedChanged += new System.EventHandler(this.chkCatChuyen_CheckedChanged);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(128, 229);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ReadOnly = true;
            this.txtGhiChu.Size = new System.Drawing.Size(285, 25);
            this.txtGhiChu.TabIndex = 11;
            this.txtGhiChu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGhiChu_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Ghi Chú:";
            // 
            // frmSoDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(882, 271);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkCatChuyen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtThoiHan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSoNKDangKy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSoNKTong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaCT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLoaiCT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSoDK";
            this.Text = "Cập Nhật Sổ Đăng Ký";
            this.Load += new System.EventHandler(this.frmSoDK_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLoaiCT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaCT;
        private System.Windows.Forms.TextBox txtSoNKTong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoNKDangKy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtThoiHan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDanhBo_Cat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHoTen_Cat;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDiaChiKH_Cat;
        private System.Windows.Forms.CheckBox chkCatChuyen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSoNKCat;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label9;
    }
}