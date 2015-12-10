namespace ThuTien.GUI.ToTruong
{
    partial class frmTongHopNo
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKinhGui = new System.Windows.Forms.TextBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCSM = new System.Windows.Forms.TextBox();
            this.txtCSC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDM = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateThanhToan = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNguoiKy = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Danh Bộ:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(70, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 17;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Kính Gửi:";
            // 
            // txtKinhGui
            // 
            this.txtKinhGui.Location = new System.Drawing.Point(277, 12);
            this.txtKinhGui.Name = "txtKinhGui";
            this.txtKinhGui.Size = new System.Drawing.Size(250, 20);
            this.txtKinhGui.TabIndex = 19;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
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
            this.MaHD,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.Ky,
            this.GiaBieu,
            this.DinhMuc,
            this.TieuThu,
            this.GiaBan,
            this.ThueGTGT,
            this.PhiBVMT,
            this.TongCong});
            this.dgvHoaDon.Location = new System.Drawing.Point(12, 38);
            this.dgvHoaDon.Name = "dgvHoaDon";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.Size = new System.Drawing.Size(1183, 480);
            this.dgvHoaDon.TabIndex = 21;
            this.dgvHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellContentClick);
            this.dgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHoaDon_CellFormatting);
            this.dgvHoaDon.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvHoaDon_CellValidating);
            this.dgvHoaDon.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHoaDon_RowPostPaint);
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.Name = "MaHD";
            this.MaHD.Visible = false;
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
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.Width = 50;
            // 
            // GiaBieu
            // 
            this.GiaBieu.DataPropertyName = "GiaBieu";
            this.GiaBieu.HeaderText = "Giá Biểu";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.Width = 80;
            // 
            // DinhMuc
            // 
            this.DinhMuc.DataPropertyName = "DinhMuc";
            this.DinhMuc.HeaderText = "Định Mức";
            this.DinhMuc.Name = "DinhMuc";
            this.DinhMuc.Width = 80;
            // 
            // TieuThu
            // 
            this.TieuThu.DataPropertyName = "TieuThu";
            this.TieuThu.HeaderText = "Tiêu Thụ";
            this.TieuThu.Name = "TieuThu";
            this.TieuThu.Width = 80;
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "GiaBan";
            this.GiaBan.HeaderText = "Giá Bán";
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.Width = 80;
            // 
            // ThueGTGT
            // 
            this.ThueGTGT.DataPropertyName = "ThueGTGT";
            this.ThueGTGT.HeaderText = "Thuế GTGT";
            this.ThueGTGT.Name = "ThueGTGT";
            // 
            // PhiBVMT
            // 
            this.PhiBVMT.DataPropertyName = "PhiBVMT";
            this.PhiBVMT.HeaderText = "Phí BVMT";
            this.PhiBVMT.Name = "PhiBVMT";
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(533, 10);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 35;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "(enter)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(614, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "CSM:";
            // 
            // txtCSM
            // 
            this.txtCSM.Location = new System.Drawing.Point(653, 12);
            this.txtCSM.Name = "txtCSM";
            this.txtCSM.Size = new System.Drawing.Size(50, 20);
            this.txtCSM.TabIndex = 38;
            // 
            // txtCSC
            // 
            this.txtCSC.Location = new System.Drawing.Point(748, 12);
            this.txtCSC.Name = "txtCSC";
            this.txtCSC.Size = new System.Drawing.Size(50, 20);
            this.txtCSC.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(709, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "CSC:";
            // 
            // txtTT
            // 
            this.txtTT.Location = new System.Drawing.Point(834, 12);
            this.txtTT.Name = "txtTT";
            this.txtTT.Size = new System.Drawing.Size(50, 20);
            this.txtTT.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(804, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "TT:";
            // 
            // txtDM
            // 
            this.txtDM.Location = new System.Drawing.Point(923, 12);
            this.txtDM.Name = "txtDM";
            this.txtDM.Size = new System.Drawing.Size(50, 20);
            this.txtDM.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(890, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "ĐM:";
            // 
            // dateThanhToan
            // 
            this.dateThanhToan.CustomFormat = "dd/MM/yyyy";
            this.dateThanhToan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateThanhToan.Location = new System.Drawing.Point(1037, 13);
            this.dateThanhToan.Name = "dateThanhToan";
            this.dateThanhToan.Size = new System.Drawing.Size(100, 20);
            this.dateThanhToan.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(979, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Ngày TT:";
            // 
            // txtNguoiKy
            // 
            this.txtNguoiKy.Location = new System.Drawing.Point(1202, 12);
            this.txtNguoiKy.Name = "txtNguoiKy";
            this.txtNguoiKy.Size = new System.Drawing.Size(100, 20);
            this.txtNguoiKy.TabIndex = 48;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1143, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Người Ký:";
            // 
            // frmTongHopNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 531);
            this.Controls.Add(this.txtNguoiKy);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateThanhToan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDM);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCSC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCSM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKinhGui);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDanhBo);
            this.Name = "frmTongHopNo";
            this.Text = "Tổng Hợp Nợ";
            this.Load += new System.EventHandler(this.frmTongHopNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKinhGui;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCSM;
        private System.Windows.Forms.TextBox txtCSC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DateTimePicker dateThanhToan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNguoiKy;
        private System.Windows.Forms.Label label9;
    }
}