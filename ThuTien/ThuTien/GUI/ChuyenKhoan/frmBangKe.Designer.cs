namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmBangKe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongDanhBo = new System.Windows.Forms.TextBox();
            this.txtTongSoTien = new System.Windows.Forms.TextBox();
            this.dateNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInDSTon = new System.Windows.Forms.Button();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaBK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBangKe = new System.Windows.Forms.DataGridView();
            this.txtTongHD = new System.Windows.Forms.TextBox();
            this.txtTongCong = new System.Windows.Forms.TextBox();
            this.dgvBangKeGroup = new System.Windows.Forms.DataGridView();
            this.TenNH_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLichSuTienDu = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateDate_LSTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien_LSTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loai_LSTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangKeGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuTienDu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(12, 106);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 70;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(448, 9);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 67;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(12, 179);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 69;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(172, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Từ Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(342, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Đến Ngày:";
            // 
            // txtTongDanhBo
            // 
            this.txtTongDanhBo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDanhBo.Location = new System.Drawing.Point(118, 605);
            this.txtTongDanhBo.Name = "txtTongDanhBo";
            this.txtTongDanhBo.Size = new System.Drawing.Size(40, 20);
            this.txtTongDanhBo.TabIndex = 76;
            this.txtTongDanhBo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongSoTien
            // 
            this.txtTongSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSoTien.Location = new System.Drawing.Point(359, 605);
            this.txtTongSoTien.Name = "txtTongSoTien";
            this.txtTongSoTien.Size = new System.Drawing.Size(100, 20);
            this.txtTongSoTien.TabIndex = 75;
            this.txtTongSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateNgayLap
            // 
            this.dateNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dateNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayLap.Location = new System.Drawing.Point(12, 57);
            this.dateNgayLap.Name = "dateNgayLap";
            this.dateNgayLap.Size = new System.Drawing.Size(100, 20);
            this.dateNgayLap.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "Ngày Lập:";
            // 
            // btnInDSTon
            // 
            this.btnInDSTon.Location = new System.Drawing.Point(529, 9);
            this.btnInDSTon.Name = "btnInDSTon";
            this.btnInDSTon.Size = new System.Drawing.Size(75, 23);
            this.btnInDSTon.TabIndex = 79;
            this.btnInDSTon.Text = "In DS Tồn";
            this.btnInDSTon.UseVisualStyleBackColor = true;
            this.btnInDSTon.Visible = false;
            this.btnInDSTon.Click += new System.EventHandler(this.btnInDSTon_Click);
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            // 
            // HoaDon
            // 
            this.HoaDon.DataPropertyName = "HoaDon";
            this.HoaDon.HeaderText = "HĐ";
            this.HoaDon.Name = "HoaDon";
            this.HoaDon.Width = 50;
            // 
            // TenNH
            // 
            this.TenNH.DataPropertyName = "TenNH";
            this.TenNH.HeaderText = "Ngân Hàng";
            this.TenNH.Name = "TenNH";
            // 
            // SoTien
            // 
            this.SoTien.DataPropertyName = "SoTien";
            this.SoTien.HeaderText = "Số Tiền";
            this.SoTien.Name = "SoTien";
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // MaBK
            // 
            this.MaBK.DataPropertyName = "MaBK";
            this.MaBK.HeaderText = "MaBK";
            this.MaBK.Name = "MaBK";
            this.MaBK.Visible = false;
            // 
            // dgvBangKe
            // 
            this.dgvBangKe.AllowUserToAddRows = false;
            this.dgvBangKe.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvBangKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaBK,
            this.CreateDate,
            this.DanhBo,
            this.SoTien,
            this.TenNH,
            this.HoaDon,
            this.TongCong});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBangKe.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvBangKe.Location = new System.Drawing.Point(118, 38);
            this.dgvBangKe.Name = "dgvBangKe";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKe.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBangKe.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvBangKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBangKe.Size = new System.Drawing.Size(619, 567);
            this.dgvBangKe.TabIndex = 62;
            this.dgvBangKe.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBangKe_CellFormatting);
            this.dgvBangKe.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBangKe_CellValidating);
            this.dgvBangKe.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBangKe_RowPostPaint);
            // 
            // txtTongHD
            // 
            this.txtTongHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD.Location = new System.Drawing.Point(559, 605);
            this.txtTongHD.Name = "txtTongHD";
            this.txtTongHD.Size = new System.Drawing.Size(50, 20);
            this.txtTongHD.TabIndex = 81;
            this.txtTongHD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongCong
            // 
            this.txtTongCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong.Location = new System.Drawing.Point(609, 605);
            this.txtTongCong.Name = "txtTongCong";
            this.txtTongCong.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong.TabIndex = 80;
            this.txtTongCong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvBangKeGroup
            // 
            this.dgvBangKeGroup.AllowUserToAddRows = false;
            this.dgvBangKeGroup.AllowUserToDeleteRows = false;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKeGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvBangKeGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangKeGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenNH_Group,
            this.SoLuong_Group,
            this.TongCong_Group});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBangKeGroup.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvBangKeGroup.Location = new System.Drawing.Point(743, 38);
            this.dgvBangKeGroup.Name = "dgvBangKeGroup";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKeGroup.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBangKeGroup.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvBangKeGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBangKeGroup.Size = new System.Drawing.Size(313, 225);
            this.dgvBangKeGroup.TabIndex = 82;
            this.dgvBangKeGroup.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBangKeGroup_CellFormatting);
            this.dgvBangKeGroup.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBangKeGroup_RowPostPaint);
            // 
            // TenNH_Group
            // 
            this.TenNH_Group.DataPropertyName = "TenNH";
            this.TenNH_Group.HeaderText = "Ngân Hàng";
            this.TenNH_Group.Name = "TenNH_Group";
            // 
            // SoLuong_Group
            // 
            this.SoLuong_Group.DataPropertyName = "SoLuong";
            this.SoLuong_Group.HeaderText = "SL";
            this.SoLuong_Group.Name = "SoLuong_Group";
            this.SoLuong_Group.Width = 50;
            // 
            // TongCong_Group
            // 
            this.TongCong_Group.DataPropertyName = "TongCong";
            this.TongCong_Group.HeaderText = "Tổng Cộng";
            this.TongCong_Group.Name = "TongCong_Group";
            // 
            // dgvLichSuTienDu
            // 
            this.dgvLichSuTienDu.AllowUserToAddRows = false;
            this.dgvLichSuTienDu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichSuTienDu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvLichSuTienDu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuTienDu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreateDate_LSTD,
            this.SoTien_LSTD,
            this.Loai_LSTD});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichSuTienDu.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgvLichSuTienDu.Location = new System.Drawing.Point(743, 295);
            this.dgvLichSuTienDu.Name = "dgvLichSuTienDu";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichSuTienDu.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvLichSuTienDu.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvLichSuTienDu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSuTienDu.Size = new System.Drawing.Size(313, 310);
            this.dgvLichSuTienDu.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(743, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 85;
            this.label5.Text = "Danh Bộ:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(801, 269);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 84;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(907, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "(enter)";
            // 
            // CreateDate_LSTD
            // 
            this.CreateDate_LSTD.DataPropertyName = "CreateDate";
            this.CreateDate_LSTD.HeaderText = "Ngày Lập";
            this.CreateDate_LSTD.Name = "CreateDate_LSTD";
            // 
            // SoTien_LSTD
            // 
            this.SoTien_LSTD.DataPropertyName = "SoTien";
            this.SoTien_LSTD.HeaderText = "Số Tiền";
            this.SoTien_LSTD.Name = "SoTien_LSTD";
            this.SoTien_LSTD.Width = 70;
            // 
            // Loai_LSTD
            // 
            this.Loai_LSTD.DataPropertyName = "Loai";
            this.Loai_LSTD.HeaderText = "Loại";
            this.Loai_LSTD.Name = "Loai_LSTD";
            this.Loai_LSTD.Width = 80;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(743, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 87;
            this.label6.Text = "Group Ngân Hàng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(963, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Lịch Sử Giao Dịch";
            // 
            // frmBangKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1473, 673);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.dgvLichSuTienDu);
            this.Controls.Add(this.dgvBangKeGroup);
            this.Controls.Add(this.txtTongHD);
            this.Controls.Add(this.txtTongCong);
            this.Controls.Add(this.btnInDSTon);
            this.Controls.Add(this.dateNgayLap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTongDanhBo);
            this.Controls.Add(this.txtTongSoTien);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.dgvBangKe);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnXoa);
            this.KeyPreview = true;
            this.Name = "frmBangKe";
            this.Text = "Bảng Kê";
            this.Load += new System.EventHandler(this.frmBangKe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBangKe_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangKeGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuTienDu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongDanhBo;
        private System.Windows.Forms.TextBox txtTongSoTien;
        private System.Windows.Forms.DateTimePicker dateNgayLap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInDSTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBK;
        private System.Windows.Forms.DataGridView dgvBangKe;
        private System.Windows.Forms.TextBox txtTongHD;
        private System.Windows.Forms.TextBox txtTongCong;
        private System.Windows.Forms.DataGridView dgvBangKeGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNH_Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong_Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_Group;
        private System.Windows.Forms.DataGridView dgvLichSuTienDu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate_LSTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien_LSTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai_LSTD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}