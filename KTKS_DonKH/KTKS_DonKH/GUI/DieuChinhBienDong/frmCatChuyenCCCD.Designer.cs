namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmCatChuyenCCCD
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
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.radCongTy = new System.Windows.Forms.RadioButton();
            this.radTCT = new System.Windows.Forms.RadioButton();
            this.DanhBoCu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBoMoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViCu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViMoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hinh = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBoCu,
            this.DanhBoMoi,
            this.DonViCu,
            this.DonViMoi,
            this.NoiDung,
            this.Hinh});
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 64);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDanhSach.Size = new System.Drawing.Size(847, 457);
            this.dgvDanhSach.TabIndex = 1;
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(202, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 17;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(375, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Từ Ngày:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Đến Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(471, 11);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 21;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // radCongTy
            // 
            this.radCongTy.AutoSize = true;
            this.radCongTy.Checked = true;
            this.radCongTy.Location = new System.Drawing.Point(12, 12);
            this.radCongTy.Name = "radCongTy";
            this.radCongTy.Size = new System.Drawing.Size(77, 20);
            this.radCongTy.TabIndex = 22;
            this.radCongTy.TabStop = true;
            this.radCongTy.Text = "Công Ty";
            this.radCongTy.UseVisualStyleBackColor = true;
            // 
            // radTCT
            // 
            this.radTCT.AutoSize = true;
            this.radTCT.Location = new System.Drawing.Point(12, 38);
            this.radTCT.Name = "radTCT";
            this.radTCT.Size = new System.Drawing.Size(120, 20);
            this.radTCT.TabIndex = 23;
            this.radTCT.Text = "Chi Nhánh Khác";
            this.radTCT.UseVisualStyleBackColor = true;
            // 
            // DanhBoCu
            // 
            this.DanhBoCu.DataPropertyName = "DanhBoCu";
            this.DanhBoCu.HeaderText = "Danh Bộ Cũ";
            this.DanhBoCu.Name = "DanhBoCu";
            // 
            // DanhBoMoi
            // 
            this.DanhBoMoi.DataPropertyName = "DanhBoMoi";
            this.DanhBoMoi.HeaderText = "Danh Bộ Mới";
            this.DanhBoMoi.Name = "DanhBoMoi";
            // 
            // DonViCu
            // 
            this.DonViCu.DataPropertyName = "DonViCu";
            this.DonViCu.HeaderText = "Chi Nhánh Cũ";
            this.DonViCu.Name = "DonViCu";
            // 
            // DonViMoi
            // 
            this.DonViMoi.DataPropertyName = "DonViMoi";
            this.DonViMoi.HeaderText = "Chi Nhánh Mới";
            this.DonViMoi.Name = "DonViMoi";
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            // 
            // Hinh
            // 
            this.Hinh.HeaderText = "Hình";
            this.Hinh.Name = "Hinh";
            this.Hinh.Text = "Xem";
            // 
            // frmCatChuyenCCCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(871, 533);
            this.Controls.Add(this.radTCT);
            this.Controls.Add(this.radCongTy);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvDanhSach);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCatChuyenCCCD";
            this.Text = "Cắt Chuyển CCCD";
            this.Load += new System.EventHandler(this.frmCatChuyenCCCD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.RadioButton radCongTy;
        private System.Windows.Forms.RadioButton radTCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBoCu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBoMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViCu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewButtonColumn Hinh;
    }
}