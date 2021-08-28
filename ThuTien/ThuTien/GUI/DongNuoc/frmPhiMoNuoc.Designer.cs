namespace ThuTien.GUI.DongNuoc
{
    partial class frmPhiMoNuoc
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
            this.dgvKQDongNuoc = new System.Windows.Forms.DataGridView();
            this.In = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKQDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DongPhi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NgayDongPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV_DongPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoThan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiSoDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiMoNuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_To = new System.Windows.Forms.Panel();
            this.panel_NhanVien = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQDongNuoc)).BeginInit();
            this.panel_To.SuspendLayout();
            this.panel_NhanVien.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKQDongNuoc
            // 
            this.dgvKQDongNuoc.AllowUserToAddRows = false;
            this.dgvKQDongNuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKQDongNuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKQDongNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKQDongNuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In,
            this.MaDN,
            this.MaKQDN,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NgayDN,
            this.DongPhi,
            this.NgayDongPhi,
            this.MaNV_DongPhi,
            this.Hieu,
            this.Co,
            this.SoThan,
            this.ChiSoDN,
            this.LyDo,
            this.PhiMoNuoc});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKQDongNuoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKQDongNuoc.Location = new System.Drawing.Point(12, 64);
            this.dgvKQDongNuoc.Name = "dgvKQDongNuoc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKQDongNuoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvKQDongNuoc.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKQDongNuoc.Size = new System.Drawing.Size(1027, 557);
            this.dgvKQDongNuoc.TabIndex = 33;
            this.dgvKQDongNuoc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKQDongNuoc_CellFormatting);
            this.dgvKQDongNuoc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvKQDongNuoc_RowPostPaint);
            // 
            // In
            // 
            this.In.DataPropertyName = "In";
            this.In.HeaderText = "In";
            this.In.Name = "In";
            this.In.Width = 30;
            // 
            // MaDN
            // 
            this.MaDN.DataPropertyName = "MaDN";
            this.MaDN.HeaderText = "Mã TB";
            this.MaDN.Name = "MaDN";
            this.MaDN.Width = 70;
            // 
            // MaKQDN
            // 
            this.MaKQDN.DataPropertyName = "MaKQDN";
            this.MaKQDN.HeaderText = "MaKQDN";
            this.MaKQDN.Name = "MaKQDN";
            this.MaKQDN.Visible = false;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Width = 80;
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
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // NgayDN
            // 
            this.NgayDN.DataPropertyName = "NgayDN";
            this.NgayDN.HeaderText = "Đóng Nước";
            this.NgayDN.Name = "NgayDN";
            this.NgayDN.Width = 80;
            // 
            // DongPhi
            // 
            this.DongPhi.DataPropertyName = "DongPhi";
            this.DongPhi.HeaderText = "Đóng Phí";
            this.DongPhi.Name = "DongPhi";
            this.DongPhi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DongPhi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DongPhi.Width = 50;
            // 
            // NgayDongPhi
            // 
            this.NgayDongPhi.DataPropertyName = "NgayDongPhi";
            this.NgayDongPhi.HeaderText = "Ngày Đóng Phí";
            this.NgayDongPhi.Name = "NgayDongPhi";
            this.NgayDongPhi.Width = 80;
            // 
            // MaNV_DongPhi
            // 
            this.MaNV_DongPhi.DataPropertyName = "MaNV_DongPhi";
            this.MaNV_DongPhi.HeaderText = "Nhân Viên";
            this.MaNV_DongPhi.Name = "MaNV_DongPhi";
            // 
            // Hieu
            // 
            this.Hieu.DataPropertyName = "Hieu";
            this.Hieu.HeaderText = "Hieu";
            this.Hieu.Name = "Hieu";
            this.Hieu.Visible = false;
            // 
            // Co
            // 
            this.Co.DataPropertyName = "Co";
            this.Co.HeaderText = "Co";
            this.Co.Name = "Co";
            this.Co.Visible = false;
            // 
            // SoThan
            // 
            this.SoThan.DataPropertyName = "SoThan";
            this.SoThan.HeaderText = "SoThan";
            this.SoThan.Name = "SoThan";
            this.SoThan.Visible = false;
            // 
            // ChiSoDN
            // 
            this.ChiSoDN.DataPropertyName = "ChiSoDN";
            this.ChiSoDN.HeaderText = "ChiSoDN";
            this.ChiSoDN.Name = "ChiSoDN";
            this.ChiSoDN.Visible = false;
            // 
            // LyDo
            // 
            this.LyDo.DataPropertyName = "LyDo";
            this.LyDo.HeaderText = "LyDo";
            this.LyDo.Name = "LyDo";
            this.LyDo.Visible = false;
            // 
            // PhiMoNuoc
            // 
            this.PhiMoNuoc.DataPropertyName = "PhiMoNuoc";
            this.PhiMoNuoc.HeaderText = "PhiMoNuoc";
            this.PhiMoNuoc.Name = "PhiMoNuoc";
            this.PhiMoNuoc.Visible = false;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(357, 10);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Từ Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(527, 10);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Đến Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(633, 7);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 34;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(714, 7);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 43;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(52, 41);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(86, 17);
            this.chkAll.TabIndex = 44;
            this.chkAll.Text = "Chọn Tất Cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(32, 3);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(50, 21);
            this.cmbTo.TabIndex = 57;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Tổ:";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(69, 3);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(118, 21);
            this.cmbNhanVien.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Nhân Viên:";
            // 
            // panel_To
            // 
            this.panel_To.Controls.Add(this.cmbTo);
            this.panel_To.Controls.Add(this.label1);
            this.panel_To.Location = new System.Drawing.Point(12, 6);
            this.panel_To.Name = "panel_To";
            this.panel_To.Size = new System.Drawing.Size(86, 27);
            this.panel_To.TabIndex = 58;
            this.panel_To.Visible = false;
            // 
            // panel_NhanVien
            // 
            this.panel_NhanVien.Controls.Add(this.cmbNhanVien);
            this.panel_NhanVien.Controls.Add(this.label4);
            this.panel_NhanVien.Location = new System.Drawing.Point(104, 6);
            this.panel_NhanVien.Name = "panel_NhanVien";
            this.panel_NhanVien.Size = new System.Drawing.Size(190, 27);
            this.panel_NhanVien.TabIndex = 59;
            this.panel_NhanVien.Visible = false;
            // 
            // frmPhiMoNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1053, 631);
            this.Controls.Add(this.panel_NhanVien);
            this.Controls.Add(this.panel_To);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dgvKQDongNuoc);
            this.Name = "frmPhiMoNuoc";
            this.Text = "Phí Mở Nước";
            this.Load += new System.EventHandler(this.frmPhiMoNuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQDongNuoc)).EndInit();
            this.panel_To.ResumeLayout(false);
            this.panel_To.PerformLayout();
            this.panel_NhanVien.ResumeLayout(false);
            this.panel_NhanVien.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKQDongNuoc;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_To;
        private System.Windows.Forms.Panel panel_NhanVien;
        private System.Windows.Forms.DataGridViewCheckBoxColumn In;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKQDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DongPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDongPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV_DongPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Co;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoThan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiSoDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiMoNuoc;
    }
}