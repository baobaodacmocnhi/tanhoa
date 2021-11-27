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
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.txtDot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnTVDieuChinh = new System.Windows.Forms.Button();
            this.btnTVLapDon = new System.Windows.Forms.Button();
            this.STT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCHD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT2,
            this.DanhBo,
            this.DCHD,
            this.MaDon,
            this.STT,
            this.Nam,
            this.Ky,
            this.Dot});
            this.dgvDanhSach.Location = new System.Drawing.Point(1, 41);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.Size = new System.Drawing.Size(571, 466);
            this.dgvDanhSach.TabIndex = 0;
            this.dgvDanhSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellContentClick);
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(12, 12);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 71;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // txtDot
            // 
            this.txtDot.Location = new System.Drawing.Point(298, 12);
            this.txtDot.Name = "txtDot";
            this.txtDot.Size = new System.Drawing.Size(50, 20);
            this.txtDot.TabIndex = 77;
            this.txtDot.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "Đợt";
            // 
            // txtKy
            // 
            this.txtKy.Location = new System.Drawing.Point(212, 12);
            this.txtKy.Name = "txtKy";
            this.txtKy.Size = new System.Drawing.Size(50, 20);
            this.txtKy.TabIndex = 75;
            this.txtKy.Text = "12";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Kỳ";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(131, 12);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(50, 20);
            this.txtNam.TabIndex = 73;
            this.txtNam.Text = "2021";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Năm";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(354, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 78;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnTVDieuChinh
            // 
            this.btnTVDieuChinh.Location = new System.Drawing.Point(531, 12);
            this.btnTVDieuChinh.Name = "btnTVDieuChinh";
            this.btnTVDieuChinh.Size = new System.Drawing.Size(90, 23);
            this.btnTVDieuChinh.TabIndex = 80;
            this.btnTVDieuChinh.Text = "TV Điều Chỉnh";
            this.btnTVDieuChinh.UseVisualStyleBackColor = true;
            this.btnTVDieuChinh.Click += new System.EventHandler(this.btnTVDieuChinh_Click);
            // 
            // btnTVLapDon
            // 
            this.btnTVLapDon.Location = new System.Drawing.Point(435, 12);
            this.btnTVLapDon.Name = "btnTVLapDon";
            this.btnTVLapDon.Size = new System.Drawing.Size(90, 23);
            this.btnTVLapDon.TabIndex = 79;
            this.btnTVLapDon.Text = "TV Lập Đơn";
            this.btnTVLapDon.UseVisualStyleBackColor = true;
            this.btnTVLapDon.Click += new System.EventHandler(this.btnTVLapDon_Click);
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
            // DCHD
            // 
            this.DCHD.DataPropertyName = "DCHD";
            this.DCHD.HeaderText = "ĐCHĐ";
            this.DCHD.Name = "DCHD";
            this.DCHD.Width = 50;
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
            // frmDieuChinhHangLoat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1111, 668);
            this.Controls.Add(this.btnTVDieuChinh);
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
            this.Name = "frmDieuChinhHangLoat";
            this.Text = "Điều Chỉnh Hàng Loạt";
            this.Load += new System.EventHandler(this.frmDieuChinhHangLoat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.TextBox txtDot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnTVDieuChinh;
        private System.Windows.Forms.Button btnTVLapDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DCHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
    }
}