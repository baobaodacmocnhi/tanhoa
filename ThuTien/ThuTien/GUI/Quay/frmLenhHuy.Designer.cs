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
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lstHD = new System.Windows.Forms.ListBox();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateLap = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(563, 10);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(81, 23);
            this.btnIn.TabIndex = 19;
            this.btnIn.Text = "In Danh Sách";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ky,
            this.MLT,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.SoHoaDon,
            this.SoPhatHanh,
            this.TongCong,
            this.GiaBieu,
            this.HanhThu,
            this.To});
            this.dgvHoaDon.Location = new System.Drawing.Point(252, 39);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.Size = new System.Drawing.Size(903, 590);
            this.dgvHoaDon.TabIndex = 20;
            this.dgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHD_CellFormatting);
            this.dgvHoaDon.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHD_RowPostPaint);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(161, 134);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(161, 105);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(161, 76);
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
            this.lstHD.Location = new System.Drawing.Point(15, 76);
            this.lstHD.Name = "lstHD";
            this.lstHD.Size = new System.Drawing.Size(120, 173);
            this.lstHD.TabIndex = 15;
            this.lstHD.SelectedIndexChanged += new System.EventHandler(this.lstHD_SelectedIndexChanged);
            this.lstHD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHD_MouseDoubleClick);
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(87, 12);
            this.txtSoHoaDon.Multiline = true;
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 45);
            this.txtSoHoaDon.TabIndex = 13;
            this.txtSoHoaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHoaDon_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Danh Sách Hóa Đơn:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(482, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 25;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateLap
            // 
            this.dateLap.CustomFormat = "dd/MM/yyyy";
            this.dateLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateLap.Location = new System.Drawing.Point(376, 12);
            this.dateLap.Name = "dateLap";
            this.dateLap.Size = new System.Drawing.Size(100, 20);
            this.dateLap.TabIndex = 24;
            this.dateLap.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Ngày Lập:";
            this.label1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "(Enter)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Số Lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(85, 255);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(50, 20);
            this.txtSoLuong.TabIndex = 37;
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.ReadOnly = true;
            this.Ky.Width = 50;
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.ReadOnly = true;
            this.MLT.Width = 80;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 200;
            // 
            // SoHoaDon
            // 
            this.SoHoaDon.DataPropertyName = "SoHoaDon";
            this.SoHoaDon.HeaderText = "Số HĐ";
            this.SoHoaDon.Name = "SoHoaDon";
            this.SoHoaDon.ReadOnly = true;
            // 
            // SoPhatHanh
            // 
            this.SoPhatHanh.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh.HeaderText = "Số Phát Hành";
            this.SoPhatHanh.Name = "SoPhatHanh";
            this.SoPhatHanh.ReadOnly = true;
            this.SoPhatHanh.Width = 80;
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            this.TongCong.ReadOnly = true;
            this.TongCong.Width = 80;
            // 
            // GiaBieu
            // 
            this.GiaBieu.DataPropertyName = "GiaBieu";
            this.GiaBieu.HeaderText = "GiaBieu";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.ReadOnly = true;
            this.GiaBieu.Visible = false;
            // 
            // HanhThu
            // 
            this.HanhThu.DataPropertyName = "HanhThu";
            this.HanhThu.HeaderText = "HanhThu";
            this.HanhThu.Name = "HanhThu";
            this.HanhThu.ReadOnly = true;
            this.HanhThu.Visible = false;
            // 
            // To
            // 
            this.To.DataPropertyName = "To";
            this.To.HeaderText = "To";
            this.To.Name = "To";
            this.To.ReadOnly = true;
            this.To.Visible = false;
            // 
            // frmLenhHuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 638);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateLap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dgvHoaDon);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstHD;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateLap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
    }
}