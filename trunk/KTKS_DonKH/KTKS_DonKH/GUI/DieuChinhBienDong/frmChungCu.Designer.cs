namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmChungCu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHopDong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvKhachHangChungCu = new System.Windows.Forms.DataGridView();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNKTong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNKDangKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHetHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIn = new System.Windows.Forms.Button();
            this.txtMaCT_TimKiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.thêmThuộcĐịaBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHangChungCu)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHopDong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDanhBo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(429, 43);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(470, 25);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa Chỉ";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(223, 43);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(200, 25);
            this.txtHoTen.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách Hàng";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(117, 43);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.ReadOnly = true;
            this.txtHopDong.Size = new System.Drawing.Size(100, 25);
            this.txtHopDong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hợp Đồng";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(11, 43);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 25);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ";
            // 
            // dgvKhachHangChungCu
            // 
            this.dgvKhachHangChungCu.AllowUserToAddRows = false;
            this.dgvKhachHangChungCu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhachHangChungCu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhachHangChungCu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHangChungCu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo,
            this.Lo,
            this.Phong,
            this.TenLCT,
            this.MaLCT,
            this.MaCT,
            this.DiaChi,
            this.SoNKTong,
            this.SoNKDangKy,
            this.ThoiHan,
            this.NgayHetHan,
            this.GhiChu});
            this.dgvKhachHangChungCu.Location = new System.Drawing.Point(2, 88);
            this.dgvKhachHangChungCu.Name = "dgvKhachHangChungCu";
            this.dgvKhachHangChungCu.Size = new System.Drawing.Size(1350, 455);
            this.dgvKhachHangChungCu.TabIndex = 5;
            this.dgvKhachHangChungCu.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvKhachHangChungCu_CellMouseClick);
            this.dgvKhachHangChungCu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvKhachHangChungCu_RowPostPaint);
            this.dgvKhachHangChungCu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvKhachHangChungCu_MouseClick);
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "DanhBo";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.Visible = false;
            // 
            // Lo
            // 
            this.Lo.DataPropertyName = "Lo";
            this.Lo.HeaderText = "Lô";
            this.Lo.Name = "Lo";
            this.Lo.ReadOnly = true;
            this.Lo.Width = 130;
            // 
            // Phong
            // 
            this.Phong.DataPropertyName = "Phong";
            this.Phong.HeaderText = "Phòng";
            this.Phong.Name = "Phong";
            this.Phong.ReadOnly = true;
            this.Phong.Width = 130;
            // 
            // TenLCT
            // 
            this.TenLCT.DataPropertyName = "TenLCT";
            this.TenLCT.HeaderText = "Loại Chứng Từ";
            this.TenLCT.Name = "TenLCT";
            this.TenLCT.Width = 150;
            // 
            // MaLCT
            // 
            this.MaLCT.DataPropertyName = "MaLCT";
            this.MaLCT.HeaderText = "Loại Chứng Từ";
            this.MaLCT.Name = "MaLCT";
            this.MaLCT.ReadOnly = true;
            this.MaLCT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaLCT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MaLCT.Visible = false;
            this.MaLCT.Width = 150;
            // 
            // MaCT
            // 
            this.MaCT.DataPropertyName = "MaCT";
            this.MaCT.HeaderText = "Số Chứng Từ";
            this.MaCT.Name = "MaCT";
            this.MaCT.ReadOnly = true;
            this.MaCT.Width = 130;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 200;
            // 
            // SoNKTong
            // 
            this.SoNKTong.DataPropertyName = "SoNKTong";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SoNKTong.DefaultCellStyle = dataGridViewCellStyle2;
            this.SoNKTong.HeaderText = "Tổng NK";
            this.SoNKTong.Name = "SoNKTong";
            this.SoNKTong.ReadOnly = true;
            this.SoNKTong.Width = 50;
            // 
            // SoNKDangKy
            // 
            this.SoNKDangKy.DataPropertyName = "SoNKDangKy";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SoNKDangKy.DefaultCellStyle = dataGridViewCellStyle3;
            this.SoNKDangKy.HeaderText = "Số NK Đăng Ký";
            this.SoNKDangKy.Name = "SoNKDangKy";
            this.SoNKDangKy.ReadOnly = true;
            this.SoNKDangKy.Width = 90;
            // 
            // ThoiHan
            // 
            this.ThoiHan.DataPropertyName = "ThoiHan";
            this.ThoiHan.HeaderText = "Thời Hạn";
            this.ThoiHan.Name = "ThoiHan";
            this.ThoiHan.ReadOnly = true;
            this.ThoiHan.Width = 60;
            // 
            // NgayHetHan
            // 
            this.NgayHetHan.DataPropertyName = "NgayHetHan";
            this.NgayHetHan.HeaderText = "Ngày Hết Hạn";
            this.NgayHetHan.Name = "NgayHetHan";
            this.NgayHetHan.ReadOnly = true;
            this.NgayHetHan.Width = 90;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            this.GhiChu.Width = 300;
            // 
            // btnIn
            // 
            this.btnIn.Image = global::KTKS_DonKH.Properties.Resources.print_24x24;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(1139, 12);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(123, 35);
            this.btnIn.TabIndex = 23;
            this.btnIn.Text = "In Danh Sách";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // txtMaCT_TimKiem
            // 
            this.txtMaCT_TimKiem.Location = new System.Drawing.Point(929, 48);
            this.txtMaCT_TimKiem.Name = "txtMaCT_TimKiem";
            this.txtMaCT_TimKiem.Size = new System.Drawing.Size(100, 25);
            this.txtMaCT_TimKiem.TabIndex = 22;
            this.txtMaCT_TimKiem.TextChanged += new System.EventHandler(this.txtMaCT_TimKiem_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(926, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Số Chứng Từ Tìm Kiếm";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmThuộcĐịaBànToolStripMenuItem,
            this.sửaToolStripMenuItem,
            this.nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(272, 70);
            // 
            // thêmThuộcĐịaBànToolStripMenuItem
            // 
            this.thêmThuộcĐịaBànToolStripMenuItem.Enabled = false;
            this.thêmThuộcĐịaBànToolStripMenuItem.Name = "thêmThuộcĐịaBànToolStripMenuItem";
            this.thêmThuộcĐịaBànToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.thêmThuộcĐịaBànToolStripMenuItem.Text = "Thêm (Thuộc Địa Bàn)";
            this.thêmThuộcĐịaBànToolStripMenuItem.Click += new System.EventHandler(this.thêmThuộcĐịaBànToolStripMenuItem_Click);
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Enabled = false;
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.sửaToolStripMenuItem.Text = "Sửa";
            this.sửaToolStripMenuItem.Click += new System.EventHandler(this.sửaToolStripMenuItem_Click);
            // 
            // nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem
            // 
            this.nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem.Enabled = false;
            this.nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem.Name = "nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem";
            this.nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem.Text = "Nhận Định Mức (Khác Địa Bàn)";
            this.nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem.Click += new System.EventHandler(this.nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem_Click);
            // 
            // frmChungCu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1356, 553);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.txtMaCT_TimKiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvKhachHangChungCu);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChungCu";
            this.Text = "Nhập Định Mức Chung Cư";
            this.Load += new System.EventHandler(this.frmChungCu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChungCu_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHangChungCu)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHopDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvKhachHangChungCu;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.TextBox txtMaCT_TimKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNKTong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNKDangKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHetHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thêmThuộcĐịaBànToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem;
    }
}