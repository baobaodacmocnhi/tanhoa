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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnTVCapNhatQLDHN = new System.Windows.Forms.Button();
            this.btnTVDieuChinh = new System.Windows.Forms.Button();
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
            this.DCHD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdatedDHN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UpdatedDHN_Ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(918, 644);
            this.tabControl1.TabIndex = 82;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(910, 618);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Biến Động";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnTVCapNhatQLDHN);
            this.tabPage2.Controls.Add(this.btnTVDieuChinh);
            this.tabPage2.Controls.Add(this.btnTVLapDon);
            this.tabPage2.Controls.Add(this.btnXem);
            this.tabPage2.Controls.Add(this.txtDot);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtKy);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtNam);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnChonFile);
            this.tabPage2.Controls.Add(this.dgvDanhSach);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(910, 618);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hóa Đơn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnTVCapNhatQLDHN
            // 
            this.btnTVCapNhatQLDHN.Location = new System.Drawing.Point(630, 6);
            this.btnTVCapNhatQLDHN.Name = "btnTVCapNhatQLDHN";
            this.btnTVCapNhatQLDHN.Size = new System.Drawing.Size(120, 23);
            this.btnTVCapNhatQLDHN.TabIndex = 93;
            this.btnTVCapNhatQLDHN.Text = "TV Cập Nhật QLĐHN";
            this.btnTVCapNhatQLDHN.UseVisualStyleBackColor = true;
            this.btnTVCapNhatQLDHN.Click += new System.EventHandler(this.btnTVCapNhatQLDHN_Click);
            // 
            // btnTVDieuChinh
            // 
            this.btnTVDieuChinh.Location = new System.Drawing.Point(534, 6);
            this.btnTVDieuChinh.Name = "btnTVDieuChinh";
            this.btnTVDieuChinh.Size = new System.Drawing.Size(90, 23);
            this.btnTVDieuChinh.TabIndex = 92;
            this.btnTVDieuChinh.Text = "TV Điều Chỉnh";
            this.btnTVDieuChinh.UseVisualStyleBackColor = true;
            this.btnTVDieuChinh.Click += new System.EventHandler(this.btnTVDieuChinh_Click);
            // 
            // btnTVLapDon
            // 
            this.btnTVLapDon.Location = new System.Drawing.Point(438, 6);
            this.btnTVLapDon.Name = "btnTVLapDon";
            this.btnTVLapDon.Size = new System.Drawing.Size(90, 23);
            this.btnTVLapDon.TabIndex = 91;
            this.btnTVLapDon.Text = "TV Lập Đơn";
            this.btnTVLapDon.UseVisualStyleBackColor = true;
            this.btnTVLapDon.Click += new System.EventHandler(this.btnTVLapDon_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(357, 6);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 90;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // txtDot
            // 
            this.txtDot.Location = new System.Drawing.Point(301, 6);
            this.txtDot.Name = "txtDot";
            this.txtDot.Size = new System.Drawing.Size(50, 20);
            this.txtDot.TabIndex = 89;
            this.txtDot.Text = "8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Đợt";
            // 
            // txtKy
            // 
            this.txtKy.Location = new System.Drawing.Point(215, 6);
            this.txtKy.Name = "txtKy";
            this.txtKy.Size = new System.Drawing.Size(50, 20);
            this.txtKy.TabIndex = 87;
            this.txtKy.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Kỳ";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(134, 6);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(50, 20);
            this.txtNam.TabIndex = 85;
            this.txtNam.Text = "2022";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Năm";
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(15, 6);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 83;
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
            this.DCHD,
            this.MaDon,
            this.STT,
            this.Nam,
            this.Ky,
            this.Dot,
            this.UpdatedDHN,
            this.UpdatedDHN_Ngay});
            this.dgvDanhSach.Location = new System.Drawing.Point(4, 35);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.Size = new System.Drawing.Size(762, 466);
            this.dgvDanhSach.TabIndex = 82;
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
            // frmDieuChinhHangLoat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(918, 644);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmDieuChinhHangLoat";
            this.Text = "Điều Chỉnh Hàng Loạt";
            this.Load += new System.EventHandler(this.frmDieuChinhHangLoat_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnTVCapNhatQLDHN;
        private System.Windows.Forms.Button btnTVDieuChinh;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn STT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DCHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UpdatedDHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdatedDHN_Ngay;

    }
}