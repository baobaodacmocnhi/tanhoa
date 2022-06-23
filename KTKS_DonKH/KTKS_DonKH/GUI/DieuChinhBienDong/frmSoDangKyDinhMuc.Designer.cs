namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmSoDangKyDinhMuc
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaCT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNKTong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNKDangKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFileBilling = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số Sổ";
            // 
            // txtMaCT
            // 
            this.txtMaCT.Location = new System.Drawing.Point(117, 13);
            this.txtMaCT.Name = "txtMaCT";
            this.txtMaCT.Size = new System.Drawing.Size(114, 22);
            this.txtMaCT.TabIndex = 1;
            this.txtMaCT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaCT_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "(enter)";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(294, 11);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(86, 25);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Loai,
            this.TenLCT,
            this.MaCT,
            this.SoNKTong,
            this.DanhBo,
            this.SoNKDangKy,
            this.CreateDate});
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 41);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.Size = new System.Drawing.Size(914, 320);
            this.dgvDanhSach.TabIndex = 38;
            // 
            // Loai
            // 
            this.Loai.DataPropertyName = "Loai";
            this.Loai.HeaderText = "Loại";
            this.Loai.Name = "Loai";
            // 
            // TenLCT
            // 
            this.TenLCT.DataPropertyName = "TenLCT";
            this.TenLCT.HeaderText = "Loại Chứng Từ";
            this.TenLCT.Name = "TenLCT";
            this.TenLCT.Width = 120;
            // 
            // MaCT
            // 
            this.MaCT.DataPropertyName = "MaCT";
            this.MaCT.HeaderText = "Số Sổ";
            this.MaCT.Name = "MaCT";
            // 
            // SoNKTong
            // 
            this.SoNKTong.DataPropertyName = "SoNKTong";
            this.SoNKTong.HeaderText = "Số NK Tổng";
            this.SoNKTong.Name = "SoNKTong";
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // SoNKDangKy
            // 
            this.SoNKDangKy.DataPropertyName = "SoNKDangKy";
            this.SoNKDangKy.HeaderText = "Số NK Đăng Ký";
            this.SoNKDangKy.Name = "SoNKDangKy";
            this.SoNKDangKy.Width = 120;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // btnFileBilling
            // 
            this.btnFileBilling.Location = new System.Drawing.Point(386, 11);
            this.btnFileBilling.Name = "btnFileBilling";
            this.btnFileBilling.Size = new System.Drawing.Size(130, 25);
            this.btnFileBilling.TabIndex = 39;
            this.btnFileBilling.Text = "Xuất CCCD Billing";
            this.btnFileBilling.UseVisualStyleBackColor = true;
            this.btnFileBilling.Click += new System.EventHandler(this.btnFileBilling_Click);
            // 
            // frmSoDangKyDinhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(983, 506);
            this.Controls.Add(this.btnFileBilling);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaCT);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "frmSoDangKyDinhMuc";
            this.Text = "Quản Lý Sổ Đăng Ký Định Mức";
            this.Load += new System.EventHandler(this.frmSoDangKyDinhMuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaCT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNKTong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNKDangKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.Button btnFileBilling;
    }
}