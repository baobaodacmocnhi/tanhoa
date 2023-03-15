namespace KTKS_DonKH.GUI.ThuTraLoi
{
    partial class frmBaoCaoTTTL
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
            this.btnBaoCao_ToTrinh = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNoiDung_ToTrinh = new System.Windows.Forms.ComboBox();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu_ToTrinh = new System.Windows.Forms.DateTimePicker();
            this.dateDen_ToTrinh = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBaoCao_TTTL = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNoiDung_TTTL = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTu_TTTL = new System.Windows.Forms.DateTimePicker();
            this.dateDen_TTTL = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBaoCao_ToTrinh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbNoiDung_ToTrinh);
            this.groupBox1.Controls.Add(this.panel_KhoangThoiGian);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tờ Trình";
            // 
            // btnBaoCao_ToTrinh
            // 
            this.btnBaoCao_ToTrinh.Location = new System.Drawing.Point(257, 56);
            this.btnBaoCao_ToTrinh.Name = "btnBaoCao_ToTrinh";
            this.btnBaoCao_ToTrinh.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_ToTrinh.TabIndex = 27;
            this.btnBaoCao_ToTrinh.Text = "Báo Cáo";
            this.btnBaoCao_ToTrinh.UseVisualStyleBackColor = true;
            this.btnBaoCao_ToTrinh.Click += new System.EventHandler(this.btnBaoCao_ToTrinh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Nội Dung";
            // 
            // cmbNoiDung_ToTrinh
            // 
            this.cmbNoiDung_ToTrinh.FormattingEnabled = true;
            this.cmbNoiDung_ToTrinh.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Danh Bộ",
            "Số Công Văn",
            "Ngày"});
            this.cmbNoiDung_ToTrinh.Location = new System.Drawing.Point(257, 26);
            this.cmbNoiDung_ToTrinh.Name = "cmbNoiDung_ToTrinh";
            this.cmbNoiDung_ToTrinh.Size = new System.Drawing.Size(300, 24);
            this.cmbNoiDung_ToTrinh.TabIndex = 26;
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu_ToTrinh);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen_ToTrinh);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(6, 21);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(175, 60);
            this.panel_KhoangThoiGian.TabIndex = 24;
            // 
            // dateTu_ToTrinh
            // 
            this.dateTu_ToTrinh.CustomFormat = "dd/MM/yyyy";
            this.dateTu_ToTrinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_ToTrinh.Location = new System.Drawing.Point(80, 5);
            this.dateTu_ToTrinh.Name = "dateTu_ToTrinh";
            this.dateTu_ToTrinh.Size = new System.Drawing.Size(90, 22);
            this.dateTu_ToTrinh.TabIndex = 13;
            // 
            // dateDen_ToTrinh
            // 
            this.dateDen_ToTrinh.CustomFormat = "dd/MM/yyyy";
            this.dateDen_ToTrinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_ToTrinh.Location = new System.Drawing.Point(80, 33);
            this.dateDen_ToTrinh.Name = "dateDen_ToTrinh";
            this.dateDen_ToTrinh.Size = new System.Drawing.Size(90, 22);
            this.dateDen_ToTrinh.TabIndex = 14;
            this.dateDen_ToTrinh.ValueChanged += new System.EventHandler(this.dateDen_ToTrinh_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBaoCao_TTTL);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbNoiDung_TTTL);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(565, 89);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thư Trả Lời";
            // 
            // btnBaoCao_TTTL
            // 
            this.btnBaoCao_TTTL.Location = new System.Drawing.Point(257, 56);
            this.btnBaoCao_TTTL.Name = "btnBaoCao_TTTL";
            this.btnBaoCao_TTTL.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_TTTL.TabIndex = 27;
            this.btnBaoCao_TTTL.Text = "Báo Cáo";
            this.btnBaoCao_TTTL.UseVisualStyleBackColor = true;
            this.btnBaoCao_TTTL.Click += new System.EventHandler(this.btnBaoCao_TTTL_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Nội Dung";
            // 
            // cmbNoiDung_TTTL
            // 
            this.cmbNoiDung_TTTL.FormattingEnabled = true;
            this.cmbNoiDung_TTTL.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Danh Bộ",
            "Số Công Văn",
            "Ngày"});
            this.cmbNoiDung_TTTL.Location = new System.Drawing.Point(257, 26);
            this.cmbNoiDung_TTTL.Name = "cmbNoiDung_TTTL";
            this.cmbNoiDung_TTTL.Size = new System.Drawing.Size(300, 24);
            this.cmbNoiDung_TTTL.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTu_TTTL);
            this.panel1.Controls.Add(this.dateDen_TTTL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(6, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 60);
            this.panel1.TabIndex = 24;
            // 
            // dateTu_TTTL
            // 
            this.dateTu_TTTL.CustomFormat = "dd/MM/yyyy";
            this.dateTu_TTTL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_TTTL.Location = new System.Drawing.Point(80, 5);
            this.dateTu_TTTL.Name = "dateTu_TTTL";
            this.dateTu_TTTL.Size = new System.Drawing.Size(90, 22);
            this.dateTu_TTTL.TabIndex = 13;
            // 
            // dateDen_TTTL
            // 
            this.dateDen_TTTL.CustomFormat = "dd/MM/yyyy";
            this.dateDen_TTTL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_TTTL.Location = new System.Drawing.Point(80, 33);
            this.dateDen_TTTL.Name = "dateDen_TTTL";
            this.dateDen_TTTL.Size = new System.Drawing.Size(90, 22);
            this.dateDen_TTTL.TabIndex = 14;
            this.dateDen_TTTL.ValueChanged += new System.EventHandler(this.dateDen_TTTL_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Từ Ngày:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Đến Ngày:";
            // 
            // frmBaoCaoTTTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(775, 380);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBaoCaoTTTL";
            this.Text = "Báo Cáo";
            this.Load += new System.EventHandler(this.frmBaoCaoTTTL_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu_ToTrinh;
        private System.Windows.Forms.DateTimePicker dateDen_ToTrinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbNoiDung_ToTrinh;
        private System.Windows.Forms.Button btnBaoCao_ToTrinh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBaoCao_TTTL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNoiDung_TTTL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTu_TTTL;
        private System.Windows.Forms.DateTimePicker dateDen_TTTL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;

    }
}