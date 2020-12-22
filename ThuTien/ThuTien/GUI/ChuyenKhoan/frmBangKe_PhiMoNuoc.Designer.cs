namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmBangKe_PhiMoNuoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvBangKe = new System.Windows.Forms.DataGridView();
            this.MaBK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBangKeGroup = new System.Windows.Forms.DataGridView();
            this.TenNH_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvBangKeGroup3 = new System.Windows.Forms.DataGridView();
            this.TenNH_Group3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong_Group3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_Group3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.chkNgayLap = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangKeGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangKeGroup3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(0, 106);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 70;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(416, 9);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 67;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(0, 179);
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
            this.dateTu.Location = new System.Drawing.Point(140, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Từ Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(310, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Đến Ngày:";
            // 
            // txtTongDanhBo
            // 
            this.txtTongDanhBo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDanhBo.Location = new System.Drawing.Point(86, 605);
            this.txtTongDanhBo.Name = "txtTongDanhBo";
            this.txtTongDanhBo.Size = new System.Drawing.Size(40, 20);
            this.txtTongDanhBo.TabIndex = 76;
            this.txtTongDanhBo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongSoTien
            // 
            this.txtTongSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSoTien.Location = new System.Drawing.Point(453, 605);
            this.txtTongSoTien.Name = "txtTongSoTien";
            this.txtTongSoTien.Size = new System.Drawing.Size(100, 20);
            this.txtTongSoTien.TabIndex = 75;
            this.txtTongSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateNgayLap
            // 
            this.dateNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dateNgayLap.Enabled = false;
            this.dateNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayLap.Location = new System.Drawing.Point(766, 12);
            this.dateNgayLap.Name = "dateNgayLap";
            this.dateNgayLap.Size = new System.Drawing.Size(100, 20);
            this.dateNgayLap.TabIndex = 78;
            // 
            // dgvBangKe
            // 
            this.dgvBangKe.AllowUserToAddRows = false;
            this.dgvBangKe.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBangKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaBK,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.SoTien,
            this.TenNH});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBangKe.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBangKe.Location = new System.Drawing.Point(86, 38);
            this.dgvBangKe.Name = "dgvBangKe";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKe.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBangKe.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBangKe.Size = new System.Drawing.Size(954, 567);
            this.dgvBangKe.TabIndex = 62;
            this.dgvBangKe.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBangKe_CellFormatting);
            this.dgvBangKe.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBangKe_CellValidating);
            this.dgvBangKe.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBangKe_ColumnHeaderMouseClick);
            this.dgvBangKe.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBangKe_RowPostPaint);
            // 
            // MaBK
            // 
            this.MaBK.DataPropertyName = "MaBK";
            this.MaBK.HeaderText = "MaBK";
            this.MaBK.Name = "MaBK";
            this.MaBK.Visible = false;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.Width = 90;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 150;
            // 
            // SoTien
            // 
            this.SoTien.DataPropertyName = "SoTien";
            this.SoTien.HeaderText = "Số Tiền";
            this.SoTien.Name = "SoTien";
            this.SoTien.Width = 80;
            // 
            // TenNH
            // 
            this.TenNH.DataPropertyName = "TenNH";
            this.TenNH.HeaderText = "Ngân Hàng";
            this.TenNH.Name = "TenNH";
            this.TenNH.Width = 70;
            // 
            // dgvBangKeGroup
            // 
            this.dgvBangKeGroup.AllowUserToAddRows = false;
            this.dgvBangKeGroup.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKeGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBangKeGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangKeGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenNH_Group,
            this.SoLuong_Group,
            this.TongCong_Group});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBangKeGroup.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBangKeGroup.Location = new System.Drawing.Point(1046, 38);
            this.dgvBangKeGroup.Name = "dgvBangKeGroup";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKeGroup.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBangKeGroup.RowsDefaultCellStyle = dataGridViewCellStyle8;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1046, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 87;
            this.label6.Text = "Group Ngân Hàng";
            // 
            // dgvBangKeGroup3
            // 
            this.dgvBangKeGroup3.AllowUserToAddRows = false;
            this.dgvBangKeGroup3.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKeGroup3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBangKeGroup3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangKeGroup3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenNH_Group3,
            this.SoLuong_Group3,
            this.TongCong_Group3});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBangKeGroup3.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvBangKeGroup3.Location = new System.Drawing.Point(1046, 269);
            this.dgvBangKeGroup3.Name = "dgvBangKeGroup3";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKeGroup3.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBangKeGroup3.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvBangKeGroup3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBangKeGroup3.Size = new System.Drawing.Size(313, 130);
            this.dgvBangKeGroup3.TabIndex = 88;
            this.dgvBangKeGroup3.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBangKeGroup3_CellFormatting);
            // 
            // TenNH_Group3
            // 
            this.TenNH_Group3.DataPropertyName = "TenNH";
            this.TenNH_Group3.HeaderText = "Ngân Hàng";
            this.TenNH_Group3.Name = "TenNH_Group3";
            // 
            // SoLuong_Group3
            // 
            this.SoLuong_Group3.DataPropertyName = "SoLuong";
            this.SoLuong_Group3.HeaderText = "SL";
            this.SoLuong_Group3.Name = "SoLuong_Group3";
            this.SoLuong_Group3.Width = 50;
            // 
            // TongCong_Group3
            // 
            this.TongCong_Group3.DataPropertyName = "TongCong";
            this.TongCong_Group3.HeaderText = "Tổng Cộng";
            this.TongCong_Group3.Name = "TongCong_Group3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(546, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 89;
            this.label2.Text = "Danh Bộ Sai: màu đỏ";
            // 
            // chkNgayLap
            // 
            this.chkNgayLap.AutoSize = true;
            this.chkNgayLap.Location = new System.Drawing.Point(688, 15);
            this.chkNgayLap.Name = "chkNgayLap";
            this.chkNgayLap.Size = new System.Drawing.Size(72, 17);
            this.chkNgayLap.TabIndex = 91;
            this.chkNgayLap.Text = "Ngày Lập";
            this.chkNgayLap.UseVisualStyleBackColor = true;
            this.chkNgayLap.CheckedChanged += new System.EventHandler(this.chkNgayLap_CheckedChanged);
            // 
            // frmBangKe_PhiMoNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 631);
            this.Controls.Add(this.chkNgayLap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvBangKeGroup3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvBangKeGroup);
            this.Controls.Add(this.dateNgayLap);
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
            this.Name = "frmBangKe_PhiMoNuoc";
            this.Text = "Bảng Kê Phí Mở Nước";
            this.Load += new System.EventHandler(this.frmBangKe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBangKe_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangKeGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangKeGroup3)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvBangKe;
        private System.Windows.Forms.DataGridView dgvBangKeGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNH_Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong_Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_Group;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvBangKeGroup3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNH_Group3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong_Group3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_Group3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkNgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBK;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNH;
    }
}