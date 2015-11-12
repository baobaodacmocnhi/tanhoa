namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmLichSuDieuChinhTienDu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvLichSuDieuChinhTienDu = new System.Windows.Forms.DataGridView();
            this.DanhBoChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTienChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBoNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuDieuChinhTienDu)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(109, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Từ Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(385, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 48;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(279, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Đến Ngày:";
            // 
            // dgvLichSuDieuChinhTienDu
            // 
            this.dgvLichSuDieuChinhTienDu.AllowUserToAddRows = false;
            this.dgvLichSuDieuChinhTienDu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichSuDieuChinhTienDu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLichSuDieuChinhTienDu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuDieuChinhTienDu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBoChuyen,
            this.SoTienChuyen,
            this.DanhBoNhan,
            this.CreateDate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichSuDieuChinhTienDu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLichSuDieuChinhTienDu.Location = new System.Drawing.Point(12, 38);
            this.dgvLichSuDieuChinhTienDu.Name = "dgvLichSuDieuChinhTienDu";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichSuDieuChinhTienDu.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvLichSuDieuChinhTienDu.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLichSuDieuChinhTienDu.Size = new System.Drawing.Size(473, 580);
            this.dgvLichSuDieuChinhTienDu.TabIndex = 83;
            this.dgvLichSuDieuChinhTienDu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLichSuDieuChinhTienDu_CellFormatting);
            this.dgvLichSuDieuChinhTienDu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLichSuDieuChinhTienDu_RowPostPaint);
            // 
            // DanhBoChuyen
            // 
            this.DanhBoChuyen.DataPropertyName = "DanhBoChuyen";
            this.DanhBoChuyen.HeaderText = "Danh Bộ Chuyển";
            this.DanhBoChuyen.Name = "DanhBoChuyen";
            // 
            // SoTienChuyen
            // 
            this.SoTienChuyen.DataPropertyName = "SoTienChuyen";
            this.SoTienChuyen.HeaderText = "Số Tiền Chuyển";
            this.SoTienChuyen.Name = "SoTienChuyen";
            // 
            // DanhBoNhan
            // 
            this.DanhBoNhan.DataPropertyName = "DanhBoNhan";
            this.DanhBoNhan.HeaderText = "Danh Bộ Nhận";
            this.DanhBoNhan.Name = "DanhBoNhan";
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // frmLichSuDieuChinhTienDu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 630);
            this.Controls.Add(this.dgvLichSuDieuChinhTienDu);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label4);
            this.Name = "frmLichSuDieuChinhTienDu";
            this.Text = "Lịch Sử Điều Chỉnh Tiền Dư";
            this.Load += new System.EventHandler(this.frmLichSuDieuChinhTien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuDieuChinhTienDu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvLichSuDieuChinhTienDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBoChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTienChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBoNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
    }
}