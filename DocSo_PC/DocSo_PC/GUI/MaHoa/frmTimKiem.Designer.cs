namespace DocSo_PC.GUI.MaHoa
{
    partial class frmTimKiem
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbDot = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMay = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChiDHN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChiHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoThan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKiemDinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1392, 621);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkAll);
            this.tabPage1.Controls.Add(this.dgvDanhSach);
            this.tabPage1.Controls.Add(this.btnXem);
            this.tabPage1.Controls.Add(this.cmbDot);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmbMay);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1384, 595);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Địa Chỉ Sai Lệch";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(320, 9);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(103, 17);
            this.chkAll.TabIndex = 65;
            this.chkAll.Text = "Tất Cả Danh Bộ";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MLT,
            this.DanhBo,
            this.HoTen,
            this.GiaBieu,
            this.DiaChiDHN,
            this.DiaChiHD,
            this.Phuong,
            this.Quan,
            this.Co,
            this.Hieu,
            this.SoThan,
            this.NgayThay,
            this.NgayKiemDinh});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSach.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.Location = new System.Drawing.Point(3, 34);
            this.dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDanhSach.Size = new System.Drawing.Size(1348, 553);
            this.dgvDanhSach.TabIndex = 64;
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(429, 6);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 63;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbDot
            // 
            this.cmbDot.FormattingEnabled = true;
            this.cmbDot.Items.AddRange(new object[] {
            "Tất Cả",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
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
            this.cmbDot.Location = new System.Drawing.Point(176, 6);
            this.cmbDot.Name = "cmbDot";
            this.cmbDot.Size = new System.Drawing.Size(39, 21);
            this.cmbDot.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "Đợt";
            // 
            // cmbMay
            // 
            this.cmbMay.FormattingEnabled = true;
            this.cmbMay.Location = new System.Drawing.Point(254, 6);
            this.cmbMay.Name = "cmbMay";
            this.cmbMay.Size = new System.Drawing.Size(60, 21);
            this.cmbMay.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Máy";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1255, 595);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bảng Tiêu Thụ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.Width = 80;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.Width = 80;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 150;
            // 
            // GiaBieu
            // 
            this.GiaBieu.DataPropertyName = "GiaBieu";
            this.GiaBieu.HeaderText = "Giá Biểu";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.Width = 50;
            // 
            // DiaChiDHN
            // 
            this.DiaChiDHN.DataPropertyName = "DiaChiDHN";
            this.DiaChiDHN.HeaderText = "Địa Chỉ ĐHN";
            this.DiaChiDHN.Name = "DiaChiDHN";
            this.DiaChiDHN.Width = 200;
            // 
            // DiaChiHD
            // 
            this.DiaChiHD.DataPropertyName = "DiaChiHD";
            this.DiaChiHD.HeaderText = "Địa Chỉ HĐ";
            this.DiaChiHD.Name = "DiaChiHD";
            this.DiaChiHD.Width = 200;
            // 
            // Phuong
            // 
            this.Phuong.DataPropertyName = "Phuong";
            this.Phuong.HeaderText = "Phường";
            this.Phuong.Name = "Phuong";
            this.Phuong.Width = 50;
            // 
            // Quan
            // 
            this.Quan.DataPropertyName = "Quan";
            this.Quan.HeaderText = "Quận";
            this.Quan.Name = "Quan";
            this.Quan.Width = 50;
            // 
            // Co
            // 
            this.Co.DataPropertyName = "Co";
            this.Co.HeaderText = "Cỡ";
            this.Co.Name = "Co";
            this.Co.Width = 50;
            // 
            // Hieu
            // 
            this.Hieu.DataPropertyName = "Hieu";
            this.Hieu.HeaderText = "Hiệu";
            this.Hieu.Name = "Hieu";
            this.Hieu.Width = 80;
            // 
            // SoThan
            // 
            this.SoThan.DataPropertyName = "SoThan";
            this.SoThan.HeaderText = "Số Thân";
            this.SoThan.Name = "SoThan";
            // 
            // NgayThay
            // 
            this.NgayThay.DataPropertyName = "NgayThay";
            this.NgayThay.HeaderText = "Ngày Thay";
            this.NgayThay.Name = "NgayThay";
            // 
            // NgayKiemDinh
            // 
            this.NgayKiemDinh.DataPropertyName = "NgayKiemDinh";
            this.NgayKiemDinh.HeaderText = "Ngày Kiểm Định";
            this.NgayKiemDinh.Name = "NgayKiemDinh";
            // 
            // frmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 621);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmTimKiem";
            this.Text = "Tìm Kiếm";
            this.Load += new System.EventHandler(this.frmTimKiem_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cmbDot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChiDHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChiHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Co;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoThan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThay;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKiemDinh;
    }
}