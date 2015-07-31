namespace ThuTien.GUI.Doi
{
    partial class frmKiemPortTon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.TieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInDS = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lstHD = new System.Windows.Forms.ListBox();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Số Hóa Đơn:";
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // SoNha
            // 
            this.SoNha.DataPropertyName = "SoNha";
            this.SoNha.HeaderText = "Số Nhà";
            this.SoNha.Name = "SoNha";
            this.SoNha.ReadOnly = true;
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            this.TongCong.ReadOnly = true;
            this.TongCong.Width = 90;
            // 
            // Duong
            // 
            this.Duong.DataPropertyName = "Duong";
            this.Duong.HeaderText = "Đường";
            this.Duong.Name = "Duong";
            this.Duong.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChonFile);
            this.groupBox1.Location = new System.Drawing.Point(5, 371);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 75);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lưu File Hóa Đơn Tồn";
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(69, 29);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 8;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(150, 168);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 24;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // TieuThu
            // 
            this.TieuThu.DataPropertyName = "TieuThu";
            this.TieuThu.HeaderText = "Tiêu Thụ";
            this.TieuThu.Name = "TieuThu";
            this.TieuThu.ReadOnly = true;
            this.TieuThu.Width = 80;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(150, 110);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 23;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.ReadOnly = true;
            this.MLT.Width = 80;
            // 
            // btnInDS
            // 
            this.btnInDS.Location = new System.Drawing.Point(150, 260);
            this.btnInDS.Name = "btnInDS";
            this.btnInDS.Size = new System.Drawing.Size(81, 23);
            this.btnInDS.TabIndex = 28;
            this.btnInDS.Text = "In Danh Sách";
            this.btnInDS.UseVisualStyleBackColor = true;
            this.btnInDS.Click += new System.EventHandler(this.btnInDS_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(433, 9);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 25;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.Loai,
            this.SoHoaDon,
            this.SoPhatHanh,
            this.Ky,
            this.MLT,
            this.TieuThu,
            this.TongCong,
            this.DanhBo,
            this.HoTen,
            this.SoNha,
            this.Duong});
            this.dgvHoaDon.Location = new System.Drawing.Point(243, 38);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(966, 652);
            this.dgvHoaDon.TabIndex = 26;
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.Name = "MaHD";
            this.MaHD.ReadOnly = true;
            this.MaHD.Visible = false;
            // 
            // Loai
            // 
            this.Loai.DataPropertyName = "Loai";
            this.Loai.HeaderText = "Loại";
            this.Loai.Name = "Loai";
            this.Loai.ReadOnly = true;
            this.Loai.Width = 50;
            // 
            // SoHoaDon
            // 
            this.SoHoaDon.DataPropertyName = "SoHoaDon";
            this.SoHoaDon.HeaderText = "Số Hóa Đơn";
            this.SoHoaDon.Name = "SoHoaDon";
            this.SoHoaDon.ReadOnly = true;
            // 
            // SoPhatHanh
            // 
            this.SoPhatHanh.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh.HeaderText = "SoPhatHanh";
            this.SoPhatHanh.Name = "SoPhatHanh";
            this.SoPhatHanh.ReadOnly = true;
            this.SoPhatHanh.Visible = false;
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.ReadOnly = true;
            this.Ky.Width = 50;
            // 
            // lstHD
            // 
            this.lstHD.FormattingEnabled = true;
            this.lstHD.Location = new System.Drawing.Point(12, 110);
            this.lstHD.Name = "lstHD";
            this.lstHD.Size = new System.Drawing.Size(120, 173);
            this.lstHD.TabIndex = 22;
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(84, 12);
            this.txtSoHoaDon.Multiline = true;
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 79);
            this.txtSoHoaDon.TabIndex = 20;
            this.txtSoHoaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHoaDon_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Danh Sách Hóa Đơn:";
            // 
            // frmKiemPortTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 700);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnInDS);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.lstHD);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.label4);
            this.Name = "frmKiemPortTon";
            this.Text = "Kiểm Port Tồn";
            this.Load += new System.EventHandler(this.frmKiemPortTon_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNha;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.Button btnInDS;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.ListBox lstHD;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.Label label4;
    }
}