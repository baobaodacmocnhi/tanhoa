namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmTienDu
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
            this.cmbToDot = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnInDSDuTien = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnXuatExcelTienDu = new System.Windows.Forms.Button();
            this.dateNgayGiaiTrach = new System.Windows.Forms.DateTimePicker();
            this.btnChuyenTamThu = new System.Windows.Forms.Button();
            this.cmbFromDot = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnInDSThuThem = new System.Windows.Forms.Button();
            this.txtTongCongTienAm = new System.Windows.Forms.TextBox();
            this.txtTongCongTienDu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTienDu = new System.Windows.Forms.DataGridView();
            this.DanhBo_TienDu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien_TienDu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phi_TienDu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyDate_TienDu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai_TienDu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChoXuLy_TienDu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTienAm = new System.Windows.Forms.DataGridView();
            this.DanhBo_TienAm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien_TienAm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyDate_TienAm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienDu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienAm)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbToDot
            // 
            this.cmbToDot.FormattingEnabled = true;
            this.cmbToDot.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbToDot.Location = new System.Drawing.Point(1009, 12);
            this.cmbToDot.Name = "cmbToDot";
            this.cmbToDot.Size = new System.Drawing.Size(40, 21);
            this.cmbToDot.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(953, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Đến Đợt:";
            // 
            // btnInDSDuTien
            // 
            this.btnInDSDuTien.Location = new System.Drawing.Point(942, 86);
            this.btnInDSDuTien.Name = "btnInDSDuTien";
            this.btnInDSDuTien.Size = new System.Drawing.Size(94, 23);
            this.btnInDSDuTien.TabIndex = 11;
            this.btnInDSDuTien.Text = "In DS Đủ Tiền";
            this.btnInDSDuTien.UseVisualStyleBackColor = true;
            this.btnInDSDuTien.Click += new System.EventHandler(this.btnInDSDuTien_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(613, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Double-Click để Điều Chỉnh Tiền";
            // 
            // btnXuatExcelTienDu
            // 
            this.btnXuatExcelTienDu.Location = new System.Drawing.Point(942, 271);
            this.btnXuatExcelTienDu.Name = "btnXuatExcelTienDu";
            this.btnXuatExcelTienDu.Size = new System.Drawing.Size(107, 23);
            this.btnXuatExcelTienDu.TabIndex = 14;
            this.btnXuatExcelTienDu.Text = "Xuất Excel Tiền Dư";
            this.btnXuatExcelTienDu.UseVisualStyleBackColor = true;
            this.btnXuatExcelTienDu.Click += new System.EventHandler(this.btnXuatExcelTienDu_Click);
            // 
            // dateNgayGiaiTrach
            // 
            this.dateNgayGiaiTrach.CustomFormat = "dd/MM/yyyy";
            this.dateNgayGiaiTrach.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayGiaiTrach.Location = new System.Drawing.Point(942, 245);
            this.dateNgayGiaiTrach.Name = "dateNgayGiaiTrach";
            this.dateNgayGiaiTrach.Size = new System.Drawing.Size(100, 20);
            this.dateNgayGiaiTrach.TabIndex = 13;
            // 
            // btnChuyenTamThu
            // 
            this.btnChuyenTamThu.Location = new System.Drawing.Point(942, 115);
            this.btnChuyenTamThu.Name = "btnChuyenTamThu";
            this.btnChuyenTamThu.Size = new System.Drawing.Size(100, 23);
            this.btnChuyenTamThu.TabIndex = 12;
            this.btnChuyenTamThu.Text = "Chuyển Tạm Thu";
            this.btnChuyenTamThu.UseVisualStyleBackColor = true;
            this.btnChuyenTamThu.Click += new System.EventHandler(this.btnChuyenTamThu_Click);
            // 
            // cmbFromDot
            // 
            this.cmbFromDot.FormattingEnabled = true;
            this.cmbFromDot.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbFromDot.Location = new System.Drawing.Point(907, 12);
            this.cmbFromDot.Name = "cmbFromDot";
            this.cmbFromDot.Size = new System.Drawing.Size(40, 21);
            this.cmbFromDot.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(858, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Từ Đợt:";
            // 
            // btnInDSThuThem
            // 
            this.btnInDSThuThem.Location = new System.Drawing.Point(942, 57);
            this.btnInDSThuThem.Name = "btnInDSThuThem";
            this.btnInDSThuThem.Size = new System.Drawing.Size(94, 23);
            this.btnInDSThuThem.TabIndex = 10;
            this.btnInDSThuThem.Text = "In DS Thu Thêm";
            this.btnInDSThuThem.UseVisualStyleBackColor = true;
            this.btnInDSThuThem.Click += new System.EventHandler(this.btnInDSThuThem_Click);
            // 
            // txtTongCongTienAm
            // 
            this.txtTongCongTienAm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCongTienAm.Location = new System.Drawing.Point(153, 610);
            this.txtTongCongTienAm.Name = "txtTongCongTienAm";
            this.txtTongCongTienAm.Size = new System.Drawing.Size(100, 20);
            this.txtTongCongTienAm.TabIndex = 103;
            this.txtTongCongTienAm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongCongTienDu
            // 
            this.txtTongCongTienDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCongTienDu.Location = new System.Drawing.Point(521, 610);
            this.txtTongCongTienDu.Name = "txtTongCongTienDu";
            this.txtTongCongTienDu.Size = new System.Drawing.Size(100, 20);
            this.txtTongCongTienDu.TabIndex = 102;
            this.txtTongCongTienDu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Danh Sách Danh Bộ Tiền Dư";
            // 
            // dgvTienDu
            // 
            this.dgvTienDu.AllowUserToAddRows = false;
            this.dgvTienDu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTienDu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTienDu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTienDu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo_TienDu,
            this.SoTien_TienDu,
            this.Phi_TienDu,
            this.ModifyDate_TienDu,
            this.DienThoai_TienDu,
            this.ChoXuLy_TienDu});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTienDu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTienDu.Location = new System.Drawing.Point(380, 41);
            this.dgvTienDu.Name = "dgvTienDu";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTienDu.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTienDu.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTienDu.Size = new System.Drawing.Size(551, 569);
            this.dgvTienDu.TabIndex = 4;
            this.dgvTienDu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTienDu_CellFormatting);
            this.dgvTienDu.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTienDu_CellMouseDoubleClick);
            this.dgvTienDu.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvTienDu_CellValidating);
            this.dgvTienDu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTienDu_RowPostPaint);
            // 
            // DanhBo_TienDu
            // 
            this.DanhBo_TienDu.DataPropertyName = "DanhBo";
            this.DanhBo_TienDu.HeaderText = "Danh Bộ";
            this.DanhBo_TienDu.Name = "DanhBo_TienDu";
            // 
            // SoTien_TienDu
            // 
            this.SoTien_TienDu.DataPropertyName = "SoTien";
            this.SoTien_TienDu.HeaderText = "Số Tiền";
            this.SoTien_TienDu.Name = "SoTien_TienDu";
            this.SoTien_TienDu.Width = 90;
            // 
            // Phi_TienDu
            // 
            this.Phi_TienDu.DataPropertyName = "Phi";
            this.Phi_TienDu.HeaderText = "Phí";
            this.Phi_TienDu.Name = "Phi_TienDu";
            this.Phi_TienDu.Visible = false;
            this.Phi_TienDu.Width = 70;
            // 
            // ModifyDate_TienDu
            // 
            this.ModifyDate_TienDu.DataPropertyName = "ModifyDate";
            this.ModifyDate_TienDu.HeaderText = "Cập Nhật";
            this.ModifyDate_TienDu.Name = "ModifyDate_TienDu";
            // 
            // DienThoai_TienDu
            // 
            this.DienThoai_TienDu.DataPropertyName = "DienThoai";
            this.DienThoai_TienDu.HeaderText = "Điện Thoại";
            this.DienThoai_TienDu.Name = "DienThoai_TienDu";
            this.DienThoai_TienDu.Width = 150;
            // 
            // ChoXuLy_TienDu
            // 
            this.ChoXuLy_TienDu.DataPropertyName = "ChoXuLy";
            this.ChoXuLy_TienDu.HeaderText = "Chờ Xử Lý";
            this.ChoXuLy_TienDu.Name = "ChoXuLy_TienDu";
            this.ChoXuLy_TienDu.Width = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Danh Sách Danh Bộ Tiền Âm";
            // 
            // dgvTienAm
            // 
            this.dgvTienAm.AllowUserToAddRows = false;
            this.dgvTienAm.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTienAm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTienAm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTienAm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo_TienAm,
            this.SoTien_TienAm,
            this.ModifyDate_TienAm});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTienAm.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTienAm.Location = new System.Drawing.Point(12, 41);
            this.dgvTienAm.Name = "dgvTienAm";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTienAm.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTienAm.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTienAm.Size = new System.Drawing.Size(362, 569);
            this.dgvTienAm.TabIndex = 2;
            this.dgvTienAm.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTienAm_CellFormatting);
            this.dgvTienAm.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTienAm_CellMouseDoubleClick);
            this.dgvTienAm.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTienAm_RowPostPaint);
            // 
            // DanhBo_TienAm
            // 
            this.DanhBo_TienAm.DataPropertyName = "DanhBo";
            this.DanhBo_TienAm.HeaderText = "Danh Bộ";
            this.DanhBo_TienAm.Name = "DanhBo_TienAm";
            // 
            // SoTien_TienAm
            // 
            this.SoTien_TienAm.DataPropertyName = "SoTien";
            this.SoTien_TienAm.HeaderText = "Số Tiền";
            this.SoTien_TienAm.Name = "SoTien_TienAm";
            // 
            // ModifyDate_TienAm
            // 
            this.ModifyDate_TienAm.DataPropertyName = "ModifyDate";
            this.ModifyDate_TienAm.HeaderText = "Cập Nhật";
            this.ModifyDate_TienAm.Name = "ModifyDate_TienAm";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(299, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 0;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // frmTienDu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 638);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbToDot);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnInDSDuTien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnXuatExcelTienDu);
            this.Controls.Add(this.dateNgayGiaiTrach);
            this.Controls.Add(this.btnChuyenTamThu);
            this.Controls.Add(this.cmbFromDot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnInDSThuThem);
            this.Controls.Add(this.txtTongCongTienAm);
            this.Controls.Add(this.txtTongCongTienDu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvTienDu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTienAm);
            this.KeyPreview = true;
            this.Name = "frmTienDu";
            this.Text = "Tiền Dư";
            this.Load += new System.EventHandler(this.frmTienDu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTienDu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienDu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienAm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbToDot;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnInDSDuTien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnXuatExcelTienDu;
        private System.Windows.Forms.DateTimePicker dateNgayGiaiTrach;
        private System.Windows.Forms.Button btnChuyenTamThu;
        private System.Windows.Forms.ComboBox cmbFromDot;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnInDSThuThem;
        private System.Windows.Forms.TextBox txtTongCongTienAm;
        private System.Windows.Forms.TextBox txtTongCongTienDu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvTienDu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTienAm;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_TienAm;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien_TienAm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyDate_TienAm;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_TienDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien_TienDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phi_TienDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyDate_TienDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai_TienDu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChoXuLy_TienDu;


    }
}