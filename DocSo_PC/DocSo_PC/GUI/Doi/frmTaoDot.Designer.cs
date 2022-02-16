namespace DocSo_PC.GUI.Doi
{
    partial class frmTaoDot
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDateBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDateTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaoDot = new System.Windows.Forms.DataGridViewButtonColumn();
            this.KiemTra = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chot = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BillID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.txtDuongDan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongHD = new System.Windows.Forms.TextBox();
            this.txtTongBD = new System.Windows.Forms.TextBox();
            this.txtTongTD = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTongTD);
            this.groupBox1.Controls.Add(this.txtTongBD);
            this.groupBox1.Controls.Add(this.txtTongHD);
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.dgvDanhSach);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Controls.Add(this.cmbKy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbNam);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 566);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Hóa Đơn";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(388, 25);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(203, 23);
            this.progressBar.TabIndex = 12;
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
            this.Dot,
            this.TongHD,
            this.TongBD,
            this.TongTD,
            this.CreateDateBD,
            this.CreateDateTD,
            this.TaoDot,
            this.KiemTra,
            this.Nam,
            this.Ky,
            this.Chot,
            this.BillID});
            this.dgvDanhSach.Location = new System.Drawing.Point(9, 54);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.Size = new System.Drawing.Size(695, 480);
            this.dgvDanhSach.TabIndex = 5;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            this.dgvDanhSach.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellValueChanged);
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
            this.TongHD.HeaderText = "Tổng HĐ Kỳ Trước";
            this.TongHD.Name = "TongHD";
            this.TongHD.Width = 80;
            // 
            // TongBD
            // 
            this.TongBD.DataPropertyName = "TongBD";
            this.TongBD.HeaderText = "Tổng BĐ";
            this.TongBD.Name = "TongBD";
            this.TongBD.Width = 80;
            // 
            // TongTD
            // 
            this.TongTD.DataPropertyName = "TongTD";
            this.TongTD.HeaderText = "Tổng TĐ";
            this.TongTD.Name = "TongTD";
            this.TongTD.Width = 80;
            // 
            // CreateDateBD
            // 
            this.CreateDateBD.DataPropertyName = "CreateDateBD";
            this.CreateDateBD.HeaderText = "Ngày Lập BĐ";
            this.CreateDateBD.Name = "CreateDateBD";
            // 
            // CreateDateTD
            // 
            this.CreateDateTD.DataPropertyName = "CreateDateTD";
            this.CreateDateTD.HeaderText = "Ngày Lập TĐ";
            this.CreateDateTD.Name = "CreateDateTD";
            // 
            // TaoDot
            // 
            this.TaoDot.HeaderText = "Tạo Đợt";
            this.TaoDot.Name = "TaoDot";
            this.TaoDot.Text = "Tạo Đợt";
            this.TaoDot.UseColumnTextForButtonValue = true;
            this.TaoDot.Width = 70;
            // 
            // KiemTra
            // 
            this.KiemTra.HeaderText = "Chỉ Số Nền";
            this.KiemTra.Name = "KiemTra";
            this.KiemTra.Text = "Kiểm Tra";
            this.KiemTra.UseColumnTextForButtonValue = true;
            this.KiemTra.Width = 70;
            // 
            // Nam
            // 
            this.Nam.DataPropertyName = "Nam";
            this.Nam.HeaderText = "Năm";
            this.Nam.Name = "Nam";
            this.Nam.Visible = false;
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.Visible = false;
            // 
            // Chot
            // 
            this.Chot.DataPropertyName = "Chot";
            this.Chot.HeaderText = "Chốt";
            this.Chot.Name = "Chot";
            this.Chot.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Chot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Chot.ThreeState = true;
            this.Chot.Visible = false;
            this.Chot.Width = 50;
            // 
            // BillID
            // 
            this.BillID.DataPropertyName = "BillID";
            this.BillID.HeaderText = "BillID";
            this.BillID.Name = "BillID";
            this.BillID.Visible = false;
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
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(517, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 23);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm File Biến Động";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(391, 5);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(120, 23);
            this.btnChonFile.TabIndex = 7;
            this.btnChonFile.Text = "Chọn File Biến Động";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Location = new System.Drawing.Point(85, 7);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.ReadOnly = true;
            this.txtDuongDan.Size = new System.Drawing.Size(300, 20);
            this.txtDuongDan.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Đường Dẫn:";
            // 
            // txtTongHD
            // 
            this.txtTongHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD.Location = new System.Drawing.Point(101, 534);
            this.txtTongHD.Name = "txtTongHD";
            this.txtTongHD.Size = new System.Drawing.Size(80, 20);
            this.txtTongHD.TabIndex = 13;
            this.txtTongHD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongBD
            // 
            this.txtTongBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongBD.Location = new System.Drawing.Point(181, 534);
            this.txtTongBD.Name = "txtTongBD";
            this.txtTongBD.Size = new System.Drawing.Size(80, 20);
            this.txtTongBD.TabIndex = 14;
            this.txtTongBD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongTD
            // 
            this.txtTongTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTD.Location = new System.Drawing.Point(261, 534);
            this.txtTongTD.Name = "txtTongTD";
            this.txtTongTD.Size = new System.Drawing.Size(80, 20);
            this.txtTongTD.TabIndex = 15;
            this.txtTongTD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmTaoDot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 630);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.txtDuongDan);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "frmTaoDot";
            this.Text = "Tạo Dữ Liệu Đọc Số";
            this.Load += new System.EventHandler(this.frmTaoDot_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.TextBox txtDuongDan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDateBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDateTD;
        private System.Windows.Forms.DataGridViewButtonColumn TaoDot;
        private System.Windows.Forms.DataGridViewButtonColumn KiemTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chot;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillID;
        private System.Windows.Forms.TextBox txtTongTD;
        private System.Windows.Forms.TextBox txtTongBD;
        private System.Windows.Forms.TextBox txtTongHD;

    }
}