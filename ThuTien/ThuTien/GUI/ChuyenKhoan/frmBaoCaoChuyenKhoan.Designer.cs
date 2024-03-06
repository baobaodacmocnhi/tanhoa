namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmBaoCaoChuyenKhoan
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXuatExcelTongHopDangNgan = new System.Windows.Forms.Button();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkTanHoa = new System.Windows.Forms.CheckBox();
            this.btnXuatExcelBangKeMoi = new System.Windows.Forms.Button();
            this.btnXuatExcelBangKe = new System.Windows.Forms.Button();
            this.dateGiaiTrach = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnXuatExcelDSChuyenKhoan = new System.Windows.Forms.Button();
            this.backgroundWorker_BangKe = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_BangKeMoi = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXuatExcelTongHopDangNgan);
            this.groupBox1.Controls.Add(this.dateTu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateDen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng Hợp Đăng Ngân";
            // 
            // btnXuatExcelTongHopDangNgan
            // 
            this.btnXuatExcelTongHopDangNgan.Location = new System.Drawing.Point(341, 17);
            this.btnXuatExcelTongHopDangNgan.Name = "btnXuatExcelTongHopDangNgan";
            this.btnXuatExcelTongHopDangNgan.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcelTongHopDangNgan.TabIndex = 28;
            this.btnXuatExcelTongHopDangNgan.Text = "Xuất Excel";
            this.btnXuatExcelTongHopDangNgan.UseVisualStyleBackColor = true;
            this.btnXuatExcelTongHopDangNgan.Click += new System.EventHandler(this.btnXuatExcelTongHopDangNgan_Click);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(65, 19);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Từ Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(235, 19);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Đến Ngày:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkTanHoa);
            this.groupBox2.Controls.Add(this.btnXuatExcelBangKeMoi);
            this.groupBox2.Controls.Add(this.btnXuatExcelBangKe);
            this.groupBox2.Controls.Add(this.dateGiaiTrach);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 52);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bảng Kê";
            // 
            // chkTanHoa
            // 
            this.chkTanHoa.AutoSize = true;
            this.chkTanHoa.Location = new System.Drawing.Point(65, 21);
            this.chkTanHoa.Name = "chkTanHoa";
            this.chkTanHoa.Size = new System.Drawing.Size(68, 17);
            this.chkTanHoa.TabIndex = 30;
            this.chkTanHoa.Text = "Tân Hòa";
            this.chkTanHoa.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcelBangKeMoi
            // 
            this.btnXuatExcelBangKeMoi.Location = new System.Drawing.Point(422, 17);
            this.btnXuatExcelBangKeMoi.Name = "btnXuatExcelBangKeMoi";
            this.btnXuatExcelBangKeMoi.Size = new System.Drawing.Size(90, 23);
            this.btnXuatExcelBangKeMoi.TabIndex = 29;
            this.btnXuatExcelBangKeMoi.Text = "Xuất Excel 2";
            this.btnXuatExcelBangKeMoi.UseVisualStyleBackColor = true;
            this.btnXuatExcelBangKeMoi.Visible = false;
            this.btnXuatExcelBangKeMoi.Click += new System.EventHandler(this.btnXuatExcelBangKeMoi_Click);
            // 
            // btnXuatExcelBangKe
            // 
            this.btnXuatExcelBangKe.Location = new System.Drawing.Point(341, 17);
            this.btnXuatExcelBangKe.Name = "btnXuatExcelBangKe";
            this.btnXuatExcelBangKe.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcelBangKe.TabIndex = 28;
            this.btnXuatExcelBangKe.Text = "Xuất Excel";
            this.btnXuatExcelBangKe.UseVisualStyleBackColor = true;
            this.btnXuatExcelBangKe.Click += new System.EventHandler(this.btnXuatExcelBangKe_Click);
            // 
            // dateGiaiTrach
            // 
            this.dateGiaiTrach.CustomFormat = "dd/MM/yyyy";
            this.dateGiaiTrach.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateGiaiTrach.Location = new System.Drawing.Point(235, 19);
            this.dateGiaiTrach.Name = "dateGiaiTrach";
            this.dateGiaiTrach.Size = new System.Drawing.Size(100, 20);
            this.dateGiaiTrach.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Ngày Đăng Ngân:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbNam);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnXuatExcelDSChuyenKhoan);
            this.groupBox3.Location = new System.Drawing.Point(12, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(426, 52);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh Sách Chuyển Khoản";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(275, 18);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Năm:";
            // 
            // btnXuatExcelDSChuyenKhoan
            // 
            this.btnXuatExcelDSChuyenKhoan.Location = new System.Drawing.Point(341, 17);
            this.btnXuatExcelDSChuyenKhoan.Name = "btnXuatExcelDSChuyenKhoan";
            this.btnXuatExcelDSChuyenKhoan.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcelDSChuyenKhoan.TabIndex = 28;
            this.btnXuatExcelDSChuyenKhoan.Text = "Xuất Excel";
            this.btnXuatExcelDSChuyenKhoan.UseVisualStyleBackColor = true;
            this.btnXuatExcelDSChuyenKhoan.Click += new System.EventHandler(this.btnXuatExcelDSChuyenKhoan_Click);
            // 
            // backgroundWorker_BangKe
            // 
            this.backgroundWorker_BangKe.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_BangKe_DoWork);
            this.backgroundWorker_BangKe.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_BangKe_RunWorkerCompleted);
            // 
            // backgroundWorker_BangKeMoi
            // 
            this.backgroundWorker_BangKeMoi.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_BangKeMoi_DoWork);
            this.backgroundWorker_BangKeMoi.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_BangKeMoi_RunWorkerCompleted);
            // 
            // frmBaoCaoChuyenKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(871, 382);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBaoCaoChuyenKhoan";
            this.Text = "Báo Cáo Chuyển Khoản";
            this.Load += new System.EventHandler(this.frmBaoCaoChuyenKhoan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXuatExcelTongHopDangNgan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXuatExcelBangKe;
        private System.Windows.Forms.DateTimePicker dateGiaiTrach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnXuatExcelDSChuyenKhoan;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorker_BangKe;
        private System.Windows.Forms.Button btnXuatExcelBangKeMoi;
        private System.ComponentModel.BackgroundWorker backgroundWorker_BangKeMoi;
        private System.Windows.Forms.CheckBox chkTanHoa;
    }
}