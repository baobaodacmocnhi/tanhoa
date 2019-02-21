namespace KTKS_DonKH.GUI.BamChi
{
    partial class frmBaoCaoBamChi
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
            this.dateDen_ThongKeLoaiDon = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTu_ThongKeLoaiDon = new System.Windows.Forms.DateTimePicker();
            this.btnBaoCao_ThongKeLoaiDon = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIn_ThongKeLoaiDon = new System.Windows.Forms.Button();
            this.btnBaoCao_ThongKeTrangThaiBamChi = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTu_ThongKeTrangThaiBamChi = new System.Windows.Forms.DateTimePicker();
            this.dateDen_ThongKeTrangThaiBamChi = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIn_ThongKeTrangThaiBamChi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbTrangThaiBC = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateDen_ThongKeLoaiDon
            // 
            this.dateDen_ThongKeLoaiDon.CustomFormat = "dd/MM/yyyy";
            this.dateDen_ThongKeLoaiDon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_ThongKeLoaiDon.Location = new System.Drawing.Point(80, 33);
            this.dateDen_ThongKeLoaiDon.Name = "dateDen_ThongKeLoaiDon";
            this.dateDen_ThongKeLoaiDon.Size = new System.Drawing.Size(90, 22);
            this.dateDen_ThongKeLoaiDon.TabIndex = 14;
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
            // dateTu_ThongKeLoaiDon
            // 
            this.dateTu_ThongKeLoaiDon.CustomFormat = "dd/MM/yyyy";
            this.dateTu_ThongKeLoaiDon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_ThongKeLoaiDon.Location = new System.Drawing.Point(80, 5);
            this.dateTu_ThongKeLoaiDon.Name = "dateTu_ThongKeLoaiDon";
            this.dateTu_ThongKeLoaiDon.Size = new System.Drawing.Size(90, 22);
            this.dateTu_ThongKeLoaiDon.TabIndex = 13;
            // 
            // btnBaoCao_ThongKeLoaiDon
            // 
            this.btnBaoCao_ThongKeLoaiDon.Location = new System.Drawing.Point(187, 25);
            this.btnBaoCao_ThongKeLoaiDon.Name = "btnBaoCao_ThongKeLoaiDon";
            this.btnBaoCao_ThongKeLoaiDon.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_ThongKeLoaiDon.TabIndex = 28;
            this.btnBaoCao_ThongKeLoaiDon.Text = "Báo Cáo";
            this.btnBaoCao_ThongKeLoaiDon.UseVisualStyleBackColor = true;
            this.btnBaoCao_ThongKeLoaiDon.Click += new System.EventHandler(this.btnBaoCao_ThongKeLoaiDon_Click);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu_ThongKeLoaiDon);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen_ThongKeLoaiDon);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(6, 21);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(175, 60);
            this.panel_KhoangThoiGian.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIn_ThongKeLoaiDon);
            this.groupBox1.Controls.Add(this.panel_KhoangThoiGian);
            this.groupBox1.Controls.Add(this.btnBaoCao_ThongKeLoaiDon);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 88);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống Kê theo Loại Đơn (ngày Bấm Chì)";
            // 
            // btnIn_ThongKeLoaiDon
            // 
            this.btnIn_ThongKeLoaiDon.Location = new System.Drawing.Point(187, 54);
            this.btnIn_ThongKeLoaiDon.Name = "btnIn_ThongKeLoaiDon";
            this.btnIn_ThongKeLoaiDon.Size = new System.Drawing.Size(75, 25);
            this.btnIn_ThongKeLoaiDon.TabIndex = 30;
            this.btnIn_ThongKeLoaiDon.Text = "In DS";
            this.btnIn_ThongKeLoaiDon.UseVisualStyleBackColor = true;
            this.btnIn_ThongKeLoaiDon.Click += new System.EventHandler(this.btnIn_ThongKeLoaiDon_Click);
            // 
            // btnBaoCao_ThongKeTrangThaiBamChi
            // 
            this.btnBaoCao_ThongKeTrangThaiBamChi.Location = new System.Drawing.Point(354, 19);
            this.btnBaoCao_ThongKeTrangThaiBamChi.Name = "btnBaoCao_ThongKeTrangThaiBamChi";
            this.btnBaoCao_ThongKeTrangThaiBamChi.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_ThongKeTrangThaiBamChi.TabIndex = 28;
            this.btnBaoCao_ThongKeTrangThaiBamChi.Text = "Báo Cáo";
            this.btnBaoCao_ThongKeTrangThaiBamChi.UseVisualStyleBackColor = true;
            this.btnBaoCao_ThongKeTrangThaiBamChi.Click += new System.EventHandler(this.btnBaoCao_ThongKeTrangThaiBamChi_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTu_ThongKeTrangThaiBamChi);
            this.panel1.Controls.Add(this.dateDen_ThongKeTrangThaiBamChi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 60);
            this.panel1.TabIndex = 27;
            // 
            // dateTu_ThongKeTrangThaiBamChi
            // 
            this.dateTu_ThongKeTrangThaiBamChi.CustomFormat = "dd/MM/yyyy";
            this.dateTu_ThongKeTrangThaiBamChi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_ThongKeTrangThaiBamChi.Location = new System.Drawing.Point(80, 5);
            this.dateTu_ThongKeTrangThaiBamChi.Name = "dateTu_ThongKeTrangThaiBamChi";
            this.dateTu_ThongKeTrangThaiBamChi.Size = new System.Drawing.Size(90, 22);
            this.dateTu_ThongKeTrangThaiBamChi.TabIndex = 13;
            // 
            // dateDen_ThongKeTrangThaiBamChi
            // 
            this.dateDen_ThongKeTrangThaiBamChi.CustomFormat = "dd/MM/yyyy";
            this.dateDen_ThongKeTrangThaiBamChi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_ThongKeTrangThaiBamChi.Location = new System.Drawing.Point(80, 33);
            this.dateDen_ThongKeTrangThaiBamChi.Name = "dateDen_ThongKeTrangThaiBamChi";
            this.dateDen_ThongKeTrangThaiBamChi.Size = new System.Drawing.Size(90, 22);
            this.dateDen_ThongKeTrangThaiBamChi.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Từ Ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Đến Ngày:";
            // 
            // btnIn_ThongKeTrangThaiBamChi
            // 
            this.btnIn_ThongKeTrangThaiBamChi.Location = new System.Drawing.Point(354, 48);
            this.btnIn_ThongKeTrangThaiBamChi.Name = "btnIn_ThongKeTrangThaiBamChi";
            this.btnIn_ThongKeTrangThaiBamChi.Size = new System.Drawing.Size(75, 25);
            this.btnIn_ThongKeTrangThaiBamChi.TabIndex = 30;
            this.btnIn_ThongKeTrangThaiBamChi.Text = "In DS";
            this.btnIn_ThongKeTrangThaiBamChi.UseVisualStyleBackColor = true;
            this.btnIn_ThongKeTrangThaiBamChi.Click += new System.EventHandler(this.btnIn_ThongKeTrangThaiBamChi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbTrangThaiBC);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnIn_ThongKeTrangThaiBamChi);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.btnBaoCao_ThongKeTrangThaiBamChi);
            this.groupBox2.Location = new System.Drawing.Point(12, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 88);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống Kê theo Trạng Thái Bấm Chì (ngày Bấm Chì)";
            // 
            // cmbTrangThaiBC
            // 
            this.cmbTrangThaiBC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThaiBC.FormattingEnabled = true;
            this.cmbTrangThaiBC.Location = new System.Drawing.Point(187, 49);
            this.cmbTrangThaiBC.MaxDropDownItems = 50;
            this.cmbTrangThaiBC.Name = "cmbTrangThaiBC";
            this.cmbTrangThaiBC.Size = new System.Drawing.Size(161, 24);
            this.cmbTrangThaiBC.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Trạng Thái Bấm Chì";
            // 
            // frmBaoCaoBamChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(726, 388);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmBaoCaoBamChi";
            this.Text = "Báo Cáo Bấm Chì";
            this.Load += new System.EventHandler(this.frmBaoCaoBamChi_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateDen_ThongKeLoaiDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTu_ThongKeLoaiDon;
        private System.Windows.Forms.Button btnBaoCao_ThongKeLoaiDon;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIn_ThongKeLoaiDon;
        private System.Windows.Forms.Button btnBaoCao_ThongKeTrangThaiBamChi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTu_ThongKeTrangThaiBamChi;
        private System.Windows.Forms.DateTimePicker dateDen_ThongKeTrangThaiBamChi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIn_ThongKeTrangThaiBamChi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbTrangThaiBC;
        private System.Windows.Forms.Label label5;

    }
}