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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbQuan_TheoNgayLap = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbLoaiBaoCao_TheoNgayLap = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbLoaiBaoCao_TheoNgayXuLy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBaoCao_TheoNgayXuLy = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.cmbNoiDung_TheoNgayXuLy = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.btnBaoCao_TheoNgayLap.Location = new System.Drawing.Point(261, 20);
            this.btnBaoCao_TheoNgayLap.Name = "btnBaoCao_TheoNgayLap";
            this.btnBaoCao_TheoNgayLap.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_TheoNgayLap.TabIndex = 28;
            this.btnBaoCao_TheoNgayLap.Text = "Báo Cáo";
            this.btnBaoCao_TheoNgayLap.UseVisualStyleBackColor = true;
            this.btnBaoCao_TheoNgayLap.Click += new System.EventHandler(this.btnBaoCao_TheoNgayLap_Click);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(165, 12);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(183, 60);
            this.panel_KhoangThoiGian.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbQuan_TheoNgayLap);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbLoaiBaoCao_TheoNgayLap);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBaoCao_TheoNgayLap);
            this.groupBox1.Location = new System.Drawing.Point(12, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 86);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Theo Ngày Lập";
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
            "DS Cắt Tạm Chưa Xử Lý"});
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
            this.groupBox2.Controls.Add(this.cmbNoiDung_TheoNgayXuLy);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbLoaiBaoCao_TheoNgayXuLy);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnBaoCao_TheoNgayXuLy);
            this.groupBox2.Location = new System.Drawing.Point(12, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 86);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Theo Ngày Xử Lý";
            // 
            // cmbLoaiBaoCao_TheoNgayXuLy
            // 
            this.cmbLoaiBaoCao_TheoNgayXuLy.FormattingEnabled = true;
            this.cmbLoaiBaoCao_TheoNgayXuLy.Items.AddRange(new object[] {
            "DS Cắt Hủy",
            "DS Cắt Tạm"});
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
            this.btnBaoCao_TheoNgayXuLy.Location = new System.Drawing.Point(361, 50);
            this.btnBaoCao_TheoNgayXuLy.Name = "btnBaoCao_TheoNgayXuLy";
            this.btnBaoCao_TheoNgayXuLy.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_TheoNgayXuLy.TabIndex = 28;
            this.btnBaoCao_TheoNgayXuLy.Text = "Báo Cáo";
            this.btnBaoCao_TheoNgayXuLy.UseVisualStyleBackColor = true;
            this.btnBaoCao_TheoNgayXuLy.Click += new System.EventHandler(this.btnBaoCao_TheoNgayXuLy_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(354, 46);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(75, 25);
            this.btnThongKe.TabIndex = 29;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // cmbNoiDung_TheoNgayXuLy
            // 
            this.cmbNoiDung_TheoNgayXuLy.FormattingEnabled = true;
            this.cmbNoiDung_TheoNgayXuLy.Items.AddRange(new object[] {
            "DS Cắt Hủy",
            "DS Cắt Tạm"});
            this.cmbNoiDung_TheoNgayXuLy.Location = new System.Drawing.Point(105, 51);
            this.cmbNoiDung_TheoNgayXuLy.Name = "cmbNoiDung_TheoNgayXuLy";
            this.cmbNoiDung_TheoNgayXuLy.Size = new System.Drawing.Size(250, 24);
            this.cmbNoiDung_TheoNgayXuLy.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Nội Dung";
            // 
            // frmBaoCaoCHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(712, 402);
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

    }
}