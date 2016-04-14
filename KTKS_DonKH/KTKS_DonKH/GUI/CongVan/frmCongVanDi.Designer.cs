namespace KTKS_DonKH.GUI.CongVan
{
    partial class frmCongVanDi
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
            this.dateChuyen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLoaiVanBan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstMa = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvDSCatChuyenDM = new System.Windows.Forms.DataGridView();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCatChuyenDM)).BeginInit();
            this.SuspendLayout();
            // 
            // dateChuyen
            // 
            this.dateChuyen.CustomFormat = "dd/MM/yyyy";
            this.dateChuyen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateChuyen.Location = new System.Drawing.Point(109, 10);
            this.dateChuyen.Name = "dateChuyen";
            this.dateChuyen.Size = new System.Drawing.Size(100, 25);
            this.dateChuyen.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ngày Chuyển:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Loại Văn Bản:";
            // 
            // cmbLoaiVanBan
            // 
            this.cmbLoaiVanBan.FormattingEnabled = true;
            this.cmbLoaiVanBan.Items.AddRange(new object[] {
            "Đơn Tổ Khách Hàng",
            "Đơn Tổ Xử Lý",
            "Kiểm Tra Xác Minh",
            "Bấm Chì",
            "Điều Chỉnh Biến Động",
            "Điều Chỉnh Hóa Đơn",
            "Cắt Tạm Danh Bộ",
            "Cắt Hủy Danh Bộ",
            "Phiếu Hủy Danh Bộ",
            "Thư Trả Lời"});
            this.cmbLoaiVanBan.Location = new System.Drawing.Point(12, 65);
            this.cmbLoaiVanBan.Name = "cmbLoaiVanBan";
            this.cmbLoaiVanBan.Size = new System.Drawing.Size(150, 25);
            this.cmbLoaiVanBan.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Từ Mã:";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(168, 65);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(70, 25);
            this.txtMa.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(320, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 25);
            this.textBox1.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Danh Bộ:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(476, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 25);
            this.textBox2.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Địa Chỉ:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(682, 65);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(200, 25);
            this.textBox3.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(677, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Nội Dung:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Đội TCTB",
            "Đội QLĐHN",
            "Đội Thu Tiền",
            "P. KHĐT",
            "P. GNKDT",
            "Ban QLDA",
            "P. Kế Toán",
            "P. TCHC",
            "P. KTCN",
            "Đội TCXL"});
            this.comboBox1.Location = new System.Drawing.Point(888, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 25);
            this.comboBox1.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(885, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Nơi Chuyển:";
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::KTKS_DonKH.Properties.Resources.save_24x24;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(994, 55);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(70, 35);
            this.btnLuu.TabIndex = 30;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(168, 113);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(70, 25);
            this.textBox4.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(165, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "Đến Mã:";
            // 
            // lstMa
            // 
            this.lstMa.FormattingEnabled = true;
            this.lstMa.ItemHeight = 17;
            this.lstMa.Location = new System.Drawing.Point(244, 65);
            this.lstMa.Name = "lstMa";
            this.lstMa.Size = new System.Drawing.Size(70, 72);
            this.lstMa.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(241, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 17);
            this.label9.TabIndex = 34;
            this.label9.Text = "Danh Sách:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(244, 165);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 25);
            this.dateTu.TabIndex = 35;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(428, 165);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 25);
            this.dateDen.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(166, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 37;
            this.label10.Text = "Từ Ngày:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(350, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 17);
            this.label11.TabIndex = 38;
            this.label11.Text = "Đến Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Image = global::KTKS_DonKH.Properties.Resources.find_24x24;
            this.btnXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXem.Location = new System.Drawing.Point(534, 162);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(70, 35);
            this.btnXem.TabIndex = 39;
            this.btnXem.Text = "Xem";
            this.btnXem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXem.UseVisualStyleBackColor = true;
            // 
            // dgvDSCatChuyenDM
            // 
            this.dgvDSCatChuyenDM.AllowUserToAddRows = false;
            this.dgvDSCatChuyenDM.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSCatChuyenDM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSCatChuyenDM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSCatChuyenDM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Loai,
            this.Ma,
            this.CreateDate,
            this.NoiDung,
            this.NoiChuyen});
            this.dgvDSCatChuyenDM.Location = new System.Drawing.Point(12, 204);
            this.dgvDSCatChuyenDM.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSCatChuyenDM.MultiSelect = false;
            this.dgvDSCatChuyenDM.Name = "dgvDSCatChuyenDM";
            this.dgvDSCatChuyenDM.RowHeadersWidth = 60;
            this.dgvDSCatChuyenDM.Size = new System.Drawing.Size(592, 414);
            this.dgvDSCatChuyenDM.TabIndex = 40;
            // 
            // Loai
            // 
            this.Loai.DataPropertyName = "Loai";
            this.Loai.HeaderText = "Loại";
            this.Loai.Name = "Loai";
            // 
            // Ma
            // 
            this.Ma.DataPropertyName = "Ma";
            this.Ma.HeaderText = "Mã";
            this.Ma.Name = "Ma";
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            // 
            // NoiChuyen
            // 
            this.NoiChuyen.DataPropertyName = "NoiChuyen";
            this.NoiChuyen.HeaderText = "Nơi Chuyển";
            this.NoiChuyen.Name = "NoiChuyen";
            // 
            // frmCongVanDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1293, 631);
            this.Controls.Add(this.dgvDSCatChuyenDM);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lstMa);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLoaiVanBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateChuyen);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCongVanDi";
            this.Text = "Công Văn Đi";
            this.Load += new System.EventHandler(this.frmCongVanDi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCatChuyenDM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateChuyen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLoaiVanBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstMa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvDSCatChuyenDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiChuyen;
    }
}