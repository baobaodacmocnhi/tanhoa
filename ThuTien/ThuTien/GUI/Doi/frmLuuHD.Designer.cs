namespace ThuTien.GUI.Doi
{
    partial class frmLuuHD
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDuongDan = new System.Windows.Forms.TextBox();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTongHD0 = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtTongCong = new System.Windows.Forms.TextBox();
            this.txtTongPhiBVMT = new System.Windows.Forms.TextBox();
            this.txtTongThueGTGT = new System.Windows.Forms.TextBox();
            this.txtTongGiaBan = new System.Windows.Forms.TextBox();
            this.txtTongTieuThu = new System.Windows.Forms.TextBox();
            this.txtTongHD = new System.Windows.Forms.TextBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongThueGTGT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongPhiBVMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HD0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSoSanhKyTruoc = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường Dẫn:";
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Location = new System.Drawing.Point(83, 12);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.ReadOnly = true;
            this.txtDuongDan.Size = new System.Drawing.Size(300, 20);
            this.txtDuongDan.TabIndex = 1;
            this.txtDuongDan.TextChanged += new System.EventHandler(this.txtDuongDan_TextChanged);
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(389, 10);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 2;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(470, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSoSanhKyTruoc);
            this.groupBox1.Controls.Add(this.txtTongHD0);
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.txtTongCong);
            this.groupBox1.Controls.Add(this.txtTongPhiBVMT);
            this.groupBox1.Controls.Add(this.txtTongThueGTGT);
            this.groupBox1.Controls.Add(this.txtTongGiaBan);
            this.groupBox1.Controls.Add(this.txtTongTieuThu);
            this.groupBox1.Controls.Add(this.txtTongHD);
            this.groupBox1.Controls.Add(this.dgvHoaDon);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Controls.Add(this.cmbKy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbNam);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(824, 550);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Hóa Đơn";
            // 
            // txtTongHD0
            // 
            this.txtTongHD0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD0.Location = new System.Drawing.Point(762, 519);
            this.txtTongHD0.Name = "txtTongHD0";
            this.txtTongHD0.Size = new System.Drawing.Size(50, 20);
            this.txtTongHD0.TabIndex = 13;
            this.txtTongHD0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(561, 25);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(203, 23);
            this.progressBar.TabIndex = 12;
            // 
            // txtTongCong
            // 
            this.txtTongCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong.Location = new System.Drawing.Point(561, 519);
            this.txtTongCong.Name = "txtTongCong";
            this.txtTongCong.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong.TabIndex = 11;
            this.txtTongCong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongPhiBVMT
            // 
            this.txtTongPhiBVMT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongPhiBVMT.Location = new System.Drawing.Point(461, 519);
            this.txtTongPhiBVMT.Name = "txtTongPhiBVMT";
            this.txtTongPhiBVMT.Size = new System.Drawing.Size(100, 20);
            this.txtTongPhiBVMT.TabIndex = 10;
            this.txtTongPhiBVMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongThueGTGT
            // 
            this.txtTongThueGTGT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongThueGTGT.Location = new System.Drawing.Point(361, 519);
            this.txtTongThueGTGT.Name = "txtTongThueGTGT";
            this.txtTongThueGTGT.Size = new System.Drawing.Size(100, 20);
            this.txtTongThueGTGT.TabIndex = 9;
            this.txtTongThueGTGT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongGiaBan
            // 
            this.txtTongGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongGiaBan.Location = new System.Drawing.Point(261, 519);
            this.txtTongGiaBan.Name = "txtTongGiaBan";
            this.txtTongGiaBan.Size = new System.Drawing.Size(100, 20);
            this.txtTongGiaBan.TabIndex = 8;
            this.txtTongGiaBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongTieuThu
            // 
            this.txtTongTieuThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTieuThu.Location = new System.Drawing.Point(181, 519);
            this.txtTongTieuThu.Name = "txtTongTieuThu";
            this.txtTongTieuThu.Size = new System.Drawing.Size(80, 20);
            this.txtTongTieuThu.TabIndex = 7;
            this.txtTongTieuThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongHD
            // 
            this.txtTongHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD.Location = new System.Drawing.Point(101, 519);
            this.txtTongHD.Name = "txtTongHD";
            this.txtTongHD.Size = new System.Drawing.Size(80, 20);
            this.txtTongHD.TabIndex = 6;
            this.txtTongHD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dot,
            this.TongHD,
            this.TongTieuThu,
            this.TongGiaBan,
            this.TongThueGTGT,
            this.TongPhiBVMT,
            this.TongCong,
            this.CreateDate,
            this.HD0});
            this.dgvHoaDon.Location = new System.Drawing.Point(9, 54);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.Size = new System.Drawing.Size(805, 465);
            this.dgvHoaDon.TabIndex = 5;
            this.dgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHoaDon_CellFormatting);
            // 
            // Dot
            // 
            this.Dot.DataPropertyName = "Dot";
            this.Dot.HeaderText = "Đợt";
            this.Dot.Name = "Dot";
            this.Dot.Width = 50;
            // 
            // TongHD
            // 
            this.TongHD.DataPropertyName = "TongHD";
            this.TongHD.HeaderText = "Tổng HĐ";
            this.TongHD.Name = "TongHD";
            this.TongHD.Width = 80;
            // 
            // TongTieuThu
            // 
            this.TongTieuThu.DataPropertyName = "TongTieuThu";
            this.TongTieuThu.HeaderText = "Tiêu Thụ";
            this.TongTieuThu.Name = "TongTieuThu";
            this.TongTieuThu.Width = 80;
            // 
            // TongGiaBan
            // 
            this.TongGiaBan.DataPropertyName = "TongGiaBan";
            this.TongGiaBan.HeaderText = "Giá Bán";
            this.TongGiaBan.Name = "TongGiaBan";
            // 
            // TongThueGTGT
            // 
            this.TongThueGTGT.DataPropertyName = "TongThueGTGT";
            this.TongThueGTGT.HeaderText = "Thuế GTGT";
            this.TongThueGTGT.Name = "TongThueGTGT";
            // 
            // TongPhiBVMT
            // 
            this.TongPhiBVMT.DataPropertyName = "TongPhiBVMT";
            this.TongPhiBVMT.HeaderText = "Phí BVMT";
            this.TongPhiBVMT.Name = "TongPhiBVMT";
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Tạo";
            this.CreateDate.Name = "CreateDate";
            // 
            // HD0
            // 
            this.HD0.DataPropertyName = "HD0";
            this.HD0.HeaderText = "HĐ=0";
            this.HD0.Name = "HD0";
            this.HD0.Width = 50;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(214, 25);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 4;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbKy
            // 
            this.cmbKy.FormattingEnabled = true;
            this.cmbKy.Items.AddRange(new object[] {
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
            "12"});
            this.cmbKy.Location = new System.Drawing.Point(143, 25);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(65, 21);
            this.cmbKy.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kỳ:";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(44, 25);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(65, 21);
            this.cmbNam.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Năm:";
            // 
            // btnSoSanhKyTruoc
            // 
            this.btnSoSanhKyTruoc.Location = new System.Drawing.Point(295, 25);
            this.btnSoSanhKyTruoc.Name = "btnSoSanhKyTruoc";
            this.btnSoSanhKyTruoc.Size = new System.Drawing.Size(105, 23);
            this.btnSoSanhKyTruoc.TabIndex = 14;
            this.btnSoSanhKyTruoc.Text = "So Sánh Kỳ Trước";
            this.btnSoSanhKyTruoc.UseVisualStyleBackColor = true;
            this.btnSoSanhKyTruoc.Click += new System.EventHandler(this.btnSoSanhKyTruoc_Click);
            // 
            // frmLuuHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 623);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.txtDuongDan);
            this.Controls.Add(this.label1);
            this.Name = "frmLuuHD";
            this.Text = "Lưu Hoá Đơn";
            this.Load += new System.EventHandler(this.frmLuuHoaDon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDuongDan;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongCong;
        private System.Windows.Forms.TextBox txtTongPhiBVMT;
        private System.Windows.Forms.TextBox txtTongThueGTGT;
        private System.Windows.Forms.TextBox txtTongGiaBan;
        private System.Windows.Forms.TextBox txtTongTieuThu;
        private System.Windows.Forms.TextBox txtTongHD;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongThueGTGT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongPhiBVMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn HD0;
        private System.Windows.Forms.TextBox txtTongHD0;
        private System.Windows.Forms.Button btnSoSanhKyTruoc;
    }
}