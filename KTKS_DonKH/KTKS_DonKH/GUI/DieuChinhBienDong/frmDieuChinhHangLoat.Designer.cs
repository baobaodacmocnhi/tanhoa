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
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCHD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.txtDot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MLT,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.DCHD});
            this.dgvDanhSach.Location = new System.Drawing.Point(1, 41);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.Size = new System.Drawing.Size(891, 274);
            this.dgvDanhSach.TabIndex = 0;
            // 
            // MLT
            // 
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MLT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // DCHD
            // 
            this.DCHD.HeaderText = "ĐCHĐ";
            this.DCHD.Name = "DCHD";
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
            // frmDieuChinhHangLoat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1111, 668);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DCHD;
    }
}