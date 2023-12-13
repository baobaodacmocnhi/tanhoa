namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmDieuChinhHangLoat
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
            this.btnTVCapNhatQLDHN = new System.Windows.Forms.Button();
            this.btnTVLapDon = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.txtDot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.STT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaXuLy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdatedDHN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UpdatedDHN_Ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTVDieuChinh = new System.Windows.Forms.Button();
            this.radDCBD = new System.Windows.Forms.RadioButton();
            this.radDCHD = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTVCapNhatQLDHN
            // 
            this.btnTVCapNhatQLDHN.Location = new System.Drawing.Point(729, 7);
            this.btnTVCapNhatQLDHN.Name = "btnTVCapNhatQLDHN";
            this.btnTVCapNhatQLDHN.Size = new System.Drawing.Size(120, 23);
            this.btnTVCapNhatQLDHN.TabIndex = 105;
            this.btnTVCapNhatQLDHN.Text = "TV Cập Nhật QLĐHN";
            this.btnTVCapNhatQLDHN.UseVisualStyleBackColor = true;
            this.btnTVCapNhatQLDHN.Click += new System.EventHandler(this.btnTVCapNhatQLDHN_Click);
            // 
            // btnTVLapDon
            // 
            this.btnTVLapDon.Location = new System.Drawing.Point(537, 7);
            this.btnTVLapDon.Name = "btnTVLapDon";
            this.btnTVLapDon.Size = new System.Drawing.Size(90, 23);
            this.btnTVLapDon.TabIndex = 103;
            this.btnTVLapDon.Text = "TV Lập Đơn";
            this.btnTVLapDon.UseVisualStyleBackColor = true;
            this.btnTVLapDon.Click += new System.EventHandler(this.btnTVLapDon_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(456, 7);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 102;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // txtDot
            // 
            this.txtDot.Location = new System.Drawing.Point(400, 7);
            this.txtDot.Name = "txtDot";
            this.txtDot.Size = new System.Drawing.Size(50, 20);
            this.txtDot.TabIndex = 101;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 100;
            this.label3.Text = "Đợt";
            // 
            // txtKy
            // 
            this.txtKy.Location = new System.Drawing.Point(314, 7);
            this.txtKy.Name = "txtKy";
            this.txtKy.Size = new System.Drawing.Size(50, 20);
            this.txtKy.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 98;
            this.label2.Text = "Kỳ";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(233, 7);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(50, 20);
            this.txtNam.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "Năm";
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(114, 7);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 95;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT2,
            this.DanhBo,
            this.DaXuLy,
            this.MaDon,
            this.STT,
            this.Nam,
            this.Ky,
            this.Dot,
            this.UpdatedDHN,
            this.UpdatedDHN_Ngay});
            this.dgvDanhSach.Location = new System.Drawing.Point(105, 36);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.Size = new System.Drawing.Size(787, 466);
            this.dgvDanhSach.TabIndex = 94;
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            // 
            // STT2
            // 
            this.STT2.DataPropertyName = "STT2";
            this.STT2.HeaderText = "STT";
            this.STT2.Name = "STT2";
            this.STT2.Width = 50;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // DaXuLy
            // 
            this.DaXuLy.DataPropertyName = "DaXuLy";
            this.DaXuLy.HeaderText = "Đã Xử Lý";
            this.DaXuLy.Name = "DaXuLy";
            this.DaXuLy.Width = 70;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // Nam
            // 
            this.Nam.DataPropertyName = "Nam";
            this.Nam.HeaderText = "Năm";
            this.Nam.Name = "Nam";
            this.Nam.Width = 50;
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.Width = 50;
            // 
            // Dot
            // 
            this.Dot.DataPropertyName = "Dot";
            this.Dot.HeaderText = "Đợt";
            this.Dot.Name = "Dot";
            this.Dot.Width = 50;
            // 
            // UpdatedDHN
            // 
            this.UpdatedDHN.DataPropertyName = "UpdatedDHN";
            this.UpdatedDHN.HeaderText = "UpdatedDHN";
            this.UpdatedDHN.Name = "UpdatedDHN";
            // 
            // UpdatedDHN_Ngay
            // 
            this.UpdatedDHN_Ngay.DataPropertyName = "UpdatedDHN_Ngay";
            this.UpdatedDHN_Ngay.HeaderText = "UpdatedDHN_Ngay";
            this.UpdatedDHN_Ngay.Name = "UpdatedDHN_Ngay";
            // 
            // btnTVDieuChinh
            // 
            this.btnTVDieuChinh.Location = new System.Drawing.Point(633, 7);
            this.btnTVDieuChinh.Name = "btnTVDieuChinh";
            this.btnTVDieuChinh.Size = new System.Drawing.Size(90, 23);
            this.btnTVDieuChinh.TabIndex = 104;
            this.btnTVDieuChinh.Text = "TV Điều Chỉnh";
            this.btnTVDieuChinh.UseVisualStyleBackColor = true;
            this.btnTVDieuChinh.Click += new System.EventHandler(this.btnTVDieuChinh_Click);
            // 
            // radDCBD
            // 
            this.radDCBD.AutoSize = true;
            this.radDCBD.Checked = true;
            this.radDCBD.Location = new System.Drawing.Point(12, 6);
            this.radDCBD.Name = "radDCBD";
            this.radDCBD.Size = new System.Drawing.Size(93, 17);
            this.radDCBD.TabIndex = 106;
            this.radDCBD.TabStop = true;
            this.radDCBD.Text = "ĐC Biến Động";
            this.radDCBD.UseVisualStyleBackColor = true;
            // 
            // radDCHD
            // 
            this.radDCHD.AutoSize = true;
            this.radDCHD.Location = new System.Drawing.Point(12, 29);
            this.radDCHD.Name = "radDCHD";
            this.radDCHD.Size = new System.Drawing.Size(86, 17);
            this.radDCHD.TabIndex = 107;
            this.radDCHD.Text = "ĐC Hóa Đơn";
            this.radDCHD.UseVisualStyleBackColor = true;
            // 
            // frmDieuChinhHangLoat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(918, 644);
            this.Controls.Add(this.radDCHD);
            this.Controls.Add(this.radDCBD);
            this.Controls.Add(this.btnTVCapNhatQLDHN);
            this.Controls.Add(this.btnTVLapDon);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.txtDot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.btnTVDieuChinh);
            this.Name = "frmDieuChinhHangLoat";
            this.Text = "Điều Chỉnh Hàng Loạt";
            this.Load += new System.EventHandler(this.frmDieuChinhHangLoat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTVCapNhatQLDHN;
        private System.Windows.Forms.Button btnTVLapDon;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.TextBox txtDot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Button btnTVDieuChinh;
        private System.Windows.Forms.RadioButton radDCBD;
        private System.Windows.Forms.RadioButton radDCHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DaXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UpdatedDHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdatedDHN_Ngay;


    }
}