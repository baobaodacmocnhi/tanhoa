namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmChanTienDu
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaHD_HD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_HD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_HD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_HD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_HD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_HD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_HD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_HD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu_HD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvDSChanTienDu = new System.Windows.Forms.DataGridView();
            this.ChanTienDu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NgayChanTienDu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_Chan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_Chan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_Chan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_Chan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_Chan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_Chan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_Chan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu_Chan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienDu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSChanTienDu)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "(Enter)";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(160, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ:";
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
            this.Chon,
            this.MaHD_HD,
            this.SoHoaDon_HD,
            this.Ky_HD,
            this.DanhBo_HD,
            this.HoTen_HD,
            this.DiaChi_HD,
            this.TongCong_HD,
            this.To_HD,
            this.HanhThu_HD});
            this.dgvHoaDon.Location = new System.Drawing.Point(12, 38);
            this.dgvHoaDon.Name = "dgvHoaDon";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.Size = new System.Drawing.Size(950, 200);
            this.dgvHoaDon.TabIndex = 4;
            this.dgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHoaDon_CellFormatting);
            this.dgvHoaDon.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHoaDon_RowPostPaint);
            // 
            // Chon
            // 
            this.Chon.FalseValue = "false";
            this.Chon.HeaderText = "Chọn";
            this.Chon.Name = "Chon";
            this.Chon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Chon.TrueValue = "true";
            this.Chon.Width = 50;
            // 
            // MaHD_HD
            // 
            this.MaHD_HD.DataPropertyName = "MaHD";
            this.MaHD_HD.HeaderText = "MaHD";
            this.MaHD_HD.Name = "MaHD_HD";
            this.MaHD_HD.Visible = false;
            // 
            // SoHoaDon_HD
            // 
            this.SoHoaDon_HD.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_HD.HeaderText = "Số HĐ";
            this.SoHoaDon_HD.Name = "SoHoaDon_HD";
            // 
            // Ky_HD
            // 
            this.Ky_HD.DataPropertyName = "Ky";
            this.Ky_HD.HeaderText = "Kỳ";
            this.Ky_HD.Name = "Ky_HD";
            this.Ky_HD.Width = 50;
            // 
            // DanhBo_HD
            // 
            this.DanhBo_HD.DataPropertyName = "DanhBo";
            this.DanhBo_HD.HeaderText = "Danh Bộ";
            this.DanhBo_HD.Name = "DanhBo_HD";
            // 
            // HoTen_HD
            // 
            this.HoTen_HD.DataPropertyName = "HoTen";
            this.HoTen_HD.HeaderText = "Họ Tên";
            this.HoTen_HD.Name = "HoTen_HD";
            this.HoTen_HD.Width = 150;
            // 
            // DiaChi_HD
            // 
            this.DiaChi_HD.DataPropertyName = "DiaChi";
            this.DiaChi_HD.HeaderText = "Địa Chỉ";
            this.DiaChi_HD.Name = "DiaChi_HD";
            this.DiaChi_HD.Width = 200;
            // 
            // TongCong_HD
            // 
            this.TongCong_HD.DataPropertyName = "TongCong";
            this.TongCong_HD.HeaderText = "Tổng Cộng";
            this.TongCong_HD.Name = "TongCong_HD";
            // 
            // To_HD
            // 
            this.To_HD.DataPropertyName = "To";
            this.To_HD.HeaderText = "Tổ";
            this.To_HD.Name = "To_HD";
            this.To_HD.Width = 40;
            // 
            // HanhThu_HD
            // 
            this.HanhThu_HD.DataPropertyName = "HanhThu";
            this.HanhThu_HD.HeaderText = "Hành Thu";
            this.HanhThu_HD.Name = "HanhThu_HD";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(310, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvDSChanTienDu
            // 
            this.dgvDSChanTienDu.AllowUserToAddRows = false;
            this.dgvDSChanTienDu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSChanTienDu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSChanTienDu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSChanTienDu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChanTienDu,
            this.NgayChanTienDu,
            this.SoHoaDon_Chan,
            this.Ky_Chan,
            this.DanhBo_Chan,
            this.HoTen_Chan,
            this.DiaChi_Chan,
            this.TongCong_Chan,
            this.To_Chan,
            this.HanhThu_Chan,
            this.TienDu});
            this.dgvDSChanTienDu.Location = new System.Drawing.Point(12, 273);
            this.dgvDSChanTienDu.Name = "dgvDSChanTienDu";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDSChanTienDu.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDSChanTienDu.Size = new System.Drawing.Size(1160, 369);
            this.dgvDSChanTienDu.TabIndex = 5;
            this.dgvDSChanTienDu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSChanTienDu_CellFormatting);
            this.dgvDSChanTienDu.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDSChanTienDu_CellValidating);
            this.dgvDSChanTienDu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSChanTienDu_RowPostPaint);
            // 
            // ChanTienDu
            // 
            this.ChanTienDu.DataPropertyName = "ChanTienDu";
            this.ChanTienDu.HeaderText = "Chặn";
            this.ChanTienDu.Name = "ChanTienDu";
            this.ChanTienDu.Width = 50;
            // 
            // NgayChanTienDu
            // 
            this.NgayChanTienDu.DataPropertyName = "NgayChanTienDu";
            this.NgayChanTienDu.HeaderText = "Ngày Chặn";
            this.NgayChanTienDu.Name = "NgayChanTienDu";
            // 
            // SoHoaDon_Chan
            // 
            this.SoHoaDon_Chan.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_Chan.HeaderText = "Số HĐ";
            this.SoHoaDon_Chan.Name = "SoHoaDon_Chan";
            // 
            // Ky_Chan
            // 
            this.Ky_Chan.DataPropertyName = "Ky";
            this.Ky_Chan.HeaderText = "Kỳ";
            this.Ky_Chan.Name = "Ky_Chan";
            this.Ky_Chan.Width = 50;
            // 
            // DanhBo_Chan
            // 
            this.DanhBo_Chan.DataPropertyName = "DanhBo";
            this.DanhBo_Chan.HeaderText = "Danh Bộ";
            this.DanhBo_Chan.Name = "DanhBo_Chan";
            // 
            // HoTen_Chan
            // 
            this.HoTen_Chan.DataPropertyName = "HoTen";
            this.HoTen_Chan.HeaderText = "Họ Tên";
            this.HoTen_Chan.Name = "HoTen_Chan";
            this.HoTen_Chan.Width = 150;
            // 
            // DiaChi_Chan
            // 
            this.DiaChi_Chan.DataPropertyName = "DiaChi";
            this.DiaChi_Chan.HeaderText = "Địa Chỉ";
            this.DiaChi_Chan.Name = "DiaChi_Chan";
            this.DiaChi_Chan.Width = 200;
            // 
            // TongCong_Chan
            // 
            this.TongCong_Chan.DataPropertyName = "TongCong";
            this.TongCong_Chan.HeaderText = "Tổng Cộng";
            this.TongCong_Chan.Name = "TongCong_Chan";
            // 
            // To_Chan
            // 
            this.To_Chan.DataPropertyName = "To";
            this.To_Chan.HeaderText = "Tổ";
            this.To_Chan.Name = "To_Chan";
            this.To_Chan.Width = 40;
            // 
            // HanhThu_Chan
            // 
            this.HanhThu_Chan.DataPropertyName = "HanhThu";
            this.HanhThu_Chan.HeaderText = "Hành Thu";
            this.HanhThu_Chan.Name = "HanhThu_Chan";
            // 
            // TienDu
            // 
            this.TienDu.DataPropertyName = "TienDu";
            this.TienDu.HeaderText = "Tiền Dư";
            this.TienDu.Name = "TienDu";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(310, 244);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(52, 250);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(86, 17);
            this.chkAll.TabIndex = 7;
            this.chkAll.Text = "Chặn Tất Cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // frmChanTienDu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 654);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvDSChanTienDu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label1);
            this.Name = "frmChanTienDu";
            this.Text = "Chặn Tiền Dư";
            this.Load += new System.EventHandler(this.frmChanTienDu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSChanTienDu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvDSChanTienDu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD_HD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_HD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_HD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_HD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_HD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_HD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_HD;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_HD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu_HD;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChanTienDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChanTienDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_Chan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_Chan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_Chan;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_Chan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_Chan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_Chan;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_Chan;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu_Chan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienDu;
    }
}