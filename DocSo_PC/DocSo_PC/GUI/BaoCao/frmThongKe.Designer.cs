namespace DocSo_PC.GUI.BaoCao
{
    partial class frmThongKe
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
            this.cmbDot = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.lbTo = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.cmbCode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoThan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTieuThu1 = new System.Windows.Forms.TextBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.txtSoKy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkGieng = new System.Windows.Forms.CheckBox();
            this.txtTieuThu2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDot
            // 
            this.cmbDot.FormattingEnabled = true;
            this.cmbDot.Items.AddRange(new object[] {
            "Tất Cả",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbDot.Location = new System.Drawing.Point(367, 12);
            this.cmbDot.Name = "cmbDot";
            this.cmbDot.Size = new System.Drawing.Size(39, 21);
            this.cmbDot.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Đợt";
            // 
            // cmbKy
            // 
            this.cmbKy.FormattingEnabled = true;
            this.cmbKy.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbKy.Location = new System.Drawing.Point(294, 12);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(37, 21);
            this.cmbKy.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Năm ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Kỳ ";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(210, 12);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(50, 21);
            this.cmbNam.TabIndex = 53;
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTo.Location = new System.Drawing.Point(28, 12);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(32, 19);
            this.lbTo.TabIndex = 51;
            this.lbTo.Text = "Tổ:";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbTo.Location = new System.Drawing.Point(66, 12);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(100, 21);
            this.cmbTo.TabIndex = 50;
            this.cmbTo.Visible = false;
            // 
            // cmbCode
            // 
            this.cmbCode.FormattingEnabled = true;
            this.cmbCode.Location = new System.Drawing.Point(450, 12);
            this.cmbCode.Name = "cmbCode";
            this.cmbCode.Size = new System.Drawing.Size(60, 21);
            this.cmbCode.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(412, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "Code";
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo,
            this.MLT,
            this.HoTen,
            this.DiaChi,
            this.Hieu,
            this.Co,
            this.SoThan,
            this.TieuThu,
            this.Phuong,
            this.Quan});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSach.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 39);
            this.dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDanhSach.Size = new System.Drawing.Size(930, 630);
            this.dgvDanhSach.TabIndex = 60;
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.Width = 80;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            // 
            // Hieu
            // 
            this.Hieu.DataPropertyName = "Hieu";
            this.Hieu.HeaderText = "Hiệu";
            this.Hieu.Name = "Hieu";
            this.Hieu.Width = 80;
            // 
            // Co
            // 
            this.Co.DataPropertyName = "Co";
            this.Co.HeaderText = "Cỡ";
            this.Co.Name = "Co";
            this.Co.Width = 50;
            // 
            // SoThan
            // 
            this.SoThan.DataPropertyName = "SoThan";
            this.SoThan.HeaderText = "Số Thân";
            this.SoThan.Name = "SoThan";
            this.SoThan.Width = 80;
            // 
            // TieuThu
            // 
            this.TieuThu.DataPropertyName = "TieuThu";
            this.TieuThu.HeaderText = "Tiêu Thụ";
            this.TieuThu.Name = "TieuThu";
            this.TieuThu.Width = 80;
            // 
            // Phuong
            // 
            this.Phuong.DataPropertyName = "Phuong";
            this.Phuong.HeaderText = "Phường";
            this.Phuong.Name = "Phuong";
            // 
            // Quan
            // 
            this.Quan.DataPropertyName = "Quan";
            this.Quan.HeaderText = "Quận";
            this.Quan.Name = "Quan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Tiêu Thụ >=";
            // 
            // txtTieuThu1
            // 
            this.txtTieuThu1.Location = new System.Drawing.Point(587, 12);
            this.txtTieuThu1.Name = "txtTieuThu1";
            this.txtTieuThu1.Size = new System.Drawing.Size(50, 20);
            this.txtTieuThu1.TabIndex = 62;
            this.txtTieuThu1.Text = "0";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(882, 11);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 63;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // txtSoKy
            // 
            this.txtSoKy.Location = new System.Drawing.Point(826, 13);
            this.txtSoKy.Name = "txtSoKy";
            this.txtSoKy.Size = new System.Drawing.Size(50, 20);
            this.txtSoKy.TabIndex = 65;
            this.txtSoKy.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(770, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Số Kỳ <=";
            // 
            // chkGieng
            // 
            this.chkGieng.AutoSize = true;
            this.chkGieng.Location = new System.Drawing.Point(948, 40);
            this.chkGieng.Name = "chkGieng";
            this.chkGieng.Size = new System.Drawing.Size(54, 17);
            this.chkGieng.TabIndex = 66;
            this.chkGieng.Text = "Giếng";
            this.chkGieng.UseVisualStyleBackColor = true;
            this.chkGieng.CheckedChanged += new System.EventHandler(this.chkGieng_CheckedChanged);
            // 
            // txtTieuThu2
            // 
            this.txtTieuThu2.Location = new System.Drawing.Point(714, 12);
            this.txtTieuThu2.Name = "txtTieuThu2";
            this.txtTieuThu2.Size = new System.Drawing.Size(50, 20);
            this.txtTieuThu2.TabIndex = 68;
            this.txtTieuThu2.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(643, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Tiêu Thụ <=";
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 681);
            this.Controls.Add(this.txtTieuThu2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkGieng);
            this.Controls.Add(this.txtSoKy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.txtTieuThu1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.cmbCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbKy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.cmbTo);
            this.Name = "frmThongKe";
            this.Text = "Thống Kê";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.ComboBox cmbCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTieuThu1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.TextBox txtSoKy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkGieng;
        private System.Windows.Forms.TextBox txtTieuThu2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Co;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoThan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quan;
    }
}