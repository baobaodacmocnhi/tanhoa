namespace QLVanThu
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvDSVanThuDi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDonThuDen = new System.Windows.Forms.CheckBox();
            this.chkCongVanDen = new System.Windows.Forms.CheckBox();
            this.btnXuatFileExcel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkTimeTimKiem = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dateTuNgay = new System.Windows.Forms.DateTimePicker();
            this.NgayDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoKyHieuVB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThangVB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiVB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiTrichYeuNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiNhan = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiVBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiVBName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSVanThuDi)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 651);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1366, 24);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(617, 19);
            this.toolStripStatusLabel1.Text = "Bản quyền(2013) thuộc Công ty TNHH MTV Cấp Nước Tân Hòa. Được P.CNTT phát triển";
            // 
            // dgvDSVanThuDi
            // 
            this.dgvDSVanThuDi.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSVanThuDi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSVanThuDi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSVanThuDi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayDi,
            this.SoDi,
            this.SoKyHieuVB,
            this.NgayThangVB,
            this.LoaiVB,
            this.LoaiTrichYeuNoiDung,
            this.NoiNhan,
            this.ID,
            this.LoaiVBID,
            this.LoaiVBName});
            this.dgvDSVanThuDi.Location = new System.Drawing.Point(0, 118);
            this.dgvDSVanThuDi.Name = "dgvDSVanThuDi";
            this.dgvDSVanThuDi.RowHeadersWidth = 20;
            this.dgvDSVanThuDi.Size = new System.Drawing.Size(1366, 557);
            this.dgvDSVanThuDi.TabIndex = 0;
            this.dgvDSVanThuDi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSVanThu_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(556, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nội Dung Tìm Kiếm:";
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiDungTimKiem.ForeColor = System.Drawing.Color.Red;
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(729, 38);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(300, 29);
            this.txtNoiDungTimKiem.TabIndex = 2;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDonThuDen);
            this.groupBox1.Controls.Add(this.chkCongVanDen);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại Văn Thư";
            this.groupBox1.Visible = false;
            // 
            // chkDonThuDen
            // 
            this.chkDonThuDen.AutoSize = true;
            this.chkDonThuDen.ForeColor = System.Drawing.Color.Blue;
            this.chkDonThuDen.Location = new System.Drawing.Point(11, 59);
            this.chkDonThuDen.Name = "chkDonThuDen";
            this.chkDonThuDen.Size = new System.Drawing.Size(134, 25);
            this.chkDonThuDen.TabIndex = 5;
            this.chkDonThuDen.Text = "Đơn Thư Đến";
            this.chkDonThuDen.UseVisualStyleBackColor = true;
            this.chkDonThuDen.CheckedChanged += new System.EventHandler(this.chkDonThuDen_CheckedChanged);
            // 
            // chkCongVanDen
            // 
            this.chkCongVanDen.AutoSize = true;
            this.chkCongVanDen.ForeColor = System.Drawing.Color.Blue;
            this.chkCongVanDen.Location = new System.Drawing.Point(11, 28);
            this.chkCongVanDen.Name = "chkCongVanDen";
            this.chkCongVanDen.Size = new System.Drawing.Size(141, 25);
            this.chkCongVanDen.TabIndex = 4;
            this.chkCongVanDen.Text = "Công Văn Đến";
            this.chkCongVanDen.UseVisualStyleBackColor = true;
            this.chkCongVanDen.CheckedChanged += new System.EventHandler(this.chkCongVanDen_CheckedChanged);
            // 
            // btnXuatFileExcel
            // 
            this.btnXuatFileExcel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatFileExcel.ForeColor = System.Drawing.Color.Red;
            this.btnXuatFileExcel.Location = new System.Drawing.Point(1155, 32);
            this.btnXuatFileExcel.Name = "btnXuatFileExcel";
            this.btnXuatFileExcel.Size = new System.Drawing.Size(150, 33);
            this.btnXuatFileExcel.TabIndex = 4;
            this.btnXuatFileExcel.Text = "Xuất File Excel";
            this.btnXuatFileExcel.UseVisualStyleBackColor = true;
            this.btnXuatFileExcel.Click += new System.EventHandler(this.btnXuatFileExcel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkTimeTimKiem);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dateDenNgay);
            this.groupBox2.Controls.Add(this.dateTuNgay);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(199, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khoảng Thời Gian";
            // 
            // chkTimeTimKiem
            // 
            this.chkTimeTimKiem.AutoSize = true;
            this.chkTimeTimKiem.Location = new System.Drawing.Point(251, 18);
            this.chkTimeTimKiem.Name = "chkTimeTimKiem";
            this.chkTimeTimKiem.Size = new System.Drawing.Size(68, 25);
            this.chkTimeTimKiem.TabIndex = 4;
            this.chkTimeTimKiem.Text = "Click";
            this.chkTimeTimKiem.UseVisualStyleBackColor = true;
            this.chkTimeTimKiem.CheckedChanged += new System.EventHandler(this.chkTimeTimKiem_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(10, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến Ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(10, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ Ngày:";
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dateDenNgay.Enabled = false;
            this.dateDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDenNgay.Location = new System.Drawing.Point(107, 65);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Size = new System.Drawing.Size(120, 29);
            this.dateDenNgay.TabIndex = 1;
            this.dateDenNgay.ValueChanged += new System.EventHandler(this.dateDenNgay_ValueChanged);
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dateTuNgay.Enabled = false;
            this.dateTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTuNgay.Location = new System.Drawing.Point(107, 30);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Size = new System.Drawing.Size(120, 29);
            this.dateTuNgay.TabIndex = 0;
            // 
            // NgayDi
            // 
            this.NgayDi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NgayDi.DataPropertyName = "NgayDi";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = null;
            this.NgayDi.DefaultCellStyle = dataGridViewCellStyle2;
            this.NgayDi.HeaderText = "Ngày Đi";
            this.NgayDi.Name = "NgayDi";
            this.NgayDi.Width = 85;
            // 
            // SoDi
            // 
            this.SoDi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SoDi.DataPropertyName = "SoDi";
            this.SoDi.HeaderText = "Số Đi";
            this.SoDi.Name = "SoDi";
            this.SoDi.Visible = false;
            this.SoDi.Width = 69;
            // 
            // SoKyHieuVB
            // 
            this.SoKyHieuVB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SoKyHieuVB.DataPropertyName = "SoKyHieuVB";
            this.SoKyHieuVB.HeaderText = "Số Ký Hiệu Văn Bản";
            this.SoKyHieuVB.Name = "SoKyHieuVB";
            this.SoKyHieuVB.Width = 127;
            // 
            // NgayThangVB
            // 
            this.NgayThangVB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NgayThangVB.DataPropertyName = "NgayThangVB";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = null;
            this.NgayThangVB.DefaultCellStyle = dataGridViewCellStyle3;
            this.NgayThangVB.HeaderText = "Ngày Tháng Văn Bản";
            this.NgayThangVB.Name = "NgayThangVB";
            this.NgayThangVB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NgayThangVB.Width = 110;
            // 
            // LoaiVB
            // 
            this.LoaiVB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LoaiVB.DataPropertyName = "LoaiVB";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LoaiVB.DefaultCellStyle = dataGridViewCellStyle4;
            this.LoaiVB.HeaderText = "Loại";
            this.LoaiVB.Name = "LoaiVB";
            this.LoaiVB.Width = 61;
            // 
            // LoaiTrichYeuNoiDung
            // 
            this.LoaiTrichYeuNoiDung.DataPropertyName = "LoaiTrichYeuNoiDung";
            this.LoaiTrichYeuNoiDung.HeaderText = "Loại Trích Yếu Nội Dung";
            this.LoaiTrichYeuNoiDung.Name = "LoaiTrichYeuNoiDung";
            this.LoaiTrichYeuNoiDung.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoaiTrichYeuNoiDung.Width = 650;
            // 
            // NoiNhan
            // 
            this.NoiNhan.DataPropertyName = "NoiNhan";
            this.NoiNhan.HeaderText = "Nơi Nhận";
            this.NoiNhan.Name = "NoiNhan";
            this.NoiNhan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NoiNhan.Width = 290;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // LoaiVBID
            // 
            this.LoaiVBID.DataPropertyName = "LoaiVBGID";
            this.LoaiVBID.HeaderText = "LoaiVBID";
            this.LoaiVBID.Name = "LoaiVBID";
            this.LoaiVBID.Visible = false;
            // 
            // LoaiVBName
            // 
            this.LoaiVBName.DataPropertyName = "LoaiVBGName";
            this.LoaiVBName.HeaderText = "Loại Văn Bản";
            this.LoaiVBName.Name = "LoaiVBName";
            this.LoaiVBName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LoaiVBName.Visible = false;
            this.LoaiVBName.Width = 160;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1366, 675);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnXuatFileExcel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDSVanThuDi);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Chương trình QUẢN LÝ VĂN THƯ ĐI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSVanThuDi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dgvDSVanThuDi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkDonThuDen;
        private System.Windows.Forms.CheckBox chkCongVanDen;
        private System.Windows.Forms.Button btnXuatFileExcel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDenNgay;
        private System.Windows.Forms.DateTimePicker dateTuNgay;
        private System.Windows.Forms.CheckBox chkTimeTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoKyHieuVB;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThangVB;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiVB;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiTrichYeuNoiDung;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn NoiNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiVBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiVBName;
    }
}

