﻿namespace KTKS_DonKH.GUI.CapNhat
{
    partial class frmTTKH
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDuongDan = new System.Windows.Forms.TextBox();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.dgvDSTTKHDate = new System.Windows.Forms.DataGridView();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTTKHDate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường Dẫn:";
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Location = new System.Drawing.Point(102, 16);
            this.txtDuongDan.Margin = new System.Windows.Forms.Padding(4);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.ReadOnly = true;
            this.txtDuongDan.Size = new System.Drawing.Size(400, 25);
            this.txtDuongDan.TabIndex = 1;
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(101, 48);
            this.btnChonFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(90, 30);
            this.btnChonFile.TabIndex = 2;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(252, 48);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(100, 30);
            this.btnCapNhat.TabIndex = 3;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // dgvDSTTKHDate
            // 
            this.dgvDSTTKHDate.AllowUserToAddRows = false;
            this.dgvDSTTKHDate.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSTTKHDate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSTTKHDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTTKHDate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nam,
            this.Ky,
            this.Dot,
            this.ModifyDate,
            this.ModifyBy});
            this.dgvDSTTKHDate.Location = new System.Drawing.Point(12, 84);
            this.dgvDSTTKHDate.MultiSelect = false;
            this.dgvDSTTKHDate.Name = "dgvDSTTKHDate";
            this.dgvDSTTKHDate.ReadOnly = true;
            this.dgvDSTTKHDate.Size = new System.Drawing.Size(613, 468);
            this.dgvDSTTKHDate.TabIndex = 4;
            // 
            // Nam
            // 
            this.Nam.DataPropertyName = "Nam";
            this.Nam.HeaderText = "Năm";
            this.Nam.Name = "Nam";
            this.Nam.ReadOnly = true;
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.ReadOnly = true;
            // 
            // Dot
            // 
            this.Dot.DataPropertyName = "Dot";
            this.Dot.HeaderText = "Đợt";
            this.Dot.Name = "Dot";
            this.Dot.ReadOnly = true;
            // 
            // ModifyDate
            // 
            this.ModifyDate.DataPropertyName = "ModifyDate";
            this.ModifyDate.HeaderText = "Ngày Cập Nhật";
            this.ModifyDate.Name = "ModifyDate";
            this.ModifyDate.ReadOnly = true;
            this.ModifyDate.Width = 148;
            // 
            // ModifyBy
            // 
            this.ModifyBy.DataPropertyName = "ModifyBy";
            this.ModifyBy.HeaderText = "Cập Nhật Bởi";
            this.ModifyBy.Name = "ModifyBy";
            this.ModifyBy.ReadOnly = true;
            this.ModifyBy.Width = 120;
            // 
            // frmTTKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(639, 570);
            this.Controls.Add(this.dgvDSTTKHDate);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.txtDuongDan);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTTKH";
            this.Text = "Thông Tin Khách Hàng";
            this.Load += new System.EventHandler(this.frmTTKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTTKHDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDuongDan;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.DataGridView dgvDSTTKHDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyBy;
    }
}