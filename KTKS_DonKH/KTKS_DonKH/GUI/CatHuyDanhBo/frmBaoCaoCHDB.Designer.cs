namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    partial class frmBaoCaoCHDB
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
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.btnBaoCao_TheoNgayLap = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.cmbQuan = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLyDo_TheoNgayLap = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbQuan_TheoNgayLap = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbLoaiBaoCao_TheoNgayLap = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbQuan_TheoNgayXuLy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbNoiDung_TheoNgayXuLy = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbLoaiBaoCao_TheoNgayXuLy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBaoCao_TheoNgayXuLy = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnImportExcelCatHuy = new System.Windows.Forms.Button();
            this.btnImportExcelCatTam = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBaoCao_CatHuy = new System.Windows.Forms.Button();
            this.btnBaoCao_CatTam = new System.Windows.Forms.Button();
            this.cmbNoiDung = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbLyDo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(84, 33);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(84, 5);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 13;
            // 
            // btnBaoCao_TheoNgayLap
            // 
            this.btnBaoCao_TheoNgayLap.Location = new System.Drawing.Point(361, 80);
            this.btnBaoCao_TheoNgayLap.Name = "btnBaoCao_TheoNgayLap";
            this.btnBaoCao_TheoNgayLap.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_TheoNgayLap.TabIndex = 28;
            this.btnBaoCao_TheoNgayLap.Text = "Báo Cáo";
            this.btnBaoCao_TheoNgayLap.UseVisualStyleBackColor = true;
            this.btnBaoCao_TheoNgayLap.Click += new System.EventHandler(this.btnBaoCao_TheoNgayLap_Click);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.cmbQuan);
            this.panel_KhoangThoiGian.Controls.Add(this.label8);
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(165, 12);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(191, 92);
            this.panel_KhoangThoiGian.TabIndex = 27;
            // 
            // cmbQuan
            // 
            this.cmbQuan.FormattingEnabled = true;
            this.cmbQuan.Location = new System.Drawing.Point(84, 61);
            this.cmbQuan.Name = "cmbQuan";
            this.cmbQuan.Size = new System.Drawing.Size(100, 24);
            this.cmbQuan.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Quận";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbLyDo_TheoNgayLap);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbQuan_TheoNgayLap);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbLoaiBaoCao_TheoNgayLap);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBaoCao_TheoNgayLap);
            this.groupBox1.Location = new System.Drawing.Point(12, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 115);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Theo Ngày Lập";
            // 
            // cmbLyDo_TheoNgayLap
            // 
            this.cmbLyDo_TheoNgayLap.FormattingEnabled = true;
            this.cmbLyDo_TheoNgayLap.Items.AddRange(new object[] {
            "DS Cắt Hủy",
            "DS Cắt Tạm"});
            this.cmbLyDo_TheoNgayLap.Location = new System.Drawing.Point(105, 81);
            this.cmbLyDo_TheoNgayLap.Name = "cmbLyDo_TheoNgayLap";
            this.cmbLyDo_TheoNgayLap.Size = new System.Drawing.Size(250, 24);
            this.cmbLyDo_TheoNgayLap.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Lý Do";
            // 
            // cmbQuan_TheoNgayLap
            // 
            this.cmbQuan_TheoNgayLap.FormattingEnabled = true;
            this.cmbQuan_TheoNgayLap.Location = new System.Drawing.Point(105, 51);
            this.cmbQuan_TheoNgayLap.Name = "cmbQuan_TheoNgayLap";
            this.cmbQuan_TheoNgayLap.Size = new System.Drawing.Size(100, 24);
            this.cmbQuan_TheoNgayLap.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "Quận";
            // 
            // cmbLoaiBaoCao_TheoNgayLap
            // 
            this.cmbLoaiBaoCao_TheoNgayLap.FormattingEnabled = true;
            this.cmbLoaiBaoCao_TheoNgayLap.Items.AddRange(new object[] {
            "DS Cắt Hủy Đã Xử Lý",
            "DS Cắt Hủy Chưa Xử Lý",
            "DS Cắt Tạm Đã Xử Lý",
            "DS Cắt Tạm Chưa Xử Lý",
            "DS Cắt Tạm Code 68",
            "DS Cắt Hủy Code 68"});
            this.cmbLoaiBaoCao_TheoNgayLap.Location = new System.Drawing.Point(105, 21);
            this.cmbLoaiBaoCao_TheoNgayLap.Name = "cmbLoaiBaoCao_TheoNgayLap";
            this.cmbLoaiBaoCao_TheoNgayLap.Size = new System.Drawing.Size(150, 24);
            this.cmbLoaiBaoCao_TheoNgayLap.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại Báo Cáo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbQuan_TheoNgayXuLy);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbNoiDung_TheoNgayXuLy);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbLoaiBaoCao_TheoNgayXuLy);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnBaoCao_TheoNgayXuLy);
            this.groupBox2.Location = new System.Drawing.Point(12, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 114);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Theo Ngày Xử Lý";
            // 
            // cmbQuan_TheoNgayXuLy
            // 
            this.cmbQuan_TheoNgayXuLy.FormattingEnabled = true;
            this.cmbQuan_TheoNgayXuLy.Location = new System.Drawing.Point(105, 51);
            this.cmbQuan_TheoNgayXuLy.Name = "cmbQuan_TheoNgayXuLy";
            this.cmbQuan_TheoNgayXuLy.Size = new System.Drawing.Size(100, 24);
            this.cmbQuan_TheoNgayXuLy.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Quận";
            // 
            // cmbNoiDung_TheoNgayXuLy
            // 
            this.cmbNoiDung_TheoNgayXuLy.FormattingEnabled = true;
            this.cmbNoiDung_TheoNgayXuLy.Items.AddRange(new object[] {
            "DS Cắt Hủy",
            "DS Cắt Tạm"});
            this.cmbNoiDung_TheoNgayXuLy.Location = new System.Drawing.Point(105, 81);
            this.cmbNoiDung_TheoNgayXuLy.Name = "cmbNoiDung_TheoNgayXuLy";
            this.cmbNoiDung_TheoNgayXuLy.Size = new System.Drawing.Size(250, 24);
            this.cmbNoiDung_TheoNgayXuLy.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Nội Dung";
            // 
            // cmbLoaiBaoCao_TheoNgayXuLy
            // 
            this.cmbLoaiBaoCao_TheoNgayXuLy.FormattingEnabled = true;
            this.cmbLoaiBaoCao_TheoNgayXuLy.Items.AddRange(new object[] {
            "DS Cắt Hủy",
            "DS Cắt Tạm",
            "DS Cắt Tạm Code 68",
            "DS Cắt Hủy Code 68"});
            this.cmbLoaiBaoCao_TheoNgayXuLy.Location = new System.Drawing.Point(105, 21);
            this.cmbLoaiBaoCao_TheoNgayXuLy.Name = "cmbLoaiBaoCao_TheoNgayXuLy";
            this.cmbLoaiBaoCao_TheoNgayXuLy.Size = new System.Drawing.Size(150, 24);
            this.cmbLoaiBaoCao_TheoNgayXuLy.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loại Báo Cáo";
            // 
            // btnBaoCao_TheoNgayXuLy
            // 
            this.btnBaoCao_TheoNgayXuLy.Location = new System.Drawing.Point(361, 80);
            this.btnBaoCao_TheoNgayXuLy.Name = "btnBaoCao_TheoNgayXuLy";
            this.btnBaoCao_TheoNgayXuLy.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_TheoNgayXuLy.TabIndex = 28;
            this.btnBaoCao_TheoNgayXuLy.Text = "Báo Cáo";
            this.btnBaoCao_TheoNgayXuLy.UseVisualStyleBackColor = true;
            this.btnBaoCao_TheoNgayXuLy.Click += new System.EventHandler(this.btnBaoCao_TheoNgayXuLy_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(362, 67);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(75, 25);
            this.btnThongKe.TabIndex = 29;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnImportExcelCatHuy
            // 
            this.btnImportExcelCatHuy.Location = new System.Drawing.Point(443, 58);
            this.btnImportExcelCatHuy.Name = "btnImportExcelCatHuy";
            this.btnImportExcelCatHuy.Size = new System.Drawing.Size(100, 40);
            this.btnImportExcelCatHuy.TabIndex = 35;
            this.btnImportExcelCatHuy.Text = "Import Excel Cắt Hủy";
            this.btnImportExcelCatHuy.UseVisualStyleBackColor = true;
            this.btnImportExcelCatHuy.Click += new System.EventHandler(this.btnImportExcelCatHuy_Click);
            // 
            // btnImportExcelCatTam
            // 
            this.btnImportExcelCatTam.Location = new System.Drawing.Point(443, 12);
            this.btnImportExcelCatTam.Name = "btnImportExcelCatTam";
            this.btnImportExcelCatTam.Size = new System.Drawing.Size(100, 40);
            this.btnImportExcelCatTam.TabIndex = 36;
            this.btnImportExcelCatTam.Text = "Import Excel Cắt Tạm";
            this.btnImportExcelCatTam.UseVisualStyleBackColor = true;
            this.btnImportExcelCatTam.Click += new System.EventHandler(this.btnImportExcelCatTam_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBaoCao_CatHuy);
            this.groupBox3.Controls.Add(this.btnBaoCao_CatTam);
            this.groupBox3.Controls.Add(this.cmbNoiDung);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cmbLyDo);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(12, 370);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(500, 84);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Theo Lý Do - Nội Dung Xử Lý";
            // 
            // btnBaoCao_CatHuy
            // 
            this.btnBaoCao_CatHuy.Location = new System.Drawing.Point(361, 50);
            this.btnBaoCao_CatHuy.Name = "btnBaoCao_CatHuy";
            this.btnBaoCao_CatHuy.Size = new System.Drawing.Size(130, 25);
            this.btnBaoCao_CatHuy.TabIndex = 38;
            this.btnBaoCao_CatHuy.Text = "Báo Cáo Cắt Hủy";
            this.btnBaoCao_CatHuy.UseVisualStyleBackColor = true;
            this.btnBaoCao_CatHuy.Click += new System.EventHandler(this.btnBaoCao_CatHuy_Click);
            // 
            // btnBaoCao_CatTam
            // 
            this.btnBaoCao_CatTam.Location = new System.Drawing.Point(361, 21);
            this.btnBaoCao_CatTam.Name = "btnBaoCao_CatTam";
            this.btnBaoCao_CatTam.Size = new System.Drawing.Size(130, 25);
            this.btnBaoCao_CatTam.TabIndex = 37;
            this.btnBaoCao_CatTam.Text = "Báo Cáo Cắt Tạm";
            this.btnBaoCao_CatTam.UseVisualStyleBackColor = true;
            this.btnBaoCao_CatTam.Click += new System.EventHandler(this.btnBaoCao_CatTam_Click);
            // 
            // cmbNoiDung
            // 
            this.cmbNoiDung.FormattingEnabled = true;
            this.cmbNoiDung.Items.AddRange(new object[] {
            "DS Cắt Hủy",
            "DS Cắt Tạm"});
            this.cmbNoiDung.Location = new System.Drawing.Point(105, 51);
            this.cmbNoiDung.Name = "cmbNoiDung";
            this.cmbNoiDung.Size = new System.Drawing.Size(250, 24);
            this.cmbNoiDung.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 35;
            this.label11.Text = "Nội Dung";
            // 
            // cmbLyDo
            // 
            this.cmbLyDo.FormattingEnabled = true;
            this.cmbLyDo.Items.AddRange(new object[] {
            "DS Cắt Hủy",
            "DS Cắt Tạm"});
            this.cmbLyDo.Location = new System.Drawing.Point(105, 21);
            this.cmbLyDo.Name = "cmbLyDo";
            this.cmbLyDo.Size = new System.Drawing.Size(250, 24);
            this.cmbLyDo.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 16);
            this.label10.TabIndex = 33;
            this.label10.Text = "Lý Do";
            // 
            // frmBaoCaoCHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(712, 575);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnImportExcelCatTam);
            this.Controls.Add(this.btnImportExcelCatHuy);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmBaoCaoCHDB";
            this.Text = "Báo Cáo Cắt Hủy Danh Bộ";
            this.Load += new System.EventHandler(this.frmBaoCaoCHDB_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Button btnBaoCao_TheoNgayLap;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbLoaiBaoCao_TheoNgayLap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbLoaiBaoCao_TheoNgayXuLy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBaoCao_TheoNgayXuLy;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.ComboBox cmbQuan_TheoNgayLap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbNoiDung_TheoNgayXuLy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbLyDo_TheoNgayLap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbQuan_TheoNgayXuLy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbQuan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnImportExcelCatHuy;
        private System.Windows.Forms.Button btnImportExcelCatTam;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbLyDo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBaoCao_CatTam;
        private System.Windows.Forms.ComboBox cmbNoiDung;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBaoCao_CatHuy;

    }
}