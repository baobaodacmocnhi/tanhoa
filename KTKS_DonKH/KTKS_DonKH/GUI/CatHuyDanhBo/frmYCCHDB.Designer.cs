namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    partial class frmYCCHDB
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
            this.txtMaDonCu = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHopDong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxNoiDungXuLy = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHieuLucKy = new System.Windows.Forms.TextBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLyDo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.txtMaYCCHDB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkCatTamNutBit = new System.Windows.Forms.CheckBox();
            this.dateCatTamNutBit = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxCatTamNutBit = new System.Windows.Forms.GroupBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.chkTroNgai = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbNoiDung = new System.Windows.Forms.ComboBox();
            this.dateTroNgai = new System.Windows.Forms.DateTimePicker();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtMaDonMoi = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxNoiDungXuLy.SuspendLayout();
            this.groupBoxCatTamNutBit.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaDonCu
            // 
            this.txtMaDonCu.Location = new System.Drawing.Point(248, 12);
            this.txtMaDonCu.Name = "txtMaDonCu";
            this.txtMaDonCu.Size = new System.Drawing.Size(75, 22);
            this.txtMaDonCu.TabIndex = 3;
            this.txtMaDonCu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDonCu_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(166, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 16);
            this.label21.TabIndex = 2;
            this.label21.Text = "Mã Đơn Cũ:";
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
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 76);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(424, 40);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(470, 22);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa Chỉ";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(218, 40);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(201, 22);
            this.txtHoTen.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách Hàng";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(112, 40);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.Size = new System.Drawing.Size(100, 22);
            this.txtHopDong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hợp Đồng";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(6, 40);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ";
            // 
            // groupBoxNoiDungXuLy
            // 
            this.groupBoxNoiDungXuLy.Controls.Add(this.label10);
            this.groupBoxNoiDungXuLy.Controls.Add(this.txtHieuLucKy);
            this.groupBoxNoiDungXuLy.Controls.Add(this.txtSoTien);
            this.groupBoxNoiDungXuLy.Controls.Add(this.label7);
            this.groupBoxNoiDungXuLy.Controls.Add(this.txtGhiChu);
            this.groupBoxNoiDungXuLy.Controls.Add(this.label6);
            this.groupBoxNoiDungXuLy.Controls.Add(this.cmbLyDo);
            this.groupBoxNoiDungXuLy.Controls.Add(this.label5);
            this.groupBoxNoiDungXuLy.Location = new System.Drawing.Point(12, 121);
            this.groupBoxNoiDungXuLy.Name = "groupBoxNoiDungXuLy";
            this.groupBoxNoiDungXuLy.Size = new System.Drawing.Size(640, 82);
            this.groupBoxNoiDungXuLy.TabIndex = 8;
            this.groupBoxNoiDungXuLy.TabStop = false;
            this.groupBoxNoiDungXuLy.Text = "Nội Dung Xử Lý";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(486, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "Hiệu Lực Kỳ:";
            // 
            // txtHieuLucKy
            // 
            this.txtHieuLucKy.Location = new System.Drawing.Point(573, 24);
            this.txtHieuLucKy.Name = "txtHieuLucKy";
            this.txtHieuLucKy.Size = new System.Drawing.Size(58, 22);
            this.txtHieuLucKy.TabIndex = 16;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(380, 24);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(100, 22);
            this.txtSoTien.TabIndex = 5;
            this.txtSoTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTien_KeyPress);
            this.txtSoTien.Leave += new System.EventHandler(this.txtSoTien_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(316, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Số Tiền:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(71, 52);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(333, 22);
            this.txtGhiChu.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ghi Chú:";
            // 
            // cmbLyDo
            // 
            this.cmbLyDo.FormattingEnabled = true;
            this.cmbLyDo.Location = new System.Drawing.Point(71, 22);
            this.cmbLyDo.Name = "cmbLyDo";
            this.cmbLyDo.Size = new System.Drawing.Size(239, 24);
            this.cmbLyDo.TabIndex = 1;
            this.cmbLyDo.SelectedIndexChanged += new System.EventHandler(this.cmbLyDo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Lý Do:";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(658, 134);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(658, 227);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(75, 25);
            this.btnInPhieu.TabIndex = 18;
            this.btnInPhieu.Text = "In Phiếu";
            this.btnInPhieu.UseVisualStyleBackColor = true;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // txtMaYCCHDB
            // 
            this.txtMaYCCHDB.Location = new System.Drawing.Point(574, 12);
            this.txtMaYCCHDB.Name = "txtMaYCCHDB";
            this.txtMaYCCHDB.Size = new System.Drawing.Size(60, 22);
            this.txtMaYCCHDB.TabIndex = 20;
            this.txtMaYCCHDB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaYCCHDB_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(503, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Số Phiếu:";
            // 
            // chkCatTamNutBit
            // 
            this.chkCatTamNutBit.AutoSize = true;
            this.chkCatTamNutBit.Location = new System.Drawing.Point(12, 209);
            this.chkCatTamNutBit.Name = "chkCatTamNutBit";
            this.chkCatTamNutBit.Size = new System.Drawing.Size(119, 20);
            this.chkCatTamNutBit.TabIndex = 21;
            this.chkCatTamNutBit.Text = "Cắt Tạm Nút Bít";
            this.chkCatTamNutBit.UseVisualStyleBackColor = true;
            this.chkCatTamNutBit.CheckedChanged += new System.EventHandler(this.chkCatTamNutBit_CheckedChanged);
            // 
            // dateCatTamNutBit
            // 
            this.dateCatTamNutBit.CustomFormat = "dd/MM/yyyy";
            this.dateCatTamNutBit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCatTamNutBit.Location = new System.Drawing.Point(8, 37);
            this.dateCatTamNutBit.Name = "dateCatTamNutBit";
            this.dateCatTamNutBit.Size = new System.Drawing.Size(109, 22);
            this.dateCatTamNutBit.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "Ngày Cắt";
            // 
            // groupBoxCatTamNutBit
            // 
            this.groupBoxCatTamNutBit.Controls.Add(this.dateCatTamNutBit);
            this.groupBoxCatTamNutBit.Controls.Add(this.label9);
            this.groupBoxCatTamNutBit.Enabled = false;
            this.groupBoxCatTamNutBit.Location = new System.Drawing.Point(12, 225);
            this.groupBoxCatTamNutBit.Name = "groupBoxCatTamNutBit";
            this.groupBoxCatTamNutBit.Size = new System.Drawing.Size(126, 68);
            this.groupBoxCatTamNutBit.TabIndex = 24;
            this.groupBoxCatTamNutBit.TabStop = false;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(658, 165);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(12, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 18);
            this.label22.TabIndex = 90;
            this.label22.Text = "Phiếu Hủy";
            // 
            // chkTroNgai
            // 
            this.chkTroNgai.AutoSize = true;
            this.chkTroNgai.Location = new System.Drawing.Point(246, 214);
            this.chkTroNgai.Name = "chkTroNgai";
            this.chkTroNgai.Size = new System.Drawing.Size(83, 20);
            this.chkTroNgai.TabIndex = 94;
            this.chkTroNgai.Text = "Trở Ngại:";
            this.chkTroNgai.UseVisualStyleBackColor = true;
            this.chkTroNgai.CheckedChanged += new System.EventHandler(this.chkNgayXuLy_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(175, 241);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 16);
            this.label19.TabIndex = 93;
            this.label19.Text = "Nội Dung:";
            // 
            // cmbNoiDung
            // 
            this.cmbNoiDung.Enabled = false;
            this.cmbNoiDung.FormattingEnabled = true;
            this.cmbNoiDung.Items.AddRange(new object[] {
            "Xếp hồ sơ",
            "Tái lập danh bộ",
            "Đường cấm đào"});
            this.cmbNoiDung.Location = new System.Drawing.Point(249, 239);
            this.cmbNoiDung.Name = "cmbNoiDung";
            this.cmbNoiDung.Size = new System.Drawing.Size(194, 24);
            this.cmbNoiDung.TabIndex = 92;
            // 
            // dateTroNgai
            // 
            this.dateTroNgai.CustomFormat = "dd/MM/yyyy";
            this.dateTroNgai.Enabled = false;
            this.dateTroNgai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTroNgai.Location = new System.Drawing.Point(334, 209);
            this.dateTroNgai.Name = "dateTroNgai";
            this.dateTroNgai.Size = new System.Drawing.Size(109, 22);
            this.dateTroNgai.TabIndex = 91;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(658, 196);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 95;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtMaDonMoi
            // 
            this.txtMaDonMoi.Location = new System.Drawing.Point(417, 12);
            this.txtMaDonMoi.Name = "txtMaDonMoi";
            this.txtMaDonMoi.Size = new System.Drawing.Size(80, 22);
            this.txtMaDonMoi.TabIndex = 117;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(329, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 16);
            this.label12.TabIndex = 116;
            this.label12.Text = "Mã Đơn Mới:";
            // 
            // frmYCCHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(927, 304);
            this.Controls.Add(this.txtMaDonMoi);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.chkTroNgai);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmbNoiDung);
            this.Controls.Add(this.dateTroNgai);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.groupBoxCatTamNutBit);
            this.Controls.Add(this.chkCatTamNutBit);
            this.Controls.Add(this.txtMaYCCHDB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.groupBoxNoiDungXuLy);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtMaDonCu);
            this.Controls.Add(this.label21);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmYCCHDB";
            this.Text = "Lập Phiếu Yêu Cầu Hủy Danh Bộ";
            this.Load += new System.EventHandler(this.frmYCCHDB_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxNoiDungXuLy.ResumeLayout(false);
            this.groupBoxNoiDungXuLy.PerformLayout();
            this.groupBoxCatTamNutBit.ResumeLayout(false);
            this.groupBoxCatTamNutBit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaDonCu;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHopDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxNoiDungXuLy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbLyDo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHieuLucKy;
        private System.Windows.Forms.Button btnInPhieu;
        private System.Windows.Forms.TextBox txtMaYCCHDB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkCatTamNutBit;
        private System.Windows.Forms.DateTimePicker dateCatTamNutBit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBoxCatTamNutBit;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox chkTroNgai;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbNoiDung;
        private System.Windows.Forms.DateTimePicker dateTroNgai;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtMaDonMoi;
        private System.Windows.Forms.Label label12;
    }
}