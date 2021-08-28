namespace ThuTien.GUI.Quay
{
    partial class frmBaoCaoQuay
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
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.TabIndex = 1;
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
            // frmBaoCaoQuay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(871, 382);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBaoCaoQuay";
            this.Text = "Báo Cáo Quầy";
            this.Load += new System.EventHandler(this.frmBaoCaoQuay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXuatExcelTongHopDangNgan;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
    }
}