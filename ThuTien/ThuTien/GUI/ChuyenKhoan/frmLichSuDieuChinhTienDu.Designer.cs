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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.dgvLichSuTienDu = new System.Windows.Forms.DataGridView();
            this.CreateDate_LSTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien_LSTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loai_LSTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBoChuyenNhan_LSTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuDieuChinhTienDu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuTienDu)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(92, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Từ Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(368, 10);
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
            this.dateDen.Location = new System.Drawing.Point(262, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 15);
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
            this.dgvLichSuDieuChinhTienDu.Location = new System.Drawing.Point(12, 39);
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
            this.dgvLichSuDieuChinhTienDu.Size = new System.Drawing.Size(463, 580);
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
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(899, 38);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.TabIndex = 95;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(775, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 94;
            this.label7.Text = "Lịch Sử Giao Dịch";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(660, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 93;
            this.label2.Text = "(enter)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(496, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 92;
            this.label5.Text = "Danh Bộ:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(554, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 91;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // dgvLichSuTienDu
            // 
            this.dgvLichSuTienDu.AllowUserToAddRows = false;
            this.dgvLichSuTienDu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichSuTienDu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLichSuTienDu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuTienDu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreateDate_LSTD,
            this.SoTien_LSTD,
            this.Loai_LSTD,
            this.DanhBoChuyenNhan_LSTD});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichSuTienDu.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLichSuTienDu.Location = new System.Drawing.Point(481, 38);
            this.dgvLichSuTienDu.Name = "dgvLichSuTienDu";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichSuTienDu.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvLichSuTienDu.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLichSuTienDu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSuTienDu.Size = new System.Drawing.Size(412, 580);
            this.dgvLichSuTienDu.TabIndex = 90;
            this.dgvLichSuTienDu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLichSuTienDu_CellFormatting);
            this.dgvLichSuTienDu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLichSuTienDu_RowPostPaint);
            // 
            // CreateDate_LSTD
            // 
            this.CreateDate_LSTD.DataPropertyName = "CreateDate";
            this.CreateDate_LSTD.HeaderText = "Ngày Lập";
            this.CreateDate_LSTD.Name = "CreateDate_LSTD";
            // 
            // SoTien_LSTD
            // 
            this.SoTien_LSTD.DataPropertyName = "SoTien";
            this.SoTien_LSTD.HeaderText = "Số Tiền";
            this.SoTien_LSTD.Name = "SoTien_LSTD";
            this.SoTien_LSTD.Width = 70;
            // 
            // Loai_LSTD
            // 
            this.Loai_LSTD.DataPropertyName = "Loai";
            this.Loai_LSTD.HeaderText = "Loại";
            this.Loai_LSTD.Name = "Loai_LSTD";
            this.Loai_LSTD.Width = 80;
            // 
            // DanhBoChuyenNhan_LSTD
            // 
            this.DanhBoChuyenNhan_LSTD.DataPropertyName = "DanhBoChuyenNhan";
            this.DanhBoChuyenNhan_LSTD.HeaderText = "Danh Bộ Chuyển/Nhận";
            this.DanhBoChuyenNhan_LSTD.Name = "DanhBoChuyenNhan_LSTD";
            // 
            // frmLichSuDieuChinhTienDu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 630);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.dgvLichSuTienDu);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuTienDu)).EndInit();
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
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.DataGridView dgvLichSuTienDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate_LSTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien_LSTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai_LSTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBoChuyenNhan_LSTD;
    }
}