﻿namespace ThuTien.GUI.TongHop
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
            this.btnXemTongHopDangNgan = new System.Windows.Forms.Button();
            this.dateGiaiTrachTongHopDangNgan = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXemTongHopDangNgan);
            this.groupBox1.Controls.Add(this.dateGiaiTrachTongHopDangNgan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng Hợp Đăng Ngân";
            // 
            // btnXemTongHopDangNgan
            // 
            this.btnXemTongHopDangNgan.Location = new System.Drawing.Point(206, 17);
            this.btnXemTongHopDangNgan.Name = "btnXemTongHopDangNgan";
            this.btnXemTongHopDangNgan.Size = new System.Drawing.Size(75, 23);
            this.btnXemTongHopDangNgan.TabIndex = 53;
            this.btnXemTongHopDangNgan.Text = "Xem";
            this.btnXemTongHopDangNgan.UseVisualStyleBackColor = true;
            this.btnXemTongHopDangNgan.Click += new System.EventHandler(this.btnXemTongHopDangNgan_Click);
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
            // frmBaoCaoTongHop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 404);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBaoCaoTongHop";
            this.Text = "Báo Cáo Tổng Hợp";
            this.Load += new System.EventHandler(this.frmBaoCaoTongHop_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXemTongHopDangNgan;
        private System.Windows.Forms.DateTimePicker dateGiaiTrachTongHopDangNgan;
        private System.Windows.Forms.Label label1;
    }
}