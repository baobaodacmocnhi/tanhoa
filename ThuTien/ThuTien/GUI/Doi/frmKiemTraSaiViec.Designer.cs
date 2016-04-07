﻿namespace ThuTien.GUI.Doi
{
    partial class frmKiemTraSaiViec
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
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateGiaiTrach = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTongHD_Billing = new System.Windows.Forms.TextBox();
            this.lstView_Billing = new System.Windows.Forms.ListView();
            this.SoHoaDon_B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ky_B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongCong_B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnChonFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTongHD_TH = new System.Windows.Forms.TextBox();
            this.lstView_TH = new System.Windows.Forms.ListView();
            this.SoHoaDon_TH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ky_TH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongCong_TH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.DanhBo_TH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DanhBo_B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(370, 12);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(118, 21);
            this.cmbNhanVien.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Nhân Viên:";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(248, 11);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(50, 21);
            this.cmbTo.TabIndex = 46;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Tổ:";
            // 
            // dateGiaiTrach
            // 
            this.dateGiaiTrach.CustomFormat = "dd/MM/yyyy";
            this.dateGiaiTrach.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateGiaiTrach.Location = new System.Drawing.Point(125, 20);
            this.dateGiaiTrach.Name = "dateGiaiTrach";
            this.dateGiaiTrach.Size = new System.Drawing.Size(100, 20);
            this.dateGiaiTrach.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Ngày Giải Trách:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(231, 19);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 51;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTongHD_Billing);
            this.groupBox1.Controls.Add(this.lstView_Billing);
            this.groupBox1.Controls.Add(this.btnChonFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 453);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Billing";
            // 
            // txtTongHD_Billing
            // 
            this.txtTongHD_Billing.Location = new System.Drawing.Point(6, 424);
            this.txtTongHD_Billing.Name = "txtTongHD_Billing";
            this.txtTongHD_Billing.Size = new System.Drawing.Size(100, 20);
            this.txtTongHD_Billing.TabIndex = 54;
            // 
            // lstView_Billing
            // 
            this.lstView_Billing.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SoHoaDon_B,
            this.Ky_B,
            this.TongCong_B,
            this.DanhBo_B});
            this.lstView_Billing.Location = new System.Drawing.Point(6, 48);
            this.lstView_Billing.Name = "lstView_Billing";
            this.lstView_Billing.Size = new System.Drawing.Size(379, 370);
            this.lstView_Billing.TabIndex = 53;
            this.lstView_Billing.UseCompatibleStateImageBehavior = false;
            this.lstView_Billing.View = System.Windows.Forms.View.Details;
            // 
            // SoHoaDon_B
            // 
            this.SoHoaDon_B.Text = "Số Hóa Đơn";
            this.SoHoaDon_B.Width = 100;
            // 
            // Ky_B
            // 
            this.Ky_B.Text = "Kỳ";
            // 
            // TongCong_B
            // 
            this.TongCong_B.Text = "Tổng Cộng";
            this.TongCong_B.Width = 100;
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(54, 19);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 52;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTongHD_TH);
            this.groupBox2.Controls.Add(this.lstView_TH);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dateGiaiTrach);
            this.groupBox2.Controls.Add(this.btnXem);
            this.groupBox2.Location = new System.Drawing.Point(489, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 453);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tân Hòa";
            // 
            // txtTongHD_TH
            // 
            this.txtTongHD_TH.Location = new System.Drawing.Point(6, 424);
            this.txtTongHD_TH.Name = "txtTongHD_TH";
            this.txtTongHD_TH.Size = new System.Drawing.Size(100, 20);
            this.txtTongHD_TH.TabIndex = 55;
            // 
            // lstView_TH
            // 
            this.lstView_TH.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SoHoaDon_TH,
            this.Ky_TH,
            this.TongCong_TH,
            this.DanhBo_TH});
            this.lstView_TH.Location = new System.Drawing.Point(6, 48);
            this.lstView_TH.Name = "lstView_TH";
            this.lstView_TH.Size = new System.Drawing.Size(379, 370);
            this.lstView_TH.TabIndex = 54;
            this.lstView_TH.UseCompatibleStateImageBehavior = false;
            this.lstView_TH.View = System.Windows.Forms.View.Details;
            // 
            // SoHoaDon_TH
            // 
            this.SoHoaDon_TH.Text = "Số Hóa Đơn";
            this.SoHoaDon_TH.Width = 100;
            // 
            // Ky_TH
            // 
            this.Ky_TH.Text = "Kỳ";
            // 
            // TongCong_TH
            // 
            this.TongCong_TH.Text = "Tổng Cộng";
            this.TongCong_TH.Width = 100;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(408, 87);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(75, 23);
            this.btnKiemTra.TabIndex = 54;
            this.btnKiemTra.Text = "Kiểm Tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // DanhBo_TH
            // 
            this.DanhBo_TH.Text = "Danh Bộ";
            this.DanhBo_TH.Width = 100;
            // 
            // DanhBo_B
            // 
            this.DanhBo_B.Text = "Danh Bộ";
            this.DanhBo_B.Width = 100;
            // 
            // frmKiemTraSaiViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 536);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.label4);
            this.Name = "frmKiemTraSaiViec";
            this.Text = "Kiểm Tra Sai Việc";
            this.Load += new System.EventHandler(this.frmKiemTraSaiViec_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateGiaiTrach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstView_Billing;
        private System.Windows.Forms.ColumnHeader SoHoaDon_B;
        private System.Windows.Forms.ColumnHeader Ky_B;
        private System.Windows.Forms.ColumnHeader TongCong_B;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstView_TH;
        private System.Windows.Forms.ColumnHeader SoHoaDon_TH;
        private System.Windows.Forms.ColumnHeader Ky_TH;
        private System.Windows.Forms.ColumnHeader TongCong_TH;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.TextBox txtTongHD_Billing;
        private System.Windows.Forms.TextBox txtTongHD_TH;
        private System.Windows.Forms.ColumnHeader DanhBo_B;
        private System.Windows.Forms.ColumnHeader DanhBo_TH;
    }
}