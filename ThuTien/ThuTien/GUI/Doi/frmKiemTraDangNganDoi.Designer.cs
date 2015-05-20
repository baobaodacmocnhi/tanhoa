namespace ThuTien.GUI.Doi
{
    partial class frmKiemTraDangNganDoi
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
            this.txtTongCong_CQ = new System.Windows.Forms.TextBox();
            this.txtTongHD_CQ = new System.Windows.Forms.TextBox();
            this.dgvHDCoQuan = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.tabCoQuan = new System.Windows.Forms.TabPage();
            this.txtTongCong_TG = new System.Windows.Forms.TextBox();
            this.txtTongHD_TG = new System.Windows.Forms.TextBox();
            this.tabTuGia = new System.Windows.Forms.TabPage();
            this.dgvHDTuGia = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateDangNgan = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.MaHD_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTo_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTo_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuMLT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenMLT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuSoPhatHanh_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenSoPhatHanh_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHD_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHD_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTo_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTo_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuMLT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenMLT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuSoPhatHanh_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenSoPhatHanh_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHD_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).BeginInit();
            this.tabCoQuan.SuspendLayout();
            this.tabTuGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTongCong_CQ
            // 
            this.txtTongCong_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_CQ.Location = new System.Drawing.Point(562, 401);
            this.txtTongCong_CQ.Name = "txtTongCong_CQ";
            this.txtTongCong_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_CQ.TabIndex = 5;
            this.txtTongCong_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongHD_CQ
            // 
            this.txtTongHD_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD_CQ.Location = new System.Drawing.Point(479, 401);
            this.txtTongHD_CQ.Name = "txtTongHD_CQ";
            this.txtTongHD_CQ.Size = new System.Drawing.Size(80, 20);
            this.txtTongHD_CQ.TabIndex = 4;
            this.txtTongHD_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvHDCoQuan
            // 
            this.dgvHDCoQuan.AllowUserToAddRows = false;
            this.dgvHDCoQuan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDCoQuan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHDCoQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDCoQuan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD_CQ,
            this.MaTo_CQ,
            this.TenTo_CQ,
            this.TuMLT_CQ,
            this.DenMLT_CQ,
            this.TuSoPhatHanh_CQ,
            this.DenSoPhatHanh_CQ,
            this.TongHD_CQ,
            this.TongCong_CQ});
            this.dgvHDCoQuan.Location = new System.Drawing.Point(6, 6);
            this.dgvHDCoQuan.MultiSelect = false;
            this.dgvHDCoQuan.Name = "dgvHDCoQuan";
            this.dgvHDCoQuan.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDCoQuan.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHDCoQuan.Size = new System.Drawing.Size(679, 395);
            this.dgvHDCoQuan.TabIndex = 1;
            this.dgvHDCoQuan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDCoQuan_CellFormatting);
            this.dgvHDCoQuan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDCoQuan_RowPostPaint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày Đăng Ngân:";
            // 
            // tabCoQuan
            // 
            this.tabCoQuan.Controls.Add(this.txtTongCong_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongHD_CQ);
            this.tabCoQuan.Controls.Add(this.dgvHDCoQuan);
            this.tabCoQuan.Location = new System.Drawing.Point(4, 22);
            this.tabCoQuan.Name = "tabCoQuan";
            this.tabCoQuan.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoQuan.Size = new System.Drawing.Size(693, 442);
            this.tabCoQuan.TabIndex = 1;
            this.tabCoQuan.Text = "Cơ Quan";
            this.tabCoQuan.UseVisualStyleBackColor = true;
            // 
            // txtTongCong_TG
            // 
            this.txtTongCong_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_TG.Location = new System.Drawing.Point(562, 401);
            this.txtTongCong_TG.Name = "txtTongCong_TG";
            this.txtTongCong_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_TG.TabIndex = 3;
            this.txtTongCong_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongHD_TG
            // 
            this.txtTongHD_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD_TG.Location = new System.Drawing.Point(479, 401);
            this.txtTongHD_TG.Name = "txtTongHD_TG";
            this.txtTongHD_TG.Size = new System.Drawing.Size(80, 20);
            this.txtTongHD_TG.TabIndex = 2;
            this.txtTongHD_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabTuGia
            // 
            this.tabTuGia.Controls.Add(this.txtTongCong_TG);
            this.tabTuGia.Controls.Add(this.txtTongHD_TG);
            this.tabTuGia.Controls.Add(this.dgvHDTuGia);
            this.tabTuGia.Location = new System.Drawing.Point(4, 22);
            this.tabTuGia.Name = "tabTuGia";
            this.tabTuGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabTuGia.Size = new System.Drawing.Size(693, 442);
            this.tabTuGia.TabIndex = 0;
            this.tabTuGia.Text = "Tư Gia";
            this.tabTuGia.UseVisualStyleBackColor = true;
            // 
            // dgvHDTuGia
            // 
            this.dgvHDTuGia.AllowUserToAddRows = false;
            this.dgvHDTuGia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDTuGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHDTuGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDTuGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD_TG,
            this.MaTo_TG,
            this.TenTo_TG,
            this.TuMLT_TG,
            this.DenMLT_TG,
            this.TuSoPhatHanh_TG,
            this.DenSoPhatHanh_TG,
            this.TongHD_TG,
            this.TongCong_TG});
            this.dgvHDTuGia.Location = new System.Drawing.Point(6, 6);
            this.dgvHDTuGia.MultiSelect = false;
            this.dgvHDTuGia.Name = "dgvHDTuGia";
            this.dgvHDTuGia.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDTuGia.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHDTuGia.Size = new System.Drawing.Size(679, 395);
            this.dgvHDTuGia.TabIndex = 0;
            this.dgvHDTuGia.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDTuGia_CellFormatting);
            this.dgvHDTuGia.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDTuGia_RowPostPaint);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTuGia);
            this.tabControl.Controls.Add(this.tabCoQuan);
            this.tabControl.Location = new System.Drawing.Point(12, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(701, 468);
            this.tabControl.TabIndex = 5;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(466, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 4;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateDangNgan
            // 
            this.dateDangNgan.CustomFormat = "dd/MM/yyyy";
            this.dateDangNgan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDangNgan.Location = new System.Drawing.Point(365, 12);
            this.dateDangNgan.Name = "dateDangNgan";
            this.dateDangNgan.Size = new System.Drawing.Size(95, 20);
            this.dateDangNgan.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổ:";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(139, 12);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(121, 21);
            this.cmbTo.TabIndex = 1;
            // 
            // MaHD_CQ
            // 
            this.MaHD_CQ.DataPropertyName = "MaHD";
            this.MaHD_CQ.HeaderText = "MaHD";
            this.MaHD_CQ.Name = "MaHD_CQ";
            this.MaHD_CQ.ReadOnly = true;
            this.MaHD_CQ.Visible = false;
            // 
            // MaTo_CQ
            // 
            this.MaTo_CQ.DataPropertyName = "MaTo";
            this.MaTo_CQ.HeaderText = "MaTo";
            this.MaTo_CQ.Name = "MaTo_CQ";
            this.MaTo_CQ.ReadOnly = true;
            this.MaTo_CQ.Visible = false;
            // 
            // TenTo_CQ
            // 
            this.TenTo_CQ.DataPropertyName = "TenTo";
            this.TenTo_CQ.HeaderText = "Tên Tổ";
            this.TenTo_CQ.Name = "TenTo_CQ";
            this.TenTo_CQ.ReadOnly = true;
            // 
            // TuMLT_CQ
            // 
            this.TuMLT_CQ.DataPropertyName = "TuMLT";
            this.TuMLT_CQ.HeaderText = "Từ MLT";
            this.TuMLT_CQ.Name = "TuMLT_CQ";
            this.TuMLT_CQ.ReadOnly = true;
            this.TuMLT_CQ.Width = 80;
            // 
            // DenMLT_CQ
            // 
            this.DenMLT_CQ.DataPropertyName = "DenMLT";
            this.DenMLT_CQ.HeaderText = "Đến MLT";
            this.DenMLT_CQ.Name = "DenMLT_CQ";
            this.DenMLT_CQ.ReadOnly = true;
            this.DenMLT_CQ.Width = 80;
            // 
            // TuSoPhatHanh_CQ
            // 
            this.TuSoPhatHanh_CQ.DataPropertyName = "TuSoPhatHanh";
            this.TuSoPhatHanh_CQ.HeaderText = "Từ Số Phát Hành";
            this.TuSoPhatHanh_CQ.Name = "TuSoPhatHanh_CQ";
            this.TuSoPhatHanh_CQ.ReadOnly = true;
            this.TuSoPhatHanh_CQ.Width = 85;
            // 
            // DenSoPhatHanh_CQ
            // 
            this.DenSoPhatHanh_CQ.DataPropertyName = "DenSoPhatHanh";
            this.DenSoPhatHanh_CQ.HeaderText = "Đến Số Phát Hành";
            this.DenSoPhatHanh_CQ.Name = "DenSoPhatHanh_CQ";
            this.DenSoPhatHanh_CQ.ReadOnly = true;
            this.DenSoPhatHanh_CQ.Width = 90;
            // 
            // TongHD_CQ
            // 
            this.TongHD_CQ.DataPropertyName = "TongHD";
            this.TongHD_CQ.HeaderText = "Tổng HĐ";
            this.TongHD_CQ.Name = "TongHD_CQ";
            this.TongHD_CQ.ReadOnly = true;
            this.TongHD_CQ.Width = 80;
            // 
            // TongCong_CQ
            // 
            this.TongCong_CQ.DataPropertyName = "TongCong";
            this.TongCong_CQ.HeaderText = "Tổng Cộng";
            this.TongCong_CQ.Name = "TongCong_CQ";
            this.TongCong_CQ.ReadOnly = true;
            // 
            // MaHD_TG
            // 
            this.MaHD_TG.DataPropertyName = "MaHD";
            this.MaHD_TG.HeaderText = "MaHD";
            this.MaHD_TG.Name = "MaHD_TG";
            this.MaHD_TG.ReadOnly = true;
            this.MaHD_TG.Visible = false;
            // 
            // MaTo_TG
            // 
            this.MaTo_TG.DataPropertyName = "MaTo";
            this.MaTo_TG.HeaderText = "MaTo";
            this.MaTo_TG.Name = "MaTo_TG";
            this.MaTo_TG.ReadOnly = true;
            this.MaTo_TG.Visible = false;
            // 
            // TenTo_TG
            // 
            this.TenTo_TG.DataPropertyName = "TenTo";
            this.TenTo_TG.HeaderText = "Tên Tổ";
            this.TenTo_TG.Name = "TenTo_TG";
            this.TenTo_TG.ReadOnly = true;
            // 
            // TuMLT_TG
            // 
            this.TuMLT_TG.DataPropertyName = "TuMLT";
            this.TuMLT_TG.HeaderText = "Từ MLT";
            this.TuMLT_TG.Name = "TuMLT_TG";
            this.TuMLT_TG.ReadOnly = true;
            this.TuMLT_TG.Width = 80;
            // 
            // DenMLT_TG
            // 
            this.DenMLT_TG.DataPropertyName = "DenMLT";
            this.DenMLT_TG.HeaderText = "Đến MLT";
            this.DenMLT_TG.Name = "DenMLT_TG";
            this.DenMLT_TG.ReadOnly = true;
            this.DenMLT_TG.Width = 80;
            // 
            // TuSoPhatHanh_TG
            // 
            this.TuSoPhatHanh_TG.DataPropertyName = "TuSoPhatHanh";
            this.TuSoPhatHanh_TG.HeaderText = "Từ Số Phát Hành";
            this.TuSoPhatHanh_TG.Name = "TuSoPhatHanh_TG";
            this.TuSoPhatHanh_TG.ReadOnly = true;
            this.TuSoPhatHanh_TG.Width = 85;
            // 
            // DenSoPhatHanh_TG
            // 
            this.DenSoPhatHanh_TG.DataPropertyName = "DenSoPhatHanh";
            this.DenSoPhatHanh_TG.HeaderText = "Đến Số Phát Hành";
            this.DenSoPhatHanh_TG.Name = "DenSoPhatHanh_TG";
            this.DenSoPhatHanh_TG.ReadOnly = true;
            this.DenSoPhatHanh_TG.Width = 90;
            // 
            // TongHD_TG
            // 
            this.TongHD_TG.DataPropertyName = "TongHD";
            this.TongHD_TG.HeaderText = "Tổng HĐ";
            this.TongHD_TG.Name = "TongHD_TG";
            this.TongHD_TG.ReadOnly = true;
            this.TongHD_TG.Width = 80;
            // 
            // TongCong_TG
            // 
            this.TongCong_TG.DataPropertyName = "TongCong";
            this.TongCong_TG.HeaderText = "Tổng Cộng";
            this.TongCong_TG.Name = "TongCong_TG";
            this.TongCong_TG.ReadOnly = true;
            // 
            // frmKiemTraDangNganDoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 519);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateDangNgan);
            this.Name = "frmKiemTraDangNganDoi";
            this.Text = "Kiểm Tra Đăng Ngân Đội";
            this.Load += new System.EventHandler(this.frmKiemTraDangNganDoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).EndInit();
            this.tabCoQuan.ResumeLayout(false);
            this.tabCoQuan.PerformLayout();
            this.tabTuGia.ResumeLayout(false);
            this.tabTuGia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTongCong_CQ;
        private System.Windows.Forms.TextBox txtTongHD_CQ;
        private System.Windows.Forms.DataGridView dgvHDCoQuan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabCoQuan;
        private System.Windows.Forms.TextBox txtTongCong_TG;
        private System.Windows.Forms.TextBox txtTongHD_TG;
        private System.Windows.Forms.TabPage tabTuGia;
        private System.Windows.Forms.DataGridView dgvHDTuGia;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateDangNgan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTo_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTo_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuMLT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenMLT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuSoPhatHanh_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenSoPhatHanh_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHD_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTo_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTo_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuMLT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenMLT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuSoPhatHanh_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenSoPhatHanh_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHD_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_TG;
    }
}