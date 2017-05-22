namespace KTKS_DonKH.GUI.TruyThu
{
    partial class frmBaoCaoTruyThu
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
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu_ThongKeTruyThu = new System.Windows.Forms.DateTimePicker();
            this.dateDen_ThongKeTruyThu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBaoCao_ThongKeTruyThu = new System.Windows.Forms.Button();
            this.radDaThanhToan = new System.Windows.Forms.RadioButton();
            this.radGuiThu = new System.Windows.Forms.RadioButton();
            this.radChuaThanhToan = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radChuaThanhToan);
            this.groupBox1.Controls.Add(this.radGuiThu);
            this.groupBox1.Controls.Add(this.radDaThanhToan);
            this.groupBox1.Controls.Add(this.panel_KhoangThoiGian);
            this.groupBox1.Controls.Add(this.btnBaoCao_ThongKeTruyThu);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 140);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống Kê Truy Thu";
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu_ThongKeTruyThu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen_ThongKeTruyThu);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(6, 21);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(177, 60);
            this.panel_KhoangThoiGian.TabIndex = 22;
            // 
            // dateTu_ThongKeTruyThu
            // 
            this.dateTu_ThongKeTruyThu.CustomFormat = "dd/MM/yyyy";
            this.dateTu_ThongKeTruyThu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_ThongKeTruyThu.Location = new System.Drawing.Point(80, 5);
            this.dateTu_ThongKeTruyThu.Name = "dateTu_ThongKeTruyThu";
            this.dateTu_ThongKeTruyThu.Size = new System.Drawing.Size(90, 22);
            this.dateTu_ThongKeTruyThu.TabIndex = 13;
            // 
            // dateDen_ThongKeTruyThu
            // 
            this.dateDen_ThongKeTruyThu.CustomFormat = "dd/MM/yyyy";
            this.dateDen_ThongKeTruyThu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_ThongKeTruyThu.Location = new System.Drawing.Point(80, 33);
            this.dateDen_ThongKeTruyThu.Name = "dateDen_ThongKeTruyThu";
            this.dateDen_ThongKeTruyThu.Size = new System.Drawing.Size(90, 22);
            this.dateDen_ThongKeTruyThu.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // btnBaoCao_ThongKeTruyThu
            // 
            this.btnBaoCao_ThongKeTruyThu.Location = new System.Drawing.Point(189, 41);
            this.btnBaoCao_ThongKeTruyThu.Name = "btnBaoCao_ThongKeTruyThu";
            this.btnBaoCao_ThongKeTruyThu.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_ThongKeTruyThu.TabIndex = 23;
            this.btnBaoCao_ThongKeTruyThu.Text = "Báo Cáo";
            this.btnBaoCao_ThongKeTruyThu.UseVisualStyleBackColor = true;
            this.btnBaoCao_ThongKeTruyThu.Click += new System.EventHandler(this.btnBaoCao_ThongKeTruyThu_Click);
            // 
            // radDaThanhToan
            // 
            this.radDaThanhToan.AutoSize = true;
            this.radDaThanhToan.Location = new System.Drawing.Point(12, 87);
            this.radDaThanhToan.Name = "radDaThanhToan";
            this.radDaThanhToan.Size = new System.Drawing.Size(119, 20);
            this.radDaThanhToan.TabIndex = 25;
            this.radDaThanhToan.TabStop = true;
            this.radDaThanhToan.Text = "Đã Thanh Toán";
            this.radDaThanhToan.UseVisualStyleBackColor = true;
            // 
            // radGuiThu
            // 
            this.radGuiThu.AutoSize = true;
            this.radGuiThu.Location = new System.Drawing.Point(146, 87);
            this.radGuiThu.Name = "radGuiThu";
            this.radGuiThu.Size = new System.Drawing.Size(72, 20);
            this.radGuiThu.TabIndex = 26;
            this.radGuiThu.TabStop = true;
            this.radGuiThu.Text = "Gửi Thư";
            this.radGuiThu.UseVisualStyleBackColor = true;
            // 
            // radChuaThanhToan
            // 
            this.radChuaThanhToan.AutoSize = true;
            this.radChuaThanhToan.Location = new System.Drawing.Point(12, 113);
            this.radChuaThanhToan.Name = "radChuaThanhToan";
            this.radChuaThanhToan.Size = new System.Drawing.Size(133, 20);
            this.radChuaThanhToan.TabIndex = 27;
            this.radChuaThanhToan.TabStop = true;
            this.radChuaThanhToan.Text = "Chưa Thanh Toán";
            this.radChuaThanhToan.UseVisualStyleBackColor = true;
            // 
            // frmBaoCaoTruyThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(969, 545);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBaoCaoTruyThu";
            this.Text = "Báo Cáo Truy Thu";
            this.Load += new System.EventHandler(this.frmBaoCaoTruyThu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu_ThongKeTruyThu;
        private System.Windows.Forms.DateTimePicker dateDen_ThongKeTruyThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBaoCao_ThongKeTruyThu;
        private System.Windows.Forms.RadioButton radChuaThanhToan;
        private System.Windows.Forms.RadioButton radGuiThu;
        private System.Windows.Forms.RadioButton radDaThanhToan;
    }
}