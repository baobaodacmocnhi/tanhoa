namespace KTKS_DonKH.GUI.DonTu
{
    partial class frmDonTu_Scan
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvScan = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.dgvHinh = new System.Windows.Forms.DataGridView();
            this.ID_Hinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image_Hinh = new System.Windows.Forms.DataGridViewImageColumn();
            this.Name_Hinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bytes_Hinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loai_Hinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNguoiBao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xoaFile_dgvHinh = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHinh)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(92, 11);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(111, 23);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(92, 39);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(111, 23);
            this.txtDienThoai.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Điện Thoại";
            // 
            // dgvScan
            // 
            this.dgvScan.AllowUserToAddRows = false;
            this.dgvScan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Column3,
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column2,
            this.Column6});
            this.dgvScan.Location = new System.Drawing.Point(6, 48);
            this.dgvScan.MultiSelect = false;
            this.dgvScan.Name = "dgvScan";
            this.dgvScan.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvScan.Size = new System.Drawing.Size(820, 452);
            this.dgvScan.TabIndex = 91;
            this.dgvScan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScan_CellClick);
            this.dgvScan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvScan_RowPostPaint);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CreateDate";
            this.Column3.HeaderText = "Ngày Lập";
            this.Column3.Name = "Column3";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DanhBo";
            this.Column1.HeaderText = "Danh Bộ";
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "HoTen";
            this.Column4.HeaderText = "Khách Hàng";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DiaChi";
            this.Column5.HeaderText = "Địa Chỉ";
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DienThoai";
            this.Column2.HeaderText = "Điện Thoại";
            this.Column2.Name = "Column2";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NguoiBao";
            this.Column6.HeaderText = "Người Báo";
            this.Column6.Name = "Column6";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateDen);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dateTu);
            this.groupBox1.Controls.Add(this.dgvScan);
            this.groupBox1.Location = new System.Drawing.Point(13, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 506);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(436, 17);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(83, 25);
            this.btnXem.TabIndex = 136;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(253, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 135;
            this.label7.Text = "Đến Ngày";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(330, 18);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 23);
            this.dateDen.TabIndex = 134;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(79, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 17);
            this.label16.TabIndex = 133;
            this.label16.Text = "Từ Ngày";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(147, 18);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 23);
            this.dateTu.TabIndex = 132;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChonFile);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.dgvHinh);
            this.groupBox2.Location = new System.Drawing.Point(852, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 362);
            this.groupBox2.TabIndex = 93;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi Tiết";
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(27, 22);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 25);
            this.btnChonFile.TabIndex = 34;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.Red;
            this.label30.Location = new System.Drawing.Point(108, 26);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(156, 17);
            this.label30.TabIndex = 33;
            this.label30.Text = "Chuột Phải để XÓA File";
            // 
            // dgvHinh
            // 
            this.dgvHinh.AllowUserToAddRows = false;
            this.dgvHinh.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHinh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Hinh,
            this.Image_Hinh,
            this.Name_Hinh,
            this.Bytes_Hinh,
            this.Loai_Hinh});
            this.dgvHinh.Location = new System.Drawing.Point(6, 53);
            this.dgvHinh.Name = "dgvHinh";
            this.dgvHinh.Size = new System.Drawing.Size(267, 300);
            this.dgvHinh.TabIndex = 11;
            this.dgvHinh.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHinh_CellMouseClick);
            this.dgvHinh.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHinh_RowPostPaint);
            this.dgvHinh.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvHinh_MouseClick);
            this.dgvHinh.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvHinh_MouseDoubleClick);
            // 
            // ID_Hinh
            // 
            this.ID_Hinh.DataPropertyName = "ID";
            this.ID_Hinh.HeaderText = "ID";
            this.ID_Hinh.Name = "ID_Hinh";
            this.ID_Hinh.Visible = false;
            // 
            // Image_Hinh
            // 
            this.Image_Hinh.HeaderText = "Image";
            this.Image_Hinh.Image = global::KTKS_DonKH.Properties.Resources.file_24x24;
            this.Image_Hinh.Name = "Image_Hinh";
            this.Image_Hinh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Image_Hinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Image_Hinh.Width = 50;
            // 
            // Name_Hinh
            // 
            this.Name_Hinh.DataPropertyName = "Name";
            this.Name_Hinh.HeaderText = "File";
            this.Name_Hinh.Name = "Name_Hinh";
            this.Name_Hinh.Width = 150;
            // 
            // Bytes_Hinh
            // 
            this.Bytes_Hinh.DataPropertyName = "Bytes";
            this.Bytes_Hinh.HeaderText = "Bytes";
            this.Bytes_Hinh.Name = "Bytes_Hinh";
            this.Bytes_Hinh.Visible = false;
            // 
            // Loai_Hinh
            // 
            this.Loai_Hinh.DataPropertyName = "Loai";
            this.Loai_Hinh.HeaderText = "Loai";
            this.Loai_Hinh.Name = "Loai_Hinh";
            this.Loai_Hinh.Visible = false;
            // 
            // txtNguoiBao
            // 
            this.txtNguoiBao.Location = new System.Drawing.Point(92, 67);
            this.txtNguoiBao.Name = "txtNguoiBao";
            this.txtNguoiBao.Size = new System.Drawing.Size(111, 23);
            this.txtNguoiBao.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 94;
            this.label3.Text = "Người Báo";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(269, 39);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(83, 25);
            this.btnThem.TabIndex = 96;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(269, 70);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(83, 25);
            this.btnXoa.TabIndex = 97;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(358, 11);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(166, 23);
            this.txtHoTen.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 98;
            this.label4.Text = "Khách Hàng";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(589, 11);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(222, 23);
            this.txtDiaChi.TabIndex = 101;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 100;
            this.label5.Text = "Địa Chỉ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 17);
            this.label6.TabIndex = 102;
            this.label6.Text = "(enter)";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xoaFile_dgvHinh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // xoaFile_dgvHinh
            // 
            this.xoaFile_dgvHinh.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoaFile_dgvHinh.Name = "xoaFile_dgvHinh";
            this.xoaFile_dgvHinh.Size = new System.Drawing.Size(100, 22);
            this.xoaFile_dgvHinh.Text = "Xóa";
            this.xoaFile_dgvHinh.Click += new System.EventHandler(this.xoaFile_dgvHinh_Click);
            // 
            // frmDonTu_Scan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1334, 622);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtNguoiBao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDonTu_Scan";
            this.Text = "Đơn Từ Scan";
            this.Load += new System.EventHandler(this.frmDonTu_Scan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHinh)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvScan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvHinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Hinh;
        private System.Windows.Forms.DataGridViewImageColumn Image_Hinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Hinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bytes_Hinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai_Hinh;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtNguoiBao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xoaFile_dgvHinh;
    }
}