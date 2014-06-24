namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    partial class frmShowYCCHDB
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
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGhiChuXuLy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLyDo = new System.Windows.Forms.ComboBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHopDong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBoxNguyenNhanXuLy = new System.Windows.Forms.GroupBox();
            this.txtHieuLucKy = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxNguyenNhanXuLy.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(429, 43);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(470, 25);
            this.txtDiaChi.TabIndex = 7;
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(333, 6);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.ReadOnly = true;
            this.txtMaDon.Size = new System.Drawing.Size(100, 25);
            this.txtMaDon.TabIndex = 10;
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
            // txtGhiChuXuLy
            // 
            this.txtGhiChuXuLy.Location = new System.Drawing.Point(73, 55);
            this.txtGhiChuXuLy.Name = "txtGhiChuXuLy";
            this.txtGhiChuXuLy.Size = new System.Drawing.Size(412, 25);
            this.txtGhiChuXuLy.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa Chỉ";
            // 
            // cmbLyDo
            // 
            this.cmbLyDo.FormattingEnabled = true;
            this.cmbLyDo.Items.AddRange(new object[] {
            "",
            "Theo Yêu Cầu Khách Hàng",
            "Theo Yêu Cầu Công Ty",
            "Nợ Tiền Nước",
            "Nợ Tiền Bồi Thường ĐHN",
            "Không Thanh Toán Tiền Bồi Thường ĐHN",
            "Nợ Tiền Gian Lận Nước",
            "Vấn Đề Khác"});
            this.cmbLyDo.Location = new System.Drawing.Point(73, 24);
            this.cmbLyDo.Name = "cmbLyDo";
            this.cmbLyDo.Size = new System.Drawing.Size(240, 25);
            this.cmbLyDo.TabIndex = 1;
            this.cmbLyDo.SelectedIndexChanged += new System.EventHandler(this.cmbLyDo_SelectedIndexChanged);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(223, 43);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(200, 25);
            this.txtHoTen.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(491, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Hiệu Lực Kỳ:";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách Hàng";
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
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(117, 43);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.ReadOnly = true;
            this.txtHopDong.Size = new System.Drawing.Size(100, 25);
            this.txtHopDong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hợp Đồng";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(11, 43);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.ReadOnly = true;
            this.txtDanhBo.Size = new System.Drawing.Size(100, 25);
            this.txtDanhBo.TabIndex = 1;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(385, 24);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.ReadOnly = true;
            this.txtSoTien.Size = new System.Drawing.Size(100, 25);
            this.txtSoTien.TabIndex = 5;
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
            this.groupBox1.Size = new System.Drawing.Size(911, 80);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(266, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 17);
            this.label21.TabIndex = 9;
            this.label21.Text = "Mã Đơn:";
            // 
            // groupBoxNguyenNhanXuLy
            // 
            this.groupBoxNguyenNhanXuLy.Controls.Add(this.label10);
            this.groupBoxNguyenNhanXuLy.Controls.Add(this.txtHieuLucKy);
            this.groupBoxNguyenNhanXuLy.Controls.Add(this.txtSoTien);
            this.groupBoxNguyenNhanXuLy.Controls.Add(this.label7);
            this.groupBoxNguyenNhanXuLy.Controls.Add(this.txtGhiChuXuLy);
            this.groupBoxNguyenNhanXuLy.Controls.Add(this.label6);
            this.groupBoxNguyenNhanXuLy.Controls.Add(this.cmbLyDo);
            this.groupBoxNguyenNhanXuLy.Controls.Add(this.label5);
            this.groupBoxNguyenNhanXuLy.Location = new System.Drawing.Point(12, 123);
            this.groupBoxNguyenNhanXuLy.Name = "groupBoxNguyenNhanXuLy";
            this.groupBoxNguyenNhanXuLy.Size = new System.Drawing.Size(658, 94);
            this.groupBoxNguyenNhanXuLy.TabIndex = 13;
            this.groupBoxNguyenNhanXuLy.TabStop = false;
            this.groupBoxNguyenNhanXuLy.Text = "Nguyên Nhân Xử Lý";
            // 
            // txtHieuLucKy
            // 
            this.txtHieuLucKy.Location = new System.Drawing.Point(586, 24);
            this.txtHieuLucKy.Name = "txtHieuLucKy";
            this.txtHieuLucKy.Size = new System.Drawing.Size(58, 25);
            this.txtHieuLucKy.TabIndex = 16;
            // 
            // btnSua
            // 
            this.btnSua.Image = global::KTKS_DonKH.Properties.Resources.pencil_24x24;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(717, 181);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(65, 35);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Image = global::KTKS_DonKH.Properties.Resources.print_24x24;
            this.btnInPhieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInPhieu.Location = new System.Drawing.Point(788, 181);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(135, 35);
            this.btnInPhieu.TabIndex = 17;
            this.btnInPhieu.Text = "In Phiếu CHDB";
            this.btnInPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInPhieu.UseVisualStyleBackColor = true;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // frmShowYCCHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(938, 228);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBoxNguyenNhanXuLy);
            this.Controls.Add(this.btnSua);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmShowYCCHDB";
            this.Text = "Hiển Thị Lập Phiếu Yêu Cầu Cắt Hủy Danh Bộ";
            this.Load += new System.EventHandler(this.frmShowYCCHDB_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxNguyenNhanXuLy.ResumeLayout(false);
            this.groupBoxNguyenNhanXuLy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGhiChuXuLy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbLyDo;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHopDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBoxNguyenNhanXuLy;
        private System.Windows.Forms.TextBox txtHieuLucKy;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnInPhieu;
    }
}