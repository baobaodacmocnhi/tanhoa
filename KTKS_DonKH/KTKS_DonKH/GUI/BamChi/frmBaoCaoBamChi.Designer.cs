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
            this.dateDen_ThongKeTrangThaiBamChi = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTu_ThongKeTrangThaiBamChi = new System.Windows.Forms.DateTimePicker();
            this.btnBaoCao_ThongKeTrangThaiBamChi = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // dateTu_ThongKeTrangThaiBamChi
            // 
            this.dateTu_ThongKeTrangThaiBamChi.CustomFormat = "dd/MM/yyyy";
            this.dateTu_ThongKeTrangThaiBamChi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_ThongKeTrangThaiBamChi.Location = new System.Drawing.Point(80, 5);
            this.dateTu_ThongKeTrangThaiBamChi.Name = "dateTu_ThongKeTrangThaiBamChi";
            this.dateTu_ThongKeTrangThaiBamChi.Size = new System.Drawing.Size(90, 22);
            this.dateTu_ThongKeTrangThaiBamChi.TabIndex = 13;
            // 
            // btnBaoCao_ThongKeTrangThaiBamChi
            // 
            this.btnBaoCao_ThongKeTrangThaiBamChi.Location = new System.Drawing.Point(192, 41);
            this.btnBaoCao_ThongKeTrangThaiBamChi.Name = "btnBaoCao_ThongKeTrangThaiBamChi";
            this.btnBaoCao_ThongKeTrangThaiBamChi.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_ThongKeTrangThaiBamChi.TabIndex = 28;
            this.btnBaoCao_ThongKeTrangThaiBamChi.Text = "Báo Cáo";
            this.btnBaoCao_ThongKeTrangThaiBamChi.UseVisualStyleBackColor = true;
            this.btnBaoCao_ThongKeTrangThaiBamChi.Click += new System.EventHandler(this.btnBaoCao_ThongKeTrangThaiBamChi_Click);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu_ThongKeTrangThaiBamChi);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen_ThongKeTrangThaiBamChi);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(6, 22);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(180, 60);
            this.panel_KhoangThoiGian.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel_KhoangThoiGian);
            this.groupBox1.Controls.Add(this.btnBaoCao_ThongKeTrangThaiBamChi);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 90);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống Kê Trạng Thái Bấm Chì";
            // 
            // frmBaoCaoBamChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(726, 388);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmBaoCaoBamChi";
            this.Text = "Các Loại Báo Cáo Bấm Chì";
            this.Load += new System.EventHandler(this.frmBaoCaoBamChi_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateDen_ThongKeTrangThaiBamChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTu_ThongKeTrangThaiBamChi;
        private System.Windows.Forms.Button btnBaoCao_ThongKeTrangThaiBamChi;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}