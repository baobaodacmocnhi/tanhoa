namespace ThuTien.GUI.Doi
{
    partial class frmPhanTichDoanhThu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.txtTongTieuThu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongGiaBan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.radGiaBieu = new System.Windows.Forms.RadioButton();
            this.radDinhMuc = new System.Windows.Forms.RadioButton();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.txtTongHD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTuDM = new System.Windows.Forms.TextBox();
            this.lbTuDM = new System.Windows.Forms.Label();
            this.txtDenDM = new System.Windows.Forms.TextBox();
            this.lbDenDM = new System.Windows.Forms.Label();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongDinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBanBinhQuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TyLeTongTieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TyLeTongGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbKy
            // 
            this.cmbKy.FormattingEnabled = true;
            this.cmbKy.Items.AddRange(new object[] {
            "Tất cả",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbKy.Location = new System.Drawing.Point(256, 12);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(50, 21);
            this.cmbKy.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Kỳ:";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(162, 12);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Năm:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(312, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 16;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // txtTongTieuThu
            // 
            this.txtTongTieuThu.Location = new System.Drawing.Point(600, 9);
            this.txtTongTieuThu.Name = "txtTongTieuThu";
            this.txtTongTieuThu.Size = new System.Drawing.Size(100, 20);
            this.txtTongTieuThu.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Sản Lượng:";
            // 
            // txtTongGiaBan
            // 
            this.txtTongGiaBan.Location = new System.Drawing.Point(600, 35);
            this.txtTongGiaBan.Name = "txtTongGiaBan";
            this.txtTongGiaBan.Size = new System.Drawing.Size(100, 20);
            this.txtTongGiaBan.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(530, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Doanh Thu:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(765, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Đã điều chỉnh Hóa Đơn";
            // 
            // radGiaBieu
            // 
            this.radGiaBieu.AutoSize = true;
            this.radGiaBieu.Checked = true;
            this.radGiaBieu.Location = new System.Drawing.Point(37, 12);
            this.radGiaBieu.Name = "radGiaBieu";
            this.radGiaBieu.Size = new System.Drawing.Size(65, 17);
            this.radGiaBieu.TabIndex = 22;
            this.radGiaBieu.TabStop = true;
            this.radGiaBieu.Text = "Giá Biểu";
            this.radGiaBieu.UseVisualStyleBackColor = true;
            this.radGiaBieu.CheckedChanged += new System.EventHandler(this.radGiaBieu_CheckedChanged);
            // 
            // radDinhMuc
            // 
            this.radDinhMuc.AutoSize = true;
            this.radDinhMuc.Location = new System.Drawing.Point(37, 40);
            this.radDinhMuc.Name = "radDinhMuc";
            this.radDinhMuc.Size = new System.Drawing.Size(71, 17);
            this.radDinhMuc.TabIndex = 23;
            this.radDinhMuc.Text = "Định Mức";
            this.radDinhMuc.UseVisualStyleBackColor = true;
            this.radDinhMuc.CheckedChanged += new System.EventHandler(this.radDinhMuc_CheckedChanged);
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDoanhThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Loai,
            this.TongTieuThu,
            this.TongGiaBan,
            this.TongDinhMuc,
            this.GiaBanBinhQuan,
            this.TyLeTongTieuThu,
            this.TyLeTongGiaBan});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDoanhThu.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDoanhThu.Location = new System.Drawing.Point(37, 67);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDoanhThu.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDoanhThu.Size = new System.Drawing.Size(722, 513);
            this.dgvDoanhThu.TabIndex = 24;
            this.dgvDoanhThu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDoanhThu_CellFormatting);
            this.dgvDoanhThu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDoanhThu_RowPostPaint);
            // 
            // txtTongHD
            // 
            this.txtTongHD.Location = new System.Drawing.Point(460, 9);
            this.txtTongHD.Name = "txtTongHD";
            this.txtTongHD.Size = new System.Drawing.Size(66, 20);
            this.txtTongHD.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tổng HĐ:";
            // 
            // txtTuDM
            // 
            this.txtTuDM.Location = new System.Drawing.Point(173, 39);
            this.txtTuDM.Name = "txtTuDM";
            this.txtTuDM.Size = new System.Drawing.Size(30, 20);
            this.txtTuDM.TabIndex = 28;
            this.txtTuDM.Text = "14";
            this.txtTuDM.Visible = false;
            // 
            // lbTuDM
            // 
            this.lbTuDM.AutoSize = true;
            this.lbTuDM.Location = new System.Drawing.Point(124, 42);
            this.lbTuDM.Name = "lbTuDM";
            this.lbTuDM.Size = new System.Drawing.Size(43, 13);
            this.lbTuDM.TabIndex = 27;
            this.lbTuDM.Text = "Từ ĐM:";
            this.lbTuDM.Visible = false;
            // 
            // txtDenDM
            // 
            this.txtDenDM.Location = new System.Drawing.Point(265, 39);
            this.txtDenDM.Name = "txtDenDM";
            this.txtDenDM.Size = new System.Drawing.Size(30, 20);
            this.txtDenDM.TabIndex = 30;
            this.txtDenDM.Text = "32";
            this.txtDenDM.Visible = false;
            // 
            // lbDenDM
            // 
            this.lbDenDM.AutoSize = true;
            this.lbDenDM.Location = new System.Drawing.Point(209, 42);
            this.lbDenDM.Name = "lbDenDM";
            this.lbDenDM.Size = new System.Drawing.Size(50, 13);
            this.lbDenDM.TabIndex = 29;
            this.lbDenDM.Text = "Đến ĐM:";
            this.lbDenDM.Visible = false;
            // 
            // Loai
            // 
            this.Loai.DataPropertyName = "Loai";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Loai.DefaultCellStyle = dataGridViewCellStyle2;
            this.Loai.HeaderText = "Loại";
            this.Loai.Name = "Loai";
            this.Loai.Width = 80;
            // 
            // TongTieuThu
            // 
            this.TongTieuThu.DataPropertyName = "TongTieuThu";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TongTieuThu.DefaultCellStyle = dataGridViewCellStyle3;
            this.TongTieuThu.HeaderText = "Sản Lượng";
            this.TongTieuThu.Name = "TongTieuThu";
            this.TongTieuThu.Width = 90;
            // 
            // TongGiaBan
            // 
            this.TongGiaBan.DataPropertyName = "TongGiaBan";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TongGiaBan.DefaultCellStyle = dataGridViewCellStyle4;
            this.TongGiaBan.HeaderText = "Doanh Thu";
            this.TongGiaBan.Name = "TongGiaBan";
            // 
            // TongDinhMuc
            // 
            this.TongDinhMuc.DataPropertyName = "TongDinhMuc";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TongDinhMuc.DefaultCellStyle = dataGridViewCellStyle5;
            this.TongDinhMuc.HeaderText = "Định Mức";
            this.TongDinhMuc.Name = "TongDinhMuc";
            this.TongDinhMuc.Width = 90;
            // 
            // GiaBanBinhQuan
            // 
            this.GiaBanBinhQuan.DataPropertyName = "GiaBanBinhQuan";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GiaBanBinhQuan.DefaultCellStyle = dataGridViewCellStyle6;
            this.GiaBanBinhQuan.HeaderText = "Giá Bán Bình Quân";
            this.GiaBanBinhQuan.Name = "GiaBanBinhQuan";
            // 
            // TyLeTongTieuThu
            // 
            this.TyLeTongTieuThu.DataPropertyName = "TyLeTongTieuThu";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TyLeTongTieuThu.DefaultCellStyle = dataGridViewCellStyle7;
            this.TyLeTongTieuThu.HeaderText = "Tỷ Lệ Sản Lượng (%)";
            this.TyLeTongTieuThu.Name = "TyLeTongTieuThu";
            // 
            // TyLeTongGiaBan
            // 
            this.TyLeTongGiaBan.DataPropertyName = "TyLeTongGiaBan";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TyLeTongGiaBan.DefaultCellStyle = dataGridViewCellStyle8;
            this.TyLeTongGiaBan.HeaderText = "Tỷ Lệ Doanh Thu (%)";
            this.TyLeTongGiaBan.Name = "TyLeTongGiaBan";
            // 
            // frmPhanTichDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 605);
            this.Controls.Add(this.txtDenDM);
            this.Controls.Add(this.lbDenDM);
            this.Controls.Add(this.txtTuDM);
            this.Controls.Add(this.lbTuDM);
            this.Controls.Add(this.txtTongHD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDoanhThu);
            this.Controls.Add(this.radDinhMuc);
            this.Controls.Add(this.radGiaBieu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTongTieuThu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTongGiaBan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbKy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.label5);
            this.Name = "frmPhanTichDoanhThu";
            this.Text = "Phân Tích Doanh Thu";
            this.Load += new System.EventHandler(this.frmPhanTichDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.TextBox txtTongTieuThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongGiaBan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radGiaBieu;
        private System.Windows.Forms.RadioButton radDinhMuc;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.TextBox txtTongHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTuDM;
        private System.Windows.Forms.Label lbTuDM;
        private System.Windows.Forms.TextBox txtDenDM;
        private System.Windows.Forms.Label lbDenDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongDinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBanBinhQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TyLeTongTieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TyLeTongGiaBan;
    }
}