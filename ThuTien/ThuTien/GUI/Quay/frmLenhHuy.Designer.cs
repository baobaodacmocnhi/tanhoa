namespace ThuTien.GUI.Quay
{
    partial class frmLenhHuy
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
            this.btnIn = new System.Windows.Forms.Button();
            this.dgvHD = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lstHD = new System.Windows.Forms.ListBox();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(161, 201);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(81, 23);
            this.btnIn.TabIndex = 19;
            this.btnIn.Text = "In Danh Sách";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Visible = false;
            // 
            // dgvHD
            // 
            this.dgvHD.AllowUserToAddRows = false;
            this.dgvHD.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoHoaDon,
            this.Ky,
            this.MLT,
            this.SoPhatHanh,
            this.DanhBo,
            this.TongCong});
            this.dgvHD.Location = new System.Drawing.Point(271, 38);
            this.dgvHD.Name = "dgvHD";
            this.dgvHD.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHD.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHD.Size = new System.Drawing.Size(671, 603);
            this.dgvHD.TabIndex = 20;
            this.dgvHD.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHD_CellFormatting);
            this.dgvHD.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHD_RowPostPaint);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(161, 109);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(161, 80);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(161, 51);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Số Hóa Đơn:";
            // 
            // lstHD
            // 
            this.lstHD.FormattingEnabled = true;
            this.lstHD.Location = new System.Drawing.Point(15, 51);
            this.lstHD.Name = "lstHD";
            this.lstHD.Size = new System.Drawing.Size(120, 173);
            this.lstHD.TabIndex = 15;
            this.lstHD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHD_MouseDoubleClick);
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(87, 12);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 20);
            this.txtSoHoaDon.TabIndex = 13;
            this.txtSoHoaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHoaDon_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Danh Sách Hóa Đơn:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(607, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 25;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(501, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(437, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Đến Ngày:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(331, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Từ Ngày:";
            // 
            // SoHoaDon
            // 
            this.SoHoaDon.DataPropertyName = "SoHoaDon";
            this.SoHoaDon.HeaderText = "Số HĐ";
            this.SoHoaDon.Name = "SoHoaDon";
            this.SoHoaDon.ReadOnly = true;
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.ReadOnly = true;
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.ReadOnly = true;
            // 
            // SoPhatHanh
            // 
            this.SoPhatHanh.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh.HeaderText = "Số Phát Hành";
            this.SoPhatHanh.Name = "SoPhatHanh";
            this.SoPhatHanh.ReadOnly = true;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            this.TongCong.ReadOnly = true;
            // 
            // frmLenhHuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 652);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dgvHD);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstHD);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.label4);
            this.Name = "frmLenhHuy";
            this.Text = "Lệnh Hủy";
            this.Load += new System.EventHandler(this.frmLenhHuy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.DataGridView dgvHD;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstHD;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
    }
}