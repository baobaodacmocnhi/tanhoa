﻿namespace KTKS_DonKH.GUI.KhachHang
{
    partial class frmQLDonKH
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
            this.dgvDSDonKH = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDonKH)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDSDonKH
            // 
            this.dgvDSDonKH.AllowUserToAddRows = false;
            this.dgvDSDonKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDonKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaDon,
            this.TenLD,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi});
            this.dgvDSDonKH.Location = new System.Drawing.Point(16, 16);
            this.dgvDSDonKH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDSDonKH.Name = "dgvDSDonKH";
            this.dgvDSDonKH.RowHeadersWidth = 20;
            this.dgvDSDonKH.Size = new System.Drawing.Size(1625, 506);
            this.dgvDSDonKH.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            // 
            // MaDon
            // 
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            // 
            // TenLD
            // 
            this.TenLD.HeaderText = "Tên Loại Đơn";
            this.TenLD.Name = "TenLD";
            // 
            // CreateDate
            // 
            this.CreateDate.HeaderText = "Ngày Nhận";
            this.CreateDate.Name = "CreateDate";
            // 
            // DanhBo
            // 
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            // 
            // frmQLDonKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.dgvDSDonKH);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmQLDonKH";
            this.Text = "frmQLDonKH";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDonKH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSDonKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;


    }
}