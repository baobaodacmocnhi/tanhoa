namespace ThuTien.GUI.TongHop
{
    partial class frmBaoCaoTongHop
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
            this.btnTongHopDangNganDoiMoi = new System.Windows.Forms.Button();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPhanKy = new System.Windows.Forms.CheckBox();
            this.btnTongHopDangNganCQ = new System.Windows.Forms.Button();
            this.btnTongHopDangNganTG = new System.Windows.Forms.Button();
            this.btnTongHopDangNganDoi = new System.Windows.Forms.Button();
            this.dateGiaiTrachTongHopDangNgan = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkTheoThang = new System.Windows.Forms.CheckBox();
            this.btnXuatExcel_KeToan = new System.Windows.Forms.Button();
            this.btnIn_KeToan = new System.Windows.Forms.Button();
            this.dateTu_KeToan = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateDen_KeToan = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkTheoThang_Chot2019 = new System.Windows.Forms.CheckBox();
            this.btnXuatExcel_KeToan_Chot2019 = new System.Windows.Forms.Button();
            this.btnIn_KeToan_Chot2019 = new System.Windows.Forms.Button();
            this.dateTu_KeToan_Chot2019 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateDen_KeToan_Chot2019 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTongHopDangNganDoiMoi);
            this.groupBox1.Controls.Add(this.cmbKy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbNam);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkPhanKy);
            this.groupBox1.Controls.Add(this.btnTongHopDangNganCQ);
            this.groupBox1.Controls.Add(this.btnTongHopDangNganTG);
            this.groupBox1.Controls.Add(this.btnTongHopDangNganDoi);
            this.groupBox1.Controls.Add(this.dateGiaiTrachTongHopDangNgan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng Hợp Đăng Ngân";
            // 
            // btnTongHopDangNganDoiMoi
            // 
            this.btnTongHopDangNganDoiMoi.Location = new System.Drawing.Point(449, 17);
            this.btnTongHopDangNganDoiMoi.Name = "btnTongHopDangNganDoiMoi";
            this.btnTongHopDangNganDoiMoi.Size = new System.Drawing.Size(85, 23);
            this.btnTongHopDangNganDoiMoi.TabIndex = 61;
            this.btnTongHopDangNganDoiMoi.Text = "Tổng Hợp Mới";
            this.btnTongHopDangNganDoiMoi.UseVisualStyleBackColor = true;
            this.btnTongHopDangNganDoiMoi.Click += new System.EventHandler(this.btnTongHopDangNganDoiMoi_Click);
            // 
            // cmbKy
            // 
            this.cmbKy.Enabled = false;
            this.cmbKy.FormattingEnabled = true;
            this.cmbKy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbKy.Location = new System.Drawing.Point(234, 45);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(50, 21);
            this.cmbKy.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Kỳ:";
            // 
            // cmbNam
            // 
            this.cmbNam.Enabled = false;
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(140, 45);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Năm:";
            // 
            // chkPhanKy
            // 
            this.chkPhanKy.AutoSize = true;
            this.chkPhanKy.Location = new System.Drawing.Point(30, 47);
            this.chkPhanKy.Name = "chkPhanKy";
            this.chkPhanKy.Size = new System.Drawing.Size(66, 17);
            this.chkPhanKy.TabIndex = 56;
            this.chkPhanKy.Text = "Phân Kỳ";
            this.chkPhanKy.UseVisualStyleBackColor = true;
            this.chkPhanKy.CheckedChanged += new System.EventHandler(this.chkPhanKy_CheckedChanged);
            // 
            // btnTongHopDangNganCQ
            // 
            this.btnTongHopDangNganCQ.Location = new System.Drawing.Point(368, 17);
            this.btnTongHopDangNganCQ.Name = "btnTongHopDangNganCQ";
            this.btnTongHopDangNganCQ.Size = new System.Drawing.Size(75, 23);
            this.btnTongHopDangNganCQ.TabIndex = 55;
            this.btnTongHopDangNganCQ.Text = "Cơ Quan";
            this.btnTongHopDangNganCQ.UseVisualStyleBackColor = true;
            this.btnTongHopDangNganCQ.Click += new System.EventHandler(this.btnTongHopDangNganCQ_Click);
            // 
            // btnTongHopDangNganTG
            // 
            this.btnTongHopDangNganTG.Location = new System.Drawing.Point(287, 17);
            this.btnTongHopDangNganTG.Name = "btnTongHopDangNganTG";
            this.btnTongHopDangNganTG.Size = new System.Drawing.Size(75, 23);
            this.btnTongHopDangNganTG.TabIndex = 54;
            this.btnTongHopDangNganTG.Text = "Tư Gia";
            this.btnTongHopDangNganTG.UseVisualStyleBackColor = true;
            this.btnTongHopDangNganTG.Click += new System.EventHandler(this.btnTongHopDangNganTG_Click);
            // 
            // btnTongHopDangNganDoi
            // 
            this.btnTongHopDangNganDoi.Location = new System.Drawing.Point(206, 17);
            this.btnTongHopDangNganDoi.Name = "btnTongHopDangNganDoi";
            this.btnTongHopDangNganDoi.Size = new System.Drawing.Size(75, 23);
            this.btnTongHopDangNganDoi.TabIndex = 53;
            this.btnTongHopDangNganDoi.Text = "Tổng Hợp";
            this.btnTongHopDangNganDoi.UseVisualStyleBackColor = true;
            this.btnTongHopDangNganDoi.Click += new System.EventHandler(this.btnTongHopDangNganDoi_Click);
            // 
            // dateGiaiTrachTongHopDangNgan
            // 
            this.dateGiaiTrachTongHopDangNgan.CustomFormat = "dd/MM/yyyy";
            this.dateGiaiTrachTongHopDangNgan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateGiaiTrachTongHopDangNgan.Location = new System.Drawing.Point(100, 19);
            this.dateGiaiTrachTongHopDangNgan.Name = "dateGiaiTrachTongHopDangNgan";
            this.dateGiaiTrachTongHopDangNgan.Size = new System.Drawing.Size(100, 20);
            this.dateGiaiTrachTongHopDangNgan.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Ngày Giải Trách:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkTheoThang);
            this.groupBox2.Controls.Add(this.btnXuatExcel_KeToan);
            this.groupBox2.Controls.Add(this.btnIn_KeToan);
            this.groupBox2.Controls.Add(this.dateTu_KeToan);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dateDen_KeToan);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tổng Hợp Tiền Nước Thu Được gửi Kế Toán";
            // 
            // chkTheoThang
            // 
            this.chkTheoThang.AutoSize = true;
            this.chkTheoThang.Location = new System.Drawing.Point(504, 21);
            this.chkTheoThang.Name = "chkTheoThang";
            this.chkTheoThang.Size = new System.Drawing.Size(85, 17);
            this.chkTheoThang.TabIndex = 35;
            this.chkTheoThang.Text = "Theo Tháng";
            this.chkTheoThang.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcel_KeToan
            // 
            this.btnXuatExcel_KeToan.Location = new System.Drawing.Point(423, 17);
            this.btnXuatExcel_KeToan.Name = "btnXuatExcel_KeToan";
            this.btnXuatExcel_KeToan.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel_KeToan.TabIndex = 34;
            this.btnXuatExcel_KeToan.Text = "Xuất Excel";
            this.btnXuatExcel_KeToan.UseVisualStyleBackColor = true;
            this.btnXuatExcel_KeToan.Click += new System.EventHandler(this.btnXuatExcel_KeToan_Click);
            // 
            // btnIn_KeToan
            // 
            this.btnIn_KeToan.Location = new System.Drawing.Point(342, 17);
            this.btnIn_KeToan.Name = "btnIn_KeToan";
            this.btnIn_KeToan.Size = new System.Drawing.Size(75, 23);
            this.btnIn_KeToan.TabIndex = 33;
            this.btnIn_KeToan.Text = "In";
            this.btnIn_KeToan.UseVisualStyleBackColor = true;
            this.btnIn_KeToan.Click += new System.EventHandler(this.btnIn_KeToan_Click);
            // 
            // dateTu_KeToan
            // 
            this.dateTu_KeToan.CustomFormat = "dd/MM/yyyy";
            this.dateTu_KeToan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_KeToan.Location = new System.Drawing.Point(66, 19);
            this.dateTu_KeToan.Name = "dateTu_KeToan";
            this.dateTu_KeToan.Size = new System.Drawing.Size(100, 20);
            this.dateTu_KeToan.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Từ Ngày:";
            // 
            // dateDen_KeToan
            // 
            this.dateDen_KeToan.CustomFormat = "dd/MM/yyyy";
            this.dateDen_KeToan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_KeToan.Location = new System.Drawing.Point(236, 19);
            this.dateDen_KeToan.Name = "dateDen_KeToan";
            this.dateDen_KeToan.Size = new System.Drawing.Size(100, 20);
            this.dateDen_KeToan.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Đến Ngày:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkTheoThang_Chot2019);
            this.groupBox3.Controls.Add(this.btnXuatExcel_KeToan_Chot2019);
            this.groupBox3.Controls.Add(this.btnIn_KeToan_Chot2019);
            this.groupBox3.Controls.Add(this.dateTu_KeToan_Chot2019);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.dateDen_KeToan_Chot2019);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(12, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 49);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tổng Hợp Tiền Nước Thu Được gửi Kế Toán (chốt 2019)";
            // 
            // chkTheoThang_Chot2019
            // 
            this.chkTheoThang_Chot2019.AutoSize = true;
            this.chkTheoThang_Chot2019.Location = new System.Drawing.Point(504, 21);
            this.chkTheoThang_Chot2019.Name = "chkTheoThang_Chot2019";
            this.chkTheoThang_Chot2019.Size = new System.Drawing.Size(85, 17);
            this.chkTheoThang_Chot2019.TabIndex = 35;
            this.chkTheoThang_Chot2019.Text = "Theo Tháng";
            this.chkTheoThang_Chot2019.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcel_KeToan_Chot2019
            // 
            this.btnXuatExcel_KeToan_Chot2019.Location = new System.Drawing.Point(423, 17);
            this.btnXuatExcel_KeToan_Chot2019.Name = "btnXuatExcel_KeToan_Chot2019";
            this.btnXuatExcel_KeToan_Chot2019.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel_KeToan_Chot2019.TabIndex = 34;
            this.btnXuatExcel_KeToan_Chot2019.Text = "Xuất Excel";
            this.btnXuatExcel_KeToan_Chot2019.UseVisualStyleBackColor = true;
            this.btnXuatExcel_KeToan_Chot2019.Click += new System.EventHandler(this.btnXuatExcel_KeToan_Chot2019_Click);
            // 
            // btnIn_KeToan_Chot2019
            // 
            this.btnIn_KeToan_Chot2019.Location = new System.Drawing.Point(342, 17);
            this.btnIn_KeToan_Chot2019.Name = "btnIn_KeToan_Chot2019";
            this.btnIn_KeToan_Chot2019.Size = new System.Drawing.Size(75, 23);
            this.btnIn_KeToan_Chot2019.TabIndex = 33;
            this.btnIn_KeToan_Chot2019.Text = "In";
            this.btnIn_KeToan_Chot2019.UseVisualStyleBackColor = true;
            this.btnIn_KeToan_Chot2019.Click += new System.EventHandler(this.btnIn_KeToan_Chot2019_Click);
            // 
            // dateTu_KeToan_Chot2019
            // 
            this.dateTu_KeToan_Chot2019.CustomFormat = "dd/MM/yyyy";
            this.dateTu_KeToan_Chot2019.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_KeToan_Chot2019.Location = new System.Drawing.Point(66, 19);
            this.dateTu_KeToan_Chot2019.Name = "dateTu_KeToan_Chot2019";
            this.dateTu_KeToan_Chot2019.Size = new System.Drawing.Size(100, 20);
            this.dateTu_KeToan_Chot2019.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Từ Ngày:";
            // 
            // dateDen_KeToan_Chot2019
            // 
            this.dateDen_KeToan_Chot2019.CustomFormat = "dd/MM/yyyy";
            this.dateDen_KeToan_Chot2019.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_KeToan_Chot2019.Location = new System.Drawing.Point(236, 19);
            this.dateDen_KeToan_Chot2019.Name = "dateDen_KeToan_Chot2019";
            this.dateDen_KeToan_Chot2019.Size = new System.Drawing.Size(100, 20);
            this.dateDen_KeToan_Chot2019.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Đến Ngày:";
            // 
            // frmBaoCaoTongHop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(712, 404);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBaoCaoTongHop";
            this.Text = "Báo Cáo Tổng Hợp";
            this.Load += new System.EventHandler(this.frmBaoCaoTongHop_Load);
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
        private System.Windows.Forms.Button btnTongHopDangNganDoi;
        private System.Windows.Forms.DateTimePicker dateGiaiTrachTongHopDangNgan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTongHopDangNganCQ;
        private System.Windows.Forms.Button btnTongHopDangNganTG;
        private System.Windows.Forms.CheckBox chkPhanKy;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTongHopDangNganDoiMoi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnIn_KeToan;
        private System.Windows.Forms.DateTimePicker dateTu_KeToan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateDen_KeToan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXuatExcel_KeToan;
        private System.Windows.Forms.CheckBox chkTheoThang;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkTheoThang_Chot2019;
        private System.Windows.Forms.Button btnXuatExcel_KeToan_Chot2019;
        private System.Windows.Forms.Button btnIn_KeToan_Chot2019;
        private System.Windows.Forms.DateTimePicker dateTu_KeToan_Chot2019;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateDen_KeToan_Chot2019;
        private System.Windows.Forms.Label label7;
    }
}