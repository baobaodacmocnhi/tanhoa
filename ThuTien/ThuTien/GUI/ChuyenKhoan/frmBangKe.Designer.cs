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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvBangKe = new System.Windows.Forms.DataGridView();
            this.txtTongHD = new System.Windows.Forms.TextBox();
            this.txtTongCong = new System.Windows.Forms.TextBox();
            this.dgvBangKeGroup = new System.Windows.Forms.DataGridView();
            this.TenNH_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.MaBK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChenhLech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangKeGroup)).BeginInit();
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
            this.btnXem.Location = new System.Drawing.Point(428, 9);
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
            this.dateTu.Location = new System.Drawing.Point(152, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Từ Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(322, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Đến Ngày:";
            // 
            // txtTongDanhBo
            // 
            this.txtTongDanhBo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDanhBo.Location = new System.Drawing.Point(98, 605);
            this.txtTongDanhBo.Name = "txtTongDanhBo";
            this.txtTongDanhBo.Size = new System.Drawing.Size(40, 20);
            this.txtTongDanhBo.TabIndex = 76;
            this.txtTongDanhBo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongSoTien
            // 
            this.txtTongSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSoTien.Location = new System.Drawing.Point(485, 605);
            this.txtTongSoTien.Name = "txtTongSoTien";
            this.txtTongSoTien.Size = new System.Drawing.Size(100, 20);
            this.txtTongSoTien.TabIndex = 75;
            this.txtTongSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateNgayLap
            // 
            this.dateNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dateNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayLap.Location = new System.Drawing.Point(658, 12);
            this.dateNgayLap.Name = "dateNgayLap";
            this.dateNgayLap.Size = new System.Drawing.Size(100, 20);
            this.dateNgayLap.TabIndex = 78;
            this.dateNgayLap.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(596, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "Ngày Lập:";
            this.label1.Visible = false;
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
            this.Phi,
            this.TenNH,
            this.HoaDon,
            this.TongCong,
            this.ChenhLech,
            this.GiaBieu});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBangKe.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBangKe.Location = new System.Drawing.Point(98, 38);
            this.dgvBangKe.Name = "dgvBangKe";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKe.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBangKe.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBangKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBangKe.Size = new System.Drawing.Size(904, 567);
            this.dgvBangKe.TabIndex = 62;
            this.dgvBangKe.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBangKe_CellFormatting);
            this.dgvBangKe.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBangKe_CellValidating);
            this.dgvBangKe.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBangKe_RowPostPaint);
            // 
            // txtTongHD
            // 
            this.txtTongHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD.Location = new System.Drawing.Point(735, 605);
            this.txtTongHD.Name = "txtTongHD";
            this.txtTongHD.Size = new System.Drawing.Size(50, 20);
            this.txtTongHD.TabIndex = 81;
            this.txtTongHD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongCong
            // 
            this.txtTongCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong.Location = new System.Drawing.Point(785, 605);
            this.txtTongCong.Name = "txtTongCong";
            this.txtTongCong.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong.TabIndex = 80;
            this.txtTongCong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvBangKeGroup
            // 
            this.dgvBangKeGroup.AllowUserToAddRows = false;
            this.dgvBangKeGroup.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKeGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBangKeGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangKeGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenNH_Group,
            this.SoLuong_Group,
            this.TongCong_Group});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBangKeGroup.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBangKeGroup.Location = new System.Drawing.Point(1008, 38);
            this.dgvBangKeGroup.Name = "dgvBangKeGroup";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangKeGroup.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBangKeGroup.RowsDefaultCellStyle = dataGridViewCellStyle9;
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
            this.label6.Location = new System.Drawing.Point(1008, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 87;
            this.label6.Text = "Group Ngân Hàng";
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
            // Phi
            // 
            this.Phi.DataPropertyName = "Phi";
            this.Phi.HeaderText = "Phí";
            this.Phi.Name = "Phi";
            this.Phi.Width = 70;
            // 
            // TenNH
            // 
            this.TenNH.DataPropertyName = "TenNH";
            this.TenNH.HeaderText = "Ngân Hàng";
            this.TenNH.Name = "TenNH";
            // 
            // HoaDon
            // 
            this.HoaDon.DataPropertyName = "HoaDon";
            this.HoaDon.HeaderText = "HĐ";
            this.HoaDon.Name = "HoaDon";
            this.HoaDon.Width = 50;
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            this.TongCong.Width = 80;
            // 
            // ChenhLech
            // 
            this.ChenhLech.DataPropertyName = "ChenhLech";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            this.ChenhLech.DefaultCellStyle = dataGridViewCellStyle2;
            this.ChenhLech.HeaderText = "Chênh Lệch";
            this.ChenhLech.Name = "ChenhLech";
            this.ChenhLech.Width = 80;
            // 
            // GiaBieu
            // 
            this.GiaBieu.DataPropertyName = "GiaBieu";
            this.GiaBieu.HeaderText = "GB";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.Width = 30;
            // 
            // frmBangKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 645);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvBangKeGroup);
            this.Controls.Add(this.txtTongHD);
            this.Controls.Add(this.txtTongCong);
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
        private System.Windows.Forms.DataGridView dgvBangKe;
        private System.Windows.Forms.TextBox txtTongHD;
        private System.Windows.Forms.TextBox txtTongCong;
        private System.Windows.Forms.DataGridView dgvBangKeGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNH_Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong_Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_Group;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBK;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChenhLech;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
    }
}