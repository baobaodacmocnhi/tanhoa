﻿namespace KTKS_DonKH.GUI.DonTu
{
    partial class frmBaoCaoDonTu
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
            this.btnBaoCao_LichSuChuyenDon = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTu_LichSuChuyenDon = new System.Windows.Forms.DateTimePicker();
            this.dateDen_LichSuChuyenDon = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBaoCao_LichSuChuyenDon);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 87);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lịch Sử Chuyển Đơn";
            // 
            // btnBaoCao_LichSuChuyenDon
            // 
            this.btnBaoCao_LichSuChuyenDon.Location = new System.Drawing.Point(189, 40);
            this.btnBaoCao_LichSuChuyenDon.Name = "btnBaoCao_LichSuChuyenDon";
            this.btnBaoCao_LichSuChuyenDon.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_LichSuChuyenDon.TabIndex = 25;
            this.btnBaoCao_LichSuChuyenDon.Text = "Báo Cáo";
            this.btnBaoCao_LichSuChuyenDon.UseVisualStyleBackColor = true;
            this.btnBaoCao_LichSuChuyenDon.Click += new System.EventHandler(this.btnBaoCao_LichSuChuyenDon_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTu_LichSuChuyenDon);
            this.panel1.Controls.Add(this.dateDen_LichSuChuyenDon);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 60);
            this.panel1.TabIndex = 24;
            // 
            // dateTu_LichSuChuyenDon
            // 
            this.dateTu_LichSuChuyenDon.CustomFormat = "dd/MM/yyyy";
            this.dateTu_LichSuChuyenDon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_LichSuChuyenDon.Location = new System.Drawing.Point(80, 5);
            this.dateTu_LichSuChuyenDon.Name = "dateTu_LichSuChuyenDon";
            this.dateTu_LichSuChuyenDon.Size = new System.Drawing.Size(90, 22);
            this.dateTu_LichSuChuyenDon.TabIndex = 13;
            // 
            // dateDen_LichSuChuyenDon
            // 
            this.dateDen_LichSuChuyenDon.CustomFormat = "dd/MM/yyyy";
            this.dateDen_LichSuChuyenDon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_LichSuChuyenDon.Location = new System.Drawing.Point(80, 33);
            this.dateDen_LichSuChuyenDon.Name = "dateDen_LichSuChuyenDon";
            this.dateDen_LichSuChuyenDon.Size = new System.Drawing.Size(90, 22);
            this.dateDen_LichSuChuyenDon.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Từ Ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Đến Ngày:";
            // 
            // frmBaoCaoDonTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(551, 407);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBaoCaoDonTu";
            this.Text = "Báo Cáo Đơn Từ";
            this.Load += new System.EventHandler(this.frmBaoCaoDonTu_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBaoCao_LichSuChuyenDon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTu_LichSuChuyenDon;
        private System.Windows.Forms.DateTimePicker dateDen_LichSuChuyenDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}