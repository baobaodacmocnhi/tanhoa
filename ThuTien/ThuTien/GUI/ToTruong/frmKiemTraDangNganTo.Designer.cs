namespace ThuTien.GUI.ToTruong
{
    partial class frmKiemTraDangNganTo
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
            this.lbTo = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTuGia = new System.Windows.Forms.TabPage();
            this.txtTongGiaBan_TG = new System.Windows.Forms.TextBox();
            this.txtTongThueGTGT_TG = new System.Windows.Forms.TextBox();
            this.txtTongPhiBVMT_TG = new System.Windows.Forms.TextBox();
            this.txtTongCong_TG = new System.Windows.Forms.TextBox();
            this.txtTongHD_TG = new System.Windows.Forms.TextBox();
            this.dgvHDTuGia = new System.Windows.Forms.DataGridView();
            this.MaHD_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHD_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongGiaBan_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongThueGTGT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongPhiBVMT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCoQuan = new System.Windows.Forms.TabPage();
            this.txtTongGiaBan_CQ = new System.Windows.Forms.TextBox();
            this.txtTongThueGTGT_CQ = new System.Windows.Forms.TextBox();
            this.txtTongPhiBVMT_CQ = new System.Windows.Forms.TextBox();
            this.txtTongCong_CQ = new System.Windows.Forms.TextBox();
            this.txtTongHD_CQ = new System.Windows.Forms.TextBox();
            this.dgvHDCoQuan = new System.Windows.Forms.DataGridView();
            this.MaHD_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHD_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongGiaBan_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongThueGTGT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongPhiBVMT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.dateGiaiTrach = new System.Windows.Forms.DateTimePicker();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnInDSCoThuHo = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabTuGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).BeginInit();
            this.tabCoQuan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTo.Location = new System.Drawing.Point(110, 9);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(32, 19);
            this.lbTo.TabIndex = 15;
            this.lbTo.Text = "Tổ:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(412, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 14;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTuGia);
            this.tabControl.Controls.Add(this.tabCoQuan);
            this.tabControl.Location = new System.Drawing.Point(12, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(651, 486);
            this.tabControl.TabIndex = 18;
            // 
            // tabTuGia
            // 
            this.tabTuGia.Controls.Add(this.txtTongGiaBan_TG);
            this.tabTuGia.Controls.Add(this.txtTongThueGTGT_TG);
            this.tabTuGia.Controls.Add(this.txtTongPhiBVMT_TG);
            this.tabTuGia.Controls.Add(this.txtTongCong_TG);
            this.tabTuGia.Controls.Add(this.txtTongHD_TG);
            this.tabTuGia.Controls.Add(this.dgvHDTuGia);
            this.tabTuGia.Location = new System.Drawing.Point(4, 22);
            this.tabTuGia.Name = "tabTuGia";
            this.tabTuGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabTuGia.Size = new System.Drawing.Size(643, 460);
            this.tabTuGia.TabIndex = 0;
            this.tabTuGia.Text = "Tư Gia";
            this.tabTuGia.UseVisualStyleBackColor = true;
            // 
            // txtTongGiaBan_TG
            // 
            this.txtTongGiaBan_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongGiaBan_TG.Location = new System.Drawing.Point(229, 406);
            this.txtTongGiaBan_TG.Name = "txtTongGiaBan_TG";
            this.txtTongGiaBan_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongGiaBan_TG.TabIndex = 6;
            this.txtTongGiaBan_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongThueGTGT_TG
            // 
            this.txtTongThueGTGT_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongThueGTGT_TG.Location = new System.Drawing.Point(329, 406);
            this.txtTongThueGTGT_TG.Name = "txtTongThueGTGT_TG";
            this.txtTongThueGTGT_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongThueGTGT_TG.TabIndex = 5;
            this.txtTongThueGTGT_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongPhiBVMT_TG
            // 
            this.txtTongPhiBVMT_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongPhiBVMT_TG.Location = new System.Drawing.Point(429, 406);
            this.txtTongPhiBVMT_TG.Name = "txtTongPhiBVMT_TG";
            this.txtTongPhiBVMT_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongPhiBVMT_TG.TabIndex = 4;
            this.txtTongPhiBVMT_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongCong_TG
            // 
            this.txtTongCong_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_TG.Location = new System.Drawing.Point(529, 406);
            this.txtTongCong_TG.Name = "txtTongCong_TG";
            this.txtTongCong_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_TG.TabIndex = 3;
            this.txtTongCong_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongHD_TG
            // 
            this.txtTongHD_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD_TG.Location = new System.Drawing.Point(149, 406);
            this.txtTongHD_TG.Name = "txtTongHD_TG";
            this.txtTongHD_TG.Size = new System.Drawing.Size(80, 20);
            this.txtTongHD_TG.TabIndex = 2;
            this.txtTongHD_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvHDTuGia
            // 
            this.dgvHDTuGia.AllowUserToAddRows = false;
            this.dgvHDTuGia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDTuGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHDTuGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDTuGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD_TG,
            this.MaNV_TG,
            this.HoTen_TG,
            this.TongHD_TG,
            this.TongGiaBan_TG,
            this.TongThueGTGT_TG,
            this.TongPhiBVMT_TG,
            this.TongCong_TG});
            this.dgvHDTuGia.Location = new System.Drawing.Point(6, 6);
            this.dgvHDTuGia.MultiSelect = false;
            this.dgvHDTuGia.Name = "dgvHDTuGia";
            this.dgvHDTuGia.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDTuGia.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHDTuGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHDTuGia.Size = new System.Drawing.Size(625, 400);
            this.dgvHDTuGia.TabIndex = 0;
            this.dgvHDTuGia.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDTuGia_CellFormatting);
            this.dgvHDTuGia.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDTuGia_RowPostPaint);
            // 
            // MaHD_TG
            // 
            this.MaHD_TG.DataPropertyName = "MaHD";
            this.MaHD_TG.HeaderText = "MaHD";
            this.MaHD_TG.Name = "MaHD_TG";
            this.MaHD_TG.ReadOnly = true;
            this.MaHD_TG.Visible = false;
            // 
            // MaNV_TG
            // 
            this.MaNV_TG.DataPropertyName = "MaNV";
            this.MaNV_TG.HeaderText = "MaNV";
            this.MaNV_TG.Name = "MaNV_TG";
            this.MaNV_TG.ReadOnly = true;
            this.MaNV_TG.Visible = false;
            // 
            // HoTen_TG
            // 
            this.HoTen_TG.DataPropertyName = "HoTen";
            this.HoTen_TG.HeaderText = "Nhân Viên";
            this.HoTen_TG.Name = "HoTen_TG";
            this.HoTen_TG.ReadOnly = true;
            // 
            // TongHD_TG
            // 
            this.TongHD_TG.DataPropertyName = "TongHD";
            this.TongHD_TG.HeaderText = "Tổng HĐ";
            this.TongHD_TG.Name = "TongHD_TG";
            this.TongHD_TG.ReadOnly = true;
            this.TongHD_TG.Width = 80;
            // 
            // TongGiaBan_TG
            // 
            this.TongGiaBan_TG.DataPropertyName = "TongGiaBan";
            this.TongGiaBan_TG.HeaderText = "Tổng Giá Bán";
            this.TongGiaBan_TG.Name = "TongGiaBan_TG";
            this.TongGiaBan_TG.ReadOnly = true;
            // 
            // TongThueGTGT_TG
            // 
            this.TongThueGTGT_TG.DataPropertyName = "TongThueGTGT";
            this.TongThueGTGT_TG.HeaderText = "Tổng Thuế GTGT";
            this.TongThueGTGT_TG.Name = "TongThueGTGT_TG";
            this.TongThueGTGT_TG.ReadOnly = true;
            // 
            // TongPhiBVMT_TG
            // 
            this.TongPhiBVMT_TG.DataPropertyName = "TongPhiBVMT";
            this.TongPhiBVMT_TG.HeaderText = "Tổng Phí BVMT";
            this.TongPhiBVMT_TG.Name = "TongPhiBVMT_TG";
            this.TongPhiBVMT_TG.ReadOnly = true;
            // 
            // TongCong_TG
            // 
            this.TongCong_TG.DataPropertyName = "TongCong";
            this.TongCong_TG.HeaderText = "Tổng Cộng";
            this.TongCong_TG.Name = "TongCong_TG";
            this.TongCong_TG.ReadOnly = true;
            // 
            // tabCoQuan
            // 
            this.tabCoQuan.Controls.Add(this.txtTongGiaBan_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongThueGTGT_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongPhiBVMT_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongCong_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongHD_CQ);
            this.tabCoQuan.Controls.Add(this.dgvHDCoQuan);
            this.tabCoQuan.Location = new System.Drawing.Point(4, 22);
            this.tabCoQuan.Name = "tabCoQuan";
            this.tabCoQuan.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoQuan.Size = new System.Drawing.Size(643, 460);
            this.tabCoQuan.TabIndex = 1;
            this.tabCoQuan.Text = "Cơ Quan";
            this.tabCoQuan.UseVisualStyleBackColor = true;
            // 
            // txtTongGiaBan_CQ
            // 
            this.txtTongGiaBan_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongGiaBan_CQ.Location = new System.Drawing.Point(229, 406);
            this.txtTongGiaBan_CQ.Name = "txtTongGiaBan_CQ";
            this.txtTongGiaBan_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongGiaBan_CQ.TabIndex = 8;
            this.txtTongGiaBan_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongThueGTGT_CQ
            // 
            this.txtTongThueGTGT_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongThueGTGT_CQ.Location = new System.Drawing.Point(329, 406);
            this.txtTongThueGTGT_CQ.Name = "txtTongThueGTGT_CQ";
            this.txtTongThueGTGT_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongThueGTGT_CQ.TabIndex = 7;
            this.txtTongThueGTGT_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongPhiBVMT_CQ
            // 
            this.txtTongPhiBVMT_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongPhiBVMT_CQ.Location = new System.Drawing.Point(429, 406);
            this.txtTongPhiBVMT_CQ.Name = "txtTongPhiBVMT_CQ";
            this.txtTongPhiBVMT_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongPhiBVMT_CQ.TabIndex = 6;
            this.txtTongPhiBVMT_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongCong_CQ
            // 
            this.txtTongCong_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_CQ.Location = new System.Drawing.Point(529, 406);
            this.txtTongCong_CQ.Name = "txtTongCong_CQ";
            this.txtTongCong_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_CQ.TabIndex = 5;
            this.txtTongCong_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongHD_CQ
            // 
            this.txtTongHD_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD_CQ.Location = new System.Drawing.Point(149, 406);
            this.txtTongHD_CQ.Name = "txtTongHD_CQ";
            this.txtTongHD_CQ.Size = new System.Drawing.Size(80, 20);
            this.txtTongHD_CQ.TabIndex = 4;
            this.txtTongHD_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvHDCoQuan
            // 
            this.dgvHDCoQuan.AllowUserToAddRows = false;
            this.dgvHDCoQuan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDCoQuan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHDCoQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDCoQuan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD_CQ,
            this.MaNV_CQ,
            this.HoTen_CQ,
            this.TongHD_CQ,
            this.TongGiaBan_CQ,
            this.TongThueGTGT_CQ,
            this.TongPhiBVMT_CQ,
            this.TongCong_CQ});
            this.dgvHDCoQuan.Location = new System.Drawing.Point(6, 6);
            this.dgvHDCoQuan.MultiSelect = false;
            this.dgvHDCoQuan.Name = "dgvHDCoQuan";
            this.dgvHDCoQuan.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDCoQuan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHDCoQuan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHDCoQuan.Size = new System.Drawing.Size(625, 400);
            this.dgvHDCoQuan.TabIndex = 1;
            this.dgvHDCoQuan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDCoQuan_CellFormatting);
            this.dgvHDCoQuan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDCoQuan_RowPostPaint);
            // 
            // MaHD_CQ
            // 
            this.MaHD_CQ.DataPropertyName = "MaHD";
            this.MaHD_CQ.HeaderText = "MaHD";
            this.MaHD_CQ.Name = "MaHD_CQ";
            this.MaHD_CQ.ReadOnly = true;
            this.MaHD_CQ.Visible = false;
            // 
            // MaNV_CQ
            // 
            this.MaNV_CQ.DataPropertyName = "MaNV";
            this.MaNV_CQ.HeaderText = "MaNV";
            this.MaNV_CQ.Name = "MaNV_CQ";
            this.MaNV_CQ.ReadOnly = true;
            this.MaNV_CQ.Visible = false;
            // 
            // HoTen_CQ
            // 
            this.HoTen_CQ.DataPropertyName = "HoTen";
            this.HoTen_CQ.HeaderText = "Nhân Viên";
            this.HoTen_CQ.Name = "HoTen_CQ";
            this.HoTen_CQ.ReadOnly = true;
            // 
            // TongHD_CQ
            // 
            this.TongHD_CQ.DataPropertyName = "TongHD";
            this.TongHD_CQ.HeaderText = "Tổng HĐ";
            this.TongHD_CQ.Name = "TongHD_CQ";
            this.TongHD_CQ.ReadOnly = true;
            this.TongHD_CQ.Width = 80;
            // 
            // TongGiaBan_CQ
            // 
            this.TongGiaBan_CQ.DataPropertyName = "TongGiaBan";
            this.TongGiaBan_CQ.HeaderText = "Tổng Giá Bán";
            this.TongGiaBan_CQ.Name = "TongGiaBan_CQ";
            this.TongGiaBan_CQ.ReadOnly = true;
            // 
            // TongThueGTGT_CQ
            // 
            this.TongThueGTGT_CQ.DataPropertyName = "TongThueGTGT";
            this.TongThueGTGT_CQ.HeaderText = "Tổng Thuế GTGT";
            this.TongThueGTGT_CQ.Name = "TongThueGTGT_CQ";
            this.TongThueGTGT_CQ.ReadOnly = true;
            // 
            // TongPhiBVMT_CQ
            // 
            this.TongPhiBVMT_CQ.DataPropertyName = "TongPhiBVMT";
            this.TongPhiBVMT_CQ.HeaderText = "Tổng Phí BVMT";
            this.TongPhiBVMT_CQ.Name = "TongPhiBVMT_CQ";
            this.TongPhiBVMT_CQ.ReadOnly = true;
            // 
            // TongCong_CQ
            // 
            this.TongCong_CQ.DataPropertyName = "TongCong";
            this.TongCong_CQ.HeaderText = "Tổng Cộng";
            this.TongCong_CQ.Name = "TongCong_CQ";
            this.TongCong_CQ.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Ngày Giải Trách:";
            // 
            // dateGiaiTrach
            // 
            this.dateGiaiTrach.CustomFormat = "dd/MM/yyyy";
            this.dateGiaiTrach.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateGiaiTrach.Location = new System.Drawing.Point(311, 12);
            this.dateGiaiTrach.Name = "dateGiaiTrach";
            this.dateGiaiTrach.Size = new System.Drawing.Size(95, 20);
            this.dateGiaiTrach.TabIndex = 20;
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(493, 10);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 21;
            this.btnIn.Text = "In DS";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnInDSCoThuHo
            // 
            this.btnInDSCoThuHo.Location = new System.Drawing.Point(574, 10);
            this.btnInDSCoThuHo.Name = "btnInDSCoThuHo";
            this.btnInDSCoThuHo.Size = new System.Drawing.Size(100, 23);
            this.btnInDSCoThuHo.TabIndex = 22;
            this.btnInDSCoThuHo.Text = "In DS Có Thu Hộ";
            this.btnInDSCoThuHo.UseVisualStyleBackColor = true;
            this.btnInDSCoThuHo.Click += new System.EventHandler(this.btnInDSCoThuHo_Click);
            // 
            // frmKiemTraDangNganTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 537);
            this.Controls.Add(this.btnInDSCoThuHo);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dateGiaiTrach);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.btnXem);
            this.Name = "frmKiemTraDangNganTo";
            this.Text = "Kiểm Tra Đăng Ngân Tổ";
            this.Load += new System.EventHandler(this.frmKiemTraDangNgan_Load);
            this.tabControl.ResumeLayout(false);
            this.tabTuGia.ResumeLayout(false);
            this.tabTuGia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).EndInit();
            this.tabCoQuan.ResumeLayout(false);
            this.tabCoQuan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTuGia;
        private System.Windows.Forms.DataGridView dgvHDTuGia;
        private System.Windows.Forms.TabPage tabCoQuan;
        private System.Windows.Forms.DataGridView dgvHDCoQuan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateGiaiTrach;
        private System.Windows.Forms.TextBox txtTongCong_TG;
        private System.Windows.Forms.TextBox txtTongHD_TG;
        private System.Windows.Forms.TextBox txtTongCong_CQ;
        private System.Windows.Forms.TextBox txtTongHD_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHD_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongGiaBan_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongThueGTGT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongPhiBVMT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHD_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongGiaBan_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongThueGTGT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongPhiBVMT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_CQ;
        private System.Windows.Forms.TextBox txtTongGiaBan_TG;
        private System.Windows.Forms.TextBox txtTongThueGTGT_TG;
        private System.Windows.Forms.TextBox txtTongPhiBVMT_TG;
        private System.Windows.Forms.TextBox txtTongGiaBan_CQ;
        private System.Windows.Forms.TextBox txtTongThueGTGT_CQ;
        private System.Windows.Forms.TextBox txtTongPhiBVMT_CQ;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnInDSCoThuHo;
    }
}