namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmPhiMoNuocChuyenKhoan
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
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTienDu = new System.Windows.Forms.DataGridView();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvPhiMoNuoc = new System.Windows.Forms.DataGridView();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.MaPMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanHD_PMN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NgayNhanHD_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TraHD_PMN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NgayTraHD_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBK_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienDu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhiMoNuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Danh Sách Danh Bộ Đóng Phí Mở Nước";
            // 
            // dgvTienDu
            // 
            this.dgvTienDu.AllowUserToAddRows = false;
            this.dgvTienDu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTienDu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTienDu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTienDu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo,
            this.Phi});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTienDu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTienDu.Location = new System.Drawing.Point(12, 41);
            this.dgvTienDu.Name = "dgvTienDu";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTienDu.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTienDu.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTienDu.Size = new System.Drawing.Size(237, 534);
            this.dgvTienDu.TabIndex = 6;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // Phi
            // 
            this.Phi.DataPropertyName = "Phi";
            this.Phi.HeaderText = "Phí";
            this.Phi.Name = "Phi";
            this.Phi.Width = 70;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(589, 13);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 7;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvPhiMoNuoc
            // 
            this.dgvPhiMoNuoc.AllowUserToAddRows = false;
            this.dgvPhiMoNuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhiMoNuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPhiMoNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhiMoNuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPMN,
            this.DanhBo_PMN,
            this.HoTen_PMN,
            this.DiaChi_PMN,
            this.GhiChu_PMN,
            this.NhanHD_PMN,
            this.NgayNhanHD_PMN,
            this.TraHD_PMN,
            this.NgayTraHD_PMN,
            this.NgayBK_PMN,
            this.SoTien_PMN,
            this.TongCong_PMN});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhiMoNuoc.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPhiMoNuoc.Location = new System.Drawing.Point(255, 41);
            this.dgvPhiMoNuoc.MultiSelect = false;
            this.dgvPhiMoNuoc.Name = "dgvPhiMoNuoc";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhiMoNuoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhiMoNuoc.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPhiMoNuoc.Size = new System.Drawing.Size(989, 534);
            this.dgvPhiMoNuoc.TabIndex = 8;
            this.dgvPhiMoNuoc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPhiMoNuoc_CellFormatting);
            this.dgvPhiMoNuoc.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPhiMoNuoc_CellValidating);
            this.dgvPhiMoNuoc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPhiMoNuoc_RowPostPaint);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(313, 15);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Từ Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(483, 15);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Đến Ngày:";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(670, 13);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 32;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // MaPMN
            // 
            this.MaPMN.DataPropertyName = "MaPMN";
            this.MaPMN.HeaderText = "Số Phiếu";
            this.MaPMN.Name = "MaPMN";
            this.MaPMN.Width = 80;
            // 
            // DanhBo_PMN
            // 
            this.DanhBo_PMN.DataPropertyName = "DanhBo";
            this.DanhBo_PMN.HeaderText = "Danh Bộ";
            this.DanhBo_PMN.Name = "DanhBo_PMN";
            // 
            // HoTen_PMN
            // 
            this.HoTen_PMN.DataPropertyName = "HoTen";
            this.HoTen_PMN.HeaderText = "Khách Hàng";
            this.HoTen_PMN.Name = "HoTen_PMN";
            this.HoTen_PMN.Width = 150;
            // 
            // DiaChi_PMN
            // 
            this.DiaChi_PMN.DataPropertyName = "DiaChi";
            this.DiaChi_PMN.HeaderText = "Địa Chỉ";
            this.DiaChi_PMN.Name = "DiaChi_PMN";
            this.DiaChi_PMN.Width = 150;
            // 
            // GhiChu_PMN
            // 
            this.GhiChu_PMN.DataPropertyName = "GhiChu";
            this.GhiChu_PMN.HeaderText = "Ghi Chú";
            this.GhiChu_PMN.Name = "GhiChu_PMN";
            this.GhiChu_PMN.Width = 150;
            // 
            // NhanHD_PMN
            // 
            this.NhanHD_PMN.DataPropertyName = "NhanHD";
            this.NhanHD_PMN.HeaderText = "Nhận";
            this.NhanHD_PMN.Name = "NhanHD_PMN";
            this.NhanHD_PMN.Width = 50;
            // 
            // NgayNhanHD_PMN
            // 
            this.NgayNhanHD_PMN.DataPropertyName = "NgayNhanHD";
            this.NgayNhanHD_PMN.HeaderText = "Ngày Nhận";
            this.NgayNhanHD_PMN.Name = "NgayNhanHD_PMN";
            this.NgayNhanHD_PMN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TraHD_PMN
            // 
            this.TraHD_PMN.DataPropertyName = "TraHD";
            this.TraHD_PMN.HeaderText = "Trả";
            this.TraHD_PMN.Name = "TraHD_PMN";
            this.TraHD_PMN.Width = 50;
            // 
            // NgayTraHD_PMN
            // 
            this.NgayTraHD_PMN.DataPropertyName = "NgayTraHD";
            this.NgayTraHD_PMN.HeaderText = "Ngày Trả";
            this.NgayTraHD_PMN.Name = "NgayTraHD_PMN";
            // 
            // NgayBK_PMN
            // 
            this.NgayBK_PMN.DataPropertyName = "NgayBK";
            this.NgayBK_PMN.HeaderText = "NgayBK";
            this.NgayBK_PMN.Name = "NgayBK_PMN";
            this.NgayBK_PMN.Visible = false;
            // 
            // SoTien_PMN
            // 
            this.SoTien_PMN.DataPropertyName = "SoTien";
            this.SoTien_PMN.HeaderText = "SoTien";
            this.SoTien_PMN.Name = "SoTien_PMN";
            this.SoTien_PMN.Visible = false;
            // 
            // TongCong_PMN
            // 
            this.TongCong_PMN.DataPropertyName = "TongCong";
            this.TongCong_PMN.HeaderText = "TongCong";
            this.TongCong_PMN.Name = "TongCong_PMN";
            this.TongCong_PMN.Visible = false;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(751, 13);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 33;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmPhiMoNuocChuyenKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 587);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvPhiMoNuoc);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvTienDu);
            this.Name = "frmPhiMoNuocChuyenKhoan";
            this.Text = "Phí Mở Nước Chuyển Khoản";
            this.Load += new System.EventHandler(this.frmPhiMoNuocChuyenKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienDu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhiMoNuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvTienDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phi;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvPhiMoNuoc;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu_PMN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NhanHD_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhanHD_PMN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TraHD_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTraHD_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBK_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_PMN;
        private System.Windows.Forms.Button btnXoa;
    }
}